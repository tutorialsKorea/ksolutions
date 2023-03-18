using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSYS
{
    public class TSYS_DB_FILELIST
    {

        public static DataTable TSYS_DB_FILELIST_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("SELECT   PLT_CODE ");
                    //sbQuery.Append(" , FILE_ID     ");
                    sbQuery.Append(" , FILE_NAME     ");
                    sbQuery.Append(" , LINK_KEY     ");
                    sbQuery.Append(" , FILE_CONTENT      ");
                    sbQuery.Append(" , REG_DATE ");
                    sbQuery.Append(" , REG_EMP ");
                    sbQuery.Append(" , DATA_FLAG      ");
                    sbQuery.Append(" FROM TSYS_DB_FILELIST ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND LINK_KEY = @LINK_KEY ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "LINK_KEY")) isHasColumn = false;

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

        public static void TSYS_DB_FILELIST_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TSYS_DB_FILELIST ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append("    PLT_CODE ");
                    //sbQuery.Append("    , FILE_ID     ");
                    sbQuery.Append("    , FILE_NAME     ");
                    sbQuery.Append("    , LINK_KEY     ");
                    sbQuery.Append("    , FILE_CONTENT      ");
                    sbQuery.Append("    , REG_DATE ");
                    sbQuery.Append("    , REG_EMP ");
                    sbQuery.Append("    , DATA_FLAG      ");
                    sbQuery.Append(" ) ");
                    sbQuery.Append(" VALUES ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append("    @PLT_CODE ");
                    //sbQuery.Append("    , @FILE_ID     ");
                    sbQuery.Append("    , @FILE_NAME     ");
                    sbQuery.Append("    , @LINK_KEY     ");
                    sbQuery.Append("    , @FILE_CONTENT      ");
                    sbQuery.Append("    , @REG_DATE ");
                    sbQuery.Append("    , @REG_EMP ");
                    sbQuery.Append("    , 0      ");
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

        public static void TSYS_DB_FILELIST_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSYS_DB_FILELIST ");
                    sbQuery.Append(" SET FILE_CONTENT = @FILE_CONTENT ");
                    sbQuery.Append(" , FILE_NAME = @FILE_NAME ");
                    sbQuery.Append(" , MDFY_DATE = @MDFY_DATE ");
                    sbQuery.Append(" , MDFY_EMP = @MDFY_EMP");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND LINK_KEY = @LINK_KEY  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "LINK_KEY")) isHasColumn = false;

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

        public static void TSYS_DB_FILELIST_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSYS_DB_FILELIST ");
                    sbQuery.Append(" SET DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append(" , DEL_DATE = @DEL_DATE ");
                    sbQuery.Append(" , DEL_EMP = @DEL_EMP");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND LINK_KEY = @LINK_KEY  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "LINK_KEY")) isHasColumn = false;

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

    public class TSYS_DB_FILELIST_QUERY
    {
        //가용설비 조회
        public static DataTable TSYS_DB_FILELIST_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    
                    sbQuery.Append(" SELECT LSPA.PLT_CODE");
                    sbQuery.Append(" , LSPA.PART_CODE     ");
                    sbQuery.Append(" , LSPA.PROC_CODE     ");
                    sbQuery.Append(" , LSPA.PROC_CONTENTS     ");
                    sbQuery.Append(" , LSPA.PROC_REMARK      ");
                    sbQuery.Append(" , LSPA.INS_METHOD ");
                    sbQuery.Append(" , LSPA.ASSY_TIME ");
                    sbQuery.Append(" , CASE LSPP.PART_CODE WHEN NULL THEN '0' ELSE '1' END AS SEL");
                    sbQuery.Append(" , LSPA.REG_DATE      ");
                    sbQuery.Append(" , LSPA.REG_EMP       ");
                    sbQuery.Append(" , LSPA.MDFY_DATE     ");
                    sbQuery.Append(" , LSPA.MDFY_EMP      ");
                    sbQuery.Append(" FROM LSE_STD_PARTPROC LSPP");
                    sbQuery.Append("    LEFT JOIN TSYS_DB_FILELIST LSPA");
                    sbQuery.Append("        ON LSPA.PLT_CODE = LSPP.PLT_CODE");
                    sbQuery.Append("        AND LSPA.PART_CODE = LSPP.PART_CODE");
                    sbQuery.Append("        AND LSPA.PROC_CODE = LSPP.PROC_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        StringBuilder sbWhere = new StringBuilder(" WHERE LSPA.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "LSPP.PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROC_CODE", "LSPP.PROC_CODE = @PROC_CODE"));

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
