using BizExecute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSAN
{
    public class SAN02A
    {
        public static DataSet SAN02A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "BALJU_STAT", "11", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "IS_CANCEL", "1", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "IS_SAN_PUR", "0", typeof(Byte));
                DataTable dtRslt = new DataTable();

                DataTable emp = new DataTable("RQSTDT");
                emp.Columns.Add("PLT_CODE", typeof(string));
                emp.Columns.Add("EMP_CODE", typeof(string));

                DataRow newRow = emp.NewRow();
                newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                newRow["EMP_CODE"] = ConnInfo.UserID;
                emp.Rows.Add(newRow);

                DataTable dtEmp = DSTD.TSTD_EMPLOYEE.TSTD_EMPLOYEE_SER(emp, bizExecute);

                bool isChk = true;
                if (paramDS.Tables["RQSTDT"].Columns.Contains("IS_APP"))
                {
                    if (paramDS.Tables["RQSTDT"].Rows[0]["IS_APP"].ToString() == "1")
                    {
                        isChk = false;
                    }
                }

                if (isChk)
                {
                    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "IS_SAN_PUR", dtEmp.Rows[0]["IS_SAN_PUR"], typeof(Byte));
                }

                switch (paramDS.Tables["RQSTDT"].Rows[0]["SER_TYPE"].ToString())
                {
                    case "MAT_REQ_APP":
                        dtRslt = DMAT.TMAT_BALJU_MASTER_QUERY.TMAT_BALJU_MASTER_QUERY5(paramDS.Tables["RQSTDT"], bizExecute);
                        break;

                    case "MAT_APP_CANCEL":
                        dtRslt = DMAT.TMAT_BALJU_MASTER_QUERY.TMAT_BALJU_MASTER_QUERY6(paramDS.Tables["RQSTDT"], bizExecute);
                        break;

                    case "MAT_REJ_CANCEL":
                        dtRslt = DMAT.TMAT_BALJU_MASTER_QUERY.TMAT_BALJU_MASTER_QUERY7(paramDS.Tables["RQSTDT"], bizExecute);
                        break;

                    case "OUT_REQ_APP":
                        dtRslt = DOUT.TOUT_PROCBALJU_MASTER_QUERY.TOUT_PROCBALJU_MASTER_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);
                        break;

                    case "OUT_APP_CANCEL":
                        dtRslt = DOUT.TOUT_PROCBALJU_MASTER_QUERY.TOUT_PROCBALJU_MASTER_QUERY4(paramDS.Tables["RQSTDT"], bizExecute);
                        break;

                    case "OUT_REJ_CANCEL":
                        dtRslt = DOUT.TOUT_PROCBALJU_MASTER_QUERY.TOUT_PROCBALJU_MASTER_QUERY5(paramDS.Tables["RQSTDT"], bizExecute);
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

        public static DataSet SAN02A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "NOT_BAL_STAT", "14", typeof(string));

                DataTable dtRslt = new DataTable();

                if (paramDS.Tables["RQSTDT"].Rows[0]["LOG_SER_TYPE"].ToString() == "MAT")
                {
                    dtRslt = DMAT.TMAT_BALJU_QUERY.TMAT_BALJU_QUERY18(paramDS.Tables["RQSTDT"], bizExecute);
                }
                else if (paramDS.Tables["RQSTDT"].Rows[0]["LOG_SER_TYPE"].ToString() == "OUT")
                {
                    dtRslt = DOUT.TOUT_PROCBALJU_QUERY.TOUT_PROCBALJU_QUERY21(paramDS.Tables["RQSTDT"], bizExecute);
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

        public static DataSet SAN02A_UPD(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_TYPE", "PUR", typeof(string));

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
                    //{
                    //    throw UTIL.SetException("승인자 정보가 없습니다."
                    //                   , new System.Diagnostics.StackFrame().GetMethod().Name);
                    //}

                    DataTable dtWork = new DataTable();
                    switch(row["BAL_SER_TYPE"].ToString())
                    {
                        case "MAT":
                            dtWork = DMAT.TMAT_BALJU_MASTER.TMAT_BALJU_MASTER_SER(UTIL.GetRowToDt(row), bizExecute);
                            break;

                        case "OUT":
                            dtWork = DOUT.TOUT_PROCBALJU_MASTER.TOUT_PROCBALJU_MASTER_SER(UTIL.GetRowToDt(row), bizExecute);
                            break;
                    }

                    if (dtWork.Rows.Count != 0)
                    {
                        if (dtWork.Rows[0]["APP_STATUS"].ToString() == "3")
                        {
                            throw UTIL.SetException("반려된 신청입니다."
                                        , new System.Diagnostics.StackFrame().GetMethod().Name);
                        }

                        row["APP_EMP1"] = dtWork.Rows[0]["APP_EMP1"];
                        row["APP_EMP_FLAG1"] = dtWork.Rows[0]["APP_EMP_FLAG1"];

                        row["APP_EMP2"] = dtWork.Rows[0]["APP_EMP2"];
                        row["APP_EMP_FLAG2"] = dtWork.Rows[0]["APP_EMP_FLAG2"];

                        row["APP_EMP3"] = dtWork.Rows[0]["APP_EMP3"];
                        row["APP_EMP_FLAG3"] = dtWork.Rows[0]["APP_EMP_FLAG3"];

                        row["APP_EMP4"] = dtWork.Rows[0]["APP_EMP4"];
                        row["APP_EMP_FLAG4"] = dtWork.Rows[0]["APP_EMP_FLAG4"];

                        if (dtWork.Rows[0]["APP_STATUS"].ToString() == "2")
                        {
                            row["APP_STATUS"] = "2";
                        }

                        bool is_appuser = false;
                        if (row["APP_EMP1"].Equals(ConnInfo.UserID))
                        {
                            //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP1", ConnInfo.UserID, typeof(string));
                            //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP_FLAG1", row["APP_FLAG"].ToString(), typeof(string));
                            row["APP_EMP1"] = ConnInfo.UserID;
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

                            switch (row["BAL_SER_TYPE"].ToString())
                            {
                                case "MAT":
                                    DMAT.TMAT_BALJU_MASTER.TMAT_BALJU_MASTER_UPD3(UTIL.GetRowToDt(row), bizExecute);
                                    break;

                                case "OUT":
                                    DOUT.TOUT_PROCBALJU_MASTER.TOUT_PROCBALJU_MASTER_UPD3(UTIL.GetRowToDt(row), bizExecute);
                                    break;
                            }
                            is_appuser = true;
                        }

                        if (row["APP_EMP2"].Equals(ConnInfo.UserID))
                        {
                            if (dtWork.Rows[0]["APP_EMP_FLAG1"].ToString() != "1")
                            {
                                throw UTIL.SetException("이전 승인자가 승인하지 않았습니다."
                                       , new System.Diagnostics.StackFrame().GetMethod().Name);
                            }

                            //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP2", ConnInfo.UserID, typeof(string));
                            //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP_FLAG2", row["APP_FLAG"].ToString(), typeof(string));
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

                            switch (row["BAL_SER_TYPE"].ToString())
                            {
                                case "MAT":
                                    DMAT.TMAT_BALJU_MASTER.TMAT_BALJU_MASTER_UPD3(UTIL.GetRowToDt(row), bizExecute);
                                    break;

                                case "OUT":
                                    DOUT.TOUT_PROCBALJU_MASTER.TOUT_PROCBALJU_MASTER_UPD3(UTIL.GetRowToDt(row), bizExecute);
                                    break;
                            }
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
                            //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP_FLAG3", row["APP_FLAG"].ToString(), typeof(string));
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

                            switch (row["BAL_SER_TYPE"].ToString())
                            {
                                case "MAT":
                                    DMAT.TMAT_BALJU_MASTER.TMAT_BALJU_MASTER_UPD3(UTIL.GetRowToDt(row), bizExecute);
                                    break;

                                case "OUT":
                                    DOUT.TOUT_PROCBALJU_MASTER.TOUT_PROCBALJU_MASTER_UPD3(UTIL.GetRowToDt(row), bizExecute);
                                    break;
                            }
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
                            //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP_FLAG4", row["APP_FLAG"].ToString(), typeof(string));
                            //row["APP_EMP4"] = ConnInfo.UserID;
                            row["APP_EMP_FLAG4"] = row["APP_FLAG"];

                            row["APP_STATUS"] = "2";

                            switch (row["BAL_SER_TYPE"].ToString())
                            {
                                case "MAT":
                                    DMAT.TMAT_BALJU_MASTER.TMAT_BALJU_MASTER_UPD3(UTIL.GetRowToDt(row), bizExecute);
                                    break;

                                case "OUT":
                                    DOUT.TOUT_PROCBALJU_MASTER.TOUT_PROCBALJU_MASTER_UPD3(UTIL.GetRowToDt(row), bizExecute);
                                    break;
                            }
                            is_appuser = true;
                        }

                        if (is_appuser == false)
                        {
                            throw UTIL.SetException("승인자 정보가 없습니다."
                                           , new System.Diagnostics.StackFrame().GetMethod().Name);
                        }
                    }
                }


                return SAN02A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet SAN02A_UPD2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_TYPE", "PUR", typeof(string));

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
                    //    throw UTIL.SetException("승인자 정보가 없습니다."
                    //                   , new System.Diagnostics.StackFrame().GetMethod().Name);

                    DataTable dtWork = new DataTable();
                    switch (row["BAL_SER_TYPE"].ToString())
                    {
                        case "MAT":
                            dtWork = DMAT.TMAT_BALJU_MASTER.TMAT_BALJU_MASTER_SER(UTIL.GetRowToDt(row), bizExecute);
                            break;

                        case "OUT":
                            dtWork = DOUT.TOUT_PROCBALJU_MASTER.TOUT_PROCBALJU_MASTER_SER(UTIL.GetRowToDt(row), bizExecute);
                            break;
                    }

                    if (dtWork.Rows.Count == 0)
                        throw UTIL.SetException("데이터에 문제가 발생 하였습니다.다시 확인하여 주십시오."
                                       , new System.Diagnostics.StackFrame().GetMethod().Name);

                    row["APP_EMP1"] = dtWork.Rows[0]["APP_EMP1"];
                    row["APP_EMP_FLAG1"] = dtWork.Rows[0]["APP_EMP_FLAG1"];

                    row["APP_EMP2"] = dtWork.Rows[0]["APP_EMP2"];
                    row["APP_EMP_FLAG2"] = dtWork.Rows[0]["APP_EMP_FLAG2"];

                    row["APP_EMP3"] = dtWork.Rows[0]["APP_EMP3"];
                    row["APP_EMP_FLAG3"] = dtWork.Rows[0]["APP_EMP_FLAG3"];

                    row["APP_EMP4"] = dtWork.Rows[0]["APP_EMP4"];
                    row["APP_EMP_FLAG4"] = dtWork.Rows[0]["APP_EMP_FLAG4"];

                    int iAppCnt = 0;
                    if (dtWork.Rows[0]["APP_EMP_FLAG1"].ToString() == "1")
                    {
                        iAppCnt++;
                    }
                    if (dtWork.Rows[0]["APP_EMP_FLAG2"].ToString() == "1"
                        || dtWork.Rows[0]["APP_EMP_FLAG2"].ToString() == "2")
                    {
                        iAppCnt++;
                    }
                    if (dtWork.Rows[0]["APP_EMP_FLAG3"].ToString() == "1"
                        || dtWork.Rows[0]["APP_EMP_FLAG3"].ToString() == "2")
                    {
                        iAppCnt++;
                    }
                    if (dtWork.Rows[0]["APP_EMP_FLAG4"].ToString() == "1"
                        || dtWork.Rows[0]["APP_EMP_FLAG4"].ToString() == "2")
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

                        switch (row["BAL_SER_TYPE"].ToString())
                        {
                            case "MAT":
                                DMAT.TMAT_BALJU_MASTER.TMAT_BALJU_MASTER_UPD3(UTIL.GetRowToDt(row), bizExecute);
                                break;

                            case "OUT":
                                DOUT.TOUT_PROCBALJU_MASTER.TOUT_PROCBALJU_MASTER_UPD3(UTIL.GetRowToDt(row), bizExecute);
                                break;
                        }
                        is_appuser = true;
                    }

                    if (row["APP_EMP2"].Equals(ConnInfo.UserID))
                    {
                        //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP2", DBNull.Value, typeof(string));

                        //row["APP_EMP2"] = DBNull.Value;
                        row["APP_EMP_FLAG2"] = row["APP_FLAG"];

                        switch (row["BAL_SER_TYPE"].ToString())
                        {
                            case "MAT":
                                DMAT.TMAT_BALJU_MASTER.TMAT_BALJU_MASTER_UPD3(UTIL.GetRowToDt(row), bizExecute);
                                break;

                            case "OUT":
                                DOUT.TOUT_PROCBALJU_MASTER.TOUT_PROCBALJU_MASTER_UPD3(UTIL.GetRowToDt(row), bizExecute);
                                break;
                        }
                        is_appuser = true;
                    }

                    if (row["APP_EMP3"].Equals(ConnInfo.UserID))
                    {
                        //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP3", DBNull.Value, typeof(string));

                        //row["APP_EMP3"] = DBNull.Value;
                        row["APP_EMP_FLAG3"] = row["APP_FLAG"];

                        switch (row["BAL_SER_TYPE"].ToString())
                        {
                            case "MAT":
                                DMAT.TMAT_BALJU_MASTER.TMAT_BALJU_MASTER_UPD3(UTIL.GetRowToDt(row), bizExecute);
                                break;

                            case "OUT":
                                DOUT.TOUT_PROCBALJU_MASTER.TOUT_PROCBALJU_MASTER_UPD3(UTIL.GetRowToDt(row), bizExecute);
                                break;
                        }
                        is_appuser = true;
                    }

                    if (row["APP_EMP4"].Equals(ConnInfo.UserID))
                    {
                        //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP4", DBNull.Value, typeof(string));

                        //row["APP_EMP4"] = DBNull.Value;
                        row["APP_EMP_FLAG4"] = row["APP_FLAG"];

                        switch (row["BAL_SER_TYPE"].ToString())
                        {
                            case "MAT":
                                DMAT.TMAT_BALJU_MASTER.TMAT_BALJU_MASTER_UPD3(UTIL.GetRowToDt(row), bizExecute);
                                break;

                            case "OUT":
                                DOUT.TOUT_PROCBALJU_MASTER.TOUT_PROCBALJU_MASTER_UPD3(UTIL.GetRowToDt(row), bizExecute);
                                break;
                        }
                        is_appuser = true;
                    }

                    if (is_appuser == false)
                        throw UTIL.SetException("승인자 정보가 없습니다."
                                       , new System.Diagnostics.StackFrame().GetMethod().Name);

                }

                return SAN02A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static DataSet SAN02A_UPD3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_TYPE", "PUR", typeof(string));

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

                    DataTable dtWork = new DataTable();
                    switch (row["BAL_SER_TYPE"].ToString())
                    {
                        case "MAT":
                            dtWork = DMAT.TMAT_BALJU_MASTER.TMAT_BALJU_MASTER_SER(UTIL.GetRowToDt(row), bizExecute);
                            break;

                        case "OUT":
                            dtWork = DOUT.TOUT_PROCBALJU_MASTER.TOUT_PROCBALJU_MASTER_SER(UTIL.GetRowToDt(row), bizExecute);
                            break;
                    }

                    if (dtWork.Rows.Count == 0)
                        throw UTIL.SetException("데이터에 문제가 발생 하였습니다.다시 확인하여 주십시오."
                                       , new System.Diagnostics.StackFrame().GetMethod().Name);


                    row["APP_EMP1"] = dtWork.Rows[0]["APP_EMP1"];
                    row["APP_EMP_FLAG1"] = dtWork.Rows[0]["APP_EMP_FLAG1"];

                    row["APP_EMP2"] = dtWork.Rows[0]["APP_EMP2"];
                    row["APP_EMP_FLAG2"] = dtWork.Rows[0]["APP_EMP_FLAG2"];

                    row["APP_EMP3"] = dtWork.Rows[0]["APP_EMP3"];
                    row["APP_EMP_FLAG3"] = dtWork.Rows[0]["APP_EMP_FLAG3"];

                    row["APP_EMP4"] = dtWork.Rows[0]["APP_EMP4"];
                    row["APP_EMP_FLAG4"] = dtWork.Rows[0]["APP_EMP_FLAG4"];

                    bool is_appuser = false;
                    if (row["APP_EMP1"].Equals(ConnInfo.UserID))
                    {
                        //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP1", ConnInfo.UserID, typeof(string));
                        //row["APP_EMP1"] = ConnInfo.UserID;
                        row["APP_EMP_FLAG1"] = row["APP_FLAG"];

                        switch (row["BAL_SER_TYPE"].ToString())
                        {
                            case "MAT":
                                DMAT.TMAT_BALJU_MASTER.TMAT_BALJU_MASTER_UPD3(UTIL.GetRowToDt(row), bizExecute);
                                break;

                            case "OUT":
                                DOUT.TOUT_PROCBALJU_MASTER.TOUT_PROCBALJU_MASTER_UPD3(UTIL.GetRowToDt(row), bizExecute);
                                break;
                        }
                        is_appuser = true;
                    }

                    if (row["APP_EMP2"].Equals(ConnInfo.UserID))
                    {
                        if (dtWork.Rows[0]["APP_EMP_FLAG1"].ToString() != "1")
                        {
                            throw UTIL.SetException("이전 승인자가 승인하지 않았습니다."
                                   , new System.Diagnostics.StackFrame().GetMethod().Name);
                        }

                        //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP2", ConnInfo.UserID, typeof(string));
                        //row["APP_EMP2"] = ConnInfo.UserID;
                        row["APP_EMP_FLAG2"] = row["APP_FLAG"];

                        switch (row["BAL_SER_TYPE"].ToString())
                        {
                            case "MAT":
                                DMAT.TMAT_BALJU_MASTER.TMAT_BALJU_MASTER_UPD3(UTIL.GetRowToDt(row), bizExecute);
                                break;

                            case "OUT":
                                DOUT.TOUT_PROCBALJU_MASTER.TOUT_PROCBALJU_MASTER_UPD3(UTIL.GetRowToDt(row), bizExecute);
                                break;
                        }
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

                        switch (row["BAL_SER_TYPE"].ToString())
                        {
                            case "MAT":
                                DMAT.TMAT_BALJU_MASTER.TMAT_BALJU_MASTER_UPD3(UTIL.GetRowToDt(row), bizExecute);
                                break;

                            case "OUT":
                                DOUT.TOUT_PROCBALJU_MASTER.TOUT_PROCBALJU_MASTER_UPD3(UTIL.GetRowToDt(row), bizExecute);
                                break;
                        }
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

                        switch (row["BAL_SER_TYPE"].ToString())
                        {
                            case "MAT":
                                DMAT.TMAT_BALJU_MASTER.TMAT_BALJU_MASTER_UPD3(UTIL.GetRowToDt(row), bizExecute);
                                break;

                            case "OUT":
                                DOUT.TOUT_PROCBALJU_MASTER.TOUT_PROCBALJU_MASTER_UPD3(UTIL.GetRowToDt(row), bizExecute);
                                break;
                        }
                        is_appuser = true;
                    }

                    if (is_appuser == false)
                        throw UTIL.SetException("승인자 정보가 없습니다."
                                       , new System.Diagnostics.StackFrame().GetMethod().Name);
                }


                return SAN02A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }
    }
}
