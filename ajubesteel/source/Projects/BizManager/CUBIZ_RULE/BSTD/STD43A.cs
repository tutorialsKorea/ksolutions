using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BSTD
{
    public class STD43A
    {
        public static DataSet STD43A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {

                    if (row["APP_TYPE"].ToString() != "PUR" && row["APP_TYPE"].ToString() != "AS")
                    {
                        DataTable dtRslt = DSTD.TSTD_APP_EMP.TSTD_APP_EMP_SER(UTIL.GetRowToDt(row), bizExecute);

                        if (dtRslt.Rows.Count > 0)
                        {
                            DSTD.TSTD_APP_EMP.TSTD_APP_EMP_UPD(UTIL.GetRowToDt(row), bizExecute);
                        }
                        else
                        {

                            DSTD.TSTD_APP_EMP.TSTD_APP_EMP_INS(UTIL.GetRowToDt(row), bizExecute);
                        }
                    }
                    else
                    {
                        DataTable dtRslt = DSTD.TSTD_APP_EMP.TSTD_APP_EMP_SER4(UTIL.GetRowToDt(row), bizExecute);

                        if (dtRslt.Rows.Count > 0)
                        {
                            DSTD.TSTD_APP_EMP.TSTD_APP_EMP_UPD2(UTIL.GetRowToDt(row), bizExecute);
                        }
                        else
                        {

                            DSTD.TSTD_APP_EMP.TSTD_APP_EMP_INS(UTIL.GetRowToDt(row), bizExecute);
                        }
                    }
                    
                }
                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static DataSet STD43A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {

                DataTable dtRslt = DSTD.TSTD_APP_EMP.TSTD_APP_EMP_SER2(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";


                DataTable dtOrg = DSTD.TSTD_ORG_QUERY.TSTD_ORG_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtOrg.TableName = "RSLTDT_ORG";

                paramDS.Tables.Add(dtRslt);
                paramDS.Tables.Add(dtOrg);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet STD43A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {

                DataTable dtRslt = DSTD.TSTD_APP_EMP.TSTD_APP_EMP_SER(paramDS.Tables["RQSTDT"], bizExecute);

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
