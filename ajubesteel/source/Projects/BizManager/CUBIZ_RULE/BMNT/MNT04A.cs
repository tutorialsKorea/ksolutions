using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BMNT
{

    public class MNT04A
    {
        public static DataSet MNT04A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                /*
                 *입고
                 * 1. 외주 공정 다음공정을 진행하지 않은 공정들
                 * 2. 해당 외주 공정이 끝났으면 - 완료
                 *    시작도 안했으면 - 대기
                 *    시작했으면 - 진행
                 * 3. 입고완료된것들은 제일 위의 행으로
                 */


                /*
                 * 출고
                 * 1. 외주 공정이 시작 되지 않은 공정들(외주 발주 안된)
                 * 2. 직전 공정이 끝났으면 - 완료
                 *    직전 공정이 진행중이면 - 진행
                 *    직전 공정이 대기중이면 - 대기
                 * 3. 가공 완료된(직전 공정이 완료)공정이 제일 위
                 *    진행이 2순위, 그 외 3순위
                 */
                //입고
                DataTable dtInProc = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER6(paramDS.Tables["RQSTDT"], bizExecute);
                dtInProc.TableName = "RSLTDT_IN";

                //출고
                DataTable dtOutProc = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER5(paramDS.Tables["RQSTDT"], bizExecute);
                dtOutProc.TableName = "RSLTDT_OUT";


                paramDS.Tables.Add(dtInProc);
                paramDS.Tables.Add(dtOutProc);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
    }
}
