using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BPLN
{
    /// <summary>
    /// 일일작업지시현황(확정)
    /// </summary>
    public class PLN05A
    {

        //제품 작업지시 정보
        public static DataSet PLN05A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WO_FLAG", "1", typeof(string));

                DataTable dtRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY24(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable dtToday = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY30(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";
                dtToday.TableName = "RSLTDT_TODAY";

                paramDS.Tables.Add(dtRslt);
                paramDS.Tables.Add(dtToday);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }


    }
}
