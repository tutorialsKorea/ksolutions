using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DMAT
{
    public class TMAT_RET_REQ
    {
        public static DataTable TMAT_RET_REQ_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE			 ");
                    sbQuery.Append(" ,RET_REQ_ID				 ");
                    sbQuery.Append(" ,PART_CODE					 ");
                    sbQuery.Append(" ,FIELD_CODE				 ");
                    sbQuery.Append(" ,RET_REQ_DATE				 ");
                    sbQuery.Append(" ,RET_REQ_EMP				 ");
                    sbQuery.Append(" ,RET_REQ_QTY				 ");
                    sbQuery.Append(" ,RET_REQ_STAT				 ");
                    sbQuery.Append(" ,SCOMMENT					 ");
                    sbQuery.Append(" ,REG_DATE					 ");
                    sbQuery.Append(" ,REG_EMP					 ");
                    sbQuery.Append(" ,MDFY_DATE					 ");
                    sbQuery.Append(" ,MDFY_EMP					 ");
                    sbQuery.Append(" ,DATA_FLAG					 ");
                    sbQuery.Append(" ,DEL_DATE					 ");
                    sbQuery.Append(" ,DEL_EMP					 ");
                    sbQuery.Append(" FROM TMAT_RET_REQ			 ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE	 ");
                    sbQuery.Append(" AND RET_REQ_ID = @RET_REQ_ID");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "RET_REQ_ID")) isHasColumn = false;

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

        public static void TMAT_RET_REQ_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO TMAT_RET_REQ");
                    sbQuery.Append(" (PLT_CODE				 ");
                    sbQuery.Append(" ,RET_REQ_ID			 ");
                    sbQuery.Append(" ,PT_ID			 ");
                    sbQuery.Append(" ,PART_CODE				 ");
                    sbQuery.Append(" ,STOCK_LOC			 ");
                    sbQuery.Append(" ,RET_REQ_DATE			 ");
                    sbQuery.Append(" ,RET_REQ_EMP			 ");
                    sbQuery.Append(" ,RET_REQ_QTY			 ");
                    sbQuery.Append(" ,RET_REQ_COST			 ");
                    sbQuery.Append(" ,RET_REQ_STAT			 ");
                    sbQuery.Append(" ,OUT_ID			 ");
                    sbQuery.Append(" ,SCOMMENT				 ");
                    sbQuery.Append(" ,REG_DATE				 ");
                    sbQuery.Append(" ,REG_EMP				 ");
                    sbQuery.Append(" ,DATA_FLAG)			 ");
                    sbQuery.Append(" VALUES					 ");
                    sbQuery.Append(" (						 ");
                    sbQuery.Append(" @PLT_CODE				 ");
                    sbQuery.Append(" ,@RET_REQ_ID			 ");
                    sbQuery.Append(" ,@PT_ID			 ");
                    sbQuery.Append(" ,@PART_CODE			 ");
                    sbQuery.Append(" ,@STOCK_LOC			 ");
                    sbQuery.Append(" ,@RET_REQ_DATE			 ");
                    sbQuery.Append(" ,@RET_REQ_EMP			 ");
                    sbQuery.Append(" ,@RET_REQ_QTY			 ");
                    sbQuery.Append(" ,@RET_REQ_COST			 ");
                    sbQuery.Append(" ,@RET_REQ_STAT			 ");
                    sbQuery.Append(" ,@OUT_ID			 ");
                    sbQuery.Append(" ,@SCOMMENT				 ");
                    sbQuery.Append(" ,GETDATE()			     ");
                    sbQuery.Append(" ," + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" ,@DATA_FLAG			 ");
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


        public static void TMAT_RET_REQ_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_RET_REQ	   ");
                    sbQuery.Append(" SET RET_REQ_STAT = @RET_REQ_STAT  ");
                    sbQuery.Append("  , RET_REQ_COST = @MAT_COST  ");
                    sbQuery.Append("  , YPGO_ID = @YPGO_ID  ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("   AND RET_REQ_ID = @RET_REQ_ID     ");


                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "RET_REQ_ID")) isHasColumn = false;

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

        public static void TMAT_RET_REQ_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_RET_REQ	   ");
                    sbQuery.Append(" SET RET_REQ_STAT = @RET_REQ_STAT  ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("   AND RET_REQ_ID = (SELECT RET_REQ_ID FROM TMAT_INSP WHERE PLT_CODE = @PLT_CODE AND INSP_ID = @INSP_ID)     ");


                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "INSP_ID")) isHasColumn = false;

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

        public static void TMAT_RET_REQ_UPD3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_RET_REQ	   ");
                    sbQuery.Append(" SET RET_REQ_STAT = @RET_REQ_STAT  ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("   AND RET_REQ_ID = @RET_REQ_ID     ");


                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "RET_REQ_ID")) isHasColumn = false;

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

        public static void TMAT_RET_REQ_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_RET_REQ	   ");
                    sbQuery.Append(" SET   DEL_DATE = GETDATE() ");
                    sbQuery.Append(" , DEL_EMP = '" + ConnInfo.UserID + "'");
                    sbQuery.Append(" , DATA_FLAG = 2 ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("   AND RET_REQ_ID = @RET_REQ_ID     ");


                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "RET_REQ_ID")) isHasColumn = false;

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

    public class TMAT_RET_REQ_QUERY
    {
        public static DataTable TMAT_RET_REQ_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT R.RET_REQ_ID    ");
                    sbQuery.Append(" 	, R.PART_CODE       ");
                    sbQuery.Append(" 	, P.PART_NAME       ");
                    sbQuery.Append(" 	, R.RET_REQ_DATE    ");
                    sbQuery.Append(" 	, R.STOCK_LOC    ");
                    sbQuery.Append(" 	, E.ORG_CODE AS RET_REQ_ORG     ");
                    sbQuery.Append(" 	, O.ORG_NAME AS RET_REQ_ORG_NAME");
                    sbQuery.Append(" 	, R.RET_REQ_EMP     ");
                    sbQuery.Append(" 	, R.RET_REQ_QTY     ");
                    sbQuery.Append("    , R.RET_REQ_COST    ");
                    sbQuery.Append(" 	, R.SCOMMENT            ");
                    sbQuery.Append(" 	, P.DRAW_NO             ");
                    sbQuery.Append(" 	, P.PART_PRODTYPE       ");
                    sbQuery.Append(" 	, P.MAT_LTYPE           ");
                    sbQuery.Append(" 	, P.MAT_MTYPE           ");
                    sbQuery.Append(" 	, P.MAT_STYPE           ");
                    sbQuery.Append(" 	, P.MAT_UNIT            ");
                    sbQuery.Append(" 	, P.MAT_SPEC	        ");
                    sbQuery.Append(" 	, P.INS_FLAG	        ");
                    sbQuery.Append(" 	, P.MAT_TYPE	        ");
                    sbQuery.Append(" FROM TMAT_RET_REQ R        ");
                    sbQuery.Append(" 	JOIN LSE_STD_PART P     ");
                    sbQuery.Append(" 	 ON R.PLT_CODE = P.PLT_CODE         ");
                    sbQuery.Append(" 	 AND R.PART_CODE = P.PART_CODE      ");

                    sbQuery.Append(" 	 LEFT JOIN TSTD_EMPLOYEE E      ");
                    sbQuery.Append(" 	 ON R.PLT_CODE = E.PLT_CODE      ");
                    sbQuery.Append(" 	 AND R.RET_REQ_EMP = E.EMP_CODE      ");

                    sbQuery.Append(" 	 LEFT JOIN TSTD_ORG O      ");
                    sbQuery.Append(" 	 ON E.PLT_CODE = O.PLT_CODE      ");
                    sbQuery.Append(" 	 AND E.ORG_CODE = O.ORG_CODE      ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE R.RET_REQ_STAT IN ( '49', '26')  ");
                        sbWhere.Append(UTIL.GetWhere(row, "@RET_REQ_LIKE", " (R.RET_REQ_ID LIKE '%' + @RET_REQ_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@RET_REQ_ID", " R.RET_REQ_ID = @RET_REQ_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@RET_REQ_ORG", "E.ORG_CODE = @RET_REQ_ORG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", " (R.PART_CODE LIKE '%' + @PART_LIKE + '%' OR P.PART_NAME LIKE '%' + @PART_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DRAW_LIKE", " (P.DRAW_NO LIKE '%' + @DRAW_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@STK_LOC", " R.STOCK_LOC = @STOCK_LOC "));
                        sbWhere.Append(UTIL.GetWhere(row, "@SPEC_LIKE", " (P.MAT_SPEC LIKE '%' + @SPEC_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_RET_REQ_DATE,@E_RET_REQ_DATE", " R.RET_REQ_DATE BETWEEN @S_RET_REQ_DATE AND @E_RET_REQ_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", " R.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(" ORDER BY R.RET_REQ_DATE DESC ");

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


        public static DataTable TMAT_RET_REQ_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT R.RET_REQ_ID    ");
                    sbQuery.Append(" 	, R.PART_CODE       ");
                    sbQuery.Append(" 	, P.PART_NAME       ");
                    sbQuery.Append(" 	, R.RET_REQ_DATE    ");
                    sbQuery.Append(" 	, R.STOCK_LOC    ");
                    sbQuery.Append(" 	, E.ORG_CODE AS RET_REQ_ORG     ");
                    sbQuery.Append(" 	, O.ORG_NAME AS RET_REQ_ORG_NAME");
                    sbQuery.Append(" 	, R.RET_REQ_EMP     ");
                    sbQuery.Append(" 	, R.RET_REQ_QTY     ");
                    sbQuery.Append("    , R.RET_REQ_COST    ");
                    //sbQuery.Append(" 	, R.SCOMMENT            ");
                    sbQuery.Append(" 	, P.DRAW_NO             ");
                    sbQuery.Append(" 	, P.PART_PRODTYPE       ");
                    sbQuery.Append(" 	, P.MAT_LTYPE           ");
                    sbQuery.Append(" 	, P.MAT_MTYPE           ");
                    sbQuery.Append(" 	, P.MAT_STYPE           ");
                    sbQuery.Append(" 	, P.MAT_UNIT            ");
                    sbQuery.Append(" 	, P.MAT_SPEC	        ");
                    sbQuery.Append(" 	, P.INS_FLAG	        ");
                    sbQuery.Append(" 	, P.MAT_TYPE	        ");
                    sbQuery.Append(" 	, R.YPGO_ID	        ");
                    sbQuery.Append(" 	, YP.SCOMMENT	        ");
                    sbQuery.Append(" FROM TMAT_RET_REQ R        ");
                    sbQuery.Append(" 	JOIN LSE_STD_PART P     ");
                    sbQuery.Append(" 	 ON R.PLT_CODE = P.PLT_CODE         ");
                    sbQuery.Append(" 	 AND R.PART_CODE = P.PART_CODE      ");

                    sbQuery.Append(" 	 LEFT JOIN TSTD_EMPLOYEE E      ");
                    sbQuery.Append(" 	 ON R.PLT_CODE = E.PLT_CODE      ");
                    sbQuery.Append(" 	 AND R.RET_REQ_EMP = E.EMP_CODE      "); 

                    sbQuery.Append(" 	 LEFT JOIN TMAT_YPGO YP      ");
                    sbQuery.Append(" 	 ON R.PLT_CODE = YP.PLT_CODE      ");
                    sbQuery.Append(" 	 AND R.YPGO_ID = YP.YPGO_ID      "); 

                    sbQuery.Append(" 	 LEFT JOIN TSTD_ORG O      ");
                    sbQuery.Append(" 	 ON E.PLT_CODE = O.PLT_CODE      ");
                    sbQuery.Append(" 	 AND E.ORG_CODE = O.ORG_CODE      ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE R.RET_REQ_STAT = '22'  ");
                        sbWhere.Append(UTIL.GetWhere(row, "@RET_REQ_LIKE", " (R.RET_REQ_ID LIKE '%' + @RET_REQ_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@RET_REQ_ID", " R.RET_REQ_ID = @RET_REQ_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@RET_REQ_ORG", "E.ORG_CODE = @RET_REQ_ORG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", " (R.PART_CODE LIKE '%' + @PART_LIKE + '%' OR P.PART_NAME LIKE '%' + @PART_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DRAW_LIKE", " (P.DRAW_NO LIKE '%' + @DRAW_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@STK_LOC", " R.STOCK_LOC = @STK_LOC "));
                        sbWhere.Append(UTIL.GetWhere(row, "@SPEC_LIKE", " (P.MAT_SPEC LIKE '%' + @SPEC_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_RET_REQ_DATE,@E_RET_REQ_DATE", " R.RET_REQ_DATE BETWEEN @S_RET_REQ_DATE AND @E_RET_REQ_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", " R.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(" ORDER BY R.RET_REQ_DATE DESC ");

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
