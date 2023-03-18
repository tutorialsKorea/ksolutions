using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BREP
{
    public class REP20A
    {
        //월별 공정 품질 비용 현황
        public static DataSet REP20A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRsltNg = DSHP.TSHP_NG_QUERY.TSHP_NG_QUERY5(paramDS.Tables["RQSTDT"], bizExecute);
                dtRsltNg.TableName = "RSLTDT_NG";

                DataTable dtRsltPNg = DQCT.TQCT_PURCHASE_NG_QUERY.TQCT_PURCHASE_NG_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);
                dtRsltPNg.TableName = "RSLTDT_PNG";

                DataTable dtRslt = DSHP.TSHP_NG_QUERY.TSHP_NG_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

                UTIL.SetBizAddColumnToValue(dtRslt, "DATA_FLAG", 0, typeof(Byte), true);
                if (dtRslt.Rows.Count > 0)
                {
                    DataTable dtWo = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY20(dtRslt, bizExecute);

                    DataTable dt = dtRslt.AsEnumerable()
                            .Join(dtWo.AsEnumerable()
                                , wo => wo["ACTUAL_ID"]
                                , rslt => rslt["ACTUAL_ID"]
                                , (rslt, wo) => new
                                {
                                    PLT_CODE = rslt.Field<String>("PLT_CODE"),
                                    EMP_CODE = rslt.Field<String>("EMP_CODE").ToLower(),
                                    NG_QTY = rslt.Field<int>("NG_QTY"),
                                    NG_OUT_COST = rslt.Field<Decimal>("NG_OUT_COST"),
                                    NG_PROC_COST = rslt.Field<Decimal>("NG_PROC_COST"),
                                    IN_COST = wo.Field<byte?>("IS_OS") == 0 ? rslt["QUANTITY"].toDecimal() * wo["PROC_COST"].toDecimal() : 0,
                                    OUT_COST = wo.Field<byte?>("IS_OS") == 1 ? rslt["QUANTITY"].toDecimal() * wo["PROC_COST"].toDecimal() : 0
                                })
                    .GroupBy(g => new { PLT_CODE = g.PLT_CODE, EMP_CODE = g.EMP_CODE })
                    .Select(r => new
                    {
                        PLT_CODE = r.Key.PLT_CODE,
                        EMP_CODE = r.Key.EMP_CODE,
                        TOT_QTY = r.Sum(s=>s.NG_QTY),
                        TOT_COST = (r.Max(m => m.NG_OUT_COST).isNullOrEmpty() ? r.Sum(s => s.OUT_COST.toDecimal()) : r.Max(m => m.NG_OUT_COST.toDecimal()))
                                        + (r.Max(m => m.NG_PROC_COST).isNullOrEmpty() ? r.Sum(s => s.IN_COST.toDecimal()) : r.Max(m => m.NG_PROC_COST.toDecimal()))
                    }).LINQToDataTable();

                    dt.TableName = "RSLTDT_NG_EMP";
                    paramDS.Tables.Add(dt);
                }
                else
                {
                    dtRslt.TableName = "RSLTDT_NG_EMP";
                    paramDS.Tables.Add(dtRslt);
                }

                DataTable dtRsltPNgVen = DQCT.TQCT_PURCHASE_NG_QUERY.TQCT_PURCHASE_NG_QUERY4(paramDS.Tables["RQSTDT"], bizExecute);
                dtRsltPNgVen.TableName = "RSLTDT_PNG_VEN";

                paramDS.Tables.Add(dtRsltNg);
                paramDS.Tables.Add(dtRsltPNg);
                paramDS.Tables.Add(dtRsltPNgVen);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
    }
}
 