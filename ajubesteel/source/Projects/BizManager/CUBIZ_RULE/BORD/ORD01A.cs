using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BORD
{
    public class ORD01A
    {
        public static DataSet ORD01A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtYear = DORD.TORD_GOAL_YEAR_QUERY.TORD_GOAL_YEAR_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

                if (dtYear.Rows.Count == 0)
                {
                    DataRow row = dtYear.NewRow();
                    row["PLT_CODE"] = ConnInfo.PLT_CODE;
                    row["GOAL_Y"] = DateTime.Now.AddYears(-1).ToString("yyyy");

                    dtYear.Rows.Add(row);
                }

                DataTable dtParam = new DataTable();
                dtParam.Columns.Add("PLT_CODE", typeof(string));
                dtParam.Columns.Add("GOAL_Y", typeof(string));

                string year = (dtYear.Rows[0]["GOAL_Y"].toInt32() + 1).ToString();
                DataRow newRow = dtParam.NewRow();
                newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                newRow["GOAL_Y"] = year;

                dtParam.Rows.Add(newRow);

                //for (int i = 1; 13 > i; i++)
                //{
                //    DataRow paramRow = dtParam.NewRow();
                //    paramRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                //    paramRow["GOAL_YM"] = year + string.Format("{0:D2}", i);

                //    dtParam.Rows.Add(paramRow);
                //}

                DORD.TORD_GOAL_YEAR.TORD_GOAL_YEAR_INS(dtParam, bizExecute);

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "GOAL_Y", year, typeof(string));


                return ORD01A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        //연도별 목표금액 조회
        public static DataSet ORD01A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DORD.TORD_GOAL_YEAR_QUERY.TORD_GOAL_YEAR_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                DataTable dtRsltYear = DORD.TORD_GOAL_YEAR_QUERY.TORD_GOAL_YEAR_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);

                dtRsltYear.TableName = "RSLTDT_YEAR";

                paramDS.Tables.Add(dtRsltYear);

                return paramDS;                
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        //월별 목표금액 조회
        public static DataSet ORD01A_SER2_OLD(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRsltM = DORD.TORD_GOAL_AMT_QUERY.TORD_GOAL_AMT_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
                dtRsltM.TableName = "RSLTDT_MONTH";

                DataTable dtRslt = DORD.TORD_GOAL_AMT_QUERY.TORD_GOAL_AMT_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRsltM);
                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }



        //월별 목표금액 조회
        public static DataSet ORD01A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt_M = DORD.TORD_GOAL_AMT_QUERY.TORD_GOAL_AMT_QUERY4(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt_M.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt_M);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        /// <summary>
        /// 임직원 조회
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet ORD01A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(byte));

                //DataTable dtRslt = DSTD.TSTD_EMPLOYEE_QUERY.TSTD_EMPLOYEE_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                DataTable dtRslt = DSTD.TSTD_BILL_VENDOR_QUERY.TSTD_BILL_VENDOR_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet ORD01A_SER4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(byte));

                DataTable dtRslt = DORD.TORD_GOAL_YEAR_QUERY.TORD_GOAL_YEAR_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }




        //저장
        public static DataSet ORD01A_SAVE_OLD(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DORD.TORD_GOAL_YEAR.TORD_GOAL_YEAR_UPD(paramDS.Tables["RQSTDT_M"], bizExecute);


                if (paramDS.Tables["RQSTDT"].Rows.Count == 0)
                {
                    throw UTIL.SetException("저장할 데이터가 존재 하지 않습니다."
                                   , new System.Diagnostics.StackFrame().GetMethod().Name);
                }

                DataTable dtYear = new DataTable();
                dtYear.Columns.Add("PLT_CODE", typeof(string));
                dtYear.Columns.Add("GOAL_Y", typeof(string));

                DataRow rowYear = dtYear.NewRow();
                rowYear["PLT_CODE"] = ConnInfo.PLT_CODE;
                rowYear["GOAL_Y"] = paramDS.Tables["RQSTDT"].Rows[0]["GOAL_YM"].ToString().Substring(0, 4);
                dtYear.Rows.Add(rowYear);

                DORD.TORD_GOAL_AMT.TORD_GOAL_AMT_DEL(dtYear, bizExecute);

                DORD.TORD_GOAL_AMT.TORD_GOAL_AMT_INS(paramDS.Tables["RQSTDT"], bizExecute);
                
                DataTable dtRsltY = DORD.TORD_GOAL_AMT_QUERY.TORD_GOAL_AMT_QUERY1(dtYear, bizExecute);
                dtRsltY.TableName = "RSLTDT_YEAR";

                DataTable dtRsltM = DORD.TORD_GOAL_AMT_QUERY.TORD_GOAL_AMT_QUERY2(dtYear, bizExecute);
                dtRsltM.TableName = "RSLTDT_MONTH";

                DataTable dtRslt = DORD.TORD_GOAL_AMT_QUERY.TORD_GOAL_AMT_QUERY3(dtYear, bizExecute);
                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRsltY);
                paramDS.Tables.Add(dtRsltM);
                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }



        public static DataSet ORD01A_SAVE(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataTable dtYear = DORD.TORD_GOAL_YEAR.TORD_GOAL_YEAR_SER2(paramDS.Tables["RQSTDT_Y"], bizExecute);

                if (dtYear.Rows.Count > 0)
                {
                    // 등록된 연도가 있으면 기존 목표액 삭제하고 다시 저장

                    DORD.TORD_GOAL_AMT.TORD_GOAL_AMT_DEL2(dtYear, bizExecute);

                    DORD.TORD_GOAL_AMT.TORD_GOAL_AMT_INS(paramDS.Tables["RQSTDT_M"], bizExecute);
                }
                else
                {
                    // 담당자별 연도 및 월별 목표액 추가

                    DORD.TORD_GOAL_YEAR.TORD_GOAL_YEAR_INS(paramDS.Tables["RQSTDT_Y"], bizExecute);

                    DORD.TORD_GOAL_AMT.TORD_GOAL_AMT_INS(paramDS.Tables["RQSTDT_M"], bizExecute);

                }

                return ORD01A_SER(UTIL.GetDtToDs(paramDS.Tables["RQSTDT"]), bizExecute);

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static DataSet ORD01A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DORD.TORD_GOAL_YEAR.TORD_GOAL_YEAR_DEL2(paramDS.Tables["RQSTDT"], bizExecute);

                DORD.TORD_GOAL_AMT.TORD_GOAL_AMT_DEL2(paramDS.Tables["RQSTDT"], bizExecute);


                DataTable dtRsltYear = DORD.TORD_GOAL_YEAR_QUERY.TORD_GOAL_YEAR_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);

                dtRsltYear.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRsltYear);

                return paramDS;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }



    }
}
