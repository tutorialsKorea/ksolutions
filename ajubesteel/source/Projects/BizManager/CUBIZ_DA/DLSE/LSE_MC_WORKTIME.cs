using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DLSE
{
    public class LSE_MC_WORKTIME
    {

        public static DataTable LSE_MC_WORKTIME_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();


                    sbQuery.Append("SELECT PLT_CODE");
                    sbQuery.Append(", MC_CODE");
                    sbQuery.Append(", MC_SHIFT");
                    sbQuery.Append(", MON_TIME");
                    sbQuery.Append(", TUE_TIME");
                    sbQuery.Append(", WED_TIME");
                    sbQuery.Append(", THR_TIME");
                    sbQuery.Append(", FRI_TIME");
                    sbQuery.Append(", SAT_TIME");
                    sbQuery.Append(", SUN_TIME");
                    sbQuery.Append(" FROM LSE_MC_WORKTIME");
                    sbQuery.Append(" WHERE MC_CODE = @MC_CODE");
                    sbQuery.Append(" AND MC_SHIFT = @MC_SHIFT");
                    sbQuery.Append(" AND PLT_CODE = @PLT_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "MC_CODE")) isHasColumn = false;

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


        public static DataTable LSE_MC_WORKTIME_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                   
                    sbQuery.Append("SELECT PLT_CODE");
                    sbQuery.Append(", MC_CODE");
                    sbQuery.Append(", MC_SHIFT");
                    sbQuery.Append(", MON_TIME");
                    sbQuery.Append(", TUE_TIME");
                    sbQuery.Append(", WED_TIME");
                    sbQuery.Append(", THR_TIME");
                    sbQuery.Append(", FRI_TIME");
                    sbQuery.Append(", SAT_TIME");
                    sbQuery.Append(", SUN_TIME");
                    sbQuery.Append(" FROM LSE_MC_WORKTIME");
                    sbQuery.Append(" WHERE MC_CODE = @MC_CODE");
                    sbQuery.Append(" AND PLT_CODE = @PLT_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "MC_CODE")) isHasColumn = false;

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

        public static DataTable LSE_MC_WORKTIME_GETIMG(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbQuery = new StringBuilder();
                        sbQuery.Append(" SELECT PLT_CODE");
                        sbQuery.Append(" MC_IMAGE ");
                        sbQuery.Append(" FROM LSE_MACHINE");
                        sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                        sbQuery.Append(" AND MC_CODE = @MC_CODE ");

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "MC_CODE")) isHasColumn = false;

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

        public static void LSE_MC_WORKTIME_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE LSE_MACHINE ");
                    sbQuery.Append(" SET MC_CODE = @MC_CODE ");
                    sbQuery.Append(" , MC_NAME = @MC_NAME ");
                    sbQuery.Append(" , MC_GROUP = @MC_GROUP ");
                    sbQuery.Append(" , MC_AUTOMATED = @MC_AUTOMATED ");
                    sbQuery.Append(" , MC_OS = @MC_OS ");
                    sbQuery.Append(" , MC_SHIFT = @MC_SHIFT ");
                    sbQuery.Append(" , MC_MGT_FLAG = @MC_MGT_FLAG ");
                    sbQuery.Append(" , MC_OPEN_DATE = @MC_OPEN_DATE ");
                    sbQuery.Append(" , MC_CLOSE_DATE = @MC_CLOSE_DATE ");
                    sbQuery.Append(" , MC_MODEL = @MC_MODEL ");
                    sbQuery.Append(" , MC_EFFICIENCY = @MC_EFFICIENCY ");
                    sbQuery.Append(" , CPROC_CODE = @CPROC_CODE ");
                    sbQuery.Append(" , MC_SEQ = @MC_SEQ ");
                    sbQuery.Append(" , MAIN_EMP = @MAIN_EMP ");
                    sbQuery.Append(" , SCOMMENT = @SCOMMENT ");
                    sbQuery.Append(" , MC_IP = @MC_IP ");
                    sbQuery.Append(" , PLC_IP = @PLC_IP ");
                    sbQuery.Append(" , PLC_PORT = @PLC_PORT ");
                    sbQuery.Append(" , IS_SIGNAL = @IS_SIGNAL ");
                    sbQuery.Append(" , SIGNAL_TYPE = @SIGNAL_TYPE ");
                    sbQuery.Append(" , IS_OPERATE_STATE = @IS_OPERATE_STATE ");
                    sbQuery.Append(" , IS_MULTI_START = @IS_MULTI_START ");
                    sbQuery.Append(" , MULTI_START_DIV = @MULTI_START_DIV ");
                    sbQuery.Append(" , FTP_PORT = @FTP_PORT ");
                    sbQuery.Append(" , FTP_USER = @FTP_USER ");
                    sbQuery.Append(" , FTP_USER_PW = @FTP_USER_PW ");
                    sbQuery.Append(" , FTP_DIR = @FTP_DIR ");
                    sbQuery.Append(" , IF_MC_CODE = @IF_MC_CODE ");
                    sbQuery.Append(" , MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , DATA_FLAG = 0 ");
                    sbQuery.Append(" WHERE MC_CODE = @MC_CODE ");
                    sbQuery.Append(" AND PLT_CODE = @PLT_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "MC_CODE")) isHasColumn = false;

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

        public static void LSE_MC_WORKTIME_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE LSE_MACHINE");
                    sbQuery.Append(" SET MAIN_EMP = @MAIN_EMP");
                    sbQuery.Append(" , DEL_DATE = GETDATE() ");
                    sbQuery.Append(" , DEL_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , DATA_FLAG = 2 ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND MC_CODE = @MC_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MC_CODE")) isHasColumn = false;

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

        public static void LSE_MC_WORKTIME_DEL2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append("DELETE FROM LSE_MC_WORKTIME ");
                    sbQuery.Append(" WHERE MC_CODE = @MC_CODE");
                    sbQuery.Append(" AND PLT_CODE = @PLT_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "MC_CODE")) isHasColumn = false;

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


        public static void LSE_MC_WORKTIME_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO LSE_MC_WORKTIME ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append("        PLT_CODE ");
                    sbQuery.Append("      , MC_CODE ");
                    sbQuery.Append("      , MC_SHIFT ");
                    sbQuery.Append("      , MON_TIME ");
                    sbQuery.Append("      , TUE_TIME ");
                    sbQuery.Append("      , WED_TIME ");
                    sbQuery.Append("      , THR_TIME ");
                    sbQuery.Append("      , FRI_TIME ");
                    sbQuery.Append("      , SAT_TIME ");
                    sbQuery.Append("      , SUN_TIME ");
                    sbQuery.Append(" ) ");
                    sbQuery.Append(" VALUES ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append("        @PLT_CODE ");
                    sbQuery.Append("      , @MC_CODE ");
                    sbQuery.Append("      , @MC_SHIFT ");
                    sbQuery.Append("      , @MON_TIME ");
                    sbQuery.Append("      , @TUE_TIME ");
                    sbQuery.Append("      , @WED_TIME ");
                    sbQuery.Append("      , @THR_TIME ");
                    sbQuery.Append("      , @FRI_TIME ");
                    sbQuery.Append("      , @SAT_TIME ");
                    sbQuery.Append("      , @SUN_TIME ");
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

    }

    public class LSE_MC_WORKTIME_QUERY
    {


        //설비 기준정보 불러오기
        public static DataTable LSE_MC_WORKTIME_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" ,MC_CODE");
                    sbQuery.Append(" ,MC_NAME");
                    sbQuery.Append(" ,MC_GROUP ");
                    sbQuery.Append(" ,MC_AUTOMATED ");
                    sbQuery.Append(" ,MC_OS");
                    sbQuery.Append(" ,MC_SHIFT ");
                    sbQuery.Append(" ,MC_MGT_FLAG");
                    sbQuery.Append(" ,MC_OPEN_DATE ");
                    sbQuery.Append(" ,MC_CLOSE_DATE");
                    sbQuery.Append(" ,MC_MODEL ");
                    sbQuery.Append(" ,MC_EFFICIENCY");
                    sbQuery.Append(" ,CPROC_CODE ");
                    sbQuery.Append(" ,MC_TYPE");
                    sbQuery.Append(" ,MC_SEQ ");
                    sbQuery.Append(" ,MAIN_EMP ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP");
                    sbQuery.Append(" ,MDFY_DATE");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append(" ,DATA_FLAG");
                    sbQuery.Append(" ,DEL_DATE ");
                    sbQuery.Append(" ,DEL_EMP");
                    sbQuery.Append(" ,MC_IP");
                    sbQuery.Append(" ,PLC_IP ");
                    sbQuery.Append(" ,IS_SIGNAL");
                    sbQuery.Append(" ,IS_OPERATE_STATE ");
                    sbQuery.Append(" ,FTP_PORT ");
                    sbQuery.Append(" ,FTP_USER ");
                    sbQuery.Append(" ,FTP_USER_PW");
                    sbQuery.Append(" ,FTP_DIR");
                    sbQuery.Append(" FROM LSE_MACHINE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE =" + UTIL.GetValidValue(row, "PLT_CODE").ToString().ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@MC_CODE", "MC_CODE = @MC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_GROUP", "MC_GROUP = @MC_GROUP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_OS", "MC_OS = @MC_OS"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_OPERATE_STATE", "IS_OPERATE_STATE = @IS_OPERATE_STATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAIN_EMP", "MAIN_EMP = @MAIN_EMP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_MGT_FLAG", "MC_MGT_FLAG = @MC_MGT_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_LIKE", "(MC_CODE LIKE '%' + @MC_LIKE + '%' OR MC_NAME LIKE '%' + @MC_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "DATA_FLAG = @DATA_FLAG"));

                        sbWhere.Append(" ORDER BY MC_SEQ ASC");

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

        public static DataTable LSE_MC_WORKTIME_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("SELECT ");
                    sbQuery.Append(" A.PLT_CODE ");
                    sbQuery.Append(" ,A.MC_CODE ");
                    sbQuery.Append(" ,A.MC_NAME ");
                    sbQuery.Append(" ,A.MC_MODEL");
                    sbQuery.Append(" ,A.MC_GROUP");
                    sbQuery.Append(" ,A.MC_AUTOMATED");
                    sbQuery.Append(" ,A.MC_OS ");
                    sbQuery.Append(" ,A.MC_MGT_FLAG ");
                    sbQuery.Append(" ,A.MC_OPEN_DATE");
                    sbQuery.Append(" ,A.MC_CLOSE_DATE ");
                    sbQuery.Append(" ,A.MC_SEQ");
                    sbQuery.Append(" ,A.MAIN_EMP");
                    sbQuery.Append(" ,B.EMP_NAME AS MAIN_EMP_NAME ");
                    sbQuery.Append(" ,A.CPROC_CODE");
                    sbQuery.Append(" ,UM.UTC_NAME AS CPROC_NAME ");
                    sbQuery.Append(" ,A.SCOMMENT");
                    sbQuery.Append(" ,A.REG_DATE");
                    sbQuery.Append(" ,A.REG_EMP ");
                    sbQuery.Append(" ,REG.EMP_NAME AS REG_EMP_NAME");
                    sbQuery.Append(" ,A.MDFY_DATE ");
                    sbQuery.Append(" ,A.MDFY_EMP");
                    sbQuery.Append(" ,MDFY.EMP_NAME AS MDFY_EMP_NAME");
                    sbQuery.Append(" ,A.MC_SHIFT");
                    sbQuery.Append(" ,A.IS_SIGNAL ");
                    sbQuery.Append(" ,A.MC_IP ");
                    sbQuery.Append(" ,A.PLC_IP");
                    sbQuery.Append(" ,A.PLC_PORT");
                    sbQuery.Append(" ,A.IS_OPERATE_STATE");
                    sbQuery.Append(" ,A.FTP_PORT");
                    sbQuery.Append(" ,A.FTP_USER");
                    sbQuery.Append(" ,A.FTP_USER_PW ");
                    sbQuery.Append(" ,A.FTP_DIR ");
                    sbQuery.Append(" ,A.IS_MULTI_START");
                    sbQuery.Append(" ,A.MULTI_START_DIV ");
                    sbQuery.Append(" ,A.SIGNAL_TYPE ");
                    sbQuery.Append(" ,A.IF_MC_CODE");
                    sbQuery.Append(" FROM LSE_MACHINE A");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE B");
                    sbQuery.Append(" ON A.PLT_CODE = B.PLT_CODE AND A.MAIN_EMP = B.EMP_CODE ");
                    sbQuery.Append(" LEFT JOIN TCST_UNIT_COST_MASTER UM ");
                    sbQuery.Append(" ON A.PLT_CODE = UM.PLT_CODE AND A.CPROC_CODE = UM.UTC_CODE ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG");
                    sbQuery.Append(" ON A.PLT_CODE = REG.PLT_CODE AND A.REG_EMP = REG.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY ");
                    sbQuery.Append(" ON A.PLT_CODE = MDFY.PLT_CODE AND A.MDFY_EMP = MDFY.EMP_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE A.PLT_CODE =" + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@AVAILEMP", "A.MC_CODE IN (SELECT MC_CODE  FROM TSTD_MC_AVAILEMP WHERE  PLT_CODE = A.PLT_CODE AND EMP_CODE = @AVAILEMP)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_CODE", "A.MC_CODE = @MC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_NAME", "A.MC_NAME = @MC_NAME"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_LIKE", "(A.MC_CODE LIKE '%' + @MC_LIKE + '%' OR A.MC_NAME LIKE '%' + @MC_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_MODEL_LIKE", "(A.MC_MODEL LIKE '%' + @MC_MODEL_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "A.DATA_FLAG = @DATA_FLAG"));

                        sbWhere.Append(" ORDER BY A.MC_SEQ");

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
