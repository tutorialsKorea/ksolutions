using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BizExecute;

namespace BTOL
{
    public class TOL03A
    {
        //공구 묶음 지급
        public static DataSet TOL03A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //TSTD_TOOLLIST 에서 입고일순으로 정렬하여 빠른것 기준으로 입고 수량만큼 가져옴
                //폐기이라는 행위하나에 TDU_NO 한번 지정
                
                string tduNo = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "TDV", bizExecute);
                int tduCnt = 1;
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtRslt = DTOL.TTOL_TOOLLIST.TTOL_TOOLLIST_SER2(UTIL.GetRowToDt(row), bizExecute);

                    //공구 폐기시 묶음단위로 생성
                    row["TDU_NO"] = tduNo;

                    if (dtRslt.Rows.Count < row["GIVE_QTY"].toInt32())
                    {
                        throw UTIL.SetException("이미처리되거나 유효하지 않는 데이터입니다. 새로고침합니다."
                           , new System.Diagnostics.StackFrame().GetMethod().Name
                           , BizException.UNVALID_DATA);
                    }

                    for (int i=1;i<=row["GIVE_QTY"].toInt32();i++)
                    {
                        row["TDU_SEQ"] = tduCnt++;
                        row["TL_LOT"] = dtRslt.Rows[i - 1]["TL_LOT"];
                        DTOL.TTOL_DISUSE.TTOL_DISUSE_INS(UTIL.GetRowToDt(row), bizExecute);
                        
                        DTOL.TTOL_TOOLLIST.TTOL_TOOLLIST_UPD(UTIL.GetRowToDt(row), bizExecute);
                    }

                    //폐기 완료 후 재고 변화
                    DSTD.TSTD_TOOL.TSTD_TOOL_UPD4(UTIL.GetRowToDt(row), bizExecute);
                }

                //return TOL03A_SER(paramDS, bizExecute);
                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        /// <summary>
        /// 공구 LOT 단위 폐기
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet TOL03A_INS2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                string tduNo = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "TDV", bizExecute);
                int seq = 1;
                foreach (DataRow row in paramDS.Tables["RQSTDT"].AsEnumerable()
                                                                .OrderBy(o=>o.Field<string>("TL_CODE"))
                                                                .ThenBy(t=>t.Field<string>("YPGO_DATE")))
                {
                        //그룹단위 입력
                        row["TDU_NO"] = tduNo;
                        //공구 묶음 단위 내에서 개별 폐기시 생성
                        row["TDU_SEQ"] = seq++;
                        DTOL.TTOL_DISUSE.TTOL_DISUSE_INS(UTIL.GetRowToDt(row), bizExecute);

                        DTOL.TTOL_TOOLLIST.TTOL_TOOLLIST_UPD(UTIL.GetRowToDt(row), bizExecute);
                    //폐기 완료 후 재고 변화
                    DSTD.TSTD_TOOL.TSTD_TOOL_UPD4(UTIL.GetRowToDt(row), bizExecute);
                }
                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 공구 LOT 단위 폐기(지급대상)
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet TOL03A_INS3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                string tduNo = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "TDV", bizExecute);
                int seq = 1;
                foreach (DataRow row in paramDS.Tables["RQSTDT"].AsEnumerable()
                                                                .OrderBy(o => o.Field<string>("TL_CODE"))
                                                                .ThenBy(t => t.Field<string>("YPGO_DATE")))
                {
                    //그룹단위 입력
                    row["TDU_NO"] = tduNo;
                    //공구 묶음 단위 내에서 개별 폐기시 생성
                    row["TDU_SEQ"] = seq++;
                    DTOL.TTOL_DISUSE.TTOL_DISUSE_INS(UTIL.GetRowToDt(row), bizExecute);

                    DTOL.TTOL_TOOLLIST.TTOL_TOOLLIST_UPD(UTIL.GetRowToDt(row), bizExecute);
                    //폐기 완료 후 재고 변화
                    DSTD.TSTD_TOOL.TSTD_TOOL_UPD4(UTIL.GetRowToDt(row), bizExecute);

                    DTOL.TTOL_GIVE.TTOL_GIVE_UPD(UTIL.GetRowToDt(row), bizExecute);
                }
                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        /// <summary>
        /// 폐기 취소
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet TOL03A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            ///폐기 취소의 경우 완전삭제
            ///폐기 테이블에서 데이터 삭제
            ///공구 lot에서 상태 변경
            try
            {

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    //삭제
                    DTOL.TTOL_DISUSE.TTOL_DISUSE_DEL(UTIL.GetRowToDt(row), bizExecute);

                    DTOL.TTOL_TOOLLIST.TTOL_TOOLLIST_UPD(UTIL.GetRowToDt(row), bizExecute);

                    //재고 업데이트
                    DSTD.TSTD_TOOL.TSTD_TOOL_UPD5(UTIL.GetRowToDt(row), bizExecute);
                }


                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 공구 지급 정보 수정
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet TOL03A_UPD(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DTOL.TTOL_DISUSE.TTOL_DISUSE_UPD(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable dtRslt = DTOL.TTOL_DISUSE_QUERY.TTOL_DISUSE_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
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
        /// 공구 목록 조회
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet TOL03A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSTD.TSTD_TOOL_QUERY.TSTD_TOOL_QUERY1(paramDS.Tables["RQSTDT"],  bizExecute);

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
        /// 공구 LOT 목록 조회
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet TOL03A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
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
        /// 지급 공구
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet TOL03A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DTOL.TTOL_DISUSE_QUERY.TTOL_DISUSE_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
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
