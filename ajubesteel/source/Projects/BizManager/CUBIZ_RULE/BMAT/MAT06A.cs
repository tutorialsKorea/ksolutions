using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BMAT
{
    public class MAT06A
    {
        /// <summary>
        /// 현재고 조회
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExe"></param>
        /// <returns></returns>
        public static DataSet MAT06A_SER(DataSet paramDS, BizExecute.BizExecute bizExe)
        {
            try
            {
                DataTable dtRslt = DMAT.TMAT_STOCK_QUERY.TMAT_STOCK_QUERY1(paramDS.Tables["RQSTDT"], bizExe);
                dtRslt.Columns.Add("SEL", typeof(String));
                dtRslt.Columns.Add("UPD_SCOMMENT", typeof(String));

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
        /// LOT 조회
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExe"></param>
        /// <returns></returns>
        public static DataSet MAT06A_SER2(DataSet paramDS, BizExecute.BizExecute bizExe)
        {
            try
            {
                //DataTable dtRslt = DMAT.TMAT_STOCK_LOT_QUERY.TMAT_STOCK_LOT_QUERY1(paramDS.Tables["RQSTDT"], bizExe);
                DataTable dtRslt = DMAT.TMAT_STOCK_LOG_DETAIL_QUERY.TMAT_STOCK_LOG_DETAIL_QUERY4(paramDS.Tables["RQSTDT"], bizExe); 
                dtRslt.Columns.Add("SEL", typeof(String));

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
        /// 재고 생성
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExe"></param>
        /// <returns></returns>
        public static DataSet MAT06A_INS(DataSet paramDS, BizExecute.BizExecute bizExe)
        {
            try
            {
                if (!paramDS.Tables["RQSTDT"].Columns.Contains("DETAIL_PART_NAME"))
                {
                    paramDS.Tables["RQSTDT"].Columns.Add("DETAIL_PART_NAME", typeof(String));
                }

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    CTRL.CTRL.SET_STOCK_PROCESS(row, bizExe, "PART_CODE", "STOCK_LOC", "PART_QTY", "AMT");
                }

                DataTable dtRslt = DMAT.TMAT_STOCK_QUERY.TMAT_STOCK_QUERY1(paramDS.Tables["RQSTDT_SER"], bizExe);
                dtRslt.Columns.Add("SEL", typeof(String));
                dtRslt.Columns.Add("UPD_SCOMMENT", typeof(String));

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
        /// 재고 이동
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExe"></param>
        /// <returns></returns>
        //public static DataSet MAT06A_INS2(DataSet paramDS, BizExecute.BizExecute bizExe)
        //{
        //    try
        //    {
        //        UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "MV_STK_ID", "0", typeof(string));
        //        if (paramDS.Tables["RQSTDT"].Rows.Count > 0)
        //        {
        //            foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
        //            {
        //                //이동창고 존재여부
        //                DataTable stockSer = DMAT.TMAT_STOCK.TMAT_STOCK_SER3(UTIL.GetRowToDt(row), bizExe);
        //                if (stockSer.Rows.Count > 0)
        //                {
        //                    //창고 존재
        //                    row["MV_STK_ID"] = stockSer.Rows[0]["STK_ID"];
        //                }
        //                else
        //                {
        //                    //존재하지 않음

        //                    DataTable dtStock = new DataTable();
        //                    dtStock.Columns.Add("PLT_CODE", typeof(String));
        //                    dtStock.Columns.Add("STK_ID", typeof(String));
        //                    dtStock.Columns.Add("PART_CODE", typeof(String));
        //                    dtStock.Columns.Add("STOCK_LOC", typeof(String));
        //                    dtStock.Columns.Add("TOT_YPGO_AMT", typeof(decimal));
        //                    dtStock.Columns.Add("PART_QTY", typeof(decimal));
        //                    dtStock.Columns.Add("DETAIL_PART_NAME", typeof(String));

        //                    DataRow drCreate = dtStock.NewRow();
        //                    drCreate["PLT_CODE"] = row["PLT_CODE"];
        //                    drCreate["STK_ID"] = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "STK", bizExe);
        //                    drCreate["PART_CODE"] = row["PART_CODE"];
        //                    drCreate["STOCK_LOC"] = row["MOVE_STOCK_LOC"];
        //                    drCreate["DETAIL_PART_NAME"] = row["DETAIL_PART_NAME"];
        //                    dtStock.Rows.Add(drCreate);

        //                    DMAT.TMAT_STOCK.TMAT_STOCK_INS(dtStock, bizExe);

        //                    row["MV_STK_ID"] = drCreate["STK_ID"];
        //                }

        //                DMAT.TMAT_STOCK_LOT.TMAT_STOCK_LOT_UPD4(UTIL.GetRowToDt(row), bizExe);

        //                DataTable stkDt = paramDS.Tables["RQSTDT"].AsEnumerable()
        //                                                            .GroupBy(g => new
        //                                                            {
        //                                                                PLT_CODE = g["PLT_CODE"],
        //                                                                STK_ID = g["STK_ID"]
        //                                                            })
        //                                                            .Select(r => new
        //                                                            {
        //                                                                PLT_CODE = r.Key.PLT_CODE,
        //                                                                STK_ID = r.Key.STK_ID
        //                                                            }).LINQToDataTable();
        //                DMAT.TMAT_STOCK.TMAT_STOCK_UPD2(stkDt, bizExe);

        //                DataTable mvStkDt = paramDS.Tables["RQSTDT"].AsEnumerable()
        //                                                                .GroupBy(g => new
        //                                                                {
        //                                                                    PLT_CODE = g["PLT_CODE"],
        //                                                                    STK_ID = g["MV_STK_ID"]
        //                                                                })
        //                                                                .Select(r => new
        //                                                                {
        //                                                                    PLT_CODE = r.Key.PLT_CODE,
        //                                                                    STK_ID = r.Key.STK_ID
        //                                                                }).LINQToDataTable();
        //                DMAT.TMAT_STOCK.TMAT_STOCK_UPD2(mvStkDt, bizExe);
        //            }
        //        }

        //        //TODO:재고 이동 로그 필요
        //        DataTable dtRslt = DMAT.TMAT_STOCK_QUERY.TMAT_STOCK_QUERY1(paramDS.Tables["RQSTDT_SER"], bizExe);
        //        dtRslt.Columns.Add("SEL", typeof(String));

        //        dtRslt.TableName = "RSLTDT";

        //        paramDS.Tables.Add(dtRslt);

        //        return paramDS;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
        //    }
        //}

        /// <summary>
        /// 재고 이동
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExe"></param>
        /// <returns></returns>
        public static DataSet MAT06A_INS2_1(DataSet paramDS, BizExecute.BizExecute bizExe)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "MV_STK_ID", "0", typeof(string));
                if (paramDS.Tables["RQSTDT"].Rows.Count > 0)
                {
                    #region 재고 테이블 생성
                    DataTable dtStockLog = new DataTable();
                    dtStockLog.Columns.Add("PLT_CODE", typeof(String));
                    dtStockLog.Columns.Add("STK_ID", typeof(String));
                    dtStockLog.Columns.Add("LOT_ID", typeof(String));
                    dtStockLog.Columns.Add("YPGO_ID", typeof(String));
                    dtStockLog.Columns.Add("OUT_ID", typeof(String));
                    dtStockLog.Columns.Add("PART_CODE", typeof(String));
                    dtStockLog.Columns.Add("STOCK_LOC", typeof(String));
                    dtStockLog.Columns.Add("STOCK_FLAG", typeof(String));
                    dtStockLog.Columns.Add("GUBUN", typeof(String));//생산완료 등록(PF / 생산완료 취소(PC / 출하 등록(SF / 출하 취소(SC / 재고조정(SA / 선삭재고 전환(-)(TMinus) / 선삭재고 전환(+) (TPlus)
                    dtStockLog.Columns.Add("IN_QTY", typeof(decimal));
                    dtStockLog.Columns.Add("IN_COST", typeof(decimal));
                    dtStockLog.Columns.Add("IN_AMT", typeof(decimal));
                    dtStockLog.Columns.Add("OUT_QTY", typeof(decimal));
                    dtStockLog.Columns.Add("OUT_COST", typeof(decimal));
                    dtStockLog.Columns.Add("OUT_AMT", typeof(decimal));
                    dtStockLog.Columns.Add("TOT_YPGO_AMT", typeof(decimal));
                    dtStockLog.Columns.Add("PART_QTY", typeof(decimal));
                    dtStockLog.Columns.Add("SCOMMENT", typeof(String));
                    dtStockLog.Columns.Add("REG_EMP", typeof(String));
                    dtStockLog.Columns.Add("DETAIL_PART_NAME", typeof(String));
                    #endregion

                    foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                    {
                        //이동창고 존재여부
                        DataTable stockSer = DMAT.TMAT_STOCK.TMAT_STOCK_SER3(UTIL.GetRowToDt(row), bizExe);
                        if (stockSer.Rows.Count > 0)
                        {
                            //창고 존재
                            row["MV_STK_ID"] = stockSer.Rows[0]["STK_ID"];
                        }
                        else
                        {
                            //존재하지 않음

                            DataTable dtStock = new DataTable();
                            dtStock.Columns.Add("PLT_CODE", typeof(String));
                            dtStock.Columns.Add("STK_ID", typeof(String));
                            dtStock.Columns.Add("PART_CODE", typeof(String));
                            dtStock.Columns.Add("STOCK_LOC", typeof(String));
                            dtStock.Columns.Add("TOT_YPGO_AMT", typeof(decimal));
                            dtStock.Columns.Add("PART_QTY", typeof(decimal));
                            dtStock.Columns.Add("DETAIL_PART_NAME", typeof(String));

                            DataRow drCreate = dtStock.NewRow();
                            drCreate["PLT_CODE"] = row["PLT_CODE"];
                            drCreate["STK_ID"] = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "STK", bizExe);
                            drCreate["PART_CODE"] = row["PART_CODE"];
                            drCreate["STOCK_LOC"] = row["MOVE_STOCK_LOC"];
                            drCreate["DETAIL_PART_NAME"] = row["DETAIL_PART_NAME"];
                            dtStock.Rows.Add(drCreate);

                            DMAT.TMAT_STOCK.TMAT_STOCK_INS(dtStock, bizExe);

                            row["MV_STK_ID"] = drCreate["STK_ID"];
                        }

                        DataTable stockMoveLotSer = DMAT.TMAT_STOCK.TMAT_STOCK_SER3(UTIL.GetRowToDt(row), bizExe);  //이동창고데이터

                        //DataTable stockLotSer = DMAT.TMAT_STOCK_LOT.TMAT_STOCK_LOT_SER2(UTIL.GetRowToDt(row), bizExe);  //기존창고데이터
                        //DataTable selStockLot = stockLotSer.AsEnumerable()
                        //                                    .OrderBy(o => o["REG_DATE"])
                        //                                    .Take(row["MV_QTY"].toInt())
                        //                                    .CopyToDataTable();

                        DataTable stockLotSer = DMAT.TMAT_STOCK_LOG_DETAIL_QUERY.TMAT_STOCK_LOG_DETAIL_QUERY1(UTIL.GetRowToDt(row), bizExe);  //기존창고데이터

                        UTIL.SetBizAddColumnToValue(stockLotSer, "MV_STK_ID", row["MV_STK_ID"], typeof(string));

                        int qty = row["MV_QTY"].toInt();

                        int outStockQty = 0;
                        decimal outTotYpgoAmt = 0;

                        int inStockQty = 0;
                        decimal inTotYpgoAmt = 0;

                        if (stockLotSer.Rows.Count > 0)
                        {
                            outStockQty = stockLotSer.Rows[0]["PART_QTY"].toInt();

                            outTotYpgoAmt = stockLotSer.Rows[0]["TOT_YPGO_AMT"].toInt();
                        }

                        if (stockMoveLotSer.Rows.Count > 0)
                        {
                            inStockQty = stockMoveLotSer.Rows[0]["PART_QTY"].toInt();

                            inTotYpgoAmt = stockMoveLotSer.Rows[0]["TOT_YPGO_AMT"].toInt();
                        }

                        foreach (DataRow rw in stockLotSer.Rows)
                        {
                            if (qty == 0) break;

                            int outQty = 0;

                            if ((rw["REMAIN_QTY"].toInt() - qty) >= 0)
                            {
                                outQty = qty;
                                qty = 0;
                            }
                            else
                            {
                                outQty = rw["REMAIN_QTY"].toInt();
                                qty = qty - rw["REMAIN_QTY"].toInt();
                            }

                            #region OUT 로그
                            DataRow drOut = dtStockLog.NewRow();
                            drOut["PLT_CODE"] = row["PLT_CODE"];
                            drOut["PART_CODE"] = row["PART_CODE"];
                            drOut["STK_ID"] = row["STK_ID"];
                            drOut["LOT_ID"] = rw["LOT_ID"];
                            drOut["YPGO_ID"] = rw["YPGO_ID"];
                            drOut["STOCK_LOC"] = row["STOCK_LOC"];
                            drOut["STOCK_FLAG"] = "MV";
                            drOut["GUBUN"] = "MV";
                            drOut["OUT_QTY"] = outQty;
                            drOut["OUT_COST"] = rw["UNIT_COST"];
                            drOut["OUT_AMT"] = drOut["OUT_QTY"].toDecimal() * drOut["OUT_COST"].toDecimal();

                            outTotYpgoAmt = outTotYpgoAmt - drOut["OUT_AMT"].toDecimal();
                            outStockQty = outStockQty - drOut["OUT_QTY"].toInt();

                            drOut["TOT_YPGO_AMT"] = outTotYpgoAmt;
                            drOut["PART_QTY"] = outStockQty;

                            drOut["DETAIL_PART_NAME"] = row["DETAIL_PART_NAME"];
                            dtStockLog.Rows.Add(drOut);

                            CTRL.CTRL.SET_STOCK_LOG(drOut, bizExe);
                            #endregion

                            #region IN 로그
                            DataRow drIn = dtStockLog.NewRow();
                            drIn["PLT_CODE"] = row["PLT_CODE"];
                            drIn["PART_CODE"] = row["PART_CODE"];
                            drIn["STK_ID"] = row["MV_STK_ID"];
                            drIn["YPGO_ID"] = rw["YPGO_ID"];
                            drIn["STOCK_LOC"] = row["MOVE_STOCK_LOC"];
                            drIn["STOCK_FLAG"] = "MV";
                            drIn["GUBUN"] = "MV";
                            drIn["IN_QTY"] = outQty;
                            drIn["IN_COST"] = rw["UNIT_COST"];
                            drIn["IN_AMT"] = drIn["IN_QTY"].toDecimal() * drIn["IN_AMT"].toDecimal();

                            inTotYpgoAmt = inTotYpgoAmt + drIn["IN_AMT"].toDecimal();
                            inStockQty = inStockQty + drIn["IN_QTY"].toInt();

                            drIn["TOT_YPGO_AMT"] = inTotYpgoAmt;
                            drIn["PART_QTY"] = inStockQty;


                            drIn["DETAIL_PART_NAME"] = row["DETAIL_PART_NAME"];
                            dtStockLog.Rows.Add(drIn);

                            CTRL.CTRL.SET_STOCK_LOG(drIn, bizExe);
                            #endregion
                        }

                        //DMAT.TMAT_STOCK_LOT.TMAT_STOCK_LOT_UPD3(selStockLot, bizExe);
                    }

                    #region STOCK : PART_QTY, AMT 업데이트
                    DataTable stkDt = paramDS.Tables["RQSTDT"].AsEnumerable()
                                                                    .GroupBy(g => new
                                                                    {
                                                                        PLT_CODE = g["PLT_CODE"],
                                                                        STK_ID = g["STK_ID"]
                                                                    })
                                                                    .Select(r => new
                                                                    {
                                                                        PLT_CODE = r.Key.PLT_CODE,
                                                                        STK_ID = r.Key.STK_ID
                                                                    }).LINQToDataTable();
                    DMAT.TMAT_STOCK.TMAT_STOCK_UPD2(stkDt, bizExe);

                    DataTable mvStkDt = paramDS.Tables["RQSTDT"].AsEnumerable()
                                                                    .GroupBy(g => new
                                                                    {
                                                                        PLT_CODE = g["PLT_CODE"],
                                                                        STK_ID = g["MV_STK_ID"]
                                                                    })
                                                                    .Select(r => new
                                                                    {
                                                                        PLT_CODE = r.Key.PLT_CODE,
                                                                        STK_ID = r.Key.STK_ID
                                                                    }).LINQToDataTable();
                    DMAT.TMAT_STOCK.TMAT_STOCK_UPD2(mvStkDt, bizExe);
                    #endregion
                }


                DataTable dtRslt = DMAT.TMAT_STOCK_QUERY.TMAT_STOCK_QUERY1(paramDS.Tables["RQSTDT_SER"], bizExe);
                dtRslt.Columns.Add("SEL", typeof(String));

                dtRslt.Columns.Add("UPD_SCOMMENT", typeof(String));
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
        /// 재고간 이동 : LOT
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExe"></param>
        /// <returns></returns>
        //public static DataSet MAT06A_INS3(DataSet paramDS, BizExecute.BizExecute bizExe)
        //{
        //    try
        //    {
        //        UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "MV_STK_ID", "0", typeof(string));
        //        if (paramDS.Tables["RQSTDT"].Rows.Count > 0)
        //        {
        //            foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
        //            {
        //                //이동창고 존재여부
        //                DataTable stockSer = DMAT.TMAT_STOCK.TMAT_STOCK_SER3(UTIL.GetRowToDt(row), bizExe);
        //                if (stockSer.Rows.Count > 0)
        //                {
        //                    //창고 존재
        //                    row["MV_STK_ID"] = stockSer.Rows[0]["STK_ID"];
        //                }
        //                else
        //                {
        //                    throw UTIL.SetException("재고가 존재하지 않습니다. 재고를 생성해주세요."
        //                                                     , row["PART_CODE"].toStringEmpty()
        //                                                     , new System.Diagnostics.StackFrame().GetMethod().Name
        //                                                     , BizException.ABORT, row);
        //                }

        //                DMAT.TMAT_STOCK_LOT.TMAT_STOCK_LOT_UPD3(UTIL.GetRowToDt(row), bizExe);
        //            }

        //            DataTable stkDt = paramDS.Tables["RQSTDT"].AsEnumerable()
        //                                                            .GroupBy(g => new
        //                                                            {
        //                                                                PLT_CODE = g["PLT_CODE"],
        //                                                                STK_ID = g["STK_ID"]
        //                                                            })
        //                                                            .Select(r => new
        //                                                            {
        //                                                                PLT_CODE = r.Key.PLT_CODE,
        //                                                                STK_ID = r.Key.STK_ID
        //                                                            }).LINQToDataTable();
        //            DMAT.TMAT_STOCK.TMAT_STOCK_UPD2(stkDt, bizExe);

        //            DataTable mvStkDt = paramDS.Tables["RQSTDT"].AsEnumerable()
        //                                                            .GroupBy(g => new
        //                                                            {
        //                                                                PLT_CODE = g["PLT_CODE"],
        //                                                                STK_ID = g["MV_STK_ID"]
        //                                                            })
        //                                                            .Select(r => new
        //                                                            {
        //                                                                PLT_CODE = r.Key.PLT_CODE,
        //                                                                STK_ID = r.Key.STK_ID
        //                                                            }).LINQToDataTable();
        //            DMAT.TMAT_STOCK.TMAT_STOCK_UPD2(mvStkDt, bizExe);
        //        }

        //        //TODO:재고 이동 로그 필요
        //        DataTable dtRslt = DMAT.TMAT_STOCK_QUERY.TMAT_STOCK_QUERY1(paramDS.Tables["RQSTDT_SER"], bizExe);
        //        dtRslt.Columns.Add("SEL", typeof(String));

        //        dtRslt.TableName = "RSLTDT";

        //        paramDS.Tables.Add(dtRslt);

        //        return paramDS;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
        //    }
        //}

        /// <summary>
        /// 재고간 이동 : STOCK
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExe"></param>
        /// <returns></returns>
        public static DataSet MAT06A_INS4(DataSet paramDS, BizExecute.BizExecute bizExe)
        {
            try
            {
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "MV_STK_ID", "0", typeof(string));

                //foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                //{
                //    DataTable stockSer = DMAT.TMAT_STOCK.TMAT_STOCK_SER3(UTIL.GetRowToDt(row), bizExe);
                //    if (stockSer.Rows.Count > 0)
                //    {
                //        //창고 존재
                //        row["MV_STK_ID"] = stockSer.Rows[0]["STK_ID"];
                //    }
                //    else
                //    {
                //        string stkId = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "STK", UTIL.emSerialFormat.YYMMDD, "", bizExe);

                //        row["MV_STK_ID"] = stkId;

                //        DataTable dtStock = new DataTable();
                //        dtStock.Columns.Add("PLT_CODE", typeof(String));
                //        dtStock.Columns.Add("STK_ID", typeof(String));
                //        dtStock.Columns.Add("PART_CODE", typeof(String));
                //        dtStock.Columns.Add("STOCK_LOC", typeof(String));
                //        dtStock.Columns.Add("TOT_YPGO_AMT", typeof(decimal));
                //        dtStock.Columns.Add("PART_QTY", typeof(decimal));

                //        DataRow drCreate = dtStock.NewRow();
                //        drCreate["PLT_CODE"] = row["PLT_CODE"];
                //        drCreate["STK_ID"] = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "STK", bizExe);
                //        drCreate["PART_CODE"] = row["PART_CODE"];
                //        drCreate["STOCK_LOC"] = row["MOVE_STOCK_LOC"];
                //        dtStock.Rows.Add(drCreate);

                //        DMAT.TMAT_STOCK.TMAT_STOCK_INS(dtStock, bizExe);
                //    }

                //    DataTable lotDt = DMAT.TMAT_STOCK_LOT.TMAT_STOCK_LOT_SER2(UTIL.GetRowToDt(row), bizExe);
                //    UTIL.SetBizAddColumnToValue(lotDt, "MV_STK_ID", row["MV_STK_ID"], typeof(string));

                //    DataTable serLotDt = lotDt.AsEnumerable()
                //                            .OrderBy(o => o["REG_DATE"])
                //                            .Take(row["MOVE_QTY"].toInt())//지정한 수량만큼 행을 반환
                //                            .CopyToDataTable();

                //    DMAT.TMAT_STOCK_LOT.TMAT_STOCK_LOT_UPD3(serLotDt, bizExe);
                //    //foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                //    //{
                //    //    //이동창고 존재여부
                //    //    DataTable stockSer = DMAT.TMAT_STOCK.TMAT_STOCK_SER3(UTIL.GetRowToDt(row), bizExe);
                //    //    if (stockSer.Rows.Count > 0)
                //    //    {
                //    //        //창고 존재
                //    //        row["MV_STK_ID"] = stockSer.Rows[0]["STK_ID"];
                //    //    }
                //    //    else
                //    //    {
                //    //        throw UTIL.SetException("재고가 존재하지 않습니다. 재고를 생성해주세요."
                //    //                                         , row["PART_CODE"].toStringEmpty()
                //    //                                         , new System.Diagnostics.StackFrame().GetMethod().Name
                //    //                                         , BizException.ABORT, row);
                //    //    }

                //    //    DMAT.TMAT_STOCK_LOT.TMAT_STOCK_LOT_UPD3(UTIL.GetRowToDt(row), bizExe);
                //    //}

                //    DataTable stkDt = paramDS.Tables["RQSTDT"].AsEnumerable()
                //                                                    .GroupBy(g => new
                //                                                    {
                //                                                        PLT_CODE = g["PLT_CODE"],
                //                                                        STK_ID = g["STK_ID"]
                //                                                    })
                //                                                    .Select(r => new
                //                                                    {
                //                                                        PLT_CODE = r.Key.PLT_CODE,
                //                                                        STK_ID = r.Key.STK_ID
                //                                                    }).LINQToDataTable();
                //    DMAT.TMAT_STOCK.TMAT_STOCK_UPD2(stkDt, bizExe);

                //    DataTable mvStkDt = paramDS.Tables["RQSTDT"].AsEnumerable()
                //                                                    .GroupBy(g => new
                //                                                    {
                //                                                        PLT_CODE = g["PLT_CODE"],
                //                                                        STK_ID = g["MV_STK_ID"]
                //                                                    })
                //                                                    .Select(r => new
                //                                                    {
                //                                                        PLT_CODE = r.Key.PLT_CODE,
                //                                                        STK_ID = r.Key.STK_ID
                //                                                    }).LINQToDataTable();
                //    DMAT.TMAT_STOCK.TMAT_STOCK_UPD2(mvStkDt, bizExe);
                //}

                ////TODO:재고 이동 로그 필요
                //DataTable dtRslt = DMAT.TMAT_STOCK_QUERY.TMAT_STOCK_QUERY1(paramDS.Tables["RQSTDT_SER"], bizExe);
                //dtRslt.Columns.Add("SEL", typeof(String));

                //dtRslt.TableName = "RSLTDT";

                //paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet MAT06A_Create(DataSet paramDS, BizExecute.BizExecute bizExe)
        {
            try
            {
                DataTable stockRslt = DMAT.TMAT_STOCK_QUERY.TMAT_STOCK_QUERY_CREATE1(paramDS.Tables["RQSTDT"], bizExe);
                DataTable stockLogRslt = DMAT.TMAT_STOCK_QUERY.TMAT_STOCK_QUERY_CREATE2(paramDS.Tables["RQSTDT"], bizExe);

                DataTable lotTable = new DataTable("RQSTDT");
                lotTable.Columns.Add("PLT_CODE", typeof(string));
                lotTable.Columns.Add("LOT_ID", typeof(string));
                lotTable.Columns.Add("STK_ID", typeof(string));
                lotTable.Columns.Add("UNIT_COST", typeof(decimal));
                lotTable.Columns.Add("STOCK_FLAG", typeof(string));
                lotTable.Columns.Add("YPGO_ID", typeof(string));
                lotTable.Columns.Add("OUT_ID", typeof(string));
                lotTable.Columns.Add("REG_DATE", typeof(DateTime));
                lotTable.Columns.Add("REG_EMP", typeof(string));
                lotTable.Columns.Add("MDFY_DATE", typeof(DateTime));
                lotTable.Columns.Add("MDFY_EMP", typeof(string));
                lotTable.Columns.Add("CUTTING_CNT", typeof(int));
                lotTable.Columns.Add("OLD_STK_ID", typeof(string));

                DataTable logDetailTable = new DataTable("RQSTDT");
                logDetailTable.Columns.Add("UID", typeof(Int64));
                logDetailTable.Columns.Add("LOG_UID", typeof(Int64));
                logDetailTable.Columns.Add("LOT_ID", typeof(string));

                int cnt = 1;
                string stkID = "STK220202";

                int lotCnt = 1;
                string lotID = "SLOT";
                int lotIDCnt = 22020201;

                int UID = 1;

                foreach (DataRow row in stockLogRslt.Rows)
                {
                    string fullStkID = stkID + cnt.ToString().PadLeft(3, '0');

                    row["STK_ID"] = fullStkID;

                    //재고 테이블 재고ID부여
                    DataRow[] Rows = stockRslt.Select("PART_CODE = '" + row["PART_CODE"].ToString() + "'");
                    
                    if (Rows.Length == 1)
                    {
                        Rows[0]["STK_ID"] = fullStkID;
                    }

                    //재고 로그 인써트후 UID 반환
                    object logRsltID = DMAT.TMAT_STOCK_LOG.TMAT_STOCK_LOG_INS(UTIL.GetRowToDt(row), bizExe);


                    //수량만큼 LOT, LOG DETAIL 생성
                    DateTime nowDateTime = DateTime.Now;
                    //SLOT21 08 05 16 0082
                    for (int i = 0; i < row["IN_QTY"].toInt(); i++)
                    {
                        if (lotCnt == 9999)
                        {
                            lotCnt = 1;
                            lotIDCnt++;
                        }

                        string fullLotID = lotID + lotIDCnt.ToString() + lotCnt.ToString().PadLeft(4, '0');

                        DataRow lotRow = lotTable.NewRow();
                        lotRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                        lotRow["LOT_ID"] = fullLotID;
                        lotRow["STK_ID"] = fullStkID;
                        lotRow["UNIT_COST"] = row["IN_COST"];
                        lotRow["STOCK_FLAG"] = "NE";
                        lotRow["REG_DATE"] = nowDateTime;
                        lotRow["REG_EMP"] = "active";
                        lotTable.Rows.Add(lotRow);

                        DataRow logDetailRow = logDetailTable.NewRow();
                        logDetailRow["UID"] = UID;
                        logDetailRow["LOG_UID"] = System.Convert.ToInt64(logRsltID);
                        logDetailRow["LOT_ID"] = fullLotID;
                        logDetailTable.Rows.Add(logDetailRow);

                        lotCnt++;
                        UID++;
                    }

                    cnt++;
                }

                //throw new Exception();
                bizExe.executeBulkInsertQuery(logDetailTable, "TMAT_STOCK_LOG_DETAIL");
                bizExe.executeBulkInsertQuery(stockRslt, "TMAT_STOCK");
                bizExe.executeBulkInsertQuery(lotTable, "TMAT_STOCK_LOT");

                //throw new Exception();

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 재고조정 STK 단위
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExe"></param>
        /// <returns></returns>
        public static DataSet MAT06A_UPD(DataSet paramDS, BizExecute.BizExecute bizExe)
        {
            try
            {
                if (paramDS.Tables["RQSTDT"].Rows.Count > 0)
                {
                    if (!paramDS.Tables["RQSTDT"].Columns.Contains("DETAIL_PART_NAME"))
                    {
                        paramDS.Tables["RQSTDT"].Columns.Add("DETAIL_PART_NAME", typeof(String));
                    }

                    foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                    {
                        CTRL.CTRL.SET_STOCK_PROCESS(row, bizExe, "PART_CODE", "STOCK_LOC", "DIFF_QTY", "AMT");
                    }
                }

                DataTable dtRslt = DMAT.TMAT_STOCK_QUERY.TMAT_STOCK_QUERY1(paramDS.Tables["RQSTDT_SER"], bizExe);
                dtRslt.Columns.Add("SEL", typeof(String));
                dtRslt.Columns.Add("UPD_SCOMMENT", typeof(String));

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
        /// 재고 폐기
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExe"></param>
        /// <returns></returns>
        //public static DataSet MAT06A_UDE(DataSet paramDS, BizExecute.BizExecute bizExe)
        //{
        //    try
        //    {
        //        if (paramDS.Tables["RQSTDT"].Rows.Count > 0)
        //        {
        //            foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
        //            {
        //                DMAT.TMAT_STOCK_LOT.TMAT_STOCK_LOT_DEL2(UTIL.GetRowToDt(row), bizExe);
        //            }

        //            DataTable stkDt = paramDS.Tables["RQSTDT"].AsEnumerable()
        //                                                            .GroupBy(g => new
        //                                                            {
        //                                                                PLT_CODE = g["PLT_CODE"],
        //                                                                STK_ID = g["STK_ID"]
        //                                                            })
        //                                                            .Select(r => new
        //                                                            {
        //                                                                PLT_CODE = r.Key.PLT_CODE,
        //                                                                STK_ID = r.Key.STK_ID
        //                                                            }).LINQToDataTable();
        //            DMAT.TMAT_STOCK.TMAT_STOCK_UPD2(stkDt, bizExe);
        //        }

        //        //TODO:재고 이동 로그 필요
        //        DataTable dtRslt = DMAT.TMAT_STOCK_QUERY.TMAT_STOCK_QUERY1(paramDS.Tables["RQSTDT_SER"], bizExe);
        //        dtRslt.Columns.Add("SEL", typeof(String));

        //        dtRslt.TableName = "RSLTDT";

        //        paramDS.Tables.Add(dtRslt);

        //        return paramDS;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
        //    }
        //}

        public static DataSet MAT06A_UDE2(DataSet paramDS, BizExecute.BizExecute bizExe)
        {
            try
            {
                #region 재고 테이블 생성
                DataTable dtStock = new DataTable();
                dtStock.Columns.Add("PLT_CODE", typeof(String));
                dtStock.Columns.Add("STK_ID", typeof(String));
                dtStock.Columns.Add("PART_CODE", typeof(String));
                dtStock.Columns.Add("STOCK_LOC", typeof(String));
                dtStock.Columns.Add("STOCK_FLAG", typeof(String));
                dtStock.Columns.Add("GUBUN", typeof(String));
                dtStock.Columns.Add("IN_QTY", typeof(decimal));
                dtStock.Columns.Add("IN_COST", typeof(decimal));
                dtStock.Columns.Add("IN_AMT", typeof(decimal));
                dtStock.Columns.Add("OUT_QTY", typeof(decimal));
                dtStock.Columns.Add("OUT_COST", typeof(decimal));
                dtStock.Columns.Add("OUT_AMT", typeof(decimal));
                dtStock.Columns.Add("TOT_YPGO_AMT", typeof(decimal));
                dtStock.Columns.Add("PART_QTY", typeof(decimal));
                dtStock.Columns.Add("SCOMMENT", typeof(String));
                dtStock.Columns.Add("REG_EMP", typeof(String));
                dtStock.Columns.Add("DETAIL_PART_NAME", typeof(String));

                dtStock.Columns.Add("LOT_ID", typeof(String));
                dtStock.Columns.Add("YPGO_ID", typeof(String));
                dtStock.Columns.Add("OUT_ID", typeof(String));

                #endregion

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    //int delQty = row["DEL_QTY"].toInt();
                    //DataTable lotTable = DMAT.TMAT_STOCK_LOT.TMAT_STOCK_LOT_SER2(UTIL.GetRowToDt(row), bizExe);

                    //decimal delCost = 0;
                    //decimal delAtm = 0;
                    //decimal delTotAmt = 0;
                    //int partQty = 0;

                    //DataTable delLotTable = null;
                    //if (lotTable.Rows.Count >= delQty)
                    //{
                    //    delLotTable = lotTable.AsEnumerable().OrderBy(o => o["REG_DATE"]) //정렬
                    //                                                   .Take(delQty)//DEL_QTY 개수만큼 가져옴
                    //                                                   .CopyToDataTable();
                    //    delAtm = delLotTable.Compute("Sum(UNIT_COST)", "").toDecimal();
                    //    delCost = delAtm / delLotTable.Rows.Count;
                    //    delTotAmt = delLotTable.Compute("Sum(UNIT_COST)", "").toDecimal() / delLotTable.Rows.Count;
                    //    partQty = lotTable.Rows.Count - delLotTable.Rows.Count;

                    //    DMAT.TMAT_STOCK_LOT.TMAT_STOCK_LOT_DEL2(delLotTable, bizExe);
                    //}
                    //else
                    //{
                    //    throw UTIL.SetException("폐기 수량이 현 재고보다 많습니다."
                    //                                                  , row["STK_ID"].toStringEmpty()
                    //                                                  , new System.Diagnostics.StackFrame().GetMethod().Name
                    //                                                  , BizException.ABORT, row);
                    //}

                    //DataRow drOut = dtStock.NewRow();
                    //drOut["PLT_CODE"] = row["PLT_CODE"];
                    //drOut["PART_CODE"] = lotTable.Rows[0]["PART_CODE"];
                    //drOut["STK_ID"] = lotTable.Rows[0]["STK_ID"];
                    //drOut["STOCK_LOC"] = lotTable.Rows[0]["STOCK_LOC"];
                    //drOut["STOCK_FLAG"] = "PE";
                    //drOut["GUBUN"] = "PE";
                    //drOut["OUT_QTY"] = delQty;
                    //drOut["OUT_COST"] = delCost;
                    //drOut["OUT_AMT"] = delAtm;
                    //drOut["TOT_YPGO_AMT"] = lotTable.Rows[0]["TOT_YPGO_AMT"].toDecimal() - delAtm;
                    //drOut["PART_QTY"] = partQty;
                    //drOut["DETAIL_PART_NAME"] = lotTable.Rows[0]["DETAIL_PART_NAME"];
                    //dtStock.Rows.Add(drOut);

                    ////STOCK 상태 바뀌기전에 입력
                    //CTRL.CTRL.SET_STOCK_LOG(drOut, delLotTable, bizExe);

                    //DMAT.TMAT_STOCK.TMAT_STOCK_UPD2(UTIL.GetRowToDt(row), bizExe);

                    DataTable lotTable = DMAT.TMAT_STOCK_LOG_DETAIL_QUERY.TMAT_STOCK_LOG_DETAIL_QUERY1(UTIL.GetRowToDt(row), bizExe);

                    int qty = row["DEL_QTY"].toInt();

                    //int stockQty = 0;
                    //decimal totYpgoAmt = 0;

                    //if (lotTable.Rows.Count > 0)
                    //{
                    //    stockQty = lotTable.Rows[0]["PART_QTY"].toInt();

                    //    totYpgoAmt = lotTable.Rows[0]["TOT_YPGO_AMT"].toInt();
                    //}

                    Dictionary<string, decimal> amtDic = new Dictionary<string, decimal>();
                    Dictionary<string, int> qtyDic = new Dictionary<string, int>();

                    foreach (DataRow rw in lotTable.Rows)
                    {
                        string stkLoc = rw["STOCK_LOC"].ToString();

                        if (!amtDic.ContainsKey(stkLoc))
                        {
                            amtDic.Add(stkLoc, rw["TOT_YPGO_AMT"].toDecimal());
                        }

                        if (!qtyDic.ContainsKey(stkLoc))
                        {
                            qtyDic.Add(stkLoc, rw["PART_QTY"].toInt());
                        }

                        dtStock.Clear();
                        if (qty == 0) break;

                        int outQty = 0;

                        if ((rw["REMAIN_QTY"].toInt() - qty) >= 0)
                        {
                            outQty = qty;
                            qty = 0;
                        }
                        else
                        {
                            outQty = rw["REMAIN_QTY"].toInt();
                            qty = qty - rw["REMAIN_QTY"].toInt();
                        }

                        DataRow drOut = dtStock.NewRow();
                        drOut["PLT_CODE"] = row["PLT_CODE"];
                        drOut["PART_CODE"] = rw["PART_CODE"];
                        drOut["STK_ID"] = rw["STK_ID"];
                        drOut["STOCK_LOC"] = rw["STOCK_LOC"];
                        drOut["STOCK_FLAG"] = "PE";
                        drOut["GUBUN"] = "PE";
                        drOut["OUT_QTY"] = outQty;
                        drOut["OUT_COST"] = rw["UNIT_COST"];
                        drOut["OUT_AMT"] = drOut["OUT_QTY"].toDecimal() * drOut["OUT_AMT"].toDecimal();

                        //totYpgoAmt = totYpgoAmt - drOut["OUT_AMT"].toDecimal();
                        //stockQty = stockQty - outQty;

                        //drOut["TOT_YPGO_AMT"] = totYpgoAmt;
                        //drOut["PART_QTY"] = stockQty;

                        amtDic[stkLoc] = amtDic[stkLoc] - drOut["OUT_AMT"].toDecimal();
                        qtyDic[stkLoc] = qtyDic[stkLoc] - outQty;

                        drOut["TOT_YPGO_AMT"] = amtDic[stkLoc];
                        drOut["PART_QTY"] = qtyDic[stkLoc];

                        drOut["DETAIL_PART_NAME"] = rw["DETAIL_PART_NAME"];
                        drOut["LOT_ID"] = rw["LOT_ID"];
                        drOut["YPGO_ID"] = rw["YPGO_ID"];
                        dtStock.Rows.Add(drOut);

                        //STOCK 상태 바뀌기전에 입력
                        CTRL.CTRL.SET_STOCK_LOG(drOut, bizExe);

                        DMAT.TMAT_STOCK.TMAT_STOCK_UPD2(UTIL.GetRowToDt(row), bizExe);

                    }

                    if (qty > 0)
                    {
                        throw UTIL.SetException("폐기 수량이 현 재고보다 많습니다."
                                                                      , row["STK_ID"].toStringEmpty()
                                                                      , new System.Diagnostics.StackFrame().GetMethod().Name
                                                                      , BizException.ABORT, row);
                    }

                }

                DataTable dtRslt = DMAT.TMAT_STOCK_QUERY.TMAT_STOCK_QUERY1(paramDS.Tables["RQSTDT_SER"], bizExe);
                dtRslt.Columns.Add("SEL", typeof(String));

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
