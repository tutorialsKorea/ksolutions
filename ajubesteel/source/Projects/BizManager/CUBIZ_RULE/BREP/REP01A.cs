using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BREP
{
    public class REP01A
    {
        public static DataSet REP01A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "IS_WO_PART", "1", typeof(string));

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "IS_NOT_SHIP_FINISH", "1", typeof(string));

                ///part list
                DataTable dtRslt = DMAT.TMAT_PARTLIST_QUERY.TMAT_PARTLIST_QUERY2_1(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt.Columns.Add("SEL");
                dtRslt.Columns.Add("CAM_EMP");
                dtRslt.Columns.Add("CAM_EMP_NAME");
                dtRslt.TableName = "RSLTDT";

                DataTable dtRslt_wo = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY26(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt_wo.Columns.Add("SEL");
                dtRslt_wo.TableName = "RSLTDT_WO";

                paramDS.Tables.Add(dtRslt);
                paramDS.Tables.Add(dtRslt_wo);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        #region 기존 가동률 Rule
        ////일별 가동율 조회
        //public static DataSet REP01A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        //{
        //    try
        //    {
        //        DataTable dtRslt = DSTD.TSTD_MC_DAILYCAPA_QUERY.TSTD_MC_DAILYCAPA_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

        //        dtRslt.Columns.Add("SEL", typeof(string));
        //        dtRslt.TableName = "RSLTDT";

        //        paramDS.Tables.Add(dtRslt);

        //        return paramDS;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
        //    }
        //}

        ////기간별 가동율 조회
        //public static DataSet REP01A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        //{
        //    try
        //    {
        //        DataTable dtRslt = DSTD.TSTD_MC_DAILYCAPA_QUERY.TSTD_MC_DAILYCAPA_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);

        //        dtRslt.Columns.Add("SEL", typeof(string));
        //        dtRslt.TableName = "RSLTDT";

        //        paramDS.Tables.Add(dtRslt);

        //        return paramDS;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
        //    }
        //}

        ////월별(설비) 가동율 조회
        //public static DataSet REP01A_SER4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        //{
        //    try
        //    {
        //        foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
        //        {
        //            DataTable dtRslt = DSTD.TSTD_MC_DAILYCAPA_QUERY.TSTD_MC_DAILYCAPA_QUERY3(UTIL.GetRowToDt(row), bizExecute);


        //            UTIL.SetBizAddColumnToValue(dtRslt, "S_WORK_DATE", row["S_WORK_DATE"], typeof(String));
        //            UTIL.SetBizAddColumnToValue(dtRslt, "E_WORK_DATE", row["E_WORK_DATE"], typeof(String));

        //            dtRslt.Columns.Add("SEL", typeof(string));
        //            dtRslt.TableName = "RSLTDT";
        //            paramDS.Merge(dtRslt);
        //        }

        //        return paramDS;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
        //    }
        //}

        ////월별(설비그룹) 가동율 조회
        //public static DataSet REP01A_SER6(DataSet paramDS, BizExecute.BizExecute bizExecute)
        //{
        //    try
        //    {
        //        foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
        //        {
        //            DataTable dtRslt = DSTD.TSTD_MC_DAILYCAPA_QUERY.TSTD_MC_DAILYCAPA_QUERY4(UTIL.GetRowToDt(row), bizExecute);

        //            UTIL.SetBizAddColumnToValue(dtRslt, "S_WORK_DATE", row["S_WORK_DATE"], typeof(String));
        //            UTIL.SetBizAddColumnToValue(dtRslt, "E_WORK_DATE", row["E_WORK_DATE"], typeof(String));

        //            dtRslt.Columns.Add("SEL", typeof(string));
        //            dtRslt.TableName = "RSLTDT";
        //            paramDS.Merge(dtRslt);
        //        }

        //        return paramDS;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
        //    }
        //}
        #endregion
    }
}
