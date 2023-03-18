using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DMAT
{
    public class TMAT_OUT_REQ
    {

        public static DataTable TMAT_OUT_REQ_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append("  FROM TMAT_OUT_REQ  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND PT_ID = @PT_ID  ");
                    sbQuery.Append("  AND DATA_FLAG = '0'  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;

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

        public static DataTable TMAT_OUT_REQ_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append("  ,OUT_REQ_ID ");
                    sbQuery.Append("  ,OUT_REQ_QTY ");
                    sbQuery.Append("  ,OUT_REQ_STAT "); 
                    sbQuery.Append("  FROM TMAT_OUT_REQ  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND PT_ID = @PT_ID  ");
                    sbQuery.Append("  AND OUT_REQ_STAT = @OUT_REQ_STAT  ");
                    sbQuery.Append("  AND DATA_FLAG = '0'  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "OUT_REQ_STAT")) isHasColumn = false;

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

        public static DataTable TMAT_OUT_REQ_SER3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append("  ,OUT_REQ_ID ");
                    sbQuery.Append("  ,OUT_REQ_QTY ");
                    sbQuery.Append("  ,OUT_REQ_STAT ");
                    sbQuery.Append("  FROM TMAT_OUT_REQ  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND PT_ID = @PT_ID  ");
                    sbQuery.Append("  AND DATA_FLAG = '0'  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;

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

        public static void TMAT_OUT_REQ_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TMAT_OUT_REQ");
                    sbQuery.Append(" (PLT_CODE				 ");
                    sbQuery.Append(" ,OUT_REQ_ID			 ");
                    sbQuery.Append(" ,PT_ID				 ");
                    sbQuery.Append(" ,PART_CODE				 ");
                    sbQuery.Append(" ,STOCK_CODE			 ");
                    sbQuery.Append(" ,OUT_REQ_DATE			 ");
                    sbQuery.Append(" ,OUT_REQ_EMP			 ");
                    sbQuery.Append(" ,OUT_REQ_QTY			 ");
                    sbQuery.Append(" ,OUT_REQ_STAT			 ");
                    sbQuery.Append(" ,OUT_REQ_LOC			 ");
                    sbQuery.Append(" ,SCOMMENT				 ");
                    sbQuery.Append(" ,PROD_CODE				 ");
                    sbQuery.Append(" ,REG_DATE				 ");
                    sbQuery.Append(" ,REG_EMP				 ");
                    sbQuery.Append(" ,DATA_FLAG)			 ");
                    sbQuery.Append(" VALUES					 ");
                    sbQuery.Append(" (						 ");
                    sbQuery.Append(" @PLT_CODE				 ");
                    sbQuery.Append(" ,@OUT_REQ_ID			 ");
                    sbQuery.Append(" ,@PT_ID				 ");
                    sbQuery.Append(" ,@PART_CODE			 ");
                    sbQuery.Append(" ,@STOCK_CODE			 ");
                    sbQuery.Append(" ,@OUT_REQ_DATE			 ");
                    sbQuery.Append(" ,@OUT_REQ_EMP			 ");
                    sbQuery.Append(" ,@OUT_REQ_QTY			 ");
                    sbQuery.Append(" ,@OUT_REQ_STAT			 ");
                    sbQuery.Append(" ,@OUT_REQ_LOC			 ");
                    sbQuery.Append(" ,@SCOMMENT				 ");
                    sbQuery.Append(" ,@PROD_CODE				 ");
                    sbQuery.Append(" ,GETDATE()			     ");
                    sbQuery.Append(" ," + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" ,@DATA_FLAG			 ");
                    sbQuery.Append(" )						 ");


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


        public static void TMAT_OUT_REQ_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_OUT_REQ	   ");
                    sbQuery.Append(" SET OUT_REQ_STAT = @OUT_REQ_STAT  ");
                    sbQuery.Append("   , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("   , MDFY_EMP =  " + UTIL.GetValidValue(ConnInfo.UserID));

                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("   AND OUT_REQ_ID = @OUT_REQ_ID     ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "OUT_REQ_ID")) isHasColumn = false;

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

        public static void TMAT_OUT_REQ_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_OUT_REQ ");
                    sbQuery.Append(" SET OUT_REQ_QTY = @OUT_REQ_QTY ");
                    sbQuery.Append("   , SCOMMENT = @SCOMMENT    ");
                    sbQuery.Append("   , MDFY_DATE   = GETDATE() ");
                    sbQuery.Append("   , MDFY_EMP    =  " + UTIL.GetValidValue(ConnInfo.UserID));

                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("   AND OUT_REQ_ID = @OUT_REQ_ID     ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "OUT_REQ_ID")) isHasColumn = false;

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

        public static void TMAT_OUT_REQ_UPD3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_OUT_REQ ");
                    sbQuery.Append(" SET OUT_REQ_QTY = @OUT_REQ_QTY ");
                    sbQuery.Append("   , MDFY_DATE   = GETDATE() ");
                    sbQuery.Append("   , MDFY_EMP    =  " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("   AND OUT_REQ_ID = @OUT_REQ_ID     ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "OUT_REQ_ID")) isHasColumn = false;

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

        public static void TMAT_OUT_REQ_UPD4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_OUT_REQ ");
                    sbQuery.Append(" SET SCOMMENT = @SCOMMENT ");
                    sbQuery.Append("   , MDFY_DATE   = GETDATE() ");
                    sbQuery.Append("   , MDFY_EMP    =  " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("   AND OUT_REQ_ID = @OUT_REQ_ID     ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "OUT_REQ_ID")) isHasColumn = false;

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


        public static void TMAT_OUT_REQ_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_OUT_REQ	   ");
                    sbQuery.Append(" SET DATA_FLAG = 2 ");
                    sbQuery.Append("   , DEL_DATE = GETDATE() ");
                    sbQuery.Append("   , DEL_EMP =  @DEL_EMP  ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("   AND OUT_REQ_ID = @OUT_REQ_ID     ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "OUT_REQ_ID")) isHasColumn = false;

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

        public static void TMAT_OUT_REQ_UDE2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_OUT_REQ	   ");
                    sbQuery.Append(" SET DATA_FLAG = 2 ");
                    sbQuery.Append("   , DEL_DATE = GETDATE() ");
                    sbQuery.Append("   , DEL_EMP =  @DEL_EMP  ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("   AND PT_ID = @PT_ID     ");
                    sbQuery.Append("   AND OUT_REQ_STAT IN ('50', '53')     ");
                    sbQuery.Append("   AND DATA_FLAG = '0'");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PT_ID")) isHasColumn = false;

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

        public static void TMAT_OUT_REQ_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" DELETE FROM TMAT_OUT_REQ	   ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("   AND PT_ID LIKE '%' + @PROD_CODE + '%'    ");
                    sbQuery.Append("   AND OUT_REQ_STAT = '50'    ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;

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

    public class TMAT_OUT_REQ_QUERY
    {
        public static DataTable TMAT_OUT_REQ_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();


                    sbQuery.Append(" SELECT  OREQ.PLT_CODE      ");
                    sbQuery.Append(" 	, OREQ.OUT_REQ_ID       ");
                    sbQuery.Append("    , OREQ.PT_ID				 ");
                    sbQuery.Append(" 	, OREQ.PART_CODE        ");
                    sbQuery.Append(" 	, P.PART_NAME           ");
                    sbQuery.Append(" 	, P.PART_PRODTYPE       ");
                    sbQuery.Append(" 	, P.DRAW_NO             ");
                    sbQuery.Append(" 	, P.MAT_SPEC            ");
                    sbQuery.Append(" 	, P.MAT_LTYPE       ");
                    sbQuery.Append(" 	, P.MAT_MTYPE       ");
                    sbQuery.Append(" 	, P.MAT_STYPE       ");
                    sbQuery.Append(" 	, P.MAT_TYPE            ");
                    sbQuery.Append(" 	, P.MAT_TYPE1            ");
                    sbQuery.Append(" 	, OREQ.OUT_REQ_LOC     ");
                    sbQuery.Append(" 	, OREQ.OUT_REQ_DATE     ");
                    sbQuery.Append(" 	, STOCK.CD_NAME AS STOCK_NAME     ");
                    sbQuery.Append(" 	, OREQ.STOCK_CODE     ");
                    sbQuery.Append(" 	, OREQ.OUT_REQ_EMP      ");
                    sbQuery.Append(" 	, OREQ.OUT_REQ_QTY      ");
                    sbQuery.Append(" 	, E.ORG_CODE AS OUT_REQ_ORG      ");
                    sbQuery.Append(" 	, ISNULL(O.OUT_QTY, 0) AS O_OUT_QTY   ");
                    sbQuery.Append(" 	, OREQ.OUT_REQ_QTY - ISNULL(O.OUT_QTY, 0) REMAIN_QTY    ");
                    sbQuery.Append(" 	, OREQ.OUT_REQ_QTY - ISNULL(O.OUT_QTY, 0) AS OUT_QTY   ");
                    sbQuery.Append(" 	, OREQ.OUT_REQ_STAT     ");
                    sbQuery.Append(" 	, OREQ.SCOMMENT         ");
                    sbQuery.Append(" 	, OREQ.REG_DATE         ");
                    sbQuery.Append(" 	, OREQ.REG_EMP	        ");
                    sbQuery.Append(" 	, P.STK_LOCATION        ");
                    sbQuery.Append(" 	, CASE WHEN OREQ.PT_ID IS NULL THEN OREQ.PROD_CODE ELSE PT.PROD_CODE END AS PROD_CODE          ");
                    sbQuery.Append(" 	, CASE WHEN OREQ.PT_ID IS NULL THEN OREQ.PROD_CODE ELSE PT.PROD_CODE END AS PROD_CODE_GROUP          ");
                    sbQuery.Append(" 	, PT.PART_QTY          ");
                    sbQuery.Append(" 	, CASE WHEN ISNULL(PT.ORD_QTY, 0) > 0 THEN PT.ORD_QTY ELSE PD.PROD_QTY END AS PROD_QTY  ");
                    sbQuery.Append(" 	, PT.O_PART_QTY          ");

                    sbQuery.Append(" 	, PT.ORD_QTY          ");
                    sbQuery.Append(" 	, PD.CVND_CODE          ");
                    sbQuery.Append(" 	, V.VEN_NAME AS CVND_NAME          ");
                    sbQuery.Append(" 	, AD.DRAW_EMP          ");

                    sbQuery.Append(" 	, PD.DUE_DATE          ");
                    sbQuery.Append(" 	, PD.CHG_DUE_DATE          ");
                    sbQuery.Append(" 	, PD.PROD_NAME          ");
                    sbQuery.Append(" 	, PD.SCOMMENT AS ORD_SCOMMENT          ");

                    sbQuery.Append(" 	, AW.WO_FLAG          ");

                    sbQuery.Append(" 	, PD.PROD_FLAG          ");
                    sbQuery.Append(" 	, PD.PROD_TYPE          ");

                    sbQuery.Append(" FROM TMAT_OUT_REQ OREQ JOIN LSE_STD_PART P ");
                    sbQuery.Append("   ON OREQ.PLT_CODE = P.PLT_CODE             ");
                    sbQuery.Append(" AND OREQ.PART_CODE = P.PART_CODE            ");
                    
                    sbQuery.Append("  LEFT JOIN TMAT_PARTLIST PT ");
                    sbQuery.Append("  ON OREQ.PLT_CODE = PT.PLT_CODE ");
                    sbQuery.Append("  AND OREQ.PT_ID = PT.PT_ID ");

                    sbQuery.Append("  LEFT JOIN TORD_PRODUCT PD ");
                    sbQuery.Append("  ON PT.PLT_CODE = PD.PLT_CODE ");
                    sbQuery.Append("  AND PT.PROD_CODE = PD.PROD_CODE ");

                    sbQuery.Append("  LEFT JOIN (SELECT PLT_CODE, OUT_REQ_ID, SUM(OUT_QTY) AS OUT_QTY   ");
                    sbQuery.Append(" 			FROM TMAT_OUT                       ");
                    sbQuery.Append(" 			WHERE DATA_FLAG = 0                 ");
                    sbQuery.Append(" 			GROUP BY PLT_CODE, OUT_REQ_ID ) O   ");
                    sbQuery.Append(" 	ON OREQ.PLT_CODE = O.PLT_CODE               ");
                    sbQuery.Append(" 	AND OREQ.OUT_REQ_ID = O.OUT_REQ_ID          ");

                    sbQuery.Append("  LEFT JOIN TSTD_EMPLOYEE E ");
                    sbQuery.Append("   ON OREQ.PLT_CODE = E.PLT_CODE ");
                    sbQuery.Append("   AND OREQ.OUT_REQ_EMP = E.EMP_CODE ");
                    
                    sbQuery.Append("  LEFT JOIN TSTD_CODES STOCK ");
                    sbQuery.Append("   ON STOCK.CAT_CODE = 'M005' ");
                    sbQuery.Append("   AND OREQ.PLT_CODE = STOCK.PLT_CODE");
                    sbQuery.Append("   AND OREQ.STOCK_CODE = STOCK.CD_CODE");

                    sbQuery.Append("  LEFT JOIN TSTD_VENDOR V ");
                    sbQuery.Append("   ON PD.PLT_CODE = V.PLT_CODE ");
                    sbQuery.Append("   AND PD.CVND_CODE = V.VEN_CODE ");

                    sbQuery.Append(" LEFT JOIN (");
                    sbQuery.Append(" SELECT PLT_CODE, PROD_CODE, MAX(DRAW_EMP) AS DRAW_EMP FROM TMAT_PARTLIST");
                    sbQuery.Append(" WHERE ISNULL(O_PT_ID,'') = '' AND DATA_FLAG = '0' AND LEFT(PART_CODE,1) = 'A'");
                    sbQuery.Append(" GROUP BY PLT_CODE, PROD_CODE");
                    sbQuery.Append(" ) AD");
                    sbQuery.Append(" ON PT.PLT_CODE = AD.PLT_CODE");
                    sbQuery.Append(" AND PT.PROD_CODE = AD.PROD_CODE");

                    sbQuery.Append(" LEFT JOIN (");
                    sbQuery.Append(" SELECT PLT_CODE, PROD_CODE, PROC_CODE, MAX(WO_FLAG) AS WO_FLAG FROM TSHP_WORKORDER WITH(NOLOCK)");
                    sbQuery.Append(" WHERE PROC_CODE = 'P-09' AND DATA_FLAG = '0'");
                    sbQuery.Append(" GROUP BY PLT_CODE, PROD_CODE, PROC_CODE");
                    sbQuery.Append(" ) AW");
                    sbQuery.Append(" ON PD.PLT_CODE = AW.PLT_CODE");
                    sbQuery.Append(" AND PD.PROD_CODE = AW.PROD_CODE");



                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE OREQ.DATA_FLAG = 0 AND OREQ.OUT_REQ_STAT IN ('50', '51', '53')  ");

                        sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", " OREQ.PLT_CODE = @PLT_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DATE,@E_DATE", "OREQ.OUT_REQ_DATE BETWEEN @S_DATE AND @E_DATE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "P.PART_CODE LIKE '%' + @PART_LIKE + '%' OR P.PART_NAME LIKE '%' + @PART_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DRAW_LIKE", "P.DRAW_NO LIKE '%' + @DRAW_LIKE + '%' "));
                        sbWhere.Append(UTIL.GetWhere(row, "@SPEC_LIKE", "P.MAT_SPEC LIKE '%' + @SPEC_LIKE + '%' "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_LTYPE", "P.MAT_LTYPE = @MAT_LTYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_MTYPE", "P.MAT_MTYPE = @MAT_MTYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_STYPE", "P.MAT_STYPE = @MAT_STYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@OUT_REQ_ID", "OREQ.OUT_REQ_ID LIKE '%' + @OUT_REQ_ID + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_PRODTYPE", "P.PART_PRODTYPE LIKE '%' + @PART_PRODTYPE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_LIKE", "(PD.PROD_CODE LIKE '%' + @PROD_LIKE + '%' OR PD.PROD_NAME LIKE '%' + @PROD_LIKE + '%' OR OREQ.PROD_CODE LIKE '%' + @PROD_LIKE + '%')"));
                        //sbWhere.Append(" ORDER BY R.RET_REQ_DATE DESC ");

                        sbWhere.Append(UTIL.GetWhere(row, "@IS_MAIN", "ISNULL(P.IS_MAIN_PART, '0') = '1'  "));

                        sbWhere.Append(" AND ISNULL(PD.DATA_FLAG, '0') = '0' AND ISNULL(PD.PROD_STATE, '1') <> '5'");

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

        public static DataTable TMAT_OUT_REQ_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                StringBuilder sbQuery = new StringBuilder();

                sbQuery.Append(" SELECT                 ");
                sbQuery.Append(" 	O.OUT_REQ_ID        ");
                sbQuery.Append(" 	, O.PT_ID       ");
                sbQuery.Append(" 	, CASE WHEN O.PT_ID IS NULL THEN O.PROD_CODE ELSE TP.PROD_CODE END AS PROD_CODE      ");
                sbQuery.Append(" 	, O.PART_CODE       ");
                sbQuery.Append(" 	, P.PART_NAME       ");
                sbQuery.Append(" 	, P.MAT_SPEC        ");
                sbQuery.Append(" 	, P.PART_PRODTYPE   ");
                sbQuery.Append(" 	, P.DRAW_NO         ");
                sbQuery.Append(" 	, P.MAT_TYPE        ");
                sbQuery.Append(" 	, P.MAT_LTYPE       ");
                sbQuery.Append(" 	, P.MAT_MTYPE       ");
                sbQuery.Append(" 	, P.MAT_STYPE       ");
                sbQuery.Append(" 	, O.STOCK_CODE      ");
                sbQuery.Append(" 	, STOCK.CD_NAME AS STOCK_NAME      ");
                sbQuery.Append(" 	, O.OUT_REQ_DATE    ");
                sbQuery.Append(" 	, O.OUT_REQ_EMP     ");
                sbQuery.Append(" 	, O.OUT_REQ_QTY     ");
                sbQuery.Append(" 	, O.OUT_REQ_STAT    ");
                sbQuery.Append(" 	, O.SCOMMENT        ");
                sbQuery.Append(" 	, O.OUT_REQ_STAT ");
                sbQuery.Append(" 	, O.OUT_REQ_LOC ");
                //sbQuery.Append(" 	, MO.OUT_DATE ");

                sbQuery.Append(" 	, AW.WO_FLAG          ");

                sbQuery.Append(" FROM TMAT_OUT_REQ O JOIN LSE_STD_PART P  ");
                sbQuery.Append("    ON O.PLT_CODE = P.PLT_CODE ");
                sbQuery.Append(" AND O.PART_CODE = P.PART_CODE ");
                sbQuery.Append("  LEFT JOIN TSTD_CODES STOCK ");
                sbQuery.Append("   ON STOCK.CAT_CODE = 'M005' ");
                sbQuery.Append("   AND O.PLT_CODE = STOCK.PLT_CODE");
                sbQuery.Append("   AND O.STOCK_CODE = STOCK.CD_CODE");

                sbQuery.Append("  LEFT JOIN TMAT_PARTLIST TP ");
                sbQuery.Append("   ON O.PLT_CODE = TP.PLT_CODE ");
                sbQuery.Append("   AND O.PT_ID = TP.PT_ID");
                sbQuery.Append("   AND TP.DATA_FLAG = '0'");

                sbQuery.Append(" LEFT JOIN (");
                sbQuery.Append(" SELECT PLT_CODE, PROD_CODE, PROC_CODE, MAX(WO_FLAG) AS WO_FLAG FROM TSHP_WORKORDER WITH(NOLOCK)");
                sbQuery.Append(" WHERE PROC_CODE = 'P-09' AND DATA_FLAG = '0'");
                sbQuery.Append(" GROUP BY PLT_CODE, PROD_CODE, PROC_CODE");
                sbQuery.Append(" ) AW");
                sbQuery.Append(" ON TP.PLT_CODE = AW.PLT_CODE");
                sbQuery.Append(" AND TP.PROD_CODE = AW.PROD_CODE");

                //sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE,OUT_REQ_ID,MAX(OUT_DATE) AS OUT_DATE FROM TMAT_OUT GROUP BY  PLT_CODE,OUT_REQ_ID)  MO ");
                //sbQuery.Append(" ON O.PLT_CODE = MO.PLT_CODE ");
                //sbQuery.Append(" AND O.OUT_REQ_ID = MO.OUT_REQ_ID ");


                foreach (DataRow row in dtParam.Rows)
                {
                    StringBuilder sbWhere = new StringBuilder(" WHERE O.DATA_FLAG = 0 ");

                    sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", " O.PLT_CODE = @PLT_CODE"));
                    sbWhere.Append(UTIL.GetWhere(row, "@S_DATE,@E_DATE", "O.OUT_REQ_DATE BETWEEN @S_DATE AND @E_DATE "));
                    sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "P.PART_CODE LIKE '%' + @PART_LIKE + '%' OR P.PART_NAME LIKE '%' + @PART_LIKE + '%'"));
                    sbWhere.Append(UTIL.GetWhere(row, "@PROD_LIKE", "TP.PROD_CODE LIKE '%' + @PROD_LIKE + '%'"));
                    sbWhere.Append(UTIL.GetWhere(row, "@DRAW_LIKE", "P.DRAW_NO LIKE '%' + @DRAW_LIKE + '%' "));
                    sbWhere.Append(UTIL.GetWhere(row, "@SPEC_LIKE", "P.MAT_SPEC LIKE '%' + @SPEC_LIKE + '%' "));
                    sbWhere.Append(UTIL.GetWhere(row, "@OUT_REQ_ID", "O.OUT_REQ_ID LIKE '%' + @OUT_REQ_ID + '%'"));
                    sbWhere.Append(UTIL.GetWhere(row, "@STOCK_CODE", "STOCK.CD_CODE = @STOCK_CODE"));
                    if (row["IS_OUT"].ToString() == "1")
                    {
                        sbWhere.Append(" AND O.OUT_REQ_STAT IN ('50', '51', '52','53') ");
                    }
                    else
                    {
                        sbWhere.Append(" AND O.OUT_REQ_STAT IN ('50', '51','53') ");
                    }


                    sbWhere.Append(" ORDER BY O.OUT_REQ_ID DESC ");

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

        public static DataTable TMAT_OUT_REQ_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                StringBuilder sbQuery = new StringBuilder();

                sbQuery.Append(" SELECT");
                sbQuery.Append(" PT.PLT_CODE");
                sbQuery.Append(" ,PT.PART_CODE");
                sbQuery.Append(" ,SPT.PART_NAME");
                sbQuery.Append(" ,SPT.MAT_LTYPE");
                sbQuery.Append(" ,SPT.MAT_MTYPE");
                sbQuery.Append(" ,SPT.MAT_STYPE");
                sbQuery.Append(" ,SUM(PT.PART_QTY) AS PART_QTY");
                sbQuery.Append(" ,REQ.OUT_REQ_QTY");
                sbQuery.Append(" ,REQ.OUT_QTY");
                sbQuery.Append(" ,SUM(PART_QTY) - REQ.OUT_QTY AS REMAIN_QTY");
                sbQuery.Append(" ,STK.STOCK_QTY");                
                sbQuery.Append(" FROM TMAT_PARTLIST  PT");
                sbQuery.Append(" LEFT JOIN TORD_PRODUCT P");
                sbQuery.Append(" ON PT.PLT_CODE = P.PLT_CODE");
                sbQuery.Append(" AND PT.PROD_CODE = P.PROD_CODE");
                sbQuery.Append(" LEFT JOIN");
                sbQuery.Append(" (");
                sbQuery.Append(" SELECT");
                sbQuery.Append(" RE.PLT_CODE");
                sbQuery.Append(" ,RE.PART_CODE");
                sbQuery.Append(" ,SUM(RE.OUT_REQ_QTY) AS OUT_REQ_QTY");
                sbQuery.Append(" ,SUM(OUT_QTY) AS OUT_QTY");
                sbQuery.Append(" FROM");
                sbQuery.Append(" (");
                sbQuery.Append(" SELECT");
                sbQuery.Append(" TR.PLT_CODE");
                sbQuery.Append(" ,TR.PART_CODE");
                sbQuery.Append(" ,TR.OUT_REQ_QTY");
                sbQuery.Append(" ,SUM(ISNULL(OU.OUT_QTY, 0)) AS  OUT_QTY");
                sbQuery.Append(" FROM TMAT_OUT_REQ TR");
                sbQuery.Append(" LEFT JOIN TMAT_OUT OU");
                sbQuery.Append(" ON TR.PLT_CODE = OU.PLT_CODE");
                sbQuery.Append(" AND TR.OUT_REQ_ID = OU.OUT_REQ_ID");
                sbQuery.Append(" AND OU.DATA_FLAG = '0'");
                sbQuery.Append(" LEFT JOIN TMAT_PARTLIST PT");
                sbQuery.Append(" ON TR.PLT_CODE = PT.PLT_CODE");
                sbQuery.Append(" AND TR.PT_ID = PT.PT_ID");
                sbQuery.Append(" LEFT JOIN TORD_PRODUCT P");
                sbQuery.Append(" ON PT.PLT_CODE = P.PLT_CODE");
                sbQuery.Append(" AND PT.PROD_CODE = P.PROD_CODE");
                sbQuery.Append(" WHERE TR.DATA_FLAG = '0'");
                sbQuery.Append(" AND P.PROD_STATE IN ('1','7')");
                sbQuery.Append(" GROUP BY");
                sbQuery.Append(" TR.PLT_CODE");
                sbQuery.Append(" ,TR.PART_CODE");
                sbQuery.Append(" ,TR.OUT_REQ_QTY");
                sbQuery.Append(" ,TR.OUT_REQ_ID");
                sbQuery.Append(" ) RE");
                sbQuery.Append(" GROUP BY RE.PLT_CODE");
                sbQuery.Append(" ,RE.PART_CODE");
                sbQuery.Append(" ) REQ");
                sbQuery.Append(" ON PT.PLT_CODE = REQ.PLT_CODE");
                sbQuery.Append(" AND PT.PART_CODE = REQ.PART_CODE");
                sbQuery.Append(" LEFT JOIN");
                sbQuery.Append(" (");
                sbQuery.Append(" SELECT");
                sbQuery.Append(" S.PLT_CODE");
                sbQuery.Append(" ,S.PART_CODE");
                sbQuery.Append(" ,SUM(S.PART_QTY) AS STOCK_QTY");
                sbQuery.Append(" FROM TMAT_STOCK S");
                sbQuery.Append(" GROUP BY S.PLT_CODE");
                sbQuery.Append(" ,S.PART_CODE");
                sbQuery.Append(" )STK");
                sbQuery.Append(" ON PT.PLT_CODE = STK.PLT_CODE");
                sbQuery.Append(" AND PT.PART_CODE = STK.PART_CODE");
                sbQuery.Append(" LEFT JOIN LSE_STD_PART SPT");
                sbQuery.Append(" ON PT.PLT_CODE = SPT.PLT_CODE");
                sbQuery.Append(" AND PT.PART_CODE = SPT.PART_CODE");



                foreach (DataRow row in dtParam.Rows)
                {
                    StringBuilder sbWhere = new StringBuilder(" WHERE PT.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                    sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE_IN", "PT.PART_CODE IN @PART_CODE_IN", UTIL.SqlCondType.IN));
                    sbWhere.Append(" AND P.PROD_STATE in ('1','7') AND PT.DATA_FLAG = '0' AND P.DATA_FLAG = '0'");

                    sbWhere.Append(" GROUP BY PT.PLT_CODE");
                    sbWhere.Append(" ,PT.PART_CODE");
                    sbWhere.Append(" ,SPT.PART_NAME");
                    sbWhere.Append(" ,REQ.OUT_REQ_QTY");
                    sbWhere.Append(" ,REQ.OUT_QTY");
                    sbWhere.Append(" ,STK.STOCK_QTY");
                    sbWhere.Append(" ,SPT.MAT_LTYPE");
                    sbWhere.Append(" ,SPT.MAT_MTYPE");
                    sbWhere.Append(" ,SPT.MAT_STYPE");

                    sbWhere.Append(" HAVING SUM(PART_QTY) - REQ.OUT_QTY >= STOCK_QTY"); 

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

        public static DataTable TMAT_OUT_REQ_QUERY4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                StringBuilder sbQuery = new StringBuilder();
                sbQuery.Append(" SELECT");
                sbQuery.Append(" ORE.PLT_CODE");
                sbQuery.Append(" ,ORE.PT_ID");
                sbQuery.Append(" ,ORE.PART_CODE");
                sbQuery.Append(" ,ORE.OUT_REQ_STAT");
                sbQuery.Append(" FROM TMAT_OUT_REQ ORE");
                sbQuery.Append(" LEFT JOIN TMAT_PARTLIST PT");
                sbQuery.Append(" ON PT.PLT_CODE = ORE.PLT_CODE");
                sbQuery.Append(" AND PT.PT_ID = ORE.PT_ID");
                sbQuery.Append(" AND ORE.DATA_FLAG = '0'");




                foreach (DataRow row in dtParam.Rows)
                {
                    StringBuilder sbWhere = new StringBuilder(" WHERE ORE.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                    sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "PT.PROD_CODE = @PROD_CODE"));
                    sbWhere.Append(" AND ORE.OUT_REQ_STAT NOT IN ('50', '53')");

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

        public static DataTable TMAT_OUT_REQ_QUERY5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                StringBuilder sbQuery = new StringBuilder();
                sbQuery.Append(" SELECT");
                sbQuery.Append(" ORE.PLT_CODE");
                sbQuery.Append(" ,ORE.OUT_REQ_ID");
                sbQuery.Append(" ,ORE.PT_ID");
                sbQuery.Append(" ,ORE.PART_CODE");
                sbQuery.Append(" ,ORE.OUT_REQ_STAT");
                sbQuery.Append(" FROM TMAT_OUT_REQ ORE");
                sbQuery.Append(" LEFT JOIN TMAT_PARTLIST PT");
                sbQuery.Append(" ON PT.PLT_CODE = ORE.PLT_CODE");
                sbQuery.Append(" AND PT.PT_ID = ORE.PT_ID");
                sbQuery.Append(" AND ORE.DATA_FLAG = '0'");


                foreach (DataRow row in dtParam.Rows)
                {
                    StringBuilder sbWhere = new StringBuilder(" WHERE ORE.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                    sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "PT.PROD_CODE IN @PROD_CODE"));

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

        public static DataTable TMAT_OUT_REQ_QUERY6(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                StringBuilder sbQuery = new StringBuilder();
                sbQuery.Append(" SELECT");
                sbQuery.Append(" O.PLT_CODE");
                sbQuery.Append(" ,OQ.OUT_REQ_STAT");
                sbQuery.Append(" ,OQ.OUT_REQ_ID");
                sbQuery.Append(" ,O.OUT_ID");
                sbQuery.Append(" ,P.PROD_CODE");
                sbQuery.Append(" ,PT.PART_QTY");
                sbQuery.Append(" ,OQ.OUT_REQ_QTY");
                sbQuery.Append(" ,O.OUT_QTY");
                sbQuery.Append(" ,O.OUT_DATE");
                sbQuery.Append(" ,O.OUT_EMP");
                sbQuery.Append(" ,E.EMP_NAME AS OUT_EMP_NAME");
                sbQuery.Append(" ,OQ.PART_CODE");
                sbQuery.Append(" ,SP.PART_NAME");
                sbQuery.Append(" ,SP.PART_NAME");
                sbQuery.Append(" ,SP.MAT_LTYPE");
                sbQuery.Append(" ,SP.MAT_MTYPE");
                sbQuery.Append(" ,SP.MAT_STYPE");
                sbQuery.Append(" ,SP.DRAW_NO");
                sbQuery.Append(" ,SP.MAT_SPEC");
                sbQuery.Append(" ,ISNULL(O.ORD_SHIP_FLAG, '0') AS ORD_SHIP_FLAG");
                sbQuery.Append(" ,ISNULL(O.SHIP_QTY, 0) AS O_SHIP_QTY");
                sbQuery.Append(" ,O.OUT_QTY - ISNULL(O.SHIP_QTY, 0) AS SHIP_QTY");
                sbQuery.Append(" FROM TMAT_OUT_REQ OQ");
                sbQuery.Append(" LEFT JOIN TMAT_OUT O");
                sbQuery.Append(" ON O.PLT_CODE = OQ.PLT_CODE");
                sbQuery.Append(" AND O.OUT_REQ_ID = OQ.OUT_REQ_ID");
                sbQuery.Append(" AND O.DATA_FLAG = '0'"); 

                sbQuery.Append(" LEFT JOIN TMAT_PARTLIST PT");
                sbQuery.Append(" ON OQ.PLT_CODE = PT.PLT_CODE");
                sbQuery.Append(" AND OQ.PT_ID = PT.PT_ID");
                
                sbQuery.Append(" LEFT JOIN TORD_PRODUCT P");
                sbQuery.Append(" ON PT.PLT_CODE = P.PLT_CODE");
                sbQuery.Append(" AND PT.PROD_CODE = P.PROD_CODE");
                
                sbQuery.Append(" LEFT JOIN LSE_STD_PART SP");
                sbQuery.Append(" ON OQ.PLT_CODE = SP.PLT_CODE");
                sbQuery.Append(" AND OQ.PART_CODE = SP.PART_CODE");
                
                sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E");
                sbQuery.Append(" ON O.PLT_CODE = E.PLT_CODE");
                sbQuery.Append(" AND O.OUT_EMP = E.EMP_CODE");



                foreach (DataRow row in dtParam.Rows)
                {
                    StringBuilder sbWhere = new StringBuilder(" WHERE OQ.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                    sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "P.PROD_CODE = @PROD_CODE"));
                    //sbWhere.Append(UTIL.GetWhere(row, "@OUT_REQ_STAT", "OQ.OUT_REQ_STAT = @OUT_REQ_STAT"));
                    sbWhere.Append(UTIL.GetWhere(row, "@OUT_REQ_STAT", "OQ.OUT_REQ_STAT IN ('50', '52')"));

                    sbWhere.Append(" AND OQ.DATA_FLAG = '0' AND P.DATA_FLAG = '0'");

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

        public static DataTable TMAT_OUT_REQ_QUERY7(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                StringBuilder sbQuery = new StringBuilder();
                sbQuery.Append(" SELECT");
                sbQuery.Append(" TREQ.PLT_CODE");
                sbQuery.Append(" ,PT.PROD_CODE");
                sbQuery.Append(" ,TREQ.OUT_REQ_ID");
                sbQuery.Append(" ,TREQ.PT_ID");
                sbQuery.Append(" ,TREQ.PART_CODE");
                sbQuery.Append(" ,TREQ.OUT_REQ_STAT");
                sbQuery.Append(" ,TOUT.ORD_SHIP_FLAG");
                sbQuery.Append(" ,TOUT.OUT_DATE");
                sbQuery.Append(" FROM TMAT_OUT_REQ TREQ");
                sbQuery.Append(" LEFT JOIN TMAT_OUT TOUT");
                sbQuery.Append(" ON TREQ.PLT_CODE = TOUT.PLT_CODE");
                sbQuery.Append(" AND TREQ.OUT_REQ_ID = TOUT.OUT_REQ_ID");
                sbQuery.Append(" AND TOUT.DATA_FLAG = '0'");
                
                sbQuery.Append(" LEFT JOIN TMAT_PARTLIST PT");
                sbQuery.Append(" ON TREQ.PLT_CODE = PT.PLT_CODE");
                sbQuery.Append(" AND TREQ.PT_ID = PT.PT_ID");




                foreach (DataRow row in dtParam.Rows)
                {
                    StringBuilder sbWhere = new StringBuilder(" WHERE TREQ.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                    sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "PT.PROD_CODE = @PROD_CODE"));
                    sbWhere.Append(UTIL.GetWhere(row, "@OUT_REQ_LOC", "TREQ.OUT_REQ_LOC = @OUT_REQ_LOC"));

                    sbWhere.Append(" AND TREQ.DATA_FLAG = '0'");

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

        public static DataTable TMAT_OUT_REQ_QUERY8(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                StringBuilder sbQuery = new StringBuilder();

                sbQuery.Append(" SELECT");
                sbQuery.Append(" O.PLT_CODE");
                sbQuery.Append(" ,O.OUT_REQ_ID");
                sbQuery.Append(" ,O.OUT_REQ_STAT");
                sbQuery.Append(" ,O.OUT_REQ_QTY");
                sbQuery.Append(" ,OU.OUT_QTY");
                sbQuery.Append(" ,O.PART_CODE");
                sbQuery.Append(" ,SP.PART_NAME");
                sbQuery.Append(" ,SP.MAT_LTYPE");
                sbQuery.Append(" ,SP.MAT_MTYPE");
                sbQuery.Append(" ,SP.MAT_STYPE");
                sbQuery.Append(" ,O.OUT_REQ_DATE");
                sbQuery.Append(" ,OU.SHIP_QTY");
                sbQuery.Append(" FROM TMAT_OUT_REQ O");
                sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE, OUT_REQ_ID, SUM(OUT_QTY) AS OUT_QTY, SUM(SHIP_QTY) AS SHIP_QTY FROM TMAT_OUT WHERE DATA_FLAG = '0' GROUP BY PLT_CODE, OUT_REQ_ID) OU");
                sbQuery.Append(" ON O.PLT_CODE = OU.PLT_CODE");
                sbQuery.Append(" AND O.OUT_REQ_ID = OU.OUT_REQ_ID");
                sbQuery.Append(" LEFT JOIN TMAT_PARTLIST PT");
                sbQuery.Append(" ON O.PLT_CODE = PT.PLT_CODE");
                sbQuery.Append(" AND O.PT_ID = PT.PT_ID");
                sbQuery.Append(" LEFT JOIN TORD_PRODUCT P");
                sbQuery.Append(" ON PT.PLT_CODE = P.PLT_CODE");
                sbQuery.Append(" AND PT.PROD_CODE = P.PROD_CODE");
                sbQuery.Append(" LEFT JOIN LSE_STD_PART SP");
                sbQuery.Append(" ON O.PLT_CODE = SP.PLT_CODE");
                sbQuery.Append(" AND O.PART_CODE = SP.PART_CODE");


                foreach (DataRow row in dtParam.Rows)
                {
                    StringBuilder sbWhere = new StringBuilder(" WHERE O.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                    sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "P.PROD_CODE = @PROD_CODE"));

                    sbWhere.Append(" AND O.DATA_FLAG = '0'");

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
