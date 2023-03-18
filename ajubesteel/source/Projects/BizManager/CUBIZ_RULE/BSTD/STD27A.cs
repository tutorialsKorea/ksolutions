using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BSTD
{
    public class STD27A
    {
        /// <summary>
        /// 기준 임률 추가
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet STD27A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {

                    DataTable dtRslt = DCST.TCST_UNIT_COST_MASTER.TCST_UNIT_COST_MASTER_SER(UTIL.GetRowToDt(row), bizExecute);

                    //데이터가 있으면 삭제여부 및 덮어쓰기 여부에 따라 update
                    if (dtRslt.Rows.Count > 0)
                    {

                        if (row["OVERWRITE"].Equals("1"))
                        {
                            DCST.TCST_UNIT_COST_MASTER.TCST_UNIT_COST_MASTER_UPD(UTIL.GetRowToDt(row), bizExecute);
                        }
                        else
                        {
                            if (dtRslt.Rows[0]["DATA_FLAG"].Equals((byte)2))
                            {

                                throw UTIL.SetException("동일 데이터가 이력이 존재할때 발생"
                                    , row["UTC_CODE"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.OVERWRITE_HISTORY, dtRslt.Rows[0]);

                            }
                            else
                            {
                                throw UTIL.SetException("동일 데이터가 존재할때 발생"
                                    , row["UTC_CODE"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.OVERWRITE);
                            }
                        }
                    }
                    else
                    {

                        DCST.TCST_UNIT_COST_MASTER.TCST_UNIT_COST_MASTER_INS(UTIL.GetRowToDt(row), bizExecute);
                    }

                }

                return STD27A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        /// <summary>
        /// 기준 임률 추가 - 디테일
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet STD27A_INS2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //1. 적용일 중첩되는지 확인
                //2. 동일 데이터 체크
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "UTC_DATE", "", typeof(String));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "MDFY_EMP", 0, typeof(String));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtRslt = DCST.TCST_UNIT_COST_DETAIL.TCST_UNIT_COST_DETAIL_SER(UTIL.GetRowToDt(row), bizExecute);

                    //데이터가 있으면 삭제여부 및 덮어쓰기 여부에 따라 update
                    if (dtRslt.Rows.Count > 0)
                    {

                        if (row["OVERWRITE"].Equals("1"))
                        {
                            row["MDFY_EMP"] = row["REG_EMP"];

                            DCST.TCST_UNIT_COST_DETAIL.TCST_UNIT_COST_DETAIL_UPD(UTIL.GetRowToDt(row), bizExecute);
                        }
                        else
                        {
                            if (dtRslt.Rows[0]["DATA_FLAG"].Equals((byte)2))
                            {

                                throw UTIL.SetException("동일 데이터가 이력이 존재할때 발생"
                                    , row["UCD_ID"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.OVERWRITE_HISTORY, dtRslt.Rows[0]);

                            }
                            else
                            {
                                throw UTIL.SetException("동일 데이터가 존재할때 발생"
                                    , row["UCD_ID"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.OVERWRITE);
                            }
                        }
                    }
                    else
                    {

                        //1-1. 시작일자 중첩 확인
                        row["UTC_DATE"] = row["UTC_START"];

                        DataTable dtDetailRslt = DCST.TCST_UNIT_COST_DETAIL_QUERY.TCST_UNIT_COST_DETAIL_QUERY2(UTIL.GetRowToDt(row), bizExecute);

                        //데이터가 있으면 시작날짜 중첩
                        if (dtDetailRslt.Rows.Count > 0)
                        {
                            throw UTIL.SetException("시작일자 중첩"
                                            , row["UTC_CODE"].ToString()
                                            , new System.Diagnostics.StackFrame().GetMethod().Name
                                            , 200100);
                        }

                        //1-2. 완료일자 중첩 확인
                        row["UTC_DATE"] = row["UTC_END"];

                        dtDetailRslt = DCST.TCST_UNIT_COST_DETAIL_QUERY.TCST_UNIT_COST_DETAIL_QUERY2(UTIL.GetRowToDt(row), bizExecute);

                        //데이터가 있으면 시작날짜 중첩
                        if (dtDetailRslt.Rows.Count > 0)
                        {
                            throw UTIL.SetException("시작일자 중첩"
                                            , row["UTC_CODE"].ToString()
                                            , new System.Diagnostics.StackFrame().GetMethod().Name
                                            , 200100);
                        }



                        string serialNo = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "UCD", bizExecute);
                        row["UCD_ID"] = serialNo;

                        DCST.TCST_UNIT_COST_DETAIL.TCST_UNIT_COST_DETAIL_INS(UTIL.GetRowToDt(row), bizExecute);
                    }

                }

                return STD27A_SER2(paramDS, bizExecute);

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 특정일 임률 추가
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet STD27A_INS3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtRslt = DCST.TCST_UNIT_COST_DATE.TCST_UNIT_COST_DATE_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (object.Equals(paramDS.Tables["OPT"].Rows[0]["CREATE_TYPE"], "ADD"))
                    {
                        DataTable dtRsltOPT = DCST.TCST_UNIT_COST_MASTER_QUERY.TCST_UNIT_COST_MASTER_QUERY3(UTIL.GetRowToDt(row), bizExecute);

                        string week = CTRL.CTRL.GetDateStringWeek(row["UTC_DATE"].ToString(), bizExecute);

                        decimal man = 0;
                        decimal self = 0;
                        decimal ot = 0;

                        decimal addCostPercent = ((decimal)paramDS.Tables["OPT"].Rows[0]["ADD_COST_PERCENT"] / 100);

                        switch (week)
                        {
                            case "Monday":
                                man = (decimal)dtRsltOPT.Rows[0]["NOW_MON_MAN"];
                                self = (decimal)dtRsltOPT.Rows[0]["NOW_MON_SELF"];
                                ot = (decimal)dtRsltOPT.Rows[0]["NOW_MON_OT"];

                                break;

                            case "Tuesday":
                                man = (decimal)dtRsltOPT.Rows[0]["NOW_TUE_MAN"];
                                self = (decimal)dtRsltOPT.Rows[0]["NOW_TUE_SELF"];
                                ot = (decimal)dtRsltOPT.Rows[0]["NOW_TUE_OT"];

                                break;

                            case "Wednesday":
                                man = (decimal)dtRsltOPT.Rows[0]["NOW_WED_MAN"];
                                self = (decimal)dtRsltOPT.Rows[0]["NOW_WED_SELF"];
                                ot = (decimal)dtRsltOPT.Rows[0]["NOW_WED_OT"];
                                break;


                            case "Thursday":
                                man = (decimal)dtRsltOPT.Rows[0]["NOW_THR_MAN"];
                                self = (decimal)dtRsltOPT.Rows[0]["NOW_THR_SELF"];
                                ot = (decimal)dtRsltOPT.Rows[0]["NOW_THR_OT"];

                                break;

                            case "Friday":
                                man = (decimal)dtRsltOPT.Rows[0]["NOW_FRI_MAN"];
                                self = (decimal)dtRsltOPT.Rows[0]["NOW_FRI_SELF"];
                                ot = (decimal)dtRsltOPT.Rows[0]["NOW_FRI_OT"];

                                break;

                            case "Saturday":
                                man = (decimal)dtRsltOPT.Rows[0]["NOW_SAT_MAN"];
                                self = (decimal)dtRsltOPT.Rows[0]["NOW_SAT_SELF"];
                                ot = (decimal)dtRsltOPT.Rows[0]["NOW_SAT_OT"];

                                break;


                            case "Sunday":
                                man = (decimal)dtRsltOPT.Rows[0]["NOW_SUN_MAN"];
                                self = (decimal)dtRsltOPT.Rows[0]["NOW_SUN_SELF"];
                                ot = (decimal)dtRsltOPT.Rows[0]["NOW_SUN_OT"];

                                break;

                        }


                        decimal addCostMan = man * addCostPercent;
                        decimal addCostSelf = self * addCostPercent;
                        decimal addCostOt = ot * addCostPercent;

                        paramDS.Tables["RQSTDT"].Rows[0]["MAN"] = man + addCostMan;
                        paramDS.Tables["RQSTDT"].Rows[0]["SELF"] = self + addCostSelf;
                        paramDS.Tables["RQSTDT"].Rows[0]["OT"] = ot + addCostOt;

                    }   

                    if (dtRslt.Rows.Count > 0)
                    {                        
                        if (row["OVERWRITE"].Equals("1"))
                        {
                            DCST.TCST_UNIT_COST_DATE.TCST_UNIT_COST_DATE_UPD(UTIL.GetRowToDt(row), bizExecute);
                        }
                        else
                        {
                            if (dtRslt.Rows[0]["DATA_FLAG"].Equals((byte)2))
                            {

                                throw UTIL.SetException("동일 데이터가 이력이 존재할때 발생"
                                    , row["UTC_CODE"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.OVERWRITE_HISTORY, dtRslt.Rows[0]);

                            }
                            else
                            {
                                throw UTIL.SetException("동일 데이터가 존재할때 발생"
                                    , row["UTC_CODE"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.OVERWRITE);
                            }
                        }
                    }
                    else
                    {

                        DCST.TCST_UNIT_COST_DATE.TCST_UNIT_COST_DATE_INS(UTIL.GetRowToDt(row), bizExecute);
                    }

                }

                return STD27A_SER5(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        /// <summary>
        /// 특정일 임률 수정
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet STD27A_INS4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DCST.TCST_UNIT_COST_DATE.TCST_UNIT_COST_DATE_UPD2(UTIL.GetRowToDt(row), bizExecute);
                }

                return STD27A_SER3(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }



        /// <summary>
        /// 기본 임률  조회
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet STD27A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte)); // VAR에 DATA_FLAG값 0 설정

                DataTable dtRslt = DCST.TCST_UNIT_COST_MASTER_QUERY.TCST_UNIT_COST_MASTER_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.Columns.Add("SEL", typeof(string));
                dtRslt.TableName = "RSLTDT";

                foreach (DataRow r in dtRslt.Rows)
                {
                    r["SEL"] = "0";
                }

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 기본 임률  조회 - 디테일
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet STD27A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte)); // VAR에 DATA_FLAG값 0 설정

                DataTable dtRslt = DCST.TCST_UNIT_COST_DETAIL_QUERY.TCST_UNIT_COST_DETAIL_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.Columns.Add("SEL", typeof(string));
                dtRslt.TableName = "RSLTDT";

                foreach (DataRow r in dtRslt.Rows)
                {
                    r["SEL"] = "0";
                }

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 특정일 임률 조회
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet STD27A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte)); // VAR에 DATA_FLAG값 0 설정

                DataTable dtRslt = DCST.TCST_UNIT_COST_DATE_QUERY.TCST_UNIT_COST_DATE_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.Columns.Add("SEL", typeof(string));
                dtRslt.TableName = "RSLTDT";

                foreach (DataRow r in dtRslt.Rows)
                {
                    r["SEL"] = "0";
                }

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 특정일 임률 조회 - 팝업
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet STD27A_SER4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte)); // VAR에 DATA_FLAG값 0 설정

                DataTable dtRslt = DCST.TCST_UNIT_COST_MASTER_QUERY.TCST_UNIT_COST_MASTER_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.Columns.Add("SEL", typeof(string));
                dtRslt.TableName = "RSLTDT";

                foreach (DataRow r in dtRslt.Rows)
                {
                    r["SEL"] = "0";
                }

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 특정일 임률 조회-생성 후 조회
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet STD27A_SER5(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte)); // VAR에 DATA_FLAG값 0 설정

                DataTable dtRslt = DCST.TCST_UNIT_COST_DATE_QUERY.TCST_UNIT_COST_DATE_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.Columns.Add("SEL", typeof(string));
                dtRslt.TableName = "RSLTDT";

                foreach (DataRow r in dtRslt.Rows)
                {
                    r["SEL"] = "0";
                }

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 임률 삭제
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet STD27A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DCST.TCST_UNIT_COST_MASTER.TCST_UNIT_COST_MASTER_UDE(paramDS.Tables["RQSTDT"], bizExecute);
                return paramDS;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        /// <summary>
        /// 임률 삭제 - 디테일
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet STD27A_DEL2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DCST.TCST_UNIT_COST_DETAIL.TCST_UNIT_COST_DETAIL_UDE(paramDS.Tables["RQSTDT"], bizExecute);
                return paramDS;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        /// <summary>
        /// 특정일 임률 삭제
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet STD27A_DEL3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DCST.TCST_UNIT_COST_DATE.TCST_UNIT_COST_DATE_UDE(paramDS.Tables["RQSTDT"], bizExecute);
                return paramDS;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

    }
}
