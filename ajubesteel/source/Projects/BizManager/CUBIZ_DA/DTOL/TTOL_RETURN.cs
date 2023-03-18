using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DTOL
{
    public class TTOL_RETURN
    {
        public static DataTable TTOL_RETURN_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT  PLT_CODE      ");
                    sbQuery.Append("       , RTN_NO       ");
                    sbQuery.Append("       , RTN_SEQ      ");
                    sbQuery.Append("       , RTN_DATE      ");
                    sbQuery.Append("       , RTN_EMP      ");
                    sbQuery.Append("       , GIVE_NO        ");
                    sbQuery.Append("       , GIVE_SEQ      ");
                    sbQuery.Append("       , SCOMMENT      ");
                    sbQuery.Append("       , REG_DATE      ");
                    sbQuery.Append("       , REG_EMP      ");
                    sbQuery.Append("       , MDFY_DATE      ");
                    sbQuery.Append("       , MDFY_EMP   ");
                    sbQuery.Append("  FROM TTOL_RETURN       ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append("   AND GIVE_NO = @GIVE_NO      ");
                    sbQuery.Append("   AND GIVE_SEQ = @GIVE_SEQ      ");
                    //sbQuery.Append("   AND RTN_NO = @RTN_NO      ");
                    //sbQuery.Append("   AND RTN_SEQ = @RTN_SEQ      ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "GIVE_NO")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "GIVE_SEQ")) isHasColumn = false;
                        //if (!UTIL.ValidColumn(row, "RTN_NO")) isHasColumn = false;
                        //if (!UTIL.ValidColumn(row, "RTN_SEQ")) isHasColumn = false;

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
        /// 반납일, 반납자
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TTOL_RETURN_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TTOL_RETURN                      ");
                    sbQuery.Append("    SET  RTN_DATE = @RTN_DATE ");
                    sbQuery.Append("        , RTN_EMP = @RTN_EMP ");
                    sbQuery.Append("        , SCOMMENT = @SCOMMENT ");
                    sbQuery.Append("        , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("        , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE           ");
                    sbQuery.Append("    AND RTN_NO = @RTN_NO             ");
                    sbQuery.Append("    AND RTN_SEQ = @RTN_SEQ             ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "RTN_NO")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "RTN_SEQ")) isHasColumn = false;

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
        /// 반납 삭제
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TTOL_RETURN_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" DELETE FROM  TTOL_RETURN                  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE           ");
                    sbQuery.Append("    AND RTN_NO = @RTN_NO             ");
                    sbQuery.Append("    AND RTN_SEQ = @RTN_SEQ             ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "RTN_NO")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "RTN_SEQ")) isHasColumn = false;

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

        public static void TTOL_RETURN_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO TTOL_RETURN ");
                    sbQuery.Append(" (                         ");
                    sbQuery.Append("        PLT_CODE      ");
                    sbQuery.Append("       , RTN_NO       ");
                    sbQuery.Append("       , RTN_SEQ      ");
                    sbQuery.Append("       , RTN_DATE      ");
                    sbQuery.Append("       , RTN_EMP      ");
                    sbQuery.Append("       , GIVE_NO       ");
                    sbQuery.Append("       , GIVE_SEQ      ");
                    sbQuery.Append("       , SCOMMENT      ");
                    sbQuery.Append("       , REG_DATE      ");
                    sbQuery.Append("       , REG_EMP      ");
                    sbQuery.Append(" )                         ");
                    sbQuery.Append(" VALUES                    ");
                    sbQuery.Append(" (                         ");
                    sbQuery.Append("        @PLT_CODE      ");
                    sbQuery.Append("       , @RTN_NO       ");
                    sbQuery.Append("       , @RTN_SEQ      ");
                    sbQuery.Append("       , @RTN_DATE      ");
                    sbQuery.Append("       , @RTN_EMP      ");
                    sbQuery.Append("       , @GIVE_NO       ");
                    sbQuery.Append("       , @GIVE_SEQ      ");
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

    public class TTOL_RETURN_QUERY
    {
        /// <summary>
        /// 반납된 공구 LOT 목록
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TTOL_RETURN_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("    SELECT R.PLT_CODE												  ");
                    sbQuery.Append("      	  , R.RTN_NO												  ");
                    sbQuery.Append("      	  , R.RTN_SEQ												  ");
                    sbQuery.Append("      	  , R.RTN_DATE											  ");
                    sbQuery.Append("      	  , R.RTN_EMP											  ");
                    sbQuery.Append("      	  , TL.TL_CODE												  ");
                    sbQuery.Append("      	  , TL.TL_LOT												  ");
                    sbQuery.Append("      	  , R.GIVE_NO												  ");
                    sbQuery.Append("      	  , R.GIVE_SEQ												  ");
                    sbQuery.Append("      	  , R.SCOMMENT												  ");
                    sbQuery.Append("      	  , R.REG_DATE												  ");
                    sbQuery.Append("      	  , R.REG_EMP												  ");
                    sbQuery.Append("      	  , R.MDFY_DATE											  ");
                    sbQuery.Append("      	  , R.MDFY_EMP												  ");
                    sbQuery.Append("      FROM TTOL_RETURN R					 	  ");
                    sbQuery.Append("      	INNER JOIN TTOL_GIVE G			      ");
                    sbQuery.Append("      		ON R.PLT_CODE = G.PLT_CODE		  ");
                    sbQuery.Append("      		AND R.GIVE_NO = G.GIVE_NO			  ");
                    sbQuery.Append("      		AND R.GIVE_SEQ = G.GIVE_SEQ 						  ");
                    sbQuery.Append("        INNER JOIN TTOL_TOOLLIST TL               ");
                    sbQuery.Append("            ON G.PLT_CODE = TL.PLT_CODE            ");
                    sbQuery.Append("            AND G.TL_LOT = TL.TL_LOT            ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE R.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@TL_LOT", "G.TL_LOT = @TL_LOT"));
                        sbWhere.Append(UTIL.GetWhere(row, "@YEAR", "LEFT(R.RTN_DATE,4) = @YEAR"));

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
