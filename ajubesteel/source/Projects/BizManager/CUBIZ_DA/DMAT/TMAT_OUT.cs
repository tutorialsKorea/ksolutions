using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DMAT
{
    public class TMAT_OUT
    {
        public static DataTable TMAT_OUT_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE		   ");
                    sbQuery.Append(" ,OUT_ID					   ");
                    sbQuery.Append(" ,OUT_QTY				   ");
                    sbQuery.Append(" ,ISNULL(SHIP_QTY, 0) SHIP_QTY				   ");
                    sbQuery.Append(" ,ISNULL(REMAIN_QTY, OUT_QTY) REMAIN_QTY				   ");
                    sbQuery.Append(" FROM TMAT_OUT		   ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND OUT_ID = @OUT_ID		   ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "OUT_ID")) isHasColumn = false;

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

        public static DataTable TMAT_BALJU_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,BALJU_NUM ");
                    sbQuery.Append(" ,BALJU_SEQ ");
                    sbQuery.Append(" ,REQUEST_NO ");
                    sbQuery.Append(" ,REQUEST_SEQ ");
                    sbQuery.Append(" ,PART_CODE ");
                    sbQuery.Append(" ,DUE_DATE ");
                    sbQuery.Append(" ,UNIT_COST ");
                    sbQuery.Append(" ,QTY ");
                    sbQuery.Append(" ,OK_QTY ");
                    sbQuery.Append(" ,AMT ");
                    sbQuery.Append(" ,CHG_UNIT_COST ");
                    sbQuery.Append(" ,MAT_SPEC ");
                    sbQuery.Append(" ,MAT_WEIGHT ");
                    sbQuery.Append(" ,BAL_STAT ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,INS_FLAG ");
                    sbQuery.Append(" ,INS_DATE ");
                    sbQuery.Append(" ,INS_EMP ");
                    sbQuery.Append(" ,C_REASON ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,MDFY_DATE ");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append(" ,TYP_LOC ");
                    sbQuery.Append("  FROM TMAT_BALJU  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND BALJU_NUM = @BALJU_NUM  ");
                    sbQuery.Append("  AND BALJU_SEQ = @BALJU_SEQ  ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "BALJU_NUM")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "BALJU_SEQ")) isHasColumn = false;

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

        public static void TMAT_OUT_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                 DataSet dsResult = new DataSet();

                 if (dtParam.Rows.Count > 0)
                 {
                     StringBuilder sbQuery = new StringBuilder();

                     sbQuery.Append(" INSERT INTO TMAT_OUT");
                     sbQuery.Append(" (PLT_CODE			 ");
                     sbQuery.Append(" ,OUT_ID			 ");
                     sbQuery.Append(" ,OUT_REQ_ID		 ");
                     sbQuery.Append(" ,PART_CODE		 ");
                     sbQuery.Append(" ,OUT_FIELD		 ");
                     sbQuery.Append(" ,OUT_DATE			 ");
                     sbQuery.Append(" ,OUT_EMP			 ");
                     sbQuery.Append(" ,OUT_QTY			 ");
                     sbQuery.Append(" ,OUT_AMT			 ");
                     sbQuery.Append(" ,OUT_LOC			 ");
                     sbQuery.Append(" ,OUT_ORG			 ");
                     sbQuery.Append(" ,SCOMMENT			 ");
                     sbQuery.Append(" ,REG_DATE			 ");
                     sbQuery.Append(" ,REG_EMP			 ");
                     sbQuery.Append(" ,DATA_FLAG)		 ");
                     sbQuery.Append(" VALUES			 ");
                     sbQuery.Append(" (@PLT_CODE		 ");
                     sbQuery.Append(" ,@OUT_ID			 ");
                     sbQuery.Append(" ,@OUT_REQ_ID		 ");
                     sbQuery.Append(" ,@PART_CODE		 ");
                     sbQuery.Append(" ,@OUT_FIELD		 ");
                     sbQuery.Append(" ,@OUT_DATE		 ");
                     sbQuery.Append(" ,@OUT_EMP			 ");
                     sbQuery.Append(" ,@OUT_QTY			 ");
                     sbQuery.Append(" ,@OUT_AMT			 ");
                     sbQuery.Append(" ,@OUT_LOC			 ");
                     sbQuery.Append(" ,@OUT_ORG			 ");
                     sbQuery.Append(" ,@SCOMMENT		 ");
                     sbQuery.Append(" ,GETDATE()		 ");
                     sbQuery.Append(" ," + UTIL.GetValidValue(ConnInfo.UserID));
                     sbQuery.Append(" ,0)		 ");

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

        public static void TMAT_OUT_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TMAT_OUT		   ");
                    sbQuery.Append(" SET YPGO_FLAG = @YPGO_FLAG");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND OUT_ID = @OUT_ID      ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "OUT_ID")) isHasColumn = false;

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

        public static void TMAT_OUT_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TMAT_OUT		   ");
                    sbQuery.Append(" SET DATA_FLAG = @DATA_FLAG");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND OUT_ID = @OUT_ID      ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "OUT_ID")) isHasColumn = false;

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

        public static void TMAT_OUT_UPD3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TMAT_OUT		   ");
                    sbQuery.Append(" SET ORD_SHIP_FLAG = @ORD_SHIP_FLAG");
                    sbQuery.Append("   , SHIP_QTY = @SHIP_QTY");
                    sbQuery.Append("   , REMAIN_QTY = @REMAIN_QTY");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND OUT_ID = @OUT_ID      ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "OUT_ID")) isHasColumn = false;

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

        public static void TMAT_OUT_UPD4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TMAT_OUT		   ");
                    sbQuery.Append(" SET SCOMMENT = @SCOMMENT");
                    sbQuery.Append(" ,MDFY_EMP = '" + ConnInfo.UserID + "' ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND OUT_ID = @OUT_ID      ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "OUT_ID")) isHasColumn = false;

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

    public class TMAT_OUT_QUERY
    {
        public static DataTable TMAT_OUT_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();


                    sbQuery.Append(" SELECT  O.PLT_CODE     ");
                    sbQuery.Append(" 	, O.OUT_REQ_ID      ");
                    sbQuery.Append(" 	, OREQ.OUT_REQ_EMP      ");
                    sbQuery.Append(" 	, O.OUT_ID          ");
                    sbQuery.Append(" 	, CASE WHEN OREQ.PT_ID IS NULL THEN OREQ.PROD_CODE ELSE PT.PROD_CODE END AS PROD_CODE       ");
                    sbQuery.Append(" 	, CASE WHEN OREQ.PT_ID IS NULL THEN OREQ.PROD_CODE ELSE PT.PROD_CODE END AS PROD_CODE_GROUP       ");
                    sbQuery.Append(" 	, O.PART_CODE       ");
                    sbQuery.Append(" 	, P.PART_NAME       ");
                    sbQuery.Append(" 	, P.PART_PRODTYPE   ");
                    sbQuery.Append(" 	, P.DRAW_NO         ");
                    sbQuery.Append(" 	, P.MAT_SPEC        ");
                    sbQuery.Append(" 	, P.MAT_LTYPE       ");
                    sbQuery.Append(" 	, P.MAT_MTYPE       ");
                    sbQuery.Append(" 	, P.MAT_STYPE       ");
                    sbQuery.Append(" 	, P.MAT_TYPE       ");
                    sbQuery.Append(" 	, O.OUT_DATE        ");
                    sbQuery.Append(" 	, O.OUT_EMP         ");
                    sbQuery.Append(" 	, O.OUT_QTY         ");
                    sbQuery.Append(" ,O.OUT_AMT			 ");
                    sbQuery.Append(" ,O.OUT_LOC			 ");
                    sbQuery.Append(" 	, O.OUT_ORG         ");
                    sbQuery.Append(" 	, O.SCOMMENT        ");
                    sbQuery.Append(" 	, OREQ.OUT_REQ_LOC     ");
                    sbQuery.Append("    , OREQ.STOCK_CODE      ");
                    sbQuery.Append("    , STOCK.CD_NAME AS STOCK_NAME      ");
                    sbQuery.Append(" 	, O.REG_DATE        ");
                    sbQuery.Append(" 	, O.REG_EMP	        ");
                    sbQuery.Append(" 	, AD.DRAW_EMP          ");
                    sbQuery.Append(" 	, PD.DUE_DATE          ");
                    sbQuery.Append(" 	, PD.CHG_DUE_DATE          ");
                    sbQuery.Append(" 	, PD.PROD_NAME          ");

                    sbQuery.Append(" 	, PT.PART_QTY          ");
                    sbQuery.Append(" 	, PD.PROD_QTY          ");
                    sbQuery.Append(" 	, PT.O_PART_QTY          ");
                    sbQuery.Append(" 	, PD.SCOMMENT AS ORD_SCOMMENT          ");

                    sbQuery.Append(" 	, PD.CVND_CODE          ");
                    sbQuery.Append(" 	, V.VEN_NAME AS CVND_NAME          ");

                    sbQuery.Append(" 	, R.RET_REQ_STAT AS RET_STATUS          ");
                    sbQuery.Append(" 	, CASE WHEN R.RET_REQ_STAT IS NOT NULL THEN '재입고' ELSE NULL END AS RET_STAT          ");
                    sbQuery.Append(" 	, R.RET_REQ_QTY AS RET_QTY          ");
                    sbQuery.Append(" 	, R.SCOMMENT AS RET_SCOMMENT         ");

                    sbQuery.Append(" 	, AW.WO_FLAG          ");

                    sbQuery.Append(" 	, OREQ.SCOMMENT AS REQ_SCOMMENT         ");

                    sbQuery.Append(" 	, PT.PART_QTY          ");
                    sbQuery.Append(" 	, CASE WHEN ISNULL(PT.ORD_QTY, 0) > 0 THEN PT.ORD_QTY ELSE PD.PROD_QTY END AS PROD_QTY  ");
                    sbQuery.Append(" 	, PT.O_PART_QTY          ");

                    sbQuery.Append(" 	, PD.PROD_FLAG          ");
                    sbQuery.Append(" 	, PD.PROD_TYPE          ");

                    sbQuery.Append(" FROM TMAT_OUT O LEFT JOIN TMAT_OUT_REQ OREQ ");
                    sbQuery.Append("  ON O.PLT_CODE = OREQ.PLT_CODE AND O.OUT_REQ_ID = OREQ.OUT_REQ_ID ");



                    sbQuery.Append("     LEFT JOIN LSE_STD_PART P ");
                    sbQuery.Append("   ON O.PLT_CODE = P.PLT_CODE             ");
                    sbQuery.Append(" AND O.PART_CODE = P.PART_CODE            ");
                    
                    sbQuery.Append("  LEFT JOIN TSTD_CODES STOCK ");
                    sbQuery.Append("   ON STOCK.CAT_CODE = 'M005' ");
                    sbQuery.Append("   AND OREQ.PLT_CODE = STOCK.PLT_CODE");
                    sbQuery.Append("   AND OREQ.STOCK_CODE = STOCK.CD_CODE");

                    sbQuery.Append("  LEFT JOIN TMAT_PARTLIST PT ");
                    sbQuery.Append("  ON OREQ.PLT_CODE = PT.PLT_CODE ");
                    sbQuery.Append("  AND OREQ.PT_ID = PT.PT_ID ");

                    sbQuery.Append("  LEFT JOIN TORD_PRODUCT PD ");
                    sbQuery.Append("  ON PT.PLT_CODE = PD.PLT_CODE ");
                    sbQuery.Append("  AND PT.PROD_CODE = PD.PROD_CODE ");

                    sbQuery.Append("  LEFT JOIN TSTD_VENDOR V ");
                    sbQuery.Append("  ON PD.PLT_CODE = V.PLT_CODE ");
                    sbQuery.Append("  AND PD.CVND_CODE = V.VEN_CODE ");

                    sbQuery.Append("  LEFT JOIN (SELECT * FROM ( ");
                    sbQuery.Append("  SELECT PLT_CODE, OUT_ID, SCOMMENT, RET_REQ_QTY, RET_REQ_STAT, ROW_NUMBER() OVER(PARTITION BY OUT_ID ORDER BY REG_DATE DESC) AS SEQ FROM TMAT_RET_REQ ");
                    sbQuery.Append("  WHERE RET_REQ_STAT = '22' AND DATA_FLAG = '0' AND OUT_ID IS NOT NULL ");
                    sbQuery.Append("  ) A ");
                    sbQuery.Append("  WHERE SEQ = 1 ");
                    sbQuery.Append("  ) R ");
                    sbQuery.Append("  ON O.PLT_CODE = R.PLT_CODE ");
                    sbQuery.Append("  AND O.OUT_ID = R.OUT_ID ");

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
                        StringBuilder sbWhere = new StringBuilder(" WHERE O.DATA_FLAG = 0  ");

                        sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", " O.PLT_CODE = @PLT_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DATE,@E_DATE", "O.OUT_DATE BETWEEN @S_DATE AND @E_DATE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "P.PART_CODE LIKE '%' + @PART_LIKE + '%' OR P.PART_NAME LIKE '%' + @PART_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DRAW_LIKE", "P.DRAW_NO LIKE '%' + @DRAW_LIKE + '%' "));
                        sbWhere.Append(UTIL.GetWhere(row, "@SPEC_LIKE", "P.MAT_SPEC LIKE '%' + @SPEC_LIKE + '%' "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_LTYPE", "P.MAT_LTYPE = @MAT_LTYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_MTYPE", "P.MAT_MTYPE = @MAT_MTYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_STYPE", "P.MAT_STYPE = @MAT_STYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@OUT_REQ_NAME", "OREQ.OUT_REQ_EMP IN ( SELECT EMP_CODE FROM TSTD_EMPLOYEE WHERE EMP_NAME LIKE '%' + @OUT_REQ_NAME + '%' )"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_PRODTYPE", "P.PART_PRODTYPE LIKE '%' + @PART_PRODTYPE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_LIKE", "(PD.PROD_CODE LIKE '%' + @PROD_LIKE + '%' OR PD.PROD_NAME LIKE '%' + @PROD_LIKE + '%' OR OREQ.PROD_CODE LIKE '%' + @PROD_LIKE + '%')"));
                        //sbWhere.Append(" ORDER BY R.RET_REQ_DATE DESC ");

                        sbWhere.Append(" AND ISNULL(PD.DATA_FLAG, '0') = '0'");

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

        public static DataTable TMAT_OUT_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT				 ");
                    sbQuery.Append(" O.PLT_CODE			 ");
                    sbQuery.Append(" ,ORE.FIELD_CODE	 ");
                    sbQuery.Append(" ,F.FIELD_NAME		 ");
                    sbQuery.Append(" ,O.OUT_ID			 ");
                    sbQuery.Append(" ,ORE.OUT_REQ_ID	 ");
                    sbQuery.Append(" ,ORE.OUT_REQ_DATE	 ");
                    sbQuery.Append(" ,ORE.PART_CODE		 ");
                    sbQuery.Append(" ,PT.PART_NAME		 ");
                    sbQuery.Append(" ,PT.DRAW_NO		 ");
                    sbQuery.Append(" ,PT.MAT_SPEC		 ");
                    sbQuery.Append(" ,PT.PART_PRODTYPE		 ");
                    sbQuery.Append(" ,ORE.REG_EMP AS OUT_REQ_EMP	 "); 
                    sbQuery.Append(" ,ORE.OUT_REQ_QTY	 ");
                    sbQuery.Append(" ,O.OUT_QTY			 ");
                    sbQuery.Append(" ,O.OUT_AMT			 ");
                    sbQuery.Append(" ,O.OUT_LOC			 ");
                    sbQuery.Append(" ,(SELECT ISNULL(SUM(OT.OUT_QTY),0) AS YPGO_QTY FROM TMAT_OUT OT WHERE O.OUT_REQ_ID = OT.OUT_REQ_ID AND OT.YPGO_FLAG = '1') AS YPGO_QTY					   ");
                    sbQuery.Append(" ,ORE.OUT_REQ_QTY - (SELECT ISNULL(SUM(OT.OUT_QTY),0) AS YPGO_QTY FROM TMAT_OUT OT WHERE O.OUT_REQ_ID = OT.OUT_REQ_ID AND OT.YPGO_FLAG = '1') AS REMAIN_QTY");
                    sbQuery.Append(" ,PT.MAT_UNIT							");
                    sbQuery.Append(" ,O.SCOMMENT							");
                    sbQuery.Append(" FROM TMAT_OUT O						");
                    sbQuery.Append(" LEFT JOIN TMAT_OUT_REQ ORE				");
                    sbQuery.Append(" ON O.PLT_CODE = ORE.PLT_CODE			");
                    sbQuery.Append(" AND O.OUT_REQ_ID = ORE.OUT_REQ_ID		");
                    sbQuery.Append(" 										");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART PT				");
                    sbQuery.Append(" ON ORE.PLT_CODE = PT.PLT_CODE			");
                    sbQuery.Append(" AND ORE.PART_CODE = PT.PART_CODE		");
                    sbQuery.Append(" 										");
                    sbQuery.Append(" LEFT JOIN TSTD_FIELD F					");
                    sbQuery.Append(" ON ORE.PLT_CODE = F.PLT_CODE			");
                    sbQuery.Append(" AND ORE.FIELD_CODE = F.FIELD_CODE		");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE O.DATA_FLAG = 0  ");

                        sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", " O.PLT_CODE = @PLT_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@FIELD_CODE", " ORE.FIELD_CODE = @FIELD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_REQ_DATE,@E_REQ_DATE", "ORE.OUT_REQ_DATE BETWEEN @S_REQ_DATE AND @E_REQ_DATE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_OUT_DATE,@E_OUT_DATE", "O.OUT_DATE BETWEEN @S_OUT_DATE AND @E_OUT_DATE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", " (ORE.PART_CODE LIKE '%' + @PART_LIKE + '%' OR PT.PART_NAME LIKE '%' + @PART_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DRAW_LIKE", " (PT.DRAW_NO LIKE '%' + @DRAW_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@SPEC_LIKE", " (PT.MAT_SPEC LIKE '%' + @SPEC_LIKE + '%')"));

                        sbWhere.Append(" AND ISNULL(O.YPGO_FLAG,'0') <> '1' ");
                        sbWhere.Append(" AND O.OUT_REQ_ID IS NOT NULL ");

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

        public static DataTable TMAT_OUT_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT							");																													
                    sbQuery.Append("   O.PLT_CODE					");
                    sbQuery.Append("  ,O.OUT_ID					");																			
                    sbQuery.Append("  ,O.OUT_FIELD AS FIELD_CODE	");																						
                    sbQuery.Append("  ,F.FIELD_NAME					");																			
                    
                    sbQuery.Append("  ,O.PART_CODE					");																		
                    sbQuery.Append("  ,PT.PART_NAME					");																		
                    sbQuery.Append("  ,PT.DRAW_NO					");																			
                    sbQuery.Append("  ,PT.MAT_SPEC					");
                    sbQuery.Append("  ,PT.PART_PRODTYPE					");
                    sbQuery.Append("  ,PT.MAT_LTYPE					");
                    sbQuery.Append("  ,PT.SCOMMENT AS PT_SCOMMENT					");																			
                    sbQuery.Append("  ,O.OUT_QTY					");																			
                    sbQuery.Append("  ,O.OUT_AMT		            ");
                    sbQuery.Append("  ,O.OUT_LOC		            ");

                    //sbQuery.Append(" ,(SELECT ISNULL(SUM(OT.OUT_QTY),0) AS YPGO_QTY ");
                    //sbQuery.Append("    FROM TMAT_OUT OT WHERE O.OUT_REQ_ID = OT.OUT_REQ_ID AND OT.YPGO_FLAG = '1') AS YPGO_QTY					   ");
                    //sbQuery.Append(" ,ORE.OUT_REQ_QTY - (SELECT ISNULL(SUM(OT.OUT_QTY),0) AS YPGO_QTY ");
                    //sbQuery.Append("    FROM TMAT_OUT OT WHERE O.OUT_REQ_ID = OT.OUT_REQ_ID AND OT.YPGO_FLAG = '1') AS REMAIN_QTY");

                    sbQuery.Append("  ,PT.MAT_UNIT					");																											
                    sbQuery.Append("  ,O.SCOMMENT			        ");

                    sbQuery.Append(" FROM TMAT_OUT O					");
                    
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART PT			 ");
                    sbQuery.Append(" ON O.PLT_CODE = PT.PLT_CODE		 ");
                    sbQuery.Append(" AND O.PART_CODE = PT.PART_CODE		 ");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_FIELD F				 ");
                    sbQuery.Append(" ON O.PLT_CODE = F.PLT_CODE			 ");
                    sbQuery.Append(" AND O.OUT_FIELD = F.FIELD_CODE		 ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE O.DATA_FLAG = 0  ");

                        sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", " O.PLT_CODE = @PLT_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@FIELD_CODE", " O.OUT_FIELD = @FIELD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_OUT_DATE,@E_OUT_DATE", "O.OUT_DATE BETWEEN @S_OUT_DATE AND @E_OUT_DATE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", " (O.PART_CODE LIKE '%' + @PART_LIKE + '%' OR PT.PART_NAME LIKE '%' + @PART_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DRAW_LIKE", " (PT.DRAW_NO LIKE '%' + @DRAW_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@SPEC_LIKE", " (PT.MAT_SPEC LIKE '%' + @SPEC_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_LTYPE", " PT.MAT_LTYPE = @MAT_LTYPE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_PROD_LIKE", " PT.PART_PRODTYPE LIKE '%' + @PART_PROD_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@SCOMMENT_LIKE", " PT.SCOMMENT LIKE '%' + @SCOMMENT_LIKE + '%'"));

                        sbWhere.Append(" AND ISNULL(O.YPGO_FLAG,'0') <> '1' ");
                        sbWhere.Append(" AND O.OUT_REQ_ID IS NULL ");

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
