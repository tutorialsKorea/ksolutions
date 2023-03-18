using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DTOL
{
    public class TTOL_DISUSE
    {
        public static DataTable TTOL_DISUSE_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT  PLT_CODE      ");
                    sbQuery.Append("       , TDU_NO       ");
                    sbQuery.Append("       , TDU_SEQ      ");
                    sbQuery.Append("       , TDU_DATE      ");
                    sbQuery.Append("       , TDU_EMP      ");
                    sbQuery.Append("       , TL_LOT      ");
                    sbQuery.Append("       , SCOMMENT      ");
                    sbQuery.Append("       , REG_DATE      ");
                    sbQuery.Append("       , REG_EMP      ");
                    sbQuery.Append("       , MDFY_DATE      ");
                    sbQuery.Append("       , MDFY_EMP   ");
                    sbQuery.Append("  FROM TTOL_DISUSE       ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append("   AND TL_LOT = @TL_LOT      ");
                    //sbQuery.Append("   AND TDU_NO = @TDU_NO      ");
                    //sbQuery.Append("   AND TDU_SEQ = @TDU_SEQ      ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "TL_LOT")) isHasColumn = false;
                        //if (!UTIL.ValidColumn(row, "TDU_NO")) isHasColumn = false;
                        //if (!UTIL.ValidColumn(row, "TDU_SEQ")) isHasColumn = false;

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
        /// 정보 수정 (설비, 작업자)
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TTOL_DISUSE_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TTOL_DISUSE                      ");
                    sbQuery.Append("    SET  TDU_EMP = @TDU_EMP ");
                    sbQuery.Append("        , TDU_DATE = @TDU_DATE ");
                    sbQuery.Append("        , SCOMMNET = @SCOMMNET ");
                    sbQuery.Append("        , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("        , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE           ");
                    sbQuery.Append("    AND TDU_NO = @TDU_NO             ");
                    sbQuery.Append("    AND TDU_SEQ = @TDU_SEQ             ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "TDU_NO")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "TDU_SEQ")) isHasColumn = false;

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
        public static void TTOL_DISUSE_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" DELETE FROM  TTOL_DISUSE                  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE           ");
                    sbQuery.Append("    AND TDU_NO = @TDU_NO             ");
                    sbQuery.Append("    AND TDU_SEQ = @TDU_SEQ             ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "TDU_NO")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "TDU_SEQ")) isHasColumn = false;

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

        public static void TTOL_DISUSE_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO TTOL_DISUSE ");
                    sbQuery.Append(" (                         ");
                    sbQuery.Append("        PLT_CODE      ");
                    sbQuery.Append("       , TDU_NO       ");
                    sbQuery.Append("       , TDU_SEQ      ");
                    sbQuery.Append("       , TDU_DATE      ");
                    sbQuery.Append("       , TDU_EMP       ");
                    sbQuery.Append("       , TL_LOT      ");
                    sbQuery.Append("       , SCOMMENT      ");
                    sbQuery.Append("       , REG_DATE      ");
                    sbQuery.Append("       , REG_EMP      ");
                    sbQuery.Append(" )                         ");
                    sbQuery.Append(" VALUES                    ");
                    sbQuery.Append(" (                         ");
                    sbQuery.Append("        @PLT_CODE      ");
                    sbQuery.Append("       , @TDU_NO       ");
                    sbQuery.Append("       , @TDU_SEQ      ");
                    sbQuery.Append("       , @TDU_DATE      ");
                    sbQuery.Append("       , @TDU_EMP      ");
                    sbQuery.Append("       , @TL_LOT      ");
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

    public class TTOL_DISUSE_QUERY
    {
        /// <summary>
        /// 지급된 공구 LOT 목록
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TTOL_DISUSE_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
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
                    sbQuery.Append("       , TD.TDU_NO												  ");
                    sbQuery.Append("       , TD.TDU_SEQ												  ");
                    sbQuery.Append("       , TD.TDU_DATE											  ");
                    sbQuery.Append("       , TD.TDU_EMP												  ");
                    sbQuery.Append("       , TD.TL_LOT												  ");
                    sbQuery.Append("       , TD.SCOMMENT												  ");
                    sbQuery.Append("       , TD.REG_DATE												  ");
                    sbQuery.Append("       , TD.REG_EMP												  ");
                    sbQuery.Append("       , TD.MDFY_DATE											  ");
                    sbQuery.Append("       , TD.MDFY_EMP												  ");
                    sbQuery.Append("       , TE.EMP_CODE AS TDU_EMP_CODE												  ");
                    sbQuery.Append("       , TE.EMP_NAME AS TDU_EMP_NAME												  ");
                    sbQuery.Append("       , TE_REG.EMP_CODE AS REG_EMP_CODE								  ");
                    sbQuery.Append("       , TE_REG.EMP_NAME AS REG_EMP_NAME								  ");
                    sbQuery.Append("       , CODE2.CD_NAME AS TL_TYPE_NAME           ");
                    sbQuery.Append("       , CODE3.CD_NAME AS TL_LTYPE_NAME           ");
                    sbQuery.Append("       , CODE4.CD_NAME AS TL_MTYPE_NAME           ");
                    sbQuery.Append("       , CODE5.CD_NAME AS TL_STYPE_NAME           ");
                    sbQuery.Append("  FROM TTOL_TOOLLIST TL      ");
                    sbQuery.Append("    INNER JOIN TSTD_TOOL T      ");
                    sbQuery.Append("        ON T.PLT_CODE = TL.PLT_CODE      ");
                    sbQuery.Append("        AND T.TL_CODE = TL.TL_CODE      ");
                    sbQuery.Append("    INNER JOIN (SELECT D.PLT_CODE												  ");
                    sbQuery.Append("                	  , D.TDU_NO												  ");
                    sbQuery.Append("                	  , D.TDU_SEQ												  ");
                    sbQuery.Append("                	  , D.TDU_DATE											  ");
                    sbQuery.Append("                	  , D.TDU_EMP											  ");
                    sbQuery.Append("                	  , D.TL_LOT											  ");
                    sbQuery.Append("                	  , D.SCOMMENT												  ");
                    sbQuery.Append("                	  , D.REG_DATE												  ");
                    sbQuery.Append("                	  , D.REG_EMP												  ");
                    sbQuery.Append("                	  , D.MDFY_DATE											  ");
                    sbQuery.Append("                	  , D.MDFY_EMP												  ");
                    sbQuery.Append("                  FROM TTOL_DISUSE AS D												  ");
                    sbQuery.Append("                	INNER JOIN (SELECT PLT_CODE,MAX(REG_DATE) AS REG_DATE, TDU_NO, TDU_SEQ ");
                    sbQuery.Append("                				FROM TTOL_DISUSE									  ");
                    sbQuery.Append("                				GROUP BY PLT_CODE, TDU_NO, TDU_SEQ) AS SUB_D			  ");
                    sbQuery.Append("                		ON D.PLT_CODE = SUB_D.PLT_CODE						  ");
                    sbQuery.Append("                		AND D.TDU_NO = SUB_D.TDU_NO							  ");
                    sbQuery.Append("                		AND D.TDU_SEQ = SUB_D.TDU_SEQ							  ");
                    sbQuery.Append("                		AND D.REG_DATE = SUB_D.REG_DATE) AS TD						  ");
                    sbQuery.Append("        ON TL.PLT_CODE = TD.PLT_CODE      ");
                    sbQuery.Append("        AND TL.TL_LOT = TD.TL_LOT      ");
                    sbQuery.Append("    INNER JOIN TSTD_EMPLOYEE TE                ");
                    sbQuery.Append("        ON TD.TDU_EMP = TE.EMP_CODE            ");
                    sbQuery.Append("    INNER JOIN TSTD_EMPLOYEE TE_REG                ");
                    sbQuery.Append("        ON TD.REG_EMP = TE_REG.EMP_CODE            ");
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
                        sbWhere.Append(UTIL.GetWhere(row, "@TDU_NO", " TD.TDU_NO = @TDU_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@TDU_SEQ", " TD.TDU_SEQ = @TDU_SEQ"));
                        sbWhere.Append(UTIL.GetWhere(row, "@TDU_EMP", " TD.TDU_EMP = @TDU_EMP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WO_NO", " TL.WO_NO = @WO_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "T.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE,@E_REG_DATE", "CONVERT(CHAR(10), TD.REG_DATE, 23) BETWEEN @S_REG_DATE AND @E_REG_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_TDU_DATE,@E_TDU_DATE", "CONVERT(CHAR(10), TD.TDU_DATE, 23) BETWEEN @S_TDU_DATE AND @E_TDU_DATE"));

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

        public static DataTable TTOL_DISUSE_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();


                    sbQuery.Append("    SELECT D.PLT_CODE												  ");
                    sbQuery.Append("      	  , D.TDU_NO												  ");
                    sbQuery.Append("      	  , D.TDU_SEQ												  ");
                    sbQuery.Append("      	  , D.TDU_DATE											  ");
                    sbQuery.Append("      	  , D.TDU_EMP											  ");
                    sbQuery.Append("      	  , TL.TL_CODE												  ");
                    sbQuery.Append("      	  , D.TL_LOT												  ");
                    sbQuery.Append("      	  , D.SCOMMENT												  ");
                    sbQuery.Append("      	  , D.REG_DATE												  ");
                    sbQuery.Append("      	  , D.REG_EMP												  ");
                    sbQuery.Append("      	  , D.MDFY_DATE												  ");
                    sbQuery.Append("      	  , D.MDFY_EMP											  ");
                    sbQuery.Append("      FROM TTOL_DISUSE D					 	  ");
                    sbQuery.Append("        INNER JOIN TTOL_TOOLLIST TL               ");
                    sbQuery.Append("            ON D.PLT_CODE = TL.PLT_CODE            ");
                    sbQuery.Append("            AND D.TL_LOT = TL.TL_LOT            ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE D.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@TL_LOT", "D.TL_LOT = @TL_LOT"));
                        sbWhere.Append(UTIL.GetWhere(row, "@YEAR", "LEFT(D.TDU_DATE,4) = @YEAR"));

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
