using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DMAT
{
    public class TMAT_OUT_COST
    {
        public static DataTable TMAT_OUT_COST_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE		   ");
                    sbQuery.Append(" ,OC_ID					   ");
                    sbQuery.Append(" ,YPGO_ID				   ");
                    sbQuery.Append(" ,PART_CODE				   ");
                    sbQuery.Append(" ,QTY					   ");
                    sbQuery.Append(" ,COST					   ");
                    sbQuery.Append(" ,AMT					   ");
                    sbQuery.Append(" ,REG_DATE				   ");
                    sbQuery.Append(" ,REG_EMP				   ");
                    sbQuery.Append(" FROM TMAT_OUT_COST		   ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND OC_ID = @OC_ID		   ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "OC_ID")) isHasColumn = false;

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

        public static DataTable TMAT_OUT_COST_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE		      ");
                    sbQuery.Append(" ,OC_ID					      ");
                    sbQuery.Append(" ,OUT_ID				      ");
                    sbQuery.Append(" ,PART_CODE				      ");
                    sbQuery.Append(" ,QTY					      ");
                    sbQuery.Append(" ,COST					      ");
                    sbQuery.Append(" ,AMT					      ");
                    sbQuery.Append(" ,REG_DATE				      ");
                    sbQuery.Append(" ,REG_EMP				      ");
                    sbQuery.Append(" FROM TMAT_OUT_COST		      ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE   ");
                    sbQuery.Append(" AND OUT_ID = @OUT_ID	      ");
                    sbQuery.Append(" ORDER BY REG_DATE DESC ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "OUT_ID")) isHasColumn = false;

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

        public static void TMAT_OUT_COST_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                //throw new Exception("exit");

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TMAT_OUT_COST");
                    sbQuery.Append(" (PLT_CODE				  ");
                    sbQuery.Append(" ,OC_ID					  ");
                    sbQuery.Append(" ,YPGO_ID				  ");
                    sbQuery.Append(" ,OUT_ID				  ");
                    sbQuery.Append(" ,PART_CODE				  ");
                    sbQuery.Append(" ,QTY					  ");
                    sbQuery.Append(" ,COST					  ");
                    sbQuery.Append(" ,AMT					  ");
                    sbQuery.Append(" ,REG_DATE				  ");
                    sbQuery.Append(" ,REG_EMP)				  ");
                    sbQuery.Append(" VALUES					  ");
                    sbQuery.Append(" (@PLT_CODE				  ");
                    sbQuery.Append(" ,@OC_ID				  ");
                    sbQuery.Append(" ,@YPGO_ID				  ");
                    sbQuery.Append(" ,@OUT_ID				  ");
                    sbQuery.Append(" ,@PART_CODE			  ");
                    sbQuery.Append(" ,@QTY					  ");
                    sbQuery.Append(" ,@COST					  ");
                    sbQuery.Append(" ,@AMT					  ");
                    sbQuery.Append(" ,GETDATE()			  ");
                    sbQuery.Append(" ," + UTIL.GetValidValue(ConnInfo.UserID));
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

    public class TMAT_OUT_COST_QUERY
    {
        public static DataTable TMAT_OUT_COST_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();


                    sbQuery.Append(" SELECT						");
                    sbQuery.Append("  OC.PLT_CODE				");
                    sbQuery.Append(" ,OC.OC_ID					");
                    sbQuery.Append(" ,OC.OUT_ID					");
                    sbQuery.Append(" ,OC.YPGO_ID				");
                    sbQuery.Append(" ,OC.PART_CODE				");
                    sbQuery.Append(" ,OC.QTY					");
                    sbQuery.Append(" ,OC.COST					");
                    sbQuery.Append(" ,OC.AMT					");
                    sbQuery.Append(" ,Y.YPGO_DATE				");
                    sbQuery.Append(" ,Y.YPGO_LOC				");
                    sbQuery.Append(" FROM TMAT_OUT_COST OC		");
                    sbQuery.Append(" LEFT JOIN TMAT_YPGO Y		");
                    sbQuery.Append(" ON OC.PLT_CODE = Y.PLT_CODE");
                    sbQuery.Append(" AND OC.YPGO_ID = Y.YPGO_ID	");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE OC.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@OUT_ID", " OUT_ID = @OUT_ID"));
                        
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
