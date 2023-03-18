using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BPUR
{
    public class PUR04A
    {
        public static DataSet PUR04A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PUR", "PUR", typeof(string));

                DataTable dtRslt = DMAT.TMAT_BALJU_MASTER_QUERY.TMAT_BALJU_MASTER_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                
                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PUR04A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "BAL_STAT", "11", typeof(string));

                DataTable dtRslt = DMAT.TMAT_BALJU_MASTER_QUERY.TMAT_BALJU_MASTER_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.Columns.Add("STATUS", typeof(string));
                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PUR04A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "BAL_STAT", "11", typeof(string));

                //DataTable dtRslt = DOUT.TOUT_PROCBALJU_QUERY.TOUT_PROCBALJU_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);
                DataTable dtRslt = DOUT.TOUT_PROCBALJU_MASTER_QUERY.TOUT_PROCBALJU_MASTER_QUERY5(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt.Columns.Add("STATUS", typeof(string));
                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static DataSet PUR04A_SER4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PUR", "PUR", typeof(string));

                DataTable dtRslt = DOUT.TOUT_PROCBALJU_MASTER_QUERY.TOUT_PROCBALJU_MASTER_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static DataSet PUR04A_SER5(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PUR", "PUR", typeof(string));
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "BAL_TYPE", "PUR", typeof(string));

                DataTable dtRslt = DMAT.TMAT_BALJU_QUERY.TMAT_BALJU_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable dtMail = DSYS.TSYS_EMAILSEND_LOG_QUERY.TSYS_EMAILSEND_LOG_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable dtPrint = DSYS.TSYS_PRINT_LOG_QUERY.TSYS_PRINT_LOG_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.Columns.Add("STATUS");
                dtRslt.TableName = "RSLTDT";
                dtMail.TableName = "RSLTDT_MAIL";

                dtPrint.TableName = "RSLTDT_PRINT";

                paramDS.Tables.Add(dtRslt);
                paramDS.Tables.Add(dtMail);
                paramDS.Tables.Add(dtPrint);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static DataSet PUR04A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    if (row["TYPE"].ToString() == "MAT")
                    {
                        DMAT.TMAT_BALJU_MASTER.TMAT_BALJU_MASTER_UPD4(UTIL.GetRowToDt(row), bizExecute);
                        return PUR04A_SER2(paramDS, bizExecute);
                    }
                    else if (row["TYPE"].ToString() == "OUT")
                    {
                        DOUT.TOUT_PROCBALJU_MASTER.TOUT_PROCBALJU_MASTER_UPD4(UTIL.GetRowToDt(row), bizExecute);
                        return PUR04A_SER3(paramDS, bizExecute);
                    }
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
