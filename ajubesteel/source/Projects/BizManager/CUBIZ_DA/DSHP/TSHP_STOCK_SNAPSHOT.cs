using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSHP
{
    public class TSHP_STOCK_SNAPSHOT_QUERY
    {

        public static DataTable TSHP_STOCK_SNAPSHOT_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT  SN.PLT_CODE   ");
                    sbQuery.Append(" ,SN.SAVE_DATE  ");
                    sbQuery.Append(" ,SN.STOCK_LOC  ");
                    sbQuery.Append(" ,SN.PART_CODE  ");
                    sbQuery.Append(" ,SN.PART_NAME  ");
                    sbQuery.Append(" ,SN.MAT_TYPE   ");
                    sbQuery.Append(" ,SN.MAT_SPEC   ");
                    sbQuery.Append(" ,SN.DRAW_NO    ");
                    sbQuery.Append(" ,SN.PART_QTY   ");
                    sbQuery.Append(" ,SN.SAFE_QTY   ");
                    sbQuery.Append(" ,SN.AMT        ");

                    sbQuery.Append(" ,SP.MAT_LTYPE  ");
                    sbQuery.Append(" ,SP.MAT_MTYPE  ");
                    sbQuery.Append(" ,SP.MAT_STYPE  ");
                    sbQuery.Append(" ,SP.MNG_FLAG  ");

                    sbQuery.Append(" FROM TSHP_STOCK_SNAPSHOT SN");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP ");
                    sbQuery.Append(" ON SN.PLT_CODE = SP.PLT_CODE ");
                    sbQuery.Append(" AND SN.PART_CODE = SP.PART_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        StringBuilder sbWhere = new StringBuilder(" WHERE SN.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", " SN.PLT_CODE = @PLT_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", " SN.PART_CODE LIKE '%' + @PART_LIKE + '%' OR SN.PART_NAME LIKE '%' + @PART_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DRAW_LIKE", " SN.DRAW_NO LIKE '%' + @DRAW_LIKE + '%' "));
                        sbWhere.Append(UTIL.GetWhere(row, "@SPEC_LIKE", " SN.MAT_SPEC LIKE '%' + @SPEC_LIKE + '%' "));
                        sbWhere.Append(UTIL.GetWhere(row, "@STK_LOC", " SN.STOCK_LOC LIKE '%' + @STK_LOC + '%' "));
                        sbWhere.Append(UTIL.GetWhere(row, "@SAVE_DATE", " SN.SAVE_DATE = @SAVE_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MNG_FLAG", " SP.MNG_FLAG = @MNG_FLAG"));
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
