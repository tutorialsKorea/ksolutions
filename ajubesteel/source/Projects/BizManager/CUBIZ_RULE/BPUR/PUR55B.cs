using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BPUR
{
    public class PUR55B
    {
        /// <summary>
        /// 재고 그룹 리스트 조회
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet PUR55B_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataTable dtRslt = new DataTable("RSLTDT");

                if (paramDS.Tables["RQSTDT"].Rows.Count > 0)
                {
                    dtRslt = DSTD.TSTD_STOCK_GRP.TSTD_STOCK_GRP_SER(paramDS.Tables["RQSTDT"], bizExecute);
                    
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
        public static DataSet PUR55B_SER1(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataTable dtRslt = new DataTable("RSLTDT");

                if (paramDS.Tables["RQSTDT"].Rows.Count > 0)
                {
                    if (paramDS.Tables["RQSTDT"].Rows[0]["STK_GROUP"].ToString() == "")
                    {
                        dtRslt = DLSE.LSE_STD_PART_QUERY.LSE_STD_PART_QUERY4(paramDS.Tables["RQSTDT"], bizExecute);
                        dtRslt.Columns.Add("USE_QTY", typeof(int));
                        dtRslt.Columns.Add("STK_", typeof(int));
                        dtRslt.Columns.Add("STK_SCOMMENT", typeof(string));
                    }
                    else
                        dtRslt = DSTD.TSTD_STOCK_GRP.TSTD_STOCK_GRP_SER1(paramDS.Tables["RQSTDT"], bizExecute);
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
        /// 재고 그룹 리스트 저장
        /// RQSTDT_M, PLT_CODE, STK_GROUP, STK_GROUP_NAME, SCOMMENT, REG_EMP
        /// RQSTDT_D, PLT_CODE, STK_GROUP, PART_CODE 
        /// STK_GRP_NAME : TSTD_CODES.CAT_CODE = 'S089', CD_CODE
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet PUR55B_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //1. TSTD_CODES SER 있으면 UPDATE, 없으면 INSERT
                //2. TSTD_STOCK_GRP 해당 데이터 삭제 후 INSERT

                DataTable dtMaster = paramDS.Tables["RQSTDT_M"];
                DataTable dtDetail = paramDS.Tables["RQSTDT_D"];

                string cat_code = "S089";
                string cd_code = "";

                dtMaster.Columns.Add("CAT_CODE", typeof(String));
                dtMaster.Columns.Add("CD_CODE", typeof(String));
                dtMaster.Columns.Add("VALUE", typeof(String));
                dtMaster.Columns.Add("CD_PARENT", typeof(String));
                dtMaster.Columns.Add("CD_SEQ", typeof(Int16));
                dtMaster.Columns.Add("IS_DEFAULT", typeof(Int32));

                UTIL.SetBizAddColumnToValue(dtMaster, "CD_NAME", "STK_GROUP_NAME");
                dtMaster.Rows[0]["CAT_CODE"] = cat_code;
                dtMaster.Rows[0]["IS_DEFAULT"] = 0;

                if (dtMaster.Rows[0]["STK_GROUP"].ToString() == "")
                {
                    cd_code = UTIL.UTILITY_GET_SERIALNO(dtMaster.Rows[0]["PLT_CODE"].ToString(), "STK", UTIL.emSerialFormat.YYMM, "", bizExecute);
                    
                    dtMaster.Rows[0]["CD_CODE"] = cd_code;
                    
                    DSTD.TSTD_CODES.TSTD_CODES_INS(dtMaster, bizExecute);

                    foreach (DataRow dr in dtDetail.Rows)
                    {
                        dr["STK_GROUP"] = cd_code;
                    }

                    dtMaster.Rows[0]["STK_GROUP"] = cd_code;
                }
                else
                {
                    UTIL.SetBizAddColumnToValue(dtMaster, "CD_CODE", "STK_GROUP");
                    
                    DSTD.TSTD_CODES.TSTD_CODES_UPD(dtMaster, bizExecute);
                }
              
                foreach (DataRow drD in dtDetail.Rows)
                {
                    if (drD["FLAG"].ToString() == "I")
                        DSTD.TSTD_STOCK_GRP.TSTD_STOCK_GRP_INS(UTIL.GetRowToDt(drD), bizExecute);
                    else if(drD["FLAG"].ToString() == "D")
                        DSTD.TSTD_STOCK_GRP.TSTD_STOCK_GRP_DEL(UTIL.GetRowToDt(drD), bizExecute);
                    else if(drD["FLAG"].ToString() == "U")
                        DSTD.TSTD_STOCK_GRP.TSTD_STOCK_GRP_UPD(UTIL.GetRowToDt(drD), bizExecute);
                }
               

                DataTable dtRslt = DSTD.TSTD_STOCK_GRP.TSTD_STOCK_GRP_SER1(paramDS.Tables["RQSTDT_M"], bizExecute);
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
        /// 재고 그룹 복사
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet PUR55B_INS2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //ORI_GRP, TARGET_GRP
                //
                
//INSERT INTO TSTD_STOCK_GRP
//SELECT PLT_CODE, @TARGET_GRP, PART_CODE, @SCOMMENT, @REG_DATE, @REG_EMP, NULL, NULL
//FROM TSTD_STOCK_GRP
//WHERE PLT_CODE = ''
//AND STK_GRP_NAME = ''
                DataTable dtRslt = DSTD.TSTD_STOCK_GRP.TSTD_STOCK_GRP_SER1(paramDS.Tables["RQSTDT"], bizExecute);
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
        /// 재고 그룹 삭제
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet PUR55B_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (paramDS.Tables["RQSTDT"].Rows.Count > 0)
                {
                    paramDS.Tables["RQSTDT"].Columns.Add("CAT_CODE", typeof(String));
                    paramDS.Tables["RQSTDT"].Columns.Add("CD_CODE", typeof(String));

                    paramDS.Tables["RQSTDT"].Rows[0]["CAT_CODE"] = "S089";
                    paramDS.Tables["RQSTDT"].Rows[0]["CD_CODE"] = paramDS.Tables["RQSTDT"].Rows[0]["STK_GROUP"].ToString();
                    
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
