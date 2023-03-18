using BizExecute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWOR
{
    public class WOR09A
    {
        public static DataSet WOR09A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                //근태 조회
                DataTable dtRslt = DSHP.TSHP_WORK_MNG_QUERY.TSHP_WORK_MNG_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable dtHoliRslt = DLSE.LSE_HOLIDAY_QUERY.LSE_HOLIDAY_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                //연차(W05),경조(W07) 날짜 쪼개기
                DataRow[] dayRows = dtRslt.Select("WORK_CODE IN ('W05','W07')");

                foreach (DataRow row in dayRows)
                {
                    int days = row["REQ_TIME"].toInt() / 480;

                    for (int i = 0; i < days; i++)
                    {
                        DateTime reqDateTime = row["REQ_START_DATE"].toDateTime().AddDays(i);
                        DataRow[] holiRows = dtHoliRslt.Select("HOLI_DATE = '" + reqDateTime.toDateString("yyyyMMdd") + "'");

                        if (holiRows.Length > 0
                            || reqDateTime.DayOfWeek == DayOfWeek.Saturday
                            || reqDateTime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            days++;
                            continue;
                        }

                        DataRow newRow = dtRslt.NewRow();
                        newRow.ItemArray = row.ItemArray;

                        newRow["STR_REQ_DATE"] = reqDateTime.toDateString("yyyyMMdd");
                        newRow["REQ_START_DATE"] = new DateTime(reqDateTime.Year, reqDateTime.Month, reqDateTime.Day, 0, 0, 0);
                        newRow["REQ_END_DATE"] = new DateTime(reqDateTime.Year, reqDateTime.Month, reqDateTime.Day, 0, 0, 0);
                        newRow["REQ_TIME"] = 480;

                        dtRslt.Rows.Add(newRow);
                    }

                    dtRslt.Rows.Remove(row);
                }


                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                //엑셀자료 조회
                DataTable dtRslt2 = DSTD.TSTD_WORKMNG_QUERY.TSTD_WORKMNG_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt2.TableName = "RSLTDT2";

                paramDS.Tables.Add(dtRslt2);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet WOR09A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", "0", typeof(Byte));


                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtRslt = DSTD.TSTD_WORKMNG.TSTD_WORKMNG_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (dtRslt.Rows.Count > 0)
                    {
                        DSTD.TSTD_WORKMNG.TSTD_WORKMNG_UPD(UTIL.GetRowToDt(row), bizExecute);
                    }
                    else
                    {
                        DSTD.TSTD_WORKMNG.TSTD_WORKMNG_INS(UTIL.GetRowToDt(row), bizExecute);
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
