using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BQCT
{
    public class QCT04A
    {
        public static DataSet QCT04A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DQCT.TQCT_COST_QUERY.TQCT_COST_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

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

        /// <summary>
        /// 품질 비용 저장
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        public static DataSet QCT04A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtParam = paramDS.Tables["RQSTDT"];

                foreach (DataRow dr in dtParam.Rows)
                {
                    DataTable dtSer = DQCT.TQCT_COST.TQCT_COST_SER(UTIL.GetRowToDt(dr), bizExecute);

                    if (dtSer.Rows.Count > 0)
                    {
                        DQCT.TQCT_COST.TQCT_COST_UPD(UTIL.GetRowToDt(dr), bizExecute);
                    }
                    else
                    {
                        //사내 불량 추가
                        dr["QCT_NO"] = UTIL.UTILITY_GET_SERIALNO(dr["PLT_CODE"].ToString(), "QC", UTIL.emSerialFormat.YYMM, "", bizExecute);

                        DataTable dtCost = UTIL.GetRowToDt(dr);
                        DQCT.TQCT_COST.TQCT_COST_INS(dtCost, bizExecute);
                    }
                }
                return QCT04A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet QCT04A_INS2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow dr in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtSer = DQCT.TQCT_COST.TQCT_COST_SER(UTIL.GetRowToDt(dr), bizExecute);

                    if (dtSer.Rows.Count > 0)
                    {
                        DQCT.TQCT_COST.TQCT_COST_UPD2(UTIL.GetRowToDt(dr), bizExecute);
                    }
                }
                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet QCT04A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow dr in paramDS.Tables["RQSTDT"].Rows)
                {
                    DQCT.TQCT_COST.TQCT_COST_DEL(UTIL.GetRowToDt(dr), bizExecute);
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
