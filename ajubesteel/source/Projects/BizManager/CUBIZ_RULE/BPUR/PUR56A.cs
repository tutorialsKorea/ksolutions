using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BPUR
{
    public class PUR56A
    {

        /// <summary>
        /// 재고 입/출고 등록
        /// 기준일 이전 최근 재고 내역 조회. -> 이전재고량으로 사용
        /// 기준일 이후 재고 내역 조회 -> PREV_QTY, NEXT_QTY UPDATE.
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet PUR56A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_INS"], "PREV_QTY", 0, typeof(int));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_INS"], "NEXT_QTY", 0, typeof(int));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_INS"], "LESS_TIME", "", typeof(String));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_INS"], "MORE_TIME", "", typeof(String));

                DataTable dtParam = paramDS.Tables["RQSTDT_INS"];
                
                int prev_qty = 0, next_qty = 0;
                int in_qty =0, out_qty = 0;
                int sa_qty = 0;

                if (dtParam.Rows.Count > 0)
                {
                    in_qty = dtParam.Rows[0]["IN_QTY"].toInt32();
                    out_qty = dtParam.Rows[0]["OUT_QTY"].toInt32();
                    sa_qty = dtParam.Rows[0]["SA_QTY"].toInt32();

                    //기준일 이전 최근 재고 내역 조회 :
                    dtParam.Rows[0]["LESS_TIME"] = dtParam.Rows[0]["EVENT_TIME"];
                    
                    DataTable dtPrevStock = DSHP.TSHP_STOCK_LOG_QUERY.TSHP_STOCK_LOG_QUERY2(dtParam, bizExecute);

                    if (dtPrevStock.Rows.Count > 0)
                    {
                        int idx = dtPrevStock.Rows.Count;
                        prev_qty = dtPrevStock.Rows[idx-1]["NEXT_QTY"].toInt32();

                        dtParam.Rows[0]["PREV_QTY"] = prev_qty;
                    }

                    if (sa_qty > 0)
                    {
                        next_qty = sa_qty;
                        dtParam.Rows[0]["NEXT_QTY"] = next_qty;
                    }
                    else
                    {
                        next_qty = prev_qty + in_qty - out_qty;
                        dtParam.Rows[0]["NEXT_QTY"] = next_qty;
                    }
                    

                    DSHP.TSHP_STOCK_LOG.TSHP_STOCK_LOG_INS2(dtParam, bizExecute);

                    //기준일 이후 재고 내역 prev_qty, next_qty 업데이트
                    dtParam.Rows[0]["LESS_TIME"] = DBNull.Value;
                    dtParam.Rows[0]["MORE_TIME"] = dtParam.Rows[0]["EVENT_TIME"];
                    DataTable dtNextStock = DSHP.TSHP_STOCK_LOG_QUERY.TSHP_STOCK_LOG_QUERY2(dtParam, bizExecute);

                    foreach(DataRow dr in dtNextStock.Rows)
                    {
                        if (sa_qty > 0)
                            dr["PREV_QTY"] = next_qty;
                        else
                            dr["PREV_QTY"] = dr["PREV_QTY"].toInt32() + next_qty;

                        dr["NEXT_QTY"] = dr["PREV_QTY"].toInt32() + dr["IN_QTY"].toInt32() - dr["OUT_QTY"].toInt32();
                        next_qty = dr["NEXT_QTY"].toInt32();

                        //PLT_CODE,PART_CODE,EVENT_TIME,PREV_QTY,NEXT_QTY
                        DSHP.TSHP_STOCK_LOG.TSHP_STOCK_LOG_UPD(UTIL.GetRowToDt(dr), bizExecute);

                    }

                    
                    //현재고 업데이트
                    DataTable dtPartParam = new DataTable("RQSTDT");
                    dtPartParam.Columns.Add("PLT_CODE", typeof(String));
                    dtPartParam.Columns.Add("PART_CODE", typeof(String));
                    dtPartParam.Columns.Add("STK_QTY", typeof(int));

                    DataRow drParam = dtPartParam.NewRow();
                    drParam["PLT_CODE"] = dtParam.Rows[0]["PLT_CODE"];
                    drParam["PART_CODE"] = dtParam.Rows[0]["PART_CODE"];
                    drParam["STK_QTY"] = next_qty;
                    dtPartParam.Rows.Add(drParam);

                    if (dtParam.Rows[0]["STOCK_TYPE"].ToString() == "S01")  //완재고
                    {
                        DLSE.LSE_STD_PART.LSE_STD_PART_UPD10(dtPartParam, bizExecute);
                    }
                    else
                    {
                        DLSE.LSE_STD_PART.LSE_STD_PART_UPD11(dtPartParam, bizExecute);
                    }
                    
                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramDS.Tables["RQSTDT"].Copy());

                return PUR56A_SER(paramSet, bizExecute);
                
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static void PUR56A_INS2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_INS"], "PREV_QTY", 0, typeof(int));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_INS"], "NEXT_QTY", 0, typeof(int));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_INS"], "LESS_TIME", "", typeof(String));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_INS"], "MORE_TIME", "", typeof(String));

                DataTable dtParam = paramDS.Tables["RQSTDT_INS"];

                int prev_qty = 0, next_qty = 0;
                int in_qty = 0, out_qty = 0;
                int sa_qty = 0;

                //if (dtParam.Rows.Count > 0)
                foreach (DataRow paramRow in dtParam.Rows)
                {
                    in_qty = paramRow["IN_QTY"].toInt32();
                    out_qty = paramRow["OUT_QTY"].toInt32();
                    sa_qty = paramRow["SA_QTY"].toInt32();

                    //기준일 이전 최근 재고 내역 조회 :
                    paramRow["LESS_TIME"] = paramRow["EVENT_TIME"];

                    DataTable dtPrevStock = DSHP.TSHP_STOCK_LOG_QUERY.TSHP_STOCK_LOG_QUERY2(UTIL.GetRowToDt(paramRow), bizExecute);

                    if (dtPrevStock.Rows.Count > 0)
                    {
                        int idx = dtPrevStock.Rows.Count;
                        prev_qty = dtPrevStock.Rows[idx - 1]["NEXT_QTY"].toInt32();

                        paramRow["PREV_QTY"] = prev_qty;
                    }

                    if (sa_qty >= 0)
                    {
                        next_qty = sa_qty;
                        paramRow["NEXT_QTY"] = next_qty;
                    }
                    else
                    {
                        next_qty = prev_qty + in_qty - out_qty;
                        paramRow["NEXT_QTY"] = next_qty;
                    }


                    //DSHP.TSHP_STOCK_LOG.TSHP_STOCK_LOG_INS2(UTIL.GetRowToDt(paramRow), bizExecute);
                    DSHP.TSHP_STOCK_LOG.TSHP_STOCK_LOG_INS3(UTIL.GetRowToDt(paramRow), bizExecute);

                    //기준일 이후 재고 내역 prev_qty, next_qty 업데이트
                    paramRow["LESS_TIME"] = DBNull.Value;
                    paramRow["MORE_TIME"] = paramRow["EVENT_TIME"];
                    DataTable dtNextStock = DSHP.TSHP_STOCK_LOG_QUERY.TSHP_STOCK_LOG_QUERY2(UTIL.GetRowToDt(paramRow), bizExecute);

                    foreach (DataRow dr in dtNextStock.Rows)
                    {
                        if (sa_qty > 0)
                            dr["PREV_QTY"] = next_qty;
                        else
                            dr["PREV_QTY"] = dr["PREV_QTY"].toInt32() + next_qty;

                        dr["NEXT_QTY"] = dr["PREV_QTY"].toInt32() + dr["IN_QTY"].toInt32() - dr["OUT_QTY"].toInt32();
                        next_qty = dr["NEXT_QTY"].toInt32();

                        //PLT_CODE,PART_CODE,EVENT_TIME,PREV_QTY,NEXT_QTY
                        DSHP.TSHP_STOCK_LOG.TSHP_STOCK_LOG_UPD(UTIL.GetRowToDt(dr), bizExecute);

                    }


                    //현재고 업데이트
                    DataTable dtPartParam = new DataTable("RQSTDT");
                    dtPartParam.Columns.Add("PLT_CODE", typeof(String));
                    dtPartParam.Columns.Add("PART_CODE", typeof(String));
                    dtPartParam.Columns.Add("STK_QTY", typeof(int));

                    DataRow drParam = dtPartParam.NewRow();
                    drParam["PLT_CODE"] = paramRow["PLT_CODE"];
                    drParam["PART_CODE"] = paramRow["PART_CODE"];
                    drParam["STK_QTY"] = next_qty;
                    dtPartParam.Rows.Add(drParam);

                    if (paramRow["STOCK_TYPE"].ToString() == "S01")  //완재고
                    {
                        DLSE.LSE_STD_PART.LSE_STD_PART_UPD10(dtPartParam, bizExecute);
                    }
                    else
                    {
                        DLSE.LSE_STD_PART.LSE_STD_PART_UPD11(dtPartParam, bizExecute);
                    }

                }

                return;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PUR56A_INS3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_INS"], "PREV_QTY", 0, typeof(int));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_INS"], "NEXT_QTY", 0, typeof(int));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_INS"], "LESS_TIME", "", typeof(String));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_INS"], "MORE_TIME", "", typeof(String));

                DataTable dtParam = paramDS.Tables["RQSTDT_INS"];

                int prev_qty = 0, next_qty = 0;
                int in_qty = 0, out_qty = 0;
                int sa_qty = 0;

                if (dtParam.Rows.Count > 0)
                {
                    in_qty = dtParam.Rows[0]["IN_QTY"].toInt32();
                    out_qty = dtParam.Rows[0]["OUT_QTY"].toInt32();
                    sa_qty = dtParam.Rows[0]["SA_QTY"].toInt32();

                    //기준일 이전 최근 재고 내역 조회 :
                    dtParam.Rows[0]["LESS_TIME"] = dtParam.Rows[0]["EVENT_TIME"];

                    DataTable dtPrevStock = DSHP.TSHP_STOCK_LOG_QUERY.TSHP_STOCK_LOG_QUERY2(dtParam, bizExecute);

                    if (dtPrevStock.Rows.Count > 0)
                    {
                        int idx = dtPrevStock.Rows.Count;
                        prev_qty = dtPrevStock.Rows[idx - 1]["NEXT_QTY"].toInt32();

                        dtParam.Rows[0]["PREV_QTY"] = prev_qty;
                    }

                    if (sa_qty > 0)
                    {
                        next_qty = sa_qty;
                        dtParam.Rows[0]["NEXT_QTY"] = next_qty;
                    }
                    else
                    {
                        next_qty = prev_qty + in_qty - out_qty;
                        dtParam.Rows[0]["NEXT_QTY"] = next_qty;
                    }


                    DSHP.TSHP_STOCK_LOG.TSHP_STOCK_LOG_INS2(dtParam, bizExecute);

                    //기준일 이후 재고 내역 prev_qty, next_qty 업데이트
                    dtParam.Rows[0]["LESS_TIME"] = DBNull.Value;
                    dtParam.Rows[0]["MORE_TIME"] = dtParam.Rows[0]["EVENT_TIME"];
                    DataTable dtNextStock = DSHP.TSHP_STOCK_LOG_QUERY.TSHP_STOCK_LOG_QUERY2(dtParam, bizExecute);

                    foreach (DataRow dr in dtNextStock.Rows)
                    {
                        if (sa_qty > 0)
                            dr["PREV_QTY"] = next_qty;
                        else
                            dr["PREV_QTY"] = dr["PREV_QTY"].toInt32() + next_qty;

                        dr["NEXT_QTY"] = dr["PREV_QTY"].toInt32() + dr["IN_QTY"].toInt32() - dr["OUT_QTY"].toInt32();
                        next_qty = dr["NEXT_QTY"].toInt32();

                        //PLT_CODE,PART_CODE,EVENT_TIME,PREV_QTY,NEXT_QTY
                        DSHP.TSHP_STOCK_LOG.TSHP_STOCK_LOG_UPD(UTIL.GetRowToDt(dr), bizExecute);

                    }


                    //현재고 업데이트
                    DataTable dtPartParam = new DataTable("RQSTDT");
                    dtPartParam.Columns.Add("PLT_CODE", typeof(String));
                    dtPartParam.Columns.Add("PART_CODE", typeof(String));
                    dtPartParam.Columns.Add("STK_QTY", typeof(int));

                    DataRow drParam = dtPartParam.NewRow();
                    drParam["PLT_CODE"] = dtParam.Rows[0]["PLT_CODE"];
                    drParam["PART_CODE"] = dtParam.Rows[0]["PART_CODE"];
                    drParam["STK_QTY"] = next_qty;
                    dtPartParam.Rows.Add(drParam);

                    DLSE.LSE_STD_PART.LSE_STD_PART_UPD10(dtPartParam, bizExecute);

                }

                return null;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static DataSet PUR56A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                
                DataTable dtRslt = DSHP.TSHP_STOCK_LOG_QUERY.TSHP_STOCK_LOG_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

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
