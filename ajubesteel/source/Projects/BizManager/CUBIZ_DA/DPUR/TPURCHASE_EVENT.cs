using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DPUR
{
    public class TPURCHASE_EVENT
    {
        public static void TPURCHASE_EVENT_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();


                    sbQuery.Append(" INSERT INTO TPURCHASE_EVENT");
                    sbQuery.Append(" (							");
                    sbQuery.Append(" PLT_CODE					");
                    sbQuery.Append(" ,REQUEST_NO				");
                    sbQuery.Append(" ,REQUEST_SEQ				");
                    sbQuery.Append(" ,PUR_STAT					");
                    sbQuery.Append(" ,EVENT_DATE				");
                    sbQuery.Append(" ,REG_EMP					");
                    sbQuery.Append(" )							");
                    sbQuery.Append(" VALUES						");
                    sbQuery.Append(" (							");
                    sbQuery.Append(" @PLT_CODE					");
                    sbQuery.Append(" ,@REQUEST_NO				");
                    sbQuery.Append(" ,@REQUEST_SEQ				");
                    sbQuery.Append(" ,@PUR_STAT				 	");
                    sbQuery.Append(" ,GETDATE()			        ");
                    sbQuery.Append(" ," + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" )							");

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

        public static DataTable TPURCHASE_EVENT_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT TOP 1  PLT_CODE ");
                    sbQuery.Append("        , REQUEST_NO ");
                    sbQuery.Append("        , REQUEST_SEQ ");
                    sbQuery.Append("        , PUR_STAT ");
                    sbQuery.Append("        , EVENT_DATE ");
                    sbQuery.Append("        , REG_EMP ");
                    sbQuery.Append("   FROM TPURCHASE_EVENT ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("    AND REQUEST_NO = @REQUEST_NO  ");
                    sbQuery.Append("    AND REQUEST_SEQ = @REQUEST_SEQ  ");
                    sbQuery.Append("    AND PUR_STAT = @PUR_STAT ");
                    sbQuery.Append(" ORDER BY EVENT_DATE DESC ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "REQUEST_NO")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "REQUEST_SEQ")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PUR_STAT")) isHasColumn = false;

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
    }
}
