using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BPLN
{
    /// <summary>
    /// 반제품 출하 취소
    /// </summary>
    public class PLN06A
    {
        /// <summary>
        /// 반제품 재고 취소
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        public static DataSet PLN06A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //1. TSHP_STOCK DELETE
                //2. TSHP_ACTUAL 혹은 TSHP_MANACTUAL에 UPDATE STK_ID IS NULL 
                DataTable dtStock = paramDS.Tables["RQSTDT"];
                
                foreach (DataRow dr in dtStock.Rows)
                {

                    DSHP.TSHP_STOCK.TSHP_STOCK_DEL(UTIL.GetRowToDt(dr), bizExecute);
                    
                    //ACTUAL_ID랑 WO_NO가 같으면 수작업 실적임.
                    if (dr["ACTUAL_ID"].Equals(dr["WO_NO"]))
                        DSHP.TSHP_MANACTUAL.TSHP_MANACTUAL_UPD7(UTIL.GetRowToDt(dr), bizExecute);
                    else
                        DSHP.TSHP_ACTUAL.TSHP_ACTUAL_UPD7(UTIL.GetRowToDt(dr), bizExecute);

                    DSHP.TSHP_DAILYWORK.TSHP_DAILYWORK_UPD2(UTIL.GetRowToDt(dr), bizExecute);
                    
                }

                return paramDS;


            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PLN06A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsRslt = new DataSet();

                if (paramDS.Tables["RQSTDT"].Rows.Count > 0)
                {
                    DataTable dtResult = DSHP.TSHP_DAILYWORK_QUERY.TSHP_DAILYWORK_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
                    //DataTable dtResult = DSHP.TSHP_STOCK.TSHP_STOCK_SER(paramDS.Tables["RQSTDT"], bizExecute);
                    dtResult.TableName = "RSLTDT";
                    dtResult.Columns.Add("SEL", typeof(String));

                    dsRslt.Tables.Add(dtResult);
                }

                return dsRslt;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
    }
}
