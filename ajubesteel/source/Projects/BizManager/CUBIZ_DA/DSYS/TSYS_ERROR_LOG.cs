using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSYS
{
    public class TSYS_ERROR_LOG
    {
        public static void TSYS_ERROR_LOG_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO TSYS_ERROR_LOG");
                    sbQuery.Append(" (						   ");
                    sbQuery.Append(" PLT_CODE				   ");
                    sbQuery.Append(" , SYSTEM_VERSION		   ");
                    sbQuery.Append(" , CLASS_NAME			   ");
                    sbQuery.Append(" , ERR_MESSAGE			   ");
                    sbQuery.Append(" , COMMENT				   ");
                    sbQuery.Append(" , REG_DATE				   ");
                    sbQuery.Append(" , REG_EMP				   ");
                    sbQuery.Append(" )						   ");
                    sbQuery.Append(" VALUES					   ");
                    sbQuery.Append(" (						   ");
                    sbQuery.Append(" @PLT_CODE				   ");
                    sbQuery.Append(" , @SYSTEM_VERSION		   ");
                    sbQuery.Append(" , @CLASS_NAME			   ");
                    sbQuery.Append(" , @ERR_MESSAGE			   ");
                    sbQuery.Append(" , @COMMENT				   ");
                    sbQuery.Append(" , GETDATE()			   ");
                    sbQuery.Append(" , " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" )						   ");

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

        public static void TSYS_ERROR_LOG_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" DELETE FROM TSYS_ERROR_LOG ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND UID = @UID");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크     
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "UID")) isHasColumn = false;

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

    public class TSYS_ERROR_LOG_QUERY
    {
        public static DataTable TSYS_ERROR_LOG_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT UID 		 ");
                    sbQuery.Append(" ,PLT_CODE			 ");
                    sbQuery.Append(" ,SYSTEM_VERSION	 ");
                    sbQuery.Append(" ,CLASS_NAME		 ");
                    sbQuery.Append(" ,ERR_MESSAGE		 ");
                    sbQuery.Append(" ,COMMENT			 ");
                    sbQuery.Append(" ,REG_DATE			 ");
                    sbQuery.Append(" ,REG_EMP			 ");
                    sbQuery.Append(" FROM TSYS_ERROR_LOG ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(" AND REG_DATE < DATEADD(MONTH,-3,GETDATE())");

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
