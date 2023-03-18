using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BizExecute;

namespace BTOL
{
    public class TOL01A
    {
        //공구 묶음 지급
        public static DataSet TOL01A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //TSTD_TOOLLIST 에서 입고일순으로 정렬하여 빠른것 기준으로 입고 수량만큼 가져옴
                //TL_CODE를 기준으로 하여 GIVE_NO을 생성하고 GIVE_NO 하나당 GIVE_SEQ를 지급 수량만큼 1부터 증가시킴
                //↑(수정) 지급이라는 행위하나에 GIVE_NO 한번 지정
                
                string giveNo = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "TGV", bizExecute);
                int giveCnt = 1;
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtRslt = DTOL.TTOL_TOOLLIST.TTOL_TOOLLIST_SER2(UTIL.GetRowToDt(row), bizExecute);

                    //공구 지급시 묶음단위로 생성
                    row["GIVE_NO"] = giveNo;

                    if(dtRslt.Rows.Count < row["GIVE_QTY"].toInt32())
                    {
                        throw UTIL.SetException("이미처리되거나 유효하지 않는 데이터입니다. 새로고침합니다."
                           , new System.Diagnostics.StackFrame().GetMethod().Name
                           , BizException.UNVALID_DATA);
                    }

                    for (int i=1;i<=row["GIVE_QTY"].toInt32();i++)
                    {
                        //공구 묶음 단위 내에서 개별 지급시 생성
                        //row["GIVE_SEQ"] = i;

                        row["GIVE_SEQ"] = giveCnt++;
                        row["TL_LOT"] = dtRslt.Rows[i - 1]["TL_LOT"];
                        DTOL.TTOL_GIVE.TTOL_GIVE_INS(UTIL.GetRowToDt(row), bizExecute);
                        
                        DTOL.TTOL_TOOLLIST.TTOL_TOOLLIST_UPD(UTIL.GetRowToDt(row), bizExecute);
                    }

                    //20190902 지급시 현재고 수량 변화 X
                    //지급 완료 후 재고 변화
                    //DSTD.TSTD_TOOL.TSTD_TOOL_UPD3(UTIL.GetRowToDt(row), bizExecute);
                }

                return TOL01A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        //공구 LOT 정보 입력
        public static DataSet TOL01A_INS2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
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

        /// <summary>
        /// 공구 LOT 단위 지급
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet TOL01A_INS3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //선택한 LOT번호들만 지급
                // tl_code를 묶음으로 give_no 하나에 give_seq 순차 증가인지 ?
                // ↑give_no 하나에 give_seq 순차적으로 증가!(선택)
                //foreach (var codeRow in paramDS.Tables["RQSTDT"].AsEnumerable().GroupBy(g => new { PLT_CODE = g["PLT_CODE"], TL_CODE = g["TL_CODE"] })
                //                                       .Select(r => new { PLT_CODE = r.Key.PLT_CODE, TL_CODE = r.Key.TL_CODE, TLLIST = r.ToList<DataRow>() }))
                //{
                //string giveNo = UTIL.UTILITY_GET_SERIALNO(codeRow.PLT_CODE.ToString(), "TGV", bizExecute);
                string giveNo = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "TGV", bizExecute);
                int seq = 1;
                //foreach (DataRow row in codeRow.TLLIST)

                foreach (DataRow row in paramDS.Tables["RQSTDT"].AsEnumerable()
                                                                .OrderBy(o => o.Field<string>("TL_CODE"))
                                                                .ThenBy(t => t.Field<string>("YPGO_DATE")))
                {
                    //그룹단위 입력
                    row["GIVE_NO"] = giveNo;
                    //공구 묶음 단위 내에서 개별 지급시 생성
                    row["GIVE_SEQ"] = seq++;

                    DataTable dtRslt = DTOL.TTOL_TOOLLIST.TTOL_TOOLLIST_SER(UTIL.GetRowToDt(row), bizExecute);

                    if(dtRslt.Rows.Count == 0)
                    {
                        throw UTIL.SetException("이미처리되거나 유효하지 않는 데이터입니다. 새로고침합니다."
                           , new System.Diagnostics.StackFrame().GetMethod().Name
                           , BizException.UNVALID_DATA);
                    }

                    DTOL.TTOL_GIVE.TTOL_GIVE_INS(UTIL.GetRowToDt(row), bizExecute);

                    DTOL.TTOL_TOOLLIST.TTOL_TOOLLIST_UPD(UTIL.GetRowToDt(row), bizExecute);
                    //지급 완료 후 재고 변화
                    //20190902 지급시 현재고 수량 변화 X
                    //DSTD.TSTD_TOOL.TSTD_TOOL_UPD3(UTIL.GetRowToDt(row), bizExecute);
                }
                { }
                //}
                return TOL01A_SER2(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 지급 취소
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet TOL01A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
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
                    DTOL.TTOL_GIVE.TTOL_GIVE_DEL(UTIL.GetRowToDt(row), bizExecute);

                    DTOL.TTOL_TOOLLIST.TTOL_TOOLLIST_UPD(UTIL.GetRowToDt(row), bizExecute);

                    //재고 업데이트
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
        /// 공구 지급 정보 수정
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet TOL01A_UPD(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DTOL.TTOL_GIVE.TTOL_GIVE_UPD2(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable dtRslt = DTOL.TTOL_TOOLLIST_QUERY.TTOL_TOOLLIST_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
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
        public static DataSet TOL01A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSTD.TSTD_TOOL_QUERY.TSTD_TOOL_QUERY1(paramDS.Tables["RQSTDT"],  bizExecute);

                dtRslt.Columns.Add("SEL", typeof(string));
                dtRslt.TableName = "RSLTDT";

                UTIL.SetBizAddColumnToValue(dtRslt, "GIVE_QTY", "0");

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
        public static DataSet TOL01A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
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
        public static DataSet TOL01A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DTOL.TTOL_TOOLLIST_QUERY.TTOL_TOOLLIST_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
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
