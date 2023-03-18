using BizExecute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSYS
{
    public class TSYS_CONTROL_CONDITION
    {
        public static DataTable TSYS_CONTROL_CONDITION_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" ,MENU_CODE");
                    sbQuery.Append(" ,CONTROL_NAME");
                    sbQuery.Append(" ,CONDITION");
                    sbQuery.Append(" ,REG_EMP");
                    sbQuery.Append(" ,REG_DATE");
                    sbQuery.Append(" FROM TSYS_CONTROL_CONDITION");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND MENU_CODE = @MENU_CODE");
                    sbQuery.Append("   AND CONTROL_NAME = @CONTROL_NAME");
                    sbQuery.Append("   AND REG_EMP = @REG_EMP");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MENU_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "CONTROL_NAME")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "REG_EMP")) isHasColumn = false;

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

        public static DataTable TSYS_CONTROL_CONDITION_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" ,MENU_CODE");
                    sbQuery.Append(" ,CONTROL_NAME");
                    sbQuery.Append(" ,CONDITION");
                    sbQuery.Append(" ,REG_EMP");
                    sbQuery.Append(" ,REG_DATE");
                    sbQuery.Append(" FROM TSYS_CONTROL_CONDITION");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND MENU_CODE = @MENU_CODE");
                    sbQuery.Append("   AND REG_EMP = @REG_EMP");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MENU_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "REG_EMP")) isHasColumn = false;

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

        public static void TSYS_CONTROL_CONDITION_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSYS_CONTROL_CONDITION SET");
                    sbQuery.Append(" CONDITION = @CONDITION");
                    sbQuery.Append(" ,REG_DATE = GETDATE()");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND MENU_CODE = @MENU_CODE");
                    sbQuery.Append(" AND CONTROL_NAME = @CONTROL_NAME");
                    sbQuery.Append(" AND REG_EMP = @REG_EMP");


                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크                        
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MENU_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "CONTROL_NAME")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "REG_EMP")) isHasColumn = false;

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

        public static void TSYS_CONTROL_CONDITION_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TSYS_CONTROL_CONDITION");
                    sbQuery.Append(" (");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" ,MENU_CODE");
                    sbQuery.Append(" ,CONTROL_NAME");
                    sbQuery.Append(" ,CONDITION");
                    sbQuery.Append(" ,REG_EMP");
                    sbQuery.Append(" ,REG_DATE");
                    sbQuery.Append(" )");
                    sbQuery.Append(" VALUES");
                    sbQuery.Append(" (");
                    sbQuery.Append(" @PLT_CODE");
                    sbQuery.Append(" ,@MENU_CODE");
                    sbQuery.Append(" ,@CONTROL_NAME");
                    sbQuery.Append(" ,@CONDITION");
                    sbQuery.Append(" ," + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" ,GETDATE()");
                    sbQuery.Append(" )");


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
    }

    public class TSYS_CONTROL_CONDITION_QUERY
    {

    }
}
