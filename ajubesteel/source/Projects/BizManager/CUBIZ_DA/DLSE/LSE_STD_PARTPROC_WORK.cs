using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DLSE
{
    public class LSE_STD_PARTPROC_WORK
    {

        public static DataTable LSE_STD_PARTPROC_WORK_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("SELECT   PLT_CODE ");
                    sbQuery.Append("    , PART_CODE        ");
                    sbQuery.Append("    , PROC_CODE        ");
                    sbQuery.Append("    , WORK_CODE        ");
                    sbQuery.Append("    , WORK_GUBUN_CODE  ");
                    sbQuery.Append("    , WORK_CONT_CODE  ");
                    sbQuery.Append("    , WORK_SEQ         ");
                    sbQuery.Append("    , WORK_TIME        ");
                    sbQuery.Append("    , REG_DATE         ");
                    sbQuery.Append("    , REG_EMP          ");
                    sbQuery.Append("    , MDFY_DATE        ");
                    sbQuery.Append("    , MDFY_EMP         ");

                    sbQuery.Append(" FROM LSE_STD_PARTPROC_WORK ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE ");
                    sbQuery.Append(" AND PROC_CODE = @PROC_CODE ");
                    //sbQuery.Append(" AND WORK_CODE = @WORK_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;
                        //if (!UTIL.ValidColumn(row, "WORK_CODE")) isHasColumn = false;

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

        public static void LSE_STD_PARTPROC_WORK_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO LSE_STD_PARTPROC_WORK ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append("        PLT_CODE ");
                    sbQuery.Append("      , PART_CODE        ");
                    sbQuery.Append("      , PROC_CODE        ");
                    sbQuery.Append("      , WORK_CODE        ");
                    sbQuery.Append("      , WORK_GUBUN_CODE  ");
                    sbQuery.Append("      , WORK_CONT_CODE  ");
                    sbQuery.Append("      , WORK_SEQ         ");
                    sbQuery.Append("      , WORK_TIME        ");
                    sbQuery.Append("      , REG_DATE         ");
                    sbQuery.Append("      , REG_EMP          ");
                    sbQuery.Append(" ) ");
                    sbQuery.Append(" VALUES ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append("        @PLT_CODE ");
                    sbQuery.Append("      , @PART_CODE        ");
                    sbQuery.Append("      , @PROC_CODE        ");
                    sbQuery.Append("      , @WORK_CODE        ");
                    sbQuery.Append("      , @WORK_GUBUN_CODE  ");
                    sbQuery.Append("      , @WORK_CONT_CODE  ");
                    sbQuery.Append("      , @WORK_SEQ         ");
                    sbQuery.Append("      , @WORK_TIME        ");
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

        public static void LSE_STD_PARTPROC_WORK_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE LSE_STD_PARTPROC_WORK  ");
                    //sbQuery.Append(" SET WORK_CODE = @WORK_CODE ");
                    sbQuery.Append("   SET WORK_GUBUN_CODE = @WORK_GUBUN_CODE  ");
                    sbQuery.Append("      , WORK_CONT_CODE = @WORK_CONT_CODE  ");
                    sbQuery.Append("   , WORK_SEQ = @WORK_SEQ         ");
                    sbQuery.Append("   , WORK_TIME = @WORK_TIME       ");
                    sbQuery.Append(" , MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND PART_CODE = @PART_CODE  ");
                    sbQuery.Append("   AND PROC_CODE = @PROC_CODE  ");
                    sbQuery.Append("   AND WORK_CODE = @WORK_CODE  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "WORK_CODE")) isHasColumn = false;

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

        public static void LSE_STD_PARTPROC_WORK_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" DELETE FROM LSE_STD_PARTPROC_WORK ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND PART_CODE = @PART_CODE  ");
                    sbQuery.Append("   AND PROC_CODE = @PROC_CODE  ");
                    sbQuery.Append("   AND WORK_CODE = @WORK_CODE  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "WORK_CODE")) isHasColumn = false;

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

        public static void LSE_STD_PARTPROC_WORK_DEL2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" DELETE FROM LSE_STD_PARTPROC_WORK ");
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

    public class LSE_STD_PARTPROC_WORK_QUERY
    {
        //가용설비 조회
        public static DataTable LSE_STD_PARTPROC_WORK_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    
                    sbQuery.Append(" SELECT PLT_CODE");
                    sbQuery.Append("    , PART_CODE        ");
                    sbQuery.Append("    , PROC_CODE        ");
                    sbQuery.Append("    , WORK_CODE        ");
                    sbQuery.Append("    , WORK_GUBUN_CODE  ");
                    sbQuery.Append("    , WORK_SEQ         ");
                    sbQuery.Append("    , WORK_TIME        ");
                    sbQuery.Append("    , REG_DATE         ");
                    sbQuery.Append("    , REG_EMP          ");
                    sbQuery.Append("    , MDFY_DATE        ");
                    sbQuery.Append("    , MDFY_EMP         ");

                    sbQuery.Append(" FROM LSE_STD_PARTPROC_WORK ");
                    foreach (DataRow row in dtParam.Rows)
                    {

                        StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROC_CODE", "PROC_CODE = @PROC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WORK_CODE", "WORK_CODE = @WORK_CODE"));

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
