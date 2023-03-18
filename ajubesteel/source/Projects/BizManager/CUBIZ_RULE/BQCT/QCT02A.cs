using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BQCT
{
    public class QCT02A
    {
        public static DataSet QCT02A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DORD.TORD_PRODUCT_QUERY.TORD_PRODUCT_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                //DataTable dtRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY13(paramDS.Tables["RQSTDT"], bizExecute);

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

        public static DataSet QCT02A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSHP.TSHP_INSPECTION_RESULT_QUERY.TSHP_INSPECTION_RESULT_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

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
        /// 검사 결과 등록
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet QCT02A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte), true);


                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {

                    DataTable dtRslt = DSHP.TSHP_INSPECTION_RESULT.TSHP_INSPECTION_RESULT_SER(UTIL.GetRowToDt(row), bizExecute);

                    //데이터가 있을경우
                    if (dtRslt.Rows.Count > 0)
                    {
                        //데이터 삭제여부
                        if (row["DATA_FLAG"].Equals("2"))
                        {
                            //덮어쓰기 여부
                            if (row["OVERWRITE"].Equals("1"))
                            {
                                DORD.TORD_ITEM.TORD_ITEM_UPD(UTIL.GetRowToDt(row), bizExecute);
                            }

                            else
                            {
                                throw UTIL.SetException("동일 이력 데이터가 존재합니다."
                                   , new System.Diagnostics.StackFrame().GetMethod().Name);
                            }
                        }

                        //덮어쓰기 여부
                        else
                        {

                            if (row["OVERWRITE"].Equals("1"))
                            {

                                DSHP.TSHP_INSPECTION_RESULT.TSHP_INSPECTION_RESULT_UPD(UTIL.GetRowToDt(row), bizExecute);
                            }
                            else
                            {
                                throw UTIL.SetException("동일 데이터가 존재합니다."
                                  , new System.Diagnostics.StackFrame().GetMethod().Name);
                            }
                        }
                    }
                    else
                    {
                        if (row["INS_NO"].ToString() == string.Empty)
                        {
                            string ins_no = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "INS", UTIL.emSerialFormat.YYMMDD, "-", bizExecute);

                            row["INS_NO"] = ins_no;
                        }

                        DSHP.TSHP_INSPECTION_RESULT.TSHP_INSPECTION_RESULT_INS(UTIL.GetRowToDt(row), bizExecute);

                    }

                }

                if(paramDS.Tables.Contains("RQSTDT_DEL"))
                {
                    foreach (DataRow row in paramDS.Tables["RQSTDT_DEL"].Rows)
                    {
                        DSHP.TSHP_INSPECTION_RESULT.TSHP_INSPECTION_RESULT_UDE(UTIL.GetRowToDt(row), bizExecute);
                    }

                }


                return QCT02A_SER2(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        /// <summary>
        /// 검사결과 삭제
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet QCT02A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 2, typeof(Byte));


                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {

                    DSHP.TSHP_INSPECTION_RESULT.TSHP_INSPECTION_RESULT_UDE(UTIL.GetRowToDt(row), bizExecute);

                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
    }
}
