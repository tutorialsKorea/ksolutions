using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DMAT
{
    public class TMAT_PUR_PARTLIST
    {

        public static DataTable TMAT_PUR_PARTLIST_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE	   ");
                    sbQuery.Append(" ,REQUEST_NO		   ");
                    sbQuery.Append(" ,REQUEST_SEQ		   ");
                    sbQuery.Append(" ,PROD_CODE			   ");
                    sbQuery.Append(" ,PART_CODE			   ");
                    sbQuery.Append(" ,PART_NUM			   ");
                    sbQuery.Append(" ,PT_ID				   ");
                    sbQuery.Append(" ,PT_NAME			   ");
                    sbQuery.Append(" ,PART_PRODTYPE		   ");
                    sbQuery.Append(" ,PART_QLTY			   ");
                    sbQuery.Append(" ,PART_SPEC			   ");
                    sbQuery.Append(" ,PART_SPEC1		   ");
                    sbQuery.Append(" ,PART_QTY			   ");
                    sbQuery.Append(" ,WEIGHT_VOLUME		   ");
                    sbQuery.Append(" ,WEIGHT_VOLUME1	   ");
                    sbQuery.Append(" ,UNIT_COST			   ");
                    sbQuery.Append(" ,MAT_COST			   ");
                    sbQuery.Append(" ,DRAW_EMP			   ");
                    sbQuery.Append(" ,DRAW_NO			   ");
                    sbQuery.Append(" ,O_PT_ID			   ");
                    sbQuery.Append(" ,INS_FLAG			   ");
                    sbQuery.Append(" ,SCOMMENT			   ");
                    sbQuery.Append(" FROM TMAT_PUR_PARTLIST");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND REQUEST_NO = @REQUEST_NO ");
                    sbQuery.Append(" AND REQUEST_SEQ = @REQUEST_SEQ ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "REQUEST_NO")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "REQUEST_SEQ")) isHasColumn = false;

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



        public static void TMAT_PUR_PARLIST_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    
                    sbQuery.Append(" INSERT INTO TMAT_PUR_PARTLIST");
                    sbQuery.Append(" (							  ");
                    sbQuery.Append("  PLT_CODE					  ");
                    sbQuery.Append(" ,REQUEST_NO				  ");
                    sbQuery.Append(" ,REQUEST_SEQ				  ");
                    sbQuery.Append(" ,PROD_CODE					  ");
                    sbQuery.Append(" ,PART_CODE					  ");
                    sbQuery.Append(" ,PART_NUM					  ");
                    sbQuery.Append(" ,PT_ID						  ");
                    sbQuery.Append(" ,PT_NAME					  ");
                    sbQuery.Append(" ,PART_PRODTYPE				  ");
                    sbQuery.Append(" ,PART_QLTY					  ");
                    sbQuery.Append(" ,PART_SPEC					  ");
                    sbQuery.Append(" ,PART_SPEC1				  ");
                    sbQuery.Append(" ,PART_QTY					  ");
                    sbQuery.Append(" ,WEIGHT_VOLUME				  ");
                    sbQuery.Append(" ,WEIGHT_VOLUME1			  ");
                    sbQuery.Append(" ,UNIT_COST					  ");
                    sbQuery.Append(" ,MAT_COST					  ");
                    sbQuery.Append(" ,DRAW_EMP					  ");
                    sbQuery.Append(" ,DRAW_NO					  ");
                    sbQuery.Append(" ,O_PT_ID					  ");
                    sbQuery.Append(" ,INS_FLAG					  ");
                    sbQuery.Append(" ,SCOMMENT)					  ");
                    sbQuery.Append(" VALUES						  ");
                    sbQuery.Append(" (@PLT_CODE					  ");
                    sbQuery.Append(" ,@REQUEST_NO				  ");
                    sbQuery.Append(" ,@REQUEST_SEQ				  ");
                    sbQuery.Append(" ,@PROD_CODE				  ");
                    sbQuery.Append(" ,@PART_CODE				  ");
                    sbQuery.Append(" ,@PART_NUM					  ");
                    sbQuery.Append(" ,@PT_ID					  ");
                    sbQuery.Append(" ,@PT_NAME					  ");
                    sbQuery.Append(" ,@PART_PRODTYPE			  ");
                    sbQuery.Append(" ,@PART_QLTY				  ");
                    sbQuery.Append(" ,@PART_SPEC				  ");
                    sbQuery.Append(" ,@PART_SPEC1				  ");
                    sbQuery.Append(" ,@PART_QTY					  ");
                    sbQuery.Append(" ,@WEIGHT_VOLUME			  ");
                    sbQuery.Append(" ,@WEIGHT_VOLUME1			  ");
                    sbQuery.Append(" ,@UNIT_COST				  ");
                    sbQuery.Append(" ,@MAT_COST					  ");
                    sbQuery.Append(" ,@DRAW_EMP					  ");
                    sbQuery.Append(" ,@DRAW_NO					  ");
                    sbQuery.Append(" ,@O_PT_ID					  ");
                    sbQuery.Append(" ,@INS_FLAG					  ");
                    sbQuery.Append(" ,@SCOMMENT					  ");
                    sbQuery.Append(" )							  ");

                    
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
