using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSTD
{
    public class TSTD_ACTUAL_TOOL
    {
        public static DataTable TSTD_ACTUAL_TOOL_SER1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT   PLT_CODE            ");
                    sbQuery.Append("       , PART_CODE             ");
                    sbQuery.Append("       , PROC_CODE             ");
                    sbQuery.Append("       , TL_LOT             ");
                    sbQuery.Append("       , WO_RPM            ");
                    sbQuery.Append("       , WO_FEED            ");
                    sbQuery.Append("       , REG_DATE            ");
                    sbQuery.Append("       , REG_EMP             ");
                    sbQuery.Append("  FROM TSTD_ACTUAL_TOOL              ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE   ");
                    sbQuery.Append("   AND PART_CODE = @PART_CODE     ");
                    sbQuery.Append("   AND PROC_CODE = @PROC_CODE     ");
                    sbQuery.Append("   AND TL_LOT = @TL_LOT     ");
                    sbQuery.Append("   AND DATA_FLAG = 0          ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "TL_LOT")) isHasColumn = false;

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

        public static void TSTD_ACTUAL_TOOL_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSTD_ACTUAL_TOOL");
                    sbQuery.Append(" SET WO_RPM = @WO_RPM           ");
                    sbQuery.Append("   , WO_FEED = @WO_FEED           ");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append("   AND PART_CODE = @PART_CODE     ");
                    sbQuery.Append("   AND PROC_CODE = @PROC_CODE     ");
                    sbQuery.Append("   AND TL_LOT = @TL_LOT     ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "TL_LOT")) isHasColumn = false;

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

        public static void TSTD_ACTUAL_TOOL_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append("DELETE TSTD_ACTUAL_TOOL ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append("   AND PART_CODE = @PART_CODE     ");
                    sbQuery.Append("   AND PROC_CODE = @PROC_CODE     ");
                    sbQuery.Append("   AND TL_LOT = @TL_LOT     ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "TL_LOT")) isHasColumn = false;

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

        public static void TSTD_ACTUAL_TOOL_COPY(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO TSHP_ACTUAL_TOOL");
                    sbQuery.Append(" (");
                    sbQuery.Append(" PLT_CODE            ");
                    sbQuery.Append(" , TL_LOT             ");
                    sbQuery.Append(" , WO_NO             ");
                    sbQuery.Append(" , WO_MC             ");
                    sbQuery.Append(" , WO_RPM            ");
                    sbQuery.Append(" , WO_FEED            ");
                    sbQuery.Append(" , REG_DATE            ");
                    sbQuery.Append(" , REG_EMP             ");
                    sbQuery.Append(" )");
                    sbQuery.Append(" SELECT  ");
                    sbQuery.Append(" PLT_CODE            ");
                    sbQuery.Append(" , TL_LOT             ");
                    sbQuery.Append(" , @WO_NO             ");
                    sbQuery.Append(" , @WO_MC             ");
                    sbQuery.Append(" , @WO_RPM            ");
                    sbQuery.Append(" , @WO_FEED            ");
                    sbQuery.Append(" , GETDATE() ");
                    sbQuery.Append(" ," + UTIL.GetValidValue(ConnInfo.UserID));

                    sbQuery.Append(" FROM TSTD_ACTUAL_TOOL");
                    sbQuery.Append(" WHERE PART_CODE = @PART_CODE");
                    sbQuery.Append(" AND PROC_CODE = @PROC_CODE");

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

        public static void TSTD_ACTUAL_TOOL_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO TSTD_ACTUAL_TOOL");
                    sbQuery.Append(" (");
                    sbQuery.Append(" PLT_CODE            ");
                    sbQuery.Append(" , PART_CODE             ");
                    sbQuery.Append(" , PROC_CODE             ");
                    sbQuery.Append(" , TL_LOT             ");
                    sbQuery.Append(" , WO_RPM            ");
                    sbQuery.Append(" , WO_FEED            ");
                    sbQuery.Append(" , REG_DATE            ");
                    sbQuery.Append(" , REG_EMP             ");
                    sbQuery.Append(" )");
                    sbQuery.Append(" VALUES ");
                    sbQuery.Append(" (");
                    sbQuery.Append(" @PLT_CODE            ");
                    sbQuery.Append(" , @PART_CODE             ");
                    sbQuery.Append(" , @PROC_CODE             ");
                    sbQuery.Append(" , @TL_LOT             ");
                    sbQuery.Append(" , @WO_RPM            ");
                    sbQuery.Append(" , @WO_FEED            ");
                    sbQuery.Append(" , GETDATE() ");
                    sbQuery.Append(" ," + UTIL.GetValidValue(ConnInfo.UserID));

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

    public class TSTD_ACTUAL_TOOL_QUERY
    {
        public static DataTable TSTD_ACTUAL_TOOL_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT T.PLT_CODE            ");
                    sbQuery.Append("       , T.PART_CODE             ");
                    sbQuery.Append("       , T.PROC_CODE             ");
                    sbQuery.Append("       , T.TL_LOT             ");
                    sbQuery.Append("       , T.WO_RPM            ");
                    sbQuery.Append("       , T.WO_FEED            ");
                    sbQuery.Append("       , T.REG_DATE            ");
                    sbQuery.Append("       , T.REG_EMP             ");
                    sbQuery.Append("       , T.REG_DATE            ");
                    sbQuery.Append("       , T.REG_EMP             ");
                    sbQuery.Append("       , T.MDFY_DATE           ");
                    sbQuery.Append("       , T.MDFY_EMP            ");
                    sbQuery.Append("       , TT.TL_LIFE           ");
                    sbQuery.Append("       , TT.YPGO_DATE            ");
                    sbQuery.Append("       , TT.TL_STAT            ");
                    sbQuery.Append("       , ST.TL_CODE           ");
                    sbQuery.Append("       , ST.TL_NAME            ");
                    sbQuery.Append("       , ST.TL_LENGTH            ");
                    sbQuery.Append("       , ST.HOLDER            ");
                    sbQuery.Append("  FROM TSTD_ACTUAL_TOOL  T    ");
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
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "T.PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROC_CODE", "T.PROC_CODE = @PROC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@TL_LOT", "T.TL_LOT = @TL_LOT"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WO_NO", "TT.WO_NO = @WO_NO"));

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

        public static DataTable TSTD_ACTUAL_TOOL_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT AT.PLT_CODE            ");
                    sbQuery.Append("       , AT.PART_CODE             ");
                    sbQuery.Append("       , AT.PROC_CODE             ");
                    sbQuery.Append("       , AT.TL_LOT             ");
                    sbQuery.Append("       , AT.WO_RPM            ");
                    sbQuery.Append("       , AT.WO_FEED            ");
                    sbQuery.Append("       , AT.REG_DATE            ");
                    sbQuery.Append("       , AT.REG_EMP             ");
                    sbQuery.Append("       , AT.REG_DATE            ");
                    sbQuery.Append("       , AT.REG_EMP             ");
                    sbQuery.Append("       , AT.MDFY_DATE           ");
                    sbQuery.Append("       , AT.MDFY_EMP            ");
                    sbQuery.Append("       , T.TL_CODE             ");
                    sbQuery.Append("       , T.TL_NAME             ");
                    sbQuery.Append("       , T.TL_TYPE             ");
                    sbQuery.Append("       , T.TL_LTYPE            ");
                    sbQuery.Append("       , T.TL_MTYPE            ");
                    sbQuery.Append("       , T.TL_STYPE            ");
                    sbQuery.Append("       , T.TL_SPEC             ");
                    sbQuery.Append("       , T.TL_MIN              ");
                    sbQuery.Append("       , T.TL_MAX              ");
                    sbQuery.Append("       , T.TL_DANGER_QTY       ");
                    sbQuery.Append("       , T.TL_MAKER            ");
                    sbQuery.Append("       , T.TL_UNITCOST         ");
                    sbQuery.Append("       , T.TL_UNIT             ");
                    sbQuery.Append("       , T.HOLDER              ");
                    sbQuery.Append("       , T.TL_LENGTH           ");
                    sbQuery.Append("       , T.MAIN_VND            ");
                    sbQuery.Append("       , T.TL_QTY              ");
                    sbQuery.Append("       , T.TL_D_QTY            ");
                    sbQuery.Append("       , T.TL_IMAGE            ");
                    sbQuery.Append("       , T.REG_DATE          ");
                    sbQuery.Append("       , T.REG_EMP           ");
                    sbQuery.Append("       , T.MDFY_DATE         ");
                    sbQuery.Append("       , T.MDFY_EMP          ");
                    sbQuery.Append("       , TL.TL_LOT             ");
                    sbQuery.Append("       , T.SCOMMENT            ");
                    sbQuery.Append("       , TL.WO_NO             ");
                    sbQuery.Append("       , TL.TL_CODE           ");
                    sbQuery.Append("       , TL.TL_LIFE            ");
                    sbQuery.Append("       , TL.TL_STAT           ");
                    sbQuery.Append("       , TL.YPGO_DATE           ");
                    sbQuery.Append("       , TL.SCOMMENT          ");
                    sbQuery.Append("       , TL.REG_DATE          ");
                    sbQuery.Append("       , TL.REG_EMP           ");
                    sbQuery.Append("       , TL.MDFY_DATE         ");
                    sbQuery.Append("       , TL.MDFY_EMP          ");

                    sbQuery.Append("  FROM TSTD_ACTUAL_TOOL  AT     ");
                    sbQuery.Append("    INNER JOIN TTOL_TOOLLIST  TL     ");
                    sbQuery.Append("        ON AT.PLT_CODE = TL.PLT_CODE      ");
                    sbQuery.Append("        AND AT.TL_LOT = TL.TL_LOT  ");
                    sbQuery.Append("    INNER JOIN TSTD_TOOL  T     ");
                    sbQuery.Append("        ON TT.PLT_CODE = T.PLT_CODE      ");
                    sbQuery.Append("        AND TT.TL_CODE = T.TL_CODE  ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@TL_CODE", "AT.TL_CODE = @TL_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "AT.PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROC_CODE", "AT.PROC_CODE = @PROC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@TL_LOT", "AT.TL_LOT = @TL_LOT"));

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
