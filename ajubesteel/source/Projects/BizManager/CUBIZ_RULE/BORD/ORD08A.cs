using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BORD
{
    public class ORD08A
    {

        public static DataSet ORD08A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(byte));

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_TYPE", "B", typeof(string));

                DataTable dtRslt = DORD.TORD_ST_GROUP_QUERY.TORD_ST_GROUP_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.Columns.Add("SEL");

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet ORD08A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(byte));

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_TYPE", "M", typeof(string));

                DataTable dtRslt = DORD.TORD_ST_GROUP_QUERY.TORD_ST_GROUP_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                if(dtRslt.Rows.Count == 0)
                    dtRslt = DORD.TORD_ST_GROUP_QUERY.TORD_ST_GROUP_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);


                dtRslt.Columns.Add("SEL");

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet ORD08A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(byte));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtSer = DORD.TORD_ST_GROUP.TORD_ST_GROUP_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (dtSer.Rows.Count > 0)
                    {
                        DORD.TORD_ST_GROUP.TORD_ST_GROUP_UPD(UTIL.GetRowToDt(row), bizExecute);
                    }
                    else
                    {
                        string scode = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "S", bizExecute);

                        row["SCODE"] = scode;

                        DORD.TORD_ST_GROUP.TORD_ST_GROUP_INS(UTIL.GetRowToDt(row), bizExecute);
                    }

                }

                DataTable dtRslt = DORD.TORD_ST_GROUP_QUERY.TORD_ST_GROUP_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.Columns.Add("SEL");

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);


                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static DataSet ORD08A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 2, typeof(byte));

                DORD.TORD_ST_GROUP.TORD_ST_GROUP_UDE(paramDS.Tables["RQSTDT"], bizExecute);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
    }
}
