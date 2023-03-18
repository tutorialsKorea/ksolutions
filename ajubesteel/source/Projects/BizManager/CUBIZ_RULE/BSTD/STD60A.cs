using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BizExecute;

namespace BSTD
{
    public class STD60A
    {
        public static DataSet STD60A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(byte));

                DataTable dtRslt = DSTD.TSTD_PANEL_MASTER_QUERY.TSTD_PANEL_MASTER_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

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

        public static DataSet STD60A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(byte));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "IS_ACCESS", "1", typeof(string));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                { 
                    DataTable dtSer = DSTD.TSTD_PANEL_MASTER.TSTD_PANEL_MASTER_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (dtSer.Rows.Count > 0)
                    {
                        DSTD.TSTD_PANEL_MASTER.TSTD_PANEL_MASTER_UPD(UTIL.GetRowToDt(row), bizExecute);
                    }
                    else
                    {
                        string serial = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "PNL", bizExecute);

                        row["PANEL_CODE"] = serial;

                        DSTD.TSTD_PANEL_MASTER.TSTD_PANEL_MASTER_INS(UTIL.GetRowToDt(row), bizExecute);
                    }

                }

                return STD60A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }



        public static DataSet STD60A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
     
                
            
                DSTD.TSTD_PANEL_MASTER.TSTD_PANEL_MASTER_UDE(paramDS.Tables["RQSTDT"], bizExecute);
                
                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

    }
}
