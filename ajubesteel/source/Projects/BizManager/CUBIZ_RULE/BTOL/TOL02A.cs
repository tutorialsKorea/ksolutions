using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BizExecute;

namespace BTOL
{
    public class TOL02A
    {
        //공구 묶음 지급
        public static DataSet TOL02A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //TTOL_GIVE 에서 지급일순으로 정렬하여 느린것(최근것) 기준으로 입고 수량만큼 가져옴
                //반납이라는 행위하나에 GIVE_NO 한번 지정
                
                string rtnNo = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "TRV", bizExecute);
                int rtnCnt = 1;
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    //해당하는 지급 내역을 가져온다
                    DataTable dtRslt = DTOL.TTOL_TOOLLIST_QUERY.TTOL_TOOLLIST_QUERY2(UTIL.GetRowToDt(row), bizExecute);
                    dtRslt.DefaultView.Sort = "GIVE_DATE";
                    //공구 반납시 묶음단위로 생성
                    row["RTN_NO"] = rtnNo;

                    if (dtRslt.Rows.Count < row["ADD_QTY"].toInt32())
                    {
                        throw UTIL.SetException("이미처리되거나 유효하지 않는 데이터입니다. 새로고침합니다."
                           , new System.Diagnostics.StackFrame().GetMethod().Name
                           , BizException.UNVALID_DATA);
                    }

                    for (int i=0;i<row["ADD_QTY"].toInt32();i++)
                    {
                        row["RTN_SEQ"] = rtnCnt++;
                        row["GIVE_NO"] = dtRslt.Rows[i]["GIVE_NO"];
                        row["GIVE_SEQ"] = dtRslt.Rows[i]["GIVE_SEQ"];
                        row["TL_LOT"] = dtRslt.Rows[i]["TL_LOT"];

                        //반납 내역 입력
                        DTOL.TTOL_RETURN.TTOL_RETURN_INS(UTIL.GetRowToDt(row), bizExecute);
                        
                        //TTOL_TOOLLIST 상태 업데이트
                        DTOL.TTOL_TOOLLIST.TTOL_TOOLLIST_UPD(UTIL.GetRowToDt(row), bizExecute);

                        //TTOL_GIVE 상태 업데이트
                        DTOL.TTOL_GIVE.TTOL_GIVE_UPD(UTIL.GetRowToDt(row), bizExecute);
                    }

                    //반납 완료 후 재고 변화
                    //20190902 지급시 현재고 수량 변화 X
                    //DSTD.TSTD_TOOL.TSTD_TOOL_UPD2(UTIL.GetRowToDt(row), bizExecute);
                }

                return paramDS;
                //return TOL02A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 공구 LOT 단위 반납
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet TOL02A_INS2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //선택한 LOT번호들만 반납
                
                string rtnNo = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "TRV", bizExecute);
                int seq = 1;
                foreach (DataRow row in paramDS.Tables["RQSTDT"].AsEnumerable()
                                                                .OrderBy(o => o.Field<string>("TL_CODE"))
                                                                .ThenByDescending(t => t.Field<string>("GIVE_DATE")))
                {
                    //그룹단위 입력
                    row["RTN_NO"] = rtnNo;
                    //공구 묶음 단위 내에서 개별 지급시 생성
                    row["RTN_SEQ"] = seq++;
                    //반납 내역 입력
                    DTOL.TTOL_RETURN.TTOL_RETURN_INS(UTIL.GetRowToDt(row), bizExecute);

                    //TTOL_TOOLLIST 상태 업데이트
                    DTOL.TTOL_TOOLLIST.TTOL_TOOLLIST_UPD(UTIL.GetRowToDt(row), bizExecute);

                    //TTOL_GIVE 상태 업데이트
                    DTOL.TTOL_GIVE.TTOL_GIVE_UPD(UTIL.GetRowToDt(row), bizExecute);

                    //반납 후 재고 수량 변화
                    //20190902 지급시 현재고 수량 변화 X
                    //DSTD.TSTD_TOOL.TSTD_TOOL_UPD2(UTIL.GetRowToDt(row), bizExecute);
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 반납 취소
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet TOL02A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            ///지급 취소의 경우 완전삭제
            ///지급 테이블에서 데이터 삭제
            ///공구 lot에서 상태 변경
            try
            {
                //지급을 삭제 시 재고가 다시 증가 하므로 공구 LOT당 재고를 1씩 올려준다.
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "ADD_QTY", 1, typeof(String));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    //삭제
                    DTOL.TTOL_RETURN.TTOL_RETURN_DEL(UTIL.GetRowToDt(row), bizExecute);

                    //지급상태로 변경
                    DTOL.TTOL_GIVE.TTOL_GIVE_UPD(UTIL.GetRowToDt(row), bizExecute);

                    //공구 지급으로 상태변경
                    DTOL.TTOL_TOOLLIST.TTOL_TOOLLIST_UPD(UTIL.GetRowToDt(row), bizExecute);

                    //재고 업데이트 : 감소
                    //20190902 지급시 현재고 수량 변화 X
                    //DSTD.TSTD_TOOL.TSTD_TOOL_UPD3(UTIL.GetRowToDt(row), bizExecute);
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
        public static DataSet TOL02A_UPD(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DTOL.TTOL_RETURN.TTOL_RETURN_UPD(paramDS.Tables["RQSTDT"], bizExecute);

                return TOL02A_SER3(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 공구 지급 목록 조회
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet TOL02A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSTD.TSTD_TOOL_QUERY.TSTD_TOOL_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.Columns.Add("SEL", typeof(string));
                dtRslt.TableName = "RSLTDT";

                //반납 수량
                //UTIL.SetBizAddColumnToValue(dtRslt, "RTN_QTY", 0, typeof(decimal));

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        /// <summary>
        /// 공구 지급 LOT 목록 조회
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet TOL02A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt =  DTOL.TTOL_TOOLLIST_QUERY.TTOL_TOOLLIST_QUERY2(paramDS.Tables["RQSTDT"],  bizExecute);
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
        public static DataSet TOL02A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DTOL.TTOL_GIVE_QUERY.TTOL_GIVE_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
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
