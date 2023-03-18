using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSYS
{
    public class TSYS_MENULIST
    {
        public static DataTable TSYS_MENULIST_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" , MENU_CODE ");
                    sbQuery.Append(" , MENU_PARENT ");
                    sbQuery.Append(" , MENU_SEQ");
                    sbQuery.Append(" , SCOMMENT");
                    sbQuery.Append(" , RES_ID");
                    sbQuery.Append(" , CLASSNAME ");
                    sbQuery.Append(" , ASSEMBLY");
                    sbQuery.Append(" , ICON");
                    sbQuery.Append(" , USE_FLAG");
                    sbQuery.Append(" , IS_SYS_MENU ");
                    sbQuery.Append(" , IS_STD_MENU ");
                    sbQuery.Append(" , IS_PRO_MENU ");
                    sbQuery.Append(" , HEADER_COLOR ");
                    sbQuery.Append(" , REG_DATE");
                    sbQuery.Append(" , REG_EMP ");
                    sbQuery.Append(" , MDFY_DATE ");
                    sbQuery.Append(" , MDFY_EMP");
                    sbQuery.Append(" , DEL_DATE");
                    sbQuery.Append(" , DEL_EMP ");
                    sbQuery.Append(" , DATA_FLAG ");
                    sbQuery.Append(" FROM TSYS_MENULIST");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND MENU_CODE = @MENU_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {                        

                        bool isHasColumn = true;

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


        public static void TSYS_MENULIST_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSYS_MENULIST");
                    sbQuery.Append(" SET MENU_CODE = @MENU_CODE");
                    sbQuery.Append(" , MENU_PARENT = @MENU_PARENT");
                    sbQuery.Append(" , MENU_SEQ = @MENU_SEQ");
                    sbQuery.Append(" , SCOMMENT = @SCOMMENT");
                    sbQuery.Append(" , RES_ID = @RES_ID");
                    sbQuery.Append(" , CLASSNAME = @CLASSNAME");
                    sbQuery.Append(" , ASSEMBLY = @ASSEMBLY");
                    sbQuery.Append(" , ICON = @ICON");
                    sbQuery.Append(" , USE_FLAG = @USE_FLAG");
                    sbQuery.Append(" , IS_SYS_MENU = @IS_SYS_MENU");
                    sbQuery.Append(" , IS_STD_MENU = @IS_STD_MENU");
                    sbQuery.Append(" , IS_PRO_MENU = @IS_PRO_MENU");
                    sbQuery.Append(" , HEADER_COLOR = @HEADER_COLOR ");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , DATA_FLAG = 0");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND MENU_CODE = @O_MENU_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크                        
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

        public static void TSYS_MENULIST_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSYS_MENULIST ");    
                    sbQuery.Append(" SET ");
                    sbQuery.Append("  DEL_DATE = GETDATE()");
                    sbQuery.Append(" , DEL_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , DATA_FLAG = 2");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND MENU_CODE = @MENU_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크                        
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

        public static void TSYS_MENULIST_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TSYS_MENULIST");
                    sbQuery.Append(" (");
                    sbQuery.Append(" PLT_CODE ");
                    sbQuery.Append(" , MENU_CODE");
                    sbQuery.Append(" , MENU_PARENT");
                    sbQuery.Append(" , MENU_SEQ ");
                    sbQuery.Append(" , SCOMMENT ");
                    sbQuery.Append(" , RES_ID ");
                    sbQuery.Append(" , CLASSNAME");
                    sbQuery.Append(" , ASSEMBLY ");
                    sbQuery.Append(" , ICON ");
                    sbQuery.Append(" , USE_FLAG ");
                    sbQuery.Append(" , IS_SYS_MENU");
                    sbQuery.Append(" , IS_STD_MENU");
                    sbQuery.Append(" , IS_PRO_MENU");
                    sbQuery.Append(" , HEADER_COLOR ");
                    sbQuery.Append(" , REG_DATE ");
                    sbQuery.Append(" , REG_EMP");
                    sbQuery.Append(" , DATA_FLAG");
                    sbQuery.Append(" )");
                    sbQuery.Append(" VALUES ");
                    sbQuery.Append(" (");
                    sbQuery.Append(" @PLT_CODE");
                    sbQuery.Append(" , @MENU_CODE ");
                    sbQuery.Append(" , @MENU_PARENT ");
                    sbQuery.Append(" , @MENU_SEQ");
                    sbQuery.Append(" , @SCOMMENT");
                    sbQuery.Append(" , @RES_ID");
                    sbQuery.Append(" , @CLASSNAME ");
                    sbQuery.Append(" , @ASSEMBLY");
                    sbQuery.Append(" , @ICON");
                    sbQuery.Append(" , @USE_FLAG");
                    sbQuery.Append(" , @IS_SYS_MENU ");
                    sbQuery.Append(" , @IS_STD_MENU ");
                    sbQuery.Append(" , @IS_PRO_MENU ");
                    sbQuery.Append(" , @HEADER_COLOR ");
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

    public class TSYS_MENULIST_QUERY
    {
        public static DataTable TSYS_MENULIST_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT ");
                    sbQuery.Append(" MENU.PLT_CODE");
                    sbQuery.Append(" ,MENU.MENU_CODE");
                    sbQuery.Append(" ,MENU.MENU_CODE AS O_MENU_CODE");
	                sbQuery.Append(" ,MENU_NAME = RES.RES_CONTENTS");
                    sbQuery.Append(" ,MENU.MENU_PARENT");
                    sbQuery.Append(" ,MENU.MENU_SEQ");
                    sbQuery.Append(" ,MENU.SCOMMENT");
                    sbQuery.Append(" ,MENU.RES_ID");
                    sbQuery.Append(" ,MENU.ASSEMBLY");
                    sbQuery.Append(" ,MENU.CLASSNAME");
                    sbQuery.Append(" ,MENU.ICON");
                    sbQuery.Append(" ,MENU.USE_FLAG");                          
                    sbQuery.Append(" ,MENU.IS_SYS_MENU");                       
                    sbQuery.Append(" ,MENU.IS_STD_MENU");                       
                    sbQuery.Append(" ,MENU.IS_PRO_MENU");                       
                    sbQuery.Append(" ,MENU.REG_DATE");                          
                    sbQuery.Append(" ,MENU.REG_EMP");                           
                    sbQuery.Append(" ,MENU.MDFY_DATE");                         
                    sbQuery.Append(" ,MENU.MDFY_EMP");
                    sbQuery.Append(" ,MENU.HEADER_COLOR");
                    sbQuery.Append("  FROM TSYS_MENULIST MENU ");
                    sbQuery.Append("  LEFT JOIN TSYS_STRINGTABLE RES ON MENU.PLT_CODE = RES.PLT_CODE AND MENU.RES_ID = RES.RES_ID   ");

                    DataRow row = dtParam.Rows[0];

                    bool isHasColumn = true;
                    //검색 조건 유무 체크                        
                    if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                    if (!UTIL.ValidColumn(row, "LANG")) isHasColumn = false;


                    if (isHasColumn == true)
                    {
                        sbQuery.Replace("@PLT_CODE", UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbQuery.Replace("@LANG", UTIL.GetValidValue(row, "LANG").ToString());

                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE MENU.DATA_FLAG = 0 ");

                        sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", "MENU.PLT_CODE = @PLT_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@LANG", " (RES.RES_LANG = @LANG OR RES.RES_LANG IS NULL) "));
                        
                        sbWhere.Append(" ORDER BY MENU.MENU_SEQ");

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

        public static DataTable TSYS_MENULIST_QUERY4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" A.ICON");
                    sbQuery.Append(" ,A.MENU_CODE");
                    sbQuery.Append(" ,B.RES_CONTENTS AS MENU_NAME");
                    sbQuery.Append(" ,A.MENU_PARENT");
                    sbQuery.Append(" ,PMS.RES_CONTENTS AS MENU_PARENT_NAME");
                    sbQuery.Append(" ,A.SCOMMENT");
                    sbQuery.Append(" ,A.RES_ID");
                    sbQuery.Append(" ,A.ICON");
                    sbQuery.Append(" ,A.CLASSNAME");
                    sbQuery.Append(" ,A.ASSEMBLY");
                    sbQuery.Append(" ,A.HEADER_COLOR");
                    sbQuery.Append(" FROM TSYS_MENULIST A");
                    sbQuery.Append(" LEFT JOIN TSYS_STRINGTABLE B");
                    sbQuery.Append(" ON A.PLT_CODE = B.PLT_CODE");
                    sbQuery.Append(" AND A.RES_ID = B.RES_ID");
                    sbQuery.Append(" AND B.RES_LANG = @LANG");
                    sbQuery.Append(" LEFT JOIN TSYS_MENULIST PM");
                    sbQuery.Append(" ON A.PLT_CODE = PM.PLT_CODE ");
                    sbQuery.Append(" AND A.MENU_PARENT = PM.MENU_CODE");
                    sbQuery.Append(" LEFT OUTER JOIN ");
                    sbQuery.Append(" (SELECT PLT_CODE, RES_ID, RES_CONTENTS FROM TSYS_STRINGTABLE WHERE PLT_CODE = @PLT_CODE AND RES_LANG = @LANG) PMS");
                    sbQuery.Append(" ON");
                    sbQuery.Append(" PM.RES_ID = PMS.RES_ID");
                    sbQuery.Append(" AND PM.PLT_CODE = PMS.PLT_CODE");



                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크                        
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "LANG")) isHasColumn = false;


                        if (isHasColumn == true)
                        {
                            sbQuery.Replace("@PLT_CODE", UTIL.GetValidValue(row, "PLT_CODE").ToString());
                            sbQuery.Replace("@LANG", UTIL.GetValidValue(row, "LANG").ToString());

                            StringBuilder sbWhere = new StringBuilder();

                            sbWhere.Append(" WHERE A.DATA_FLAG = 0 ");

                            sbWhere.Append(UTIL.GetWhere(row, "@MENU_CODE", "A.MENU_CODE = @MENU_CODE"));
                            sbWhere.Append(UTIL.GetWhere(row, "@USE_FLAG", "A.USE_FLAG = @USE_FLAG"));
                            sbWhere.Append(UTIL.GetWhere(row, "@IS_MENU", "A.MENU_PARENT IS NOT NULL"));
                            sbWhere.Append(UTIL.GetWhere(row, "@STD_MENU", "A.IS_STD_MENU = 1"));
                            sbWhere.Append(UTIL.GetWhere(row, "@PRO_MENU", "A.IS_PRO_MENU = 1"));
                            sbWhere.Append(UTIL.GetWhere(row, "@USE_CONF", "A.USE_CONF = @USE_CONF"));
                            sbWhere.Append(" ORDER BY A.MENU_SEQ");

                            DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

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


        public static DataTable TSYS_MENULIST_QUERY5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT ");
                    sbQuery.Append(" A.PLT_CODE,");
                    sbQuery.Append(" A.MENU_CODE,");
                    sbQuery.Append(" S.RES_CONTENTS AS MENU_NAME,");
                    sbQuery.Append(" A.MENU_PARENT,");
                    sbQuery.Append(" A.SCOMMENT,");
                    sbQuery.Append(" A.MENU_SEQ,");
                    sbQuery.Append(" B.USRGRP_CODE,");
                    sbQuery.Append(" A.RES_ID,");
                    sbQuery.Append(" A.ICON,");
                    sbQuery.Append(" A.CLASSNAME,");
                    sbQuery.Append(" A.ASSEMBLY,");
                    sbQuery.Append(" B.ACC_LEVEL,");
                    sbQuery.Append(" S.RES_LANG,");
                    sbQuery.Append(" ISNULL(B.IS_DEFAULT_MENU, 0) IS_DEFAULT_MENU");
                    sbQuery.Append(" ,A.HEADER_COLOR");
                    sbQuery.Append(" FROM TSYS_MENULIST A");
                    sbQuery.Append(" LEFT JOIN TSYS_STRINGTABLE S");
                    sbQuery.Append(" ON A.PLT_CODE = S.PLT_CODE");
                    sbQuery.Append(" AND A.RES_ID = S.RES_ID");
                    sbQuery.Append(" LEFT JOIN TSYS_ACCESS B");
                    sbQuery.Append(" ON A.PLT_CODE = B.PLT_CODE");
                    sbQuery.Append(" AND A.MENU_CODE = B.MENU_CODE");
                    sbQuery.Append(" LEFT JOIN TSYS_MENULIST P ");
                    sbQuery.Append(" ON A.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND A.MENU_PARENT = P.MENU_CODE ");
                    sbQuery.Append(" AND P.MENU_PARENT IS NULL ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크                        
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "RES_LANG")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "USRGRP_CODE")) isHasColumn = false;


                        if (isHasColumn == true)
                        {
                            sbQuery.Replace("@PLT_CODE", UTIL.GetValidValue(row, "PLT_CODE").ToString());
                            sbQuery.Replace("@RES_LANG", UTIL.GetValidValue(row, "RES_LANG").ToString());
                            sbQuery.Replace("@USRGRP_CODE", UTIL.GetValidValue(row, "USRGRP_CODE").ToString());

                            StringBuilder sbWhere = new StringBuilder();

                            sbWhere.Append(" WHERE A.USE_FLAG = 1");
                            //sbWhere.Append(" AND B.ACC_LEVEL = 2");
                            sbWhere.Append(" AND A.IS_SYS_MENU = 0");
                            sbWhere.Append(" AND A.DATA_FLAG = 0");
                            sbWhere.Append(" AND ISNULL(P.DATA_FLAG,0) = 0 AND ISNULL(P.USE_FLAG,1) = 1");

                            sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", "A.PLT_CODE = @PLT_CODE"));
                            sbWhere.Append(UTIL.GetWhere(row, "@USRGRP_CODE", "B.USRGRP_CODE = @USRGRP_CODE"));
                            sbWhere.Append(UTIL.GetWhere(row, "@RES_LANG", "S.RES_LANG = @RES_LANG"));
                            sbWhere.Append(UTIL.GetWhere(row, "@STD_MENU", "A.IS_STD_MENU = 1"));
                            sbWhere.Append(UTIL.GetWhere(row, "@PRO_MENU", "A.IS_PRO_MENU = 1"));
                            sbWhere.Append(" ORDER BY A.MENU_SEQ");

                            DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

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

        public static DataTable TSYS_MENULIST_QUERY6(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    
                    sbQuery.Append(" SELECT ");
                    sbQuery.Append(" A.PLT_CODE ,");
                    sbQuery.Append(" A.MENU_CODE,");
                    sbQuery.Append(" S.RES_CONTENTS AS MENU_NAME,");
                    sbQuery.Append(" A.MENU_PARENT,");
                    sbQuery.Append(" A.SCOMMENT,");
                    sbQuery.Append(" A.MENU_SEQ,");
                    sbQuery.Append(" @USRGRP_CODE AS USRGRP_CODE,");
                    sbQuery.Append(" A.RES_ID,");
                    sbQuery.Append(" A.ICON,");
                    sbQuery.Append(" A.CLASSNAME,");
                    sbQuery.Append(" A.ASSEMBLY,");
                    sbQuery.Append(" '1' AS ACC_LEVEL,");
                    sbQuery.Append(" S.RES_LANG,");
                    sbQuery.Append(" CONVERT(tinyint , 0) IS_DEFAULT_MENU");                    
                    sbQuery.Append(" ,A.HEADER_COLOR");
                    sbQuery.Append(" FROM TSYS_MENULIST A");
                    sbQuery.Append(" LEFT JOIN TSYS_STRINGTABLE S");
                    sbQuery.Append(" ON A.PLT_CODE = S.PLT_CODE");
                    sbQuery.Append(" AND A.RES_ID = S.RES_ID");
                    sbQuery.Append(" LEFT JOIN TSYS_MENULIST P ");
                    sbQuery.Append(" ON A.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND A.MENU_PARENT = P.MENU_CODE ");
                    sbQuery.Append(" AND P.MENU_PARENT IS NULL ");


                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크                        
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "RES_LANG")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "USRGRP_CODE")) isHasColumn = false;


                        if (isHasColumn == true)
                        {
                            sbQuery.Replace("@PLT_CODE", UTIL.GetValidValue(row, "PLT_CODE").ToString());
                            sbQuery.Replace("@RES_LANG", UTIL.GetValidValue(row, "RES_LANG").ToString());
                            sbQuery.Replace("@USRGRP_CODE", UTIL.GetValidValue(row, "USRGRP_CODE").ToString());

                            StringBuilder sbWhere = new StringBuilder();

                            sbWhere.Append(" WHERE A.USE_FLAG = 1");
                            sbWhere.Append(" AND A.IS_SYS_MENU = 0");
                            sbWhere.Append(" AND A.DATA_FLAG = 0");
                            sbWhere.Append(" AND ISNULL(P.DATA_FLAG,0) = 0  AND ISNULL(P.USE_FLAG,1) = 1");

                            sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", "A.PLT_CODE = @PLT_CODE"));
                            sbWhere.Append(UTIL.GetWhere(row, "@RES_LANG", "S.RES_LANG = @RES_LANG"));
                            sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE, @USRGRP_CODE", "A.MENU_CODE NOT IN  (SELECT MENU_CODE FROM TSYS_ACCESS WHERE PLT_CODE = @PLT_CODE AND USRGRP_CODE = @USRGRP_CODE )"));
                            sbWhere.Append(UTIL.GetWhere(row, "@STD_MENU", "A.IS_STD_MENU = 1"));
                            sbWhere.Append(UTIL.GetWhere(row, "@PRO_MENU", "A.IS_PRO_MENU = 1"));

                            DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

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

        //시스템 관리자
        public static DataTable TSYS_MENULIST_QUERY7(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                StringBuilder sbQuery = new StringBuilder();

                sbQuery.Append(" SELECT ");
                sbQuery.Append(" A.MENU_CODE,");
                sbQuery.Append(" S.RES_CONTENTS AS MENU_NAME,");
                sbQuery.Append(" A.MENU_PARENT,");
                sbQuery.Append(" A.SCOMMENT, ");
                sbQuery.Append(" A.MENU_SEQ,");
                sbQuery.Append(" A.RES_ID, ");
                sbQuery.Append(" A.ICON,");
                sbQuery.Append(" A.CLASSNAME, ");
                sbQuery.Append(" A.ASSEMBLY,");
                sbQuery.Append(" 2 AS ACC_LEVEL,");
                sbQuery.Append(" 0 AS IS_DEFAULT_MENU,");
                sbQuery.Append(" A.IS_POP_MENU ");
                sbQuery.Append(" ,A.HEADER_COLOR");
                sbQuery.Append(" FROM TSYS_MENULIST A");
                sbQuery.Append(" LEFT JOIN TSYS_STRINGTABLE S");
                sbQuery.Append(" ON A.PLT_CODE = S.PLT_CODE");
                sbQuery.Append(" AND A.RES_ID = S.RES_ID");

                

                foreach (DataRow row in dtParam.Rows)
                {                    

                    StringBuilder sbWhere = new StringBuilder();
                    
                    sbWhere.Append(" WHERE A.USE_FLAG = 1");                    
                    sbWhere.Append(" AND A.DATA_FLAG = 0");
                    sbWhere.Append(" AND A.USE_FLAG = 1"); 

                    sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", "A.PLT_CODE = @PLT_CODE"));
                    sbWhere.Append(UTIL.GetWhere(row, "@RES_LANG", "S.RES_LANG = @RES_LANG"));                    
                    sbWhere.Append(UTIL.GetWhere(row, "@STD_MENU", "A.IS_STD_MENU = 1"));
                    sbWhere.Append(UTIL.GetWhere(row, "@PRO_MENU", "A.IS_PRO_MENU = 1"));
                    sbWhere.Append(UTIL.GetWhere(row, "@SYS_MENU", "A.IS_SYS_MENU = 0"));

                    sbWhere.Append(" ORDER BY A.MENU_SEQ");

                    DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

                    sourceTable.TableName = "RSLTDT";
                    dsResult.Merge(sourceTable);
 
                }
                 

                return UTIL.GetDsToDt(dsResult);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        //일반 사용자
        public static DataTable TSYS_MENULIST_QUERY8(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                StringBuilder sbQuery = new StringBuilder();

                sbQuery.Append(" SELECT  A.PLT_CODE,");
                sbQuery.Append(" A.MENU_CODE,");
                sbQuery.Append(" S.RES_CONTENTS AS MENU_NAME,");
                sbQuery.Append(" A.MENU_PARENT,");
                sbQuery.Append(" A.SCOMMENT, ");
                sbQuery.Append(" A.MENU_SEQ,");
                sbQuery.Append(" B.USRGRP_CODE, ");
                sbQuery.Append(" A.RES_ID, ");
                sbQuery.Append(" A.ICON,");
                sbQuery.Append(" A.CLASSNAME, ");
                sbQuery.Append(" A.ASSEMBLY,");
                sbQuery.Append(" B.ACC_LEVEL,");
                sbQuery.Append(" B.IS_DEFAULT_MENU,");
                sbQuery.Append(" A.IS_POP_MENU, ");
                sbQuery.Append(" A.HEADER_COLOR");
                sbQuery.Append("  FROM TSYS_MENULIST A");
                sbQuery.Append("  LEFT JOIN TSYS_STRINGTABLE S");
                sbQuery.Append("    ON A.PLT_CODE = S.PLT_CODE");
                sbQuery.Append("   AND A.RES_ID = S.RES_ID");
                sbQuery.Append("  LEFT JOIN TSYS_ACCESS B");
                sbQuery.Append("    ON A.PLT_CODE = B.PLT_CODE");
                sbQuery.Append("   AND A.MENU_CODE = B.MENU_CODE");

                foreach (DataRow row in dtParam.Rows)
                {

                    StringBuilder sbWhere = new StringBuilder();

                    sbWhere.Append(" WHERE A.USE_FLAG = 1");
                    sbWhere.Append(" AND A.DATA_FLAG = 0");
                    sbWhere.Append(" AND A.USE_FLAG = 1");
                    sbQuery.Append(" AND B.ACC_LEVEL = 2 ");          //권한
                    sbQuery.Append(" AND A.IS_SYS_MENU = 0 ");        //시스템 메뉴 제외

                    sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", "A.PLT_CODE = @PLT_CODE"));
                    sbWhere.Append(UTIL.GetWhere(row, "@RES_LANG", "S.RES_LANG = @RES_LANG"));
                    sbWhere.Append(UTIL.GetWhere(row, "@USRGRP_CODE", "B.USRGRP_CODE = @USRGRP_CODE"));
                    sbWhere.Append(UTIL.GetWhere(row, "@STD_MENU", "A.IS_STD_MENU = 1"));
                    sbWhere.Append(UTIL.GetWhere(row, "@PRO_MENU", "A.IS_PRO_MENU = 1"));
                    sbWhere.Append(UTIL.GetWhere(row, "@SYS_MENU", "A.IS_SYS_MENU = 0"));

                    sbWhere.Append(" ORDER BY A.MENU_SEQ");

                    DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

                    sourceTable.TableName = "RSLTDT";
                    dsResult.Merge(sourceTable);

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
