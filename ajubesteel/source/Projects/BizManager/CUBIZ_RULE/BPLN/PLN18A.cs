using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BizExecute;

namespace BPLN
{
    public class PLN18A
    {


        /// 프로젝트현황 조회 (TORD_PROJECT)

        public static DataSet PLN18A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DORD.TORD_PROJECT.TORD_PROJECT_SER(paramDS.Tables["RQSTDT"], bizExecute);

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


        public static DataSet PLN18A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DORD.TORD_PROJECT_QUERY.TORD_PROJECT_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

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



        /// 프로젝트현황 진행사항 조회 (TORD_PROJECT_HISTORY)
        public static DataSet PLN18A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DORD.TORD_PROJECT_HISTORY.TORD_PROJECT_HISTORY_SER(paramDS.Tables["RQSTDT"], bizExecute);

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


        public static DataSet PLN18A_SER4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DORD.TORD_PROJECT_HISTORY_QUERY.TORD_PROJECT_HISTORY_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

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





        /// 프로젝트현황 등록 (TORD_PROJECT)

        public static DataSet PLN18A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (paramDS.Tables["RQSTDT"].Rows.Count != 0)
                {
                    DORD.TORD_PROJECT.TORD_PROJECT_INS(paramDS.Tables["RQSTDT"], bizExecute);
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PLN18A_INS2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                if (paramDS.Tables["RQSTDT"].Rows.Count != 0)
                {

                    DataRow row = paramDS.Tables["RQSTDT"].Rows[0];

                    DataTable dtRst = DORD.TORD_PROJECT.TORD_PROJECT_SER(paramDS.Tables["RQSTDT"], bizExecute);

                    if (dtRst.Rows.Count > 0)
                    {
                        DORD.TORD_PROJECT.TORD_PROJECT_UPD(paramDS.Tables["RQSTDT"], bizExecute);
                    }
                    else
                    {

                        string serial = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "PRJ", bizExecute);


                        row["PRJ_CODE"] = serial;


                        DORD.TORD_PROJECT.TORD_PROJECT_INS(paramDS.Tables["RQSTDT"], bizExecute);
                    }

                }
               
                return PLN18A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }




        /// 프로젝트현황 진행사항 등록 (TORD_PROJECT_HISTORY)
        public static DataSet PLN18A_INS3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (paramDS.Tables["RQSTDT"].Rows.Count != 0)
                {
                    DORD.TORD_PROJECT_HISTORY.TORD_PROJECT_HISTORY_INS(paramDS.Tables["RQSTDT"], bizExecute);
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PLN18A_INS4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                if (paramDS.Tables["RQSTDT"].Rows.Count != 0)
                {

                    DataRow row = paramDS.Tables["RQSTDT"].Rows[0];

                    DataTable dtRst = DORD.TORD_PROJECT_HISTORY.TORD_PROJECT_HISTORY_SER(paramDS.Tables["RQSTDT"], bizExecute);

                    if (dtRst.Rows.Count > 0)
                    {
                        DORD.TORD_PROJECT_HISTORY.TORD_PROJECT_HISTORY_UPD(paramDS.Tables["RQSTDT"], bizExecute);
                    }
                    else
                    {

                        string serial = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "PRJH", bizExecute);


                        row["PRJ_HIS_CODE"] = serial;


                        DORD.TORD_PROJECT_HISTORY.TORD_PROJECT_HISTORY_INS(paramDS.Tables["RQSTDT"], bizExecute);
                    }

                }

                return PLN18A_SER4(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }





        public static DataSet PLN18A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
     
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                { 
            
                    DORD.TORD_PROJECT.TORD_PROJECT_UDE(UTIL.GetRowToDt(row), bizExecute);
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }


        public static DataSet PLN18A_DEL2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {

                    DORD.TORD_PROJECT_HISTORY.TORD_PROJECT_HISTORY_UDE(UTIL.GetRowToDt(row), bizExecute);
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
