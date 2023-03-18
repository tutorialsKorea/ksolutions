using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DAPS
{
    public class APS_STD_ERROR
    {
    }


    public class APS_STD_ERROR_QUERY
    {
        public static DataTable APS_STD_ERROR_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT ");
                    sbQuery.Append(" SE.APS_CONTENTS, ");
                    sbQuery.Append(" SE.MES_CONTENTS, ");
                    sbQuery.Append(" EL.ERR_CODE, ");
                    sbQuery.Append(" EL.VERSION_NO, ");
                    sbQuery.Append(" EL.SEVERITY, ");
                    sbQuery.Append(" EL.CATEGORY, ");
                    sbQuery.Append(" EL.REASON, ");
                    sbQuery.Append(" EL.ITEM, ");
                    sbQuery.Append(" EL.DEMAND_ID, ");
                    sbQuery.Append(" EL.PRODUCT_ID, ");
                    sbQuery.Append(" EL.STEP_ID, ");
                    sbQuery.Append(" EL.EQP_ID, ");
                    sbQuery.Append(" EL.LOT_ID, ");
                    sbQuery.Append(" EL.LOG_TIME ");
                    sbQuery.Append(" FROM [smartaps_sungwon]..ERROR_LOG EL ");
                    sbQuery.Append(" LEFT JOIN APS_STD_ERROR SE ");
                    sbQuery.Append(" ON SE.ERR_CODE = EL.ERR_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE 1=1 ");

                        sbWhere.Append(UTIL.GetWhere(row, "@VERSION_NO", "EL.VERSION_NO = @VERSION_NO"));
                        
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
