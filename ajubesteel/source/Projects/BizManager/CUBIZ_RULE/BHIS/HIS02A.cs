using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BHIS
{
    public class HIS02A
    {
        public static DataSet HIS02A_SER1(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DHIS.THIS_PM_MC_QUERY.THIS_PM_MC_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable linqRslt = dtRslt.AsEnumerable()
                                            .GroupBy(g => new
                                            {
                                                PLT_CODE = g["PLT_CODE"],
                                                MC_GROUP = g["MC_GROUP"],
                                                MC_CODE = g["MC_CODE"],
                                                MC_NAME = g["MC_NAME"],
                                                SCOMMENT = g["M_SCOMMENT"]
                                            })
                                            .Select(r => new
                                            {
                                                PLT_CODE = r.Key.PLT_CODE,
                                                MC_GROUP = r.Key.MC_GROUP,
                                                MC_CODE = r.Key.MC_CODE,
                                                MC_NAME = r.Key.MC_NAME,
                                                SCOMMENT = r.Key.SCOMMENT,
                                                SEL = 0
                                            })
                                            .LINQToDataTable();
                
                linqRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(linqRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet HIS02A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DHIS.THIS_PM_MC_QUERY.THIS_PM_MC_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt.TableName = "RSLTDT";

                UTIL.SetBizAddColumnToValue(dtRslt, "SEL", 1, typeof(Int32), true);
                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet HIS02A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DHIS.THIS_PM_PLAN_QUERY.THIS_PM_PLAN_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet HIS02A_SER4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DHIS.THIS_PM_MC_PARTS_QUERY.THIS_PM_MC_PARTS_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet HIS02A_INS1(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                #region 삭제
                DataTable delDt = paramDS.Tables["RQSTDT"].AsEnumerable()
                                                            .GroupBy(g => new
                                                            {
                                                                PLT_CODE = g["PLT_CODE"],
                                                                MTN_CODE = g["MTN_CODE"],
                                                                MC_CODE = g["MC_CODE"]
                                                            })
                                                            .Select(r => new
                                                            {
                                                                PLT_CODE = r.Key.PLT_CODE,
                                                                MTN_CODE = r.Key.MTN_CODE,
                                                                MC_CODE = r.Key.MC_CODE
                                                            })
                                                            .LINQToDataTable();
                foreach(DataRow delRow in delDt.Rows)
                {
                    DataTable notActDt = DHIS.THIS_PM_PLAN.THIS_PM_PLAN_SER2(UTIL.GetRowToDt(delRow), bizExecute);
                    foreach (DataRow partDelRow in notActDt.Rows)
                    {
                        DHIS.THIS_PM_PLAN_PARTS.THIS_PM_PLAN_PARTS_DEL(UTIL.GetRowToDt(delRow), bizExecute);
                    }

                    DHIS.THIS_PM_PLAN.THIS_PM_PLAN_DEL(UTIL.GetRowToDt(delRow), bizExecute);
                }
                #endregion

                foreach (DataRow paramRow in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable rsltDt = DHIS.THIS_PM_PLAN.THIS_PM_PLAN_SER(UTIL.GetRowToDt(paramRow), bizExecute);

                    if (rsltDt.Rows.Count > 0)
                    {
                        //업데이트는 어떻게 처리할지
                        //DHIS.THIS_PM_PLAN.plan(UTIL.GetRowToDt(paramRow), bizExecute);
                    }
                    else
                    {
                        //입력
                        DHIS.THIS_PM_PLAN.THIS_PM_PLAN_INS(UTIL.GetRowToDt(paramRow), bizExecute);

                        DataTable planPartsDt = DHIS.THIS_PM_PLAN_PARTS_QUERY.THIS_PM_PLAN_PARTS_QUERY1(UTIL.GetRowToDt(paramRow), bizExecute);
                        if (planPartsDt.Rows.Count == 0)
                        {
                            DHIS.THIS_PM_PLAN_PARTS.THIS_PM_PLAN_PARTS_COPY(UTIL.GetRowToDt(paramRow), bizExecute);
                        }
                    }
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
    }
}
