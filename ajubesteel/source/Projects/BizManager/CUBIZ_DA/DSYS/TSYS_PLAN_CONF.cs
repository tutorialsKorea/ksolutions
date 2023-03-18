using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSYS
{
    public class TSYS_PLAN_CONF
    {
        public static DataTable TSYS_PLAN_CONF_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE		");
                    sbQuery.Append(" ,PLN_DATE				");
                    sbQuery.Append(" ,TOTAL_PERSONS			");
                    sbQuery.Append(" ,ACCIDENT				");
                    sbQuery.Append(" ,PERSONS				");
                    sbQuery.Append(" ,ACCIDENT_CONTENTS		");
                    sbQuery.Append(" ,MORNING				");
                    sbQuery.Append(" ,AFTERNOON				");
                    sbQuery.Append(" ,OVERTIME				");
                    sbQuery.Append(" ,SCOMMENT				");
                    sbQuery.Append(" ,REG_DATE				");
                    sbQuery.Append(" ,REG_EMP				");
                    sbQuery.Append(" ,MDFY_DATE				");
                    sbQuery.Append(" ,MDFY_EMP				");
                    sbQuery.Append(" ,DEL_DATE				");
                    sbQuery.Append(" ,DEL_EMP				");
                    sbQuery.Append(" ,DATA_FLAG				");
                    sbQuery.Append(" FROM TSYS_PLAN_CONF    ");
                    sbQuery.Append(" WHERE PLT_CODE  = @PLT_CODE");
                    sbQuery.Append(" AND DATA_FLAG  = @DATA_FLAG");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "DATA_FLAG")) isHasColumn = false;

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

        public static DataTable TSYS_PLAN_CONF_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE		");
                    sbQuery.Append(" ,PLN_DATE				");
                    sbQuery.Append(" ,TOTAL_PERSONS			");
                    sbQuery.Append(" ,ACCIDENT				");
                    sbQuery.Append(" ,PERSONS				");
                    sbQuery.Append(" ,ACCIDENT_CONTENTS		");
                    sbQuery.Append(" ,MORNING				");
                    sbQuery.Append(" ,AFTERNOON				");
                    sbQuery.Append(" ,OVERTIME				");
                    sbQuery.Append(" ,SCOMMENT				");
                    sbQuery.Append(" ,REG_DATE				");
                    sbQuery.Append(" ,REG_EMP				");
                    sbQuery.Append(" ,MDFY_DATE				");
                    sbQuery.Append(" ,MDFY_EMP				");
                    sbQuery.Append(" ,DEL_DATE				");
                    sbQuery.Append(" ,DEL_EMP				");
                    sbQuery.Append(" ,DATA_FLAG				");
                    sbQuery.Append(" FROM TSYS_PLAN_CONF    ");
                    sbQuery.Append(" WHERE PLT_CODE  = @PLT_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;

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

        public static void TSYS_PLAN_CONF_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("INSERT INTO TSYS_PLAN_CONF");
                    sbQuery.Append("(PLT_CODE				  ");
                    sbQuery.Append(",PLN_DATE				  ");
                    sbQuery.Append(",TOTAL_PERSONS			  ");
                    sbQuery.Append(",ACCIDENT				  ");
                    sbQuery.Append(",PERSONS				  ");
                    sbQuery.Append(",ACCIDENT_CONTENTS		  ");
                    sbQuery.Append(",MORNING				  ");
                    sbQuery.Append(",AFTERNOON				  ");
                    sbQuery.Append(",OVERTIME				  ");
                    sbQuery.Append(",SCOMMENT				  ");
                    sbQuery.Append(",REG_DATE				  ");
                    sbQuery.Append(",REG_EMP				  ");
                    sbQuery.Append(",DATA_FLAG)				  ");
                    sbQuery.Append("VALUES					  ");
                    sbQuery.Append("(			    		  ");
                    sbQuery.Append(" @PLT_CODE				  ");
                    sbQuery.Append(",@PLN_DATE				  ");
                    sbQuery.Append(",@TOTAL_PERSONS			  ");
                    sbQuery.Append(",@ACCIDENT				  ");
                    sbQuery.Append(",@PERSONS				  ");
                    sbQuery.Append(",@ACCIDENT_CONTENTS		  ");
                    sbQuery.Append(",@MORNING				  ");
                    sbQuery.Append(",@AFTERNOON				  ");
                    sbQuery.Append(",@OVERTIME				  ");
                    sbQuery.Append(",@SCOMMENT				  ");
                    sbQuery.Append(",GETDATE()				  ");
                    sbQuery.Append(" ," + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(",@DATA_FLAG	    		  ");
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

        public static void TSYS_PLAN_CONF_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("UPDATE TSYS_PLAN_CONF				   ");
                    sbQuery.Append("SET PLN_DATE = @PLN_DATE			   ");
                    sbQuery.Append(",TOTAL_PERSONS = @TOTAL_PERSONS		   ");
                    sbQuery.Append(",ACCIDENT = @ACCIDENT				   ");
                    sbQuery.Append(",PERSONS = @PERSONS 				   ");
                    sbQuery.Append(",ACCIDENT_CONTENTS = @ACCIDENT_CONTENTS");
                    sbQuery.Append(",MORNING = @MORNING				   ");
                    sbQuery.Append(",AFTERNOON = @AFTERNOON				   ");
                    sbQuery.Append(",OVERTIME = @OVERTIME				   ");
                    sbQuery.Append(",SCOMMENT = @SCOMMENT				   ");
                    sbQuery.Append(",MDFY_DATE = GETDATE()				   ");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(",DATA_FLAG = @DATA_FLAG			   ");
                    sbQuery.Append("WHERE PLT_CODE = @PLT_CODE			   ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;

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

        public static void TSYS_PLAN_CONF_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSYS_PLAN_CONF");
                    sbQuery.Append(" SET");
                    sbQuery.Append(" , DEL_DATE = GETDATE()");
                    sbQuery.Append(" , DEL_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , DATA_FLAG = @DATA_FLAG");
                    sbQuery.Append("WHERE PLT_CODE = @PLT_CODE			   ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;

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

    public class TSYS_PLAN_CONF_QUERY
    {
    }
}
