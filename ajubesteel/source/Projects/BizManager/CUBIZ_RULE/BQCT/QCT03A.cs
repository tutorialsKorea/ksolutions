using BizExecute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BQCT
{
    public class QCT03A
    {
        public static DataSet QCT03A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DQCT.TQCT_VENDOR_EVAL_QUERY.TQCT_VENDOR_EVAL_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet QCT03A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                DataTable dtParam = paramDS.Tables["RQSTDT"];

                foreach (DataRow dr in dtParam.Rows)
                {
                    DataTable dtSer = DQCT.TQCT_VENDOR_EVAL.TQCT_VENDOR_EVAL_SER(UTIL.GetRowToDt(dr), bizExecute);

                    if (dtSer.Rows.Count > 0)
                    {
                        DQCT.TQCT_VENDOR_EVAL.TQCT_VENDOR_EVAL_UPD(UTIL.GetRowToDt(dr), bizExecute);
                    }
                    else
                    {
                        dr["EVAL_NO"] = UTIL.UTILITY_GET_SERIALNO(dr["PLT_CODE"].ToString(), "EV", UTIL.emSerialFormat.YYYYMMDD, "", bizExecute);

                        DQCT.TQCT_VENDOR_EVAL.TQCT_VENDOR_EVAL_INS(UTIL.GetRowToDt(dr), bizExecute);
                    }
                }

                return QCT03A_SER(paramDS, bizExecute);

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet QCT03A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 2, typeof(Byte));

                foreach (DataRow dr in paramDS.Tables["RQSTDT"].Rows)
                {
                    DQCT.TQCT_VENDOR_EVAL.TQCT_VENDOR_EVAL_UDE(UTIL.GetRowToDt(dr), bizExecute);
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
