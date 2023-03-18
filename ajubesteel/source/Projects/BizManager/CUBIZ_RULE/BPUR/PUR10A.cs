using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BPUR
{
    public class PUR10A
    {

        public static DataSet PUR10A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(int));

                DataTable dtRslt = DMAT.TMAT_BALJU_SET_QUERY.TMAT_BALJU_SET_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static DataSet PUR10A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtparam = paramDS.Tables["RQSTDT"];

                DataTable dtRslt = DMAT.TMAT_BALJU_SET.TMAT_BALJU_SET_SER(dtparam, bizExecute);

                if (dtRslt.Rows.Count > 0)
                {
                    
                    DMAT.TMAT_BALJU_SET.TMAT_BALJU_SET_UPD(dtparam, bizExecute);
                }
                else
                {

                    string setId = UTIL.UTILITY_GET_SERIALNO(dtparam.Rows[0]["PLT_CODE"].ToString(), "SI", UTIL.emSerialFormat.YYMMDD, "", bizExecute);

                    dtparam.Rows[0]["SET_ID"] = setId;

                    DMAT.TMAT_BALJU_SET.TMAT_BALJU_SET_INS(dtparam, bizExecute);
                }

                
                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static DataSet PUR10A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DMAT.TMAT_BALJU_SET.TMAT_BALJU_SET_UDE(paramDS.Tables["RQSTDT"], bizExecute);
                
                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


    }
}

