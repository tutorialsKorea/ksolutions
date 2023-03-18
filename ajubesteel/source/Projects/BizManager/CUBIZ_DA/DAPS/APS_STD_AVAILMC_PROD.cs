using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DAPS
{
    public class APS_STD_AVAILMC_PROD
    {
        public static void APS_STD_AVAILMC_PROD_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO APS_STD_AVAILMC_PROD");
                    sbQuery.Append("(");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" , PROD_CODE ");
                    sbQuery.Append(" , PART_CODE ");
                    sbQuery.Append(" , PROC_CODE");
                    sbQuery.Append(" , MC_CODE");
                    sbQuery.Append(" , MC_SEQ ");
                    sbQuery.Append(" , TACT_TIME");
                    sbQuery.Append(" , PROC_TIME");
                    sbQuery.Append(" , LOAD_FLAG");
                    sbQuery.Append(")");
                    sbQuery.Append(" VALUES");
                    sbQuery.Append("(");
                    sbQuery.Append(" @PLT_CODE");
                    sbQuery.Append(" , @PROD_CODE ");
                    sbQuery.Append(" , @PART_CODE ");
                    sbQuery.Append(" , @PROC_CODE");
                    sbQuery.Append(" , @MC_CODE");
                    sbQuery.Append(" , @MC_SEQ ");
                    sbQuery.Append(" , @TACT_TIME");
                    sbQuery.Append(" , @PROC_TIME");
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

        public static void APS_STD_AVAILMC_PROD_COPY(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO APS_STD_AVAILMC_PROD");
                    sbQuery.Append("(");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" , PROD_CODE ");
                    sbQuery.Append(" , PART_CODE ");
                    sbQuery.Append(" , PROC_CODE");
                    sbQuery.Append(" , MC_CODE");
                    sbQuery.Append(" , MC_SEQ ");
                    sbQuery.Append(" , TACT_TIME");
                    sbQuery.Append(" , PROC_TIME");
                    sbQuery.Append(" , LOAD_FLAG");
                    sbQuery.Append(")");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append("  PART.PLT_CODE");
                    sbQuery.Append(" , @PROD_CODE ");
                    sbQuery.Append(" , PART.PART_CODE ");
                    sbQuery.Append(" , PART.PROC_CODE");
                    sbQuery.Append(" , PART.MC_CODE");
                    sbQuery.Append(" , PART.MC_SEQ ");
                    sbQuery.Append(" , PART.TACT_TIME ");
                    sbQuery.Append(" , PART.PROC_TIME ");
                    sbQuery.Append(" , 0");
                    sbQuery.Append(" FROM APS_STD_AVAILMC_PART 	PART   ");
                    sbQuery.Append("    INNER JOIN LSE_STD_PROC PRO");
                    sbQuery.Append("        ON PART.PLT_CODE = PRO.PLT_CODE");
                    sbQuery.Append("        AND PART.PROC_CODE = PRO.PROC_CODE");
                    sbQuery.Append(" WHERE PART.PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PART.PART_CODE = @PART_CODE");
                    sbQuery.Append(" AND PRO.IS_ASSY='1'");


                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
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

        public static void APS_STD_AVAILMC_PROD_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE  APS_STD_AVAILMC_PROD SET");
                    sbQuery.Append(" TACT_TIME = @TACT_TIME");
                    sbQuery.Append(" , PROC_TIME = @PROC_TIME");
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
        public static void APS_STD_AVAILMC_PROD_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append("DELETE FROM APS_STD_AVAILMC_PROD");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PROD_CODE = @PROD_CODE");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE");
                    //sbQuery.Append(" AND PROC_CODE = @PROC_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;
                        //if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;

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
        public static void APS_STD_AVAILMC_PROD_DEL2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append("DELETE FROM APS_STD_AVAILMC_PROD");
                    sbQuery.Append(" FROM APS_STD_AVAILMC_PROD PROD");
                    sbQuery.Append("    INNER JOIN LSE_STD_PROC PRO");
                    sbQuery.Append("        ON PROD.PLT_CODE = PRO.PLT_CODE");
                    sbQuery.Append("        AND PROD.PROC_CODE = PRO.PROC_CODE");
                    sbQuery.Append(" WHERE PROD.PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PROD.PROD_CODE = @PROD_CODE");
                    sbQuery.Append(" AND PROD.PART_CODE = @PART_CODE");
                    sbQuery.Append(" AND PRO.IS_ASSY='1'");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
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

        public static void APS_STD_AVAILMC_PROD_DEL3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append("DELETE FROM APS_STD_AVAILMC_PROD");
                    sbQuery.Append(" FROM APS_STD_AVAILMC_PROD AP");
                    sbQuery.Append("    INNER JOIN TSHP_WORKORDER TW");
                    sbQuery.Append("        ON AP.PLT_CODE = TW.PLT_CODE");
                    sbQuery.Append("        AND AP.PROD_CODE = TW.PROD_CODE");
                    sbQuery.Append("        AND AP.PART_CODE = TW.PART_CODE");
                    sbQuery.Append("        AND AP.PROC_CODE = TW.PROC_CODE");
                    sbQuery.Append(" WHERE TW.WO_NO = @WO_NO");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "WO_NO")) isHasColumn = false;

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

    public class APS_STD_AVAILMC_PROD_QUERY
    {
        public static DataTable APS_STD_AVAILMC_PROD_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT  A.PLT_CODE");
                    sbQuery.Append(" , A.PROD_CODE ");
                    sbQuery.Append(" , A.PART_CODE ");
                    sbQuery.Append(" , A.PROC_CODE");
                    sbQuery.Append(" , A.MC_CODE");
                    sbQuery.Append(" , MC.MC_NAME");
                    sbQuery.Append(" , A.MC_SEQ ");
                    sbQuery.Append(" , A.TACT_TIME");
                    sbQuery.Append(" , A.PROC_TIME");
                    sbQuery.Append(" , A.LOAD_FLAG");
                    sbQuery.Append(" FROM APS_STD_AVAILMC_PROD A  ");
                    sbQuery.Append("    LEFT JOIN LSE_MACHINE MC");
                    sbQuery.Append("        ON A.PLT_CODE = MC.PLT_CODE");
                    sbQuery.Append("        AND A.MC_CODE = MC.MC_CODE");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE A.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "A.PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "A.PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROC_CODE", "A.PROC_CODE = @PROC_CODE"));

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
        public static DataTable APS_STD_AVAILMC_PROD_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT TOP 1 AP.* ");
                    sbQuery.Append(" FROM APS_STD_AVAILMC_PROD AP	   ");
                    sbQuery.Append("    INNER JOIN TSHP_WORKORDER TW");
                    sbQuery.Append("        ON AP.PLT_CODE = TW.PLT_CODE");
                    sbQuery.Append("        AND AP.PROD_CODE = TW.PROD_CODE");
                    sbQuery.Append("        AND AP.PART_CODE = TW.PART_CODE");
                    sbQuery.Append("        AND AP.PROC_CODE = TW.PROC_CODE");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE AP.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@WO_NO", "TW.WO_NO = @WO_NO"));

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
