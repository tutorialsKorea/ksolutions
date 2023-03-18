using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizExecute;
using System.Data;

namespace DPOP
{
    public class TPOP_MC_STATUS
    {
        public static DataTable TPOP_MC_STATUS_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT M.PLT_CODE,   ");
                    sbQuery.Append(" 	M.MC_CODE,           ");
                    sbQuery.Append(" 	M.MC_NAME,           ");
                    sbQuery.Append(" 	M.MC_IMAGE,           ");
                    sbQuery.Append(" 	M.MC_MODEL,           ");
                    sbQuery.Append(" 	S.STS_CODE,            ");
                    sbQuery.Append(" 	S.PROD_INFO,          ");
                    sbQuery.Append(" 	S.UPDATE_DATE        ");
                    sbQuery.Append(" FROM LSE_MACHINE M JOIN TPOP_MC_STATUS S ");
                    sbQuery.Append(" ON M.PLT_CODE = S.PLT_CODE ");
                    sbQuery.Append(" AND M.MC_CODE = S.MC_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString(), row).Copy();

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

    public class TPOP_MC_STATUS_QUERY
    {
        public static DataTable TPOP_MC_STATUS_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" MS.PLT_CODE");
                    sbQuery.Append(" ,MS.MC_CODE");
                    sbQuery.Append(" ,M.MC_NAME");
                    sbQuery.Append(" ,M.MC_MNT_NAME");
                    sbQuery.Append(" ,CASE WHEN DATEDIFF(SECOND,MS.UPDATE_TIME, GETDATE()) > 60 THEN '88' ELSE MS.STS_CODE END AS STS_CODE");
                    sbQuery.Append(" ,CASE WHEN MS.STS_CODE = '2' THEN '가동' WHEN MS.STS_CODE = '3' THEN '중지' WHEN MS.STS_CODE = '9' THEN '알람' END AS STS_NAME");
                    sbQuery.Append(" ,MS.UPDATE_TIME");
                    sbQuery.Append(" ,MS.TOOL_NO");
                    sbQuery.Append(" ,M.MC_SEQ");
                    sbQuery.Append(" ,A.OK_QTY");
                    sbQuery.Append(" FROM TPOP_MC_STATUS MS");
                    sbQuery.Append(" LEFT JOIN LSE_MACHINE M");
                    sbQuery.Append(" ON MS.PLT_CODE = M.PLT_CODE");
                    sbQuery.Append(" AND MS.MC_CODE = M.MC_CODE");

                    sbQuery.Append(" LEFT JOIN");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" A.PLT_CODE, A.MC_CODE, SUM(OK_QTY) AS OK_QTY");
                    sbQuery.Append(" FROM TSHP_ACTUAL A WITH(NOLOCK)");
                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER W WITH(NOLOCK)");
                    sbQuery.Append(" ON A.PLT_CODE = W.PLT_CODE");
                    sbQuery.Append(" AND A.WO_NO = W.WO_NO");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P");
                    sbQuery.Append(" ON W.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND W.PROD_CODE = P.PROD_CODE");
                    sbQuery.Append(" WHERE WORK_DATE = CONVERT(VARCHAR(8), GETDATE(), 112)");
                    sbQuery.Append(" AND W.DATA_FLAG = '0' AND P.DATA_FLAG = '0'");
                    sbQuery.Append(" GROUP BY A.PLT_CODE, A.MC_CODE");
                    sbQuery.Append(" ) A");
                    sbQuery.Append(" ON MS.PLT_CODE = A.PLT_CODE");
                    sbQuery.Append(" AND MS.MC_CODE = A.MC_CODE");




                    foreach (DataRow row in dtParam.Rows)
                    {

                        StringBuilder sbWhere = new StringBuilder(" WHERE MS.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

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

        public static DataTable TPOP_MC_STATUS_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT * FROM");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" A.PLT_CODE");
                    sbQuery.Append(" ,A.MC_CODE");
                    sbQuery.Append(" ,RIGHT(W.PROD_CODE, 11) AS PROD_CODE");
                    sbQuery.Append(" ,W.PART_CODE");
                    sbQuery.Append(" ,SP.PART_NAME");
                    sbQuery.Append(" ,A.ACT_START_TIME");
                    sbQuery.Append(" ,A.ACT_END_TIME");
                    sbQuery.Append(" ,ROW_NUMBER() OVER(PARTITION BY A.MC_CODE ORDER BY A.ACT_START_TIME DESC, W.PROD_CODE DESC) SEQ");
                    sbQuery.Append(" FROM TSHP_ACTUAL A WITH(NOLOCK)");
                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER W WITH(NOLOCK)");
                    sbQuery.Append(" ON A.PLT_CODE = W.PLT_CODE");
                    sbQuery.Append(" AND A.WO_NO = W.WO_NO");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P");
                    sbQuery.Append(" ON W.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND W.PROD_CODE = P.PROD_CODE");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP");
                    sbQuery.Append(" ON W.PLT_CODE = SP.PLT_CODE");
                    sbQuery.Append(" AND W.PART_CODE = SP.PART_CODE");
                    sbQuery.Append(" WHERE A.ACT_END_TIME IS NULL");
                    sbQuery.Append(" AND W.DATA_FLAG = '0' AND P.DATA_FLAG = '0'");
                    sbQuery.Append(" )");
                    sbQuery.Append(" A");
                    sbQuery.Append(" WHERE A.SEQ = 1");


                    foreach (DataRow row in dtParam.Rows)
                    {

                        //StringBuilder sbWhere = new StringBuilder(" WHERE A.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        StringBuilder sbWhere = new StringBuilder();

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
