using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BizExecute;

namespace DLSE
{
    public class LSE_STD_PROC
    {
        public static DataTable LSE_STD_PROC_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" , PROC_CODE ");
                    sbQuery.Append(" , PROC_NAME ");
                    sbQuery.Append(" , MPROC_CODE");
                    sbQuery.Append(" , LPROC_CODE");
                    sbQuery.Append(" , PROC_TYPE ");
                    sbQuery.Append(" , PROC_SEQ");
                    sbQuery.Append(" , PROC_COLOR");
                    sbQuery.Append(" , PROC_SELF_TIME");
                    sbQuery.Append(" , PROC_MAN_TIME ");
                    sbQuery.Append(" , CPROC_CODE");
                    sbQuery.Append(" , WO_DEFAULT_OSMC ");
                    sbQuery.Append(" , IS_OS ");
                    sbQuery.Append(" , BAL_DISP ");
                    sbQuery.Append(" , INS_FLAG");
                    sbQuery.Append(" , WO_TYPE");
                    sbQuery.Append(" , IS_BOP_PROC ");
                    sbQuery.Append(" , IS_CHECK_PREV_PROC");
                    sbQuery.Append(" , IS_PART_SAME_START");
                    sbQuery.Append(" , IS_CHECK_TOOL ");
                    sbQuery.Append(" , IS_ATTACH_USE ");
                    sbQuery.Append(" , IS_ASSY ");
                    sbQuery.Append(" , MPROC_PROGRESS_RATE ");
                    sbQuery.Append(" , MAIN_VND");
                    sbQuery.Append(" , ACT_CODE");
                    sbQuery.Append(" , REG_DATE");
                    sbQuery.Append(" , REG_EMP ");
                    sbQuery.Append(" , MDFY_DATE ");
                    sbQuery.Append(" , MDFY_EMP");
                    sbQuery.Append(" , DEL_EMP ");
                    sbQuery.Append(" , DEL_REASON");
                    sbQuery.Append(" , DEL_DATE");
                    sbQuery.Append(" , DATA_FLAG ");
                    sbQuery.Append(" FROM LSE_STD_PROC ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PROC_CODE = @PROC_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {                            

                            DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString(),row).Copy();

                            sourceTable.TableName = "RSLTDT";
                            dsResult.Merge(sourceTable);  
                        }
                    }
                }
                return UTIL.GetDsToDt(dsResult);
            }
            catch(Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataTable LSE_STD_PROC_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" , PROC_CODE ");
                    sbQuery.Append(" , PROC_NAME ");
                    sbQuery.Append(" , MPROC_CODE");
                    sbQuery.Append(" , LPROC_CODE");
                    sbQuery.Append(" , PROC_TYPE ");
                    sbQuery.Append(" , PROC_SEQ");
                    sbQuery.Append(" , PROC_COLOR");
                    sbQuery.Append(" , PROC_SELF_TIME");
                    sbQuery.Append(" , PROC_MAN_TIME ");
                    sbQuery.Append(" , CPROC_CODE");
                    sbQuery.Append(" , WO_DEFAULT_OSMC ");
                    sbQuery.Append(" , IS_OS ");
                    sbQuery.Append(" , BAL_DISP ");
                    sbQuery.Append(" , INS_FLAG");
                    sbQuery.Append(" , WO_TYPE");
                    sbQuery.Append(" , IS_BOP_PROC ");
                    sbQuery.Append(" , IS_CHECK_PREV_PROC");
                    sbQuery.Append(" , IS_PART_SAME_START");
                    sbQuery.Append(" , IS_CHECK_TOOL ");
                    sbQuery.Append(" , IS_ATTACH_USE ");
                    sbQuery.Append(" , IS_ASSY ");
                    sbQuery.Append(" , MPROC_PROGRESS_RATE ");
                    sbQuery.Append(" , MAIN_VND");
                    sbQuery.Append(" , ACT_CODE");
                    sbQuery.Append(" , REG_DATE");
                    sbQuery.Append(" , REG_EMP ");
                    sbQuery.Append(" , MDFY_DATE ");
                    sbQuery.Append(" , MDFY_EMP");
                    sbQuery.Append(" , DEL_EMP ");
                    sbQuery.Append(" , DEL_REASON");
                    sbQuery.Append(" , DEL_DATE");
                    sbQuery.Append(" , DATA_FLAG ");
                    sbQuery.Append(" FROM LSE_STD_PROC ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND WO_TYPE = @WO_TYPE");
                    sbQuery.Append(" AND DATA_FLAG = @DATA_FLAG");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "WO_TYPE")) isHasColumn = false;
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

        public static void LSE_STD_PROC_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE LSE_STD_PROC ");
                    sbQuery.Append(" SET PROC_NAME = @PROC_NAME");
                    sbQuery.Append(" , PROC_SEQ = @PROC_SEQ");
                    sbQuery.Append(" , PROC_COLOR = @PROC_COLOR");
                    sbQuery.Append(" , PROC_SELF_TIME = @PROC_SELF_TIME");
                    sbQuery.Append(" , PROC_MAN_TIME = @PROC_MAN_TIME");
                    sbQuery.Append(" , PROC_UC = @PROC_UC");
                    sbQuery.Append(" , PROC_COST = @PROC_COST");
                    sbQuery.Append(" , CPROC_CODE = @CPROC_CODE");
                    sbQuery.Append(" , WO_DEFAULT_OSMC = @WO_DEFAULT_OSMC");
                    sbQuery.Append(" , IS_OS = @IS_OS");
                    sbQuery.Append(" , BAL_DISP = @BAL_DISP");
                    sbQuery.Append(" , IS_MAT = @IS_MAT");
                    sbQuery.Append(" , IS_ASSY  = @IS_ASSY");
                    sbQuery.Append(" , INS_FLAG = @INS_FLAG");
                    sbQuery.Append(" , WO_TYPE = @WO_TYPE");
                    sbQuery.Append(" , IS_BOP_PROC = @IS_BOP_PROC");
                    sbQuery.Append(" , IS_CHECK_PREV_PROC = @IS_CHECK_PREV_PROC");
                    sbQuery.Append(" , IS_PART_SAME_START = @IS_PART_SAME_START");
                    sbQuery.Append(" , IS_CHECK_TOOL = @IS_CHECK_TOOL");
                    sbQuery.Append(" , IS_ATTACH_USE = @IS_ATTACH_USE"); 
                    sbQuery.Append(" , MAIN_VND = @MAIN_VND");
                    sbQuery.Append(" , ACT_CODE = @ACT_CODE");
                    //sbQuery.Append(" , IF_PROC_CODE = @IF_PROC_CODE");
                    sbQuery.Append(" , SCOMMENT = @SCOMMENT");
                    sbQuery.Append(" , TRANSFER_TIME = @TRANSFER_TIME");
                    sbQuery.Append(" , MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , DATA_FLAG = 0 ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND PROC_CODE = @PROC_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        
                        if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            bizExecute.executeUpdateQuery(sbQuery.ToString(),row);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        /// <summary>
        /// 공정의 대일정, 중일정 변경
        /// </summary>
        /// <param name="dtParam"></param>
        public static void LSE_STD_PROC_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE LSE_STD_PROC SET ");
                    sbQuery.Append(" MPROC_CODE = @MPROC_CODE");
                    sbQuery.Append(" , LPROC_CODE = @LPROC_CODE");
                    sbQuery.Append(" , MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND PROC_CODE = @PROC_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;

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
        /// 공정의 대일정 변경
        /// </summary>
        /// <param name="dtParam"></param>
        public static void LSE_STD_PROC_UPD3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE LSE_STD_PROC SET ");                                        
                    sbQuery.Append(" LPROC_CODE = @LPROC_CODE");                    
                    sbQuery.Append(" , MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));                    
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND MPROC_CODE = @MPROC_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;


                        if (!UTIL.ValidColumn(row, "MPROC_CODE")) isHasColumn = false;

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

        //20160406 김준구 - 표준공정(대중소); 소일정 수정
        public static void LSE_STD_PROC_UPD4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE LSE_STD_PROC ");
                    sbQuery.Append(" SET PROC_NAME = @PROC_NAME");
                    sbQuery.Append(" , MPROC_CODE = @MPROC_CODE");
                    sbQuery.Append(" , LPROC_CODE = @LPROC_CODE");
                    sbQuery.Append(" , PROC_SEQ = @PROC_SEQ");
                    sbQuery.Append(" , PROC_COLOR = @PROC_COLOR");
                    sbQuery.Append(" , PROC_SELF_TIME = @PROC_SELF_TIME");
                    sbQuery.Append(" , PROC_MAN_TIME = @PROC_MAN_TIME");
                    sbQuery.Append(" , CPROC_CODE = @CPROC_CODE");
                    sbQuery.Append(" , WO_DEFAULT_OSMC = @WO_DEFAULT_OSMC");
                    sbQuery.Append(" , IS_OS = @IS_OS");
                    sbQuery.Append(" , IS_ASSY  = @IS_ASSY");
                    sbQuery.Append(" , BAL_DISP = @BAL_DISP");
                    sbQuery.Append(" , INS_FLAG = @INS_FLAG");
                    sbQuery.Append(" , WO_TYPE = @WO_TYPE");
                    sbQuery.Append(" , IS_BOP_PROC = @IS_BOP_PROC");
                    sbQuery.Append(" , IS_CHECK_PREV_PROC = @IS_CHECK_PREV_PROC");
                    sbQuery.Append(" , IS_PART_SAME_START = @IS_PART_SAME_START");
                    sbQuery.Append(" , IS_CHECK_TOOL = @IS_CHECK_TOOL");
                    sbQuery.Append(" , IS_ATTACH_USE = @IS_ATTACH_USE ");
                    sbQuery.Append(" , MPROC_PROGRESS_RATE = @MPROC_PROGRESS_RATE");
                    sbQuery.Append(" , MAIN_VND = @MAIN_VND");
                    sbQuery.Append(" , ACT_CODE = @ACT_CODE");
                    //sbQuery.Append(" , IF_PROC_CODE = @IF_PROC_CODE");
                    sbQuery.Append(" , MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , DATA_FLAG = 0 ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND PROC_CODE = @PROC_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;


                        if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;

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


        public static void LSE_STD_PROC_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE LSE_STD_PROC ");
                    sbQuery.Append(" SET DEL_DATE = GETDATE()");
                    sbQuery.Append(" , DEL_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , DEL_REASON = @DEL_REASON");
                    sbQuery.Append(" , DATA_FLAG = 2");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PROC_CODE = @PROC_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PROC_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            bizExecute.executeUpdateQuery(sbQuery.ToString(),row);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }


        public static void LSE_STD_PROC_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO LSE_STD_PROC");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" , PROC_CODE ");
                    sbQuery.Append(" , PROC_NAME ");
                    sbQuery.Append(" , PROC_TYPE ");
                    sbQuery.Append(" , PROC_SEQ");
                    sbQuery.Append(" , PROC_COLOR");
                    sbQuery.Append(" , PROC_SELF_TIME");
                    sbQuery.Append(" , PROC_MAN_TIME ");
                    sbQuery.Append(" , PROC_UC ");
                    sbQuery.Append(" , PROC_COST ");
                    sbQuery.Append(" , CPROC_CODE");
                    sbQuery.Append(" , WO_DEFAULT_OSMC ");
                    sbQuery.Append(" , IS_OS ");
                    sbQuery.Append(" , BAL_DISP ");
                    sbQuery.Append(" , IS_MAT ");
                    sbQuery.Append(" , INS_FLAG");
                    sbQuery.Append(" , WO_TYPE");
                    sbQuery.Append(" , IS_BOP_PROC ");
                    sbQuery.Append(" , IS_CHECK_PREV_PROC");
                    sbQuery.Append(" , IS_PART_SAME_START");
                    sbQuery.Append(" , IS_CHECK_TOOL ");
                    sbQuery.Append(" , IS_ATTACH_USE ");
                    sbQuery.Append(" , IS_ASSY ");
                    sbQuery.Append(" , MAIN_VND");
                    sbQuery.Append(" , ACT_CODE");
                    sbQuery.Append(" , IF_PROC_CODE");
                    sbQuery.Append(" , SCOMMENT");
                    sbQuery.Append(" , TRANSFER_TIME");
                    sbQuery.Append(" , REG_DATE");
                    sbQuery.Append(" , REG_EMP ");
                    sbQuery.Append(" , DATA_FLAG ");
                    sbQuery.Append(" ) ");
                    sbQuery.Append(" VALUES");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" @PLT_CODE ");
                    sbQuery.Append(" , @PROC_CODE");
                    sbQuery.Append(" , @PROC_NAME");
                    sbQuery.Append(" , @PROC_TYPE");
                    sbQuery.Append(" , @PROC_SEQ ");
                    sbQuery.Append(" , @PROC_COLOR ");
                    sbQuery.Append(" , @PROC_SELF_TIME ");
                    sbQuery.Append(" , @PROC_MAN_TIME");
                    sbQuery.Append(" , @PROC_UC ");
                    sbQuery.Append(" , @PROC_COST ");
                    sbQuery.Append(" , @CPROC_CODE ");
                    sbQuery.Append(" , @WO_DEFAULT_OSMC");
                    sbQuery.Append(" , @IS_OS");
                    sbQuery.Append(" , @BAL_DISP");
                    sbQuery.Append(" , @IS_MAT");
                    sbQuery.Append(" , @INS_FLAG ");
                    sbQuery.Append(" , @WO_TYPE");
                    sbQuery.Append(" , @IS_BOP_PROC");
                    sbQuery.Append(" , @IS_CHECK_PREV_PROC ");
                    sbQuery.Append(" , @IS_PART_SAME_START ");
                    sbQuery.Append(" , @IS_CHECK_TOOL");
                    sbQuery.Append(" , @IS_ATTACH_USE ");
                    sbQuery.Append(" , @IS_ASSY ");
                    sbQuery.Append(" , @MAIN_VND ");
                    sbQuery.Append(" , @ACT_CODE ");
                    sbQuery.Append(" , @IF_PROC_CODE ");
                    sbQuery.Append(" , @SCOMMENT");
                    sbQuery.Append(" , @TRANSFER_TIME");
                    sbQuery.Append(" , GETDATE() ");
                    sbQuery.Append(" , " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , 0");
                    sbQuery.Append(")");

                    foreach (DataRow row in dtParam.Rows)
                    {                       
                        bizExecute.executeInsertQuery(sbQuery.ToString(), row);
                    }
                }
            }
            catch(Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        //20160406 김준구 - 표준공정(대중소); 소일정 추가
        public static void LSE_STD_PROC_INS2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO LSE_STD_PROC");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" , PROC_CODE ");
                    sbQuery.Append(" , PROC_NAME ");
                    sbQuery.Append(" , MPROC_CODE");
                    sbQuery.Append(" , LPROC_CODE");
                    sbQuery.Append(" , PROC_TYPE ");
                    sbQuery.Append(" , PROC_SEQ");
                    sbQuery.Append(" , PROC_COLOR");
                    sbQuery.Append(" , PROC_SELF_TIME");
                    sbQuery.Append(" , PROC_MAN_TIME ");
                    sbQuery.Append(" , CPROC_CODE");
                    sbQuery.Append(" , WO_DEFAULT_OSMC ");
                    sbQuery.Append(" , IS_OS ");
                    sbQuery.Append(" , BAL_DISP ");
                    sbQuery.Append(" , INS_FLAG");
                    sbQuery.Append(" , WO_TYPE");
                    sbQuery.Append(" , IS_BOP_PROC ");
                    sbQuery.Append(" , IS_CHECK_PREV_PROC");
                    sbQuery.Append(" , IS_PART_SAME_START");
                    sbQuery.Append(" , IS_CHECK_TOOL ");
                    sbQuery.Append(" , IS_ATTACH_USE ");
                    sbQuery.Append(" , IS_ASSY ");
                    sbQuery.Append(" , MPROC_PROGRESS_RATE ");
                    sbQuery.Append(" , MAIN_VND");
                    sbQuery.Append(" , ACT_CODE");
                    sbQuery.Append(" , IF_PROC_CODE");
                    sbQuery.Append(" , REG_DATE");
                    sbQuery.Append(" , REG_EMP ");
                    sbQuery.Append(" , DATA_FLAG ");
                    sbQuery.Append(" ) ");
                    sbQuery.Append(" VALUES");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" @PLT_CODE ");
                    sbQuery.Append(" , @PROC_CODE");
                    sbQuery.Append(" , @PROC_NAME");
                    sbQuery.Append(" , @MPROC_CODE ");
                    sbQuery.Append(" , @LPROC_CODE ");
                    sbQuery.Append(" , @PROC_TYPE");
                    sbQuery.Append(" , @PROC_SEQ ");
                    sbQuery.Append(" , @PROC_COLOR ");
                    sbQuery.Append(" , @PROC_SELF_TIME ");
                    sbQuery.Append(" , @PROC_MAN_TIME");
                    sbQuery.Append(" , @CPROC_CODE ");
                    sbQuery.Append(" , @WO_DEFAULT_OSMC");
                    sbQuery.Append(" , @IS_OS");
                    sbQuery.Append(" , @BAL_DISP");
                    sbQuery.Append(" , @INS_FLAG ");
                    sbQuery.Append(" , @WO_TYPE");
                    sbQuery.Append(" , @IS_BOP_PROC");
                    sbQuery.Append(" , @IS_CHECK_PREV_PROC ");
                    sbQuery.Append(" , @IS_PART_SAME_START ");
                    sbQuery.Append(" , @IS_CHECK_TOOL");
                    sbQuery.Append(" , @IS_ATTACH_USE ");
                    sbQuery.Append(" , @IS_ASSY ");
                    sbQuery.Append(" , @MPROC_PROGRESS_RATE");
                    sbQuery.Append(" , @MAIN_VND ");
                    sbQuery.Append(" , @ACT_CODE ");
                    sbQuery.Append(" , @IF_PROC_CODE ");
                    sbQuery.Append(" , GETDATE() ");
                    sbQuery.Append(" , " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , 0");
                    sbQuery.Append(")");

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

    public class LSE_STD_PROC_QUERY
    {
        public static DataTable LSE_STD_PROC_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append("       ,PROC_CODE ");
                    sbQuery.Append("       ,PROC_NAME ");
                    sbQuery.Append("       ,MPROC_CODE ");
                    sbQuery.Append("       ,LPROC_CODE ");
                    sbQuery.Append("       ,PROC_TYPE ");
                    sbQuery.Append("       ,PROC_SEQ ");
                    sbQuery.Append("       ,PROC_COLOR ");
                    sbQuery.Append("       ,PROC_SELF_TIME ");
                    sbQuery.Append("       ,PROC_MAN_TIME ");
                    sbQuery.Append("       ,CPROC_CODE ");
                    sbQuery.Append("       ,WO_DEFAULT_OSMC ");
                    sbQuery.Append("       ,IS_OS ");
                    sbQuery.Append("       ,INS_FLAG ");
                    sbQuery.Append("       ,WO_TYPE");
                    sbQuery.Append("       ,IS_BOP_PROC ");
                    sbQuery.Append("       ,IS_ASSY ");
                    sbQuery.Append("       ,MAIN_VND ");
                    sbQuery.Append("       ,ACT_CODE ");
                    sbQuery.Append("       ,REG_DATE ");
                    sbQuery.Append("       ,REG_EMP ");
                    sbQuery.Append("       ,MDFY_DATE ");
                    sbQuery.Append("       ,MDFY_EMP ");
                    sbQuery.Append("       ,DATA_FLAG ");
                    sbQuery.Append("       ,DEL_DATE ");
                    sbQuery.Append("       ,DEL_EMP ");
                    sbQuery.Append("       ,DEL_REASON ");
                    sbQuery.Append("   FROM LSE_STD_PROC ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PROC_CODE", "PROC_CODE = @PROC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_ASSY", "IS_ASSY = @IS_ASSY"));
                        sbWhere.Append(UTIL.GetWhere(row, "@LPROC_CODE", "LPROC_CODE = @LPROC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MPROC_CODE", "MPROC_CODE = @MPROC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_BOP_PROC", "IS_BOP_PROC = @IS_BOP_PROC"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_DISP", "ISNULL(IS_DISP, 0) = @IS_DISP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_DISP2", "ISNULL(IS_DISP2, 0) = @IS_DISP2"));

                        sbWhere.Append(" ORDER BY PROC_SEQ ");

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

        public static DataTable LSE_STD_PROC_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT	 ");
                    sbQuery.Append(" P.PLT_CODE");
                    sbQuery.Append(" ,P.PROC_CODE");
                    sbQuery.Append(" ,P.PROC_NAME");
                    sbQuery.Append(" ,P.PROC_SEQ ");
                    sbQuery.Append(" ,P.PROC_COLOR ");
                    sbQuery.Append(" ,P.PROC_MAN_TIME");
                    sbQuery.Append(" ,P.PROC_SELF_TIME ");
                    sbQuery.Append(" ,P.PROC_UC ");
                    sbQuery.Append(" ,P.PROC_COST ");
                    sbQuery.Append(" ,P.CPROC_CODE ");
                    sbQuery.Append(" ,UTC.UTC_NAME AS CPROC_NAME ");
                    sbQuery.Append(" ,P.REG_DATE ");
                    sbQuery.Append(" ,P.REG_EMP");
                    sbQuery.Append(" ,REG.EMP_NAME AS REG_EMP_NAME ");
                    sbQuery.Append(" ,P.MDFY_DATE");
                    sbQuery.Append(" ,P.MDFY_EMP ");
                    sbQuery.Append(" ,MDFY.EMP_NAME AS MDFY_EMP_NAME ");
                    sbQuery.Append(" ,P.DATA_FLAG");
                    sbQuery.Append(" ,P.WO_DEFAULT_OSMC");
                    sbQuery.Append(" ,WO_OSMC.MC_NAME AS WO_DEFAULT_OSMC_NAME");
                    sbQuery.Append(" ,P.IS_OS");
                    sbQuery.Append(" ,P.BAL_DISP");
                    sbQuery.Append(" ,P.IS_MAT");
                    sbQuery.Append(" ,P.IS_BOP_PROC");
                    sbQuery.Append(" ,P.IS_CHECK_PREV_PROC ");
                    sbQuery.Append(" ,P.IS_PART_SAME_START ");
                    sbQuery.Append(" ,P.IS_CHECK_TOOL");
                    sbQuery.Append(" ,P.IS_ATTACH_USE");
                    sbQuery.Append(" ,P.IS_ASSY ");
                    sbQuery.Append(" ,P.INS_FLAG ");
                    sbQuery.Append(" ,P.WO_TYPE");
                    sbQuery.Append(" ,P.MAIN_VND ");
                    sbQuery.Append(" ,V.VEN_NAME AS MAIN_VND_NAME");
                    sbQuery.Append(" ,P.ACT_CODE ");
                    sbQuery.Append(" ,P.IF_PROC_CODE ");
                    sbQuery.Append(" ,P.SCOMMENT ");
                    sbQuery.Append(" ,P.TRANSFER_TIME ");
                    sbQuery.Append(" FROM LSE_STD_PROC P ");
                    sbQuery.Append(" LEFT JOIN LSE_MACHINE WO_OSMC ");
                    sbQuery.Append(" ON P.PLT_CODE = WO_OSMC.PLT_CODE");
                    sbQuery.Append(" AND P.WO_DEFAULT_OSMC = WO_OSMC.MC_CODE ");
                    sbQuery.Append(" LEFT JOIN TCST_UNIT_COST_MASTER UTC ");
                    sbQuery.Append(" ON P.PLT_CODE = UTC.PLT_CODE");
                    sbQuery.Append(" AND P.CPROC_CODE = UTC.UTC_CODE ");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V ");
                    sbQuery.Append(" ON P.PLT_CODE = V.PLT_CODE");
                    sbQuery.Append(" AND P.MAIN_VND = V.VEN_CODE ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG ");
                    sbQuery.Append(" ON P.PLT_CODE = REG.PLT_CODE");
                    sbQuery.Append(" AND P.REG_EMP = REG.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY");
                    sbQuery.Append(" ON P.PLT_CODE = MDFY.PLT_CODE ");
                    sbQuery.Append(" AND P.MDFY_EMP = MDFY.EMP_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE P.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PRG_CODE", "P.MPROC_CODE = @PRG_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROC_CODE", "P.PROC_CODE = @PROC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@AVAILEMP", "P.PROC_CODE IN (SELECT PROC_CODE FROM LSE_STD_AVAILMC WHERE MC_CODE IN (SELECT MC_CODE FROM TSTD_MC_AVAILEMP WHERE EMP_CODE = @AVAILEMP))"));
                        sbWhere.Append(UTIL.GetWhere(row, "@AVAILMC", "P.PROC_CODE IN (SELECT PROC_CODE FROM LSE_STD_AVAILMC WHERE MC_CODE = @AVAILMC)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROC_LIKE", "(P.PROC_CODE LIKE '%' + @PROC_LIKE + '%' OR P.PROC_NAME LIKE '%' + @PROC_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_OS", "P.IS_OS = @IS_OS"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_BOP_PROC", "P.IS_BOP_PROC = @IS_BOP_PROC"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG","P.DATA_FLAG = @DATA_FLAG"));

                        sbWhere.Append(" ORDER BY P.PROC_SEQ");

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

                        sourceTable.TableName = "RSLTDT";
                        dsResult.Merge(sourceTable);  
                    }
                }


                return UTIL.GetDsToDt(dsResult);
            }
            catch(Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        //표준 공정 정보(계획 그리드 컬럼 생성 용)
        public static DataTable LSE_STD_PROC_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT ROW_NUMBER() OVER (ORDER BY PLT_CODE ASC) AS ROW_NUM");
                    sbQuery.Append(" , PROC_CODE 	 ");
                    sbQuery.Append(" , PROC_NAME 	 ");
                    sbQuery.Append(" , IS_MAT 	 ");
                    sbQuery.Append(" , PROC_MAN_TIME 	 ");
                    sbQuery.Append(" , SCOMMENT AS CAUTION	 ");
                    sbQuery.Append(" , MPROC_CODE ");
                    sbQuery.Append(" , IS_SHIP_PROC ");
                    sbQuery.Append(" , PROC_SEQ ");
                    sbQuery.Append(" , IS_ASSY ");
                    sbQuery.Append(" , IS_ATTACH_USE ");
                    sbQuery.Append(" FROM LSE_STD_PROC");
      
                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(" AND DATA_FLAG = 0 AND IS_BOP_PROC = 1 ");
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_MAT", "ISNULL(IS_MAT,0) = @IS_MAT"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MPROC_CODE", "MPROC_CODE = @MPROC_CODE"));

                        sbWhere.Append(" ORDER BY PROC_SEQ");

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

        public static DataTable LSE_STD_PROC_QUERY4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT	 ");
                    sbQuery.Append(" P.PLT_CODE");
                    sbQuery.Append(" ,P.PROC_CODE");
                    sbQuery.Append(" ,P.PROC_NAME");
                    sbQuery.Append(" ,P.MPROC_CODE ");
                    sbQuery.Append(" ,PGM.PRG_NAME AS MPROC_NAME ");
                    sbQuery.Append(" ,LPROC_CODE ");
                    sbQuery.Append(" ,PGL.PRG_NAME AS LPROC_NAME ");
                    sbQuery.Append(" ,P.PROC_SEQ ");
                    sbQuery.Append(" ,P.PROC_COLOR ");
                    sbQuery.Append(" ,PGL.PRG_SEQ AS PGL_SEQ ");
                    sbQuery.Append(" ,PGM.PRG_SEQ AS PGM_SEQ ");
                    sbQuery.Append(" ,P.PROC_MAN_TIME");
                    sbQuery.Append(" ,P.PROC_SELF_TIME ");
                    sbQuery.Append(" ,P.CPROC_CODE ");
                    sbQuery.Append(" ,UTC.UTC_NAME AS CPROC_NAME ");
                    sbQuery.Append(" ,P.REG_DATE ");
                    sbQuery.Append(" ,P.REG_EMP");
                    sbQuery.Append(" ,REG.EMP_NAME AS REG_EMP_NAME ");
                    sbQuery.Append(" ,P.MDFY_DATE");
                    sbQuery.Append(" ,P.MDFY_EMP ");
                    sbQuery.Append(" ,MDFY.EMP_NAME AS MDFY_EMP_NAME ");
                    sbQuery.Append(" ,P.DATA_FLAG");
                    sbQuery.Append(" ,P.WO_DEFAULT_OSMC");
                    sbQuery.Append(" ,WO_OSMC.MC_NAME AS WO_DEFAULT_OSMC_NAME");
                    sbQuery.Append(" ,P.IS_OS");
                    sbQuery.Append(" ,P.BAL_DISP");
                    sbQuery.Append(" ,P.IS_BOP_PROC");
                    sbQuery.Append(" ,P.IS_CHECK_PREV_PROC ");
                    sbQuery.Append(" ,P.IS_PART_SAME_START ");
                    sbQuery.Append(" ,P.IS_CHECK_TOOL");
                    sbQuery.Append(" ,P.IS_ASSY ");
                    sbQuery.Append(" ,P.INS_FLAG ");
                    sbQuery.Append(" ,P.WO_TYPE ");
                    sbQuery.Append(" ,P.MAIN_VND ");
                    sbQuery.Append(" ,V.VEN_NAME AS MAIN_VND_NAME");
                    sbQuery.Append(" ,P.ACT_CODE ");
                    sbQuery.Append(" ,P.MPROC_PROGRESS_RATE");
                    sbQuery.Append(" ,P.IF_PROC_CODE ");
                    sbQuery.Append(" FROM LSE_STD_PROC P ");
                    sbQuery.Append(" JOIN TSTD_PROCGRP PGL ");
                    sbQuery.Append(" ON P.PLT_CODE = PGL.PLT_CODE");
                    sbQuery.Append(" AND P.LPROC_CODE = PGL.PRG_CODE ");
                    sbQuery.Append(" JOIN TSTD_PROCGRP PGM ");
                    sbQuery.Append(" ON P.PLT_CODE = PGM.PLT_CODE");
                    sbQuery.Append(" AND P.MPROC_CODE = PGM.PRG_CODE ");
                    sbQuery.Append(" LEFT JOIN LSE_MACHINE WO_OSMC ");
                    sbQuery.Append(" ON P.PLT_CODE = WO_OSMC.PLT_CODE");
                    sbQuery.Append(" AND P.WO_DEFAULT_OSMC = WO_OSMC.MC_CODE ");
                    sbQuery.Append(" LEFT JOIN TCST_UNIT_COST_MASTER UTC ");
                    sbQuery.Append(" ON P.PLT_CODE = UTC.PLT_CODE");
                    sbQuery.Append(" AND P.CPROC_CODE = UTC.UTC_CODE ");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V ");
                    sbQuery.Append(" ON P.PLT_CODE = V.PLT_CODE");
                    sbQuery.Append(" AND P.MAIN_VND = V.VEN_CODE ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG ");
                    sbQuery.Append(" ON P.PLT_CODE = REG.PLT_CODE");
                    sbQuery.Append(" AND P.REG_EMP = REG.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY");
                    sbQuery.Append(" ON P.PLT_CODE = MDFY.PLT_CODE ");
                    sbQuery.Append(" AND P.MDFY_EMP = MDFY.EMP_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE P.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@LPROC_CODE", "P.LPROC_CODE = @LPROC_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MPROC_CODE", "P.MPROC_CODE = @MPROC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROC_CODE", "P.PROC_CODE = @PROC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@AVAILEMP", "P.PROC_CODE IN (SELECT PROC_CODE FROM LSE_STD_AVAILMC WHERE MC_CODE IN (SELECT MC_CODE FROM TSTD_MC_AVAILEMP WHERE EMP_CODE = @AVAILEMP))"));
                        sbWhere.Append(UTIL.GetWhere(row, "@AVAILMC", "P.PROC_CODE IN (SELECT PROC_CODE FROM LSE_STD_AVAILMC WHERE MC_CODE = @AVAILMC)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROC_LIKE", "(P.PROC_CODE LIKE '%' + @PROC_LIKE + '%' OR P.PROC_NAME LIKE '%' + @PROC_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_OS", "P.IS_OS = @IS_OS"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MCLASS_FLAG", "PGM.MCLASS_FLAG = @MCLASS_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_BOP_PROC", "P.IS_BOP_PROC = @IS_BOP_PROC"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "P.DATA_FLAG = @DATA_FLAG AND PGL.DATA_FLAG = @DATA_FLAG AND PGM.DATA_FLAG = @DATA_FLAG"));

                        sbWhere.Append(" ORDER BY PGL.PRG_SEQ , PGM.PRG_SEQ , P.PROC_SEQ");

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

        public static DataTable LSE_STD_PROC_QUERY5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT LSP.PLT_CODE						  ");
                    sbQuery.Append("	 , TP.PRG_CODE						  ");
                    sbQuery.Append("	 , TP.PRG_NAME						  ");
                    sbQuery.Append("	 , LSP.PROC_CODE					  ");
                    sbQuery.Append("	 , LSP.PROC_NAME					  ");
                    sbQuery.Append("  FROM LSE_STD_PROC LSP					  ");
                    sbQuery.Append("	INNER JOIN TSTD_PROCGRP TP			  ");
                    sbQuery.Append("		ON LSP.MPROC_CODE = TP.PRG_CODE	  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE LSP.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PROC_CODE", "LSP.PROC_CODE = @PROC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_ASSY", "LSP.IS_ASSY = @IS_ASSY"));
                        sbWhere.Append(UTIL.GetWhere(row, "@LPROC_CODE", "LSP.LPROC_CODE = @LPROC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MPROC_CODE", "LSP.MPROC_CODE = @MPROC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "LSP.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_BOP_PROC", "LSP.IS_BOP_PROC = @IS_BOP_PROC"));

                        //sbWhere.Append(" ORDER BY TP.PRG_CODE, LSP.PROC_SEQ					  ");
                        sbWhere.Append(" ORDER BY TP.PRG_SEQ, LSP.PROC_SEQ					  ");
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
