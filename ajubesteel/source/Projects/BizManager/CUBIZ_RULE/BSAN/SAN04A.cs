using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BizExecute;

namespace BSAN
{
    public class SAN04A
    {        

        public static DataSet SAN04A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                //DataTable dtRslt = DORD.TORD_PRODUCT_AS_QUERY.TORD_PRODUCT_AS_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                DataTable dtRslt = new DataTable();
                switch (paramDS.Tables["RQSTDT"].Rows[0]["SER_TYPE"].ToString())
                {
                    case "REQ_APP":
                        dtRslt = DORD.TORD_PRODUCT_AS_QUERY.TORD_PRODUCT_AS_QUERY4(paramDS.Tables["RQSTDT"], bizExecute);
                        break;

                    case "APP_CANCEL":
                        dtRslt = DORD.TORD_PRODUCT_AS_QUERY.TORD_PRODUCT_AS_QUERY5(paramDS.Tables["RQSTDT"], bizExecute);
                        break;

                    case "REJ_CANCEL":
                        dtRslt = DORD.TORD_PRODUCT_AS_QUERY.TORD_PRODUCT_AS_QUERY6(paramDS.Tables["RQSTDT"], bizExecute);
                        break;
                }

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


        public static DataSet SAN04A_UPD(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_TYPE", "AS", typeof(string));

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP1", null, typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP_FLAG1", null, typeof(string));

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP2", null, typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP_FLAG2", null, typeof(string));

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP3", null, typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP_FLAG3", null, typeof(string));

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP4", null, typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP_FLAG4", null, typeof(string));

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_STATUS", "1", typeof(string));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    //DataTable dtAppEmp = DSTD.TSTD_APP_EMP.TSTD_APP_EMP_SER(UTIL.GetRowToDt(row), bizExecute);

                    //if (dtAppEmp.Rows.Count == 0)
                    //    throw UTIL.SetException("A/S승인자 정보가 없습니다."
                    //                   , new System.Diagnostics.StackFrame().GetMethod().Name);

                    DataTable dtAs = DORD.TORD_PRODUCT_AS.TORD_PRODUCT_AS_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (dtAs.Rows.Count == 0)
                        throw UTIL.SetException("데이터에 문제가 발생 하였습니다.다시 확인하여 주십시오."
                                       , new System.Diagnostics.StackFrame().GetMethod().Name);

                    row["APP_EMP1"] = dtAs.Rows[0]["APP_EMP1"];
                    row["APP_EMP_FLAG1"] = dtAs.Rows[0]["APP_EMP_FLAG1"];

                    row["APP_EMP2"] = dtAs.Rows[0]["APP_EMP2"];
                    row["APP_EMP_FLAG2"] = dtAs.Rows[0]["APP_EMP_FLAG2"];

                    row["APP_EMP3"] = dtAs.Rows[0]["APP_EMP3"];
                    row["APP_EMP_FLAG3"] = dtAs.Rows[0]["APP_EMP_FLAG3"];

                    row["APP_EMP4"] = dtAs.Rows[0]["APP_EMP4"];
                    row["APP_EMP_FLAG4"] = dtAs.Rows[0]["APP_EMP_FLAG4"];

                    if (dtAs.Rows[0]["APP_STATUS"].ToString() == "2")
                    {
                        row["APP_STATUS"] = "2";
                    }

                    bool is_appuser = false;

                    if (row["APP_EMP1"].Equals(ConnInfo.UserID))
                    {
                        //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP1", ConnInfo.UserID, typeof(string));

                        //row["APP_EMP1"] = ConnInfo.UserID;
                        row["APP_EMP_FLAG1"] = row["APP_FLAG"];

                        if (row["APP_EMP2"] == null
                            && row["APP_EMP3"] == null
                            && row["APP_EMP4"] == null)
                        {
                            row["APP_STATUS"] = "2";
                        }
                        else
                        {
                            if (row["APP_EMP2"].ToString() == ""
                                && row["APP_EMP3"].ToString() == ""
                                && row["APP_EMP4"].ToString() == "")
                            {
                                row["APP_STATUS"] = "2";
                            }
                        }

                        DORD.TORD_PRODUCT_AS.TORD_PRODUCT_AS_UPD2(UTIL.GetRowToDt(row), bizExecute);
                        is_appuser = true;
                    }

                    if (row["APP_EMP2"].Equals(ConnInfo.UserID))
                    {
                        if (row["APP_EMP_FLAG1"].ToString() != "1")
                        {
                            throw UTIL.SetException("이전 승인자가 승인하지 않았습니다."
                                   , new System.Diagnostics.StackFrame().GetMethod().Name);
                        }

                        //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP2", ConnInfo.UserID, typeof(string));

                        //row["APP_EMP2"] = ConnInfo.UserID;
                        row["APP_EMP_FLAG2"] = row["APP_FLAG"];

                        if (row["APP_EMP3"] == null
                            && row["APP_EMP4"] == null)
                        {
                            row["APP_STATUS"] = "2";
                        }
                        else
                        {
                            if (row["APP_EMP3"].ToString() == ""
                                && row["APP_EMP4"].ToString() == "")
                            {
                                row["APP_STATUS"] = "2";
                            }
                        }


                        DORD.TORD_PRODUCT_AS.TORD_PRODUCT_AS_UPD2(UTIL.GetRowToDt(row), bizExecute);
                        is_appuser = true;
                    }

                    if (row["APP_EMP3"].Equals(ConnInfo.UserID))
                    {
                        if (row["APP_EMP_FLAG1"].ToString() != "1"
                            || row["APP_EMP_FLAG2"].ToString() != "1")
                        {
                            throw UTIL.SetException("이전 승인자가 승인하지 않았습니다."
                                   , new System.Diagnostics.StackFrame().GetMethod().Name);
                        }

                        //row["APP_EMP3"] = ConnInfo.UserID;
                        row["APP_EMP_FLAG3"] = row["APP_FLAG"];

                        if (row["APP_EMP4"] == null)
                        {
                            row["APP_STATUS"] = "2";
                        }
                        else
                        {
                            if (row["APP_EMP4"].ToString() == "")
                            {
                                row["APP_STATUS"] = "2";
                            }
                        }

                        //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP3", ConnInfo.UserID, typeof(string));
                        DORD.TORD_PRODUCT_AS.TORD_PRODUCT_AS_UPD2(UTIL.GetRowToDt(row), bizExecute);

                        is_appuser = true;
                    }

                    if (row["APP_EMP4"].Equals(ConnInfo.UserID))
                    {
                        if (row["APP_EMP_FLAG1"].ToString() != "1"
                            || row["APP_EMP_FLAG2"].ToString() != "1"
                            || row["APP_EMP_FLAG3"].ToString() != "1")
                        {
                            throw UTIL.SetException("이전 승인자가 승인하지 않았습니다."
                                   , new System.Diagnostics.StackFrame().GetMethod().Name);
                        }

                        //row["APP_EMP4"] = ConnInfo.UserID;
                        row["APP_EMP_FLAG4"] = row["APP_FLAG"];
                        row["APP_STATUS"] = "2";

                        //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP4", ConnInfo.UserID, typeof(string));
                        DORD.TORD_PRODUCT_AS.TORD_PRODUCT_AS_UPD2(UTIL.GetRowToDt(row), bizExecute);
                        is_appuser = true;
                    }

                    if (is_appuser == false)
                        throw UTIL.SetException("A/S승인자 정보가 없습니다."
                                       , new System.Diagnostics.StackFrame().GetMethod().Name);

                }


                return SAN04A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static DataSet SAN04A_UPD2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_TYPE", "AS", typeof(string));

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP1", null, typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP_FLAG1", null, typeof(string));

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP2", null, typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP_FLAG2", null, typeof(string));

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP3", null, typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP_FLAG3", null, typeof(string));

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP4", null, typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP_FLAG4", null, typeof(string));

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_STATUS", "0", typeof(string));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {

                    //DataTable dtAppEmp = DSTD.TSTD_APP_EMP.TSTD_APP_EMP_SER(UTIL.GetRowToDt(row), bizExecute);

                    //if (dtAppEmp.Rows.Count == 0)
                    //    throw UTIL.SetException("A/S승인자 정보가 없습니다."
                    //                   , new System.Diagnostics.StackFrame().GetMethod().Name);

                    DataTable dtAs = DORD.TORD_PRODUCT_AS.TORD_PRODUCT_AS_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (dtAs.Rows.Count == 0)
                        throw UTIL.SetException("데이터에 문제가 발생 하였습니다.다시 확인하여 주십시오."
                                       , new System.Diagnostics.StackFrame().GetMethod().Name);

                    row["APP_EMP1"] = dtAs.Rows[0]["APP_EMP1"];
                    row["APP_EMP_FLAG1"] = dtAs.Rows[0]["APP_EMP_FLAG1"];

                    row["APP_EMP2"] = dtAs.Rows[0]["APP_EMP2"];
                    row["APP_EMP_FLAG2"] = dtAs.Rows[0]["APP_EMP_FLAG2"];

                    row["APP_EMP3"] = dtAs.Rows[0]["APP_EMP3"];
                    row["APP_EMP_FLAG3"] = dtAs.Rows[0]["APP_EMP_FLAG3"];

                    row["APP_EMP4"] = dtAs.Rows[0]["APP_EMP4"];
                    row["APP_EMP_FLAG4"] = dtAs.Rows[0]["APP_EMP_FLAG4"];

                    int iAppCnt = 0;
                    if (dtAs.Rows[0]["APP_EMP_FLAG1"].ToString() == "1")
                    {
                        iAppCnt++;
                    }
                    if (dtAs.Rows[0]["APP_EMP_FLAG2"].ToString() == "1")
                    {
                        iAppCnt++;
                    }
                    if (dtAs.Rows[0]["APP_EMP_FLAG3"].ToString() == "1")
                    {
                        iAppCnt++;
                    }
                    if (dtAs.Rows[0]["APP_EMP_FLAG4"].ToString() == "1")
                    {
                        iAppCnt++;
                    }

                    if (iAppCnt > 1)
                    {
                        row["APP_STATUS"] = "1";
                    }

                    bool is_appuser = false;

                    if (row["APP_EMP1"].Equals(ConnInfo.UserID))
                    {
                        //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP1", DBNull.Value, typeof(string));

                        //row["APP_EMP1"] = DBNull.Value;
                        row["APP_EMP_FLAG1"] = row["APP_FLAG"];

                        DORD.TORD_PRODUCT_AS.TORD_PRODUCT_AS_UPD2(UTIL.GetRowToDt(row), bizExecute);
                        is_appuser = true;
                    }

                    if (row["APP_EMP2"].Equals(ConnInfo.UserID))
                    {
                        //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP2", DBNull.Value, typeof(string));

                        //row["APP_EMP2"] = DBNull.Value;
                        row["APP_EMP_FLAG2"] = row["APP_FLAG"];

                        DORD.TORD_PRODUCT_AS.TORD_PRODUCT_AS_UPD2(UTIL.GetRowToDt(row), bizExecute);
                        is_appuser = true;
                    }

                    if (row["APP_EMP3"].Equals(ConnInfo.UserID))
                    {
                        //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP3", DBNull.Value, typeof(string));

                        //row["APP_EMP3"] = DBNull.Value;
                        row["APP_EMP_FLAG3"] = row["APP_FLAG"];

                        DORD.TORD_PRODUCT_AS.TORD_PRODUCT_AS_UPD2(UTIL.GetRowToDt(row), bizExecute);
                        is_appuser = true;
                    }

                    if (row["APP_EMP4"].Equals(ConnInfo.UserID))
                    {
                        //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP4", DBNull.Value, typeof(string));

                        //row["APP_EMP4"] = DBNull.Value;
                        row["APP_EMP_FLAG4"] = row["APP_FLAG"];

                        DORD.TORD_PRODUCT_AS.TORD_PRODUCT_AS_UPD2(UTIL.GetRowToDt(row), bizExecute);
                        is_appuser = true;
                    }

                    if (is_appuser == false)
                        throw UTIL.SetException("A/S승인자 정보가 없습니다."
                                       , new System.Diagnostics.StackFrame().GetMethod().Name);

                }

                return SAN04A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static DataSet SAN04A_UPD3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_TYPE", "AS", typeof(string));

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP1", null, typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP_FLAG1", null, typeof(string));

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP2", null, typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP_FLAG2", null, typeof(string));

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP3", null, typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP_FLAG3", null, typeof(string));

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP4", null, typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP_FLAG4", null, typeof(string));

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_STATUS", "3", typeof(string));


                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    //DataTable dtAppEmp = DSTD.TSTD_APP_EMP.TSTD_APP_EMP_SER(UTIL.GetRowToDt(row), bizExecute);

                    //if (dtAppEmp.Rows.Count == 0)
                    //    throw UTIL.SetException("승인자 정보가 없습니다."
                    //                   , new System.Diagnostics.StackFrame().GetMethod().Name);

                    DataTable dtAs = DORD.TORD_PRODUCT_AS.TORD_PRODUCT_AS_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (dtAs.Rows.Count == 0)
                        throw UTIL.SetException("데이터에 문제가 발생 하였습니다.다시 확인하여 주십시오."
                                       , new System.Diagnostics.StackFrame().GetMethod().Name);


                    row["APP_EMP1"] = dtAs.Rows[0]["APP_EMP1"];
                    row["APP_EMP_FLAG1"] = dtAs.Rows[0]["APP_EMP_FLAG1"];

                    row["APP_EMP2"] = dtAs.Rows[0]["APP_EMP2"];
                    row["APP_EMP_FLAG2"] = dtAs.Rows[0]["APP_EMP_FLAG2"];

                    row["APP_EMP3"] = dtAs.Rows[0]["APP_EMP3"];
                    row["APP_EMP_FLAG3"] = dtAs.Rows[0]["APP_EMP_FLAG3"];

                    row["APP_EMP4"] = dtAs.Rows[0]["APP_EMP4"];
                    row["APP_EMP_FLAG4"] = dtAs.Rows[0]["APP_EMP_FLAG4"];

                    bool is_appuser = false;
                    if (row["APP_EMP1"].Equals(ConnInfo.UserID))
                    {
                        //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP1", ConnInfo.UserID, typeof(string));
                        //row["APP_EMP1"] = ConnInfo.UserID;
                        row["APP_EMP_FLAG1"] = row["APP_FLAG"];

                        DORD.TORD_PRODUCT_AS.TORD_PRODUCT_AS_UPD2(UTIL.GetRowToDt(row), bizExecute);
                        is_appuser = true;
                    }

                    if (row["APP_EMP2"].Equals(ConnInfo.UserID))
                    {
                        if (row["APP_EMP_FLAG1"].ToString() != "1")
                        {
                            throw UTIL.SetException("이전 승인자가 승인하지 않았습니다."
                                   , new System.Diagnostics.StackFrame().GetMethod().Name);
                        }

                        //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP2", ConnInfo.UserID, typeof(string));
                        //row["APP_EMP2"] = ConnInfo.UserID;
                        row["APP_EMP_FLAG2"] = row["APP_FLAG"];

                        DORD.TORD_PRODUCT_AS.TORD_PRODUCT_AS_UPD2(UTIL.GetRowToDt(row), bizExecute);
                        is_appuser = true;
                    }

                    if (row["APP_EMP3"].Equals(ConnInfo.UserID))
                    {
                        if (row["APP_EMP_FLAG1"].ToString() != "1"
                            || row["APP_EMP_FLAG2"].ToString() != "1")
                        {
                            throw UTIL.SetException("이전 승인자가 승인하지 않았습니다."
                                   , new System.Diagnostics.StackFrame().GetMethod().Name);
                        }

                        //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP3", ConnInfo.UserID, typeof(string));
                        //row["APP_EMP3"] = ConnInfo.UserID;
                        row["APP_EMP_FLAG3"] = row["APP_FLAG"];

                        DORD.TORD_PRODUCT_AS.TORD_PRODUCT_AS_UPD2(UTIL.GetRowToDt(row), bizExecute);
                        is_appuser = true;
                    }

                    if (row["APP_EMP4"].Equals(ConnInfo.UserID))
                    {
                        if (row["APP_EMP_FLAG1"].ToString() != "1"
                            || row["APP_EMP_FLAG2"].ToString() != "1"
                            || row["APP_EMP_FLAG3"].ToString() != "1")
                        {
                            throw UTIL.SetException("이전 승인자가 승인하지 않았습니다."
                                   , new System.Diagnostics.StackFrame().GetMethod().Name);
                        }

                        //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP4", ConnInfo.UserID, typeof(string));
                        //row["APP_EMP4"] = ConnInfo.UserID;
                        row["APP_EMP_FLAG4"] = row["APP_FLAG"];

                        DORD.TORD_PRODUCT_AS.TORD_PRODUCT_AS_UPD2(UTIL.GetRowToDt(row), bizExecute);
                        is_appuser = true;
                    }

                    if (is_appuser == false)
                        throw UTIL.SetException("승인자 정보가 없습니다."
                                       , new System.Diagnostics.StackFrame().GetMethod().Name);
                }


                return SAN04A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }


    }
}
