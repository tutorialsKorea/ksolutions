using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSTD
{
    public class TSTD_ROUTING
    {
        public static DataTable TSTD_ROUTING_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,SCODE ");
                    sbQuery.Append(" ,P_SCODE ");
                    sbQuery.Append(" ,DATA_TYPE ");
                    sbQuery.Append(" ,ROUT_CODE ");
                    sbQuery.Append(" ,ROUT_FLAG ");
                    sbQuery.Append(" ,ROUT_SEQ ");
                    sbQuery.Append(" ,USE_FLAG ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append(" ,MDFY_DATE ");
                    sbQuery.Append(" ,DEL_EMP ");
                    sbQuery.Append(" ,DEL_DATE ");
                    sbQuery.Append(" ,DEL_REASON ");
                    sbQuery.Append("  FROM TSTD_ROUTING  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND SCODE = @SCODE  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "SCODE")) isHasColumn = false;

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
        /// 생산계획 생성시 표준 라우팅 불러오기
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TSTD_ROUTING_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT DISTINCT * FROM  (");
                    sbQuery.Append(" SELECT ");
                    sbQuery.Append("  SP.PLT_CODE ");
                    sbQuery.Append(" ,A.SCODE ");
                    sbQuery.Append(" ,A.P_SCODE ");
                    sbQuery.Append(" ,A.DATA_TYPE ");
                    sbQuery.Append(" ,SP.PROC_CODE AS ROUT_CODE ");
                    sbQuery.Append(" ,SP.PROC_NAME AS ROUT_NAME ");
                    sbQuery.Append(" ,SP.PROC_CODE ");
                    sbQuery.Append(" ,SP.PROC_NAME ");
                    sbQuery.Append(" ,A.ROUT_FLAG AS PROC_FLAG ");
                    sbQuery.Append(" ,A.ROUT_FLAG ");
                    sbQuery.Append(" ,A.ROUT_SEQ ");
                    sbQuery.Append(" ,A.USE_FLAG ");
                    sbQuery.Append(" ,A.SCOMMENT ");
                    sbQuery.Append(" ,SP.PROC_MAN_TIME ");
                    sbQuery.Append(" ,SP.MAIN_VND ");
                    sbQuery.Append(" ,SP.IS_OS ");
                    sbQuery.Append(" ,SP.WO_TYPE ");
                    sbQuery.Append(" ,SP.WORK_START_TIME ");
                    sbQuery.Append(" ,SP.WORK_END_TIME ");
                    sbQuery.Append(" ,SP.PROC_SEQ ");
                    sbQuery.Append(" FROM LSE_STD_PROC SP");
                    sbQuery.Append(" LEFT JOIN TSTD_ROUTING A ");
                    sbQuery.Append(" ON A.PLT_CODE = SP.PLT_CODE ");
                    sbQuery.Append(" AND A.ROUT_CODE = SP.PROC_CODE ");
                    sbQuery.Append(" LEFT JOIN TSTD_ROUTING B ");
                    sbQuery.Append(" ON A.PLT_CODE = B.PLT_CODE ");
                    sbQuery.Append(" AND A.P_SCODE = B.SCODE ");
                    sbQuery.Append("  WHERE SP.PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND B.ROUT_CODE = @ROUT_CODE  ");
                    sbQuery.Append("  AND SP.DATA_FLAG = 0  ");
                    sbQuery.Append("  AND A.ROUT_FLAG = 1   ");
                    sbQuery.Append("  AND A.DATA_TYPE = 'M'  ");

                    if (dtParam.Columns.Contains("IS_SIDE"))
                    {
                        if (dtParam.Rows[0]["IS_SIDE"].ToString() == "1")
                        {
                            sbQuery.Append(" UNION ALL");
                            sbQuery.Append(" SELECT");
                            sbQuery.Append(" SP.PLT_CODE");
                            sbQuery.Append(" ,A.SCODE");
                            sbQuery.Append(" ,A.P_SCODE");
                            sbQuery.Append(" ,A.DATA_TYPE");
                            sbQuery.Append(" ,SP.PROC_CODE AS ROUT_CODE");
                            sbQuery.Append(" ,SP.PROC_NAME AS ROUT_NAME");
                            sbQuery.Append(" ,SP.PROC_CODE");
                            sbQuery.Append(" ,SP.PROC_NAME");
                            sbQuery.Append(" ,A.ROUT_FLAG AS PROC_FLAG");
                            sbQuery.Append(" ,A.ROUT_FLAG");
                            sbQuery.Append(" ,A.ROUT_SEQ");
                            sbQuery.Append(" ,A.USE_FLAG");
                            sbQuery.Append(" ,A.SCOMMENT");
                            sbQuery.Append(" ,SP.PROC_MAN_TIME");
                            sbQuery.Append(" ,SP.MAIN_VND");
                            sbQuery.Append(" ,SP.IS_OS");
                            sbQuery.Append(" ,SP.WO_TYPE");
                            sbQuery.Append(" ,SP.WORK_START_TIME");
                            sbQuery.Append(" ,SP.WORK_END_TIME");
                            sbQuery.Append(" ,SP.PROC_SEQ");
                            sbQuery.Append(" FROM LSE_STD_PROC SP");
                            sbQuery.Append(" LEFT JOIN TSTD_ROUTING A");
                            sbQuery.Append(" ON A.PLT_CODE = SP.PLT_CODE");
                            sbQuery.Append(" AND A.ROUT_CODE = SP.PROC_CODE");
                            sbQuery.Append(" LEFT JOIN TSTD_ROUTING B");
                            sbQuery.Append(" ON A.PLT_CODE = B.PLT_CODE");
                            sbQuery.Append(" AND A.P_SCODE = B.SCODE");
                            sbQuery.Append("  WHERE SP.PLT_CODE = @PLT_CODE  ");
                            sbQuery.Append("  AND B.ROUT_CODE = @ROUT_CODE  ");
                            sbQuery.Append(" AND SP.PROC_CODE = 'P-07'");
                            sbQuery.Append(" AND A.DATA_TYPE = 'M'");

                        }
                    }


                    sbQuery.Append("  )A ORDER BY PLT_CODE,PROC_SEQ  ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "ROUT_CODE")) isHasColumn = false;

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

        public static void TSTD_ROUTING_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TSTD_ROUTING (  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,SCODE ");
                    sbQuery.Append(" ,P_SCODE ");
                    sbQuery.Append(" ,DATA_TYPE ");
                    sbQuery.Append(" ,ROUT_CODE ");
                    sbQuery.Append(" ,ROUT_FLAG ");
                    sbQuery.Append(" ,ROUT_SEQ ");
                    sbQuery.Append(" ,USE_FLAG ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append(" ,DEL_REASON ");
                    sbQuery.Append("  ) VALUES (  ");
                    sbQuery.Append("  @PLT_CODE ");
                    sbQuery.Append(" ,@SCODE ");
                    sbQuery.Append(" ,@P_SCODE ");
                    sbQuery.Append(" ,@DATA_TYPE ");
                    sbQuery.Append(" ,@ROUT_CODE ");
                    sbQuery.Append(" ,@ROUT_FLAG ");
                    sbQuery.Append(" ,@ROUT_SEQ ");
                    sbQuery.Append(" ,@USE_FLAG ");
                    sbQuery.Append(" ,@SCOMMENT ");
                    sbQuery.Append(" ,'" + ConnInfo.UserID + "' ");
                    sbQuery.Append(" ,GETDATE() ");
                    sbQuery.Append(" ,@DATA_FLAG ");
                    sbQuery.Append(" ,@DEL_REASON ");
                    sbQuery.Append("  ) ");

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



        public static void TSTD_ROUTING_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSTD_ROUTING SET  ");
                    sbQuery.Append("  P_SCODE = @P_SCODE ");
                    sbQuery.Append(" ,DATA_TYPE = @DATA_TYPE ");
                    sbQuery.Append(" ,ROUT_CODE = @ROUT_CODE ");
                    sbQuery.Append(" ,ROUT_FLAG = @ROUT_FLAG ");
                    sbQuery.Append(" ,ROUT_SEQ = @ROUT_SEQ ");
                    sbQuery.Append(" ,USE_FLAG = @USE_FLAG ");
                    sbQuery.Append(" ,SCOMMENT = @SCOMMENT ");
                    sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append(" ,MDFY_EMP = '" + ConnInfo.UserID + "' ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,DEL_REASON = @DEL_REASON ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND SCODE = @SCODE ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "SCODE")) isHasColumn = false;

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



        public static void TSTD_ROUTING_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSTD_ROUTING SET  ");                                        
                    sbQuery.Append(" DATA_FLAG = 2 ");
                    sbQuery.Append(" ,DEL_EMP = '" + ConnInfo.UserID + "' ");
                    sbQuery.Append(" ,DEL_DATE = GETDATE() ");
                    sbQuery.Append(" ,DEL_REASON = @DEL_REASON ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND SCODE = @SCODE ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "SCODE")) isHasColumn = false;

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

        public static void TSTD_ROUTING_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" DELETE FROM TSTD_ROUTING	   ");                   
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND SCODE = @SCODE	   ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "SCODE")) isHasColumn = false;
                        
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

    public class TSTD_ROUTING_QUERY
    {
        /// <summary>
        /// 표준 공정 라우팅 공정 그룹 불러오기
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TSTD_ROUTING_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT ");
                    sbQuery.Append("  A.PLT_CODE ");
                    sbQuery.Append(" ,A.SCODE ");
                    sbQuery.Append(" ,A.P_SCODE ");
                    sbQuery.Append(" ,A.DATA_TYPE ");
                    sbQuery.Append(" ,A.ROUT_CODE ");
                    sbQuery.Append(" ,SP.PROC_NAME AS ROUT_NAME ");
                    sbQuery.Append(" ,A.ROUT_FLAG ");
                    sbQuery.Append(" ,A.ROUT_SEQ ");
                    sbQuery.Append(" ,A.USE_FLAG ");
                    sbQuery.Append(" ,A.SCOMMENT ");
                    sbQuery.Append(" FROM TSTD_ROUTING A");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC SP ");
                    sbQuery.Append(" ON A.PLT_CODE = SP.PLT_CODE ");
                    sbQuery.Append(" AND A.ROUT_CODE = SP.PROC_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE A.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());                        
                        sbWhere.Append(UTIL.GetWhere(row, "@SCODE", "A.SCODE = @SCODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@ROUT_CODE", "A.ROUT_CODE = @ROUT_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_TYPE", "A.DATA_TYPE = @DATA_TYPE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@P_SCODE", "A.P_SCODE = @P_SCODE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "A.DATA_FLAG = @DATA_FLAG"));

                        //sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "SP.DATA_FLAG = @DATA_FLAG"));

                        sbWhere.Append(" ORDER BY A.PLT_CODE,A.ROUT_CODE");
 

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
        /// 표준 공정 라우팅 공정 리스트 불러오기(기본값)
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TSTD_ROUTING_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT ");
                    sbQuery.Append("  A.PLT_CODE ");
                    sbQuery.Append(" ,null AS SCODE ");
                    sbQuery.Append(" ,null AS P_SCODE ");
                    sbQuery.Append(" ,'M' AS DATA_TYPE ");
                    sbQuery.Append(" ,A.PROC_CODE AS ROUT_CODE ");
                    sbQuery.Append(" ,A.PROC_NAME AS ROUT_NAME ");
                    sbQuery.Append(" ,A.PROC_SEQ AS ROUT_SEQ ");
                    sbQuery.Append(" ,'0' AS ROUT_FLAG ");
                    sbQuery.Append(" ,null AS SCOMMENT ");
                    sbQuery.Append(" FROM LSE_STD_PROC A");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE A.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        //sbWhere.Append(UTIL.GetWhere(row, "@SCODE", "A.SCODE = @SCODE"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@ST_CODE", "A.ST_CODE = @ST_CODE"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@DATA_TYPE", "A.DATA_TYPE = @DATA_TYPE"));

                        //sbWhere.Append(UTIL.GetWhere(row, "@P_SCODE", "A.P_SCODE = @P_SCODE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "A.DATA_FLAG = @DATA_FLAG"));

                        sbWhere.Append(" ORDER BY A.PLT_CODE,A.PROC_CODE,A.PROC_SEQ");


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
        /// 표준 라우팅 공정 리스트 불러오기
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TSTD_ROUTING_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT ");
                    sbQuery.Append("  SP.PLT_CODE ");
                    sbQuery.Append(" ,A.SCODE ");
                    sbQuery.Append(" ,A.P_SCODE ");
                    sbQuery.Append(" ,A.DATA_TYPE ");
                    sbQuery.Append(" ,SP.PROC_CODE AS ROUT_CODE ");
                    sbQuery.Append(" ,SP.PROC_NAME AS ROUT_NAME ");
                    sbQuery.Append(" ,SP.PROC_CODE ");
                    sbQuery.Append(" ,SP.PROC_NAME ");
                    sbQuery.Append(" ,A.ROUT_FLAG AS PROC_FLAG ");
                    sbQuery.Append(" ,A.ROUT_FLAG ");
                    sbQuery.Append(" ,A.ROUT_SEQ ");
                    sbQuery.Append(" ,A.USE_FLAG ");
                    sbQuery.Append(" ,A.SCOMMENT ");
                    sbQuery.Append(" FROM LSE_STD_PROC SP");
                    sbQuery.Append(" LEFT JOIN TSTD_ROUTING A ");
                    sbQuery.Append(" ON A.PLT_CODE = SP.PLT_CODE ");
                    sbQuery.Append(" AND A.ROUT_CODE = SP.PROC_CODE ");
                    sbQuery.Append(" AND A.P_SCODE = @P_SCODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE SP.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@SCODE", "A.SCODE = @SCODE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@ROUT_CODE", "SP.PROC_CODE = @ROUT_CODE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_TYPE", "A.DATA_TYPE = @DATA_TYPE OR A.DATA_TYPE IS NULL"));

                        //sbWhere.Append(UTIL.GetWhere(row, "@P_SCODE", "A.P_SCODE = @P_SCODE OR A.P_SCODE IS NULL "));

                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "SP.DATA_FLAG = @DATA_FLAG"));

                        sbWhere.Append(UTIL.GetWhere(row, "@PROC_FLAG", "A.ROUT_FLAG = 1 "));

                        sbWhere.Append(" ORDER BY SP.PLT_CODE,SP.PROC_SEQ ");


                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(),row).Copy();

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
        /// 생산계획 생성시 표준 라우팅 불러오기
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TSTD_ROUTING_QUERY4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT ");
                    sbQuery.Append("  SP.PLT_CODE ");
                    sbQuery.Append(" ,A.SCODE ");
                    sbQuery.Append(" ,A.P_SCODE ");
                    sbQuery.Append(" ,A.DATA_TYPE ");
                    sbQuery.Append(" ,SP.PROC_CODE AS ROUT_CODE ");
                    sbQuery.Append(" ,SP.PROC_NAME AS ROUT_NAME ");
                    sbQuery.Append(" ,SP.PROC_CODE ");
                    sbQuery.Append(" ,SP.PROC_NAME ");
                    sbQuery.Append(" ,A.ROUT_FLAG AS PROC_FLAG ");
                    sbQuery.Append(" ,A.ROUT_FLAG ");
                    sbQuery.Append(" ,A.ROUT_SEQ ");
                    sbQuery.Append(" ,A.USE_FLAG ");
                    sbQuery.Append(" ,A.SCOMMENT ");
                    sbQuery.Append(" FROM LSE_STD_PROC SP");
                    sbQuery.Append(" LEFT JOIN TSTD_ROUTING A ");
                    sbQuery.Append(" ON A.PLT_CODE = SP.PLT_CODE ");
                    sbQuery.Append(" AND A.ROUT_CODE = SP.PROC_CODE ");
                    sbQuery.Append(" LEFT JOIN TSTD_ROUTING B ");
                    sbQuery.Append(" ON A.PLT_CODE = B.PLT_CODE ");
                    sbQuery.Append(" AND A.P_SCODE = B.SCODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE SP.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        //sbWhere.Append(UTIL.GetWhere(row, "@SCODE", "A.SCODE = @SCODE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@ROUT_CODE", "B.ROUT_CODE = @ROUT_CODE"));

                        //sbWhere.Append(UTIL.GetWhere(row, "@P_SCODE", "A.P_SCODE = @P_SCODE OR A.P_SCODE IS NULL "));

                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "SP.DATA_FLAG = @DATA_FLAG"));

                        sbWhere.Append(" AND A.ROUT_FLAG = 1 ");

                        sbWhere.Append(" AND A.DATA_TYPE = 'M' ");

                        sbWhere.Append(" ORDER BY SP.PLT_CODE,SP.PROC_SEQ ");


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
