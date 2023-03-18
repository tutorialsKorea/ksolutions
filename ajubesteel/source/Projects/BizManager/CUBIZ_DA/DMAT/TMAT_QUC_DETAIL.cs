using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DMAT
{
    public class TMAT_QUC_DETAIL
    {

        public static DataTable TMAT_QUC_DETAIL_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT   PLT_CODE ");
                    sbQuery.Append("       , QCD_ID ");
                    sbQuery.Append("       , MQLTY_CODE ");
                    sbQuery.Append("       , MQLTY_START ");
                    sbQuery.Append("       , MQLTY_END ");
                    sbQuery.Append("       , MQLTY_UC ");
                    sbQuery.Append("       , REG_DATE ");
                    sbQuery.Append("       , REG_EMP ");
                    sbQuery.Append("       , MDFY_DATE ");
                    sbQuery.Append("       , MDFY_EMP ");
                    sbQuery.Append("       , DEL_DATE ");
                    sbQuery.Append("       , DEL_EMP ");
                    sbQuery.Append("       , DATA_FLAG ");
                    sbQuery.Append("  FROM TMAT_QUC_DETAIL ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND QCD_ID = @QCD_ID ");

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

        public static void TMAT_QUC_DETAIL_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                StringBuilder sbQuery = new StringBuilder();
                if (dtParam.Rows.Count > 0)
                {
                    

                    sbQuery.Append(" INSERT INTO TMAT_QUC_DETAIL ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append("        PLT_CODE ");
                    sbQuery.Append("      , QCD_ID ");
                    sbQuery.Append("      , MQLTY_CODE ");
                    sbQuery.Append("      , MQLTY_START ");
                    sbQuery.Append("      , MQLTY_END ");
                    sbQuery.Append("      , MQLTY_UC ");
                    sbQuery.Append("      , REG_DATE ");
                    sbQuery.Append("      , REG_EMP ");
                    sbQuery.Append("      , DATA_FLAG ");
                    sbQuery.Append(" ) ");
                    sbQuery.Append(" VALUES ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append("        @PLT_CODE ");
                    sbQuery.Append("      , @QCD_ID ");
                    sbQuery.Append("      , @MQLTY_CODE ");
                    sbQuery.Append("      , @MQLTY_START ");
                    sbQuery.Append("      , @MQLTY_END ");
                    sbQuery.Append("      , @MQLTY_UC ");
                    sbQuery.Append("      , GETDATE() ");
                    sbQuery.Append("      , @REG_EMP ");
                    sbQuery.Append("      , @DATA_FLAG ");
                    sbQuery.Append(" ) ");
                }

                foreach (DataRow row in dtParam.Rows)
                {

                    bizExecute.executeInsertQuery(sbQuery.ToString(), row);
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static void TMAT_QUC_DETAIL_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                StringBuilder sbQuery = new StringBuilder();

                if (dtParam.Rows.Count > 0)
                {
                 

                    sbQuery.Append(" UPDATE TMAT_QUC_DETAIL ");
                    sbQuery.Append("   SET   MQLTY_CODE = @MQLTY_CODE ");
                    sbQuery.Append("       , MQLTY_START = @MQLTY_START ");
                    sbQuery.Append("       , MQLTY_END = @MQLTY_END ");
                    sbQuery.Append("       , MQLTY_UC = @MQLTY_UC ");
                    sbQuery.Append("       , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("       , MDFY_EMP = @MDFY_EMP ");
                    sbQuery.Append("       , DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND QCD_ID = @QCD_ID ");
                }

                foreach (DataRow row in dtParam.Rows)
                {

                    bizExecute.executeUpdateQuery(sbQuery.ToString(), row);
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 선택한 재질 단가 적용
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TMAT_QUC_DETAIL_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                StringBuilder sbQuery = new StringBuilder();

                if (dtParam.Rows.Count > 0)
                {


                    sbQuery.Append(" UPDATE TMAT_QUC_DETAIL ");
                    sbQuery.Append("   SET  APPLIED = @APPLIED ");
                    sbQuery.Append("       , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("       , MDFY_EMP = @MDFY_EMP ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND QCD_ID = @QCD_ID ");
                }

                foreach (DataRow row in dtParam.Rows)
                {

                    bizExecute.executeUpdateQuery(sbQuery.ToString(), row);
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 선택한 재질 단가 미적용
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TMAT_QUC_DETAIL_UPD3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                StringBuilder sbQuery = new StringBuilder();

                if (dtParam.Rows.Count > 0)
                {


                    sbQuery.Append(" UPDATE TMAT_QUC_DETAIL ");
                    sbQuery.Append("   SET  APPLIED = 'N' ");
                    sbQuery.Append("       , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("       , MDFY_EMP = @MDFY_EMP ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND QCD_ID <> @QCD_ID ");
                    sbQuery.Append("   AND MQLTY_CODE = @MQLTY_CODE ");
                }

                foreach (DataRow row in dtParam.Rows)
                {

                    bizExecute.executeUpdateQuery(sbQuery.ToString(), row);
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static void TMAT_QUC_DETAIL_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                StringBuilder sbQuery = new StringBuilder();

                if (dtParam.Rows.Count > 0)
                {
                
                    sbQuery.Append(" UPDATE TMAT_QUC_DETAIL ");
                    sbQuery.Append("   SET   DEL_DATE = GETDATE() ");
                    sbQuery.Append("       , DEL_EMP = @DEL_EMP ");
                    sbQuery.Append("       , DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND QCD_ID = @QCD_ID ");
                }

                foreach (DataRow row in dtParam.Rows)
                {

                    bizExecute.executeUpdateQuery(sbQuery.ToString(), row);
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static void TMAT_QUC_DETAIL_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                StringBuilder sbQuery = new StringBuilder();

                if (dtParam.Rows.Count > 0)
                {

                    sbQuery.Append(" DELETE TMAT_QUC_DETAIL ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");

                }

                foreach (DataRow row in dtParam.Rows)
                {

                    bizExecute.executeUpdateQuery(sbQuery.ToString(), row);
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
    }

    public class TMAT_QUC_DETAIL_QUERY
    {
        /// <summary>
        /// 적용기간 중첩 확인
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TMAT_QUC_DETAIL_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append("      ,QCD_ID ");
                    sbQuery.Append("      ,MQLTY_CODE ");
                    sbQuery.Append("      ,MQLTY_START ");
                    sbQuery.Append("      ,MQLTY_END ");
                    sbQuery.Append("      ,MQLTY_UC ");
                    sbQuery.Append("      ,REG_DATE ");
                    sbQuery.Append("      ,REG_EMP ");
                    sbQuery.Append("      ,MDFY_DATE ");
                    sbQuery.Append("      ,MDFY_EMP ");
                    sbQuery.Append("      ,DEL_DATE ");
                    sbQuery.Append("      ,DEL_EMP ");
                    sbQuery.Append("      ,DATA_FLAG ");
                    sbQuery.Append("  FROM TMAT_QUC_DETAIL ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@QCD_ID", "QCD_ID <> @QCD_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MQLTY_DATE", "@MQLTY_DATE BETWEEN MQLTY_START AND MQLTY_END"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MQLTY_CODE", "MQLTY_CODE = @MQLTY_CODE"));
                        

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
        /// <summary>
        /// 재질코드의 단가 이력 조회
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TMAT_QUC_DETAIL_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT D.PLT_CODE ");
                    sbQuery.Append("       ,D.QCD_ID ");
                    sbQuery.Append("       ,D.MQLTY_CODE ");
                    sbQuery.Append("       ,D.MQLTY_START ");
                    sbQuery.Append("       ,D.MQLTY_END ");
                    sbQuery.Append("       ,D.MQLTY_UC ");
                    sbQuery.Append("       ,ISNULL(D.APPLIED, 'N') AS APPLIED ");
                    sbQuery.Append("       ,D.REG_DATE ");
                    sbQuery.Append("       ,D.REG_EMP ");
                    sbQuery.Append("       ,REG.EMP_NAME AS REG_EMP_NAME ");
                    sbQuery.Append("       ,D.MDFY_DATE ");
                    sbQuery.Append("       ,D.MDFY_EMP ");
                    sbQuery.Append("       ,MDFY.EMP_NAME AS MDFY_EMP_NAME ");
                    sbQuery.Append("       ,D.DATA_FLAG ");
                    sbQuery.Append("   FROM TMAT_QUC_DETAIL D ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG ");
                    sbQuery.Append(" ON D.PLT_CODE = REG.PLT_CODE ");
                    sbQuery.Append(" AND D.REG_EMP = REG.EMP_CODE ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY ");
                    sbQuery.Append(" ON D.PLT_CODE = MDFY.PLT_CODE ");
                    sbQuery.Append(" AND D.MDFY_EMP = MDFY.EMP_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE D.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@QCD_ID", "D.QCD_ID = @QCD_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MQLTY_CODE", "D.MQLTY_CODE = @MQLTY_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "D.DATA_FLAG = @DATA_FLAG"));

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
