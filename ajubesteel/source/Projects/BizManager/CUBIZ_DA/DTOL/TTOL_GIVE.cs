using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DTOL
{
    public class TTOL_GIVE
    {
        public static DataTable TTOL_GIVE_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT  PLT_CODE      ");
                    sbQuery.Append("       , GIVE_NO       ");
                    sbQuery.Append("       , GIVE_SEQ      ");
                    sbQuery.Append("       , GIVE_DATE      ");
                    sbQuery.Append("       , GIVE_STATE       ");
                    sbQuery.Append("       , TL_LOT      ");
                    sbQuery.Append("       , GIVE_MC        ");
                    sbQuery.Append("       , GIVE_EMP      ");
                    sbQuery.Append("       , SCOMMENT      ");
                    sbQuery.Append("       , REG_DATE      ");
                    sbQuery.Append("       , REG_EMP      ");
                    sbQuery.Append("       , MDFY_DATE      ");
                    sbQuery.Append("       , MDFY_EMP   ");
                    sbQuery.Append("  FROM TTOL_GIVE       ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append("   AND TL_LOT = @TL_LOT      ");
                    //sbQuery.Append("   AND GIVE_NO = @GIVE_NO      ");
                    //sbQuery.Append("   AND GIVE_SEQ = @GIVE_SEQ      ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "TL_LOT")) isHasColumn = false;
                        //if (!UTIL.ValidColumn(row, "GIVE_NO")) isHasColumn = false;
                        //if (!UTIL.ValidColumn(row, "GIVE_SEQ")) isHasColumn = false;

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
        /// 상태변경
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TTOL_GIVE_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TTOL_GIVE                      ");
                    sbQuery.Append("    SET  GIVE_STATE = @GIVE_STATE ");
                    sbQuery.Append("        , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("        , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE           ");
                    sbQuery.Append("    AND GIVE_NO = @GIVE_NO             ");
                    sbQuery.Append("    AND GIVE_SEQ = @GIVE_SEQ             ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "GIVE_NO")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "GIVE_SEQ")) isHasColumn = false;

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

        public static void TTOL_GIVE_UPD_1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TTOL_GIVE                      ");
                    sbQuery.Append("    SET  GIVE_STATE = @TL_STAT ");
                    sbQuery.Append("        , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("        , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE           ");
                    sbQuery.Append("    AND GIVE_NO = @GIVE_NO             ");
                    sbQuery.Append("    AND GIVE_SEQ = @GIVE_SEQ             ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "GIVE_NO")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "GIVE_SEQ")) isHasColumn = false;

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
        /// 정보 수정 (설비, 작업자)
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TTOL_GIVE_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TTOL_GIVE                      ");
                    sbQuery.Append("    SET  GIVE_MC = @GIVE_MC ");
                    sbQuery.Append("        , GIVE_EMP = @GIVE_EMP ");
                    sbQuery.Append("        , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("        , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE           ");
                    sbQuery.Append("    AND GIVE_NO = @GIVE_NO             ");
                    sbQuery.Append("    AND GIVE_SEQ = @GIVE_SEQ             ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "GIVE_NO")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "GIVE_SEQ")) isHasColumn = false;

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
        /// 지급 삭제
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TTOL_GIVE_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" DELETE FROM  TTOL_GIVE                  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE           ");
                    sbQuery.Append("    AND GIVE_NO = @GIVE_NO             ");
                    sbQuery.Append("    AND GIVE_SEQ = @GIVE_SEQ             ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "GIVE_NO")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "GIVE_SEQ")) isHasColumn = false;

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

        public static void TTOL_GIVE_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO TTOL_GIVE ");
                    sbQuery.Append(" (                         ");
                    sbQuery.Append("        PLT_CODE      ");
                    sbQuery.Append("       , GIVE_NO       ");
                    sbQuery.Append("       , GIVE_SEQ      ");
                    sbQuery.Append("       , GIVE_DATE      ");
                    sbQuery.Append("       , GIVE_STATE       ");
                    sbQuery.Append("       , TL_LOT      ");
                    sbQuery.Append("       , GIVE_MC        ");
                    sbQuery.Append("       , GIVE_EMP      ");
                    sbQuery.Append("       , EQUIP_POS      ");
                    sbQuery.Append("       , USED_LIFE      ");
                    sbQuery.Append("       , SCOMMENT      ");
                    sbQuery.Append("       , REG_DATE      ");
                    sbQuery.Append("       , REG_EMP      ");
                    sbQuery.Append(" )                         ");
                    sbQuery.Append(" VALUES                    ");
                    sbQuery.Append(" (                         ");
                    sbQuery.Append("        @PLT_CODE      ");
                    sbQuery.Append("       , @GIVE_NO       ");
                    sbQuery.Append("       , @GIVE_SEQ      ");
                    sbQuery.Append("       , @GIVE_DATE      ");
                    sbQuery.Append("       , @GIVE_STATE       ");
                    sbQuery.Append("       , @TL_LOT      ");
                    sbQuery.Append("       , @GIVE_MC        ");
                    sbQuery.Append("       , @GIVE_EMP      ");
                    sbQuery.Append("       , @EQUIP_POS      ");
                    sbQuery.Append("       , @USED_LIFE      ");
                    sbQuery.Append("       , @SCOMMENT      ");
                    sbQuery.Append("      , GETDATE()");
                    sbQuery.Append("      , " + UTIL.GetValidValue(ConnInfo.UserID));
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

    public class TTOL_GIVE_QUERY
    {
        /// <summary>
        /// 지급된 공구 LOT 목록
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TTOL_GIVE_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
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
                    sbQuery.Append("       , TG.GIVE_MC												  ");
                    sbQuery.Append("       , TG.GIVE_EMP												  ");
                    //sbQuery.Append("       , TG.SCOMMENT												  ");
                    //sbQuery.Append("       , TG.REG_DATE												  ");
                    //sbQuery.Append("       , TG.REG_EMP												  ");
                    //sbQuery.Append("       , TG.MDFY_DATE											  ");
                    //sbQuery.Append("       , TG.MDFY_EMP												  ");
                    sbQuery.Append("       , TR.PLT_CODE												  ");
                    sbQuery.Append("       , TR.RTN_NO												  ");
                    sbQuery.Append("       , TR.RTN_SEQ												  ");
                    sbQuery.Append("       , TR.RTN_DATE											  ");
                    sbQuery.Append("       , TR.RTN_EMP											  ");
                    sbQuery.Append("       , TR.SCOMMENT												  ");
                    sbQuery.Append("       , TR.REG_DATE												  ");
                    sbQuery.Append("       , TR.REG_EMP												  ");
                    sbQuery.Append("       , LM.MC_CODE AS GIVE_MC_CODE												  ");
                    sbQuery.Append("       , LM.MC_NAME AS GIVE_MC_NAME												  ");
                    sbQuery.Append("       , TE1.EMP_CODE AS GIVE_EMP_CODE												  ");
                    sbQuery.Append("       , TE1.EMP_NAME AS GIVE_EMP_NAME												  ");
                    sbQuery.Append("       , TE2.EMP_CODE AS RTN_EMP_CODE												  ");
                    sbQuery.Append("       , TE2.EMP_NAME AS RTN_EMP_NAME												  ");
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
                    sbQuery.Append("    INNER JOIN TTOL_GIVE TG ");
                    sbQuery.Append("        ON TL.PLT_CODE = TG.PLT_CODE      ");
                    sbQuery.Append("        AND TL.TL_LOT = TG.TL_LOT      ");
                    sbQuery.Append("    INNER JOIN (SELECT R.PLT_CODE												  ");
                    sbQuery.Append("                	  , R.RTN_NO												  ");
                    sbQuery.Append("                	  , R.RTN_SEQ												  ");
                    sbQuery.Append("                	  , R.RTN_DATE											  ");
                    sbQuery.Append("                	  , R.RTN_EMP											  ");
                    sbQuery.Append("                	  , R.GIVE_NO												  ");
                    sbQuery.Append("                	  , R.GIVE_SEQ												  ");
                    sbQuery.Append("                	  , R.SCOMMENT												  ");
                    sbQuery.Append("                	  , R.REG_DATE												  ");
                    sbQuery.Append("                	  , R.REG_EMP												  ");
                    sbQuery.Append("                	  , R.MDFY_DATE											  ");
                    sbQuery.Append("                	  , R.MDFY_EMP												  ");
                    sbQuery.Append("                  FROM TTOL_RETURN AS R												  ");
                    sbQuery.Append("                	INNER JOIN (SELECT PLT_CODE,MAX(REG_DATE) AS REG_DATE, GIVE_NO, GIVE_SEQ ");
                    sbQuery.Append("                				FROM TTOL_RETURN									  ");
                    sbQuery.Append("                				GROUP BY PLT_CODE, GIVE_NO, GIVE_SEQ) AS SUB_R			  ");
                    sbQuery.Append("                		ON R.PLT_CODE = SUB_R.PLT_CODE						  ");
                    sbQuery.Append("                		AND R.GIVE_NO = SUB_R.GIVE_NO							  ");
                    sbQuery.Append("                		AND R.GIVE_SEQ = SUB_R.GIVE_SEQ							  ");
                    sbQuery.Append("                		AND R.REG_DATE = SUB_R.REG_DATE) AS TR						  ");
                    sbQuery.Append("        ON TG.PLT_CODE = TR.PLT_CODE      ");
                    sbQuery.Append("        AND TG.GIVE_NO = TR.GIVE_NO      ");
                    sbQuery.Append("        AND TG.GIVE_SEQ = TR.GIVE_SEQ      ");
                    sbQuery.Append("    INNER JOIN TSTD_EMPLOYEE TE1                ");
                    sbQuery.Append("        ON TG.GIVE_EMP = TE1.EMP_CODE            ");
                    sbQuery.Append("    INNER JOIN TSTD_EMPLOYEE TE2                ");
                    sbQuery.Append("        ON TR.RTN_EMP = TE2.EMP_CODE            ");
                    sbQuery.Append("    INNER JOIN TSTD_EMPLOYEE TE_REG                ");
                    sbQuery.Append("        ON TR.REG_EMP = TE_REG.EMP_CODE            ");
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
                        sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE,@E_REG_DATE", "CONVERT(CHAR(10), TR.REG_DATE, 23) BETWEEN @S_REG_DATE AND @E_REG_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_RTN_DATE,@E_RTN_DATE", "CONVERT(CHAR(10), TR.RTN_DATE, 23) BETWEEN @S_RTN_DATE AND @E_RTN_DATE"));

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

        public static DataTable TTOL_GIVE_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT   TG.PLT_CODE         ");
                    sbQuery.Append("       , TG.GIVE_NO		");
                    sbQuery.Append("       , TG.GIVE_SEQ	  ");
                    sbQuery.Append("       , TG.GIVE_DATE	");
                    sbQuery.Append("       , TG.GIVE_STATE	");
                    sbQuery.Append("       , TG.GIVE_MC		");
                    sbQuery.Append("       , TG.GIVE_EMP	  ");
                    sbQuery.Append("       , TG.TL_LOT	  ");
                    sbQuery.Append("       , TL.TL_CODE	  ");
                    sbQuery.Append("       , TG.SCOMMENT	  ");
                    sbQuery.Append("       , TG.REG_DATE	  ");
                    sbQuery.Append("       , TG.REG_EMP		");
                    sbQuery.Append("       , TG.MDFY_DATE	");
                    sbQuery.Append("       , TG.MDFY_EMP	  ");
                    sbQuery.Append("       , LM.MC_CODE		");
                    sbQuery.Append("       , LM.MC_NAME		");
                    sbQuery.Append("  FROM TTOL_GIVE TG ");
                    sbQuery.Append("    INNER JOIN TTOL_TOOLLIST TL               ");
                    sbQuery.Append("        ON TG.PLT_CODE = TL.PLT_CODE            ");
                    sbQuery.Append("        AND TG.TL_LOT = TL.TL_LOT            ");
                    sbQuery.Append("    LEFT JOIN LSE_MACHINE LM                ");
                    sbQuery.Append("        ON TG.PLT_CODE = LM.PLT_CODE            ");
                    sbQuery.Append("        AND TG.GIVE_MC = LM.MC_CODE            ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE TG.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@TL_LOT", "TG.TL_LOT = @TL_LOT"));
                        sbWhere.Append(UTIL.GetWhere(row, "@YEAR", "LEFT(TG.GIVE_DATE,4) = @YEAR"));

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
