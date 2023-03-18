using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DLSE
{
    public class LSE_STD_PARTPROC_CONT
    {

        public static DataTable LSE_STD_PARTPROC_CONT_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("SELECT   PLT_CODE ");
                    sbQuery.Append(" , PART_CODE     ");
                    sbQuery.Append(" , PROC_CODE     ");
                    sbQuery.Append(" , CONT_CODE     ");
                    sbQuery.Append(" , PROC_SEQ      ");
                    sbQuery.Append(" , PROC_CONTENTS ");
                    sbQuery.Append(" , REG_DATE      ");
                    sbQuery.Append(" , REG_EMP       ");
                    sbQuery.Append(" , MDFY_DATE     ");
                    sbQuery.Append(" , MDFY_EMP      ");

                    sbQuery.Append(" FROM LSE_STD_PARTPROC_CONT ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE ");
                    sbQuery.Append(" AND PROC_CODE = @PROC_CODE ");
                    //sbQuery.Append(" AND CONT_CODE = @CONT_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;
                        //if (!UTIL.ValidColumn(row, "CONT_CODE")) isHasColumn = false;

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

        public static void LSE_STD_PARTPROC_CONT_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO LSE_STD_PARTPROC_CONT ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append("        PLT_CODE ");
                    sbQuery.Append("      , PART_CODE     ");
                    sbQuery.Append("      , PROC_CODE     ");
                    sbQuery.Append("      , CONT_CODE     ");
                    sbQuery.Append("      , PROC_SEQ      ");
                    sbQuery.Append("      , PROC_CONTENTS ");
                    sbQuery.Append("      , REG_DATE      ");
                    sbQuery.Append("      , REG_EMP       ");
                    sbQuery.Append(" ) ");
                    sbQuery.Append(" VALUES ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append("        @PLT_CODE ");
                    sbQuery.Append("      , @PART_CODE     ");
                    sbQuery.Append("      , @PROC_CODE     ");
                    sbQuery.Append("      , @CONT_CODE     ");
                    sbQuery.Append("      , @PROC_SEQ      ");
                    sbQuery.Append("      , @PROC_CONTENTS ");
                    sbQuery.Append("      , @REG_DATE      ");
                    sbQuery.Append("      , @REG_EMP");
                    sbQuery.Append(" ) ");

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

        public static void LSE_STD_PARTPROC_CONT_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE LSE_STD_PARTPROC_CONT ");
                    sbQuery.Append(" SET PROC_SEQ = @PROC_SEQ ");
                    sbQuery.Append(" , MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND PART_CODE = @PART_CODE  ");
                    sbQuery.Append("   AND PROC_CODE = @PROC_CODE  ");
                    sbQuery.Append("   AND CONT_CODE = @CONT_CODE  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "CONT_CODE")) isHasColumn = false;

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

        public static void LSE_STD_PARTPROC_CONT_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE LSE_STD_PARTPROC_CONT ");
                    sbQuery.Append(" SET PROC_CONTENTS = @PROC_CONTENTS ");
                    sbQuery.Append(" , MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND PART_CODE = @PART_CODE  ");
                    sbQuery.Append("   AND PROC_CODE = @PROC_CODE  ");
                    sbQuery.Append("   AND CONT_CODE = @CONT_CODE  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "CONT_CODE")) isHasColumn = false;

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

        public static void LSE_STD_PARTPROC_CONT_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" DELETE FROM LSE_STD_PARTPROC_CONT ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND PART_CODE = @PART_CODE  ");
                    sbQuery.Append("   AND PROC_CODE = @PROC_CODE  ");
                    sbQuery.Append("   AND CONT_CODE = @CONT_CODE  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "CONT_CODE")) isHasColumn = false;

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

        public static void LSE_STD_PARTPROC_CONT_DEL2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" DELETE FROM LSE_STD_PARTPROC_CONT ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND PART_CODE = @PART_CODE  ");
                    sbQuery.Append("   AND PROC_CODE = @PROC_CODE  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

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
    }

    public class LSE_STD_PARTPROC_CONT_QUERY
    {
        //가용설비 조회
        public static DataTable LSE_STD_PARTPROC_CONT_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    
                    sbQuery.Append(" SELECT M.PLT_CODE");
                    sbQuery.Append(" , M.PART_CODE     ");
                    sbQuery.Append(" , M.PROC_CODE     ");
                    sbQuery.Append(" , M.CONT_CODE     ");
                    sbQuery.Append(" , M.PROC_SEQ      ");
                    sbQuery.Append(" , M.PROC_CONTENTS ");
                    sbQuery.Append(" , M.REG_DATE      ");
                    sbQuery.Append(" , M.REG_EMP       ");
                    sbQuery.Append(" , M.MDFY_DATE     ");
                    sbQuery.Append(" , M.MDFY_EMP      ");
                    sbQuery.Append(" , D.IS_COMPLETE      ");
                    sbQuery.Append(" FROM LSE_STD_PARTPROC_CONT M ");
                    sbQuery.Append("    LEFT JOIN LSE_STD_PARTPROC_CONT_DETAIL D");
                    sbQuery.Append("        ON M.PLT_CODE = D.PLT_CODE");
                    sbQuery.Append("        AND M.CONT_CODE = D.CONT_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        StringBuilder sbWhere = new StringBuilder(" WHERE M.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "M.PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROC_CODE", "M.PROC_CODE = @PROC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CONT_CODE", "M.CONT_CODE = @CONT_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "D.PROD_CODE = @PROD_CODE"));

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
