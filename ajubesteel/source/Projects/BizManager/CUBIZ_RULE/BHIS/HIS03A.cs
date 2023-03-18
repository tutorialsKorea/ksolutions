using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BHIS
{
    public class HIS03A
    {
        public static DataSet HIS03A_SER1(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "MC_GROUP", "MCT", typeof(string));

                DataTable dtRslt = DLSE.LSE_MACHINE_QUERY.LSE_MACHINE_QUERY5(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                //DataTable dtRslt = DHIS.THIS_PM_MC_QUERY.THIS_PM_MC_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                //DataTable linqRslt = dtRslt.AsEnumerable()
                //                            .GroupBy(g => new
                //                            {
                //                                PLT_CODE = g["PLT_CODE"],
                //                                MC_GROUP = g["MC_GROUP"],
                //                                MC_CODE = g["MC_CODE"],
                //                                MC_NAME = g["MC_NAME"],
                //                                MC_MAKER = g["MC_MAKER"],
                //                                SCOMMENT = g["M_SCOMMENT"]
                //                            })
                //                            .Select(r => new
                //                            {
                //                                PLT_CODE = r.Key.PLT_CODE,
                //                                MC_GROUP = r.Key.MC_GROUP,
                //                                MC_CODE = r.Key.MC_CODE,
                //                                MC_NAME = r.Key.MC_NAME,
                //                                MC_MAKER = r.Key.MC_MAKER,
                //                                SCOMMENT = r.Key.SCOMMENT,
                //                                SEL = 0
                //                            })
                //                            .LINQToDataTable();

                //linqRslt.TableName = "RSLTDT";

                //paramDS.Tables.Add(linqRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet HIS03A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DLSE.LSE_MACHINE_QUERY.LSE_MACHINE_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt.TableName = "RSLTDT";

                DataTable dtRsltAct = DHIS.THIS_PM_ACT_QUERY.THIS_PM_ACT_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                dtRsltAct.TableName = "RSLTDT_ACT";

                DataTable dtRsltPlan = DHIS.THIS_PM_PLAN_QUERY.THIS_PM_PLAN_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                dtRsltPlan.TableName = "RSLTDT_PLAN";

                // DataTable dtRsltIns = DHIS.THIS_INS_MC_QUERY.THIS_INS_MC_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                DataTable dtRsltIns = DHIS.THIS_INS_MC.THIS_INS_MC_SER2(paramDS.Tables["RQSTDT"], bizExecute);
                dtRsltIns.TableName = "RSLTDT_INS";

                paramDS.Tables.Add(dtRslt);
                paramDS.Tables.Add(dtRsltAct);
                paramDS.Tables.Add(dtRsltPlan);
                paramDS.Tables.Add(dtRsltIns);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static DataSet HIS03A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DHIS.THIS_PM_PLAN_PARTS_QUERY.THIS_PM_PLAN_PARTS_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static DataSet HIS03A_SER4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DHIS.THIS_INS_MC_PARTS_QUERY.THIS_PM_MC_PARTS_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static DataSet HIS03A_SER5(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DHIS.THIS_INS_MC.THIS_INS_MC_SER2(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }



        public static DataSet HIS03A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable resultTable = DHIS.THIS_PM_ACT_QUERY.THIS_PM_ACT_QUERY1(UTIL.GetRowToDt(row), bizExecute);
                    if (resultTable.Rows.Count > 0)
                    {
                        DHIS.THIS_PM_ACT.THIS_PM_ACT_DEL(UTIL.GetRowToDt(row), bizExecute);
                    }
                }
                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet HIS03A_DEL2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "IS_CANCEL_DEL", typeof(String));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable resultTable = DHIS.THIS_PM_PLAN.THIS_PM_PLAN_SER(UTIL.GetRowToDt(row), bizExecute);
                    
                    if (resultTable.Rows.Count > 0)
                    {
                        if (resultTable.AsEnumerable().Where(w => w["ACT_DATE"].isNullOrEmpty() == false).Any())
                        {
                            //실적이 존재한다.
                            row["IS_CANCEL_DEL"] = "1";
                        }
                        else
                        {
                            //DHIS.THIS_PM_ACT.THIS_PM_ACT_DEL(UTIL.GetRowToDt(row), bizExecute);
                            DHIS.THIS_PM_PLAN.THIS_PM_PLAN_DEL2(UTIL.GetRowToDt(row), bizExecute);
                        }
                    }
                }
                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        // 설비 정기점검 내역삭제
        public static DataSet HIS03A_DEL3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                 
                    DHIS.THIS_INS_MC.THIS_INS_MC_DEL2(UTIL.GetRowToDt(row), bizExecute);

                }
                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


       //설비정기점검 소요품목 제거 
        public static DataSet HIS03A_DEL4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {

                    DHIS.THIS_INS_MC_PARTS.THIS_INS_MC_PARTS_DEL(UTIL.GetRowToDt(row), bizExecute);

                }
                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        /// 계측기 지급,반환, 삭제 

        public static DataSet HIS03A_DEL5(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {

                    DHIS.THIS_MEASURE_HISTORY.THIS_MEASURE_HISTORY_DEL2(UTIL.GetRowToDt(row), bizExecute);

                }
                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        /// 검교정 삭제 

        public static DataSet HIS03A_DEL6(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {

                    DHIS.THIS_MEASURE_REPAIR.THIS_MEASURE_REPAIR_DEL(UTIL.GetRowToDt(row), bizExecute);
                }
                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }




        public static DataSet HIS03A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow paramRow in paramDS.Tables["RQSTDT"].Rows)
                {
                    if(paramRow["PM_ACT_CODE"].isNullOrEmpty())
                    {
                        paramRow["PM_ACT_CODE"] = UTIL.UTILITY_GET_SERIALNO(paramRow["PLT_CODE"].ToString(), "PM", UTIL.emSerialFormat.YYMM, "", bizExecute);
                    }

                    DataTable rsltDt = DHIS.THIS_PM_ACT_QUERY.THIS_PM_ACT_QUERY1(UTIL.GetRowToDt(paramRow), bizExecute);

                    if (rsltDt.Rows.Count > 0)
                    {
                        //업데이트
                        DHIS.THIS_PM_ACT.THIS_PM_ACT_UPD(UTIL.GetRowToDt(paramRow), bizExecute);
                    }
                    else
                    {
                        //입력
                        DHIS.THIS_PM_ACT.THIS_PM_ACT_INS(UTIL.GetRowToDt(paramRow), bizExecute);
                    }
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static DataSet HIS03A_INS2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow paramRow in paramDS.Tables["RQSTDT"].Rows)
                {
                    //실적입 업데이트
                    DHIS.THIS_PM_PLAN.THIS_PM_PLAN_UPD(UTIL.GetRowToDt(paramRow), bizExecute);

                    //실적테이블 업데이트
                    DataTable rsltDt = DHIS.THIS_PM_ACT_QUERY.THIS_PM_ACT_QUERY2(UTIL.GetRowToDt(paramRow), bizExecute);

                    if (rsltDt.Rows.Count > 0)
                    {
                        //업데이트
                        paramRow["PM_ACT_CODE"] = rsltDt.Rows[0]["PM_ACT_CODE"];

                        DHIS.THIS_PM_ACT.THIS_PM_ACT_UPD(UTIL.GetRowToDt(paramRow), bizExecute);
                    }
                    else
                    {
                        //입력
                        paramRow["PM_ACT_CODE"] = UTIL.UTILITY_GET_SERIALNO(paramRow["PLT_CODE"].ToString(), "PM", UTIL.emSerialFormat.YYMM, "", bizExecute);

                        DHIS.THIS_PM_ACT.THIS_PM_ACT_INS(UTIL.GetRowToDt(paramRow), bizExecute);
                    }
                }

                //foreach (DataRow paramRow in paramDS.Tables["RQSTDT_PARTS"].Rows)
                //{
                //    DHIS.THIS_PM_PLAN_PARTS.THIS_PM_PLAN_PARTS_UPD(UTIL.GetRowToDt(paramRow), bizExecute);
                //}

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        // 설비별 정기점검기록 등록 
        public static DataSet HIS03A_INS3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                string MRI_CODE = null;

                foreach (DataRow paramRow in paramDS.Tables["RQSTDT"].Rows)
                {
                    if (paramRow["MRI_CODE"].isNullOrEmpty())
                    {
                        paramRow["MRI_CODE"] = UTIL.UTILITY_GET_SERIALNO(paramRow["PLT_CODE"].ToString(), "MRI", UTIL.emSerialFormat.YYMM, "", bizExecute);

                        MRI_CODE = paramRow["MRI_CODE"].ToString();
                    }

                    // 정기점검테이블 조회할 것 
                    DataTable rsltDt = DHIS.THIS_INS_MC.THIS_INS_MC_SER(UTIL.GetRowToDt(paramRow), bizExecute);

                    if (rsltDt.Rows.Count > 0)
                    {
                        //업데이트
                        DHIS.THIS_INS_MC.THIS_INS_MC_UPD(UTIL.GetRowToDt(paramRow), bizExecute);
                    }
                    else
                    {
                        //입력
                        DHIS.THIS_INS_MC.THIS_INS_MC_INS(UTIL.GetRowToDt(paramRow), bizExecute);
                    }
                }

                return HIS03A_SER5(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

    }
}
