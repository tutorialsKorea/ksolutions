using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BizExecute;

namespace BSYS
{
    public class SYS15A
    {
        public static DataSet SYS15A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
              
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSTD.TSTD_EMPLOYEE.TSTD_EMPLOYEE_SER5(paramDS.Tables["RQSTDT"], bizExecute);
             
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


        public static DataSet SYS15A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //업무현황정보
                DataTable dtRslt_DLOG = DSYS.TSYS_DAILY_LOG_QUERY.TSYS_DAILY_LOG_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt_DLOG.TableName = "RSLTDT_L";
                paramDS.Tables.Add(dtRslt_DLOG);


                foreach (DataRow paramRow in paramDS.Tables["RQSTDT"].Rows)
                {
                   
                   //실적정보
                   DataTable dtRslt_ACT = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY9(UTIL.GetRowToDt(paramRow), bizExecute);
                   dtRslt_ACT.TableName = "RSLTDT_A";
                   paramDS.Tables.Add(dtRslt_ACT);
                  
                }

                DataTable dtAvgRslt = new DataTable("RSLTDT2");
                dtAvgRslt.Columns.Add("PLT_CODE", typeof(string));
                dtAvgRslt.Columns.Add("PLAN_AVG_TIME", typeof(decimal));
                dtAvgRslt.Columns.Add("PLAN_AVG_HOUR_TIME", typeof(decimal));
                dtAvgRslt.Columns.Add("ACT_AVG_TIME", typeof(decimal));
                dtAvgRslt.Columns.Add("ACT_AVG_HOUR_TIME", typeof(decimal));

                Dictionary<string, decimal> planDic = new Dictionary<string, decimal>();
                Dictionary<string, decimal> actDic = new Dictionary<string, decimal>();

                DataRow avgRow = dtAvgRslt.NewRow();
                avgRow["PLT_CODE"] = ConnInfo.PLT_CODE;

                int pCnt = 0;
                int aCnt = 0;
                foreach (DataRow row in dtRslt_DLOG.Rows)
                {
                    if (row["PLAN_DATE"].ToString() != "")
                    {
                        avgRow["PLAN_AVG_TIME"] = avgRow["PLAN_AVG_TIME"].toDecimal() + row["DLOG_PLAN_TIME"].toDecimal();

                        if (!planDic.ContainsKey(row["PLAN_DATE"].ToString()))
                        {
                            pCnt++;
                            planDic.Add(row["PLAN_DATE"].ToString(), pCnt);
                        }
                    }


                    if (row["WORK_DATE"].ToString() != "")
                    {
                        avgRow["ACT_AVG_TIME"] = avgRow["ACT_AVG_TIME"].toDecimal() + row["DLOG_TIME"].toDecimal();

                        if (!actDic.ContainsKey(row["WORK_DATE"].ToString()))
                        {
                            aCnt++;
                            actDic.Add(row["WORK_DATE"].ToString(), aCnt);
                        }
                    }
                }

                if (pCnt > 0)
                {
                    avgRow["PLAN_AVG_TIME"] = Math.Round(avgRow["PLAN_AVG_TIME"].toDecimal() / pCnt.toDecimal(), 1);
                    avgRow["PLAN_AVG_HOUR_TIME"] = Math.Round(avgRow["PLAN_AVG_TIME"].toDouble() / 60.0, 1);
                }

                if (aCnt > 0)
                {
                    avgRow["ACT_AVG_TIME"] = Math.Round(avgRow["ACT_AVG_TIME"].toDecimal() / aCnt.toDecimal(), 1);
                    avgRow["ACT_AVG_HOUR_TIME"] = Math.Round(avgRow["ACT_AVG_TIME"].toDouble() / 60.0, 1);
                }

                dtAvgRslt.Rows.Add(avgRow);

                paramDS.Tables.Add(dtAvgRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet SYS15A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSTD.TSTD_EMPLOYEE.TSTD_EMPLOYEE_SER(paramDS.Tables["RQSTDT"], bizExecute);

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



        public static DataSet SYS15A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (paramDS.Tables["RQSTDT"].Rows.Count != 0)
                {
                    DSYS.TSYS_DAILY_LOG.TSYS_DAILY_LOG_INS(paramDS.Tables["RQSTDT"], bizExecute);
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static DataSet SYS15A_INS2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                if (paramDS.Tables["RQSTDT"].Rows.Count != 0)
                {
                    string sr_code = "DYL";
                    DataRow row = paramDS.Tables["RQSTDT"].Rows[0];

                    DataTable dtRst = DSYS.TSYS_DAILY_LOG.TSYS_DAILY_LOG_SER(paramDS.Tables["RQSTDT"], bizExecute);

                    if (dtRst.Rows.Count > 0)
                    {
                        DSYS.TSYS_DAILY_LOG.TSYS_DAILY_LOG_UPD(paramDS.Tables["RQSTDT"], bizExecute);
                    }
                    else
                    {
                        string serial = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), sr_code, bizExecute);
                        row["DLOG_ID"] = serial;

                        DSYS.TSYS_DAILY_LOG.TSYS_DAILY_LOG_INS(paramDS.Tables["RQSTDT"], bizExecute);
                    }

                }

                return SYS15A_SER2(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }



        public static DataSet SYS15A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
     
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                { 
            
                    DSYS.TSYS_DAILY_LOG.TSYS_DAILY_LOG_UDE(UTIL.GetRowToDt(row), bizExecute);
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
