using BizExecute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWOR
{
    public class WOR07A
    {
        public static DataSet WOR07A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSTD.TSTD_EMP_HOLI_QUERY.TSTD_EMP_HOLI_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt.TableName = "RSLTDT";
                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet WOR07A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSTD.TSTD_EMPLOYEE_QUERY.TSTD_EMPLOYEE_QUERY8(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt.TableName = "RSLTDT";
                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet WOR07A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtRslt = DSTD.TSTD_EMPLOYEE.TSTD_EMPLOYEE_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (dtRslt.Rows.Count > 0)
                    {

                        //입사일
                        if (dtRslt.Rows[0]["HIRE_DATE"].ToString() == "")
                        {
                            throw UTIL.SetException("입사일이 등록되지 않았습니다."
                            , row["EMP_CODE"].ToString()
                            , new System.Diagnostics.StackFrame().GetMethod().Name
                            , BizException.ABORT);
                        }
                        string hire_date = dtRslt.Rows[0]["HIRE_DATE"].ToString();
                        string hire_year = hire_date.Length > 0 ? hire_date.Substring(0, 4) : "";
                        string hire_month = hire_date.Length > 0 ? hire_date.Substring(4, 2) : "";
                        string hire_day = hire_date.Length > 0 ? hire_date.Substring(6, 2) : "";

                        //첫회계일
                        //string account_date = dtRslt.Rows[0]["ACCOUNT_DATE"].ToString();
                        string account_date = row["ACCOUNT_DATE"].ToString();
                        string account_year = "";
                        string account_month = account_date.Length > 0 ? account_date.Substring(4, 2) : "";
                        string account_day = account_date.Length > 0 ? account_date.Substring(6, 2) : "";

                        //퇴사일
                        string retire_date = dtRslt.Rows[0]["RETIRE_DATE"].ToString();
                        string retire_year = retire_date.Length > 0 ? retire_date.Substring(0, 4) : "";
                        string retire_month = retire_date.Length > 0 ? retire_date.Substring(4, 2) : "";
                        string retire_day = retire_date.Length > 0 ? retire_date.Substring(6, 2) : "";

                        //회계일:입사일
                        string ac_hi = "0";

                        if (hire_date.Length > 0 && account_date.Length > 0)
                        {
                            //입사월 * 100 + 입사일 > 회계연도 첫월 * 100 + 회계연도 첫일 이면 0
                            //입사월 * 100 + 입사일 = 회계연도 첫월 * 100 + 회계연도 첫일 이면 0
                            //둘다 아니면 2
                            if ((hire_month.toInt() * 100 + hire_day.toInt()) > (account_month.toInt() * 100 + account_day.toInt()))
                            {
                                ac_hi = "0";
                            }
                            else if ((hire_month.toInt() * 100 + hire_day.toInt()) == (account_month.toInt() * 100 + account_day.toInt()))
                            {
                                ac_hi = "1";
                            }
                            else
                            {
                                ac_hi = "2";
                            }
                        }

                        if (ac_hi.toInt() < 2)
                        {
                            account_year = (hire_year.toInt() + 1).ToString();
                        }

                        //첫회계일
                        DateTime accountDatetime = new DateTime(account_year.toInt(), account_month.toInt(), account_day.toInt(), 0, 0, 0);
                        account_date = accountDatetime.toDateString("yyyyMMdd");

                        //초년월수 - 입사일에서 첫회계일 뺴기 하루까지의 월수
                        DateTime hireDatetime = hire_date.toDateTime();
                        DateTime retireDatetime = retire_date != "" ? retire_date.toDateTime() : "9998-12-31".toDateTime();
                        DateTime accountDatetimeTemp = accountDatetime.AddDays(-1);

                        string firstMonth = (accountDatetimeTemp.Month - hireDatetime.Month).ToString();

                        //재직월수
                        //퇴사하지 않았으면 1200(100년)
                        //퇴사했으면 입사일 부터 퇴사일+1까지의 월
                        string workMonth = "1200";

                        if (retire_date != "")
                        {
                            DateTime retireDatetimeTemp = retireDatetime.AddDays(1);
                            workMonth = (hireDatetime.Month - retireDatetimeTemp.Month).ToString();
                        }

                        //대상자
                        //string target_date = dtRslt.Rows[0]["TARGET_DATE"].ToString();
                        string target_date = row["TARGET_DATE"].ToString();

                        //시행일자
                        //string enfor_date = dtRslt.Rows[0]["ENFOR_DATE"].ToString();
                        string enfor_date = row["ENFOR_DATE"].ToString();

                        //////////////////////////////



                        DataTable paramTable = new DataTable("RQSTDT");
                        paramTable.Columns.Add("PLT_CODE", typeof(string));
                        paramTable.Columns.Add("EMP_CODE", typeof(string));
                        paramTable.Columns.Add("EH_SEQ", typeof(string));
                        paramTable.Columns.Add("AC_HI", typeof(string));
                        paramTable.Columns.Add("FIRST_MONTH", typeof(string));
                        paramTable.Columns.Add("WORK_MONTH", typeof(string));
                        paramTable.Columns.Add("ACCOUNT_CNT", typeof(string));
                        paramTable.Columns.Add("ACCOUNT_CALC_DATE", typeof(string));
                        paramTable.Columns.Add("EMP_STATUS", typeof(string));
                        paramTable.Columns.Add("WORK_YEAR", typeof(string));
                        paramTable.Columns.Add("HOLI_OCCUR_DATE", typeof(string));
                        paramTable.Columns.Add("HOLI_OCCUR_CNT", typeof(decimal));
                        paramTable.Columns.Add("IS_USE", typeof(string));
                        paramTable.Columns.Add("DATA_FLAG", typeof(byte));

                        //회계연수
                        int account_cnt = -2;

                        for (int i = 0; i < 24; i++)
                        {
                            if (i != 2)
                            {
                                account_cnt++;
                            }

                            //회계산정일
                            //년 - 회계일:입사일이 2보다 작으면 입사년 + 회계연수 + 1
                            //      2보다 크면 입사년 + 회계연수
                            //월 - 회계월
                            //일 - 회계일
                            int year = 0;
                            if (ac_hi.toInt() < 2)
                            {
                                year = hire_year.toInt() + account_cnt + 1;
                            }
                            else
                            {
                                year = hire_year.toInt() + account_cnt;
                            }

                            DateTime accountFixDateTime = new DateTime(year, account_month.toInt(), account_day.toInt(), 0, 0, 0);
                            string account_fix_date = accountFixDateTime.toDateString("yyyyMMdd");

                            //재직여부
                            //퇴사일자가 있고 회계산정일 - 1일보다 퇴사일자가 크면 2
                            //회계산정일 - 1일과 퇴사일자가 같으면 1
                            //둘다 아니면 0
                            string work_flag = "0";

                            if (retire_date != "")
                            {
                                accountFixDateTime = accountFixDateTime.AddDays(-1);
                                if (accountFixDateTime > retire_date.toDateTime())
                                {
                                    work_flag = "2";
                                }
                                else if (accountFixDateTime == retire_date.toDateTime())
                                {
                                    work_flag = "1";
                                }

                                accountFixDateTime = accountFixDateTime.AddDays(1);
                            }

                            //근무년차
                            //회계연수 + 2 + "년차"로 표시
                            //1년차는 1년차(월차)
                            //2년차는 2년차, 2년차(월차) 존재
                            //3년차 이후 각년차만 존재
                            string work_year = "";
                            if (work_flag != "2")
                            {
                                if (i == 0 || i == 2)
                                {
                                    work_year = (account_cnt + 2).ToString() + "년차" + "(월차)";
                                }
                                else
                                {
                                    work_year = (account_cnt + 2).ToString() + "년차";
                                }
                            }

                            //휴가발생일자
                            //월차 - "매월" + 입사일자 + "일(1개씩)"
                            //년차 - 재직여부가 2면 빈칸
                            //재직여부가 1이면 퇴사일자
                            //재직여부가 0이면 회계산정일

                            //월차
                            string occur_date = "";
                            if (i == 0 || i == 2)
                            {
                                occur_date = "매월" + hire_day + "일(1개씩)";
                            }
                            else
                            {
                                //년차
                                occur_date = account_fix_date;
                                if (work_flag == "2")
                                {
                                    occur_date = "";
                                }
                                else if (work_flag == "1")
                                {
                                    occur_date = retire_date;
                                }
                            }

                            //휴가발생일수
                            /*
                            1년차(월차) - 첫회계일 - 1일이 퇴사일자보다크면 재직월수 작으면 초년월수

                            2년차
                            재직여부가 2면 빈칸
                            재직여부가 2가 아니면
                                (15 * (회계산정일 - 입사일) / 365) - 입사일자가 대상자보다 크거나 같고 퇴사일자가 시행일자보 크거나 같으면 0 아니면 1년차(월차) 연간 사용일수

                            2년차(월차)
                            재직여부가 2면 빈칸
                            재직여부가 2가 아니면
                                3년차 회계산정일 - 1일이 퇴사일자보다 크면 (재직월수가 11보다 크면 11 아니면 재직월수) - 1년차(월차)휴가발생
                                3년차 회계산정일 - 1일이 퇴사일자보다 작으면 11 - 초년월수

                            3년차
                            재직여부가 2면 빈칸
                            재직여부가 2가 아니면
                                (15 + ((회계연수-1) / 2) ) - 입사일자가 대상자보다크거나 같고 퇴사일자가 시행일자보다 크거나 같으면 0 아니면 2년차(월차)연간사용일수

                            4년차~
                            재직여부가 2면 빈칸
                            재직여부가 2가 아니면
                                15 + ((회계연수 - INT(회계일:입사일이 1이면 0 아니면 1)) / 2)
                            */
                            double holi_day = 0.0;

                            if (i == 0)
                            {
                                //1년차(월차)
                                holi_day = firstMonth.toDouble();
                                if (accountDatetime > retireDatetime)
                                {
                                    holi_day = workMonth.toDouble();
                                }
                            }
                            else if (i == 1)
                            {
                                //2년차
                                if (work_flag != "2")
                                {
                                    TimeSpan ts = accountFixDateTime.Subtract(hireDatetime);
                                    holi_day = 15 * (ts.TotalDays) / 365;

                                    //if (hire_date.toDateTime() >= target_date.toDateTime() && retire_date.toDateTime() >= enfor_date.toDateTime())
                                    //{

                                    //}
                                    //else
                                    //{
                                    //    holi_day = holi_day 
                                    //}
                                }
                            }
                            else if (i == 2)
                            {
                                //2년차(월차)
                                if (work_flag != "2")
                                {
                                    int iCalc1 = workMonth.toInt();
                                    DateTime accountFixDateTimeTemp = accountFixDateTime.AddYears(1).AddDays(-1);
                                    if (accountFixDateTimeTemp > retireDatetime)
                                    {
                                        if (workMonth.toInt() > 11)
                                        {
                                            iCalc1 = 11;
                                        }

                                        holi_day = iCalc1 - holi_day;//(1년차휴가 필요)
                                    }
                                    else
                                    {
                                        holi_day = 11 - firstMonth.toDouble();
                                    }
                                }
                            }
                            else if (i == 3)
                            {
                                //3년차
                                if (work_flag != "2")
                                {
                                    holi_day = 15.0 + ((account_cnt - 1) / 2.0);

                                    if (hireDatetime >= target_date.toDateTime() && retireDatetime >= enfor_date.toDateTime())
                                    {

                                    }
                                    else
                                    {
                                        holi_day = holi_day - 0;//2년차 연간사용일수
                                    }
                                }
                            }
                            else
                            {
                                //4년차~
                                if (work_flag != "2")
                                {
                                    double calc1 = 0.0;

                                    if (ac_hi == "1")
                                    {
                                        calc1 = 0.0;
                                    }
                                    else
                                    {
                                        calc1 = 1.0;
                                    }

                                    holi_day = 15 + Math.Truncate(((account_cnt.toInt() - calc1) / 2));

                                }
                            }


                            DataRow newRow = paramTable.NewRow();
                            newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                            newRow["EMP_CODE"] = row["EMP_CODE"];
                            newRow["EH_SEQ"] = i;
                            newRow["AC_HI"] = ac_hi;
                            newRow["FIRST_MONTH"] = firstMonth;
                            newRow["WORK_MONTH"] = workMonth;
                            newRow["ACCOUNT_CNT"] = account_cnt;
                            newRow["ACCOUNT_CALC_DATE"] = account_fix_date;
                            newRow["EMP_STATUS"] = work_flag;
                            newRow["WORK_YEAR"] = work_year;
                            newRow["HOLI_OCCUR_DATE"] = occur_date;
                            newRow["HOLI_OCCUR_CNT"] = Math.Round(holi_day, 1);
                            newRow["DATA_FLAG"] = "0";

                            paramTable.Rows.Add(newRow);
                        }


                        //현재년기준 적용연차수 설정
                        //계산되어 나온 연차저장
                        foreach (DataRow rw in paramTable.Rows)
                        {
                            //현재년기준 적용연차수 설정
                            if (paramDS.Tables["RQSTDT"].Rows[0]["REG_DATE"].toDateString("yyyy") == rw["ACCOUNT_CALC_DATE"].ToString().Substring(0, 4))
                            {
                                if (rw["EMP_STATUS"].ToString() != "2")
                                {
                                    rw["IS_USE"] = "1";
                                }
                            }

                            //계산되어 나온 연차저장
                            DataTable empHoliRslt = DSTD.TSTD_EMP_HOLI.TSTD_EMP_HOLI_SER(UTIL.GetRowToDt(rw), bizExecute);

                            if (empHoliRslt.Rows.Count > 0)
                            {
                                DSTD.TSTD_EMP_HOLI.TSTD_EMP_HOLI_UPD2(UTIL.GetRowToDt(rw), bizExecute);
                            }
                            else
                            {
                                DSTD.TSTD_EMP_HOLI.TSTD_EMP_HOLI_INS(UTIL.GetRowToDt(rw), bizExecute);
                            }

                        }

                    }
                }

                

                return WOR07A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet WOR07A_INS2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtEmpRslt = DSTD.TSTD_EMPLOYEE_QUERY.TSTD_EMPLOYEE_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                foreach (DataRow row in dtEmpRslt.Rows)
                {
                    DataTable dtRslt = DSTD.TSTD_EMPLOYEE.TSTD_EMPLOYEE_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (dtRslt.Rows.Count > 0)
                    {

                        //입사일
                        if (dtRslt.Rows[0]["HIRE_DATE"].ToString() == "")
                        {
                            throw UTIL.SetException("입사일이 등록되지 않은 직원이 있습니다."
                            , row["EMP_CODE"].ToString()
                            , new System.Diagnostics.StackFrame().GetMethod().Name
                            , BizException.ABORT);
                        }

                        string hire_date = dtRslt.Rows[0]["HIRE_DATE"].ToString();
                        string hire_year = hire_date.Length > 0 ? hire_date.Substring(0, 4) : "";
                        string hire_month = hire_date.Length > 0 ? hire_date.Substring(4, 2) : "";
                        string hire_day = hire_date.Length > 0 ? hire_date.Substring(6, 2) : "";

                        //첫회계일
                        //string account_date = dtRslt.Rows[0]["ACCOUNT_DATE"].ToString();
                        string account_date = paramDS.Tables["RQSTDT"].Rows[0]["ACCOUNT_DATE"].ToString();
                        string account_year = "";
                        string account_month = account_date.Length > 0 ? account_date.Substring(4, 2) : "";
                        string account_day = account_date.Length > 0 ? account_date.Substring(6, 2) : "";

                        //퇴사일
                        string retire_date = dtRslt.Rows[0]["RETIRE_DATE"].ToString();
                        string retire_year = retire_date.Length > 0 ? retire_date.Substring(0, 4) : "";
                        string retire_month = retire_date.Length > 0 ? retire_date.Substring(4, 2) : "";
                        string retire_day = retire_date.Length > 0 ? retire_date.Substring(6, 2) : "";

                        //회계일:입사일
                        string ac_hi = "0";

                        if (hire_date.Length > 0 && account_date.Length > 0)
                        {
                            //입사월 * 100 + 입사일 > 회계연도 첫월 * 100 + 회계연도 첫일 이면 0
                            //입사월 * 100 + 입사일 = 회계연도 첫월 * 100 + 회계연도 첫일 이면 0
                            //둘다 아니면 2
                            if ((hire_month.toInt() * 100 + hire_day.toInt()) > (account_month.toInt() * 100 + account_day.toInt()))
                            {
                                ac_hi = "0";
                            }
                            else if ((hire_month.toInt() * 100 + hire_day.toInt()) == (account_month.toInt() * 100 + account_day.toInt()))
                            {
                                ac_hi = "1";
                            }
                            else
                            {
                                ac_hi = "2";
                            }
                        }

                        if (ac_hi.toInt() < 2)
                        {
                            account_year = (hire_year.toInt() + 1).ToString();
                        }

                        //첫회계일
                        DateTime accountDatetime = new DateTime(account_year.toInt(), account_month.toInt(), account_day.toInt(), 0, 0, 0);
                        account_date = accountDatetime.toDateString("yyyyMMdd");

                        //초년월수 - 입사일에서 첫회계일 뺴기 하루까지의 월수
                        DateTime hireDatetime = hire_date.toDateTime();
                        DateTime retireDatetime = retire_date != "" ? retire_date.toDateTime() : "9998-12-31".toDateTime();
                        DateTime accountDatetimeTemp = accountDatetime.AddDays(-1);

                        string firstMonth = (accountDatetimeTemp.Month - hireDatetime.Month).ToString();

                        //재직월수
                        //퇴사하지 않았으면 1200(100년)
                        //퇴사했으면 입사일 부터 퇴사일+1까지의 월
                        string workMonth = "1200";

                        if (retire_date != "")
                        {
                            DateTime retireDatetimeTemp = retireDatetime.AddDays(1);
                            workMonth = (hireDatetime.Month - retireDatetimeTemp.Month).ToString();
                        }

                        //대상자
                        //string target_date = dtRslt.Rows[0]["TARGET_DATE"].ToString();
                        string target_date = paramDS.Tables["RQSTDT"].Rows[0]["TARGET_DATE"].ToString();

                        //시행일자
                        //string enfor_date = dtRslt.Rows[0]["ENFOR_DATE"].ToString();
                        string enfor_date = paramDS.Tables["RQSTDT"].Rows[0]["ENFOR_DATE"].ToString();

                        //////////////////////////////



                        DataTable paramTable = new DataTable("RQSTDT");
                        paramTable.Columns.Add("PLT_CODE", typeof(string));
                        paramTable.Columns.Add("EMP_CODE", typeof(string));
                        paramTable.Columns.Add("EH_SEQ", typeof(string));
                        paramTable.Columns.Add("AC_HI", typeof(string));
                        paramTable.Columns.Add("FIRST_MONTH", typeof(string));
                        paramTable.Columns.Add("WORK_MONTH", typeof(string));
                        paramTable.Columns.Add("ACCOUNT_CNT", typeof(string));
                        paramTable.Columns.Add("ACCOUNT_CALC_DATE", typeof(string));
                        paramTable.Columns.Add("EMP_STATUS", typeof(string));
                        paramTable.Columns.Add("WORK_YEAR", typeof(string));
                        paramTable.Columns.Add("HOLI_OCCUR_DATE", typeof(string));
                        paramTable.Columns.Add("HOLI_OCCUR_CNT", typeof(decimal));
                        paramTable.Columns.Add("IS_USE", typeof(string));
                        paramTable.Columns.Add("DATA_FLAG", typeof(byte));

                        //회계연수
                        int account_cnt = -2;

                        for (int i = 0; i < 24; i++)
                        {
                            if (i != 2)
                            {
                                account_cnt++;
                            }

                            //회계산정일
                            //년 - 회계일:입사일이 2보다 작으면 입사년 + 회계연수 + 1
                            //      2보다 크면 입사년 + 회계연수
                            //월 - 회계월
                            //일 - 회계일
                            int year = 0;
                            if (ac_hi.toInt() < 2)
                            {
                                year = hire_year.toInt() + account_cnt + 1;
                            }
                            else
                            {
                                year = hire_year.toInt() + account_cnt;
                            }

                            DateTime accountFixDateTime = new DateTime(year, account_month.toInt(), account_day.toInt(), 0, 0, 0);
                            string account_fix_date = accountFixDateTime.toDateString("yyyyMMdd");

                            //재직여부
                            //퇴사일자가 있고 회계산정일 - 1일보다 퇴사일자가 크면 2
                            //회계산정일 - 1일과 퇴사일자가 같으면 1
                            //둘다 아니면 0
                            string work_flag = "0";

                            if (retire_date != "")
                            {
                                accountFixDateTime = accountFixDateTime.AddDays(-1);
                                if (accountFixDateTime > retire_date.toDateTime())
                                {
                                    work_flag = "2";
                                }
                                else if (accountFixDateTime == retire_date.toDateTime())
                                {
                                    work_flag = "1";
                                }

                                accountFixDateTime = accountFixDateTime.AddDays(1);
                            }

                            //근무년차
                            //회계연수 + 2 + "년차"로 표시
                            //1년차는 1년차(월차)
                            //2년차는 2년차, 2년차(월차) 존재
                            //3년차 이후 각년차만 존재
                            string work_year = "";
                            if (work_flag != "2")
                            {
                                if (i == 0 || i == 2)
                                {
                                    work_year = (account_cnt + 2).ToString() + "년차" + "(월차)";
                                }
                                else
                                {
                                    work_year = (account_cnt + 2).ToString() + "년차";
                                }
                            }

                            //휴가발생일자
                            //월차 - "매월" + 입사일자 + "일(1개씩)"
                            //년차 - 재직여부가 2면 빈칸
                            //재직여부가 1이면 퇴사일자
                            //재직여부가 0이면 회계산정일

                            //월차
                            string occur_date = "";
                            if (i == 0 || i == 2)
                            {
                                occur_date = "매월" + hire_day + "일(1개씩)";
                            }
                            else
                            {
                                //년차
                                occur_date = account_fix_date;
                                if (work_flag == "2")
                                {
                                    occur_date = "";
                                }
                                else if (work_flag == "1")
                                {
                                    occur_date = retire_date;
                                }
                            }

                            //휴가발생일수
                            /*
                            1년차(월차) - 첫회계일 - 1일이 퇴사일자보다크면 재직월수 작으면 초년월수

                            2년차
                            재직여부가 2면 빈칸
                            재직여부가 2가 아니면
                                (15 * (회계산정일 - 입사일) / 365) - 입사일자가 대상자보다 크거나 같고 퇴사일자가 시행일자보 크거나 같으면 0 아니면 1년차(월차) 연간 사용일수

                            2년차(월차)
                            재직여부가 2면 빈칸
                            재직여부가 2가 아니면
                                3년차 회계산정일 - 1일이 퇴사일자보다 크면 (재직월수가 11보다 크면 11 아니면 재직월수) - 1년차(월차)휴가발생
                                3년차 회계산정일 - 1일이 퇴사일자보다 작으면 11 - 초년월수

                            3년차
                            재직여부가 2면 빈칸
                            재직여부가 2가 아니면
                                (15 + ((회계연수-1) / 2) ) - 입사일자가 대상자보다크거나 같고 퇴사일자가 시행일자보다 크거나 같으면 0 아니면 2년차(월차)연간사용일수

                            4년차~
                            재직여부가 2면 빈칸
                            재직여부가 2가 아니면
                                15 + ((회계연수 - INT(회계일:입사일이 1이면 0 아니면 1)) / 2)
                            */
                            double holi_day = 0.0;

                            if (i == 0)
                            {
                                //1년차(월차)
                                holi_day = firstMonth.toDouble();
                                if (accountDatetime > retireDatetime)
                                {
                                    holi_day = workMonth.toDouble();
                                }
                            }
                            else if (i == 1)
                            {
                                //2년차
                                if (work_flag != "2")
                                {
                                    TimeSpan ts = accountFixDateTime.Subtract(hireDatetime);
                                    holi_day = 15 * (ts.TotalDays) / 365;

                                    //if (hire_date.toDateTime() >= target_date.toDateTime() && retire_date.toDateTime() >= enfor_date.toDateTime())
                                    //{

                                    //}
                                    //else
                                    //{
                                    //    holi_day = holi_day 
                                    //}
                                }
                            }
                            else if (i == 2)
                            {
                                //2년차(월차)
                                if (work_flag != "2")
                                {
                                    int iCalc1 = workMonth.toInt();
                                    DateTime accountFixDateTimeTemp = accountFixDateTime.AddYears(1).AddDays(-1);
                                    if (accountFixDateTimeTemp > retireDatetime)
                                    {
                                        if (workMonth.toInt() > 11)
                                        {
                                            iCalc1 = 11;
                                        }

                                        holi_day = iCalc1 - holi_day;//(1년차휴가 필요)
                                    }
                                    else
                                    {
                                        holi_day = 11 - firstMonth.toDouble();
                                    }
                                }
                            }
                            else if (i == 3)
                            {
                                //3년차
                                if (work_flag != "2")
                                {
                                    holi_day = 15.0 + ((account_cnt - 1) / 2.0);

                                    if (hireDatetime >= target_date.toDateTime() && retireDatetime >= enfor_date.toDateTime())
                                    {

                                    }
                                    else
                                    {
                                        holi_day = holi_day - 0;//2년차 연간사용일수
                                    }
                                }
                            }
                            else
                            {
                                //4년차~
                                if (work_flag != "2")
                                {
                                    double calc1 = 0.0;

                                    if (ac_hi == "1")
                                    {
                                        calc1 = 0.0;
                                    }
                                    else
                                    {
                                        calc1 = 1.0;
                                    }

                                    holi_day = 15 + Math.Truncate(((account_cnt.toInt() - calc1) / 2));

                                }
                            }


                            DataRow newRow = paramTable.NewRow();
                            newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                            newRow["EMP_CODE"] = row["EMP_CODE"];
                            newRow["EH_SEQ"] = i;
                            newRow["AC_HI"] = ac_hi;
                            newRow["FIRST_MONTH"] = firstMonth;
                            newRow["WORK_MONTH"] = workMonth;
                            newRow["ACCOUNT_CNT"] = account_cnt;
                            newRow["ACCOUNT_CALC_DATE"] = account_fix_date;
                            newRow["EMP_STATUS"] = work_flag;
                            newRow["WORK_YEAR"] = work_year;
                            newRow["HOLI_OCCUR_DATE"] = occur_date;
                            newRow["HOLI_OCCUR_CNT"] = Math.Round(holi_day, 1);
                            newRow["DATA_FLAG"] = "0";

                            paramTable.Rows.Add(newRow);
                        }


                        //현재년기준 적용연차수 설정
                        //계산되어 나온 연차저장
                        foreach (DataRow rw in paramTable.Rows)
                        {
                            //현재년기준 적용연차수 설정
                            if (paramDS.Tables["RQSTDT"].Rows[0]["REG_DATE"].toDateString("yyyy") == rw["ACCOUNT_CALC_DATE"].ToString().Substring(0, 4))
                            {
                                if (rw["EMP_STATUS"].ToString() != "2")
                                {
                                    rw["IS_USE"] = "1";
                                }
                            }

                            //계산되어 나온 연차저장
                            DataTable empHoliRslt = DSTD.TSTD_EMP_HOLI.TSTD_EMP_HOLI_SER(UTIL.GetRowToDt(rw), bizExecute);

                            if (empHoliRslt.Rows.Count > 0)
                            {
                                DSTD.TSTD_EMP_HOLI.TSTD_EMP_HOLI_UPD2(UTIL.GetRowToDt(rw), bizExecute);
                            }
                            else
                            {
                                DSTD.TSTD_EMP_HOLI.TSTD_EMP_HOLI_INS(UTIL.GetRowToDt(rw), bizExecute);
                            }

                        }

                    }
                }



                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet WOR07A_UPD(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable empHoliRslt = DSTD.TSTD_EMP_HOLI.TSTD_EMP_HOLI_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (empHoliRslt.Rows.Count == 1)
                    {
                        //적용연차가 설정되어있을때는 초기화
                        if (row["IS_USE"].ToString() == "1")
                        {
                            row["IS_USE"] = "0";
                            DSTD.TSTD_EMP_HOLI.TSTD_EMP_HOLI_UPD3(UTIL.GetRowToDt(row), bizExecute);
                            row["IS_USE"] = "1";
                        }

                        DSTD.TSTD_EMP_HOLI.TSTD_EMP_HOLI_UPD4(UTIL.GetRowToDt(row), bizExecute);

                        if (row["IS_USE"].ToString() == "1")
                        {
                            //같은년차(회계연수, 회계산정일이 같은)가 존재할 경우 적용연차 업데이트
                            DataTable sameEmpHoli = DSTD.TSTD_EMP_HOLI.TSTD_EMP_HOLI_SER2(empHoliRslt, bizExecute);

                            if (sameEmpHoli.Rows.Count > 1)
                            {
                                foreach (DataRow rw in sameEmpHoli.Rows)
                                {
                                    if (row["EMP_CODE"].ToString() == rw["EMP_CODE"].ToString()
                                        && row["EH_SEQ"].toInt() != rw["EH_SEQ"].toInt())
                                    {
                                        rw["IS_USE"] = "1";
                                        DSTD.TSTD_EMP_HOLI.TSTD_EMP_HOLI_UPD5(UTIL.GetRowToDt(rw), bizExecute);
                                    }
                                }
                            }
                        }
                    }

                }

                return WOR07A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet WOR07A_UPD2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtRslt = DSTD.TSTD_EMP_HOLI_QUERY.TSTD_EMP_HOLI_QUERY1(UTIL.GetRowToDt(row), bizExecute);

                    foreach (DataRow rw in dtRslt.Rows)
                    {
                        //rw["HOLI_OCCUR_INPUT_CNT"] = rw["HOLI_OCCUR_CNT"];

                        double cnt = (int)rw["HOLI_OCCUR_CNT"].toDouble();
                        double cntPoint = Math.Round(rw["HOLI_OCCUR_CNT"].toDouble() - cnt, 1);
                        if (cntPoint >= 0.5)
                        {
                            cnt = cnt + 0.5;
                        }

                        rw["HOLI_OCCUR_INPUT_CNT"] = cnt;

                        DSTD.TSTD_EMP_HOLI.TSTD_EMP_HOLI_UPD6(UTIL.GetRowToDt(rw), bizExecute);
                    }
                }

                return WOR07A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet WOR07A_UPD3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtEmpRslt = DSTD.TSTD_EMPLOYEE_QUERY.TSTD_EMPLOYEE_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                foreach (DataRow row in dtEmpRslt.Rows)
                {
                    DataTable dtRslt = DSTD.TSTD_EMP_HOLI_QUERY.TSTD_EMP_HOLI_QUERY1(UTIL.GetRowToDt(row), bizExecute);

                    foreach (DataRow rw in dtRslt.Rows)
                    {
                        //rw["HOLI_OCCUR_INPUT_CNT"] = rw["HOLI_OCCUR_CNT"];

                        double cnt = (int)rw["HOLI_OCCUR_CNT"].toDouble();
                        double cntPoint = Math.Round(rw["HOLI_OCCUR_CNT"].toDouble() - cnt, 1);
                        if (cntPoint >= 0.5)
                        {
                            cnt = cnt + 0.5;
                        }

                        rw["HOLI_OCCUR_INPUT_CNT"] = cnt;

                        DSTD.TSTD_EMP_HOLI.TSTD_EMP_HOLI_UPD6(UTIL.GetRowToDt(rw), bizExecute);
                    }
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
    }
}
