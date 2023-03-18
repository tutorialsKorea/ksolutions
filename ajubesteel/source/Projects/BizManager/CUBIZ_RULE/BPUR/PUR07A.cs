using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BPUR
{
    public class PUR07A
    {

        //자재 입고 현황
        public static DataSet PUR07A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "YPGO", "YPGO", typeof(string));

                DataTable dtRslt = DMAT.TMAT_YPGO_QUERY.TMAT_YPGO_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                
                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        //외주 입고 현황
        public static DataSet PUR07A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "YPGO", "YPGO", typeof(string));

                DataTable dtRslt = DOUT.TOUT_PROCYPGO_QUERY.TOUT_PROCYPGO_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                
                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        
        //수입검사(공정외주)
        //발주->수입검사->입고 
        //TOUT_PROCBALJU에 검사 정보 업데이트
        public static DataSet PUR06A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //DataTable paramTableYPGO = new DataTable("YPGO");
                //paramTableYPGO.Columns.Add("PLT_CODE", typeof(string)); //
                //paramTableYPGO.Columns.Add("YPGO_ID", typeof(string)); //
                //paramTableYPGO.Columns.Add("BALJU_NUM", typeof(string)); //
                //paramTableYPGO.Columns.Add("BALJU_SEQ", typeof(Int32)); //
                //paramTableYPGO.Columns.Add("YPGO_DATE", typeof(string)); //
                //paramTableYPGO.Columns.Add("QTY", typeof(Int32)); //
                //paramTableYPGO.Columns.Add("YPGO_STAT", typeof(string)); //
                //paramTableYPGO.Columns.Add("INS_FLAG", typeof(string)); //
                //paramTableYPGO.Columns.Add("INS_DATE", typeof(string)); //
                //paramTableYPGO.Columns.Add("INS_EMP", typeof(string)); //
                //paramTableYPGO.Columns.Add("SCOMMENT", typeof(string)); //

                DataTable paramTableBALJU = new DataTable("BALJU");
                paramTableBALJU.Columns.Add("BAL_STAT", typeof(String)); //
                paramTableBALJU.Columns.Add("PLT_CODE", typeof(String)); //
                paramTableBALJU.Columns.Add("BALJU_NUM", typeof(String)); //
                paramTableBALJU.Columns.Add("BALJU_SEQ", typeof(Int32)); //
                paramTableBALJU.Columns.Add("INS_DATE", typeof(string)); //
                paramTableBALJU.Columns.Add("INS_EMP", typeof(string)); //
                paramTableBALJU.Columns.Add("OK_QTY", typeof(Int32)); //

                DataTable paramTableNG = new DataTable("NG");
                paramTableNG.Columns.Add("PLT_CODE", typeof(string));
                paramTableNG.Columns.Add("NG_ID", typeof(string));
                paramTableNG.Columns.Add("BALJU_NUM", typeof(string));
                paramTableNG.Columns.Add("BALJU_SEQ", typeof(int));
                paramTableNG.Columns.Add("INS_DATE", typeof(string));
                paramTableNG.Columns.Add("MASTER_CAUSE", typeof(string));
                paramTableNG.Columns.Add("NG_QTY", typeof(int));
                paramTableNG.Columns.Add("NG_CONTENTS", typeof(string));

                //string YPGO_STAT = "43";    //검사 완료
                string BAL_STAT = "43";     
                
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    string PLT_CODE = row["PLT_CODE"].ToString();
                    string BALJU_NUM = row["BALJU_NUM"].ToString();
                    string BALJU_SEQ = row["BALJU_SEQ"].ToString();
                    string YPGO_DATE = row["INS_DATE"].ToString();
                    int QTY = row["QTY"].toInt32();
                    int NG_QTY = row["NG_QTY"].toInt32();
                    string REG_EMP = row["INS_EMP"].ToString();
                    string SCOMMENT = row["SCOMMENT"].ToString();
    
                    //string SR_NO = UTIL.UTILITY_GET_SERIALNO(PLT_CODE, "YP", UTIL.emSerialFormat.YYYYMMDD, "", bizExecute);

                    //paramTableYPGO.Clear();
                    //DataRow paramRowYPGO = paramTableYPGO.NewRow();
                    //paramRowYPGO["PLT_CODE"] = PLT_CODE;
                    //paramRowYPGO["YPGO_ID"] = SR_NO;
                    //paramRowYPGO["BALJU_NUM"] = BALJU_NUM;
                    //paramRowYPGO["BALJU_SEQ"] = BALJU_SEQ;
                    //paramRowYPGO["YPGO_DATE"] = YPGO_DATE;
                    //paramRowYPGO["QTY"] = QTY - NG_QTY;
                    //paramRowYPGO["YPGO_STAT"] = YPGO_STAT;
                    //paramRowYPGO["INS_FLAG"] = "2";
                    //paramRowYPGO["INS_DATE"] = YPGO_DATE;
                    //paramRowYPGO["INS_EMP"] = REG_EMP;
                    //paramRowYPGO["SCOMMENT"] = SCOMMENT;
                    //paramTableYPGO.Rows.Add(paramRowYPGO);
                    ////입고 정보
                    //DOUT.TOUT_PROCYPGO.TOUT_PROCYPGO_INS(paramTableYPGO, bizExecute);

                    paramTableBALJU.Clear();
                    DataRow paramRowBALJU = paramTableBALJU.NewRow();
                    paramRowBALJU["BAL_STAT"] = BAL_STAT;
                    paramRowBALJU["PLT_CODE"] = PLT_CODE;
                    paramRowBALJU["BALJU_NUM"] = BALJU_NUM;
                    paramRowBALJU["BALJU_SEQ"] = BALJU_SEQ;
                    paramRowBALJU["OK_QTY"] = QTY - NG_QTY;
                    paramRowBALJU["INS_DATE"] = YPGO_DATE;
                    paramRowBALJU["INS_EMP"] = REG_EMP;
                    paramTableBALJU.Rows.Add(paramRowBALJU);

                    //발주상태 변경
                    DOUT.TOUT_PROCBALJU.TOUT_PROCBALJU_UPD6(paramTableBALJU, bizExecute);
                    
                    if (row["NG_QTY"].toInt() > 0)
                    {
                        string NG_ID = UTIL.UTILITY_GET_SERIALNO(PLT_CODE, "PNG", UTIL.emSerialFormat.YYYYMMDD, "", bizExecute);

                        paramTableNG.Clear();
                        DataRow paramRowNG = paramTableNG.NewRow();
                        paramRowNG["PLT_CODE"] = PLT_CODE;
                        paramRowNG["NG_ID"] = NG_ID;
                        paramRowNG["BALJU_NUM"] = BALJU_NUM;
                        paramRowNG["BALJU_SEQ"] = BALJU_SEQ;
                        paramRowNG["INS_DATE"] = YPGO_DATE;
                        paramRowNG["MASTER_CAUSE"] = row["MASTER_CAUSE"];
                        paramRowNG["NG_QTY"] = row["NG_QTY"];
                        paramRowNG["NG_CONTENTS"] = SCOMMENT;
                        paramTableNG.Rows.Add(paramRowNG);

                        DQCT.TQCT_PURCHASE_NG.TQCT_PURCHASE_NG_INS(paramTableNG, bizExecute);
                    }


                }
                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PUR06A_UPD(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable paramTableBALJU = new DataTable("BALJU");
                paramTableBALJU.Columns.Add("BAL_STAT", typeof(String)); //
                paramTableBALJU.Columns.Add("PLT_CODE", typeof(String)); //
                paramTableBALJU.Columns.Add("BALJU_NUM", typeof(String)); //
                paramTableBALJU.Columns.Add("BALJU_SEQ", typeof(Int32)); //
                paramTableBALJU.Columns.Add("INS_DATE", typeof(string)); //
                paramTableBALJU.Columns.Add("INS_EMP", typeof(string)); //
                paramTableBALJU.Columns.Add("OK_QTY", typeof(Int32)); //

                DataTable paramTableNG = new DataTable("NG");
                paramTableNG.Columns.Add("PLT_CODE", typeof(string));
                paramTableNG.Columns.Add("NG_ID", typeof(string));
                paramTableNG.Columns.Add("BALJU_NUM", typeof(string));
                paramTableNG.Columns.Add("BALJU_SEQ", typeof(int));
                paramTableNG.Columns.Add("INS_DATE", typeof(string));
                paramTableNG.Columns.Add("MASTER_CAUSE", typeof(string));
                paramTableNG.Columns.Add("NG_QTY", typeof(int));
                paramTableNG.Columns.Add("NG_CONTENTS", typeof(string));


                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {

                    paramTableBALJU.Clear();
                    DataRow rowBalju = paramTableBALJU.NewRow();
                    rowBalju["BAL_STAT"] = "43";
                    rowBalju["PLT_CODE"] = row["PLT_CODE"];
                    rowBalju["BALJU_NUM"] = row["BALJU_NUM"];
                    rowBalju["BALJU_SEQ"] = row["BALJU_SEQ"];
                    rowBalju["INS_DATE"] = DateTime.Today.ToString("yyyyMMdd");
                    rowBalju["INS_EMP"] = row["REG_EMP"];
                    rowBalju["OK_QTY"] = row["QTY"].toInt() - row["NG_QTY"].toInt();
                    paramTableBALJU.Rows.Add(rowBalju);

                    //발주 상태 변경 11
                    DOUT.TOUT_PROCBALJU.TOUT_PROCBALJU_UPD6(paramTableBALJU, bizExecute);

                    if (row["NG_ID"].ToString() != "")
                    {
                        paramTableNG.Clear();
                        DataRow rowNg = paramTableNG.NewRow();
                        rowNg["PLT_CODE"] = row["PLT_CODE"];
                        rowNg["NG_ID"] = row["NG_ID"];
                        rowNg["MASTER_CAUSE"] = row["MASTER_CAUSE"];
                        rowNg["NG_QTY"] = row["NG_QTY"];
                        rowNg["NG_CONTENTS"] = row["SCOMMENT"];
                        paramTableNG.Rows.Add(rowNg);

                        if (row["NG_QTY"].toInt() > 0)
                        {
                            DQCT.TQCT_PURCHASE_NG.TQCT_PURCHASE_NG_UPD(UTIL.GetRowToDt(row), bizExecute);
                        }
                        else
                        {
                            DQCT.TQCT_PURCHASE_NG.TQCT_PURCHASE_NG_UDE(UTIL.GetRowToDt(row), bizExecute);
                        }
                    }
                    
                }

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "BAL_STAT", "43", typeof(string));

                DataTable dtRslt = DQCT.TQCT_PURCHASE_NG_QUERY.TQCT_PURCHASE_NG_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";
                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PUR07A_UPD2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DMAT.TMAT_YPGO.TMAT_YPGO_UPD7(UTIL.GetRowToDt(row), bizExecute);
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PUR07A_UPD3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DOUT.TOUT_PROCYPGO.TOUT_PROCYPGO_UPD6(UTIL.GetRowToDt(row), bizExecute);
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PUR07A_UPD4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DMAT.TMAT_YPGO.TMAT_YPGO_UPD8(UTIL.GetRowToDt(row), bizExecute);
                }

                return PUR07A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PUR07A_UPD5(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DOUT.TOUT_PROCYPGO.TOUT_PROCYPGO_UPD7(UTIL.GetRowToDt(row), bizExecute);
                }

                return PUR07A_SER2(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }




        public static DataSet PUR07A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable paramTableBALJU = new DataTable("BALJU");
                paramTableBALJU.Columns.Add("BAL_STAT", typeof(String)); //
                paramTableBALJU.Columns.Add("YPGO_STAT", typeof(String)); //
                paramTableBALJU.Columns.Add("PLT_CODE", typeof(String)); //
                paramTableBALJU.Columns.Add("BALJU_NUM", typeof(String)); //
                paramTableBALJU.Columns.Add("BALJU_SEQ", typeof(Int32)); //
                paramTableBALJU.Columns.Add("YPGO_ID", typeof(string)); //
                //재고 관련
                paramTableBALJU.Columns.Add("PART_CODE", typeof(string)); //
                paramTableBALJU.Columns.Add("DETAIL_PART_NAME", typeof(string)); //
                paramTableBALJU.Columns.Add("TYPE", typeof(string)); //

                //취소할 입고ID, 입고상태'23'(입고취소)이 아닌 입고 데이터 조회
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "NOT_YPGO_ID", "YPGO_ID");
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "NOT_YPGO_STAT", "23", typeof(string));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    paramTableBALJU.Clear();
                    DataRow rowBalju = paramTableBALJU.NewRow();

                    //입고정보조회
                    DataTable ypgoRslt = DMAT.TMAT_YPGO_QUERY.TMAT_YPGO_QUERY6(UTIL.GetRowToDt(row), bizExecute);
                    DataTable baljuRslt = DMAT.TMAT_BALJU.TMAT_BALJU_SER(UTIL.GetRowToDt(row), bizExecute);

                    //발주상태
                    string balStat = "11";

                    if (ypgoRslt.Rows.Count > 0)
                    {
                        //입고정보가 존재하면 부분입고
                        balStat = "21";
                    }
                    else
                    {
                        //입고정보가 없는데 수입검사를진행하는 발주면 '검사완료'상태로 변경
                        if (baljuRslt.Rows.Count > 0)
                        {
                            if (baljuRslt.Rows[0]["INS_FLAG"].ToString() == "2")
                            {
                                balStat = "43";
                            }
                        }
                    }

                    rowBalju["BAL_STAT"] = balStat;    //발주상태 변경
                    rowBalju["YPGO_STAT"] = "23";    //입고 취소
                    rowBalju["PLT_CODE"] = row["PLT_CODE"];
                    rowBalju["BALJU_NUM"] = row["BALJU_NUM"];
                    rowBalju["BALJU_SEQ"] = row["BALJU_SEQ"];
                    rowBalju["YPGO_ID"] = row["YPGO_ID"];
                    rowBalju["TYPE"] = "IN_CANCEL";
                    
                    paramTableBALJU.Rows.Add(rowBalju);

                    DMAT.TMAT_BALJU.TMAT_BALJU_UPD2(paramTableBALJU, bizExecute);

                    DMAT.TMAT_YPGO.TMAT_YPGO_UPD2(paramTableBALJU, bizExecute);

                    //재고 입고 취소 처리
                    if (row["PART_CODE"].ToString() != "")
                    {
                        CTRL.CTRL.SET_STOCK_PROCESS(rowBalju, bizExecute, "PART_CODE", "YPGO_LOC", "QTY", "AMT", "YPGO_ID", null);
                    }                    
                    

                }
                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PUR07A_DEL2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable paramTableBALJU = new DataTable("BALJU");
                paramTableBALJU.Columns.Add("BAL_STAT", typeof(String)); //
                paramTableBALJU.Columns.Add("YPGO_STAT", typeof(String)); //
                paramTableBALJU.Columns.Add("PLT_CODE", typeof(String)); //
                paramTableBALJU.Columns.Add("BALJU_NUM", typeof(String)); //
                paramTableBALJU.Columns.Add("BALJU_SEQ", typeof(Int32)); //
                paramTableBALJU.Columns.Add("YPGO_ID", typeof(string)); //


                DataTable paramTableWO = new DataTable("RQSTDT");
                paramTableWO.Columns.Add("PLT_CODE", typeof(String));
                paramTableWO.Columns.Add("WO_NO", typeof(String));
                paramTableWO.Columns.Add("WO_FLAG", typeof(Int32));
                paramTableWO.Columns.Add("ACT_END_TIME", typeof(DateTime));
                paramTableWO.Columns.Add("ACT_QTY", typeof(Int32));

                //취소할 입고ID, 입고상태'23'(입고취소)이 아닌 입고 데이터 조회
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "NOT_YPGO_ID", "YPGO_ID");
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "NOT_YPGO_STAT", "23", typeof(string));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable ypgoRslt = DOUT.TOUT_PROCYPGO_QUERY.TOUT_PROCYPGO_QUERY5(UTIL.GetRowToDt(row), bizExecute);
                    DataTable baljuRslt = DOUT.TOUT_PROCBALJU.TOUT_PROCBALJU_SER(UTIL.GetRowToDt(row), bizExecute);

                    //발주상태
                    string balStat = "11";

                    if (ypgoRslt.Rows.Count > 0)
                    {
                        //입고정보가 존재하면 부분입고
                        balStat = "21";
                    }
                    else
                    {
                        //입고정보가 없는데 수입검사를진행하는 발주면 '검사완료'상태로 변경
                        if (baljuRslt.Rows.Count > 0)
                        {
                            if (baljuRslt.Rows[0]["INS_FLAG"].ToString() == "2")
                            {
                                balStat = "43";
                            }
                        }
                    }

                    paramTableBALJU.Clear();
                    DataRow rowBalju = paramTableBALJU.NewRow();
                    rowBalju["BAL_STAT"] = balStat;    //발주상태 변경
                    rowBalju["YPGO_STAT"] = "23";    //입고 취소
                    rowBalju["PLT_CODE"] = row["PLT_CODE"];
                    rowBalju["BALJU_NUM"] = row["BALJU_NUM"];
                    rowBalju["BALJU_SEQ"] = row["BALJU_SEQ"];
                    rowBalju["YPGO_ID"] = row["YPGO_ID"]; 

                    paramTableBALJU.Rows.Add(rowBalju);

                    DOUT.TOUT_PROCBALJU.TOUT_PROCBALJU_UPD2(paramTableBALJU, bizExecute);
                    DOUT.TOUT_PROCYPGO.TOUT_PROCYPGO_UPD5(paramTableBALJU, bizExecute);

                    DataRow paramRowWo = paramTableWO.NewRow();
                    paramRowWo["PLT_CODE"] = row["PLT_CODE"]; 
                    paramRowWo["WO_NO"] = row["WO_NO"];
                    paramRowWo["WO_FLAG"] = "2";
                    
                    paramRowWo["ACT_QTY"] = row["ACT_QTY"];
                    paramTableWO.Rows.Add(paramRowWo);

                    DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD5_1(paramTableWO, bizExecute);

                    
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

