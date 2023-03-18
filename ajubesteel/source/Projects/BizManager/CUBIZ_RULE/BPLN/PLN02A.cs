using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BPLN
{


    /// <summary>
    /// 주간 계획 수립
    /// </summary>
    /// <author>신재경</author>
    /// <remarks>
    /// <b>2016.03.26</b> 신규생성<br/>
    /// </remarks>    
    public class PLN02A
    {



        public static DataSet PLN02A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                
                DataTable dtRslt = DORD.TORD_PRODUCT_QUERY.TORD_PRODUCT_QUERY4(paramDS.Tables["RQSTDT"], bizExecute);

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

        public static DataSet PLN02A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "IS_WO_PART", "1", typeof(string));

                ///part list
                DataTable dtRslt = DMAT.TMAT_PARTLIST_QUERY.TMAT_PARTLIST_QUERY2_1(paramDS.Tables["RQSTDT"], bizExecute);
                //DataTable dtRslt_ALL = DMAT.TMAT_PARTLIST_QUERY.TMAT_PARTLIST_QUERY2_ALL(paramDS.Tables["RQSTDT"], bizExecute);                
                //dtRslt_PART.TableName = "RSLTDT";
                //dtRslt_ALL.TableName = "RSLTDT";
                //DataSet ds = new DataSet();

                //ds.Merge(dtRslt_PART);
                //ds.Merge(dtRslt_ALL);

                //DataTable dtRslt = ds.Tables[0].Copy();
                dtRslt.TableName = "RSLTDT";
                dtRslt.Columns.Add("SEL", typeof(string));


                if (dtRslt.Rows.Count > 0)
                {
                    UTIL.SetBizAddColumnToValue(dtRslt, "DATA_FLAG", 0, typeof(Byte), true);
                    UTIL.SetBizAddColumnToValue(dtRslt, "ROUT_CODE", string.Empty, typeof(string));
                    UTIL.SetBizAddColumnToValue(dtRslt, "DATA_TYPE", "M", typeof(string));
                    UTIL.SetBizAddColumnToValue(dtRslt, "PROC_FLAG", 1, typeof(byte));
                    UTIL.SetBizAddColumnToValue(dtRslt, "WORK_SCOMMENT", string.Empty, typeof(string));
                }

                foreach (DataRow row in dtRslt.Rows)
                {
                    DataTable dtRslt_wo = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY2(UTIL.GetRowToDt(row), bizExecute);

                    dtRslt_wo.Columns.Add("SEL");
                    dtRslt_wo.TableName = "RSLTDT_WO";

                    paramDS.Merge(dtRslt_wo);

                    if (dtRslt_wo.Rows.Count == 0)
                    {

                        //string mc_group = CTRL.CTRL.GetPartToMcGroup(row["PART_CODE"].ToString(), bizExecute);

                        //해당 품목의 표준 라우팅 코드를 가져온다.
                        string rout_code = CTRL.CTRL.GetPartToRoutGroup(row["PROD_CODE"].ToString(), row["PART_CODE"].ToString(), row["PT_ID"].ToString(), bizExecute);

                        row["ROUT_CODE"] = rout_code;

                        //dtRslt_wo = DLSE.LSE_STD_PARTPROC.LSE_STD_PARTPROC_SER2(UTIL.GetRowToDt(row), bizExecute);

                        dtRslt_wo = DSTD.TSTD_ROUTING.TSTD_ROUTING_SER2(UTIL.GetRowToDt(row), bizExecute);
                        UTIL.SetBizAddColumnToValue(dtRslt_wo, "PT_ID", row["PT_ID"], typeof(string));
                        dtRslt_wo.Columns.Add("SEL");                        
                        dtRslt_wo.TableName = "RSLTDT_WO";
                        paramDS.Merge(dtRslt_wo);
                    }
                                        
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
        /// 공정정보 저장
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet PLN02A_SAVE(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                string day_close = UTIL.GetConfValue("DAY_CLOSE_TIME", bizExecute);
                //paramDS.Tables["RQSTDT"].DefaultView.Sort = "PT_ID , PROC_ID";

                DataView dataView = new DataView(paramDS.Tables["RQSTDT"]);

                dataView.Sort = "PT_ID , PROC_ID";

                DataTable dtRqst = dataView.ToTable();

                foreach (DataRow row in dtRqst.Rows)
                {
                    //SCOMMENT 업데이트
                    DMAT.TMAT_PARTLIST.TMAT_PARTLIST_UPD5(UTIL.GetRowToDt(row), bizExecute);

                    DataTable partlistTable = DMAT.TMAT_PARTLIST.TMAT_PARTLIST_SER(UTIL.GetRowToDt(row), bizExecute);

                    DataTable dtRow = UTIL.GetRowToDt(row);

                    if (partlistTable.Rows.Count > 0)
                    {
                        if (partlistTable.Rows[0]["DATA_FLAG"].ToString() != "2")
                        {
                            DataTable dtSer = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER2(dtRow, bizExecute);

                            if (dtSer.Rows.Count > 0)
                            {
                                if (row["DATA_FLAG"].Equals((byte)0))
                                {
                                    //작업일 작업시간으로 변경
                                    //UTIL.SetBizAddColumnToValue(dtRow, "PLN_START_TIME", dtSer.Rows[0]["PLN_START_DATE"].ToString() + "0800", typeof(string));
                                    ////작업일 작업시간으로 변경
                                    //UTIL.SetBizAddColumnToValue(dtRow, "PLN_END_TIME", dtSer.Rows[0]["PLN_END_DATE"].ToString() + "0800", typeof(string));

                                    //DataTable woTable = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER(UTIL.GetRowToDt(row), bizExecute);

                                    if (dtSer.Rows[0]["DATA_FLAG"].ToString() == "0")
                                    {
                                        if (dtRow.Rows[0]["WO_FLAG"].ToString() != dtSer.Rows[0]["WO_FLAG"].ToString())
                                        {
                                            if (dtSer.Rows[0]["WO_FLAG"].ToString() != "0"
                                            && dtSer.Rows[0]["WO_FLAG"].ToString() != "1")
                                            {
                                                dtRow.Rows[0]["WO_FLAG"] = dtSer.Rows[0]["WO_FLAG"];
                                            }
                                        }
                                    }

                                    if (dtRow.Rows[0]["WO_FLAG"].ToString() == "0")
                                    {
                                        dtRow.Rows[0]["WO_FLAG"] = "1";
                                    }

                                    DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD2(dtRow, bizExecute);

                                    if (dtRow.Rows[0]["IS_DES_CHANGE"].ToString() != "0")
                                    {
                                        DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD2_2(dtRow, bizExecute);
                                    }


                                }
                                else
                                {
                                    //if (dtSer.Rows[0]["WO_FLAG"].ToString() != "0" && dtSer.Rows[0]["WO_FLAG"].ToString() != "1")
                                    //{
                                    //    throw UTIL.SetException("작업지시가 이미 진행중이라 삭제 할 수 없습니다.\n\r"
                                    //                                + "다시 확인 하여 주십시오"
                                    //    , dtSer.Rows[0]["WO_NO"].ToString()
                                    //    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    //    , 200090, dtSer.Rows[0]);
                                    //}
                                    DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD2(dtRow, bizExecute);
                                    DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD2_3(dtRow, bizExecute);

                                }
                            }
                            else
                            {
                                if (row["DATA_FLAG"].Equals((byte)0))
                                {
                                    //작지 번호
                                    string strSerialWO = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "W", bizExecute);
                                    UTIL.SetBizAddColumnToValue(dtRow, "WO_NO", strSerialWO, typeof(string));

                                    //설비 그룹 정보를 가져온다.
                                    //DataTable dtProcMc = DLSE.LSE_STD_AVAILMC.LSE_STD_AVAILMC_SER2(dtRow, bizExecute);
                                    string mc_group = CTRL.CTRL.GetPartToMcGroup(row["PART_CODE"].ToString(), row["PROC_CODE"].ToString(), row["PT_ID"].ToString(), bizExecute);
                                    //if (dtProcMc.Rows.Count > 0) strMcCode = dtProcMc.Rows[0]["MC_CODE"].ToString();
                                    UTIL.SetBizAddColumnToValue(dtRow, "MC_GROUP", mc_group, typeof(string));

                                    //작업자 정보는 사용하지 않는다.
                                    //DataTable dtMcEmp = DLSE.LSE_MACHINE.LSE_MACHINE_SER(dtRow, bizExecute);
                                    //string strEmpCode = "";
                                    //if (dtMcEmp.Rows.Count > 0) strEmpCode = dtMcEmp.Rows[0]["MAIN_EMP"].ToString();

                                    string wo_flag = "1";
                                    string wo_type = string.Empty;
                                    DataTable dtProc = DLSE.LSE_STD_PROC.LSE_STD_PROC_SER(dtRow, bizExecute);
                                    string is_os = "0"; string os_vnd = string.Empty; double proc_time = 0;

                                    if (dtProc.Rows.Count > 0)
                                    {
                                        //공정외주 인지 판단
                                        is_os = dtProc.Rows[0]["IS_OS"].ToString();
                                        os_vnd = dtProc.Rows[0]["MAIN_VND"].ToString();
                                        //가공시간
                                        proc_time = dtProc.Rows[0]["PROC_MAN_TIME"].toDouble();

                                        wo_type = dtProc.Rows[0]["WO_TYPE"].ToString();

                                        //설계일경우
                                        if (wo_type == "DES")
                                        {
                                            wo_flag = "4";
                                            //BOM등록일 가져오기
                                            DataTable dtSerPt = DMAT.TMAT_PARTLIST.TMAT_PARTLIST_SER(UTIL.GetRowToDt(row), bizExecute);
                                            if (dtSerPt.Rows.Count > 0)
                                            {
                                                //설계계획 시작시간을 BOM등록 시간에서 표준공수를 뺀시간
                                                UTIL.SetBizAddColumnToValue(dtRow, "PLN_START_TIME", dtSerPt.Rows[0]["REG_DATE"].toDateTime().AddMinutes(-proc_time).toDateString("yyyyMMddHHmm"), typeof(string));
                                                //설계계획 완료 시간을 BOM등록시간으로
                                                UTIL.SetBizAddColumnToValue(dtRow, "PLN_END_TIME", dtSerPt.Rows[0]["REG_DATE"].toDateTime().toDateString("yyyyMMddHHmm"), typeof(string));

                                                //설계실적 시작시간을 BOM등록 시간에서 표준공수를 뺀시간
                                                UTIL.SetBizAddColumnToValue(dtRow, "ACT_START_TIME", dtSerPt.Rows[0]["REG_DATE"].toDateTime().AddMinutes(-proc_time), typeof(DateTime));
                                                //설계실적 완료 시간을 BOM등록시간으로
                                                UTIL.SetBizAddColumnToValue(dtRow, "ACT_END_TIME", dtSerPt.Rows[0]["REG_DATE"].toDateTime(), typeof(DateTime));

                                                //계획수량을 실적수량으로
                                                UTIL.SetBizAddColumnToValue(dtRow, "ACT_QTY", dtSerPt.Rows[0]["REG_DATE"].toDateTime(), typeof(DateTime));
                                            }
                                        }
                                    }

                                    UTIL.SetBizAddColumnToValue(dtRow, "IS_OS", is_os, typeof(string));
                                    UTIL.SetBizAddColumnToValue(dtRow, "OS_VND", os_vnd, typeof(string));

                                    //UTIL.SetBizAddColumnToValue(dtRow, "EMP_CODE", strEmpCode, typeof(string));
                                    //작업지시 상태
                                    UTIL.SetBizAddColumnToValue(dtRow, "WO_FLAG", wo_flag, typeof(string));
                                    //작업지시 타입(용도 모름, 사용 안함)
                                    UTIL.SetBizAddColumnToValue(dtRow, "WO_TYPE", "0", typeof(string));

                                    //우선순위

                                    if (row["PROD_PRIORITY"].ToString() == "2")
                                    {
                                        UTIL.SetBizAddColumnToValue(dtRow, "JOB_PRIORITY", "0", typeof(string));
                                    }
                                    else
                                    {
                                        UTIL.SetBizAddColumnToValue(dtRow, "JOB_PRIORITY", "1", typeof(string));
                                    }

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

                                        DateTime lastTime = DateTime.Now;

                                        if (dtBeforeProc.Rows.Count > 0)
                                        {
                                            lastTime = dtBeforeProc.Rows[0]["PLN_END_TIME"].toDateTime();
                                            //이전 공정이 설계이면 12시간 이후 시작
                                            if (dtBeforeProc.Rows[0]["WO_TYPE"].Equals("DES"))
                                                lastTime = lastTime.AddHours(12);
                                        }
                                        //공휴일 정보 체크 - 적용 보류

                                        //일요일 체크 - 일요일이면 다음날로
                                        if (lastTime.DayOfWeek == DayOfWeek.Sunday)
                                        {
                                            lastTime = lastTime.AddDays(1);
                                            lastTime = (lastTime.Year.ToString() + lastTime.Month.ToString() + lastTime.Day.ToString() + day_close).toDateTime();
                                        }

                                        //작업일 작업시간으로 변경
                                        UTIL.SetBizAddColumnToValue(dtRow, "PLN_START_TIME", lastTime.toDateString("yyyyMMddHHmm"), typeof(string));
                                        //작업일 작업시간으로 변경
                                        UTIL.SetBizAddColumnToValue(dtRow, "PLN_END_TIME", lastTime.AddMinutes(proc_time).toDateString("yyyyMMddHHmm"), typeof(string));
                                    }
                                    DSHP.TSHP_WORKORDER.TSHP_WORKORDER_INS(dtRow, bizExecute);

                                    if (dtRow.Rows[0]["IS_DES_CHANGE"].ToString() != "0")
                                    {
                                        DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD2_2(dtRow, bizExecute);
                                    }
                                }
                            }
                        }
                    }

                    

                    //출하공정 체크
                    if (dtRow.Rows.Count > 0)
                    {
                        DataTable paramTable = dtRow.Clone();
                        DataRow paramRow = paramTable.NewRow();
                        paramRow.ItemArray = dtRow.Rows[0].ItemArray;
                        paramRow["PROC_CODE"] = "P-13";
                        paramTable.Rows.Add(paramRow);

                        DataTable procTable = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER2(paramTable, bizExecute);

                        foreach (DataRow rw in procTable.Rows)
                        {
                            if (rw["DATA_FLAG"].ToString() == "0" && rw["WO_FLAG"].ToString() == "0")
                            {
                                rw["WO_FLAG"] = "1";

                                DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD5_5(UTIL.GetRowToDt(rw), bizExecute);
                            }
                        }

                    }
                }

                //DataTable dtRslt = DLSE.LSE_STD_PARTPROC.LSE_STD_PARTPROC_SER2(dtRqst_Copy, bizExecute);

                //dtRslt.TableName = "RSLTDT";

                //paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }


        public static DataSet PLN02A_SER_WO(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                //공정 정보
                //DataTable dtRslt_Proc = DLSE.LSE_STD_PROC_QUERY.LSE_STD_PROC_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);
                ////DataTable dtRslt_Proc = DLSE.LSE_STD_PARTPROC.LSE_STD_PARTPROC_SER2(paramDS.Tables["RQSTDT"], bizExecute);

                //dtRslt_Proc.Columns.Add("SEL", typeof(String));
                //dtRslt_Proc.Columns.Add("WO_FLAG", typeof(String));
                //dtRslt_Proc.Columns.Add("WP_NO", typeof(String));
                //dtRslt_Proc.Columns.Add("WO_NO", typeof(String));
                //dtRslt_Proc.Columns.Add("MC_CODE", typeof(String));
                //dtRslt_Proc.Columns.Add("EMP_CODE", typeof(String));
                //dtRslt_Proc.Columns.Add("PART_ID", typeof(Int32));
                //dtRslt_Proc.Columns.Add("PLN_QTY", typeof(Int32));
                //dtRslt_Proc.Columns.Add("ACT_QTY", typeof(Int32));
                //dtRslt_Proc.Columns.Add("PLN_PROC_TIME", typeof(Decimal));
                //dtRslt_Proc.Columns.Add("PLN_STD_TIME", typeof(Decimal));
                //dtRslt_Proc.Columns.Add("PROC_UC", typeof(Decimal));
                //dtRslt_Proc.Columns.Add("PROC_COST", typeof(Decimal));
                ////UTIL.SetBizAddColumnToValue(dtRslt_Proc, "WO_FLAG", "0", typeof(String));                
                //UTIL.SetBizAddColumnToValue(dtRslt_Proc, "JOB_PRIORITY", "2", typeof(String));
                //dtRslt_Proc.TableName = "RSLTDT_PROC";

                //paramDS.Tables.Add(dtRslt_Proc);

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(byte));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "CAT_CODE", "C020", typeof(string));//설비 그룹

                DataTable dtRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);
                //dtRslt.Columns.Add("SEL");
                dtRslt.Columns.Add("IDLE_CODE");
                dtRslt.TableName = "RSLTDT_PROC";
                paramDS.Tables.Add(dtRslt);

                //설비 정보 key 공정+설비그룹
                //DataTable dtRslt_Grp = DLSE.LSE_STD_AVAILMC_QUERY.LSE_STD_AVAILMC_QUERY6(paramDS.Tables["RQSTDT"], bizExecute);
                DataTable dtRslt_Grp = DSTD.TSTD_CODES_QUERY.TSTD_CODES_QUERY9(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt_Grp.Columns.Add("SEL", typeof(string));
                dtRslt_Grp.TableName = "RSLTDT_GRP";

                paramDS.Tables.Add(dtRslt_Grp);

                ////작업자  key 설비+작업자
                //DataTable dtRslt_Emp = DSTD.TSTD_MC_AVAILEMP_QUERY.TSTD_MC_AVAILEMP_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

                //dtRslt_Emp.Columns.Add("SEL", typeof(string));
                //dtRslt_Emp.TableName = "RSLTDT_EMP";
                //paramDS.Tables.Add(dtRslt_Emp);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }


        public static DataSet PLN02A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                //DataTable dtRslt = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER3(paramDS.Tables["RQSTDT"], bizExecute);
                //dtRslt.Columns.Add("SEL");
                //dtRslt.Columns.Add("IDLE_CODE");
                //dtRslt.TableName = "RSLTDT";

                DataTable dtIdle = DSHP.TSHP_IDLETIME_QUERY.TSHP_IDLETIME_QUERY5(paramDS.Tables["RQSTDT"], bizExecute);
                dtIdle.TableName = "RSLTDT_IDLE";

                //paramDS.Tables.Add(dtRslt);
                paramDS.Tables.Add(dtIdle);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PLN02A_SER4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WO_PART", "1", typeof(string));

                DataTable rsltDT = DMAT.TMAT_PARTLIST_QUERY.TMAT_PARTLIST_QUERY6(paramDS.Tables["RQSTDT"], bizExecute);

                rsltDT.Columns.Add("SEL", typeof(string));

                rsltDT.TableName = "RSLTDT";

                paramDS.Tables.Add(rsltDT);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 공정정보 저장
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet PLN02A_SAVE2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {

                DataTable dtRqst = paramDS.Tables["RQSTDT"];

                foreach (DataRow row in dtRqst.Rows)
                {
                    DataTable dtRow = UTIL.GetRowToDt(row);

                    DataTable dtSer = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER2(dtRow, bizExecute);

                    if (dtSer.Rows.Count > 0)
                    {
                        if (row["DATA_FLAG"].Equals((byte)0))
                        {
                            //작업일 작업시간으로 변경
                            //UTIL.SetBizAddColumnToValue(dtRow, "PLN_START_TIME", dtSer.Rows[0]["PLN_START_DATE"].ToString() + "0800", typeof(string));
                            ////작업일 작업시간으로 변경
                            //UTIL.SetBizAddColumnToValue(dtRow, "PLN_END_TIME", dtSer.Rows[0]["PLN_END_DATE"].ToString() + "0800", typeof(string));

                            //가공공정만 설비그룹 변경가능하게하고
                            //가공공정이 아니면 기존 작지에 MC_GROUP으로 설정
                            if (dtRow.Rows[0]["WO_TYPE"].ToString() != "PRC")
                            {
                                dtRow.Rows[0]["MC_GROUP"] = dtSer.Rows[0]["MC_GROUP"];
                            }
                            else
                            {
                                if (dtRow.Rows[0]["PROC_CODE"].ToString() == "P-07")
                                {
                                    dtRow.Rows[0]["MC_GROUP"] = "F";
                                }
                            }

                            UTIL.SetBizAddColumnToValue(dtRow, "WO_TYPE", "0", typeof(string));
                            UTIL.SetBizAddColumnToValue(dtRow, "ACT_INPUT_TYPE", "IN", typeof(string));

                            if (dtRow.Rows[0]["WO_NO"].ToString() == "")
                            {
                                dtRow.Rows[0]["WO_NO"] = dtSer.Rows[0]["WO_NO"];
                                dtRow.Rows[0]["WO_FLAG"] = dtSer.Rows[0]["WO_FLAG"];
                            }

                            if (dtRow.Rows[0]["WO_FLAG"].ToString() == "0")
                            {
                                dtRow.Rows[0]["WO_FLAG"] = "1";
                            }

                            DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD(dtRow, bizExecute);
                        }
                        else
                        {
                            //if (dtSer.Rows[0]["WO_FLAG"].ToString() != "0" && dtSer.Rows[0]["WO_FLAG"].ToString() != "1")
                            //{
                            //    throw UTIL.SetException("작업지시가 이미 진행중이라 삭제 할 수 없습니다.\n\r"
                            //                                + "다시 확인 하여 주십시오"
                            //    , dtSer.Rows[0]["WO_NO"].ToString()
                            //    , new System.Diagnostics.StackFrame().GetMethod().Name
                            //    , 200090, dtSer.Rows[0]);
                            //}

                            if (dtRow.Rows[0]["WO_FLAG"].ToString() != "")
                            {
                                DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD2(dtRow, bizExecute);
                            }

                            if (dtRow.Rows[0]["IS_DES_CHANGE"].ToString() != "0")
                            {
                                DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD2_2(dtRow, bizExecute);
                            }

                            DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD2_3(dtRow, bizExecute);

                        }
                    }
                    else
                    {
                        if (row["DATA_FLAG"].Equals((byte)0))
                        {
                            //작지 번호
                            string strSerialWO = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "W", bizExecute);
                            UTIL.SetBizAddColumnToValue(dtRow, "WO_NO", strSerialWO, typeof(string));

                            //설비 정보
                            //DataTable dtProcMc = DLSE.LSE_STD_AVAILMC.LSE_STD_AVAILMC_SER2(dtRow, bizExecute);
                            //string strMcCode = "";
                            //if (dtProcMc.Rows.Count > 0) strMcCode = dtProcMc.Rows[0]["MC_CODE"].ToString();

                            string mc_group = CTRL.CTRL.GetPartToMcGroup(row["PART_CODE"].ToString(), row["PROC_CODE"].ToString(), row["PT_ID"].ToString(), bizExecute); ;

                            UTIL.SetBizAddColumnToValue(dtRow, "MC_GROUP", mc_group, typeof(string));
                            //작업자 정보
                            //DataTable dtMcEmp = DLSE.LSE_MACHINE.LSE_MACHINE_SER(dtRow, bizExecute);
                            //string strEmpCode = "";
                            //if (dtMcEmp.Rows.Count > 0) strEmpCode = dtMcEmp.Rows[0]["MAIN_EMP"].ToString();
                            //UTIL.SetBizAddColumnToValue(dtRow, "EMP_CODE", strEmpCode, typeof(string));
                            //작업지시 상태
                            UTIL.SetBizAddColumnToValue(dtRow, "WO_FLAG", "1", typeof(string));
                            //작업지시 타입
                            UTIL.SetBizAddColumnToValue(dtRow, "WO_TYPE", "0", typeof(string));
                            //우선순위
                            UTIL.SetBizAddColumnToValue(dtRow, "JOB_PRIORITY", "2", typeof(string));
                            //
                            UTIL.SetBizAddColumnToValue(dtRow, "ACT_INPUT_TYPE", "IN", typeof(string));
                            //작업일 작업시간으로 변경
                            //UTIL.SetBizAddColumnToValue(dtRow, "PLN_START_TIME", dtRow.Rows[0]["PLN_START_DATE"].ToString() + "0800", typeof(string));
                            ////작업일 작업시간으로 변경
                            //UTIL.SetBizAddColumnToValue(dtRow, "PLN_END_TIME", dtRow.Rows[0]["PLN_END_DATE"].ToString() + "0800", typeof(string));

                            DSHP.TSHP_WORKORDER.TSHP_WORKORDER_INS(dtRow, bizExecute);


                            if (dtRow.Rows[0]["IS_DES_CHANGE"].ToString() != "0")
                            {
                                DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD2_2(dtRow, bizExecute);
                            }
                        }
                    }

                    ////출하공정 체크
                    //if (dtRow.Rows.Count > 0)
                    //{
                    //    DataTable paramTable = dtRow.Clone();
                    //    DataRow paramRow = paramTable.NewRow();
                    //    paramRow.ItemArray = dtRow.Rows[0].ItemArray;
                    //    paramRow["PROC_CODE"] = "P-13";
                    //    paramTable.Rows.Add(paramRow);

                    //    DataTable procTable = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER2(paramTable, bizExecute);

                    //    foreach (DataRow rw in procTable.Rows)
                    //    {
                    //        if (rw["DATA_FLAG"].ToString() == "0" && rw["WO_FLAG"].ToString() == "0")
                    //        {
                    //            rw["WO_FLAG"] = "1";

                    //            DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD5_5(UTIL.GetRowToDt(rw), bizExecute);
                    //        }
                    //    }

                    //}

                }




                //DataTable dtRslt = DLSE.LSE_STD_PARTPROC.LSE_STD_PARTPROC_SER2(dtRqst_Copy, bizExecute);

                //dtRslt.TableName = "RSLTDT";

                //paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 수주별 가공품별 작업지시에 대해 부하율을 고려하여 외주 작업지시 추가 및 이후공정을 제외한 모든 작업지시 삭제
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet PLN02A_UPD2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "IS_WO_PART", "1", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(byte));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WO_TYPE", "PRC", typeof(string));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtPartList = DMAT.TMAT_PARTLIST_QUERY.TMAT_PARTLIST_QUERY2(UTIL.GetRowToDt(row), bizExecute);

                    DataTable dtRslt = dtPartList.Clone();
                    dtRslt.TableName = "RSLTDT";

                    foreach (DataRow part_row in dtPartList.Rows)
                    {
                        //if (part_row["MC_GROUP"].isNullOrEmpty())
                        //    continue;

                        //DateTime now = UTIL.UTILITY_GET_NOW(bizExecute);

                        //string start_date = now.toDateString("yyyyMMdd");
                        //string end_date = now.toDateString("yyyyMMdd");

                        DataTable dtDate = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY28(UTIL.GetRowToDt(part_row), bizExecute);

                        foreach (DataRow rowDate in dtDate.Rows)
                        {
                            if (rowDate["MC_GROUP"].isNullOrEmpty())
                                continue;

                            DataTable dtParam = new DataTable("RQSTDT");
                            UTIL.SetBizAddColumnToValue(dtParam, "PLT_CODE", ConnInfo.PLT_CODE, typeof(string));
                            UTIL.SetBizAddColumnToValue(dtParam, "MC_GROUP", rowDate["MC_GROUP"], typeof(string));
                            UTIL.SetBizAddColumnToValue(dtParam, "S_DATE", rowDate["PLN_START_DATE"], typeof(string));
                            UTIL.SetBizAddColumnToValue(dtParam, "E_DATE", rowDate["PLN_END_DATE"], typeof(string));

                            //PLAN_RATE
                            DataTable dtOverLoadRate = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY27(dtParam, bizExecute);
                            if (dtOverLoadRate.Rows.Count > 0)
                            {
                                //부하율이 100%이상이면
                                if (dtOverLoadRate.Rows[0]["PLAN_RATE"].toDouble() >= 1.0)
                                {
                                    //외주공정 프로세스
                                    SetOsWorkOrderCreate(part_row, "0", bizExecute);

                                    dtRslt.ImportRow(part_row);

                                    break;
                                }
                            }
                        }

                    }

                    paramDS.Merge(dtRslt);
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PLN02A_UPD3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DORD.TORD_PRODUCT.TORD_PRODUCT_UPD14(UTIL.GetRowToDt(row), bizExecute);
                }

                return PLN02A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PLN02A_UPD4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DMAT.TMAT_PARTLIST.TMAT_PARTLIST_UPD13(UTIL.GetRowToDt(row), bizExecute);
                }

                return PLN02A_SER2(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PLN02A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                string day_close = UTIL.GetConfValue("DAY_CLOSE_TIME", bizExecute);

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtRow = UTIL.GetRowToDt(row);

                    DataTable dtSer = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER16(dtRow, bizExecute);

                    if (dtSer.Rows.Count > 0)
                    {
                        DSHP.TSHP_WORKORDER.TSHP_WORKORDER_DEL(dtRow, bizExecute);
                    }

                    UTIL.SetBizAddColumnToValue(dtRow, "WO_PART", "1", typeof(string));

                    DMAT.TMAT_PARTLIST.TMAT_PARTLIST_UPD7(dtRow, bizExecute);

                    SetWorkOrderCreate(row, "", bizExecute);

                }
                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PLN02A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WO_PART", "0", typeof(string));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable isIng = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER17(UTIL.GetRowToDt(row), bizExecute);

                    if (isIng.Rows.Count > 0)
                    {
                        throw UTIL.SetException("진행중인 품목은 삭제할 수 없습니다."
                          , new System.Diagnostics.StackFrame().GetMethod().Name
                          , BizException.ABORT);
                    }

                    DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UDE3(UTIL.GetRowToDt(row), bizExecute);

                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(string));
                    paramTable.Columns.Add("PROD_CODE", typeof(string));
                    paramTable.Columns.Add("PT_ID", typeof(string));

                    DataRow newRow = paramTable.NewRow();
                    newRow["PLT_CODE"] = row["PLT_CODE"];
                    newRow["PROD_CODE"] = row["PROD_CODE"];
                    newRow["PT_ID"] = row["PT_ID"];
                    paramTable.Rows.Add(newRow);

                    DataTable woTable = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER3(paramTable, bizExecute);

                    if (woTable.Rows.Count == 0)
                    {
                        DMAT.TMAT_PARTLIST.TMAT_PARTLIST_UPD7(UTIL.GetRowToDt(row), bizExecute);
                    }
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        private static void SetWorkOrderCreate(DataRow row, string type, BizExecute.BizExecute bizExecute)
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


            DataTable partDt = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER15(dtParam, bizExecute);

            int part_id = 0;

            if (partDt.Rows.Count > 0)
            {
                part_id = partDt.Rows[0]["PART_ID"].toInt() + 1;
            }

            foreach (DataRow part_row in dtPartList.Rows)
            {
                DataTable dtSer = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER3(UTIL.GetRowToDt(part_row), bizExecute);

                if (dtSer.Rows.Count > 0)
                    continue;

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

                part_row["ROUT_CODE"] = rout_group;

                part_row["MC_GROUP"] = mc_group;
                //라우트 그룹, 설비 그룹 파트 리스트에 저장
                DMAT.TMAT_PARTLIST.TMAT_PARTLIST_UPD2(UTIL.GetRowToDt(part_row), bizExecute);

                dtParam.Rows[0]["ROUT_CODE"] = rout_group;

                //DataTable dtProc = DLSE.LSE_STD_PROC_QUERY.LSE_STD_PROC_QUERY1(dtParam, bizExecute);

                DataTable dtProc = DSTD.TSTD_ROUTING.TSTD_ROUTING_SER2(dtParam, bizExecute);

                int proc_id = 0;

                if (part_row["ORD_QTY"].toInt() > 0)
                {
                    part_row["PART_QTY"] = part_row["PART_QTY"].toInt() * part_row["ORD_QTY"].toInt() * part_row["O_PART_QTY"].toInt();
                }
                else
                {
                    part_row["PART_QTY"] = part_row["PART_QTY"].toInt() * part_row["PROD_QTY"].toInt() * part_row["O_PART_QTY"].toInt();
                }

                foreach (DataRow proc_row in dtProc.Rows)
                {
                    DataTable dtRow = new DataTable("RQSTDT");
                    UTIL.SetBizAddColumnToValue(dtRow, "PLT_CODE", ConnInfo.PLT_CODE, typeof(string));
                    //작지 번호
                    string strSerialWO = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "W", bizExecute);
                    UTIL.SetBizAddColumnToValue(dtRow, "WO_NO", strSerialWO, typeof(string));

                    UTIL.SetBizAddColumnToValue(dtRow, "PROD_CODE", part_row["PROD_CODE"], typeof(string));

                    UTIL.SetBizAddColumnToValue(dtRow, "PT_ID", part_row["PT_ID"], typeof(string));

                    UTIL.SetBizAddColumnToValue(dtRow, "PART_CODE", part_row["PART_CODE"], typeof(string));

                    UTIL.SetBizAddColumnToValue(dtRow, "PT_NAME", part_row["PART_NAME"], typeof(string));

                    //if (dtProcMc.Rows.Count > 0) strMcCode = dtProcMc.Rows[0]["MC_CODE"].ToString();
                    mc_group = CTRL.CTRL.GetPartToMcGroup(part_row["PART_CODE"].ToString(), proc_row["PROC_CODE"].ToString(), part_row["PT_ID"].ToString(), bizExecute);

                    //if (proc_row["PROC_CODE"].ToString() == "P-07")
                    //{
                    //    mc_group = "F";
                    //}

                    UTIL.SetBizAddColumnToValue(dtRow, "MC_GROUP", mc_group, typeof(string));

                    UTIL.SetBizAddColumnToValue(dtRow, "PART_ID", part_id, typeof(int));

                    UTIL.SetBizAddColumnToValue(dtRow, "PROC_ID", proc_id, typeof(int));

                    UTIL.SetBizAddColumnToValue(dtRow, "PROC_CODE", proc_row["PROC_CODE"], typeof(string));

                    UTIL.SetBizAddColumnToValue(dtRow, "PART_QTY", part_row["PART_QTY"], typeof(int));


                    if (row.Table.Columns.Contains("OLD_PROD_CODE"))
                    {
                        DataTable paramCamTable = new DataTable("RQSTDT");
                        paramCamTable.Columns.Add("PLT_CODE", typeof(string));
                        paramCamTable.Columns.Add("PROD_CODE", typeof(string));
                        paramCamTable.Columns.Add("PART_CODE", typeof(string));
                        paramCamTable.Columns.Add("PROC_CODE", typeof(string));

                        DataRow paramCamRow = paramCamTable.NewRow();
                        paramCamRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                        paramCamRow["PROD_CODE"] = row["OLD_PROD_CODE"];
                        paramCamRow["PART_CODE"] = part_row["PART_CODE"];
                        paramCamRow["PROC_CODE"] = proc_row["PROC_CODE"];

                        paramCamTable.Rows.Add(paramCamRow);

                        DataTable dtCAMSer = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER11(paramCamTable, bizExecute);

                        if (dtCAMSer.Rows.Count > 0)
                        {
                            UTIL.SetBizAddColumnToValue(dtRow, "CAM_EMP", dtCAMSer.Rows[0]["CAM_EMP"].ToString(), typeof(string));
                        }
                    }

                    //작업자 정보는 사용하지 않는다.
                    //DataTable dtMcEmp = DLSE.LSE_MACHINE.LSE_MACHINE_SER(dtRow, bizExecute);
                    //string strEmpCode = "";
                    //if (dtMcEmp.Rows.Count > 0) strEmpCode = dtMcEmp.Rows[0]["MAIN_EMP"].ToString();

                    string wo_flag = "0";
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

                        //설계일경우
                        if (wo_type == "DES")
                        {
                            wo_flag = "4";
                            //BOM등록일 가져오기
                            //DataTable dtSerPt = DMAT.TMAT_PARTLIST.TMAT_PARTLIST_SER(UTIL.GetRowToDt(row), bizExecute);
                            //if (dtSerPt.Rows.Count > 0)
                            {
                                if (type == "RE")
                                {
                                    //설계계획 시작시간을 BOM등록 시간에서 표준공수를 뺀시간
                                    //UTIL.SetBizAddColumnToValue(dtRow, "PLN_START_TIME", part_row["REG_DATE"].toDateTime().AddMinutes(-proc_time).toDateString("yyyyMMddHHmm"), typeof(string));
                                    //설계계획 시작 시간을 BOM등록시간으로
                                    UTIL.SetBizAddColumnToValue(dtRow, "PLN_START_TIME", part_row["REG_DATE"].toDateTime().toDateString("yyyyMMddHHmm"), typeof(string));
                                    //설계계획 완료 시간을 BOM등록시간으로
                                    UTIL.SetBizAddColumnToValue(dtRow, "PLN_END_TIME", part_row["REG_DATE"].toDateTime().toDateString("yyyyMMddHHmm"), typeof(string));

                                    //설계실적 시작시간을 BOM등록 시간에서 표준공수를 뺀시간
                                    //UTIL.SetBizAddColumnToValue(dtRow, "ACT_START_TIME", part_row["REG_DATE"].toDateTime().AddMinutes(-proc_time), typeof(DateTime));

                                    //설계실적 시작 시간을 BOM등록시간으로
                                    UTIL.SetBizAddColumnToValue(dtRow, "ACT_START_TIME", part_row["REG_DATE"].toDateTime(), typeof(DateTime));
                                    //설계실적 완료 시간을 BOM등록시간으로
                                    UTIL.SetBizAddColumnToValue(dtRow, "ACT_END_TIME", part_row["REG_DATE"].toDateTime(), typeof(DateTime));
                                }
                                else
                                {
                                    //설계계획 시작시간을 BOM등록 시간에서 표준공수를 뺀시간
                                    UTIL.SetBizAddColumnToValue(dtRow, "PLN_START_TIME", part_row["REG_DATE"].toDateTime().AddMinutes(-proc_time).toDateString("yyyyMMddHHmm"), typeof(string));
                                    //설계계획 완료 시간을 BOM등록시간으로
                                    UTIL.SetBizAddColumnToValue(dtRow, "PLN_END_TIME", part_row["REG_DATE"].toDateTime().toDateString("yyyyMMddHHmm"), typeof(string));

                                    //설계실적 시작시간을 BOM등록 시간에서 표준공수를 뺀시간
                                    UTIL.SetBizAddColumnToValue(dtRow, "ACT_START_TIME", part_row["REG_DATE"].toDateTime().AddMinutes(-proc_time), typeof(DateTime));

                                    //설계실적 완료 시간을 BOM등록시간으로
                                    UTIL.SetBizAddColumnToValue(dtRow, "ACT_END_TIME", part_row["REG_DATE"].toDateTime(), typeof(DateTime));
                                }
                            }
                        }
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
                            if (type == "RE")
                            {
                                proc_time = 5;
                            }
                            else
                            {
                                if (camTime > 0)
                                {
                                    proc_time = camTime;
                                }
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
                        //조립품(어쎄이) 공정중 PROC_ID가 '0'인 공정 가져온다.
                        //조립품 라우팅을 가져온다.
                        //계획 시작시간이 dtRow["PLN_END_TIME"]보다 작을경우 해당시간으로 시간 계산해서 업데이트
                        DataTable dtAsseyPart = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY34(dtRow, bizExecute);

                        if (dtAsseyPart.Rows.Count > 0)
                        {
                            if (dtAsseyPart.Rows[0]["PLN_START_TIME"].toDateTime() < dtRow.Rows[0]["PLN_END_TIME"].toDateTime())
                            {
                                DataTable dtAsseyRout = DMAT.TMAT_PARTLIST.TMAT_PARTLIST_SER(dtAsseyPart, bizExecute);

                                if (dtAsseyRout.Rows.Count > 0)
                                {
                                    DataTable dtRout = new DataTable("RQSTDT");
                                    dtRout.Columns.Add("PLT_CODE", typeof(string));
                                    dtRout.Columns.Add("ROUT_CODE", typeof(string));

                                    DataRow routRow = dtRout.NewRow();
                                    routRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                                    routRow["ROUT_CODE"] = dtAsseyRout.Rows[0]["ROUT_CODE"];
                                    dtRout.Rows.Add(routRow);

                                    DataTable dtAsseyProc = DSTD.TSTD_ROUTING.TSTD_ROUTING_SER2(dtRout, bizExecute);

                                    lastTime = dtRow.Rows[0]["PLN_END_TIME"].toDateTime();

                                    foreach (DataRow asseyRow in dtAsseyProc.Rows)
                                    {
                                        DataTable dtWo = new DataTable("RQSTDT");
                                        dtWo.Columns.Add("PLT_CODE", typeof(string));
                                        dtWo.Columns.Add("PROD_CODE", typeof(string));
                                        dtWo.Columns.Add("PART_CODE", typeof(string));
                                        dtWo.Columns.Add("PROC_CODE", typeof(string));

                                        DataRow woRow = dtWo.NewRow();
                                        woRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                                        woRow["PROD_CODE"] = dtRow.Rows[0]["PROD_CODE"];
                                        woRow["PART_CODE"] = dtAsseyPart.Rows[0]["PART_CODE"];
                                        woRow["PROC_CODE"] = asseyRow["PROC_CODE"];
                                        dtWo.Rows.Add(woRow);

                                        DataTable dtAsseyWo = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER10(dtWo, bizExecute);

                                        if (dtAsseyWo.Rows.Count > 0)
                                        {
                                            proc_time = dtAsseyWo.Rows[0]["PLN_PROC_TIME"].toDouble();

                                            dtAsseyWo.Rows[0]["PLN_START_TIME"] = lastTime.toDateString("yyyyMMddHHmm");
                                            dtAsseyWo.Rows[0]["PLN_END_TIME"] = lastTime.AddMinutes(proc_time).toDateString("yyyyMMddHHmm");

                                            if (proc_row["WORK_START_TIME"].toStringEmpty() != "")
                                            {
                                                int startTime = dtAsseyWo.Rows[0]["PLN_END_TIME"].toDateString("HHmm").toInt();
                                                int procStartTime = proc_row["WORK_START_TIME"].toInt();
                                                int procEndTime = proc_row["WORK_END_TIME"].toInt();

                                                if (procEndTime < startTime)
                                                {
                                                    //종료시간이 공정 가용시간 @WORK_END_TIME 보다 크거나
                                                    //@WORK_END_TIME 부터 종료시간까지차이를 다음날 @WORK_START_TIME 이후로 붙여준다

                                                    DateTime tempTime = (dtAsseyWo.Rows[0]["PLN_END_TIME"].toDateString("yyyyMMdd") + proc_row["WORK_END_TIME"].ToString()).toDateTime();
                                                    TimeSpan ts = dtAsseyWo.Rows[0]["PLN_END_TIME"].toDateTime().Subtract(tempTime);
                                                    dtAsseyWo.Rows[0]["PLN_END_TIME"] = (dtAsseyWo.Rows[0]["PLN_END_TIME"].toDateTime().AddDays(1).toDateString("yyyyMMdd") + proc_row["WORK_START_TIME"].ToString()).toDateTime().toDateString("yyyyMMddHHmm");
                                                    dtAsseyWo.Rows[0]["PLN_END_TIME"] = dtAsseyWo.Rows[0]["PLN_END_TIME"].toDateTime().AddMinutes(ts.TotalMinutes).toDateString("yyyyMMddHHmm");

                                                }
                                                else if (procStartTime > startTime)
                                                {
                                                    //종료시간이 공정 가용시간 @WORK_START_TIME 보다 작으면
                                                    //@WORK_END_TIME 부터 종료시간까지차이를 다음날 @WORK_START_TIME 이후로 붙여준다
                                                    DateTime tempTime = (dtAsseyWo.Rows[0]["PLN_END_TIME"].toDateTime().AddDays(-1).toDateString("yyyyMMdd") + proc_row["WORK_END_TIME"].ToString()).toDateTime();
                                                    TimeSpan ts = dtAsseyWo.Rows[0]["PLN_END_TIME"].toDateTime().Subtract(tempTime);
                                                    dtAsseyWo.Rows[0]["PLN_END_TIME"] = (dtAsseyWo.Rows[0]["PLN_END_TIME"].toDateTime().toDateString("yyyyMMdd") + proc_row["WORK_START_TIME"].ToString()).toDateTime().toDateString("yyyyMMddHHmm");
                                                    dtAsseyWo.Rows[0]["PLN_END_TIME"] = dtAsseyWo.Rows[0]["PLN_END_TIME"].toDateTime().AddMinutes(ts.TotalMinutes).toDateString("yyyyMMddHHmm");
                                                }
                                            }


                                            bool isAseeyEnd = true;
                                            while (isAseeyEnd)
                                            {
                                                if (dtAsseyWo.Rows[0]["PLN_END_TIME"].toDateTime().DayOfWeek == DayOfWeek.Saturday
                                                    || dtAsseyWo.Rows[0]["PLN_END_TIME"].toDateTime().DayOfWeek == DayOfWeek.Sunday)
                                                {
                                                    dtAsseyWo.Rows[0]["PLN_END_TIME"] = dtAsseyWo.Rows[0]["PLN_END_TIME"].toDateTime().AddDays(1).toDateString("yyyyMMddHHmm");
                                                }
                                                else if (dtHoliDay.Select("HOLI_DATE = '" + dtAsseyWo.Rows[0]["PLN_END_TIME"].toDateString("yyyyMMdd") + "'").Length > 0)
                                                {
                                                    dtAsseyWo.Rows[0]["PLN_END_TIME"] = dtAsseyWo.Rows[0]["PLN_END_TIME"].toDateTime().AddDays(1).toDateString("yyyyMMddHHmm");
                                                }
                                                else
                                                {
                                                    isAseeyEnd = false;
                                                }
                                            }

                                            lastTime = dtAsseyWo.Rows[0]["PLN_END_TIME"].toDateTime();

                                            DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD17(UTIL.GetRowToDt(dtAsseyWo.Rows[0]), bizExecute);
                                        }
                                    }
                                }
                            }
                        }
                    }

                    foreach (DataRow sideRow in dtRow.Rows)
                    {
                        if (sideRow["PROC_CODE"].ToString() == "P-07")
                        {
                            sideRow["MC_GROUP"] = "F";
                        }
                    }

                    //작지가 있으면 UPDATE, 있으면 INSERT로 바꿀것
                    DSHP.TSHP_WORKORDER.TSHP_WORKORDER_INS(dtRow, bizExecute);

                    proc_id++;
                }

                part_id++;
            }

        }



        /// <summary>
        /// 외주 공정 처리 프로세스(디플러스 전용)
        /// </summary>
        /// <param name="row">가공품</param>
        /// <param name="bizExecute"></param>
        public static void SetOsWorkOrderCreate(DataRow row, string isOrd, BizExecute.BizExecute bizExecute)
        {
            //일마감 시간 가져오기
            string day_close = UTIL.GetConfValue("DAY_CLOSE_TIME", bizExecute);

            DataTable dtNow = UTIL.UTILITY_GET_DTNOW(bizExecute);
            int part_id = 0;
            
            //외주 공정 정보 가져오기 P14
            DataTable dtOsProc = CTRL.CTRL.GetOsProc(bizExecute);

            if(dtOsProc.Rows.Count == 0)
                throw UTIL.SetException("외주 공정이 없습니다."
                          , new System.Diagnostics.StackFrame().GetMethod().Name
                          , BizException.ABORT);

            string wo_flag = "1";//작업지시 상태

            DataTable dtSer2 = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER8_2(UTIL.GetRowToDt(row), bizExecute);

            DataRow[] rows = dtSer2.Select("PROC_CODE = 'P-06'");

            if (rows.Length == 0)
            {
                DataTable dtMidInsProc = CTRL.CTRL.GetMidInsProc(bizExecute);
                //중간검사없으면 생성후 재조회
                DataTable dtINSRow = new DataTable("RQSTDT");
                //사업장코드
                UTIL.SetBizAddColumnToValue(dtINSRow, "PLT_CODE", ConnInfo.PLT_CODE, typeof(string));
                //제품코드(수주코드)
                UTIL.SetBizAddColumnToValue(dtINSRow, "PROD_CODE", row["PROD_CODE"], typeof(string));
                //파트 ID
                UTIL.SetBizAddColumnToValue(dtINSRow, "PT_ID", row["PT_ID"], typeof(string));
                //품목코드
                UTIL.SetBizAddColumnToValue(dtINSRow, "PART_CODE", row["PART_CODE"], typeof(string));
                //품목명
                UTIL.SetBizAddColumnToValue(dtINSRow, "PT_NAME", row["PART_NAME"], typeof(string));
                //설비그룹
                UTIL.SetBizAddColumnToValue(dtINSRow, "MC_GROUP", null, typeof(string));
                //공정 SEQ
                UTIL.SetBizAddColumnToValue(dtINSRow, "PROC_ID", 1, typeof(int));
                //공정코드
                UTIL.SetBizAddColumnToValue(dtINSRow, "PROC_CODE", "P-06", typeof(string));

                int qty = 0;

                if (row["ORD_QTY"].toInt() > 0)
                {
                    qty = row["PART_QTY"].toInt() * row["ORD_QTY"].toInt() * row["O_PART_QTY"].toInt();
                }
                else
                {
                    qty = row["PART_QTY"].toInt() * row["PROD_QTY"].toInt() * row["O_PART_QTY"].toInt();
                }


                //가공 수량
                UTIL.SetBizAddColumnToValue(dtINSRow, "PART_QTY", qty, typeof(int));
                //작업지시 상태
                UTIL.SetBizAddColumnToValue(dtINSRow, "WO_FLAG", wo_flag, typeof(string));
                //작업지시 타입(용도 모름, 사용 안함)
                UTIL.SetBizAddColumnToValue(dtINSRow, "WO_TYPE", "0", typeof(string));
                //우선순위(보통)
                UTIL.SetBizAddColumnToValue(dtINSRow, "JOB_PRIORITY", "2", typeof(string));
                //사용 X
                UTIL.SetBizAddColumnToValue(dtINSRow, "ACT_INPUT_TYPE", "IN", typeof(string));
                //가공 예상 시간(분)
                UTIL.SetBizAddColumnToValue(dtINSRow, "PLN_PROC_TIME", dtMidInsProc.Rows[0]["PROC_MAN_TIME"].toDouble(), typeof(double));
                UTIL.SetBizAddColumnToValue(dtINSRow, "PLN_PROC_MAN_TIME", dtMidInsProc.Rows[0]["PROC_MAN_TIME"].toDouble(), typeof(double));
                //설계가 아닐경우
                //작업일 작업시간으로 변경
                UTIL.SetBizAddColumnToValue(dtINSRow, "PLN_START_TIME", DateTime.Now.toDateString("yyyyMMddHHmm"), typeof(string));
                //작업일 작업시간으로 변경
                UTIL.SetBizAddColumnToValue(dtINSRow, "PLN_END_TIME", DateTime.Now.AddMinutes(dtMidInsProc.Rows[0]["PROC_MAN_TIME"].toDouble()).toDateString("yyyyMMddHHmm"), typeof(string));

                if (dtSer2.Rows.Count > 0)
                {
                    part_id = dtSer2.Rows[0]["PART_ID"].toInt();
                }

                UTIL.SetBizAddColumnToValue(dtINSRow, "PART_ID", part_id, typeof(int));

                //작지 번호
                string strSerialWO = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "W", bizExecute);
                UTIL.SetBizAddColumnToValue(dtINSRow, "WO_NO", strSerialWO, typeof(string));
                DSHP.TSHP_WORKORDER.TSHP_WORKORDER_INS(dtINSRow, bizExecute);
            }
            else
            {
                if (rows[0]["DATA_FLAG"].ToString() == "2")
                {
                    DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD4_3(UTIL.GetRowToDt(rows[0]), bizExecute);
                }
            }

            DataTable dtSer = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER8(UTIL.GetRowToDt(row), bizExecute);

            //DataTable dtProc = DLSE.LSE_STD_PROC.LSE_STD_PROC_SER(dtRow, bizExecute);
            string is_os = "1";
            //기본 외주업체
            string os_vnd = dtOsProc.Rows[0]["MAIN_VND"].ToString();
            //가공시간
            double proc_time = dtOsProc.Rows[0]["PROC_MAN_TIME"].toDouble();
            //
            //string wo_type = dtOsProc.Rows[0]["WO_TYPE"].ToString();


            int proc_id = 1;
            //부품리스트 등록일이 설계완료일, 설계완료 12시간 이후, 해당부품에 설계 공정이 없을경우 임의로 가공 시작 시간 설정
            DateTime lastTime = row["REG_DATE"].toDateTime().AddHours(12);

            //외주 가공 계획 시간
            DateTime pln_start_time = lastTime;
            DateTime pln_end_time = lastTime.AddMinutes(proc_time);

            foreach (DataRow proc_row in dtSer.Rows)
            {

                part_id = proc_row["PART_ID"].toInt();
                //설계공정은 기본적으로 BOM등록되는 순간 완료 실적 처리됨
                if (proc_row["WO_TYPE"].ToString() == "DES")// proc_row["PROC_SEQ"].toInt() == 0)
                {
                    //설계 작지의 계획 완료시간을 외주 공정 시작 계획시간으로 가져온다.
                    lastTime = proc_row["PLN_END_TIME"].toDateTime().AddHours(12);

                    //계획 시작 시간이 일요일이면 다음날 일마감 시간으로 변경한다.
                    if (lastTime.DayOfWeek == DayOfWeek.Sunday)
                    {
                        lastTime = lastTime.AddDays(1);
                        lastTime = (lastTime.Year.ToString() + lastTime.Month.ToString() + lastTime.Day.ToString() + day_close).toDateTime();
                    }
                    //외주가공 시작시간
                    pln_start_time = lastTime;
                    //외주가가오 완료시간
                    pln_end_time = lastTime.AddMinutes(proc_time);
                    //다음공정 시작시간
                    lastTime = pln_end_time;
                    //설계공정은 skip : 
                    continue;
                }

                //if (proc_row["PROC_SEQ"].toInt() == dtOsProc.Rows[0]["PROC_SEQ"].toInt())
                //{
                //    DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD42(UTIL.GetRowToDt(proc_row), bizExecute);
                //}

                //공정외주보다 이후인 공정인경우 공정 순서 변경
                if(proc_row["PROC_SEQ"].toInt() > dtOsProc.Rows[0]["PROC_SEQ"].toInt())
                {
                    if (proc_row["PROC_CODE"].ToString() == "P-07")
                    {
                        DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UDE(UTIL.GetRowToDt(proc_row), bizExecute);
                    }
                    else
                    {
                        proc_row["PROC_ID"] = proc_id;

                        proc_row["PLN_START_TIME"] = lastTime.toDateString("yyyyMMddHHmm");

                        proc_row["PLN_END_TIME"] = lastTime.AddMinutes(proc_row["PLN_PROC_TIME"].toInt()).toDateString("yyyyMMddHHmm");

                        lastTime = lastTime.AddMinutes(proc_row["PLN_PROC_TIME"].toInt());

                        DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD3(UTIL.GetRowToDt(proc_row), bizExecute);

                        proc_id++;
                    }
                }
                else
                {
                    //중간검사 체크유지
                    if (proc_row["PROC_CODE"].ToString() == "P-06")
                    {
                        proc_row["PROC_ID"] = proc_id;

                        proc_row["PLN_START_TIME"] = lastTime.toDateString("yyyyMMddHHmm");

                        proc_row["PLN_END_TIME"] = lastTime.AddMinutes(proc_row["PLN_PROC_TIME"].toInt()).toDateString("yyyyMMddHHmm");

                        lastTime = lastTime.AddMinutes(proc_row["PLN_PROC_TIME"].toInt());

                        DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD3_2(UTIL.GetRowToDt(proc_row), bizExecute);

                        proc_id++;
                    }
                    else
                    {
                        DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UDE(UTIL.GetRowToDt(proc_row), bizExecute);
                    }
                }
            }

            if (row["ORD_QTY"].toInt() > 0)
            {
                row["PART_QTY"] = row["PART_QTY"].toInt() * row["ORD_QTY"].toInt() * row["O_PART_QTY"].toInt();
            }
            else
            {
                row["PART_QTY"] = row["PART_QTY"].toInt() * row["PROD_QTY"].toInt() * row["O_PART_QTY"].toInt();
            }


            #region 외주 공정 추가
            DataTable dtRow = new DataTable("RQSTDT");
            //사업장코드
            UTIL.SetBizAddColumnToValue(dtRow, "PLT_CODE", ConnInfo.PLT_CODE, typeof(string));
            //제품코드(수주코드)
            UTIL.SetBizAddColumnToValue(dtRow, "PROD_CODE", row["PROD_CODE"], typeof(string));
            //파트 ID
            UTIL.SetBizAddColumnToValue(dtRow, "PT_ID", row["PT_ID"], typeof(string));
            //품목코드
            UTIL.SetBizAddColumnToValue(dtRow, "PART_CODE", row["PART_CODE"], typeof(string));
            //품목명
            UTIL.SetBizAddColumnToValue(dtRow, "PT_NAME", row["PART_NAME"], typeof(string));
            //설비그룹
            UTIL.SetBizAddColumnToValue(dtRow, "MC_GROUP", null, typeof(string));
            //공정 SEQ
            UTIL.SetBizAddColumnToValue(dtRow, "PROC_ID", 2, typeof(int));
            //공정코드
            UTIL.SetBizAddColumnToValue(dtRow, "PROC_CODE", dtOsProc.Rows[0]["PROC_CODE"], typeof(string));
            //가공 수량
            UTIL.SetBizAddColumnToValue(dtRow, "PART_QTY", row["PART_QTY"], typeof(int));            
            //외주 가공 여부
            UTIL.SetBizAddColumnToValue(dtRow, "IS_OS", is_os, typeof(string));
            //기본 외주 업체
            UTIL.SetBizAddColumnToValue(dtRow, "OS_VND", os_vnd, typeof(string));            
            //작업지시 상태
            UTIL.SetBizAddColumnToValue(dtRow, "WO_FLAG", wo_flag, typeof(string));
            //작업지시 타입(용도 모름, 사용 안함)
            UTIL.SetBizAddColumnToValue(dtRow, "WO_TYPE", "0", typeof(string));
            //우선순위(보통)
            UTIL.SetBizAddColumnToValue(dtRow, "JOB_PRIORITY", "2", typeof(string));
            //사용 X
            UTIL.SetBizAddColumnToValue(dtRow, "ACT_INPUT_TYPE", "IN", typeof(string));
            //가공 예상 시간(분)
            UTIL.SetBizAddColumnToValue(dtRow, "PLN_PROC_TIME", proc_time, typeof(double));
            UTIL.SetBizAddColumnToValue(dtRow, "PLN_PROC_MAN_TIME", proc_time, typeof(double));
            //설계가 아닐경우
            //작업일 작업시간으로 변경
            UTIL.SetBizAddColumnToValue(dtRow, "PLN_START_TIME", pln_start_time.toDateString("yyyyMMddHHmm"), typeof(string));
            //작업일 작업시간으로 변경
            UTIL.SetBizAddColumnToValue(dtRow, "PLN_END_TIME", pln_end_time.AddMinutes(proc_time).toDateString("yyyyMMddHHmm"), typeof(string));

            //공정외주 추가
            UTIL.SetBizAddColumnToValue(dtRow, "PART_ID", part_id, typeof(int));

            UTIL.SetBizAddColumnToValue(dtRow, "IS_ORD", isOrd, typeof(string));

            if (isOrd == "1")
            {
                UTIL.SetBizAddColumnToValue(dtRow, "OS_ORD_EMP", row["OS_ORD_EMP"], typeof(string));
                UTIL.SetBizAddColumnToValue(dtRow, "OS_ORD_DATE", row["OS_ORD_DATE"], typeof(string));
            }

            DataTable woTable = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER14(dtRow, bizExecute);

            if (woTable.Rows.Count > 0)
            {
                UTIL.SetBizAddColumnToValue(dtRow, "WO_NO", woTable.Rows[0]["WO_NO"], typeof(string)); 
                UTIL.SetBizAddColumnToValue(dtRow, "DATA_FLAG", 0, typeof(byte));

                if (woTable.Rows[0]["WO_FLAG"].ToString() == "2"
                    || woTable.Rows[0]["WO_FLAG"].ToString() == "3"
                    || woTable.Rows[0]["WO_FLAG"].ToString() == "4")
                {
                    UTIL.SetBizAddColumnToValue(dtRow, "WO_FLAG", woTable.Rows[0]["WO_FLAG"].ToString(), typeof(string));
                }

                DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD43(dtRow, bizExecute);
            }
            else
            {
                //작지 번호
                string strSerialWO = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "W", bizExecute);
                UTIL.SetBizAddColumnToValue(dtRow, "WO_NO", strSerialWO, typeof(string));
                DSHP.TSHP_WORKORDER.TSHP_WORKORDER_INS(dtRow, bizExecute);
            }
            #endregion
        }


        //모델 정보 가져오기
        //public static DataSet PLN02A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        //{

        //    try
        //    {
        //        //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

        //        DataTable dtRslt = DLSE.LSE_STD_PART_QUERY.LSE_STD_PART_QUERY6(paramDS.Tables["RQSTDT"], bizExecute);

        //        dtRslt.Columns.Add("SEL", typeof(string));
        //        dtRslt.TableName = "RSLTDT";

        //        paramDS.Tables.Add(dtRslt);

        //        return paramDS;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
        //    }

        //}

        ////모델별 부품 정보
        //public static DataSet PLN02A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        //{

        //    try
        //    {
        //        //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

        //        DataTable dtRslt = DLSE.LSE_STD_PART_QUERY.LSE_STD_PART_QUERY7(paramDS.Tables["RQSTDT"], bizExecute);                
        //        dtRslt.TableName = "RSLTDT";
        //        paramDS.Tables.Add(dtRslt);

        //        return paramDS;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
        //    }

        //}

        ////품목별 표준 계획 공정 정보 가져오기
        //public static DataSet PLN02A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        //{

        //    try
        //    {
        //        //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

        //        DataTable dtRslt = DLSE.LSE_STD_PARTPROC_QUERY.LSE_STD_PARTPROC_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
        //        dtRslt.TableName = "RSLTDT";
        //        paramDS.Tables.Add(dtRslt);

        //        return paramDS;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
        //    }

        //}


        ////주차별 계획 정보 가져오기
        //public static DataSet PLN02A_SER4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        //{

        //    try
        //    {
        //        //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

        //        DataTable dtRslt_M = DSHP.TSHP_WORKPLAN_QUERY.TSHP_WORKPLAN_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
        //        dtRslt_M.TableName = "RSLTDT_M";
        //        paramDS.Tables.Add(dtRslt_M);

        //        DataTable dtRslt_D = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
        //        dtRslt_D.TableName = "RSLTDT_D";
        //        paramDS.Tables.Add(dtRslt_D);

        //        return paramDS;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
        //    }

        //}

        ////품목공정 정보 저장
        //public static DataSet PLN02A_SAVE(DataSet paramDS, BizExecute.BizExecute bizExecute)
        //{

        //    try
        //    {
        //        if(paramDS.Tables["RQSTDT_M"].Rows.Count == 0) 
        //        {                    
        //            return paramDS;
        //        }

        //        string strSerialWP = "";

        //        //마스터 저장
        //        DataTable dtRqst_M = paramDS.Tables["RQSTDT_M"];

        //        foreach(DataRow partRow in dtRqst_M.Rows)
        //        {
        //            DataTable dtPart_Copy = UTIL.GetRowToDt(partRow);

        //            //계획 품번 유무 확인
        //            DataTable dtSer_M = DSHP.TSHP_WORKPLAN.TSHP_WORKPLAN_SER(dtPart_Copy, bizExecute);

        //            if(dtSer_M.Rows.Count > 0)
        //            {
        //                //있다면
        //                if (partRow["IS_SAVE"].ToString() == "1")//저장
        //                {
        //                    strSerialWP = partRow["WP_NO"].ToString();
        //                    DSHP.TSHP_WORKPLAN.TSHP_WORKPLAN_UPD(dtPart_Copy, bizExecute);                            
        //                }
        //                else//삭제
        //                {
        //                    DSHP.TSHP_WORKPLAN.TSHP_WORKPLAN_UDE(dtPart_Copy, bizExecute);
        //                }
        //            }
        //            else
        //            {
        //                //없다면
        //                if (partRow["IS_SAVE"].ToString() == "1")
        //                {
        //                    strSerialWP = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "WP", bizExecute);
        //                    UTIL.SetBizAddColumnToValue(dtPart_Copy, "WP_NO", strSerialWP, typeof(string));
        //                    DSHP.TSHP_WORKPLAN.TSHP_WORKPLAN_INS(dtPart_Copy, bizExecute);
        //                }
        //            }

        //            //상세 공정 정보 저장
        //            DataRow[] arRslt_D = paramDS.Tables["RQSTDT_D"].Select("PART_CODE = '"+ partRow["PART_CODE"].ToString() +"'");

        //            foreach (DataRow procRow in arRslt_D)
        //            {
        //                DataTable dtProc_Copy = UTIL.GetRowToDt(procRow);                        

        //                DataTable dtSer_D = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER(dtProc_Copy, bizExecute);

        //                if (dtSer_D.Rows.Count > 0)
        //                {
        //                    if (procRow["IS_SAVE"].ToString() == "1")
        //                    {
        //                        //작업일 작업시간으로 변경
        //                        UTIL.SetBizAddColumnToValue(dtProc_Copy, "PLN_START_TIME", dtProc_Copy.Rows[0]["PLN_START_DATE"].ToString() + "0800", typeof(string));
        //                        //작업일 작업시간으로 변경
        //                        UTIL.SetBizAddColumnToValue(dtProc_Copy, "PLN_END_TIME", dtProc_Copy.Rows[0]["PLN_END_DATE"].ToString() + "0800", typeof(string));

        //                        DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD(dtProc_Copy, bizExecute);
        //                    }
        //                    else
        //                    {
        //                        if (dtSer_D.Rows[0]["WO_FLAG"].ToString() != "0")
        //                        {
        //                            throw UTIL.SetException("작업지시가 이미 진행중이라 삭제 할 수 없습니다.\n\r"
        //                                                     +"다시 확인 하여 주십시오"
        //                            , procRow["WO_NO"].ToString()
        //                            , new System.Diagnostics.StackFrame().GetMethod().Name
        //                            , 200090, dtSer_D.Rows[0]);
        //                        }
        //                        DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UDE(dtProc_Copy, bizExecute);

        //                    }
        //                }
        //                else
        //                {
        //                    if (procRow["IS_SAVE"].ToString() == "1")
        //                    {
        //                        //계획번호
        //                        UTIL.SetBizAddColumnToValue(dtProc_Copy, "WP_NO", strSerialWP, typeof(string));
        //                        //작지 번호
        //                        string strSerialWO = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "W", bizExecute);
        //                        UTIL.SetBizAddColumnToValue(dtProc_Copy, "WO_NO", strSerialWO, typeof(string));

        //                        //설비 정보
        //                        DataTable dtProcMc = DLSE.LSE_STD_AVAILMC.LSE_STD_AVAILMC_SER2(dtProc_Copy, bizExecute);
        //                        string strMcCode = "";
        //                        if (dtProcMc.Rows.Count > 0) strMcCode = dtProcMc.Rows[0]["MC_CODE"].ToString();
        //                        UTIL.SetBizAddColumnToValue(dtProc_Copy, "MC_CODE", strMcCode, typeof(string));
        //                        //작업자 정보
        //                        DataTable dtMcEmp = DLSE.LSE_MACHINE.LSE_MACHINE_SER(dtProc_Copy, bizExecute);
        //                        string strEmpCode = "";
        //                        if (dtMcEmp.Rows.Count > 0) strEmpCode = dtMcEmp.Rows[0]["MAIN_EMP"].ToString();
        //                        UTIL.SetBizAddColumnToValue(dtProc_Copy, "EMP_CODE", strEmpCode, typeof(string));
        //                        //작업지시 상태
        //                        UTIL.SetBizAddColumnToValue(dtProc_Copy, "WO_FLAG", "0", typeof(string));
        //                        //작업지시 타입
        //                        UTIL.SetBizAddColumnToValue(dtProc_Copy, "WO_TYPE", "0", typeof(string));
        //                        //우선순위
        //                        UTIL.SetBizAddColumnToValue(dtProc_Copy, "JOB_PRIORITY", "2", typeof(string));
        //                        //
        //                        UTIL.SetBizAddColumnToValue(dtProc_Copy, "ACT_INPUT_TYPE", "IN", typeof(string));
        //                        //작업일 작업시간으로 변경
        //                        UTIL.SetBizAddColumnToValue(dtProc_Copy, "PLN_START_TIME", dtProc_Copy.Rows[0]["PLN_START_DATE"].ToString() + "0800", typeof(string));
        //                        //작업일 작업시간으로 변경
        //                        UTIL.SetBizAddColumnToValue(dtProc_Copy, "PLN_END_TIME", dtProc_Copy.Rows[0]["PLN_END_DATE"].ToString() + "0800", typeof(string));

        //                        DSHP.TSHP_WORKORDER.TSHP_WORKORDER_INS(dtProc_Copy, bizExecute);
        //                    }
        //                }

        //            }

        //            UTIL.SetBizAddColumnToValue(dtPart_Copy, "IS_LAST", "1", typeof(string));
        //            UTIL.SetBizAddColumnToValue(dtPart_Copy, "PROC_ID", dtPart_Copy.Rows[0]["LAST_PROC_ID"].ToString(), typeof(string));

        //            DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD3(dtPart_Copy, bizExecute);

        //            strSerialWP = "";

        //        }




        //        //DataTable dtRslt = DLSE.LSE_STD_PARTPROC.LSE_STD_PARTPROC_SER2(dtRqst_Copy, bizExecute);

        //        //dtRslt.TableName = "RSLTDT";

        //        //paramDS.Tables.Add(dtRslt);

        //        return paramDS;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
        //    }

        //}


    }
}
