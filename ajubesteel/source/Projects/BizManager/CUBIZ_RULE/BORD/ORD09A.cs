using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BORD
{
    public class ORD09A
    {

        public static DataSet ORD09A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DORD.TORD_PRODUCT_QUERY.TORD_PRODUCT_QUERY16(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt.TableName = "RSLTDT";
                paramDS.Tables.Add(dtRslt);

                foreach (DataRow row in dtRslt.Rows)
                {

                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet ORD09A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DORD.TORD_PRODUCT_QUERY.TORD_PRODUCT_QUERY22(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt.TableName = "RSLTDT";
                paramDS.Tables.Add(dtRslt);

                foreach (DataRow row in dtRslt.Rows)
                {

                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet ORD09A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DORD.TORD_PRODUCT_BILL_QUERY.TORD_PRODUCT_BILL_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt.TableName = "RSLTDT";
                paramDS.Tables.Add(dtRslt);


                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet ORD09A_SER4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DORD.TORD_PRODUCT_BILL_QUERY.TORD_PRODUCT_BILL_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);
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
