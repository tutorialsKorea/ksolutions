using BizExecute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCOST
{
    public class DCOST
    {
        public static DataTable DCOST_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" P.PLT_CODE");
                    sbQuery.Append(" ,P.PROD_CODE");
                    sbQuery.Append(" ,P.PROD_NAME");
                    sbQuery.Append(" ,P.PROD_FLAG");
                    sbQuery.Append(" ,P.PROD_TYPE");
                    sbQuery.Append(" ,P.ITEM_FLAG");
                    sbQuery.Append(" ,P.CVND_CODE");
                    sbQuery.Append(" ,V.VEN_NAME AS CVND_NAME");
                    sbQuery.Append(" ,P.BUSINESS_EMP");
                    sbQuery.Append(" ,E.EMP_NAME AS BUSINESS_EMP_NAME");
                    sbQuery.Append(" ,CASE WHEN PO.PLT_CODE IS NULL THEN '사내' ELSE '외주' END AS IS_OS");
                    sbQuery.Append(" ,PT.PART_CODE");
                    sbQuery.Append(" ,SP.PART_NAME");
                    sbQuery.Append(" ,AC.MAT_CODE");
                    sbQuery.Append(" ,AC.MAT_QLTY");
                    sbQuery.Append(" ,PT.MATERIAL"); 
                    sbQuery.Append(" ,W.RE_WO_NO");
                    sbQuery.Append(" ,W.PART_QTY");
                    sbQuery.Append(" ,ISNULL(CONVERT(DECIMAL(18,0), CASE WHEN ISNULL(MSP.CUTTING_CNT, 1) > 0 THEN MSP.MAT_COST / ISNULL(MSP.CUTTING_CNT, 1)");
                    sbQuery.Append(" ELSE MSP.MAT_COST END), 0) AS CIRCLE_COST");

                    sbQuery.Append(" ,ISNULL(CONVERT(DECIMAL(18,0), CASE WHEN CASE WHEN PO.PLT_CODE IS NULL THEN '사내' ELSE '외주' END = '사내'");
                    sbQuery.Append(" THEN CASE WHEN P.PROD_FLAG = 'NE' THEN COST.COST_DES ELSE 3920 END");
                    sbQuery.Append(" ELSE 0 END), 0) AS DES_COST");

                    sbQuery.Append(" ,ISNULL(CONVERT(DECIMAL(18,0), CASE WHEN CASE WHEN PO.PLT_CODE IS NULL THEN '사내' ELSE '외주' END = '사내'");
                    sbQuery.Append(" THEN COST.COST_MILL");
                    sbQuery.Append(" ELSE 0 END), 0) AS MILL_COST");

                    sbQuery.Append(" ,ISNULL(CONVERT(DECIMAL(18,0), CASE WHEN CASE WHEN PO.PLT_CODE IS NULL THEN '사내' ELSE '외주' END = '사내'");
                    sbQuery.Append(" THEN CASE WHEN P.PROD_FLAG = 'NE' THEN COST.COST_CAM ELSE 3990 END");
                    sbQuery.Append(" ELSE 0 END), 0) AS CAM_COST");

                    sbQuery.Append(" ,ISNULL(CONVERT(DECIMAL(18,0), CASE WHEN CASE WHEN PO.PLT_CODE IS NULL THEN '사내' ELSE '외주' END = '사내'");
                    sbQuery.Append(" THEN COST.MCT_COST * ACT.ACT_TIME * CASE WHEN W.PART_QTY > 20 THEN W.PART_QTY * 0.5");
                    sbQuery.Append(" WHEN W.PART_QTY > 4 THEN W.PART_QTY * 0.8");
                    sbQuery.Append(" ELSE W.PART_QTY * 1 END");
                    sbQuery.Append(" ELSE 0 END), 0) AS MCT_COST");

                    sbQuery.Append(" ,ISNULL(CONVERT(DECIMAL(18,0), CASE WHEN CASE WHEN PO.PLT_CODE IS NULL THEN '사내' ELSE '외주' END = '사내'");
                    sbQuery.Append(" THEN COST.COST_SIDE * CASE WHEN W.PART_QTY > 20 THEN W.PART_QTY * 0.5");
                    sbQuery.Append(" WHEN W.PART_QTY > 4 THEN W.PART_QTY * 0.8");
                    sbQuery.Append(" ELSE W.PART_QTY * 1 END");
                    sbQuery.Append(" ELSE 0 END), 0) AS SIDE_COST");

                    sbQuery.Append(" ,ISNULL(CONVERT(DECIMAL(18,0), COST.COST_ASSY * CASE WHEN W.PART_QTY > 20 THEN W.PART_QTY * 0.5");
                    sbQuery.Append(" WHEN W.PART_QTY > 4 THEN W.PART_QTY * 0.8");
                    sbQuery.Append(" ELSE W.PART_QTY * 1 END");
                    sbQuery.Append(" ), 0) AS ASSY_COST");

                    sbQuery.Append(" ,ISNULL(CONVERT(DECIMAL(18,0), COST.COST_SHIP * CASE WHEN W.PART_QTY > 20 THEN W.PART_QTY * 0.5");
                    sbQuery.Append(" WHEN W.PART_QTY > 4 THEN W.PART_QTY * 0.8");
                    sbQuery.Append(" ELSE W.PART_QTY * 1 END");
                    sbQuery.Append(" ), 0) AS SHIP_COST");

                    sbQuery.Append(" ,ISNULL(CONVERT(DECIMAL(18,0), COST.COST_INS * CASE WHEN W.PART_QTY > 20 THEN W.PART_QTY * 0.5");
                    sbQuery.Append(" WHEN W.PART_QTY > 4 THEN W.PART_QTY * 0.8");
                    sbQuery.Append(" ELSE W.PART_QTY * 1 END");
                    sbQuery.Append(" ), 0) AS INS_COST");

                    sbQuery.Append(" FROM TORD_PRODUCT P");
                    sbQuery.Append(" LEFT JOIN (SELECT * FROM TMAT_PARTLIST WHERE WO_PART = '1' AND DATA_FLAG = '0') PT");
                    sbQuery.Append(" ON P.PLT_CODE = PT.PLT_CODE");
                    sbQuery.Append(" AND P.PROD_CODE = PT.PROD_CODE");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP");
                    sbQuery.Append(" ON PT.PLT_CODE = SP.PLT_CODE");
                    sbQuery.Append(" AND PT.PART_CODE = SP.PART_CODE");
                    sbQuery.Append(" LEFT JOIN ( SELECT PLT_CODE, PT_ID, RE_WO_NO, PART_QTY FROM TSHP_WORKORDER WHERE DATA_FLAG = '0' GROUP BY PLT_CODE, PT_ID, RE_WO_NO, PART_QTY) W");
                    sbQuery.Append(" ON PT.PLT_CODE = W.PLT_CODE");
                    sbQuery.Append(" AND PT.PT_ID = W.PT_ID");
                    sbQuery.Append(" LEFT JOIN TSHP_ACTUAL_CAM AC");
                    sbQuery.Append(" ON W.PLT_CODE = AC.PLT_CODE");
                    sbQuery.Append(" AND W.PT_ID = AC.PT_ID");
                    sbQuery.Append(" AND ISNULL(W.RE_WO_NO, '99') = ISNULL(AC.RE_WO_NO, '99')");
                    sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE, PT_ID, RE_WO_NO FROM TSHP_WORKORDER WHERE PROC_CODE = 'P14' AND DATA_FLAG = '0' GROUP BY PLT_CODE, PT_ID, RE_WO_NO) PO");
                    sbQuery.Append(" ON W.PLT_CODE = PO.PLT_CODE");
                    sbQuery.Append(" AND W.PT_ID = PO.PT_ID");
                    sbQuery.Append(" AND ISNULL(W.RE_WO_NO, '99') = ISNULL(PO.RE_WO_NO, '99')");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART MSP");
                    sbQuery.Append(" ON AC.PLT_CODE = MSP.PLT_CODE");
                    sbQuery.Append(" AND AC.MAT_CODE = MSP.PART_CODE");
                    sbQuery.Append(" LEFT JOIN (SELECT SP.PLT_CODE, SP.PART_CODE");
                    sbQuery.Append(" , SP.COST_DES_TIME * CT.DES_COST * PR.DES_RATE AS COST_DES, SP.COST_MILL_TIME * CT.MILL_COST * PR.MILL_RATE AS COST_MILL");
                    sbQuery.Append(" , SP.COST_SIDE_TIME * CT.SIDE_COST * PR.SIDE_RATE AS COST_SIDE, SP.COST_INS_TIME * CT.INS_COST * PR.INS_RATE AS COST_INS");
                    sbQuery.Append(" , SP.COST_ASSY_TIME * CT.ASSY_COST * PR.ASSY_RATE AS COST_ASSY, SP.COST_SHIP_TIME * CT.SHIP_COST * PR.SHIP_RATE AS COST_SHIP");
                    sbQuery.Append(" , SP.COST_CAM_TIME * CT.CAM_COST * PR.CAM_RATE AS COST_CAM");
                    sbQuery.Append(" , CT.MCT_COST * PR.MCT_RATE AS MCT_COST");
                    sbQuery.Append(" FROM LSE_STD_PART SP");
                    sbQuery.Append(" LEFT JOIN TSTD_PART_RATE PR");
                    sbQuery.Append(" ON SP.PLT_CODE = PR.PLT_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_COST_TYPE CT");
                    sbQuery.Append(" ON SP.PLT_CODE = CT.PLT_CODE");
                    sbQuery.Append(" AND CT.COST_FLAG = '3'");
                    sbQuery.Append(" WHERE SP.MAT_LTYPE = '33' AND SP.DATA_FLAG = '0'");
                    sbQuery.Append(" ) COST");
                    sbQuery.Append(" ON PT.PLT_CODE = COST.PLT_CODE");
                    sbQuery.Append(" AND PT.PART_CODE = COST.PART_CODE");
                    sbQuery.Append(" LEFT JOIN");
                    sbQuery.Append(" (");
                    sbQuery.Append(" SELECT A.PLT_CODE, W.PART_CODE, W.PROD_CODE, W.PT_ID, W.RE_WO_NO");
                    sbQuery.Append(" ,CASE WHEN SUM(W.PART_QTY) > 0 THEN SUM(A.ACT_TIME) / SUM(W.PART_QTY) ELSE 1 END AS ACT_TIME FROM TSHP_ACTUAL A");
                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER W");
                    sbQuery.Append(" ON A.PLT_CODE = W.PLT_CODE");
                    sbQuery.Append(" AND A.WO_NO = W.WO_NO");
                    sbQuery.Append(" GROUP BY A.PLT_CODE, W.PART_CODE, W.PROD_CODE, W.PT_ID, W.RE_WO_NO");
                    sbQuery.Append(" ) ACT");
                    sbQuery.Append(" ON W.PLT_CODE = ACT.PLT_CODE");
                    sbQuery.Append(" AND W.PT_ID = ACT.PT_ID");
                    sbQuery.Append(" AND ISNULL(W.RE_WO_NO, '99') = ISNULL(ACT.RE_WO_NO, '99')");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E");
                    sbQuery.Append(" ON E.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND E.EMP_CODE = P.BUSINESS_EMP");

                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V");
                    sbQuery.Append(" ON V.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND V.VEN_CODE = P.CVND_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE 1 = 1 ");

                        sbWhere.Append(" AND LEFT(PT.PART_CODE, 1) = 'M' ");

                        sbWhere.Append(UTIL.GetWhere(row, "@S_ORD_DATE,@E_ORD_DATE", "P.ORD_DATE BETWEEN @S_ORD_DATE AND @E_ORD_DATE"));

                        sbWhere.Append(" ORDER BY P.PROD_CODE, PT.PART_CODE, AC.RE_WO_NO ");

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

        public static DataTable DCOST_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                    sbQuery.Append(" SELECT O.PLT_CODE, ISNULL(PT.PROD_CODE,OQ.PROD_CODE) AS PROD_CODE, O.PART_CODE, SP.PART_NAME, SP.MAT_LTYPE, SP.MAT_MTYPE");
                    sbQuery.Append(" , O.OUT_QTY, SP.MAT_COST");
                    sbQuery.Append(" , O.OUT_QTY * SP.MAT_COST AS OUT_AMT ");

                    sbQuery.Append(" ,P.PROD_FLAG");
                    sbQuery.Append(" ,P.PROD_TYPE");
                    sbQuery.Append(" ,P.ITEM_FLAG");
                    sbQuery.Append(" ,P.CVND_CODE");
                    sbQuery.Append(" ,V.VEN_NAME AS CVND_NAME");

                    sbQuery.Append(" FROM TMAT_OUT O");
                    
                    sbQuery.Append(" LEFT JOIN TMAT_OUT_REQ OQ");
                    sbQuery.Append(" ON O.PLT_CODE = OQ.PLT_CODE");
                    sbQuery.Append(" AND O.OUT_REQ_ID = OQ.OUT_REQ_ID");

                    sbQuery.Append(" LEFT JOIN TMAT_PARTLIST PT");
                    sbQuery.Append(" ON OQ.PLT_CODE = PT.PLT_CODE");
                    sbQuery.Append(" AND OQ.PT_ID = PT.PT_ID");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP");
                    sbQuery.Append(" ON O.PLT_CODE = SP.PLT_CODE");
                    sbQuery.Append(" AND O.PART_CODE = SP.PART_CODE");

                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P");
                    sbQuery.Append(" ON PT.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND PT.PROD_CODE = P.PROD_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V");
                    sbQuery.Append(" ON V.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND V.VEN_CODE = P.CVND_CODE");



                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE 1 = 1 ");

                        sbWhere.Append(" AND O.DATA_FLAG = '0' AND OQ.DATA_FLAG = '0' ");
                        sbWhere.Append(" AND SP.MAT_LTYPE = '22' AND SP.MAT_MTYPE IN('21','23') ");
                        sbWhere.Append(" AND ISNULL(PT.PROD_CODE, OQ.PROD_CODE) IS NOT NULL");
                        sbWhere.Append(" AND O.OUT_QTY > 0 ");

                        sbWhere.Append(UTIL.GetWhere(row, "@S_ORD_DATE,@E_ORD_DATE", "P.ORD_DATE BETWEEN @S_ORD_DATE AND @E_ORD_DATE"));

                        sbWhere.Append(" ORDER BY ISNULL(PT.PROD_CODE,OQ.PROD_CODE) ");

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

        public static DataTable DCOST_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" PY.PLT_CODE");
                    sbQuery.Append(" ,W.PROD_CODE");
                    sbQuery.Append(" ,W.PART_CODE");
                    sbQuery.Append(" ,SP.PART_NAME");
                    sbQuery.Append(" ,POM.OVND_CODE");
                    sbQuery.Append(" ,V.VEN_NAME AS OVND_NAME");
                    sbQuery.Append(" ,PY.QTY");
                    sbQuery.Append(" ,CASE WHEN PO.BAL_UNIT = '1' THEN PY.AMT * EX.DOLLAR ELSE PY.AMT END AS AMT");

                    sbQuery.Append(" ,P.PROD_FLAG");
                    sbQuery.Append(" ,P.PROD_TYPE");
                    sbQuery.Append(" ,P.ITEM_FLAG");
                    sbQuery.Append(" ,P.CVND_CODE");
                    sbQuery.Append(" ,CV.VEN_NAME AS CVND_NAME");

                    sbQuery.Append(" FROM TOUT_PROCYPGO PY");
                    sbQuery.Append(" LEFT JOIN TOUT_PROCBALJU PO");
                    sbQuery.Append(" ON PY.PLT_CODE = PO.PLT_CODE");
                    sbQuery.Append(" AND PY.BALJU_NUM = PO.BALJU_NUM");
                    sbQuery.Append(" AND PY.BALJU_SEQ = PO.BALJU_SEQ");
                    sbQuery.Append(" LEFT JOIN TOUT_PROCBALJU_MASTER POM");
                    sbQuery.Append(" ON PY.PLT_CODE = POM.PLT_CODE");
                    sbQuery.Append(" AND PY.BALJU_NUM = POM.BALJU_NUM");
                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER W");
                    sbQuery.Append(" ON PO.PLT_CODE = W.PLT_CODE");
                    sbQuery.Append(" AND PO.WO_NO = W.WO_NO");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP");
                    sbQuery.Append(" ON W.PLT_CODE = SP.PLT_CODE");
                    sbQuery.Append(" AND W.PART_CODE = SP.PART_CODE");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V");
                    sbQuery.Append(" ON POM.PLT_CODE = V.PLT_CODE");
                    sbQuery.Append(" AND POM.OVND_CODE = V.VEN_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_COST_EXCHANGE EX");
                    sbQuery.Append(" ON PY.PLT_CODE = EX.PLT_CODE");
                    sbQuery.Append(" AND LEFT(PY.YPGO_DATE, 6) = EX.MONTH");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P");
                    sbQuery.Append(" ON W.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND W.PROD_CODE = P.PROD_CODE");

                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR CV");
                    sbQuery.Append(" ON CV.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND CV.VEN_CODE = P.CVND_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE 1 = 1 ");

                        sbWhere.Append(" AND PY.YPGO_STAT = '19' ");
                        sbWhere.Append(" AND W.PROD_CODE IS NOT NULL ");
                        sbWhere.Append(" AND W.PROC_CODE = 'P14'");

                        sbWhere.Append(UTIL.GetWhere(row, "@S_ORD_DATE,@E_ORD_DATE", "P.ORD_DATE BETWEEN @S_ORD_DATE AND @E_ORD_DATE"));

                        sbWhere.Append(" ORDER BY W.PROD_CODE ");

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
