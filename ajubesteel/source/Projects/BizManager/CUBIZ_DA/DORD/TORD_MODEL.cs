using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DORD
{
    public class TORD_MODEL
    {
        public static DataTable TORD_MODEL_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
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
                    sbQuery.Append(" ,VEN_CODE ");
                    sbQuery.Append(" ,DATA_TYPE ");
                    sbQuery.Append(" ,MODEL_CODE ");
                    sbQuery.Append(" ,MODEL_NAME ");
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
                    sbQuery.Append("  FROM TORD_MODEL  ");
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

        public static DataTable TORD_MODEL_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
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
                    sbQuery.Append(" ,VEN_CODE ");
                    sbQuery.Append(" ,DATA_TYPE ");
                    sbQuery.Append(" ,MODEL_CODE ");
                    sbQuery.Append(" ,MODEL_NAME ");
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
                    sbQuery.Append("  FROM TORD_MODEL  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND DATA_TYPE = @DATA_TYPE  ");
                    sbQuery.Append("  AND MODEL_NAME = @MODEL_NAME  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "DATA_TYPE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MODEL_NAME")) isHasColumn = false;

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



        public static void TORD_MODEL_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TORD_MODEL (  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,SCODE ");
                    sbQuery.Append(" ,P_SCODE ");
                    sbQuery.Append(" ,VEN_CODE ");
                    sbQuery.Append(" ,DATA_TYPE ");
                    sbQuery.Append(" ,MODEL_CODE ");
                    sbQuery.Append(" ,MODEL_NAME ");
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
                    sbQuery.Append(" ,@VEN_CODE ");
                    sbQuery.Append(" ,@DATA_TYPE ");
                    sbQuery.Append(" ,@MODEL_CODE ");
                    sbQuery.Append(" ,@MODEL_NAME ");
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

        public static void TORD_MODEL_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TORD_MODEL SET  ");
                    sbQuery.Append("  P_SCODE = @P_SCODE ");
                    sbQuery.Append(" ,VEN_CODE = @VEN_CODE ");
                    sbQuery.Append(" ,DATA_TYPE = @DATA_TYPE ");
                    sbQuery.Append(" ,MODEL_CODE = @MODEL_CODE ");
                    sbQuery.Append(" ,MODEL_NAME = @MODEL_NAME ");
                    sbQuery.Append(" ,USE_FLAG = @USE_FLAG ");
                    sbQuery.Append(" ,SCOMMENT = @SCOMMENT ");
                    sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append(" ,MDFY_EMP = '" + ConnInfo.UserID + "' ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
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


        public static void TORD_MODEL_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TORD_MODEL SET  ");                                        
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

        public static void TORD_MODEL_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" DELETE FROM TORD_MODEL	   ");                   
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

    public class TORD_MODEL_QUERY
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TORD_MODEL_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
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
                    sbQuery.Append(" ,A.VEN_CODE ");
                    sbQuery.Append(" ,A.DATA_TYPE ");
                    sbQuery.Append(" ,A.MODEL_CODE ");
                    sbQuery.Append(" ,A.MODEL_NAME ");
                    sbQuery.Append(" ,A.USE_FLAG ");
                    sbQuery.Append(" ,A.SCOMMENT ");
                    sbQuery.Append(" FROM TORD_MODEL A");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE A.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());                        
                        sbWhere.Append(UTIL.GetWhere(row, "@SCODE", "A.SCODE = @SCODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MODEL_CODE", "A.MODEL_CODE = @MODEL_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_TYPE", "A.DATA_TYPE = @DATA_TYPE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@P_SCODE", "A.P_SCODE = @P_SCODE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@VEN_CODE", "A.VEN_CODE = @VEN_CODE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@USE_FLAG", "A.USE_FLAG = @USE_FLAG"));

                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "A.DATA_FLAG = @DATA_FLAG"));

                        sbWhere.Append(" ORDER BY A.PLT_CODE,A.REG_DATE");
 

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


        public static DataTable TORD_MODEL_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
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
                    sbQuery.Append(" ,A.VEN_CODE ");
                    sbQuery.Append(" ,B.VEN_NAME ");
                    sbQuery.Append(" ,A.DATA_TYPE ");
                    sbQuery.Append(" ,A.MODEL_CODE ");
                    sbQuery.Append(" ,A.MODEL_NAME ");
                    sbQuery.Append(" ,A.USE_FLAG ");
                    sbQuery.Append(" ,A.SCOMMENT ");
                    sbQuery.Append(" FROM TORD_MODEL A");
                    sbQuery.Append(" JOIN TSTD_VENDOR B");
                    sbQuery.Append(" ON A.PLT_CODE = B.PLT_CODE");
                    sbQuery.Append(" AND A.VEN_CODE = B.VEN_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE A.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                       
                        sbWhere.Append(UTIL.GetWhere(row, "@MODEL_CODE", "A.MODEL_CODE = @MODEL_CODE"));
                        
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_TYPE", "A.DATA_TYPE = @DATA_TYPE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@P_SCODE", "A.P_SCODE = @P_SCODE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@VEN_CODE", "A.VEN_CODE = @VEN_CODE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "A.DATA_FLAG = @DATA_FLAG"));

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

        public static DataTable TORD_MODEL_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
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
                    sbQuery.Append(" ,A.VEN_CODE ");
                    sbQuery.Append(" ,A.DATA_TYPE ");
                    sbQuery.Append(" ,A.MODEL_CODE ");
                    sbQuery.Append(" ,A.MODEL_NAME ");
                    sbQuery.Append(" ,A.USE_FLAG ");
                    sbQuery.Append(" ,A.SCOMMENT ");
                    sbQuery.Append(" FROM TORD_MODEL A");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE A.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@MODEL_LIKE", "(A.MODEL_CODE LIKE '%' + @MODEL_LIKE + '%' OR A.MODEL_NAME LIKE '%' + @MODEL_LIKE + '%')"));

                        sbWhere.Append(UTIL.GetWhere(row, "@P_SCODE", "A.P_SCODE = @P_SCODE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "A.DATA_FLAG = @DATA_FLAG"));

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

        public static DataTable TORD_MODEL_QUERY4(DataTable dtParam, BizExecute.BizExecute bizExecute)
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
                    sbQuery.Append(" ,A.VEN_CODE ");
                    sbQuery.Append(" ,A.DATA_TYPE ");
                    sbQuery.Append(" ,A.MODEL_CODE ");
                    sbQuery.Append(" ,A.MODEL_NAME ");
                    sbQuery.Append(" ,A.USE_FLAG ");
                    sbQuery.Append(" ,A.SCOMMENT ");
                    sbQuery.Append(" ,ML.LOCK_FLAG ");
                    sbQuery.Append(" ,ML.EMP_CODE ");
                    sbQuery.Append(" ,E.EMP_NAME ");
                    sbQuery.Append(" FROM TORD_MODEL A");
                    sbQuery.Append(" LEFT JOIN TORD_MODEL_LOCK ML");
                    sbQuery.Append(" ON A.PLT_CODE = ML.PLT_CODE");
                    sbQuery.Append(" AND A.SCODE = ML.SCODE");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E");
                    sbQuery.Append(" ON ML.PLT_CODE = E.PLT_CODE");
                    sbQuery.Append(" AND ML.EMP_CODE = E.EMP_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V");
                    sbQuery.Append(" ON A.PLT_CODE = V.PLT_CODE");
                    sbQuery.Append(" AND A.VEN_CODE = V.VEN_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE A.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@SCODE", "A.SCODE = @SCODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MODEL_CODE", "A.MODEL_CODE = @MODEL_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_TYPE", "A.DATA_TYPE = @DATA_TYPE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@P_SCODE", "A.P_SCODE = @P_SCODE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@VEN_CODE", "A.VEN_CODE = @VEN_CODE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@USE_FLAG", "A.USE_FLAG = @USE_FLAG"));

                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "A.DATA_FLAG = @DATA_FLAG"));

                        sbWhere.Append(" ORDER BY A.PLT_CODE, A.MODEL_NAME, V.VEN_NAME,A.REG_DATE");

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
