using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizExecute;
using System.Data;

namespace DSTD
{
    public class TSTD_PIPE_PRICE
    {
        public static DataTable TSTD_PIPE_PRICE_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,CAT_CODE ");
                    sbQuery.Append(" ,PIP_CODE ");
                    sbQuery.Append(" ,PIP_NAME ");
                    sbQuery.Append(" ,PIP_PROD_NAME ");
                    sbQuery.Append(" ,PIP_SIZE ");
                    sbQuery.Append(" ,PIP_PROD_TYPE ");
                    sbQuery.Append(" ,PIP_PRICE ");
                    sbQuery.Append(" ,PIP_ACTIVE ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,MDFY_DATE ");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append(" ,DEL_DATE ");
                    sbQuery.Append(" ,DEL_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append("  FROM TSTD_PIPE_PRICE  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND CAT_CODE = @CAT_CODE  ");
                    sbQuery.Append("  AND PIP_CODE = @PIP_CODE  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "CAT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PIP_CODE")) isHasColumn = false;

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


        public static void TSTD_PIPE_PRICE_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSTD_PIPE_PRICE SET  ");
                    sbQuery.Append("  PIP_NAME = @PIP_NAME ");
                    sbQuery.Append(" ,PIP_PROD_NAME = @PIP_PROD_NAME ");
                    sbQuery.Append(" ,PIP_SIZE = @PIP_SIZE ");
                    sbQuery.Append(" ,PIP_PROD_TYPE = @PIP_PROD_TYPE ");
                    sbQuery.Append(" ,PIP_PRICE = @PIP_PRICE ");
                    sbQuery.Append(" ,PIP_ACTIVE = @PIP_ACTIVE ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = '" + ConnInfo.UserID + "' ");
                    sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append(" ,SCOMMENT = @SCOMMENT ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND CAT_CODE = @CAT_CODE ");
                    sbQuery.Append("  AND PIP_CODE = @PIP_CODE ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "CAT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PIP_CODE")) isHasColumn = false;

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


        public static void TSTD_PIPE_PRICE_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append("UPDATE TSTD_PIPE_PRICE SET");
                    sbQuery.Append("  DEL_DATE = GETDATE()");
                    sbQuery.Append(" , DEL_EMP = '" + ConnInfo.UserID + "'");
                    sbQuery.Append(" , DATA_FLAG = 2");

                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND CAT_CODE = @CAT_CODE ");
                    sbQuery.Append("  AND PIP_CODE = @PIP_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "CAT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PIP_CODE")) isHasColumn = false;

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

        public static void TSTD_PIPE_PRICE_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TSTD_PIPE_PRICE (  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,CAT_CODE ");
                    sbQuery.Append(" ,PIP_CODE ");
                    sbQuery.Append(" ,PIP_NAME ");
                    sbQuery.Append(" ,PIP_PROD_NAME ");
                    sbQuery.Append(" ,PIP_SIZE ");
                    sbQuery.Append(" ,PIP_PROD_TYPE ");
                    sbQuery.Append(" ,PIP_PRICE ");
                    sbQuery.Append(" ,PIP_ACTIVE ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append("  ) VALUES (  ");
                    sbQuery.Append("  @PLT_CODE ");
                    sbQuery.Append(" ,@CAT_CODE ");
                    sbQuery.Append(" ,@PIP_CODE ");
                    sbQuery.Append(" ,@PIP_NAME ");
                    sbQuery.Append(" ,@PIP_PROD_NAME ");
                    sbQuery.Append(" ,@PIP_SIZE ");
                    sbQuery.Append(" ,@PIP_PROD_TYPE ");
                    sbQuery.Append(" ,@PIP_PRICE ");
                    sbQuery.Append(" ,@PIP_ACTIVE ");
                    sbQuery.Append(" ,GETDATE() ");
                    sbQuery.Append(" ,'" + ConnInfo.UserID + "' ");
                    sbQuery.Append(" ,@DATA_FLAG ");
                    sbQuery.Append(" ,@SCOMMENT ");
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

    public class TSTD_PIPE_PRICE_QUERY
    {
        public static DataTable TSTD_PIPE_PRICE_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT  ");
                    sbQuery.Append(" PP.PLT_CODE");
                    sbQuery.Append(" , PP.CAT_CODE");
                    sbQuery.Append(" , PP.PIP_CODE");
                    sbQuery.Append(" , PP.PIP_NAME");
                    sbQuery.Append(" , PP.PIP_PROD_NAME");
                    sbQuery.Append(" , PP.PIP_SIZE");
                    sbQuery.Append(" , PP.PIP_PROD_TYPE");
                    sbQuery.Append(" , PP.PIP_PRICE");
                    sbQuery.Append(" , PP.PIP_ACTIVE");
                    sbQuery.Append(" , PP.REG_DATE");
                    sbQuery.Append(" , PP.REG_EMP");
                    sbQuery.Append(" , REG.EMP_NAME AS REG_EMP_NAME");
                    sbQuery.Append(" , PP.MDFY_DATE");
                    sbQuery.Append(" , PP.MDFY_EMP");
                    sbQuery.Append(" , MDFY.EMP_NAME AS MDFY_EMP_NAME");
                    sbQuery.Append(" , PP.DEL_DATE");
                    sbQuery.Append(" , PP.DEL_EMP");
                    sbQuery.Append(" , PP.DATA_FLAG");
                    sbQuery.Append(" FROM TSTD_PIPE_PRICE PP");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG ");
                    sbQuery.Append(" ON PP.PLT_CODE = REG.PLT_CODE ");
                    sbQuery.Append(" AND PP.REG_EMP = REG.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE  MDFY");
                    sbQuery.Append(" ON PP.PLT_CODE = MDFY.PLT_CODE ");
                    sbQuery.Append(" AND PP.MDFY_EMP = MDFY.EMP_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PP.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@CAT_CODE", "PP.CAT_CODE = @CAT_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PIP_CODE", "PP.PIP_CODE = @PIP_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "PP.DATA_FLAG = @DATA_FLAG"));

                        sbWhere.Append(" ORDER BY PP.PLT_CODE, PP.CAT_CODE, PP.PIP_CODE");

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

    }
}
