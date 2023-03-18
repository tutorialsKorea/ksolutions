using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BizExecute;

namespace DLSE
{
    public class TPLN_WEEKPLAN
    {
        public static DataTable TPLN_WEEKPLAN_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" , PLAN_CODE ");
                    sbQuery.Append(" , PART_CODE ");
                    sbQuery.Append(" , PROC_CODE");
                    sbQuery.Append(" , PROC_SEQ");
                    sbQuery.Append(" , REG_EMP ");
                    sbQuery.Append(" , REG_DATE");
                    sbQuery.Append(" FROM TPLN_WEEKPLAN ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PLAN_CODE = @PLAN_CODE");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE");
                    sbQuery.Append(" AND PROC_CODE = @PROC_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLAN_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;                        

                        if (isHasColumn == true)
                        {                            

                            DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString(),row).Copy();

                            sourceTable.TableName = "RSLTDT";
                            dsResult.Merge(sourceTable);  
                        }
                    }
                }
                return UTIL.GetDsToDt(dsResult);
            }
            catch(Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }    
        }

        
        public static void TPLN_WEEKPLAN_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" DELETE FROM TPLN_WEEKPLAN ");                    
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PLAN_CODE = @PLAN_CODE");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLAN_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            bizExecute.executeUpdateQuery(sbQuery.ToString(),row);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }


        public static void TPLN_WEEKPLAN_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TPLN_WEEKPLAN");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" , PLAN_CODE ");
                    sbQuery.Append(" , PART_CODE ");
                    sbQuery.Append(" , PROC_CODE ");
                    sbQuery.Append(" , PROC_SEQ");
                    sbQuery.Append(" , REG_DATE");
                    sbQuery.Append(" , REG_EMP ");                    
                    sbQuery.Append(" ) ");
                    sbQuery.Append(" VALUES");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" @PLT_CODE ");
                    sbQuery.Append(" , @PLAN_CODE");
                    sbQuery.Append(" , @PART_CODE");
                    sbQuery.Append(" , @PROC_CODE");
                    sbQuery.Append(" , @PROC_SEQ");
                    sbQuery.Append(" , GETDATE() ");
                    sbQuery.Append(" , " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(")");

                    foreach (DataRow row in dtParam.Rows)
                    {                       
                        bizExecute.executeInsertQuery(sbQuery.ToString(), row);
                    }
                }
            }
            catch(Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }        

    }

    public class TPLN_WEEKPLAN_QUERY
    {
        //품목 별 공정 정보
        public static DataTable TPLN_WEEKPLAN_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE");
                    sbQuery.Append(" ,PART_CODE");
                    sbQuery.Append(" ,PROC_CODE");
                    sbQuery.Append(" ,PROC_SEQ");
                    sbQuery.Append(" FROM TPLN_WEEKPLAN ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "PART_CODE = @PART_CODE"));

                        //sbWhere.Append(" AND DATA_FLAG = 0");
                        sbWhere.Append(" ORDER BY PROC_SEQ");

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
