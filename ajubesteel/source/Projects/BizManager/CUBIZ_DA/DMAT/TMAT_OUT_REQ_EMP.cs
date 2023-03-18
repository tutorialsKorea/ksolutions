using BizExecute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMAT
{
    public class TMAT_OUT_REQ_EMP
    {
        public static DataTable TMAT_OUT_REQ_EMP_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,OUT_REQ_ID ");
                    sbQuery.Append(" ,EMP_CODE ");
                    sbQuery.Append(" ,IS_POPUP ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,MDFY_DATE ");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append("  FROM TMAT_OUT_REQ_EMP  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND OUT_REQ_ID = @OUT_REQ_ID  ");
                    sbQuery.Append("  AND EMP_CODE = @EMP_CODE  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "OUT_REQ_ID")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "EMP_CODE")) isHasColumn = false;

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

        public static DataTable TMAT_OUT_REQ_EMP_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,OUT_REQ_ID ");
                    sbQuery.Append(" ,EMP_CODE ");
                    sbQuery.Append(" ,IS_POPUP ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,MDFY_DATE ");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append("  FROM TMAT_OUT_REQ_EMP  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND EMP_CODE = @EMP_CODE  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "EMP_CODE")) isHasColumn = false;

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

        public static void TMAT_OUT_REQ_EMP_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TMAT_OUT_REQ_EMP (  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,OUT_REQ_ID ");
                    sbQuery.Append(" ,EMP_CODE ");
                    sbQuery.Append(" ,IS_POPUP ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append("  ) VALUES (  ");
                    sbQuery.Append("  @PLT_CODE ");
                    sbQuery.Append(" ,@OUT_REQ_ID ");
                    sbQuery.Append(" ,@EMP_CODE ");
                    sbQuery.Append(" ,@IS_POPUP ");
                    sbQuery.Append(" ,GETDATE() ");
                    sbQuery.Append(" ,'" + ConnInfo.UserID + "' ");
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

        public static void TMAT_OUT_REQ_EMP_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_OUT_REQ_EMP SET  ");
                    sbQuery.Append("  IS_POPUP = @IS_POPUP ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = '" + ConnInfo.UserID + "' ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND OUT_REQ_ID = @OUT_REQ_ID ");
                    sbQuery.Append("  AND EMP_CODE = @EMP_CODE ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "OUT_REQ_ID")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "EMP_CODE")) isHasColumn = false;

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

    public class TMAT_OUT_REQ_EMP_QUERY
    {
        public static DataTable TMAT_OUT_REQ_EMP_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" OE.PLT_CODE");
                    sbQuery.Append(" ,OE.OUT_REQ_ID");
                    sbQuery.Append(" ,OE.EMP_CODE");
                    sbQuery.Append(" ,P.PROD_CODE");
                    sbQuery.Append(" ,PT.PART_CODE");
                    sbQuery.Append(" ,SP.PART_NAME");
                    sbQuery.Append(" ,SP.MAT_MTYPE");
                    sbQuery.Append(" ,SP.MAT_STYPE");
                    sbQuery.Append(" ,SP.MAT_LTYPE");
                    sbQuery.Append(" ,O.OUT_REQ_DATE");
                    sbQuery.Append(" ,O.OUT_REQ_QTY");
                    sbQuery.Append(" ,O.OUT_REQ_EMP");
                    sbQuery.Append(" ,E.EMP_NAME AS OUT_REQ_EMP_NAME");
                    sbQuery.Append(" ,SP.MAT_SPEC");
                    sbQuery.Append(" ,P.CVND_CODE");
                    sbQuery.Append(" ,V.VEN_NAME AS CVND_NAME");
                    sbQuery.Append(" ,P.ORD_DATE");
                    sbQuery.Append(" ,P.DUE_DATE");
                    sbQuery.Append(" FROM TMAT_OUT_REQ_EMP OE");
                    sbQuery.Append(" LEFT JOIN TMAT_OUT_REQ O");
                    sbQuery.Append(" ON OE.PLT_CODE = O.PLT_CODE");
                    sbQuery.Append(" AND OE.OUT_REQ_ID = O.OUT_REQ_ID");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E");
                    sbQuery.Append(" ON O.PLT_CODE = E.PLT_CODE");
                    sbQuery.Append(" AND O.OUT_REQ_EMP = E.EMP_CODE");
                    
                    sbQuery.Append(" LEFT JOIN TMAT_PARTLIST PT");
                    sbQuery.Append(" ON O.PLT_CODE = PT.PLT_CODE");
                    sbQuery.Append(" AND O.PT_ID = PT.PT_ID");
                    
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP");
                    sbQuery.Append(" ON PT.PLT_CODE = SP.PLT_CODE");
                    sbQuery.Append(" AND PT.PART_CODE = SP.PART_CODE");
                    
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P");
                    sbQuery.Append(" ON PT.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND PT.PROD_CODE = P.PROD_CODE");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V");
                    sbQuery.Append(" ON P.PLT_CODE = V.PLT_CODE");
                    sbQuery.Append(" AND P.CVND_CODE = V.VEN_CODE");



                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE OE.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", " OE.PLT_CODE = @PLT_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_POPUP", " OE.IS_POPUP = @IS_POPUP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", " OE.EMP_CODE = @EMP_CODE"));

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
