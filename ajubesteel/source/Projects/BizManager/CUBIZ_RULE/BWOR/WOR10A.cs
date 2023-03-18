using BizExecute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWOR
{
    public class WOR10A
    {
        public static DataSet WOR10A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSHP.TSHP_WORK_MNG_QUERY.TSHP_WORK_MNG_QUERY7(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.Columns.Add("SEL");
                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                //if (paramDS.Tables["RQSTDT"].Columns.Contains("S_REQ_DATE"))
                //{
                //    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "REQ_YEAR", paramDS.Tables["RQSTDT"].Rows[0]["S_REQ_DATE"].ToString().Substring(0, 4), typeof(string));
                //}
                //else
                //{
                //    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "REQ_YEAR", paramDS.Tables["RQSTDT"].Rows[0]["REQ_START_DATE"].ToString().Substring(0, 4), typeof(string));
                //}
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "S_REQ_DATE", null, typeof(string));
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "E_REQ_DATE", null, typeof(string));
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "REQ_STATUS", "2", typeof(string));

                //DataTable dtYearRslt = DSHP.TSHP_WORK_MNG_QUERY.TSHP_WORK_MNG_QUERY7(paramDS.Tables["RQSTDT"], bizExecute);
                //dtYearRslt.TableName = "RSLTDT_YEAR";
                //paramDS.Tables.Add(dtYearRslt);

                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "IS_USE", "1", typeof(string));
                //DataTable dtEmpHoli = DSTD.TSTD_EMP_HOLI_QUERY.TSTD_EMP_HOLI_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
                //dtEmpHoli.TableName = "RSLTDT_EMP_HOLI";
                //paramDS.Tables.Add(dtEmpHoli);

                //DataTable workDayRslt = DSTD.TSTD_WORKDAY.TSTD_WORKDAY_SER2(paramDS.Tables["RQSTDT"], bizExecute);
                //workDayRslt.TableName = "RSLTDT_WORKDAY";
                //paramDS.Tables.Add(workDayRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
    }
}
