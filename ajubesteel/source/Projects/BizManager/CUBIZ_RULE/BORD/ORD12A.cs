using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BORD
{
    public class ORD12A
    {
        public static DataSet ORD12A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "IS_NOT_SHIP", "1", typeof(string));

                //DataTable dtRslt = DORD.TORD_PRODUCT_QUERY.TORD_PRODUCT_QUERY13(paramDS.Tables["RQSTDT"], bizExecute);
                DataTable dtRslt = DMAT.TMAT_PARTLIST_QUERY.TMAT_PARTLIST_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

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

        //public static DataSet ORD12A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        //{
        //    try
        //    {
        //        UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

        //        UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WO_TYPE", "CAM", typeof(string));

        //        DataTable dtRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY9(paramDS.Tables["RQSTDT"], bizExecute);

        //        dtRslt.Columns.Add("SEL", typeof(string));
        //        dtRslt.TableName = "RSLTDT";

        //        paramDS.Tables.Add(dtRslt);

        //        return paramDS;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
        //    }
        //}


        /// <summary>
        ///   
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet ORD12A_UPD(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "OS_ORD_EMP", ConnInfo.UserID, typeof(string), true);
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "OS_ORD_DATE", DateTime.Now.ToString("yyyyMMdd"), typeof(string), true);

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtPartList = DMAT.TMAT_PARTLIST_QUERY.TMAT_PARTLIST_QUERY2(UTIL.GetRowToDt(row), bizExecute);

                    UTIL.SetBizAddColumnToValue(dtPartList, "OS_ORD_EMP", row["OS_ORD_EMP"].ToString(), typeof(string), true);
                    UTIL.SetBizAddColumnToValue(dtPartList, "OS_ORD_DATE", row["OS_ORD_DATE"].ToString(), typeof(string), true);

                    if (dtPartList.Rows.Count > 0)
                    {
                        //외주공정 프로세스
                        BPLN.PLN02A.SetOsWorkOrderCreate(dtPartList.Rows[0], "1", bizExecute);
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
