using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BMCN
{
    public class MCN01A
    {
        public static DataSet MCN01A_SER1(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Int32));

                DataTable dtRslt = DHIS.THIS_MEASURE_MASTER_QUERY.THIS_MEASURE_MASTER_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 이미지 개별 로딩
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet MCN01A_SER1_2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DHIS.THIS_MEASURE_MASTER.THIS_MEASURE_MASTER_SER2(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet MCN01A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataTable dtRslt_His = DHIS.THIS_MEASURE_HISTORY_QUERY.THIS_MEASURE_HISTORY_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt_His.TableName = "RSLTDT_HIS";

                DataTable dtRslt_Rep = DHIS.THIS_MEASURE_REPAIR_QUERY.THIS_MEASURE_REPAIR_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt_Rep.TableName = "RSLTDT_REP";

                paramDS.Tables.Add(dtRslt_His);
                paramDS.Tables.Add(dtRslt_Rep);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet MCN01A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtParam = paramDS.Tables["RQSTDT"];

                foreach (DataRow dr in dtParam.Rows)
                {
                    DataTable dtSer = DHIS.THIS_MEASURE_MASTER.THIS_MEASURE_MASTER_SER(UTIL.GetRowToDt(dr), bizExecute);

                    if (dtSer.Rows.Count > 0)
                    {
                        //불량 내용 수정
                        DHIS.THIS_MEASURE_MASTER.THIS_MEASURE_MASTER_UPD(UTIL.GetRowToDt(dr), bizExecute);
                    }
                    else
                    {
                        dr["MS_NO"] = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "MS", UTIL.emSerialFormat.YYMMDD, "", bizExecute);
                        DataTable dtMs = UTIL.GetRowToDt(dr);
                        DHIS.THIS_MEASURE_MASTER.THIS_MEASURE_MASTER_INS(dtMs, bizExecute);
                    }
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static DataSet MCN01A_INS2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtParam = paramDS.Tables["RQSTDT"];

                foreach (DataRow dr in dtParam.Rows)
                {
                    #region 기존소스
                    //DataTable dtSer = DHIS.THIS_MEASURE_HISTORY.THIS_MEASURE_HISTORY_SER(UTIL.GetRowToDt(dr), bizExecute);

                    //if (dtSer.Rows.Count > 0)
                    //{
                    //    //불량 내용 수정
                    //    DHIS.THIS_MEASURE_HISTORY.THIS_MEASURE_HISTORY_UPD(UTIL.GetRowToDt(dr), bizExecute);
                    //}
                    //else
                    //{
                    //object identity = DHIS.THIS_MEASURE_HISTORY.THIS_MEASURE_HISTORY_INS(UTIL.GetRowToDt(dr), bizExecute);
                    //
                    #endregion

                    if(!dr["MS_HIS_ID"].isNullOrEmpty())
                    {
                        DHIS.THIS_MEASURE_HISTORY.THIS_MEASURE_HISTORY_UPD2(UTIL.GetRowToDt(dr), bizExecute);
                    }
                    else
                    {
                        object identity = DHIS.THIS_MEASURE_HISTORY.THIS_MEASURE_HISTORY_INS(UTIL.GetRowToDt(dr), bizExecute);

                        if (identity != null
                            && identity.toInt32() > 0)
                        {
                            dr["MS_HIS_ID"] = identity;
                            DHIS.THIS_MEASURE_MASTER.THIS_MEASURE_MASTER_UPD2(UTIL.GetRowToDt(dr), bizExecute);
                        }
                    }
                }

                return MCN01A_SER1(paramDS,bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet MCN01A_INS3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtParam = paramDS.Tables["RQSTDT"];

                foreach (DataRow dr in dtParam.Rows)
                {
                    if(!dr["MS_REP_ID"].isNullOrEmpty())
                    {
                        DHIS.THIS_MEASURE_REPAIR.THIS_MEASURE_REPAIR_UPD2(UTIL.GetRowToDt(dr), bizExecute);
                    }
                    else
                    {
                        object identity = DHIS.THIS_MEASURE_REPAIR.THIS_MEASURE_REPAIR_INS(UTIL.GetRowToDt(dr), bizExecute);

                        if (identity != null
                            && identity.toInt32() > 0)
                        {
                            dr["MS_REP_ID"] = identity;
                            DHIS.THIS_MEASURE_MASTER.THIS_MEASURE_MASTER_UPD3(UTIL.GetRowToDt(dr), bizExecute);
                        }
                    }
                }

                return MCN01A_SER1(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet MCN01A_UDE(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtParam = paramDS.Tables["RQSTDT"];

                foreach (DataRow dr in dtParam.Rows)
                {
                    DHIS.THIS_MEASURE_MASTER.THIS_MEASURE_MASTER_UDE(UTIL.GetRowToDt(dr), bizExecute);
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
