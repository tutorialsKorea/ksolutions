using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DAPS
{
    public class APS_EXE
    {
        public static DataTable APS_EXE_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT ");
                    sbQuery.Append(" PLT_CODE, ");
                    sbQuery.Append(" VERSION_NO, ");
                    sbQuery.Append(" SCH_UID, ");
                    sbQuery.Append(" SCH_STATE, ");
                    sbQuery.Append(" UPDATE_TIME, ");
                    sbQuery.Append(" UPDATE_EMP, ");
                    sbQuery.Append(" ERROR_MSG ");
                    sbQuery.Append(" FROM APS_EXE ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString(), row).Copy();

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


        public static void APS_EXE_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" exec SAPS_PUT @PLT_CODE, @EMP_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "EMP_CODE")) isHasColumn = false;

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


    public class APS_EXE_QUERY
    {
        public static DataTable APS_EXE_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT ");
                    sbQuery.Append(" SCH_UID ");
                    sbQuery.Append(" FROM APS_PLAN ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PLN_DATE", "SUBSTRING(SCH_UID,4,8) = @PLN_DATE"));

                        sbWhere.Append(" GROUP BY SCH_UID ");
                        sbWhere.Append(" ORDER BY SCH_UID ASC");

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

        public static DataTable APS_EXE_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT ");
                    sbQuery.Append(" PLT_CODE, ");
                    sbQuery.Append(" SCH_UID, ");
                    sbQuery.Append(" SCH_STATE, ");
                    sbQuery.Append(" UPDATE_TIME, ");
                    sbQuery.Append(" UPDATE_EMP, ");
                    sbQuery.Append(" ERROR_MSG, ");
                    sbQuery.Append(" VERSION_NO ");
                    sbQuery.Append(" FROM APS_EXE_LOG ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PLN_DATE", "SUBSTRING(SCH_UID,4,8) = @PLN_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@SCH_UID", "SCH_UID = @SCH_UID"));

                        sbWhere.Append(" AND SCH_STATE = 'C' ");
                        sbWhere.Append(" ORDER BY SCH_UID ASC");

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
