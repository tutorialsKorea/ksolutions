using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;
using System.Drawing;
using Zebra.Printing;

namespace BPOP
{
    public class POP03A
    {


        public static DataSet POP03A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WO_TYPE", "MIL", typeof(string));

                DataTable dtRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY14(paramDS.Tables["RQSTDT"], bizExecute);

                UTIL.SetBizAddColumnToValue(dtRslt, "DATA_FLAG", 0, typeof(Byte), true);

                UTIL.SetBizAddColumnToValue(dtRslt, "WO_TYPE", "MIL", typeof(string), true);
                UTIL.SetBizAddColumnToValue(dtRslt, "NOT_WO_NO", "WO_NO");

                DataTable dtWoRslt = dtRslt.Clone();

                Dictionary<string, bool> chainDic = new Dictionary<string, bool>();

                foreach (DataRow row in dtRslt.Rows)
                {
                    if (row["CHAIN_WO_NO"].ToString() != "")
                    {
                        if (!chainDic.ContainsKey(row["CHAIN_WO_NO"].ToString()))
                        {
                            chainDic.Add(row["CHAIN_WO_NO"].ToString(), true);
                        }
                        else
                        {
                            DataRow[] rows = dtWoRslt.Select("WO_NO = '" + row["WO_NO"].ToString() + "'");
                            if (rows.Length > 0)
                            {
                                dtWoRslt.Rows.Remove(rows[0]);
                            }
                            continue;
                        }

                        DataTable paramTable = new DataTable("RQSTDT");
                        paramTable.Columns.Add("PLT_CODE", typeof(string));
                        paramTable.Columns.Add("NOT_WO_NO", typeof(string));
                        paramTable.Columns.Add("WO_TYPE", typeof(string));
                        paramTable.Columns.Add("CHAIN_WO_NO", typeof(string));
                        paramTable.Columns.Add("DATA_FLAG", typeof(Byte));

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = row["PLT_CODE"];
                        paramRow["NOT_WO_NO"] = row["NOT_WO_NO"];
                        paramRow["WO_TYPE"] = row["WO_TYPE"];
                        paramRow["CHAIN_WO_NO"] = row["CHAIN_WO_NO"];
                        paramRow["DATA_FLAG"] = 0;

                        paramTable.Rows.Add(paramRow);

                        DataTable dtChainWoRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY14(paramTable, bizExecute);

                        foreach (DataRow cRow in dtChainWoRslt.Rows)
                        {
                            DataRow newRow = dtWoRslt.NewRow();
                            newRow.ItemArray = cRow.ItemArray;
                            dtWoRslt.Rows.Add(newRow);
                        }
                    }
                }

                if (dtWoRslt.Rows.Count > 0)
                {
                    dtRslt.Merge(dtWoRslt);
                }

                DataView dv = dtRslt.DefaultView;
                //dv.Sort = "DUE_DATE ASC, PROD_PRIORITY ASC";
                dv.Sort = "MIL_REQ_DATE ASC, PROD_PRIORITY ASC, PART_CODE ASC";

                dtRslt = dv.ToTable();


                chainDic.Clear();

                DataTable dtRsltWo = dtRslt.Clone();

                foreach (DataRow row in dtRslt.Rows)
                {
                    if (row["CHAIN_WO_NO"].ToString() != "")
                    {
                        if (!chainDic.ContainsKey(row["CHAIN_WO_NO"].ToString()))
                        {
                            chainDic.Add(row["CHAIN_WO_NO"].ToString(), true);
                        }
                        else
                        {
                            continue;
                        }

                        DataRow[] rows = dtRslt.Select("CHAIN_WO_NO = '" + row["CHAIN_WO_NO"].ToString() + "'");

                        foreach (DataRow rw in rows)
                        {
                            DataRow newRow = dtRsltWo.NewRow();
                            newRow.ItemArray = rw.ItemArray;
                            dtRsltWo.Rows.Add(newRow);
                        }

                    }
                    else
                    {
                        DataRow newRow = dtRsltWo.NewRow();
                        newRow.ItemArray = row.ItemArray;
                        dtRsltWo.Rows.Add(newRow);
                    }
                }


                dtRsltWo.Columns.Add("SEL");
                dtRsltWo.Columns.Add("BTN_END", typeof(Bitmap));
                dtRsltWo.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRsltWo);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }



        /// <summary>
        /// 수주별 공정 조회
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet POP03A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "POP03A", "1", typeof(String));

                DataTable dtRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY29(paramDS.Tables["RQSTDT"], bizExecute);

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
        ///   밀링
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet POP03A_SAVE(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte), true);
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PROC_STAT", 4, typeof(Byte), true);
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WO_FLAG", "4", typeof(string), true);
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WORK_DATE", DateTime.Now.ToString("yyyyMMdd"), typeof(string), true);
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "REAL_OUT_QTY", "OUT_QTY");
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "REAL_IN_QTY", 0, typeof(decimal));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WO_TYPE", "PRC");
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "TOTAL_PAGE", paramDS.Tables["RQSTDT"].Rows.Count, typeof(decimal));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PAGE", 0, typeof(int));

                int idx = 1;

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtSer = DSHP.TSHP_ACTUAL_MILL.TSHP_ACTUAL_MILL_SER2(UTIL.GetRowToDt(row), bizExecute);

                    bool is_out = true;

                    if (dtSer.Rows.Count > 0)
                    {
                        DataRow oldRow = dtSer.Rows[0];
                        row["ACTUAL_ID"] = dtSer.Rows[0]["ACTUAL_ID"];
                        DSHP.TSHP_ACTUAL_MILL.TSHP_ACTUAL_MILL_UPD(UTIL.GetRowToDt(row), bizExecute);

                        DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD34(UTIL.GetRowToDt(row), bizExecute);

                        //#region 실적 취소
                        //if (oldRow["ACT_QTY"].toInt() > 0)
                        //{

                        //    DataTable paramTable = new DataTable();
                        //    paramTable.Columns.Add("PLT_CODE", typeof(String));
                        //    paramTable.Columns.Add("ACTUAL_ID", typeof(String));
                        //    paramTable.Columns.Add("DATA_FLAG", typeof(String));

                        //    DataRow paramRow = paramTable.NewRow();
                        //    paramRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                        //    paramRow["ACTUAL_ID"] = oldRow["ACTUAL_ID"];
                        //    paramRow["DATA_FLAG"] = 0;

                        //    paramTable.Rows.Add(paramRow);
                        //    //해당 실적에 소모된 Lot/절단 수량 Log 가져오기
                        //    DataTable dtLot = DSHP.TSHP_ACTUAL_LOT_LOG.TSHP_ACTUAL_LOT_LOG_SER(paramTable, bizExecute);
                        //    //사용된 절단 수량 해당 Lot에 더해주기
                        //    DMAT.TMAT_STOCK_LOT.TMAT_STOCK_LOT_UPD6(dtLot, bizExecute);
                        //    //사용된 실적 절단 수량 Log 삭제
                        //    DSHP.TSHP_ACTUAL_LOT_LOG.TSHP_ACTUAL_LOT_LOG_UDE(paramTable, bizExecute);
                            
                        //}
                        //#endregion

                        //불출 수량이 틀리거나, 품목코드가 틀리거나, 불출 유무가 변경됐을경우 불출 취소 처리
                        if (oldRow["MAT_OUT"].Equals("1") && (oldRow["OUT_QTY"].toInt() != row["OUT_QTY"].toInt()
                            || oldRow["MAT_OUT"].ToString() != oldRow["MAT_OUT"].ToString()
                            || oldRow["MAT_CODE"].ToString() != oldRow["MAT_CODE"].ToString()))
                        {
                            row["REAL_IN_QTY"] = oldRow["OUT_QTY"];

                            if (oldRow["MAT_CODE"].ToString() == oldRow["MAT_CODE"].ToString())
                            {
                                if(oldRow["OUT_QTY"].toInt() > row["OUT_QTY"].toInt())
                                {
                                    row["REAL_OUT_QTY"] = 0;
                                    row["REAL_IN_QTY"] = oldRow["OUT_QTY"].toInt() - row["OUT_QTY"].toInt();
                                }
                                else
                                {
                                    row["REAL_OUT_QTY"] = row["OUT_QTY"].toInt() - oldRow["OUT_QTY"].toInt();
                                    row["REAL_IN_QTY"] = 0;
                                }
                            }

                            #region 불출취소
                            DataTable paramTable = new DataTable();
                            paramTable.Columns.Add("PLT_CODE", typeof(String));
                            paramTable.Columns.Add("STK_ID", typeof(String));
                            paramTable.Columns.Add("TYPE", typeof(String));
                            paramTable.Columns.Add("PART_CODE", typeof(String));
                            paramTable.Columns.Add("DETAIL_PART_NAME", typeof(String));
                            //paramTable.Columns.Add("STOCK_LOC", typeof(String));
                            paramTable.Columns.Add("PART_QTY", typeof(String));
                            paramTable.Columns.Add("AMT", typeof(String));
                            paramTable.Columns.Add("YPGO_ID", typeof(String));
                            paramTable.Columns.Add("OUT_ID", typeof(String));
                            paramTable.Columns.Add("WO_TYPE", typeof(String));

                            DataRow paramRow = paramTable.NewRow();
                            paramRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                            paramRow["TYPE"] = "OUT_CANCEL_MIL";
                            paramRow["PART_CODE"] = oldRow["OUT_MAT_CODE"];//불출 소재
                            //paramRow["STOCK_LOC"] = null;
                            paramRow["PART_QTY"] = row["REAL_IN_QTY"].toInt();
                            paramRow["OUT_ID"] = oldRow["WO_NO"];
                            //paramRow["WO_TYPE"] = "MIL";
                            paramTable.Rows.Add(paramRow);
                            try
                            {
                                if(paramRow["PART_QTY"].toInt() > 0)
                                    CTRL.CTRL.SET_STOCK_PROCESS(paramRow, bizExecute, "PART_CODE", "STOCK_LOC", "PART_QTY", "AMT", "", "OUT_ID");
                            }
                            catch(Exception ex) {
                                //BizException bex = ex.Data as BizException;
                                //if (bex.ErrNumber == BizException.STOCK_ERROR)
                                throw ex;
                            }
                            #endregion
                        }                        
                    }
                    else
                    {
                        row["ACTUAL_ID"] = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "MACT", bizExecute);

                        DSHP.TSHP_ACTUAL_MILL.TSHP_ACTUAL_MILL_INS(UTIL.GetRowToDt(row), bizExecute);

                        DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD32(UTIL.GetRowToDt(row), bizExecute);
                    }


                    //불출
                    if (row["MAT_OUT"].Equals("1"))
                    {
                        #region 재고불출
                        DataTable paramTable = new DataTable();
                        paramTable.Columns.Add("PLT_CODE", typeof(String));
                        paramTable.Columns.Add("STK_ID", typeof(String));
                        paramTable.Columns.Add("TYPE", typeof(String));
                        paramTable.Columns.Add("PART_CODE", typeof(String));
                        paramTable.Columns.Add("DETAIL_PART_NAME", typeof(String));
                        //paramTable.Columns.Add("STOCK_LOC", typeof(String));
                        paramTable.Columns.Add("PART_QTY", typeof(String));
                        paramTable.Columns.Add("AMT", typeof(String));
                        paramTable.Columns.Add("YPGO_ID", typeof(String));
                        paramTable.Columns.Add("OUT_ID", typeof(String));

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                        paramRow["TYPE"] = "OUT";
                        paramRow["PART_CODE"] = row["OUT_MAT_CODE"];//불출소재
                        //paramRow["STOCK_LOC"] = "5";
                        paramRow["PART_QTY"] = row["REAL_OUT_QTY"].toInt();
                        paramRow["OUT_ID"] = row["WO_NO"];
                        paramTable.Rows.Add(paramRow);
                        CTRL.CTRL.SET_STOCK_PROCESS(paramRow, bizExecute, "PART_CODE", "STOCK_LOC", "PART_QTY", "AMT", "", "OUT_ID");
                        #endregion

                    }

                    row["PAGE"] = idx;
                    idx++;

                    //바코드(QR) 출력
                    barcodePrint(row, bizExecute);

                    //#region 실적 처리 원판 처리
                    //if (row["ACT_QTY"].toInt() > 0)
                    //{
                    //    DataTable paramTable = new DataTable();
                    //    paramTable.Columns.Add("PLT_CODE", typeof(String));
                    //    paramTable.Columns.Add("PART_CODE", typeof(String));
                    //    paramTable.Columns.Add("OUT_ID", typeof(String));
                    //    paramTable.Columns.Add("WO_TYPE", typeof(String));

                    //    DataRow paramRow = paramTable.NewRow();
                    //    paramRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                    //    paramRow["PART_CODE"] = row["MAT_CODE"];//사용 소재
                    //    paramRow["OUT_ID"] = row["WO_NO"];
                    //    paramRow["WO_TYPE"] = "MIL";
                    //    paramTable.Rows.Add(paramRow);

                    //    //밀링 작업지시에 의해 불출된 소재 목록 조회
                    //    DataTable dtLot = DMAT.TMAT_STOCK_LOT_QUERY.TMAT_STOCK_LOT_QUERY3(paramTable, bizExecute);

                    //    UTIL.SetBizAddColumnToValue(dtLot, "USE_AMT", 0, typeof(decimal),true);
                    //    UTIL.SetBizAddColumnToValue(dtLot, "ACTUAL_ID", row["ACTUAL_ID"], typeof(string), true);
                    //    UTIL.SetBizAddColumnToValue(dtLot, "DATA_FLAG", 0, typeof(byte), true);

                    //    dtLot.DefaultView.Sort = "CUTTING_CNT,REG_DATE";

                    //    int out_qty = row["ACT_QTY"].toInt();
                    //    int in_qty = 0;
                    //    foreach (DataRow lotRow in dtLot.Rows)
                    //    {
                    //        //int std_cutting_cnt = lotRow["STD_CUTTING_CNT"].toInt();

                    //        int cutting_cnt = lotRow["CUTTING_CNT"].toInt();

                    //        if (out_qty > cutting_cnt )
                    //        {
                    //            out_qty = out_qty - cutting_cnt;
                    //            in_qty = 0;
                    //        }
                    //        else
                    //        {
                    //            in_qty = cutting_cnt - out_qty;
                    //            out_qty = 0;
                    //            break;
                    //        }

                    //        lotRow["CUTTING_CNT"] = in_qty;

                    //        DMAT.TMAT_STOCK_LOT.TMAT_STOCK_LOT_UPD5(UTIL.GetRowToDt(lotRow), bizExecute);

                    //        lotRow["USE_AMT"] = cutting_cnt - in_qty;

                    //        DSHP.TSHP_ACTUAL_LOT_LOG.TSHP_ACTUAL_LOT_LOG_INS(UTIL.GetRowToDt(lotRow), bizExecute);
                    //    }
                    //    //불출된 소재가 없거나 모자를경우 임의 사용 목록 추가 추후 어떻게 처리할지 논의 필요할듯******
                    //    if(out_qty  > 0)
                    //    {
                    //        DataTable dtMinusLot = new DataTable();                            
                    //        UTIL.SetBizAddColumnToValue(dtMinusLot, "PLT_CODE", ConnInfo.PLT_CODE, typeof(string));
                    //        UTIL.SetBizAddColumnToValue(dtMinusLot, "PART_CODE", row["MAT_CODE"], typeof(string));
                    //        UTIL.SetBizAddColumnToValue(dtMinusLot, "USE_AMT", out_qty, typeof(decimal));
                    //        UTIL.SetBizAddColumnToValue(dtMinusLot, "ACTUAL_ID", row["ACTUAL_ID"], typeof(string));
                    //        UTIL.SetBizAddColumnToValue(dtMinusLot, "DATA_FLAG", 0, typeof(byte));
                    //        //UTIL.SetBizAddColumnToValue(dtMinusLot, "LOT_ID", UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "SLOT", bizExecute),typeof(string));
                    //        DSHP.TSHP_ACTUAL_LOT_LOG.TSHP_ACTUAL_LOT_LOG_INS(dtMinusLot, bizExecute);
                    //    }
                    //}
                    //#endregion

                }

                return POP03A_SER(paramDS,bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }




        //밀링 실적 취소
        public static DataSet POP03A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte), true);
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "REAL_IN_QTY", 0, typeof(decimal));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                   
                    DataTable dtSer = DSHP.TSHP_ACTUAL_MILL.TSHP_ACTUAL_MILL_SER2(UTIL.GetRowToDt(row), bizExecute);

                    if (dtSer.Rows.Count > 0)
                    {
                        DataRow oldRow = dtSer.Rows[0];

                        row["REAL_IN_QTY"] = oldRow["OUT_QTY"];
                        row["ACTUAL_ID"] = dtSer.Rows[0]["ACTUAL_ID"];
                        // 실적 삭제
                        DSHP.TSHP_ACTUAL_MILL.TSHP_ACTUAL_MILL_DEL(UTIL.GetRowToDt(row), bizExecute);

                        // 작지 상태 변경
                        DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD36(UTIL.GetRowToDt(row), bizExecute);

                        //// 가공 소재 불출수량 만큼 원상복구
                        //#region 실적 취소
                        //if (oldRow["ACT_QTY"].toInt() > 0)
                        //{
                        //    DataTable paramTable = new DataTable();
                        //    paramTable.Columns.Add("PLT_CODE", typeof(String));
                        //    paramTable.Columns.Add("ACTUAL_ID", typeof(String));
                        //    paramTable.Columns.Add("DATA_FLAG", typeof(String));

                        //    DataRow paramRow = paramTable.NewRow();
                        //    paramRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                        //    paramRow["ACTUAL_ID"] = oldRow["ACTUAL_ID"];
                        //    paramRow["DATA_FLAG"] = 0;

                        //    paramTable.Rows.Add(paramRow);
                        //    //해당 실적에 소모된 Lot/절단 수량 Log 가져오기
                        //    DataTable dtLot = DSHP.TSHP_ACTUAL_LOT_LOG.TSHP_ACTUAL_LOT_LOG_SER(paramTable, bizExecute);
                        //    //사용된 절단 수량 해당 Lot에 더해주기
                        //    DMAT.TMAT_STOCK_LOT.TMAT_STOCK_LOT_UPD6(dtLot, bizExecute);
                        //    //사용된 실적 절단 수량 Log 삭제
                        //    DSHP.TSHP_ACTUAL_LOT_LOG.TSHP_ACTUAL_LOT_LOG_UDE(paramTable, bizExecute);
                        //}
                        //#endregion


                        #region 불출취소
                        DataTable paramTable2 = new DataTable();
                        paramTable2.Columns.Add("PLT_CODE", typeof(String));
                        paramTable2.Columns.Add("STK_ID", typeof(String));
                        paramTable2.Columns.Add("TYPE", typeof(String));
                        paramTable2.Columns.Add("PART_CODE", typeof(String));
                        paramTable2.Columns.Add("DETAIL_PART_NAME", typeof(String));
                        //paramTable.Columns.Add("STOCK_LOC", typeof(String));
                        paramTable2.Columns.Add("PART_QTY", typeof(String));
                        paramTable2.Columns.Add("AMT", typeof(String));
                        paramTable2.Columns.Add("YPGO_ID", typeof(String));
                        paramTable2.Columns.Add("OUT_ID", typeof(String));
                        paramTable2.Columns.Add("WO_TYPE", typeof(String));

                        DataRow paramRow2 = paramTable2.NewRow();
                        paramRow2["PLT_CODE"] = ConnInfo.PLT_CODE;
                        paramRow2["TYPE"] = "OUT_CANCEL_MIL";
                        paramRow2["PART_CODE"] = oldRow["OUT_MAT_CODE"];//불출 소재
                                                                       //paramRow["STOCK_LOC"] = null;
                        paramRow2["PART_QTY"] = row["REAL_IN_QTY"].toInt();
                        paramRow2["OUT_ID"] = oldRow["WO_NO"];
                        //paramRow["WO_TYPE"] = "MIL";
                        paramTable2.Rows.Add(paramRow2);
                        try
                        {
                            if (paramRow2["PART_QTY"].toInt() > 0)
                                CTRL.CTRL.SET_STOCK_PROCESS(paramRow2, bizExecute, "PART_CODE", "STOCK_LOC", "PART_QTY", "AMT", "", "OUT_ID");
                        }
                        catch (Exception ex)
                        {
                            //BizException bex = ex.Data as BizException;
                            //if (bex.ErrNumber == BizException.STOCK_ERROR)
                            throw ex;
                        }
                        #endregion

                    }
                }

                return POP03A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }



        /// <summary>
        ///   밀링 작업완료
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        //public static DataSet POP03A_UPD(DataSet paramDS, BizExecute.BizExecute bizExecute)
        //{
        //    try
        //    {
        //        UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte), true);
        //        UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PROC_STAT", 4, typeof(Byte), true);
        //        UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WO_FLAG", "4", typeof(string), true);
        //        UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WORK_DATE", DateTime.Now.ToString("yyyyMMdd"), typeof(string), true);

        //        foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
        //        {
        //            DataTable dtSer = DSHP.TSHP_ACTUAL_MILL.TSHP_ACTUAL_MILL_SER(UTIL.GetRowToDt(row), bizExecute);

        //            if (dtSer.Rows.Count > 0)
        //            {
        //                DSHP.TSHP_ACTUAL_MILL.TSHP_ACTUAL_MILL_UPD2(UTIL.GetRowToDt(row), bizExecute);
        //            }
        //            else
        //            {
        //                row["ACTUAL_ID"] = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "CACT", bizExecute);

        //                DSHP.TSHP_ACTUAL_MILL.TSHP_ACTUAL_MILL_INS(UTIL.GetRowToDt(row), bizExecute);
        //            }

        //            DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD34(UTIL.GetRowToDt(row), bizExecute);
        //        }


        //        return POP03A_SER(paramDS, bizExecute);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
        //    }
        //}

        public static DataSet POP03A_PRINT(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "TOTAL_PAGE", paramDS.Tables["RQSTDT"].Rows.Count, typeof(decimal));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PAGE", 0, typeof(int));

                int idx = 1;
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    row["PAGE"] = idx;
                    idx++;
                    barcodePrint(row, bizExecute);
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
        static void barcodePrint(DataRow row, BizExecute.BizExecute bizExecute)
        {
            //DataTable mcStartRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY35(UTIL.GetRowToDt(row), bizExecute);

            DataTable sideTable = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY35(UTIL.GetRowToDt(row), bizExecute);

            DataTable prodTalbe =DORD.TORD_PRODUCT.TORD_PRODUCT_SER(UTIL.GetRowToDt(row), bizExecute);

            DataTable matparamTable = new DataTable();
            matparamTable.Columns.Add("PLT_CODE", typeof(String));
            matparamTable.Columns.Add("PART_CODE", typeof(String));

            DataRow matparamRow = matparamTable.NewRow();
            matparamRow["PLT_CODE"] = ConnInfo.PLT_CODE;
            matparamRow["PART_CODE"] = row["MAT_CODE"];
            matparamTable.Rows.Add(matparamRow);

            DataTable matRslt = DLSE.LSE_STD_PART.LSE_STD_PART_SER(matparamTable, bizExecute);

            DataTable mcGroupparamTable = new DataTable();
            mcGroupparamTable.Columns.Add("PLT_CODE", typeof(String));
            mcGroupparamTable.Columns.Add("CAT_CODE", typeof(String));
            mcGroupparamTable.Columns.Add("CD_CODE", typeof(String));

            DataRow mcGroupparamRow = mcGroupparamTable.NewRow();
            mcGroupparamRow["PLT_CODE"] = ConnInfo.PLT_CODE;
            mcGroupparamRow["CAT_CODE"] = "C020";
            mcGroupparamRow["CD_CODE"] = row["MC_GROUP"];
            mcGroupparamTable.Rows.Add(mcGroupparamRow);

            DataTable mcGroupRslt = DSTD.TSTD_CODES.TSTD_CODES_SER(mcGroupparamTable, bizExecute);


            string mcGroup = "";
            //string mcStart = "";
            string prodName = "";
            string partID = "";
            string matName = "";
            string matSize = "";
            string prodCode = "";
            string cvndName = "";
            string prodQty = "";
            string barcode = "";

            string dueDate = "";
            string isSide = "";
            string Pcnt = "";
            string totalPage = "";
            string page = "";
            string camEmp = "";

            string milReqDate = "";

            string scomment = "";

            if (row["PROD_PRIORITY"].ToString() == "긴급")
            {
                milReqDate = row["PROD_PRIORITY"].ToString() + "  ";
            }
            

            if (mcGroupRslt.Rows.Count > 0) mcGroup = mcGroupRslt.Rows[0]["CD_NAME"].ToString();

            //if (mcStartRslt.Rows.Count > 0)
            //{
            //    DateTime mcStartTime = mcStartRslt.Rows[0]["PLN_START_TIME"].toDateTime();

            //    string am_pm = "";
            //    if (mcStartTime.Hour < 12 && mcStartTime.Minute < 1)
            //    {
            //        am_pm = "오전";
            //    }
            //    else
            //    {
            //        am_pm = "오후";
            //    }

            //    mcStart = mcStartTime.ToString("yyyy-MM-dd") + " " + am_pm;
            //}


            prodName = row["PROD_NAME"].ToString();
            partID = row["PART_CODE"].ToString() + ";-" + row["PART_NAME"].ToString();
            //if (matRslt.Rows.Count > 0) matName = matRslt.Rows[0]["PART_NAME"].ToString();
            matName = row["MAT_QLTY"].ToString();

            string tvalue = row["T_VALUE"].ToString() + "T";

            if (row["T_VALUE"].ToString() == "")
            {
                tvalue = "";
            }

            matSize = row["X_VALUE"].ToString() + "x" + row["Y_VALUE"].ToString() + "x" + tvalue;

            prodCode = row["PROD_CODE"].ToString();
            cvndName = row["CVND_NAME"].ToString();

            if (cvndName.Length > 14)
            {
                cvndName = cvndName.Substring(0, 13) + "..";
            }

            //prodQty = row["PROD_QTY"].ToString();
            prodQty = row["PART_QTY"].ToString();

            barcode = row["PROD_CODE"].ToString() + ";" + row["PART_CODE"].ToString();

            //dueDate = row["DUE_DATE"].toDateString("yyyy-MM-dd");
            if (prodTalbe.Rows.Count > 0)
            {
                if (prodTalbe.Rows[0]["DUE_DATE"].ToString().Length == 8)
                {
                    //dueDate = prodTalbe.Rows[0]["DUE_DATE"].ToString().Substring(0, 4) + "-" + prodTalbe.Rows[0]["DUE_DATE"].ToString().Substring(4, 2) + "-" + prodTalbe.Rows[0]["DUE_DATE"].ToString().Substring(6, 2);
                    dueDate = prodTalbe.Rows[0]["DUE_DATE"].ToString().Substring(4, 2) + "-" + prodTalbe.Rows[0]["DUE_DATE"].ToString().Substring(6, 2);
                }
            }

            if (sideTable.Rows.Count > 0)
            {
                isSide = "(측면)";
            }

            
            Pcnt = row["P_CNT"].ToString();
            totalPage = row["TOTAL_PAGE"].ToString();
            page = row["PAGE"].ToString();
            camEmp = row["CAM_EMP_NAME"].ToString();

            if (row["MIL_REQ_DATE"].ToString().Length == 8)
            {
                string milReq = row["MIL_REQ_DATE"].ToString();
                milReqDate += milReq.Substring(0, 4) + "-" + milReq.Substring(4, 2) + "-" + milReq.Substring(6, 2);
            }

            if (row["MIL_REQ_DATE"].ToString().Length > 8)
            {
                string milReq = System.Convert.ToDateTime(row["MIL_REQ_DATE"].ToString()).ToString("yyyyMMdd");
                milReqDate += milReq.Substring(0, 4) + "-" + milReq.Substring(4, 2) + "-" + milReq.Substring(6, 2);
            }

            prodQty = prodQty + " / " + Pcnt;

            if (partID.Length > 27)
            {
                partID = partID.Substring(0, 26) + ".." + " (" + page + "/" + totalPage + ")";
            }
            else
            {
                partID = partID + "  (" + page + "/" + totalPage + ")";
            }

            

            scomment = row["SCOMMENT"].ToString();


            if (camEmp.Length > 11)
            {
                camEmp = camEmp.Substring(0, 10) + "..";
            }

            //if (matSize.Length > 10)
            //{
            //    matSize = camEmp.Substring(0, 8) + "..";
            //}

            if (cvndName.Length > 11)
            {
                cvndName = cvndName.Substring(0, 10) + "..";
            }

            

            if (prodName.Length > 31)
            {
                prodName = prodName.Substring(0, 30) + "..";
            }
            
                
            DataTable barcodeTable = new DataTable();
            barcodeTable.Columns.Add("MC_GROUP", typeof(string));
            barcodeTable.Columns.Add("MC_START_TIME", typeof(string));
            barcodeTable.Columns.Add("PROD_NAME", typeof(string));
            barcodeTable.Columns.Add("PART_ID", typeof(string));
            barcodeTable.Columns.Add("MAT_NAME", typeof(string));
            barcodeTable.Columns.Add("MAT_SIZE", typeof(string));
            barcodeTable.Columns.Add("PROD_CODE", typeof(string));
            barcodeTable.Columns.Add("PROD_QTY", typeof(string));
            barcodeTable.Columns.Add("CVND_NAME", typeof(string));
            barcodeTable.Columns.Add("BARCODE", typeof(string));

            barcodeTable.Columns.Add("DUE_DATE", typeof(string));
            barcodeTable.Columns.Add("P_CNT", typeof(string));
            barcodeTable.Columns.Add("CAM_EMP_NAME", typeof(string));
            barcodeTable.Columns.Add("IS_SIDE", typeof(string));
            barcodeTable.Columns.Add("MIL_REQ_DATE", typeof(string));

            barcodeTable.Columns.Add("SCOMMENT0", typeof(string));
            barcodeTable.Columns.Add("SCOMMENT1", typeof(string));
            barcodeTable.Columns.Add("SCOMMENT2", typeof(string));
            barcodeTable.Columns.Add("SCOMMENT3", typeof(string));
            barcodeTable.Columns.Add("SCOMMENT4", typeof(string));
            barcodeTable.Columns.Add("SCOMMENT5", typeof(string));
            barcodeTable.Columns.Add("SCOMMENT6", typeof(string));
            barcodeTable.Columns.Add("SCOMMENT7", typeof(string));
            barcodeTable.Columns.Add("SCOMMENT8", typeof(string));
            barcodeTable.Columns.Add("SCOMMENT9", typeof(string));

            DataRow barcodeRow = barcodeTable.NewRow();
            barcodeRow["MC_GROUP"] = mcGroup;// + isSide;
            //barcodeRow["MC_START_TIME"] = mcStart;
            barcodeRow["PROD_NAME"] = prodName;
            barcodeRow["PART_ID"] = partID;
            barcodeRow["MAT_NAME"] = matName;
            barcodeRow["MAT_SIZE"] = matSize;
            barcodeRow["PROD_CODE"] = prodCode;
            barcodeRow["PROD_QTY"] = prodQty;
            barcodeRow["CVND_NAME"] = cvndName;
            barcodeRow["BARCODE"] = barcode;

            barcodeRow["DUE_DATE"] = dueDate;
            barcodeRow["CAM_EMP_NAME"] = camEmp;
            barcodeRow["IS_SIDE"] = isSide;
            barcodeRow["MIL_REQ_DATE"] = milReqDate;

            string[] strs = scomment.Split('\n');

            for (int i = 0; i < strs.Length; i++)
            {
                if (i > 9) break;

                strs[i] = strs[i].Trim();

                barcodeRow["SCOMMENT" + (i).ToString()] = strs[i];

                if (i == 9)
                {
                    if (strs.Length > 9)
                    {
                        barcodeRow["SCOMMENT" + (i).ToString()] = barcodeRow["SCOMMENT" + (i).ToString()].ToString() + "..";
                    }
                }
            }

            barcodeTable.Rows.Add(barcodeRow);

            StringBuilder sbBarcode = new StringBuilder();

            sbBarcode.Append(" ^XA");
            sbBarcode.Append(" ^SEE:UHANGUL.DAT^FS");
            sbBarcode.Append(" ^CW1,E:KFONT3.FNT^CI26^FS");
            sbBarcode.Append(" ^CF0,60");
            sbBarcode.Append(" ^FO15,20^GB815,10,2^FS");
            sbBarcode.Append(" ^FO15,30^GB815,435,2^FS");
            sbBarcode.Append(" ^FO30,55");
            sbBarcode.Append(" ^A1N,40,45");
            sbBarcode.Append(" ^FD@MC_GROUP^FS");

            sbBarcode.Append(" ^FO270,55");
            sbBarcode.Append(" ^A1N,35,40");
            sbBarcode.Append(" ^FD@IS_SIDE^FS");

            sbBarcode.Append(" ^FO450,55");
            sbBarcode.Append(" ^A1N,35,35");
            sbBarcode.Append(" ^FD@MIL_REQ_DATE^FS");

            sbBarcode.Append(" ^FO15,110^GB815,3,3^FS");
            sbBarcode.Append(" ^FO550,120^GB270,310,1^FS");

            sbBarcode.Append(" ^FO30,130");
            sbBarcode.Append(" ^A1N,40,25");
            sbBarcode.Append(" ^FD@PROD_NAME^FS");

            sbBarcode.Append(" ^FO560,130");
            sbBarcode.Append(" ^A1N,30,20");
            sbBarcode.Append(" ^FD@SCOMMENT0^FS");

            sbBarcode.Append(" ^FO560,160");
            sbBarcode.Append(" ^A1N,30,20");
            sbBarcode.Append(" ^FD@SCOMMENT1^FS");

            sbBarcode.Append(" ^FO560,190");
            sbBarcode.Append(" ^A1N,30,20");
            sbBarcode.Append(" ^FD@SCOMMENT2^FS");

            sbBarcode.Append(" ^FO560,220");
            sbBarcode.Append(" ^A1N,30,20");
            sbBarcode.Append(" ^FD@SCOMMENT3^FS");

            sbBarcode.Append(" ^FO560,250");
            sbBarcode.Append(" ^A1N,30,20");
            sbBarcode.Append(" ^FD@SCOMMENT4^FS");

            sbBarcode.Append(" ^FO560,280");
            sbBarcode.Append(" ^A1N,30,20");
            sbBarcode.Append(" ^FD@SCOMMENT5^FS");

            sbBarcode.Append(" ^FO560,310");
            sbBarcode.Append(" ^A1N,30,20");
            sbBarcode.Append(" ^FD@SCOMMENT6^FS");

            sbBarcode.Append(" ^FO560,340");
            sbBarcode.Append(" ^A1N,30,20");
            sbBarcode.Append(" ^FD@SCOMMENT7^FS");

            sbBarcode.Append(" ^FO560,370");
            sbBarcode.Append(" ^A1N,30,20");
            sbBarcode.Append(" ^FD@SCOMMENT8^FS");

            sbBarcode.Append(" ^FO560,400");
            sbBarcode.Append(" ^A1N,30,20");
            sbBarcode.Append(" ^FD@SCOMMENT9^FS");

            sbBarcode.Append(" ^FO30,200");
            sbBarcode.Append(" ^A1N,42,25");
            sbBarcode.Append(" ^FD@PART_ID^FS");

            sbBarcode.Append(" ^FO30,270");
            sbBarcode.Append(" ^A1N,42,25");
            sbBarcode.Append(" ^FD@PROD_QTY^FS");

            sbBarcode.Append(" ^FO300,270");
            sbBarcode.Append(" ^A1N,42,25");
            sbBarcode.Append(" ^FD@CAM_EMP_NAME^FS");

            sbBarcode.Append(" ^FO30,340");
            sbBarcode.Append(" ^A1N,42,25");
            sbBarcode.Append(" ^FD@MAT_NAME^FS");

            sbBarcode.Append(" ^FO300,340");
            sbBarcode.Append(" ^A1N,42,25");
            sbBarcode.Append(" ^FD@MAT_SIZE^FS");

            sbBarcode.Append(" ^FO30,410");
            sbBarcode.Append(" ^A1N,42,25");
            sbBarcode.Append(" ^FD@PROD_CODE^FS");

            sbBarcode.Append(" ^FO300,410");
            sbBarcode.Append(" ^A1N,42,25");
            sbBarcode.Append(" ^FD@CVND_NAME^FS");

            sbBarcode.Append(" ^FO560,435");
            sbBarcode.Append(" ^A1N,30,25");
            sbBarcode.Append(" ^FD@DUE_DATE^FS");
            sbBarcode.Append(" ^XZ");



            //sbBarcode.Append(" ^XA");
            //sbBarcode.Append(" ^SEE:UHANGUL.DAT^FS");
            //sbBarcode.Append(" ^CW1,E:KFONT3.FNT^CI26^FS");
            //sbBarcode.Append(" ^CF0,60");
            //sbBarcode.Append(" ^FO15,20^GB815,10,2^FS");
            //sbBarcode.Append(" ^FO15,30^GB815,435,2^FS");
            //sbBarcode.Append(" ^FO30,65");
            //sbBarcode.Append(" ^A1N,40,45");
            //sbBarcode.Append(" ^FD@MC_GROUP^FS");

            //sbBarcode.Append(" ^FO270,65");
            //sbBarcode.Append(" ^A1N,35,40");
            //sbBarcode.Append(" ^FD@IS_SIDE^FS");

            //sbBarcode.Append(" ^FO450,65");
            //sbBarcode.Append(" ^A1N,35,35");
            //sbBarcode.Append(" ^FD@MIL_REQ_DATE^FS");

            //sbBarcode.Append(" ^FO15,120^GB815,3,3^FS");

            //sbBarcode.Append(" ^FO30,140");
            //sbBarcode.Append(" ^A1N,45,30");
            //sbBarcode.Append(" ^FD@PROD_NAME^FS");

            //sbBarcode.Append(" ^FO30,226");
            //sbBarcode.Append(" ^A1N,45,25");
            //sbBarcode.Append(" ^FD@PART_ID^FS");

            //sbBarcode.Append(" ^FO725,226");
            //sbBarcode.Append(" ^A1N,45,25");
            //sbBarcode.Append(" ^FD@PROD_QTY^FS");

            //sbBarcode.Append(" ^FO30,312");
            //sbBarcode.Append(" ^A1N,45,30");
            //sbBarcode.Append(" ^FD@MAT_NAME^FS");

            //sbBarcode.Append(" ^FO340,312");
            //sbBarcode.Append(" ^A1N,45,30");
            //sbBarcode.Append(" ^FD@MAT_SIZE^FS");

            //sbBarcode.Append(" ^FO30,398");
            //sbBarcode.Append(" ^A1N,45,30");
            //sbBarcode.Append(" ^FD@PROD_CODE^FS");

            //sbBarcode.Append(" ^FO300,398");
            //sbBarcode.Append(" ^A1N,45,30");
            //sbBarcode.Append(" ^FD@CVND_NAME^FS");

            //sbBarcode.Append(" ^FO720,398");
            //sbBarcode.Append(" ^A1N,45,30");
            //sbBarcode.Append(" ^FD@DUE_DATE^FS"); 

            //sbBarcode.Append(" ^FO570,312");
            //sbBarcode.Append(" ^A1N,45,30");
            //sbBarcode.Append(" ^FD@CAM_EMP_NAME^FS");
            //sbBarcode.Append(" ^XZ");


            #region
            //sbBarcode.Append(" ^XA");
            //sbBarcode.Append(" ^SEE:UHANGUL.DAT^FS");
            //sbBarcode.Append(" ^CW1,E:KFONT3.FNT^CI26^FS");
            //sbBarcode.Append(" ^CF0,60");
            //sbBarcode.Append(" ^FO15,20^GB815,10,2^FS");
            //sbBarcode.Append(" ^FO15,30^GB815,435,2^FS");
            //sbBarcode.Append(" ^FO30,65");
            //sbBarcode.Append(" ^A1N,40,45");
            //sbBarcode.Append(" ^FD@MC_GROUP^FS");
            //sbBarcode.Append(" ^FO470,65");
            //sbBarcode.Append(" ^A1N,40,40");
            //sbBarcode.Append(" ^FD@DUE_DATE^FS");
            //sbBarcode.Append(" ^FO15,120^GB815,3,3^FS");
            //sbBarcode.Append(" ^FO30,140");
            //sbBarcode.Append(" ^A1N,45,30");
            //sbBarcode.Append(" ^FD@PROD_NAME^FS");
            //sbBarcode.Append(" ^FO30,226");
            //sbBarcode.Append(" ^A1N,45,25");
            //sbBarcode.Append(" ^FD@PART_ID^FS");
            //sbBarcode.Append(" ^FO650,226");
            //sbBarcode.Append(" ^A1N,45,25");
            //sbBarcode.Append(" ^FD@PROD_QTY^FS");
            //sbBarcode.Append(" ^FO30,312");
            //sbBarcode.Append(" ^A1N,45,30");
            //sbBarcode.Append(" ^FD@MAT_NAME^FS");
            //sbBarcode.Append(" ^FO340,312");
            //sbBarcode.Append(" ^A1N,45,30");
            //sbBarcode.Append(" ^FD@MAT_SIZE^FS");
            //sbBarcode.Append(" ^FO30,398");
            //sbBarcode.Append(" ^A1N,45,30");
            //sbBarcode.Append(" ^FD@PROD_CODE^FS");
            //sbBarcode.Append(" ^FO300,398");
            //sbBarcode.Append(" ^A1N,45,30");
            //sbBarcode.Append(" ^FD@CVND_NAME^FS");
            //sbBarcode.Append(" ^FO650,255");
            //sbBarcode.Append(" ^BQN,2,6");
            //sbBarcode.Append(" ^FDQA,@BARCODE^FS");
            //sbBarcode.Append(" ^XZ");
            #endregion

            #region

            //sbBarcode.Append(" ^XA");
            //sbBarcode.Append(" ^SEE:UHANGUL.DAT^FS");
            //sbBarcode.Append(" ^CW1,E:KFONT3.FNT^CI26^FS");
            //sbBarcode.Append(" ^CF0,60");

            //sbBarcode.Append(" ^FO15,20^GB815,10,2^FS");
            //sbBarcode.Append(" ^FO15,30^GB815,435,2^FS");

            //sbBarcode.Append(" ^FO30,55");
            //sbBarcode.Append(" ^A1N,40,40");
            //sbBarcode.Append(" ^FD장비그룹^FS");

            //sbBarcode.Append(" ^FO30,95");
            //sbBarcode.Append(" ^A1N,40,40");
            //sbBarcode.Append(" ^FD@MC_GROUP^FS");

            //sbBarcode.Append(" ^FO582,55");
            //sbBarcode.Append(" ^A1N,40,40");
            //sbBarcode.Append(" ^FD가공 시작일^FS");

            //sbBarcode.Append(" ^FO470,95");
            //sbBarcode.Append(" ^A1N,40,40");
            //sbBarcode.Append(" ^FD@MC_START_TIME^FS");

            //sbBarcode.Append(" ^FO15,150^GB815,3,3^FS");

            //sbBarcode.Append(" ^FO30,170");
            //sbBarcode.Append(" ^A1N,40,40");
            //sbBarcode.Append(" ^FD부품ID/부품명^FS");

            //sbBarcode.Append(" ^FO30,210");
            //sbBarcode.Append(" ^A1N,40,25");
            //sbBarcode.Append(" ^FD@PART_ID^FS");

            //sbBarcode.Append(" ^FO30,270");
            //sbBarcode.Append(" ^A1N,40,40");
            //sbBarcode.Append(" ^FD소재명^FS");

            //sbBarcode.Append(" ^FO30,310");
            //sbBarcode.Append(" ^A1N,40,25");
            //sbBarcode.Append(" ^FD@MAT_NAME^FS");

            //sbBarcode.Append(" ^FO380,270");
            //sbBarcode.Append(" ^A1N,40,40");
            //sbBarcode.Append(" ^FD소재크기^FS");

            //sbBarcode.Append(" ^FO380,310");
            //sbBarcode.Append(" ^A1N,40,25");
            //sbBarcode.Append(" ^FD@MAT_SIZE^FS");

            //sbBarcode.Append(" ^FO30,370");
            //sbBarcode.Append(" ^A1N,40,40");
            //sbBarcode.Append(" ^FD수주번호^FS");

            //sbBarcode.Append(" ^FO30,410");
            //sbBarcode.Append(" ^A1N,40,40");
            //sbBarcode.Append(" ^FD@PROD_CODE^FS");

            //sbBarcode.Append(" ^FO380,370");
            //sbBarcode.Append(" ^A1N,40,40");
            //sbBarcode.Append(" ^FD생산수량^FS");

            //sbBarcode.Append(" ^FO450,410");
            //sbBarcode.Append(" ^A1N,40,40");
            //sbBarcode.Append(" ^FD@PROD_QTY^FS");

            //sbBarcode.Append(" ^FO650,245");
            //sbBarcode.Append(" ^BQN,2,6");
            //sbBarcode.Append(" ^FDQA,@BARCODE^FS");
            //sbBarcode.Append(" ^XZ");

            #endregion

            SendBarcode.SendUsbBarcode(sbBarcode.ToString(), barcodeRow);
        }

    }
}
