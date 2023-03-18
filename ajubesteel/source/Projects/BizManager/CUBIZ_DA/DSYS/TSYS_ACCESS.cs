using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSYS
{
    public class TSYS_ACCESS
    {
        public static DataTable TSYS_ACCESS_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" , USRGRP_CODE");
                    sbQuery.Append(" , MENU_CODE");
                    sbQuery.Append(" , ACC_LEVEL");                    
                    sbQuery.Append(" FROM TSYS_ACCESS ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND USRGRP_CODE = @USRGRP_CODE ");
                    sbQuery.Append(" AND MENU_CODE = @MENU_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {                        

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "USRGRP_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MENU_CODE")) isHasColumn = false;                        

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
        

        public static void TSYS_ACCESS_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSYS_ACCESS ");
                    sbQuery.Append(" SET  USRGRP_CODE   = @USRGRP_CODE ");
                    sbQuery.Append(" , MENU_CODE = @MENU_CODE");
                    sbQuery.Append(" , ACC_LEVEL  = @ACC_LEVEL ");                    
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND USRGRP_CODE = @USRGRP_CODE ");
                    sbQuery.Append(" AND MENU_CODE = @MENU_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {                        

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "USRGRP_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MENU_CODE")) isHasColumn = false;                        

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

        public static void TSYS_ACCESS_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" DELETE FROM TSYS_ACCESS ");                        
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND USRGRP_CODE = @USRGRP_CODE");


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

        public static void TSYS_ACCESS_DEL2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" DELETE FROM TSYS_ACCESS ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND USRGRP_CODE = @USRGRP_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크     
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "USRGRP_CODE")) isHasColumn = false;

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

        public static void TSYS_ACCESS_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TSYS_ACCESS");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" , USRGRP_CODE");
                    sbQuery.Append(" , MENU_CODE");
                    sbQuery.Append(" , ACC_LEVEL");
                    sbQuery.Append(" , IS_DEFAULT_MENU ");
                    sbQuery.Append(" ) ");
                    sbQuery.Append(" VALUES");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" @PLT_CODE ");
                    sbQuery.Append(" , @USRGRP_CODE ");
                    sbQuery.Append(" , @MENU_CODE ");
                    sbQuery.Append(" , @ACC_LEVEL ");
                    sbQuery.Append(" , @IS_DEFAULT_MENU");                    
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

    public class TSYS_ACCESS_QUERY
    {
        public static DataTable TSYS_ACCESS_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE");
                    sbQuery.Append(" ,USRGRP_CODE");
                    sbQuery.Append(" ,MENU_CODE");
                    sbQuery.Append(" ,ACC_LEVEL");
                    sbQuery.Append(" ,IS_DEFAULT_MENU");
                    sbQuery.Append(" FROM TSYS_ACCESS");
                    
                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@COPY_USRGRP_CODE", "USRGRP_CODE = @COPY_USRGRP_CODE"));

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
