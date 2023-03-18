using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizExecute;
using System.Data;

namespace DSTD
{
    public class TSTD_PROCGRP
    {
        public static DataTable TSTD_PROCGRP_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" , PRG_CODE");
                    sbQuery.Append(" , PRG_CLASS ");
                    sbQuery.Append(" , PRG_NAME");
                    sbQuery.Append(" , UP_CLASS");
                    sbQuery.Append(" , MCLASS_FLAG ");
                    sbQuery.Append(" , PRG_SEQ ");
                    sbQuery.Append(" , PRG_RATIO ");
                    sbQuery.Append(" , PRG_ACCUM ");
                    sbQuery.Append(" , PRG_TYPE");
                    sbQuery.Append(" , ORG_CODE");
                    sbQuery.Append(" , PRG_COLOR ");
                    sbQuery.Append(" , INS_FLAG");
                    sbQuery.Append(" , IS_OS ");
                    sbQuery.Append(" , REG_DATE");
                    sbQuery.Append(" , REG_EMP ");
                    sbQuery.Append(" , MDFY_DATE ");
                    sbQuery.Append(" , MDFY_EMP");
                    sbQuery.Append(" , DEL_DATE");
                    sbQuery.Append(" , DEL_EMP ");
                    sbQuery.Append(" , DEL_REASON");
                    sbQuery.Append(" , DATA_FLAG ");
                    sbQuery.Append(" FROM TSTD_PROCGRP ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PRG_CODE = @PRG_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {                                                         
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PRG_CODE")) isHasColumn = false;                        

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

        public static void TSTD_PROCGRP_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSTD_PROCGRP ");
                    sbQuery.Append(" SET PRG_CODE = @PRG_CODE");
                    sbQuery.Append(", PRG_CLASS = @PRG_CLASS");
                    sbQuery.Append(", PRG_NAME = @PRG_NAME");
                    sbQuery.Append(", UP_CLASS = @UP_CLASS");
                    sbQuery.Append(", MCLASS_FLAG = @MCLASS_FLAG");
                    sbQuery.Append(", PRG_SEQ = @PRG_SEQ");
                    sbQuery.Append(", PRG_TYPE = @PRG_TYPE");
                    sbQuery.Append(", ORG_CODE = @ORG_CODE");
                    sbQuery.Append(", PRG_COLOR = @PRG_COLOR");
                    sbQuery.Append(", INS_FLAG = @INS_FLAG");
                    sbQuery.Append(", IS_OS = @IS_OS");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()");
                    sbQuery.Append(" , MDFY_EMP = "+ UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , DATA_FLAG = 0");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PRG_CODE = @PRG_CODE");
                    sbQuery.Append(" AND PRG_CLASS = @PRG_CLASS");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PRG_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PRG_CLASS")) isHasColumn = false;

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

        /// <summary>
        /// 상위일정변경(중일정)
        /// </summary>
        /// <param name="dtParam"></param>
        public static void TSTD_PROCGRP_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSTD_PROCGRP SET ");                    
                    sbQuery.Append(" UP_CLASS = @UP_CLASS");                    
                    sbQuery.Append(" , MDFY_DATE = GETDATE()");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));                    
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PRG_CODE = @PRG_CODE");
                    
                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PRG_CODE")) isHasColumn = false;                        

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

        public static void TSTD_PROCGRP_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append("UPDATE TSTD_PROCGRP SET");
                    sbQuery.Append("  DEL_DATE = GETDATE()");
                    sbQuery.Append(" , DEL_EMP = '" + ConnInfo.UserID + "'");
                    sbQuery.Append(" , DATA_FLAG = 2");

                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PRG_CODE = @PRG_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PRG_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            bizExecute.executeUpdateQuery(sbQuery.ToString(), row );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static void TSTD_PROCGRP_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO TSTD_PROCGRP");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" , PRG_CODE");
                    sbQuery.Append(" , PRG_CLASS ");
                    sbQuery.Append(" , PRG_NAME");
                    sbQuery.Append(" , UP_CLASS");
                    sbQuery.Append(" , MCLASS_FLAG ");
                    sbQuery.Append(" , PRG_SEQ ");
                    sbQuery.Append(" , PRG_TYPE");
                    sbQuery.Append(" , ORG_CODE");
                    sbQuery.Append(" , PRG_COLOR ");
                    sbQuery.Append(" , INS_FLAG");
                    sbQuery.Append(" , IS_OS ");
                    sbQuery.Append(" , REG_DATE");
                    sbQuery.Append(" , REG_EMP ");
                    sbQuery.Append(" , DATA_FLAG ");
                    sbQuery.Append(" ) ");
                    sbQuery.Append(" VALUES");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" @PLT_CODE ");
                    sbQuery.Append(" , @PRG_CODE ");
                    sbQuery.Append(" , @PRG_CLASS");
                    sbQuery.Append(" , @PRG_NAME ");
                    sbQuery.Append(" , @UP_CLASS ");
                    sbQuery.Append(" , @MCLASS_FLAG");
                    sbQuery.Append(" , @PRG_SEQ");
                    sbQuery.Append(" , @PRG_TYPE ");
                    sbQuery.Append(" , @ORG_CODE ");
                    sbQuery.Append(" , @PRG_COLOR");
                    sbQuery.Append(" , @INS_FLAG ");
                    sbQuery.Append(" , @IS_OS");                    
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

    public class TSTD_PROCGRP_QUERY
    {
        /// <summary>
        /// 공정 그룹 기본 쿼리
        /// </summary>
        /// <param name="dtParam"></param>
        /// <returns></returns>
        public static DataTable TSTD_PROCGRP_QUERY4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PG.PLT_CODE");
                    sbQuery.Append(" ,PG.PRG_CODE");
                    sbQuery.Append(" ,PG.PRG_CLASS ");
                    sbQuery.Append(" ,PG.PRG_NAME");
                    sbQuery.Append(" ,PG.UP_CLASS");
                    sbQuery.Append(" ,PG.MCLASS_FLAG ");
                    sbQuery.Append(" ,PG.PRG_SEQ ");
                    sbQuery.Append(" ,PG.PRG_RATIO ");
                    sbQuery.Append(" ,PG.PRG_ACCUM ");
                    sbQuery.Append(" ,PG.PRG_TYPE");
                    sbQuery.Append(" ,PG.ORG_CODE");
                    sbQuery.Append(" ,O.ORG_NAME");
                    sbQuery.Append(" ,PG.PRG_COLOR ");
                    sbQuery.Append(" ,PG.INS_FLAG");
                    sbQuery.Append(" ,PG.REG_DATE");
                    sbQuery.Append(" ,PG.REG_EMP ");
                    sbQuery.Append(" ,PG.MDFY_DATE ");
                    sbQuery.Append(" ,PG.MDFY_EMP");
                    sbQuery.Append(" ,PG.DATA_FLAG ");
                    sbQuery.Append(" ,PG.DEL_DATE");
                    sbQuery.Append(" ,PG.DEL_EMP ");
                    sbQuery.Append(" ,PG.IS_OS ");
                    sbQuery.Append(" FROM TSTD_PROCGRP PG LEFT JOIN TSTD_ORG O ");
                    sbQuery.Append("   ON PG.PLT_CODE = O.PLT_CODE ");
                    sbQuery.Append("  AND PG.ORG_CODE = O.ORG_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PG.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", "PG.PLT_CODE = @PLT_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PRG_CODE", "PG.PRG_CODE = @PRG_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "PG.DATA_FLAG = @DATA_FLAG"));

                        sbWhere.Append(" ORDER BY PG.PRG_SEQ");

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



        /// <summary>
        /// 공정 그룹 사용자정의 기본 쿼리
        /// </summary>
        /// <param name="dtParam"></param>
        /// <returns></returns>
        public static DataTable TSTD_PROCGRP_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE");
                    sbQuery.Append(" ,PRG_CODE");
                    sbQuery.Append(" ,PRG_CLASS ");
                    sbQuery.Append(" ,PRG_NAME");
                    sbQuery.Append(" ,UP_CLASS");
                    sbQuery.Append(" ,MCLASS_FLAG ");
                    sbQuery.Append(" ,PRG_SEQ ");
                    sbQuery.Append(" ,PRG_RATIO ");
                    sbQuery.Append(" ,PRG_ACCUM ");
                    sbQuery.Append(" ,PRG_TYPE");
                    sbQuery.Append(" ,ORG_CODE");
                    sbQuery.Append(" ,PRG_COLOR ");
                    sbQuery.Append(" ,INS_FLAG");
                    sbQuery.Append(" ,REG_DATE");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,MDFY_DATE ");
                    sbQuery.Append(" ,MDFY_EMP");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append(" ,DEL_DATE");
                    sbQuery.Append(" ,DEL_EMP ");
                    sbQuery.Append(" FROM TSTD_PROCGRP");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        
                        sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", "PLT_CODE = @PLT_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PRG_CODE", "PRG_CODE = @PRG_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PRG_CLASS", "PRG_CLASS = @PRG_CLASS"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "DATA_FLAG = @DATA_FLAG"));

                        sbWhere.Append(" ORDER BY PRG_SEQ");

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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtParam"></param>
        /// <returns></returns>
        public static DataTable TSTD_PROCGRP_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT P.PLT_CODE");
                    sbQuery.Append(" ,P.PRG_CODE");
                    sbQuery.Append(" ,P.PRG_CLASS ");
                    sbQuery.Append(" ,P.PRG_NAME");
                    sbQuery.Append(" ,P.UP_CLASS");
                    sbQuery.Append(" ,P.MCLASS_FLAG ");
                    sbQuery.Append(" ,P.PRG_SEQ ");
                    sbQuery.Append(" ,P.PRG_RATIO ");
                    sbQuery.Append(" ,P.PRG_ACCUM ");
                    sbQuery.Append(" ,P.PRG_TYPE");
                    sbQuery.Append(" ,P.ORG_CODE");
                    sbQuery.Append(" ,O.ORG_NAME");
                    sbQuery.Append(" ,P.PRG_COLOR ");
                    sbQuery.Append(" ,P.INS_FLAG");
                    sbQuery.Append(" ,P.IS_OS ");
                    sbQuery.Append(" ,P.REG_DATE");
                    sbQuery.Append(" ,P.REG_EMP ");
                    sbQuery.Append(" ,REG_EMP.EMP_NAME AS REG_EMP_NAME");
                    sbQuery.Append(" ,P.MDFY_DATE ");
                    sbQuery.Append(" ,P.MDFY_EMP");
                    sbQuery.Append(" ,MDFY_EMP.EMP_NAME AS MDFY_EMP_NAME");
                    sbQuery.Append(" ,P.DATA_FLAG ");
                    sbQuery.Append(" FROM TSTD_PROCGRP P");
                    sbQuery.Append(" LEFT JOIN TSTD_PROCGRP PU ON P.PLT_CODE = PU.PLT_CODE AND P.UP_CLASS = PU.PRG_CODE ");
                    sbQuery.Append(" LEFT JOIN TSTD_ORG O ON P.PLT_CODE = O.PLT_CODE AND P.ORG_CODE = O.ORG_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG_EMP ON P.PLT_CODE = REG_EMP.PLT_CODE AND P.REG_EMP = REG_EMP.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY_EMP ON P.PLT_CODE = MDFY_EMP.PLT_CODE AND P.MDFY_EMP = MDFY_EMP.EMP_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE P.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        
                        sbWhere.Append(UTIL.GetWhere(row, "@PRG_CODE", "P.PRG_CODE = @PRG_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PRG_CLASS", "P.PRG_CLASS = @PRG_CLASS"));
                        sbWhere.Append(UTIL.GetWhere(row, "@UP_CLASS", "P.UP_CLASS = @UP_CLASS"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "P.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MCLASS_FLAG", "P.MCLASS_FLAG = @MCLASS_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "", "(PU.DATA_FLAG = 0 OR PU.DATA_FLAG IS NULL)"));

                        sbWhere.Append(" ORDER BY P.PRG_SEQ");

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

        /// <summary>
        /// 대일정, 중일정 선택 컨트롤
        /// </summary>
        /// <param name="dtParam"></param>
        /// <returns></returns>
        public static DataTable TSTD_PROCGRP_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT ");
                    sbQuery.Append(" PG.PLT_CODE ,");
                    sbQuery.Append(" PG.PRG_CODE ,");
                    sbQuery.Append(" PG.PRG_CLASS , ");
                    sbQuery.Append(" PG.PRG_NAME ,");
                    sbQuery.Append(" PG.PRG_COLOR , ");
                    sbQuery.Append(" PG.PRG_SEQ , ");
                    sbQuery.Append(" PG.UP_CLASS ,");
                    sbQuery.Append(" PGU.PRG_NAME AS UP_CLASS_NAME ,");
                    sbQuery.Append(" PG.MCLASS_FLAG,");
                    sbQuery.Append(" PG.PRG_TYPE, ");
                    sbQuery.Append(" PG.ORG_CODE");
                    sbQuery.Append(" FROM TSTD_PROCGRP PG ");
                    sbQuery.Append(" LEFT JOIN TSTD_PROCGRP PGU ");
                    sbQuery.Append(" ON PG.PLT_CODE = PGU.PLT_CODE");
                    sbQuery.Append(" AND PG.UP_CLASS = PGU.PRG_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PG.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PRG_CODE", "PG.PRG_CODE = @PRG_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PRG_NAME", "PG.PRG_NAME = @PRG_NAME"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PRG_CLASS", "PG.PRG_CLASS = @PRG_CLASS"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MCLASS_FLAG", "PG.MCLASS_FLAG = @MCLASS_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_OS", "PG.IS_OS = @IS_OS"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "PG.DATA_FLAG = @DATA_FLAG AND (PGU.DATA_FLAG = @DATA_FLAG  OR PGU.DATA_FLAG IS NULL)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PRG_TYPE", "PG.PRG_TYPE = @PRG_TYPE"));

                        sbWhere.Append(" ORDER BY PG.PRG_SEQ");

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
