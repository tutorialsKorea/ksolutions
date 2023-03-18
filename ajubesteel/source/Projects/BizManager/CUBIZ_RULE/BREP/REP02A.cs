using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BREP
{
    public class REP02A
    {
     
        /// <summary>
        /// 설비별 일별 가동 시간 현황
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet REP02A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DPOP.TPOP_MC_ACTUAL_QUERY.TPOP_MC_ACTUAL_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.Columns.Add("SEL");
                dtRslt.TableName = "RSLTDT";


                DataTable dtRsltMc = DLSE.LSE_MACHINE_QUERY.LSE_MACHINE_QUERY5(paramDS.Tables["RQSTDT"], bizExecute);

                dtRsltMc.Columns.Add("SEL");
                dtRsltMc.TableName = "RSLTDT_MC";


                paramDS.Tables.Add(dtRslt);
                paramDS.Tables.Add(dtRsltMc);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }
    }
}
