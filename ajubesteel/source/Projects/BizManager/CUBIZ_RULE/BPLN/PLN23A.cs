using BizExecute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPLN
{
    public class PLN23A
    {
        public static DataSet PLN23A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                //DataTable dtRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY31(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable dtRslt = DSHP.TSHP_NG_QUERY.TSHP_NG_QUERY7(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.Columns.Add("SEL", typeof(string));

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static DataSet PLN23A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(byte), true);
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "IS_NG_REWORK", 1, typeof(byte), true);
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "RE_WO_NO", "", typeof(String), true);

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    ////해당 가공품에 작업지시 리스트를 가져옴
                    //DataTable dtWoRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY32_2(UTIL.GetRowToDt(row), bizExecute);

                    ////표준공정
                    //DataTable dtProcRslt = DLSE.LSE_STD_PROC_QUERY.LSE_STD_PROC_QUERY1(UTIL.GetRowToDt(row), bizExecute);

                    ////작업지시 리스트가 있을경우 재작업지시번호 생성
                    //string reWoNo = "";

                    //if (dtWoRslt.Rows.Count > 0)
                    //{
                    //    reWoNo = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "RW", UTIL.emSerialFormat.YYYYMMDD, "W", bizExecute);
                    //}

                    ////공정ID
                    //int procID = 0;

                    ////이전공정의 완료시간이 다음공정의 시작시간으로 함
                    ////공정의 시작시간
                    //DateTime nextStartTime = row["PLAN_DATE"].toDateTime();

                    ////공정리스트 재작업지시를 생성함
                    //foreach (DataRow rw in dtWoRslt.Rows)
                    //{
                    //    //공정 기준정보에서 작지타입, 공수를 가져옴
                    //    DataRow[] procs = dtProcRslt.Select("PROC_CODE = '" + rw["PROC_CODE"].ToString() + "'");

                    //    int procTime = 0;
                    //    int procManTime = 0;
                    //    int procSelfTime = 0;
                    //    if (procs.Length == 1)
                    //    {
                    //        //설계공정(DES)일 경우 넘어감
                    //        if (procs[0]["WO_TYPE"].ToString() == "DES")
                    //        {
                    //            continue;
                    //        }

                    //        if (row["NG_TYPE"].ToString() == "P")
                    //        {
                    //            if (procs[0]["WO_TYPE"].ToString() == "MIL")
                    //            {
                    //                continue;
                    //            }
                    //        }

                    //        //공정공수
                    //        procTime = procs[0]["PROC_SELF_TIME"].toInt() + procs[0]["PROC_MAN_TIME"].toInt();
                    //        procManTime = procs[0]["PROC_MAN_TIME"].toInt();
                    //        procSelfTime = procs[0]["PROC_SELF_TIME"].toInt();
                    //    }

                    //    DataTable paramTable = new DataTable("RQSTDT");
                    //    paramTable.Columns.Add("PLT_CODE", typeof(string));
                    //    paramTable.Columns.Add("WO_NO", typeof(string));
                    //    paramTable.Columns.Add("PT_ID", typeof(string));
                    //    paramTable.Columns.Add("PROD_CODE", typeof(string));
                    //    paramTable.Columns.Add("PART_CODE", typeof(string));
                    //    paramTable.Columns.Add("PART_ID", typeof(int));
                    //    paramTable.Columns.Add("PROC_CODE", typeof(string));
                    //    paramTable.Columns.Add("PROC_ID", typeof(int));
                    //    paramTable.Columns.Add("MC_GROUP", typeof(string));
                    //    paramTable.Columns.Add("PLN_PROC_TIME", typeof(decimal));
                    //    paramTable.Columns.Add("PLN_PROC_SELF_TIME", typeof(decimal));
                    //    paramTable.Columns.Add("PLN_PROC_MAN_TIME", typeof(decimal));
                    //    paramTable.Columns.Add("PART_QTY", typeof(int));
                    //    paramTable.Columns.Add("PLN_START_TIME", typeof(string));
                    //    paramTable.Columns.Add("PLN_END_TIME", typeof(string));
                    //    paramTable.Columns.Add("WO_FLAG", typeof(string));
                    //    paramTable.Columns.Add("ACT_QTY", typeof(int));
                    //    paramTable.Columns.Add("FNS_QTY", typeof(int));
                    //    paramTable.Columns.Add("NG_QTY", typeof(int));
                    //    paramTable.Columns.Add("WO_TYPE", typeof(string));
                    //    paramTable.Columns.Add("JOB_PRIORITY", typeof(string));
                    //    paramTable.Columns.Add("ACT_INPUT_TYPE", typeof(string));
                    //    paramTable.Columns.Add("O_WO_NO", typeof(string));
                    //    paramTable.Columns.Add("RE_WO_NO", typeof(string));
                    //    paramTable.Columns.Add("CAM_EMP", typeof(string));
                    //    paramTable.Columns.Add("CAM_EMP_DATE", typeof(string));

                    //    string woNo = UTIL.UTILITY_GET_SERIALNO(rw["PLT_CODE"].ToString(), "W", UTIL.emSerialFormat.YYYYMMDD, "W", bizExecute);

                    //    DataRow paramRow = paramTable.NewRow();
                    //    paramRow["PLT_CODE"] = rw["PLT_CODE"];
                    //    paramRow["WO_NO"] = woNo;
                    //    paramRow["PT_ID"] = rw["PT_ID"];
                    //    paramRow["PROD_CODE"] = rw["PROD_CODE"];
                    //    paramRow["PART_CODE"] = rw["PART_CODE"];
                    //    paramRow["PART_ID"] = rw["PART_ID"];
                    //    paramRow["PROC_CODE"] = rw["PROC_CODE"];
                    //    paramRow["PROC_ID"] = procID;
                    //    paramRow["MC_GROUP"] = rw["MC_GROUP"];
                    //    paramRow["PLN_PROC_TIME"] = procTime;
                    //    paramRow["PLN_PROC_SELF_TIME"] = procSelfTime;
                    //    paramRow["PLN_PROC_MAN_TIME"] = procManTime;
                    //    paramRow["PART_QTY"] = row["PLAN_QTY"];
                    //    paramRow["PLN_START_TIME"] = nextStartTime.ToString("yyyyMMddHHmm");
                    //    paramRow["PLN_END_TIME"] = nextStartTime.AddMinutes(procTime).ToString("yyyyMMddHHmm");
                    //    paramRow["WO_FLAG"] = "1"; //확정상태로 작지를 내림
                    //    paramRow["ACT_QTY"] = 0;
                    //    paramRow["FNS_QTY"] = 0;
                    //    paramRow["NG_QTY"] = 0;
                    //    paramRow["WO_TYPE"] = rw["WO_TYPE"];
                    //    paramRow["JOB_PRIORITY"] = rw["JOB_PRIORITY"];
                    //    paramRow["ACT_INPUT_TYPE"] = rw["ACT_INPUT_TYPE"];
                    //    paramRow["O_WO_NO"] = rw["WO_NO"];
                    //    paramRow["RE_WO_NO"] = reWoNo;
                    //    paramRow["CAM_EMP"] = rw["CAM_EMP"];
                    //    if (!rw["CAM_EMP"].isNullOrEmpty())
                    //    {
                    //        paramRow["CAM_EMP_DATE"] = DateTime.Now.ToString("yyyyMMdd");
                    //    }

                    //    paramTable.Rows.Add(paramRow);

                    //    DSHP.TSHP_WORKORDER.TSHP_WORKORDER_INS(paramTable, bizExecute);

                    //    //다음공정 시작시간은 현재공정의 완료시간으로 설정
                    //    nextStartTime = nextStartTime.AddMinutes(procTime);

                    //    procID++;
                    //}

                    //작업지시 리스트가 있을경우 재작업지시번호 생성
                    string reWoNo = "";

                    reWoNo = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "RW", UTIL.emSerialFormat.YYYYMMDD, "W", bizExecute);

                    DataTable woDt = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (woDt.Rows.Count == 1)
                    {
                        DataTable stopWodt = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER1_1(woDt, bizExecute);

                        foreach (DataRow rw in stopWodt.Rows)
                        {
                            DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UDE(UTIL.GetRowToDt(rw), bizExecute);
                        }
                    }


                    SetWorkOrderCreate(row, reWoNo, bizExecute);

                    row["RE_WO_NO"] = reWoNo;
                    DSHP.TSHP_NG.TSHP_NG_UPD4(UTIL.GetRowToDt(row), bizExecute);
                }

                return PLN23A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        private static void SetWorkOrderCreate(DataRow row, String reWoNo, BizExecute.BizExecute bizExecute)
        {
            DataTable dtSerProd = DORD.TORD_PRODUCT.TORD_PRODUCT_SER(UTIL.GetRowToDt(row), bizExecute);

            if (dtSerProd.Rows.Count == 0)
                throw UTIL.SetException("수주 정보가 없습니다."
                          , new System.Diagnostics.StackFrame().GetMethod().Name
                          , BizException.ABORT);

            string day_close = UTIL.GetConfValue("DAY_CLOSE_TIME", bizExecute);

            DataTable dtParam = new DataTable("RQSTDT");

            UTIL.SetBizAddColumnToValue(dtParam, "PLT_CODE", ConnInfo.PLT_CODE, typeof(string));

            UTIL.SetBizAddColumnToValue(dtParam, "PROD_CODE", row["PROD_CODE"], typeof(string));

            UTIL.SetBizAddColumnToValue(dtParam, "PT_ID", row["PT_ID"], typeof(string));

            UTIL.SetBizAddColumnToValue(dtParam, "IS_WO_PART", "1", typeof(string));

            UTIL.SetBizAddColumnToValue(dtParam, "DATA_FLAG", 0, typeof(byte));

            UTIL.SetBizAddColumnToValue(dtParam, "ROUT_CODE", null, typeof(string));

            DataTable dtPartList = DMAT.TMAT_PARTLIST_QUERY.TMAT_PARTLIST_QUERY2(dtParam, bizExecute);

            //휴일조회
            DataTable dtHoliDay = DLSE.LSE_HOLIDAY_QUERY.LSE_HOLIDAY_QUERY1(dtParam, bizExecute);

            DataTable dtNow = UTIL.UTILITY_GET_DTNOW(bizExecute);
            int part_id = 0;
            foreach (DataRow part_row in dtPartList.Rows)
            {
                //DataTable dtSer = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER3(UTIL.GetRowToDt(part_row), bizExecute);

                //if (dtSer.Rows.Count > 0)
                //    continue;

                //부품별 공정시간 가져온다
                DataTable dtPart = DLSE.LSE_STD_PART.LSE_STD_PART_SER(UTIL.GetRowToDt(part_row), bizExecute);

                int camTime = 0;
                int milTime = 0;
                int mcTime = 0;
                int slitTime = 0;
                int midInsTime = 0;
                int sideTime = 0;
                int asseyTime = 0;
                int msopTime = 0;
                int actAsseyTime = 0;
                int shipInsTime = 0;

                if (dtPart.Rows.Count > 0)
                {
                    camTime = dtPart.Rows[0]["CAM_TIME"].toInt();
                    milTime = dtPart.Rows[0]["MIL_TIME"].toInt();
                    mcTime = dtPart.Rows[0]["MC_TIME"].toInt();
                    slitTime = dtPart.Rows[0]["SLIT_TIME"].toInt();
                    midInsTime = dtPart.Rows[0]["MID_INS_TIME"].toInt();
                    sideTime = dtPart.Rows[0]["SIDE_TIME"].toInt();
                    asseyTime = dtPart.Rows[0]["ASSEY_TIME"].toInt();
                    msopTime = dtPart.Rows[0]["MSOP_TIME"].toInt();
                    actAsseyTime = dtPart.Rows[0]["ACT_ASSEY_TIME"].toInt();
                    shipInsTime = dtPart.Rows[0]["SHIP_INS_TIME"].toInt();
                }


                string mc_group = CTRL.CTRL.GetPartToMcGroup(part_row["PART_CODE"].ToString(), "", part_row["PT_ID"].ToString(), bizExecute);

                string rout_group = CTRL.CTRL.GetPartToRoutGroup(part_row["PROD_CODE"].ToString(), part_row["PART_CODE"].ToString(), part_row["PT_ID"].ToString(), bizExecute);

                if (row["NG_TYPE"].ToString() == "P")
                {
                    rout_group = "16Group";
                }
                else if (row["NG_TYPE"].ToString() == "R")
                {
                    if (row["NG_CAT"].ToString() == "OT" && rout_group != "15Group")
                    {
                        rout_group = "17Group";
                    }
                }

                part_row["ROUT_CODE"] = rout_group;

                part_row["MC_GROUP"] = mc_group;
                //라우트 그룹, 설비 그룹 파트 리스트에 저장
                DMAT.TMAT_PARTLIST.TMAT_PARTLIST_UPD2(UTIL.GetRowToDt(part_row), bizExecute);

                dtParam.Rows[0]["ROUT_CODE"] = rout_group;

                //DataTable dtProc = DLSE.LSE_STD_PROC_QUERY.LSE_STD_PROC_QUERY1(dtParam, bizExecute);

                DataTable dtProc = DSTD.TSTD_ROUTING.TSTD_ROUTING_SER2(dtParam, bizExecute);

                int proc_id = 0;

                part_row["PART_QTY"] = row["PLAN_QTY"];

                foreach (DataRow proc_row in dtProc.Rows)
                {
                    //설계공정(DES)일 경우 넘어감
                    if (proc_row["WO_TYPE"].ToString() == "DES")
                    {
                        continue;
                    }

                    if (row["NG_TYPE"].ToString() == "P")
                    {
                        if (proc_row["WO_TYPE"].ToString() == "MIL")
                        {
                            continue;
                        }
                    }

                    DataTable dtRow = new DataTable("RQSTDT");
                    UTIL.SetBizAddColumnToValue(dtRow, "PLT_CODE", ConnInfo.PLT_CODE, typeof(string));
                    //작지 번호
                    string strSerialWO = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "W", bizExecute);
                    UTIL.SetBizAddColumnToValue(dtRow, "WO_NO", strSerialWO, typeof(string));

                    UTIL.SetBizAddColumnToValue(dtRow, "PROD_CODE", part_row["PROD_CODE"], typeof(string));

                    UTIL.SetBizAddColumnToValue(dtRow, "PT_ID", part_row["PT_ID"], typeof(string));

                    UTIL.SetBizAddColumnToValue(dtRow, "PART_CODE", part_row["PART_CODE"], typeof(string));

                    UTIL.SetBizAddColumnToValue(dtRow, "PT_NAME", part_row["PART_NAME"], typeof(string));

                    mc_group = CTRL.CTRL.GetPartToMcGroup(part_row["PART_CODE"].ToString(), proc_row["PROC_CODE"].ToString(), part_row["PT_ID"].ToString(), bizExecute);

                    //if (row["NG_TYPE"].ToString() == "P")
                    //{
                    //    mc_group = "F";
                    //}

                    UTIL.SetBizAddColumnToValue(dtRow, "MC_GROUP", mc_group, typeof(string));

                    UTIL.SetBizAddColumnToValue(dtRow, "PART_ID", part_id, typeof(int));

                    UTIL.SetBizAddColumnToValue(dtRow, "PROC_ID", proc_id, typeof(int));

                    UTIL.SetBizAddColumnToValue(dtRow, "PROC_CODE", proc_row["PROC_CODE"], typeof(string));

                    UTIL.SetBizAddColumnToValue(dtRow, "PART_QTY", part_row["PART_QTY"], typeof(int));


                    if (row.Table.Columns.Contains("PROD_CODE"))
                    {
                        DataTable paramCamTable = new DataTable("RQSTDT");
                        paramCamTable.Columns.Add("PLT_CODE", typeof(string));
                        paramCamTable.Columns.Add("PROD_CODE", typeof(string));
                        paramCamTable.Columns.Add("PART_CODE", typeof(string));
                        paramCamTable.Columns.Add("PROC_CODE", typeof(string));

                        DataRow paramCamRow = paramCamTable.NewRow();
                        paramCamRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                        paramCamRow["PROD_CODE"] = row["PROD_CODE"];
                        paramCamRow["PART_CODE"] = part_row["PART_CODE"];
                        paramCamRow["PROC_CODE"] = proc_row["PROC_CODE"];

                        paramCamTable.Rows.Add(paramCamRow);

                        //if (row["NG_TYPE"].ToString() == "P")
                        //{
                        //    //수정CAM담당자는 기준정보에서 가져온다.
                        //    DataTable dtCAMSer = DSTD.TSTD_EMPLOYEE.TSTD_EMPLOYEE_SER7(paramCamTable, bizExecute);

                        //    if (dtCAMSer.Rows.Count > 0)
                        //    {
                        //        UTIL.SetBizAddColumnToValue(dtRow, "CAM_EMP", dtCAMSer.Rows[0]["EMP_CODE"].ToString(), typeof(string));
                        //    }
                        //}
                        //else
                        //{
                            DataTable dtCAMSer = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER11(paramCamTable, bizExecute);

                            if (dtCAMSer.Rows.Count > 0)
                            {
                                UTIL.SetBizAddColumnToValue(dtRow, "CAM_EMP", dtCAMSer.Rows[0]["CAM_EMP"].ToString(), typeof(string));
                            }
                        //}
                    }

                    //작업자 정보는 사용하지 않는다.
                    //DataTable dtMcEmp = DLSE.LSE_MACHINE.LSE_MACHINE_SER(dtRow, bizExecute);
                    //string strEmpCode = "";
                    //if (dtMcEmp.Rows.Count > 0) strEmpCode = dtMcEmp.Rows[0]["MAIN_EMP"].ToString();

                    string wo_flag = "1";
                    string wo_type = string.Empty;
                    //DataTable dtProc = DLSE.LSE_STD_PROC.LSE_STD_PROC_SER(dtRow, bizExecute);
                    string is_os = "0"; string os_vnd = string.Empty; double proc_time = 0;

                    //if (dtProc.Rows.Count > 0)
                    {
                        //공정외주 인지 판단
                        is_os = proc_row["IS_OS"].ToString();
                        os_vnd = proc_row["MAIN_VND"].ToString();
                        //가공시간
                        proc_time = proc_row["PROC_MAN_TIME"].toDouble();

                        wo_type = proc_row["WO_TYPE"].ToString();
                    }

                    UTIL.SetBizAddColumnToValue(dtRow, "IS_OS", is_os, typeof(string));
                    UTIL.SetBizAddColumnToValue(dtRow, "OS_VND", os_vnd, typeof(string));

                    //UTIL.SetBizAddColumnToValue(dtRow, "EMP_CODE", strEmpCode, typeof(string));
                    //작업지시 상태
                    UTIL.SetBizAddColumnToValue(dtRow, "WO_FLAG", wo_flag, typeof(string));
                    //작업지시 타입(용도 모름, 사용 안함)
                    UTIL.SetBizAddColumnToValue(dtRow, "WO_TYPE", "0", typeof(string));
                    //우선순위(보통)
                    UTIL.SetBizAddColumnToValue(dtRow, "JOB_PRIORITY", "1", typeof(string));
                    //사용 X
                    UTIL.SetBizAddColumnToValue(dtRow, "ACT_INPUT_TYPE", "IN", typeof(string));
                    //가공 예상 시간(분)
                    UTIL.SetBizAddColumnToValue(dtRow, "PLN_PROC_TIME", proc_time, typeof(double));
                    UTIL.SetBizAddColumnToValue(dtRow, "PLN_PROC_MAN_TIME", proc_time, typeof(double));
                    //설계가 아닐경우
                    if (wo_type != "DES")
                    {
                        //이전 작업의 계획 완료 시간 가져오기
                        DataTable dtBeforeProc = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER7(dtRow, bizExecute);

                        DateTime lastTime = part_row["REG_DATE"].toDateTime();

                        if (dtBeforeProc.Rows.Count > 0)
                        {
                            lastTime = dtBeforeProc.Rows[0]["PLN_END_TIME"].toDateTime();
                            //이전 공정이 설계이면 12시간 이후 시작
                            if (dtBeforeProc.Rows[0]["WO_TYPE"].Equals("DES"))
                                lastTime = lastTime.AddHours(12);
                        }

                        //
                        if (proc_row["WORK_START_TIME"].toStringEmpty() != "")
                        {
                            int startTime = lastTime.toDateString("HHmm").toInt();
                            int procStartTime = proc_row["WORK_START_TIME"].toInt();
                            int procEndTime = proc_row["WORK_END_TIME"].toInt();

                            if (procEndTime < startTime)
                            {
                                //종료시간이 공정 가용시간 @WORK_END_TIME 보다 크거나
                                //@WORK_END_TIME 부터 종료시간까지차이를 다음날 @WORK_START_TIME 이후로 붙여준다

                                DateTime tempTime = (lastTime.toDateString("yyyyMMdd") + proc_row["WORK_END_TIME"].ToString()).toDateTime();
                                //TimeSpan ts = lastTime.Subtract(tempTime);
                                lastTime = (lastTime.AddDays(1).toDateString("yyyyMMdd") + proc_row["WORK_START_TIME"].ToString()).toDateTime();
                                //lastTime = lastTime.AddMinutes(ts.TotalMinutes);

                            }
                            else if (procStartTime > startTime)
                            {
                                //종료시간이 공정 가용시간 @WORK_START_TIME 보다 작으면
                                //@WORK_END_TIME 부터 종료시간까지차이를 다음날 @WORK_START_TIME 이후로 붙여준다
                                DateTime tempTime = (lastTime.AddDays(-1).toDateString("yyyyMMdd") + proc_row["WORK_END_TIME"].ToString()).toDateTime();
                                //TimeSpan ts = lastTime.Subtract(tempTime);
                                lastTime = (lastTime.toDateString("yyyyMMdd") + proc_row["WORK_START_TIME"].ToString()).toDateTime();
                                //lastTime = lastTime.AddMinutes(ts.TotalMinutes);
                            }
                        }

                        bool isprevEnd = true;
                        while (isprevEnd)
                        {
                            if (lastTime.DayOfWeek == DayOfWeek.Saturday
                                || lastTime.DayOfWeek == DayOfWeek.Sunday)
                            {
                                lastTime = lastTime.AddDays(1);
                            }
                            else if (dtHoliDay.Select("HOLI_DATE = '" + lastTime.toDateString("yyyyMMdd") + "'").Length > 0)
                            {
                                lastTime = lastTime.AddDays(1);
                            }
                            else
                            {
                                isprevEnd = false;
                            }
                        }


                        if (proc_row["PROC_CODE"].ToString() == "P-02")
                        {
                            //if (type == "RE")
                            //{
                            //    proc_time = 5;
                            //}
                            //else
                            //{
                            //    if (camTime > 0)
                            //    {
                            //        proc_time = camTime;
                            //    }
                            //}

                            if (camTime > 0)
                            {
                                proc_time = camTime;
                            }
                        }
                        else if (proc_row["PROC_CODE"].ToString() == "P-03")
                        {
                            if (milTime > 0)
                            {
                                proc_time = milTime;
                            }
                        }
                        else if (proc_row["PROC_CODE"].ToString() == "P-04")
                        {
                            if (mcTime > 0)
                            {
                                proc_time = mcTime * part_row["PART_QTY"].toInt();
                            }

                            //갯수에따라 시간 비율 계산
                            if (part_row["PART_QTY"].toInt() < 4)
                            {
                                proc_time = proc_time * 1;
                            }
                            else if (part_row["PART_QTY"].toInt() < 10)
                            {
                                proc_time = proc_time * 0.85;
                            }
                            else if (part_row["PART_QTY"].toInt() >= 10)
                            {
                                proc_time = proc_time * 0.5;
                            }
                        }
                        else if (proc_row["PROC_CODE"].ToString() == "P-05")
                        {
                            if (slitTime > 0)
                            {
                                proc_time = slitTime;
                            }
                        }
                        else if (proc_row["PROC_CODE"].ToString() == "P-06")
                        {
                            if (midInsTime > 0)
                            {
                                proc_time = midInsTime;
                            }
                        }
                        else if (proc_row["PROC_CODE"].ToString() == "P-07")
                        {
                            if (sideTime > 0)
                            {
                                proc_time = sideTime;
                            }
                        }
                        else if (proc_row["PROC_CODE"].ToString() == "P-09")
                        {
                            if (asseyTime > 0)
                            {
                                proc_time = asseyTime;
                            }
                        }
                        else if (proc_row["PROC_CODE"].ToString() == "P-10")
                        {
                            if (msopTime > 0)
                            {
                                proc_time = msopTime;
                            }
                        }
                        else if (proc_row["PROC_CODE"].ToString() == "P-11")
                        {
                            if (actAsseyTime > 0)
                            {
                                proc_time = actAsseyTime;
                            }
                        }
                        else if (proc_row["PROC_CODE"].ToString() == "P-12")
                        {
                            if (shipInsTime > 0)
                            {
                                proc_time = shipInsTime;
                            }
                        }

                        ////일요일 체크 - 일요일이면 다음날로
                        //if (lastTime.DayOfWeek == DayOfWeek.Sunday)
                        //{
                        //    lastTime = lastTime.AddDays(1);
                        //    lastTime = (lastTime.Year.ToString() + lastTime.Month.ToString() + lastTime.Day.ToString() + day_close).toDateTime();
                        //}

                        //작업일 작업시간으로 변경
                        UTIL.SetBizAddColumnToValue(dtRow, "PLN_START_TIME", lastTime.toDateString("yyyyMMddHHmm"), typeof(string));
                        //작업일 작업시간으로 변경
                        UTIL.SetBizAddColumnToValue(dtRow, "PLN_END_TIME", lastTime.AddMinutes(proc_time).toDateString("yyyyMMddHHmm"), typeof(string));


                        if (proc_row["WORK_START_TIME"].toStringEmpty() != "")
                        {
                            int startTime = dtRow.Rows[0]["PLN_END_TIME"].toDateString("HHmm").toInt();
                            int procStartTime = proc_row["WORK_START_TIME"].toInt();
                            int procEndTime = proc_row["WORK_END_TIME"].toInt();

                            if (procEndTime < startTime)
                            {
                                //종료시간이 공정 가용시간 @WORK_END_TIME 보다 크거나
                                //@WORK_END_TIME 부터 종료시간까지차이를 다음날 @WORK_START_TIME 이후로 붙여준다

                                DateTime tempTime = (dtRow.Rows[0]["PLN_END_TIME"].toDateString("yyyyMMdd") + proc_row["WORK_END_TIME"].ToString()).toDateTime();
                                TimeSpan ts = dtRow.Rows[0]["PLN_END_TIME"].toDateTime().Subtract(tempTime);
                                dtRow.Rows[0]["PLN_END_TIME"] = (dtRow.Rows[0]["PLN_END_TIME"].toDateTime().AddDays(1).toDateString("yyyyMMdd") + proc_row["WORK_START_TIME"].ToString()).toDateTime().toDateString("yyyyMMddHHmm");
                                dtRow.Rows[0]["PLN_END_TIME"] = dtRow.Rows[0]["PLN_END_TIME"].toDateTime().AddMinutes(ts.TotalMinutes).toDateString("yyyyMMddHHmm");

                            }
                            else if (procStartTime > startTime)
                            {
                                //종료시간이 공정 가용시간 @WORK_START_TIME 보다 작으면
                                //@WORK_END_TIME 부터 종료시간까지차이를 다음날 @WORK_START_TIME 이후로 붙여준다
                                DateTime tempTime = (dtRow.Rows[0]["PLN_END_TIME"].toDateTime().AddDays(-1).toDateString("yyyyMMdd") + proc_row["WORK_END_TIME"].ToString()).toDateTime();
                                TimeSpan ts = dtRow.Rows[0]["PLN_END_TIME"].toDateTime().Subtract(tempTime);
                                dtRow.Rows[0]["PLN_END_TIME"] = (dtRow.Rows[0]["PLN_END_TIME"].toDateTime().toDateString("yyyyMMdd") + proc_row["WORK_START_TIME"].ToString()).toDateTime().toDateString("yyyyMMddHHmm");
                                dtRow.Rows[0]["PLN_END_TIME"] = dtRow.Rows[0]["PLN_END_TIME"].toDateTime().AddMinutes(ts.TotalMinutes).toDateString("yyyyMMddHHmm");
                            }
                        }


                        bool isEnd = true;
                        while (isEnd)
                        {
                            if (dtRow.Rows[0]["PLN_END_TIME"].toDateTime().DayOfWeek == DayOfWeek.Saturday
                                || dtRow.Rows[0]["PLN_END_TIME"].toDateTime().DayOfWeek == DayOfWeek.Sunday)
                            {
                                dtRow.Rows[0]["PLN_END_TIME"] = dtRow.Rows[0]["PLN_END_TIME"].toDateTime().AddDays(1).toDateString("yyyyMMddHHmm");
                            }
                            else if (dtHoliDay.Select("HOLI_DATE = '" + dtRow.Rows[0]["PLN_END_TIME"].toDateString("yyyyMMdd") + "'").Length > 0)
                            {
                                dtRow.Rows[0]["PLN_END_TIME"] = dtRow.Rows[0]["PLN_END_TIME"].toDateTime().AddDays(1).toDateString("yyyyMMddHHmm");
                            }
                            else
                            {
                                isEnd = false;
                            }
                        }


                        //가공 예상 시간(분)
                        UTIL.SetBizAddColumnToValue(dtRow, "PLN_PROC_TIME", proc_time, typeof(double));
                        UTIL.SetBizAddColumnToValue(dtRow, "PLN_PROC_MAN_TIME", proc_time, typeof(double));

                        UTIL.SetBizAddColumnToValue(dtRow, "DATA_FLAG", 0, typeof(Byte));
                        
                    }

                    foreach (DataRow sideRow in dtRow.Rows)
                    {
                        if (sideRow["PROC_CODE"].ToString() == "P-07")
                        {
                            sideRow["MC_GROUP"] = "F";
                        }
                    }

                    UTIL.SetBizAddColumnToValue(dtRow, "RE_WO_NO", reWoNo, typeof(String));
                    UTIL.SetBizAddColumnToValue(dtRow, "O_WO_NO", row["WO_NO"], typeof(String));

                    DSHP.TSHP_WORKORDER.TSHP_WORKORDER_INS(dtRow, bizExecute);

                    proc_id++;
                }

                part_id++;
            }

        }
    }
}
