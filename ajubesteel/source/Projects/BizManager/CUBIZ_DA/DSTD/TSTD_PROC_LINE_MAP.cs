using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizExecute;
using System.Data;

namespace DSTD
{
    public class TSTD_PROC_LINE_MAP
    {

        public static DataTable TSTD_PROC_LINE_MAP_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,MAP_CLASS ");
                    sbQuery.Append(" ,MAP_CODE_F ");
                    sbQuery.Append(" ,MAP_CODE_T ");
                    sbQuery.Append(" ,MAP_SEQ ");
                    sbQuery.Append(" ,USE_FLAG ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append(" ,MDFY_DATE ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append("  FROM TSTD_PROC_LINE_MAP  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND MAP_CLASS = @MAP_CLASS  ");
                    sbQuery.Append("  AND MAP_CODE_F = @MAP_CODE_F  ");
                    sbQuery.Append("  AND MAP_CODE_T = @MAP_CODE_T  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MAP_CLASS")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MAP_CODE_F")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MAP_CODE_T")) isHasColumn = false;

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

        public static void TSTD_PROC_LINE_MAP_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSTD_PROC_LINE_MAP SET  ");
                    sbQuery.Append("  MAP_SEQ = @MAP_SEQ ");
                    sbQuery.Append(" ,USE_FLAG = @USE_FLAG ");
                    sbQuery.Append(" ,MDFY_EMP = '" + ConnInfo.UserID + "' ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND MAP_CLASS = @MAP_CLASS ");
                    sbQuery.Append("  AND MAP_CODE_F = @MAP_CODE_F ");
                    sbQuery.Append("  AND MAP_CODE_T = @MAP_CODE_T ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MAP_CLASS")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MAP_CODE_F")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MAP_CODE_T")) isHasColumn = false;

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

        public static void TSTD_PROC_LINE_MAP_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append("UPDATE TSTD_PROC_LINE_MAP SET");
                    sbQuery.Append("  DEL_DATE = GETDATE()");
                    sbQuery.Append(" , DEL_EMP = '" + ConnInfo.UserID + "'");
                    sbQuery.Append(" , DATA_FLAG = 2");

                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND MAP_CLASS = @MAP_CLASS ");
                    sbQuery.Append("  AND MAP_CODE_F = @MAP_CODE_F ");
                    sbQuery.Append("  AND MAP_CODE_T = @MAP_CODE_T ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MAP_CLASS")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MAP_CODE_F")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MAP_CODE_T")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            bizExecute.executeUpdateQuery(sbQuery.ToString(),row );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static void TSTD_PROC_LINE_MAP_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TSTD_PROC_LINE_MAP (  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,MAP_CLASS ");
                    sbQuery.Append(" ,MAP_CODE_F ");
                    sbQuery.Append(" ,MAP_CODE_T ");
                    sbQuery.Append(" ,MAP_SEQ ");
                    sbQuery.Append(" ,USE_FLAG ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append(" ,MDFY_DATE ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append("  ) VALUES (  ");
                    sbQuery.Append("  @PLT_CODE ");
                    sbQuery.Append(" ,@MAP_CLASS ");
                    sbQuery.Append(" ,@MAP_CODE_F ");
                    sbQuery.Append(" ,@MAP_CODE_T ");
                    sbQuery.Append(" ,@MAP_SEQ ");
                    sbQuery.Append(" ,@USE_FLAG ");
                    sbQuery.Append(" ,'" + ConnInfo.UserID + "' ");
                    sbQuery.Append(" ,GETDATE() ");
                    sbQuery.Append(" ,'" + ConnInfo.UserID + "' ");
                    sbQuery.Append(" ,GETDATE() ");
                    sbQuery.Append(" ,@DATA_FLAG ");
                    sbQuery.Append("  ) ");

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

    public class TSTD_PROC_LINE_MAP_QUERY
    {
        public static DataTable TSTD_PROC_LINE_MAP_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT ");
                    sbQuery.Append(" 	CD.CAT_CODE ");
                    sbQuery.Append(" 	, CD.CD_CODE ");
                    sbQuery.Append(" 	, CD.CD_NAME ");
                    sbQuery.Append(" 	, PLM.MAP_CLASS ");
                    sbQuery.Append(" 	, PLM.MAP_CODE_F ");
                    sbQuery.Append(" 	, PLM.MAP_CODE_T ");
                    sbQuery.Append(" 	, ISNULL(PLM.MAP_SEQ, 0) MAP_SEQ ");
                    sbQuery.Append(" 	, ISNULL(PLM.USE_FLAG, 0) USE_FLAG ");
                    sbQuery.Append(" 	, PLM.MDFY_DATE ");
                    sbQuery.Append(" 	, MDFY.EMP_NAME AS MDFY_EMP_NAME ");
                    sbQuery.Append(" FROM TSTD_CODES CD ");
                    sbQuery.Append(" LEFT JOIN TSTD_PROC_LINE_MAP PLM ");
                    sbQuery.Append(" 	ON CD.PLT_CODE=PLM.PLT_CODE ");
                    sbQuery.Append(" 	AND CD.CAT_CODE=PLM.MAP_CLASS ");
                    sbQuery.Append(" 	AND CD.CD_CODE=PLM.MAP_CODE_F ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY ");
                    sbQuery.Append(" 	ON PLM.PLT_CODE = MDFY.PLT_CODE ");
                    sbQuery.Append(" 	AND PLM.MDFY_EMP = MDFY.EMP_CODE  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE CD.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@CAT_CODE", "CD.CAT_CODE = @CAT_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "CD.DATA_FLAG = @DATA_FLAG"));

                        sbWhere.Append(" ORDER BY ISNULL(PLM.MAP_SEQ, 0) ");

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString() ).Copy();

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

        public static DataTable TSTD_PROC_LINE_MAP_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT ");
                    sbQuery.Append(" 	PLM_F.MAP_CLASS ");
                    sbQuery.Append(" 	, PLM_F.MAP_CODE_F ");
                    sbQuery.Append(" 	, PLM_F.MAP_CODE_T ");
                    sbQuery.Append(" 	, PLM_F.MAP_SEQ ");
                    sbQuery.Append(" 	, PLM_F.USE_FLAG ");
                    sbQuery.Append(" 	, PLM_F.MDFY_DATE ");
                    sbQuery.Append(" 	, MDFY.EMP_NAME AS MDFY_EMP_NAME ");
                    sbQuery.Append(" 	, CD_F.CD_NAME MAP_NAME_F ");
                    sbQuery.Append(" 	, CD_T.CD_NAME MAP_NAME_T ");
                    sbQuery.Append(" FROM ");
                    sbQuery.Append(" 	TSTD_PROC_LINE_MAP PLM_F ");
                    sbQuery.Append(" LEFT JOIN TSTD_CODES CD_F ");
                    sbQuery.Append(" 	ON CD_F.PLT_CODE=PLM_F.PLT_CODE ");
                    sbQuery.AppendFormat(" 	AND CD_F.CAT_CODE='{0}' ", dtParam.Rows[0]["CAT_CODE_F"].ToString());
                    sbQuery.Append(" 	AND CD_F.CD_CODE=PLM_F.MAP_CODE_F ");
                    sbQuery.Append(" LEFT JOIN TSTD_CODES CD_T ");
                    sbQuery.Append(" 	ON CD_T.PLT_CODE=PLM_F.PLT_CODE ");
                    sbQuery.Append(" 	AND CD_T.CAT_CODE=PLM_F.MAP_CLASS ");
                    sbQuery.Append(" 	AND CD_T.CD_CODE=PLM_F.MAP_CODE_T ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY ");
                    sbQuery.Append(" 	ON PLM_F.PLT_CODE = MDFY.PLT_CODE ");
                    sbQuery.Append(" 	AND PLM_F.MDFY_EMP = MDFY.EMP_CODE  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PLM_F.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@MAP_CLASS", "PLM_F.MAP_CLASS = @MAP_CLASS"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAP_CODE_F", "PLM_F.MAP_CODE_F = @MAP_CODE_F"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "PLM_F.DATA_FLAG = @DATA_FLAG"));

                        sbWhere.Append(" ORDER BY PLM_F.MAP_SEQ ");

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
