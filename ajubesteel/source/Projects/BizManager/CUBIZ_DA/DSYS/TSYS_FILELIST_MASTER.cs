using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;
using System.Windows.Forms;

namespace DSYS
{
    public class TSYS_FILELIST_MASTER
    {
        public static DataTable TSYS_FILELIST_MASTER_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT   PLT_CODE ");
                    sbQuery.Append("       , FILE_ID ");
                    sbQuery.Append("       , FILE_SEQ ");
                    sbQuery.Append("       , FILE_NAME ");
                    sbQuery.Append("       , FILE_NAME AS O_FILE_NAME");
                    sbQuery.Append("       , FILE_SIZE ");
                    sbQuery.Append("       , LINK_KEY ");
                    sbQuery.Append("       , IS_UPLOAD ");
                    sbQuery.Append("       , UPLOAD_MENU ");
                    sbQuery.Append("       , UPLOAD_CLASS ");
                    sbQuery.Append("       , ACC_LEVEL ");
                    sbQuery.Append("       , REG_DATE ");
                    sbQuery.Append("       , REG_EMP ");
                    sbQuery.Append("       , MDFY_DATE ");
                    sbQuery.Append("       , MDFY_EMP ");
                    sbQuery.Append("       , DEL_DATE ");
                    sbQuery.Append("       , DEL_EMP ");
                    sbQuery.Append("       , DATA_FLAG ");
                    sbQuery.Append("  FROM TSYS_FILELIST_MASTER ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND FILE_ID = @FILE_ID ");
                    sbQuery.Append(" ORDER BY FILE_SEQ");
                    sbQuery.Append("  ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "FILE_ID")) isHasColumn = false;

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

        public static DataTable TSYS_FILELIST_MASTER_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT TOP 1  PLT_CODE ");
                    sbQuery.Append("       , FILE_ID ");
                    sbQuery.Append("       , FILE_SEQ ");
                    sbQuery.Append("       , FILE_NAME ");
                    sbQuery.Append("       , FILE_NAME AS O_FILE_NAME");
                    sbQuery.Append("       , FILE_SIZE ");
                    sbQuery.Append("       , LINK_KEY ");
                    sbQuery.Append("       , IS_UPLOAD ");
                    sbQuery.Append("       , UPLOAD_MENU ");
                    sbQuery.Append("       , UPLOAD_CLASS ");
                    sbQuery.Append("       , ACC_LEVEL ");
                    sbQuery.Append("       , REG_DATE ");
                    sbQuery.Append("       , REG_EMP ");
                    sbQuery.Append("       , MDFY_DATE ");
                    sbQuery.Append("       , MDFY_EMP ");
                    sbQuery.Append("       , DEL_DATE ");
                    sbQuery.Append("       , DEL_EMP ");
                    sbQuery.Append("       , DATA_FLAG ");
                    sbQuery.Append("  FROM TSYS_FILELIST_MASTER ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND LINK_KEY = @LINK_KEY ");
                    sbQuery.Append("   AND UPLOAD_MENU = @UPLOAD_MENU ");
                    sbQuery.Append("   AND SUBSTRING(FILE_NAME, LEN(FILE_NAME) - CHARINDEX('.', REVERSE(FILE_NAME), 0) + 2, LEN(FILE_NAME) - (LEN(FILE_NAME) - CHARINDEX('.', REVERSE(FILE_NAME), 0) + 1)) = @FILE_TYPE ");
                    sbQuery.Append("   AND DATA_FLAG = '0' ");

                    sbQuery.Append(" ORDER BY REG_DATE DESC");
                    sbQuery.Append("  ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "LINK_KEY")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "UPLOAD_MENU")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "FILE_TYPE")) isHasColumn = false;

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

        public static DataTable TSYS_FILELIST_MASTER_SER3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT   PLT_CODE ");
                    sbQuery.Append("       , FILE_ID ");
                    sbQuery.Append("       , FILE_SEQ ");
                    sbQuery.Append("       , FILE_NAME ");
                    sbQuery.Append("       , FILE_NAME AS O_FILE_NAME");
                    sbQuery.Append("       , FILE_SIZE ");
                    sbQuery.Append("       , LINK_KEY ");
                    sbQuery.Append("       , IS_UPLOAD ");
                    sbQuery.Append("       , UPLOAD_MENU ");
                    sbQuery.Append("       , UPLOAD_CLASS ");
                    sbQuery.Append("       , ACC_LEVEL ");
                    sbQuery.Append("       , REG_DATE ");
                    sbQuery.Append("       , REG_EMP ");
                    sbQuery.Append("       , MDFY_DATE ");
                    sbQuery.Append("       , MDFY_EMP ");
                    sbQuery.Append("       , DEL_DATE ");
                    sbQuery.Append("       , DEL_EMP ");
                    sbQuery.Append("       , DATA_FLAG ");
                    sbQuery.Append("  FROM TSYS_FILELIST_MASTER ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND LINK_KEY = @LINK_KEY ");
                    sbQuery.Append("   AND UPLOAD_MENU = @UPLOAD_MENU ");
                    sbQuery.Append("   AND DATA_FLAG = '0' ");
                    sbQuery.Append("   AND IS_UPLOAD = '1' ");
                    sbQuery.Append("  ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "LINK_KEY")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "UPLOAD_MENU")) isHasColumn = false;

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

        public static void TSYS_FILELIST_MASTER_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TSYS_FILELIST_MASTER ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append("        PLT_CODE ");
                    sbQuery.Append("      , FILE_ID ");
                    sbQuery.Append("      , FILE_SEQ ");
                    sbQuery.Append("      , FILE_NAME ");
                    sbQuery.Append("      , FILE_SIZE ");
                    sbQuery.Append("      , LINK_KEY ");
                    sbQuery.Append("      , IS_UPLOAD ");
                    sbQuery.Append("      , UPLOAD_MENU ");
                    sbQuery.Append("      , UPLOAD_CLASS ");
                    sbQuery.Append("      , ACC_LEVEL ");
                    sbQuery.Append("      , REG_DATE ");
                    sbQuery.Append("      , REG_EMP ");
                    sbQuery.Append("      , DATA_FLAG ");
                    sbQuery.Append(" ) ");
                    sbQuery.Append(" VALUES ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append("        @PLT_CODE ");
                    sbQuery.Append("      , @FILE_ID ");
                    sbQuery.Append("      , @FILE_SEQ ");
                    sbQuery.Append("      , @FILE_NAME ");
                    sbQuery.Append("      , @FILE_SIZE ");
                    sbQuery.Append("      , @LINK_KEY ");
                    sbQuery.Append("      , @IS_UPLOAD ");
                    sbQuery.Append("      , @UPLOAD_MENU ");
                    sbQuery.Append("      , @UPLOAD_CLASS ");
                    sbQuery.Append("      , @ACC_LEVEL ");
                    sbQuery.Append("      , @REG_DATE ");
                    sbQuery.Append("      , @REG_EMP ");
                    sbQuery.Append("      , @DATA_FLAG ");
                    sbQuery.Append(" ) ");

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

        public static void TSYS_FILELIST_MASTER_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute )
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSYS_FILELIST_MASTER ");
                    sbQuery.Append("   SET   FILE_NAME = @FILE_NAME ");
                    sbQuery.Append("       , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("       , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND FILE_ID = @FILE_ID ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크                        
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "FILE_ID")) isHasColumn = false;

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

        public static void TSYS_FILELIST_MASTER_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSYS_FILELIST_MASTER ");
                    sbQuery.Append("    SET   IS_UPLOAD = @IS_UPLOAD ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND FILE_ID = @FILE_ID ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크                        
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "FILE_ID")) isHasColumn = false;

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

        public static void TSYS_FILELIST_MASTER_UPD3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSYS_FILELIST_MASTER ");
                    sbQuery.Append("   SET   ACC_LEVEL = @ACC_LEVEL ");
                    sbQuery.Append("       , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("       , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND FILE_ID = @FILE_ID ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크                        
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "FILE_ID")) isHasColumn = false;

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

        public static void TSYS_FILELIST_MASTER_UPD4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSYS_FILELIST_MASTER ");
                    sbQuery.Append("   SET   GUBUN = @GUBUN ");
                    sbQuery.Append("       , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("       , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND FILE_ID = @FILE_ID ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크                        
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "FILE_ID")) isHasColumn = false;

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

        public static void TSYS_FILELIST_MASTER_UPD5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSYS_FILELIST_MASTER ");
                    sbQuery.Append("   SET   FILE_SEQ = @FILE_SEQ ");
                    sbQuery.Append("       , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("       , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND FILE_ID = @FILE_ID ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크                        
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "FILE_ID")) isHasColumn = false;

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

        public static void TSYS_FILELIST_MASTER_UPD6(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSYS_FILELIST_MASTER ");
                    sbQuery.Append("   SET   LINK_KEY = @LINK_KEY ");
                    sbQuery.Append("       , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("       , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND FILE_ID = @FILE_ID ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크                        
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "FILE_ID")) isHasColumn = false;

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

        public static void TSYS_FILELIST_MASTER_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSYS_FILELIST_MASTER ");
                    sbQuery.Append("   SET   DEL_DATE = GETDATE() ");
                    sbQuery.Append("       , DEL_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("       , DATA_FLAG = 2 ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND FILE_ID = @FILE_ID ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크                        
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "FILE_ID")) isHasColumn = false;

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

        /// <summary>
        /// 첨부파일 삭제
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TSYS_FILELIST_MASTER_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" DELETE FROM TSYS_FILELIST_MASTER ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND FILE_ID = @FILE_ID ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크                        
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "FILE_ID")) isHasColumn = false;

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

        //public static void 
    }

    public class TSYS_FILELIST_MASTER_QUERY
    {
        public static DataTable TSYS_FILELIST_MASTER_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append("     ,FILE_ID ");
                    sbQuery.Append("     ,FILE_SEQ "); 
                    sbQuery.Append("     ,FILE_NAME ");
                    sbQuery.Append("     ,FILE_SIZE ");
                    sbQuery.Append("     ,LINK_KEY ");
                    sbQuery.Append("     ,IS_UPLOAD ");
                    sbQuery.Append("     ,UPLOAD_MENU ");
                    sbQuery.Append("     ,UPLOAD_CLASS ");
                    sbQuery.Append("     ,ACC_LEVEL ");
                    sbQuery.Append("     ,REG_DATE ");
                    sbQuery.Append("     ,REG_EMP ");
                    sbQuery.Append("     ,MDFY_EMP ");
                    sbQuery.Append("     ,MDFY_DATE ");
                    sbQuery.Append("     ,DEL_DATE ");
                    sbQuery.Append("     ,DEL_EMP ");
                    sbQuery.Append("     ,DATA_FLAG ");
                    sbQuery.Append(" FROM TSYS_FILELIST_MASTER ");

                    DataRow row = dtParam.Rows[0];

                    bool isHasColumn = true;
                    
                    //검색 조건 유무 체크                        
                    
                    if (isHasColumn == true)
                    {
                        
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE 1 = 1");

                        sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", "PLT_CODE = @PLT_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@LINK_KEY", " LINK_KEY = @LINK_KEY "));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_UPLOAD", " IS_UPLOAD = @IS_UPLOAD "));
                        sbWhere.Append(UTIL.GetWhere(row, "@ACC_LEVEL", " ACC_LEVEL = @ACC_LEVEL "));
                        sbWhere.Append(UTIL.GetWhere(row, "@UPLOAD_CLASS", " UPLOAD_CLASS = @UPLOAD_CLASS "));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", " DATA_FLAG = @DATA_FLAG "));

                        sbWhere.Append(" ORDER BY FILE_SEQ");
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
        /// <summary>
        /// 첨부파일목록 조회
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TSYS_FILELIST_MASTER_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT F.PLT_CODE ");
                    sbQuery.Append("       ,F.FILE_ID ");
                    sbQuery.Append("       ,F.FILE_SEQ ");
                    sbQuery.Append("       ,F.GUBUN ");
                    sbQuery.Append("       ,F.FILE_NAME ");
                    sbQuery.Append("       ,F.FILE_NAME AS O_FILE_NAME");
                    sbQuery.Append("       ,F.FILE_SIZE ");
                    sbQuery.Append("       ,F.LINK_KEY ");
                    sbQuery.Append("       ,F.IS_UPLOAD ");
                    sbQuery.Append("       ,F.UPLOAD_MENU ");
                    sbQuery.Append("       ,MR.RES_CONTENTS AS UPLOAD_MENU_NAME ");
                    sbQuery.Append("       ,M.MENU_SEQ AS UPLOAD_MENU_SEQ ");
                    sbQuery.Append("       ,F.UPLOAD_CLASS ");
                    sbQuery.Append("       ,F.REG_DATE ");
                    sbQuery.Append("       ,F.REG_EMP ");
                    sbQuery.Append(" 	  ,REG.EMP_NAME AS REG_EMP_NAME ");
                    sbQuery.Append("       ,F.MDFY_EMP ");
                    sbQuery.Append(" 	  ,MDFY.EMP_NAME AS MDFY_EMP_NAME ");
                    sbQuery.Append("       ,F.MDFY_DATE ");
                    sbQuery.Append("       ,F.ACC_LEVEL ");
                    sbQuery.Append("   FROM TSYS_FILELIST_MASTER F ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG ");
                    sbQuery.Append(" ON F.PLT_CODE = REG.PLT_CODE ");
                    sbQuery.Append(" AND F.REG_EMP = REG.EMP_CODE ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY ");
                    sbQuery.Append(" ON F.PLT_CODE = MDFY.PLT_CODE ");
                    sbQuery.Append(" AND F.REG_EMP = MDFY.EMP_CODE ");
                    sbQuery.Append(" LEFT JOIN TSYS_MENULIST M ");
                    sbQuery.Append(" ON F.PLT_CODE = M.PLT_CODE ");
                    sbQuery.Append(" AND F.UPLOAD_MENU = M.MENU_CODE ");
                    sbQuery.Append(" LEFT JOIN TSYS_STRINGTABLE MR ");
                    sbQuery.Append(" ON M.PLT_CODE = MR.PLT_CODE ");
                    sbQuery.Append(" AND M.RES_ID = MR.RES_ID ");
                    sbQuery.Append(" AND MR.RES_LANG = @LANG ");

                    DataRow row = dtParam.Rows[0];

                    bool isHasColumn = true;
                    //검색 조건 유무 체크                        
                    if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                    if (!UTIL.ValidColumn(row, "LANG")) isHasColumn = false;


                    if (isHasColumn == true)
                    {
                        sbQuery.Replace("@PLT_CODE", UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbQuery.Replace("@LANG", UTIL.GetValidValue(row, "LANG").ToString());
                        sbQuery.Replace("@LINK_KEY", UTIL.GetValidValue(row, "LINK_KEY").ToString());

                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE F.IS_UPLOAD = 1 AND F.DATA_FLAG = 0");

                        sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", "F.PLT_CODE = @PLT_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@LINK_KEY", " F.LINK_KEY = @LINK_KEY "));


                        sbWhere.Append(" ORDER BY FILE_SEQ");
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

        /// <summary>
        /// 첨부파일목록 삭제된이력 조회 
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TSYS_FILELIST_MASTER_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT F.PLT_CODE ");
                    sbQuery.Append("       ,F.FILE_ID ");
                    sbQuery.Append("       ,F.FILE_SEQ ");
                    sbQuery.Append("       ,F.GUBUN ");
                    sbQuery.Append("       ,F.FILE_NAME ");
                    sbQuery.Append("       ,F.FILE_SIZE ");
                    sbQuery.Append("       ,F.LINK_KEY ");
                    sbQuery.Append("       ,F.IS_UPLOAD ");
                    sbQuery.Append("       ,F.UPLOAD_MENU ");
                    sbQuery.Append("       ,MR.RES_CONTENTS AS UPLOAD_MENU_NAME ");
                    sbQuery.Append("       ,M.MENU_SEQ AS UPLOAD_MENU_SEQ ");
                    sbQuery.Append("       ,F.UPLOAD_CLASS ");
                    sbQuery.Append("       ,F.DEL_DATE ");
                    sbQuery.Append("       ,F.DEL_EMP ");
                    sbQuery.Append(" 	,DEL.EMP_NAME AS DEL_EMP_NAME ");
                    sbQuery.Append("   FROM TSYS_FILELIST_MASTER F ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE DEL ");
                    sbQuery.Append(" ON F.PLT_CODE = DEL.PLT_CODE ");
                    sbQuery.Append(" AND F.DEL_EMP = DEL.EMP_CODE ");
                    sbQuery.Append(" LEFT JOIN TSYS_MENULIST M ");
                    sbQuery.Append(" ON F.PLT_CODE = M.PLT_CODE ");
                    sbQuery.Append(" AND F.UPLOAD_MENU = M.MENU_CODE ");
                    sbQuery.Append(" LEFT JOIN TSYS_STRINGTABLE MR ");
                    sbQuery.Append(" ON M.PLT_CODE = MR.PLT_CODE ");
                    sbQuery.Append(" AND M.RES_ID = MR.RES_ID ");
                    sbQuery.Append(" AND MR.RES_LANG = @LANG ");

                    

                    DataRow row = dtParam.Rows[0];

                    bool isHasColumn = true;
                    //검색 조건 유무 체크                        
                    if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                    if (!UTIL.ValidColumn(row, "LANG")) isHasColumn = false;


                    if (isHasColumn == true)
                    {
                        sbQuery.Replace("@PLT_CODE", UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbQuery.Replace("@LANG", UTIL.GetValidValue(row, "LANG").ToString());
                        sbQuery.Replace("@LINK_KEY", UTIL.GetValidValue(row, "LINK_KEY").ToString());

                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE F.IS_UPLOAD = 1 AND F.DATA_FLAG = 2");

                        sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", "F.PLT_CODE = @PLT_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@LINK_KEY", " F.LINK_KEY = @LINK_KEY "));

                        sbWhere.Append(" ORDER BY FILE_SEQ");
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

        /// <summary>
        /// 작업현황(개선) 첨부파일 목록
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TSYS_FILELIST_MASTER_QUERY4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT FM.PLT_CODE");
                    sbQuery.Append(" 	  , FM.LINK_KEY");
                    sbQuery.Append("   FROM (SELECT PLT_CODE, LINK_KEY, DATA_FLAG ");
                    sbQuery.Append(" 		  FROM TSYS_FILELIST_MASTER ");
                    sbQuery.Append(" 		 WHERE IS_UPLOAD = 1 AND UPLOAD_MENU = 'PLN11C' AND DATA_FLAG = 0 ");
                    sbQuery.Append(" 		GROUP BY PLT_CODE, LINK_KEY,DATA_FLAG) FM");
                    sbQuery.Append(" 	INNER JOIN TORD_PRODUCT TP");
                    sbQuery.Append(" 		ON FM.PLT_CODE = TP.PLT_CODE");
                    sbQuery.Append(" 		AND FM.LINK_KEY LIKE (TP.PROD_CODE + TP.PART_CODE + '%')");
                    sbQuery.Append(" 		AND FM.DATA_FLAG = TP.DATA_FLAG");
                    sbQuery.Append("  WHERE FM.PLT_CODE = @PLT_CODE");
                    sbQuery.Append("  AND TP.PROD_CODE = @PROD_CODE");
                    sbQuery.Append("  AND TP.PART_CODE = @PART_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;

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
