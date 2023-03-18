using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BizExecute;


namespace BSTD
{
    public class STD23B
    {

        public static DataSet STD23B_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte)); // VAR에 DATA_FLAG값 0 설정

                DataTable dtRslt = DLSE.LSE_HOLIDAY_QUERY.LSE_HOLIDAY_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable dtRsltCapa = DSTD.TSTD_MC_DAILYCAPA_QUERY.TSTD_MC_DAILYCAPA_QUERY5(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.Columns.Add("SEL");
                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                dtRsltCapa.TableName = "RSLTDT_MC";

                //paramDS.Tables.Add(dtRslt);
                paramDS.Tables.Add(dtRsltCapa);

                DataTable dtRsltMng = DSTD.TSTD_WORKDAY.TSTD_WORKDAY_SER2(paramDS.Tables["RQSTDT"], bizExecute);

                dtRsltMng.Columns.Add("SEL");
                dtRsltMng.TableName = "RSLTDT_MNG";

                paramDS.Tables.Add(dtRsltMng);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }



        public static DataSet STD23B_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte)); // VAR에 DATA_FLAG값 0 설정

                DataTable dtRsltCapa = DSTD.TSTD_MC_DAILYCAPA_QUERY.TSTD_MC_DAILYCAPA_QUERY5(paramDS.Tables["RQSTDT"], bizExecute);

                dtRsltCapa.TableName = "RSLTDT";

                //paramDS.Tables.Add(dtRslt);
                paramDS.Tables.Add(dtRsltCapa);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }


       

        public static DataSet STD23A_SER5(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte)); // VAR에 DATA_FLAG값 0 설정
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "MC_MGT_FLAG", 1, typeof(Byte));

                DataTable dtRslt = DLSE.LSE_MACHINE_QUERY.LSE_MACHINE_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

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


        public static DataSet STD23B_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {


                if (paramDS.Tables["RQSTDT"].Rows.Count == 1)
                {

                    DataTable CALENDAR = new DataTable("RQSTDT");
                    CALENDAR.Columns.Add("DATE", typeof(String));
                    CALENDAR.Columns.Add("WEEK", typeof(String));

                    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "FR_DATE_STR", ((DateTime)paramDS.Tables["RQSTDT"].Rows[0]["FR_DATE"]).ToString("yyyyMMdd"), typeof(String));
                    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "TO_DATE_STR", ((DateTime)paramDS.Tables["RQSTDT"].Rows[0]["TO_DATE"]).ToString("yyyyMMdd"), typeof(String));
                    //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "OVERWRITE", paramDS.Tables["RQSTDT"].Rows[0], typeof(String));
                    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "HOLIDAY_CAPA", 0, typeof(Decimal));


                    DateTime fromDate = (DateTime)paramDS.Tables["RQSTDT"].Rows[0]["FR_DATE"];
                    DateTime toDate = (DateTime)paramDS.Tables["RQSTDT"].Rows[0]["TO_DATE"];

                    while (!fromDate.Equals(toDate.AddDays(1)))
                    {

                        CALENDAR.Rows.Add(fromDate.ToString("yyyyMMdd"), fromDate.DayOfWeek.ToString());

                        fromDate = fromDate.AddDays(1);

                    }

                    foreach (DataRow row in CALENDAR.Rows)
                    {
                        DataTable dt1 = new DataTable("RQSTDT");

                        //UTIL.SetBizAddColumnToValue(dt1, "PLT_CODE", paramDS.Tables["RQSTDT"], typeof(String));
                        //UTIL.SetBizAddColumnToValue(dt1, "HOLI_DATE", CALENDAR.Rows[0]["DATE"], typeof(String));
                        dt1.Columns.Add("PLT_CODE", typeof(String)); //
                        dt1.Columns.Add("HOLI_DATE", typeof(String)); //
                        DataRow paramRow0 = dt1.NewRow();
                        paramRow0["PLT_CODE"] = paramDS.Tables["RQSTDT"].Rows[0]["PLT_CODE"].ToString();
                        paramRow0["HOLI_DATE"] = row["DATE"].ToString();
                        dt1.Rows.Add(paramRow0);

                        //설비별 처리
                        foreach (DataRow row2 in paramDS.Tables["RQSTDT2"].Rows)
                        {

                            DataTable dt2 = new DataTable("RQSTDT");
                            dt2.Columns.Add("PLT_CODE", typeof(String)); //
                            dt2.Columns.Add("MC_CODE", typeof(String)); //
                            dt2.Columns.Add("WORK_DATE", typeof(String)); //
                            dt2.Columns.Add("MC_DATE", typeof(String)); //
                            dt2.Columns.Add("CAPA", typeof(Decimal));

                            DataRow paramRow = dt2.NewRow();
                            paramRow["PLT_CODE"] = paramDS.Tables["RQSTDT"].Rows[0]["PLT_CODE"].ToString();
                            paramRow["MC_CODE"] = row2["MC_CODE"].ToString();
                            paramRow["WORK_DATE"] = row["DATE"].ToString();
                            paramRow["MC_DATE"] = row["DATE"].ToString();
                            paramRow["CAPA"] = paramDS.Tables["RQSTDT"].Rows[0]["CAPA"];

                            dt2.Rows.Add(paramRow);
                            DataSet paramSet = new DataSet();
                            paramSet.Tables.Add(dt2);

                            DataTable dtSer = DSTD.TSTD_MC_DAILYCAPA.TSTD_MC_DAILYCAPA_SER(dt2, bizExecute);

                            if (dtSer.Rows.Count > 0)
                                DSTD.TSTD_MC_DAILYCAPA.TSTD_MC_DAILYCAPA_UPD(dt2, bizExecute);
                            else
                                DSTD.TSTD_MC_DAILYCAPA.TSTD_MC_DAILYCAPA_INS(dt2, bizExecute);

                            
                        }

                    }

                    DLSE.LSE_HOLIDAY.LSE_HOLIDAY_UPD(paramDS.Tables["RQSTDT"], bizExecute);


                }

                else
                {
                    throw new Exception("입력 파라메터가 잘못되었습니다.");
                }
                return paramDS;
                //return STD23A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static DataSet STD23A_INS2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                if (paramDS.Tables["RQSTDT"].Rows.Count != 0)
                {

                    DataTable paramDT = new DataTable("RQSTDT");
                    paramDT.Columns.Add("PLT_CODE", typeof(String)); //
                    paramDT.Columns.Add("USRGRP_CODE", typeof(String)); //

                    DataRow paramRow = paramDT.NewRow();
                    paramRow["PLT_CODE"] = paramDS.Tables["RQSTDT"].Rows[0]["PLT_CODE"];
                    paramRow["USRGRP_CODE"] = paramDS.Tables["RQSTDT"].Rows[0]["USRGRP_CODE"];
                    paramDT.Rows.Add(paramRow);

                    //SQL.SQL_SETDATA("TSYS_ACCESS_DEL2", paramDT, bizExecute);
                    DSYS.TSYS_ACCESS.TSYS_ACCESS_DEL2(paramDS.Tables["RQSTDT"], bizExecute);

                }

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    //SQL.SQL_SETDATA("TSYS_ACCESS_INS", paramDS.Tables["RQSTDT"],  bizExecute);
                    DSYS.TSYS_ACCESS.TSYS_ACCESS_INS(UTIL.GetRowToDt(row), bizExecute);
                }



                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet STD23B_INS3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", "0", typeof(Byte));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtRslt = DSTD.TSTD_WORKDAY.TSTD_WORKDAY_SER(UTIL.GetRowToDt(row), bizExecute);

                    //데이터가 있으면 삭제여부 및 덮어쓰기 여부에 따라 update
                    if (dtRslt.Rows.Count > 0)
                    {
                        if (row["OVERWRITE"].Equals("1"))
                        {
                            DSTD.TSTD_WORKDAY.TSTD_WORKDAY_UPD(UTIL.GetRowToDt(row), bizExecute);
                        }
                        else
                        {
                            if (dtRslt.Rows[0]["DATA_FLAG"].Equals((byte)2))
                            {

                                throw UTIL.SetException("동일 데이터가 이력이 존재할때 발생"
                                    , row["WORK_MONTH"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.OVERWRITE_HISTORY, dtRslt.Rows[0]);

                            }
                            else
                            {
                                throw UTIL.SetException("동일 데이터가 존재할때 발생"
                                    , row["WORK_MONTH"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.OVERWRITE);
                            }
                        }
                    }
                    else
                    {
                        DSTD.TSTD_WORKDAY.TSTD_WORKDAY_INS(UTIL.GetRowToDt(row), bizExecute);
                    }
                }


                DataTable dtRsltMng = DSTD.TSTD_WORKDAY.TSTD_WORKDAY_SER(paramDS.Tables["RQSTDT"], bizExecute);

                dtRsltMng.Columns.Add("SEL");
                dtRsltMng.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRsltMng);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static DataSet STD23B_UPD2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "HOLI_DATE", "WORK_DATE");

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {

                    DataTable dtRslt = DLSE.LSE_HOLIDAY.LSE_HOLIDAY_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (dtRslt.Rows.Count == 0)
                    {
                        DLSE.LSE_HOLIDAY.LSE_HOLIDAY_INS(UTIL.GetRowToDt(row), bizExecute);
                    }
                }

                DataTable dtCAPA = DSTD.TSTD_MC_DAILYCAPA_QUERY.TSTD_MC_DAILYCAPA_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                UTIL.SetBizAddColumnToValue(dtCAPA, "CAPA", 0, typeof(Decimal));

                if (dtCAPA.Rows.Count != 0)
                {
                    DSTD.TSTD_MC_DAILYCAPA.TSTD_MC_DAILYCAPA_UPD(dtCAPA, bizExecute);
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet STD23B_UPD3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DLSE.LSE_HOLIDAY.LSE_HOLIDAY_DEL3(paramDS.Tables["RQSTDT"], bizExecute);

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WORK_DATE", paramDS.Tables["RQSTDT"].Rows[0]["HOLI_DATE"].ToString(), typeof(String));
                DataTable dtRslt = DSTD.TSTD_MC_DAILYCAPA_QUERY.TSTD_MC_DAILYCAPA_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                foreach (DataRow row in dtRslt.Rows)
                {

                    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PLT_CODE", dtRslt.Rows[0]["PLT_CODE"], typeof(String)); //
                    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "MC_CODE", dtRslt.Rows[0]["MC_CODE"], typeof(String)); //
                    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WORK_DATE", dtRslt.Rows[0]["WORK_DATE"], typeof(String)); //
                    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "CAPA", dtRslt.Rows[0]["CAPA"], typeof(Decimal)); //

                    string week = CTRL.CTRL.GetDateStringWeek(row["WORK_DATE"].ToString(), bizExecute);

                    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WEEK", week, typeof(String)); //

                    DataSet dtSER = STD23A.STD23A_SER4(paramDS, bizExecute);

                    paramDS.Tables["RQSTDT"].Rows[0]["CAPA"] = dtSER.Tables["RSLTDT"].Rows[0]["CAPA"];

                    DSTD.TSTD_MC_DAILYCAPA.TSTD_MC_DAILYCAPA_UPD(paramDS.Tables["RQSTDT"], bizExecute);

                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        //특정일 개별 설비 CAPA 변경
        public static DataSet STD23B_UPD4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {

                DSTD.TSTD_MC_DAILYCAPA.TSTD_MC_DAILYCAPA_UPD(paramDS.Tables["RQSTDT"], bizExecute);

                
                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet STD23B_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", "2", typeof(Byte));

                DSTD.TSTD_WORKDAY.TSTD_WORKDAY_UDE(paramDS.Tables["RQSTDT"], bizExecute);


                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


    }
}
