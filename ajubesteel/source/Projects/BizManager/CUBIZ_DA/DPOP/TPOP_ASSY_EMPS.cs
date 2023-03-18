using BizExecute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPOP
{
    public class TPOP_ASSY_EMPS
    {
        public static DataTable TPOP_ASSY_EMPS_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,PT_ID ");
                    sbQuery.Append(" ,FLAG ");
                    sbQuery.Append(" ,EMP_CODE ");
                    sbQuery.Append("  FROM TPOP_ASSY_EMPS  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND PT_ID = @PT_ID  ");
                    sbQuery.Append("  AND FLAG = @FLAG  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "FLAG")) isHasColumn = false;

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

        public static void TPOP_ASSY_EMPS_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TPOP_ASSY_EMPS (  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,PT_ID ");
                    sbQuery.Append(" ,FLAG ");
                    sbQuery.Append(" ,EMP_CODE ");
                    sbQuery.Append("  ) VALUES (  ");
                    sbQuery.Append("  @PLT_CODE ");
                    sbQuery.Append(" ,@PT_ID ");
                    sbQuery.Append(" ,@FLAG ");
                    sbQuery.Append(" ,@EMP_CODE ");
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

        public static void TPOP_ASSY_EMPS_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" DELETE FROM TPOP_ASSY_EMPS  ");
                    sbQuery.Append("   WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND PT_ID = @PT_ID ");
                    sbQuery.Append("  AND FLAG = @FLAG ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "FLAG")) isHasColumn = false;

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

    public class TPOP_ASSY_EMPS_QUERY
    {
        public static DataTable TPOP_ASSY_EMPS_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  A.PLT_CODE ");
                    sbQuery.Append(" ,A.PT_ID ");
                    sbQuery.Append(" ,A.FLAG ");
                    sbQuery.Append(" ,A.EMP_CODE ");
                    sbQuery.Append(" ,B.EMP_NAME ");
                    sbQuery.Append(" ,B.ORG_CODE ");
                    sbQuery.Append(" ,C.ORG_NAME ");
                    sbQuery.Append("  FROM TPOP_ASSY_EMPS A ");
                    sbQuery.Append("  LEFT JOIN TSTD_EMPLOYEE B ");
                    sbQuery.Append("  ON A.PLT_CODE = B.PLT_CODE ");
                    sbQuery.Append("  AND A.EMP_CODE = B.EMP_CODE ");

                    sbQuery.Append("  LEFT JOIN TSTD_ORG C ");
                    sbQuery.Append("  ON B.PLT_CODE = C.PLT_CODE ");
                    sbQuery.Append("  AND B.ORG_CODE = C.ORG_CODE ");


                    foreach (DataRow row in dtParam.Rows)
                    {

                        StringBuilder sbWhere = new StringBuilder(" WHERE A.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@FLAG", "A.FLAG = @FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PT_ID", "A.PT_ID = @PT_ID"));

                        sbWhere.Append(" ORDER BY B.EMP_NAME ");

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(), row).Copy();

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
