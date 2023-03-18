using BizExecute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSTD
{
    public class STD25A
    {
        public static DataSet STD25A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSTD.TSTD_WORKTIME_QUERY.TSTD_WORKTIME_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.Columns.Add("SEL");
                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet STD25A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSTD.TSTD_WORKCODE_QUERY.TSTD_WORKCODE_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet STD25A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", "0", typeof(Byte));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "NOT_WT_ID", "", typeof(string));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    //시간 밸리데이션 추가
                    //추가/수정된 근태시간ID를 제외한 같은 근태 유형의
                    //시간들을 가져옴

                    bool isValid = false;

                    row["NOT_WT_ID"] = row["WT_ID"];
                    DataTable workTable = DSTD.TSTD_WORKTIME_QUERY.TSTD_WORKTIME_QUERY2(UTIL.GetRowToDt(row), bizExecute);

                    DateTime StdTime = DateTime.Now;

                    string startHour = row["WORK_START_HOUR"].ToString().Substring(0, 2);
                    string startMinute = row["WORK_START_HOUR"].ToString().Substring(2, 2);

                    string endHour = row["WORK_END_HOUR"].ToString().Substring(0, 2);
                    string endMinute = row["WORK_END_HOUR"].ToString().Substring(2, 2);

                    DateTime inputStartTime = new DateTime(StdTime.Year, StdTime.Month, StdTime.Day, startHour.toInt(), startMinute.toInt(), 0);

                    if (startHour.toInt() > endHour.toInt())
                    {
                        StdTime = StdTime.AddDays(1);
                    }

                    DateTime inputEndTime = new DateTime(StdTime.Year, StdTime.Month, StdTime.Day, endHour.toInt(), endMinute.toInt(), 0);

                    foreach (DataRow workRow in workTable.Rows)
                    {
                        DateTime CompareTime = DateTime.Now;

                        string starStdtHour = workRow["WORK_START_HOUR"].ToString().Substring(0, 2);
                        string startStdMinute = workRow["WORK_START_HOUR"].ToString().Substring(2, 2);

                        string endStdHour = workRow["WORK_END_HOUR"].ToString().Substring(0, 2);
                        string endStdMinute = workRow["WORK_END_HOUR"].ToString().Substring(2, 2);

                        DateTime CompareStartTime = new DateTime(CompareTime.Year, CompareTime.Month, CompareTime.Day, starStdtHour.toInt(), startStdMinute.toInt(), 0);

                        if (starStdtHour.toInt() > endStdHour.toInt())
                        {
                            CompareTime = CompareTime.AddDays(1);
                        }

                        DateTime CompareEndTime = new DateTime(CompareTime.Year, CompareTime.Month, CompareTime.Day, endStdHour.toInt(), endStdMinute.toInt(), 0);

                        if ((CompareStartTime < inputStartTime
                            && CompareEndTime > inputStartTime)
                            ||
                            (CompareStartTime < inputEndTime
                            && CompareEndTime > inputEndTime))
                        {
                            isValid = true;
                            break;
                        }
                    }


                    DataTable dtRslt = DSTD.TSTD_WORKTIME.TSTD_WORKTIME_SER(UTIL.GetRowToDt(row), bizExecute);

                    //데이터가 있으면 삭제여부 및 덮어쓰기 여부에 따라 update
                    if (dtRslt.Rows.Count > 0)
                    {
                        if (row["OVERWRITE"].Equals("1"))
                        {
                            if (isValid)
                            {
                                throw UTIL.SetException("시간 중복일때 발생"
                                    , row["WORK_CODE"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , 300000);
                            }

                            DSTD.TSTD_WORKTIME.TSTD_WORKTIME_UPD(UTIL.GetRowToDt(row), bizExecute);
                        }
                        else
                        {
                            if (dtRslt.Rows[0]["DATA_FLAG"].Equals((byte)2))
                            {

                                throw UTIL.SetException("동일 데이터가 이력이 존재할때 발생"
                                    , row["WORK_CODE"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.OVERWRITE_HISTORY, dtRslt.Rows[0]);

                            }
                            else
                            {
                                throw UTIL.SetException("동일 데이터가 존재할때 발생"
                                    , row["WORK_CODE"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.OVERWRITE);
                            }
                        }
                    }
                    else
                    {
                        if (isValid)
                        {
                            throw UTIL.SetException("시간 중복일때 발생"
                                , row["WORK_CODE"].ToString()
                                , new System.Diagnostics.StackFrame().GetMethod().Name
                                , 300000);
                        }

                        row["WT_ID"] = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "WT", UTIL.emSerialFormat.YYYYMMDD, "", bizExecute);
                        DSTD.TSTD_WORKTIME.TSTD_WORKTIME_INS(UTIL.GetRowToDt(row), bizExecute);
                    }
                }

                return STD25A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet STD25A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", "2", typeof(Byte));

                DSTD.TSTD_WORKTIME.TSTD_WORKTIME_UDE(paramDS.Tables["RQSTDT"], bizExecute);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
    }
}
