using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BizExecute;

namespace BSTD
{
    public class STD07A
    {
        //공구 정보 입력 
        public static DataSet STD07A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "MDFY_EMP", 0, typeof(String));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtRslt = DSTD.TSTD_TOOL.TSTD_TOOL_SER1(UTIL.GetRowToDt(row), bizExecute);

                    //데이터가 있으면 삭제여부 및 덮어쓰기 여부에 따라 update
                    if (dtRslt.Rows.Count > 0)
                    {
                        if (row["OVERWRITE"].Equals("1"))
                        {
                            row["MDFY_EMP"] = row["REG_EMP"];
                            DSTD.TSTD_TOOL.TSTD_TOOL_UPD(UTIL.GetRowToDt(row), bizExecute);
                        }
                        else
                        {
                            if (dtRslt.Rows[0]["DATA_FLAG"].Equals((byte)2))
                            {

                                throw UTIL.SetException("동일 데이터가 이력이 존재할때 발생"
                                    , row["TL_CODE"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.OVERWRITE_HISTORY, dtRslt.Rows[0]);

                            }
                            else
                            {
                                throw UTIL.SetException("동일 데이터가 존재할때 발생"
                                    , row["TL_CODE"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.OVERWRITE);
                            }
                        }
                    }
                    else
                    {
                        DSTD.TSTD_TOOL.TSTD_TOOL_INS(UTIL.GetRowToDt(row), bizExecute);
                    }
                }

                return STD07A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        //공구 LOT 정보 입력
        public static DataSet STD07A_INS2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_DETAIL"], "DATA_FLAG", 0, typeof(Decimal));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_DETAIL"], "TL_LOT", "", typeof(String));

                foreach (DataRow row in paramDS.Tables["RQSTDT_DETAIL"].Rows)
                {
                    row["TL_LOT"] = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "LOT", bizExecute);
                    DTOL.TTOL_TOOLLIST.TTOL_TOOLLIST_INS(UTIL.GetRowToDt(row), bizExecute);
                }

                DSTD.TSTD_TOOL.TSTD_TOOL_UPD2(paramDS.Tables["RQSTDT"], bizExecute);


                DataTable dtRslt_detail = DTOL.TTOL_TOOLLIST_QUERY.TTOL_TOOLLIST_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt_detail.Columns.Add("SEL", typeof(string));
                dtRslt_detail.TableName = "RSLTDT_DETAIL";
                paramDS.Tables.Add(dtRslt_detail);

                DataTable dtRslt = DSTD.TSTD_TOOL_QUERY.TSTD_TOOL_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
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

        //공구정보, 품목정보 입력
        public static DataSet STD07A_INS3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "MDFY_EMP", 0, typeof(String));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtRslt = DSTD.TSTD_TOOL.TSTD_TOOL_SER1(UTIL.GetRowToDt(row), bizExecute);

                    //데이터가 있으면 삭제여부 및 덮어쓰기 여부에 따라 update
                    if (dtRslt.Rows.Count > 0)
                    {
                        if (row["OVERWRITE"].Equals("1"))
                        {
                            row["MDFY_EMP"] = row["REG_EMP"];
                            DSTD.TSTD_TOOL.TSTD_TOOL_UPD(UTIL.GetRowToDt(row), bizExecute);
                        }
                        else
                        {
                            if (dtRslt.Rows[0]["DATA_FLAG"].Equals((byte)2))
                            {

                                throw UTIL.SetException("동일 데이터가 이력이 존재할때 발생"
                                    , row["TL_CODE"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.OVERWRITE_HISTORY, dtRslt.Rows[0]);

                            }
                            else
                            {
                                throw UTIL.SetException("동일 데이터가 존재할때 발생"
                                    , row["TL_CODE"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.OVERWRITE);
                            }
                        }
                    }
                    else
                    {
                        DSTD.TSTD_TOOL.TSTD_TOOL_INS(UTIL.GetRowToDt(row), bizExecute);
                    }
                }

                #region 품목정보 입력
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_ITEM"], "MDFY_EMP", 0, typeof(String));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_ITEM"], "IS_TOOL", 1, typeof(String));

                foreach (DataRow row in paramDS.Tables["RQSTDT_ITEM"].Rows)
                {

                    DataTable dtRslt = DLSE.LSE_STD_PART.LSE_STD_PART_SER(UTIL.GetRowToDt(row), bizExecute);

                    //데이터가 있으면 삭제여부 및 덮어쓰기 여부에 따라 update
                    if (dtRslt.Rows.Count > 0)
                    {
                        DLSE.LSE_STD_PART.LSE_STD_PART_UPD(UTIL.GetRowToDt(row), bizExecute);
                    }
                    else
                    {
                        DLSE.LSE_STD_PART.LSE_STD_PART_INS2(UTIL.GetRowToDt(row), bizExecute);
                    }
                }
                #endregion

                return STD07A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        //공구 정보 삭제
        public static DataSet STD07A_UPD(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Decimal));
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtRslt = DTOL.TTOL_TOOLLIST.TTOL_TOOLLIST_SER3(UTIL.GetRowToDt(row), bizExecute);

                    //공구 LOT이 존재하면 삭제 불가
                    if (dtRslt.Rows.Count > 0)
                    {
                        throw UTIL.SetException("공구 LOT이 존재하여 삭제 불가합니다."
                            , row["TL_CODE"].ToString()
                            , new System.Diagnostics.StackFrame().GetMethod().Name
                            , BizException.CANNOT_DELETE);
                    }
                    else
                    {
                        DSTD.TSTD_TOOL.TSTD_TOOL_UDE(UTIL.GetRowToDt(row), bizExecute);
                    }
                }

                return STD07A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet STD07A_UPD2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Decimal));
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                        DTOL.TTOL_TOOLLIST.TTOL_TOOLLIST_UPD2(UTIL.GetRowToDt(row), bizExecute);
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet STD07A_UPD3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DTOL.TTOL_TOOLLIST.TTOL_TOOLLIST_UDE(UTIL.GetRowToDt(row), bizExecute);
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 공구 목록 조회
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet STD07A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSTD.TSTD_TOOL_QUERY.TSTD_TOOL_QUERY4(paramDS.Tables["RQSTDT"],  bizExecute);

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
        /// TL_CODE에 연관된 모든 목록 가져오기
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet STD07A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //1. 생성된 LOT 목록을 가져옴
                //
                DataTable dtRslt =  DTOL.TTOL_TOOLLIST_QUERY.TTOL_TOOLLIST_QUERY1(paramDS.Tables["RQSTDT"],  bizExecute);
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
        /// TL_CODE에 연관된 모든 목록 가져오기
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet STD07A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //1. 생성된 LOT 목록을 가져옴
                //
                DataTable dtRslt = DTOL.TTOL_TOOLLIST.TTOL_TOOLLIST_SER3(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable dtGive = DTOL.TTOL_GIVE_QUERY.TTOL_GIVE_QUERY2(dtRslt, bizExecute);
                dtGive.TableName = "DT_GIVE";

                DataTable dtReturn = DTOL.TTOL_RETURN.TTOL_RETURN_SER(dtGive, bizExecute);
                dtReturn.TableName = "DT_RETURN";

                DataTable dtDisuse = DTOL.TTOL_DISUSE.TTOL_DISUSE_SER(dtRslt, bizExecute);
                dtDisuse.TableName = "DT_DISUSE";

                paramDS.Tables.Add(dtGive);
                paramDS.Tables.Add(dtDisuse);
                paramDS.Tables.Add(dtReturn);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
    }
}
