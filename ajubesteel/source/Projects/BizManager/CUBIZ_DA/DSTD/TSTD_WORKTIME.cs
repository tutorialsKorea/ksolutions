using BizExecute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSTD
{
    public class TSTD_WORKTIME
    {
        public static DataTable TSTD_WORKTIME_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,WT_ID ");
                    sbQuery.Append(" ,WORK_CODE ");
                    sbQuery.Append(" ,WORK_START_HOUR ");
                    sbQuery.Append(" ,WORK_END_HOUR ");
                    sbQuery.Append(" ,WORK_RATE ");
                    sbQuery.Append(" ,NIGHT_FLAG ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,MDFY_DATE ");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append(" ,DEL_DATE ");
                    sbQuery.Append(" ,DEL_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append("  FROM TSTD_WORKTIME  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND WT_ID = @WT_ID  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "WT_ID")) isHasColumn = false;

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


        public static void TSTD_WORKTIME_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TSTD_WORKTIME (  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,WT_ID ");
                    sbQuery.Append(" ,WORK_CODE ");
                    sbQuery.Append(" ,WORK_START_HOUR ");
                    sbQuery.Append(" ,WORK_END_HOUR ");
                    sbQuery.Append(" ,WORK_RATE ");
                    sbQuery.Append(" ,NIGHT_FLAG ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append("  ) VALUES (  ");
                    sbQuery.Append("  @PLT_CODE ");
                    sbQuery.Append(" ,@WT_ID ");
                    sbQuery.Append(" ,@WORK_CODE ");
                    sbQuery.Append(" ,@WORK_START_HOUR ");
                    sbQuery.Append(" ,@WORK_END_HOUR ");
                    sbQuery.Append(" ,@WORK_RATE ");
                    sbQuery.Append(" ,@NIGHT_FLAG ");
                    sbQuery.Append(" ,GETDATE() ");
                    sbQuery.Append(" ," + UTIL.GetValidValue(ConnInfo.UserID));
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

        public static void TSTD_WORKTIME_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSTD_WORKTIME SET  ");
                    sbQuery.Append("  WORK_CODE = @WORK_CODE ");
                    sbQuery.Append(" ,WORK_START_HOUR = @WORK_START_HOUR ");
                    sbQuery.Append(" ,WORK_END_HOUR = @WORK_END_HOUR ");
                    sbQuery.Append(" ,WORK_RATE = @WORK_RATE ");
                    sbQuery.Append(" ,NIGHT_FLAG = @NIGHT_FLAG ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE()");
                    sbQuery.Append(" ,MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND WT_ID = @WT_ID ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "WT_ID")) isHasColumn = false;

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


        public static void TSTD_WORKTIME_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSTD_WORKTIME SET  ");
                    sbQuery.Append("  DEL_DATE = GETDATE()");
                    sbQuery.Append(" ,DEL_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND WT_ID = @WT_ID ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "WT_ID")) isHasColumn = false;

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

    public class TSTD_WORKTIME_QUERY
    {
        public static DataTable TSTD_WORKTIME_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" WT.PLT_CODE");
                    sbQuery.Append(" ,WT.WT_ID");
                    sbQuery.Append(" ,WT.WORK_CODE");
                    sbQuery.Append(" ,WC.WORK_NAME");
                    sbQuery.Append(" ,WT.WORK_START_HOUR");
                    sbQuery.Append(" ,WT.WORK_END_HOUR");
                    sbQuery.Append(" ,WT.WORK_RATE");
                    sbQuery.Append(" ,WT.NIGHT_FLAG");
                    sbQuery.Append(" ,WT.NIGHT_FLAG_52");
                    sbQuery.Append(" ,WT.WORK_TIME");
                    sbQuery.Append(" ,WT.IS_EIGHT_TIME_PLUS");
                    sbQuery.Append(" ,WT.REG_DATE");
                    sbQuery.Append(" ,WT.REG_EMP");
                    sbQuery.Append(" ,WT.MDFY_DATE");
                    sbQuery.Append(" ,WT.MDFY_EMP");
                    sbQuery.Append(" ,WT.DEL_DATE");
                    sbQuery.Append(" ,WT.DEL_EMP");
                    sbQuery.Append(" ,WT.DATA_FLAG");
                    sbQuery.Append(" FROM TSTD_WORKTIME WT");
                    sbQuery.Append(" LEFT JOIN TSTD_WORKCODE WC");
                    sbQuery.Append(" ON WT.PLT_CODE = WC.PLT_CODE");
                    sbQuery.Append(" AND WT.WORK_CODE = WC.WORK_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE WT.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@WT_ID", "WT_ID = @WT_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WORK_CODE", "WT.WORK_CODE = @WORK_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WORK_LIKE", "(WT.WORK_CODE LIKE '%' + @WORK_LIKE + '%' OR WC.WORK_NAME '%' + @WORK_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "WT.DATA_FLAG = @DATA_FLAG"));


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

        public static DataTable TSTD_WORKTIME_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" WT.PLT_CODE");
                    sbQuery.Append(" ,WT.WT_ID");
                    sbQuery.Append(" ,WT.WORK_CODE");
                    sbQuery.Append(" ,WC.WORK_NAME");
                    sbQuery.Append(" ,WT.WORK_START_HOUR");
                    sbQuery.Append(" ,WT.WORK_END_HOUR");
                    sbQuery.Append(" ,WT.WORK_RATE");
                    sbQuery.Append(" ,WT.NIGHT_FLAG");
                    sbQuery.Append(" ,WT.REG_DATE");
                    sbQuery.Append(" ,WT.REG_EMP");
                    sbQuery.Append(" ,WT.MDFY_DATE");
                    sbQuery.Append(" ,WT.MDFY_EMP");
                    sbQuery.Append(" ,WT.DEL_DATE");
                    sbQuery.Append(" ,WT.DEL_EMP");
                    sbQuery.Append(" ,WT.DATA_FLAG");
                    sbQuery.Append(" FROM TSTD_WORKTIME WT");
                    sbQuery.Append(" LEFT JOIN TSTD_WORKCODE WC");
                    sbQuery.Append(" ON WT.PLT_CODE = WC.PLT_CODE");
                    sbQuery.Append(" AND WT.WORK_CODE = WC.WORK_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE WT.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        //sbWhere.Append(UTIL.GetWhere(row, "@WT_ID", "WT_ID = @WT_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@NOT_WT_ID", "WT_ID <> @NOT_WT_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WORK_CODE", "WT.WORK_CODE = @WORK_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WORK_LIKE", "(WT.WORK_CODE LIKE '%' + @WORK_LIKE + '%' OR WC.WORK_NAME '%' + @WORK_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "WT.DATA_FLAG = @DATA_FLAG"));


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
