using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DTOL
{
    public class TTOL_TOOLLIST
    {
        public static DataTable TTOL_TOOLLIST_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT   PLT_CODE         ");
                    sbQuery.Append("       , TL_LOT             ");
                    sbQuery.Append("       , WO_NO             ");
                    sbQuery.Append("       , TL_CODE           ");
                    sbQuery.Append("       , TL_LIFE            ");
                    sbQuery.Append("       , TL_STAT           ");
                    sbQuery.Append("       , YPGO_DATE           ");
                    sbQuery.Append("       , SCOMMENT          ");
                    sbQuery.Append("       , REG_DATE          ");
                    sbQuery.Append("       , REG_EMP           ");
                    sbQuery.Append("       , MDFY_DATE         ");
                    sbQuery.Append("       , MDFY_EMP          ");
                    sbQuery.Append("  FROM TTOL_TOOLLIST       ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append("   AND TL_LOT = @TL_LOT      ");
                    sbQuery.Append("   AND TL_STAT = 'NP'      ");  //신품

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "TL_LOT")) isHasColumn = false;

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

        public static DataTable TTOL_TOOLLIST_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT ");
                    sbQuery.Append("       PLT_CODE         ");
                    sbQuery.Append("       , TL_LOT             ");
                    sbQuery.Append("       , WO_NO             ");
                    sbQuery.Append("       , TL_CODE           ");
                    sbQuery.Append("       , TL_LIFE            ");
                    sbQuery.Append("       , TL_STAT           ");
                    sbQuery.Append("       , YPGO_DATE           ");
                    sbQuery.Append("       , SCOMMENT          ");
                    sbQuery.Append("       , REG_DATE          ");
                    sbQuery.Append("       , REG_EMP           ");
                    sbQuery.Append("       , MDFY_DATE         ");
                    sbQuery.Append("       , MDFY_EMP          ");
                    sbQuery.Append("  FROM TTOL_TOOLLIST       ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append("   AND TL_CODE = @TL_CODE      ");
                    sbQuery.Append("   AND TL_STAT = 'NP'      ");  //신품
                    sbQuery.Append(" ORDER BY YPGO_DATE ");
                    
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "TL_CODE")) isHasColumn = false;

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

        public static DataTable TTOL_TOOLLIST_SER3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT   PLT_CODE         ");
                    sbQuery.Append("       , TL_LOT             ");
                    sbQuery.Append("       , WO_NO             ");
                    sbQuery.Append("       , TL_CODE           ");
                    sbQuery.Append("       , TL_LIFE            ");
                    sbQuery.Append("       , TL_STAT           ");
                    sbQuery.Append("       , YPGO_DATE           ");
                    sbQuery.Append("       , SCOMMENT          ");
                    sbQuery.Append("       , REG_DATE          ");
                    sbQuery.Append("       , REG_EMP           ");
                    sbQuery.Append("       , MDFY_DATE         ");
                    sbQuery.Append("       , MDFY_EMP          ");
                    sbQuery.Append("  FROM TTOL_TOOLLIST       ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append("   AND TL_CODE = @TL_CODE      ");
                    sbQuery.Append("   AND DATA_FLAG = '0'      ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "TL_CODE")) isHasColumn = false;

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
        /// 상태 업데이트
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TTOL_TOOLLIST_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TTOL_TOOLLIST                      ");
                    sbQuery.Append("    SET  TL_STAT = @TL_STAT          ");
                    sbQuery.Append("        , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("        , MDFY_EMP = "+ UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE           ");
                    sbQuery.Append("    AND TL_LOT = @TL_LOT             ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "TL_LOT")) isHasColumn = false;

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
        /// 수명업데이트
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TTOL_TOOLLIST_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TTOL_TOOLLIST                      ");
                    sbQuery.Append("    SET  TL_LIFE = @TL_LIFE          ");
                    sbQuery.Append("        , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("        , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE           ");
                    sbQuery.Append("    AND TL_LOT = @TL_LOT             ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "TL_LOT")) isHasColumn = false;

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
        /// 수명 업데이트(실적처리)
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TTOL_TOOLLIST_UPD3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TTOL_TOOLLIST                      ");
                    sbQuery.Append("    SET  TL_LIFE = TL_LIFE + CONVERT(DECIMAL,@TL_LIFE_USE)       ");
                    sbQuery.Append("        , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("        , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE           ");
                    sbQuery.Append("    AND TL_LOT = @TL_LOT             ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "TL_LOT")) isHasColumn = false;

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

        public static void TTOL_TOOLLIST_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TTOL_TOOLLIST SET                     ");
                    sbQuery.Append(" DEL_DATE = GETDATE()");
                    sbQuery.Append(" , DEL_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , DATA_FLAG = 2");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE           ");
                    sbQuery.Append("    AND TL_LOT = @TL_LOT             ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "TL_LOT")) isHasColumn = false;

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

        public static void TTOL_TOOLLIST_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO TTOL_TOOLLIST ");
                    sbQuery.Append(" (                         ");
                    sbQuery.Append("        PLT_CODE");
                    sbQuery.Append("      , TL_LOT");
                    sbQuery.Append("      , WO_NO");
                    sbQuery.Append("      , TL_CODE");
                    sbQuery.Append("      , TL_LIFE");
                    sbQuery.Append("      , TL_STAT");
                    sbQuery.Append("      , YPGO_DATE");
                    sbQuery.Append("      , SCOMMENT");
                    sbQuery.Append("      , REG_DATE");
                    sbQuery.Append("      , REG_EMP");
                    sbQuery.Append("      , DATA_FLAG");
                    sbQuery.Append(" )                         ");
                    sbQuery.Append(" VALUES                    ");
                    sbQuery.Append(" (                         ");
                    sbQuery.Append("        @PLT_CODE");
                    sbQuery.Append("      , @TL_LOT");
                    sbQuery.Append("      , @WO_NO");
                    sbQuery.Append("      , @TL_CODE");
                    sbQuery.Append("      , @TL_LIFE");
                    sbQuery.Append("      , @TL_STAT");
                    sbQuery.Append("      , @YPGO_DATE");
                    sbQuery.Append("      , @SCOMMENT");
                    sbQuery.Append("      , GETDATE()");
                    sbQuery.Append("      , " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("      , @DATA_FLAG");
                    sbQuery.Append(" )                         ");

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
    }

    public class TTOL_TOOLLIST_QUERY
    {
        public static DataTable TTOL_TOOLLIST_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT   T.PLT_CODE         ");
                    sbQuery.Append("       , T.TL_CODE             ");
                    sbQuery.Append("       , T.TL_NAME             ");
                    sbQuery.Append("       , T.TL_TYPE             ");
                    sbQuery.Append("       , T.TL_LTYPE            ");
                    sbQuery.Append("       , T.TL_MTYPE            ");
                    sbQuery.Append("       , T.TL_STYPE            ");
                    sbQuery.Append("       , T.TL_SPEC             ");
                    sbQuery.Append("       , T.TL_MIN              ");
                    sbQuery.Append("       , T.TL_MAX              ");
                    sbQuery.Append("       , T.TL_DANGER_QTY       ");
                    sbQuery.Append("       , T.TL_MAKER            ");
                    sbQuery.Append("       , T.TL_UNITCOST         ");
                    sbQuery.Append("       , T.TL_UNIT             ");
                    sbQuery.Append("       , T.HOLDER              ");
                    sbQuery.Append("       , T.TL_LENGTH           ");
                    sbQuery.Append("       , T.MAIN_VND            ");
                    sbQuery.Append("       , T.TL_QTY              ");
                    sbQuery.Append("       , T.TL_D_QTY            ");
                    sbQuery.Append("       , T.TL_IMAGE            ");
                    sbQuery.Append("       , T.REG_DATE          ");
                    sbQuery.Append("       , T.REG_EMP           ");
                    sbQuery.Append("       , T.MDFY_DATE         ");
                    sbQuery.Append("       , T.MDFY_EMP          ");
                    sbQuery.Append("       , TL.TL_LOT             ");
                    sbQuery.Append("       , T.SCOMMENT            ");
                    sbQuery.Append("       , TL.WO_NO             ");
                    sbQuery.Append("       , TL.TL_CODE           ");
                    sbQuery.Append("       , TL.TL_LIFE            ");
                    sbQuery.Append("       , TL.TL_STAT           ");
                    sbQuery.Append("       , TL.YPGO_DATE           ");
                    sbQuery.Append("       , TL.SCOMMENT          ");
                    sbQuery.Append("       , TL.REG_DATE          ");
                    sbQuery.Append("       , TL.REG_EMP           ");
                    sbQuery.Append("       , TL.MDFY_DATE         ");
                    sbQuery.Append("       , TL.MDFY_EMP          ");
                    sbQuery.Append("  FROM TSTD_TOOL T      ");
                    sbQuery.Append("    INNER JOIN TTOL_TOOLLIST TL      ");
                    sbQuery.Append("        ON T.PLT_CODE = TL.PLT_CODE      ");
                    sbQuery.Append("        AND T.TL_CODE = TL.TL_CODE      ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE T.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@TL_STAT", "TL.TL_STAT = @TL_STAT"));
                        sbWhere.Append(UTIL.GetWhere(row, "@TL_CODE", "T.TL_CODE = @TL_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@TL_LIKE", "(T.TL_CODE LIKE '%' + @TL_LIKE + '%' OR T.TL_NAME LIKE '%' + @TL_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@TL_LOT_LIKE", "(TL.TL_LOT LIKE '%' + @TL_LOT_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@TL_SPEC_LIKE", "(T.TL_SPEC LIKE '%' + @TL_SPEC_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WO_NO", " TL.WO_NO = @WO_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "T.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE,@E_REG_DATE", "CONVERT(CHAR(10), TL.REG_DATE, 23) BETWEEN @S_REG_DATE AND @E_REG_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_YPGO_DATE,@E_YPGO_DATE", "CONVERT(CHAR(10), TL.YPGO_DATE, 23) BETWEEN @S_YPGO_DATE AND @E_YPGO_DATE"));

                        sbWhere.Append(" AND TL.DATA_FLAG =0 ");

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

        public static DataTable TTOL_TOOLLIST_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT   T.PLT_CODE         ");
                    sbQuery.Append("       , T.TL_CODE             ");
                    sbQuery.Append("       , T.TL_NAME             ");
                    sbQuery.Append("       , T.TL_TYPE             ");
                    sbQuery.Append("       , T.TL_LTYPE            ");
                    sbQuery.Append("       , T.TL_MTYPE            ");
                    sbQuery.Append("       , T.TL_STYPE            ");
                    sbQuery.Append("       , T.TL_SPEC             ");
                    sbQuery.Append("       , T.TL_MIN              ");
                    sbQuery.Append("       , T.TL_MAX              ");
                    sbQuery.Append("       , T.TL_DANGER_QTY       ");
                    sbQuery.Append("       , T.TL_MAKER            ");
                    sbQuery.Append("       , T.TL_UNITCOST         ");
                    sbQuery.Append("       , T.TL_UNIT             ");
                    sbQuery.Append("       , T.HOLDER              ");
                    sbQuery.Append("       , T.TL_LENGTH           ");
                    sbQuery.Append("       , T.MAIN_VND            ");
                    sbQuery.Append("       , T.TL_QTY              ");
                    sbQuery.Append("       , T.TL_D_QTY            ");
                    sbQuery.Append("       , T.STD_LIFE            ");
                    //sbQuery.Append("       , T.TL_IMAGE            ");
                    //sbQuery.Append("       , T.REG_DATE          ");
                    //sbQuery.Append("       , T.REG_EMP           ");
                    //sbQuery.Append("       , T.MDFY_DATE         ");
                    //sbQuery.Append("       , T.MDFY_EMP          ");
                    sbQuery.Append("       , TL.TL_LOT             ");
                    //sbQuery.Append("       , T.SCOMMENT            ");
                    sbQuery.Append("       , TL.WO_NO             ");
                    sbQuery.Append("       , TL.TL_CODE           ");
                    sbQuery.Append("       , TL.TL_LIFE            ");
                    sbQuery.Append("       , TL.TL_STAT           ");
                    sbQuery.Append("       , TL.YPGO_DATE           ");
                    //sbQuery.Append("       , TL.SCOMMENT          ");
                    //sbQuery.Append("       , TL.REG_DATE          ");
                    //sbQuery.Append("       , TL.REG_EMP           ");
                    //sbQuery.Append("       , TL.MDFY_DATE         ");
                    //sbQuery.Append("       , TL.MDFY_EMP          ");
                    sbQuery.Append("       , TG.GIVE_NO												  ");
                    sbQuery.Append("       , TG.GIVE_SEQ												  ");
                    sbQuery.Append("       , TG.GIVE_DATE											  ");
                    sbQuery.Append("       , TG.GIVE_STATE											  ");
                    sbQuery.Append("       , TG.TL_LOT												  ");
                    sbQuery.Append("       , TG.GIVE_MC												  ");
                    sbQuery.Append("       , TG.GIVE_EMP												  ");
                    sbQuery.Append("       , TG.SCOMMENT												  ");
                    sbQuery.Append("       , TG.REG_DATE												  ");
                    sbQuery.Append("       , TG.REG_EMP												  ");
                    sbQuery.Append("       , TG.MDFY_DATE											  ");
                    sbQuery.Append("       , TG.MDFY_EMP												  ");
                    sbQuery.Append("       , LM.MC_CODE AS GIVE_MC_CODE												  ");
                    sbQuery.Append("       , LM.MC_NAME	AS GIVE_MC_NAME											  ");
                    sbQuery.Append("       , TE.EMP_CODE AS GIVE_EMP_CODE												  ");
                    sbQuery.Append("       , TE.EMP_NAME AS GIVE_EMP_NAME												  ");
                    sbQuery.Append("       , TE_REG.EMP_CODE AS REG_EMP_CODE								  ");
                    sbQuery.Append("       , TE_REG.EMP_NAME AS REG_EMP_NAME								  ");
                    sbQuery.Append("       , CODE1.CD_NAME AS GIVE_STATE_NAME           ");
                    sbQuery.Append("       , CODE2.CD_NAME AS TL_TYPE_NAME           ");
                    sbQuery.Append("       , CODE3.CD_NAME AS TL_LTYPE_NAME           ");
                    sbQuery.Append("       , CODE4.CD_NAME AS TL_MTYPE_NAME           ");
                    sbQuery.Append("       , CODE5.CD_NAME AS TL_STYPE_NAME           ");
                    sbQuery.Append("  FROM TTOL_TOOLLIST TL      ");
                    sbQuery.Append("    INNER JOIN TSTD_TOOL T      ");
                    sbQuery.Append("        ON T.PLT_CODE = TL.PLT_CODE      ");
                    sbQuery.Append("        AND T.TL_CODE = TL.TL_CODE      ");
                    sbQuery.Append("    INNER JOIN (SELECT G.PLT_CODE												  ");
                    sbQuery.Append("                	  , G.GIVE_NO												  ");
                    sbQuery.Append("                	  , G.GIVE_SEQ												  ");
                    sbQuery.Append("                	  , G.GIVE_DATE											  ");
                    sbQuery.Append("                	  , G.GIVE_STATE											  ");
                    sbQuery.Append("                	  , G.TL_LOT												  ");
                    sbQuery.Append("                	  , G.GIVE_MC												  ");
                    sbQuery.Append("                	  , G.GIVE_EMP												  ");
                    sbQuery.Append("                	  , G.SCOMMENT												  ");
                    sbQuery.Append("                	  , G.REG_DATE												  ");
                    sbQuery.Append("                	  , G.REG_EMP												  ");
                    sbQuery.Append("                	  , G.MDFY_DATE											  ");
                    sbQuery.Append("                	  , G.MDFY_EMP												  ");
                    sbQuery.Append("                  FROM TTOL_GIVE AS G												  ");
                    sbQuery.Append("                	INNER JOIN (SELECT PLT_CODE,MAX(REG_DATE) AS REG_DATE, TL_LOT ");
                    sbQuery.Append("                				FROM TTOL_GIVE									  ");
                    sbQuery.Append("                				WHERE GIVE_STATE = 'GU'							  ");//상태값 GU는 지급
                    sbQuery.Append("                				GROUP BY PLT_CODE, TL_LOT) AS SUB_G			        ");
                    sbQuery.Append("                		ON G.PLT_CODE = SUB_G.PLT_CODE						        ");
                    sbQuery.Append("                		AND G.TL_LOT = SUB_G.TL_LOT							        ");
                    sbQuery.Append("                		AND G.REG_DATE = SUB_G.REG_DATE) AS TG						  ");
                    sbQuery.Append("        ON TL.PLT_CODE = TG.PLT_CODE      ");
                    sbQuery.Append("        AND TL.TL_LOT = TG.TL_LOT      ");
                    sbQuery.Append("    INNER JOIN TSTD_EMPLOYEE TE                ");
                    sbQuery.Append("        ON TG.GIVE_EMP = TE.EMP_CODE            ");
                    sbQuery.Append("    INNER JOIN TSTD_EMPLOYEE TE_REG                ");
                    sbQuery.Append("        ON TG.REG_EMP = TE_REG.EMP_CODE            ");
                    sbQuery.Append("    INNER JOIN LSE_MACHINE LM                ");
                    sbQuery.Append("        ON TG.GIVE_MC = LM.MC_CODE            ");
                    sbQuery.Append("    LEFT JOIN TSTD_CODES CODE1                ");
                    sbQuery.Append("        ON CODE1.CAT_CODE = 'T005'            ");//상태
                    sbQuery.Append("        AND CODE1.CD_CODE = TG.GIVE_STATE            ");//
                    sbQuery.Append("    LEFT JOIN TSTD_CODES CODE2                ");
                    sbQuery.Append("        ON CODE2.CAT_CODE = 'T004'            ");//형태
                    sbQuery.Append("        AND CODE2.CD_CODE = T.TL_TYPE            ");//
                    sbQuery.Append("    LEFT JOIN TSTD_CODES CODE3                ");
                    sbQuery.Append("        ON CODE3.CAT_CODE = 'T001'            ");//대분류
                    sbQuery.Append("        AND CODE3.CD_CODE = T.TL_LTYPE            ");//
                    sbQuery.Append("    LEFT JOIN TSTD_CODES CODE4                ");
                    sbQuery.Append("        ON CODE4.CAT_CODE = 'T002'            ");//중분류
                    sbQuery.Append("        AND CODE4.CD_CODE = T.TL_MTYPE            ");//
                    sbQuery.Append("    LEFT JOIN TSTD_CODES CODE5                ");
                    sbQuery.Append("        ON CODE5.CAT_CODE = 'T003'            ");//소분류
                    sbQuery.Append("        AND CODE5.CD_CODE = T.TL_STYPE            ");//

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE T.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@TL_CODE", "T.TL_CODE = @TL_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@TL_LIKE", "(T.TL_CODE LIKE '%' + @TL_LIKE + '%' OR T.TL_NAME LIKE '%' + @TL_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@TL_SPEC_LIKE", "(T.TL_SPEC LIKE '%' + @TL_SPEC_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@TL_LOT", " TL.TL_LOT = @TL_LOT "));
                        sbWhere.Append(UTIL.GetWhere(row, "@TL_LOT_LIKE", "(TL.TL_LOT LIKE '%' + @TL_LOT_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@GIVE_NO", " TG.GIVE_NO = @GIVE_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@GIVE_SEQ", " TG.GIVE_SEQ = @GIVE_SEQ"));
                        sbWhere.Append(UTIL.GetWhere(row, "@GIVE_MC", " TG.GIVE_MC = @GIVE_MC"));
                        sbWhere.Append(UTIL.GetWhere(row, "@GIVE_EMP", " TG.GIVE_EMP = @GIVE_EMP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WO_NO", " TL.WO_NO = @WO_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "T.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE,@E_REG_DATE", "CONVERT(CHAR(10), TG.REG_DATE, 23) BETWEEN @S_REG_DATE AND @E_REG_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_GIVE_DATE,@E_GIVE_DATE", "CONVERT(CHAR(10), TG.GIVE_DATE, 23) BETWEEN @S_GIVE_DATE AND @E_GIVE_DATE"));

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

        public static DataTable TTOL_TOOLLIST_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT   T.PLT_CODE         ");
                    sbQuery.Append("       , T.TL_CODE             ");
                    sbQuery.Append("       , T.TL_NAME             ");
                    sbQuery.Append("       , T.TL_TYPE             ");
                    sbQuery.Append("       , T.TL_LTYPE            ");
                    sbQuery.Append("       , T.TL_MTYPE            ");
                    sbQuery.Append("       , T.TL_STYPE            ");
                    sbQuery.Append("       , T.TL_SPEC             ");
                    sbQuery.Append("       , T.TL_MIN              ");
                    sbQuery.Append("       , T.TL_MAX              ");
                    sbQuery.Append("       , T.TL_DANGER_QTY       ");
                    sbQuery.Append("       , T.TL_MAKER            ");
                    sbQuery.Append("       , T.TL_UNITCOST         ");
                    sbQuery.Append("       , T.TL_UNIT             ");
                    sbQuery.Append("       , T.HOLDER              ");
                    sbQuery.Append("       , T.TL_LENGTH           ");
                    sbQuery.Append("       , T.MAIN_VND            ");
                    sbQuery.Append("       , T.TL_QTY              ");
                    sbQuery.Append("       , T.TL_D_QTY            ");
                    //sbQuery.Append("       , T.TL_IMAGE            ");
                    sbQuery.Append("       , T.REG_DATE          ");
                    sbQuery.Append("       , T.REG_EMP           ");
                    sbQuery.Append("       , T.MDFY_DATE         ");
                    sbQuery.Append("       , T.MDFY_EMP          ");
                    sbQuery.Append("       , TL.TL_LOT             ");
                    sbQuery.Append("       , T.SCOMMENT            ");
                    sbQuery.Append("       , TL.WO_NO             ");
                    sbQuery.Append("       , TL.TL_CODE           ");
                    sbQuery.Append("       , TL.TL_LIFE            ");
                    sbQuery.Append("       , TL.TL_STAT           ");
                    sbQuery.Append("       , TL.YPGO_DATE           ");
                    sbQuery.Append("       , TL.SCOMMENT          ");
                    sbQuery.Append("       , TL.REG_DATE          ");
                    sbQuery.Append("       , TL.REG_EMP           ");
                    sbQuery.Append("       , TL.MDFY_DATE         ");
                    sbQuery.Append("       , TL.MDFY_EMP          ");
                    sbQuery.Append("       , TAT.WO_MC          ");
                    sbQuery.Append("       , TAT.WO_RPM          ");
                    sbQuery.Append("       , TAT.WO_FEED          ");
                    sbQuery.Append("       , TAT.WO_LIFE          ");
                    sbQuery.Append("       , TAT.REG_DATE          ");
                    sbQuery.Append("       , TAT.REG_EMP          ");
                    sbQuery.Append("  FROM TTOL_TOOLLIST TL      ");
                    sbQuery.Append("    INNER JOIN TSTD_TOOL T      ");
                    sbQuery.Append("        ON T.PLT_CODE = TL.PLT_CODE      ");
                    sbQuery.Append("        AND T.TL_CODE = TL.TL_CODE      ");
                    sbQuery.Append("    INNER JOIN TSHP_ACTUAL_TOOL TAT      ");
                    sbQuery.Append("        ON TL.PLT_CODE = TAT.PLT_CODE      ");
                    sbQuery.Append("        AND TL.TL_LOT = TAT.TL_LOT      ");
                    //sbQuery.Append("        AND TL.WO_NO = TAT.WO_NO      ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE T.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@TL_STAT", "TL.TL_STAT = @TL_STAT"));
                        sbWhere.Append(UTIL.GetWhere(row, "@TL_CODE", "T.TL_CODE = @TL_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@TL_LIKE", "(T.TL_CODE LIKE '%' + @TL_LIKE + '%' OR T.TL_NAME LIKE '%' + @TL_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@TL_LOT_LIKE", "(TL.TL_LOT LIKE '%' + @TL_LOT_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@TL_SPEC_LIKE", "(T.TL_SPEC LIKE '%' + @TL_SPEC_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WO_NO", " TAT.WO_NO = @WO_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@TL_LOT", " TL.TL_LOT = @TL_LOT"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "T.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE,@E_REG_DATE", "CONVERT(CHAR(10), TL.REG_DATE, 23) BETWEEN @S_REG_DATE AND @E_REG_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_YPGO_DATE,@E_YPGO_DATE", "CONVERT(CHAR(10), TL.YPGO_DATE, 23) BETWEEN @S_YPGO_DATE AND @E_YPGO_DATE"));

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
