using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSTD
{
    public class TSTD_MC_AVAILEMP
    {

        public static DataTable TSTD_MC_AVAILEMP_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" , MC_CODE ");
                    sbQuery.Append(" , EMP_CODE");
                    sbQuery.Append(" , EMP_SEQ ");
                    sbQuery.Append(" FROM TSTD_MC_AVAILEMP ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND MC_CODE = @MC_CODE");
                    sbQuery.Append(" AND EMP_CODE = @EMP_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {                        
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "MC_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "EMP_CODE")) isHasColumn = false;                        

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
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataTable TSTD_MC_AVAILEMP_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT TOP 1 PLT_CODE ");
                    sbQuery.Append(" , MC_CODE ");
                    sbQuery.Append(" , EMP_CODE");
                    sbQuery.Append(" , EMP_SEQ ");
                    sbQuery.Append(" FROM TSTD_MC_AVAILEMP ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND MC_CODE = @MC_CODE");
                    sbQuery.Append(" ORDER BY EMP_SEQ");

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

        public static void TSTD_MC_AVAILEMP_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO TSTD_MC_AVAILEMP");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" , MC_CODE ");
                    sbQuery.Append(" , EMP_CODE");
                    sbQuery.Append(" , EMP_SEQ ");
                    sbQuery.Append(" ) ");
                    sbQuery.Append(" VALUES");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" @PLT_CODE ");
                    sbQuery.Append(" , @MC_CODE");
                    sbQuery.Append(" , @EMP_CODE ");
                    sbQuery.Append(" , @EMP_SEQ");
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


        public static void TSTD_MC_AVAILEMP_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" DELETE FROM TSTD_MC_AVAILEMP");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND MC_CODE = @MC_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "MC_CODE")) isHasColumn = false;                        
                        if (isHasColumn == true)
                        {

                            bizExecute.executeInsertQuery(sbQuery.ToString(), row);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static void TSTD_MC_AVAILEMP_DEL2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" DELETE FROM TSTD_MC_AVAILEMP");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND EMP_CODE = @EMP_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "EMP_CODE")) isHasColumn = false;
                        if (isHasColumn == true)
                        {

                            bizExecute.executeInsertQuery(sbQuery.ToString(), row);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static void TSTD_MC_AVAILEMP_DEL3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" DELETE FROM TSTD_MC_AVAILEMP");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");                    

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        //if (!UTIL.ValidColumn(row, "MC_CODE")) isHasColumn = false;
                        if (isHasColumn == true)
                        {
                            bizExecute.executeInsertQuery(sbQuery.ToString(), row);
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

    public class TSTD_MC_AVAILEMP_QUERY
    {
        //가용설비 조회
        public static DataTable TSTD_MC_AVAILEMP_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT M.PLT_CODE");
                    sbQuery.Append(" ,M.MC_CODE");
                    sbQuery.Append(" ,MC.MC_NAME");
                    sbQuery.Append(" ,E.ORG_CODE");
                    sbQuery.Append(" ,O.ORG_NAME");
                    sbQuery.Append(" ,M.EMP_CODE ");
                    sbQuery.Append(" ,E.EMP_NAME ");
                    sbQuery.Append(" ,M.EMP_SEQ");
                    sbQuery.Append(" FROM TSTD_MC_AVAILEMP M");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E ON M.PLT_CODE = E.PLT_CODE ");
                    sbQuery.Append(" AND M.EMP_CODE = E.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_ORG O ON E.PLT_CODE = O.PLT_CODE ");
                    sbQuery.Append(" AND E.ORG_CODE = O.ORG_CODE ");
                    sbQuery.Append(" LEFT JOIN LSE_MACHINE MC");
                    sbQuery.Append(" ON M.PLT_CODE = MC.PLT_CODE");
                    sbQuery.Append(" AND M.MC_CODE = MC.MC_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        StringBuilder sbWhere = new StringBuilder(" WHERE M.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@MC_CODE", "M.MC_CODE = @MC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "M.EMP_CODE = @EMP_CODE"));

                        sbWhere.Append(" ORDER BY M.EMP_SEQ");

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

        //가용설비 조회
        public static DataTable TSTD_MC_AVAILEMP_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT AE.PLT_CODE ");
                    sbQuery.Append(" ,AE.MC_CODE ");
                    sbQuery.Append(" ,AE.EMP_CODE ");
                    sbQuery.Append(" ,AE.MC_CODE+':'+AE.EMP_CODE AS MC_EMP_CODE  ");
                    sbQuery.Append(" ,EMP.EMP_NAME ");
                    sbQuery.Append(" FROM TSTD_MC_AVAILEMP AE ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE EMP ");
                    sbQuery.Append(" ON AE.PLT_CODE = EMP.PLT_CODE ");
                    sbQuery.Append(" AND AE.EMP_CODE = EMP.EMP_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        StringBuilder sbWhere = new StringBuilder(" WHERE AE.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@MC_CODE", "AE.MC_CODE = @MC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "AE.EMP_CODE = @EMP_CODE"));

                        sbWhere.Append(" ORDER BY EMP.EMP_SEQ");

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

        
        /// 가용설비 조회 (지정한 담당 작업자에 대한 설비 최우선 정렬)
        public static DataTable TSTD_MC_AVAILEMP_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT M.PLT_CODE");
                    sbQuery.Append(" ,M.MC_CODE");
                    sbQuery.Append(" ,MC.MC_NAME");
                    sbQuery.Append(" ,E.ORG_CODE");
                    sbQuery.Append(" ,O.ORG_NAME");
                    sbQuery.Append(" ,M.EMP_CODE ");
                    sbQuery.Append(" ,E.EMP_NAME ");
                    sbQuery.Append(" ,M.EMP_SEQ");
                    sbQuery.Append(" FROM TSTD_MC_AVAILEMP M");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E ON M.PLT_CODE = E.PLT_CODE ");
                    sbQuery.Append(" AND M.EMP_CODE = E.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_ORG O ON E.PLT_CODE = O.PLT_CODE ");
                    sbQuery.Append(" AND E.ORG_CODE = O.ORG_CODE ");
                    sbQuery.Append(" LEFT JOIN LSE_MACHINE MC");
                    sbQuery.Append(" ON M.PLT_CODE = MC.PLT_CODE");
                    sbQuery.Append(" AND M.MC_CODE = MC.MC_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        StringBuilder sbWhere = new StringBuilder(" WHERE M.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(" ORDER BY CASE WHEN M.EMP_CODE = " + UTIL.GetValidValue(row,"EMP_CODE") +  "THEN 1 END DESC");

                       // sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "ORDER BY CASE WHEN M.EMP_CODE = @EMP_CODE THEN 1 END DESC"));

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
