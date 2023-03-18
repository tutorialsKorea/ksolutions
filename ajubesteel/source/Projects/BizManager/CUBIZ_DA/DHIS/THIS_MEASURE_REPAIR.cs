using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DHIS
{
    public class THIS_MEASURE_REPAIR
    {
        public static DataTable THIS_MEASURE_REPAIR_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT  PLT_CODE      ");
                    sbQuery.Append("        ,MS_REP_ID ");
                    sbQuery.Append("        ,PLT_CODE ");
                    sbQuery.Append("        ,MS_NO ");
                    sbQuery.Append("        ,REP_DATE ");
                    sbQuery.Append("        ,REP_TYPE ");
                    sbQuery.Append("        ,REP_EMP ");
                    sbQuery.Append("        ,SCOMMENT ");
                    sbQuery.Append("        ,REG_DATE ");
                    sbQuery.Append("        ,REG_EMP ");
                    sbQuery.Append("        ,MDFY_DATE ");
                    sbQuery.Append("        ,MDFY_EMP ");
                    sbQuery.Append("  FROM THIS_MEASURE_REPAIR       ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append("   AND MS_REP_ID = @MS_REP_ID      ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MS_REP_ID")) isHasColumn = false;

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
        public static void THIS_MEASURE_REPAIR_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE THIS_MEASURE_REPAIR                      ");
                    sbQuery.Append("    SET  GIVE_STATE = @GIVE_STATE ");
                    sbQuery.Append("        , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("        , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE           ");
                    sbQuery.Append("    AND MS_REP_ID = @MS_REP_ID             ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MS_REP_ID")) isHasColumn = false;

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
        /// 테이블 업데이트 
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void THIS_MEASURE_REPAIR_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE THIS_MEASURE_REPAIR   ");
                    sbQuery.Append("    SET   REP_DATE = @REP_DATE");
                    sbQuery.Append("        , REP_TYPE = @REP_TYPE");
                    sbQuery.Append("        , REP_EMP = @REP_EMP");
                    sbQuery.Append("        , SCOMMENT = @SCOMMENT");
                    sbQuery.Append("        , REP_VEN = @REP_VEN");
                    sbQuery.Append("        , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("        , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE           ");
                    sbQuery.Append("    AND MS_REP_ID = @MS_REP_ID             ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MS_REP_ID")) isHasColumn = false;

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
        /// 계측기 삭제
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void THIS_MEASURE_REPAIR_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" DELETE FROM  THIS_MEASURE_REPAIR                  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE           ");
                    sbQuery.Append("    AND MS_REP_ID = @MS_REP_ID             ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MS_REP_ID")) isHasColumn = false;

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

        public static object THIS_MEASURE_REPAIR_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO THIS_MEASURE_REPAIR ");
                    sbQuery.Append(" (                         ");
                    sbQuery.Append("        PLT_CODE      ");
                    //sbQuery.Append("        ,MS_REP_ID ");
                    sbQuery.Append("        ,MS_NO ");
                    sbQuery.Append("        ,REP_DATE ");
                    sbQuery.Append("        ,REP_TYPE ");
                    sbQuery.Append("        ,REP_VEN ");
                    sbQuery.Append("        ,SCOMMENT ");
                    sbQuery.Append("        ,REG_DATE ");
                    sbQuery.Append("        ,REG_EMP ");
                    sbQuery.Append(" )                         ");
                    sbQuery.Append(" VALUES                    ");
                    sbQuery.Append(" (                         ");
                    sbQuery.Append("        @PLT_CODE      ");
                    //sbQuery.Append("        ,@MS_REP_ID ");
                    sbQuery.Append("        ,@MS_NO ");
                    sbQuery.Append("        ,@REP_DATE ");
                    sbQuery.Append("        ,@REP_TYPE ");
                    sbQuery.Append("        ,@REP_VEN ");
                    sbQuery.Append("        ,@SCOMMENT ");
                    sbQuery.Append("        , GETDATE()");
                    sbQuery.Append("        , " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" );                         ");
                    sbQuery.Append(" SELECT CAST(SCOPE_IDENTITY() AS INT);             ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        return bizExecute.executeScalarQuery(sbQuery.ToString(), row);
                    }

                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

            return null;
        }
    }

    public class THIS_MEASURE_REPAIR_QUERY
    {
        /// <summary>
        /// 계측기 목록
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable THIS_MEASURE_REPAIR_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT   TMR.PLT_CODE         ");
                    sbQuery.Append("        , TMR.MS_REP_ID ");
                    sbQuery.Append("        , TMR.PLT_CODE ");
                    sbQuery.Append("        , TMR.MS_NO ");
                    sbQuery.Append("        , TMR.REP_DATE ");
                    sbQuery.Append("        , TMR.REP_TYPE ");
                    sbQuery.Append("        , TMR.REP_EMP ");
                    sbQuery.Append("        , TMR.REP_VEN ");
                    sbQuery.Append("        , TMR.SCOMMENT ");
                    sbQuery.Append("        , TMR.REG_DATE ");
                    sbQuery.Append("        , TMR.REG_EMP ");
                    sbQuery.Append("        , TMR.MDFY_DATE ");
                    sbQuery.Append("        , TMR.MDFY_EMP ");
                    sbQuery.Append("  FROM THIS_MEASURE_REPAIR TMR      ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE TMR.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@MS_NO", "TMR.MS_NO = @MS_NO "));

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



        public static DataTable THIS_MEASURE_REPAIR_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT   TMR.PLT_CODE         ");
                    sbQuery.Append("        , TMR.MS_REP_ID ");
                    sbQuery.Append("        , TMR.PLT_CODE ");
                    sbQuery.Append("        , TMR.MS_NO ");
                    sbQuery.Append("        , TMM.MS_NAME ");
                    sbQuery.Append("        , TMR.REP_DATE ");
                    sbQuery.Append("        , TMR.REP_TYPE ");
                    sbQuery.Append("        , TMR.REP_EMP ");
                    sbQuery.Append("        , TMR.REP_VEN ");
                    sbQuery.Append("        , TMR.SCOMMENT ");
                    sbQuery.Append("        , TMR.REG_DATE ");
                    sbQuery.Append("        , TMR.REG_EMP ");
                    sbQuery.Append("        , TMR.MDFY_DATE ");
                    sbQuery.Append("        , TMR.MDFY_EMP ");
                    sbQuery.Append("  FROM THIS_MEASURE_REPAIR TMR      ");
                    sbQuery.Append("  JOIN THIS_MEASURE_MASTER TMM ");
                    sbQuery.Append("  ON TMR.PLT_CODE = TMM.PLT_CODE ");
                    sbQuery.Append("  AND TMR.MS_NO = TMM.MS_NO ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE TMR.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@MS_NO", "TMR.MS_NO = @MS_NO "));

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
