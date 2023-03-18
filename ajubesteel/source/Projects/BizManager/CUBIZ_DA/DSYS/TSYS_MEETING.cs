using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSYS
{
    public class TSYS_MEETING
    {

        public static DataTable TSYS_MEETING_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE");
                    sbQuery.Append(" ,MEETING_ID    ");
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
                    sbQuery.Append(" FROM TSYS_MEETING");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND MEETING_ID = @MEETING_ID ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "MEETING_ID")) isHasColumn = false;

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

        public static void TSYS_MEETING_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSYS_MEETING	   ");
                    sbQuery.Append(" SET TITLE = @TITLE		   ");
                    sbQuery.Append(" ,ACC_LEVEL = @ACC_LEVEL   ");
                    sbQuery.Append(" ,CONTENTS = @CONTENTS	   ");
                    sbQuery.Append(" ,RECEIVER = @RECEIVER	   ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE()	   ");
                    sbQuery.Append(" ,MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND MEETING_ID = @MEETING_ID  ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크                        
                        if (!UTIL.ValidColumn(row, "MEETING_ID")) isHasColumn = false;

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
        public static void TSYS_MEETING_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSYS_MEETING	SET    ");
                    sbQuery.Append(" READER = CASE WHEN READER IS NULL OR READER = '' THEN @READER ELSE READER +',' + @READER END ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE()	   ");
                    sbQuery.Append(" ,MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND MEETING_ID = @MEETING_ID  ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크                        
                        if (!UTIL.ValidColumn(row, "MEETING_ID")) isHasColumn = false;
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

        public static void TSYS_MEETING_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();


                    sbQuery.Append(" INSERT INTO TSYS_MEETING ");
                    sbQuery.Append(" (PLT_CODE			   ");
                    sbQuery.Append(" ,MEETING_ID		   ");
                    sbQuery.Append(" ,LINK_ID			   ");
                    sbQuery.Append(" ,TITLE				   ");
                    sbQuery.Append(" ,ACC_LEVEL			   ");
                    sbQuery.Append(" ,CONTENTS			   ");
                    sbQuery.Append(" ,RECEIVER			   ");
                    sbQuery.Append(" ,METTING_TYPE		   ");
                    sbQuery.Append(" ,REG_DATE			   ");
                    sbQuery.Append(" ,REG_EMP			   ");
                    sbQuery.Append(" ,DATA_FLAG)		   ");
                    sbQuery.Append(" VALUES				   ");
                    sbQuery.Append("            		   ");
                    sbQuery.Append(" (@PLT_CODE			   ");
                    sbQuery.Append(" ,@MEETING_ID		   ");
                    sbQuery.Append(" ,@LINK_ID			   ");
                    sbQuery.Append(" ,@TITLE			   ");
                    sbQuery.Append(" ,@ACC_LEVEL		   ");
                    sbQuery.Append(" ,@CONTENTS			   ");
                    sbQuery.Append(" ,@RECEIVER			   ");
                    sbQuery.Append(" ,@METTING_TYPE		   ");
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

        public static void TSYS_MEETING_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("UPDATE TSYS_MEETING ");
                    sbQuery.Append("  SET   DEL_DATE = GETDATE() ");
                    sbQuery.Append("      , DEL_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("      , DATA_FLAG = 2 ");
                    sbQuery.Append("WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND MEETING_ID = @MEETING_ID ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크                        
                        if (!UTIL.ValidColumn(row, "MEETING_ID")) isHasColumn = false;

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
        public static void TSYS_MEETING_UDE2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("UPDATE TSYS_MEETING ");
                    sbQuery.Append("  SET   DEL_DATE = GETDATE() ");
                    sbQuery.Append("      , DEL_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("      , DATA_FLAG = 2 ");
                    sbQuery.Append("WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND LINK_ID = @LINK_ID ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크                        
                        if (!UTIL.ValidColumn(row, "MEETING_ID")) isHasColumn = false;

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

    public class TSYS_MEETING_QUERY
    {
        //게시글조회
        public static DataTable TSYS_MEETING_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT M.PLT_CODE			 ");
                    sbQuery.Append(" ,M.MEETING_ID				 ");
                    sbQuery.Append(" ,LINK_ID					 ");
                    sbQuery.Append(" ,TITLE						 ");
                    sbQuery.Append(" ,M.ACC_LEVEL				 ");
                    sbQuery.Append(" ,CONTENTS					 ");
                    sbQuery.Append(" ,RECEIVER					 ");
                    sbQuery.Append(" ,READER					 ");
                    sbQuery.Append(" ,M.REG_DATE				 ");
                    sbQuery.Append(" ,M.REG_EMP					 ");
                    sbQuery.Append(" , REG.EMP_NAME + ' (' + M.REG_EMP + ')' AS REG_EMP_NAME				 ");
                     
                    sbQuery.Append(" ,M.MDFY_DATE					 ");
                    sbQuery.Append(" ,M.MDFY_EMP					 ");
                    sbQuery.Append(" ,M.DEL_DATE					 ");
                    sbQuery.Append(" ,M.DEL_EMP					 ");
                    sbQuery.Append(" ,M.DATA_FLAG					 ");
                    sbQuery.Append(" FROM TSYS_MEETING M			 ");
                    sbQuery.Append(" LEFT JOIN TSYS_MEETING_EMP ME ");
                    sbQuery.Append(" ON M.PLT_CODE = ME.PLT_CODE ");
                    sbQuery.Append(" AND M.MEETING_ID = ME.MEETING_ID");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG ");
                    sbQuery.Append(" ON M.PLT_CODE = REG.PLT_CODE ");
                    sbQuery.Append(" AND M.REG_EMP = REG.EMP_CODE");
                    
                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE M.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@MEETING_ID", "M.MEETING_ID = @MEETING_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@TITLE", "M.TITLE LIKE '%' + @TITLE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE,@REG_EMP", "(ME.EMP_CODE = @EMP_CODE OR M.REG_EMP = @REG_EMP OR ACC_LEVEL = 'P')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DATE,@E_DATE", "M.REG_DATE BETWEEN @S_DATE AND @E_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@METTING_TYPE", "M.METTING_TYPE = @METTING_TYPE"));
                        sbWhere.Append(" AND M.LINK_ID IS NULL AND M.DATA_FLAG = '0'");

                        StringBuilder sbGroup = new StringBuilder();

                        sbGroup.Append(" GROUP BY M.PLT_CODE");
                        sbGroup.Append(" ,M.MEETING_ID		");
                        sbGroup.Append(" ,M.LINK_ID			");
                        sbGroup.Append(" ,M.TITLE				");
                        sbGroup.Append(" ,M.ACC_LEVEL		");
                        sbGroup.Append(" ,M.CONTENTS			");
                        sbGroup.Append(" ,M.RECEIVER			");
                        sbGroup.Append(" ,M.READER			");
                        sbGroup.Append(" ,M.REG_DATE		");
                        sbGroup.Append(" ,M.REG_EMP			");
                        sbGroup.Append(" ,M.MDFY_DATE			");
                        sbGroup.Append(" ,M.MDFY_EMP			");
                        sbGroup.Append(" ,M.DEL_DATE			");
                        sbGroup.Append(" ,M.DEL_EMP			");
                        sbGroup.Append(" ,M.DATA_FLAG			");
                        sbGroup.Append(" ,REG.EMP_NAME			");
                        sbGroup.Append(" ORDER BY M.REG_DATE");

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
        public static DataTable TSYS_MEETING_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE");
                    sbQuery.Append(" ,MEETING_ID	");
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
                    sbQuery.Append(" FROM TSYS_MEETING");

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
        public static DataTable TSYS_MEETING_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT M.PLT_CODE			 ");
                    sbQuery.Append(" ,M.MEETING_ID				 ");
                    sbQuery.Append(" ,M.LINK_ID					 ");
                    sbQuery.Append(" ,M.TITLE					 ");
                    sbQuery.Append(" ,M.ACC_LEVEL				 ");
                    sbQuery.Append(" ,M.CONTENTS				 ");
                    sbQuery.Append(" ,ISNULL(RECEIVER,'전체') AS RECEIVER					 ");
                    sbQuery.Append(" ,M.REG_DATE				 ");
                    sbQuery.Append(" ,M.REG_EMP					 ");
                    sbQuery.Append(" ,REG.EMP_NAME AS REG_EMP_NAME	");
                    sbQuery.Append(" ,M.MDFY_DATE					 ");
                    sbQuery.Append(" ,M.MDFY_EMP					 ");
                    sbQuery.Append(" ,M.DEL_DATE					 ");
                    sbQuery.Append(" ,M.DEL_EMP					 ");
                    sbQuery.Append(" ,M.DATA_FLAG					 ");
                    sbQuery.Append(" FROM TSYS_MEETING M			 ");
                    sbQuery.Append(" LEFT JOIN TSYS_MEETING_EMP ME ");
                    sbQuery.Append(" ON M.PLT_CODE = ME.PLT_CODE ");
                    sbQuery.Append(" AND M.MEETING_ID = ME.MEETING_ID");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG ");
                    sbQuery.Append(" ON M.PLT_CODE = REG.PLT_CODE ");
                    sbQuery.Append(" AND M.REG_EMP = REG.EMP_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE M.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "(ME.EMP_CODE = @EMP_CODE OR M.ACC_LEVEL = 'P')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "M.REG_EMP <> @EMP_CODE"));
                        //sbWhere.Append(" AND B.LINK_ID IS NULL AND B.DATA_FLAG = '0' AND ISNULL(BE.IS_READ,0) <> '1' ");
                        sbWhere.Append(" AND M.DATA_FLAG = '0' AND ISNULL(ME.IS_READ,0) <> '1' ");

                        StringBuilder sbGroup = new StringBuilder();

                        sbGroup.Append(" GROUP BY M.PLT_CODE");
                        sbGroup.Append(" ,M.BOARD_ID		");
                        sbGroup.Append(" ,M.LINK_ID			");
                        sbGroup.Append(" ,M.TITLE			");
                        sbGroup.Append(" ,M.ACC_LEVEL		");
                        sbGroup.Append(" ,M.CONTENTS		");
                        sbGroup.Append(" ,M.RECEIVER		");
                        sbGroup.Append(" ,M.REG_DATE		");
                        sbGroup.Append(" ,M.REG_EMP			");
                        sbGroup.Append(" ,M.MDFY_DATE		");
                        sbGroup.Append(" ,M.MDFY_EMP		");
                        sbGroup.Append(" ,M.DEL_DATE		");
                        sbGroup.Append(" ,M.DEL_EMP			");
                        sbGroup.Append(" ,M.DATA_FLAG		");
                        sbGroup.Append(" ,REG.EMP_NAME		");
                        sbGroup.Append(" ORDER BY M.REG_DATE");

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

        public static DataTable TSYS_MEETING_QUERY4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT M.PLT_CODE			 ");
                    sbQuery.Append("    , M.BOARD_ID  ");
                    sbQuery.Append(" 	, M.LINK_ID   ");
                    sbQuery.Append(" 	, MC.TITLE     ");
                    sbQuery.Append(" 	, MC.CONTENTS  ");
                    sbQuery.Append(" 	, MC.ACC_LEVEL ");
                    sbQuery.Append(" 	, M.TITLE AS REPLY_TITLE  ");
                    sbQuery.Append(" 	, M.CONTENTS AS REPLY_CONTENTS  ");
                    sbQuery.Append(" 	, ISNULL(M.RECEIVER, '전체') AS RECEIVER  ");
                    sbQuery.Append(" 	, M.REG_DATE  ");
                    sbQuery.Append(" 	, M.REG_EMP   ");
                    sbQuery.Append(" 	, MC.REG_EMP   ");

                    sbQuery.Append(" FROM TSYS_MEETING M ");
                    sbQuery.Append("   JOIN TSYS_MEETING MC ");
                    sbQuery.Append("    ON M.PLT_CODE = MC.PLT_CODE ");
                    sbQuery.Append("   AND M.LINK_ID = MC.BOARD_ID ");
                    sbQuery.Append("   LEFT JOIN TSYS_BOARD_EMP ME  ");
                    sbQuery.Append("   ON M.PLT_CODE = ME.PLT_CODE ");
                    sbQuery.Append("   AND M.BOARD_ID = ME.BOARD_ID ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE M.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        //sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "(BE.EMP_CODE = @EMP_CODE OR M.ACC_LEVEL = 'P')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "MC.REG_EMP = @EMP_CODE"));
                        sbWhere.Append(" AND M.DATA_FLAG = 0 AND ISNULL(ME.IS_READ,0) <> 1 AND M.LINK_ID IS NOT NULL ");

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
