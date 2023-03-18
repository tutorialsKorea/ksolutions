using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSHP
{
    public class TSHP_WORKORDER_HIS
    {

        public static DataTable TSHP_WORKORDER_HIS_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" , WO_NO ");
                    sbQuery.Append(" , WO_FLAG ");
                    sbQuery.Append(" , MDFY_DATE");
                    sbQuery.Append(" , MDFY_EMP");
                    sbQuery.Append(" FROM TSHP_WORKORDER_HIS ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND WO_NO = @WO_NO");

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

        public static void TSHP_WORKORDER_HIS_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TSHP_WORKORDER_HIS");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" , WO_NO ");
                    sbQuery.Append(" , WO_FLAG ");
                    sbQuery.Append(" , MDFY_DATE ");
                    sbQuery.Append(" , MDFY_EMP ");
                    sbQuery.Append(" ) ");
                    sbQuery.Append(" VALUES");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" @PLT_CODE ");
                    sbQuery.Append(" , @WO_NO");
                    sbQuery.Append(" , @WO_FLAG");
                      sbQuery.Append(" , GETDATE() ");
                    sbQuery.Append(" , " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(")");

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

    public class TSHP_WORKORDER_HIS_QUERY
    {
        public static DataTable TSHP_WORKORDER_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT H.PLT_CODE  ");
                    sbQuery.Append(" 	, H.WO_NO           ");
                    sbQuery.Append(" 	, W.PART_CODE      ");
                    sbQuery.Append(" 	, P.PART_NAME      ");
                    sbQuery.Append(" 	, W.PROC_CODE      ");
                    sbQuery.Append(" 	, PR.PROC_NAME    ");
                    sbQuery.Append(" 	, H.WO_FLAG         ");
                    sbQuery.Append(" 	, H.MDFY_DATE      ");
                    sbQuery.Append(" 	, H.MDFY_EMP        ");
                    sbQuery.Append(" 	, E.EMP_NAME       ");
                    sbQuery.Append(" FROM TSHP_WORKORDER_HIS H JOIN TSHP_WORKORDER W    ");
                    sbQuery.Append("   ON H.PLT_CODE = W.PLT_CODE   ");
                    sbQuery.Append("  AND H.WO_NO = W.WO_NO   ");
                    sbQuery.Append("  JOIN LSE_STD_PART P   ");
                    sbQuery.Append("   ON W.PLT_CODE = P.PLT_CODE   ");
                    sbQuery.Append("  AND W.PART_CODE = P.PART_CODE   "); 
                    sbQuery.Append("  JOIN LSE_STD_PROC PR   ");
                    sbQuery.Append("   ON W.PLT_CODE = PR.PLT_CODE   ");
                    sbQuery.Append("  AND W.PROC_CODE = PR.PROC_CODE   ");
                    sbQuery.Append("  JOIN TSTD_EMPLOYEE E   ");
                    sbQuery.Append("   ON H.PLT_CODE = E.PLT_CODE   ");
                    sbQuery.Append("  AND H.MDFY_EMP = E.EMP_CODE   ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "WO_NO")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            StringBuilder sbWhere = new StringBuilder();

                            sbWhere.Append(" WHERE H.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                            sbWhere.Append(UTIL.GetWhere(row, "@WO_NO", "H.WO_NO = @WO_NO"));
                        
                            DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(), row).Copy();

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
    }
   
}
