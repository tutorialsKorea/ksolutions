using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BENE
{
    public class ENE02A
    {
        public static DataSet ENE02A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                DataTable dtResult =  DSHP.TSHP_DAILYWORK_QUERY.TSHP_DAILYWORK_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);

                dsResult.Tables.Add(dtResult);

                return dsResult;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet ENE02A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DORD.TORD_ITEM_QUERY.TORD_ITEM_QUERY8(paramDS.Tables["RQSTDT"], bizExecute);

                DataSet dsRslt = new DataSet();

                dtRslt.TableName = "RSLTDT";

                dsRslt.Tables.Add(dtRslt);

                return dsRslt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static DataSet ENE02A_SER4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DORD.TORD_PRODUCT_SPEC.TORD_PRODUCT_SPEC_SER(paramDS.Tables["RQSTDT"], bizExecute);

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

    }
}
