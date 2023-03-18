using BizExecute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSYS
{
    public class SYS18A
    {
        public static DataSet SYS18A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DSYS.TSYS_DAILY_LOG_PLAN_QUERY.TSYS_DAILY_LOG_PLAN_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

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

        public static DataSet SYS18A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                string sr_code = "DYLP";

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", "0", typeof(Byte));

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DLOG_ACT_FLAG", "0", typeof(Byte));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PLAN_SCOMMENT", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DLOG_PLAN_TIME", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PLAN_DATE", DateTime.Now.toDateString("yyyyMMdd"), typeof(string));


                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtRslt = DSYS.TSYS_DAILY_LOG_PLAN.TSYS_DAILY_LOG_PLAN_SER(paramDS.Tables["RQSTDT"], bizExecute);

                    //데이터가 있으면 삭제여부 및 덮어쓰기 여부에 따라 update
                    if (dtRslt.Rows.Count > 0)
                    {
                        if (row["OVERWRITE"].Equals("1"))
                        {
                            DSYS.TSYS_DAILY_LOG_PLAN.TSYS_DAILY_LOG_PLAN_UPD(UTIL.GetRowToDt(row), bizExecute);
                        }
                        else
                        {
                            if (dtRslt.Rows[0]["DATA_FLAG"].Equals((byte)2))
                            {
                                throw UTIL.SetException("동일 데이터가 이력이 존재할때 발생"
                                    , row["DLOG_ID"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.OVERWRITE_HISTORY, dtRslt.Rows[0]);

                            }
                            else
                            {
                                throw UTIL.SetException("동일 데이터가 존재할때 발생"
                                    , row["DLOG_ID"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.OVERWRITE);
                            }
                        }
                    }
                    else
                    {
                        string serial = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), sr_code, bizExecute);
                        row["DLOG_ID"] = serial;

                        DSYS.TSYS_DAILY_LOG_PLAN.TSYS_DAILY_LOG_PLAN_INS(UTIL.GetRowToDt(row), bizExecute);

                        // 처음 등록하는 경우 TSYS_DAILY_LOG에 바로 추가 - 22.01.20 kdpark
                        // 요구사항 : - 업무계획관리에 금일 동록한 경우에도 당일 업무일지에 조회되어 계획 수행이 될 수 있도록 (일, 주간, 월간, 년간 모두 동일)
                       
                        if (row["APPLY_FLAG"].ToString() == "1" &&
                            (DateTime.ParseExact(row["APPLY_START_DATE"].ToString(), "yyyyMMdd", null) <= DateTime.Now
                            && DateTime.ParseExact(row["APPLY_END_DATE"].ToString(), "yyyyMMdd", null) >= DateTime.Now))
                        {
                            string serial2 = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "DYL", bizExecute);
                            row["DLOG_ID"] = serial2;
                            row["PLAN_SCOMMENT"] = row["SCOMMENT"];
                            row["DLOG_PLAN_TIME"] = row["DLOG_TIME"];
                            row["SCOMMENT"] = null;
                            row["DLOG_TIME"] = null;
                            DSYS.TSYS_DAILY_LOG.TSYS_DAILY_LOG_INS(UTIL.GetRowToDt(row), bizExecute);

                            row["DLOG_ID"] = serial;
                        }

                    }
                }

                return SYS18A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet SYS18A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", "2", typeof(Byte));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {

                    DSYS.TSYS_DAILY_LOG_PLAN.TSYS_DAILY_LOG_PLAN_UDE(UTIL.GetRowToDt(row), bizExecute);
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
