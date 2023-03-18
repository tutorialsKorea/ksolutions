using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BizExecute;

namespace BSTD
{
    public class STD04A
    {

        public static DataSet STD04A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {

                    DataTable dtSer = DLSE.LSE_MACHINE.LSE_MACHINE_SER(paramDS.Tables["RQSTDT"],  bizExecute);

                    if (dtSer.Rows.Count > 0)
                    {
                        if (row["OVERWRITE"].Equals("1"))
                        {
                            DLSE.LSE_MACHINE.LSE_MACHINE_UPD(UTIL.GetRowToDt(row), bizExecute);
                        }
                        else
                        {
                            if (dtSer.Rows[0]["DATA_FLAG"].Equals((byte)2))
                            {
                                throw UTIL.SetException("동일 데이터가 이력이 존재할때 발생"
                                    , row["MC_CODE"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.OVERWRITE_HISTORY, dtSer.Rows[0]);

                            }
                            else
                            {
                                throw UTIL.SetException("동일 데이터가 존재할때 발생"
                                    , row["MC_CODE"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.OVERWRITE);
                            }
                        }
                    }
                    else
                    {
                        DLSE.LSE_MACHINE.LSE_MACHINE_INS(UTIL.GetRowToDt(row), bizExecute);
                    }



                    DLSE.LSE_MC_WORKTIME.LSE_MC_WORKTIME_DEL2(UTIL.GetRowToDt(row), bizExecute);

                    DLSE.LSE_MC_WORKTIME.LSE_MC_WORKTIME_INS(UTIL.GetRowToDt(row), bizExecute);

                    if (row["OPT_CAPA_CHANGE"].Equals("1"))
                    {
                        DataTable dtNow = UTIL.UTILITY_GET_DTNOW(bizExecute);
                        string dt = dtNow.Rows[0]["YYYYMMDD"].ToString();


                        DataTable dtNew = UTIL.GetRowToDt(row);
                        UTIL.SetBizAddColumnToValue(dtNew, "AFTER_WORK_DATE", dt, typeof(String));
                        

                        DataTable dtDC = DSTD.TSTD_MC_DAILYCAPA_QUERY.TSTD_MC_DAILYCAPA_QUERY1(dtNew, bizExecute);
                                      
                        foreach (DataRow row2 in dtDC.Rows)
                        {
                            string week = CTRL.CTRL.GetDateStringWeek(row2["WORK_DATE"].ToString(), bizExecute);


                            DataTable dtNew2 = UTIL.GetRowToDt(row2);
                            dtNew2.TableName = "RQSTDT";
                            UTIL.SetBizAddColumnToValue(dtNew2, "WEEK", week, typeof(String));
                            UTIL.SetBizAddColumnToValue(dtNew2, "MC_DATE", row2["WORK_DATE"], typeof(String));
               
                            DataSet dsResult = new DataSet();

                            dsResult.Merge(dtNew2);

                            DataSet dsStd23 = STD23A.STD23A_SER4(dsResult, bizExecute);
                            

                            
                            DLSE.LSE_MC_CAPAPLAN.LSE_MC_CAPAPLAN_DEL3(dtNew2, bizExecute);

                            dtNew2.Rows[0]["CAPA"] = dsStd23.Tables["RSLTDT"].Rows[0]["CAPA"].ToString();


                            DSTD.TSTD_MC_DAILYCAPA.TSTD_MC_DAILYCAPA_UPD(dtNew2, bizExecute);
                        }
                    }
                    //DataSet dsStd04 = STD04A_SER(paramDS, bizExecute);
                }

                return STD04A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
        
        public static DataSet STD04A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DLSE.LSE_MACHINE_QUERY.LSE_MACHINE_QUERY3(paramDS.Tables["RQSTDT"],  bizExecute);

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

        public static DataSet STD04A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DLSE.LSE_MC_WORKTIME.LSE_MC_WORKTIME_SER2(paramDS.Tables["RQSTDT"],  bizExecute);

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





        public static DataSet STD04A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 2, typeof(Byte));
                DataTable dtNow = UTIL.UTILITY_GET_DTNOW(bizExecute);
                string dt = ((DateTime)dtNow.Rows[0]["NOW_DT"]).ToString("yyyy-MM-dd HH:mm:ss");

                //요일별 capa 삭제
                DLSE.LSE_MC_WORKTIME.LSE_MC_WORKTIME_DEL2(paramDS.Tables["RQSTDT"], bizExecute);

                //machine data_flag 변경
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DELDATE", dt, typeof(String));
                DLSE.LSE_MACHINE.LSE_MACHINE_UDE(paramDS.Tables["RQSTDT"], bizExecute);

                //공정별 가용설비 데이터 삭제
                DLSE.LSE_STD_AVAILMC.LSE_STD_AVAILMC_DEL2(paramDS.Tables["RQSTDT"], bizExecute);

                //설비별 가용인원 데이터 삭제
                DSTD.TSTD_MC_AVAILEMP.TSTD_MC_AVAILEMP_DEL(paramDS.Tables["RQSTDT"], bizExecute);
                //특정날짜이후 CAPAㄷ이터 삭제 부분 미완성


      

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static DataTable QueryTableSchema()
        {
            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //사업장 코드
            paramTable.Columns.Add("MC_CODE", typeof(String));
            paramTable.Columns.Add("MC_LIKE", typeof(String));
            paramTable.Columns.Add("MC_MODEL_LIKE", typeof(String));

            return paramTable;
        }

        
    }
}
