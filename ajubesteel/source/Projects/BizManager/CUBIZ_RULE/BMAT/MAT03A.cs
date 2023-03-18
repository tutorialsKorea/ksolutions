using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BMAT
{
    public class MAT03A
    {
        /// <summary>
        /// 불출 대상 조회(불출 요청내역)
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExe"></param>
        /// <returns></returns>
        public static DataSet MAT03A_SER(DataSet paramDS, BizExecute.BizExecute bizExe)
        {
            try
            {
                DataTable dtRslt = DMAT.TMAT_OUT_REQ_QUERY.TMAT_OUT_REQ_QUERY1(paramDS.Tables["RQSTDT"], bizExe);
                dtRslt.Columns.Add("SEL", typeof(String));
                dtRslt.Columns.Add("TOT_QTY", typeof(decimal));

                dtRslt.TableName = "RSLTDT";

                DataTable dtRsltStock = DMAT.TMAT_STOCK.TMAT_STOCK_SER4(dtRslt, bizExe);
                dtRsltStock.TableName = "RSLTDT_STOCK";
                
                paramDS.Tables.Add(dtRslt);
                paramDS.Tables.Add(dtRsltStock);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static DataSet MAT03A_SER2(DataSet paramDS, BizExecute.BizExecute bizExe)
        {
            try
            {

                DataTable dtRslt = DMAT.TMAT_OUT_QUERY.TMAT_OUT_QUERY1(paramDS.Tables["RQSTDT"], bizExe);

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

        public static DataSet MAT03A_SER3(DataSet paramDS, BizExecute.BizExecute bizExe)
        {
            try
            {

                DataTable dtRslt = DMAT.TMAT_OUT_COST_QUERY.TMAT_OUT_COST_QUERY1(paramDS.Tables["RQSTDT"], bizExe);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet MAT03A_SER4(DataSet paramDS, BizExecute.BizExecute bizExe)
        {
            try
            {

                DataTable dtRslt = DMAT.TMAT_STOCK_QUERY.TMAT_STOCK_QUERY3(paramDS.Tables["RQSTDT"], bizExe);

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
        /// 불출 등록
        /// </summary>
        /// <param name="paramDS">
        /// PLT_CODE		
        /// ,YPGO_ID		
        /// ,INSP_ID	
        /// ,PART_CODE
        /// ,BALJU_NUM		
        /// ,BALJU_SEQ		
        /// ,YPGO_DATE		
        /// ,YPGO_EMP		
        /// ,YPGO_ORG		
        /// ,YPGO_LOC	
        /// ,INSP_QTY
        /// ,YPGO_QTY		
        /// ,YPGO_STAT		
        /// ,SCOMMENT	
        /// ,TMP_YPGO_ID	
        ///</param>
        /// <param name="bizExe"></param>
        public static DataSet MAT03A_INS(DataSet paramDS, BizExecute.BizExecute bizExe)
        {
            try
            {
                string out_id;

                paramDS.Tables["RQSTDT"].Columns.Add("OUT_REQ_STAT", typeof(String));

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PROD_STATE", "10", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "SHIP_FLAG", "1", typeof(string));

                DataTable paramTable = new DataTable();
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("STK_ID", typeof(String));
                paramTable.Columns.Add("TYPE", typeof(String));
                paramTable.Columns.Add("PART_CODE", typeof(String));
                paramTable.Columns.Add("DETAIL_PART_NAME", typeof(String));
                paramTable.Columns.Add("STOCK_LOC", typeof(String));
                paramTable.Columns.Add("PART_QTY", typeof(String));
                paramTable.Columns.Add("AMT", typeof(String));
                paramTable.Columns.Add("YPGO_ID", typeof(String));
                paramTable.Columns.Add("OUT_ID", typeof(String));

                paramTable.Columns.Add("PROD_CODE", typeof(String));

                DataTable paramTableOutCost = new DataTable();
                paramTableOutCost.Columns.Add("PLT_CODE", typeof(String));
                paramTableOutCost.Columns.Add("OC_ID", typeof(String));
                paramTableOutCost.Columns.Add("YPGO_ID", typeof(String));
                paramTableOutCost.Columns.Add("OUT_ID", typeof(String));
                paramTableOutCost.Columns.Add("PART_CODE", typeof(String));
                paramTableOutCost.Columns.Add("QTY", typeof(String));
                paramTableOutCost.Columns.Add("COST", typeof(String));
                paramTableOutCost.Columns.Add("AMT", typeof(String));

                foreach (DataRow dr in paramDS.Tables["RQSTDT"].Rows)
                {
                    paramTable.Clear();
                    paramTableOutCost.Clear();

                    out_id = UTIL.UTILITY_GET_SERIALNO(dr["PLT_CODE"].ToString(), "OUT", UTIL.emSerialFormat.YYMMDD, "", bizExe);
                    dr["OUT_ID"] = out_id;


                    //DataTable rsltDt = DMAT.TMAT_STOCK_LOT_QUERY.TMAT_STOCK_LOT_QUERY1(UTIL.GetRowToDt(dr), bizExe);
                    //if (rsltDt.Rows.Count == 0)
                    //{
                    //    throw UTIL.SetException("입고 상태인 LOT이 존재하지 않습니다."
                    //                                        , dr["PART_CODE"].toStringEmpty()
                    //                                        , new System.Diagnostics.StackFrame().GetMethod().Name
                    //                                        , BizException.ABORT, dr);
                    //}
                    ////PART_CODE로 탐색
                    ////REG_DATE로 순차(선입선출)
                    //var dtSer = rsltDt
                    //                .AsEnumerable()
                    //                .OrderBy(o => o["REG_DATE"])
                    //                .ToList()
                    //                .GetRange(0, dr["OUT_QTY"].toInt())
                    //                .GroupBy(g => new
                    //                {
                    //                    PLT_CODE = g["PLT_CODE"],
                    //                    REG_DATE = g["REG_DATE"],
                    //                    PART_CODE = g["PART_CODE"],
                    //                    YPGO_ID = g["YPGO_ID"],
                    //                    STOCK_LOC = g["STOCK_LOC"],
                    //                    UNIT_COST = g["UNIT_COST"]
                    //                })
                    //                .Select(r => new
                    //                {
                    //                    PLT_CODE = r.Key.PLT_CODE,
                    //                    PART_CODE = r.Key.PART_CODE,
                    //                    YPGO_ID = r.Key.YPGO_ID,
                    //                    STOCK_LOC = r.Key.STOCK_LOC,
                    //                    UNIT_COST = r.Key.UNIT_COST,
                    //                    PART_QTY = r.Max(m => m["PART_QTY"].toDecimal()),
                    //                    TOT_YPGO_AMT = r.Max(m => m["TOT_YPGO_AMT"].toDecimal()),
                    //                    OUT_PART_QTY = r.Count(),
                    //                    LOT_LIST = r.ToList()
                    //                });

                    //foreach (var drSer in dtSer)
                    //{
                    //    DataRow paramRowOutCost = paramTableOutCost.NewRow();
                    //    paramRowOutCost["PLT_CODE"] = dr["PLT_CODE"];
                    //    paramRowOutCost["OC_ID"] = UTIL.UTILITY_GET_SERIALNO(dr["PLT_CODE"].ToString(), "OC", UTIL.emSerialFormat.YYMMDD, "", bizExe);
                    //    paramRowOutCost["YPGO_ID"] = drSer.YPGO_ID;
                    //    paramRowOutCost["OUT_ID"] = out_id;
                    //    paramRowOutCost["PART_CODE"] = drSer.PART_CODE;
                    //    paramRowOutCost["QTY"] = drSer.OUT_PART_QTY;
                    //    paramRowOutCost["COST"] = drSer.UNIT_COST;
                    //    paramRowOutCost["AMT"] = drSer.UNIT_COST.toDecimal() * drSer.OUT_PART_QTY;
                    //    paramTableOutCost.Rows.Add(paramRowOutCost);
                    //}

                    //재고 LOT조회
                    DataTable rsltDT = DMAT.TMAT_STOCK_LOG_DETAIL_QUERY.TMAT_STOCK_LOG_DETAIL_QUERY1(UTIL.GetRowToDt(dr), bizExe);

                    //LOT별 출고수량/단가 정하기
                    int qty = dr["OUT_QTY"].toInt();

                    foreach (DataRow row in rsltDT.Rows)
                    {

                        if (qty == 0) break;

                        int outQty = 0;

                        if ((row["REMAIN_QTY"].toInt() - qty) >= 0)
                        {
                            outQty = qty;
                            qty = 0;
                        }
                        else
                        {
                            outQty = row["REMAIN_QTY"].toInt();
                            qty = qty - row["REMAIN_QTY"].toInt();
                        }

                        DataRow paramRowOutCost = paramTableOutCost.NewRow();
                        paramRowOutCost["PLT_CODE"] = row["PLT_CODE"];
                        paramRowOutCost["OC_ID"] = UTIL.UTILITY_GET_SERIALNO(dr["PLT_CODE"].ToString(), "OC", UTIL.emSerialFormat.YYMMDD, "", bizExe);
                        paramRowOutCost["YPGO_ID"] = row["YPGO_ID"];
                        paramRowOutCost["OUT_ID"] = out_id;
                        paramRowOutCost["PART_CODE"] = row["PART_CODE"];
                        paramRowOutCost["QTY"] = outQty;
                        paramRowOutCost["COST"] = row["UNIT_COST"];
                        paramRowOutCost["AMT"] = paramRowOutCost["COST"].toDecimal() * paramRowOutCost["QTY"].toDecimal();
                        paramTableOutCost.Rows.Add(paramRowOutCost);
                    }

                    //출고수량이 남을경우 재고수량 부족
                    if (qty > 0)
                    {
                        throw UTIL.SetException("재고 수량이 부족합니다."
                                                            , dr["PART_CODE"].toStringEmpty()
                                                            , new System.Diagnostics.StackFrame().GetMethod().Name
                                                            , BizException.ABORT, dr);
                    }


                    DMAT.TMAT_OUT_COST.TMAT_OUT_COST_INS(paramTableOutCost, bizExe);

                    DMAT.TMAT_OUT.TMAT_OUT_INS(UTIL.GetRowToDt(dr), bizExe);


                    if (dr["OUT_REQ_QTY"].toInt32() > (dr["O_OUT_QTY"].toInt32() + dr["OUT_QTY"].toInt32()))
                        dr["OUT_REQ_STAT"] = "51";     //부분불출
                    else
                        dr["OUT_REQ_STAT"] = "52";     //불출완료

                    DMAT.TMAT_OUT_REQ.TMAT_OUT_REQ_UPD(UTIL.GetRowToDt(dr), bizExe);


                    #region 출고
                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                    paramRow["TYPE"] = "OUT";
                    paramRow["PART_CODE"] = dr["PART_CODE"];
                    paramRow["STOCK_LOC"] = dr["OUT_LOC"];
                    paramRow["PART_QTY"] = dr["OUT_QTY"];
                    paramRow["OUT_ID"] = out_id;

                    paramRow["PROD_CODE"] = dr["PROD_CODE"];
                    paramTable.Rows.Add(paramRow);
                    CTRL.CTRL.SET_STOCK_PROCESS(paramRow, bizExe, "PART_CODE", "STOCK_LOC", "PART_QTY", "AMT", "", "OUT_ID");
                    #endregion

                    //출하지시
                    if (dr["IS_SHIP"].ToString() == "1" && dr["OUT_REQ_STAT"].ToString() == "52")
                    {
                        DataTable prodRslt = DORD.TORD_PRODUCT.TORD_PRODUCT_SER(UTIL.GetRowToDt(dr), bizExe);

                        if (prodRslt.Rows.Count == 1)
                        {
                            if (prodRslt.Rows[0]["PROD_KIND"].ToString() == "IE")
                            {
                                if (dr["IS_SHIP"].ToString() == "1")
                                {
                                    DORD.TORD_PRODUCT.TORD_PRODUCT_UPD3(UTIL.GetRowToDt(dr), bizExe);
                                }
                            }
                        }
                    }
                }

                return MAT03A_SER(UTIL.GetDtToDs(paramDS.Tables["RQSTDT_SER"]), bizExe);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet MAT03A_INS2(DataSet paramDS, BizExecute.BizExecute bizExe)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "OUT_REQ_STAT", "53", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", "2", typeof(byte));

                DataTable paramTable = new DataTable();
                paramTable.Columns.Add("PLT_CODE", typeof(String));
                paramTable.Columns.Add("STK_ID", typeof(String));
                paramTable.Columns.Add("TYPE", typeof(String));
                paramTable.Columns.Add("PART_CODE", typeof(String));
                paramTable.Columns.Add("DETAIL_PART_NAME", typeof(String));
                paramTable.Columns.Add("STOCK_LOC", typeof(String));
                paramTable.Columns.Add("PART_QTY", typeof(String));
                paramTable.Columns.Add("AMT", typeof(String));
                paramTable.Columns.Add("YPGO_ID", typeof(String));
                paramTable.Columns.Add("OUT_ID", typeof(String));

                DataTable paramTableOutCost = new DataTable();
                paramTableOutCost.Columns.Add("PLT_CODE", typeof(String));
                paramTableOutCost.Columns.Add("OC_ID", typeof(String));
                paramTableOutCost.Columns.Add("YPGO_ID", typeof(String));
                paramTableOutCost.Columns.Add("OUT_ID", typeof(String));
                paramTableOutCost.Columns.Add("PART_CODE", typeof(String));
                paramTableOutCost.Columns.Add("QTY", typeof(String));
                paramTableOutCost.Columns.Add("COST", typeof(String));
                paramTableOutCost.Columns.Add("AMT", typeof(String));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    paramTable.Clear();
                    paramTableOutCost.Clear();

                    DMAT.TMAT_OUT.TMAT_OUT_UPD2(UTIL.GetRowToDt(row), bizExe);
                    DMAT.TMAT_OUT_REQ.TMAT_OUT_REQ_UPD(UTIL.GetRowToDt(row), bizExe);

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                    paramRow["TYPE"] = "OUT_CANCEL";
                    paramRow["OUT_ID"] = row["OUT_ID"];
                    paramTable.Rows.Add(paramRow);
                    CTRL.CTRL.SET_STOCK_PROCESS(paramRow, bizExe, "PART_CODE", "STOCK_LOC", "PART_QTY", "AMT", "", "OUT_ID");

                }
                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet MAT03A_UPD2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PROD_STATE", "10", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "SHIP_FLAG", "1", typeof(string));
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DORD.TORD_PRODUCT.TORD_PRODUCT_UPD3(UTIL.GetRowToDt(row), bizExecute);
                }
                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet MAT03A_UPD3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DMAT.TMAT_OUT.TMAT_OUT_UPD4(UTIL.GetRowToDt(row), bizExecute);
                }
                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
        public static DataSet MAT03A_UPD4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DMAT.TMAT_OUT_REQ.TMAT_OUT_REQ_UPD4(UTIL.GetRowToDt(row), bizExecute);
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
