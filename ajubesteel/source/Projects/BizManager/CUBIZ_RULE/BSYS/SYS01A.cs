using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BSYS
{
    public class SYS01A
    {
        public static DataSet SYS01A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dt = DSYS.TSYS_REPORTLIST_QUERY.TSYS_REPORTLIST_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
                dt.Columns.Add("SEL");
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

        public static DataSet SYS01A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {

                    DataTable dtRptRslt = DSYS.TSYS_REPORTLIST.TSYS_REPORTLIST_SER(UTIL.GetRowToDt(row), bizExecute);
                    //데이터확인
                    if (dtRptRslt.Rows.Count != 0)
                    {
                        //데이터가 이미 있을때
                        if (row["OVERWRITE"].Equals("1"))
                        {
                            DSYS.TSYS_REPORTLIST.TSYS_REPORTLIST_UPD(UTIL.GetRowToDt(row), bizExecute);
                        }
                        else
                        {
                            throw UTIL.SetException("동일 데이터가 존재합니다. 덮어쓰시겠습니까?"
                                , new System.Diagnostics.StackFrame().GetMethod().Name
                                , 100001);
                        }
                    }
                    else
                    {
                        DSYS.TSYS_REPORTLIST.TSYS_REPORTLIST_INS(UTIL.GetRowToDt(row), bizExecute);
                    }

                }

                return SYS01A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet SYS01A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DSYS.TSYS_REPORTLIST.TSYS_REPORTLIST_DEL(paramDS.Tables["RQSTDT"], bizExecute);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
    }
}
