using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BizExecute;

namespace BSTD
{
    public class STD44A
    {
        public static DataSet STD44A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DSTD.TSTD_MC_INS_LIST.TSTD_MC_INS_LIST_SER(paramDS.Tables["RQSTDT"], bizExecute);

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


        public static DataSet STD44A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DSTD.TSTD_MC_INS_LIST_QUERY.TSTD_MC_INS_LIST_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                // dtRslt.Columns.Add("SEL", typeof(string));

                dtRslt.Columns.Add("INS_DATE", typeof(string));
                dtRslt.Columns.Add("INS_OK", typeof(byte));
                dtRslt.Columns.Add("INS_NG", typeof(byte));
                dtRslt.Columns.Add("INS_CHARGE", typeof(string));
                dtRslt.Columns.Add("MEASURE", typeof(decimal));

                

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        // 설비별 정기점검 내역 열기
        public static DataSet STD44A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DSTD.TSTD_MC_INS_LIST_QUERY.TSTD_MC_INS_LIST_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);

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


        public static DataSet STD44A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (paramDS.Tables["RQSTDT"].Rows.Count != 0)
                {
                    DSTD.TSTD_MC_INS_LIST.TSTD_MC_INS_LIST_INS(paramDS.Tables["RQSTDT"], bizExecute);
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static DataSet STD44A_INS2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                if (paramDS.Tables["RQSTDT"].Rows.Count != 0)
                {
                    string sr_code = "INS";
                    DataRow row = paramDS.Tables["RQSTDT"].Rows[0];

                    DataTable dtRst = DSTD.TSTD_MC_INS_LIST.TSTD_MC_INS_LIST_SER(paramDS.Tables["RQSTDT"], bizExecute);

                    if (dtRst.Rows.Count > 0)
                    {
                        DSTD.TSTD_MC_INS_LIST.TSTD_MC_INS_LIST_UPD(paramDS.Tables["RQSTDT"], bizExecute);
                    }
                    else
                    {
                        string serial = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), sr_code, bizExecute);
                        row["MC_INS_CODE"] = serial;

                        DSTD.TSTD_MC_INS_LIST.TSTD_MC_INS_LIST_INS(paramDS.Tables["RQSTDT"], bizExecute);
                    }

                }

                return STD44A_SER2(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }



        public static DataSet STD44A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
     
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                { 
            
                    DSTD.TSTD_MC_INS_LIST.TSTD_MC_INS_LIST_UDE(UTIL.GetRowToDt(row), bizExecute);
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
