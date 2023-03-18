using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BPLN
{
    /// <summary>
    /// 부품별 표준 계획 수립
    /// </summary>
    /// <author>신재경</author>
    /// <remarks>
    /// <b>2016.03.24</b> 신규생성<br/>
    /// </remarks>
    public class PLN01A
    {
        //품목 정보 가져오기(트리)
        public static DataSet PLN01A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                //DataTable dtRslt = DLSE.LSE_STD_PART_QUERY.LSE_STD_PART_QUERY10(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable dtRslt = DLSE.LSE_STD_PART_QUERY.LSE_STD_PART_QUERY14(paramDS.Tables["RQSTDT"], bizExecute);

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

        //품목 정보 가져오기(공정 및 자주검사 정보)
        public static DataSet PLN01A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                //DataTable dtRslt = DLSE.LSE_STD_PART_QUERY.LSE_STD_PART_QUERY5(paramDS.Tables["RQSTDT"], bizExecute);                
                //dtRslt.TableName = "RSLTDT";
                //paramDS.Tables.Add(dtRslt);
                //자주검사 정보
                DataTable dtRslt = DSTD.TSTD_PART_INS.TSTD_PART_INS_SER(paramDS.Tables["RQSTDT"], bizExecute);
                //dtRslt.Columns.Add("SEL", typeof(string));
                dtRslt.TableName = "RSLTDT";
                //공정정보
                DataTable dtRslt2 = DLSE.LSE_STD_PARTPROC.LSE_STD_PARTPROC_SER2(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt2.TableName = "RSLTDT_PROC";

                DataTable dtRslt3 = DLSE.LSE_STD_PART.LSE_STD_PART_SER(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt3.TableName = "RSLTDT_PART";


                paramDS.Tables.Add(dtRslt);
                paramDS.Tables.Add(dtRslt2);
                paramDS.Tables.Add(dtRslt3);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        /// <summary>
        /// 보관위치 이미지
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet PLN01A_SER6(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataTable dtRslt = DLSE.LSE_STD_PART.LSE_STD_PART_SER2(paramDS.Tables["RQSTDT"], bizExecute);

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

        //품목공정 정보 저장
        public static DataSet PLN01A_SAVE(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                if(paramDS.Tables["RQSTDT"].Rows.Count == 0) 
                {
                    paramDS.Tables.Add(new DataTable("RSLTDT"));
                    return paramDS;
                }

                DataTable dtRqst_Copy = UTIL.GetRowToDt(paramDS.Tables["RQSTDT"].Rows[0]);

                DLSE.LSE_STD_PARTPROC.LSE_STD_PARTPROC_DEL(dtRqst_Copy, bizExecute);

                DLSE.LSE_STD_PARTPROC.LSE_STD_PARTPROC_INS(paramDS.Tables["RQSTDT"], bizExecute);

                //가공비 UPDATE
                DataTable dtproc = DLSE.LSE_STD_PARTPROC_QUERY.LSE_STD_PARTPROC_QUERY4(paramDS.Tables["RQSTDT"], bizExecute);

                DLSE.LSE_STD_PART.LSE_STD_PART_UPD7(dtproc, bizExecute);

                #region 설비 삭제 및 등록
                //기존 등록 설비들 삭제
                DAPS.APS_STD_AVAILMC_PART.APS_STD_AVAILMC_PART_DEL(paramDS.Tables["RQSTDT"], bizExecute);
                
                DAPS.APS_STD_AVAILMC_PART.APS_STD_AVAILMC_PART_INS(paramDS.Tables["RQSTDT_MC_SEQ"], bizExecute);

                #endregion


                DataTable dtRslt = DLSE.LSE_STD_PARTPROC.LSE_STD_PARTPROC_SER2(dtRqst_Copy, bizExecute);
                
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
        /// 품목별 자주검사 항목 저장
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet PLN01A_SAVE2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (paramDS.Tables["RQSTDT"].Rows.Count == 0)
                {
                    paramDS.Tables.Add(new DataTable("RSLTDT"));
                    return paramDS;
                }

                DataRow dr = paramDS.Tables["RQSTDT"].Rows[0];

                DataTable dtSer = DSTD.TSTD_PART_INS.TSTD_PART_INS_SER(paramDS.Tables["RQSTDT"], bizExecute);

                if (dtSer.Rows.Count > 0)
                {
                    if (dr["OVERWRITE"].Equals("1"))
                    {
                        DSTD.TSTD_PART_INS.TSTD_PART_INS_UPD(UTIL.GetRowToDt(dr), bizExecute);
                    }
                }
                else
                {
                    DSTD.TSTD_PART_INS.TSTD_PART_INS_INS(paramDS.Tables["RQSTDT"], bizExecute);
                }

                paramDS.Tables["RQSTDT"].Rows[0]["INS_CODE"] = DBNull.Value;

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSTD.TSTD_PART_INS.TSTD_PART_INS_SER(paramDS.Tables["RQSTDT"], bizExecute);

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
        /// 품목 공정별 설비 및 작업자 저장
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static void PLN01A_SAVE3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (paramDS.Tables["RQSTDT"].Rows.Count == 0) return;
                
                DataRow dr = paramDS.Tables["RQSTDT"].Rows[0];

                DataTable dtSer = DLSE.LSE_STD_PARTPROC.LSE_STD_PARTPROC_SER(paramDS.Tables["RQSTDT"], bizExecute);

                if (dtSer.Rows.Count > 0)
                {
                    DLSE.LSE_STD_PARTPROC.LSE_STD_PARTPROC_UPD(paramDS.Tables["RQSTDT"], bizExecute);
                }
                else
                {
                    DLSE.LSE_STD_PARTPROC.LSE_STD_PARTPROC_INS(paramDS.Tables["RQSTDT"], bizExecute);
                }

                return ;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PLN01A_SAVE4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DLSE.LSE_STD_PARTPROC.LSE_STD_PARTPROC_DEL(paramDS.Tables["RQSTDT"], bizExecute);

                //LSE_STD_PARTPROC_INS2
                DLSE.LSE_STD_PARTPROC.LSE_STD_PARTPROC_INS2(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable dtproc = DLSE.LSE_STD_PARTPROC_QUERY.LSE_STD_PARTPROC_QUERY4(paramDS.Tables["RQSTDT"], bizExecute);

                DLSE.LSE_STD_PART.LSE_STD_PART_UPD7(dtproc, bizExecute);

                DAPS.APS_STD_AVAILMC_PART.APS_STD_AVAILMC_PART_DEL2(paramDS.Tables["RQSTDT"], bizExecute);
                DAPS.APS_STD_AVAILMC_PART.APS_STD_AVAILMC_PART_COPY(paramDS.Tables["RQSTDT"], bizExecute);

                return paramDS;

                //DataTable dtRslt = DLSE.LSE_STD_PARTPROC.LSE_STD_PARTPROC_SER2(dtRqst_Copy, bizExecute);

                //dtRslt.TableName = "RSLTDT";

                //paramDS.Tables.Add(dtRslt);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 첨부 파일 목록 수 갱신
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static void PLN01A_SAVE5(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                
                DLSE.LSE_STD_PART.LSE_STD_PART_UPD8(paramDS.Tables["RQSTDT"], bizExecute);

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 품목정보 업데이트
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        public static void PLN01A_SAVE6(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DLSE.LSE_STD_PART.LSE_STD_PART_UPD12(paramDS.Tables["RQSTDT"], bizExecute);

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// BOM 정보 업데이트
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        public static void PLN01A_SAVE7(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DSTD.TSTD_BOM.TSTD_BOM_UPD2(paramDS.Tables["RQSTDT"], bizExecute);

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
        /// <summary>
        /// 공정정보 업데이트
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        public static void PLN01A_SAVE8(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    if (row["IS_SAVE"].toInt32() == 0)
                    {
                        DLSE.LSE_STD_PARTPROC_VIRTUAL.LSE_STD_PARTPROC_VIRTUAL_DEL(UTIL.GetRowToDt(row), bizExecute);
                    }
                    else
                    {
                        DataTable result =  DLSE.LSE_STD_PARTPROC_VIRTUAL.LSE_STD_PARTPROC_VIRTUAL_SER(UTIL.GetRowToDt(row), bizExecute);
                        
                        if(result.Rows.Count == 0)
                            DLSE.LSE_STD_PARTPROC_VIRTUAL.LSE_STD_PARTPROC_VIRTUAL_INS(UTIL.GetRowToDt(row), bizExecute);
                    }
                }

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
        public static void PLN01A_MC_SAVE(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DAPS.APS_STD_AVAILMC_PART.APS_STD_AVAILMC_PART_DEL(paramDS.Tables["RQSTDT"], bizExecute);
                DAPS.APS_STD_AVAILMC_PART.APS_STD_AVAILMC_PART_INS(paramDS.Tables["RQSTDT"], bizExecute);

                return;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        /// <summary>
        /// BOM 저장
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet PLN01A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                string _strBomPartCode = "";

                if (paramDS.Tables["RQSTDT"].Rows.Count > 0)
                {
                    if (_strBomPartCode == "")
                    {
                        _strBomPartCode = paramDS.Tables["RQSTDT"].Rows[0]["BOM_PART_CODE"].ToString();
                    }

                    //BOM등록여부 조회
                    DataTable dtBomSer = new DataTable("RQSTDT");
                    dtBomSer.Columns.Add("PLT_CODE", typeof(String));
                    dtBomSer.Columns.Add("BOM_PART_CODE", typeof(String));

                    DataRow paramRow = dtBomSer.NewRow();
                    paramRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                    paramRow["BOM_PART_CODE"] = _strBomPartCode;

                    dtBomSer.Rows.Add(paramRow);

                    DataTable dtBomSerRslt = DSTD.TSTD_BOM_QUERY.TSTD_BOM_QUERY1(dtBomSer, bizExecute);

                    if (dtBomSerRslt.Rows.Count == 0)
                    {
                        //등록된 BOM이 없으면 최상위 부품 INSERT
                        DataTable dtBomIns = new DataTable("RQSTDT");
                        dtBomIns.Columns.Add("PLT_CODE", typeof(String));
                        dtBomIns.Columns.Add("BOM_ID", typeof(String));
                        dtBomIns.Columns.Add("BOM_PART_CODE", typeof(String));
                        dtBomIns.Columns.Add("PARENT_ID", typeof(String));
                        dtBomIns.Columns.Add("PART_CODE", typeof(String));

                        DataRow paramRow2 = dtBomIns.NewRow();
                        paramRow2["PLT_CODE"] = ConnInfo.PLT_CODE;
                        paramRow2["BOM_ID"] = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "BM", bizExecute);
                        paramRow2["BOM_PART_CODE"] = _strBomPartCode;
                        paramRow2["PARENT_ID"] = null;
                        paramRow2["PART_CODE"] = _strBomPartCode;

                        dtBomIns.Rows.Add(paramRow2);

                        DSTD.TSTD_BOM.TSTD_BOM_INS(dtBomIns, bizExecute);

                        //모품목 설정
                        UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PARENT_ID", dtBomIns.Rows[0]["BOM_ID"].ToString(), typeof(String));
                    }


                    foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                    {
                        if (row["BOM_ID"].ToString() != "")
                        {
                            //BOM_ID가 있을 경우 UPDATE
                            DSTD.TSTD_BOM.TSTD_BOM_UPD(UTIL.GetRowToDt(row), bizExecute);

                        }
                        else
                        {
                            //BOM_ID가 없을경우 INSERT
                            row["BOM_ID"] = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "BM", bizExecute);

                            DSTD.TSTD_BOM.TSTD_BOM_INS(UTIL.GetRowToDt(row), bizExecute);

                            //하위BOM(선삭)도 추가
                            PLN.TurnningChildBomSave(UTIL.GetRowToDt(row), bizExecute);
                        }
                    }
                }

                DataTable dtRslt = new DataTable("RQSTDT");
                dtRslt.Columns.Add("PLT_CODE", typeof(String));
                dtRslt.Columns.Add("BOM_PART_CODE", typeof(String));

                DataRow paramRow3 = dtRslt.NewRow();
                paramRow3["PLT_CODE"] = ConnInfo.PLT_CODE;
                paramRow3["BOM_PART_CODE"] = _strBomPartCode;
                dtRslt.Rows.Add(paramRow3);

                DataSet dsRslt = new DataSet();

                dsRslt.Tables.Add(dtRslt);

                return PLN01A_SER8(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// PROC 개별 설정 저장
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet PLN01A_INS2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (paramDS.Tables["RQSTDT_DEL"].Rows.Count > 0)
                {
                    DLSE.LSE_STD_PARTPROC_WORK.LSE_STD_PARTPROC_WORK_DEL2(UTIL.GetRowToDt(paramDS.Tables["RQSTDT_DEL"].Rows[0]), bizExecute);
                }

                foreach (DataRow row in paramDS.Tables["RQSTDT_WORK"].Rows)
                {
                    if (row["WORK_CODE"].isNull())
                    {
                        row["WORK_CODE"] = UTIL.UTILITY_GET_SERIALNO(row["WORK_CODE"].ToString()
                                                    , "WORK"
                                                    , bizExecute);
                    }

                    DataTable rowDt = UTIL.GetRowToDt(row);
                    DataTable dt = DLSE.LSE_STD_PARTPROC_WORK_QUERY.LSE_STD_PARTPROC_WORK_QUERY1(rowDt, bizExecute);
                    if (dt.Rows.Count > 0)
                    {
                        DLSE.LSE_STD_PARTPROC_WORK.LSE_STD_PARTPROC_WORK_UPD(rowDt, bizExecute);
                    }
                    else
                    {
                        DLSE.LSE_STD_PARTPROC_WORK.LSE_STD_PARTPROC_WORK_INS(rowDt, bizExecute);
                    }
                }

                foreach (DataRow row in paramDS.Tables["RQSTDT_PRE"].Rows)
                {
                    DataTable rowDt = UTIL.GetRowToDt(row);
                    DataTable dt = DLSE.LSE_STD_PARTPROC_PRE.LSE_STD_PARTPROC_PRE_SER(rowDt, bizExecute);
                    if (dt.Rows.Count > 0)
                    {
                        DLSE.LSE_STD_PARTPROC_PRE.LSE_STD_PARTPROC_PRE_UPD(rowDt, bizExecute);
                    }
                    else
                    {
                        DLSE.LSE_STD_PARTPROC_PRE.LSE_STD_PARTPROC_PRE_INS(rowDt, bizExecute);
                    }
                }

                if(paramDS.Tables["RQSTDT_DEL"].Rows.Count> 0)
                {
                    DLSE.LSE_STD_PARTPROC_CONT.LSE_STD_PARTPROC_CONT_DEL2(UTIL.GetRowToDt(paramDS.Tables["RQSTDT_DEL"].Rows[0]), bizExecute);                
                }

                foreach (DataRow row in paramDS.Tables["RQSTDT_CONT"].Rows)
                {
                    if(row["CONT_CODE"].isNull())
                    {
                        row["CONT_CODE"] = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString()
                                                    , "PRE"
                                                    , bizExecute);
                    }

                    DataTable rowDt = UTIL.GetRowToDt(row);
                    DataTable dt = DLSE.LSE_STD_PARTPROC_CONT_QUERY.LSE_STD_PARTPROC_CONT_QUERY1(rowDt, bizExecute);
                    if (dt.Rows.Count > 0)
                    {
                        DLSE.LSE_STD_PARTPROC_CONT.LSE_STD_PARTPROC_CONT_UPD2(rowDt, bizExecute);
                    }
                    else
                    {
                        DLSE.LSE_STD_PARTPROC_CONT.LSE_STD_PARTPROC_CONT_INS(rowDt, bizExecute);
                    }
                }

                foreach (DataRow row in paramDS.Tables["RQSTDT_ACTTOOL"].Rows)
                {
                    DataTable rowDt = UTIL.GetRowToDt(row);
                    DataTable dt = DSTD.TSTD_ACTUAL_TOOL_QUERY.TSTD_ACTUAL_TOOL_QUERY1(rowDt, bizExecute);
                    if(row["IS_DEL"].Equals("1"))
                    {
                        DSTD.TSTD_ACTUAL_TOOL.TSTD_ACTUAL_TOOL_DEL(rowDt, bizExecute);
                    }
                    else
                    {
                        if (dt.Rows.Count > 0)
                        {
                            DSTD.TSTD_ACTUAL_TOOL.TSTD_ACTUAL_TOOL_UPD(rowDt, bizExecute);
                        }
                        else
                        {
                            DSTD.TSTD_ACTUAL_TOOL.TSTD_ACTUAL_TOOL_INS(rowDt, bizExecute);
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

        /// <summary>
        /// PROC CONTENTS 저장
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet PLN01A_INS3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow paramRow in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dt = DLSE.LSE_STD_PARTPROC_ASSY.LSE_STD_PARTPROC_ASSY_SER(UTIL.GetRowToDt(paramRow), bizExecute);
                    if (dt.Rows.Count > 0)
                    {
                        DLSE.LSE_STD_PARTPROC_ASSY.LSE_STD_PARTPROC_ASSY_UPD(UTIL.GetRowToDt(paramRow), bizExecute);
                    }
                    else
                    {
                        DLSE.LSE_STD_PARTPROC_ASSY.LSE_STD_PARTPROC_ASSY_INS(UTIL.GetRowToDt(paramRow), bizExecute);
                    }
                }
                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PLN01A_INS4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DLSE.LSE_STD_PARTPROC.LSE_STD_PARTPROC_UPD3(paramDS.Tables["RQSTDT"], bizExecute);
                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PLN01A_INS5(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DLSE.LSE_STD_PART.LSE_STD_PART_UPD13(paramDS.Tables["RQSTDT"], bizExecute);
                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PLN01A_INS6(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DSTD.TSTD_PART_INS.TSTD_PART_INS_UPD3(paramDS.Tables["RQSTDT"], bizExecute);
                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        /// <summary>
        /// 품목별 자주검사 항목 조회
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet PLN01A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataTable dtRslt = DSTD.TSTD_PART_INS.TSTD_PART_INS_SER(paramDS.Tables["RQSTDT"], bizExecute);
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
        /// 품목별 자주검사 항목 삭제
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet PLN01A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DSTD.TSTD_PART_INS.TSTD_PART_INS_DEL(paramDS.Tables["RQSTDT"], bizExecute);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 공정정보 조회
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet  PLN01A_SER4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DLSE.LSE_STD_PARTPROC_QUERY.LSE_STD_PARTPROC_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static DataSet PLN01A_SER5(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DLSE.LSE_STD_PART_QUERY.LSE_STD_PART_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static DataSet PLN01A_SER7(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                DataTable dtRslt_mc = DLSE.LSE_STD_AVAILMC_QUERY.LSE_STD_AVAILMC_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt_mc.TableName = "RSLTDT_STD_MC";

                DataTable dtRslt_Aps_mc = DAPS.APS_STD_AVAILMC_PART_QUERY.APS_STD_AVAILMC_PART_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt_Aps_mc.TableName = "RSLTDT_APS_MC";

                paramDS.Tables.Add(dtRslt_mc);
                paramDS.Tables.Add(dtRslt_Aps_mc);
                return paramDS;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PLN01A_SER8(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                //DataTable dtRslt = DLSE.LSE_STD_PART_QUERY.LSE_STD_PART_QUERY5(paramDS.Tables["RQSTDT"], bizExecute);                
                //dtRslt.TableName = "RSLTDT";
                //paramDS.Tables.Add(dtRslt);
                //자주검사 정보
                DataTable dtRslt = DSTD.TSTD_PART_INS.TSTD_PART_INS_SER(paramDS.Tables["RQSTDT"], bizExecute);
                //dtRslt.Columns.Add("SEL", typeof(string));
                dtRslt.TableName = "RSLTDT";
                //공정정보
                DataTable dtRslt2 = DLSE.LSE_STD_PARTPROC.LSE_STD_PARTPROC_SER2(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt2.TableName = "RSLTDT_PROC";

                DataTable dtRslt3 = DLSE.LSE_STD_PART.LSE_STD_PART_SER(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt3.TableName = "RSLTDT_PART";


                DataTable dtRslt_Bom = DSTD.TSTD_BOM_QUERY.TSTD_BOM_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt_Bom.TableName = "RSLTDT_BOM";

                DataTable dtRslt_Bom_Proc = DLSE.LSE_STD_PARTPROC_VIRTUAL.LSE_STD_PARTPROC_VIRTUAL_SER2(dtRslt_Bom, bizExecute);
                dtRslt_Bom_Proc.TableName = "RSLTDT_BOM_PROC";

                DataTable dtRslt_PrgAndProc = DLSE.LSE_STD_PROC_QUERY.LSE_STD_PROC_QUERY5(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt_PrgAndProc.TableName = "RSLTDT_PRG_PROC";

                DataTable dtRslt_AssyProc = DLSE.LSE_STD_PARTPROC_ASSY_QUERY.LSE_STD_PARTPROC_ASSY_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt_AssyProc.TableName = "RSLTDT_ASSY_PROC";
                
                UTIL.SetBizAddColumnToValue(dtRslt_AssyProc, "SEL", typeof(String));

                paramDS.Tables.Add(dtRslt);
                paramDS.Tables.Add(dtRslt2);
                paramDS.Tables.Add(dtRslt3);
                paramDS.Tables.Add(dtRslt_Bom);
                paramDS.Tables.Add(dtRslt_Bom_Proc);
                paramDS.Tables.Add(dtRslt_PrgAndProc);
                paramDS.Tables.Add(dtRslt_AssyProc);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static DataSet PLN01A_SER9(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                //자주검사 정보
                DataTable dtRslt = DLSE.LSE_STD_PARTPROC_WORK.LSE_STD_PARTPROC_WORK_SER(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt.TableName = "RSLTDT_WORK";
                //공정정보
                DataTable dtRslt2 = DLSE.LSE_STD_PARTPROC_PRE_QUERY.LSE_STD_PARTPROC_PRE_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt2.TableName = "RSLTDT_PRE";

                DataTable dtRslt3 = DLSE.LSE_STD_PARTPROC_CONT.LSE_STD_PARTPROC_CONT_SER(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt3.TableName = "RSLTDT_CONT";

                DataTable dtRslt6 = DSTD.TSTD_ACTUAL_TOOL_QUERY.TSTD_ACTUAL_TOOL_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt6.TableName = "RSLTDT_ACT_TOOL";

                DataTable dtRslt4 = DLSE.LSE_STD_PARTPROC.LSE_STD_PARTPROC_SER4(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt4.TableName = "RSLTDT_PROC_FILE";

                DataTable dtRslt5 = DLSE.LSE_STD_PART.LSE_STD_PART_SER4(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt5.TableName = "RSLTDT_ASSY_FILE";

                paramDS.Tables.Add(dtRslt);
                paramDS.Tables.Add(dtRslt2);
                paramDS.Tables.Add(dtRslt3);
                paramDS.Tables.Add(dtRslt6);
                paramDS.Tables.Add(dtRslt4);
                paramDS.Tables.Add(dtRslt5);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }


        public static DataSet PLN01A_SER_STD(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                //공정 정보
                DataTable dtRslt = DLSE.LSE_STD_PARTPROC_QUERY.LSE_STD_PARTPROC_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT_PROC";

                paramDS.Tables.Add(dtRslt);

                //설비 정보 key 공정+설비
                DataTable dtRslt_Mc = DLSE.LSE_STD_AVAILMC_QUERY.LSE_STD_AVAILMC_QUERY6(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt_Mc.Columns.Add("SEL", typeof(string));
                dtRslt_Mc.TableName = "RSLTDT_MC";

                paramDS.Tables.Add(dtRslt_Mc);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static DataSet PLN01A_SER_STD2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                //공정 정보
                DataTable dtRslt = DLSE.LSE_STD_PARTPROC_QUERY.LSE_STD_PARTPROC_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT_PROC";

                paramDS.Tables.Add(dtRslt);

                //설비 정보 key 공정+설비
                DataTable dtRslt_Avail_Mc = DAPS.APS_STD_AVAILMC_PART_QUERY.APS_STD_AVAILMC_PART_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt_Avail_Mc.Columns.Add("SEL", typeof(string));
                dtRslt_Avail_Mc.TableName = "RSLTDT_AVAIL_MC";

                paramDS.Tables.Add(dtRslt_Avail_Mc);

                //설비 정보 key 공정+설비
                DataTable dtRslt_Mc = DLSE.LSE_STD_AVAILMC_QUERY.LSE_STD_AVAILMC_QUERY6(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt_Mc.Columns.Add("SEL", typeof(string));
                dtRslt_Mc.TableName = "RSLTDT_MC";

                paramDS.Tables.Add(dtRslt_Mc);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        }
}
