using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DPOP
{
    public class TPOP_MC_ACTUAL
    {
        public static DataTable TPOP_MC_ACTUAL_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT																							  ");
                    sbQuery.Append(" WORK_DATE																						  ");
                    sbQuery.Append(" ,A.MC_CODE																						  ");
                    sbQuery.Append(" ,M.MC_NAME																						  ");
                    sbQuery.Append(" ,CASE WHEN @WORK_DATE = CONVERT(VARCHAR(10),GETDATE(),120) THEN								  ");
                    sbQuery.Append("   			      1.0*DATEDIFF(MI, @WORK_DATE,GETDATE())										  ");
                    sbQuery.Append("   	ELSE 1440 END TOT_CAPA																		  ");
                    sbQuery.Append(" ,SUM(ISNULL(MC_TIME, 0)) TOT_TIME																  ");
                    sbQuery.Append(" ,CASE WHEN @WORK_DATE = convert(varchar(10),getdate(),120) then								  ");
                    sbQuery.Append(" 			ROUND( SUM(ISNULL(MC_TIME, 0)) / (1.0 * datediff(mi, @WORK_DATE, getdate())) * 100, 2)");
                    sbQuery.Append("       ELSE ROUND( (SUM(ISNULL(MC_TIME, 0)) / 1440.0)* 100, 2) END WORK_RATE					  ");
                    sbQuery.Append(" ,MS.UPDATE_DATE																				  ");
                    sbQuery.Append(" FROM TPOP_MC_ACTUAL A																			  ");
                    sbQuery.Append(" LEFT JOIN LSE_MACHINE M																		  ");
                    sbQuery.Append(" ON A.PLT_CODE = M.PLT_CODE																		  ");
                    sbQuery.Append(" AND A.MC_CODE = M.MC_CODE																		  ");
                    sbQuery.Append(" 																								  ");
                    sbQuery.Append(" LEFT JOIN TPOP_MC_STATUS MS																	  ");
                    sbQuery.Append(" ON A.PLT_CODE = MS.PLT_CODE																	  ");
                    sbQuery.Append(" AND A.MC_CODE = MS.MC_CODE																		  ");

                    sbQuery.Append(" WHERE WORK_DATE = @WORK_DATE");
                    sbQuery.Append(" GROUP BY WORK_DATE, A.MC_CODE, M.MC_NAME, MS.UPDATE_DATE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "WORK_DATE")) isHasColumn = false;

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


        public static void TPOP_MC_ACTUAL_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TPOP_MC_ACTUAL SET  ");
                    sbQuery.Append("  MC_CODE = @MC_CODE ");
                    sbQuery.Append(" ,WORK_DATE = @WORK_DATE ");
                    sbQuery.Append(" ,MC_START_TIME = @MC_START_TIME ");
                    sbQuery.Append(" ,MC_END_TIME = @MC_END_TIME ");
                    sbQuery.Append(" ,PROD_INFO = @PROD_INFO ");
                    sbQuery.Append(" ,MDFY_EMP = '" + ConnInfo.UserID + "' ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append(" ,TIME_SHIFT = @TIME_SHIFT ");
                    sbQuery.Append(" ,NOR_TIME = @NOR_TIME ");
                    sbQuery.Append(" ,OT_TIME = @OT_TIME ");
                    sbQuery.Append(" ,TOOL_NO = @TOOL_NO ");
                    sbQuery.Append(" ,TOOL_DEL_DATE = @TOOL_DEL_DATE ");
                    sbQuery.Append(" ,TOOL_DEL_NO = @TOOL_DEL_NO ");
                    sbQuery.Append(" ,MOUNT_ID = @MOUNT_ID ");
                    sbQuery.Append(" ,TL_CODE = @TL_CODE ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND ACT_ID = @ACT_ID ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "ACT_ID")) isHasColumn = false;

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




        public static void TPOP_MC_ACTUAL_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TPOP_MC_ACTUAL SET  ");       
                    sbQuery.Append(" ,TOOL_DEL_DATE = GETDATE() ");
                    sbQuery.Append(" ,TOOL_DEL_NO = @TOOL_DEL_NO ");
                    //sbQuery.Append(" ,MOUNT_ID = @MOUNT_ID ");
                    //sbQuery.Append(" ,TL_CODE = @TL_CODE ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND MOUNT_ID = @MOUNT_ID ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MOUNT_ID")) isHasColumn = false;

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

    public class TPOP_MC_ACTUAL_QUERY
    {
        public static DataTable TPOP_MC_ACTUAL_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
    
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();


                    sbQuery.Append(" SELECT A.PLT_CODE");
                    sbQuery.Append(" ,A.MC_CODE");
                    sbQuery.Append(" ,M.MC_NAME");
                    sbQuery.Append(" ,M.MC_GROUP");
                    sbQuery.Append(" ,A.WORK_DATE");
                    sbQuery.Append(" ,SUM(DATEDIFF(MI,A.MC_START_TIME,A.MC_END_TIME)) AS ACT_TIME");
                    sbQuery.Append(" FROM TPOP_MC_ACTUAL A");
                    sbQuery.Append(" LEFT JOIN LSE_MACHINE M");
                    sbQuery.Append(" ON A.PLT_CODE = M.PLT_CODE");
                    sbQuery.Append(" AND A.MC_CODE = M.MC_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {

                        StringBuilder sbWhere = new StringBuilder(" WHERE A.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@WORK_DATE", "A.WORK_DATE = @WORK_DATE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@S_WORK_DATE,@E_WORK_DATE", "A.WORK_DATE BETWEEN @S_WORK_DATE AND @E_WORK_DATE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@MC_GROUP", "M.MC_GROUP = @MC_GROUP"));

                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "M.DATA_FLAG = @DATA_FLAG"));

                        sbWhere.Append(" AND A.MC_END_TIME IS NOT NULL ");

                        sbWhere.Append(" GROUP BY A.PLT_CODE,A.MC_CODE,M.MC_NAME,M.MC_GROUP ,A.WORK_DATE ");

                        sbWhere.Append(" ORDER BY A.WORK_DATE, A.MC_CODE DESC ");

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

        public static DataTable TPOP_MC_ACTUAL_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT																							  ");
                    sbQuery.Append(" WORK_DATE																						  ");
                    sbQuery.Append(" ,MC_CODE																						  ");
                    sbQuery.Append(" ,MC_STATE																						  ");
                    sbQuery.Append(" ,MC_START_TIME																					  ");
                    sbQuery.Append(" ,CASE WHEN MC_END_TIME IS NULL THEN GETDATE() ELSE MC_END_TIME END AS MC_END_TIME				  ");
                    sbQuery.Append(" ,CASE WHEN @WORK_DATE = CONVERT(VARCHAR(10),GETDATE(),120) THEN								  ");
                    sbQuery.Append("   			      1.0*DATEDIFF(MI, @WORK_DATE,GETDATE())										  ");
                    sbQuery.Append("   	ELSE 1440 END TOT_CAPA																		  ");
                    sbQuery.Append(" ,SUM(ISNULL(MC_TIME, 0)) TOT_TIME																  ");
                    sbQuery.Append(" ,CASE WHEN @WORK_DATE = convert(varchar(10),getdate(),120) then								  ");
                    sbQuery.Append(" 			ROUND( SUM(ISNULL(MC_TIME, 0)) / (1.0 * datediff(mi, @WORK_DATE, getdate())) * 100, 2)");
                    sbQuery.Append("       ELSE ROUND( (SUM(ISNULL(MC_TIME, 0)) / 1440.0)* 100, 2) END WORK_RATE					  ");
                    sbQuery.Append(" FROM TPOP_MC_ACTUAL																			  ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@WORK_DATE", "WORK_DATE = @WORK_DATE"));
                        sbWhere.Append(" GROUP BY WORK_DATE, MC_CODE, MC_STATE, MC_START_TIME, MC_END_TIME");
                        sbWhere.Append(" ORDER BY MC_START_TIME DESC");

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

        public static DataTable TPOP_MC_ACTUAL_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                    sbQuery.Append(" SELECT A.PLT_CODE");
                    sbQuery.Append(" ,A.MC_CODE");
                    sbQuery.Append(" ,M.MC_NAME");
                    sbQuery.Append(" ,M.MC_GROUP");
                    sbQuery.Append(" ,A.WORK_DATE");
                    sbQuery.Append(" ,CONVERT(INT, SUM(DATEDIFF(MI,A.MC_START_TIME,A.MC_END_TIME)) / 1440.0 * 100.0) AS ACT_RATE");
                    sbQuery.Append(" FROM TPOP_MC_ACTUAL A");
                    sbQuery.Append(" LEFT JOIN LSE_MACHINE M");
                    sbQuery.Append(" ON A.PLT_CODE = M.PLT_CODE");
                    sbQuery.Append(" AND A.MC_CODE = M.MC_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {

                        StringBuilder sbWhere = new StringBuilder(" WHERE A.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@WORK_DATE", "A.WORK_DATE = @WORK_DATE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@S_WORK_DATE,@E_WORK_DATE", "A.WORK_DATE BETWEEN @S_WORK_DATE AND @E_WORK_DATE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@MC_GROUP", "M.MC_GROUP = @MC_GROUP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_GROUPS", "M.MC_GROUP IN @MC_GROUPS", UTIL.SqlCondType.IN));

                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "M.DATA_FLAG = @DATA_FLAG"));

                        sbWhere.Append(" AND A.MC_END_TIME IS NOT NULL ");

                        sbWhere.Append(" GROUP BY A.PLT_CODE,A.MC_CODE,M.MC_NAME,M.MC_GROUP ,A.WORK_DATE, M.MC_SEQ ");

                        sbWhere.Append(" ORDER BY M.MC_SEQ, A.WORK_DATE, A.MC_CODE DESC ");

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

        public static DataTable TPOP_MC_ACTUAL_QUERY3_2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                    sbQuery.Append(" SELECT A.PLT_CODE");
                    sbQuery.Append(" ,M.MC_GROUP");
                    sbQuery.Append(" ,C.CD_NAME AS MC_GROUP_NAME");
                    sbQuery.Append(" ,A.WORK_DATE");
                    sbQuery.Append(" ,CONVERT(INT , SUM(DATEDIFF(MI,A.MC_START_TIME,A.MC_END_TIME)) / (1440.0 * (SELECT COUNT(MC_CODE) FROM LSE_MACHINE WHERE MC_GROUP = M.MC_GROUP AND DATA_FLAG = '0') ) * 100.0 )AS ACT_RATE");
                    sbQuery.Append(" FROM TPOP_MC_ACTUAL A");
                    sbQuery.Append(" LEFT JOIN LSE_MACHINE M");
                    sbQuery.Append(" ON A.PLT_CODE = M.PLT_CODE");
                    sbQuery.Append(" AND A.MC_CODE = M.MC_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_CODES C");
                    sbQuery.Append(" ON M.PLT_CODE = C.PLT_CODE");
                    sbQuery.Append(" AND M.MC_GROUP = C.CD_CODE");
                    sbQuery.Append(" AND C.CAT_CODE = 'C020'");


                    foreach (DataRow row in dtParam.Rows)
                    {

                        StringBuilder sbWhere = new StringBuilder(" WHERE A.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@WORK_DATE", "A.WORK_DATE = @WORK_DATE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@S_WORK_DATE,@E_WORK_DATE", "A.WORK_DATE BETWEEN @S_WORK_DATE AND @E_WORK_DATE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@MC_GROUP", "M.MC_GROUP = @MC_GROUP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_GROUPS", "M.MC_GROUP IN @MC_GROUPS", UTIL.SqlCondType.IN));

                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "M.DATA_FLAG = @DATA_FLAG"));

                        sbWhere.Append(" AND A.MC_END_TIME IS NOT NULL AND M.MC_GROUP <> 'F'");

                        sbWhere.Append(" GROUP BY A.PLT_CODE, M.MC_GROUP ,A.WORK_DATE , C.CD_NAME, C.CD_SEQ");

                        sbWhere.Append(" ORDER BY C.CD_SEQ, A.WORK_DATE, M.MC_GROUP DESC ");

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
