using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BSYS
{
    public class SYS11A
    {
        public static DataSet SYS11A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DSYS.TSYS_EMP_CONF_LIST_QUERY.TSYS_EMP_CONF_LIST_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                UTIL.SetBizAddColumnToValue(dtRslt, "SEL", 0, typeof(String));

                DataSet dsRslt = new DataSet();

                dtRslt.TableName = "RSLTDT";

                dsRslt.Tables.Add(dtRslt);

                return dsRslt;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet SYS11A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsRslt = new DataSet();

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtConfListRslt = DSYS.TSYS_EMP_CONF_LIST.TSYS_EMP_CONF_LIST_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (dtConfListRslt.Rows.Count != 0)
                    {
                        if (row["OVERWRITE"].Equals("1"))
                        {
                            DSYS.TSYS_EMP_CONF_LIST.TSYS_EMP_CONF_LIST_UPD(UTIL.GetRowToDt(row), bizExecute);
                        }
                        else
                        {
                            throw UTIL.SetException("동일 데이터가 존재할때 발생"
                                    , row["CONF_NAME"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.OVERWRITE);
                        }
                    }
                    else
                    {
                        DSYS.TSYS_EMP_CONF_LIST.TSYS_EMP_CONF_LIST_INS(UTIL.GetRowToDt(row), bizExecute);
                    }

                    //SYS11A_SER(UTIL.GetDtToDs(UTIL.GetRowToDt(row)), bizExecute);
                }

                return  SYS11A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public DataSet SYS11A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            
            foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
            {
                DSYS.TSYS_EMP_CONF_LIST.TSYS_EMP_CONF_LIST_DEL(UTIL.GetRowToDt(row), bizExecute);
            }

            return paramDS;
        }

    }
}
