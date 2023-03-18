using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DHIS
{
    public class THIS_MEASURE_HISTORY
    {
        public static DataTable THIS_MEASURE_HISTORY_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT  PLT_CODE      ");
                    sbQuery.Append("        ,MS_HIS_ID ");
                    sbQuery.Append("        ,PLT_CODE ");
                    sbQuery.Append("        ,MS_NO ");
                    sbQuery.Append("        ,HIS_DATE ");
                    sbQuery.Append("        ,HIS_TYPE ");
                    sbQuery.Append("        ,HIS_EMP ");
                    sbQuery.Append("        ,SCOMMENT ");
                    sbQuery.Append("        ,REG_DATE ");
                    sbQuery.Append("        ,REG_EMP ");
                    sbQuery.Append("        ,MDFY_DATE ");
                    sbQuery.Append("        ,MDFY_EMP ");
                    sbQuery.Append("  FROM THIS_MEASURE_HISTORY       ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append("   AND MS_HIS_ID = @MS_HIS_ID      ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MS_HIS_ID")) isHasColumn = false;

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
        public static void THIS_MEASURE_HISTORY_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE THIS_MEASURE_HISTORY                      ");
                    sbQuery.Append("    SET  GIVE_STATE = @GIVE_STATE ");
                    sbQuery.Append("        , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("        , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE           ");
                    sbQuery.Append("    AND MS_NO = @MS_NO             ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MS_NO")) isHasColumn = false;

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

        public static void THIS_MEASURE_HISTORY_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE THIS_MEASURE_HISTORY       ");
                    sbQuery.Append("    SET   HIS_DATE = @HIS_DATE ");
                    sbQuery.Append("        , HIS_TYPE = @HIS_TYPE ");
                    sbQuery.Append("        , HIS_EMP = @HIS_EMP ");
                    sbQuery.Append("        , SCOMMENT = @SCOMMENT ");
                    sbQuery.Append("        , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("        , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE           ");
                    sbQuery.Append("    AND MS_HIS_ID = @MS_HIS_ID          ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MS_HIS_ID")) isHasColumn = false;

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
        public static void THIS_MEASURE_HISTORY_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" DELETE FROM  THIS_MEASURE_HISTORY                  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE           ");
                    sbQuery.Append("    AND MS_NO = @MS_NO             ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MS_NO")) isHasColumn = false;

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
        /// 계측기 삭제2
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void THIS_MEASURE_HISTORY_DEL2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" DELETE FROM  THIS_MEASURE_HISTORY    ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE          ");
                    sbQuery.Append("    AND MS_NO = @MS_NO             ");
                    sbQuery.Append("    AND MS_HIS_ID = @MS_HIS_ID     ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MS_NO")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MS_HIS_ID")) isHasColumn = false;

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



        public static object THIS_MEASURE_HISTORY_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO THIS_MEASURE_HISTORY ");
                    sbQuery.Append(" (                         ");
                    sbQuery.Append("        PLT_CODE      ");
                    //sbQuery.Append("        , MS_HIS_ID ");
                    sbQuery.Append("        , MS_NO ");
                    sbQuery.Append("        , HIS_DATE ");
                    sbQuery.Append("        , HIS_TYPE ");
                    sbQuery.Append("        , HIS_EMP ");
                    sbQuery.Append("        , SCOMMENT ");
                    sbQuery.Append("        , REG_DATE ");
                    sbQuery.Append("        , REG_EMP ");
                    sbQuery.Append(" )                         ");
                    sbQuery.Append(" VALUES                    ");
                    sbQuery.Append(" (                         ");
                    sbQuery.Append("        @PLT_CODE      ");
                    //sbQuery.Append("        , @MS_HIS_ID ");
                    sbQuery.Append("        , @MS_NO ");
                    sbQuery.Append("        , @HIS_DATE ");
                    sbQuery.Append("        , @HIS_TYPE ");
                    sbQuery.Append("        , @HIS_EMP ");
                    sbQuery.Append("        , @SCOMMENT ");
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

    public class THIS_MEASURE_HISTORY_QUERY
    {
        /// <summary>
        /// 계측기 목록
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable THIS_MEASURE_HISTORY_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT   TMH.PLT_CODE         ");
                    sbQuery.Append("        , TMH.MS_HIS_ID ");
                    sbQuery.Append("        , TMH.PLT_CODE ");
                    sbQuery.Append("        , TMH.MS_NO ");
                    sbQuery.Append("        , TMH.HIS_DATE ");
                    sbQuery.Append("        , TMH.HIS_TYPE ");
                    sbQuery.Append("        , TMH.HIS_EMP ");
                    sbQuery.Append("        , TMH.SCOMMENT ");
                    sbQuery.Append("        , TMH.REG_DATE ");
                    sbQuery.Append("        , TMH.REG_EMP ");
                    sbQuery.Append("        , TMH.MDFY_DATE ");
                    sbQuery.Append("        , TMH.MDFY_EMP ");
                    sbQuery.Append("  FROM THIS_MEASURE_HISTORY TMH      ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE TMH.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@MS_NO", "TMH.MS_NO = @MS_NO "));

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



        public static DataTable THIS_MEASURE_HISTORY_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT   TMH.PLT_CODE         ");
                    sbQuery.Append("        , TMH.MS_HIS_ID ");
                    sbQuery.Append("        , TMH.PLT_CODE ");
                    sbQuery.Append("        , TMH.MS_NO ");
                    sbQuery.Append("        , TMM.MS_NAME ");
                    sbQuery.Append("        , TMH.HIS_DATE ");
                    sbQuery.Append("        , TMH.HIS_TYPE ");
                    sbQuery.Append("        , TMH.HIS_EMP ");
                    sbQuery.Append("        , EMP.EMP_NAME AS HIS_EMP_NAME");
                    sbQuery.Append("        , TMH.SCOMMENT ");
                    sbQuery.Append("        , TMH.REG_DATE ");
                    sbQuery.Append("        , TMH.REG_EMP ");
                    sbQuery.Append("        , TMH.MDFY_DATE ");
                    sbQuery.Append("        , TMH.MDFY_EMP ");
                    sbQuery.Append("  FROM THIS_MEASURE_HISTORY TMH  ");
                    sbQuery.Append("  JOIN THIS_MEASURE_MASTER TMM ");
                    sbQuery.Append("  ON TMH.PLT_CODE = TMM.PLT_CODE ");
                    sbQuery.Append("  AND TMH.MS_NO = TMM.MS_NO ");
                    sbQuery.Append("  JOIN TSTD_EMPLOYEE EMP ");
                    sbQuery.Append("  ON TMH.PLT_CODE = EMP.PLT_CODE ");
                    sbQuery.Append("  AND TMH.HIS_EMP = EMP.EMP_CODE ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE TMH.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@MS_NO", "TMH.MS_NO = @MS_NO "));

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
