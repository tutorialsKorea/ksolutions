using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BPLN
{
    public class PLN13A
    {


        // 품목조회
        public static DataSet PLN13A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DLSE.LSE_STD_PART_QUERY.LSE_STD_PART_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);

               // dtRslt.Columns.Add("SEL", typeof(Byte));

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }



        // 품목별 도면내역 조회
        public static DataSet PLN13A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataTable dtRslt = DIF.IF_MES_DWG.IF_MES_DWG_FILE_SER2(paramDS.Tables["RQSTDT"], bizExecute);
                
                // dtRslt.Columns.Add("SEL", typeof(Byte));

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

    }
}
