using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DMAT
{
    public class TMAT_STOCK_LOT_temp
    {
        public static DataTable TMAT_STOCK_LOT_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE   ");
                    sbQuery.Append(" 	, LOT_ID    ");
                    sbQuery.Append(" 	, STK_ID    ");
                    sbQuery.Append(" 	, UNIT_COST    ");
                    sbQuery.Append(" 	, STOCK_FLAG     ");
                    sbQuery.Append(" 	, YPGO_ID     ");
                    sbQuery.Append(" 	, OUT_ID     ");
                    sbQuery.Append(" 	, REG_DATE    ");
                    sbQuery.Append(" 	, REG_EMP     ");
                    sbQuery.Append(" 	, MDFY_DATE    ");
                    sbQuery.Append(" 	, MDFY_EMP     ");
                    sbQuery.Append(" FROM TMAT_STOCK_LOT   ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("   AND LOT_ID = @LOT_ID ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "LOT_ID")) isHasColumn = false;

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

        public static DataTable TMAT_STOCK_LOT_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT L.PLT_CODE   ");
                    sbQuery.Append(" 	, L.LOT_ID    ");
                    sbQuery.Append(" 	, L.STK_ID    ");
                    sbQuery.Append(" 	, L.UNIT_COST    ");
                    sbQuery.Append(" 	, L.STOCK_FLAG     ");
                    sbQuery.Append(" 	, L.YPGO_ID     ");
                    sbQuery.Append(" 	, L.OUT_ID     ");
                    sbQuery.Append(" 	, L.REG_DATE    ");
                    sbQuery.Append(" 	, L.REG_EMP     ");
                    sbQuery.Append(" 	, L.MDFY_DATE    ");
                    sbQuery.Append(" 	, L.MDFY_EMP     ");
                    sbQuery.Append(" 	, S.PART_CODE     ");
                    sbQuery.Append(" 	, S.STOCK_LOC     ");
                    sbQuery.Append(" 	, S.TOT_YPGO_AMT     ");
                    sbQuery.Append(" 	, S.PART_QTY     ");
                    sbQuery.Append(" 	, S.DETAIL_PART_NAME     ");
                    sbQuery.Append(" FROM TMAT_STOCK_LOT L  ");
                    sbQuery.Append("   INNER JOIN TMAT_STOCK S  ");
                    sbQuery.Append("    ON L.PLT_CODE = S.PLT_CODE  ");
                    sbQuery.Append("    AND L.STK_ID = S.STK_ID  ");
                    sbQuery.Append(" WHERE L.PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("   AND L.STOCK_FLAG IN ('NE','YP') ");
                    sbQuery.Append("   AND L.STK_ID = @STK_ID ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "STK_ID")) isHasColumn = false;

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

        public static void TMAT_STOCK_LOT_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TMAT_STOCK_LOT             ");
                    sbQuery.Append(" (  PLT_CODE			            	  ");
                    sbQuery.Append(" 	, LOT_ID    ");
                    sbQuery.Append(" 	, STK_ID    ");
                    sbQuery.Append(" 	, UNIT_COST    ");
                    sbQuery.Append(" 	, STOCK_FLAG     ");
                    sbQuery.Append(" 	, YPGO_ID     ");
                    sbQuery.Append(" 	, OUT_ID     ");
                    sbQuery.Append(" 	, CUTTING_CNT     ");
                    sbQuery.Append(" 	, REG_DATE    ");
                    sbQuery.Append("    , REG_EMP    ) 		                 ");
                    sbQuery.Append(" VALUES				              ");
                    sbQuery.Append(" (  @PLT_CODE			            	  ");
                    sbQuery.Append(" 	, @LOT_ID    ");
                    sbQuery.Append(" 	, @STK_ID    ");
                    sbQuery.Append(" 	, @UNIT_COST    ");
                    sbQuery.Append(" 	, @STOCK_FLAG     ");
                    sbQuery.Append(" 	, @YPGO_ID     ");
                    sbQuery.Append(" 	, @OUT_ID     ");
                    sbQuery.Append(" 	, (SELECT TOP 1 CUTTING_CNT FROM LSE_STD_PART WHERE PLT_CODE = @PLT_CODE AND PART_CODE = @PART_CODE)      ");
                    sbQuery.Append("    , GETDATE()		                  ");
                    sbQuery.Append("    , " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" )			  ");


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

        public static void TMAT_STOCK_LOT_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_STOCK_LOT	   ");
                    sbQuery.Append(" SET STOCK_FLAG = @STOCK_FLAG ");
                    sbQuery.Append("   , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("   , MDFY_EMP =  " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("   AND LOT_ID = @LOT_ID     ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "LOT_ID")) isHasColumn = false;

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

        public static void TMAT_STOCK_LOT_UPD3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_STOCK_LOT	   ");
                    sbQuery.Append(" SET STK_ID = @MV_STK_ID ");
                    sbQuery.Append("   , OLD_STK_ID = @STK_ID ");
                    sbQuery.Append("   , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("   , MDFY_EMP =  " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("   AND LOT_ID = @LOT_ID     ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "LOT_ID")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MV_STK_ID")) isHasColumn = false;

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

        public static void TMAT_STOCK_LOT_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_STOCK_LOT	   ");
                    sbQuery.Append(" SET OUT_ID = @OUT_ID ");
                    sbQuery.Append("   , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("   , MDFY_EMP =  " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("   AND LOT_ID = @LOT_ID     ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "LOT_ID")) isHasColumn = false;

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

        public static void TMAT_STOCK_LOT_UPD4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_STOCK_LOT	   ");
                    sbQuery.Append(" SET STK_ID = @MV_STK_ID ");
                    sbQuery.Append("   , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("   , MDFY_EMP =  " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("   AND LOT_ID = ANY (SELECT TOP @MV_QTY LOT_ID  ");
                    sbQuery.Append("                 FROM TMAT_STOCK_LOT   ");
                    sbQuery.Append("                 WHERE STOCK_FLAG IN ('NE','YP') AND STK_ID=@STK_ID ORDER BY REG_DATE)  ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "STK_ID")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MV_QTY")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MV_STK_ID")) isHasColumn = false;

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

        /// <summary>
        /// 밀링실적 취소시 컷팅수량 복원
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TMAT_STOCK_LOT_UPD5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_STOCK_LOT	   ");
                    sbQuery.Append(" SET CUTTING_CNT = @CUTTING_CNT ");
                    sbQuery.Append("   , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("   , MDFY_EMP =  " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("   AND LOT_ID = @LOT_ID     ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "LOT_ID")) isHasColumn = false;

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

        /// <summary>
        /// 밀링 실적 취소 복원
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TMAT_STOCK_LOT_UPD6(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_STOCK_LOT	   ");
                    sbQuery.Append(" SET CUTTING_CNT = CUTTING_CNT + @USE_AMT ");
                    sbQuery.Append("   , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("   , MDFY_EMP =  " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("   AND LOT_ID = @LOT_ID     ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "USE_AMT")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "LOT_ID")) isHasColumn = false;

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

        public static void TMAT_STOCK_LOT_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" DELETE FROM TMAT_STOCK_LOT	   ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("   AND YPGO_ID = @YPGO_ID     ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "YPGO_ID")) isHasColumn = false;

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

        public static void TMAT_STOCK_LOT_DEL2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    //sbQuery.Append(" UPDATE TMAT_STOCK_LOT	   ");
                    //sbQuery.Append(" SET STOCK_FLAG = 'PE' ");//폐기
                    //sbQuery.Append("   , MDFY_DATE = GETDATE() ");
                    //sbQuery.Append("   , MDFY_EMP =  " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" DELETE FROM TMAT_STOCK_LOT	   ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("   AND LOT_ID = @LOT_ID     ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "LOT_ID")) isHasColumn = false;

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

        public static void TMAT_STOCK_LOT_DEL3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" DELETE FROM TMAT_STOCK_LOT	   ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("   AND LOT_ID = ANY (SELECT TOP @DEL_QTY LOT_ID  ");
                    sbQuery.Append("                 FROM TMAT_STOCK_LOT   ");
                    sbQuery.Append("                 WHERE STOCK_FLAG IN ('NE','YP') AND STK_ID=@STK_ID ORDER BY REG_DATE )  ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "STK_ID")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "DEL_QTY")) isHasColumn = false;

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

    public class TMAT_STOCK_LOT_QUERY_temp
    {
        public static DataTable TMAT_STOCK_LOT_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT S.PLT_CODE     ");
                    sbQuery.Append(" 	, S.STK_ID    ");
                    sbQuery.Append(" 	, S.PART_CODE    ");
                    sbQuery.Append(" 	, S.DETAIL_PART_NAME    ");
                    sbQuery.Append(" 	, S.STOCK_LOC    ");
                    sbQuery.Append(" 	, S.PART_QTY     ");
                    sbQuery.Append(" 	, S.TOT_YPGO_AMT     ");
                    sbQuery.Append(" 	, SL.LOT_ID     ");
                    sbQuery.Append(" 	, SL.UNIT_COST     ");
                    sbQuery.Append(" 	, SL.STOCK_FLAG     ");
                    sbQuery.Append(" 	, SL.YPGO_ID     ");
                    sbQuery.Append(" 	, SL.OUT_ID     ");
                    sbQuery.Append(" 	, SL.REG_DATE     ");
                    sbQuery.Append(" 	, SL.REG_EMP     ");
                    sbQuery.Append(" 	, P.PART_CODE     ");
                    sbQuery.Append(" 	, P.PART_NAME     "); 
                    sbQuery.Append(" 	, P.MAT_UNIT     ");
                    sbQuery.Append(" 	, P.MAT_LTYPE     ");
                    sbQuery.Append(" 	, P.MAT_MTYPE     ");
                    sbQuery.Append(" 	, P.MAT_STYPE     ");

                    sbQuery.Append(" FROM LSE_STD_PART P ");
                    sbQuery.Append("    INNER JOIN TMAT_STOCK S  ");
                    sbQuery.Append("        ON P.PLT_CODE = S.PLT_CODE       ");
                    sbQuery.Append("        AND P.PART_CODE = S.PART_CODE     ");

                    sbQuery.Append("    INNER JOIN TMAT_STOCK_LOT SL  ");
                    sbQuery.Append("        ON S.PLT_CODE = SL.PLT_CODE       ");
                    sbQuery.Append("        AND S.STK_ID = SL.STK_ID     ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE P.DATA_FLAG = 0   ");
                        sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", " P.PLT_CODE = @PLT_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@YPGO_ID", " SL.YPGO_ID = @YPGO_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@STK_ID", " S.STK_ID = @STK_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", " S.PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DETAIL_PART_NAME", " S.DETAIL_PART_NAME = @DETAIL_PART_NAME"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@OUT_LOC", " S.STOCK_LOC = @OUT_LOC"));
                        sbWhere.Append(" AND SL.STOCK_FLAG IN ('NE','YP') ");
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


        public static DataTable TMAT_STOCK_LOT_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT S.PLT_CODE     ");
                    sbQuery.Append(" 	, S.STK_ID    ");
                    sbQuery.Append(" 	, S.PART_CODE    ");
                    sbQuery.Append(" 	, S.STOCK_LOC    ");
                    sbQuery.Append(" 	, S.PART_QTY     ");
                    sbQuery.Append(" 	, S.TOT_YPGO_AMT     ");

                    sbQuery.Append(" 	, SL.LOT_ID     ");
                    sbQuery.Append(" 	, SL.UNIT_COST     ");
                    sbQuery.Append(" 	, SL.STOCK_FLAG     ");
                    sbQuery.Append(" 	, SL.YPGO_ID     ");
                    sbQuery.Append(" 	, SL.OUT_ID     ");
                    sbQuery.Append(" 	, SL.REG_DATE     ");
                    sbQuery.Append(" 	, SL.REG_EMP     ");

                    sbQuery.Append(" 	, P.PART_CODE     ");
                    sbQuery.Append(" 	, P.PART_NAME     ");
                    sbQuery.Append(" 	, P.MAT_UNIT     ");
                    sbQuery.Append(" 	, SL.CUTTING_CNT     ");
                    sbQuery.Append(" 	, P.CUTTING_CNT  AS STD_CUTTING_CNT    ");

                    sbQuery.Append(" FROM LSE_STD_PART P ");
                    sbQuery.Append("    INNER JOIN TMAT_STOCK S  ");
                    sbQuery.Append("        ON P.PLT_CODE = S.PLT_CODE       ");
                    sbQuery.Append("        AND P.PART_CODE = S.PART_CODE     ");

                    sbQuery.Append("    INNER JOIN TMAT_STOCK_LOT SL  ");
                    sbQuery.Append("        ON S.PLT_CODE = SL.PLT_CODE       ");
                    sbQuery.Append("        AND S.STK_ID = SL.STK_ID     ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE P.DATA_FLAG = 0   ");
                        sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", " P.PLT_CODE = @PLT_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@OUT_ID", " SL.OUT_ID = @OUT_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@STK_ID", " S.STK_ID = @STK_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", " S.PART_CODE = @PART_CODE"));
                        sbWhere.Append(" AND SL.STOCK_FLAG IN ('OT') ");
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


        public static DataTable TMAT_STOCK_LOT_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT S.PLT_CODE     ");
                    sbQuery.Append(" 	, S.STK_ID    ");
                    sbQuery.Append(" 	, S.PART_CODE    ");
                    sbQuery.Append(" 	, S.STOCK_LOC    ");
                    sbQuery.Append(" 	, S.PART_QTY     ");
                    sbQuery.Append(" 	, S.TOT_YPGO_AMT     ");

                    sbQuery.Append(" 	, SL.LOT_ID     ");
                    sbQuery.Append(" 	, SL.UNIT_COST     ");
                    sbQuery.Append(" 	, SL.STOCK_FLAG     ");
                    sbQuery.Append(" 	, SL.YPGO_ID     ");
                    sbQuery.Append(" 	, SL.OUT_ID     ");
                    sbQuery.Append(" 	, SL.REG_DATE     ");
                    sbQuery.Append(" 	, SL.REG_EMP     ");

                    sbQuery.Append(" 	, P.PART_CODE     ");
                    sbQuery.Append(" 	, P.PART_NAME     ");
                    sbQuery.Append(" 	, P.MAT_UNIT     ");
                    sbQuery.Append(" 	, SL.CUTTING_CNT     ");
                    sbQuery.Append(" 	, ISNULL(P.CUTTING_CNT,1)  AS STD_CUTTING_CNT    ");

                    sbQuery.Append(" FROM LSE_STD_PART P ");
                    sbQuery.Append("    INNER JOIN TMAT_STOCK S  ");
                    sbQuery.Append("        ON P.PLT_CODE = S.PLT_CODE       ");
                    sbQuery.Append("        AND P.PART_CODE = S.PART_CODE     ");

                    sbQuery.Append("    INNER JOIN TMAT_STOCK_LOT SL  ");
                    sbQuery.Append("        ON S.PLT_CODE = SL.PLT_CODE       ");
                    sbQuery.Append("        AND S.STK_ID = SL.STK_ID     ");

                    sbQuery.Append("    INNER JOIN TSHP_WORKORDER WO  ");
                    sbQuery.Append("        ON WO.PLT_CODE = SL.PLT_CODE       ");
                    sbQuery.Append("        AND WO.WO_NO = SL.OUT_ID     ");

                    sbQuery.Append("    INNER JOIN LSE_STD_PROC PR  ");
                    sbQuery.Append("        ON PR.PLT_CODE = WO.PLT_CODE       ");
                    sbQuery.Append("        AND PR.PROC_CODE = WO.PROC_CODE    ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE P.DATA_FLAG = 0   ");
                        sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", " P.PLT_CODE = @PLT_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@OUT_ID", " SL.OUT_ID = @OUT_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@STK_ID", " S.STK_ID = @STK_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", " S.PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WO_TYPE", " PR.WO_TYPE = @WO_TYPE"));
                        sbWhere.Append(" AND SL.STOCK_FLAG IN ('OT') ");
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
