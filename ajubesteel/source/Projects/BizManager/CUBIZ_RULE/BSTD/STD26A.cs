using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BSTD
{
    public class STD26A
    {
        /// <summary>
        /// 재질 조회
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet STD26A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte)); // VAR에 DATA_FLAG값 0 설정

                DataTable dtRslt = DMAT.TMAT_QUC_MASTER_QUERY.TMAT_QUC_MASTER_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);

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
        /// 재질단가 적용기간 조회
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet STD26A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte)); // VAR에 DATA_FLAG값 0 설정

                DataTable dtRslt = DMAT.TMAT_QUC_DETAIL_QUERY.TMAT_QUC_DETAIL_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);

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

        /// <summary>
        /// 재질 추가
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        public static DataSet STD26A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "MDFY_EMP", 0, typeof(String));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {

                    DataTable dtRslt = DMAT.TMAT_QUC_MASTER.TMAT_QUC_MASTER_SER(UTIL.GetRowToDt(row), bizExecute);

                    //데이터가 있으면 삭제여부 및 덮어쓰기 여부에 따라 update
                    if (dtRslt.Rows.Count > 0)
                    {

                        if (row["OVERWRITE"].Equals("1"))
                        {
                            row["MDFY_EMP"] = row["REG_EMP"];
                            //DSTD.TSTD_PROCGRP.TSTD_PROCGRP_UPD(UTIL.GetRowToDt(row), bizExecute);
                            DMAT.TMAT_QUC_MASTER.TMAT_QUC_MASTER_UPD(UTIL.GetRowToDt(row), bizExecute);
                        }
                        else
                        {
                            if (dtRslt.Rows[0]["DATA_FLAG"].Equals((byte)2))
                            {

                                throw UTIL.SetException("동일 데이터가 이력이 존재할때 발생"
                                    , row["MQLTY_CODE"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.OVERWRITE_HISTORY, dtRslt.Rows[0]);

                            }
                            else
                            {
                                throw UTIL.SetException("동일 데이터가 존재할때 발생"
                                    , row["MQLTY_CODE"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.OVERWRITE);
                            }
                        }
                    }
                    else
                    {
                        
                        DMAT.TMAT_QUC_MASTER.TMAT_QUC_MASTER_INS(UTIL.GetRowToDt(row), bizExecute);
                    }

                }

                return STD26A_SER(paramDS, bizExecute);

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 재질코드 단가 등록
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet STD26A_INS2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //1. 적용일 중첩되는지 확인
                //2. 동일 데이터 체크
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "MQLTY_DATE", "", typeof(String));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "MDFY_EMP", "", typeof(String));
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "QCD_ID", "", typeof(String));
                
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtRslt = DMAT.TMAT_QUC_DETAIL.TMAT_QUC_DETAIL_SER(UTIL.GetRowToDt(row), bizExecute);

                    //데이터가 있으면 삭제여부 및 덮어쓰기 여부에 따라 update
                    if (dtRslt.Rows.Count > 0)
                    {

                        if (row["OVERWRITE"].Equals("1"))
                        {
                            row["MDFY_EMP"] = row["REG_EMP"];
                            //row["QCD_ID"] = dtRslt.Rows[0]["QCD_ID"];

                            DMAT.TMAT_QUC_DETAIL.TMAT_QUC_DETAIL_UPD(UTIL.GetRowToDt(row), bizExecute);
                        }
                        else
                        {
                            if (dtRslt.Rows[0]["DATA_FLAG"].Equals((byte)2))
                            {

                                throw UTIL.SetException("동일 데이터가 이력이 존재할때 발생"
                                    , row["MQLTY_CODE"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.OVERWRITE_HISTORY, dtRslt.Rows[0]);

                            }
                            else
                            {
                                throw UTIL.SetException("동일 데이터가 존재할때 발생"
                                    , row["MQLTY_CODE"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.OVERWRITE);
                            }
                        }
                    }
                    else
                    {

                        //1-1. 시작일자 중첩 확인
                        row["MQLTY_DATE"] = row["MQLTY_START"];

                        DataTable dtDetailRslt = DMAT.TMAT_QUC_DETAIL_QUERY.TMAT_QUC_DETAIL_QUERY2(UTIL.GetRowToDt(row), bizExecute);

                        //데이터가 있으면 시작날짜 중첩
                        if (dtDetailRslt.Rows.Count > 0)
                        {
                            throw UTIL.SetException("시작일자 중첩"
                                            , row["MQLTY_CODE"].ToString()
                                            , new System.Diagnostics.StackFrame().GetMethod().Name
                                            , 200026);
                        }

                        //1-2. 완료일자 중첩 확인
                        row["MQLTY_DATE"] = row["MQLTY_END"];

                        dtDetailRslt = DMAT.TMAT_QUC_DETAIL_QUERY.TMAT_QUC_DETAIL_QUERY2(UTIL.GetRowToDt(row), bizExecute);

                        //데이터가 있으면 시작날짜 중첩
                        if (dtDetailRslt.Rows.Count > 0)
                        {
                            throw UTIL.SetException("시작일자 중첩"
                                            , row["MQLTY_CODE"].ToString()
                                            , new System.Diagnostics.StackFrame().GetMethod().Name
                                            , 200026);
                        }


                    
                        string serialNo = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "QCD", bizExecute);
                        row["QCD_ID"] = serialNo;

                        DMAT.TMAT_QUC_DETAIL.TMAT_QUC_DETAIL_INS(UTIL.GetRowToDt(row), bizExecute);
                    }

                }

                return STD26A_SER2(paramDS, bizExecute);

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
        
        /// <summary>
        /// 선택된 단가로 품목 정보 일괄 적용
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        public static DataSet STD26A_INS3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //품목정보 일괄 적용
                //MAT_UC, MAT_QLTY
                DLSE.LSE_STD_PART.LSE_STD_PART_UPD9(paramDS.Tables["RQSTDT"], bizExecute);

                //재질 단가에 적용 중 체크
                //APPLIED, MDFY_EMP, QCD_ID
                DMAT.TMAT_QUC_DETAIL.TMAT_QUC_DETAIL_UPD2(paramDS.Tables["RQSTDT"], bizExecute);

                //나머지 재질단가에 미적용 체크
                DMAT.TMAT_QUC_DETAIL.TMAT_QUC_DETAIL_UPD3(paramDS.Tables["RQSTDT"], bizExecute);


                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte)); // VAR에 DATA_FLAG값 0 설정
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "QCD_ID", DBNull.Value, typeof(Byte)); 

                DataTable dtRslt = DMAT.TMAT_QUC_DETAIL_QUERY.TMAT_QUC_DETAIL_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);

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
        /// <summary>
        /// 재질 삭제
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExcute"></param>
        public static DataSet STD26A_DEL(DataSet paramDS, BizExecute.BizExecute bizExcute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 2, typeof(Byte));

                DMAT.TMAT_QUC_MASTER.TMAT_QUC_MASTER_UDE(paramDS.Tables["RQSTDT"], bizExcute);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 재질단가 적용기간 삭제
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        public static DataSet STD26A_DEL2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 2, typeof(Byte));

                DMAT.TMAT_QUC_DETAIL.TMAT_QUC_DETAIL_UDE(paramDS.Tables["RQSTDT"], bizExecute);

                return paramDS;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
    }
}
