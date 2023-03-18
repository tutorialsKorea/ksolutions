using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;
//using ControlManager;

namespace BPUR
{
    public class PUR17A
    {
        //공정외주 발주가능건 조회
        public static DataSet PUR17A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DOUT.TOUT_PROCBALJU_QUERY.TOUT_PROCBALJU_QUERY20(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.Columns.Add("SEL");

                dtRslt.TableName = "RSLTDT";

                paramDS.Merge(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

       
    }
}
