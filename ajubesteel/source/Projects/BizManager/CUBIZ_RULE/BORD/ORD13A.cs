using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BORD
{
    public class ORD13A
    {
        public static DataSet ORD13A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DORD.TORD_PRODUCT.TORD_PRODUCT_SER(paramDS.Tables["RQSTDT"], bizExecute);

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


        public static DataSet ORD13A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DORD.TORD_PRODUCT_QUERY.TORD_PRODUCT_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

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


        public static DataSet ORD13A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataTable dtRslt_bom = DMAT.TMAT_PARTLIST_QUERY.TMAT_PARTLIST_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt_bom.Columns.Add("SEL");
                dtRslt_bom.Columns.Add("CHK_FLAG");
                dtRslt_bom.TableName = "RSLTDT_BOM";

                paramDS.Tables.Add(dtRslt_bom);

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DORD.TORD_PRODUCT_REV_QUERY.TORD_PRODUCT_REV_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.Columns.Add("SEL");
                dtRslt.TableName = "RSLTDT";
                
                //if(dtRslt.Rows.Count > 0)
                //{

                    DataTable dtRslt_prod = DORD.TORD_PRODUCT_REV_QUERY.TORD_PRODUCT_REV_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

                    UTIL.SetBizAddColumnToValue(dtRslt_prod, "REV_NO", 0, typeof(int));

                int revNo = Convert.ToInt32(dtRslt.AsEnumerable().Max(row => row["REV_NO"]));

                if (revNo >= 0 && dtRslt.Rows.Count > 0)
                {
                    revNo++;
                }

                    dtRslt_prod.Rows[0]["REV_NO"] = revNo;

                    dtRslt.Merge(dtRslt_prod);
                //}
                


                paramDS.Tables.Add(dtRslt);

                return paramDS;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }




        public static DataSet ORD13A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte), true);

                // 수주정보 조회
                DataTable dtRslt = DORD.TORD_PRODUCT.TORD_PRODUCT_SER(paramDS.Tables["RQSTDT"], bizExecute);

                UTIL.SetBizAddColumnToValue(dtRslt, "REV_ID", typeof(string));
                UTIL.SetBizAddColumnToValue(dtRslt, "REV_NO", typeof(int));
                UTIL.SetBizAddColumnToValue(dtRslt, "GUBUN", 0, typeof(int));


                // 리비전 생성 여부 조회
                DataTable dtRsltRev = DORD.TORD_PRODUCT_REV.TORD_PRODUCT_REV_SER(paramDS.Tables["RQSTDT"], bizExecute);
               
                if (dtRsltRev.Rows.Count > 0)
                {  
                    DataTable dtRevMax = DORD.TORD_PRODUCT_REV.TORD_PRODUCT_REV_SER2(paramDS.Tables["RQSTDT"], bizExecute);
                    
                    if(dtRevMax.Rows.Count > 0)
                    {
                        string rev_id = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "REV", UTIL.emSerialFormat.YYYYMMDD, "", bizExecute);
                        rev_id = rev_id.Insert(11, "0"); 
                        foreach (DataRow dr in dtRslt.Rows)
                        {
                            dr["REV_ID"] = rev_id;
                            dr["REV_NO"] = dtRevMax.Rows[0]["REV_MAX"].toInt() + 1;
                            dr["REV_EMP"] = ConnInfo.UserID;
                           
                        }
                       
                        DORD.TORD_PRODUCT_REV.TORD_PRODUCT_REV_INS(dtRslt, bizExecute);
                    }
                  
                }
                else
                {
                    // 수주에 대한 리비전 정보가 없으면 신규 생성
                    if(dtRslt.Rows.Count > 0)
                    {
                        string rev_id = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "REV", UTIL.emSerialFormat.YYYYMMDD, "", bizExecute);
                        rev_id = rev_id.Insert(11, "0");

                        foreach(DataRow dr in dtRslt.Rows)
                        {
                            dr["REV_ID"] = rev_id;
                            dr["REV_NO"] = 0;
                        }

                        DORD.TORD_PRODUCT_REV.TORD_PRODUCT_REV_INS(dtRslt, bizExecute);
                    }
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
