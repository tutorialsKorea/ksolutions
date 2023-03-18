using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BPLN
{
    public class PLN15A
    {
        public static DataSet PLN15A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DLSE.LSE_MACHINE_QUERY.LSE_MACHINE_QUERY6(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.Columns.Add("PLAN_QTY", typeof(Int32));

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        //일일업무계획 CONF 조회
        public static DataSet PLN15A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSYS.TSYS_PLAN_CONF.TSYS_PLAN_CONF_SER(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        //일일업무계획 CONF 입력
        public static DataSet PLN15A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtRslt = DSYS.TSYS_PLAN_CONF.TSYS_PLAN_CONF_SER2(UTIL.GetRowToDt(row), bizExecute);


                    if (dtRslt.Rows.Count > 0)
                    {
                        DSYS.TSYS_PLAN_CONF.TSYS_PLAN_CONF_UPD(UTIL.GetRowToDt(row), bizExecute);
                    }
                    else
                    {
                        DSYS.TSYS_PLAN_CONF.TSYS_PLAN_CONF_INS(UTIL.GetRowToDt(row), bizExecute);
                    }
                    
                }

                return PLN15A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        //일일업무계획 CONF 삭제
        public static DataSet PLN15A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 2, typeof(Byte));

                DSYS.TSYS_PLAN_CONF.TSYS_PLAN_CONF_UDE(paramDS.Tables["RQSTDT"], bizExecute);

                return paramDS;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

    }
}
