using BizExecute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMAT
{
    public class TMAT_OUT_SHIP
    {
        public static DataTable TMAT_OUT_SHIP_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  UID ");
                    sbQuery.Append(" ,PLT_CODE ");
                    sbQuery.Append(" ,SHIP_ID ");
                    sbQuery.Append(" ,OUT_ID ");
                    sbQuery.Append(" ,SHIP_QTY ");
                    sbQuery.Append("  FROM TMAT_OUT_SHIP  ");
                    sbQuery.Append("  WHERE SHIP_ID = @SHIP_ID  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "SHIP_ID")) isHasColumn = false;

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

        public static void TMAT_OUT_SHIP_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TMAT_OUT_SHIP (  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,SHIP_ID ");
                    sbQuery.Append(" ,OUT_ID ");
                    sbQuery.Append(" ,SHIP_QTY ");
                    sbQuery.Append("  ) VALUES (  ");
                    sbQuery.Append("  @PLT_CODE ");
                    sbQuery.Append(" ,@SHIP_ID ");
                    sbQuery.Append(" ,@OUT_ID ");
                    sbQuery.Append(" ,@SHIP_QTY ");
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

        public static void TMAT_OUT_SHIP_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_OUT_SHIP SET  ");
                    sbQuery.Append("  PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" ,SHIP_ID = @SHIP_ID ");
                    sbQuery.Append(" ,OUT_ID = @OUT_ID ");
                    sbQuery.Append(" ,SHIP_QTY = @SHIP_QTY ");
                    sbQuery.Append("  WHERE UID = @UID ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "UID")) isHasColumn = false;

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
}
