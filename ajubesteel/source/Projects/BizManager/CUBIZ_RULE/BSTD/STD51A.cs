using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BSTD
{
    public class STD51A
    {

        public static DataSet STD51A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(byte));

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_TYPE", "B", typeof(string));

                DataTable dtRslt = DSTD.TSTD_ROUTING_QUERY.TSTD_ROUTING_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

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

        public static DataSet STD51A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(byte));

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_TYPE", "M", typeof(string));

                DataTable dtRslt = DSTD.TSTD_ROUTING_QUERY.TSTD_ROUTING_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);

                if(dtRslt.Rows.Count == 0)
                    dtRslt = DSTD.TSTD_ROUTING_QUERY.TSTD_ROUTING_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);


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

        public static DataSet STD51A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(byte));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtSer = DSTD.TSTD_ROUTING.TSTD_ROUTING_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (dtSer.Rows.Count > 0)
                    {
                        DSTD.TSTD_ROUTING.TSTD_ROUTING_UPD(UTIL.GetRowToDt(row), bizExecute);
                    }
                    else
                    {
                        string scode = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "S", bizExecute);

                        row["SCODE"] = scode;

                        DSTD.TSTD_ROUTING.TSTD_ROUTING_INS(UTIL.GetRowToDt(row), bizExecute);
                    }

                }

                DataTable dtRslt = DSTD.TSTD_ROUTING_QUERY.TSTD_ROUTING_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

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


        public static DataSet STD51A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 2, typeof(byte));

                DSTD.TSTD_ROUTING.TSTD_ROUTING_UDE(paramDS.Tables["RQSTDT"], bizExecute);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
    }
}
