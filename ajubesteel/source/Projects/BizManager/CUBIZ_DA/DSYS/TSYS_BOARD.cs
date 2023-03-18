using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSYS
{
    public class TSYS_BOARD
    {

        public static DataTable TSYS_BOARD_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE");
                    sbQuery.Append(" ,BOARD_ID		");
                    sbQuery.Append(" ,LINK_ID		");
                    sbQuery.Append(" ,TITLE			");
                    sbQuery.Append(" ,ACC_LEVEL		");
                    sbQuery.Append(" ,CONTENTS		");
                    sbQuery.Append(" ,RECEIVER		");
                    sbQuery.Append(" ,REG_DATE		");
                    sbQuery.Append(" ,REG_EMP		");
                    sbQuery.Append(" ,MDFY_DATE		");
                    sbQuery.Append(" ,MDFY_EMP		");
                    sbQuery.Append(" ,DEL_DATE		");
                    sbQuery.Append(" ,DEL_EMP		");
                    sbQuery.Append(" ,DATA_FLAG		");
                    sbQuery.Append(" FROM TSYS_BOARD");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND BOARD_ID = @BOARD_ID ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "BOARD_ID")) isHasColumn = false;

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

        public static void TSYS_BOARD_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSYS_BOARD		   ");
                    sbQuery.Append(" SET TITLE = @TITLE		   ");
                    sbQuery.Append(" ,ACC_LEVEL = @ACC_LEVEL   ");
                    sbQuery.Append(" ,CONTENTS = @CONTENTS	   ");
                    sbQuery.Append(" ,RECEIVER = @RECEIVER	   ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE()	   ");
                    sbQuery.Append(" ,MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND BOARD_ID = @BOARD_ID  ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크                        
                        if (!UTIL.ValidColumn(row, "BOARD_ID")) isHasColumn = false;

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

        //게시판 읽은사람 업데이트
        public static void TSYS_BOARD_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSYS_BOARD	SET    ");
                    sbQuery.Append(" READER = CASE WHEN READER IS NULL OR READER = '' THEN @READER ELSE READER +',' + @READER END ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE()	   ");
                    sbQuery.Append(" ,MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND BOARD_ID = @BOARD_ID  ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크                        
                        if (!UTIL.ValidColumn(row, "BOARD_ID")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "READER")) isHasColumn = false;

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

        public static void TSYS_BOARD_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();


                    sbQuery.Append(" INSERT INTO TSYS_BOARD");
                    sbQuery.Append(" (PLT_CODE			   ");
                    sbQuery.Append(" ,BOARD_ID			   ");
                    sbQuery.Append(" ,LINK_ID			   ");
                    sbQuery.Append(" ,TITLE				   ");
                    sbQuery.Append(" ,ACC_LEVEL			   ");
                    sbQuery.Append(" ,CONTENTS			   ");
                    sbQuery.Append(" ,RECEIVER			   ");
                    sbQuery.Append(" ,REG_DATE			   ");
                    sbQuery.Append(" ,REG_EMP			   ");
                    sbQuery.Append(" ,DATA_FLAG)		   ");
                    sbQuery.Append(" VALUES				   ");
                    sbQuery.Append("            		   ");
                    sbQuery.Append(" (@PLT_CODE			   ");
                    sbQuery.Append(" ,@BOARD_ID			   ");
                    sbQuery.Append(" ,@LINK_ID			   ");
                    sbQuery.Append(" ,@TITLE			   ");
                    sbQuery.Append(" ,@ACC_LEVEL		   ");
                    sbQuery.Append(" ,@CONTENTS			   ");
                    sbQuery.Append(" ,@RECEIVER			   ");
                    sbQuery.Append(" ,GETDATE()			   ");
                    sbQuery.Append(" ," + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" ,0					   ");
                    sbQuery.Append(" )					   ");

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

        public static void TSYS_BOARD_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("UPDATE TSYS_BOARD ");
                    sbQuery.Append("  SET   DEL_DATE = GETDATE() ");
                    sbQuery.Append("      , DEL_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("      , DATA_FLAG = 2 ");
                    sbQuery.Append("WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND BOARD_ID = @BOARD_ID ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크                        
                        if (!UTIL.ValidColumn(row, "BOARD_ID")) isHasColumn = false;

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

        //댓글삭제
        public static void TSYS_BOARD_UDE2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("UPDATE TSYS_BOARD ");
                    sbQuery.Append("  SET   DEL_DATE = GETDATE() ");
                    sbQuery.Append("      , DEL_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("      , DATA_FLAG = 2 ");
                    sbQuery.Append("WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND LINK_ID = @LINK_ID ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크                        
                        if (!UTIL.ValidColumn(row, "BOARD_ID")) isHasColumn = false;

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

    public class TSYS_BOARD_QUERY
    {
        //게시글조회
        public static DataTable TSYS_BOARD_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT B.PLT_CODE			 ");
                    sbQuery.Append(" ,B.BOARD_ID				 ");
                    sbQuery.Append(" ,LINK_ID					 ");
                    sbQuery.Append(" ,TITLE						 ");
                    sbQuery.Append(" ,B.ACC_LEVEL				 ");
                    sbQuery.Append(" ,CONTENTS					 ");
                    sbQuery.Append(" ,RECEIVER					 ");
                    sbQuery.Append(" ,READER					 ");
                    sbQuery.Append(" ,B.REG_DATE				 ");
                    sbQuery.Append(" ,B.REG_EMP					 ");
                    sbQuery.Append(" , REG.EMP_NAME + ' (' + B.REG_EMP + ')' AS REG_EMP_NAME				 ");
                     
                    sbQuery.Append(" ,B.MDFY_DATE					 ");
                    sbQuery.Append(" ,B.MDFY_EMP					 ");
                    sbQuery.Append(" ,B.DEL_DATE					 ");
                    sbQuery.Append(" ,B.DEL_EMP					 ");
                    sbQuery.Append(" ,B.DATA_FLAG					 ");
                    sbQuery.Append(" FROM TSYS_BOARD B			 ");
                    sbQuery.Append(" LEFT JOIN TSYS_BOARD_EMP BE ");
                    sbQuery.Append(" ON B.PLT_CODE = BE.PLT_CODE ");
                    sbQuery.Append(" AND B.BOARD_ID = BE.BOARD_ID");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG ");
                    sbQuery.Append(" ON B.PLT_CODE = REG.PLT_CODE ");
                    sbQuery.Append(" AND B.REG_EMP = REG.EMP_CODE");
                    
                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE B.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@BOARD_ID", "B.BOARD_ID = @BOARD_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@TITLE", "B.TITLE LIKE '%' + @TITLE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE,@REG_EMP", "(BE.EMP_CODE = @EMP_CODE OR B.REG_EMP = @REG_EMP OR ACC_LEVEL = 'P')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DATE,@E_DATE", "B.REG_DATE BETWEEN @S_DATE AND @E_DATE"));
                        sbWhere.Append(" AND B.LINK_ID IS NULL AND B.DATA_FLAG = '0'");

                        StringBuilder sbGroup = new StringBuilder();

                        sbGroup.Append(" GROUP BY B.PLT_CODE");
                        sbGroup.Append(" ,B.BOARD_ID		");
                        sbGroup.Append(" ,B.LINK_ID			");
                        sbGroup.Append(" ,B.TITLE				");
                        sbGroup.Append(" ,B.ACC_LEVEL		");
                        sbGroup.Append(" ,B.CONTENTS			");
                        sbGroup.Append(" ,B.RECEIVER			");
                        sbGroup.Append(" ,B.READER			");
                        sbGroup.Append(" ,B.REG_DATE		");
                        sbGroup.Append(" ,B.REG_EMP			");
                        sbGroup.Append(" ,B.MDFY_DATE			");
                        sbGroup.Append(" ,B.MDFY_EMP			");
                        sbGroup.Append(" ,B.DEL_DATE			");
                        sbGroup.Append(" ,B.DEL_EMP			");
                        sbGroup.Append(" ,B.DATA_FLAG			");
                        sbGroup.Append(" ,REG.EMP_NAME			");
                        sbGroup.Append(" ORDER BY B.REG_DATE");

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString() + sbGroup.ToString(), row).Copy();

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

        //댓글조회
        public static DataTable TSYS_BOARD_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE");
                    sbQuery.Append(" ,BOARD_ID	   	");
                    sbQuery.Append(" ,LINK_ID		");
                    sbQuery.Append(" ,TITLE	        ");
                    sbQuery.Append(" ,ACC_LEVEL     ");
                    sbQuery.Append(" ,CONTENTS	    ");
                    sbQuery.Append(" ,RECEIVER		");
                    sbQuery.Append(" ,REG_DATE		");
                    sbQuery.Append(" ,REG_EMP		");
                    sbQuery.Append(" ,MDFY_DATE		");
                    sbQuery.Append(" ,MDFY_EMP		");
                    sbQuery.Append(" ,DEL_DATE		");
                    sbQuery.Append(" ,DEL_EMP		");
                    sbQuery.Append(" ,DATA_FLAG		");
                    sbQuery.Append(" FROM TSYS_BOARD");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@LINK_ID", "LINK_ID = @LINK_ID"));
                        sbWhere.Append(" AND LINK_ID IS NOT NULL AND DATA_FLAG = '0'");
                        sbWhere.Append(" ORDER BY REG_DATE");

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(), row).Copy();

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

        //실시간 게시판 알림 창
        public static DataTable TSYS_BOARD_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT B.PLT_CODE			 ");
                    sbQuery.Append(" ,B.BOARD_ID				 ");
                    sbQuery.Append(" ,B.LINK_ID					 ");
                    sbQuery.Append(" ,B.TITLE						 ");
                    sbQuery.Append(" ,B.ACC_LEVEL				 ");
                    sbQuery.Append(" ,B.CONTENTS					 ");
                    sbQuery.Append(" ,ISNULL(RECEIVER,'전체') AS RECEIVER					 ");
                    sbQuery.Append(" ,B.REG_DATE				 ");
                    sbQuery.Append(" ,B.REG_EMP					 ");
                    sbQuery.Append(" ,REG.EMP_NAME AS REG_EMP_NAME	");
                    sbQuery.Append(" ,B.MDFY_DATE					 ");
                    sbQuery.Append(" ,B.MDFY_EMP					 ");
                    sbQuery.Append(" ,B.DEL_DATE					 ");
                    sbQuery.Append(" ,B.DEL_EMP					 ");
                    sbQuery.Append(" ,B.DATA_FLAG					 ");
                    sbQuery.Append(" FROM TSYS_BOARD B			 ");
                    sbQuery.Append(" LEFT JOIN TSYS_BOARD_EMP BE ");
                    sbQuery.Append(" ON B.PLT_CODE = BE.PLT_CODE ");
                    sbQuery.Append(" AND B.BOARD_ID = BE.BOARD_ID");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG ");
                    sbQuery.Append(" ON B.PLT_CODE = REG.PLT_CODE ");
                    sbQuery.Append(" AND B.REG_EMP = REG.EMP_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE B.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "(BE.EMP_CODE = @EMP_CODE OR B.ACC_LEVEL = 'P')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "B.REG_EMP <> @EMP_CODE"));
                        //sbWhere.Append(" AND B.LINK_ID IS NULL AND B.DATA_FLAG = '0' AND ISNULL(BE.IS_READ,0) <> '1' ");
                        sbWhere.Append(" AND B.DATA_FLAG = '0' AND ISNULL(BE.IS_READ,0) <> '1' ");

                        StringBuilder sbGroup = new StringBuilder();

                        sbGroup.Append(" GROUP BY B.PLT_CODE");
                        sbGroup.Append(" ,B.BOARD_ID		");
                        sbGroup.Append(" ,B.LINK_ID			");
                        sbGroup.Append(" ,B.TITLE				");
                        sbGroup.Append(" ,B.ACC_LEVEL		");
                        sbGroup.Append(" ,B.CONTENTS			");
                        sbGroup.Append(" ,B.RECEIVER			");
                        sbGroup.Append(" ,B.REG_DATE		");
                        sbGroup.Append(" ,B.REG_EMP			");
                        sbGroup.Append(" ,B.MDFY_DATE			");
                        sbGroup.Append(" ,B.MDFY_EMP			");
                        sbGroup.Append(" ,B.DEL_DATE			");
                        sbGroup.Append(" ,B.DEL_EMP			");
                        sbGroup.Append(" ,B.DATA_FLAG			");
                        sbGroup.Append(" ,REG.EMP_NAME		");
                        sbGroup.Append(" ORDER BY B.REG_DATE");

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString() + sbGroup.ToString(), row).Copy();

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

        public static DataTable TSYS_BOARD_QUERY4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT B.PLT_CODE			 ");
                    sbQuery.Append("    , B.BOARD_ID  ");
                    sbQuery.Append(" 	, B.LINK_ID   ");
                    sbQuery.Append(" 	, M.TITLE     ");
                    sbQuery.Append(" 	, M.CONTENTS  ");
                    sbQuery.Append(" 	, M.ACC_LEVEL ");
                    sbQuery.Append(" 	, B.TITLE AS REPLY_TITLE  ");
                    sbQuery.Append(" 	, B.CONTENTS AS REPLY_CONTENTS  ");
                    sbQuery.Append(" 	, ISNULL(B.RECEIVER, '전체') AS RECEIVER  ");
                    sbQuery.Append(" 	, B.REG_DATE  ");
                    sbQuery.Append(" 	, B.REG_EMP   ");
                    sbQuery.Append(" 	, M.REG_EMP   ");

                    sbQuery.Append(" FROM TSYS_BOARD B ");
                    sbQuery.Append("   JOIN TSYS_BOARD M ");
                    sbQuery.Append("    ON B.PLT_CODE = M.PLT_CODE ");
                    sbQuery.Append("   AND B.LINK_ID = M.BOARD_ID ");
                    sbQuery.Append("   LEFT JOIN TSYS_BOARD_EMP BE  ");
                    sbQuery.Append("   ON B.PLT_CODE = BE.PLT_CODE ");
                    sbQuery.Append("   AND B.BOARD_ID = BE.BOARD_ID ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE B.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        //sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "(BE.EMP_CODE = @EMP_CODE OR M.ACC_LEVEL = 'P')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "M.REG_EMP = @EMP_CODE"));
                        sbWhere.Append(" AND B.DATA_FLAG = 0 AND ISNULL(BE.IS_READ,0) <> 1 AND B.LINK_ID IS NOT NULL ");

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(), row).Copy();

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
