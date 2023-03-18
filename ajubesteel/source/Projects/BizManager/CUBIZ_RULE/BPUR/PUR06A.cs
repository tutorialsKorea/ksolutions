using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BPUR
{
    public class PUR06A
    {

        public static DataSet PUR06A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "BAL_STAT", "20", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "INS_FLAG", "2", typeof(string));

                DataTable dtRslt = DOUT.TOUT_PROCBALJU_QUERY.TOUT_PROCBALJU_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);
                
                //dtRslt.Columns.Add("NG_QTY", typeof(int));
                dtRslt.Columns.Add("IN_SCOMMENT", typeof(string));
                dtRslt.Columns.Add("MASTER_CAUSE", typeof(string));
                dtRslt.TableName = "RSLTDT";


                DataTable dtRsltMat = DMAT.TMAT_BALJU_QUERY.TMAT_BALJU_QUERY5(paramDS.Tables["RQSTDT"], bizExecute);
                dtRsltMat.Columns.Add("IN_SCOMMENT", typeof(string));
                dtRsltMat.Columns.Add("MASTER_CAUSE", typeof(string));
                dtRsltMat.TableName = "RSLTDT";

                paramDS.Merge(dtRslt);
                paramDS.Merge(dtRsltMat);

                //paramDS.Tables.Add(dtRslt);


                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        //수입검사 내역 조회 
        public static DataSet PUR06A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "BAL_STAT", "43", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PUR06A", "1", typeof(string));
                DataTable dtRslt = DQCT.TQCT_PURCHASE_NG_QUERY.TQCT_PURCHASE_NG_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                
                dtRslt.TableName = "RSLTDT";

                DataTable dtRsltMat = DQCT.TQCT_PURCHASE_NG_QUERY.TQCT_PURCHASE_NG_QUERY5(paramDS.Tables["RQSTDT"], bizExecute);

                dtRsltMat.TableName = "RSLTDT";

                //paramDS.Tables.Add(dtRslt);

                paramDS.Merge(dtRslt);
                paramDS.Merge(dtRsltMat);

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
                paramTableNG.Columns.Add("NG_STATE", typeof(string));

                string BAL_STAT = "43";         //검사 완료

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

                    //발주상태 변경(외주)
                    if (BALJU_NUM.StartsWith("OB"))
                        DOUT.TOUT_PROCBALJU.TOUT_PROCBALJU_UPD6(paramTableBALJU, bizExecute);
                    else
                        DMAT.TMAT_BALJU.TMAT_BALJU_UPD6(paramTableBALJU, bizExecute);


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
                        paramRowNG["NG_STATE"] = "W";
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
                    string BALJU_NUM = row["BALJU_NUM"].ToString();

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

                    if (BALJU_NUM.StartsWith("OB"))
                    {
                        DOUT.TOUT_PROCBALJU.TOUT_PROCBALJU_UPD6(paramTableBALJU, bizExecute);
                    }
                    else
                    {
                        DMAT.TMAT_BALJU.TMAT_BALJU_UPD6(paramTableBALJU, bizExecute);
                    }

                    //if (row["NG_QTY"].toInt() > 0)
                    //{
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
                            DQCT.TQCT_PURCHASE_NG.TQCT_PURCHASE_NG_UPD(paramTableNG, bizExecute);
                        }
                        else
                        {
                            DQCT.TQCT_PURCHASE_NG.TQCT_PURCHASE_NG_UDE(paramTableNG, bizExecute);
                        }
                    }
                    else
                    {
                        if (row["NG_QTY"].toInt() > 0)
                        {
                            string NG_ID = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "PNG", UTIL.emSerialFormat.YYYYMMDD, "", bizExecute);

                            paramTableNG.Clear();
                            DataRow paramRowNG = paramTableNG.NewRow();
                            paramRowNG["PLT_CODE"] = row["PLT_CODE"].ToString();
                            paramRowNG["NG_ID"] = NG_ID;
                            paramRowNG["BALJU_NUM"] = row["BALJU_NUM"];
                            paramRowNG["BALJU_SEQ"] = row["BALJU_SEQ"];
                            paramRowNG["INS_DATE"] = DateTime.Today.toDateString("yyyyMMdd");
                            paramRowNG["MASTER_CAUSE"] = row["MASTER_CAUSE"];
                            paramRowNG["NG_QTY"] = row["NG_QTY"];
                            paramRowNG["NG_CONTENTS"] = row["SCOMMENT"];
                            paramTableNG.Rows.Add(paramRowNG);

                            DQCT.TQCT_PURCHASE_NG.TQCT_PURCHASE_NG_INS(paramTableNG, bizExecute);
                        }
                    }
                    //}
                    
                }

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_SEARCH"], "BAL_STAT", "43", typeof(string));

                DataTable dtRslt = DQCT.TQCT_PURCHASE_NG_QUERY.TQCT_PURCHASE_NG_QUERY1(paramDS.Tables["RQSTDT_SEARCH"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                DataTable dtRsltMat = DQCT.TQCT_PURCHASE_NG_QUERY.TQCT_PURCHASE_NG_QUERY5(paramDS.Tables["RQSTDT_SEARCH"], bizExecute);

                dtRsltMat.TableName = "RSLTDT";


                paramDS.Merge(dtRslt);
                paramDS.Merge(dtRsltMat);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PUR06A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
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
                paramTableBALJU.Columns.Add("NG_ID", typeof(string)); //

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    string BALJU_NUM = row["BALJU_NUM"].ToString();

                    DataTable baljuRslt = new DataTable();


                    //검사취소는 발주상태를 검사여부를 판안안하고 '검사대기(20)'로 해도 되는지 확인필요
                    if (BALJU_NUM.StartsWith("OB"))
                    {
                        baljuRslt = DOUT.TOUT_PROCBALJU.TOUT_PROCBALJU_SER(UTIL.GetRowToDt(row), bizExecute);
                    }
                    else
                    {
                        baljuRslt = DMAT.TMAT_BALJU.TMAT_BALJU_SER(UTIL.GetRowToDt(row), bizExecute);
                    }

                    string balStat = "11";

                    if (baljuRslt.Rows.Count > 0)
                    {
                        //수입검사해야할 발주면 검사대기
                        if (baljuRslt.Rows[0]["INS_FLAG"].ToString() == "2")
                        {
                            balStat = "20";
                        }

                        paramTableBALJU.Clear();
                        DataRow rowBalju = paramTableBALJU.NewRow();
                        rowBalju["BAL_STAT"] = balStat;
                        rowBalju["PLT_CODE"] = row["PLT_CODE"];
                        rowBalju["BALJU_NUM"] = row["BALJU_NUM"];
                        rowBalju["BALJU_SEQ"] = row["BALJU_SEQ"];
                        rowBalju["OK_QTY"] = 0;
                        rowBalju["NG_ID"] = row["NG_ID"];
                        paramTableBALJU.Rows.Add(rowBalju);

                        if (BALJU_NUM.StartsWith("OB"))
                        {
                            DOUT.TOUT_PROCBALJU.TOUT_PROCBALJU_UPD6(paramTableBALJU, bizExecute);
                        }
                        else
                        {
                            DMAT.TMAT_BALJU.TMAT_BALJU_UPD6(paramTableBALJU, bizExecute);
                        }

                        //검사 불량 내역 삭제
                        DQCT.TQCT_PURCHASE_NG.TQCT_PURCHASE_NG_UDE(UTIL.GetRowToDt(row), bizExecute);
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

