using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BPOP
{
    public class POP20A
    {


   //     /// <summary>
   //     /// 작업지시에 대한 실적번호 조회 쿼리  --> POP04로 변경할것
   //     /// </summary>
   //     /// <param name="paramDS"></param>
   //     /// <param name="bizExecute"></param>
   //     /// <returns></returns>
   //     public static DataSet POP20A_SER1(DataSet paramDS, BizExecute.BizExecute bizExecute)
   //     {
   //         try
   //         {
   //             // ACTUAL_ID 가져오기
   //             DataTable dtRslt = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY11(paramDS.Tables["RQSTDT"], bizExecute);

   //             DataSet dsRslt = new DataSet();

   //             dtRslt.TableName = "RSLTDT";

   //             dsRslt.Tables.Add(dtRslt);
   //             return dsRslt;


   //         }
   //         catch (Exception ex)
   //         {
   //             throw new Exception(ex.Message);
   //         }
   //     }




   //     public static DataSet POP20A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
   //     {
   //         try
   //         {
   //             UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

   //             DataTable dtRslt = DSTD.TSTD_CODES_QUERY.TSTD_CODES_QUERY7(paramDS.Tables["RQSTDT"],  bizExecute);

   //             DataSet dsRslt = new DataSet();

   //             dtRslt.TableName = "RSLTDT";

   //             dsRslt.Tables.Add(dtRslt);

   //             return dsRslt;
   //         }
   //         catch (Exception ex)
   //         {
   //             throw new Exception(ex.Message);
   //         }
   //     }

   //     /// <summary>
   //     /// 단말기 작업지시 조회
   //     /// </summary>
   //     /// <param name="paramDS"></param>
   //     /// <param name="bizExecute"></param>
   //     /// <returns></returns>
   //     public static DataSet POP20A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
   //     {
   //         try
   //         {
   //             UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

   //             DataTable dtRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY5(paramDS.Tables["RQSTDT"], bizExecute);

   //             DataSet dsRslt = new DataSet();

   //             dtRslt.TableName = "RSLTDT";

   //             dsRslt.Tables.Add(dtRslt);

   //             return dsRslt;
   //         }
   //         catch (Exception ex)
   //         {
   //             throw new Exception(ex.Message);
   //         }
   //     }

   //     /// <summary>
   //     /// 단말기 작업지시 조회 [가공]
   //     /// </summary>
   //     /// <param name="paramDS"></param>
   //     /// <param name="bizExecute"></param>
   //     /// <returns></returns>

   //     public static DataSet POP20A_SER3_1(DataSet paramDS, BizExecute.BizExecute bizExecute)
   //     {
   //         try
   //         {
   //             UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

   //             DataTable dtRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY4_1(paramDS.Tables["RQSTDT"], bizExecute);

   //             DataSet dsRslt = new DataSet();

   //             dtRslt.TableName = "RSLTDT";

   //             dsRslt.Tables.Add(dtRslt);

   //             return dsRslt;
   //         }
   //         catch (Exception ex)
   //         {
   //             throw new Exception(ex.Message);
   //         }
   //     }



   //     public static DataSet POP20A_SER4(DataSet paramDS, BizExecute.BizExecute bizExecute)
   //     {
   //         //설비별 공정
   //         UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
   //         DataTable dtRslt = DLSE.LSE_STD_PARTPROC_QUERY.LSE_STD_PARTPROC_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

   //         //해당 부품에 공정이 없을경우 전체공정을 보여줌
   //         if (dtRslt.Rows.Count == 0)
   //         {
   //             dtRslt = DLSE.LSE_STD_PROC_QUERY.LSE_STD_PROC_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
   //         }

   //         DataSet dsRslt = new DataSet();

   //         dtRslt.TableName = "RSLTDT";

   //         dsRslt.Tables.Add(dtRslt);

   //         return dsRslt;

   //     }

   //     public static DataSet POP20A_SER5(DataSet paramDS, BizExecute.BizExecute bizExecute)
   //     {

            
   //         DataTable dtRslt = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY14(paramDS.Tables["RQSTDT"], bizExecute);

   //         DataSet dsRslt = new DataSet();

   //         dtRslt.TableName = "RSLTDT";

   //         dsRslt.Tables.Add(dtRslt);


   //         DataTable dtWo = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER(paramDS.Tables["RQSTDT"], bizExecute);

   //         dtWo.TableName = "RSLTDT_WO";

   //         dsRslt.Tables.Add(dtWo);

   //         return dsRslt;

   //     }

   //     public static DataSet POP20A_SER6(DataSet paramDS, BizExecute.BizExecute bizExecute)
   //     {

   //         DataTable dtRslt = DSHP.TSHP_ACTUAL.TSHP_ACTUAL_SER(paramDS.Tables["RQSTDT"], bizExecute);

   //         DataSet dsRslt = new DataSet();

   //         dtRslt.TableName = "RSLTDT";

   //         dsRslt.Tables.Add(dtRslt);

   //         return dsRslt;

   //     }


   //     public static DataSet POP20A_SER7(DataSet paramDS, BizExecute.BizExecute bizExecute)
   //     {

   //         DataTable dtRslt = DSHP.TSHP_IDLETIME.TSHP_IDLETIME_SER(paramDS.Tables["RQSTDT"], bizExecute);

   //         DataSet dsRslt = new DataSet();

   //         dtRslt.TableName = "RSLTDT";

   //         dsRslt.Tables.Add(dtRslt);

   //         return dsRslt;

   //     }


   //     public static DataSet POP20A_SER8(DataSet paramDS, BizExecute.BizExecute bizExecute)
   //     {
   //         //수작업실적내역
   //         DataTable dtRslt = DSHP.TSHP_MANACTUAL_QUERY.TSHP_MANACTUAL_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

   //         DataSet dsRslt = new DataSet();

   //         dtRslt.TableName = "RSLTDT";

   //         dsRslt.Tables.Add(dtRslt);

   //         return dsRslt;

   //     }

   //     public static DataSet POP20A_SER9(DataSet paramDS, BizExecute.BizExecute bizExecute)
   //     {
   //         //저장된 설비 조회
   //         DataTable dtRslt = DSTD.TSTD_MC_AVAILEMP_QUERY.TSTD_MC_AVAILEMP_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

   //         DataSet dsRslt = new DataSet();

   //         dtRslt.TableName = "RSLTDT";

   //         dsRslt.Tables.Add(dtRslt);

   //         return dsRslt;

   //     }

   //     //자주검사 조회
   //     public static DataSet POP20A_SER10(DataSet paramDS, BizExecute.BizExecute bizExecute)
   //     {
   //         DataTable dtRslt = DSHP.TSHP_PART_CHK_QUERY.TSHP_PART_CHK_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
   //         dtRslt.TableName = "RSLTDT";

   //         DataTable dtRsltEmp = DSTD.TSTD_EMPLOYEE.TSTD_EMPLOYEE_SER(paramDS.Tables["RQSTDT"], bizExecute);
   //         dtRsltEmp.TableName = "RSLTDT_EMP";

   //         DataSet dsRslt = new DataSet();


   //         dsRslt.Tables.Add(dtRslt);
   //         dsRslt.Tables.Add(dtRsltEmp);

   //         return dsRslt;
   //     }




   //     //자주검사 품목별 조회
   //     public static DataSet POP20A_SER17(DataSet paramDS, BizExecute.BizExecute bizExecute)
   //     {
   //         DataTable dtRslt = DSHP.TSHP_PART_CHK_QUERY.TSHP_PART_CHK_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);

   //         DataSet dsRslt = new DataSet();
   //         dtRslt.TableName = "RSLTDT";
   //         dsRslt.Tables.Add(dtRslt);

   //         return dsRslt;
   //     }

   //     //작업지시 조회 - 조립
   //     public static DataSet POP20A_SER11(DataSet paramDS, BizExecute.BizExecute bizExecute)
   //     {
   //         try
   //         {
   //             UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

   //             //DataTable dtRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
   //             DataTable dtRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY6(paramDS.Tables["RQSTDT"], bizExecute);

   //             DataTable dtAct = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);

   //             DataSet dsRslt = new DataSet();

   //             dtRslt.TableName = "RSLTDT";
   //             dtAct.TableName = "RSLTDT_ACT";

   //             dsRslt.Tables.Add(dtRslt);
   //             dsRslt.Tables.Add(dtAct);

   //             return dsRslt;
   //         }
   //         catch (Exception ex)
   //         {
   //             throw new Exception(ex.Message);
   //         }
   //     }

   //     public static DataSet POP20A_SER11_1(DataSet paramDS, BizExecute.BizExecute bizExecute)
   //     {
   //         try
   //         {
   //             UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

   //             //DataTable dtRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
   //             DataTable dtRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY6_1(paramDS.Tables["RQSTDT"], bizExecute);

   //             DataTable dtAct = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);

   //             DataSet dsRslt = new DataSet();

   //             dtRslt.TableName = "RSLTDT";
   //             dtAct.TableName = "RSLTDT_ACT";

   //             dsRslt.Tables.Add(dtRslt);
   //             dsRslt.Tables.Add(dtAct);

   //             return dsRslt;
   //         }
   //         catch (Exception ex)
   //         {
   //             throw new Exception(ex.Message);
   //         }
   //     }


   //     //작업지시 조회 - 조립 계획
   //     public static DataSet POP20A_SER12(DataSet paramDS, BizExecute.BizExecute bizExecute)
   //     {
   //         try
   //         {
   //             UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                
   //             DataTable dtRslt_CNT = DSHP.TSHP_ASSPLAN_QUERY.TSHP_ASSPLAN_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

   //             DataTable dtRslt = DSHP.TSHP_ASSPLAN_QUERY.TSHP_ASSPLAN_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

   //             DataTable dtRsltDATA = DSHP.TSHP_ASSPLAN_QUERY.TSHP_ASSPLAN_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);

   //             DataSet dsRslt = new DataSet();

   //             dtRslt.TableName = "RSLTDT";
   //             dtRslt_CNT.TableName = "RSLTDT_CNT";
   //             dtRsltDATA.TableName = "RSLTDT_DATA";

   //             dsRslt.Tables.Add(dtRslt);
   //             dsRslt.Tables.Add(dtRslt_CNT);
   //             dsRslt.Tables.Add(dtRsltDATA);

   //             return dsRslt;
   //         }
   //         catch (Exception ex)
   //         {
   //             throw new Exception(ex.Message);
   //         }
   //     }

   //     //작업지시 조회 - 조립 계획 : 현재 작업상태(진행중인 공정이 유무)
   //     public static DataSet POP20A_SER13(DataSet paramDS, BizExecute.BizExecute bizExecute)
   //     {
   //         try
   //         {
   //             UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

   //             DataTable dtRslt = DSHP.TSHP_ASSPLAN_QUERY.TSHP_ASSPLAN_QUERY4(paramDS.Tables["RQSTDT"], bizExecute);

   //             DataSet dsRslt = new DataSet();
   //             dtRslt.TableName = "RSLTDT";
   //             dsRslt.Tables.Add(dtRslt);
   //             return dsRslt;
   //         }
   //         catch (Exception ex)
   //         {
   //             throw new Exception(ex.Message);
   //         }
   //     }

   //     //작업지시 조회 - 조립 계획 : 시작 시 메세지
   //     public static DataSet POP20A_SER14(DataSet paramDS, BizExecute.BizExecute bizExecute)
   //     {
   //         try
   //         {
   //             DataTable dtRslt = DSHP.TSHP_ASSPLAN_QUERY.TSHP_ASSPLAN_QUERY5(paramDS.Tables["RQSTDT"], bizExecute);

   //             DataSet dsRslt = new DataSet();
   //             dtRslt.TableName = "RSLTDT";
   //             dsRslt.Tables.Add(dtRslt);
   //             return dsRslt;
   //         }
   //         catch (Exception ex)
   //         {
   //             throw new Exception(ex.Message);
   //         }
   //     }

   //     //작업지시 조회 - 조립 : 불량 내역
   //     public static DataSet POP20A_SER15(DataSet paramDS, BizExecute.BizExecute bizExecute)
   //     {
   //         try
   //         {
   //             //PLT_CODE, S_WORK_DATE, E_WORK_DATE, PROC_CODE
   //             DataTable dtRslt = DSHP.TSHP_NG_QUERY.TSHP_NG_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

   //             DataSet dsRslt = new DataSet();
   //             dtRslt.TableName = "RSLTDT";
   //             dsRslt.Tables.Add(dtRslt);
   //             return dsRslt;
   //         }
   //         catch (Exception ex)
   //         {
   //             throw new Exception(ex.Message);
   //         }
   //     }

   //     //작업지시의 최근 실적
   //     public static DataSet POP20A_SER16(DataSet paramDS, BizExecute.BizExecute bizExecute)
   //     {
   //         try
   //         {
   //             //TSHP_ACTUAL_QUERY20
   //             DataTable dtRslt = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY20(paramDS.Tables["RQSTDT"], bizExecute);

   //             DataSet dsResult = new DataSet();
   //             dsResult.Tables.Add(dtRslt);

   //             return dsResult;
   //         }
   //         catch (Exception ex)
   //         {
   //             throw new Exception(ex.Message);
   //         }
   //     }

   //     public static DataSet POP20A_SER18(DataSet paramDS, BizExecute.BizExecute bizExecute)
   //     {

   //         try
   //         {
   //             //자주검사 정보
   //             DataTable dtRslt = DLSE.LSE_STD_PARTPROC_WORK.LSE_STD_PARTPROC_WORK_SER(paramDS.Tables["RQSTDT"], bizExecute);
   //             dtRslt.TableName = "RSLTDT_WORK";
   //             //공정정보
   //             DataTable dtRslt2 = DLSE.LSE_STD_PARTPROC_PRE_QUERY.LSE_STD_PARTPROC_PRE_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
   //             dtRslt2.TableName = "RSLTDT_PRE";

   //             DataTable dtRslt3 = DLSE.LSE_STD_PARTPROC_CONT_QUERY.LSE_STD_PARTPROC_CONT_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
   //             dtRslt3.TableName = "RSLTDT_CONT";

   //             DataTable dtRslt4 = DLSE.LSE_STD_PARTPROC.LSE_STD_PARTPROC_SER4(paramDS.Tables["RQSTDT"], bizExecute);
   //             dtRslt4.TableName = "RSLTDT_PROC_FILE";

   //             DataTable dtRslt5 = DLSE.LSE_STD_PART.LSE_STD_PART_SER4(paramDS.Tables["RQSTDT"], bizExecute);
   //             dtRslt5.TableName = "RSLTDT_ASSY_FILE";

   //             DataTable dtRslt6 = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY16_1(paramDS.Tables["RQSTDT_PROC"], bizExecute);
   //             dtRslt6.TableName = "RSLTDT_PROC";

   //             //DataTable dtRslt7 = DTOL.TTOL_TOOLLIST_QUERY.TTOL_TOOLLIST_QUERY3(paramDS.Tables["RQSTDT_PROC"], bizExecute);
   //             DataTable dtRslt7 = DSHP.TSHP_ACTUAL_TOOL_QUERY.TSHP_ACTUAL_TOOL_QUERY1(paramDS.Tables["RQSTDT_PROC"], bizExecute);
   //             if (dtRslt7.Rows.Count == 0)
   //             {
   //                 DSTD.TSTD_ACTUAL_TOOL.TSTD_ACTUAL_TOOL_COPY(paramDS.Tables["RQSTDT_PROC"], bizExecute);
   //                 //dtRslt7 = DSTD.TSTD_ACTUAL_TOOL_QUERY.TSTD_ACTUAL_TOOL_QUERY1(paramDS.Tables["RQSTDT_PROC"], bizExecute);
   //                 dtRslt7 = DSHP.TSHP_ACTUAL_TOOL_QUERY.TSHP_ACTUAL_TOOL_QUERY1(paramDS.Tables["RQSTDT_PROC"], bizExecute);
   //             }
   //             dtRslt7.TableName = "RSLTDT_TOL";

   //             paramDS.Tables.Add(dtRslt);
   //             paramDS.Tables.Add(dtRslt2);
   //             paramDS.Tables.Add(dtRslt3);
   //             paramDS.Tables.Add(dtRslt4);
   //             paramDS.Tables.Add(dtRslt5);
   //             paramDS.Tables.Add(dtRslt6);
   //             paramDS.Tables.Add(dtRslt7);

   //             return paramDS;
   //         }
   //         catch (Exception ex)
   //         {
   //             throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
   //         }

   //     }

   //     public static DataSet POP20A_SER19(DataSet paramDS, BizExecute.BizExecute bizExecute)
   //     {

   //         try
   //         {
   //             UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

   //             DataTable dtRslt_PrgAndProc = DLSE.LSE_STD_PROC_QUERY.LSE_STD_PROC_QUERY5(paramDS.Tables["RQSTDT"], bizExecute);
   //             dtRslt_PrgAndProc.TableName = "RSLTDT_PRG_PROC";

   //             DataTable dtRslt_AssyProc = DLSE.LSE_STD_PARTPROC_ASSY_QUERY.LSE_STD_PARTPROC_ASSY_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
   //             dtRslt_AssyProc.TableName = "RSLTDT_ASSY_PROC";

   //             //DataTable dtRslt_AssyProc_All = DLSE.LSE_STD_PARTPROC_ASSY_QUERY.LSE_STD_PARTPROC_ASSY_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
   //             //dtRslt_AssyProc_All.TableName = "RSLTDT_ASSY_PROC_ALL";

   //             DataTable dtRslt3 = DLSE.LSE_STD_PART.LSE_STD_PART_SER(paramDS.Tables["RQSTDT"], bizExecute);
   //             dtRslt3.TableName = "RSLTDT_PART";

   //             DataTable dtRslt2 = DLSE.LSE_STD_PARTPROC.LSE_STD_PARTPROC_SER2(paramDS.Tables["RQSTDT"], bizExecute);
   //             dtRslt2.TableName = "RSLTDT_PROC";

   //             DataTable dtRslt = DORD.TORD_PRODUCT_QUERY.TORD_PRODUCT_QUERY8(paramDS.Tables["RQSTDT"], bizExecute);
   //             dtRslt.TableName = "RSLTDT";

   //             DataTable dtRslt_Proc = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY19(paramDS.Tables["RQSTDT"], bizExecute);
   //             dtRslt_Proc.TableName = "RSLTDT_PROC2";

   //             //하위 단품 조회
   //             DataTable dtParts = dtParts = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY10_3(paramDS.Tables["RQSTDT"], bizExecute);
   //             dtParts.TableName = "RSLTDT_PROD";
   //             paramDS.Tables.Add(dtParts);

   //             paramDS.Tables.Add(dtRslt_PrgAndProc);
   //             paramDS.Tables.Add(dtRslt_AssyProc);
   //             //paramDS.Tables.Add(dtRslt_AssyProc_All);
   //             paramDS.Tables.Add(dtRslt2);
   //             paramDS.Tables.Add(dtRslt3);
   //             paramDS.Tables.Add(dtRslt);
   //             paramDS.Tables.Add(dtRslt_Proc);

   //             return paramDS;
   //         }
   //         catch (Exception ex)
   //         {
   //             throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
   //         }

   //     }

   //     public static DataSet POP20A_SER20(DataSet paramDS, BizExecute.BizExecute bizExecute)
   //     {
   //         try
   //         {
   //             UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

   //             DataTable dtRslt = DHIS.THIS_PM_PLAN_QUERY.THIS_PM_PLAN_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);
   //             dtRslt.TableName = "RSLTDT";

   //             DataSet dsRslt = new DataSet();
   //             dsRslt.Tables.Add(dtRslt);

   //             return dsRslt;
   //         }
   //         catch (Exception ex)
   //         {
   //             throw new Exception(ex.Message);
   //         }
   //     }



   //     public static DataSet POP20A_SER21(DataSet paramDS, BizExecute.BizExecute bizExecute)
   //     {
   //         try
   //         {
   //             UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

   //             DataTable dtRslt = DHIS.THIS_PM_PLAN_QUERY.THIS_PM_PLAN_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);

   //             DataTable dtRslt2 = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

   //             dtRslt.TableName = "RSLTDT";

   //             DataSet dsRslt = new DataSet();
   //             dsRslt.Tables.Add(dtRslt);

   //             return dsRslt;
   //         }
   //         catch (Exception ex)
   //         {
   //             throw new Exception(ex.Message);
   //         }
   //     }




   //     //INS
   //     public static DataSet POP20A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
   //     {

   //         //단말기 실적입력
   //         DPOP.TPOP_PANNEL_LOG.TPOP_PANEL_LOG_INS(paramDS.Tables["RQSTDT"], bizExecute);

			//#region 공구 수명 관리
			//if (paramDS.Tables.Contains("RQSTDT_ACTTOOL"))
   //         {
   //             foreach (DataRow paramRow in paramDS.Tables["RQSTDT"].Rows)
   //             {
   //                 //DataTable dtWKRslt = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER_1(UTIL.GetRowToDt(paramRow), bizExecute);

   //                 //if (dtWKRslt.Rows.Count > 0)
   //                 //{
   //                 //공정이 완료됐음
   //                 //공구 수명만큼 삭제 후 업데이트 할것
   //                 //DataTable actToolRslt = DSHP.TSHP_ACTUAL_TOOL.TSHP_ACTUAL_TOOL_SER2(UTIL.GetRowToDt(paramRow), bizExecute);

   //                 //UTIL.SetBizAddColumnToValue(actToolRslt, "TL_LIFE_USE", paramRow["OK_QTY"].toInt()+ paramRow["NG_QTY"].toInt(), typeof(String));
   //                 if (paramDS.Tables["RQSTDT_ACTTOOL"].Rows.Count > 0)
   //                 {
   //                     UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_ACTTOOL"], "TL_LIFE_USE", paramRow["OK_QTY"].toInt() + paramRow["NG_QTY"].toInt(), typeof(String));
   //                     foreach (DataRow actToolRow in paramDS.Tables["RQSTDT_ACTTOOL"].Rows)
   //                     {
   //                         DTOL.TTOL_TOOLLIST.TTOL_TOOLLIST_UPD3(UTIL.GetRowToDt(actToolRow), bizExecute);
   //                         //DSHP.TSHP_ACTUAL_TOOL.TSHP_ACTUAL_TOOL_INS2(UTIL.GetRowToDt(actToolRow), bizExecute);
   //                     }
   //                 }
   //                 // }
   //             }
   //         }
			//#endregion

			//DataTable dtActRslt = DSHP.TSHP_ACTUAL.TSHP_ACTUAL_SER5(paramDS.Tables["RQSTDT"], bizExecute);


   //         if (dtActRslt.Rows.Count != 0)
   //         {
   //             if (paramDS.Tables["RQSTDT_NG"].Rows.Count != 0)
   //             {
   //                 DataTable dtWKRslt2 = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER(paramDS.Tables["RQSTDT"], bizExecute);
   //                 //불량 -사내, 외주 비용 업데이트
   //                 DataTable dtCostRslt = DLSE.LSE_STD_PARTPROC_QUERY.LSE_STD_PARTPROC_QUERY5(dtWKRslt2, bizExecute);
   //                 //decimal ngProcCost = dtCostRslt.Select("IS_OS=0 AND WORK_TIME IS NOT NULL AND PROC_UC IS NOT NULL").Sum(s => s.Field<decimal>("WORK_TIME") * s.Field<decimal>("PROC_UC"));
   //                 //decimal ngOutCost = dtCostRslt.Select("IS_OS=1 AND WORK_TIME IS NOT NULL AND PROC_UC IS NOT NULL").Sum(s => s.Field<decimal>("WORK_TIME") * s.Field<decimal>("PROC_UC"));

   //                 paramDS.Tables["RQSTDT_NG"].Columns.Add("NG_ID", typeof(String));
   //                 UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_NG"], "PLT_CODE", "100", typeof(String));
   //                 UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_NG"], "NG_STATE", "W", typeof(String));
   //                 UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_NG"], "ACT_TYPE", "W", typeof(String));
   //                 UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_NG"], "LINK_KEY", dtActRslt.Rows[0]["ACTUAL_ID"].ToString(), typeof(String));
   //                 //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_NG"], "NG_PROC_COST", ngProcCost, typeof(decimal));
   //                 //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_NG"], "NG_OUT_COST", ngOutCost, typeof(decimal));

   //                 for (int i = 0; i < paramDS.Tables["RQSTDT_NG"].Rows.Count; i++)
   //                 {
   //                     string ngID = UTIL.UTILITY_GET_SERIALNO(paramDS.Tables["RQSTDT"].Rows[0]["PLT_CODE"].ToString(), "NG", bizExecute);
   //                     paramDS.Tables["RQSTDT_NG"].Rows[i]["NG_ID"] = ngID;
   //                 }

   //                 DSHP.TSHP_NG.TSHP_NG_INS(paramDS.Tables["RQSTDT_NG"], bizExecute);
   //             }

   //         }
            
   //         DataSet dsRslt = new DataSet();

   //         DataTable dtRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY5(paramDS.Tables["RQSTDT"], bizExecute);

   //         dtRslt.TableName = "RSLTDT";

   //         dsRslt.Tables.Add(dtRslt);
   //         return dsRslt;
   //     }

   //     public static DataSet POP20A_INS2(DataSet paramDS, BizExecute.BizExecute bizExecute)
   //     {
   //         //수작업실적 입력
   //         string actualID = UTIL.UTILITY_GET_SERIALNO(paramDS.Tables["RQSTDT"].Rows[0]["PLT_CODE"].ToString(), "ACT", bizExecute);
   //         UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "ACTUAL_ID", actualID, typeof(String));

   //         DSHP.TSHP_MANACTUAL.TSHP_MANACTUAL_INS(paramDS.Tables["RQSTDT"], bizExecute);

   //         if (paramDS.Tables["RQSTDT_NG"].Rows.Count != 0)
   //         {
   //             DataTable dtWKRslt2 = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER(paramDS.Tables["RQSTDT"], bizExecute);
   //             //불량 -사내, 외주 비용 업데이트
   //             DataTable dtCostRslt = DLSE.LSE_STD_PARTPROC_QUERY.LSE_STD_PARTPROC_QUERY5(dtWKRslt2, bizExecute);
   //             decimal ngProcCost = dtCostRslt.Select("IS_OS=0 AND WORK_TIME IS NOT NULL AND PROC_UC IS NOT NULL").Sum(s => s.Field<decimal>("WORK_TIME") * s.Field<decimal>("PROC_UC"));
   //             decimal ngOutCost = dtCostRslt.Select("IS_OS=1 AND WORK_TIME IS NOT NULL AND PROC_UC IS NOT NULL").Sum(s => s.Field<decimal>("WORK_TIME") * s.Field<decimal>("PROC_UC"));

   //             paramDS.Tables["RQSTDT_NG"].Columns.Add("NG_ID", typeof(String));
   //             UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_NG"], "PLT_CODE", "100", typeof(String));
   //             UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_NG"], "NG_STATE", "W", typeof(String));
   //             UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_NG"], "ACT_TYPE", "W", typeof(String));
   //             UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_NG"], "LINK_KEY", actualID, typeof(String));
   //             UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_NG"], "NG_PROC_COST", ngProcCost, typeof(decimal));
   //             UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_NG"], "NG_OUT_COST", ngOutCost, typeof(decimal));

   //             for (int i = 0; i < paramDS.Tables["RQSTDT_NG"].Rows.Count; i++)
   //             {
   //                 string ngID = UTIL.UTILITY_GET_SERIALNO(paramDS.Tables["RQSTDT"].Rows[0]["PLT_CODE"].ToString(), "NG", bizExecute);
   //                 paramDS.Tables["RQSTDT_NG"].Rows[i]["NG_ID"] = ngID;
   //             }

   //             DSHP.TSHP_NG.TSHP_NG_INS(paramDS.Tables["RQSTDT_NG"], bizExecute);
   //         }


   //         DataSet dsRslt = new DataSet();

   //         DataTable dtRslt = new DataTable();

   //         dtRslt.TableName = "RSLTDT";

   //         dsRslt.Tables.Add(dtRslt);
   //         return dsRslt;
   //     }

   //     public static DataSet POP20A_INS3(DataSet paramDS, BizExecute.BizExecute bizExecute)
   //     {
   //         //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WO_NO", DBNull.Value);
     
   //         //비가동 시작
   //         DSHP.TSHP_IDLETIME.TSHP_IDLETIME_INS(paramDS.Tables["RQSTDT"], bizExecute);

   //         DataSet dsRslt = new DataSet();

   //         DataTable dtRslt = new DataTable();

   //         dtRslt.TableName = "RSLTDT";

   //         dsRslt.Tables.Add(dtRslt);
   //         return dsRslt;
   //     }

   //     //자주검사 저장
   //     public static DataSet POP20A_INS4(DataSet paramDS, BizExecute.BizExecute bizExecute)
   //     {
   //         foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
   //         {
   //             //기존 데이터 검색
   //             DataTable dtCHKRslt = DSHP.TSHP_PART_CHK.TSHP_PART_CHK_SER(UTIL.GetRowToDt(row), bizExecute);

   //             if (dtCHKRslt.Rows.Count != 0)
   //             {
   //                 if(row["CHK_VALUE"].ToString() != dtCHKRslt.Rows[0]["CHK_VALUE"].ToString())
   //                 {
   //                     //기존 데이터가 있으면 업데이트
   //                     DSHP.TSHP_PART_CHK.TSHP_PART_CHK_UPD(UTIL.GetRowToDt(row), bizExecute);
   //                 }
                    
   //             }
   //             else
   //             {
   //                 //기존 데이터가 없으면 새로저장
   //                 DSHP.TSHP_PART_CHK.TSHP_PART_CHK_INS(UTIL.GetRowToDt(row), bizExecute);
   //             }
   //         }

   //         DataSet dsRslt = new DataSet();
   //         DataTable dtRslt = new DataTable();
   //         dtRslt.TableName = "RSLTDT";
   //         dsRslt.Tables.Add(dtRslt);

   //         return dsRslt;
   //     }

   //     public static DataSet POP20A_INS5(DataSet paramDS, BizExecute.BizExecute bizExecute)
   //     {
   //         DataTable dtASSRslt = DSHP.TSHP_ASSPLAN.TSHP_ASSPLAN_SER(paramDS.Tables["RQSTDT"], bizExecute);

   //         if (dtASSRslt.Rows.Count == 0)
   //         {
   //             DSHP.TSHP_ASSPLAN.TSHP_ASSPLAN_INS(paramDS.Tables["RQSTDT"], bizExecute);
   //         }
   //         else
   //         {
   //             throw UTIL.SetException("이미 처리되었거나 유효하지 않는 데이터입니다."
   //                                 , new System.Diagnostics.StackFrame().GetMethod().Name
   //                                 , 100003);
   //         }

   //         DataSet dsRslt = new DataSet();
   //         DataTable dtRslt = new DataTable();
   //         dtRslt.TableName = "RSLTDT";
   //         dsRslt.Tables.Add(dtRslt);
   //         return dsRslt;
   //     }

   //     public static void POP20A_INS6(DataSet paramDS, BizExecute.BizExecute bizExecute)
   //     {

   //         //단말기 실적입력
   //         DPOP.TPOP_PANNEL_LOG.TPOP_PANEL_LOG_INS(paramDS.Tables["RQSTDT"], bizExecute);

   //         return;
   //     }

   //     /// <summary>
   //     /// 작업중단 
   //     ///  : 중지로 PANNEL_LOG 입력, 중단 비가동 사유 입력
   //     /// </summary>
   //     /// <param name="paramDS"></param>
   //     /// <param name="bizExecute"></param>
   //     /// <returns></returns>
   //     public static DataSet POP20A_INS7(DataSet paramDS, BizExecute.BizExecute bizExecute)
   //     {
   //         //단말기 실적입력
   //         DPOP.TPOP_PANNEL_LOG.TPOP_PANEL_LOG_INS(paramDS.Tables["RQSTDT_PANEL"], bizExecute);

   //         //최근 실적 조회
   //         DataTable dtWoNo = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY20(paramDS.Tables["RQSTDT_IDLE"], bizExecute);

   //         UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_IDLE"], "ACTUAL_ID", dtWoNo.Rows[0]["ACTUAL_ID"].ToString(), typeof(String));

   //         //비가동 시작
   //         DSHP.TSHP_IDLETIME.TSHP_IDLETIME_INS(paramDS.Tables["RQSTDT_IDLE"], bizExecute);

   //         DataSet dsRslt = new DataSet();

   //         DataTable dtRslt = new DataTable();

   //         dtRslt.TableName = "RSLTDT";

   //         dsRslt.Tables.Add(dtRslt);
   //         return dsRslt;
   //     }

   //     public static void POP20A_INS8(DataSet paramDS, BizExecute.BizExecute bizExecute)
   //     {

   //         //단말기 실적입력
   //         DSTD.TSTD_EMPLOYEE.TSTD_EMPLOYEE_UPD4(paramDS.Tables["RQSTDT"], bizExecute);

   //         return;
   //     }

   //     /// <summary>
   //     /// 단말기 실적 시작등록 _ 21.05.12
   //     /// </summary>
   //     /// <param name="paramDS"></param>
   //     /// <param name="bizExecute"></param>
   //     /// <returns></returns>
   //     public static DataSet POP20A_INS9(DataSet paramDS, BizExecute.BizExecute bizExecute)
   //     {
           
   //         // 지시상태 변경
   //         DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD4(paramDS.Tables["RQSTDT"], bizExecute);

           
   //         // 신규생성
   //         string actualID = UTIL.UTILITY_GET_SERIALNO(paramDS.Tables["RQSTDT"].Rows[0]["PLT_CODE"].ToString(), "ACT", bizExecute);
   //         UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "ACTUAL_ID", actualID, typeof(String));

   //         DSHP.TSHP_ACTUAL.TSHP_ACTUAL_INS(paramDS.Tables["RQSTDT"], bizExecute);
            

   //         DataSet dsRslt = new DataSet();
   //         DataTable dtRslt = new DataTable();
   //         dtRslt.TableName = "RSLTDT";

   //         dsRslt.Tables.Add(dtRslt);
   //         return dsRslt;
   //     }


   //     /// <summary>
   //     /// [가공단말기] 실적중지 _21.05.13
   //     /// </summary>
   //     /// <param name="paramDS"></param>
   //     /// <param name="bizExecute"></param>
   //     /// <returns></returns>

   //     public static DataSet POP20A_INS10(DataSet paramDS, BizExecute.BizExecute bizExecute)
   //     {
   //        // 지시상태 변경
   //        DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD4(paramDS.Tables["RQSTDT"], bizExecute);

   //         // ACTUAL_ID 가져오기
   //         DataTable actRslt = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY11(paramDS.Tables["RQSTDT"], bizExecute);


   //         foreach (DataRow row in actRslt.Rows)
   //         {
   //             row["PROC_STAT"] = 3;
   //             row["PANEL_STAT"] = 2;
   //             row["ACT_END_TIME"] = paramDS.Tables["RQSTDT"].Rows[0]["START_TIME"]; //실적종료시간 = 비가동시작시간
   //             DSHP.TSHP_ACTUAL.TSHP_ACTUAL_UPD8(UTIL.GetRowToDt(row), bizExecute);  // ACT_END_TIME 추가
   //             //DSHP.TSHP_ACTUAL.TSHP_ACTUAL_UPD9(UTIL.GetRowToDt(row), bizExecute);  // ACT_TIME 산출

   //         }

   //         //비가동 시작
   //         DSHP.TSHP_IDLETIME.TSHP_IDLETIME_INS(paramDS.Tables["RQSTDT"], bizExecute);

   //         DataSet dsRslt = new DataSet();

   //         DataTable dtRslt = new DataTable();

   //         dtRslt.TableName = "RSLTDT";

   //         dsRslt.Tables.Add(dtRslt);
   //         return dsRslt;
   //     }


   //     /// <summary>
   //     /// [가공단말기] 실적완료 21.05.13
   //     /// </summary>
   //     /// <param name="paramDS"></param>
   //     /// <param name="bizExecute"></param>
   //     /// <returns></returns>
   //     public static DataSet POP20A_INS11(DataSet paramDS, BizExecute.BizExecute bizExecute)
   //     {
   //         // 작지상태 변경
   //         DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD4(paramDS.Tables["RQSTDT"], bizExecute);

   //         // ACTUAL_ID 가져오기
   //         DataTable actRslt = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY11(paramDS.Tables["RQSTDT"], bizExecute);


   //         foreach (DataRow row in actRslt.Rows)
   //         {
   //             row["PROC_STAT"] = 4;
   //             row["PANEL_STAT"] = 4;
   //             row["ACT_END_TIME"] = paramDS.Tables["RQSTDT"].Rows[0]["ACT_END_TIME"];
   //             DSHP.TSHP_ACTUAL.TSHP_ACTUAL_UPD8(UTIL.GetRowToDt(row), bizExecute);  // ACT_END_TIME 추가
   //            // DSHP.TSHP_ACTUAL.TSHP_ACTUAL_UPD9(UTIL.GetRowToDt(row), bizExecute);  // ACT_TIME 산출

   //         }

   //         DataSet dsRslt = new DataSet();

   //         DataTable dtRslt = new DataTable();

   //         dtRslt.TableName = "RSLTDT";

   //         dsRslt.Tables.Add(dtRslt);
   //         return dsRslt;
   //     }


   //     /// <summary>
   //     ///  [가공단말기] 비가동 종료 후 - 재시작 _21.05.14
   //     /// </summary>
   //     /// <param name="paramDS"></param>
   //     /// <param name="bizExecute"></param>
   //     /// <returns></returns>
   //     public static DataSet POP20A_INS12(DataSet paramDS, BizExecute.BizExecute bizExecute)
   //     {
   //         // 작지상태 변경 
   //         DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD4(paramDS.Tables["RQSTDT_IDL"], bizExecute);

   //         // IDLE_ID 가져오기
   //         DataTable idlRslt = DSHP.TSHP_IDLETIME_QUERY.TSHP_IDLETIME_QUERY6(paramDS.Tables["RQSTDT_IDL"], bizExecute);

   //         foreach (DataRow row in idlRslt.Rows)
   //         {
   //             row["IDLE_STATE"] = 0;
   //             row["END_TIME"] = paramDS.Tables["RQSTDT_IDL"].Rows[0]["END_TIME"];

   //             DSHP.TSHP_IDLETIME.TSHP_IDLETIME_UPD3(UTIL.GetRowToDt(row), bizExecute); //END_TIME,IDLE_STATE 갱신
   //             DSHP.TSHP_IDLETIME.TSHP_IDLETIME_UPD4(UTIL.GetRowToDt(row), bizExecute); // IDLE_TIME 갱신
   //         }


   //         // 신규 실적 생성 

   //         DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD4(paramDS.Tables["RQSTDT_ACT"], bizExecute);

   //         string actualID = UTIL.UTILITY_GET_SERIALNO(paramDS.Tables["RQSTDT_ACT"].Rows[0]["PLT_CODE"].ToString(), "ACT", bizExecute);
   //         UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_ACT"], "ACTUAL_ID", actualID, typeof(String));

   //         DSHP.TSHP_ACTUAL.TSHP_ACTUAL_INS(paramDS.Tables["RQSTDT_ACT"], bizExecute);


   //         DataSet dsRslt = new DataSet();

   //         DataTable dtRslt = new DataTable();

   //         dtRslt.TableName = "RSLTDT";

   //         dsRslt.Tables.Add(dtRslt);
   //         return dsRslt;
   //     }


   //     /// <summary>
   //     /// 부적합등록 _2021.05.17
   //     /// </summary>
   //     /// <param name="paramDS"></param>
   //     /// <param name="bizExecute"></param>
   //     /// <returns></returns>
   //     //public static DataSet POP20A_INS13(DataSet paramDS, BizExecute.BizExecute bizExecute)
   //     //{
   //     //    try
   //     //    {
              
   //     //        foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
   //     //        {
   //     //            row["NG_ID"] = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "NG", UTIL.emSerialFormat.YYYYMMDD, "", bizExecute);
                   
   //     //            DSHP.TSHP_NG.TSHP_NG_INS2(UTIL.GetRowToDt(row), bizExecute);

   //     //            if (paramDS.Tables["RQSTDT"].Columns.Contains("IDLE_ID"))
   //     //            {
   //     //                if (row["IDLE_ID"].ToString() != "")
   //     //                {
   //     //                    // DSHP.TSHP_IDLETIME.TSHP_IDLETIME_UPD7(UTIL.GetRowToDt(row), bizExecute);
   //     //                }
   //     //            }

   //     //            return paramDS;
                
   //     //    }
   //     //    catch (Exception ex)
   //     //    {
   //     //        throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
   //     //    }
   //     //}



   //     public static DataSet POP20A_SAVE(DataSet paramDS, BizExecute.BizExecute bizExecute)
   //     {

   //         foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
   //         {
   //             //1일때 저장
   //             if (row["IS_SAVE"].Equals("1"))
   //             {
   //                 DataTable serActTool = DSHP.TSHP_ACTUAL_TOOL.TSHP_ACTUAL_TOOL_SER(UTIL.GetRowToDt(row), bizExecute);
   //                 if (serActTool.Rows.Count == 0)
   //                 {
   //                     DSHP.TSHP_ACTUAL_TOOL.TSHP_ACTUAL_TOOL_INS(UTIL.GetRowToDt(row), bizExecute);
   //                 }
   //                 else
   //                 {
   //                     DSHP.TSHP_ACTUAL_TOOL.TSHP_ACTUAL_TOOL_UPD(UTIL.GetRowToDt(row), bizExecute);
   //                 }
   //             }
   //             else
   //             {
   //                 DSHP.TSHP_ACTUAL_TOOL.TSHP_ACTUAL_TOOL_DEL(UTIL.GetRowToDt(row), bizExecute);
   //             }
   //         }
            
   //         return paramDS;
   //     }

   //     public static DataSet POP20A_SAVE2(DataSet paramDS, BizExecute.BizExecute bizExecute)
   //     {

   //         foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
   //         {
   //                 DSHP.TSHP_ACTUAL.TSHP_ACTUAL_UPD(UTIL.GetRowToDt(row), bizExecute);
   //         }

   //         return paramDS;
   //     }


   //     public static DataSet POP20A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
   //     {

   //         DataTable dtASSRslt = DSHP.TSHP_ASSPLAN.TSHP_ASSPLAN_SER(paramDS.Tables["RQSTDT"], bizExecute);

   //         if (dtASSRslt.Rows.Count != 0)
   //         {
   //             DSHP.TSHP_ASSPLAN.TSHP_ASSPLAN_DEL(paramDS.Tables["RQSTDT"], bizExecute);
   //         }
   //         else
   //         {
   //             throw UTIL.SetException("이미 처리되었거나 유효하지 않는 데이터입니다."
   //                                 , new System.Diagnostics.StackFrame().GetMethod().Name
   //                                 , 100003);
   //         }

   //         DataSet dsRslt = new DataSet();
   //         DataTable dtRslt = new DataTable();
   //         dtRslt.TableName = "RSLTDT";
   //         dsRslt.Tables.Add(dtRslt);
   //         return dsRslt;
   //     }

   //     //UPD
   //     public static DataSet POP20A_UPD(DataSet paramDS, BizExecute.BizExecute bizExecute)
   //     {
   //         //비가동 종료
   //         DSHP.TSHP_IDLETIME.TSHP_IDLETIME_UPD(UTIL.GetRowToDt(paramDS.Tables["RQSTDT"].Rows[0]), bizExecute);

   //         paramDS.Tables["RQSTDT"].Rows[0].Delete();

   //         foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
   //         {
   //             row["IDLE_ID"] = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "IL", UTIL.emSerialFormat.YYYYMMDD, "", bizExecute);

   //             DSHP.TSHP_IDLETIME.TSHP_IDLETIME_INS2(UTIL.GetRowToDt(row), bizExecute);
   //         }
           

   //         DataSet dsRslt = new DataSet();

   //         DataTable dtRslt = new DataTable();

   //         dtRslt.TableName = "RSLTDT";

   //         dsRslt.Tables.Add(dtRslt);
   //         return dsRslt;
   //     }

   //     public static void POP20A_UPD2(DataSet paramDS, BizExecute.BizExecute bizExecute)
   //     {
   //         //마지막설비 EMP_CONF에 저장

   //         UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "EMP_CODE", ConnInfo.UserID, typeof(String));

   //         DSYS.TSYS_EMP_CONF.TSYS_EMP_CONF_UPD(paramDS.Tables["RQSTDT"], bizExecute);

   //     }

   //     /// <summary>
   //     /// 작업취소
   //     /// : 선택한 작업을 시작한 작업자가 작업의 시작을 취소.
   //     /// </summary>
   //     /// <param name="paramDS"></param>
   //     /// <param name="bizExecute"></param>
   //     public static DataSet POP20A_UPD3(DataSet paramDS, BizExecute.BizExecute bizExecute)
   //     {
   //         DataTable dtParam = paramDS.Tables["RQSTDT"];

   //         DataTable dtRslt = new DataTable("RSLTDT");

   //         if (dtParam.Rows.Count > 0)
   //         {
   //             DataTable dtPanelLog = DPOP.TPOP_PANNEL_LOG.TPOP_PANEL_LOG_SER(dtParam, bizExecute);

   //             if (dtPanelLog.Rows.Count > 0)
   //             {
   //                 DPOP.TPOP_PANNEL_LOG.TPOP_PANEL_LOG_DEL(dtPanelLog, bizExecute);
   //             }

     
   //             DataTable dtSParam = new DataTable("RQSTDT");
   //             dtSParam.Columns.Add("PLT_CODE", typeof(String)); //
   //             dtSParam.Columns.Add("MC_CODE", typeof(String)); //
   //             dtSParam.Columns.Add("EMP_CODE", typeof(String)); //
   //             dtSParam.Columns.Add("W_DATE", typeof(String)); //

   //             DataRow drSParam = dtSParam.NewRow();
   //             drSParam["PLT_CODE"] = dtParam.Rows[0]["PLT_CODE"];
   //             drSParam["MC_CODE"] = dtParam.Rows[0]["MC_CODE"];
   //             drSParam["EMP_CODE"] = dtParam.Rows[0]["EMP_CODE"];
   //             drSParam["W_DATE"] = dtParam.Rows[0]["W_DATE"];
   //             dtSParam.Rows.Add(drSParam);

   //             dtRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY5(dtSParam, bizExecute);
            
   //         }

   //         DataSet dsRslt = new DataSet();
   //         dsRslt.Tables.Add(dtRslt);

   //         return dsRslt;
            
   //     }

   //     public static DataSet POP20A_UPD4(DataSet paramDS, BizExecute.BizExecute bizExecute)
   //     {
   //         foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
   //         {
   //             DataTable rsltTable = DSHP.TSHP_ACTUAL_TOOL.TSHP_ACTUAL_TOOL_SER(UTIL.GetRowToDt(row), bizExecute);
   //             if (rsltTable.Rows.Count > 0)
   //             {
   //                 //수정
   //                 DSHP.TSHP_ACTUAL_TOOL.TSHP_ACTUAL_TOOL_UPD(UTIL.GetRowToDt(row), bizExecute);
   //             }
   //             else
   //             {
   //                 //추가
   //                 DSHP.TSHP_ACTUAL_TOOL.TSHP_ACTUAL_TOOL_INS(UTIL.GetRowToDt(row), bizExecute);
   //             }
   //         }
   //         return paramDS;
   //     }

   //     public static DataSet POP20A_UPD5(DataSet paramDS, BizExecute.BizExecute bizExecute)
   //     {

   //         DataTable rsltDt = DLSE.LSE_STD_PARTPROC_CONT_DETAIL.LSE_STD_PARTPROC_CONT_DETAIL_SER(paramDS.Tables["RQSTDT"], bizExecute);

   //         if (rsltDt.Rows.Count > 0)
   //         {
   //             DLSE.LSE_STD_PARTPROC_CONT_DETAIL.LSE_STD_PARTPROC_CONT_DETAIL_UPD(paramDS.Tables["RQSTDT"], bizExecute);
   //         }
   //         else
   //         {
   //             DLSE.LSE_STD_PARTPROC_CONT_DETAIL.LSE_STD_PARTPROC_CONT_DETAIL_INS(paramDS.Tables["RQSTDT"], bizExecute);
   //         }

   //         return paramDS;
   //     }

   //     /// <summary>
   //     /// 비가동 완료 처리 
   //     /// </summary>
   //     /// <param name="paramDS"></param>
   //     /// <param name="bizExecute"></param>
   //     /// <returns></returns>
   //     public static DataSet POP20A_UPD6(DataSet paramDS, BizExecute.BizExecute bizExecute)
   //     {
         
   //         // 작지상태 변경
   //         DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD4(paramDS.Tables["RQSTDT"], bizExecute);


   //         // IDLE_ID 가져오기
   //         DataTable idlRslt = DSHP.TSHP_IDLETIME_QUERY.TSHP_IDLETIME_QUERY6(paramDS.Tables["RQSTDT"], bizExecute);

            
   //         foreach (DataRow row in idlRslt.Rows)
   //         {
   //             row["IDLE_STATE"] = 0;
   //             row["END_TIME"] = paramDS.Tables["RQSTDT"].Rows[0]["END_TIME"]; 
               
   //             DSHP.TSHP_IDLETIME.TSHP_IDLETIME_UPD3(UTIL.GetRowToDt(row), bizExecute); //END_TIME,IDLE_STATE 갱신
   //             DSHP.TSHP_IDLETIME.TSHP_IDLETIME_UPD4(UTIL.GetRowToDt(row), bizExecute); // IDLE_TIME 갱신
   //         }

         
   //         DataSet dsRslt = new DataSet();
   //         DataTable dtRslt = new DataTable();
   //         dtRslt.TableName = "RSLTDT";
   //         dsRslt.Tables.Add(dtRslt);
   //         return dsRslt;

   //     }
    }
}
