using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BizExecute;

namespace BORD
{
    public class ORD06A
    {
        /// <summary>
        /// 수주 등록
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet ORD06A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP1", "", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP2", "", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP3", "", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP4", "", typeof(string));

                DataTable dtAppRqst = new DataTable("RQSTDT");
                dtAppRqst.Columns.Add("PLT_CODE", typeof(string));
                dtAppRqst.Columns.Add("APP_TYPE", typeof(string));
                dtAppRqst.Columns.Add("ORG_CODE", typeof(string));

                DataRow appRow = dtAppRqst.NewRow();
                appRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                appRow["APP_TYPE"] = "AS";
                appRow["ORG_CODE"] = paramDS.Tables["RQSTDT"].Rows[0]["APP_ORG"];

                dtAppRqst.Rows.Add(appRow);

                DataTable dtAppRslt = DSTD.TSTD_APP_EMP.TSTD_APP_EMP_SER3(dtAppRqst, bizExecute);

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {

                    DataTable dtRslt = DORD.TORD_PRODUCT_AS.TORD_PRODUCT_AS_SER(UTIL.GetRowToDt(row), bizExecute);

                    //데이터가 있을경우
                    if (dtRslt.Rows.Count > 0)
                    {
                    
                        if (row["OVERWRITE"].Equals("1"))
                        {

                            if ((dtRslt.Rows[0]["APP_ORG"].ToString() != "") 
                                && (dtRslt.Rows[0]["APP_STATUS"].ToString() != "0")
                                && (row["APP_ORG"].ToString() != dtRslt.Rows[0]["APP_ORG"].ToString()))
                            {
                                    
                                throw UTIL.SetException("승인이 진행 중이어서 승인자 그룹을 변경 불가"
                                , new System.Diagnostics.StackFrame().GetMethod().Name
                                , 9996);
                            }
                            else
                            {
                                if (dtAppRslt.Rows.Count > 0)
                                {
                                    row["APP_EMP1"] = dtAppRslt.Rows[0]["APP_EMP1"].ToString();
                                    row["APP_EMP2"] = dtAppRslt.Rows[0]["APP_EMP2"].ToString();
                                    row["APP_EMP3"] = dtAppRslt.Rows[0]["APP_EMP3"].ToString();
                                    row["APP_EMP4"] = dtAppRslt.Rows[0]["APP_EMP4"].ToString();
                                }

                                DORD.TORD_PRODUCT_AS.TORD_PRODUCT_AS_UPD(UTIL.GetRowToDt(row), bizExecute);
                            }
                                
                        }
                        else
                        {
                            throw UTIL.SetException("동일 데이터가 존재합니다."
                                , new System.Diagnostics.StackFrame().GetMethod().Name
                                );
                        }
                        
                    }
                    else
                    {
                        // string prod_code = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "AS", UTIL.emSerialFormat.YYYYMMDD, "-", bizExecute);

                        string serial_code = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "AS", UTIL.emSerialFormat.YYYYMMDD, "-", bizExecute);

                        //string prod_code = serial_code.Substring(2, 8) + "-" + serial_code.Substring(12, 3);

                        row["AS_NO"] = serial_code;

                        if (dtAppRslt.Rows.Count > 0)
                        {
                            row["APP_EMP1"] = dtAppRslt.Rows[0]["APP_EMP1"].ToString();
                            row["APP_EMP2"] = dtAppRslt.Rows[0]["APP_EMP2"].ToString();
                            row["APP_EMP3"] = dtAppRslt.Rows[0]["APP_EMP3"].ToString();
                            row["APP_EMP4"] = dtAppRslt.Rows[0]["APP_EMP4"].ToString();
                        }

                        DORD.TORD_PRODUCT_AS.TORD_PRODUCT_AS_INS(UTIL.GetRowToDt(row), bizExecute);

                    }

                }

                return ORD06A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }



        public static DataSet ORD06A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DORD.TORD_PRODUCT_AS_QUERY.TORD_PRODUCT_AS_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

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

        public static DataSet ORD06A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DORD.TORD_PRODUCT_AS_QUERY.TORD_PRODUCT_AS_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

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


        public static DataSet ORD06A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataTable dtRslt = DSTD.TSTD_APP_EMP_QUERY.TSTD_APP_EMP_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
        public static DataSet ORD06A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 2, typeof(Byte));
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "SEARCH_DATA_FLAG", 0, typeof(Byte));

                //DataTable dtNow = UTIL.UTILITY_GET_DTNOW(bizExecute);
                //string dt = ((DateTime)dtNow.Rows[0]["NOW_DT"]).ToString("yyyy-MM-dd HH:mm:ss");


                //foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                //{

                //    DataTable dtSer = DORD.TORD_PRODUCT_AS.TORD_PRODUCT_AS_SER(UTIL.GetRowToDt(row), bizExecute);

                //    if (dtSer.Rows[0]["PROD_STATE"].ToString() != "")
                //    {
                //        throw UTIL.SetException("대기 상태인 수주만 삭제 가능합니다."
                //              , new System.Diagnostics.StackFrame().GetMethod().Name
                //              , 200203);
                //    }

                //    else
                //    {
                //        row["DATA_FLAG"] = "2";
                        DORD.TORD_PRODUCT_AS.TORD_PRODUCT_AS_UDE(paramDS.Tables["RQSTDT"], bizExecute);
                //    }

                //}

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }


    }
}
