using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;
//using ControlManager;

namespace BPUR
{
    public class PUR14A
    {
        //공정외주 발주가능건 조회
        public static DataSet PUR14A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DOUT.TOUT_PROCBALJU_QUERY.TOUT_PROCBALJU_QUERY18(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.Columns.Add("SEL");

                dtRslt.TableName = "RSLTDT";

                paramDS.Merge(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 공정외주 발주
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet PUR14A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //정입고 이후 재고 증가해야함으로 여기서는 재고증가 X
                //아래 내용은 잘못됨

                //검사대기 수량과 비교
                //1. 불량 수량 0이고 - 재고 증가(TSHP_STOCK_LOG,TSHP_STOCK, LSE_STD_PART)
                //  1) 원래 부분 검사이면, '부분 물품입고'
                //  2) 검사대기면, '물품입고'
                //2. 불량이 1 이상이면 - OK 수량, 불량처리가 특채인것 재고증가(TSHP_STOCK_LOG,TSHP_STOCK, LSE_STD_PART)
                //  1) '부분 물품입고'
                //  2) 불량 검사 결과 저장 (TQCT_PURCHASE_NG)
                //  3) 재발주체크된 품목은 발주 처리

                foreach(DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable rsltRow = DOUT.TOUT_TEMP_YPGO.TOUT_TEMP_YPGO_SER(UTIL.GetRowToDt(row), bizExecute);

                    if(rsltRow.Rows.Count > 0)
                    {
                        //초기 상태값 '물품입고'
                        string chkStat = "41";
                        if (row["NG_QTY"].toInt32() == 0)
                        {
                            //불량수량이 없는것
                            if (row["TYP_STAT"].ToString().Equals("20"))
                            {
                                //검사 대기
                                chkStat = "41";
                            }
                            else if (row["TYP_STAT"].ToString().Equals("42"))
                            {
                                //부분 검사 대기
                                chkStat = "40";
                            }

                            //재고 증가
                        }
                        else
                        {
                            //1:반품(금액차감으로 하기로하였음 2020-05-26) 4:특채
                            if(row["NG_TYPE"].ToString().Equals("1")
                             || row["NG_TYPE"].ToString().Equals("4"))
                            {

                            }

                            //불량수량이 존재 하는것
                            //불량수량이 존재한다면 부분이건 전체이건 상관없이 부분이 입고될뿐이다.
                            chkStat = "40";

                            #region 불량검사 결과 저장
                            foreach (DataRow ngRow in paramDS.Tables["RQSTDT_NG"].Select("TYP_ID='" + row["TYP_ID"] + "'"))
                            {
                                DataTable qctTable = new DataTable();
                                qctTable.Columns.Add("PLT_CODE", typeof(String));
                                qctTable.Columns.Add("NG_ID", typeof(String));
                                qctTable.Columns.Add("TYP_ID", typeof(String));
                                qctTable.Columns.Add("NG_QTY", typeof(decimal));
                                qctTable.Columns.Add("NG_TYPE", typeof(String));
                                qctTable.Columns.Add("NG_COST", typeof(Decimal));
                                qctTable.Columns.Add("CHECK_DATE", typeof(String));

                                DataRow qctRow = qctTable.NewRow();
                                qctRow["PLT_CODE"] = row["PLT_CODE"];
                                qctRow["NG_ID"] = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "PNG", UTIL.emSerialFormat.YYMM, "", bizExecute);
                                qctRow["TYP_ID"] = row["TYP_ID"];
                                qctRow["NG_QTY"] = row["NG_QTY"];
                                qctRow["NG_TYPE"] = ngRow["NG_TYPE"];
                                qctRow["NG_COST"] = ngRow["NG_COST"];
                                qctRow["CHECK_DATE"] = ngRow["CHECK_DATE"];
                                qctTable.Rows.Add(qctRow);

                                DQCT.TQCT_PURCHASE_NG.TQCT_PURCHASE_NG_INS(qctTable, bizExecute);
                            }
                            #endregion

                            #region 재발주 처리
                            // 재발주 컬럼 숨겼음
                            //if(row["RE_BALJU"].ToString().Equals("2"))
                            //{

                            //}
                            #endregion
                        }

                        DataTable paramTable = new DataTable();
                        paramTable.Columns.Add("PLT_CODE", typeof(String));
                        paramTable.Columns.Add("TYP_ID", typeof(String));
                        paramTable.Columns.Add("TYP_STAT", typeof(String));
                        paramTable.Columns.Add("INS_DATE", typeof(String));
                        paramTable.Columns.Add("CHECK_DATE", typeof(String));

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = row["PLT_CODE"];
                        paramRow["TYP_ID"] = row["TYP_ID"];
                        paramRow["INS_DATE"] = row["INS_DATE"];
                        paramRow["CHECK_DATE"] = row["CHECK_DATE"];
                        paramRow["TYP_STAT"] = chkStat;
                        paramTable.Rows.Add(paramRow);
                        DOUT.TOUT_TEMP_YPGO.TOUT_TEMP_YPGO_UPD4(paramTable, bizExecute);

                        DataTable paramTableBALJU = new DataTable("BALJU");
                        paramTableBALJU.Columns.Add("BAL_STAT", typeof(String)); //
                        paramTableBALJU.Columns.Add("PLT_CODE", typeof(String)); //
                        paramTableBALJU.Columns.Add("BALJU_NUM", typeof(String)); //
                        paramTableBALJU.Columns.Add("BALJU_SEQ", typeof(Int32)); //


                        DataRow paramRowBALJU = paramTableBALJU.NewRow();
                        paramRowBALJU["BAL_STAT"] = row["TYP_STAT"];
                        paramRowBALJU["PLT_CODE"] = row["PLT_CODE"];
                        paramRowBALJU["BALJU_NUM"] = row["BALJU_NUM"];
                        paramRowBALJU["BALJU_SEQ"] = row["BALJU_SEQ"];
                        paramTableBALJU.Rows.Add(paramRowBALJU);

                        //발주상태 변경
                        DOUT.TOUT_PROCBALJU.TOUT_PROCBALJU_UPD2(paramTableBALJU, bizExecute);
                    }
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        //자재발주 수정
        public static DataSet PUR14A_CANCEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTable.Columns.Add("BALJU_NUM", typeof(String)); //
                    paramTable.Columns.Add("BALJU_SEQ", typeof(String)); //
                    paramTable.Columns.Add("BAL_STAT", typeof(String)); //
                    paramTable.Columns.Add("TYP_ID", typeof(String)); //

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = row["PLT_CODE"];
                    paramRow["BALJU_NUM"] = row["BALJU_NUM"];
                    paramRow["BALJU_SEQ"] = row["BALJU_SEQ"];
                    paramRow["TYP_ID"] = row["TYP_ID"];
                    
                    if(row["BAL_STAT"].Equals("20"))
                    {
                        paramRow["BAL_STAT"] = "13";
                    }
                    if (row["BAL_STAT"].Equals("42"))
                    {
                        paramRow["BAL_STAT"] = "13";
                    }

                    paramTable.Rows.Add(paramRow);

                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    //삭제
                    DOUT.TOUT_TEMP_YPGO.TOUT_TEMP_YPGO_DEL(paramTable, bizExecute);

                    //수정
                    DOUT.TOUT_PROCBALJU.TOUT_PROCBALJU_UPD2(paramTable, bizExecute);



                    DataSet dsRsltPUR = BPUR.PUR05C.PUR05C_SER_PO(paramSet, bizExecute);

                    DataTable paramTableWK = new DataTable("RQSTDT");
                    paramTableWK.Columns.Add("WO_FLAG", typeof(String)); //
                                                                         //paramTableWK.Columns.Add("ACT_END_TIME", typeof(DateTime)); //
                                                                         //paramTableWK.Columns.Add("ACT_MAN_TIME", typeof(String)); //
                    paramTableWK.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTableWK.Columns.Add("WO_NO", typeof(String)); //
                    paramTableWK.Columns.Add("INS_DATE", typeof(String));
                    paramTableWK.Columns.Add("INS_FLAG", typeof(Decimal)); //
                    paramTableWK.Columns.Add("IS_YPGO", typeof(Decimal)); //
                                                                          //paramTableWK.Columns.Add("ACT_QTY", typeof(Int32)); //
                    if (dsRsltPUR.Tables["RSLTDT"].Rows.Count > 0)
                    {
                        DataRow paramRowWK = paramTableWK.NewRow();
                        paramRowWK["WO_FLAG"] = dsRsltPUR.Tables["RSLTDT"].Rows[0]["WO_FLAG"];
                        paramRowWK["PLT_CODE"] = dsRsltPUR.Tables["RSLTDT"].Rows[0]["PLT_CODE"];
                        paramRowWK["WO_NO"] = dsRsltPUR.Tables["RSLTDT"].Rows[0]["WO_NO"];
                        paramRowWK["INS_FLAG"] = 0;
                        paramRowWK["IS_YPGO"] = 0;      //입고됐다는 표시
                        paramTableWK.Rows.Add(paramRowWK);

                        //작업지시상태 변경
                        DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD5_6(paramTableWK, bizExecute);
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
