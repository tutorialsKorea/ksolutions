using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BPUR
{
    public class PUR08A
    {

        //자재 입고 현황
        public static DataSet PUR08A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
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
        public static DataSet PUR08A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
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


        public static DataSet PUR08A_UPD(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DMAT.TMAT_YPGO.TMAT_YPGO_UPD(UTIL.GetRowToDt(row), bizExecute);
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PUR08A_UPD_PO(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {


                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
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


        public static DataSet PUR08A_UPD2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DMAT.TMAT_YPGO.TMAT_YPGO_UPD6(UTIL.GetRowToDt(row), bizExecute);
                }

                return PUR08A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PUR08A_UPD_PO2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {


                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DOUT.TOUT_PROCYPGO.TOUT_PROCYPGO_UPD2(UTIL.GetRowToDt(row), bizExecute);

                }

                return PUR08A_SER2(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PUR08A_UPD3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DMAT.TMAT_YPGO.TMAT_YPGO_UPD7(UTIL.GetRowToDt(row), bizExecute);
                }

                return PUR08A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PUR08A_UPD_PO3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {


                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DOUT.TOUT_PROCYPGO.TOUT_PROCYPGO_UPD6(UTIL.GetRowToDt(row), bizExecute);

                }

                return PUR08A_SER2(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        //자재 입고 정보 추가 등록(매입 마감) 
        public static DataSet PUR08A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "BAL_STAT", "22", typeof(string));

                string ypgo_stat = "19";

                DataTable paramTableYPGO = new DataTable("RSLTDT");
                paramTableYPGO.Columns.Add("PLT_CODE", typeof(String)); //
                paramTableYPGO.Columns.Add("YPGO_ID", typeof(String)); //
                paramTableYPGO.Columns.Add("BALJU_NUM", typeof(String)); //
                paramTableYPGO.Columns.Add("BALJU_SEQ", typeof(Int32)); //
                paramTableYPGO.Columns.Add("YPGO_DATE", typeof(String)); //
                paramTableYPGO.Columns.Add("CLOSE_DATE", typeof(String)); //
                paramTableYPGO.Columns.Add("QTY", typeof(Int32)); //
                paramTableYPGO.Columns.Add("UNIT_COST", typeof(Decimal)); //
                
                paramTableYPGO.Columns.Add("AMT", typeof(Decimal)); //
                paramTableYPGO.Columns.Add("YPGO_STAT", typeof(String)); //
                paramTableYPGO.Columns.Add("SCOMMENT", typeof(String)); //

                paramTableYPGO.Columns.Add("YPGO_QTY", typeof(Int32)); //
                paramTableYPGO.Columns.Add("YPGO_COST", typeof(Decimal)); //

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                
                    //BALJU_SEQ 구하기
                    DataTable dtBalju = DMAT.TMAT_BALJU_QUERY.TMAT_BALJU_QUERY4(UTIL.GetRowToDt(row), bizExecute); 
                    
                    //데이터 여부
                    if (dtBalju.Rows.Count > 0)
                    {
                        //발주 정보 생성
                        row["BALJU_SEQ"] = dtBalju.Rows[0]["SEQ"];

                        DMAT.TMAT_BALJU.TMAT_BALJU_INS(UTIL.GetRowToDt(row), bizExecute);

                        //입고 정보 생성
                        string SR_NO = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(),
                            "MY", UTIL.emSerialFormat.YYYYMMDD, "", bizExecute);

                        
                        DataRow paramRowYPGO = paramTableYPGO.NewRow();
                        paramRowYPGO["PLT_CODE"] = row["PLT_CODE"];
                        paramRowYPGO["YPGO_ID"] = SR_NO;
                        paramRowYPGO["BALJU_NUM"] = row["BALJU_NUM"];
                        paramRowYPGO["BALJU_SEQ"] = dtBalju.Rows[0]["SEQ"];
                        paramRowYPGO["CLOSE_DATE"] = row["YPGO_DATE"];
                        paramRowYPGO["YPGO_DATE"] = row["YPGO_DATE"];
                        paramRowYPGO["QTY"] = row["QTY"];
                        paramRowYPGO["UNIT_COST"] = row["UNIT_COST"];
                        paramRowYPGO["AMT"] = row["AMT"];
                        paramRowYPGO["YPGO_STAT"] = ypgo_stat;
                        paramRowYPGO["SCOMMENT"] = row["SCOMMENT"];

                        paramRowYPGO["YPGO_QTY"] = row["QTY"];
                        paramRowYPGO["YPGO_COST"] = row["UNIT_COST"];

                        paramTableYPGO.Rows.Add(paramRowYPGO);
                        //입고 정보
                        DMAT.TMAT_YPGO.TMAT_YPGO_INS(paramTableYPGO, bizExecute);

                    }
                }

                paramDS.Tables.Add(paramTableYPGO);
                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        //외주 입고 정보 추가 등록(매입 마감)
        public static DataSet PUR08A_INS_PO(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "BAL_STAT", "22", typeof(string));

                string ypgo_stat = "19";

                DataTable paramTableYPGO = new DataTable("RSLTDT");
                paramTableYPGO.Columns.Add("PLT_CODE", typeof(String)); //
                paramTableYPGO.Columns.Add("YPGO_ID", typeof(String)); //
                paramTableYPGO.Columns.Add("BALJU_NUM", typeof(String)); //
                paramTableYPGO.Columns.Add("BALJU_SEQ", typeof(Int32)); //
                paramTableYPGO.Columns.Add("YPGO_DATE", typeof(String)); //
                paramTableYPGO.Columns.Add("CLOSE_DATE", typeof(String)); //
                paramTableYPGO.Columns.Add("QTY", typeof(Int32)); //
                paramTableYPGO.Columns.Add("UNIT_COST", typeof(Decimal)); //
                paramTableYPGO.Columns.Add("AMT", typeof(Decimal)); //
                paramTableYPGO.Columns.Add("YPGO_STAT", typeof(String)); //
                paramTableYPGO.Columns.Add("SCOMMENT", typeof(String)); //

                paramTableYPGO.Columns.Add("YPGO_QTY", typeof(Int32)); //
                paramTableYPGO.Columns.Add("YPGO_COST", typeof(Decimal)); //

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {

                    //BALJU_SEQ 구하기
                    DataTable dtBalju = DOUT.TOUT_PROCBALJU_QUERY.TOUT_PROCBALJU_QUERY4(UTIL.GetRowToDt(row), bizExecute);

                    //데이터 여부
                    if (dtBalju.Rows.Count > 0)
                    {
                        //발주 정보 생성
                        row["BALJU_SEQ"] = dtBalju.Rows[0]["SEQ"];
                        DOUT.TOUT_PROCBALJU.TOUT_PROCBALJU_INS(UTIL.GetRowToDt(row), bizExecute);
                        
                        //입고 정보 생성
                        string SR_NO = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "PY", UTIL.emSerialFormat.YYYYMMDD, "", bizExecute);

                        
                        DataRow paramRowYPGO = paramTableYPGO.NewRow();
                        paramRowYPGO["PLT_CODE"] = row["PLT_CODE"];
                        paramRowYPGO["YPGO_ID"] = SR_NO;
                        paramRowYPGO["BALJU_NUM"] = row["BALJU_NUM"];
                        paramRowYPGO["BALJU_SEQ"] = dtBalju.Rows[0]["SEQ"];
                        paramRowYPGO["YPGO_DATE"] = row["YPGO_DATE"];
                        paramRowYPGO["CLOSE_DATE"] = row["YPGO_DATE"];
                        paramRowYPGO["QTY"] = row["QTY"];
                        paramRowYPGO["UNIT_COST"] = row["UNIT_COST"];
                        paramRowYPGO["AMT"] = row["AMT"];
                        paramRowYPGO["YPGO_STAT"] = ypgo_stat;
                        paramRowYPGO["SCOMMENT"] = row["SCOMMENT"];

                        paramRowYPGO["YPGO_QTY"] = row["QTY"];
                        paramRowYPGO["YPGO_COST"] = row["UNIT_COST"];

                        paramTableYPGO.Rows.Add(paramRowYPGO);
                        
                        //입고 정보
                        DOUT.TOUT_PROCYPGO.TOUT_PROCYPGO_INS(paramTableYPGO, bizExecute);
                    }
                }

                paramDS.Tables.Add(paramTableYPGO);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

    }
}

