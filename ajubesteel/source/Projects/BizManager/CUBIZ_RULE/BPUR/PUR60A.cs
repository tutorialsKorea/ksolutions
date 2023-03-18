using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BPUR
{
    public class PUR60A
    {
        public static DataSet PUR60A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = new DataTable("RSLTDT");

                if (paramDS.Tables["RQSTDT"].Rows.Count > 0)
                {
                    dtRslt = DSTD.TSTD_VENDOR_GRP.TSTD_VENDOR_GRP_SER(paramDS.Tables["RQSTDT"], bizExecute);
                }
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
        /// 특정 재고 그룹의 품목 리스트 조회
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet PUR60A_SER1(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataTable dtRslt = new DataTable("RSLTDT");

                if (paramDS.Tables["RQSTDT"].Rows.Count > 0)
                {
                    //if (paramDS.Tables["RQSTDT"].Rows[0]["VEN_GROUP"].ToString() == "")
                    //{
                    //    dtRslt = DLSE.LSE_STD_PART_QUERY.LSE_STD_PART_QUERY4(paramDS.Tables["RQSTDT"], bizExecute);
                    //    dtRslt.Columns.Add("USE_QTY", typeof(int));
                    //    dtRslt.Columns.Add("VEN_", typeof(int));
                    //    dtRslt.Columns.Add("VEN_SCOMMENT", typeof(string));
                    //}
                    //else
                        dtRslt = DSTD.TSTD_VENDOR_GRP.TSTD_VENDOR_GRP_SER1(paramDS.Tables["RQSTDT"], bizExecute);
                }
                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PUR60A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DSHP.TSHP_STOCK_LOG_QUERY.TSHP_STOCK_LOG_QUERY5(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt.TableName = "RSLTDT";

                DataTable dtRsltBal = DMAT.TMAT_BALJU_QUERY.TMAT_BALJU_QUERY17(paramDS.Tables["RQSTDT"], bizExecute);
                dtRsltBal.TableName = "RSLTDT_BAL";

                DataTable dtRsltOutBal = DOUT.TOUT_PROCBALJU_QUERY.TOUT_PROCBALJU_QUERY19(paramDS.Tables["RQSTDT"], bizExecute);
                dtRsltOutBal.TableName = "RSLTDT_OUTBAL";

                dtRsltBal.Merge(dtRsltOutBal);


                paramDS.Tables.Add(dtRslt);
                paramDS.Tables.Add(dtRsltBal);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }


        public static DataSet PUR60A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DSTD.TSTD_BOM_QUERY.TSTD_BOM_QUERY4(paramDS.Tables["RQSTDT"], bizExecute);

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

        public static DataSet PUR60A_SER4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DSTD.TSTD_VENDOR_GRP_QUERY.TSTD_VENDOR_GRP_QUERY_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt.TableName = "RSLTDT";

                DataTable dtRsltDetail = DSTD.TSTD_VENDOR_GRP_QUERY.TSTD_VENDOR_GRP_QUERY_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
                dtRsltDetail.TableName = "RSLTDT_DETAIL";

                paramDS.Tables.Add(dtRslt);
                paramDS.Tables.Add(dtRsltDetail);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static DataSet PUR60A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //1. TSTD_CODES SER 있으면 UPDATE, 없으면 INSERT
                //2. TSTD_STOCK_GRP 해당 데이터 삭제 후 INSERT

                DataTable dtMaster = paramDS.Tables["RQSTDT_M"];
                DataTable dtDetail = paramDS.Tables["RQSTDT_D"];

                string cat_code = "S090";
                string cd_code = "";

                dtMaster.Columns.Add("CAT_CODE", typeof(String));
                dtMaster.Columns.Add("CD_CODE", typeof(String));
                dtMaster.Columns.Add("VALUE", typeof(String));
                dtMaster.Columns.Add("CD_PARENT", typeof(String));
                dtMaster.Columns.Add("CD_SEQ", typeof(Int16));
                dtMaster.Columns.Add("IS_DEFAULT", typeof(Int32));

                UTIL.SetBizAddColumnToValue(dtMaster, "CD_NAME", "VEN_GROUP_NAME");
                dtMaster.Rows[0]["CAT_CODE"] = cat_code;
                dtMaster.Rows[0]["IS_DEFAULT"] = 0;

                if (dtMaster.Rows[0]["VEN_GROUP"].ToString() == "")
                {
                    cd_code = UTIL.UTILITY_GET_SERIALNO(dtMaster.Rows[0]["PLT_CODE"].ToString(), "VEN", UTIL.emSerialFormat.YYMM, "", bizExecute);

                    dtMaster.Rows[0]["CD_CODE"] = cd_code;

                    DSTD.TSTD_CODES.TSTD_CODES_INS(dtMaster, bizExecute);

                    foreach (DataRow dr in dtDetail.Rows)
                    {
                        dr["VEN_GROUP"] = cd_code;
                    }

                    dtMaster.Rows[0]["VEN_GROUP"] = cd_code;
                }
                else
                {
                    UTIL.SetBizAddColumnToValue(dtMaster, "CD_CODE", "VEN_GROUP");

                    DSTD.TSTD_CODES.TSTD_CODES_UPD(dtMaster, bizExecute);
                }

                foreach (DataRow drD in dtDetail.Rows)
                {
                    if (drD["FLAG"].ToString() == "I")
                    {
                        DSTD.TSTD_VENDOR_GRP.TSTD_VENDOR_GRP_INS(UTIL.GetRowToDt(drD), bizExecute);

                        //세부 파트 입력
                    }
                    else if (drD["FLAG"].ToString() == "D")
                    {
                        DSTD.TSTD_VENDOR_GRP.TSTD_VENDOR_GRP_DEL(UTIL.GetRowToDt(drD), bizExecute);

                        //세부파트 삭제
                    }
                    else if (drD["FLAG"].ToString() == "U")
                        DSTD.TSTD_VENDOR_GRP.TSTD_VENDOR_GRP_UPD(UTIL.GetRowToDt(drD), bizExecute);
                }


                DataTable dtRslt = DSTD.TSTD_VENDOR_GRP.TSTD_VENDOR_GRP_SER1(paramDS.Tables["RQSTDT_M"], bizExecute);
                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PUR60A_INS2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dataCheck = DSTD.TSTD_VENDOR_GRP_DETAIL.TSTD_VENDOR_GRP_DETAIL_SER1(UTIL.GetRowToDt(row), bizExecute);

                    if (dataCheck.Rows.Count > 0)
                    {
                        DSTD.TSTD_VENDOR_GRP_DETAIL.TSTD_VENDOR_GRP_DETAIL_UPD(UTIL.GetRowToDt(row), bizExecute);
                    }
                    else
                    {
                        DSTD.TSTD_VENDOR_GRP_DETAIL.TSTD_VENDOR_GRP_DETAIL_INS(UTIL.GetRowToDt(row), bizExecute);
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
        /// 재고 그룹 삭제
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet PUR60A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (paramDS.Tables["RQSTDT"].Rows.Count > 0)
                {
                    paramDS.Tables["RQSTDT"].Columns.Add("CAT_CODE", typeof(String));
                    paramDS.Tables["RQSTDT"].Columns.Add("CD_CODE", typeof(String));

                    paramDS.Tables["RQSTDT"].Rows[0]["CAT_CODE"] = "S090";
                    paramDS.Tables["RQSTDT"].Rows[0]["CD_CODE"] = paramDS.Tables["RQSTDT"].Rows[0]["VEN_GROUP"].ToString();

                    //STK_GROUP
                    DSTD.TSTD_CODES.TSTD_CODES_UDE(paramDS.Tables["RQSTDT"], bizExecute);

                    return paramDS;
                }

                return null;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
    }
}
