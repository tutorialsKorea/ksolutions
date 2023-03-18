using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizExecute;
using System.Data;

namespace DSTD
{
    public class TSTD_PROCPLAN
    {
        public static DataTable TSTD_PROCPLAN_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" , PLN_CODE");
                    sbQuery.Append(" , PLN_PROC ");
                    sbQuery.Append(" , LOADABLE_MC");
                    sbQuery.Append(" , PLN_SEQ");
                    sbQuery.Append(" , PLN_SELF_TIME ");
                    sbQuery.Append(" , PLN_MAN_TIME ");         
                    sbQuery.Append(" FROM TSTD_PROCPLAN ");
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


        public static DataTable TSTD_PROCPLAN_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLN.PLT_CODE");
                    sbQuery.Append(" ,PLN.PLN_CODE");
                    sbQuery.Append(" ,PLN.PLN_PROC");
                    sbQuery.Append(" ,PLN_PROC_NAME = PRC.PROC_NAME ");
                    sbQuery.Append(" ,PLN.LOADABLE_MC ");
                    sbQuery.Append(" ,PRC.PROC_COLOR");
                    sbQuery.Append(" ,PLN.PLN_SEQ ");
                    sbQuery.Append(" ,PLN.PLN_SELF_TIME ");
                    sbQuery.Append(" ,PLN.PLN_MAN_TIME");
                    sbQuery.Append(" FROM TSTD_PROCPLAN PLN ");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC PRC ON PLN.PLT_CODE = PRC.PLT_CODE AND PLN.PLN_PROC = PRC.PROC_CODE ");
                    sbQuery.Append(" WHERE PLN.PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND PLN.PLN_CODE = @PLN_CODE ");

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

        public static DataTable TSTD_PROCPLAN_SER3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" , PLN_CODE");
                    sbQuery.Append(" , PLN_PROC ");
                    sbQuery.Append(" , LOADABLE_MC");
                    sbQuery.Append(" , PLN_SEQ");
                    sbQuery.Append(" , PLN_SELF_TIME ");
                    sbQuery.Append(" , PLN_MAN_TIME ");
                    sbQuery.Append(" FROM TSTD_PROCPLAN ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PLN_PROC = @PLN_PROC");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLN_PROC")) isHasColumn = false;

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

        /// <summary>
        /// 해당공정을 사용하고있는 표준공정계획 마스터를 조회한다.
        /// </summary>
        /// <param name="dtParam"></param>
        /// <returns></returns>
        public static DataTable TSTD_PROCPLAN_SER4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" P.PLT_CODE");
                    sbQuery.Append(" , P.PLN_CODE");
                    sbQuery.Append(" FROM TSTD_PROCPLAN P");
                    sbQuery.Append(" LEFT JOIN TSTD_PROCPLAN_MASTER PM ");
                    sbQuery.Append(" ON P.PLT_CODE = PM.PLT_CODE ");
                    sbQuery.Append(" AND P.PLN_CODE = PM.PLN_CODE");
                    sbQuery.Append(" WHERE P.PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND P.PLN_PROC = @PLN_PROC");
                    sbQuery.Append(" AND PM.DATA_FLAG = 0");
                    sbQuery.Append(" GROUP BY P.PLT_CODE , P.PLN_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLN_PROC")) isHasColumn = false;

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
        

        public static void TSTD_PROCPLAN_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSTD_PROCPLAN ");
                    sbQuery.Append(" SET LOADABLE_MC = @LOADABLE_MC");                    
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PLN_CODE  = @PLN_CODE ");
                    sbQuery.Append(" AND PLN_PROC  = @PLN_PROC ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLN_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PLN_PROC ")) isHasColumn = false;

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
        /// 표준공정 기준 시간 수정
        /// </summary>
        /// <param name="dtParam"></param>
        public static void TSTD_PROCPLAN_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSTD_PROCPLAN ");
                    sbQuery.Append(" SET PLN_SELF_TIME  = @PLN_SELF_TIME ");
                    sbQuery.Append(" , PLN_MAN_TIME   = @PLN_MAN_TIME  ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PLN_CODE  = @PLN_CODE ");
                    sbQuery.Append(" AND PLN_SEQ   = @PLN_SEQ  ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLN_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PLN_SEQ  ")) isHasColumn = false;

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

        public static void TSTD_PROCPLAN_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append("DELETE FROM TSTD_PROCPLAN SET");                    
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PLN_CODE = @PLN_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLN_CODE")) isHasColumn = false;                        

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

        public static void TSTD_PROCPLAN_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO TSTD_PROCPLAN ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" , PLN_CODE");
                    sbQuery.Append(" , PLN_PROC");
                    sbQuery.Append(" , LOADABLE_MC ");
                    sbQuery.Append(" , PLN_SEQ ");
                    sbQuery.Append(" , PLN_SELF_TIME ");
                    sbQuery.Append(" , PLN_MAN_TIME");
                    sbQuery.Append(" ) ");
                    sbQuery.Append(" VALUES");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" @PLT_CODE ");
                    sbQuery.Append(" , @PLN_CODE ");
                    sbQuery.Append(" , @PLN_PROC ");
                    sbQuery.Append(" , @LOADABLE_MC");
                    sbQuery.Append(" , @PLN_SEQ");
                    sbQuery.Append(" , @PLN_SELF_TIME");
                    sbQuery.Append(" , @PLN_MAN_TIME ");
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

    public class TSTD_PROCPLAN_QUERY
    {
        /// <summary>
        /// 공정 그룹 사용자정의 기본 쿼리
        /// </summary>
        /// <param name="dtParam"></param>
        /// <returns></returns>
        public static DataTable TSTD_PROCPLAN_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" , PLN_CODE");
                    sbQuery.Append(" , PLN_PROC ");
                    sbQuery.Append(" , LOADABLE_MC");
                    sbQuery.Append(" , PLN_SEQ");
                    sbQuery.Append(" , PLN_SELF_TIME ");
                    sbQuery.Append(" , PLN_MAN_TIME ");
                    sbQuery.Append(" FROM TSTD_PROCPLAN ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        
                        sbWhere.Append(UTIL.GetWhere(row, "@PLN_CODE", "PLN_CODE = @PLN_CODE"));

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
