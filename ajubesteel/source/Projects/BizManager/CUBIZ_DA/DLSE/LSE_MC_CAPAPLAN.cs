using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DLSE
{
    public class LSE_MC_CAPAPLAN
    {
        public static DataTable LSE_MC_CAPAPLAN_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                                  
                    sbQuery.Append(" SELECT   PLT_CODE ");
                    sbQuery.Append("        , MC_CODE ");
                    sbQuery.Append("        , MC_DATE ");
                    sbQuery.Append("        , FT1 ");
                    sbQuery.Append("        , FT2 ");
                    sbQuery.Append("        , SD1 ");
                    sbQuery.Append("        , SD2");
                    sbQuery.Append("        , SOT");
                    sbQuery.Append("        , TD1");
                    sbQuery.Append("        , TD2");
                    sbQuery.Append("        , TOT");
                    sbQuery.Append("        , SCOMMENT");
                    sbQuery.Append("   FROM LSE_MC_CAPAPLAN");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("    AND MC_CODE = @MC_CODE ");
                    sbQuery.Append("    AND MC_DATE = @MC_DATE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "MC_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MC_DATE")) isHasColumn = false;

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

        public static void LSE_MC_CAPAPLAN_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    
                    sbQuery.Append(" UPDATE LSE_MC_CAPAPLAN ");
                    sbQuery.Append("    SET   PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("        , MC_CODE = @MC_CODE ");
                    sbQuery.Append("        , MC_DATE = @MC_DATE ");
                    sbQuery.Append("        , FT1 = @FT1 ");
                    sbQuery.Append("        , FT2 = @FT2 ");
                    sbQuery.Append("        , FOT = @FOT ");
                    sbQuery.Append("        , SD1 = @SD1 ");
                    sbQuery.Append("        , SD2 = @SD2 ");
                    sbQuery.Append("        , SOT = @SOT ");
                    sbQuery.Append("        , TD1 = @TD1 ");
                    sbQuery.Append("        , TD2 = @TD2 ");
                    sbQuery.Append("        , TOT = @TOT ");
                    sbQuery.Append("        , SCOMMENT = @SCOMMENT ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND MC_CODE = @MC_CODE  ");
                    sbQuery.Append("   AND MC_DATE = @MC_DATE ");


                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "MC_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MC_DATE")) isHasColumn = false;

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



        public static void LSE_MC_CAPAPLAN_DEL3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" DELETE FROM LSE_MC_CAPAPLAN ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND MC_CODE = @MC_CODE");
                    sbQuery.Append(" AND MC_DATE = @MC_DATE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "MC_CODE")) isHasColumn = false;

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


        public static void LSE_MC_CAPAPLAN_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    
                    sbQuery.Append(" INSERT INTO LSE_MC_CAPAPLAN ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append("        PLT_CODE ");
                    sbQuery.Append("      , MC_CODE ");
                    sbQuery.Append("      , MC_DATE ");
                    sbQuery.Append("      , FT1 ");
                    sbQuery.Append("      , FT2 ");
                    sbQuery.Append("      , FOT ");
                    sbQuery.Append("      , SD1 ");
                    sbQuery.Append("      , SD2 ");
                    sbQuery.Append("      , SOT ");
                    sbQuery.Append("      , TD1 ");
                    sbQuery.Append("      , TD2 ");
                    sbQuery.Append("      , TOT ");
                    sbQuery.Append("      , SCOMMENT ");
                    sbQuery.Append(" ) ");
                    sbQuery.Append(" VALUES ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append("        @PLT_CODE ");
                    sbQuery.Append("      , @MC_CODE ");
                    sbQuery.Append("      , @MC_DATE ");
                    sbQuery.Append("      , @FT1 ");
                    sbQuery.Append("      , @FT2 ");
                    sbQuery.Append("      , @FOT ");
                    sbQuery.Append("      , @SD1 ");
                    sbQuery.Append("      , @SD2 ");
                    sbQuery.Append("      , @SOT ");
                    sbQuery.Append("      , @TD1 ");
                    sbQuery.Append("      , @TD2 ");
                    sbQuery.Append("      , @TOT ");
                    sbQuery.Append("      , @SCOMMENT ");
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

    }

    public class LSE_MC_CAPAPLAN_QUERY
    {


     
    }
}
