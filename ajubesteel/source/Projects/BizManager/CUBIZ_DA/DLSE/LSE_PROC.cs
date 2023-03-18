using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DLSE
{
    public class LSE_PROC
    {
        //작업지시 진행( LSE 공정 실적 업데이트)
        public static void LSE_PROC_UPD17(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE LSE_PROC ");
                    sbQuery.Append("    SET   ACT_START_TIME = @ACT_START_TIME ");
                    sbQuery.Append("        , EXE_PLN_START = PLN_START_TIME ");
                    sbQuery.Append("        , EXE_PLN_END = PLN_END_TIME ");
                    sbQuery.Append("        , SCH_FIX = 1 ");
                    sbQuery.Append("        , PROC_STATUS = 1 ");
                    sbQuery.Append("        , ACT_MC_CODE = @ACT_MC_CODE ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("    AND PROD_CODE = @PROD_CODE  ");
                    sbQuery.Append("    AND PART_ID = @PART_ID  ");
                    sbQuery.Append("    AND PROC_ID = @PROC_ID ");


                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PART_ID")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_ID")) isHasColumn = false;

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

        public static void LSE_PROC_UPD22(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE LSE_PROC			 ");
                    sbQuery.Append(" SET   SCH_FIX = @SCH_FIX	 ");
                    sbQuery.Append(" , PLN_MC_CODE = @PLN_MC_CODE");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append(" AND PROD_CODE = @PROD_CODE  ");
                    sbQuery.Append(" AND PART_ID = @PART_ID 	 ");
                    sbQuery.Append(" AND PROC_ID = @PROC_ID		 ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PART_ID")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_ID")) isHasColumn = false;

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
}
