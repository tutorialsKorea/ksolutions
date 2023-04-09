using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BSTD
{

    public class STD02A
    {

        /// <summary>
        /// 표준 부품 저장
        /// 1. DATA_FLAG, 현재 시각 알아온다.
        /// 2. STD_STD_PART 조회,
        /// 3. 2번 데이터 있으면 삭제된 데이터인지 확인, 덮어쓰기 여부에 따라 UPDATE
        /// 4. 2번 데이터 없으면 INSERT, 결과 반환(STD02A_SER)
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet STD02A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
         
                    DataTable dtRslt = DLSE.LSE_STD_PART.LSE_STD_PART_SER(UTIL.GetRowToDt(row), bizExecute);

                    //데이터가 있으면 삭제여부 및 덮어쓰기 여부에 따라 update
                    if (dtRslt.Rows.Count > 0)
                    {

                        if (row["OVERWRITE"].Equals("1"))
                        {
                            DLSE.LSE_STD_PART.LSE_STD_PART_UPD(UTIL.GetRowToDt(row), bizExecute);
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

                        DLSE.LSE_STD_PART.LSE_STD_PART_INS(UTIL.GetRowToDt(row), bizExecute);

                    }
                    
    
                }


                return STD02A_SER(paramDS,bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        //다른이름으로 저장
        public static DataSet STD02A_INS2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {

                    DataTable dtRslt = DLSE.LSE_STD_PART.LSE_STD_PART_SER(UTIL.GetRowToDt(row), bizExecute);

                    //데이터가 있으면 삭제여부 및 덮어쓰기 여부에 따라 update
                    if (dtRslt.Rows.Count > 0)
                    {
                        //수정
                        if (row["OVERWRITE"].Equals("1"))
                        {
                            DLSE.LSE_STD_PART.LSE_STD_PART_UPD(UTIL.GetRowToDt(row), bizExecute);
                            //기존 공정,설비,작업자 / 자주검사 정보 삭제
                            DLSE.LSE_STD_PARTPROC.LSE_STD_PARTPROC_DEL(UTIL.GetRowToDt(row), bizExecute);
                            DSTD.TSTD_PART_INS.TSTD_PART_INS_DEL2(UTIL.GetRowToDt(row), bizExecute);

                            DataTable dtPartSel = UTIL.GetRowToDt(row).Copy();

                            UTIL.SetBizAddColumnToValue(dtPartSel, "DATA_FLAG", 0, typeof(Byte));
                            UTIL.SetBizAddColumnToValue(dtPartSel, "PART_CODE", row["OLD_PART_CODE"], typeof(String));

                            //공정,설비,작업자 SELECT
                            DataTable dtPartProcRslt = DLSE.LSE_STD_PARTPROC.LSE_STD_PARTPROC_SER3(dtPartSel, bizExecute);

                            //공정,설비,작업자 INSERT
                            if (dtPartProcRslt.Rows.Count > 0)
                            {
                                UTIL.SetBizAddColumnToValue(dtPartProcRslt, "PART_CODE", row["PART_CODE"], typeof(String));
                                UTIL.SetBizAddColumnToValue(dtPartProcRslt, "PART_NAME", row["PART_NAME"], typeof(String));

                                DLSE.LSE_STD_PARTPROC.LSE_STD_PARTPROC_INS(dtPartProcRslt, bizExecute);
                            }
                            
                            //자주검사 SELECT
                            DataTable dtPartInsRslt = DSTD.TSTD_PART_INS.TSTD_PART_INS_SER(dtPartSel, bizExecute);

                            //자주검사 INSERT
                            foreach (DataRow PartRow in dtPartInsRslt.Rows)
                            {

                                UTIL.SetBizAddColumnToValue(dtPartInsRslt, "PART_NAME", row["PART_NAME"], typeof(String));

                                PartRow["PART_CODE"] = row["PART_CODE"];
                                PartRow["PART_NAME"] = row["PART_NAME"];

                                DataTable dtPartRslt = DSTD.TSTD_PART_INS.TSTD_PART_INS_SER2(UTIL.GetRowToDt(PartRow), bizExecute);

                                if (dtPartRslt.Rows.Count != 0)
                                {
                                    PartRow["DATA_FLAG"] = 0;
                                    DSTD.TSTD_PART_INS.TSTD_PART_INS_UPD2(UTIL.GetRowToDt(PartRow), bizExecute);
                                }
                                else
                                {
                                    DSTD.TSTD_PART_INS.TSTD_PART_INS_INS(UTIL.GetRowToDt(PartRow), bizExecute);
                                }

                            }
                            


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
                        //품목 INSERT
                        DLSE.LSE_STD_PART.LSE_STD_PART_INS(UTIL.GetRowToDt(row), bizExecute);

                        DataTable dtPartSel = UTIL.GetRowToDt(row).Copy();

                        UTIL.SetBizAddColumnToValue(dtPartSel, "DATA_FLAG", 0, typeof(Byte));
                        UTIL.SetBizAddColumnToValue(dtPartSel, "PART_CODE", row["OLD_PART_CODE"], typeof(String));

                        //공정,설비,작업자 SELECT
                        DataTable dtPartProcRslt = DLSE.LSE_STD_PARTPROC.LSE_STD_PARTPROC_SER3(dtPartSel, bizExecute);

                        if (dtPartProcRslt.Rows.Count > 0)
                        {
                            UTIL.SetBizAddColumnToValue(dtPartProcRslt, "PART_CODE", row["PART_CODE"], typeof(String));
                            UTIL.SetBizAddColumnToValue(dtPartProcRslt, "PART_NAME", row["PART_NAME"], typeof(String));

                            //공정,설비,작업자 INSERT
                            DLSE.LSE_STD_PARTPROC.LSE_STD_PARTPROC_INS(dtPartProcRslt, bizExecute);
                        }
                        

                        //자주검사 SELECT
                        DataTable dtPartInsRslt = DSTD.TSTD_PART_INS.TSTD_PART_INS_SER(dtPartSel, bizExecute);

                        if (dtPartInsRslt.Rows.Count > 0)
                        {
                            UTIL.SetBizAddColumnToValue(dtPartInsRslt, "PART_CODE", row["PART_CODE"], typeof(String));
                            UTIL.SetBizAddColumnToValue(dtPartInsRslt, "PART_NAME", row["PART_NAME"], typeof(String));

                            //자주검사 INSERT
                            DSTD.TSTD_PART_INS.TSTD_PART_INS_INS(dtPartInsRslt, bizExecute);
                        }
                        
                        
                    }

                }

                return STD02A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        /// <summary>
        /// 표준공정 라우팅 저장
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet STD02A_SAVE(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DLSE.LSE_STD_PARTPROC.LSE_STD_PARTPROC_DEL(paramDS.Tables["RQSTDT"], bizExecute);

                DLSE.LSE_STD_PARTPROC.LSE_STD_PARTPROC_INS(paramDS.Tables["RQSTDT"], bizExecute);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        /// <summary>
        /// 표준 부품 삭제
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet STD02A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
         
                DLSE.LSE_STD_PART.LSE_STD_PART_UDE(paramDS.Tables["RQSTDT"],  bizExecute);

                //기존 공정,설비,작업자 / 자주검사 정보 삭제
                DLSE.LSE_STD_PARTPROC.LSE_STD_PARTPROC_DEL(paramDS.Tables["RQSTDT"], bizExecute);
                DSTD.TSTD_PART_INS.TSTD_PART_INS_DEL2(paramDS.Tables["RQSTDT"], bizExecute);
                return paramDS;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        /// <summary>
        /// 표준 부품 조회
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet STD02A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dt = DLSE.LSE_STD_PART_QUERY_AJB.LSE_STD_PART_QUERY2(paramDS.Tables["RQSTDT"],  bizExecute);
                dt.Columns.Add("SEL", typeof(string));
                dt.TableName = "RSLTDT";

                paramDS.Tables.Add(dt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }



        public static DataSet STD02A_SER1(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dt = DLSE.LSE_STD_PART_QUERY.LSE_STD_PART_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
                //dt.Columns.Add("SEL", typeof(string));
                dt.TableName = "RSLTDT";

                paramDS.Tables.Add(dt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        /// <summary>
        /// 표준 부품 조회
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet STD02A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dt = DLSE.LSE_STD_PARTPROC_QUERY.LSE_STD_PARTPROC_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
                dt.Columns.Add("SEL", typeof(string));
                dt.TableName = "RSLTDT";

                paramDS.Tables.Add(dt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }



        public static DataSet STD02A_UPD(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DLSE.LSE_STD_PART.LSE_STD_PART_UPD16(paramDS.Tables["RQSTDT"], bizExecute);

                return STD02A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }
    }
}
