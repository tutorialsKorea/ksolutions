using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BQCT
{
    public class QCT01A
    {
        public static DataSet QCT01A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSHP.TSHP_NG_QUERY.TSHP_NG_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.Columns.Add("SEL", typeof(string));
                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
        public static DataSet QCT01A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSHP.TSHP_NG.TSHP_NG_SER5(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.Columns.Add("SEL", typeof(string));
                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet QCT01A_SER4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "IS_DES_CHANGE", "1", typeof(string));

                DataTable dtRslt = DMAT.TMAT_PARTLIST_QUERY.TMAT_PARTLIST_QUERY2_3(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.Columns.Add("SEL", typeof(string));
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
        /// 사내 불량 대책 처리
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        public static DataSet QCT01A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtParam = paramDS.Tables["RQSTDT"];

                dtParam.Columns.Add("NG_QTY", typeof(Int32));
                dtParam.Columns.Add("ACTUAL_ID", typeof(String));

                foreach (DataRow dr in dtParam.Rows)
                {
                    DataTable dtSer = DSHP.TSHP_NG.TSHP_NG_SER(UTIL.GetRowToDt(dr), bizExecute);

                    if (dtSer.Rows.Count > 0)
                    {
                        //불량 내용 수정
                        DSHP.TSHP_NG.TSHP_NG_UPD(UTIL.GetRowToDt(dr), bizExecute);
                    }
                    else
                    {
                        //사내 불량 추가
                        dr["NG_ID"] = UTIL.UTILITY_GET_SERIALNO(dr["PLT_CODE"].ToString(), "NG", UTIL.emSerialFormat.YYYYMMDD, "", bizExecute);

                        DataTable dtNG = UTIL.GetRowToDt(dr);

                        UTIL.SetBizAddColumnToValue(dtNG, "DATA_FLAG", 0, typeof(Byte));
                        UTIL.SetBizAddColumnToValue(dtNG, "NG_STATE", "W", typeof(String));

                        DSHP.TSHP_NG.TSHP_NG_INS2(dtNG, bizExecute);
                    }

                    DataTable dtSum = DSHP.TSHP_NG.TSHP_NG_SER4(dtParam, bizExecute);

                    if (dtSum.Rows.Count > 0)
                        dr["NG_QTY"] = dtSum.Rows[0]["TOT_QTY"];
                    else
                        dr["NG_QTY"] = 0;

                    dr["ACTUAL_ID"] = dr["LINK_KEY"];
                    if (dr["ACT_TYPE"].ToString() == "W")
                        DSHP.TSHP_ACTUAL.TSHP_ACTUAL_UPD4(UTIL.GetRowToDt(dr), bizExecute);
                    else
                        DSHP.TSHP_MANACTUAL.TSHP_MANACTUAL_UPD2(UTIL.GetRowToDt(dr), bizExecute);

                }

                return QCT01A_SER(paramDS, bizExecute);

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 사내불량대책 완료 처리
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        public static DataSet QCT01A_INS2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtParam = paramDS.Tables["RQSTDT"];

                //dtParam.Columns.Add("NG_MEASURE_EMP", typeof(String));
                dtParam.Columns.Add("NG_STATE", typeof(String));
                dtParam.Columns.Add("NG_QTY", typeof(Int32));

                UTIL.SetBizAddColumnToValue(dtParam, "WK_NG_QTY", "QUANTITY");


                foreach (DataRow row in dtParam.Rows)
                {
                    DataTable dtSer = DSHP.TSHP_NG_QUERY.TSHP_NG_QUERY2(UTIL.GetRowToDt(row), bizExecute);

                    if (dtSer.Rows.Count <= 0)
                    {
                        throw UTIL.SetException("유효하지 않은 데이터"
                                      , row["NG_ID"].ToString()
                                      , new System.Diagnostics.StackFrame().GetMethod().Name
                                      , BizException.UNVALID_DATA);
                    }
                    else
                    {
                        string ngType = dtSer.Rows[0]["NG_TYPE"].ToString();

                        if (ngType == "")
                        {
                            throw UTIL.SetException("불량 형태 존재하지 않음."
                                      , row["NG_ID"].ToString()
                                      , new System.Diagnostics.StackFrame().GetMethod().Name
                                      , BizException.NOT_EXISTS_NGTYPE);
                        }

                        if (row["NG_MEASURE_EMP"].ToString() == "")
                        {
                            row["NG_MEASURE_EMP"] = row["REG_EMP"];
                        }

                        row["NG_STATE"] = "C";

                        DSHP.TSHP_NG.TSHP_NG_UPD2(UTIL.GetRowToDt(row), bizExecute);

                        //불량아님과 특채인경우
                        //작업지시에 불량수량 마이너스
                        //최근실적에서 불량수량 마이너스

                        //다음공정들 계획 수량 차감?? 확인필요

                        if (ngType == "N" || ngType == "S")
                        {
                            DataTable woRslt = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER(UTIL.GetRowToDt(row), bizExecute);

                            if (woRslt.Rows.Count > 0)
                            {
                                DataTable woTable = new DataTable("RQSTDT");
                                woTable.Columns.Add("PLT_CODE", typeof(string));
                                woTable.Columns.Add("WO_NO", typeof(string));
                                woTable.Columns.Add("NG_QTY", typeof(int));

                                DataRow woRow = woTable.NewRow();
                                woRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                                woRow["WO_NO"] = row["WO_NO"];
                                woRow["NG_QTY"] = woRslt.Rows[0]["NG_QTY"].toInt() - row["WK_NG_QTY"].toInt();
                                woTable.Rows.Add(woRow);

                                DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD39(woTable, bizExecute);
                            }


                            DataTable dtActRslt = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY33(UTIL.GetRowToDt(row), bizExecute);

                            if (dtActRslt.Rows.Count > 0)
                            {
                                DataTable actTable = new DataTable("RQSTDT");
                                actTable.Columns.Add("PLT_CODE", typeof(string));
                                actTable.Columns.Add("ACTUAL_ID", typeof(string));
                                actTable.Columns.Add("NG_QTY", typeof(int));

                                DataRow actRow = actTable.NewRow();
                                actRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                                actRow["ACTUAL_ID"] = dtActRslt.Rows[0]["ACTUAL_ID"];
                                actRow["NG_QTY"] = dtActRslt.Rows[0]["NG_QTY"].toInt() - row["WK_NG_QTY"].toInt();
                                actTable.Rows.Add(actRow);

                                DSHP.TSHP_ACTUAL.TSHP_ACTUAL_UPD9(actTable, bizExecute);
                            }

                            row["WK_NG_QTY"] = 0;

                            //확정 불량 수량 저장
                            DSHP.TSHP_NG.TSHP_NG_UPD3(UTIL.GetRowToDt(row), bizExecute);
                        }
                        else
                        {
                            //최종불량 수량이 등록된 불량수량과 다르면
                            //작업지시와 최근 실적 불량수량을 변경
                            //(기존 작지 불량수량 - 등록된 불량수량 + 최종불량수량)
                            int ngQty = row["WK_NG_QTY"].toInt();
                            if (row["WK_NG_QTY"].toInt() != dtSer.Rows[0]["QUANTITY"].toInt())
                            {
                                DataTable woRslt = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER(UTIL.GetRowToDt(row), bizExecute);

                                if (woRslt.Rows.Count > 0)
                                {
                                    DataTable woTable = new DataTable("RQSTDT");
                                    woTable.Columns.Add("PLT_CODE", typeof(string));
                                    woTable.Columns.Add("WO_NO", typeof(string));
                                    woTable.Columns.Add("NG_QTY", typeof(int));

                                    DataRow woRow = woTable.NewRow();
                                    woRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                                    woRow["WO_NO"] = row["WO_NO"];
                                    woRow["NG_QTY"] = woRslt.Rows[0]["NG_QTY"].toInt() - dtSer.Rows[0]["QUANTITY"].toInt() + row["WK_NG_QTY"].toInt();
                                    woTable.Rows.Add(woRow);

                                    DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD39(woTable, bizExecute);
                                }


                                DataTable dtActRslt = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY33(UTIL.GetRowToDt(row), bizExecute);

                                if (dtActRslt.Rows.Count > 0)
                                {
                                    DataTable actTable = new DataTable("RQSTDT");
                                    actTable.Columns.Add("PLT_CODE", typeof(string));
                                    actTable.Columns.Add("ACTUAL_ID", typeof(string));
                                    actTable.Columns.Add("NG_QTY", typeof(int));

                                    DataRow actRow = actTable.NewRow();
                                    actRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                                    actRow["ACTUAL_ID"] = dtActRslt.Rows[0]["ACTUAL_ID"];
                                    actRow["NG_QTY"] = dtActRslt.Rows[0]["NG_QTY"].toInt() - dtSer.Rows[0]["QUANTITY"].toInt() + row["WK_NG_QTY"].toInt();
                                    actTable.Rows.Add(actRow);

                                    DSHP.TSHP_ACTUAL.TSHP_ACTUAL_UPD9(actTable, bizExecute);
                                }
                            }

                            //확정 불량 수량 저장
                            DSHP.TSHP_NG.TSHP_NG_UPD3(UTIL.GetRowToDt(row), bizExecute);
                        }

                        //if (ngType == "N")
                        //{
                        //    //불량 수량 0으로 수정.
                        //    if (dtSer.Rows[0]["ACT_TYPE"].ToString() == "W")
                        //        DSHP.TSHP_ACTUAL.TSHP_ACTUAL_UPD4(UTIL.GetRowToDt(row), bizExecute);
                        //    else
                        //        DSHP.TSHP_MANACTUAL.TSHP_MANACTUAL_UPD2(UTIL.GetRowToDt(row), bizExecute);
                        //}

                        ////PROD, PART로 마지막 공정 지시 찾기.  TSHP_WORKORDER_QUERY12
                        //DataTable dtWoSer = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY12(UTIL.GetRowToDt(row), bizExecute);

                        //if (dtWoSer.Rows.Count > 0)
                        //{
                        //    row["WO_NO"] = dtWoSer.Rows[0]["WO_NO"];

                        //    //작업지시에 불량 수량 증가
                        //    DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD10(UTIL.GetRowToDt(row), bizExecute);
                        //}

                        ////불량 확정 시 해당 실적 찾아서 양품 수량에서 차감 처리
                        //DataTable dtActual = DSHP.TSHP_ACTUAL.TSHP_ACTUAL_SER2(dtSer, bizExecute);

                        //if (dtActual.Rows.Count > 0)
                        //{
                        //    dtActual.Rows[0]["OK_QTY"] = dtActual.Rows[0]["OK_QTY"].toInt32() - row["WK_NG_QTY"].toInt32();

                        //    DSHP.TSHP_ACTUAL.TSHP_ACTUAL_UPD5(dtActual, bizExecute);

                        //}


                    }
                }

                return QCT01A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 불량 삭제
        /// </summary>
        /// <param name="paramDS">NG_ID</param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet QCT01A_INS3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtParam = paramDS.Tables["RQSTDT"];

                foreach (DataRow row in dtParam.Rows)
                {
                    DataTable dtSer = DSHP.TSHP_NG_QUERY.TSHP_NG_QUERY2(UTIL.GetRowToDt(row), bizExecute);

                    if (dtSer.Rows.Count <= 0)
                    {
                        throw UTIL.SetException("유효하지 않은 데이터"
                                      , row["NG_ID"].ToString()
                                      , new System.Diagnostics.StackFrame().GetMethod().Name
                                      , BizException.UNVALID_DATA);
                    }
                    else
                    {

                        string ngState = dtSer.Rows[0]["NG_STATE"].ToString();

                        if (ngState == "C")     //대책 완료
                        {
                            throw UTIL.SetException("대책 완료 상태는 삭제 불가합니다."
                                      , row["NG_ID"].ToString()
                                      , new System.Diagnostics.StackFrame().GetMethod().Name
                                      , BizException.CANNOT_DELETE);
                        }


                        //불량 내역 삭제
                        DSHP.TSHP_NG.TSHP_NG_DEL(UTIL.GetRowToDt(row), bizExecute);

                        //불량 수량 0으로 수정.
                        if (dtSer.Rows[0]["ACT_TYPE"].ToString() == "W")
                            DSHP.TSHP_ACTUAL.TSHP_ACTUAL_UPD4(UTIL.GetRowToDt(row), bizExecute);
                        else
                            DSHP.TSHP_MANACTUAL.TSHP_MANACTUAL_UPD2(UTIL.GetRowToDt(row), bizExecute);

                    }
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        //확정 불량 수량 변경
        public static DataSet QCT01A_INS4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtParam = paramDS.Tables["RQSTDT"];

                foreach (DataRow row in dtParam.Rows)
                {
                    DataTable dtSer = DSHP.TSHP_NG_QUERY.TSHP_NG_QUERY2(UTIL.GetRowToDt(row), bizExecute);

                    if (dtSer.Rows.Count <= 0)
                    {
                        throw UTIL.SetException("유효하지 않은 데이터"
                                      , row["NG_ID"].ToString()
                                      , new System.Diagnostics.StackFrame().GetMethod().Name
                                      , BizException.UNVALID_DATA);
                    }
                    else
                    {
                        //확정수량이 변경될떄
                        if (row["OLD_WK_NG_QTY"].toInt() != row["WK_NG_QTY"].toInt())
                        {
                            //불량정보 확정불량 수량 변경
                            DSHP.TSHP_NG.TSHP_NG_UPD3(UTIL.GetRowToDt(row), bizExecute);

                            //작업지시 불량 수량 변경
                            //최근 실적 불량 수량 변경
                            //해당 작업지시에 불량수량을 더한다.
                            DataTable dtWoRslt = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER(UTIL.GetRowToDt(row), bizExecute);

                            if (dtWoRslt.Rows.Count > 0)
                            {
                                DataTable woTable = new DataTable("RQSTDT");
                                woTable.Columns.Add("PLT_CODE", typeof(string));
                                woTable.Columns.Add("WO_NO", typeof(string));
                                woTable.Columns.Add("NG_QTY", typeof(int));

                                DataRow woRow = woTable.NewRow();
                                woRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                                woRow["WO_NO"] = row["WO_NO"];
                                woRow["NG_QTY"] = dtWoRslt.Rows[0]["NG_QTY"].toInt() - row["OLD_WK_NG_QTY"].toInt() + row["WK_NG_QTY"].toInt();
                                woTable.Rows.Add(woRow);

                                DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD39(woTable, bizExecute);
                            }

                            //가공실적에 대해서만 가져온다?
                            //해당 작업지시 마지막 실적에 불량수량 더한다.
                            DataTable dtActRslt = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY33(UTIL.GetRowToDt(row), bizExecute);

                            if (dtActRslt.Rows.Count > 0)
                            {
                                DataTable actTable = new DataTable("RQSTDT");
                                actTable.Columns.Add("PLT_CODE", typeof(string));
                                actTable.Columns.Add("ACTUAL_ID", typeof(string));
                                actTable.Columns.Add("NG_QTY", typeof(int));

                                DataRow actRow = actTable.NewRow();
                                actRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                                actRow["ACTUAL_ID"] = dtActRslt.Rows[0]["ACTUAL_ID"];
                                actRow["NG_QTY"] = dtActRslt.Rows[0]["NG_QTY"].toInt() - row["OLD_WK_NG_QTY"].toInt() + row["WK_NG_QTY"].toInt();
                                actTable.Rows.Add(actRow);

                                DSHP.TSHP_ACTUAL.TSHP_ACTUAL_UPD9(actTable, bizExecute);
                            }
                        }


                        ////PROD, PART로 마지막 공정 지시 찾기.  TSHP_WORKORDER_QUERY12
                        //DataTable dtWoSer = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY12(UTIL.GetRowToDt(row), bizExecute);

                        //if (dtWoSer.Rows.Count > 0)
                        //{
                        //    row["WO_NO"] = dtWoSer.Rows[0]["WO_NO"];

                        //    //작업지시에 불량 수량 증가
                        //    DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD11(UTIL.GetRowToDt(row), bizExecute);
                        //}

                        ////불량 확정 시 해당 실적 찾아서 양품 수량에서 차감 처리
                        //DataTable dtActual = DSHP.TSHP_ACTUAL.TSHP_ACTUAL_SER2(dtSer, bizExecute);

                        //if (dtActual.Rows.Count > 0)
                        //{
                        //    dtActual.Rows[0]["OK_QTY"] = dtActual.Rows[0]["OK_QTY"].toInt32() + row["OLD_WK_NG_QTY"].toInt32()
                        //            - row["WK_NG_QTY"].toInt32();

                        //    DSHP.TSHP_ACTUAL.TSHP_ACTUAL_UPD5(dtActual, bizExecute);

                        //}
                    }

                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet QCT01A_INS5(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    //#region ITEM_CODE 생성 (공통)
                    //string newItemCode = "";
                    //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "VEN_CODE", row["CVND_CODE"], typeof(String));
                    //DataTable dtRsltV = DSTD.TSTD_VENDOR.TSTD_VENDOR_SER(UTIL.GetRowToDt(row), bizExecute);
                    //if (dtRsltV.Rows.Count > 0)
                    //{
                    //    string sKey_Gubun = dtRsltV.Rows[0]["ITEM_AUTO_CODE"].ToString();
                    //    string sKey_YY = DateTime.Now.Year.ToString().Substring(2, 2);
                    //    string sKey_MM = DateTime.Now.Month.ToString();
                    //    if (DateTime.Now.Month < 10)
                    //    {
                    //        sKey_MM = "0" + sKey_MM;
                    //    }
                    //    //string sKey_Seq = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "ITEM", UTIL.emSerialFormat.YY, "", bizExecute);
                    //    string sKey_Seq = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), sKey_Gubun, UTIL.emSerialFormat.YY, "-", bizExecute);

                    //    newItemCode = sKey_Gubun + sKey_YY + sKey_MM + "-" + sKey_Seq.Substring(4, 4);
                    //}
                    //else
                    //{
                    //    throw UTIL.SetException("거래처의 수주 구분이 존재하지 않습니다."
                    //         , new System.Diagnostics.StackFrame().GetMethod().Name);
                    //}

                    //#endregion

                    row["NG_PROD_CODE"] = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "PROD", row["ITEM_CODE"].ToString(), "-", bizExecute);

                    //DORD.TORD_PRODUCT.TORD_PRODUCT_COPY2(UTIL.GetRowToDt(row), bizExecute);

                    DQCT.TQCT_PURCHASE_NG.TQCT_PURCHASE_NG_UPD2(UTIL.GetRowToDt(row), bizExecute);
                }

				#region 입고완료 처리
				UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_YPGO"], "BAL_STAT", "22", typeof(String));

                DOUT.TOUT_PROCBALJU.TOUT_PROCBALJU_UPD2(paramDS.Tables["RQSTDT_YPGO"], bizExecute);

                DOUT.TOUT_TEMP_YPGO.TOUT_TEMP_YPGO_UPD3(paramDS.Tables["RQSTDT_YPGO"], bizExecute);

                foreach (DataRow dr in paramDS.Tables["RQSTDT_YPGO"].Rows)
                {
                    DataTable paramTableWO = new DataTable("RQSTDT");
                    paramTableWO.Columns.Add("PLT_CODE", typeof(String));
                    paramTableWO.Columns.Add("WO_NO", typeof(String));
                    paramTableWO.Columns.Add("WO_FLAG", typeof(Int32));
                    //paramTableWO.Columns.Add("ACT_END_TIME", typeof(DateTime));

                    DataRow paramRowWo = paramTableWO.NewRow();
                    paramRowWo["PLT_CODE"] = dr["PLT_CODE"];
                    paramRowWo["WO_NO"] = dr["WO_NO"];
                    paramRowWo["WO_FLAG"] = "4";            //완료

                    //string ypgo_date = dr["YPGO_DATE"].ToString();

                    //DateTime ypgo_time = new DateTime(System.Convert.ToInt32(ypgo_date.Substring(0, 4)),
                    //     System.Convert.ToInt32(ypgo_date.Substring(4, 2)),
                    //     System.Convert.ToInt32(ypgo_date.Substring(6, 2)),
                    //     DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);


                    //paramRowWo["ACT_END_TIME"] = ypgo_time;

                    paramTableWO.Rows.Add(paramRowWo);

                    DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD5_5(paramTableWO, bizExecute);
                }
				#endregion

				return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }



        public static DataSet QCT01A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSHP.TSHP_NG_QUERY.TSHP_NG_QUERY6(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.Columns.Add("SEL", typeof(string));
                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        //재발주 처리
        public static DataSet QCT01A_INS6(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataTable dtRqst = paramDS.Tables["RQSTDT"];

                string balju_num; int balju_seq = 1;

                DataTable dtNG = DQCT.TQCT_PURCHASE_NG.TQCT_PURCHASE_NG_SER(dtRqst, bizExecute);
                
                if (dtRqst.Rows[0]["BALJU_GUBUN"].ToString() == "MB")
                {
                    DataTable dtBaljuMaster = DMAT.TMAT_BALJU_MASTER.TMAT_BALJU_MASTER_SER(dtRqst, bizExecute);

                    if (dtBaljuMaster.Rows.Count > 0)
                    {
                        balju_num = UTIL.UTILITY_GET_SERIALNO(dtRqst.Rows[0]["PLT_CODE"].ToString(), "MB",
                            UTIL.emSerialFormat.YYMMDD, "", bizExecute);

                        dtBaljuMaster.Rows[0]["BALJU_NUM"] = balju_num;
                        dtBaljuMaster.Rows[0]["BALJU_DATE"] = DateTime.Today.ToString("yyyyMMdd");

                        DMAT.TMAT_BALJU_MASTER.TMAT_BALJU_MASTER_INS(dtBaljuMaster, bizExecute);

                        DataTable dtBalju = DMAT.TMAT_BALJU.TMAT_BALJU_SER(dtRqst, bizExecute);
                        dtBalju.Rows[0]["BALJU_NUM"] = balju_num;
                        dtBalju.Rows[0]["BALJU_SEQ"] = balju_seq;
                        dtBalju.Rows[0]["QTY"] = dtNG.Rows[0]["NG_QTY"];
                        dtBalju.Rows[0]["AMT"] = dtNG.Rows[0]["NG_QTY"].toInt() * dtBalju.Rows[0]["UNIT_COST"].toDouble();
                        dtBalju.Rows[0]["SCOMMENT"] = "불량으로 인한 재발주(시스템)";
                        dtBalju.Rows[0]["BAL_STAT"] = "11";

                        if (dtBalju.Rows[0]["INS_FLAG"].ToString() == "2")
                            dtBalju.Rows[0]["BAL_STAT"] = "20";

                        DMAT.TMAT_BALJU.TMAT_BALJU_INS(dtBalju, bizExecute);
                    }
                }
                else
                {
                    DataTable paramTableWO = new DataTable("RQSTDT");
                    paramTableWO.Columns.Add("PLT_CODE", typeof(String));
                    paramTableWO.Columns.Add("WO_NO", typeof(String));
                    paramTableWO.Columns.Add("WO_FLAG", typeof(Int32));
                    paramTableWO.Columns.Add("PLN_START_TIME", typeof(String));
                    paramTableWO.Columns.Add("PLN_END_TIME", typeof(String));
                    paramTableWO.Columns.Add("ACT_START_TIME", typeof(DateTime));
                    paramTableWO.Columns.Add("MC_CODE", typeof(String));

                    DataTable dtBaljuMaster = DOUT.TOUT_PROCBALJU_MASTER.TOUT_PROCBALJU_MASTER_SER(dtRqst, bizExecute);

                    if (dtBaljuMaster.Rows.Count > 0)
                    {
                        balju_num = UTIL.UTILITY_GET_SERIALNO(dtRqst.Rows[0]["PLT_CODE"].ToString(), "OB",
                            UTIL.emSerialFormat.YYMMDD, "", bizExecute);

                        DateTime balju_date = dtBaljuMaster.Rows[0]["BALJU_DATE"].toDateString("yyyy-MM-dd").toDateTime();

                        dtBaljuMaster.Rows[0]["BALJU_NUM"] = balju_num;
                        dtBaljuMaster.Rows[0]["BALJU_DATE"] = DateTime.Today.ToString("yyyyMMdd");

                        DOUT.TOUT_PROCBALJU_MASTER.TOUT_PROCBALJU_MASTER_INS(dtBaljuMaster, bizExecute);
                        
                        DataTable dtBalju = DOUT.TOUT_PROCBALJU.TOUT_PROCBALJU_SER(dtRqst, bizExecute);

                        DateTime due_date_old = dtBalju.Rows[0]["DUE_DATE"].toDateString("yyyy-MM-dd").toDateTime();

                        dtBalju.Rows[0]["BALJU_NUM"] = balju_num;
                        dtBalju.Rows[0]["BALJU_SEQ"] = balju_seq;
                        dtBalju.Rows[0]["QTY"] = dtNG.Rows[0]["NG_QTY"];
                        dtBalju.Rows[0]["AMT"] = dtNG.Rows[0]["NG_QTY"].toInt() * dtBalju.Rows[0]["UNIT_COST"].toDouble();
                        dtBalju.Rows[0]["SCOMMENT"] = "불량으로 인한 재발주(시스템)";
                        dtBalju.Rows[0]["BAL_STAT"] = "11";


                        if (dtBalju.Rows[0]["INS_FLAG"].ToString() == "2")
                            dtBalju.Rows[0]["BAL_STAT"] = "20";

                        DOUT.TOUT_PROCBALJU.TOUT_PROCBALJU_INS(dtBalju, bizExecute);

                        DateTime balju_time = DateTime.Now;
                        TimeSpan ts = due_date_old.Subtract(balju_date);
                        DateTime due_date = DateTime.Today.AddDays(ts.Days);

                        DataRow paramRowWo = paramTableWO.NewRow();
                        paramRowWo["PLT_CODE"] = dtBalju.Rows[0]["PLT_CODE"];
                        paramRowWo["WO_NO"] = dtBalju.Rows[0]["WO_NO"];
                        paramRowWo["WO_FLAG"] = 2;            //진행
                        paramRowWo["PLN_START_TIME"] = balju_time.ToString("yyyyMMddHHmm"); //paramDS.Tables["RQSTDT_M"].Rows[0]["BALJU_DATE"].ToString() + "0000";
                        paramRowWo["PLN_END_TIME"] = due_date.ToString("yyyyMMddHHmm"); //paramDS.Tables["RQSTDT_M"].Rows[0]["DUE_DATE"].ToString() + "0000";
                        paramRowWo["ACT_START_TIME"] = balju_time;
                        paramTableWO.Rows.Add(paramRowWo);

                        DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD5(paramTableWO, bizExecute);

                    }
                }



                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        //불량 내용 갱신
        public static DataSet QCT01A_INS7(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataTable dtRqst = paramDS.Tables["RQSTDT"];

                DQCT.TQCT_PURCHASE_NG.TQCT_PURCHASE_NG_UPD4(dtRqst, bizExecute);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        //불량 처리 완료
        public static DataSet QCT01A_INS8(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataTable dtRqst = paramDS.Tables["RQSTDT"];

                DQCT.TQCT_PURCHASE_NG.TQCT_PURCHASE_NG_UPD3(dtRqst, bizExecute);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

    }
}
