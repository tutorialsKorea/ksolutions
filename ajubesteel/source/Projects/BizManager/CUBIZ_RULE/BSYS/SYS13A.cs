using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BizExecute;

namespace BSYS
{
    public class SYS13A
    {


        public static DataSet SYS13A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataTable dtSer = DSYS.TSYS_UPDATE.TSYS_UPDATE_SER(paramDS.Tables["RQSTDT"], bizExecute);

                if (dtSer.Rows.Count > 0)
                {
                    DSYS.TSYS_UPDATE.TSYS_UPDATE_UPD(paramDS.Tables["RQSTDT"], bizExecute);
                }
                else
                {
                    DSYS.TSYS_UPDATE.TSYS_UPDATE_INS(paramDS.Tables["RQSTDT"], bizExecute);
                }
                DataTable dt = DSYS.TSYS_UPDATE_QUERY.TSYS_UPDATE_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dt.TableName = "RSLTDT";

                DataSet dsRslt = new DataSet();
                dsRslt.Tables.Add(dt);

                return dsRslt;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
        /// <summary>
        /// 시스템 업데이트 내역 조회
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet SYS13A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                
                DataTable dt = DSYS.TSYS_UPDATE_QUERY.TSYS_UPDATE_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                
                dt.TableName = "RSLTDT";

                DataSet dsRslt = new DataSet();
                dsRslt.Tables.Add(dt);

                return dsRslt;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        /// <summary>
        /// 시스템 업데이트 내역 삭제
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet SYS13A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (paramDS.Tables["RQSTDT"].Rows.Count != 0)
                {
                    DSYS.TSYS_UPDATE.TSYS_UPDATE_DEL(paramDS.Tables["RQSTDT"], bizExecute);
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
