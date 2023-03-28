using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BizExecute;

namespace BSTD
{
    public class STD61A
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet STD61A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtSer = DSTD.TSTD_TRANSPORT.TSTD_TRANSPORT_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (dtSer.Rows.Count > 0)
                    {
                        if (row["OVERWRITE"].Equals("1"))
                        {
                            DSTD.TSTD_TRANSPORT.TSTD_TRANSPORT_UPD(UTIL.GetRowToDt(row), bizExecute);
                        }
                        else
                        {
                            if (dtSer.Rows[0]["DATA_FLAG"].Equals((byte)2))
                            {
                                throw UTIL.SetException("동일 데이터가 이력이 존재할때 발생"
                                    , row["TRP_CODE"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.OVERWRITE_HISTORY, dtSer.Rows[0]);

                            }
                            else
                            {
                                throw UTIL.SetException("동일 데이터가 존재할때 발생"
                                    , row["TRP_CODE"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.OVERWRITE);
                            }
                        }
                    }
                    else
                    {
                        DSTD.TSTD_TRANSPORT.TSTD_TRANSPORT_INS(UTIL.GetRowToDt(row), bizExecute);
                    }

                }

                return STD61A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet STD61A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(byte));

                DataTable dtRslt = DSTD.TSTD_TRANSPORT_QUERY.TSTD_TRANSPORT_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

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

        public static DataSet STD61A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DSTD.TSTD_TRANSPORT.TSTD_TRANSPORT_UDE(UTIL.GetRowToDt(row), bizExecute);
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
