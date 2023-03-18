using BizExecute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWOR
{
    public class WOR02A
    {
        public static DataSet WOR02A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "REQ_STATUS", "2", typeof(string));

                DataTable dtRslt = DSHP.TSHP_WORK_MNG_QUERY.TSHP_WORK_MNG_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt.TableName = "RSLTDT";
                paramDS.Tables.Add(dtRslt);

                DataTable workDayRslt = DSTD.TSTD_WORKDAY.TSTD_WORKDAY_SER2(paramDS.Tables["RQSTDT"], bizExecute);
                workDayRslt.TableName = "RSLTDT_WORKDAY";
                paramDS.Tables.Add(workDayRslt);

                DataTable dtHoliRslt = DLSE.LSE_HOLIDAY_QUERY.LSE_HOLIDAY_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                dtHoliRslt.TableName = "RSLTDT_HOLI";
                paramDS.Tables.Add(dtHoliRslt);

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "IS_USE", "1", typeof(string));
                DataTable dtEmpHoli = DSTD.TSTD_EMP_HOLI_QUERY.TSTD_EMP_HOLI_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "COMPARE_YEAR", paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].toInt() - DateTime.Now.Year, typeof(int));

                if (dtEmpHoli.Rows.Count > 0
                    && paramDS.Tables["RQSTDT"].Rows[0]["COMPARE_YEAR"].toInt() != 0)
                {
                    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "IS_USE", DBNull.Value, typeof(string));
                    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "ACCOUNT_CALC_YEAR", (dtEmpHoli.Rows[0]["ACCOUNT_CALC_YEAR"].toInt() + paramDS.Tables["RQSTDT"].Rows[0]["COMPARE_YEAR"].toInt()).ToString(), typeof(string));

                    dtEmpHoli = DSTD.TSTD_EMP_HOLI_QUERY.TSTD_EMP_HOLI_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
                }

                dtEmpHoli.TableName = "RSLTDT_EMP_HOLI";
                paramDS.Tables.Add(dtEmpHoli);

                

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
    }
}
