using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BizExecute;


namespace BSTD
{
    public class STD23A
    {
        /// <summary>
        /// 사용자 그룹 조회
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet STD23A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte)); // VAR에 DATA_FLAG값 0 설정

                DataTable dtRslt = DSTD.TSTD_MC_DAILYCAPA_QUERY.TSTD_MC_DAILYCAPA_QUERY5(paramDS.Tables["RQSTDT"], bizExecute);

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

        public static DataSet STD23A_SER1(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte)); // VAR에 DATA_FLAG값 0 설정

                DataTable dtRslt = DLSE.LSE_HOLIDAY_QUERY.LSE_HOLIDAY_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

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


        public static DataSet STD23A_SER4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataTable paramTable = new DataTable("RSLTDT");
                paramTable.Columns.Add("CAPA", typeof(String)); //
                DataRow paramRow = paramTable.NewRow();

                DataTable dtRslt = DLSE.LSE_MACHINE.LSE_MACHINE_SER(paramDS.Tables["RQSTDT"], bizExecute);

                if (dtRslt.Rows.Count != 0)
                {
                    foreach (DataRow row in dtRslt.Rows)
                    {
                        if ((byte)dtRslt.Rows[0]["MC_SHIFT"] > 0)
                        {
                            row["MC_SHIFT"] = dtRslt.Rows[0]["MC_SHIFT"];
                            row["MC_CODE"] = dtRslt.Rows[0]["MC_CODE"];
                            row["PLT_CODE"] = dtRslt.Rows[0]["PLT_CODE"];

                            DataTable dtMWS = DLSE.LSE_MC_WORKTIME.LSE_MC_WORKTIME_SER(dtRslt, bizExecute);

                            if (dtMWS.Rows.Count != 0)
                            {
                                if (paramDS.Tables["RQSTDT"].Rows[0]["WEEK"].ToString() == "Sunday")
                                {
                                    paramRow["CAPA"] = dtMWS.Rows[0]["SUN_TIME"];
                                }

                                else if (paramDS.Tables["RQSTDT"].Rows[0]["WEEK"].ToString() == "Monday")
                                {
                                    paramRow["CAPA"] = dtMWS.Rows[0]["MON_TIME"];
                                }
                                else if (paramDS.Tables["RQSTDT"].Rows[0]["WEEK"].ToString() == "Tuesday")
                                {
                                    paramRow["CAPA"] = dtMWS.Rows[0]["TUE_TIME"];
                                }
                                else if (paramDS.Tables["RQSTDT"].Rows[0]["WEEK"].ToString() == "Wednesday")
                                {
                                    paramRow["CAPA"] = dtMWS.Rows[0]["WED_TIME"];
                                }
                                else if (paramDS.Tables["RQSTDT"].Rows[0]["WEEK"].ToString() == "Thursday")
                                {
                                    paramRow["CAPA"] = dtMWS.Rows[0]["THR_TIME"];
                                }
                                else if (paramDS.Tables["RQSTDT"].Rows[0]["WEEK"].ToString() == "Friday")
                                {
                                    paramRow["CAPA"] = dtMWS.Rows[0]["FRI_TIME"];
                                }
                                else if (paramDS.Tables["RQSTDT"].Rows[0]["WEEK"].ToString() == "Saturday")
                                {
                                    paramRow["CAPA"] = dtMWS.Rows[0]["SAT_TIME"];
                                }
                                paramTable.Rows.Add(paramRow);
                            }
                        }
                    }

                }
                else
                {
                    throw new Exception();

                    throw UTIL.SetException("에러 발생"                                    
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    );
                }

                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable);

                return paramSet;
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


        public static DataSet STD23A_INS_CAPA(DataSet paramDS, BizExecute.BizExecute bizExecute)
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


                        //if (paramDS.Tables["RQSTDT"].Rows[0][row["WEEK"].ToString()].ToString().Equals("1"))
                        //{
                        //    //선택된 요일 외 CAPA를 0으로 설정 키 체크된 항목에 대해서 0으로 설정한다.
                        //    //DLSE.LSE_HOLIDAY.LSE_HOLIDAY_DEL3(dt1, bizExecute);

                        //    //DLSE.LSE_MC_CAPAPLAN.LSE_MC_CAPAPLAN_INS2(dt1, bizExecute);

                        //}
                        //else
                        //{
                        //    //선택된 요일 외 CAPA를 0으로 설정 키 체크안된 항목에 대해서 기존값 유지한다.
                        //    //DataTable dtHoli = DLSE.LSE_HOLIDAY.LSE_HOLIDAY_SER(dt1, bizExecute);

                        //    //if (dtHoli.Rows.Count != 0)
                        //    //{

                        //    //}
                        //    //else
                        //    //{
                        //    //    DLSE.LSE_HOLIDAY.LSE_HOLIDAY_INS(dt1, bizExecute);
                        //    //}
                        //}

                        //설비별 처리
                        foreach (DataRow row2 in paramDS.Tables["RQSTDT2"].Rows)
                        {

                            DataTable dt2 = new DataTable("RQSTDT");
                            dt2.Columns.Add("PLT_CODE", typeof(String)); //
                            dt2.Columns.Add("MC_CODE", typeof(String)); //
                            dt2.Columns.Add("WORK_DATE", typeof(String)); //
                            dt2.Columns.Add("MC_DATE", typeof(String)); //
                            dt2.Columns.Add("WEEK", typeof(String)); //


                            DataRow paramRow = dt2.NewRow();
                            paramRow["PLT_CODE"] = paramDS.Tables["RQSTDT"].Rows[0]["PLT_CODE"].ToString();
                            paramRow["MC_CODE"] = row2["MC_CODE"].ToString();
                            paramRow["WORK_DATE"] = row["DATE"].ToString();
                            paramRow["MC_DATE"] = row["DATE"].ToString();
                            paramRow["WEEK"] = row["WEEK"].ToString();

                            dt2.Rows.Add(paramRow);
                            DataSet paramSet = new DataSet();
                            paramSet.Tables.Add(dt2);


                            if (paramDS.Tables["RQSTDT"].Rows[0][row["WEEK"].ToString()].Equals("1"))
                            {

                                //날짜체크가 되어있는 항목에 대해서
                                DataTable dtCAPA = DSTD.TSTD_MC_DAILYCAPA.TSTD_MC_DAILYCAPA_SER(dt2, bizExecute);

                                if (dtCAPA.Rows.Count != 0)
                                {

                                    if (paramDS.Tables["RQSTDT"].Rows[0]["CHECKZERO"].Equals("1"))
                                    {
                                        DSTD.TSTD_MC_DAILYCAPA.TSTD_MC_DAILYCAPA_DEL2(dt2, bizExecute);

                                        DLSE.LSE_MC_CAPAPLAN.LSE_MC_CAPAPLAN_DEL3(dt2, bizExecute);

                                        DataSet dsSTD23A = STD23A_SER4(paramSet, bizExecute);

                                        UTIL.SetBizAddColumnToValue(dt2, "CAPA", dsSTD23A.Tables["RSLTDT"].Rows[0]["CAPA"], typeof(Decimal));

                                        DSTD.TSTD_MC_DAILYCAPA.TSTD_MC_DAILYCAPA_INS(dt2, bizExecute);

                                    }
                                    else
                                    {
                                        DataSet dsSTD23A = STD23A_SER4(paramSet, bizExecute);

                                        UTIL.SetBizAddColumnToValue(dt2, "CAPA", dsSTD23A.Tables["RSLTDT"].Rows[0]["CAPA"].toInt32(), typeof(Decimal));

                                        DSTD.TSTD_MC_DAILYCAPA.TSTD_MC_DAILYCAPA_UPD(dt2, bizExecute);
                                    }


                                }
                                else
                                {
                                    DataSet dsSTD23A = STD23A_SER4(paramSet, bizExecute);

                                    UTIL.SetBizAddColumnToValue(dt2, "CAPA", dsSTD23A.Tables["RSLTDT"].Rows[0]["CAPA"], typeof(Decimal));

                                    DSTD.TSTD_MC_DAILYCAPA.TSTD_MC_DAILYCAPA_INS(dt2, bizExecute);
                                }

                            }


                            //날짜체크가 되어있지 않은 항목에 대해서
                            else
                            {  
                                //CAPA0으로 설정이 체크 되어 있는 경우
                                if (paramDS.Tables["RQSTDT"].Rows[0]["CHECKZERO"].Equals("1"))
                                {
                                    //해당 날짜를 0으로 설정한다.
                                    //DSTD.TSTD_MC_DAILYCAPA.TSTD_MC_DAILYCAPA_DEL2(dt2, bizExecute);

                                    //DLSE.LSE_MC_CAPAPLAN.LSE_MC_CAPAPLAN_DEL3(dt2, bizExecute);

                                    //UTIL.SetBizAddColumnToValue(dt2, "CAPA", 0, typeof(Decimal));

                                    DSTD.TSTD_MC_DAILYCAPA.TSTD_MC_DAILYCAPA_DEL2(dt2, bizExecute);

                                    DSTD.TSTD_MC_DAILYCAPA.TSTD_MC_DAILYCAPA_INS2(dt2, bizExecute);

                                }
                                else
                                {
                                    //해당 날짜 CAPA 그대로 유지

                                }
                            }

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


        public static DataSet STD23A_INS3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                //컬럼 유요성검사
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", "2", typeof(Byte)); //
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "MENU_CODE", null, typeof(String)); //
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "ACC_LEVEL", null, typeof(String)); //
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "IS_DEFAULT_MENU", null, typeof(Byte)); //
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "MDFY_DATE", null, typeof(String)); //
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "MDFY_EMP", null, typeof(String)); //

                //현재시간
                DataTable dtNow = UTIL.UTILITY_GET_DTNOW(bizExecute);
                string dt = ((DateTime)dtNow.Rows[0]["NOW_DT"]).ToString("yyyy-MM-dd HH:mm:ss");

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {

                    DataTable dtRslt = DSYS.TSYS_USERGRP.TSYS_USERGRP_SER(paramDS.Tables["RQSTDT"], bizExecute);

                    if (dtRslt.Rows.Count != 0)
                    {
                        if (dtRslt.Rows[0]["DATA_FLAG"].ToString() == "2")
                        {
                            if (paramDS.Tables["RQSTDT"].Rows[0]["OVERWRITE"].Equals("1"))
                            {
                                row["MDFY_DATE"] = dt;
                                row["MDFY_EMP"] = dtRslt.Rows[0]["REG_EMP"];
                                //row["DATA_FLAG"] = 0;
                                DSYS.TSYS_USERGRP.TSYS_USERGRP_INS(UTIL.GetRowToDt(row), bizExecute);

                                DSYS.TSYS_ACCESS.TSYS_ACCESS_DEL2(UTIL.GetRowToDt(row), bizExecute);

                                //DSYS.TSYS_ACCESS_QUERY.TSYS_ACCESS_QUERY1(UTIL.GetRowToDt(row), bizExecute);

                                //DataTable dtRsltAccess = DSYS.TSYS_ACCESS_QUERY.TSYS_ACCESS_QUERY1(UTIL.GetRowToDt(row), bizExecute);
                                DataTable dtRsltAccess = DSYS.TSYS_ACCESS_QUERY.TSYS_ACCESS_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                                row["MENU_CODE"] = dtRsltAccess.Rows[0]["MENU_CODE"];
                                row["ACC_LEVEL"] = dtRsltAccess.Rows[0]["ACC_LEVEL"];
                                row["IS_DEFAULT_MENU"] = dtRsltAccess.Rows[0]["IS_DEFAULT_MENU"];

                                DSYS.TSYS_ACCESS.TSYS_ACCESS_INS(UTIL.GetRowToDt(row), bizExecute);
                            }
                            else
                            {
                                throw new Exception("동일 이력 데이터가 존재합니다.");
                            }


                        }
                        else
                        {
                            if (paramDS.Tables["RQSTDT"].Rows[0]["OVERWRITE"].Equals("0"))
                            {
                                row["MDFY_DATE"] = dt;
                                row["MDFY_EMP"] = dtRslt.Rows[0]["REG_EMP"];
                                //row["DATA_FLAG"] = 0;
                                DSYS.TSYS_USERGRP.TSYS_USERGRP_UPD(UTIL.GetRowToDt(row), bizExecute);

                                DSYS.TSYS_ACCESS.TSYS_ACCESS_DEL2(UTIL.GetRowToDt(row), bizExecute);
                                
                                //DSYS.TSYS_ACCESS_QUERY.TSYS_ACCESS_QUERY1(UTIL.GetRowToDt(row), bizExecute);

                                //DataTable dtRsltAccess = DSYS.TSYS_ACCESS_QUERY.TSYS_ACCESS_QUERY1(UTIL.GetRowToDt(row), bizExecute);

                                row["USRGRP_CODE"] = paramDS.Tables["RQSTDT"].Rows[0]["COPY_USRGRP_CODE"];
                                DataTable dtRsltAccess = DSYS.TSYS_ACCESS_QUERY.TSYS_ACCESS_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                                row["MENU_CODE"] = dtRsltAccess.Rows[0]["MENU_CODE"];
                                row["ACC_LEVEL"] = dtRsltAccess.Rows[0]["ACC_LEVEL"];
                                row["IS_DEFAULT_MENU"] = dtRsltAccess.Rows[0]["IS_DEFAULT_MENU"];
                                row["USRGRP_CODE"] = dtRslt.Rows[0]["USRGRP_CODE"];

                                DSYS.TSYS_ACCESS.TSYS_ACCESS_INS(UTIL.GetRowToDt(row), bizExecute);
                            }
                            else
                            {
                                throw new Exception("동일 데이터가 존재합니다.");
                            }


                        }
                    }
                    else
                    {

                        row["MDFY_DATE"] = dt;
                        //row["MDFY_EMP"] = dtRslt.Rows[0]["REG_EMP"];

                        DSYS.TSYS_USERGRP.TSYS_USERGRP_INS(UTIL.GetRowToDt(row), bizExecute);

                        DataTable dtRsltAccess = DSYS.TSYS_ACCESS_QUERY.TSYS_ACCESS_QUERY1(UTIL.GetRowToDt(row), bizExecute);

                        row["MENU_CODE"] = dtRsltAccess.Rows[0]["MENU_CODE"];
                        row["ACC_LEVEL"] = dtRsltAccess.Rows[0]["ACC_LEVEL"];
                        row["IS_DEFAULT_MENU"] = dtRsltAccess.Rows[0]["IS_DEFAULT_MENU"];

                        DSYS.TSYS_ACCESS.TSYS_ACCESS_INS(UTIL.GetRowToDt(row), bizExecute);
                    }

                    dtRslt.Clear();
                }


                return STD23A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static DataSet STD23A_UPD1(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WEEK", "", typeof(String));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {

                   
                    string week = CTRL.CTRL.GetDateStringWeek(row["WORK_DATE"].ToString(), bizExecute);

                    row["WEEK"] = week;
                    

                    DataSet Rsltdt = STD23A_SER4(paramDS, bizExecute);

                    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "CAPA", Rsltdt.Tables["RSLTDT"].Rows[0]["CAPA"], typeof(Decimal)); //
                    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "MC_DATE", paramDS.Tables["RQSTDT"].Rows[0]["WORK_DATE"], typeof(String)); //

                    DSTD.TSTD_MC_DAILYCAPA.TSTD_MC_DAILYCAPA_UPD(paramDS.Tables["RQSTDT"], bizExecute);

                    DLSE.LSE_MC_CAPAPLAN.LSE_MC_CAPAPLAN_DEL3(paramDS.Tables["RQSTDT"], bizExecute);
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 휴일 설정
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet STD23A_UPD2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "HOLI_DATE", paramDS.Tables["RQSTDT"].Rows[0]["WORK_DATE"].ToString(), typeof(String));
                DataTable dtRslt = DLSE.LSE_HOLIDAY.LSE_HOLIDAY_SER(paramDS.Tables["RQSTDT"], bizExecute);
        
                if (dtRslt.Rows.Count == 0)
                {

                    DLSE.LSE_HOLIDAY.LSE_HOLIDAY_INS(paramDS.Tables["RQSTDT"], bizExecute);

                }

               
                DataTable dtCAPA = DSTD.TSTD_MC_DAILYCAPA_QUERY.TSTD_MC_DAILYCAPA_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                UTIL.SetBizAddColumnToValue(dtCAPA, "CAPA", 0, typeof(Decimal));


                if (dtCAPA.Rows.Count != 0)
                {
                    DSTD.TSTD_MC_DAILYCAPA.TSTD_MC_DAILYCAPA_UPD(dtCAPA, bizExecute);

                    //UTIL.SetBizAddColumnToValue(dtCAPA, "MC_DATE", dtCAPA.Rows[0]["WORK_DATE"].ToString(), typeof(String));
                    //DLSE.LSE_MC_CAPAPLAN.LSE_MC_CAPAPLAN_DEL3(dtCAPA, bizExecute);
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet STD23A_UPD3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DLSE.LSE_HOLIDAY.LSE_HOLIDAY_DEL3(paramDS.Tables["RQSTDT"], bizExecute);

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WORK_DATE", paramDS.Tables["RQSTDT"].Rows[0]["HOLI_DATE"].ToString(), typeof(String));
                DataTable dtRslt = DSTD.TSTD_MC_DAILYCAPA_QUERY.TSTD_MC_DAILYCAPA_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
               


                foreach (DataRow row in dtRslt.Rows)
                {

                    //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PLT_CODE", dtRslt.Rows[0]["PLT_CODE"], typeof(String)); //
                    //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "MC_CODE", dtRslt.Rows[0]["MC_CODE"], typeof(String)); //
                    //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WORK_DATE", dtRslt.Rows[0]["WORK_DATE"], typeof(String)); //
                    //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "CAPA", dtRslt.Rows[0]["CAPA"], typeof(Decimal)); //

                    string week = CTRL.CTRL.GetDateStringWeek(row["WORK_DATE"].ToString(), bizExecute);

                    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WEEK", week, typeof(String)); //

                    DataSet dtSER = STD23A_SER4(paramDS, bizExecute);

                    paramDS.Tables["RQSTDT"].Rows[0]["CAPA"] = dtSER.Tables["RQSTDT"].Rows[0]["CAPA"];

                    DSTD.TSTD_MC_DAILYCAPA.TSTD_MC_DAILYCAPA_UPD(paramDS.Tables["RQSTDT"], bizExecute);

                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet STD23A_UPD5_2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                if (paramDS.Tables["RQSTDT"].Rows.Count == 1)
                {


                    DataTable RQSTDT2_COPY = new DataTable("RQSTDT");
                    RQSTDT2_COPY.Columns.Add("FT1", typeof(Single));
                    RQSTDT2_COPY.Columns.Add("FT2", typeof(Single));
                    RQSTDT2_COPY.Columns.Add("FOT", typeof(Single));
                    RQSTDT2_COPY.Columns.Add("SD1", typeof(Single));
                    RQSTDT2_COPY.Columns.Add("SD2", typeof(Single));
                    RQSTDT2_COPY.Columns.Add("SOT", typeof(Single));
                    RQSTDT2_COPY.Columns.Add("TD1", typeof(Single));
                    RQSTDT2_COPY.Columns.Add("TD2", typeof(Single));
                    RQSTDT2_COPY.Columns.Add("TOT", typeof(Single));
                    RQSTDT2_COPY.Columns.Add("SCOMMENT", typeof(String));
                    RQSTDT2_COPY.Columns.Add("CAPA", typeof(Decimal));
                    RQSTDT2_COPY.Columns.Add("MC_DATE", typeof(String));
                    DataRow RQSTDT2_COPY_ROW = RQSTDT2_COPY.NewRow();

                    DataTable dtRslt =  DLSE.LSE_MACHINE.LSE_MACHINE_SER(paramDS.Tables["RQSTDT"], bizExecute);

                    foreach (DataRow row in dtRslt.Rows)
                    {
                                                                   
                                                
                        int mc_shift = row["MC_SHIFT"].toInt32();
                                                
                        switch (mc_shift)
                        {
                            case 1:
                                RQSTDT2_COPY_ROW["FT1"] = paramDS.Tables["RQSTDT2"].Rows[0]["FT1"];
                                RQSTDT2_COPY_ROW["FT2"] = paramDS.Tables["RQSTDT2"].Rows[0]["FT2"];
                                RQSTDT2_COPY_ROW["FOT"] = paramDS.Tables["RQSTDT2"].Rows[0]["FOT"];
                                RQSTDT2_COPY_ROW["SCOMMENT"] = paramDS.Tables["RQSTDT2"].Rows[0]["SCOMMENT"];
                                RQSTDT2_COPY_ROW["CAPA"] = Convert.ToDecimal(paramDS.Tables["RQSTDT2"].Rows[0]["FT1"]) + Convert.ToDecimal(paramDS.Tables["RQSTDT2"].Rows[0]["FT2"]) + Convert.ToDecimal(paramDS.Tables["RQSTDT2"].Rows[0]["FOT"]);
                                RQSTDT2_COPY_ROW["MC_DATE"] = paramDS.Tables["RQSTDT"].Rows[0]["WORK_DATE"];
                                RQSTDT2_COPY.Rows.Add(RQSTDT2_COPY_ROW);
                                break;

                            case 2:
                                RQSTDT2_COPY_ROW["FT1"] = paramDS.Tables["RQSTDT2"].Rows[0]["FT1"];
                                RQSTDT2_COPY_ROW["FT2"] = paramDS.Tables["RQSTDT2"].Rows[0]["FT2"];
                                RQSTDT2_COPY_ROW["FOT"] = paramDS.Tables["RQSTDT2"].Rows[0]["FOT"];
                                RQSTDT2_COPY_ROW["SD1"] = paramDS.Tables["RQSTDT2"].Rows[0]["SD1"];
                                RQSTDT2_COPY_ROW["SD2"] = paramDS.Tables["RQSTDT2"].Rows[0]["SD2"];
                                RQSTDT2_COPY_ROW["SOT"] = paramDS.Tables["RQSTDT2"].Rows[0]["SOT"];
                                RQSTDT2_COPY_ROW["SCOMMENT"] = paramDS.Tables["RQSTDT2"].Rows[0]["SCOMMENT"];
                                RQSTDT2_COPY_ROW["CAPA"] = Convert.ToDecimal(paramDS.Tables["RQSTDT2"].Rows[0]["FT1"]) + Convert.ToDecimal(paramDS.Tables["RQSTDT2"].Rows[0]["FT2"]) + Convert.ToDecimal(paramDS.Tables["RQSTDT2"].Rows[0]["FOT"]) + Convert.ToDecimal(paramDS.Tables["RQSTDT2"].Rows[0]["SD1"]) + Convert.ToDecimal(paramDS.Tables["RQSTDT2"].Rows[0]["SD2"]) + Convert.ToDecimal(paramDS.Tables["RQSTDT2"].Rows[0]["SOT"]);
                                //Convert.ToDecimal(RQSTDT2[0]["FT1"]) + Convert.ToDecimal(RQSTDT2[0]["FT2"]) + Convert.ToDecimal(RQSTDT2[0]["FOT"]) + Convert.ToDecimal(RQSTDT2[0]["SD1"]) + Convert.ToDecimal(RQSTDT2[0]["SD2"]) + Convert.ToDecimal(RQSTDT2[0]["SOT"])
                                RQSTDT2_COPY_ROW["MC_DATE"] = paramDS.Tables["RQSTDT"].Rows[0]["WORK_DATE"];
                                RQSTDT2_COPY.Rows.Add(RQSTDT2_COPY_ROW);
                                break;

                            case 3:
                                RQSTDT2_COPY_ROW["FT1"] = paramDS.Tables["RQSTDT2"].Rows[0]["FT1"];
                                RQSTDT2_COPY_ROW["FT2"] = paramDS.Tables["RQSTDT2"].Rows[0]["FT2"];
                                RQSTDT2_COPY_ROW["FOT"] = paramDS.Tables["RQSTDT2"].Rows[0]["FOT"];
                                RQSTDT2_COPY_ROW["SD1"] = paramDS.Tables["RQSTDT2"].Rows[0]["SD1"];
                                RQSTDT2_COPY_ROW["SD2"] = paramDS.Tables["RQSTDT2"].Rows[0]["SD2"];
                                RQSTDT2_COPY_ROW["SOT"] = paramDS.Tables["RQSTDT2"].Rows[0]["SOT"];
                                RQSTDT2_COPY_ROW["TD1"] = paramDS.Tables["RQSTDT2"].Rows[0]["TD1"];
                                RQSTDT2_COPY_ROW["TD2"] = paramDS.Tables["RQSTDT2"].Rows[0]["TD2"];
                                RQSTDT2_COPY_ROW["TOT"] = paramDS.Tables["RQSTDT2"].Rows[0]["TOT"];
                                RQSTDT2_COPY_ROW["SCOMMENT"] = paramDS.Tables["RQSTDT2"].Rows[0]["SCOMMENT"];
                                RQSTDT2_COPY_ROW["CAPA"] = Convert.ToDecimal(paramDS.Tables["RQSTDT2"].Rows[0]["FT1"]) + Convert.ToDecimal(paramDS.Tables["RQSTDT2"].Rows[0]["FT2"]) + Convert.ToDecimal(paramDS.Tables["RQSTDT2"].Rows[0]["FOT"]) + Convert.ToDecimal(paramDS.Tables["RQSTDT2"].Rows[0]["SD1"]) + Convert.ToDecimal(paramDS.Tables["RQSTDT2"].Rows[0]["SD2"]) + Convert.ToDecimal(paramDS.Tables["RQSTDT2"].Rows[0]["SOT"]) + Convert.ToDecimal(paramDS.Tables["RQSTDT2"].Rows[0]["TD1"]) + Convert.ToDecimal(paramDS.Tables["RQSTDT2"].Rows[0]["TD2"]) + Convert.ToDecimal(paramDS.Tables["RQSTDT2"].Rows[0]["TOT"]);
                                //Convert.ToDecimal(RQSTDT2[0]["FT1"]) + Convert.ToDecimal(RQSTDT2[0]["FT2"]) + Convert.ToDecimal(RQSTDT2[0]["FOT"]) + Convert.ToDecimal(RQSTDT2[0]["SD1"]) + Convert.ToDecimal(RQSTDT2[0]["SD2"]) + Convert.ToDecimal(RQSTDT2[0]["SOT"]) + Convert.ToDecimal(RQSTDT2[0]["TD1"]) + Convert.ToDecimal(RQSTDT2[0]["TD2"]) + Convert.ToDecimal(RQSTDT2[0]["TOT"])
                                RQSTDT2_COPY_ROW["MC_DATE"] = paramDS.Tables["RQSTDT"].Rows[0]["WORK_DATE"];
                                RQSTDT2_COPY.Rows.Add(RQSTDT2_COPY_ROW);
                                break;

                        }

                        UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT2"], "CAPA", RQSTDT2_COPY.Rows[0]["CAPA"], typeof(Decimal)); //
                        UTIL.SetBizAddColumnToValue(dtRslt, "MC_DATE", paramDS.Tables["RQSTDT"].Rows[0]["WORK_DATE"], typeof(String)); //
                        
                        DataTable dtCAPA = DLSE.LSE_MC_CAPAPLAN.LSE_MC_CAPAPLAN_SER(dtRslt, bizExecute);

                        UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT2"], "PLT_CODE", dtRslt.Rows[0]["PLT_CODE"], typeof(String)); //
                        UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT2"], "MC_CODE", dtRslt.Rows[0]["MC_CODE"], typeof(String)); //
                        UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT2"], "MC_DATE", paramDS.Tables["RQSTDT"].Rows[0]["WORK_DATE"], typeof(String)); //

                        if (dtCAPA.Rows.Count == 0)
                        {
                            DLSE.LSE_MC_CAPAPLAN.LSE_MC_CAPAPLAN_INS(paramDS.Tables["RQSTDT2"], bizExecute);
                        }

                        else
                        {
                            DLSE.LSE_MC_CAPAPLAN.LSE_MC_CAPAPLAN_UPD(paramDS.Tables["RQSTDT2"], bizExecute);
                        }

                        DSTD.TSTD_MC_DAILYCAPA.TSTD_MC_DAILYCAPA_UPD(paramDS.Tables["RQSTDT2"], bizExecute);

                    }

                }

                else
                {
                    throw new Exception("입력 파라메터가 잘못되었습니다.");
                }       
                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static DataSet STD23A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //컬럼 유요성검사
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", "2", typeof(Byte)); //
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "USRGRP_CODE", DBNull.Value, typeof(String));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "SEARCH_DATA_FLAG", 0, typeof(Byte));

                //현재시간
                DataTable dtNow = UTIL.UTILITY_GET_DTNOW(bizExecute);
                string dt = ((DateTime)dtNow.Rows[0]["NOW_DT"]).ToString("yyyy-MM-dd HH:mm:ss");

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {

                    DataTable dtRslt = DSTD.TSTD_EMPLOYEE_QUERY.TSTD_EMPLOYEE_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                    if (dtRslt.Rows.Count != 0)
                    {
                        if (dtRslt.Rows[0]["OVERDEL"].ToString() == "1")
                        {

                            row["MDFY_DATE"] = dt;
                            row["EMP_CODE"] = dtRslt.Rows[0]["EMP_CODE"];
                            //row["DATA_FLAG"] = 0;
                            DSTD.TSTD_EMPLOYEE.TSTD_EMPLOYEE_UPD2(UTIL.GetRowToDt(row), bizExecute);

                        }
                        else
                        {
                            throw new Exception("삭제하고자 하는 사용자 그룹으로 설정된 사용자가 존재합니다.");
                        }
                    }
                    else
                    {

                        row["DEL_DATE"] = dt;
                        //row["DATA_FLAG"] = 0;
                        DSYS.TSYS_USERGRP.TSYS_USERGRP_UDE(UTIL.GetRowToDt(row), bizExecute);

                    }

                    dtRslt.Clear();
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
