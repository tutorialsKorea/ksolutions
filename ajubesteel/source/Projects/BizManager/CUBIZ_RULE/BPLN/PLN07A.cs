using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BPLN
{
    /// <summary>
    /// 주간 실적 조회
    /// </summary>
    public class PLN07A
    {

        public static DataSet PLN07A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsRslt = new DataSet();

                if (paramDS.Tables["RQSTDT"].Rows.Count > 0)
                {
                    DataTable dtResult = DSHP.TSHP_DAILYWORK_QUERY.TSHP_DAILYWORK_QUERY4(paramDS.Tables["RQSTDT"], bizExecute);
                    dtResult.TableName = "RSLTDT";
                    dtResult.Columns.Add("SEL", typeof(String));

                    dsRslt.Tables.Add(dtResult);
                }

                return dsRslt;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
    }
}
