using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSHP
{
    public class TSHP_ASSPLAN
    {
        public static DataTable TSHP_ASSPLAN_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" ,PROD_CODE");
                    sbQuery.Append(" ,PART_CODE");                    
                    sbQuery.Append(" FROM TSHP_ASSPLAN");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PROD_CODE = @PROD_CODE ");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE ");
                    sbQuery.Append(" AND REG_EMP = @REG_EMP ");

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


        public static void TSHP_ASSPLAN_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TSHP_ASSPLAN");
                    sbQuery.Append(" (");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" , PROD_CODE");
                    sbQuery.Append(" , PART_CODE");
                    sbQuery.Append(" , REG_DATE");
                    sbQuery.Append(" , REG_EMP");
                    sbQuery.Append(" )");
                    sbQuery.Append(" VALUES");
                    sbQuery.Append(" (");
                    sbQuery.Append(" @PLT_CODE");
                    sbQuery.Append(" , @PROD_CODE ");
                    sbQuery.Append(" , @PART_CODE");
                    sbQuery.Append(" , GETDATE() ");
                    sbQuery.Append(" , @REG_EMP ");
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


        public static void TSHP_ASSPLAN_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" DELETE FROM TSHP_ASSPLAN");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PROD_CODE = @PROD_CODE");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE");
                    sbQuery.Append(" AND REG_EMP = @REG_EMP");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bizExecute.executeUpdateQuery(sbQuery.ToString(), row);
                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }


    }

    public class TSHP_ASSPLAN_QUERY
    {
        public static DataTable TSHP_ASSPLAN_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT MAX(TB.PROC_CNT) AS PROC_MAX FROM  ");
                    sbQuery.Append(" (SELECT  ");
                    sbQuery.Append(" TA.PLT_CODE, ");
                    sbQuery.Append(" TA.PROD_CODE, ");
                    sbQuery.Append(" TA.PART_CODE, ");
                    sbQuery.Append(" COUNT(TW.PROC_ID) AS PROC_CNT ");
                    sbQuery.Append(" FROM TSHP_ASSPLAN TA ");
                    sbQuery.Append(" JOIN TSHP_WORKORDER TW ");
                    sbQuery.Append(" ON TA.PLT_CODE = TW.PLT_CODE ");
                    sbQuery.Append(" AND TA.PROD_CODE = TW.PROD_CODE ");
                    sbQuery.Append(" AND TA.PART_CODE = TW.PART_CODE ");
                    sbQuery.Append(" AND TA.REG_EMP = TW.EMP_CODE ");
                    sbQuery.Append("  ");
                    sbQuery.Append(" WHERE TW.PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND TW.PROC_CODE IN (SELECT PROC_CODE FROM LSE_STD_PROC WHERE PLT_CODE = @PLT_CODE AND MPROC_CODE = 'C001') ");
                    sbQuery.Append(" AND TW.EMP_CODE = @EMP_CODE ");
                    sbQuery.Append(" AND TW.DATA_FLAG = 0 ");
                    sbQuery.Append(" GROUP BY TA.PLT_CODE, ");
                    sbQuery.Append(" TA.PROD_CODE, ");
                    sbQuery.Append(" TA.PART_CODE) TB ");



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

        public static DataTable TSHP_ASSPLAN_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT  ");
                    sbQuery.Append(" ROW_NUMBER() over (partition by TW.PROD_CODE ORDER BY TW.PROD_CODE) AS SEQ, ");
                    sbQuery.Append(" TW.WO_NO, ");
                    sbQuery.Append(" TW.PROD_CODE, ");
                    sbQuery.Append(" TW.PART_CODE, ");
                    sbQuery.Append(" TW.PROC_ID, ");
                    sbQuery.Append(" TW.PROC_CODE, ");
                    //sbQuery.Append(" LSP.PROC_NAME, ");
                    sbQuery.Append(" TW.WO_FLAG, ");
                    sbQuery.Append(" TC.CD_NAME, ");
                    sbQuery.Append(" LSP.PROC_NAME + ' (' + TC.CD_NAME + ')' AS PROC_NAME  ");
                    sbQuery.Append(" FROM TSHP_ASSPLAN TA ");
                    sbQuery.Append(" JOIN TSHP_WORKORDER TW ");
                    sbQuery.Append(" ON TA.PLT_CODE = TW.PLT_CODE ");
                    sbQuery.Append(" AND TA.PROD_CODE = TW.PROD_CODE ");
                    sbQuery.Append(" AND TA.PART_CODE = TW.PART_CODE ");
                    sbQuery.Append(" AND TA.REG_EMP = TW.EMP_CODE ");
                    sbQuery.Append(" JOIN LSE_STD_PROC LSP ");
                    sbQuery.Append(" ON TW.PLT_CODE = LSP.PLT_CODE ");
                    sbQuery.Append(" AND TW.PROC_CODE = LSP.PROC_CODE ");
                    sbQuery.Append(" JOIN TSTD_CODES TC ");
                    sbQuery.Append(" ON TW.PLT_CODE = TC.PLT_CODE ");
                    sbQuery.Append(" AND TW.WO_FLAG = TC.CD_CODE ");
                    sbQuery.Append(" AND TC.CAT_CODE = 'S032' ");                    
                    sbQuery.Append(" WHERE TW.PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND TW.PROC_CODE IN (SELECT PROC_CODE FROM LSE_STD_PROC WHERE PLT_CODE = @PLT_CODE AND MPROC_CODE = 'C001') ");
                    sbQuery.Append(" AND TW.EMP_CODE = @EMP_CODE ");
                    sbQuery.Append(" AND TW.DATA_FLAG = 0 ");

                    sbQuery.Append(" ORDER BY TA.PROD_CODE, TA.PART_CODE, TW.PROC_ID ASC ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();
                       

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

        public static DataTable TSHP_ASSPLAN_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" exec PC_TSHP_ASSPLAN @PLT_CODE, @EMP_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        DataTable sourceTable = new DataTable();
                        try
                        {
                            sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString(), row).Copy();
                        }
                        catch { }

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

        public static DataTable TSHP_ASSPLAN_QUERY4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT ");
                    sbQuery.Append(" TW.PROD_CODE, ");
                    sbQuery.Append(" TW.PART_CODE, ");
                    sbQuery.Append(" TW.WO_NO, ");
                    sbQuery.Append(" LPT.PART_PRODTYPE, ");
                    sbQuery.Append(" LPT.PART_NAME, ");
                    sbQuery.Append(" LPT.DRAW_NO, ");
                    sbQuery.Append(" TW.EMP_CODE, ");
                    sbQuery.Append(" TW.PROC_CODE,");
                    sbQuery.Append(" LPR.PROC_NAME");
                    sbQuery.Append(" FROM TSHP_WORKORDER TW ");
                    sbQuery.Append(" JOIN LSE_STD_PART LPT ");
                    sbQuery.Append(" ON TW.PLT_CODE = LPT.PLT_CODE ");
                    sbQuery.Append(" AND TW.PART_CODE = LPT.PART_CODE ");
                    sbQuery.Append(" JOIN LSE_STD_PROC LPR ");
                    sbQuery.Append(" ON TW.PLT_CODE = LPR.PLT_CODE ");
                    sbQuery.Append(" AND TW.PROC_CODE = LPR.PROC_CODE ");
                    sbQuery.Append(" WHERE TW.PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND TW.PROC_CODE IN (SELECT PROC_CODE FROM LSE_STD_PROC WHERE PLT_CODE = @PLT_CODE AND MPROC_CODE = 'C001') ");
                    //sbQuery.Append(" AND TW.EMP_CODE = @EMP_CODE ");
                    sbQuery.Append(" AND TW.DATA_FLAG = 0  ");
                    sbQuery.Append(" AND TW.PROD_CODE = @PROD_CODE ");
                    sbQuery.Append(" AND TW.PART_CODE = @PART_CODE ");
                    sbQuery.Append(" AND TW.WO_FLAG = '2' ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();


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

        public static DataTable TSHP_ASSPLAN_QUERY5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT ");
                    sbQuery.Append("  TW.PLN_PROC_TIME, ");
                    sbQuery.Append("  TW.CAUTION ");
                    sbQuery.Append(" FROM TSHP_WORKORDER TW ");
                    sbQuery.Append(" WHERE TW.PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND TW.WO_NO = @WO_NO ");
                    sbQuery.Append(" AND TW.WO_FLAG = '2' ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();


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
    }
}
