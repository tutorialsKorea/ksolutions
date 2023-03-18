using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DENE
{
    public class MovingRack
    {
        public static DataTable MovingRack_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataTable sourceTable = new DataTable();

                
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT S.ITEMCODE, ");
                    sbQuery.Append(" 	P.PART_PRODTYPE, ");
                    sbQuery.Append(" 	P.PART_NAME, ");
                    sbQuery.Append(" 	P.DRAW_NO, ");
                    sbQuery.Append(" 	P.MAT_SPEC, ");
                    sbQuery.Append(" 	S.QTY,  ");
                    sbQuery.Append(" 	S.WHSCODE, ");
                    sbQuery.Append(" 	S.UPDATETIME, ");
                    sbQuery.Append(" 	S.DESCRIPTION ");
                    sbQuery.Append(" FROM [211.244.169.93,31950].[MovingRack_Renew].[DBO].[stock] S JOIN LSE_STD_PART P ");
                    sbQuery.Append("   ON S.ITEMCODE = P.PART_CODE ");
                    sbQuery.Append(" WHERE P.PLT_CODE = @PLT_CODE ");
                    //sbQuery.Append(" ORDER BY S.UPDATETIME ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        StringBuilder sbWhere = new StringBuilder();
                       
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_PRODTYPE_LIKE", "P.PART_PRODTYPE LIKE '%' + @PART_PRODTYPE_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "(P.PART_CODE LIKE '%' + @PART_LIKE + '%' OR P.PART_NAME LIKE '%' + @PART_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DRAW_LIKE", "P.DRAW_NO LIKE '%' + @DRAW_LIKE + '%'"));

                        sbWhere.Append("ORDER BY S.UPDATETIME DESC" );

                        sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(), row).Copy();


    
                    }
                }

                DataSet dsResult = new DataSet();
                sourceTable.TableName = "RSLTDT";
                dsResult.Tables.Add(sourceTable);

                return UTIL.GetDsToDt(dsResult);

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
    }
}
