using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DLSE
{
    public class LSE_STD_PARTPROC_PRE
    {

        public static DataTable LSE_STD_PARTPROC_PRE_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("SELECT   PLT_CODE ");
                    sbQuery.Append(" , PART_CODE   ");
                    sbQuery.Append(" , PROC_CODE   ");
                    sbQuery.Append(" , PRE_CODE    ");
                    sbQuery.Append(" , PRE_SPEC    ");
                    sbQuery.Append(" , PRE_CHECK   ");
                    sbQuery.Append(" , REG_DATE    ");
                    sbQuery.Append(" , REG_EMP     ");
                    sbQuery.Append(" , MDFY_DATE   ");
                    sbQuery.Append(" , MDFY_EMP    ");

                    sbQuery.Append(" FROM LSE_STD_PARTPROC_PRE ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE ");
                    sbQuery.Append(" AND PROC_CODE = @PROC_CODE ");
                    sbQuery.Append(" AND PRE_CODE = @PRE_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PRE_CODE")) isHasColumn = false;

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

        public static void LSE_STD_PARTPROC_PRE_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO LSE_STD_PARTPROC_PRE ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append("        PLT_CODE ");
                    sbQuery.Append("      , PART_CODE   ");
                    sbQuery.Append("      , PROC_CODE   ");
                    sbQuery.Append("      , PRE_CODE    ");
                    sbQuery.Append("      , PRE_SPEC    ");
                    sbQuery.Append("      , PRE_CHECK   ");
                    sbQuery.Append("      , REG_DATE    ");
                    sbQuery.Append("      , REG_EMP     ");
                    sbQuery.Append(" ) ");
                    sbQuery.Append(" VALUES ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append("        @PLT_CODE ");
                    sbQuery.Append("      , @PART_CODE   ");
                    sbQuery.Append("      , @PROC_CODE   ");
                    sbQuery.Append("      , @PRE_CODE    ");
                    sbQuery.Append("      , @PRE_SPEC    ");
                    sbQuery.Append("      , @PRE_CHECK   ");
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

        public static void LSE_STD_PARTPROC_PRE_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE LSE_STD_PARTPROC_PRE  ");
                    //sbQuery.Append(" SET PRE_CODE = @PRE_CODE ");
                    sbQuery.Append("  SET PRE_SPEC = @PRE_SPEC ");
                    sbQuery.Append("  , PRE_CHECK = @PRE_CHECK ");
                    sbQuery.Append("  , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("  , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND PART_CODE = @PART_CODE  ");
                    sbQuery.Append("   AND PROC_CODE = @PROC_CODE  ");
                    sbQuery.Append("   AND PRE_CODE = @PRE_CODE  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PRE_CODE")) isHasColumn = false;

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

        public static void LSE_STD_PARTPROC_PRE_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE LSE_STD_PARTPROC_PRE ");
                    sbQuery.Append(" SET PROC_CONTENTS = @PROC_CONTENTS ");
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

    public class LSE_STD_PARTPROC_PRE_QUERY
    {
        //가용설비 조회
        public static DataTable LSE_STD_PARTPROC_PRE_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    
                    sbQuery.Append(" SELECT LSPP.PLT_CODE");
                    sbQuery.Append(" , LSPP.PART_CODE   ");
                    sbQuery.Append(" , LSPP.PROC_CODE   ");
                    //sbQuery.Append(" , LSPP.PRE_CODE    ");
                    sbQuery.Append(" , CD.CD_CODE AS PRE_CODE    ");
                    sbQuery.Append(" , LSPP.PRE_SPEC    ");
                    sbQuery.Append(" , LSPP.PRE_CHECK   ");
                    sbQuery.Append(" , LSPP.REG_DATE    ");
                    sbQuery.Append(" , LSPP.REG_EMP     ");
                    sbQuery.Append(" , LSPP.MDFY_DATE   ");
                    sbQuery.Append(" , LSPP.MDFY_EMP    ");
                    sbQuery.Append(" FROM (SELECT CD_CODE FROM TSTD_CODES WHERE CAT_CODE='C052') CD ");
                    sbQuery.Append("     LEFT JOIN LSE_STD_PARTPROC_PRE LSPP");
                    sbQuery.Append("         ON CD.CD_CODE = LSPP.PRE_CODE");
                    sbQuery.Append("         AND LSPP.PLT_CODE = @PLT_CODE");
                    sbQuery.Append("         AND LSPP.PART_CODE = @PART_CODE");
                    sbQuery.Append("         AND LSPP.PROC_CODE = @PROC_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString(), row).Copy();

                            sourceTable.TableName = "RSLTDT";
                            dsResult.Merge(sourceTable);
                        }

                        //StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        //sbWhere.Append(UTIL.GetWhere(row, "@S_HOLI_DATE,@E_HOLI_DATE", "HOLI_DATE BETWEEN @S_HOLI_DATE AND @E_HOLI_DATE"));

                        //DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

                        //sourceTable.TableName = "RSLTDT";
                        //dsResult.Merge(sourceTable);

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
