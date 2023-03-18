using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BORD
{
    public class ORD07A
    {

        public static DataSet ORD07A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"],"DATA_FLAG",0, typeof(byte));

                // UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_TYPE", "V", typeof(string));

                DataTable dtRslt = DORD.TORD_MODEL_QUERY.TORD_MODEL_QUERY4(paramDS.Tables["RQSTDT"], bizExecute);

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

        public static DataSet ORD07A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(byte));

                // UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_TYPE", "M", typeof(string));

                DataTable dtRslt = DORD.TORD_MODEL_QUERY.TORD_MODEL_QUERY4(paramDS.Tables["RQSTDT"], bizExecute);

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

        public static DataSet ORD07A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(byte));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtSer2 = DORD.TORD_MODEL_QUERY.TORD_MODEL_QUERY2(UTIL.GetRowToDt(row), bizExecute);

                    if (dtSer2.Rows.Count > 0)
                        throw UTIL.SetException("동일한 거래처가 이미 등록 되어 있습니다."
                           , dtSer2.Rows[0]["VEN_NAME"].ToString()
                             , new System.Diagnostics.StackFrame().GetMethod().Name, BizException.ABORT, row);


                    #region 수정전 원본
                    //DataTable dtSer2 = DORD.TORD_MODEL.TORD_MODEL_SER2(UTIL.GetRowToDt(row), bizExecute);

                    //if (dtSer2.Rows.Count > 0 && dtSer2.Rows[0]["SCODE"].ToString() != row["SCODE"].ToString())
                    //    throw UTIL.SetException("동일 한 모델이 이미 등록 되어 있습니다."
                    //        , row["MODEL_NAME"].ToString()
                    //          , new System.Diagnostics.StackFrame().GetMethod().Name, BizException.ABORT, row);
                    #endregion


                    DataTable dtSer = DORD.TORD_MODEL.TORD_MODEL_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (dtSer.Rows.Count > 0)
                    {
                        DORD.TORD_MODEL.TORD_MODEL_UPD(UTIL.GetRowToDt(row), bizExecute);
                    }
                    else
                    {
                        string scode = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "S", bizExecute);

                        row["SCODE"] = scode;

                        DORD.TORD_MODEL.TORD_MODEL_INS(UTIL.GetRowToDt(row), bizExecute);
                    }

                }

                DataTable dtRslt = DORD.TORD_MODEL_QUERY.TORD_MODEL_QUERY4(paramDS.Tables["RQSTDT"], bizExecute);

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

        public static DataSet ORD07A_INS2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtSer = DORD.TORD_MODEL_LOCK.TORD_MODEL_LOCK_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (dtSer.Rows.Count > 0)
                    {
                        DORD.TORD_MODEL_LOCK.TORD_MODEL_LOCK_UPD(UTIL.GetRowToDt(row), bizExecute);
                    }
                    else
                    {
                        DORD.TORD_MODEL_LOCK.TORD_MODEL_LOCK_INS(UTIL.GetRowToDt(row), bizExecute);
                    }
                }

                if (paramDS.Tables["RQSTDT"].Rows[0]["MODEL_TYPE"].ToString() == "V")
                {
                    return ORD07A_SER(paramDS, bizExecute);
                }
                else
                {
                    return ORD07A_SER2(paramDS, bizExecute);
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static DataSet ORD07A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "MODEL", paramDS.Tables["RQSTDT"].Rows[0]["SCODE"].ToString(), typeof(string));

                DataTable dtResult = DORD.TORD_PRODUCT_QUERY.TORD_PRODUCT_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                if (dtResult.Rows.Count == 0)
                {
                    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 2, typeof(byte));

                    DORD.TORD_MODEL.TORD_MODEL_UDE(paramDS.Tables["RQSTDT"], bizExecute);
                }
                else
                {
                    throw UTIL.SetException("해당 모델은 수주 정보와 연계되어 있습니다. "
                                      , new System.Diagnostics.StackFrame().GetMethod().Name
                                      , BizException.ABORT);
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
