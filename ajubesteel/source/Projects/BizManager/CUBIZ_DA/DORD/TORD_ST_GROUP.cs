using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DORD
{
    public class TORD_ST_GROUP
    {
        public static DataTable TORD_ST_GROUP_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
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
                    sbQuery.Append(" ,ST_CODE ");
                    sbQuery.Append(" ,ST_TIME ");
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
                    sbQuery.Append("  FROM TORD_ST_GROUP  ");
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



        public static void TORD_ST_GROUP_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TORD_ST_GROUP (  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,SCODE ");
                    sbQuery.Append(" ,P_SCODE ");
                    sbQuery.Append(" ,DATA_TYPE ");
                    sbQuery.Append(" ,ST_CODE ");
                    sbQuery.Append(" ,ST_TIME ");
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
                    sbQuery.Append(" ,@ST_CODE ");
                    sbQuery.Append(" ,@ST_TIME ");
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


        public static void TORD_ST_GROUP_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TORD_ST_GROUP SET  ");
                    sbQuery.Append("  P_SCODE = @P_SCODE ");
                    sbQuery.Append(" ,DATA_TYPE = @DATA_TYPE ");
                    sbQuery.Append(" ,ST_CODE = @ST_CODE ");
                    sbQuery.Append(" ,ST_TIME = @ST_TIME ");
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



        public static void TORD_ST_GROUP_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TORD_ST_GROUP SET  ");                                        
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

        public static void TORD_ST_GROUP_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" DELETE FROM TORD_ST_GROUP	   ");                   
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

    public class TORD_ST_GROUP_QUERY
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TORD_ST_GROUP_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
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
                    sbQuery.Append(" ,A.ST_CODE ");
                    sbQuery.Append(" ,A.ST_TIME ");
                    sbQuery.Append(" ,A.USE_FLAG ");
                    sbQuery.Append(" ,A.SCOMMENT ");
                    sbQuery.Append(" FROM TORD_ST_GROUP A");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE A.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());                        
                        sbWhere.Append(UTIL.GetWhere(row, "@SCODE", "A.SCODE = @SCODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@ST_CODE", "A.ST_CODE = @ST_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_TYPE", "A.DATA_TYPE = @DATA_TYPE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@P_SCODE", "A.P_SCODE = @P_SCODE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "A.DATA_FLAG = @DATA_FLAG"));

                        sbWhere.Append(" ORDER BY A.PLT_CODE,A.ST_CODE");
 

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


        public static DataTable TORD_ST_GROUP_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
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
                    sbQuery.Append(" ,A.CD_CODE AS ST_CODE ");
                    sbQuery.Append(" ,0 AS ST_TIME ");
                    sbQuery.Append(" ,'1' AS USE_FLAG ");
                    sbQuery.Append(" ,A.SCOMMENT ");
                    sbQuery.Append(" FROM TSTD_CODES A");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE A.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        //sbWhere.Append(UTIL.GetWhere(row, "@SCODE", "A.SCODE = @SCODE"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@ST_CODE", "A.ST_CODE = @ST_CODE"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@DATA_TYPE", "A.DATA_TYPE = @DATA_TYPE"));

                        //sbWhere.Append(UTIL.GetWhere(row, "@P_SCODE", "A.P_SCODE = @P_SCODE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "A.DATA_FLAG = @DATA_FLAG"));

                        sbWhere.Append(" AND A.CAT_CODE = 'C020' ");

                        sbWhere.Append(" ORDER BY A.PLT_CODE,A.CD_SEQ");


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
