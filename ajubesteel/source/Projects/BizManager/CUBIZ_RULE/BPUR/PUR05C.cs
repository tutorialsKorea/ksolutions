using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BPUR
{
    public class PUR05C
    {
        //자재 입고처리가능한 발주건 조회
        public static DataSet PUR05C_SER_M(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DMAT.TMAT_BALJU_QUERY.TMAT_BALJU_QUERY7(paramDS.Tables["RQSTDT"], bizExecute);

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

        //공정외주 입고처리가능한 발주건 조회
        public static DataSet PUR05C_SER_PO(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DOUT.TOUT_PROCBALJU_QUERY.TOUT_PROCBALJU_QUERY5(paramDS.Tables["RQSTDT"], bizExecute);

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

        public static DataSet PUR05C_SER_OI(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DOUT.TOUT_PROCBALJU_QUERY.TOUT_PROCBALJU_QUERY17(paramDS.Tables["RQSTDT"], bizExecute);

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

        //자재 입고
        public static DataSet PUR05C_INS_M(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                string YPGO_STAT = "";
                string SR_CODE = "MY";
                string F_YPGO_STAT = "19";
                string F_TEMP_YPGO_STAT = "20";
                string BAL_STAT = "";
                string MAT_STATE = "ST";
                string ES_TIME = "";
                string PUR_NO_TYPE_REQ = "REQ";
                string PUR_NO_TYPE_BAL = "BAL";
                int WO_FLAG = 4;        //완료;

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    string PLT_CODE = row["PLT_CODE"].ToString();
                    string BALJU_NUM = row["BALJU_NUM"].ToString();
                    string BALJU_SEQ = row["BALJU_SEQ"].ToString();
                    string YPGO_DATE = row["YPGO_DATE"].ToString();
                    string CLOSE_DATE = row["CLOSE_DATE"].ToString();
                    string YPGO_LOC = row["YPGO_LOC"].ToString();
                    string YPGO_LOC_DETAIL = row["YPGO_LOC_DETAIL"].ToString();
                    int QTY = row["QTY"].toInt32();
                    string SCOMMENT = row["SCOMMENT"].ToString();
                    string REG_EMP = row["REG_EMP"].ToString();
                    string INS_FLAG = row["INS_FLAG"].ToString();

                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTable.Columns.Add("BALJU_NUM", typeof(String)); //
                    paramTable.Columns.Add("BALJU_SEQ", typeof(String)); //

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = PLT_CODE;
                    paramRow["BALJU_NUM"] = BALJU_NUM;
                    paramRow["BALJU_SEQ"] = BALJU_SEQ;
                    paramTable.Rows.Add(paramRow);

                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    DataSet dsRsltPUR = BPUR.PUR05C.PUR05C_SER_M(paramSet, bizExecute);

                    //데이터 여부
                    if (dsRsltPUR.Tables["RSLTDT"].Rows.Count != 0)
                    {
                        //품목별 최근 창고 정보 저장
                        if (dsRsltPUR.Tables["RSLTDT"].AsEnumerable().FirstOrDefault() is DataRow fRow)
                        {

                            DataTable locTable = new DataTable();
                            locTable.Columns.Add("PLT_CODE", typeof(String));
                            locTable.Columns.Add("PART_CODE", typeof(String));
                            locTable.Columns.Add("YPGO_LOC", typeof(String));
                            locTable.Columns.Add("YPGO_LOC_DETAIL", typeof(String));
                            locTable.Columns.Add("TL_CODE", typeof(String));

                            DataRow locRow = locTable.NewRow();
                            locRow["PLT_CODE"] = row["PLT_CODE"];
                            locRow["PART_CODE"] = fRow["PART_CODE"];
                            locRow["TL_CODE"] = fRow["PART_CODE"];
                            locRow["YPGO_LOC"] = row["YPGO_LOC"];
                            locRow["YPGO_LOC_DETAIL"] = row["YPGO_LOC_DETAIL"];
                            locTable.Rows.Add(locRow);

                            //사용한 자재창고 업데이트
                            DLSE.LSE_STD_PART.LSE_STD_PART_UPD14(locTable, bizExecute);

                            //입고량 만큼 LOT 생성
                            if (fRow["IS_TOOL"].toInt32() == 1)
                            {
                                DataTable toolTable = DSTD.TSTD_TOOL.TSTD_TOOL_SER1(locTable, bizExecute);

                                //표준공구가 존재할때
                                if (toolTable.Rows.Count > 0)
                                {
                                    DataSet tlSet = new DataSet();
                                    DataTable tlTable = tlSet.Tables.Add("RQSTDT");
                                    tlTable.Columns.Add("PLT_CODE", typeof(String));
                                    tlTable.Columns.Add("TL_CODE", typeof(String));
                                    tlTable.Columns.Add("ADD_QTY", typeof(decimal));

                                    DataRow tlRow = tlTable.NewRow();
                                    tlRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                                    tlRow["TL_CODE"] = toolTable.Rows[0]["TL_CODE"];
                                    tlRow["ADD_QTY"] = QTY;
                                    tlTable.Rows.Add(tlRow);


                                    DataTable tlTable2 = tlSet.Tables.Add("RQSTDT_DETAIL");
                                    tlTable2.Columns.Add("PLT_CODE", typeof(String)); //
                                    tlTable2.Columns.Add("TL_CODE", typeof(String)); //
                                    //tlTable2.Columns.Add("TL_NAME", typeof(String)); //
                                    tlTable2.Columns.Add("TL_STAT", typeof(String)); //
                                    tlTable2.Columns.Add("YPGO_DATE", typeof(String)); //
                                    tlTable2.Columns.Add("REG_EMP", typeof(String)); //

                                    for (int i = 0; i < QTY; i++)
                                    {
                                        DataRow tlRow2 = tlTable2.NewRow();
                                        tlRow2["PLT_CODE"] = ConnInfo.PLT_CODE;
                                        tlRow2["TL_CODE"] = toolTable.Rows[0]["TL_CODE"];
                                        //tlRow2["TL_NAME"] = layoutRow["TL_NAME"];
                                        tlRow2["TL_STAT"] = "NP";
                                        tlRow2["YPGO_DATE"] = YPGO_DATE;
                                        tlRow2["REG_EMP"] = REG_EMP;
                                        tlTable2.Rows.Add(tlRow2);
                                    }

                                    //공구 추가
                                    BSTD.STD07A.STD07A_INS2(tlSet, bizExecute);
                                }
                            }
                        }

                        DataRow purRow = dsRsltPUR.Tables["RSLTDT"].Rows[0];

                        DataTable paramTable2 = new DataTable("RQSTDT");
                        paramTable2.Columns.Add("DATE1", typeof(String)); //
                        paramTable2.Columns.Add("DATE2", typeof(String)); //

                        DataRow paramRow2 = paramTable2.NewRow();
                        paramRow2["DATE1"] = purRow["BALJU_DATE"];
                        paramRow2["DATE2"] = YPGO_DATE;
                        paramTable2.Rows.Add(paramRow2);

                        DataSet paramSet2 = new DataSet();
                        paramSet2.Tables.Add(paramTable2);

                        DataSet dsRslt = CTRL.CTRL.COMPARE_DATE(paramSet2, bizExecute);

                        //발주일이 더큼
                        if (dsRslt.Tables["RSLTDT"].Rows[0]["RESULT"].ToString() == "DATE1")
                        {
                            throw UTIL.SetException("입고일은 발주일 이전날짜로 설정될 수 없습니다."
                           , new System.Diagnostics.StackFrame().GetMethod().Name
                           , BizException.ABORT);
                        }

                        //검사여부
                        if (INS_FLAG == "2")
                        {
                            //검사대기
                            YPGO_STAT = "20";
                        }
                        else
                        {
                            //입고
                            YPGO_STAT = "19";
                        }

                        //발주수량 대비 입고수량 확인
                        if (Convert.ToDecimal(purRow["BAL_QTY"])
                            < (Convert.ToDecimal(purRow["YPGO_QTY"])
                            + Convert.ToDecimal(purRow["CHK_YPGO_QTY"])
                            + Convert.ToDecimal(QTY)))
                        {
                            throw UTIL.SetException("잔량보다 입고수량이 많습니다."
                            , new System.Diagnostics.StackFrame().GetMethod().Name
                            , BizException.ABORT);
                        }


                        //부분입고, 입고완료 결정
                        if (Convert.ToDecimal(purRow["BAL_QTY"])
                            == (Convert.ToDecimal(purRow["YPGO_QTY"])
                            + Convert.ToDecimal(QTY)))
                        {
                            //검사대기 
                            if (YPGO_STAT == "20")
                            {
                                //입고처리/발주수량 동일
                                if (Convert.ToDecimal(purRow["BAL_QTY"]) == Convert.ToDecimal(QTY))
                                {
                                    //검사대기
                                    BAL_STAT = "20";
                                }
                                else
                                {
                                    //부분입고
                                    BAL_STAT = "21";
                                }
                            }
                            else
                            {
                                //입고완료
                                BAL_STAT = "22";
                            }
                        }
                        else
                        {
                            //부분입고
                            BAL_STAT = "21";
                        }

                        string SR_NO = UTIL.UTILITY_GET_SERIALNO(PLT_CODE, SR_CODE, UTIL.emSerialFormat.YYYYMMDD, "", bizExecute);


                        DataTable paramTableYPGO = new DataTable("YPGO");
                        paramTableYPGO.Columns.Add("PLT_CODE", typeof(String)); //
                        paramTableYPGO.Columns.Add("YPGO_ID", typeof(String)); //
                        paramTableYPGO.Columns.Add("BALJU_NUM", typeof(String)); //
                        paramTableYPGO.Columns.Add("BALJU_SEQ", typeof(Int32)); //
                        paramTableYPGO.Columns.Add("YPGO_DATE", typeof(String)); //
                        paramTableYPGO.Columns.Add("CLOSE_DATE", typeof(String)); //
                        paramTableYPGO.Columns.Add("YPGO_LOC", typeof(String)); //
                        paramTableYPGO.Columns.Add("YPGO_LOC_DETAIL", typeof(String)); //
                        paramTableYPGO.Columns.Add("QTY", typeof(Int32)); //
                        paramTableYPGO.Columns.Add("YPGO_STAT", typeof(String)); //
                        paramTableYPGO.Columns.Add("INS_FLAG", typeof(String)); //
                        paramTableYPGO.Columns.Add("SCOMMENT", typeof(String)); //


                        DataRow paramRowYPGO = paramTableYPGO.NewRow();
                        paramRowYPGO["PLT_CODE"] = PLT_CODE;
                        paramRowYPGO["YPGO_ID"] = SR_NO;
                        paramRowYPGO["BALJU_NUM"] = BALJU_NUM;
                        paramRowYPGO["BALJU_SEQ"] = BALJU_SEQ;
                        paramRowYPGO["YPGO_DATE"] = YPGO_DATE;
                        paramRowYPGO["CLOSE_DATE"] = CLOSE_DATE;
                        paramRowYPGO["YPGO_LOC"] = YPGO_LOC;
                        paramRowYPGO["YPGO_LOC_DETAIL"] = YPGO_LOC_DETAIL;
                        paramRowYPGO["QTY"] = QTY;
                        paramRowYPGO["YPGO_STAT"] = YPGO_STAT;
                        paramRowYPGO["INS_FLAG"] = INS_FLAG;
                        paramRowYPGO["SCOMMENT"] = SCOMMENT;

                        paramTableYPGO.Rows.Add(paramRowYPGO);
                        //입고 정보
                        DMAT.TMAT_YPGO.TMAT_YPGO_INS(paramTableYPGO, bizExecute);


                        DataTable paramTableBALJU = new DataTable("BALJU");
                        paramTableBALJU.Columns.Add("BAL_STAT", typeof(String)); //
                        paramTableBALJU.Columns.Add("PLT_CODE", typeof(String)); //
                        paramTableBALJU.Columns.Add("BALJU_NUM", typeof(String)); //
                        paramTableBALJU.Columns.Add("BALJU_SEQ", typeof(Int32)); //


                        DataRow paramRowBALJU = paramTableBALJU.NewRow();
                        paramRowBALJU["BAL_STAT"] = BAL_STAT;
                        paramRowBALJU["PLT_CODE"] = PLT_CODE;
                        paramRowBALJU["BALJU_NUM"] = BALJU_NUM;
                        paramRowBALJU["BALJU_SEQ"] = BALJU_SEQ;
                        paramTableBALJU.Rows.Add(paramRowBALJU);

                        //발주상태 변경
                        DMAT.TMAT_BALJU.TMAT_BALJU_UPD2(paramTableBALJU, bizExecute);


                        //구매이벤트
                        DataTable paramTablePURCHASE = new DataTable("RQSTDT");
                        paramTablePURCHASE.Columns.Add("PLT_CODE", typeof(String)); //
                        paramTablePURCHASE.Columns.Add("REQUEST_NO", typeof(String)); //
                        paramTablePURCHASE.Columns.Add("REQUEST_SEQ", typeof(Int32)); //
                        paramTablePURCHASE.Columns.Add("PUR_STAT", typeof(String)); //


                        DataRow paramRowPURCHASE = paramTablePURCHASE.NewRow();
                        paramRowPURCHASE["PLT_CODE"] = PLT_CODE;
                        paramRowPURCHASE["REQUEST_NO"] = purRow["REQUEST_NO"];
                        paramRowPURCHASE["REQUEST_SEQ"] = purRow["REQUEST_SEQ"];
                        paramRowPURCHASE["PUR_STAT"] = BAL_STAT;

                        paramTablePURCHASE.Rows.Add(paramRowPURCHASE);

                        CTRL.CTRL.SET_PURCHASE_EVENT_M(UTIL.GetDtToDs(paramTablePURCHASE), bizExecute);


                        //발주자 알림
                        DataTable paramTableNOTIFY = new DataTable("RQSTDT");
                        paramTableNOTIFY.Columns.Add("PLT_CODE", typeof(String)); //
                        paramTableNOTIFY.Columns.Add("EMP_CODE", typeof(String)); //
                        paramTableNOTIFY.Columns.Add("PUR_NO", typeof(String)); //
                        paramTableNOTIFY.Columns.Add("PUR_SEQ", typeof(Int32)); //
                        paramTableNOTIFY.Columns.Add("PUR_NO_TYPE", typeof(String)); //
                        paramTableNOTIFY.Columns.Add("PUR_STAT", typeof(String)); //
                        paramTableNOTIFY.Columns.Add("REG_EMP", typeof(String)); //


                        DataRow paramRowNOTIFY = paramTableNOTIFY.NewRow();
                        paramRowNOTIFY["PLT_CODE"] = PLT_CODE;
                        paramRowNOTIFY["EMP_CODE"] = purRow["BALJU_REG_EMP"];
                        paramRowNOTIFY["PUR_NO"] = purRow["BALJU_NUM"];
                        paramRowNOTIFY["PUR_SEQ"] = purRow["BALJU_SEQ"];
                        paramRowNOTIFY["PUR_NO_TYPE"] = PUR_NO_TYPE_BAL;
                        paramRowNOTIFY["PUR_STAT"] = BAL_STAT;
                        paramRowNOTIFY["REG_EMP"] = REG_EMP;

                        paramTableNOTIFY.Rows.Add(paramRowNOTIFY);

                        CTRL.CTRL.CREATE_PUR_M_SELF_NOTIFY(UTIL.GetDtToDs(paramTableNOTIFY), bizExecute);


                        //신청자 알림
                        DataTable paramTableNOTIFY_R = new DataTable("RQSTDT");
                        paramTableNOTIFY_R.Columns.Add("PLT_CODE", typeof(String)); //
                        paramTableNOTIFY_R.Columns.Add("EMP_CODE", typeof(String)); //
                        paramTableNOTIFY_R.Columns.Add("PUR_NO", typeof(String)); //
                        paramTableNOTIFY_R.Columns.Add("PUR_SEQ", typeof(Int32)); //
                        paramTableNOTIFY_R.Columns.Add("PUR_NO_TYPE", typeof(String)); //
                        paramTableNOTIFY_R.Columns.Add("PUR_STAT", typeof(String)); //
                        paramTableNOTIFY_R.Columns.Add("REG_EMP", typeof(String)); //


                        DataRow paramRowNOTIFY_R = paramTableNOTIFY_R.NewRow();
                        paramRowNOTIFY_R["PLT_CODE"] = PLT_CODE;
                        paramRowNOTIFY_R["EMP_CODE"] = purRow["REQ_REG_EMP"];
                        paramRowNOTIFY_R["PUR_NO"] = purRow["REQUEST_NO"];
                        paramRowNOTIFY_R["PUR_SEQ"] = purRow["REQUEST_SEQ"];
                        paramRowNOTIFY_R["PUR_NO_TYPE"] = PUR_NO_TYPE_REQ;
                        paramRowNOTIFY_R["PUR_STAT"] = BAL_STAT;
                        paramRowNOTIFY_R["REG_EMP"] = REG_EMP;

                        paramTableNOTIFY_R.Rows.Add(paramRowNOTIFY_R);

                        CTRL.CTRL.CREATE_PUR_M_SELF_NOTIFY(UTIL.GetDtToDs(paramTableNOTIFY_R), bizExecute);

                        if (BAL_STAT == "22" || BAL_STAT == "21")
                        {
                            //입고완료일 경우에만
                            //작업지시 상태 변경
                            DataTable paramTableWO = new DataTable("RQSTDT");
                            paramTableWO.Columns.Add("PLT_CODE", typeof(String));
                            paramTableWO.Columns.Add("WO_NO", typeof(String));
                            paramTableWO.Columns.Add("WO_FLAG", typeof(Int32));
                            //paramTableWO.Columns.Add("ACT_START_TIME", typeof(DateTime));
                            paramTableWO.Columns.Add("ACT_END_TIME", typeof(DateTime));
                            paramTableWO.Columns.Add("ACT_QTY", typeof(Int32));

                            DataRow paramRowWo = paramTableWO.NewRow();
                            paramRowWo["PLT_CODE"] = purRow["PLT_CODE"];
                            paramRowWo["WO_NO"] = purRow["WO_NO"];
                            
                            //계획의 수량과 같아야 완료
                            if (BAL_STAT == "22" && purRow["PART_QTY"].toInt32() <=(row["QTY"].toInt32()+purRow["YPGO_QTY"].toInt32() + purRow["CHK_YPGO_QTY"].toInt32()+ purRow["NG_YPGO_QTY"].toInt32()))
                                paramRowWo["WO_FLAG"] = 4;            //완료
                            else
                                paramRowWo["WO_FLAG"] = 2;

                            paramRowWo["ACT_QTY"] = purRow["YPGO_QTY"].toInt32() + QTY;

                            DateTime ypgo_time = new DateTime(System.Convert.ToInt32(YPGO_DATE.Substring(0, 4)),
                                 System.Convert.ToInt32(YPGO_DATE.Substring(4, 2)),
                                 System.Convert.ToInt32(YPGO_DATE.Substring(6, 2)),
                                 DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

                            if(purRow["ACT_END_TIME"].isNullOrEmpty() == false
                                && purRow["ACT_END_TIME"].toDateTime()> ypgo_time)
                            {
                                paramRowWo["ACT_END_TIME"] = purRow["ACT_END_TIME"];
                            }
                            else
                            {
                                paramRowWo["ACT_END_TIME"] = ypgo_time;
                            }

                            paramTableWO.Rows.Add(paramRowWo);

                            DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD5_1(paramTableWO, bizExecute);
                        }


                        //구매품일때
                        if (purRow["MAT_TYPE"].ToString().Equals("구매품"))
                        {
                            DataTable stockTable = new DataTable("RQSTDT");
                            stockTable.Columns.Add("PLT_CODE", typeof(String)); //
                            stockTable.Columns.Add("STK_ID", typeof(String)); //
                            stockTable.Columns.Add("PROD_CODE", typeof(String)); //
                            stockTable.Columns.Add("PART_CODE", typeof(String)); //
                            stockTable.Columns.Add("STOCK_DATE", typeof(String)); //
                            stockTable.Columns.Add("STOCK_CODE", typeof(String)); //창고
                            stockTable.Columns.Add("STOCK_TYPE", typeof(String)); //완성재고형태
                            stockTable.Columns.Add("PART_QTY", typeof(int)); //

                            DataRow stockRow = stockTable.NewRow();
                            stockRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                            stockRow["STK_ID"] = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "STK", UTIL.emSerialFormat.YYMMDD, "", bizExecute);
                            stockRow["PROD_CODE"] = purRow["PROD_CODE"];
                            stockRow["PART_CODE"] = purRow["PART_CODE"];
                            stockRow["STOCK_DATE"] = YPGO_DATE;
                            stockRow["STOCK_CODE"] = YPGO_LOC;
                            stockRow["STOCK_TYPE"] = purRow["STOCK_TYPE"];
                            stockRow["PART_QTY"] = QTY;
                            stockTable.Rows.Add(stockRow);

                            DSHP.TSHP_STOCK.TSHP_STOCK_INS(stockTable, bizExecute);

                            DataTable purProductTable = DORD.TORD_PRODUCT.TORD_PRODUCT_SER(UTIL.GetRowToDt(purRow), bizExecute);
                            string parentCode = String.Empty;
                            foreach (DataRow purProductRow in purProductTable.Rows)
                            {
                                parentCode = purProductRow["PART_CODE"].toStringEmpty();
                            }

                            DataTable stockLogTable = new DataTable("RQSTDT_INS");
                            stockLogTable.Columns.Add("PLT_CODE", typeof(String)); ///
                            stockLogTable.Columns.Add("PART_CODE", typeof(String)); //
                            stockLogTable.Columns.Add("EVENT_TIME", typeof(String)); //
                            stockLogTable.Columns.Add("GUBUN", typeof(String)); //
                            stockLogTable.Columns.Add("IN_QTY", typeof(int)); //
                            stockLogTable.Columns.Add("OUT_QTY", typeof(int)); //
                            stockLogTable.Columns.Add("SA_QTY", typeof(int)); //
                            stockLogTable.Columns.Add("STOCK_CODE", typeof(String)); //
                            stockLogTable.Columns.Add("STOCK_TYPE", typeof(String)); //
                            stockLogTable.Columns.Add("SCOMMENT", typeof(String)); //
                            stockLogTable.Columns.Add("REG_EMP", typeof(String)); //

                            DataRow stockLogRow = stockLogTable.NewRow();
                            stockLogRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                            stockLogRow["PART_CODE"] = purRow["PART_CODE"];
                            stockLogRow["EVENT_TIME"] = DateTime.Now.ToString("yyyyMMdd HH:mm:ss.fff");
                            stockLogRow["GUBUN"] = "IN";
                            stockLogRow["IN_QTY"] = QTY;
                            stockLogRow["OUT_QTY"] = 0;
                            stockLogRow["STOCK_CODE"] = YPGO_LOC;
                            stockLogRow["STOCK_TYPE"] = purRow["STOCK_TYPE"];
                            stockLogRow["SCOMMENT"] = "|  " + parentCode;
                            stockLogRow["REG_EMP"] = ConnInfo.UserID;
                            stockLogTable.Rows.Add(stockLogRow);

                            BPUR.PUR56A.PUR56A_INS3(UTIL.GetDtToDs(stockLogTable, "RQSTDT_INS"), bizExecute);
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

        /// <summary>
        /// 발주 상태를 입고완료로 변경
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet PUR05C_INS2_M(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "BAL_STAT", "22", typeof(String));

                DMAT.TMAT_BALJU.TMAT_BALJU_UPD2(paramDS.Tables["RQSTDT"], bizExecute);

                foreach (DataRow dr in paramDS.Tables["RQSTDT"].Rows)
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


                return paramDS;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 발주 상태를 입고완료로 변경
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet PUR05C_INS2_OI(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "BAL_STAT", "22", typeof(String));


                DOUT.TOUT_PROCBALJU.TOUT_PROCBALJU_UPD2(paramDS.Tables["RQSTDT"], bizExecute);

                DOUT.TOUT_TEMP_YPGO.TOUT_TEMP_YPGO_UPD3(paramDS.Tables["RQSTDT"], bizExecute);

                foreach (DataRow dr in paramDS.Tables["RQSTDT"].Rows)
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
                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PUR05C_INS2_PO(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "BAL_STAT", "22", typeof(String));


                DOUT.TOUT_PROCBALJU.TOUT_PROCBALJU_UPD2(paramDS.Tables["RQSTDT"], bizExecute);

                foreach (DataRow dr in paramDS.Tables["RQSTDT"].Rows)
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
                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        //자재 입고예정일 변경
        public static DataSet PUR05C_INS3_M(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    string PLT_CODE = row["PLT_CODE"].ToString();
                    string BALJU_NUM = row["BALJU_NUM"].ToString();
                    string BALJU_SEQ = row["BALJU_SEQ"].ToString();
                    string REG_EMP = row["REG_EMP"].ToString();
                    string DUE_DATE = row["DUE_DATE"].ToString();
                    string WO_NO = row["WO_NO"].ToString();

                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTable.Columns.Add("BALJU_NUM", typeof(String)); //
                    paramTable.Columns.Add("BALJU_SEQ", typeof(String)); //

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = PLT_CODE;
                    paramRow["BALJU_NUM"] = BALJU_NUM;
                    paramRow["BALJU_SEQ"] = BALJU_SEQ;
                    paramTable.Rows.Add(paramRow);

                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    DataSet dsRsltPUR = BPUR.PUR05C.PUR05C_SER_M(paramSet, bizExecute);

                    //데이터 여부
                    if (dsRsltPUR.Tables["RSLTDT"].Rows.Count != 0)
                    {
                        //발주상태 변경
                        DataTable paramTableBALJU = new DataTable("BALJU");
                        paramTableBALJU.Columns.Add("DUE_DATE", typeof(String)); //
                        paramTableBALJU.Columns.Add("PLT_CODE", typeof(String)); //
                        paramTableBALJU.Columns.Add("BALJU_NUM", typeof(String)); //
                        paramTableBALJU.Columns.Add("BALJU_SEQ", typeof(Int32)); //


                        DataRow paramRowBALJU = paramTableBALJU.NewRow();
                        paramRowBALJU["DUE_DATE"] = DUE_DATE;
                        paramRowBALJU["PLT_CODE"] = PLT_CODE;
                        paramRowBALJU["BALJU_NUM"] = BALJU_NUM;
                        paramRowBALJU["BALJU_SEQ"] = BALJU_SEQ;
                        paramTableBALJU.Rows.Add(paramRowBALJU);


                        DMAT.TMAT_BALJU.TMAT_BALJU_UPD4(paramTableBALJU, bizExecute);

                        //입고예정일 변경
                        DataTable paramTableWK = new DataTable("RQSTDT");
                        paramTableWK.Columns.Add("PLT_CODE", typeof(String)); //
                        paramTableWK.Columns.Add("WO_NO", typeof(String)); //
                        paramTableWK.Columns.Add("PLN_END_TIME", typeof(String)); //

                        DataRow paramRowWK = paramTableWK.NewRow();
                        paramRowWK["PLT_CODE"] = PLT_CODE;
                        paramRowWK["WO_NO"] = WO_NO;
                        paramRowWK["PLN_END_TIME"] = DUE_DATE + "1300";
                        paramTableWK.Rows.Add(paramRowWK);

                        DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD5_3(paramTableWK, bizExecute);


                    }
                }
                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        //공정외주 입고
        public static DataSet PUR05C_INS_PO(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                string BAL_STAT = "";
                string WO_FLAG = "2";

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    string PLT_CODE = row["PLT_CODE"].ToString();
                    string BALJU_NUM = row["BALJU_NUM"].ToString();
                    string BALJU_SEQ = row["BALJU_SEQ"].ToString();
                    string TYP_DATE = row["TYP_DATE"].ToString();
                    //string CLOSE_DATE = row["CLOSE_DATE"].ToString();
                    string YPGO_LOC = row["YPGO_LOC"].ToString();
                    string YPGO_LOC_DETAIL = row["YPGO_LOC_DETAIL"].ToString();
                    string INS_DATE = row["INS_DATE"].ToString();
                    int QTY = row["QTY"].toInt32();
                    string SCOMMENT = row["SCOMMENT"].ToString();
                    string REG_EMP = row["REG_EMP"].ToString();
                    string INS_FLAG = row["INS_FLAG"].ToString();

                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTable.Columns.Add("BALJU_NUM", typeof(String)); //
                    paramTable.Columns.Add("BALJU_SEQ", typeof(String)); //

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = PLT_CODE;
                    paramRow["BALJU_NUM"] = BALJU_NUM;
                    paramRow["BALJU_SEQ"] = BALJU_SEQ;
                    paramTable.Rows.Add(paramRow);

                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    DataSet dsRsltPUR = BPUR.PUR05C.PUR05C_SER_PO(paramSet, bizExecute);

                    //데이터 여부
                    if (dsRsltPUR.Tables["RSLTDT"].Rows.Count != 0)
                    {
                        DataTable paramTable2 = new DataTable("RQSTDT");
                        paramTable2.Columns.Add("DATE1", typeof(String)); //
                        paramTable2.Columns.Add("DATE2", typeof(String)); //

                        DataRow paramRow2 = paramTable2.NewRow();
                        paramRow2["DATE1"] = dsRsltPUR.Tables["RSLTDT"].Rows[0]["BALJU_DATE"];
                        paramRow2["DATE2"] = TYP_DATE;
                        paramTable2.Rows.Add(paramRow2);

                        DataSet paramSet2 = new DataSet();
                        paramSet2.Tables.Add(paramTable2);

                        DataSet dsRslt = CTRL.CTRL.COMPARE_DATE(paramSet2, bizExecute);

                        //발주일이 더큼
                        if (dsRslt.Tables["RSLTDT"].Rows[0]["RESULT"].ToString() == "DATE1")
                        {
                            throw UTIL.SetException("입고일은 발주일 이전날짜로 설정될 수 없습니다."
                           , new System.Diagnostics.StackFrame().GetMethod().Name
                           , BizException.ABORT);
                        }

                        //기존 INS_FLAG 사용이 불명확하여 필요없는 소스로 판단됨
                        ////검사여부
                        //if (INS_FLAG == "2")
                        //{
                        //    //검사대기
                        //    YPGO_STAT = "20";
                        //}
                        //else
                        //{
                        //    //입고
                        //    YPGO_STAT = "19";
                        //}

                        //발주수량 대비 입고수량 확인
                        if (Convert.ToDecimal(dsRsltPUR.Tables["RSLTDT"].Rows[0]["BAL_QTY"])
                            < (Convert.ToDecimal(dsRsltPUR.Tables["RSLTDT"].Rows[0]["YPGO_QTY"])
                            + Convert.ToDecimal(dsRsltPUR.Tables["RSLTDT"].Rows[0]["CHK_YPGO_QTY"])
                            + Convert.ToDecimal(QTY)))
                        {
                            throw UTIL.SetException("잔량보다 입고수량이 많습니다."
                            , new System.Diagnostics.StackFrame().GetMethod().Name
                            , BizException.ABORT);
                        }


                        //부분입고, 입고완료 결정
                        if (Convert.ToDecimal(dsRsltPUR.Tables["RSLTDT"].Rows[0]["BAL_QTY"])
                            == (Convert.ToDecimal(dsRsltPUR.Tables["RSLTDT"].Rows[0]["YPGO_QTY"])
                            + Convert.ToDecimal(QTY)))
                        {
                            //BAL_STAT = "22";
                            #region 이전 소스
                            ////검사대기 
                            //if (YPGO_STAT == "20")
                            //{
                            //    //입고처리/발주수량 동일
                            //    if (Convert.ToDecimal(dsRsltPUR.Tables["RSLTDT"].Rows[0]["BAL_QTY"]) == Convert.ToDecimal(QTY))
                            //    {
                            //        //검사대기
                            //        BAL_STAT = "20";
                            //    }
                            //    else
                            //    {
                            //        //부분입고
                            //        BAL_STAT = "21";
                            //    }
                            //}
                            //else
                            //{
                            //입고완료


                            //DataTable paramTableEVENT = new DataTable("RQSTDT");
                            //paramTableEVENT.Columns.Add("PLT_CODE", typeof(String)); //
                            //paramTableEVENT.Columns.Add("REQUEST_NO", typeof(String)); //
                            //paramTableEVENT.Columns.Add("REQUEST_SEQ", typeof(String)); //
                            //paramTableEVENT.Columns.Add("PUR_STAT", typeof(String)); //

                            //DataRow paramRowEVENT = paramTableEVENT.NewRow();
                            //paramRowEVENT["PLT_CODE"] = dsRsltPUR.Tables["RSLTDT"].Rows[0]["BALJU_DATE"];
                            //paramRowEVENT["REQUEST_NO"] = dsRsltPUR.Tables["RSLTDT"].Rows[0]["REQUEST_NO"];
                            //paramRowEVENT["REQUEST_SEQ"] = dsRsltPUR.Tables["RSLTDT"].Rows[0]["REQUEST_SEQ"];
                            //paramRowEVENT["PUR_STAT"] = PUR_STAT;
                            //paramTableEVENT.Rows.Add(paramRowEVENT);

                            ////최근 발주승인날짜 알아오기
                            //DataTable dtRsltEVET = DPUR.TPURCHASE_EVENT.TPURCHASE_EVENT_SER2(paramTableEVENT, bizExecute);

                            //try
                            //{
                            //    DateTime start = (DateTime)dtRsltEVET.Rows[0]["EVENT_DATE"];
                            //    DateTime end = DateTime.Now;

                            //    TimeSpan time = end.Subtract(start);

                            //    ACT_MAN_TIME = Convert.ToDecimal(Math.Floor(time.TotalMinutes));
                            //}
                            //catch
                            //{
                            //    ACT_MAN_TIME = 0;
                            //}

                            //DateTime ypgo_time = new DateTime(System.Convert.ToInt32(YPGO_DATE.Substring(0, 4)),
                            //     System.Convert.ToInt32(YPGO_DATE.Substring(4, 2)),
                            //     System.Convert.ToInt32(YPGO_DATE.Substring(6, 2)),
                            //     DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);


                            //DataTable paramTableWK = new DataTable("RQSTDT");
                            //paramTableWK.Columns.Add("WO_FLAG", typeof(String)); //
                            //paramTableWK.Columns.Add("ACT_END_TIME", typeof(DateTime)); //
                            //paramTableWK.Columns.Add("ACT_MAN_TIME", typeof(String)); //
                            //paramTableWK.Columns.Add("PLT_CODE", typeof(String)); //
                            //paramTableWK.Columns.Add("WO_NO", typeof(String)); //
                            //paramTableWK.Columns.Add("ACT_QTY", typeof(Int32)); //

                            //DataRow paramRowWK = paramTableWK.NewRow();
                            //paramRowWK["WO_FLAG"] = WO_FLAG;
                            //paramRowWK["ACT_END_TIME"] = ypgo_time;
                            ////paramRowWK["ACT_MAN_TIME"] = ACT_MAN_TIME;
                            //paramRowWK["PLT_CODE"] = dsRsltPUR.Tables["RSLTDT"].Rows[0]["PLT_CODE"];
                            //paramRowWK["WO_NO"] = dsRsltPUR.Tables["RSLTDT"].Rows[0]["WO_NO"];
                            //paramRowWK["ACT_QTY"] = dsRsltPUR.Tables["RSLTDT"].Rows[0]["YPGO_QTY"].toInt32() + QTY;

                            //paramTableWK.Rows.Add(paramRowWK);

                            ////작업지시상태 변경
                            //DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD5_1(paramTableWK, bizExecute);
                            ////DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD4(paramTableWK, bizExecute);
                            //  }
                            #endregion



                            //수입검사
                            if (INS_FLAG.Equals("1"))
                            {
                                BAL_STAT = "20";
                            }
                            //무검사
                            else
                            {
                                BAL_STAT = "41";
                            }
                        }
                        else
                        {
                            //부분입고
                            //BAL_STAT = "21";

                            //DateTime ypgo_time = new DateTime(System.Convert.ToInt32(YPGO_DATE.Substring(0, 4)),
                            //         System.Convert.ToInt32(YPGO_DATE.Substring(4, 2)),
                            //         System.Convert.ToInt32(YPGO_DATE.Substring(6, 2)),
                            //         DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);



                            //DataTable paramTableWK = new DataTable("RQSTDT");
                            //paramTableWK.Columns.Add("WO_FLAG", typeof(String)); //
                            ////paramTableWK.Columns.Add("ACT_END_TIME", typeof(DateTime)); //
                            ////paramTableWK.Columns.Add("ACT_MAN_TIME", typeof(String)); //
                            //paramTableWK.Columns.Add("PLT_CODE", typeof(String)); //
                            //paramTableWK.Columns.Add("WO_NO", typeof(String)); //
                            ////paramTableWK.Columns.Add("ACT_QTY", typeof(Int32)); //

                            //DataRow paramRowWK = paramTableWK.NewRow();
                            //paramRowWK["WO_FLAG"] = "2";    //진행
                            ////paramRowWK["ACT_END_TIME"] = ypgo_time;
                            //paramRowWK["PLT_CODE"] = dsRsltPUR.Tables["RSLTDT"].Rows[0]["PLT_CODE"];
                            //paramRowWK["WO_NO"] = dsRsltPUR.Tables["RSLTDT"].Rows[0]["WO_NO"];
                            ////paramRowWK["ACT_QTY"] = dsRsltPUR.Tables["RSLTDT"].Rows[0]["YPGO_QTY"].toInt32() + QTY;

                            //paramTableWK.Rows.Add(paramRowWK);

                            ////작업지시상태 변경
                            //DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD5_6(paramTableWK, bizExecute);

                            //수입검사
                            if (INS_FLAG.Equals("1"))
                            {
                                BAL_STAT = "42";
                            }
                            //무검사
                            else
                            {
                                BAL_STAT = "40";
                                //DataSet tmpYpgoSet = new DataSet();
                                //DataTable tmpYpgoTable = tmpYpgoSet.Tables.Add("RQSTDT");
                                //tmpYpgoTable.Columns.Add("PLT_CODE", typeof(String));
                                //tmpYpgoTable.Columns.Add("TYP_ID", typeof(String));
                                //tmpYpgoTable.Columns.Add("BALJU_NUM", typeof(String));
                                //tmpYpgoTable.Columns.Add("BALJU_SEQ", typeof(String));
                                //tmpYpgoTable.Columns.Add("TYP_DATE", typeof(String));
                                //tmpYpgoTable.Columns.Add("TYP_QTY", typeof(String));
                                //tmpYpgoTable.Columns.Add("TYP_STAT", typeof(String));
                                //tmpYpgoTable.Columns.Add("TYP_LOC", typeof(String));

                                //DataRow tmpYpgoRow = tmpYpgoTable.NewRow();
                                //tmpYpgoRow["PLT_CODE"] = PLT_CODE;
                                //tmpYpgoRow["TYP_ID"] = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "TYP", UTIL.emSerialFormat.YYMM, "", bizExecute);
                                //tmpYpgoRow["BALJU_NUM"] = BALJU_NUM;
                                //tmpYpgoRow["BALJU_SEQ"] = BALJU_SEQ;
                                //tmpYpgoRow["TYP_DATE"] = YPGO_DATE;
                                //tmpYpgoRow["TYP_QTY"] = QTY;
                                //tmpYpgoRow["TYP_STAT"] = BAL_STAT;
                                //tmpYpgoRow["TYP_LOC"] = YPGO_LOC;
                                //tmpYpgoTable.Rows.Add(tmpYpgoRow);

                                //DOUT.TOUT_TEMP_YPGO.TOUT_TEMP_YPGO_INS(tmpYpgoTable, bizExecute);
                            }
                        }

                        DataSet tmpYpgoSet = new DataSet();
                        DataTable tmpYpgoTable = tmpYpgoSet.Tables.Add("RQSTDT");
                        tmpYpgoTable.Columns.Add("PLT_CODE", typeof(String));
                        tmpYpgoTable.Columns.Add("TYP_ID", typeof(String));
                        tmpYpgoTable.Columns.Add("BALJU_NUM", typeof(String));
                        tmpYpgoTable.Columns.Add("BALJU_SEQ", typeof(String));
                        tmpYpgoTable.Columns.Add("TYP_DATE", typeof(String));
                        //tmpYpgoTable.Columns.Add("CLOSE_DATE", typeof(String));
                        tmpYpgoTable.Columns.Add("INS_DATE", typeof(String));
                        tmpYpgoTable.Columns.Add("TYP_QTY", typeof(String));
                        tmpYpgoTable.Columns.Add("TYP_STAT", typeof(String));
                        tmpYpgoTable.Columns.Add("TYP_LOC", typeof(String));
                        tmpYpgoTable.Columns.Add("TYP_LOC_DETAIL", typeof(String));
                        tmpYpgoTable.Columns.Add("SCOMMENT", typeof(String));
                        tmpYpgoTable.Columns.Add("INS_FLAG", typeof(String));

                        DataRow tmpYpgoRow = tmpYpgoTable.NewRow();
                        tmpYpgoRow["PLT_CODE"] = PLT_CODE;
                        tmpYpgoRow["TYP_ID"] = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "TYP", UTIL.emSerialFormat.YYMM, "", bizExecute);
                        tmpYpgoRow["BALJU_NUM"] = BALJU_NUM;
                        tmpYpgoRow["BALJU_SEQ"] = BALJU_SEQ;
                        tmpYpgoRow["TYP_DATE"] = TYP_DATE;
                        //tmpYpgoRow["CLOSE_DATE"] = CLOSE_DATE;
                        if (INS_FLAG.Equals("1"))   //수입겁사일때 검사일정 저장
                        {
                            tmpYpgoRow["INS_DATE"] = INS_DATE;
                        }
                        tmpYpgoRow["TYP_QTY"] = QTY;
                        tmpYpgoRow["TYP_STAT"] = BAL_STAT;
                        tmpYpgoRow["TYP_LOC"] = YPGO_LOC;
                        tmpYpgoRow["TYP_LOC_DETAIL"] = YPGO_LOC_DETAIL;
                        tmpYpgoRow["SCOMMENT"] = SCOMMENT;
                        tmpYpgoRow["INS_FLAG"] = INS_FLAG;
                        tmpYpgoTable.Rows.Add(tmpYpgoRow);

                        DOUT.TOUT_TEMP_YPGO.TOUT_TEMP_YPGO_INS(tmpYpgoTable, bizExecute);

                        DataTable paramTableWK = new DataTable("RQSTDT");
                        paramTableWK.Columns.Add("WO_FLAG", typeof(String)); //
                        //paramTableWK.Columns.Add("ACT_END_TIME", typeof(DateTime)); //
                        //paramTableWK.Columns.Add("ACT_MAN_TIME", typeof(String)); //
                        paramTableWK.Columns.Add("PLT_CODE", typeof(String)); //
                        paramTableWK.Columns.Add("WO_NO", typeof(String)); //
                        paramTableWK.Columns.Add("INS_DATE", typeof(String));
                        paramTableWK.Columns.Add("INS_FLAG", typeof(Decimal)); //
                        paramTableWK.Columns.Add("LOAD_FLAG", typeof(Decimal)); //
                        paramTableWK.Columns.Add("IS_YPGO", typeof(Decimal)); //
                        //paramTableWK.Columns.Add("ACT_QTY", typeof(Int32)); //

                        DataRow paramRowWK = paramTableWK.NewRow();
                        paramRowWK["WO_FLAG"] = WO_FLAG;
                        //paramRowWK["ACT_END_TIME"] = ypgo_time;
                        paramRowWK["PLT_CODE"] = dsRsltPUR.Tables["RSLTDT"].Rows[0]["PLT_CODE"];
                        paramRowWK["WO_NO"] = dsRsltPUR.Tables["RSLTDT"].Rows[0]["WO_NO"];
                        //paramRowWK["ACT_QTY"] = dsRsltPUR.Tables["RSLTDT"].Rows[0]["YPGO_QTY"].toInt32() + QTY;
                        paramRowWK["INS_DATE"] = INS_DATE;
                        paramRowWK["INS_FLAG"] = INS_FLAG;
                        paramRowWK["LOAD_FLAG"] = 1;    //스케줄대상 제외
                        paramRowWK["IS_YPGO"] = 1;      //입고됐다는 표시

                        paramTableWK.Rows.Add(paramRowWK);

                        //작업지시상태 변경
                        DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD5_6(paramTableWK, bizExecute);

                        DAPS.APS_PROC.APS_PROC_UPD3(paramTableWK, bizExecute);


                        //string SR_NO = UTIL.UTILITY_GET_SERIALNO(PLT_CODE, SR_CODE, UTIL.emSerialFormat.YYYYMMDD, "", bizExecute);


                        //DataTable paramTableYPGO = new DataTable("YPGO");
                        //paramTableYPGO.Columns.Add("PLT_CODE", typeof(String)); //
                        //paramTableYPGO.Columns.Add("YPGO_ID", typeof(String)); //
                        //paramTableYPGO.Columns.Add("BALJU_NUM", typeof(String)); //
                        //paramTableYPGO.Columns.Add("BALJU_SEQ", typeof(Int32)); //
                        //paramTableYPGO.Columns.Add("YPGO_DATE", typeof(String)); //
                        //paramTableYPGO.Columns.Add("QTY", typeof(Int32)); //
                        //paramTableYPGO.Columns.Add("YPGO_STAT", typeof(String)); //
                        //paramTableYPGO.Columns.Add("INS_FLAG", typeof(String)); //
                        //paramTableYPGO.Columns.Add("SCOMMENT", typeof(String)); //


                        //DataRow paramRowYPGO = paramTableYPGO.NewRow();
                        //paramRowYPGO["PLT_CODE"] = PLT_CODE;
                        //paramRowYPGO["YPGO_ID"] = SR_NO;
                        //paramRowYPGO["BALJU_NUM"] = BALJU_NUM;
                        //paramRowYPGO["BALJU_SEQ"] = BALJU_SEQ;
                        //paramRowYPGO["YPGO_DATE"] = YPGO_DATE;
                        //paramRowYPGO["QTY"] = QTY;
                        //paramRowYPGO["YPGO_STAT"] = YPGO_STAT;
                        //paramRowYPGO["INS_FLAG"] = INS_FLAG;
                        //paramRowYPGO["SCOMMENT"] = SCOMMENT;

                        //paramTableYPGO.Rows.Add(paramRowYPGO);
                        ////입고 정보
                        //DOUT.TOUT_PROCYPGO.TOUT_PROCYPGO_INS(paramTableYPGO, bizExecute);


                        DataTable paramTableBALJU = new DataTable("BALJU");
                        paramTableBALJU.Columns.Add("BAL_STAT", typeof(String)); //
                        paramTableBALJU.Columns.Add("PLT_CODE", typeof(String)); //
                        paramTableBALJU.Columns.Add("BALJU_NUM", typeof(String)); //
                        paramTableBALJU.Columns.Add("BALJU_SEQ", typeof(Int32)); //


                        DataRow paramRowBALJU = paramTableBALJU.NewRow();
                        paramRowBALJU["BAL_STAT"] = BAL_STAT;
                        paramRowBALJU["PLT_CODE"] = PLT_CODE;
                        paramRowBALJU["BALJU_NUM"] = BALJU_NUM;
                        paramRowBALJU["BALJU_SEQ"] = BALJU_SEQ;
                        paramTableBALJU.Rows.Add(paramRowBALJU);

                        //발주상태 변경
                        DOUT.TOUT_PROCBALJU.TOUT_PROCBALJU_UPD2(paramTableBALJU, bizExecute);


                        ////구매이벤트
                        //DataTable paramTablePURCHASE = new DataTable("RQSTDT");
                        //paramTablePURCHASE.Columns.Add("PLT_CODE", typeof(String)); //
                        //paramTablePURCHASE.Columns.Add("REQUEST_NO", typeof(String)); //
                        //paramTablePURCHASE.Columns.Add("REQUEST_SEQ", typeof(Int32)); //
                        //paramTablePURCHASE.Columns.Add("PUR_STAT", typeof(String)); //


                        //DataRow paramRowPURCHASE = paramTablePURCHASE.NewRow();
                        //paramRowPURCHASE["PLT_CODE"] = PLT_CODE;
                        //paramRowPURCHASE["REQUEST_NO"] = dsRsltPUR.Tables["RSLTDT"].Rows[0]["REQUEST_NO"];
                        //paramRowPURCHASE["REQUEST_SEQ"] = dsRsltPUR.Tables["RSLTDT"].Rows[0]["REQUEST_SEQ"];
                        //paramRowPURCHASE["PUR_STAT"] = BAL_STAT;

                        //paramTablePURCHASE.Rows.Add(paramRowPURCHASE);

                        //CTRL.CTRL.SET_PURCHASE_EVENT_M(UTIL.GetDtToDs(paramTablePURCHASE), bizExecute);


                        ////발주자 알림
                        //DataTable paramTableNOTIFY = new DataTable("RQSTDT");
                        //paramTableNOTIFY.Columns.Add("PLT_CODE", typeof(String)); //
                        //paramTableNOTIFY.Columns.Add("EMP_CODE", typeof(String)); //
                        //paramTableNOTIFY.Columns.Add("PUR_NO", typeof(String)); //
                        //paramTableNOTIFY.Columns.Add("PUR_SEQ", typeof(Int32)); //
                        //paramTableNOTIFY.Columns.Add("PUR_NO_TYPE", typeof(String)); //
                        //paramTableNOTIFY.Columns.Add("PUR_STAT", typeof(String)); //
                        //paramTableNOTIFY.Columns.Add("REG_EMP", typeof(String)); //


                        //DataRow paramRowNOTIFY = paramTableNOTIFY.NewRow();
                        //paramRowNOTIFY["PLT_CODE"] = PLT_CODE;
                        //paramRowNOTIFY["EMP_CODE"] = dsRsltPUR.Tables["RSLTDT"].Rows[0]["BALJU_REG_EMP"];
                        //paramRowNOTIFY["PUR_NO"] = dsRsltPUR.Tables["RSLTDT"].Rows[0]["BALJU_NUM"];
                        //paramRowNOTIFY["PUR_SEQ"] = dsRsltPUR.Tables["RSLTDT"].Rows[0]["BALJU_SEQ"];
                        //paramRowNOTIFY["PUR_NO_TYPE"] = PUR_NO_TYPE_BAL;
                        //paramRowNOTIFY["PUR_STAT"] = BAL_STAT;
                        //paramRowNOTIFY["REG_EMP"] = REG_EMP;

                        //paramTableNOTIFY.Rows.Add(paramRowNOTIFY);

                        //CTRL.CTRL.CREATE_PUR_PO_SELF_NOTIFY(UTIL.GetDtToDs(paramTableNOTIFY), bizExecute);


                        ////신청자 알림
                        //DataTable paramTableNOTIFY_R = new DataTable("RQSTDT");
                        //paramTableNOTIFY_R.Columns.Add("PLT_CODE", typeof(String)); //
                        //paramTableNOTIFY_R.Columns.Add("EMP_CODE", typeof(String)); //
                        //paramTableNOTIFY_R.Columns.Add("PUR_NO", typeof(String)); //
                        //paramTableNOTIFY_R.Columns.Add("PUR_SEQ", typeof(Int32)); //
                        //paramTableNOTIFY_R.Columns.Add("PUR_NO_TYPE", typeof(String)); //
                        //paramTableNOTIFY_R.Columns.Add("PUR_STAT", typeof(String)); //
                        //paramTableNOTIFY_R.Columns.Add("REG_EMP", typeof(String)); //


                        //DataRow paramRowNOTIFY_R = paramTableNOTIFY_R.NewRow();
                        //paramRowNOTIFY_R["PLT_CODE"] = PLT_CODE;
                        //paramRowNOTIFY_R["EMP_CODE"] = dsRsltPUR.Tables["RSLTDT"].Rows[0]["REQ_REG_EMP"];
                        //paramRowNOTIFY_R["PUR_NO"] = dsRsltPUR.Tables["RSLTDT"].Rows[0]["REQUEST_NO"];
                        //paramRowNOTIFY_R["PUR_SEQ"] = dsRsltPUR.Tables["RSLTDT"].Rows[0]["REQUEST_SEQ"];
                        //paramRowNOTIFY_R["PUR_NO_TYPE"] = PUR_NO_TYPE_REQ;
                        //paramRowNOTIFY_R["PUR_STAT"] = BAL_STAT;
                        //paramRowNOTIFY_R["REG_EMP"] = REG_EMP;

                        //paramTableNOTIFY_R.Rows.Add(paramRowNOTIFY_R);

                        //CTRL.CTRL.CREATE_PUR_PO_SELF_NOTIFY(UTIL.GetDtToDs(paramTableNOTIFY_R), bizExecute);

                    }
                }
                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PUR05C_INS_OI(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                string SR_CODE = "OY";
                string F_YPGO_STAT = "19";
                string F_TEMP_YPGO_STAT = "20";
                string BAL_STAT = "";
                decimal ACT_MAN_TIME = 0;
                string PUR_STAT = "13";
                string WO_FLAG = "4";
                string PUR_NO_TYPE_REQ = "REQ";
                string PUR_NO_TYPE_BAL = "BAL";

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    string PLT_CODE = row["PLT_CODE"].ToString();
                    string BALJU_NUM = row["BALJU_NUM"].ToString();
                    string BALJU_SEQ = row["BALJU_SEQ"].ToString();
                    string YPGO_DATE = row["YPGO_DATE"].ToString();
                    string CLOSE_DATE = row["CLOSE_DATE"].ToString();
                    string YPGO_LOC = row["YPGO_LOC"].ToString();
                    string YPGO_LOC_DETAIL = row["YPGO_LOC_DETAIL"].ToString();
                    string INS_DATE = row["INS_DATE"].ToString();
                    int QTY = row["QTY"].toInt32();
                    string SCOMMENT = row["SCOMMENT"].ToString();
                    string REG_EMP = row["REG_EMP"].ToString();
                    string INS_FLAG = row["INS_FLAG"].ToString();

                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTable.Columns.Add("BALJU_NUM", typeof(String)); //
                    paramTable.Columns.Add("BALJU_SEQ", typeof(String)); //

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = PLT_CODE;
                    paramRow["BALJU_NUM"] = BALJU_NUM;
                    paramRow["BALJU_SEQ"] = BALJU_SEQ;
                    paramTable.Rows.Add(paramRow);

                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    DataSet dsRsltPUR = BPUR.PUR05C.PUR05C_SER_OI(paramSet, bizExecute);

                    //데이터 여부
                    if (dsRsltPUR.Tables["RSLTDT"].Rows.Count != 0)
                    {
                        //부분입고, 입고완료 결정
                        if (Convert.ToDecimal(dsRsltPUR.Tables["RSLTDT"].Rows[0]["BAL_QTY"])
                            <= (Convert.ToDecimal(dsRsltPUR.Tables["RSLTDT"].Rows[0]["YPGO_QTY"])
                            + Convert.ToDecimal(QTY)))
                        {
                            //입고완료
                            BAL_STAT = "22";

                            
                        }
                        else
                        {
                            //부분입고
                            BAL_STAT = "21";
                        }

                        if (Convert.ToDecimal(dsRsltPUR.Tables["RSLTDT"].Rows[0]["PART_QTY"])
                                <= (Convert.ToDecimal(dsRsltPUR.Tables["RSLTDT"].Rows[0]["TAT_YPGO_QTY"]) + Convert.ToDecimal(QTY)))
                        {
                            DataTable paramTableEVENT = new DataTable("RQSTDT");
                            paramTableEVENT.Columns.Add("PLT_CODE", typeof(String)); //
                            paramTableEVENT.Columns.Add("REQUEST_NO", typeof(String)); //
                            paramTableEVENT.Columns.Add("REQUEST_SEQ", typeof(String)); //
                            paramTableEVENT.Columns.Add("PUR_STAT", typeof(String)); //

                            DataRow paramRowEVENT = paramTableEVENT.NewRow();
                            paramRowEVENT["PLT_CODE"] = dsRsltPUR.Tables["RSLTDT"].Rows[0]["BALJU_DATE"];
                            paramRowEVENT["REQUEST_NO"] = dsRsltPUR.Tables["RSLTDT"].Rows[0]["REQUEST_NO"];
                            paramRowEVENT["REQUEST_SEQ"] = dsRsltPUR.Tables["RSLTDT"].Rows[0]["REQUEST_SEQ"];
                            paramRowEVENT["PUR_STAT"] = PUR_STAT;
                            paramTableEVENT.Rows.Add(paramRowEVENT);

                            //최근 발주승인날짜 알아오기
                            DataTable dtRsltEVET = DPUR.TPURCHASE_EVENT.TPURCHASE_EVENT_SER2(paramTableEVENT, bizExecute);

                            try
                            {
                                DateTime start = (DateTime)dtRsltEVET.Rows[0]["EVENT_DATE"];
                                DateTime end = DateTime.Now;

                                TimeSpan time = end.Subtract(start);

                                ACT_MAN_TIME = Convert.ToDecimal(Math.Floor(time.TotalMinutes));
                            }
                            catch
                            {
                                ACT_MAN_TIME = 0;
                            }

                            DateTime ypgo_time = new DateTime(System.Convert.ToInt32(YPGO_DATE.Substring(0, 4)),
                                 System.Convert.ToInt32(YPGO_DATE.Substring(4, 2)),
                                 System.Convert.ToInt32(YPGO_DATE.Substring(6, 2)),
                                 DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);


                            DataTable paramTableWK = new DataTable("RQSTDT");
                            paramTableWK.Columns.Add("WO_FLAG", typeof(String)); //
                            paramTableWK.Columns.Add("ACT_END_TIME", typeof(DateTime)); //
                            paramTableWK.Columns.Add("ACT_MAN_TIME", typeof(String)); //
                            paramTableWK.Columns.Add("PLT_CODE", typeof(String)); //
                            paramTableWK.Columns.Add("WO_NO", typeof(String)); //
                            paramTableWK.Columns.Add("ACT_QTY", typeof(Int32)); //

                            DataRow paramRowWK = paramTableWK.NewRow();
                            paramRowWK["WO_FLAG"] = WO_FLAG;
                            paramRowWK["ACT_END_TIME"] = ypgo_time;
                            //paramRowWK["ACT_MAN_TIME"] = ACT_MAN_TIME;
                            paramRowWK["PLT_CODE"] = dsRsltPUR.Tables["RSLTDT"].Rows[0]["PLT_CODE"];
                            paramRowWK["WO_NO"] = dsRsltPUR.Tables["RSLTDT"].Rows[0]["WO_NO"];
                            paramRowWK["ACT_QTY"] = dsRsltPUR.Tables["RSLTDT"].Rows[0]["TAT_YPGO_QTY"].toInt32() + QTY;

                            paramTableWK.Rows.Add(paramRowWK);

                            //작업지시상태 변경
                            DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD5_1(paramTableWK, bizExecute);
                            //DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD4(paramTableWK, bizExecute);
                        }
                        else
                        {
                            DateTime ypgo_time = new DateTime(System.Convert.ToInt32(YPGO_DATE.Substring(0, 4)),
                                System.Convert.ToInt32(YPGO_DATE.Substring(4, 2)),
                                System.Convert.ToInt32(YPGO_DATE.Substring(6, 2)),
                                DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

                            DataTable paramTableWK = new DataTable("RQSTDT");
                            paramTableWK.Columns.Add("WO_FLAG", typeof(String)); //
                            paramTableWK.Columns.Add("ACT_END_TIME", typeof(DateTime)); //
                            paramTableWK.Columns.Add("ACT_MAN_TIME", typeof(String)); //
                            paramTableWK.Columns.Add("PLT_CODE", typeof(String)); //
                            paramTableWK.Columns.Add("WO_NO", typeof(String)); //
                            paramTableWK.Columns.Add("ACT_QTY", typeof(Int32)); //

                            DataRow paramRowWK = paramTableWK.NewRow();
                            paramRowWK["WO_FLAG"] = "2";    //진행
                            paramRowWK["ACT_END_TIME"] = ypgo_time;
                            paramRowWK["PLT_CODE"] = dsRsltPUR.Tables["RSLTDT"].Rows[0]["PLT_CODE"];
                            paramRowWK["WO_NO"] = dsRsltPUR.Tables["RSLTDT"].Rows[0]["WO_NO"];
                            paramRowWK["ACT_QTY"] = dsRsltPUR.Tables["RSLTDT"].Rows[0]["TAT_YPGO_QTY"].toInt32() + QTY;

                            paramTableWK.Rows.Add(paramRowWK);
                            
                            //작업지시상태 변경
                            DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD5_1(paramTableWK, bizExecute);
                        }

                        DataSet tmpYpgoSet = new DataSet();
                        DataTable tmpYpgoTable = tmpYpgoSet.Tables.Add("RQSTDT");
                        tmpYpgoTable.Columns.Add("PLT_CODE", typeof(String));
                        tmpYpgoTable.Columns.Add("TYP_ID", typeof(String));
                        tmpYpgoTable.Columns.Add("TYP_STAT", typeof(String));

                        DataRow tmpYpgoRow = tmpYpgoTable.NewRow();
                        tmpYpgoRow["PLT_CODE"] = PLT_CODE;
                        tmpYpgoRow["TYP_ID"] = row["TYP_ID"];
                        tmpYpgoRow["TYP_STAT"] = BAL_STAT;
                        tmpYpgoTable.Rows.Add(tmpYpgoRow);

                        DOUT.TOUT_TEMP_YPGO.TOUT_TEMP_YPGO_UPD(tmpYpgoTable, bizExecute);

                        string SR_NO = UTIL.UTILITY_GET_SERIALNO(PLT_CODE, SR_CODE, UTIL.emSerialFormat.YYYYMMDD, "", bizExecute);


                        DataTable paramTableYPGO = new DataTable("YPGO");
                        paramTableYPGO.Columns.Add("PLT_CODE", typeof(String)); //
                        paramTableYPGO.Columns.Add("YPGO_ID", typeof(String)); //
                        paramTableYPGO.Columns.Add("BALJU_NUM", typeof(String)); //
                        paramTableYPGO.Columns.Add("BALJU_SEQ", typeof(Int32)); //
                        paramTableYPGO.Columns.Add("TYP_ID", typeof(String)); //
                        paramTableYPGO.Columns.Add("YPGO_DATE", typeof(String)); //
                        paramTableYPGO.Columns.Add("CLOSE_DATE", typeof(String)); //
                        paramTableYPGO.Columns.Add("QTY", typeof(Int32)); //
                        paramTableYPGO.Columns.Add("YPGO_STAT", typeof(String)); //
                        paramTableYPGO.Columns.Add("INS_FLAG", typeof(String)); //
                        paramTableYPGO.Columns.Add("SCOMMENT", typeof(String)); //


                        DataRow paramRowYPGO = paramTableYPGO.NewRow();
                        paramRowYPGO["PLT_CODE"] = PLT_CODE;
                        paramRowYPGO["YPGO_ID"] = SR_NO;
                        paramRowYPGO["BALJU_NUM"] = BALJU_NUM;
                        paramRowYPGO["BALJU_SEQ"] = BALJU_SEQ;
                        paramRowYPGO["TYP_ID"] = row["TYP_ID"];
                        paramRowYPGO["YPGO_DATE"] = YPGO_DATE;
                        paramRowYPGO["CLOSE_DATE"] = CLOSE_DATE;
                        paramRowYPGO["QTY"] = QTY;
                        paramRowYPGO["YPGO_STAT"] = "19";
                        paramRowYPGO["INS_FLAG"] = INS_FLAG;
                        paramRowYPGO["SCOMMENT"] = SCOMMENT;

                        paramTableYPGO.Rows.Add(paramRowYPGO);
                        //입고 정보
                        DOUT.TOUT_PROCYPGO.TOUT_PROCYPGO_INS(paramTableYPGO, bizExecute);


                        DataTable paramTableBALJU = new DataTable("BALJU");
                        paramTableBALJU.Columns.Add("BAL_STAT", typeof(String)); //
                        paramTableBALJU.Columns.Add("PLT_CODE", typeof(String)); //
                        paramTableBALJU.Columns.Add("BALJU_NUM", typeof(String)); //
                        paramTableBALJU.Columns.Add("BALJU_SEQ", typeof(Int32)); //


                        DataRow paramRowBALJU = paramTableBALJU.NewRow();
                        paramRowBALJU["BAL_STAT"] = BAL_STAT;
                        paramRowBALJU["PLT_CODE"] = PLT_CODE;
                        paramRowBALJU["BALJU_NUM"] = BALJU_NUM;
                        paramRowBALJU["BALJU_SEQ"] = BALJU_SEQ;
                        paramTableBALJU.Rows.Add(paramRowBALJU);

                        //발주상태 변경
                        DOUT.TOUT_PROCBALJU.TOUT_PROCBALJU_UPD2(paramTableBALJU, bizExecute);


                        //구매이벤트
                        DataTable paramTablePURCHASE = new DataTable("RQSTDT");
                        paramTablePURCHASE.Columns.Add("PLT_CODE", typeof(String)); //
                        paramTablePURCHASE.Columns.Add("REQUEST_NO", typeof(String)); //
                        paramTablePURCHASE.Columns.Add("REQUEST_SEQ", typeof(Int32)); //
                        paramTablePURCHASE.Columns.Add("PUR_STAT", typeof(String)); //


                        DataRow paramRowPURCHASE = paramTablePURCHASE.NewRow();
                        paramRowPURCHASE["PLT_CODE"] = PLT_CODE;
                        paramRowPURCHASE["REQUEST_NO"] = dsRsltPUR.Tables["RSLTDT"].Rows[0]["REQUEST_NO"];
                        paramRowPURCHASE["REQUEST_SEQ"] = dsRsltPUR.Tables["RSLTDT"].Rows[0]["REQUEST_SEQ"];
                        paramRowPURCHASE["PUR_STAT"] = BAL_STAT;

                        paramTablePURCHASE.Rows.Add(paramRowPURCHASE);

                        CTRL.CTRL.SET_PURCHASE_EVENT_M(UTIL.GetDtToDs(paramTablePURCHASE), bizExecute);


                        //발주자 알림
                        DataTable paramTableNOTIFY = new DataTable("RQSTDT");
                        paramTableNOTIFY.Columns.Add("PLT_CODE", typeof(String)); //
                        paramTableNOTIFY.Columns.Add("EMP_CODE", typeof(String)); //
                        paramTableNOTIFY.Columns.Add("PUR_NO", typeof(String)); //
                        paramTableNOTIFY.Columns.Add("PUR_SEQ", typeof(Int32)); //
                        paramTableNOTIFY.Columns.Add("PUR_NO_TYPE", typeof(String)); //
                        paramTableNOTIFY.Columns.Add("PUR_STAT", typeof(String)); //
                        paramTableNOTIFY.Columns.Add("REG_EMP", typeof(String)); //


                        DataRow paramRowNOTIFY = paramTableNOTIFY.NewRow();
                        paramRowNOTIFY["PLT_CODE"] = PLT_CODE;
                        paramRowNOTIFY["EMP_CODE"] = dsRsltPUR.Tables["RSLTDT"].Rows[0]["BALJU_REG_EMP"];
                        paramRowNOTIFY["PUR_NO"] = dsRsltPUR.Tables["RSLTDT"].Rows[0]["BALJU_NUM"];
                        paramRowNOTIFY["PUR_SEQ"] = dsRsltPUR.Tables["RSLTDT"].Rows[0]["BALJU_SEQ"];
                        paramRowNOTIFY["PUR_NO_TYPE"] = PUR_NO_TYPE_BAL;
                        paramRowNOTIFY["PUR_STAT"] = BAL_STAT;
                        paramRowNOTIFY["REG_EMP"] = REG_EMP;

                        paramTableNOTIFY.Rows.Add(paramRowNOTIFY);

                        CTRL.CTRL.CREATE_PUR_PO_SELF_NOTIFY(UTIL.GetDtToDs(paramTableNOTIFY), bizExecute);


                        //신청자 알림
                        DataTable paramTableNOTIFY_R = new DataTable("RQSTDT");
                        paramTableNOTIFY_R.Columns.Add("PLT_CODE", typeof(String)); //
                        paramTableNOTIFY_R.Columns.Add("EMP_CODE", typeof(String)); //
                        paramTableNOTIFY_R.Columns.Add("PUR_NO", typeof(String)); //
                        paramTableNOTIFY_R.Columns.Add("PUR_SEQ", typeof(Int32)); //
                        paramTableNOTIFY_R.Columns.Add("PUR_NO_TYPE", typeof(String)); //
                        paramTableNOTIFY_R.Columns.Add("PUR_STAT", typeof(String)); //
                        paramTableNOTIFY_R.Columns.Add("REG_EMP", typeof(String)); //


                        DataRow paramRowNOTIFY_R = paramTableNOTIFY_R.NewRow();
                        paramRowNOTIFY_R["PLT_CODE"] = PLT_CODE;
                        paramRowNOTIFY_R["EMP_CODE"] = dsRsltPUR.Tables["RSLTDT"].Rows[0]["REQ_REG_EMP"];
                        paramRowNOTIFY_R["PUR_NO"] = dsRsltPUR.Tables["RSLTDT"].Rows[0]["REQUEST_NO"];
                        paramRowNOTIFY_R["PUR_SEQ"] = dsRsltPUR.Tables["RSLTDT"].Rows[0]["REQUEST_SEQ"];
                        paramRowNOTIFY_R["PUR_NO_TYPE"] = PUR_NO_TYPE_REQ;
                        paramRowNOTIFY_R["PUR_STAT"] = BAL_STAT;
                        paramRowNOTIFY_R["REG_EMP"] = REG_EMP;

                        paramTableNOTIFY_R.Rows.Add(paramRowNOTIFY_R);

                        CTRL.CTRL.CREATE_PUR_PO_SELF_NOTIFY(UTIL.GetDtToDs(paramTableNOTIFY_R), bizExecute);

                    }
                }
                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        //공정외주 입고예정일 변경
        public static DataSet PUR05C_INS3_PO(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    string PLT_CODE = row["PLT_CODE"].ToString();
                    string BALJU_NUM = row["BALJU_NUM"].ToString();
                    string BALJU_SEQ = row["BALJU_SEQ"].ToString();
                    string REG_EMP = row["REG_EMP"].ToString();
                    string DUE_DATE = row["DUE_DATE"].ToString();
                    string WO_NO = row["WO_NO"].ToString();

                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTable.Columns.Add("BALJU_NUM", typeof(String)); //
                    paramTable.Columns.Add("BALJU_SEQ", typeof(String)); //

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = PLT_CODE;
                    paramRow["BALJU_NUM"] = BALJU_NUM;
                    paramRow["BALJU_SEQ"] = BALJU_SEQ;
                    paramTable.Rows.Add(paramRow);

                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    DataSet dsRsltPUR = BPUR.PUR05C.PUR05C_SER_PO(paramSet, bizExecute);

                    //데이터 여부
                    if (dsRsltPUR.Tables["RSLTDT"].Rows.Count != 0)
                    {
                        //발주상태 변경
                        DataTable paramTableBALJU = new DataTable("BALJU");
                        paramTableBALJU.Columns.Add("DUE_DATE", typeof(String)); //
                        paramTableBALJU.Columns.Add("PLT_CODE", typeof(String)); //
                        paramTableBALJU.Columns.Add("BALJU_NUM", typeof(String)); //
                        paramTableBALJU.Columns.Add("BALJU_SEQ", typeof(Int32)); //

                        DataRow paramRowBALJU = paramTableBALJU.NewRow();
                        paramRowBALJU["DUE_DATE"] = DUE_DATE;
                        paramRowBALJU["PLT_CODE"] = PLT_CODE;
                        paramRowBALJU["BALJU_NUM"] = BALJU_NUM;
                        paramRowBALJU["BALJU_SEQ"] = BALJU_SEQ;
                        paramTableBALJU.Rows.Add(paramRowBALJU);

                        DOUT.TOUT_PROCBALJU.TOUT_PROCBALJU_UPD4(paramTableBALJU, bizExecute);

                        //입고예정일 변경
                        DataTable paramTableWK = new DataTable("RQSTDT");
                        paramTableWK.Columns.Add("PLT_CODE", typeof(String)); //
                        paramTableWK.Columns.Add("WO_NO", typeof(String)); //
                        paramTableWK.Columns.Add("PLN_END_TIME", typeof(String)); //

                        DataRow paramRowWK = paramTableWK.NewRow();
                        paramRowWK["PLT_CODE"] = PLT_CODE;
                        paramRowWK["WO_NO"] = WO_NO;
                        paramRowWK["PLN_END_TIME"] = DUE_DATE + "1300";
                        paramTableWK.Rows.Add(paramRowWK);

                        DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD5_3(paramTableWK, bizExecute);

                    }
                }
                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
        public static DataSet PUR05C_INS3_OI(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    string PLT_CODE = row["PLT_CODE"].ToString();
                    string BALJU_NUM = row["BALJU_NUM"].ToString();
                    string BALJU_SEQ = row["BALJU_SEQ"].ToString();
                    string REG_EMP = row["REG_EMP"].ToString();
                    string DUE_DATE = row["DUE_DATE"].ToString();
                    string WO_NO = row["WO_NO"].ToString();

                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTable.Columns.Add("BALJU_NUM", typeof(String)); //
                    paramTable.Columns.Add("BALJU_SEQ", typeof(String)); //

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = PLT_CODE;
                    paramRow["BALJU_NUM"] = BALJU_NUM;
                    paramRow["BALJU_SEQ"] = BALJU_SEQ;
                    paramTable.Rows.Add(paramRow);

                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    DataSet dsRsltPUR = BPUR.PUR05C.PUR05C_SER_OI(paramSet, bizExecute);

                    //데이터 여부
                    if (dsRsltPUR.Tables["RSLTDT"].Rows.Count != 0)
                    {
                        //발주상태 변경
                        DataTable paramTableBALJU = new DataTable("BALJU");
                        paramTableBALJU.Columns.Add("DUE_DATE", typeof(String)); //
                        paramTableBALJU.Columns.Add("PLT_CODE", typeof(String)); //
                        paramTableBALJU.Columns.Add("BALJU_NUM", typeof(String)); //
                        paramTableBALJU.Columns.Add("BALJU_SEQ", typeof(Int32)); //

                        DataRow paramRowBALJU = paramTableBALJU.NewRow();
                        paramRowBALJU["DUE_DATE"] = DUE_DATE;
                        paramRowBALJU["PLT_CODE"] = PLT_CODE;
                        paramRowBALJU["BALJU_NUM"] = BALJU_NUM;
                        paramRowBALJU["BALJU_SEQ"] = BALJU_SEQ;
                        paramTableBALJU.Rows.Add(paramRowBALJU);

                        DOUT.TOUT_PROCBALJU.TOUT_PROCBALJU_UPD4(paramTableBALJU, bizExecute);

                        //입고예정일 변경
                        DataTable paramTableWK = new DataTable("RQSTDT");
                        paramTableWK.Columns.Add("PLT_CODE", typeof(String)); //
                        paramTableWK.Columns.Add("WO_NO", typeof(String)); //
                        paramTableWK.Columns.Add("PLN_END_TIME", typeof(String)); //

                        DataRow paramRowWK = paramTableWK.NewRow();
                        paramRowWK["PLT_CODE"] = PLT_CODE;
                        paramRowWK["WO_NO"] = WO_NO;
                        paramRowWK["PLN_END_TIME"] = DUE_DATE + "1300";
                        paramTableWK.Rows.Add(paramRowWK);

                        DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD5_3(paramTableWK, bizExecute);

                    }
                }
                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 물품입고 취소
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet PUR05C_CANCEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach(DataRow cancelRow in paramDS.Tables["RQSTDT"].Rows)
                {
                    string balStat = "";

                    //INS_FLAG = 0 무검사, 1 검사
                    if(cancelRow["INS_FLAG"].Equals("0"))
                    {
                        //무검사
                        //물품입고 단계로 변경
                        //TOUT_TEMP_YPGO 테이블 데이터 삭제
                        DOUT.TOUT_TEMP_YPGO.TOUT_TEMP_YPGO_DEL(UTIL.GetRowToDt(cancelRow), bizExecute);
                        //상태값 변경
                        if (cancelRow["BAL_STAT"].Equals("40"))
                        {
                            //발주승인
                            balStat = "13";
                        }
                        else if (cancelRow["BAL_STAT"].Equals("41"))
                        {
                            //발주승인
                            balStat = "13";
                        }
                    }
                    else
                    {
                        //검사
                        //TQCT_PURCHASE_NG 테이블 데이터 삭제
                        DQCT.TQCT_PURCHASE_NG.TQCT_PURCHASE_NG_DEL(UTIL.GetRowToDt(cancelRow), bizExecute);
                        //상태값 변경
                        if (cancelRow["BAL_STAT"].Equals("40"))
                        {
                            //부분검사대기
                            balStat = "42";
                        }
                        else if (cancelRow["BAL_STAT"].Equals("41"))
                        {
                            //검사대기
                            balStat = "20";
                        }
                    }

                    if(balStat.isNullOrEmpty() == false)
                    {
                        DataTable paramTableBALJU = new DataTable("BALJU");
                        paramTableBALJU.Columns.Add("BAL_STAT", typeof(String)); //
                        paramTableBALJU.Columns.Add("PLT_CODE", typeof(String)); //
                        paramTableBALJU.Columns.Add("TYP_ID", typeof(String)); //
                        paramTableBALJU.Columns.Add("BALJU_NUM", typeof(String)); //
                        paramTableBALJU.Columns.Add("BALJU_SEQ", typeof(Int32)); //


                        DataRow paramRowBALJU = paramTableBALJU.NewRow();
                        paramRowBALJU["BAL_STAT"] = balStat;
                        paramRowBALJU["PLT_CODE"] = ConnInfo.PLT_CODE;
                        paramRowBALJU["TYP_ID"] = cancelRow["TYP_ID"];
                        paramRowBALJU["BALJU_NUM"] = cancelRow["BALJU_NUM"];
                        paramRowBALJU["BALJU_SEQ"] = cancelRow["BALJU_SEQ"];
                        paramTableBALJU.Rows.Add(paramRowBALJU);

                        //발주상태 변경
                        DOUT.TOUT_PROCBALJU.TOUT_PROCBALJU_UPD2(paramTableBALJU, bizExecute);

                        DOUT.TOUT_TEMP_YPGO.TOUT_TEMP_YPGO_UPD3(paramTableBALJU, bizExecute);
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
