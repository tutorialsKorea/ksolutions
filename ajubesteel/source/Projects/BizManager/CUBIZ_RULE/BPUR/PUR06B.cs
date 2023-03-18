using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BPUR
{
    public class PUR06B
    {

        public static DataSet PUR06B_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "BAL_STAT", "11", typeof(string));

                DataTable dtRslt = DOUT.TOUT_PROCBALJU_QUERY.TOUT_PROCBALJU_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);
                
                //dtRslt.Columns.Add("NG_QTY", typeof(int));
                dtRslt.Columns.Add("IN_SCOMMENT", typeof(string));
                dtRslt.Columns.Add("MASTER_CAUSE", typeof(string));
                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        //수입검사 내역 조회 
        public static DataSet PUR06B_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
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

        //자재 입고취소가능건 조회
        public static DataSet PUR06B_SER_M(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DMAT.TMAT_YPGO_QUERY.TMAT_YPGO_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

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

        //공정외주 입고취소가능건 조회
        public static DataSet PUR06B_SER_PO(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DOUT.TOUT_PROCYPGO_QUERY.TOUT_PROCYPGO_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

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
        
        //수입검사(공정외주)
        //발주->수입검사->입고 
        //TOUT_PROCBALJU에 검사 정보 업데이트
        public static DataSet PUR06B_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
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

        public static DataSet PUR06B_INS_PO2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach(DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DOUT.TOUT_PROCYPGO.TOUT_PROCYPGO_UPD(UTIL.GetRowToDt(row), bizExecute);
                }
                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PUR06B_INS_M2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DMAT.TMAT_YPGO.TMAT_YPGO_UPD6(UTIL.GetRowToDt(row), bizExecute);
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
