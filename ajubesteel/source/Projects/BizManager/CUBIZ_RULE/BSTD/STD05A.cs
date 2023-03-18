using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BSTD
{
    public class STD05A
    {
        /// <summary>
        /// 거래처 조회
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet STD05A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                DataTable dtRslt = DSTD.TSTD_VENDOR_QUERY.TSTD_VENDOR_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

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
        /// 거래처 담당자 조회
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet STD05A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                
                DataTable dtRslt = DSTD.TSTD_VENDOR_CHARGE_QUERY.TSTD_VENDOR_CHARGE_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.Columns.Add("SEL", typeof(string));
                dtRslt.TableName = "RSLTDT";

                //DataTable dtRslt_Item = DORD.TORD_PRODUCT_QUERY.TORD_PRODUCT_QUERY12(paramDS.Tables["RQSTDT"], bizExecute);

                //dtRslt_Item.Columns.Add("SEL", typeof(string));
                //dtRslt_Item.TableName = "RSLTDT_ITEM";


                //DataTable dtRslt_As = DORD.TORD_PRODUCT_AS_QUERY.TORD_PRODUCT_AS_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                //dtRslt_As.TableName = "RSLTDT_AS";

                paramDS.Tables.Add(dtRslt);
                //paramDS.Tables.Add(dtRslt_Item);
                //paramDS.Tables.Add(dtRslt_As);


                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static DataSet STD05A_SER4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                
                DataTable dtRslt = DSTD.TSTD_VENDOR_CHARGE.TSTD_VENDOR_CHARGE_SER(paramDS.Tables["RQSTDT"], bizExecute);

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


        public static DataSet STD05A_SER5(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DSTD.TSTD_VENDOR.TSTD_VENDOR_SER2(paramDS.Tables["RQSTDT"], bizExecute);

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
        /// 거래처 삭제
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet STD05A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DSTD.TSTD_VENDOR.TSTD_VENDOR_UDE(paramDS.Tables["RQSTDT"], bizExecute);
                return paramDS;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        /// <summary>
        /// 거래처 담당자 삭제
        /// </summary>
        /// <param name="paramDS">VEN_CHARGE_ID</param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet STD05A_DEL2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DSTD.TSTD_VENDOR_CHARGE.TSTD_VENDOR_CHARGE_DEL(paramDS.Tables["RQSTDT"], bizExecute);

                return paramDS;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        /// <summary>
        /// 거래처 추가
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet STD05A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "MDFY_EMP", 0, typeof(String));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    if (String.IsNullOrEmpty(row["VEN_CODE"].ToString()))
                    {
                        row["VEN_CODE"] = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "C-", "", "", bizExecute);

                        foreach(DataRow dr in paramDS.Tables["RQSTDT_CHARGE"].Select("VEN_CODE IS NULL"))
                        {
                            dr["VEN_CODE"] = row["VEN_CODE"];
                        }
                    }

                    DataTable dtRslt_Var = DSTD.TSTD_VENDOR_QUERY.TSTD_VENDOR_QUERY3(UTIL.GetRowToDt(row), bizExecute);
                    if (dtRslt_Var.Rows.Count == 1 && row["IS_MYVENDOR"].ToString() == "1"
                        && dtRslt_Var.Rows[0]["VEN_CODE"].ToString() != row["VEN_CODE"].ToString())
                    {
                        throw UTIL.SetException("내회사정보가 하나이상이면 저장할수없습니다."
                                        , row["VEN_CODE"].ToString()
                                        , new System.Diagnostics.StackFrame().GetMethod().Name
                                        , 200101);
                    }


                    
                    DataTable dtRslt = DSTD.TSTD_VENDOR.TSTD_VENDOR_SER(UTIL.GetRowToDt(row), bizExecute);
                  
                    //데이터가 있으면 삭제여부 및 덮어쓰기 여부에 따라 update
                    if (dtRslt.Rows.Count > 0)
                    {
                      
                        if (row["OVERWRITE"].Equals("1"))
                        {
                            DSTD.TSTD_VENDOR.TSTD_VENDOR_UPD(UTIL.GetRowToDt(row), bizExecute);
                        }
                        else
                        {
                            if (dtRslt.Rows[0]["DATA_FLAG"].Equals((byte)2))
                            {

                                throw UTIL.SetException("동일 데이터가 이력이 존재할때 발생"
                                    , row["VEN_CODE"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.OVERWRITE_HISTORY, dtRslt.Rows[0]);

                            }
                            else
                            {
                                throw UTIL.SetException("동일 데이터가 존재할때 발생"
                                    , row["VEN_CODE"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.OVERWRITE);
                            }
                        }
                    }
                    else
                    {

                        DSTD.TSTD_VENDOR.TSTD_VENDOR_INS(UTIL.GetRowToDt(row), bizExecute);
                    }

                }

                if(paramDS.Tables.Contains("RQSTDT_CHARGE_DEL"))
                {
                    DSTD.TSTD_VENDOR_CHARGE.TSTD_VENDOR_CHARGE_DEL(paramDS.Tables["RQSTDT_CHARGE_DEL"],bizExecute);
                }


                foreach (DataRow row in paramDS.Tables["RQSTDT_CHARGE"].Rows)
                {
                    if (row["VEN_CHARGE_ID"].ToString() != "" )
                        DSTD.TSTD_VENDOR_CHARGE.TSTD_VENDOR_CHARGE_UPD(UTIL.GetRowToDt(row), bizExecute);
                    else
                        DSTD.TSTD_VENDOR_CHARGE.TSTD_VENDOR_CHARGE_INS(UTIL.GetRowToDt(row), bizExecute);
                }

                return STD05A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }


       
    }
}
