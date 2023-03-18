using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSHP
{
    public class TSHP_ACTUAL_TOOL
    {

        public static DataTable TSHP_ACTUAL_TOOL_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("SELECT   PLT_CODE ");
                    sbQuery.Append(" , TL_LOT     ");
                    sbQuery.Append(" , WO_NO     ");
                    sbQuery.Append(" , WO_MC     ");
                    sbQuery.Append(" , WO_RPM      ");
                    sbQuery.Append(" , WO_FEED ");
                    sbQuery.Append(" , WO_LIFE ");
                    sbQuery.Append(" , REG_DATE      ");
                    sbQuery.Append(" , REG_EMP       ");

                    sbQuery.Append(" FROM TSHP_ACTUAL_TOOL ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND TL_LOT = @TL_LOT ");
                    sbQuery.Append(" AND WO_NO = @WO_NO ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "TL_LOT")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "WO_NO")) isHasColumn = false;

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

        public static DataTable TSHP_ACTUAL_TOOL_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("SELECT   PLT_CODE ");
                    sbQuery.Append(" , TL_LOT     ");
                    sbQuery.Append(" , WO_NO     ");
                    sbQuery.Append(" , WO_MC     ");
                    sbQuery.Append(" , WO_RPM      ");
                    sbQuery.Append(" , WO_FEED ");
                    sbQuery.Append(" , WO_LIFE ");
                    sbQuery.Append(" , REG_DATE      ");
                    sbQuery.Append(" , REG_EMP       ");

                    sbQuery.Append(" FROM TSHP_ACTUAL_TOOL ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND WO_NO = @WO_NO ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "WO_NO")) isHasColumn = false;

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

        public static void TSHP_ACTUAL_TOOL_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TSHP_ACTUAL_TOOL ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append("        PLT_CODE ");
                    sbQuery.Append("      , TL_LOT     ");
                    sbQuery.Append("      , WO_NO     ");
                    sbQuery.Append("      , WO_MC     ");
                    sbQuery.Append("      , WO_RPM      ");
                    sbQuery.Append("      , WO_FEED ");
                    sbQuery.Append("      , WO_LIFE ");
                    sbQuery.Append("      , REG_DATE      ");
                    sbQuery.Append("      , REG_EMP       ");
                    sbQuery.Append(" ) ");
                    sbQuery.Append(" VALUES ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append("        @PLT_CODE ");
                    sbQuery.Append("      , @TL_LOT     ");
                    sbQuery.Append("      , @WO_NO     ");
                    sbQuery.Append("      , @WO_MC     ");
                    sbQuery.Append("      , @WO_RPM      ");
                    sbQuery.Append("      , @WO_FEED ");
                    sbQuery.Append("      , 0 ");
                    sbQuery.Append("      , GETDATE()      ");
                    sbQuery.Append("      , '" + ConnInfo.UserID + "'");
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

        public static void TSHP_ACTUAL_TOOL_INS2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TSHP_ACTUAL_TOOL ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append("        PLT_CODE ");
                    sbQuery.Append("      , TL_LOT     ");
                    sbQuery.Append("      , WO_NO     ");
                    sbQuery.Append("      , WO_MC     ");
                    sbQuery.Append("      , WO_RPM      ");
                    sbQuery.Append("      , WO_FEED ");
                    sbQuery.Append("      , WO_LIFE ");
                    sbQuery.Append("      , REG_DATE      ");
                    sbQuery.Append("      , REG_EMP       ");
                    sbQuery.Append(" ) ");
                    sbQuery.Append(" VALUES ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append("        @PLT_CODE ");
                    sbQuery.Append("      , @TL_LOT     ");
                    sbQuery.Append("      , @WO_NO     ");
                    sbQuery.Append("      , @WO_MC     ");
                    sbQuery.Append("      , @WO_RPM      ");
                    sbQuery.Append("      , @WO_FEED ");
                    sbQuery.Append("      , @TL_LIFE_USE ");
                    sbQuery.Append("      , GETDATE()      ");
                    sbQuery.Append("      , '" + ConnInfo.UserID + "'");
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

        public static void TSHP_ACTUAL_TOOL_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSHP_ACTUAL_TOOL ");
                    sbQuery.Append(" SET WO_RPM = @WO_RPM ");
                    sbQuery.Append(" , WO_FEED = @WO_FEED ");
                    //sbQuery.Append(" , WO_LIFE = @WO_LIFE ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND TL_LOT = @TL_LOT  ");
                    sbQuery.Append("   AND WO_NO = @WO_NO  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "TL_LOT")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "WO_NO")) isHasColumn = false;

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

        public static void TSHP_ACTUAL_TOOL_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSHP_ACTUAL_TOOL ");
                    sbQuery.Append(" SET WO_LIFE = @TL_LIFE_USE ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND TL_LOT = @TL_LOT  ");
                    sbQuery.Append("   AND WO_NO = @WO_NO  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "TL_LOT")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "WO_NO")) isHasColumn = false;

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


        public static void TSHP_ACTUAL_TOOL_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" DELETE FROM TSHP_ACTUAL_TOOL ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND TL_LOT = @TL_LOT  ");
                    sbQuery.Append("   AND WO_NO = @WO_NO  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "TL_LOT")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "WO_NO")) isHasColumn = false;

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

    public class TSHP_ACTUAL_TOOL_QUERY
    {
        //가용설비 조회
        public static DataTable TSHP_ACTUAL_TOOL_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT T.PLT_CODE            ");
                    sbQuery.Append("       , T.WO_NO             ");
                    sbQuery.Append("       , T.TL_LOT             ");
                    sbQuery.Append("       , T.WO_RPM            ");
                    sbQuery.Append("       , T.WO_FEED            ");
                    sbQuery.Append("       , T.WO_LIFE            ");
                    sbQuery.Append("       , T.WO_MC            ");
                    sbQuery.Append("       , T.REG_EMP             ");
                    sbQuery.Append("       , T.REG_DATE            ");
                    sbQuery.Append("       , T.REG_EMP             ");
                    sbQuery.Append("       , TT.TL_LIFE           ");
                    sbQuery.Append("       , TT.YPGO_DATE            ");
                    sbQuery.Append("       , TT.TL_STAT            ");
                    sbQuery.Append("       , ST.TL_CODE           ");
                    sbQuery.Append("       , ST.TL_NAME            ");
                    sbQuery.Append("       , ST.TL_LENGTH            ");
                    sbQuery.Append("       , ST.HOLDER            ");
                    sbQuery.Append("  FROM TSHP_ACTUAL_TOOL  T    ");
                    sbQuery.Append("    LEFT JOIN TTOL_TOOLLIST TT    ");
                    sbQuery.Append("        ON T.PLT_CODE = TT.PLT_CODE    ");
                    sbQuery.Append("        AND T.TL_LOT = TT.TL_LOT    ");
                    sbQuery.Append("    LEFT JOIN TSTD_TOOL ST    ");
                    sbQuery.Append("        ON TT.PLT_CODE = ST.PLT_CODE    ");
                    sbQuery.Append("        AND TT.TL_CODE = ST.TL_CODE    ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE T.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@TL_CODE", "TT.TL_CODE = @TL_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@TL_LOT", "T.TL_LOT = @TL_LOT"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WO_NO", "T.WO_NO = @WO_NO"));

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
