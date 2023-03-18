using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSYS
{
    public class TSYS_BOARD_EMP
    {
        public static DataTable TSYS_BOARD_EMP_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE");
                    sbQuery.Append(" ,BOARD_EMP_ID	");
                    sbQuery.Append(" ,BOARD_ID		");
                    sbQuery.Append(" ,EMP_CODE		");
                    sbQuery.Append(" ,IS_READ		");
                    sbQuery.Append(" ,REG_DATE		");
                    sbQuery.Append(" ,REG_EMP		");                    
                    sbQuery.Append(" FROM TSYS_BOARD_EMP");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND BOARD_ID = @BOARD_ID ");
                    sbQuery.Append("   AND EMP_CODE = @EMP_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "BOARD_ID")) isHasColumn = false;
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
        public static void TSYS_BOARD_EMP_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();


                    sbQuery.Append(" INSERT INTO TSYS_BOARD_EMP");
                    sbQuery.Append(" (PLT_CODE				   ");
                    sbQuery.Append(" ,BOARD_EMP_ID			   ");
                    sbQuery.Append(" ,BOARD_ID				   ");
                    sbQuery.Append(" ,EMP_CODE				   ");
                    sbQuery.Append(" ,IS_READ				   ");
                    sbQuery.Append(" ,REG_DATE				   ");
                    sbQuery.Append(" ,REG_EMP)				   ");
                    sbQuery.Append(" VALUES					   ");
                    sbQuery.Append(" (@PLT_CODE				   ");
                    sbQuery.Append(" ,@BOARD_EMP_ID			   ");
                    sbQuery.Append(" ,@BOARD_ID				   ");
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

        public static void TSYS_BOARD_EMP_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                { 
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSYS_BOARD_EMP SET ");
                    sbQuery.Append("  IS_READ = '1'");                    
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append("  AND BOARD_ID = @BOARD_ID");
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

        public static void TSYS_BOARD_EMP_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" DELETE FROM TSYS_BOARD_EMP ");
                    sbQuery.Append("  WHERE BOARD_ID = @BOARD_ID");

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

    public class TSYS_BOARD_EMP_QUERY
    {

        public static DataTable TSYS_BOARD_EMP_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT 					 ");
                    sbQuery.Append(" BE.PLT_CODE				 ");
                    sbQuery.Append(" ,BOARD_EMP_ID				 ");
                    sbQuery.Append(" ,BOARD_ID					 ");
                    sbQuery.Append(" ,E.ORG_CODE				 ");
                    sbQuery.Append(" ,O.ORG_NAME				 ");
                    sbQuery.Append(" ,BE.EMP_CODE				 ");
                    sbQuery.Append(" ,E.EMP_NAME				 ");
                    sbQuery.Append(" ,BE.REG_DATE				 ");
                    sbQuery.Append(" ,BE.REG_EMP				 ");
                    sbQuery.Append(" FROM TSYS_BOARD_EMP BE		 ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E	 ");
                    sbQuery.Append(" ON BE.PLT_CODE = E.PLT_CODE ");
                    sbQuery.Append(" AND BE.EMP_CODE = E.EMP_CODE");
                    sbQuery.Append(" 							 ");
                    sbQuery.Append(" LEFT JOIN TSTD_ORG O		 ");
                    sbQuery.Append(" ON E.PLT_CODE = O.PLT_CODE	 ");
                    sbQuery.Append(" AND E.ORG_CODE = O.ORG_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE BE.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@BOARD_ID", "BE.BOARD_ID = @BOARD_ID"));


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
