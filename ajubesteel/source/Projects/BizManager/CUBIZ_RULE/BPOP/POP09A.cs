using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BPOP
{
    public class POP09A
    {
        public static DataSet POP09A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", "0", typeof(Byte));
            DataTable dtRslt = DSHP.TSHP_IDLETIME_QUERY.TSHP_IDLETIME_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

            DataSet dsRslt = new DataSet();
            dsRslt.Tables.Add(dtRslt);
            dtRslt.TableName = "RSLTDT";

            return dsRslt;
        }




        //비가동 입력
        public static DataSet POP09A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsRslt = new DataSet();
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {

                    DataTable dtIdleRslt = DSHP.TSHP_IDLETIME.TSHP_IDLETIME_SER2(UTIL.GetRowToDt(row), bizExecute);

                    if (dtIdleRslt.Rows.Count != 0)
                    {
                        if (dtIdleRslt.Rows[0]["DATA_FLAG"].ToString() == "2")
                        {
                            throw UTIL.SetException("이미 처리되거나 유효하지않는 데이터입니다. 새로고침합니다."
                                , new System.Diagnostics.StackFrame().GetMethod().Name
                                , BizException.DATA_REFRESH);
                        }
                        else
                        {
                            DataTable dtIdleUpd = UTIL.GetRowToDt(row);

                            UTIL.SetBizAddColumnToValue(dtIdleUpd, "DATA_FLAG", 0, typeof(Byte));
                            UTIL.SetBizAddColumnToValue(dtIdleUpd, "IDLE_STATE", 0, typeof(Byte));

                            DSHP.TSHP_IDLETIME.TSHP_IDLETIME_UPD2(dtIdleUpd, bizExecute);

                            DataSet dsUpdRslt = POP09A_SER(UTIL.GetDtToDs(UTIL.GetRowToDt(row)), bizExecute);
                            dsRslt.Merge(dsUpdRslt.Tables["RSLTDT"].Copy());
                        }

                    }
                    else
                    {
                        row["IDLE_ID"] = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "IL", UTIL.emSerialFormat.YYYYMMDD, "", bizExecute);

                        DataTable dtIdleIns = UTIL.GetRowToDt(row);

                        UTIL.SetBizAddColumnToValue(dtIdleIns, "DATA_FLAG", 0, typeof(Byte));
                        UTIL.SetBizAddColumnToValue(dtIdleIns, "IDLE_STATE", 0, typeof(Byte));

                        DSHP.TSHP_IDLETIME.TSHP_IDLETIME_INS2(dtIdleIns, bizExecute);

                        DataSet dsInsRslt = POP09A_SER(UTIL.GetDtToDs(UTIL.GetRowToDt(row)), bizExecute);
                        dsRslt.Merge(dsInsRslt.Tables["RSLTDT"].Copy());
                    }
                }

                return dsRslt;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }



        // 비가동 삭제
        public static DataSet POP09A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsRslt = new DataSet();
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtIdleDel = UTIL.GetRowToDt(row);
                    UTIL.SetBizAddColumnToValue(dtIdleDel, "DATA_FLAG", 2, typeof(Byte));
                    DSHP.TSHP_IDLETIME.TSHP_IDLETIME_UDE(dtIdleDel, bizExecute);

                }

                dsRslt.Tables.Add(paramDS.Tables["RQSTDT"].Copy());
                return dsRslt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
