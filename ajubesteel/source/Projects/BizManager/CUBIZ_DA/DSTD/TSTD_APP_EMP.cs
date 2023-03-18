using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSTD
{
    public class TSTD_APP_EMP
    {
        public static DataTable TSTD_APP_EMP_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT   PLT_CODE            ");
                    sbQuery.Append("       , APP_TYPE             ");
                    sbQuery.Append("       , APP_EMP1             ");
                    sbQuery.Append("       , APP_EMP2             ");
                    sbQuery.Append("       , APP_EMP3             ");
                    sbQuery.Append("       , APP_EMP4             ");
                    sbQuery.Append("       , REG_DATE            ");
                    sbQuery.Append("       , REG_EMP             ");
                    sbQuery.Append("       , MDFY_DATE            ");
                    sbQuery.Append("       , MDFY_EMP             ");
                    sbQuery.Append("       , ORG_CODE             ");
                    sbQuery.Append("       , APP_SEQ             ");
                    sbQuery.Append("  FROM TSTD_APP_EMP              ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE   ");
                    sbQuery.Append("   AND APP_TYPE = @APP_TYPE     ");
                    

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "APP_TYPE")) isHasColumn = false;

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


        public static DataTable TSTD_APP_EMP_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT   PLT_CODE            ");
                    sbQuery.Append("       , APP_TYPE             ");
                    sbQuery.Append("       , APP_EMP1             ");
                    sbQuery.Append("       , APP_EMP2             ");
                    sbQuery.Append("       , APP_EMP3             ");
                    sbQuery.Append("       , APP_EMP4             ");
                    sbQuery.Append("       , REG_DATE            ");
                    sbQuery.Append("       , REG_EMP             ");
                    sbQuery.Append("       , MDFY_DATE            ");
                    sbQuery.Append("       , MDFY_EMP             ");
                    sbQuery.Append("       , ORG_CODE             ");
                    sbQuery.Append("       , APP_SEQ             ");
                    sbQuery.Append("  FROM TSTD_APP_EMP              ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE   ");
                    sbQuery.Append(" ORDER BY APP_TYPE, APP_SEQ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;

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

        public static DataTable TSTD_APP_EMP_SER3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT   PLT_CODE            ");
                    sbQuery.Append("       , APP_TYPE             ");
                    sbQuery.Append("       , APP_EMP1             ");
                    sbQuery.Append("       , APP_EMP2             ");
                    sbQuery.Append("       , APP_EMP3             ");
                    sbQuery.Append("       , APP_EMP4             ");
                    sbQuery.Append("       , REG_DATE            ");
                    sbQuery.Append("       , REG_EMP             ");
                    sbQuery.Append("       , MDFY_DATE            ");
                    sbQuery.Append("       , MDFY_EMP             ");
                    sbQuery.Append("       , ORG_CODE             ");
                    sbQuery.Append("  FROM TSTD_APP_EMP              ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE   ");
                    sbQuery.Append("   AND APP_TYPE = @APP_TYPE     ");
                    sbQuery.Append("   AND ORG_CODE = @ORG_CODE     ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "APP_TYPE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "ORG_CODE")) isHasColumn = false;

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

        public static DataTable TSTD_APP_EMP_SER4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT   PLT_CODE            ");
                    sbQuery.Append("       , APP_TYPE             ");
                    sbQuery.Append("       , APP_EMP1             ");
                    sbQuery.Append("       , APP_EMP2             ");
                    sbQuery.Append("       , APP_EMP3             ");
                    sbQuery.Append("       , APP_EMP4             ");
                    sbQuery.Append("       , REG_DATE            ");
                    sbQuery.Append("       , REG_EMP             ");
                    sbQuery.Append("       , MDFY_DATE            ");
                    sbQuery.Append("       , MDFY_EMP             ");
                    sbQuery.Append("       , ORG_CODE             ");
                    sbQuery.Append("  FROM TSTD_APP_EMP              ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE   ");
                    sbQuery.Append("   AND APP_TYPE = @APP_TYPE     ");
                    sbQuery.Append("   AND APP_SEQ = @APP_SEQ     ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "APP_TYPE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "APP_SEQ")) isHasColumn = false;

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


        public static void TSTD_APP_EMP_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSTD_APP_EMP");
                    sbQuery.Append(" SET APP_EMP1 = @APP_EMP1           ");
                    sbQuery.Append("   , APP_EMP2 = @APP_EMP2           ");
                    sbQuery.Append("   , APP_EMP3 = @APP_EMP3           ");
                    sbQuery.Append("   , APP_EMP4 = @APP_EMP4           ");
                    sbQuery.Append("   , ORG_CODE = @ORG_CODE           ");
                    sbQuery.Append("   , APP_SEQ = @APP_SEQ           ");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append("   AND APP_TYPE = @APP_TYPE     ");
                    

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "APP_TYPE")) isHasColumn = false;

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

        public static void TSTD_APP_EMP_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSTD_APP_EMP");
                    sbQuery.Append(" SET APP_EMP1 = @APP_EMP1           ");
                    sbQuery.Append("   , APP_EMP2 = @APP_EMP2           ");
                    sbQuery.Append("   , APP_EMP3 = @APP_EMP3           ");
                    sbQuery.Append("   , APP_EMP4 = @APP_EMP4           ");
                    sbQuery.Append("   , ORG_CODE = @ORG_CODE           ");
                    sbQuery.Append("   , APP_SEQ = @APP_SEQ           ");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append("   AND APP_TYPE = @APP_TYPE     ");
                    sbQuery.Append("   AND APP_SEQ = @APP_SEQ     ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "APP_TYPE")) isHasColumn = false;

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


        public static void TSTD_APP_EMP_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO TSTD_APP_EMP");
                    sbQuery.Append(" (");
                    sbQuery.Append(" PLT_CODE            ");
                    sbQuery.Append(" , APP_TYPE             ");
                    sbQuery.Append(" , ORG_CODE             ");
                    sbQuery.Append(" , APP_EMP1             ");
                    sbQuery.Append(" , APP_EMP2             ");
                    sbQuery.Append(" , APP_EMP3            ");
                    sbQuery.Append(" , APP_EMP4            ");
                    sbQuery.Append(" , APP_SEQ            ");
                    sbQuery.Append(" , REG_DATE            ");
                    sbQuery.Append(" , REG_EMP             ");
                    sbQuery.Append(" )");
                    sbQuery.Append(" VALUES ");
                    sbQuery.Append(" (");
                    sbQuery.Append(" @PLT_CODE            ");
                    sbQuery.Append(" , @APP_TYPE             ");
                    sbQuery.Append(" , @ORG_CODE             ");
                    sbQuery.Append(" , @APP_EMP1             ");
                    sbQuery.Append(" , @APP_EMP2             ");
                    sbQuery.Append(" , @APP_EMP3            ");
                    sbQuery.Append(" , @APP_EMP4            ");
                    sbQuery.Append(" , @APP_SEQ            ");
                    sbQuery.Append(" , GETDATE() ");
                    sbQuery.Append(" ," + UTIL.GetValidValue(ConnInfo.UserID));

                    sbQuery.Append(" )");

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

    public class TSTD_APP_EMP_QUERY
    {
        public static DataTable TSTD_APP_EMP_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT AE.PLT_CODE");
                    sbQuery.Append(", AE.APP_TYPE ");
                    sbQuery.Append(", AE.APP_EMP1 ");
                    sbQuery.Append(", E1.EMP_NAME AS APP_EMP_NAME1 ");
                    sbQuery.Append(", AE.APP_EMP2 ");
                    sbQuery.Append(", E2.EMP_NAME AS APP_EMP_NAME2 ");
                    sbQuery.Append(", AE.APP_EMP3 ");
                    sbQuery.Append(", E3.EMP_NAME AS APP_EMP_NAME3 ");
                    sbQuery.Append(", AE.APP_EMP4 ");
                    sbQuery.Append(", E4.EMP_NAME AS APP_EMP_NAME4 ");
                    sbQuery.Append(", AE.REG_DATE");
                    sbQuery.Append(", AE.REG_EMP ");
                    sbQuery.Append(", AE.MDFY_DATE");
                    sbQuery.Append(", AE.MDFY_EMP ");
                    sbQuery.Append(", AE.ORG_CODE ");
                    sbQuery.Append(", O.ORG_NAME ");
                    sbQuery.Append(", AE.APP_SEQ ");
                    sbQuery.Append("  FROM TSTD_APP_EMP AE");
                    sbQuery.Append("  LEFT JOIN TSTD_EMPLOYEE E1");
                    sbQuery.Append("  ON AE.PLT_CODE = E1.PLT_CODE");
                    sbQuery.Append("  AND AE.APP_EMP1 = E1.EMP_CODE");

                    sbQuery.Append("  LEFT JOIN TSTD_EMPLOYEE E2");
                    sbQuery.Append("  ON AE.PLT_CODE = E2.PLT_CODE");
                    sbQuery.Append("  AND AE.APP_EMP2 = E2.EMP_CODE");

                    sbQuery.Append("  LEFT JOIN TSTD_EMPLOYEE E3");
                    sbQuery.Append("  ON AE.PLT_CODE = E3.PLT_CODE");
                    sbQuery.Append("  AND AE.APP_EMP3 = E3.EMP_CODE");

                    sbQuery.Append("  LEFT JOIN TSTD_EMPLOYEE E4");
                    sbQuery.Append("  ON AE.PLT_CODE = E4.PLT_CODE");
                    sbQuery.Append("  AND AE.APP_EMP4 = E4.EMP_CODE");

                    sbQuery.Append("  LEFT JOIN TSTD_ORG O");
                    sbQuery.Append("  ON AE.PLT_CODE = O.PLT_CODE");
                    sbQuery.Append("  AND AE.ORG_CODE = O.ORG_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE AE.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@APP_TYPE", "AE.APP_TYPE = @APP_TYPE"));
                        sbWhere.Append(" AND AE.ORG_CODE IS NOT NULL");
                        //sbWhere.Append(UTIL.GetWhere(row, "@WORK_LIKE", "(WORK_CODE LIKE '%' + @WORK_LIKE + '%' OR WORK_NAME '%' + @WORK_LIKE + '%')"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "AE.DATA_FLAG = @DATA_FLAG"));


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
