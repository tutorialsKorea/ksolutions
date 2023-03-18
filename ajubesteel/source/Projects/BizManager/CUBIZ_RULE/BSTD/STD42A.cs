using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BSTD
{

    public class STD42A
    {

        /// <summary>
        /// 목표값 입력
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet STD42A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
         
                    DataTable dtRslt = DSTD.TSTD_REPORT_GOAL.TSTD_REPORT_GOAL_SER(UTIL.GetRowToDt(row), bizExecute);

                    if(dtRslt.Rows.Count>0)
                    { 
                        DSTD.TSTD_REPORT_GOAL.TSTD_REPORT_GOAL_UPD(UTIL.GetRowToDt(row), bizExecute);
                    }
                    else
                    {

                        DSTD.TSTD_REPORT_GOAL.TSTD_REPORT_GOAL_INS(UTIL.GetRowToDt(row), bizExecute);
                    }
                }
                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        /// <summary>
        /// 대일정 삭제
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet STD42A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DSTD.TSTD_REPORT_GOAL.TSTD_REPORT_GOAL_DEL(paramDS.Tables["RQSTDT"],  bizExecute);

                return paramDS;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }


        /// <summary>
        /// 목표 조회
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet STD42A_SER( DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {

                DataTable dtRslt = DSTD.TSTD_REPORT_GOAL_QUERY.TSTD_REPORT_GOAL_QUERY_QUERY1(paramDS.Tables["RQSTDT"],  bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

    }
}
