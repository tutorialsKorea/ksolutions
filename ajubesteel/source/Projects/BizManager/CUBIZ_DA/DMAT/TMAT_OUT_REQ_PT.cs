using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DMAT
{
    public class TMAT_OUT_REQ_PT
    {
        public static void TMAT_OUT_REQ_PT_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TMAT_OUT_REQ_PT");
                    sbQuery.Append(" (PLT_CODE				 ");
                    sbQuery.Append(" ,OUT_REQ_ID			 ");
                    sbQuery.Append(" ,PART_CODE 			 ");
                    sbQuery.Append(" ,PT_ID 				 ");
                    sbQuery.Append(" ,REQ_QTY 				 ");
                    sbQuery.Append(" ,SCOMMENT 				 ");
                    sbQuery.Append(" )       				 ");
                    sbQuery.Append(" VALUES					 ");
                    sbQuery.Append(" (						 ");
                    sbQuery.Append(" @PLT_CODE				 ");
                    sbQuery.Append(" ,@OUT_REQ_ID			 ");
                    sbQuery.Append(" ,@PART_CODE   			 ");
                    sbQuery.Append(" ,@PT_ID    			 ");
                    sbQuery.Append(" ,@REQ_QTY 				 ");
                    sbQuery.Append(" ,@SCOMMENT 				 ");
                    sbQuery.Append(" )						 ");


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

        public static void TMAT_OUT_REQ_PT_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" DELETE FROM TMAT_OUT_REQ_PT");
                    sbQuery.Append(" WHERE PLT_CODE	  = @PLT_CODE ");
                    sbQuery.Append("  AND OUT_REQ_ID  = @OUT_REQ_ID ");
                    sbQuery.Append("  AND PART_CODE = @PART_CODE ");
                    sbQuery.Append("  AND PT_ID  = @PT_ID ");

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


        public static DataTable TMAT_OUT_REQ_PT_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT ");
                    sbQuery.Append(" PLT_CODE				 ");
                    sbQuery.Append(" ,OUT_REQ_ID			 ");
                    sbQuery.Append(" ,PART_CODE 			 ");
                    sbQuery.Append(" ,PT_ID 				 ");
                    sbQuery.Append(" ,REQ_QTY 				 ");
                    sbQuery.Append(" ,SCOMMENT 				 ");
                    sbQuery.Append(" FROM TMAT_OUT_REQ_PT    ");
                    sbQuery.Append(" WHERE 	PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND OUT_REQ_ID = @OUT_REQ_ID ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "OUT_REQ_ID")) isHasColumn = false;

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

    public class TMAT_OUT_REQ_PT_QUERY
    {
        public static DataTable TMAT_OUT_REQ_PT_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT                  ");
                    sbQuery.Append(" 	RP.OUT_REQ_ID        ");
                    sbQuery.Append("    , RP.REQ_QTY 				 ");
                    sbQuery.Append("    , RP.SCOMMENT 				 ");
                    sbQuery.Append(" 	, RP.PART_CODE       ");
                    sbQuery.Append(" 	, PT.PART_NAME       ");
                    sbQuery.Append(" 	, PT.MAT_SPEC        ");
                    sbQuery.Append(" 	, PT.PART_PRODTYPE   ");
                    sbQuery.Append(" 	, PT.DRAW_NO         ");
                    sbQuery.Append(" 	, PTL.SERIAL_NO      ");

                    sbQuery.Append(" FROM TMAT_OUT_REQ_PT RP JOIN LSE_STD_PART PT  ");
                    sbQuery.Append("   ON RP.PLT_CODE = PT.PLT_CODE                ");
                    sbQuery.Append(" AND RP.PART_CODE = PT.PART_CODE               ");
                    sbQuery.Append("  JOIN TMAT_PARTLIST PTL                       ");
                    sbQuery.Append("   ON RP.PLT_CODE = PTL.PLT_CODE               ");
                    sbQuery.Append(" AND RP.PT_ID = PTL.PT_ID                      ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PT.DATA_FLAG = 0  ");

                        sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", " RP.PLT_CODE = @PLT_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@OUT_REQ_ID", "RP.OUT_REQ_ID = @OUT_REQ_ID"));

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
