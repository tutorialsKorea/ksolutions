using BizExecute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWOR
{
    public class WOR01A
    {
        public static DataSet WOR01A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSHP.TSHP_WORK_MNG_QUERY.TSHP_WORK_MNG_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.Columns.Add("SEL");
                dtRslt.Columns.Add("APP_EMP_CODE1", typeof(string));
                dtRslt.Columns.Add("APP_EMP_NAME1", typeof(string));
                dtRslt.Columns.Add("APP_EMP1_FLAG", typeof(string));

                dtRslt.Columns.Add("APP_EMP_CODE2", typeof(string));
                dtRslt.Columns.Add("APP_EMP_NAME2", typeof(string));
                dtRslt.Columns.Add("APP_EMP2_FLAG", typeof(string));

                dtRslt.Columns.Add("APP_EMP_CODE3", typeof(string));
                dtRslt.Columns.Add("APP_EMP_NAME3", typeof(string));
                dtRslt.Columns.Add("APP_EMP3_FLAG", typeof(string));

                dtRslt.Columns.Add("APP_EMP_CODE4", typeof(string));
                dtRslt.Columns.Add("APP_EMP_NAME4", typeof(string));
                dtRslt.Columns.Add("APP_EMP4_FLAG", typeof(string));
                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);


                //승인자 불러오기
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_TYPE", "ATD", typeof(string));

                DataTable AppEmpRslt = DSTD.TSTD_APP_EMP_QUERY.TSTD_APP_EMP_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                AppEmpRslt.TableName = "RSLTDT_APP_EMP";

                paramDS.Tables.Add(AppEmpRslt);


                DataTable workDayRslt = DSTD.TSTD_WORKDAY.TSTD_WORKDAY_SER2(paramDS.Tables["RQSTDT"], bizExecute);
                workDayRslt.TableName = "RSLTDT_WORKDAY";

                paramDS.Tables.Add(workDayRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet WOR01A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSTD.TSTD_WORKCODE_QUERY.TSTD_WORKCODE_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet WOR01A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DLSE.LSE_HOLIDAY_QUERY.LSE_HOLIDAY_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet WOR01A_SER4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSTD.TSTD_WORKTIME_QUERY.TSTD_WORKTIME_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet WOR01A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", "0", typeof(Byte));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtRslt = DSHP.TSHP_WORK_MNG.TSHP_WORK_MNG_SER(UTIL.GetRowToDt(row), bizExecute);

                    //데이터가 있으면 삭제여부 및 덮어쓰기 여부에 따라 update
                    if (dtRslt.Rows.Count > 0)
                    {
                        if (row["OVERWRITE"].Equals("1"))
                        {
                            if (dtRslt.Rows[0]["REQ_STATUS"].ToString() != "0")
                            {
                                throw UTIL.SetException("승인 진행중일 경우 수정/삭제할 수 없습니다."
                                , row["WORK_ID"].ToString()
                                , new System.Diagnostics.StackFrame().GetMethod().Name
                                , BizException.ABORT);
                            }

                            DSHP.TSHP_WORK_MNG.TSHP_WORK_MNG_UPD(UTIL.GetRowToDt(row), bizExecute);
                        }
                        else
                        {
                            if (dtRslt.Rows[0]["DATA_FLAG"].Equals((byte)2))
                            {

                                throw UTIL.SetException("동일 데이터가 이력이 존재할때 발생"
                                    , row["WORK_ID"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.OVERWRITE_HISTORY, dtRslt.Rows[0]);

                            }
                            else
                            {
                                throw UTIL.SetException("동일 데이터가 존재할때 발생"
                                    , row["WORK_ID"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.OVERWRITE);
                            }
                        }
                    }
                    else
                    {
                        row["WORK_ID"] = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "WOR", UTIL.emSerialFormat.YYYYMMDD, "", bizExecute);
                        DSHP.TSHP_WORK_MNG.TSHP_WORK_MNG_INS(UTIL.GetRowToDt(row), bizExecute);
                    }
                }

                return WOR01A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet WOR01A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", "2", typeof(Byte));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtRslt = DSHP.TSHP_WORK_MNG.TSHP_WORK_MNG_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (dtRslt.Rows.Count > 0)
                    {
                        if (dtRslt.Rows[0]["REQ_STATUS"].ToString() != "0")
                        {
                            throw UTIL.SetException("승인 진행중일 경우 수정/삭제할 수 없습니다."
                            , row["WORK_ID"].ToString()
                            , new System.Diagnostics.StackFrame().GetMethod().Name
                            , BizException.ABORT);
                        }
                    }

                    DSHP.TSHP_WORK_MNG.TSHP_WORK_MNG_UDE(UTIL.GetRowToDt(row), bizExecute);
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