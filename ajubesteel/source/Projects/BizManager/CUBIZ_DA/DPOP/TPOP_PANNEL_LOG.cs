using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizExecute;
using System.Data;

namespace DPOP
{
    public class TPOP_PANNEL_LOG
    {
        public static void TPOP_PANEL_LOG_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" DELETE FROM TPOP_PANNEL_LOG");
                    sbQuery.Append(" WHERE UID = @UID ");
                    
                    bizExecute.executeInsertQuery(sbQuery.ToString(), dtParam.Rows[0]);
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataTable TPOP_PANEL_LOG_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                StringBuilder sbQuery = new StringBuilder();
                sbQuery.Append(" SELECT TOP 1 UID " );
                sbQuery.Append("    , PLT_CODE ");
                sbQuery.Append("    , EVENT_DATE ");
                sbQuery.Append("    , EMP_CODE ");
                sbQuery.Append("    , WO_NO ");
                sbQuery.Append("    , MC_CODE ");
                sbQuery.Append("    , PANEL_STAT ");
                sbQuery.Append(" FROM TPOP_PANNEL_LOG ");

                foreach (DataRow row in dtParam.Rows)
                {

                    StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                    sbWhere.Append(UTIL.GetWhere(row, "@WO_NO", "WO_NO = @WO_NO "));
                    sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "EMP_CODE = @EMP_CODE "));
                    sbWhere.Append(UTIL.GetWhere(row, "@MC_CODE", "MC_CODE = @MC_CODE "));

                    sbWhere.Append(" ORDER BY EVENT_DATE DESC ");

                    DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

                    sourceTable.TableName = "RSLTDT";
                    dsResult.Merge(sourceTable);

                }

                return UTIL.GetDsToDt(dsResult);

            } 
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static void TPOP_PANEL_LOG_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO TPOP_PANNEL_LOG");
                    sbQuery.Append(" (PLT_CODE");
                    sbQuery.Append(" ,EVENT_DATE");
                    sbQuery.Append(" ,EMP_CODE");
                    sbQuery.Append(" ,WO_NO");
                    sbQuery.Append(" ,MC_CODE");
                    sbQuery.Append(" ,PANEL_STAT");
                    sbQuery.Append(" ,MC_NM_CHECK");
                    sbQuery.Append(" ,MULTI_START_CNT");
                    sbQuery.Append(" ,ACT_TL_NO");
                    sbQuery.Append(" ,OK_QTY");
                    sbQuery.Append(" ,NG_QTY");
                    sbQuery.Append(" ,PAUSE_REASON");
                    sbQuery.Append(" )");
                    sbQuery.Append(" VALUES");
                    sbQuery.Append(" ( @PLT_CODE");
                    sbQuery.Append(" , GETDATE()");
                    sbQuery.Append(" , @EMP_CODE");
                    sbQuery.Append(" , @WO_NO");
                    sbQuery.Append(" , @MC_CODE");
                    sbQuery.Append(" , @PANEL_STAT");
                    sbQuery.Append(" , @MC_NM_CHECK");
                    sbQuery.Append(" , @MULTI_START_CNT");
                    sbQuery.Append(" , NULL");
                    sbQuery.Append(" , @OK_QTY");
                    sbQuery.Append(" , @NG_QTY");
                    sbQuery.Append(" , @PAUSE_REASON");
                    sbQuery.Append(" )");

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
}
