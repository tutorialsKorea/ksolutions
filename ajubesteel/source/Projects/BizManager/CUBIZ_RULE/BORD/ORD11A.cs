using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BizExecute;

namespace BORD
{
    public class ORD11A
    {
        /// <summary>
        /// assy BOM관리 품목 조회
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet ORD11A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "MAT_LTYPE", "11", typeof(string));//제품


                DataTable dtRslt = DLSE.LSE_STD_PART_QUERY.LSE_STD_PART_QUERY16(paramDS.Tables["RQSTDT"], bizExecute);

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
        /// rev전 데이터 가져오기
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet ORD11A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DORD.TORD_BOM_MASTER_QUERY.TORD_BOM_MASTER_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet ORD11A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataTable dtResult = DMAT.TMAT_PARTLIST_QUERY.TMAT_PARTLIST_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);                
                dtResult.TableName = "RSLTDT";

                paramDS.Tables.Add(dtResult);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet ORD11A_UPD(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DORD.TORD_BOM_MASTER.TORD_BOM_MASTER_UPD(paramDS.Tables["RQSTDT"], bizExecute);

  
                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

    }
}
