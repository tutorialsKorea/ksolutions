using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DAPS
{
    public class APS_PROC
    {
        public static DataTable APS_PROC_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" , PLT_CODE");
                    sbQuery.Append(" , PROD_CODE");
                    sbQuery.Append(" , PART_CODE");
                    sbQuery.Append(" , PROC_CODE");
                    sbQuery.Append(" , PROC_SEQ");
                    sbQuery.Append(" , TOTAL_TAT");
                    sbQuery.Append(" , RUN_TAT");
                    sbQuery.Append(" , IS_OS");
                    sbQuery.Append(" , LOAD_FLAG");
                    sbQuery.Append(" FROM APS_PROC ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PROD_CODE = @PROD_CODE");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE");
                    sbQuery.Append(" AND PROC_CODE = @PROC_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;

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
        public static void APS_PROC_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO APS_PROC");
                    sbQuery.Append("(");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" , PROD_CODE ");
                    sbQuery.Append(" , PART_CODE ");
                    sbQuery.Append(" , PROC_CODE");
                    sbQuery.Append(" , PARENT_PART");
                    sbQuery.Append(" , TO_PART_CODE");
                    sbQuery.Append(" , PROC_SEQ ");
                    sbQuery.Append(" , TOTAL_TAT ");
                    sbQuery.Append(" , WAIT_TAT ");
                    sbQuery.Append(" , RUN_TAT ");
                    sbQuery.Append(" , IS_OS ");
                    sbQuery.Append(" , LOAD_FLAG");
                    sbQuery.Append(")");
                    sbQuery.Append(" VALUES");
                    sbQuery.Append("(");
                    sbQuery.Append(" @PLT_CODE");
                    sbQuery.Append(" , @PROD_CODE ");
                    sbQuery.Append(" , @PART_CODE ");
                    sbQuery.Append(" , @PROC_CODE");
                    sbQuery.Append(" , @PARENT_PART");
                    sbQuery.Append(" , @TO_PART_CODE");
                    sbQuery.Append(" , @PROC_SEQ ");
                    sbQuery.Append(" , @TOTAL_TAT ");
                    sbQuery.Append(" , 0 ");    //현재 사이트(성원)에서는 사용하지 않으므로 0입력
                    sbQuery.Append(" , @RUN_TAT ");
                    sbQuery.Append(" , @IS_OS ");
                    sbQuery.Append(" , 0");
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

        public static DataTable APS_PROC_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" DELETE FROM APS_PROC ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PROD_CODE = @PROD_CODE");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE");
                    sbQuery.Append(" AND PROC_CODE = @PROC_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            bizExecute.executeUpdateQuery(sbQuery.ToString(), row);
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

        public static void APS_PROC_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE  APS_PROC SET");
                    //sbQuery.Append(" PROC_SEQ = @PROC_SEQ");
                    sbQuery.Append(" TOTAL_TAT = @TOTAL_TAT");
                    sbQuery.Append(" , RUN_TAT = @RUN_TAT");
                    sbQuery.Append(" , IS_OS = @IS_OS");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PROD_CODE = @PROD_CODE");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE");
                    sbQuery.Append(" AND PROC_CODE = @PROC_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            bizExecute.executeInsertQuery(sbQuery.ToString(), row);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static void APS_PROC_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE  APS_PROC SET");
                    sbQuery.Append(" PROC_SEQ = @PROC_SEQ");
                    sbQuery.Append(" , TOTAL_TAT = @TOTAL_TAT");
                    sbQuery.Append(" , RUN_TAT = @RUN_TAT");
                    sbQuery.Append(" , IS_OS = @IS_OS");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PROD_CODE = @PROD_CODE");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE");
                    sbQuery.Append(" AND PROC_CODE = @PROC_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            bizExecute.executeInsertQuery(sbQuery.ToString(), row);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static void APS_PROC_UPD3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE A SET");
                    sbQuery.Append(" A.LOAD_FLAG = @LOAD_FLAG");//
                    sbQuery.Append(" FROM APS_PROC A INNER JOIN TSHP_WORKORDER B");
                    sbQuery.Append("    ON A.PLT_CODE = B.PLT_CODE");
                    sbQuery.Append("    AND A.PROD_CODE = B.PROD_CODE");
                    sbQuery.Append("    AND A.PART_CODE = B.PART_CODE");
                    sbQuery.Append("    AND A.PROC_CODE = B.PROC_CODE");
                    sbQuery.Append(" WHERE B.PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND B.PROD_CODE = @WO_NO");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "WO_NO")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            bizExecute.executeInsertQuery(sbQuery.ToString(), row);
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

    public class APS_PROC_QUERY
    {
        public static DataTable APS_PROC_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" , PLT_CODE");
                    sbQuery.Append(" , PROD_CODE");
                    sbQuery.Append(" , PART_CODE");
                    sbQuery.Append(" , PROC_CODE");
                    sbQuery.Append(" , PROC_SEQ");
                    sbQuery.Append(" , TOTAL_TAT");
                    sbQuery.Append(" , RUN_TAT");
                    sbQuery.Append(" , IS_OS");
                    sbQuery.Append(" , LOAD_FLAG");
                    sbQuery.Append(" FROM APS_PROC ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "PROD_CODE = @PROD_CODE"));
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
