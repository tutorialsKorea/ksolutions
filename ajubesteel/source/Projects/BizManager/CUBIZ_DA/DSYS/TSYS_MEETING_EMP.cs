using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSYS
{
    public class TSYS_MEETING_EMP
    {
        public static DataTable TSYS_MEETING_EMP_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE");
                    sbQuery.Append(" ,MEETING_EMP_ID");
                    sbQuery.Append(" ,MEETING_ID    ");
                    sbQuery.Append(" ,EMP_CODE		");
                    sbQuery.Append(" ,IS_READ		");
                    sbQuery.Append(" ,REG_DATE		");
                    sbQuery.Append(" ,REG_EMP		");                    
                    sbQuery.Append(" FROM TSYS_MEETING_EMP");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND MEETING_ID = @MEETING_ID ");
                    sbQuery.Append("   AND EMP_CODE = @EMP_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "MEETING_ID")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "EMP_CODE")) isHasColumn = false;

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
        public static void TSYS_MEETING_EMP_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();


                    sbQuery.Append(" INSERT INTO TSYS_MEETING_EMP");
                    sbQuery.Append(" (PLT_CODE				   ");
                    sbQuery.Append(" ,MEETING_EMP_ID			   ");
                    sbQuery.Append(" ,MEETING_ID				   ");
                    sbQuery.Append(" ,EMP_CODE				   ");
                    sbQuery.Append(" ,IS_READ				   ");
                    sbQuery.Append(" ,REG_DATE				   ");
                    sbQuery.Append(" ,REG_EMP)				   ");
                    sbQuery.Append(" VALUES					   ");
                    sbQuery.Append(" (@PLT_CODE				   ");
                    sbQuery.Append(" ,@MEETING_EMP_ID			   ");
                    sbQuery.Append(" ,@MEETING_ID				   ");
                    sbQuery.Append(" ,@EMP_CODE				   ");
                    sbQuery.Append(" ,'0'   				   ");
                    sbQuery.Append(" ,GETDATE()				   ");
                    sbQuery.Append(" ," + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("  )      				   ");

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

        public static void TSYS_MEETING_EMP_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                { 
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSYS_MEETING_EMP SET ");
                    sbQuery.Append("  IS_READ = '1'");                    
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append("  AND MEETING_ID = @MEETING_ID");
                    sbQuery.Append("  AND EMP_CODE = @EMP_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bizExecute.executeUpdateQuery(sbQuery.ToString(), row);
                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static void TSYS_MEETING_EMP_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" DELETE FROM TSYS_MEETING_EMP ");
                    sbQuery.Append("  WHERE MEETING_ID = @MEETING_ID");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bizExecute.executeUpdateQuery(sbQuery.ToString(), row);
                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

    }

    public class TSYS_MEETING_EMP_QUERY
    {

        public static DataTable TSYS_MEETING_EMP_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT 					 ");
                    sbQuery.Append(" ME.PLT_CODE				 ");
                    sbQuery.Append(" ,MEETING_EMP_ID			 ");
                    sbQuery.Append(" ,MEETING_ID				 ");
                    sbQuery.Append(" ,E.ORG_CODE				 ");
                    sbQuery.Append(" ,O.ORG_NAME				 ");
                    sbQuery.Append(" ,ME.EMP_CODE				 ");
                    sbQuery.Append(" ,E.EMP_NAME				 ");
                    sbQuery.Append(" ,ME.REG_DATE				 ");
                    sbQuery.Append(" ,ME.REG_EMP				 ");
                    sbQuery.Append(" FROM TSYS_MEETING_EMP ME	 ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E	 ");
                    sbQuery.Append(" ON ME.PLT_CODE = E.PLT_CODE ");
                    sbQuery.Append(" AND ME.EMP_CODE = E.EMP_CODE");
                    sbQuery.Append(" 							 ");
                    sbQuery.Append(" LEFT JOIN TSTD_ORG O		 ");
                    sbQuery.Append(" ON E.PLT_CODE = O.PLT_CODE	 ");
                    sbQuery.Append(" AND E.ORG_CODE = O.ORG_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE ME.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@MEETING_ID", "ME.MEETING_ID = @MEETING_ID"));


                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(), row).Copy();

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
