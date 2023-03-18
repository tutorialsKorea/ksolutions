using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BizExecute;

namespace BSYS
{
    public class SYS16A
    {
        public static DataSet SYS16A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DSYS.TSYS_PROPOSE.TSYS_PROPOSE_SER(paramDS.Tables["RQSTDT"], bizExecute);

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



       
        public static DataSet SYS16A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DSYS.TSYS_PROPOSE_QUERY.TSYS_PROPOSE_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

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
        /// 다이얼로그 NEW 상태에서 첨부파일 등록을 위해 파일키 생성
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>

        public static DataSet SYS16A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataRow row = paramDS.Tables["RQSTDT"].Rows[0];

                string attach_issue = "ISU"; // 문제점_첨부파일
                string attach_solution = "SOL"; // 개선안_첨부파일
                string attach_report = "REP"; // 완료보고서_첨부파일

                string filekey1 = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), attach_issue, bizExecute);
                string filekey2 = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), attach_solution, bizExecute);
                string filekey3 = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), attach_report, bizExecute);

                DataTable dtRslt = new DataTable("RSLTDT");
                dtRslt.Columns.Add("ISSU_FILE_ID", typeof(String)); //
                dtRslt.Columns.Add("SOL_FILE_ID", typeof(String)); //
                dtRslt.Columns.Add("RPT_FILE_ID", typeof(String)); //

                DataRow paramRow = dtRslt.NewRow();
                paramRow["ISSU_FILE_ID"] = filekey1;
                paramRow["SOL_FILE_ID"] = filekey2;
                paramRow["RPT_FILE_ID"] = filekey3;
                dtRslt.Rows.Add(paramRow);

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }





        public static DataSet SYS16A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (paramDS.Tables["RQSTDT"].Rows.Count != 0)
                {
                    DSYS.TSYS_PROPOSE.TSYS_PROPOSE_INS(paramDS.Tables["RQSTDT"], bizExecute);
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static DataSet SYS16A_INS2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                if (paramDS.Tables["RQSTDT"].Rows.Count != 0)
                {

                    string attach_issue = "ISU"; // 문제점_첨부파일
                    string attach_solution = "SOL"; // 개선안_첨부파일
                    string attach_report = "REP"; // 완료보고서_첨부파일


                    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP1", "", typeof(string));
                    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP2", "", typeof(string));
                    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP3", "", typeof(string));
                    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_EMP4", "", typeof(string));

                    DataTable dtAppRqst = new DataTable("RQSTDT");
                    dtAppRqst.Columns.Add("PLT_CODE", typeof(string));
                    dtAppRqst.Columns.Add("APP_TYPE", typeof(string));

                    DataRow appRow = dtAppRqst.NewRow();
                    appRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                    appRow["APP_TYPE"] = "PRS";

                    dtAppRqst.Rows.Add(appRow);

                    DataTable dtAppRslt = DSTD.TSTD_APP_EMP.TSTD_APP_EMP_SER(dtAppRqst, bizExecute);

                    DataRow row = paramDS.Tables["RQSTDT"].Rows[0];

                    DataTable dtRst = DSYS.TSYS_PROPOSE.TSYS_PROPOSE_SER(paramDS.Tables["RQSTDT"], bizExecute);

                    if (dtRst.Rows.Count > 0)
                    {
                        DSYS.TSYS_PROPOSE.TSYS_PROPOSE_UPD(paramDS.Tables["RQSTDT"], bizExecute);
                    }
                    else
                    {
                        
                        string serialKey = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(),"",UTIL.emSerialFormat.YYMMDDHH,"-",bizExecute);

                        string filekey1 = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), attach_issue, UTIL.emSerialFormat.YYMMDDHH, "-", bizExecute);
                        string filekey2 = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), attach_solution, UTIL.emSerialFormat.YYMMDDHH, "-", bizExecute);
                        string filekey3 = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), attach_report, UTIL.emSerialFormat.YYMMDDHH, "-", bizExecute);

                        row["PROPS_ID"] = serialKey;

                        row["ISSU_FILE_ID"] = filekey1;
                        row["SOL_FILE_ID"] = filekey2;
                        row["RPT_FILE_ID"] = filekey3;

                        if (dtAppRslt.Rows.Count > 0)
                        {
                            row["APP_EMP1"] = dtAppRslt.Rows[0]["APP_EMP1"].ToString();
                            row["APP_EMP2"] = dtAppRslt.Rows[0]["APP_EMP2"].ToString();
                            row["APP_EMP3"] = dtAppRslt.Rows[0]["APP_EMP3"].ToString();
                            row["APP_EMP4"] = dtAppRslt.Rows[0]["APP_EMP4"].ToString();
                        }

                        DSYS.TSYS_PROPOSE.TSYS_PROPOSE_INS(paramDS.Tables["RQSTDT"], bizExecute);
                    }

                }
               
                return SYS16A_SER2(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }



        public static DataSet SYS16A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
     
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                { 
            
                    DSYS.TSYS_PROPOSE.TSYS_PROPOSE_UDE(UTIL.GetRowToDt(row), bizExecute);
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
