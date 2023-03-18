using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BHIS
{
    public class HIS04A
    {
        public static DataSet HIS04A_SER1(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DHIS.THIS_PM_PLAN_QUERY.THIS_PM_PLAN_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt.TableName = "RSLTDT";

                DataTable linqTitleRslt = dtRslt.AsEnumerable()
                                                .GroupBy(g=> new {
                                                    PLT_CODE = g["PLT_CODE"],
                                                    MTN_CODE = g["MTN_CODE"],
                                                    MTN_NAME = g["MTN_NAME"]
                                                })
                                                .Select(r => new
                                                {
                                                    PLT_CODE = r.Key.PLT_CODE,
                                                    MTN_CODE = r.Key.MTN_CODE,
                                                    MTN_NAME = r.Key.MTN_NAME
                                                })
                                                .LINQToDataTable();
                linqTitleRslt.TableName = "RSLTDT_TITLE";

                paramDS.Tables.Add(dtRslt);
                paramDS.Tables.Add(linqTitleRslt);



                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet HIS04A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DHIS.THIS_PM_PLAN_QUERY.THIS_PM_PLAN_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt.TableName = "RSLTDT";

                DataTable linqTitleRslt = dtRslt.AsEnumerable()
                                                .GroupBy(g => new {
                                                    PLT_CODE = g["PLT_CODE"],
                                                    MC_CODE = g["MC_CODE"],
                                                    MC_NAME = g["MC_NAME"]
                                                })
                                                .Select(r => new
                                                {
                                                    PLT_CODE = r.Key.PLT_CODE,
                                                    MC_CODE = r.Key.MC_CODE,
                                                    MC_NAME = r.Key.MC_NAME
                                                })
                                                .LINQToDataTable();
                linqTitleRslt.TableName = "RSLTDT_TITLE";

                paramDS.Tables.Add(dtRslt);
                paramDS.Tables.Add(linqTitleRslt);



                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet HIS04A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DHIS.THIS_PM_PLAN.THIS_PM_PLAN_SER(paramDS.Tables["RQSTDT"], bizExecute);
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
