using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BMNT
{
    public class MNT11A
    {

        /// <summary>
        /// 조립현황
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet MNT11A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtResult = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY7(paramDS.Tables["RQSTDT"], bizExecute);
                
                //가공진행중 부품
                //DataTable dtRsltPart = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);
                DataTable dtRsltPart = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY3(dtResult, bizExecute);
                dtRsltPart.TableName = "RSLTDT_PART";

                paramDS.Tables.Add(dtResult);
                paramDS.Tables.Add(dtRsltPart);

                return paramDS;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
        //public static DataSet MNT11A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        //{
        //    try
        //    {
                //if (paramDS.Tables["RQSTDT"].Rows.Count <= 0) return paramDS;

                //string proc_code = ControlManager.acInfo.SysConfig.GetSysConfigByServer("부품정리공정");

                //paramDS.Tables["RQSTDT"].Columns.Add("MPROC_CODE");
                //paramDS.Tables["RQSTDT"].Columns.Add("ASSY_PROC");

                //paramDS.Tables["RQSTDT"].Rows[0]["MPROC_CODE"] = "C001";
                //paramDS.Tables["RQSTDT"].Rows[0]["ASSY_PROC"] = proc_code;

                ////조립 공정 있는 품목만 
                //DataTable dtResult = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY10_2(paramDS.Tables["RQSTDT"], bizExecute);

                //dtResult.Columns.Add("MPROC_CODE", typeof(String));

                //foreach (DataRow dr in dtResult.Rows)
                //{
                //    dr["PROC_CODE"] = "";
                //    dr["MPROC_CODE"] = "C001";
                //}

                ////지시현황
                //DataTable dtRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY15(dtResult, bizExecute);
                //dtRslt.TableName = "RSLTDT";
                
                ////실적현황
                //DataTable dtRsltAct = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY4(paramDS.Tables["RQSTDT"], bizExecute);
                //dtRsltAct.TableName = "RSLTDT_ACT";

                ////가공진행중 부품
                //DataTable dtRsltPart = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);
                //dtRsltPart.TableName = "RSLTDT_PART";

                //paramDS.Tables.Add(dtRslt);
                //paramDS.Tables.Add(dtRsltAct);
                //paramDS.Tables.Add(dtRsltPart);

                //return paramDS;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
        //    }
        //}

        /// <summary>
        /// 출하현황
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet MNT11A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //출하 대상 품목 리스트
                DataTable dtPart = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY8(paramDS.Tables["RQSTDT"], bizExecute);
                
                DataTable dtResult = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY8_2(dtPart, bizExecute);
                dtResult.TableName = "RSLTDT";
                dtPart.TableName = "RSLTDT_PROD";

                paramDS.Tables.Add(dtResult);
                paramDS.Tables.Add(dtPart);
                return paramDS;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
    
    }
}
