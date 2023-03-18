using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DAPS
{
    public class APS_STD_AVAILMC_PART
    {
        public static void APS_STD_AVAILMC_PART_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO APS_STD_AVAILMC_PART");
                    sbQuery.Append("(");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" , PART_CODE ");
                    sbQuery.Append(" , PROC_CODE");
                    sbQuery.Append(" , MC_CODE");
                    sbQuery.Append(" , MC_SEQ ");
                    sbQuery.Append(" , TACT_TIME ");
                    sbQuery.Append(" , PROC_TIME ");
                    sbQuery.Append(")");
                    sbQuery.Append(" VALUES");
                    sbQuery.Append("(");
                    sbQuery.Append(" @PLT_CODE");
                    sbQuery.Append(" , @PART_CODE ");
                    sbQuery.Append(" , @PROC_CODE");
                    sbQuery.Append(" , @MC_CODE");
                    sbQuery.Append(" , @MC_SEQ ");
                    sbQuery.Append(" , @TACT_TIME ");
                    sbQuery.Append(" , @PROC_TIME ");
                    sbQuery.Append(")");

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
        public static void APS_STD_AVAILMC_PART_COPY(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO APS_STD_AVAILMC_PART");
                    sbQuery.Append("(");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" , PART_CODE ");
                    sbQuery.Append(" , PROC_CODE");
                    sbQuery.Append(" , MC_CODE");
                    sbQuery.Append(" , MC_SEQ ");
                    sbQuery.Append(" , TACT_TIME ");
                    sbQuery.Append(" , PROC_TIME ");
                    sbQuery.Append(")");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" , @PART_CODE ");
                    sbQuery.Append(" , PROC_CODE");
                    sbQuery.Append(" , MC_CODE");
                    sbQuery.Append(" , MC_SEQ ");
                    sbQuery.Append(" , TACT_TIME ");
                    sbQuery.Append(" , PROC_TIME ");

                    sbQuery.Append(" FROM APS_STD_AVAILMC_PART ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("   AND PART_CODE = @O_PART_CODE ");


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

        public static void APS_STD_AVAILMC_PART_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append("DELETE FROM APS_STD_AVAILMC_PART");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE");
                    sbQuery.Append(" AND PROC_CODE = @PROC_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;

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

        public static void APS_STD_AVAILMC_PART_DEL2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append("DELETE FROM APS_STD_AVAILMC_PART");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;

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

      public class APS_STD_AVAILMC_PART_QUERY
    {
        public static DataTable APS_STD_AVAILMC_PART_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT  PLT_CODE");
                    sbQuery.Append(" , PART_CODE ");
                    sbQuery.Append(" , PROC_CODE");
                    sbQuery.Append(" , MC_CODE");
                    sbQuery.Append(" , MC_SEQ ");
                    sbQuery.Append(" , TACT_TIME ");
                    sbQuery.Append(" , PROC_TIME ");
                    sbQuery.Append(" FROM APS_STD_AVAILMC_PART 	   ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROC_CODE", "PROC_CODE = @PROC_CODE"));

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
