using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BPLN
{


    /// <summary>
    /// 진행 실적
    /// </summary>
    /// <author>신재경</author>
    /// <remarks>
    /// <b>2016.04.04</b> 신규생성<br/>
    /// </remarks>    
    public class PLN04A
    {
        //주차별 실적 정보 가져오기
        public static DataSet PLN04A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DORD.TORD_PRODUCT_QUERY.TORD_PRODUCT_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt.TableName = "RSLTDT";
               
                //DataTable dtTemp = dtRslt.Clone();

                DataRow allRow = dtRslt.NewRow();
                allRow["CVND_NAME"] = string.Format("전체[업체:{0}]", dtRslt.Rows.Count.ToString());

                Int64 wo_cnt = 0;
                Int64 wo_end_cnt = 0;

                foreach (DataRow row in dtRslt.Rows)
                {
                    wo_cnt += row["WO_CNT"].toInt();
                    wo_end_cnt += row["WO_END_CNT"].toInt();
                }

                allRow["WO_CNT"] = wo_cnt;
                allRow["WO_END_CNT"] = wo_end_cnt;
                //dtTemp.Rows.Add(allRow);
                dtRslt.Rows.InsertAt(allRow, 0);
                paramDS.Tables.Add(dtRslt);
                //paramDS.Merge(dtRslt);
                
                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        /// <summary>
        /// 업체의 수주 정보
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet PLN04A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DORD.TORD_PRODUCT_QUERY.TORD_PRODUCT_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

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

        /// <summary>
        /// 작업지시 정보
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet PLN04A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY4(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 작업지시 실적 정보
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet PLN04A_SER4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY23(paramDS.Tables["RQSTDT"], bizExecute);
                DataTable dtRslt2 = DSHP.TSHP_ACTUAL_CAM_QUERY.TSHP_ACTUAL_CAM_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
                DataTable dtRslt3 = DSHP.TSHP_ACTUAL_MILL_QUERY.TSHP_ACTUAL_MILL_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
                DataTable dtRslt4 = DSHP.TSHP_ACTUAL_INS_QUERY.TSHP_ACTUAL_INS_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
                DataTable dtRslt5 = DSHP.TSHP_ACTUAL_ASSY_QUERY.TSHP_ACTUAL_ASSY_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.Merge(dtRslt2);
                dtRslt.Merge(dtRslt3);
                dtRslt.Merge(dtRslt4);
                dtRslt.Merge(dtRslt5);

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
