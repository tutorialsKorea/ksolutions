using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSHP
{
    public class TSHP_IDLETIME
    {
        //SER
        public static DataTable TSHP_IDLETIME_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE");
                    sbQuery.Append(" ,IDLE_ID");
                    sbQuery.Append(" ,WORK_DATE");
                    sbQuery.Append(" ,MC_CODE");
                    sbQuery.Append(" ,EMP_CODE");
                    sbQuery.Append(" ,IDLE_CODE");
                    sbQuery.Append(" ,IDLE_TIME");
                    sbQuery.Append(" ,IDLE_STATE");
                    sbQuery.Append(" ,START_TIME");
                    sbQuery.Append(" ,END_TIME");
                    sbQuery.Append(" ,SCOMMENT");
                    sbQuery.Append(" ,ACTUAL_ID");
                    sbQuery.Append(" ,WO_NO");
                    sbQuery.Append(" ,REG_DATE");
                    sbQuery.Append(" ,REG_EMP");
                    sbQuery.Append(" ,MDFY_DATE");
                    sbQuery.Append(" ,MDFY_EMP");
                    sbQuery.Append(" ,DEL_DATE");
                    sbQuery.Append(" ,DEL_EMP");
                    sbQuery.Append(" ,DATA_FLAG");
                    sbQuery.Append(" FROM TSHP_IDLETIME");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND MC_CODE = @MC_CODE");
                    sbQuery.Append(" AND IDLE_STATE = @IDLE_STATE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MC_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "IDLE_STATE")) isHasColumn = false;

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

        public static DataTable TSHP_IDLETIME_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE");
                    sbQuery.Append(" ,IDLE_ID");
                    sbQuery.Append(" ,WORK_DATE");
                    sbQuery.Append(" ,MC_CODE");
                    sbQuery.Append(" ,EMP_CODE");
                    sbQuery.Append(" ,IDLE_CODE");
                    sbQuery.Append(" ,IDLE_TIME");
                    sbQuery.Append(" ,IDLE_STATE");
                    sbQuery.Append(" ,START_TIME");
                    sbQuery.Append(" ,END_TIME");
                    sbQuery.Append(" ,SCOMMENT");
                    sbQuery.Append(" ,REG_DATE");
                    sbQuery.Append(" ,REG_EMP");
                    sbQuery.Append(" ,MDFY_DATE");
                    sbQuery.Append(" ,MDFY_EMP");
                    sbQuery.Append(" ,DEL_DATE");
                    sbQuery.Append(" ,DEL_EMP");
                    sbQuery.Append(" ,DATA_FLAG");
                    sbQuery.Append(" FROM TSHP_IDLETIME");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND IDLE_ID = @IDLE_ID");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "IDLE_ID")) isHasColumn = false;

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


        //INS
        public static void TSHP_IDLETIME_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();
                if (dtParam.Rows.Count > 0)
                {
                    string idleID = UTIL.UTILITY_GET_SERIALNO(dtParam.Rows[0]["PLT_CODE"].ToString(), "IL", UTIL.emSerialFormat.YYYYMMDD, "", bizExecute);

                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO TSHP_IDLETIME");
                    sbQuery.Append(" (PLT_CODE");
                    sbQuery.Append(" ,IDLE_ID");
                    sbQuery.Append(" ,WORK_DATE");
                    sbQuery.Append(" ,MC_CODE");
                    sbQuery.Append(" ,EMP_CODE");
                    sbQuery.Append(" ,IDLE_CODE");
                    sbQuery.Append(" ,IDLE_TIME");
                    sbQuery.Append(" ,IDLE_STATE");
                    sbQuery.Append(" ,START_TIME");
                    sbQuery.Append(" ,END_TIME");
                    sbQuery.Append(" ,ACTUAL_ID");
                    sbQuery.Append(" ,WO_NO");
                    sbQuery.Append(" ,SCOMMENT");
                    sbQuery.Append(" ,REG_DATE");
                    sbQuery.Append(" ,REG_EMP");
                    sbQuery.Append(" ,DATA_FLAG)");
                    sbQuery.Append(" VALUES");
                    sbQuery.Append(" (@PLT_CODE");
                    sbQuery.Append(" ,'" + idleID + "'");
                    sbQuery.Append(" ,CONVERT(nvarchar(8), GETDATE(), 112)");
                    sbQuery.Append(" ,@MC_CODE");
                    sbQuery.Append(" ,@EMP_CODE");
                    sbQuery.Append(" ,@IDLE_CODE");
                    sbQuery.Append(" ,NULL");
                    sbQuery.Append(" ,@IDLE_STATE");
                    sbQuery.Append(" ,GETDATE()");
                    sbQuery.Append(" ,NULL");
                    sbQuery.Append(" ,@ACTUAL_ID");
                    sbQuery.Append(" ,@WO_NO");
                    sbQuery.Append(" ,NULL");
                    sbQuery.Append(" ,GETDATE()");
                    sbQuery.Append(" ,@REG_EMP");
                    sbQuery.Append(" ,0)");

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

        public static void TSHP_IDLETIME_INS2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();
                if (dtParam.Rows.Count > 0)
                {
                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbQuery = new StringBuilder();
                        sbQuery.Append(" INSERT INTO TSHP_IDLETIME");
                        sbQuery.Append(" (PLT_CODE");
                        sbQuery.Append(" ,IDLE_ID");
                        sbQuery.Append(" ,WORK_DATE");
                        sbQuery.Append(" ,MC_CODE");
                        sbQuery.Append(" ,EMP_CODE");
                        sbQuery.Append(" ,IDLE_CODE");
                        sbQuery.Append(" ,IDLE_TIME");
                        sbQuery.Append(" ,IDLE_STATE");
                        sbQuery.Append(" ,START_TIME");
                        sbQuery.Append(" ,END_TIME");
                        sbQuery.Append(" ,ACTUAL_ID");
                        sbQuery.Append(" ,WO_NO");
                        sbQuery.Append(" ,SCOMMENT");
                        sbQuery.Append(" ,REG_DATE");
                        sbQuery.Append(" ,REG_EMP");
                        sbQuery.Append(" ,DATA_FLAG)");
                        sbQuery.Append(" VALUES");
                        sbQuery.Append(" (@PLT_CODE");
                        sbQuery.Append(" ,@IDLE_ID");
                        sbQuery.Append(" ,CONVERT(nvarchar(8), GETDATE(), 112)");
                        sbQuery.Append(" ,@MC_CODE");
                        sbQuery.Append(" ,@EMP_CODE");
                        sbQuery.Append(" ,@IDLE_CODE");
                        sbQuery.Append(" ,@IDLE_TIME");
                        sbQuery.Append(" ,@IDLE_STATE");
                        sbQuery.Append(" ,@START_TIME");
                        sbQuery.Append(" ,@END_TIME");
                        sbQuery.Append(" ,@ACTUAL_ID");
                        sbQuery.Append(" ,@WO_NO");
                        sbQuery.Append(" ,NULL");
                        sbQuery.Append(" ,GETDATE()");
                        sbQuery.Append(" ,@REG_EMP");
                        sbQuery.Append(" ,0)");

                        bizExecute.executeInsertQuery(sbQuery.ToString(), row);
                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        //UPD

        public static void TSHP_IDLETIME_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_IDLETIME SET ");
                    sbQuery.Append("  IDLE_TIME = @IDLE_TIME");
                    sbQuery.Append(" ,IDLE_STATE = @IDLE_STATE");
                    sbQuery.Append(" ,END_TIME = @END_TIME");
                    sbQuery.Append(" ,WO_NO = @WO_NO");
                    sbQuery.Append(" ,ACTUAL_ID = @ACTUAL_ID");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND IDLE_ID = @IDLE_ID");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "IDLE_ID")) isHasColumn = false;

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

        public static void TSHP_IDLETIME_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_IDLETIME       ");
                    sbQuery.Append(" SET   PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" , IDLE_ID = @IDLE_ID       ");
                    sbQuery.Append(" , WORK_DATE = @WORK_DATE   ");
                    sbQuery.Append(" , MC_CODE = @MC_CODE       ");
                    sbQuery.Append(" , EMP_CODE = @EMP_CODE		");
                    sbQuery.Append(" , IDLE_CODE = @IDLE_CODE	");
                    sbQuery.Append(" , IDLE_TIME = @IDLE_TIME	");
                    sbQuery.Append(" , IDLE_STATE = @IDLE_STATE	");
                    sbQuery.Append(" , START_TIME = @START_TIME	");
                    sbQuery.Append(" , END_TIME = @END_TIME		");
                    sbQuery.Append(" , SCOMMENT = @SCOMMENT		");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()	");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , DATA_FLAG = @DATA_FLAG	");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND IDLE_ID = @IDLE_ID		");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "IDLE_ID")) isHasColumn = false;

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

        public static void TSHP_IDLETIME_UPD3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_IDLETIME SET ");
                    sbQuery.Append("   END_TIME = @END_TIME");
                    sbQuery.Append(" , IDLE_TIME = @IDLE_TIME");
                    sbQuery.Append(" , IDLE_STATE = @IDLE_STATE");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND IDLE_ID = @IDLE_ID");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "IDLE_ID")) isHasColumn = false;

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

        public static void TSHP_IDLETIME_UPD4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_IDLETIME SET ");
                    sbQuery.Append("   IDLE_TIME = DATEDIFF(MINUTE,START_TIME,END_TIME)");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND IDLE_ID = @IDLE_ID");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "IDLE_ID")) isHasColumn = false;

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

        //UDE
        public static void TSHP_IDLETIME_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            if (dtParam.Rows.Count > 0)
            {
                StringBuilder sbQuery = new StringBuilder();
                sbQuery.Append(" UPDATE TSHP_IDLETIME       ");
                sbQuery.Append(" SET   DEL_DATE = GETDATE() ");
                sbQuery.Append(" , DEL_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                sbQuery.Append(" , DATA_FLAG = @DATA_FLAG   ");
                sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                sbQuery.Append(" AND IDLE_ID = @IDLE_ID	    ");

                foreach (DataRow row in dtParam.Rows)
                {

                    bool isHasColumn = true;

                    if (!UTIL.ValidColumn(row, "IDLE_ID")) isHasColumn = false;

                    if (isHasColumn == true)
                    {
                        bizExecute.executeUpdateQuery(sbQuery.ToString(), row);
                    }
                }
            }
        }


        //DEL
    }

    public class TSHP_IDLETIME_QUERY
    {

        public static DataTable TSHP_IDLETIME_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT IL.IDLE_ID");
                    sbQuery.Append(" ,IL.PLT_CODE");
                    sbQuery.Append(" ,IL.WORK_DATE");
                    sbQuery.Append(" ,IL.MC_CODE");
                    sbQuery.Append(" ,M.MC_NAME");
                    sbQuery.Append(" ,IL.EMP_CODE");
                    sbQuery.Append(" ,IL.WO_NO");
                    sbQuery.Append(" ,EMP.EMP_NAME");
                    sbQuery.Append(" ,IL.START_TIME");
                    sbQuery.Append(" ,IL.END_TIME");
                    sbQuery.Append(" ,IL.IDLE_STATE");
                    //sbQuery.Append(" ,IL.IDLE_CODE");
                    sbQuery.Append(" ,CD.CD_CODE AS IDLE_CODE");
                    sbQuery.Append(" ,CD.CD_NAME AS IDLE_NAME ");
                    //sbQuery.Append(" ,CDE.CD_CODE AS PAUSE_CODE");
                    //sbQuery.Append(" ,CASE WHEN CD.CD_NAME IS NULL THEN CDE.CD_NAME ELSE CD.CD_NAME END AS IDLE_NAME");
                    sbQuery.Append(" ,IL.IDLE_TIME");
                    sbQuery.Append(" ,IL.SCOMMENT");
                    sbQuery.Append(" FROM TSHP_IDLETIME IL");
                    sbQuery.Append(" LEFT JOIN LSE_MACHINE M ");
                    sbQuery.Append(" ON IL.PLT_CODE = M.PLT_CODE");
                    sbQuery.Append(" AND IL.MC_CODE = M.MC_CODE");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE EMP");
                    sbQuery.Append(" ON IL.PLT_CODE = EMP.PLT_CODE");
                    sbQuery.Append(" AND IL.EMP_CODE = EMP.EMP_CODE");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_CODES CD");
                    sbQuery.Append(" ON IL.PLT_CODE = CD.PLT_CODE");
                    sbQuery.Append(" AND IL.IDLE_CODE = CD.CD_CODE");
                    sbQuery.Append(" AND CD.CAT_CODE = 'C010'");

                    //sbQuery.Append(" LEFT JOIN TSTD_CODES CDE");
                    //sbQuery.Append(" ON IL.PLT_CODE = CDE.PLT_CODE");
                    //sbQuery.Append(" AND IL.IDLE_CODE = CDE.CD_CODE");
                    //sbQuery.Append(" AND CDE.CAT_CODE = 'C009'");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE IL.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@IDLE_ID", "IL.IDLE_ID = @IDLE_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_CODE", "IL.MC_CODE = @MC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "IL.EMP_CODE = @EMP_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "IL.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_WORK_DATE,@E_WORK_DATE", "IL.WORK_DATE BETWEEN @S_WORK_DATE AND @E_WORK_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IDLE_STATE", "IL.IDLE_STATE = @IDLE_STATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_GROUP", "M.MC_GROUP = @MC_GROUP"));

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

        
        public static DataTable TSHP_IDLETIME_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT IL.IDLE_ID");
                    sbQuery.Append(" ,IL.PLT_CODE");
                    sbQuery.Append(" ,IL.WORK_DATE");
                    sbQuery.Append(" ,IL.MC_CODE");
                    sbQuery.Append(" ,M.MC_NAME");
                    sbQuery.Append(" ,IL.EMP_CODE");
                    sbQuery.Append(" ,EMP.EMP_NAME");
                    sbQuery.Append(" ,IL.START_TIME");
                    sbQuery.Append(" ,CASE WHEN IL.IDLE_STATE = 0 THEN IL.END_TIME ");
                    sbQuery.Append(" WHEN  IL.IDLE_STATE = 1 THEN getdate() ");
                    sbQuery.Append(" END AS END_TIME ");
                    //sbQuery.Append(" ,IL.END_TIME");
                    sbQuery.Append(" ,IL.IDLE_STATE");

                    sbQuery.Append(" ,CD.CD_CODE AS IDLE_CODE");
                    sbQuery.Append(" ,CDE.CD_CODE AS PAUSE_CODE");
                    sbQuery.Append(" ,CASE WHEN CD.CD_NAME IS NULL THEN CDE.CD_NAME ELSE CD.CD_NAME END AS IDLE_NAME");
                    sbQuery.Append(" ,IL.IDLE_TIME");
                    sbQuery.Append(" ,IL.SCOMMENT");
                    sbQuery.Append(" FROM TSHP_IDLETIME IL");
                    sbQuery.Append(" LEFT JOIN LSE_MACHINE M ");
                    sbQuery.Append(" ON IL.PLT_CODE = M.PLT_CODE");
                    sbQuery.Append(" AND IL.MC_CODE = M.MC_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE EMP");
                    sbQuery.Append(" ON IL.PLT_CODE = EMP.PLT_CODE");
                    sbQuery.Append(" AND IL.EMP_CODE = EMP.EMP_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_CODES CD");
                    sbQuery.Append(" ON IL.PLT_CODE = CD.PLT_CODE");
                    sbQuery.Append(" AND IL.IDLE_CODE = CD.CD_CODE");
                    sbQuery.Append(" AND CD.CAT_CODE = 'C010'");

                    sbQuery.Append(" LEFT JOIN TSTD_CODES CDE");
                    sbQuery.Append(" ON IL.PLT_CODE = CDE.PLT_CODE");
                    sbQuery.Append(" AND IL.IDLE_CODE = CDE.CD_CODE");
                    sbQuery.Append(" AND CDE.CAT_CODE = 'C009'");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE IL.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@IDLE_ID", "IL.IDLE_ID = @IDLE_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_CODE", "IL.MC_CODE = @MC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "IL.EMP_CODE = @EMP_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "IL.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_WORK_DATE,@E_WORK_DATE", "IL.WORK_DATE BETWEEN @S_WORK_DATE AND @E_WORK_DATE"));                        
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_GROUP", "M.MC_GROUP = @MC_GROUP"));
                        sbWhere.Append(" AND IL.IDLE_STATE IN ('0', '1')");

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

        public static DataTable TSHP_IDLETIME_QUERY4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT I.PLT_CODE,  ");
                    sbQuery.Append("     I.IDLE_ID,          ");
                    sbQuery.Append("     I.MC_CODE,       ");
                    sbQuery.Append("     I.IDLE_CODE,      ");
                    sbQuery.Append("     C.CD_NAME  AS IDLE_NAME      ");
                    sbQuery.Append(" FROM TSHP_IDLETIME I JOIN TSTD_CODES C ");
                    sbQuery.Append("  ON I.PLT_CODE = C.PLT_CODE                  ");
                    sbQuery.Append("  AND I.IDLE_CODE = C.CD_CODE                ");
                    sbQuery.Append(" WHERE I.PLT_CODE = @PLT_CODE                      ");
                    sbQuery.Append(" AND I.IDLE_STATE = 1                            ");
                    sbQuery.Append(" AND C.CAT_CODE IN ('C009', 'C010')            ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString(), row).Copy();

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

        public static DataTable TSHP_IDLETIME_QUERY5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();


                    sbQuery.Append(" SELECT I.PLT_CODE               ");
                    sbQuery.Append(" 	, W.WO_NO                    ");
                    sbQuery.Append(" 	, I.IDLE_CODE                ");
                    sbQuery.Append(" 	, I.START_TIME               ");
                    sbQuery.Append(" FROM TSHP_IDLETIME I            ");
                    sbQuery.Append("  JOIN TSHP_ACTUAL A             ");
                    sbQuery.Append("  ON I.PLT_CODE = I.PLT_CODE     ");
                    sbQuery.Append(" AND I.ACTUAL_ID = A.ACTUAL_ID   ");
                    sbQuery.Append("  JOIN TSHP_WORKORDER W          ");
                    sbQuery.Append("  ON A.PLT_CODE = W.PLT_CODE     ");
                    sbQuery.Append("  AND A.WO_NO = W.WO_NO          ");
                    sbQuery.Append("  ORDER BY I.START_TIME          ");
                    
                    foreach (DataRow row in dtParam.Rows)
                    {
                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString(), row).Copy();

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



        public static DataTable TSHP_IDLETIME_QUERY6(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT  ");
                    sbQuery.Append(" PLT_CODE ");
                    sbQuery.Append(" ,IDLE_ID ");
                    sbQuery.Append(" ,IDLE_TIME ");
                    sbQuery.Append(" ,IDLE_STATE ");
                    sbQuery.Append(" ,START_TIME ");
                    sbQuery.Append(" ,END_TIME ");
                    sbQuery.Append(" FROM TSHP_IDLETIME ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@WO_NO", "WO_NO = @WO_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "EMP_CODE = @EMP_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_CODE", "MC_CODE = @MC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@NULL_END_TIME", "END_TIME IS NULL "));
                        //sbWhere.Append(UTIL.GetWhere(row, "@PROC_STAT_IN", "PROC_STAT IN ('2','3') "));

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
        /// 비가동중인 설비 조회
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TSHP_IDLETIME_QUERY7(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT IL.IDLE_ID");
                    sbQuery.Append(" ,IL.PLT_CODE");
                    sbQuery.Append(" ,IL.WORK_DATE");
                    sbQuery.Append(" ,IL.MC_CODE");
                    sbQuery.Append(" ,M.MC_NAME");
                    sbQuery.Append(" ,IL.EMP_CODE");
                    sbQuery.Append(" ,IL.WO_NO");
                    sbQuery.Append(" ,EMP.EMP_NAME");
                    sbQuery.Append(" ,IL.START_TIME");
                    sbQuery.Append(" ,IL.END_TIME");
                    sbQuery.Append(" ,IL.IDLE_STATE");
                    //sbQuery.Append(" ,IL.IDLE_CODE");
                    sbQuery.Append(" ,CD.CD_CODE AS IDLE_CODE");
                    sbQuery.Append(" ,CD.CD_NAME AS IDLE_NAME ");
                    //sbQuery.Append(" ,CDE.CD_CODE AS PAUSE_CODE");
                    //sbQuery.Append(" ,CASE WHEN CD.CD_NAME IS NULL THEN CDE.CD_NAME ELSE CD.CD_NAME END AS IDLE_NAME");
                    sbQuery.Append(" ,IL.IDLE_TIME");
                    sbQuery.Append(" ,IL.SCOMMENT");
                    sbQuery.Append(" FROM TSHP_IDLETIME IL");
                    sbQuery.Append(" LEFT JOIN LSE_MACHINE M ");
                    sbQuery.Append(" ON IL.PLT_CODE = M.PLT_CODE");
                    sbQuery.Append(" AND IL.MC_CODE = M.MC_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE EMP");
                    sbQuery.Append(" ON IL.PLT_CODE = EMP.PLT_CODE");
                    sbQuery.Append(" AND IL.EMP_CODE = EMP.EMP_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_CODES CD");
                    sbQuery.Append(" ON IL.PLT_CODE = CD.PLT_CODE");
                    sbQuery.Append(" AND IL.IDLE_CODE = CD.CD_CODE");
                    sbQuery.Append(" AND CD.CAT_CODE = 'C010'");

                    //sbQuery.Append(" LEFT JOIN TSTD_CODES CDE");
                    //sbQuery.Append(" ON IL.PLT_CODE = CDE.PLT_CODE");
                    //sbQuery.Append(" AND IL.IDLE_CODE = CDE.CD_CODE");
                    //sbQuery.Append(" AND CDE.CAT_CODE = 'C009'");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE IL.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@MC_CODE", "IL.MC_CODE = @MC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IDLE_STATE", "IL.IDLE_STATE = @IDLE_STATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "IL.DATA_FLAG = @DATA_FLAG"));

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

        public static DataTable TSHP_IDLETIME_QUERY8(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" I.PLT_CODE");
                    sbQuery.Append(" ,'비가동' AS MC_STATUS");
                    sbQuery.Append(" ,I.MC_CODE");
                    sbQuery.Append(" ,M.MC_NAME");
                    sbQuery.Append(" ,P.PROD_CODE");
                    sbQuery.Append(" ,P.PROD_NAME");
                    sbQuery.Append(" ,P.CVND_CODE");
                    sbQuery.Append(" ,V.VEN_NAME AS CVND_NAME");
                    sbQuery.Append(" ,W.PART_CODE");
                    sbQuery.Append(" ,SP.PART_NAME");
                    sbQuery.Append(" ,I.START_TIME AS ACT_START_TIME");
                    sbQuery.Append(" ,DATEDIFF(MINUTE, I.START_TIME, GETDATE()) AS ACT_TIME");
                    sbQuery.Append(" ,M.MC_SEQ");
                    sbQuery.Append(" ,M.MC_MNT_NAME");
                    sbQuery.Append(" ,I.IDLE_CODE");
                    sbQuery.Append(" FROM TSHP_IDLETIME I");
                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER W");
                    sbQuery.Append(" ON I.PLT_CODE = W.PLT_CODE");
                    sbQuery.Append(" AND I.WO_NO = W.WO_NO");
                    
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P");
                    sbQuery.Append(" ON W.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND W.PROD_CODE = P.PROD_CODE");
                    
                    sbQuery.Append(" LEFT JOIN LSE_MACHINE M");
                    sbQuery.Append(" ON I.PLT_CODE = M.PLT_CODE");
                    sbQuery.Append(" AND I.MC_CODE = M.MC_CODE");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V");
                    sbQuery.Append(" ON P.PLT_CODE = V.PLT_CODE");
                    sbQuery.Append(" AND P.CVND_CODE = V.VEN_CODE");
                    
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP");
                    sbQuery.Append(" ON W.PLT_CODE = SP.PLT_CODE");
                    sbQuery.Append(" AND W.PART_CODE = SP.PART_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE I.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "I.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(" AND IDLE_STATE = '1' ORDER BY M.MC_SEQ");

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
