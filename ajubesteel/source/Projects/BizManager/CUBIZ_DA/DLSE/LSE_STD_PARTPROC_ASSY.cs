using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DLSE
{
    public class LSE_STD_PARTPROC_ASSY
    {

        public static DataTable LSE_STD_PARTPROC_ASSY_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
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
                    sbQuery.Append(" , PROC_CONTENTS     ");
                    sbQuery.Append(" , PROC_REMARK      ");
                    sbQuery.Append(" , INS_METHOD ");
                    sbQuery.Append(" , ASSY_TIME ");
                    sbQuery.Append(" , IMPORTANCE ");
                    sbQuery.Append(" , REG_DATE      ");
                    sbQuery.Append(" , REG_EMP       ");
                    sbQuery.Append(" , MDFY_DATE     ");
                    sbQuery.Append(" , MDFY_EMP      ");

                    sbQuery.Append(" FROM LSE_STD_PARTPROC_ASSY ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE ");
                    sbQuery.Append(" AND PROC_CODE = @PROC_CODE ");

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
                    }
                }


                return UTIL.GetDsToDt(dsResult);

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static void LSE_STD_PARTPROC_ASSY_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO LSE_STD_PARTPROC_ASSY ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append("        PLT_CODE ");
                    sbQuery.Append("      , PART_CODE     ");
                    sbQuery.Append("      , PROC_CODE     ");
                    sbQuery.Append("      , PROC_CONTENTS     ");
                    sbQuery.Append("      , PROC_REMARK      ");
                    sbQuery.Append("      , INS_METHOD ");
                    sbQuery.Append("      , ASSY_TIME ");
                    sbQuery.Append("      , IMPORTANCE ");
                    sbQuery.Append("      , REG_DATE      ");
                    sbQuery.Append("      , REG_EMP       ");
                    sbQuery.Append(" ) ");
                    sbQuery.Append(" VALUES ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append("        @PLT_CODE ");
                    sbQuery.Append("      , @PART_CODE     ");
                    sbQuery.Append("      , @PROC_CODE     ");
                    sbQuery.Append("      , @PROC_CONTENTS     ");
                    sbQuery.Append("      , @PROC_REMARK      ");
                    sbQuery.Append("      , @INS_METHOD ");
                    sbQuery.Append("      , @ASSY_TIME ");
                    sbQuery.Append("      , @IMPORTANCE ");
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

        public static void LSE_STD_PARTPROC_ASSY_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE LSE_STD_PARTPROC_ASSY ");
                    sbQuery.Append(" SET PROC_CONTENTS = @PROC_CONTENTS ");
                    sbQuery.Append(" , PROC_REMARK = @PROC_REMARK ");
                    sbQuery.Append(" , INS_METHOD = @INS_METHOD ");
                    sbQuery.Append(" , ASSY_TIME = @ASSY_TIME ");
                    sbQuery.Append(" , IMPORTANCE = @IMPORTANCE");
                    sbQuery.Append(" , MDFY_DATE = @MDFY_DATE ");
                    sbQuery.Append(" , MDFY_EMP = @MDFY_EMP");
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

        public static void LSE_STD_PARTPROC_ASSY_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" DELETE FROM LSE_STD_PARTPROC_ASSY ");
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

    public class LSE_STD_PARTPROC_ASSY_QUERY
    {
        //가용설비 조회
        public static DataTable LSE_STD_PARTPROC_ASSY_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    
                    sbQuery.Append(" SELECT LSPA.PLT_CODE");
                    sbQuery.Append(" , LSPA.PART_CODE     ");
                    sbQuery.Append(" , LSPA.PROC_CODE     ");
                    sbQuery.Append(" , LSPA.PROC_CONTENTS     ");
                    sbQuery.Append(" , LSPA.PROC_REMARK      ");
                    sbQuery.Append(" , LSPA.INS_METHOD ");
                    sbQuery.Append(" , LSPA.ASSY_TIME ");
                    sbQuery.Append(" , LSPA.IMPORTANCE "); 
                    sbQuery.Append(" , CASE LSPP.PART_CODE WHEN NULL THEN '0' ELSE '1' END AS SEL");
                    sbQuery.Append(" , LSPA.REG_DATE      ");
                    sbQuery.Append(" , LSPA.REG_EMP       ");
                    sbQuery.Append(" , LSPA.MDFY_DATE     ");
                    sbQuery.Append(" , LSPA.MDFY_EMP      ");
                    sbQuery.Append(" FROM LSE_STD_PARTPROC LSPP");
                    sbQuery.Append("    LEFT JOIN LSE_STD_PARTPROC_ASSY LSPA");
                    sbQuery.Append("        ON LSPA.PLT_CODE = LSPP.PLT_CODE");
                    sbQuery.Append("        AND LSPA.PART_CODE = LSPP.PART_CODE");
                    sbQuery.Append("        AND LSPA.PROC_CODE = LSPP.PROC_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        StringBuilder sbWhere = new StringBuilder(" WHERE LSPA.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "LSPP.PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROC_CODE", "LSPP.PROC_CODE = @PROC_CODE"));

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

        public static DataTable LSE_STD_PARTPROC_ASSY_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT LSPA.PLT_CODE");
                    sbQuery.Append(" , LSPA.PART_CODE     ");
                    sbQuery.Append(" , LSPA.PROC_CODE     ");
                    sbQuery.Append(" , LSPA.PROC_CONTENTS     ");
                    sbQuery.Append(" , LSPA.PROC_REMARK      ");
                    sbQuery.Append(" , LSPA.INS_METHOD ");
                    sbQuery.Append(" , LSPA.ASSY_TIME ");
                    sbQuery.Append(" , LSPA.IMPORTANCE ");
                    sbQuery.Append(" , CASE LSPP.PART_CODE WHEN NULL THEN '0' ELSE '1' END AS SEL");
                    sbQuery.Append(" , LSPA.REG_DATE      ");
                    sbQuery.Append(" , LSPA.REG_EMP       ");
                    sbQuery.Append(" , LSPA.MDFY_DATE     ");
                    sbQuery.Append(" , LSPA.MDFY_EMP      ");
                    sbQuery.Append(" FROM LSE_STD_PARTPROC LSPP");
                    sbQuery.Append("    LEFT JOIN LSE_STD_PARTPROC_ASSY LSPA");
                    sbQuery.Append("        ON LSPA.PLT_CODE = LSPP.PLT_CODE");
                    sbQuery.Append("        AND LSPA.PART_CODE = LSPP.PART_CODE");
                    sbQuery.Append("        AND LSPA.PROC_CODE = LSPP.PROC_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        StringBuilder sbWhere = new StringBuilder(" WHERE LSPA.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "LSPP.PART_CODE = @PART_CODE"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@PROC_CODE", "LSPP.PROC_CODE = @PROC_CODE"));

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
