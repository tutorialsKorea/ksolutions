using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizExecute;
using System.Data;

namespace DSTD
{
    public class TSTD_PROCPLAN_MASTER
    {
        public static DataTable TSTD_PROCPLAN_MASTER_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" , PLN_CODE");
                    sbQuery.Append(" , PART_CODE ");
                    sbQuery.Append(" , MQLTY_CODE");
                    sbQuery.Append(" , PART_SPEC1");
                    sbQuery.Append(" , REG_DATE");
                    sbQuery.Append(" , REG_EMP ");
                    sbQuery.Append(" , MDFY_DATE ");
                    sbQuery.Append(" , MDFY_EMP");
                    sbQuery.Append(" , DEL_DATE");
                    sbQuery.Append(" , DEL_EMP ");
                    sbQuery.Append(" , DEL_REASON");
                    sbQuery.Append(" , DATA_FLAG ");
                    sbQuery.Append(" FROM TSTD_PROCPLAN_MASTER ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PLN_CODE = @PLN_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {                                                         
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLN_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                                                        
                            DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString(),row ).Copy();

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

        public static DataTable TSTD_PROCPLAN_MASTER_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" , PLN_CODE");
                    sbQuery.Append(" , PART_CODE ");
                    sbQuery.Append(" , MQLTY_CODE");
                    sbQuery.Append(" , PART_SPEC1");
                    sbQuery.Append(" , REG_DATE");
                    sbQuery.Append(" , REG_EMP ");
                    sbQuery.Append(" , MDFY_DATE ");
                    sbQuery.Append(" , MDFY_EMP");
                    sbQuery.Append(" , DEL_DATE");
                    sbQuery.Append(" , DEL_EMP ");
                    sbQuery.Append(" , DEL_REASON");
                    sbQuery.Append(" , DATA_FLAG ");
                    sbQuery.Append(" FROM TSTD_PROCPLAN_MASTER ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PART_CODE  = @PART_CODE ");
                    sbQuery.Append(" AND PART_SPEC1  = @PART_SPEC1 ");
                    sbQuery.Append(" AND MQLTY_CODE  = @MQLTY_CODE ");
                    sbQuery.Append(" AND DATA_FLAG = 0");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLN_CODE")) isHasColumn = false;

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

        public static void TSTD_PROCPLAN_MASTER_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSTD_PROCPLAN_MASTER ");
                    sbQuery.Append(" SET PLN_CODE  = @PLN_CODE ");
                    sbQuery.Append(" , PART_CODE  = @PART_CODE ");
                    sbQuery.Append(" , MQLTY_CODE  = @MQLTY_CODE ");
                    sbQuery.Append(" , PART_SPEC1  = @PART_SPEC1 ");                    
                    sbQuery.Append(" , MDFY_DATE = GETDATE()");
                    sbQuery.Append(" , MDFY_EMP = "+ UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , DATA_FLAG = 0");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PLN_CODE  = @PLN_CODE ");                    

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLN_CODE ")) isHasColumn = false;                        

                        if (isHasColumn == true)
                        {                            
                            bizExecute.executeUpdateQuery(sbQuery.ToString(),row );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static void TSTD_PROCPLAN_MASTER_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append("UPDATE TSTD_PROCPLAN_MASTER SET");
                    sbQuery.Append("  DEL_REASON  = @DEL_REASON ");
                    sbQuery.Append("  DEL_DATE = GETDATE()");
                    sbQuery.Append(" , DEL_EMP = '" + ConnInfo.UserID + "'");
                    sbQuery.Append(" , DATA_FLAG = 2");

                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PLN_CODE  = @PLN_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLN_CODE ")) isHasColumn = false;                        

                        if (isHasColumn == true)
                        {
                            

                            bizExecute.executeUpdateQuery(sbQuery.ToString(),row );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static void TSTD_PROCPLAN_MASTER_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO TSTD_PROCPLAN_MASTER ");
                    sbQuery.Append(" (");
                    sbQuery.Append("PLT_CODE");
                    sbQuery.Append(", PLN_CODE");
                    sbQuery.Append(", PART_CODE ");
                    sbQuery.Append(", MQLTY_CODE");
                    sbQuery.Append(", PART_SPEC1");
                    sbQuery.Append(", REG_DATE");
                    sbQuery.Append(", REG_EMP ");
                    sbQuery.Append(", DATA_FLAG ");
                    sbQuery.Append(" )");
                    sbQuery.Append(" VALUES ");
                    sbQuery.Append(" (");
                    sbQuery.Append("@PLT_CODE ");
                    sbQuery.Append(", @PLN_CODE ");
                    sbQuery.Append(", @PART_CODE");
                    sbQuery.Append(", @MQLTY_CODE ");
                    sbQuery.Append(", @PART_SPEC1 ");
                    sbQuery.Append(" ,GETDATE()");
                    sbQuery.Append(" ," + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" ,0");
                    sbQuery.Append(") ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        
                        bizExecute.executeInsertQuery(sbQuery.ToString(),row);
                    }
                }

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }
    }

    public class TSTD_PROCPLAN_MASTER_QUERY
    {
        public static DataTable TSTD_PROCPLAN_MASTER_QUERY7(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT CD.PLT_CODE");
                    sbQuery.Append(" ,CD.CAT_CODE");
                    sbQuery.Append(" ,CD.CD_CODE ");
                    sbQuery.Append(" ,CD.VALUE ");
                    sbQuery.Append(" ,CD.CD_NAME ");
                    sbQuery.Append(" ,CD.CD_PARENT ");
                    sbQuery.Append(" ,PC.CD_NAME AS CD_PARENT_NAME ");
                    sbQuery.Append(" ,CD.IS_DEFAULT");
                    sbQuery.Append(" ,CD.CD_SEQ");
                    sbQuery.Append(" ,CD.SCOMMENT");
                    sbQuery.Append(" ,CD.REG_DATE");
                    sbQuery.Append(" ,CD.REG_EMP ");
                    sbQuery.Append(" ,REG.EMP_NAME AS REG_EMP_NAME ");
                    sbQuery.Append(" ,CD.MDFY_DATE ");
                    sbQuery.Append(" ,CD.MDFY_EMP");
                    sbQuery.Append(" ,MDFY.EMP_NAME AS MDFY_EMP_NAME ");
                    sbQuery.Append(" FROM TSTD_PROCPLAN_MASTER CD");
                    sbQuery.Append(" LEFT JOIN TSYS_CODECAT CAT");
                    sbQuery.Append(" ON CD.PLT_CODE= CAT.PLT_CODE");
                    sbQuery.Append(" AND CD.CAT_CODE = CAT.CAT_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_PROCPLAN_MASTER PC ");
                    sbQuery.Append(" ON CD.PLT_CODE = PC.PLT_CODE");
                    sbQuery.Append(" AND CD.CD_PARENT = PC.CD_CODE ");
                    sbQuery.Append(" AND CAT.CAT_PARENT = PC.CAT_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_MC_AVAILEEMP REG ");
                    sbQuery.Append(" ON CD.PLT_CODE = REG.PLT_CODE ");
                    sbQuery.Append(" AND CD.REG_EMP = REG.EMP_CODE ");
                    sbQuery.Append(" LEFT JOIN TSTD_MC_AVAILEEMP MDFY");
                    sbQuery.Append(" ON CD.PLT_CODE = MDFY.PLT_CODE ");
                    sbQuery.Append(" AND CD.MDFY_EMP = MDFY.EMP_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE CD.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@CAT_CODE", "CD.CAT_CODE = @CAT_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CD_CODE", "CD.CD_CODE = @CD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "CD.DATA_FLAG = @DATA_FLAG"));

                        sbWhere.Append(" ORDER BY CD.CD_SEQ");

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString() ).Copy();

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
