using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BPOP
{
    public class POP07A
    {


        public static DataSet POP07A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "NOT_MC_CODE", "11CL3", typeof(string));

                DataRow paramRow = paramDS.Tables["RQSTDT"].Rows[0];

                DataTable dtRslt = null;


                dtRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY25(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt.Columns.Add("SEL");
                dtRslt.TableName = "RSLTDT";


                DataTable dtRslt2 = DSTD.TSTD_MC_DAILYCAPA_QUERY.TSTD_MC_DAILYCAPA_QUERY6(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt2.Columns.Add("SEL");
                dtRslt2.TableName = "RSLTDT2";


                paramDS.Tables.Add(dtRslt);

                paramDS.Tables.Add(dtRslt2);


                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        

    }
}
