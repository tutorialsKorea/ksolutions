using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSYS
{
    public class TSYS_USER_CUSTOM_REPORT_DETAIL
    {
        public static bool TSYS_USER_CUSTOM_REPORT_DETAIL_CREATE(BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.AppendLine(" IF NOT EXISTS ( ");
                    sbQuery.AppendLine("  SELECT * FROM INFORMATION_SCHEMA.tables WITH(NOLOCK) WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'TSYS_USER_CUSTOM_REPORT_DETAIL' ) ");
                    sbQuery.AppendLine("  exec(' ");
                    sbQuery.AppendLine(" 	CREATE TABLE TSYS_USER_CUSTOM_REPORT_DETAIL ");
                    sbQuery.AppendLine(" 	( ");
                    sbQuery.AppendLine(" 		PLT_CODE VARCHAR(3) ");
                    sbQuery.AppendLine(" 		,CUS_ID VARCHAR(20) ");
                    sbQuery.AppendLine(" 		, CONNET_COLUMN_NAME VARCHAR(20) ");
                    sbQuery.AppendLine(" 		,START_CELL_NAME VARCHAR(5) ");
                    sbQuery.AppendLine(" 		,CONSTRAINT PRI_TSYS_USER_CUSTOM_REPORT_DETAIL_PCS PRIMARY KEY (PLT_CODE,CUS_ID,CONNET_COLUMN_NAME) ");
                    sbQuery.AppendLine(" 	) ");
                    sbQuery.AppendLine("  ') ");
                    //sbQuery.AppendLine("  GO ");
                    //sbQuery.AppendLine(" GO ");
                    
                    return bizExecute.executeInsertQuery(sbQuery.ToString());
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataTable TSYS_USER_CUSTOM_REPORT_DETAIL_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" , CUS_ID");
                    sbQuery.Append(" , START_CELL_NAME ");
                    sbQuery.Append(" , CONNET_COLUMN_NAME");
                    sbQuery.Append(" FROM TSYS_USER_CUSTOM_REPORT_DETAIL");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND CUS_ID = @CUS_ID");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "CUS_ID")) isHasColumn = false;

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

        public static void TSYS_USER_CUSTOM_REPORT_DETAIL_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("DELETE FROM TSYS_USER_CUSTOM_REPORT_DETAIL");                    
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND CUS_ID = @CUS_ID");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "CUS_ID")) isHasColumn = false;

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

        public static void TSYS_USER_CUSTOM_REPORT_DETAIL_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO TSYS_USER_CUSTOM_REPORT_DETAIL");
                    sbQuery.Append(" (");
                    sbQuery.Append(" PLT_CODE ");
                    sbQuery.Append(" , CUS_ID ");
                    sbQuery.Append(" , START_CELL_NAME");
                    sbQuery.Append(" , CONNET_COLUMN_NAME ");
                    sbQuery.Append(" )");
                    sbQuery.Append(" VALUES ");
                    sbQuery.Append(" (");
                    sbQuery.Append(" @PLT_CODE ");
                    sbQuery.Append(" , @CUS_ID ");
                    sbQuery.Append(" , @START_CELL_NAME");
                    sbQuery.Append(" , @CONNET_COLUMN_NAME ");
                    sbQuery.Append(") ");

                    foreach (DataRow row in dtParam.Rows)
                    {                                                
                        bizExecute.executeInsertQuery(sbQuery.ToString(),row);
                    }
                }

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }
    }
}
