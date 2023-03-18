using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BSTD
{
    public class STD15A
    {
        public static DataSet STD15A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {

                    DataTable dtSer = DSTD.TSTD_FIELD.TSTD_FIELD_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (dtSer.Rows.Count > 0)
                    {
                        if (row["OVERWRITE"].Equals("1"))
                        {
                            DSTD.TSTD_FIELD.TSTD_FIELD_UPD(UTIL.GetRowToDt(row), bizExecute);
                        }
                        else
                        {
                            if (dtSer.Rows[0]["DATA_FLAG"].Equals((byte)2))
                            {
                                throw UTIL.SetException("동일 데이터가 이력이 존재할때 발생"
                                    , row["FIELD_CODE"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.OVERWRITE_HISTORY, dtSer.Rows[0]);

                            }
                            else
                            {
                                throw UTIL.SetException("동일 데이터가 존재할때 발생"
                                    , row["FIELD_CODE"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.OVERWRITE);
                            }
                        }
                    }
                    else
                    {
                        DSTD.TSTD_FIELD.TSTD_FIELD_INS(UTIL.GetRowToDt(row), bizExecute);
                    }

                }

                return STD15A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet STD15A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSTD.TSTD_FIELD_QUERY.TSTD_FIELD_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

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

        public static DataSet STD15A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 2, typeof(Byte));

                DSTD.TSTD_FIELD.TSTD_FIELD_UDE(paramDS.Tables["RQSTDT"], bizExecute);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }
    }
}
