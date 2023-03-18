using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSTD
{
    public class TSTD_FIELD
    {
        public static DataTable TSTD_FIELD_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE			 ");
                    sbQuery.Append(" ,FIELD_CODE				 ");
                    sbQuery.Append(" ,FIELD_NAME				 ");
                    sbQuery.Append(" ,ORG_CODE					 ");
                    sbQuery.Append(" ,PROC_CODE					 ");
                    sbQuery.Append(" ,FIELD_SEQ					 ");
                    sbQuery.Append(" ,SCOMMENT					 ");
                    sbQuery.Append(" ,REG_DATE					 ");
                    sbQuery.Append(" ,REG_EMP					 ");
                    sbQuery.Append(" ,MDFY_DATE					 ");
                    sbQuery.Append(" ,MDFY_EMP					 ");
                    sbQuery.Append(" ,DEL_DATE					 ");
                    sbQuery.Append(" ,DEL_EMP					 ");
                    sbQuery.Append(" ,DATA_FLAG					 ");
                    sbQuery.Append(" FROM TSTD_FIELD			 ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE	 ");
                    sbQuery.Append(" AND FIELD_CODE = @FIELD_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "FIELD_CODE")) isHasColumn = false;

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

        public static DataTable TSTD_FIELD_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE			 ");
                    sbQuery.Append(" ,FIELD_CODE				 ");
                    sbQuery.Append(" ,FIELD_NAME				 ");
                    sbQuery.Append(" ,ORG_CODE					 ");
                    sbQuery.Append(" ,PROC_CODE					 ");
                    sbQuery.Append(" ,FIELD_SEQ					 ");
                    sbQuery.Append(" ,SCOMMENT					 ");
                    sbQuery.Append(" ,REG_DATE					 ");
                    sbQuery.Append(" ,REG_EMP					 ");
                    sbQuery.Append(" ,MDFY_DATE					 ");
                    sbQuery.Append(" ,MDFY_EMP					 ");
                    sbQuery.Append(" ,DEL_DATE					 ");
                    sbQuery.Append(" ,DEL_EMP					 ");
                    sbQuery.Append(" ,DATA_FLAG					 ");
                    sbQuery.Append(" FROM TSTD_FIELD			 ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE	 ");
                    sbQuery.Append(" AND PROC_CODE = @PROC_CODE");
                    sbQuery.Append(" AND DATA_FLAG = @DATA_FLAG");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "DATA_FLAG")) isHasColumn = false;

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

        public static void TSTD_FIELD_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSTD_FIELD			 ");
                    sbQuery.Append(" SET FIELD_NAME = @FIELD_NAME");
                    sbQuery.Append(" ,ORG_CODE = @ORG_CODE		 ");
                    sbQuery.Append(" ,PROC_CODE = @PROC_CODE	 ");
                    sbQuery.Append(" ,FIELD_SEQ = @FIELD_SEQ	 ");
                    sbQuery.Append(" ,SCOMMENT = @SCOMMENT		 ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() 	 ");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG	 ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE	 ");
                    sbQuery.Append(" AND FIELD_CODE = @FIELD_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "FIELD_CODE")) isHasColumn = false;

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

        public static void TSTD_FIELD_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSTD_FIELD			 ");
                    sbQuery.Append(" SET DEL_DATE = GETDATE()    ");
                    sbQuery.Append(" , DEL_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG	 ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE	 ");
                    sbQuery.Append(" AND FIELD_CODE = @FIELD_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "FIELD_CODE")) isHasColumn = false;

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

        public static void TSTD_FIELD_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO TSTD_FIELD");
                    sbQuery.Append(" (PLT_CODE			   ");
                    sbQuery.Append(" ,FIELD_CODE		   ");
                    sbQuery.Append(" ,FIELD_NAME		   ");
                    sbQuery.Append(" ,ORG_CODE			   ");
                    sbQuery.Append(" ,PROC_CODE			   ");
                    sbQuery.Append(" ,FIELD_SEQ			   ");
                    sbQuery.Append(" ,SCOMMENT			   ");
                    sbQuery.Append(" ,REG_DATE			   ");
                    sbQuery.Append(" ,REG_EMP			   ");
                    sbQuery.Append(" ,DATA_FLAG)		   ");
                    sbQuery.Append(" VALUES				   ");
                    sbQuery.Append(" (@PLT_CODE			   ");
                    sbQuery.Append(" ,@FIELD_CODE		   ");
                    sbQuery.Append(" ,@FIELD_NAME		   ");
                    sbQuery.Append(" ,@ORG_CODE			   ");
                    sbQuery.Append(" ,@PROC_CODE		   ");
                    sbQuery.Append(" ,@FIELD_SEQ		   ");
                    sbQuery.Append(" ,@SCOMMENT			   ");
                    sbQuery.Append(" ,GETDATE()			   ");
                    sbQuery.Append(" , " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" ,@DATA_FLAG)		   ");

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

    public class TSTD_FIELD_QUERY
    {
        public static DataTable TSTD_FIELD_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT F.PLT_CODE			  ");
                    sbQuery.Append(" ,F.FIELD_CODE				  ");
                    sbQuery.Append(" ,F.FIELD_NAME				  ");
                    sbQuery.Append(" ,F.ORG_CODE				  ");
                    sbQuery.Append(" ,O.ORG_NAME				  ");
                    sbQuery.Append(" ,F.PROC_CODE				  ");
                    sbQuery.Append(" ,P.PROC_NAME				  ");
                    sbQuery.Append(" ,F.FIELD_SEQ				  ");
                    sbQuery.Append(" ,F.SCOMMENT				  ");
                    sbQuery.Append(" ,F.REG_DATE				  ");
                    sbQuery.Append(" ,F.REG_EMP					  ");
                    sbQuery.Append(" ,F.MDFY_DATE				  ");
                    sbQuery.Append(" ,F.MDFY_EMP				  ");
                    sbQuery.Append(" ,F.DEL_DATE				  ");
                    sbQuery.Append(" ,F.DEL_EMP					  ");
                    sbQuery.Append(" ,F.DATA_FLAG				  ");
                    sbQuery.Append(" FROM TSTD_FIELD F			  ");
                    sbQuery.Append(" LEFT JOIN TSTD_ORG O		  ");
                    sbQuery.Append(" ON F.PLT_CODE = O.PLT_CODE	  ");
                    sbQuery.Append(" AND F.ORG_CODE = O.ORG_CODE  ");
                    sbQuery.Append(" 							  ");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC P	  ");
                    sbQuery.Append(" ON F.PLT_CODE = P.PLT_CODE	  ");
                    sbQuery.Append(" AND F.PROC_CODE = P.PROC_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE F.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@FIELD_CODE", "F.FIELD_CODE = @FIELD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@FIELD_LIKE", "(F.FIELD_CODE LIKE '%' + @FIELD_LIKE + '%' OR F.FIELD_NAME LIKE '%' + @FIELD_LIKE + '%')"));
                        
                        sbWhere.Append(UTIL.GetWhere(row, "@ORG_CODE", "F.ORG_CODE = @ORG_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@ORG_LIKE", "(F.ORG_CODE LIKE '%' + @ORG_LIKE + '%' OR O.ORG_NAME LIKE '%' + @ORG_LIKE + '%')"));
                        
                        sbWhere.Append(UTIL.GetWhere(row, "@PROC_CODE", "F.PROC_CODE = @PROC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROC_LIKE", "(F.PROC_CODE LIKE '%' + @PROC_LIKE + '%' OR P.PROC_NAME LIKE '%' + @PROC_LIKE + '%')"));

                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "F.DATA_FLAG = @DATA_FLAG"));

                        sbWhere.Append(" ORDER BY F.FIELD_SEQ");

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

        //재고 작업장조회
        public static DataTable TSTD_FIELD_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT							 ");
                    sbQuery.Append(" F.PLT_CODE						 ");
                    sbQuery.Append(" ,F.FIELD_CODE					 ");
                    sbQuery.Append(" ,F.FIELD_NAME					 ");
                    sbQuery.Append(" FROM TSTD_FIELD F				 ");
                    sbQuery.Append(" LEFT JOIN TMAT_FIELD_STOCK FS	 ");
                    sbQuery.Append(" ON F.PLT_CODE = FS.PLT_CODE	 ");
                    sbQuery.Append(" AND F.FIELD_CODE = FS.FIELD_CODE");
                    sbQuery.Append(" 								 ");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART PT		 ");
                    sbQuery.Append(" ON FS.PLT_CODE = PT.PLT_CODE	 ");
                    sbQuery.Append(" AND FS.PART_CODE = PT.PART_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE F.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@FIELD_CODE", "F.FIELD_CODE = @FIELD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@FIELD_LIKE", "(F.FIELD_CODE LIKE '%' + @FIELD_LIKE + '%' OR F.FIELD_NAME LIKE '%' + @FIELD_LIKE + '%')"));

                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "(FS.PART_CODE LIKE '%' + @PART_LIKE + '%' OR PT.PART_NAME LIKE '%' + @PART_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DRAW_LIKE", "(PT.DRAW_NO LIKE '%' + @DRAW_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@SPEC_LIKE", "(PT.MAT_SPEC LIKE '%' + @SPEC_LIKE + '%')"));

                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "F.DATA_FLAG = @DATA_FLAG"));

                        sbWhere.Append(" GROUP BY F.PLT_CODE, F.FIELD_CODE, F.FIELD_NAME, F.FIELD_SEQ");
                        sbWhere.Append(" ORDER BY F.FIELD_SEQ");

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
