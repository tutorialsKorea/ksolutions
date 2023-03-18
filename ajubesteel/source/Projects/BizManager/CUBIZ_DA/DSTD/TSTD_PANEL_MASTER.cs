using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizExecute;
using System.Data;

namespace DSTD
{
    public class TSTD_PANEL_MASTER
    {
        public static DataTable TSTD_PANEL_MASTER_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,PANEL_CODE ");
                    sbQuery.Append(" ,PANEL_NAME ");
                    sbQuery.Append(" ,CONN_TYPE ");
                    sbQuery.Append(" ,CONN_INFO ");
                    sbQuery.Append(" ,PANEL_SEQ ");
                    sbQuery.Append(" ,IS_ACCESS ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,MC_GROUP ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,MDFY_DATE ");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append(" ,DEL_DATE ");
                    sbQuery.Append(" ,DEL_EMP ");
                    sbQuery.Append(" ,DEL_REASON ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append("  FROM TSTD_PANEL_MASTER  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND PANEL_CODE = @PANEL_CODE  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PANEL_CODE")) isHasColumn = false;

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


        public static void TSTD_PANEL_MASTER_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TSTD_PANEL_MASTER (  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,PANEL_CODE ");
                    sbQuery.Append(" ,PANEL_NAME ");
                    sbQuery.Append(" ,CONN_TYPE ");
                    sbQuery.Append(" ,CONN_INFO ");
                    sbQuery.Append(" ,PANEL_SEQ ");
                    sbQuery.Append(" ,IS_ACCESS ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,MC_GROUP ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,DEL_REASON ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append("  ) VALUES (  ");
                    sbQuery.Append("  @PLT_CODE ");
                    sbQuery.Append(" ,@PANEL_CODE ");
                    sbQuery.Append(" ,@PANEL_NAME ");
                    sbQuery.Append(" ,@CONN_TYPE ");
                    sbQuery.Append(" ,@CONN_INFO ");
                    sbQuery.Append(" ,@PANEL_SEQ ");
                    sbQuery.Append(" ,@IS_ACCESS ");
                    sbQuery.Append(" ,@SCOMMENT ");
                    sbQuery.Append(" ,@MC_GROUP ");
                    sbQuery.Append(" ,GETDATE() ");
                    sbQuery.Append(" ,'" + ConnInfo.UserID + "' ");
                    sbQuery.Append(" ,@DEL_REASON ");
                    sbQuery.Append(" ,@DATA_FLAG ");
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


        public static void TSTD_PANEL_MASTER_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSTD_PANEL_MASTER SET  ");
                    sbQuery.Append("  PANEL_NAME = @PANEL_NAME ");
                    sbQuery.Append(" ,CONN_TYPE = @CONN_TYPE ");
                    sbQuery.Append(" ,CONN_INFO = @CONN_INFO ");
                    sbQuery.Append(" ,PANEL_SEQ = @PANEL_SEQ ");
                    sbQuery.Append(" ,IS_ACCESS = @IS_ACCESS ");
                    sbQuery.Append(" ,SCOMMENT = @SCOMMENT ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = '" + ConnInfo.UserID + "' ");
                    sbQuery.Append(" ,DEL_REASON = @DEL_REASON ");
                    sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append(" ,MC_GROUP = @MC_GROUP ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND PANEL_CODE = @PANEL_CODE ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PANEL_CODE")) isHasColumn = false;

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


        public static void TSTD_PANEL_MASTER_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSTD_PANEL_MASTER SET  ");                      
                    sbQuery.Append(" DEL_DATE = GETDATE() ");
                    sbQuery.Append(" ,DEL_EMP = '" + ConnInfo.UserID + "' ");
                    sbQuery.Append(" ,DEL_REASON = @DEL_REASON ");
                    sbQuery.Append(" ,DATA_FLAG = 2 ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND PANEL_CODE = @PANEL_CODE ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PANEL_CODE")) isHasColumn = false;

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

    public class TSTD_PANEL_MASTER_QUERY
    {       

        /// <summary>
        /// 공정 그룹 사용자정의 기본 쿼리
        /// </summary>
        /// <param name="dtParam"></param>
        /// <returns></returns>
        public static DataTable TSTD_PANEL_MASTER_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  A.PLT_CODE ");
                    sbQuery.Append(" ,A.PANEL_CODE ");
                    sbQuery.Append(" ,A.PANEL_NAME ");
                    sbQuery.Append(" ,A.CONN_TYPE ");
                    sbQuery.Append(" ,A.CONN_INFO ");
                    sbQuery.Append(" ,A.PANEL_SEQ ");
                    sbQuery.Append(" ,A.IS_ACCESS ");
                    sbQuery.Append(" ,A.SCOMMENT ");
                    sbQuery.Append(" ,A.REG_DATE ");
                    sbQuery.Append(" ,A.REG_EMP ");
                    sbQuery.Append(" ,REG.EMP_NAME AS REG_EMP_NAME ");
                    sbQuery.Append(" ,A.MDFY_DATE ");
                    sbQuery.Append(" ,A.MDFY_EMP ");
                    sbQuery.Append(" ,MDFY.EMP_NAME AS MDFY_EMP_NAME ");
                    sbQuery.Append(" ,A.DEL_DATE ");
                    sbQuery.Append(" ,A.DEL_EMP ");
                    sbQuery.Append(" ,A.DEL_REASON ");
                    sbQuery.Append(" ,A.DATA_FLAG ");
                    sbQuery.Append(" ,A.MC_GROUP ");
                    sbQuery.Append(" FROM TSTD_PANEL_MASTER A ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG");
                    sbQuery.Append(" ON A.PLT_CODE = REG.PLT_CODE");
                    sbQuery.Append(" AND A.REG_EMP = REG.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY");
                    sbQuery.Append(" ON A.PLT_CODE = MDFY.PLT_CODE");
                    sbQuery.Append(" AND A.MDFY_EMP = MDFY.EMP_CODE");
                    //sbQuery.Append(" LEFT JOIN TSTD_PANEL_POP P ");
                    //sbQuery.Append(" ON A.PLT_CODE = P.PLT_CODE ");
                    //sbQuery.Append(" AND A.PANEL_CODE = P.PANEL_CODE ");


                    foreach (DataRow row in dtParam.Rows)
                    {

                        StringBuilder sbWhere = new StringBuilder(" WHERE A.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PANEL_LIKE", "A.PANEL_NAME LIKE '%' + @PANEL_LIKE + '%' OR A.PANEL_CODE LIKE '%' + @PANEL_LIKE + '%' "));
                        //sbWhere.Append(UTIL.GetWhere(row, "@MAC_ADDR", "P.MAC = @MAC_ADDR "));
                        //sbWhere.Append(UTIL.GetWhere(row, "@LAN_IP,@WAN_IP", "A.CONN_INFO = @LAN_IP OR A.CONN_INFO = @WAN_IP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "A.DATA_FLAG = @DATA_FLAG"));
                     
                        sbWhere.Append(" ORDER BY A.PANEL_SEQ");

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
        /// 패널에 설정된 설비조회 (IP)
        /// </summary>
        /// <param name="dtParam"></param>
        /// <returns></returns>
        public static DataTable TSTD_PANEL_MASTER_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  A.PLT_CODE ");
                    //sbQuery.Append(" ,A.MAIN_MC AS MC_CODE ");
                    //sbQuery.Append(" ,MC.MC_NAME  ");
                    sbQuery.Append(" ,A.MC_GROUP ");
                    sbQuery.Append(" ,A.PANEL_CODE ");
                    sbQuery.Append(" ,A.PANEL_NAME ");
                    sbQuery.Append(" ,A.CONN_TYPE ");
                    sbQuery.Append(" ,A.CONN_INFO ");
                    sbQuery.Append(" ,A.PANEL_SEQ ");
                    sbQuery.Append(" ,A.IS_ACCESS ");
                    sbQuery.Append(" ,A.SCOMMENT ");
                    sbQuery.Append(" ,P.MC_CODE ");
                    sbQuery.Append(" ,MC.MC_NAME ");
                    sbQuery.Append(" ,A.REG_DATE ");
                    sbQuery.Append(" ,A.REG_EMP ");
                    sbQuery.Append(" ,REG.EMP_NAME AS REG_EMP_NAME ");
                    sbQuery.Append(" ,A.MDFY_DATE ");
                    sbQuery.Append(" ,A.MDFY_EMP ");
                    sbQuery.Append(" ,MDFY.EMP_NAME AS MDFY_EMP_NAME ");
                    sbQuery.Append(" ,A.DEL_DATE ");
                    sbQuery.Append(" ,A.DEL_EMP ");
                    sbQuery.Append(" ,A.DEL_REASON ");
                    sbQuery.Append(" ,A.DATA_FLAG ");
   
                    sbQuery.Append(" FROM TSTD_PANEL_MASTER A ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG");
                    sbQuery.Append(" ON A.PLT_CODE = REG.PLT_CODE");
                    sbQuery.Append(" AND A.REG_EMP = REG.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY");
                    sbQuery.Append(" ON A.PLT_CODE = MDFY.PLT_CODE");
                    sbQuery.Append(" AND A.MDFY_EMP = MDFY.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_PANEL_POP P ");
                    sbQuery.Append(" ON A.PLT_CODE = P.PLT_CODE ");
                    sbQuery.Append(" AND A.PANEL_CODE = P.PANEL_CODE ");
                    sbQuery.Append(" LEFT JOIN LSE_MACHINE MC");
                    sbQuery.Append(" ON P.PLT_CODE = MC.PLT_CODE");
                    sbQuery.Append(" AND P.MC_CODE = MC.MC_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE A.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PANEL_CODE", "A.PANEL_CODE = @PANEL_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PANEL_NAME_LIKE", "A.PANEL_NAME LIKE '%' + @PANEL_NAME_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAC_ADDR", "P.MAC = @MAC_ADDR"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@IP_ADDR", "A.CONN_INFO = @IP_ADDR"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@MAC_ADDR", "A.MAC_ADDR = @MAC_ADDR"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@PC_NAME", "A.PC_NAME = @PC_NAME"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "A.DATA_FLAG = @DATA_FLAG"));

                        sbWhere.Append(" ORDER BY A.PANEL_SEQ");

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
