using BizExecute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSTD
{
    public class TSTD_MC_DOWN_REASON
    {
        public static DataTable TSTD_MC_DOWN_REASON_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,MDR_TCODE ");
                    sbQuery.Append(" ,MDR_RCODE ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,MDFY_DATE ");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append(" ,DEL_DATE ");
                    sbQuery.Append(" ,DEL_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append("  FROM TSTD_MC_DOWN_REASON  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND MDR_TCODE = @MDR_TCODE  ");
                    sbQuery.Append("  AND MDR_RCODE = @MDR_RCODE  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MDR_TCODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MDR_RCODE")) isHasColumn = false;

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

        public static void TSTD_MC_DOWN_REASON_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TSTD_MC_DOWN_REASON (  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,MDR_TCODE ");
                    sbQuery.Append(" ,MDR_RCODE ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append("  ) VALUES (  ");
                    sbQuery.Append("  @PLT_CODE ");
                    sbQuery.Append(" ,@MDR_TCODE ");
                    sbQuery.Append(" ,@MDR_RCODE ");
                    sbQuery.Append(" ,GETDATE() ");
                    sbQuery.Append(" ,'" + ConnInfo.UserID + "' ");
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

        public static void TSTD_MC_DOWN_REASON_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSTD_MC_DOWN_REASON SET  ");
                    sbQuery.Append("  MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = '" + ConnInfo.UserID + "' ");
                    sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND MDR_TCODE = @MDR_TCODE ");
                    sbQuery.Append("  AND MDR_RCODE = @MDR_RCODE ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MDR_TCODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MDR_RCODE")) isHasColumn = false;

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

                    sbQuery.Append(" UPDATE TSTD_MC_DOWN_REASON SET  ");
                    sbQuery.Append("  DEL_DATE = GETDATE()");
                    sbQuery.Append(" ,DEL_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND MDR_TCODE = @MDR_TCODE ");
                    sbQuery.Append("  AND MDR_RCODE = @MDR_RCODE ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MDR_TCODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MDR_RCODE")) isHasColumn = false;

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

    public class TSTD_MC_DOWN_REASON_QUERY
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
                    sbQuery.Append("  MDR.PLT_CODE ");
                    sbQuery.Append(" , MDR.MDR_TCODE ");
                    sbQuery.Append(" , MDR.MDR_RCODE ");
                    sbQuery.Append(" , MDR.REG_DATE ");
                    sbQuery.Append(" , MDR.REG_EMP ");
                    sbQuery.Append(" , MDR.MDFY_DATE ");
                    sbQuery.Append(" , MDR.MDFY_EMP ");
                    sbQuery.Append(" , MDR.DEL_DATE ");
                    sbQuery.Append(" , MDR.DEL_EMP ");
                    sbQuery.Append(" , MDR.DATA_FLAG ");

                    sbQuery.Append(" , REG.EMP_NAME AS REG_EMP_NAME");
                    sbQuery.Append(" , MDFY.EMP_NAME AS MDFY_EMP_NAME");

                    sbQuery.Append(" , ISNULL(MT.CD_NAME, '') AS MDR_TCODE_NAME");
                    sbQuery.Append(" , ISNULL(MR.CD_NAME, '') AS MDR_RCODE_NAME");

                    sbQuery.Append(" FROM TSTD_MC_DOWN_REASON MDR");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG ");
                    sbQuery.Append(" ON MDR.PLT_CODE = REG.PLT_CODE ");
                    sbQuery.Append(" AND MDR.REG_EMP = REG.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE  MDFY");
                    sbQuery.Append(" ON MDR.PLT_CODE = MDFY.PLT_CODE ");
                    sbQuery.Append(" AND MDR.MDFY_EMP = MDFY.EMP_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_CODES MT ");
                    sbQuery.Append(" ON MT.PLT_CODE = REG.PLT_CODE ");
                    sbQuery.AppendFormat(" AND MT.CAT_CODE = '{0}'", TSTD_CODES.비가동구분);
                    sbQuery.Append(" AND MT.CD_CODE = MDR.MDR_TCODE");

                    sbQuery.Append(" LEFT JOIN TSTD_CODES MR ");
                    sbQuery.Append(" ON MR.PLT_CODE = REG.PLT_CODE ");
                    sbQuery.AppendFormat(" AND MR.CAT_CODE = '{0}'", TSTD_CODES.비가동원인);
                    sbQuery.Append(" AND MR.CD_CODE = MDR.MDR_RCODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();
                        sbWhere.Append(" WHERE MDR.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@MDR_TCODE", "MDR.MDR_TCODE = @MDR_TCODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MDR_RCODE", "MDR.MDR_RCODE = @MDR_RCODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "MDR.DATA_FLAG = @DATA_FLAG"));

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
