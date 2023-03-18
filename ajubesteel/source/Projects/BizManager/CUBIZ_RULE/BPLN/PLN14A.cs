using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;
using DAPS;

namespace BPLN
{
    public class PLN14A
    {
        public static DataSet PLN14A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
            UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "MC_GROUP", "", typeof(String));

            UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "S_WORK_DATE", "", typeof(String));
            UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "E_WORK_DATE", "", typeof(String));

            UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WO_START_DATETIME", "", typeof(String));
            UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WO_END_DATETIME", "", typeof(String));

            UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "S_HOLI_DATE", paramDS.Tables["RQSTDT"].Rows[0]["START_TIME"], typeof(String));
            UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "E_HOLI_DATE", paramDS.Tables["RQSTDT"].Rows[0]["END_TIME"], typeof(String));

            DataSet paramSetTotal = paramDS.Copy();

            DataSet dsResult = new DataSet();

            object S_WORK_DATE = paramDS.Tables["RQSTDT"].Rows[0]["START_TIME"];
            object E_WORK_DATE = paramDS.Tables["RQSTDT"].Rows[0]["END_TIME"];


            //설비그룹 설비리스트
            paramDS.Tables["RQSTDT"].Rows[0]["S_WORK_DATE"] = S_WORK_DATE;
            paramDS.Tables["RQSTDT"].Rows[0]["E_WORK_DATE"] = E_WORK_DATE;

            //간트 그리드 설비리스트 조회 조건 : 공정, 설비그룹
            DataTable dtMCSerRslt;
            if (paramDS.Tables["RQSTDT"].Rows[0]["PROC_CODE"].ToString() == "")
                dtMCSerRslt = DLSE.LSE_MACHINE_QUERY.LSE_MACHINE_QUERY5(UTIL.GetRowToDt(paramDS.Tables["RQSTDT"].Rows[0]), bizExecute);
            else
                dtMCSerRslt = DLSE.LSE_STD_AVAILMC_QUERY.LSE_STD_AVAILMC_QUERY3(UTIL.GetRowToDt(paramDS.Tables["RQSTDT"].Rows[0]), bizExecute);

            //비가동
            DataTable dtIDLSerRslt = DSHP.TSHP_IDLETIME_QUERY.TSHP_IDLETIME_QUERY3(UTIL.GetRowToDt(paramDS.Tables["RQSTDT"].Rows[0]), bizExecute);
            //불량
            //DataTable dtNGSerRslt = DSHP.TSHP_NG_QUERY.TSHP_NG_QUERY3(UTIL.GetRowToDt(paramDS.Tables["RQSTDT"].Rows[0]), bizExecute);

            //작업지시_작업일
            if (paramDS.Tables["RQSTDT"].Rows[0]["WO_START_DATE_TIME"].ToString() != "")
            {
                paramDS.Tables["RQSTDT"].Rows[0]["WO_START_DATETIME"] = paramDS.Tables["RQSTDT"].Rows[0]["WO_START_DATE_TIME"];
                paramDS.Tables["RQSTDT"].Rows[0]["WO_END_DATETIME"] = paramDS.Tables["RQSTDT"].Rows[0]["WO_END_DATE_TIME"];
            }

            paramDS.Tables["RQSTDT"].Rows[0]["S_WORK_DATE"] = DBNull.Value;
            paramDS.Tables["RQSTDT"].Rows[0]["E_WORK_DATE"] = DBNull.Value;
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(UTIL.GetRowToDt(paramDS.Tables["RQSTDT"].Rows[0]));

            UTIL.SetBizAddColumnToValue(paramSet.Tables["RQSTDT"], "FINISH_PLAN", "1", typeof(String));
            DataSet paramSetCTRL = new DataSet();
            paramSetCTRL = CTRL.CTRL.CONTROL_WORKORDER_SEARCH(paramSet, bizExecute);

            DataSet paramNoplan = new DataSet();

            paramNoplan.Tables.Add(UTIL.GetRowToDt(paramDS.Tables["RQSTDT"].Rows[0]));
            paramNoplan.Tables["RQSTDT"].Clear();


            UTIL.SetBizAddColumnToValue(paramNoplan.Tables["RQSTDT"], "PLT_CODE", paramDS.Tables["RQSTDT"].Rows[0]["PLT_CODE"].ToString(), typeof(String));
            UTIL.SetBizAddColumnToValue(paramNoplan.Tables["RQSTDT"], "MC_GRP", paramDS.Tables["RQSTDT"].Rows[0]["MC_GRP"].ToString(), typeof(String));
            UTIL.SetBizAddColumnToValue(paramNoplan.Tables["RQSTDT"], "NO_PLAN", "1", typeof(String));
            UTIL.SetBizAddColumnToValue(paramNoplan.Tables["RQSTDT"], "PLN_START_DATE", "", typeof(String));
            UTIL.SetBizAddColumnToValue(paramNoplan.Tables["RQSTDT"], "PLN_END_DATE", "", typeof(String));
            UTIL.SetBizAddColumnToValue(paramNoplan.Tables["RQSTDT"], "DATA_FLAG", "0", typeof(String));


            DataSet dsNoplan = new DataSet();
            dsNoplan = CTRL.CTRL.CONTROL_WORKORDER_SEARCH(paramNoplan, bizExecute);
            dsNoplan.Tables[0].TableName = "RSLTDT2";

            ////공정
            DataTable dtPCSerRslt = DLSE.LSE_STD_PROC_QUERY.LSE_STD_PROC_QUERY1(UTIL.GetRowToDt(paramDS.Tables["RQSTDT"].Rows[0]), bizExecute);

            DataSet dsAVSerRslt = new DataSet();
            foreach (DataRow row in dtPCSerRslt.Rows)
            {
                //가용설비
                DataTable dtAVSerRslt = DLSE.LSE_STD_AVAILMC.LSE_STD_AVAILMC_SER2(UTIL.GetRowToDt(row), bizExecute);

                dtAVSerRslt.TableName = "AVAILMC_INFO";
                //dsAVSerRslt.Merge(dtAVSerRslt);
                dsResult.Merge(dtAVSerRslt);
            }

            //HOLIDAYS
            DataTable dtHolidays = DLSE.LSE_HOLIDAY_QUERY.LSE_HOLIDAY_QUERY1(UTIL.GetRowToDt(paramDS.Tables["RQSTDT"].Rows[0]), bizExecute);
            dtHolidays.TableName = "HOLIDAYS";

            dtMCSerRslt.TableName = "MC_LIST";
            dtIDLSerRslt.TableName = "IDLE";
            ////dtNGSerRslt.TableName = "NG";
            dtPCSerRslt.TableName = "PROC_INFO";

            dsResult.Merge(paramSetCTRL);
            dsResult.Merge(dsNoplan);
            dsResult.Merge(dtMCSerRslt);
            dsResult.Merge(dtIDLSerRslt);
            ////dsResult.Merge(dtNGSerRslt);
            dsResult.Merge(dtPCSerRslt);
            dsResult.Merge(dtHolidays);

            //}
            paramSetTotal.Tables.Add(dsResult.Tables["RSLTDT"].Copy());
            paramSetTotal.Tables.Add(dsResult.Tables["RSLTDT2"].Copy());
            paramSetTotal.Tables.Add(dsResult.Tables["MC_LIST"].Copy());
            paramSetTotal.Tables.Add(dsResult.Tables["IDLE"].Copy());
            //paramSetTotal.Tables.Add(dsResult.Tables["NG"].Copy());
            paramSetTotal.Tables.Add(dsResult.Tables["PROC_INFO"].Copy());
            paramSetTotal.Tables.Add(dsResult.Tables["AVAILMC_INFO"].Copy());
            paramSetTotal.Tables.Add(dsResult.Tables["HOLIDAYS"].Copy());

            UTIL.SetBizAddColumnToValue(paramSetTotal.Tables["RSLTDT"], "SEL", "0", typeof(String));
            UTIL.SetBizAddColumnToValue(paramSetTotal.Tables["RSLTDT2"], "SEL", "0", typeof(String));

            return paramSetTotal;

        }

        public static DataSet PLN14A_SER_STD(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                //공정 정보
                //DataTable dtRslt_Proc = DLSE.LSE_STD_PROC_QUERY.LSE_STD_PROC_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);

                //dtRslt_Proc.Columns.Add("SEL", typeof(String));
                //dtRslt_Proc.Columns.Add("WO_FLAG", typeof(String));
                //dtRslt_Proc.Columns.Add("WP_NO", typeof(String));
                //dtRslt_Proc.Columns.Add("WO_NO", typeof(String));
                //dtRslt_Proc.Columns.Add("MC_CODE", typeof(String));
                //dtRslt_Proc.Columns.Add("EMP_CODE", typeof(String));
                //dtRslt_Proc.Columns.Add("PART_ID", typeof(Int32));
                //dtRslt_Proc.Columns.Add("PLN_QTY", typeof(Int32));
                ////UTIL.SetBizAddColumnToValue(dtRslt_Proc, "WO_FLAG", "0", typeof(String));                
                //UTIL.SetBizAddColumnToValue(dtRslt_Proc, "JOB_PRIORITY", "2", typeof(String));
                //dtRslt_Proc.TableName = "RSLTDT_PROC";

                //paramDS.Tables.Add(dtRslt_Proc);

                //설비 정보 key 공정+설비
                DataTable dtRslt_Mc = DLSE.LSE_STD_AVAILMC_QUERY.LSE_STD_AVAILMC_QUERY6(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt_Mc.Columns.Add("SEL", typeof(string));
                dtRslt_Mc.TableName = "RSLTDT_MC";

                paramDS.Tables.Add(dtRslt_Mc);

                //작업자  key 설비+작업자
                DataTable dtRslt_Emp = DSTD.TSTD_MC_AVAILEMP_QUERY.TSTD_MC_AVAILEMP_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt_Emp.Columns.Add("SEL", typeof(string));
                dtRslt_Emp.TableName = "RSLTDT_EMP";

                paramDS.Tables.Add(dtRslt_Emp);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static DataSet PLN14A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();
                dsResult = CTRL.CTRL.CONTROL_WORKORDER_SEARCH(paramDS, bizExecute);
                
                DataTable rsltDt = dsResult.Tables["RSLTDT"];
                
                DataTable sapDt = APS_STD_AVAILMC_PROD_QUERY.APS_STD_AVAILMC_PROD_QUERY1(rsltDt, bizExecute);

                if (!rsltDt.Columns.Contains("AVALIABLE_MC_LIST")) rsltDt.Columns.Add("AVALIABLE_MC_LIST", typeof(String));
                
                foreach(DataRow row in rsltDt.Rows)
                {
                    row["AVALIABLE_MC_LIST"] = String.Join(", ", sapDt.Select("PLT_CODE = '" + row["PLT_CODE"]
                                                                        + "' AND PROD_CODE = '" + row["PROD_CODE"]
                                                                        + "' AND PART_CODE = '" + row["PART_CODE"]
                                                                        + "' AND PROC_CODE = '" + row["PROC_CODE"] + "'")
                                                                      .Select(r => r["MC_NAME"].toStringEmpty())
                                                           );

                }

                return dsResult;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PLN14A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtParam = new DataTable("RQSTDT");
                dtParam.Columns.Add("PLT_CODE", typeof(String));
                dtParam.Columns.Add("MC_CODE", typeof(String));

                DataRow paramRow = dtParam.NewRow();
                paramRow["PLT_CODE"] = paramDS.Tables["RQSTDT"].Rows[0]["PLT_CODE"];
                paramRow["MC_CODE"] = paramDS.Tables["RQSTDT"].Rows[0]["MC_CODE"];
                dtParam.Rows.Add(paramRow);

                DataTable dtProc = DLSE.LSE_STD_AVAILMC.LSE_STD_AVAILMC_SER(dtParam, bizExecute);
                DataSet dsParam = new DataSet();
                dsParam.Tables.Add(dtProc);
                dtProc.TableName = "RQSTDT";

                //UTIL.SetBizAddColumnToValue(dtProc, "MC_CODE", "", typeof(String));
                UTIL.SetBizAddColumnToValue(dtProc, "NO_PLAN", "1", typeof(String));

                DataSet dsResult = CTRL.CTRL.CONTROL_WORKORDER_SEARCH(dsParam, bizExecute);

                return dsResult;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PLN14A_UPD(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(UTIL.GetRowToDt(row));

                    paramSet.Tables[0].Rows[0]["MC_CODE"] = "";

                    DataSet paramSetCTRL = new DataSet();
                    paramSetCTRL = CTRL.CTRL.CONTROL_WORKORDER_SEARCH(paramSet, bizExecute);

                    if (paramSetCTRL.Tables["RSLTDT"].Rows.Count == 0)
                    {
                        throw UTIL.SetException("이미 처리되거나 유효하지 않는 데이터입니다. 새로고침합니다."
                                  , new System.Diagnostics.StackFrame().GetMethod().Name
                                  , BizException.DATA_REFRESH);
                    }

                    if (paramSetCTRL.Tables["RSLTDT"].Rows[0]["WO_FLAG"].Equals("2") || paramSetCTRL.Tables["RSLTDT"].Rows[0]["WO_FLAG"].Equals("4"))
                    {
                        throw UTIL.SetException("이미 처리되거나 유효하지 않는 데이터입니다. 새로고침합니다."
                                  , new System.Diagnostics.StackFrame().GetMethod().Name
                                  , BizException.DATA_REFRESH);
                    }

                    //작업지시 업데이트
                    DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD12(UTIL.GetRowToDt(row), bizExecute);


                    dsResult.Merge(CTRL.CTRL.CONTROL_WORKORDER_SEARCH(paramSet, bizExecute));
                }

                return dsResult;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PLN14A_UPD_1(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(UTIL.GetRowToDt(row));

                    paramSet.Tables[0].Rows[0]["MC_CODE"] = "";

                    DataSet paramSetCTRL = new DataSet();
                    paramSetCTRL = CTRL.CTRL.CONTROL_WORKORDER_SEARCH(paramSet, bizExecute);

                    if (paramSetCTRL.Tables["RSLTDT"].Rows.Count == 0)
                    {
                        throw UTIL.SetException("이미 처리되거나 유효하지 않는 데이터입니다. 새로고침합니다."
                                  , new System.Diagnostics.StackFrame().GetMethod().Name
                                  , BizException.DATA_REFRESH);
                    }

                    if (paramSetCTRL.Tables["RSLTDT"].Rows[0]["WO_FLAG"].Equals("2") || paramSetCTRL.Tables["RSLTDT"].Rows[0]["WO_FLAG"].Equals("4"))
                    {
                        throw UTIL.SetException("이미 처리되거나 유효하지 않는 데이터입니다. 새로고침합니다."
                                  , new System.Diagnostics.StackFrame().GetMethod().Name
                                  , BizException.DATA_REFRESH);
                    }

                    //작업지시 업데이트
                    DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD12(UTIL.GetRowToDt(row), bizExecute);

                    //확정 및 확정 취소시 이력 저장
                    DSHP.TSHP_WORKORDER_HIS.TSHP_WORKORDER_HIS_INS(UTIL.GetRowToDt(row), bizExecute);

                    DataTable woAvailableProdDt = DAPS.APS_STD_AVAILMC_PROD_QUERY.APS_STD_AVAILMC_PROD_QUERY2(UTIL.GetRowToDt(row), bizExecute);

                    if (woAvailableProdDt.Rows.Count > 0)
                    {
                        DAPS.APS_STD_AVAILMC_PROD.APS_STD_AVAILMC_PROD_DEL3(UTIL.GetRowToDt(row), bizExecute);

                        DataRow mcAPRow = woAvailableProdDt.Rows[0];
                        mcAPRow["MC_CODE"] = row["MC_CODE"];

                        DAPS.APS_STD_AVAILMC_PROD.APS_STD_AVAILMC_PROD_INS(UTIL.GetRowToDt(mcAPRow), bizExecute);
                    }

                    dsResult.Merge(CTRL.CTRL.CONTROL_WORKORDER_SEARCH(paramSet, bizExecute));
                }

                return dsResult;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PLN14A_UPD2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataSet paramSet = new DataSet();
                    paramSet.Tables.Add(UTIL.GetRowToDt(row));

                    DataSet paramSetCTRL = new DataSet();
                    DataTable param = new DataTable();
                    //paramSetCTRL = CTRL.CTRL.CONTROL_WORKORDER_SEARCH(paramSet, bizExecute);
                    param = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER(paramSet.Tables["RQSTDT"], bizExecute);

                    if (param.Rows.Count == 0)
                    {
                        throw UTIL.SetException("이미 처리되거나 유효하지 않는 데이터입니다. 새로고침합니다."
                                  , new System.Diagnostics.StackFrame().GetMethod().Name
                                  , BizException.DATA_REFRESH);
                    }

                    if (param.Rows[0]["WO_FLAG"].Equals("2") || param.Rows[0]["WO_FLAG"].Equals("4"))
                    {
                        throw UTIL.SetException("이미 처리되거나 유효하지 않는 데이터입니다. 새로고침합니다."
                                  , new System.Diagnostics.StackFrame().GetMethod().Name
                                  , BizException.DATA_REFRESH);
                    }

                    //작업지시 업데이트
                    DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD14(UTIL.GetRowToDt(row), bizExecute);

                    dsResult.Merge(CTRL.CTRL.CONTROL_WORKORDER_SEARCH(paramSet, bizExecute));
                }

                return dsResult;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PLN14A_UPD3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    //계획 고정
                    DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD28(UTIL.GetRowToDt(row), bizExecute);
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PLN14A_APS_EXE_VER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //스케쥴러 상태 확인
                DataTable dtExeLog = DAPS.APS_EXE.APS_EXE_SER(UTIL.GetRowToDt(paramDS.Tables["RQSTDT"].Rows[0]), bizExecute);

                //if (dtExeLog.Rows.Count > 0)
                //{
                //    switch (dtExeLog.Rows[0]["SCH_STATE"].ToString())
                //    {
                //        case "W":
                //            throw UTIL.SetException("스케쥴러 데이터 생성 중입니다.");
                //            break;
                //        case "R":
                //            throw UTIL.SetException("스케쥴러가 이미 실행 중입니다.");
                //            break;
                //        case "C":
                //            throw UTIL.SetException("스케쥴러가 종료 되었습니다.\n일정수립 대상 조회를 다시 시도해 주세요.");
                //            break;
                //    }
                //}

                dtExeLog.TableName = "RSLTDT";

                paramDS.Tables.Add(dtExeLog);
                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PLN14A_APS_EXE_VER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //DataTable dtRslt = DAPS.APS_EXE_QUERY.APS_EXE_QUERY1(UTIL.GetRowToDt(paramDS.Tables["RQSTDT"].Rows[0]), bizExecute);
                DataTable dtRslt = DAPS.APS_EXE_QUERY.APS_EXE_QUERY2(UTIL.GetRowToDt(paramDS.Tables["RQSTDT"].Rows[0]), bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);
                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PLN14A_APS_EXE(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //스케쥴러 상태 확인
                DataTable dtExeLog = DAPS.APS_EXE.APS_EXE_SER(UTIL.GetRowToDt(paramDS.Tables["RQSTDT"].Rows[0]), bizExecute);

                if (dtExeLog.Rows.Count > 0)
                {
                    //스케쥴러 상태가 대기여야 가능
                    if (dtExeLog.Rows[0]["SCH_STATE"].Equals("W")
                        || dtExeLog.Rows[0]["SCH_STATE"].Equals("R"))
                    {
                        throw UTIL.SetException("스케쥴러가 이미 실행 중입니다..");
                    }
                }

                //프로시저 호출
                DAPS.APS_EXE.APS_EXE_INS(paramDS.Tables["RQSTDT"], bizExecute);


                DataTable dtExeLog2 = DAPS.APS_EXE.APS_EXE_SER(UTIL.GetRowToDt(paramDS.Tables["RQSTDT"].Rows[0]), bizExecute);
                dtExeLog2.TableName = "RSLTDT_EXE";

                if (dtExeLog2.Rows.Count > 0)
                {
                    //스케쥴러 상태가 대기여야 가능
                    if (dtExeLog.Rows[0]["SCH_STATE"].Equals("E"))
                    {
                        throw UTIL.SetException("일정수립에 오류가 발생했습니다.\n" + dtExeLog.Rows[0]["ERROR_MSG"].ToString());
                    }
                }

                //스케쥴 프로시저 종료 후 Demand 결과
                DataTable dtRslt = DAPS.APS_PART_QUERY.APS_PART_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt.Columns.Add("SEL");
                dtRslt.TableName = "RSLTDT";

                //Wip
                DataTable dtRsltWip = DAPS.APS_PART_QUERY.APS_PART_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
                dtRsltWip.TableName = "RSLTDT_WIP";
                //Material
                DataTable dtRsltMat = DAPS.APS_PART_QUERY.APS_PART_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);
                dtRsltMat.TableName = "RSLTDT_MAT";
                //PresetInfo
                DataTable dtRsltPre = DAPS.APS_PART_QUERY.APS_PART_QUERY4(paramDS.Tables["RQSTDT"], bizExecute);
                dtRsltPre.TableName = "RSLTDT_PRE";
                //Replenish
                DataTable dtRsltRep = DAPS.APS_PART_QUERY.APS_PART_QUERY5(paramDS.Tables["RQSTDT"], bizExecute);
                dtRsltRep.TableName = "RSLTDT_REP";





                paramDS.Tables.Add(dtRslt);
                paramDS.Tables.Add(dtRsltWip);
                paramDS.Tables.Add(dtRsltMat);
                paramDS.Tables.Add(dtRsltRep);
                paramDS.Tables.Add(dtRsltPre);
                paramDS.Tables.Add(dtExeLog2);


                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PLN14A_APS_RESULT(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt1 = DAPS.APS_PLAN_QUERY.APS_PLAN_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt1.TableName = "MC_LIST";

                //DataTable dtRslt2 = DAPS.APS_PLAN.APS_PLAN_SER(paramDS.Tables["RQSTDT"], bizExecute);
                DataTable dtRslt2 = DAPS.APS_PLAN_QUERY.APS_PLAN_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);
                //2020-11-16 홍건웅 이사 요청 초기 체크 해제
                UTIL.SetBizAddColumnToValue(dtRslt2, "SEL", "0", typeof(String));
                dtRslt2.TableName = "RSLTDT";

                DataTable dtRslt3 = DAPS.APS_PLAN_QUERY.APS_PLAN_QUERY4(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt3.TableName = "PR_LIST";

                DataTable dtRslt4 = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY17(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt4.TableName = "RSLTDT_WO";

                DataTable dtRslt_VER = DAPS.APS_EXE_QUERY.APS_EXE_QUERY2(UTIL.GetRowToDt(paramDS.Tables["RQSTDT"].Rows[0]), bizExecute);
                DataTable dtRslt5 = DAPS.APS_STD_ERROR_QUERY.APS_STD_ERROR_QUERY1(dtRslt_VER, bizExecute);
                dtRslt5.TableName = "RSLTDT_ERR";
                paramDS.Tables.Add(dtRslt5);

                DateTime minPlanST = Convert.ToDateTime(dtRslt2.Compute("min([PLN_START_TIME])", string.Empty).toDateTime());
                DateTime maxPlanED = Convert.ToDateTime(dtRslt2.Compute("max([PLN_END_TIME])", string.Empty).toDateTime());
                DateTime minActST = Convert.ToDateTime(dtRslt2.Compute("min([ACT_START_TIME])", string.Empty).toDateTime());
                DateTime maxActED = Convert.ToDateTime(dtRslt2.Compute("max([ACT_END_TIME])", string.Empty).toDateTime());

                String sST = minPlanST.toDateString("yyyyMMdd");
                String sEN = maxPlanED.toDateString("yyyyMMdd");

                //if (minPlanST > minActST)
                //{
                //    sST = minActST.toDateString("yyyyMMdd");
                //}
                //if (minActST < maxActED)
                //{
                //    sEN = maxActED.toDateString("yyyyMMdd");
                //}

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "S_HOLI_DATE", sST, typeof(String));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "E_HOLI_DATE", sEN, typeof(String));

                //HOLIDAYS
                DataTable dtHolidays = DLSE.LSE_HOLIDAY_QUERY.LSE_HOLIDAY_QUERY1(UTIL.GetRowToDt(paramDS.Tables["RQSTDT"].Rows[0]), bizExecute);
                dtHolidays.TableName = "HOLIDAYS";


                //진행중이거나 중지인것
                DataTable dtRslt6 = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY23(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt6.TableName = "RSLTDT_WO_ACT_ING";

                paramDS.Tables.Add(dtRslt1);
                paramDS.Tables.Add(dtRslt2);
                paramDS.Tables.Add(dtRslt3);
                paramDS.Tables.Add(dtRslt4);
                paramDS.Tables.Add(dtHolidays);
                paramDS.Tables.Add(dtRslt6);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        //TODO : APS 계획 저장
        public static DataSet PLN14A_APS_SAVE(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "IS_SAVE", "0");
                foreach(DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable woTable = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY16(UTIL.GetRowToDt(row), bizExecute);
                    if (woTable.Rows.Count > 0)
                    {
                        foreach (DataRow woRow in woTable.Rows)
                        {
                            if (woRow["WO_FLAG"].Equals("0") || woRow["WO_FLAG"].Equals("1"))
                            {
                                //이력 남기기 위해 이전 데이터 전부 저장
                                DSHP.TSHP_WORKORDER.TSHP_WORKORDER_COPY(UTIL.GetRowToDt(row), bizExecute);
                                DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD27(UTIL.GetRowToDt(row), bizExecute);
                                row["IS_SAVE"] = "1";
                            }
                        }
                    }
                    else
                    {
                        //workorder가 존재하지 않음
                        //가상부품일 확률이 존재하기 때문에 가상부품인지 확인하는 작업이 필요함
                        if(row["PART_CODE"].ToString().Contains("_"+row["PROC_CODE"].ToString()))
                        {
                            //해당 조립공정

                            //조립공정코드 제거
                            string partCode = row["PART_CODE"].ToString().Replace("_" + row["PROC_CODE"].ToString(),"");

                            DataTable rowCloneTable = UTIL.GetRowToDt(row);
                            
                            foreach(DataRow assyRow in rowCloneTable.Rows)
                            {
                                assyRow["PART_CODE"] = partCode;
                            }

                            DataTable woAssyTable = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY16(rowCloneTable, bizExecute);

                            if (woAssyTable.Rows.Count > 0)
                            {
                                foreach (DataRow woAssyRow in woAssyTable.Rows)
                                {
                                    if (woAssyRow["WO_FLAG"].Equals("0") || woAssyRow["WO_FLAG"].Equals("1"))
                                    {
                                        //이력 남기기 위해 이전 데이터 전부 저장
                                        DSHP.TSHP_WORKORDER.TSHP_WORKORDER_COPY(rowCloneTable, bizExecute);
                                        DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD27(rowCloneTable, bizExecute);
                                        row["IS_SAVE"] = "1";
                                    }
                                }
                            }
                        }
                        else
                        {
                            //가상부품이 다른 조립공정을 탈때
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

        public static DataSet PLN14A_APS_SAVE2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DAPS.APS_PART.APS_PART_UPD2(paramDS.Tables["RQSTDT"], bizExecute);
               
                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
    }
}
