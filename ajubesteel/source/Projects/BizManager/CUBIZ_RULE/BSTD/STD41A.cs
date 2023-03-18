using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BSTD
{

    public class STD41A
    {

        /// <summary>
        /// 대일정 추가
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet STD41A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "MCLASS_FLAG", 0, typeof(Byte));

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PRG_CLASS", 1, typeof(Byte));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
         
                    DataTable dtRslt = DSTD.TSTD_PROCGRP.TSTD_PROCGRP_SER(UTIL.GetRowToDt(row), bizExecute);

                    //데이터가 있으면 삭제여부 및 덮어쓰기 여부에 따라 update
                    if (dtRslt.Rows.Count > 0)
                    {

                        if (row["OVERWRITE"].Equals("1"))
                        {                            
                            DSTD.TSTD_PROCGRP.TSTD_PROCGRP_UPD(UTIL.GetRowToDt(row), bizExecute);
                        }
                        else
                        {
                            if (dtRslt.Rows[0]["DATA_FLAG"].Equals((byte)2))
                            {
                    
                                throw UTIL.SetException("동일 데이터가 이력이 존재할때 발생"
                                    , row["PART_CODE"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.OVERWRITE_HISTORY,dtRslt.Rows[0]);

                            }
                            else
                            {
                                throw UTIL.SetException("동일 데이터가 존재할때 발생"
                                    , row["PART_CODE"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.OVERWRITE);
                            }
                        }
                    }
                    else
                    {

                        DSTD.TSTD_PROCGRP.TSTD_PROCGRP_INS(UTIL.GetRowToDt(row), bizExecute);

                    }
    
                }

                return STD41A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        /// <summary>
        /// 중일정 추가
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet STD41A_INS2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PRG_CLASS", 0, typeof(Byte));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {

                    DataTable dtRslt = DSTD.TSTD_PROCGRP.TSTD_PROCGRP_SER(UTIL.GetRowToDt(row), bizExecute);

                    //데이터가 있으면 삭제여부 및 덮어쓰기 여부에 따라 update
                    if (dtRslt.Rows.Count > 0)
                    {

                        if (row["OVERWRITE"].Equals("1"))
                        {
                            DSTD.TSTD_PROCGRP.TSTD_PROCGRP_UPD(UTIL.GetRowToDt(row), bizExecute);
                        }
                        else
                        {
                            if (dtRslt.Rows[0]["DATA_FLAG"].Equals((byte)2))
                            {

                                throw UTIL.SetException("동일 데이터가 이력이 존재할때 발생"
                                    , row["PART_CODE"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.OVERWRITE_HISTORY, dtRslt.Rows[0]);

                            }
                            else
                            {
                                throw UTIL.SetException("동일 데이터가 존재할때 발생"
                                    , row["PART_CODE"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.OVERWRITE);
                            }
                        }
                    }
                    else
                    {

                        DSTD.TSTD_PROCGRP.TSTD_PROCGRP_INS(UTIL.GetRowToDt(row), bizExecute);

                    }

                }

                return STD41A_SER2(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        /// <summary>
        /// 소일정 추가
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet STD41A_INS3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PROC_TYPE", 0, typeof(Byte));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {

                    DataTable dtRslt = DLSE.LSE_STD_PROC.LSE_STD_PROC_SER(UTIL.GetRowToDt(row), bizExecute);

                    //데이터가 있으면 삭제여부 및 덮어쓰기 여부에 따라 update
                    if (dtRslt.Rows.Count > 0)
                    {

                        if (row["OVERWRITE"].Equals("1"))
                        {
                            //공정 수정
                            DLSE.LSE_STD_PROC.LSE_STD_PROC_UPD4(UTIL.GetRowToDt(row), bizExecute);
                        }
                        else
                        {
                            if (dtRslt.Rows[0]["DATA_FLAG"].Equals((byte)2))
                            {

                                throw UTIL.SetException("동일 데이터가 이력이 존재할때 발생"
                                    , row["PART_CODE"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.OVERWRITE_HISTORY, dtRslt.Rows[0]);

                            }
                            else
                            {
                                throw UTIL.SetException("동일 데이터가 존재할때 발생"
                                    , row["PART_CODE"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.OVERWRITE);
                            }
                        }
                    }
                    else
                    {
                        //공정 삽입
                        DLSE.LSE_STD_PROC.LSE_STD_PROC_INS2(UTIL.GetRowToDt(row), bizExecute);

                    }

                    //가용설비 삭제
                    DLSE.LSE_STD_AVAILMC.LSE_STD_AVAILMC_DEL(UTIL.GetRowToDt(row), bizExecute);

                    if (paramDS.Tables.Contains("RQSTDT2"))
                    {
                        //가용설비 여부
                        if(paramDS.Tables["RQSTDT2"].Rows.Count > 0)
                        {
                            UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT2"], "PROC_CODE", row["PROC_CODE"],typeof(String));
                            //가용설비 설정
                            DLSE.LSE_STD_AVAILMC.LSE_STD_AVAILMC_INS(paramDS.Tables["RQSTDT2"],bizExecute);
                        }
                    }

                    //공정업데이트
                    LSEU.LSEU.UPDATE_STD_PROC(UTIL.GetDtToDs(UTIL.GetRowToDt(row)), bizExecute);

                }

                return STD41A_SER3(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }


        /// <summary>
        /// 대일정 삭제
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet STD41A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PRG_CLASS", 1, typeof(Byte));
                
                DSTD.TSTD_PROCGRP.TSTD_PROCGRP_UDE(paramDS.Tables["RQSTDT"],  bizExecute);

                return paramDS;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        /// <summary>
        /// 중일정 삭제
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet STD41A_DEL2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PRG_CLASS", 0, typeof(Byte));

                DSTD.TSTD_PROCGRP.TSTD_PROCGRP_UDE(paramDS.Tables["RQSTDT"],  bizExecute);

                return paramDS;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        /// <summary>
        /// 소일정 삭제
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet STD41A_DEL3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach(DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    //표준 공정 계획 확인
                    DataTable dtSerPlan = DSTD.TSTD_PROCPLAN.TSTD_PROCPLAN_SER4(UTIL.GetRowToDt(row), bizExecute);

                    if(dtSerPlan.Rows.Count > 0)
                    {
                        throw UTIL.SetException("표준공정계획에 해당공정이 존재하여 삭제 할수 없습니다."                                    
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , 200045);
                    }

                    //표준 BOP 확인
                    DataTable dtSerStdBop = DLSE.LSE_STDBOP_PROC.LSE_STDBOP_PROC_SER4(UTIL.GetRowToDt(row), bizExecute);

                    if(dtSerStdBop.Rows.Count > 0)
                    {
                        throw UTIL.SetException("표준BOP에 해당공정이 존재하여 삭제 할수 없습니다."                                    
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , 200046);

                    }
                    
                    //소일정 삭제
                    DLSE.LSE_STD_PROC.LSE_STD_PROC_UDE(UTIL.GetRowToDt(row), bizExecute);
                    //가용설비 삭제
                    DLSE.LSE_STD_AVAILMC.LSE_STD_AVAILMC_DEL(UTIL.GetRowToDt(row), bizExecute);

                }                

                return paramDS;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        /// <summary>
        /// 대일정 조회
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet STD41A_SER( DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PRG_CLASS", 1, typeof(Byte));

                DataTable dtRslt = DSTD.TSTD_PROCGRP_QUERY.TSTD_PROCGRP_QUERY2(paramDS.Tables["RQSTDT"],  bizExecute);

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

        /// <summary>
        /// 중일정 조회
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet STD41A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PRG_CLASS", 0, typeof(Byte));

                DataTable dtRslt = DSTD.TSTD_PROCGRP_QUERY.TSTD_PROCGRP_QUERY2(paramDS.Tables["RQSTDT"],  bizExecute);

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

        /// <summary>
        /// 소일정(공정) 조회
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet STD41A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DLSE.LSE_STD_PROC_QUERY.LSE_STD_PROC_QUERY4(paramDS.Tables["RQSTDT"],  bizExecute);

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

        /// <summary>
        /// 가용설비 조회
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet STD41A_SER4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DLSE.LSE_STD_AVAILMC_QUERY.LSE_STD_AVAILMC_QUERY2(paramDS.Tables["RQSTDT"],  bizExecute);

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

        /// <summary>
        /// 가용설비 설정을 위한 표준
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet STD41A_SER5(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DLSE.LSE_MACHINE_QUERY.LSE_MACHINE_QUERY2(paramDS.Tables["RQSTDT"],  bizExecute);

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


    }
}
