using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BizExecute;

namespace BPLN
{
    public class PLN19A
    {
        public static DataSet PLN19A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DORD.TORD_PATENT.TORD_PATENT_SER(paramDS.Tables["RQSTDT"], bizExecute);

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


        public static DataSet PLN19A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(int));
                DataTable dtRslt = DORD.TORD_PATENT_QUERY.TORD_PATENT_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

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



        public static DataSet PLN19A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (paramDS.Tables["RQSTDT"].Rows.Count != 0)
                {
                    DORD.TORD_PATENT.TORD_PATENT_INS(paramDS.Tables["RQSTDT"], bizExecute);
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static DataSet PLN19A_INS2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(int));

                if (paramDS.Tables["RQSTDT"].Rows.Count != 0)
                {
                    string sr_code = "PTN";
                    DataRow row = paramDS.Tables["RQSTDT"].Rows[0];

                    DataTable dtRst = DORD.TORD_PATENT.TORD_PATENT_SER(paramDS.Tables["RQSTDT"], bizExecute);

                    if (dtRst.Rows.Count > 0)
                    {
                        DORD.TORD_PATENT.TORD_PATENT_UPD(paramDS.Tables["RQSTDT"], bizExecute);
                    }
                    else
                    {
                        string serial = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), sr_code, bizExecute);
                        row["PATENT_CODE"] = serial;

                        DORD.TORD_PATENT.TORD_PATENT_INS(paramDS.Tables["RQSTDT"], bizExecute);
                    }

                }

                return PLN19A_SER2(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }



        public static DataSet PLN19A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
     
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                { 
            
                    DORD.TORD_PATENT.TORD_PATENT_UDE(UTIL.GetRowToDt(row), bizExecute);
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
