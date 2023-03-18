using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizExecute;
using System.Data;
using System.Data.SqlClient;

namespace DSTD
{
    public class TSTD_REPORT_GOAL
    {

        public static DataTable TSTD_REPORT_GOAL_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" , GOAL_DATE");
                    sbQuery.Append(" , GUBUN");
                    sbQuery.Append(" , VALUE");
                    sbQuery.Append(" FROM TSTD_REPORT_GOAL");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND GOAL_DATE = @GOAL_DATE");
                    sbQuery.Append(" AND GUBUN = @GUBUN");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "GOAL_DATE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "GUBUN")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString(), row).Copy();

                            sourceTable.TableName = "RSLTDT";
                            dsResult.Merge(sourceTable);
                        }
                    }
                }


                return UTIL.GetDsToDt(dsResult);

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 선택한 그룹의 품목 삭제 _ PUR55B_D0A 재고 그룹 리스트에서 삭제
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TSTD_REPORT_GOAL_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" DELETE FROM  TSTD_REPORT_GOAL  ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND GOAL_DATE = @GOAL_DATE");
                    sbQuery.Append(" AND GUBUN = @GUBUN");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "GOAL_DATE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "GUBUN")) isHasColumn = false;

                        if (isHasColumn == true)
                        {                            
                            bizExecute.executeUpdateQuery(sbQuery.ToString(),row);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static void TSTD_REPORT_GOAL_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO TSTD_REPORT_GOAL");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" , GOAL_DATE");
                    sbQuery.Append(" , GUBUN");
                    sbQuery.Append(" , VALUE");
                    sbQuery.Append(" ) ");
                    sbQuery.Append(" VALUES");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" @PLT_CODE");
                    sbQuery.Append(" , @GOAL_DATE");
                    sbQuery.Append(" , @GUBUN");
                    sbQuery.Append(" , @VALUE");
                    sbQuery.Append(" )                         ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bizExecute.executeInsertQuery(sbQuery.ToString(), row);
                    }
                }

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static void TSTD_REPORT_GOAL_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSTD_REPORT_GOAL ");
                    sbQuery.Append(" SET VALUE = @VALUE");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND GOAL_DATE = @GOAL_DATE");
                    sbQuery.Append(" AND GUBUN = @GUBUN");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "GOAL_DATE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "GUBUN")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            bizExecute.executeUpdateQuery(sbQuery.ToString(), row);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }
    }

    public class TSTD_REPORT_GOAL_QUERY
    {

        public static DataTable TSTD_REPORT_GOAL_QUERY_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE							");
                    sbQuery.Append(" , GOAL_DATE");
                    sbQuery.Append(" , GUBUN");
                    sbQuery.Append(" , VALUE");
                    sbQuery.Append(" FROM TSTD_REPORT_GOAL				");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@GOAL_YEAR", "LEFT(GOAL_DATE,4) = @GOAL_YEAR "));
                        sbWhere.Append(UTIL.GetWhere(row, "@YEAR", "LEFT(GOAL_DATE,4) = @YEAR "));
                        sbWhere.Append(UTIL.GetWhere(row, "@GOAL_DATE", "GOAL_DATE = @GOAL_DATE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@GUBUN", "GUBUN = @GUBUN "));

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

                        sourceTable.TableName = "RSLTDT";
                        dsResult.Merge(sourceTable);
                    }
                }


                return UTIL.GetDsToDt(dsResult);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }
    }
}

