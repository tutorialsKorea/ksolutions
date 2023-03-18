using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSYS
{
    public class TSYS_USERGRP
    {
        public static DataTable TSYS_USERGRP_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" , USRGRP_CODE ");
                    sbQuery.Append(" , USRGRP_NAME ");
                    sbQuery.Append(" , REG_DATE");
                    sbQuery.Append(" , REG_EMP ");
                    sbQuery.Append(" , MDFY_DATE ");
                    sbQuery.Append(" , MDFY_EMP");
                    sbQuery.Append(" , DEL_DATE");
                    sbQuery.Append(" , DEL_EMP ");
                    sbQuery.Append(" , DEL_REASON");
                    sbQuery.Append(" , DATA_FLAG ");
                    sbQuery.Append(" FROM TSYS_USERGRP ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND USRGRP_CODE = @USRGRP_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "USRGRP_CODE")) isHasColumn = false;                        

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

        public static void TSYS_USERGRP_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSYS_USERGRP ");
                    sbQuery.Append(" SET USRGRP_CODE = @USRGRP_CODE");
                    sbQuery.Append(" , USRGRP_NAME = @USRGRP_NAME");                    
                    sbQuery.Append(" , MDFY_DATE = GETDATE()");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , DATA_FLAG = 0");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND USRGRP_CODE = @USRGRP_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "USRGRP_CODE")) isHasColumn = false;                        

                        if (isHasColumn == true)
                        {                                                        
                            bizExecute.executeUpdateQuery(sbQuery.ToString(),row);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static void TSYS_USERGRP_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append("UPDATE TSYS_USERGRP SET");
                    sbQuery.Append("  DEL_DATE = GETDATE()");
                    sbQuery.Append(" , DEL_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , DATA_FLAG = 2");

                    sbQuery.Append("WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("AND USRGRP_CODE = @USRGRP_CODE");                    

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "USRGRP_CODE")) isHasColumn = false;                    

                        if (isHasColumn == true)
                        {                            
                            bizExecute.executeUpdateQuery(sbQuery.ToString(),row);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static void TSYS_USERGRP_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtNow = UTIL.UTILITY_GET_DTNOW(bizExecute);
                string dt = ((DateTime)dtNow.Rows[0]["NOW_DT"]).ToString("yyyy-MM-dd HH:mm:ss");
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO TSYS_USERGRP");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" , USRGRP_CODE ");
                    sbQuery.Append(" , USRGRP_NAME ");
                    sbQuery.Append(" , REG_DATE");
                    sbQuery.Append(" , REG_EMP ");
                    sbQuery.Append(" , DATA_FLAG ");
                    sbQuery.Append(" ) ");
                    sbQuery.Append(" VALUES");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" @PLT_CODE ");
                    sbQuery.Append(" , @USRGRP_CODE");
                    sbQuery.Append(" , @USRGRP_NAME");
                    sbQuery.Append(" , GETDATE() ");
                    sbQuery.Append(" , " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , 0");
                    sbQuery.Append(" ) ");

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

    public class TSYS_USERGRP_QUERY
    {
        public static DataTable TSYS_USERGRP_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT G.PLT_CODE ");
                    sbQuery.Append(" ,G.USRGRP_CODE");
                    sbQuery.Append(" ,G.USRGRP_NAME");
                    sbQuery.Append(" ,G.REG_DATE ");
                    sbQuery.Append(" ,REG.EMP_NAME AS REG_EMP_NAME ");
                    sbQuery.Append(" ,G.REG_EMP");
                    sbQuery.Append(" ,G.MDFY_DATE");
                    sbQuery.Append(" ,G.MDFY_EMP ");
                    sbQuery.Append(" ,MDFY.EMP_NAME AS MDFY_EMP_NAME ");
                    sbQuery.Append(" FROM TSYS_USERGRP G ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG ");
                    sbQuery.Append(" ON G.PLT_CODE = REG.PLT_CODE");
                    sbQuery.Append(" AND G.REG_EMP = REG.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY");
                    sbQuery.Append(" ON G.PLT_CODE = MDFY.PLT_CODE ");
                    sbQuery.Append(" AND G.MDFY_EMP = MDFY.EMP_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE G.PLT_CODE = @PLT_CODE ").Replace("@PLT_CODE", UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@USRGRP_CODE", "G.USRGRP_CODE = @USRGRP_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@USRGRP_NAME", "G.USRGRP_NAME = @USRGRP_NAME"));
                        sbWhere.Append(UTIL.GetWhere(row, "@USRGRP_LIKE", "(G.USRGRP_CODE LIKE '%' + @USRGRP_LIKE + '%' OR G.USRGRP_NAME LIKE '%' + @USRGRP_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "G.DATA_FLAG = @DATA_FLAG"));

                        //sbQuery.Append(" ORDER BY CD.CD_SEQ");

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString()+ sbWhere.ToString()).Copy();

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
