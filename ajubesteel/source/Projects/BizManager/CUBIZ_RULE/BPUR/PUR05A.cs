using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BPUR
{
    public class PUR05A
    {
        public static DataSet PUR05A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                // paramDS.Tables["RQSTDT"].Columns.Add("BALJU_NUM", typeof(string));

                // paramDS.Tables["RQSTDT"].Columns.Add("BALJU_SEQ", typeof(string));

                // 자재입고처리시 RQSTDT 테이블에서 BALJU_NUM, BALJU_SEQ를 미리 받아오기 때문에 주석처리함 21.07.22


                DataTable dtParam = paramDS.Tables["RQSTDT"].Copy();

                if (paramDS.Tables["RQSTDT"].Rows.Count > 0)
                {
                    if (paramDS.Tables["RQSTDT"].Columns.Contains("BARCODE"))
                    {
                        string barcode = paramDS.Tables["RQSTDT"].Rows[0]["BARCODE"].ToString();

                        if (barcode != "" && barcode.Length == 11)
                        {
                            dtParam.Rows.Clear();
                            DataRow dr = dtParam.NewRow();
                            dr["PLT_CODE"] = "100";
                            dr["BALJU_NUM"] = barcode;
                            dtParam.Rows.Add(dr);
                            //paramDS.Tables["RQSTDT"].Rows[0]["BALJU_NUM"] = barcode;
                        }
                        else if (barcode != "" && barcode.Length > 11)
                        {
                            dtParam.Rows.Clear();
                            DataRow dr = dtParam.NewRow();
                            dr["PLT_CODE"] = "100";
                            string[] bar = barcode.Split('-');
                            dr["BALJU_NUM"] = bar[0];
                            dr["BALJU_SEQ"] = bar[1];
                            dtParam.Rows.Add(dr);
                            //paramDS.Tables["RQSTDT"].Rows[0]["BALJU_NUM"] = barcode.Substring(0, 11);
                            //paramDS.Tables["RQSTDT"].Rows[0]["BALJU_SEQ"] = barcode.Substring(11, barcode.Length - 11);
                        }

                        
                    }
                    

                }
                
                //DataTable dtRslt = DMAT.TMAT_BALJU_QUERY.TMAT_BALJU_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);
                DataTable dtRslt = DMAT.TMAT_BALJU_QUERY.TMAT_BALJU_QUERY3(dtParam, bizExecute);
                dtRslt.Columns.Add("SEL");
                dtRslt.Columns.Add("EX_RATE", typeof(decimal));

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
        public static DataSet PUR05A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                //발주(11), 검사완료(43)
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PUR05A", "1", typeof(string));

                DataTable dtRslt = DOUT.TOUT_PROCBALJU_QUERY.TOUT_PROCBALJU_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.Columns.Add("SEL");

                dtRslt.Columns.Add("EX_RATE", typeof(decimal));

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
        public static DataSet PUR05A_INS_M(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                string YPGO_STAT = "";
                string SR_CODE = "MY";
                string BAL_STAT = "";
                      //완료;

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    string PLT_CODE = row["PLT_CODE"].ToString();
                    string BALJU_NUM = row["BALJU_NUM"].ToString();
                    string BALJU_SEQ = row["BALJU_SEQ"].ToString();
                    string YPGO_DATE = row["YPGO_DATE"].ToString();
                    int QTY = row["QTY"].toInt32();
                    decimal UNIT_COST = row["YPGO_COST"].toDecimal();
                    decimal AMT = row["YPGO_AMT"].toDecimal();
                    string SCOMMENT = row["SCOMMENT"].ToString();
                    string REG_EMP = row["REG_EMP"].ToString();
                    string YPGO_LOC = row["STK_LOCATION"].ToString();
                    decimal EX_RATE = row["EX_RATE"].toDecimal();
                    string VND_CODE = row["VND_CODE"].ToString();

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

                    DataSet dsRsltPUR = BPUR.PUR05A.PUR05A_SER(paramSet, bizExecute);
                    //데이터 여부
                    if (dsRsltPUR.Tables["RSLTDT"].Rows.Count != 0)
                    {
                        //DataTable paramTable2 = new DataTable("RQSTDT");
                        //paramTable2.Columns.Add("DATE1", typeof(String)); //
                        //paramTable2.Columns.Add("DATE2", typeof(String)); //

                        //DataRow paramRow2 = paramTable2.NewRow();
                        //paramRow2["DATE1"] = dsRsltPUR.Tables["RSLTDT"].Rows[0]["BALJU_DATE"];
                        //paramRow2["DATE2"] = YPGO_DATE;
                        //paramTable2.Rows.Add(paramRow2);

                        //DataSet paramSet2 = new DataSet();
                        //paramSet2.Tables.Add(paramTable2);

                        //DataSet dsRslt = CTRL.CTRL.COMPARE_DATE(paramSet2, bizExecute);

                        ////발주일이 더큼
                        //if (dsRslt.Tables["RSLTDT"].Rows[0]["RESULT"].ToString() == "DATE1")
                        //{
                        //    throw UTIL.SetException("입고일은 발주일 이전날짜로 설정될 수 없습니다."
                        //   , new System.Diagnostics.StackFrame().GetMethod().Name
                        //   , BizException.ABORT);
                        //}

                        //검사여부
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
                        YPGO_STAT = "19";

                        //+ Convert.ToDecimal(dsRsltPUR.Tables["RSLTDT"].Rows[0]["CHK_YPGO_QTY"])
                        //발주수량 대비 입고수량 확인
                        if (Convert.ToDecimal(dsRsltPUR.Tables["RSLTDT"].Rows[0]["BAL_QTY"])
                            < (Convert.ToDecimal(dsRsltPUR.Tables["RSLTDT"].Rows[0]["YPGO_QTY"])
                            + Convert.ToDecimal(QTY)
                            + Convert.ToDecimal(dsRsltPUR.Tables["RSLTDT"].Rows[0]["NG_QTY"].toDecimal())))
                        {
                            throw UTIL.SetException("잔량보다 입고할 수량이 많습니다."
                            , new System.Diagnostics.StackFrame().GetMethod().Name
                            , BizException.ABORT);
                        }


                        //부분입고, 입고완료 결정
                        if (Convert.ToDecimal(dsRsltPUR.Tables["RSLTDT"].Rows[0]["BAL_QTY"])
                            <= (Convert.ToDecimal(dsRsltPUR.Tables["RSLTDT"].Rows[0]["YPGO_QTY"]) + dsRsltPUR.Tables["RSLTDT"].Rows[0]["NG_QTY"].toDecimal()
                            + Convert.ToDecimal(QTY)))
                        {
                            //입고완료
                            BAL_STAT = "22";

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
                               
                            //}
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
                        paramTableYPGO.Columns.Add("QTY", typeof(Int32)); //
                        paramTableYPGO.Columns.Add("UNIT_COST", typeof(Decimal)); //
                        paramTableYPGO.Columns.Add("AMT", typeof(Decimal)); //
                        paramTableYPGO.Columns.Add("YPGO_STAT", typeof(String)); //
                        paramTableYPGO.Columns.Add("INS_FLAG", typeof(String)); //
                        paramTableYPGO.Columns.Add("SCOMMENT", typeof(String)); //
                        paramTableYPGO.Columns.Add("YPGO_LOC", typeof(String)); //
                        paramTableYPGO.Columns.Add("TYPE", typeof(String)); //
                        paramTableYPGO.Columns.Add("PART_CODE", typeof(String)); //
                        paramTableYPGO.Columns.Add("DETAIL_PART_NAME", typeof(String)); //
                        paramTableYPGO.Columns.Add("STK_ID", typeof(String)); //
                        paramTableYPGO.Columns.Add("EX_RATE", typeof(Decimal)); //
                        paramTableYPGO.Columns.Add("CVND_CODE", typeof(String)); //

                        DataRow paramRowYPGO = paramTableYPGO.NewRow();
                        paramRowYPGO["PLT_CODE"] = PLT_CODE;
                        paramRowYPGO["YPGO_ID"] = SR_NO;
                        paramRowYPGO["BALJU_NUM"] = BALJU_NUM;
                        paramRowYPGO["BALJU_SEQ"] = BALJU_SEQ;
                        paramRowYPGO["YPGO_DATE"] = YPGO_DATE;
                        paramRowYPGO["QTY"] = QTY;
                        paramRowYPGO["UNIT_COST"] = UNIT_COST;
                        paramRowYPGO["AMT"] = AMT;
                        paramRowYPGO["YPGO_STAT"] = YPGO_STAT;
                        //paramRowYPGO["INS_FLAG"] = INS_FLAG;
                        paramRowYPGO["SCOMMENT"] = SCOMMENT;
                        paramRowYPGO["YPGO_LOC"] = YPGO_LOC;
                        paramRowYPGO["TYPE"] = "IN";
                        paramRowYPGO["PART_CODE"] = dsRsltPUR.Tables["RSLTDT"].Rows[0]["PART_CODE"];
                        paramRowYPGO["DETAIL_PART_NAME"] = dsRsltPUR.Tables["RSLTDT"].Rows[0]["DETAIL_PART_NAME"];
                        paramRowYPGO["EX_RATE"] = EX_RATE;
                        paramRowYPGO["CVND_CODE"] = VND_CODE;

                        paramTableYPGO.Rows.Add(paramRowYPGO);

                        //입고 정보
                        DMAT.TMAT_YPGO.TMAT_YPGO_INS(paramTableYPGO, bizExecute);

                        //재고 입고 처리
                        CTRL.CTRL.SET_STOCK_PROCESS(paramRowYPGO, bizExecute, "PART_CODE", "YPGO_LOC", "QTY", "AMT", "YPGO_ID", null);

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
                    }
                }

                DataTable dtRslt = DMAT.TMAT_BALJU_QUERY.TMAT_BALJU_QUERY3(paramDS.Tables["RQSTDT_SEARCH"], bizExecute);
                dtRslt.Columns.Add("SEL");
                dtRslt.Columns.Add("EX_RATE", typeof(decimal));
                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PUR05A_INS_PO(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable paramTableYPGO = new DataTable("YPGO");
                paramTableYPGO.Columns.Add("PLT_CODE", typeof(String)); //
                paramTableYPGO.Columns.Add("YPGO_ID", typeof(String)); //
                paramTableYPGO.Columns.Add("BALJU_NUM", typeof(String)); //
                paramTableYPGO.Columns.Add("BALJU_SEQ", typeof(Int32)); //
                paramTableYPGO.Columns.Add("YPGO_DATE", typeof(String)); //
                paramTableYPGO.Columns.Add("QTY", typeof(Int32)); //
                paramTableYPGO.Columns.Add("UNIT_COST", typeof(decimal)); //
                paramTableYPGO.Columns.Add("AMT", typeof(decimal)); //
                paramTableYPGO.Columns.Add("YPGO_STAT", typeof(String)); //
                paramTableYPGO.Columns.Add("INS_FLAG", typeof(String)); //
                paramTableYPGO.Columns.Add("SCOMMENT", typeof(String)); //
                paramTableYPGO.Columns.Add("YPGO_LOC", typeof(String)); //
                paramTableYPGO.Columns.Add("EX_RATE", typeof(decimal)); //

                DataTable paramTableBALJU = new DataTable("BALJU");
                paramTableBALJU.Columns.Add("BAL_STAT", typeof(String)); //
                paramTableBALJU.Columns.Add("PLT_CODE", typeof(String)); //
                paramTableBALJU.Columns.Add("BALJU_NUM", typeof(String)); //
                paramTableBALJU.Columns.Add("BALJU_SEQ", typeof(Int32)); //


                DataTable paramTableWO = new DataTable("RQSTDT");
                paramTableWO.Columns.Add("PLT_CODE", typeof(String));
                paramTableWO.Columns.Add("WO_NO", typeof(String));
                paramTableWO.Columns.Add("WO_FLAG", typeof(Int32));
                paramTableWO.Columns.Add("ACT_END_TIME", typeof(DateTime));
                paramTableWO.Columns.Add("ACT_QTY", typeof(Int32));

                string YPGO_STAT = "";
                string BAL_STAT = "";
                string WO_FLAG = "4";
                string SR_CODE = "PY";

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    string PLT_CODE = row["PLT_CODE"].ToString();
                    string BALJU_NUM = row["BALJU_NUM"].ToString();
                    string BALJU_SEQ = row["BALJU_SEQ"].ToString();
                    string YPGO_DATE = row["YPGO_DATE"].ToString();
                    int QTY = row["QTY"].toInt32();
                    decimal UNIT_COST = row["YPGO_COST"].toDecimal();
                    decimal AMT = row["YPGO_AMT"].toDecimal();
                    string SCOMMENT = row["SCOMMENT"].ToString();
                    string REG_EMP = row["REG_EMP"].ToString();
                    string YPGO_LOC = row["STK_LOCATION"].ToString();
                    decimal EX_RATE = row["EX_RATE"].toDecimal();

                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTable.Columns.Add("BALJU_NUM", typeof(String)); //
                    paramTable.Columns.Add("BALJU_SEQ", typeof(String)); //
                    paramTable.Columns.Add("DATA_FLAG", typeof(int)); //

                    DataRow paramRow = paramTable.NewRow();
                    paramRow["PLT_CODE"] = PLT_CODE;
                    paramRow["BALJU_NUM"] = BALJU_NUM;
                    paramRow["BALJU_SEQ"] = BALJU_SEQ;
                    paramRow["DATA_FLAG"] = 0;
                    paramTable.Rows.Add(paramRow);

                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(paramTable);

                    DataTable dtRsltPUR = DOUT.TOUT_PROCBALJU_QUERY.TOUT_PROCBALJU_QUERY3(paramTable, bizExecute);
                    
                    //데이터 여부
                    if (dtRsltPUR.Rows.Count != 0)
                    {

                        YPGO_STAT = "19";

                        if (Convert.ToDecimal(dtRsltPUR.Rows[0]["BAL_QTY"])
                            < (Convert.ToDecimal(dtRsltPUR.Rows[0]["YPGO_QTY"])
                            + Convert.ToDecimal(QTY)
                            + Convert.ToDecimal(dtRsltPUR.Rows[0]["NG_QTY"].toDecimal())))
                        {
                            throw UTIL.SetException("잔량보다 입고할 수량이 많습니다."
                            , new System.Diagnostics.StackFrame().GetMethod().Name
                            , BizException.ABORT);
                        }


                        //부분입고, 입고완료 결정
                        if (Convert.ToDecimal(dtRsltPUR.Rows[0]["BAL_QTY"])
                            <= (Convert.ToDecimal(dtRsltPUR.Rows[0]["YPGO_QTY"]) + dtRsltPUR.Rows[0]["NG_QTY"].toDecimal()
                            + Convert.ToDecimal(QTY)))
                        {
                            //입고 완료
                            BAL_STAT = "22";

                        }
                        else
                        {
                            //부분입고
                            BAL_STAT = "21";
                        }
                    }

                    string SR_NO = UTIL.UTILITY_GET_SERIALNO(PLT_CODE, SR_CODE, UTIL.emSerialFormat.YYYYMMDD, "", bizExecute);

                    paramTableYPGO.Clear();
                    DataRow paramRowYPGO = paramTableYPGO.NewRow();
                    paramRowYPGO["PLT_CODE"] = PLT_CODE;
                    paramRowYPGO["YPGO_ID"] = SR_NO;
                    paramRowYPGO["BALJU_NUM"] = BALJU_NUM;
                    paramRowYPGO["BALJU_SEQ"] = BALJU_SEQ;
                    paramRowYPGO["YPGO_DATE"] = YPGO_DATE;
                    paramRowYPGO["QTY"] = QTY;
                    paramRowYPGO["UNIT_COST"] = UNIT_COST;
                    paramRowYPGO["AMT"] = AMT;
                    paramRowYPGO["YPGO_STAT"] = YPGO_STAT;
                    paramRowYPGO["YPGO_LOC"] = YPGO_LOC;
                    paramRowYPGO["SCOMMENT"] = SCOMMENT;
                    paramRowYPGO["EX_RATE"] = EX_RATE;
                    paramTableYPGO.Rows.Add(paramRowYPGO);

                    //입고 정보
                    DOUT.TOUT_PROCYPGO.TOUT_PROCYPGO_INS(paramTableYPGO, bizExecute);

                    paramTableBALJU.Clear();
                    DataRow paramRowBALJU = paramTableBALJU.NewRow();
                    paramRowBALJU["BAL_STAT"] = BAL_STAT;
                    paramRowBALJU["PLT_CODE"] = PLT_CODE;
                    paramRowBALJU["BALJU_NUM"] = BALJU_NUM;
                    paramRowBALJU["BALJU_SEQ"] = BALJU_SEQ;
                    paramTableBALJU.Rows.Add(paramRowBALJU);

                    //발주상태 변경
                    DOUT.TOUT_PROCBALJU.TOUT_PROCBALJU_UPD2(paramTableBALJU, bizExecute);

                    //입고완료일떄만 작업지시 완료처리
                    if (BAL_STAT == "22")
                    {
                        DateTime ypgo_date = new DateTime(System.Convert.ToInt32(YPGO_DATE.Substring(0, 4)),
                                 System.Convert.ToInt32(YPGO_DATE.Substring(4, 2)),
                                 System.Convert.ToInt32(YPGO_DATE.Substring(6, 2)),
                                 DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

                        paramTableWO.Clear();
                        //작업지시 상태 완료로 변경
                        DataRow paramRowWo = paramTableWO.NewRow();
                        paramRowWo["PLT_CODE"] = PLT_CODE;
                        paramRowWo["WO_NO"] = row["WO_NO"];
                        paramRowWo["WO_FLAG"] = WO_FLAG;            //완료
                        paramRowWo["ACT_END_TIME"] = ypgo_date;
                        paramRowWo["ACT_QTY"] = QTY;
                        paramTableWO.Rows.Add(paramRowWo);

                        DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD5_1_1(paramTableWO, bizExecute);
                    }
                }

                //입고후 결과조회할때 RQSTDT_SEARCH 테이블에 PUR05A 조건 탈 수 있게 추가
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_SEARCH"], "PUR05A", "1", typeof(string));

                DataTable dtRslt = DOUT.TOUT_PROCBALJU_QUERY.TOUT_PROCBALJU_QUERY3(paramDS.Tables["RQSTDT_SEARCH"], bizExecute);

                dtRslt.Columns.Add("SEL");
                dtRslt.Columns.Add("EX_RATE", typeof(decimal));

                paramDS.Tables.Add(dtRslt);


                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PUR05A_UPD(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach(DataRow dr in paramDS.Tables["RQSTDT"].Rows)
                {
                    DMAT.TMAT_BALJU.TMAT_BALJU_UPD5(UTIL.GetRowToDt(dr), bizExecute);
                }
                

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PUR05A_UPD2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                foreach(DataRow dr in paramDS.Tables["RQSTDT"].Rows)
                {
                    DOUT.TOUT_PROCBALJU.TOUT_PROCBALJU_UPD5(UTIL.GetRowToDt(dr), bizExecute);
                }
                
                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        //입고 완료 상태로 변경
        public static DataSet PUR05A_INS2_PO(DataSet paramDS, BizExecute.BizExecute bizExecute)
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
                    paramTableWO.Columns.Add("ACT_END_TIME", typeof(DateTime));

                    DataRow paramRowWo = paramTableWO.NewRow();
                    paramRowWo["PLT_CODE"] = dr["PLT_CODE"];
                    paramRowWo["WO_NO"] = dr["WO_NO"];
                    paramRowWo["WO_FLAG"] = "4";            //완료

                    string ypgo_date = dr["YPGO_DATE"].ToString();

                    DateTime ypgo_time = new DateTime(System.Convert.ToInt32(ypgo_date.Substring(0, 4)),
                         System.Convert.ToInt32(ypgo_date.Substring(4, 2)),
                         System.Convert.ToInt32(ypgo_date.Substring(6, 2)),
                         DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);


                    paramRowWo["ACT_END_TIME"] = ypgo_time;

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

        public static DataSet PUR05A_INS2_M(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "BAL_STAT", "22", typeof(String));

                DMAT.TMAT_BALJU.TMAT_BALJU_UPD2(paramDS.Tables["RQSTDT"], bizExecute);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
    }
}

