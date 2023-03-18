using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DHIS
{
    public class THIS_MEASURE_MASTER
    {
        public static DataTable THIS_MEASURE_MASTER_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT  PLT_CODE      ");
                    sbQuery.Append("        , MS_NO ");
                    sbQuery.Append("        , ASSET_NO ");
                    sbQuery.Append("        , MS_TYPE ");
                    sbQuery.Append("        , MS_STATE ");
                    sbQuery.Append("        , MS_CAT ");
                    sbQuery.Append("        , MS_NAME ");
                    sbQuery.Append("        , MS_SERIAL_NO ");
                    sbQuery.Append("        , MS_SPEC ");
                    sbQuery.Append("        , MS_MAKER ");
                    sbQuery.Append("        , MS_COST ");
                    sbQuery.Append("        , MS_BUY_DATE ");
                    sbQuery.Append("        , MS_PERIOD ");
                    sbQuery.Append("        , MS_NEXT_DATE ");
                    sbQuery.Append("        , MS_IMAGE ");
                    sbQuery.Append("        , MS_HIS_ID ");
                    sbQuery.Append("        , MS_REP_ID ");
                    sbQuery.Append("        , REG_DATE ");
                    sbQuery.Append("        , REG_EMP ");
                    sbQuery.Append("        , MDFY_DATE ");
                    sbQuery.Append("        , MDFY_EMP ");
                    sbQuery.Append("        , DEL_DATE ");
                    sbQuery.Append("        , DEL_EMP ");
                    sbQuery.Append("        , DATA_FLAG ");
                    sbQuery.Append("  FROM THIS_MEASURE_MASTER       ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append("   AND MS_NO = @MS_NO      ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MS_NO")) isHasColumn = false;

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

        public static DataTable THIS_MEASURE_MASTER_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT  PLT_CODE      ");
                    sbQuery.Append("        , MS_NO ");
                    sbQuery.Append("        , MS_IMAGE ");
                    sbQuery.Append("  FROM THIS_MEASURE_MASTER       ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append("   AND MS_NO = @MS_NO      ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MS_NO")) isHasColumn = false;

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
        public static void THIS_MEASURE_MASTER_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE THIS_MEASURE_MASTER                      ");
                    sbQuery.Append("    SET  MS_NO = @MS_NO ");
                    sbQuery.Append("        , ASSET_NO = @ASSET_NO ");
                    sbQuery.Append("        , MS_TYPE      = @MS_TYPE      ");
                    sbQuery.Append("        , MS_STATE     = @MS_STATE     ");
                    sbQuery.Append("        , MS_CAT       = @MS_CAT       ");
                    sbQuery.Append("        , MS_NAME      = @MS_NAME      ");
                    sbQuery.Append("        , MS_SERIAL_NO = @MS_SERIAL_NO ");
                    sbQuery.Append("        , MS_SPEC      = @MS_SPEC      ");
                    sbQuery.Append("        , MS_MAKER     = @MS_MAKER     ");
                    sbQuery.Append("        , MS_COST      = @MS_COST      ");
                    sbQuery.Append("        , MS_BUY_DATE  = @MS_BUY_DATE  ");
                    sbQuery.Append("        , MS_PERIOD    = @MS_PERIOD    ");
                    sbQuery.Append("        , MS_NEXT_DATE = @MS_NEXT_DATE ");
                    sbQuery.Append("        , MS_IMAGE     = @MS_IMAGE     ");
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

        /// <summary>
        /// 계측기 지급/반납/폐기 이력 정보 업데이트
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void THIS_MEASURE_MASTER_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE THIS_MEASURE_MASTER                      ");
                    sbQuery.Append("    SET  MS_HIS_ID = @MS_HIS_ID     ");
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


        /// <summary>
        /// 계측기 보전 이력 정보 업데이트
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void THIS_MEASURE_MASTER_UPD3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE THIS_MEASURE_MASTER                      ");
                    sbQuery.Append("    SET  MS_REP_ID = @MS_REP_ID     ");
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

        public static void THIS_MEASURE_MASTER_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE THIS_MEASURE_MASTER                      ");
                    sbQuery.Append("    SET  DATA_FLAG = 2     ");
                    sbQuery.Append("        , DEL_DATE = GETDATE() ");
                    sbQuery.Append("        , DEL_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
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
        /// 계측기 삭제
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void THIS_MEASURE_MASTER_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" DELETE FROM  THIS_MEASURE_MASTER                  ");
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

        public static void THIS_MEASURE_MASTER_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO THIS_MEASURE_MASTER ");
                    sbQuery.Append(" (                         ");
                    sbQuery.Append("        PLT_CODE      ");
                    sbQuery.Append("        , MS_NO ");
                    sbQuery.Append("        , ASSET_NO ");
                    sbQuery.Append("        , MS_TYPE ");
                    sbQuery.Append("        , MS_STATE ");
                    sbQuery.Append("        , MS_CAT ");
                    sbQuery.Append("        , MS_NAME ");
                    sbQuery.Append("        , MS_SERIAL_NO ");
                    sbQuery.Append("        , MS_SPEC ");
                    sbQuery.Append("        , MS_MAKER ");
                    sbQuery.Append("        , MS_COST ");
                    sbQuery.Append("        , MS_BUY_DATE ");
                    sbQuery.Append("        , MS_PERIOD ");
                    sbQuery.Append("        , MS_NEXT_DATE ");
                    sbQuery.Append("        , MS_IMAGE ");
                    sbQuery.Append("        , MS_HIS_ID ");
                    sbQuery.Append("        , MS_REP_ID ");
                    sbQuery.Append("        , REG_DATE ");
                    sbQuery.Append("        , REG_EMP ");
                    sbQuery.Append("        , DATA_FLAG ");
                    sbQuery.Append(" )                         ");
                    sbQuery.Append(" VALUES                    ");
                    sbQuery.Append(" (                         ");
                    sbQuery.Append("        @PLT_CODE      ");
                    sbQuery.Append("        , @MS_NO ");
                    sbQuery.Append("        , @ASSET_NO ");
                    sbQuery.Append("        , @MS_TYPE ");
                    sbQuery.Append("        , @MS_STATE ");
                    sbQuery.Append("        , @MS_CAT ");
                    sbQuery.Append("        , @MS_NAME ");
                    sbQuery.Append("        , @MS_SERIAL_NO ");
                    sbQuery.Append("        , @MS_SPEC ");
                    sbQuery.Append("        , @MS_MAKER ");
                    sbQuery.Append("        , @MS_COST ");
                    sbQuery.Append("        , @MS_BUY_DATE ");
                    sbQuery.Append("        , @MS_PERIOD ");
                    sbQuery.Append("        , @MS_NEXT_DATE ");
                    sbQuery.Append("        , @MS_IMAGE ");
                    sbQuery.Append("        , @MS_HIS_ID ");
                    sbQuery.Append("        , @MS_REP_ID ");
                    sbQuery.Append("        , GETDATE()");
                    sbQuery.Append("        , " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("        , 0");
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

    public class THIS_MEASURE_MASTER_QUERY
    {
        /// <summary>
        /// 계측기 목록
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable THIS_MEASURE_MASTER_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT   TMM.PLT_CODE         ");
                    sbQuery.Append("        , TMM.MS_NO ");
                    sbQuery.Append("        , TMM.ASSET_NO ");
                    sbQuery.Append("        , TMM.MS_TYPE ");
                    sbQuery.Append("        , TMM.MS_STATE ");
                    sbQuery.Append("        , TMM.MS_CAT ");
                    sbQuery.Append("        , TMM.MS_NAME ");
                    sbQuery.Append("        , TMM.MS_SERIAL_NO ");
                    sbQuery.Append("        , TMM.MS_SPEC ");
                    sbQuery.Append("        , TMM.MS_MAKER ");
                    sbQuery.Append("        , TMM.MS_COST ");
                    sbQuery.Append("        , TMM.MS_BUY_DATE ");
                    sbQuery.Append("        , TMM.MS_PERIOD ");
                    sbQuery.Append("        , TMM.MS_NEXT_DATE ");
                    //sbQuery.Append("        , TMM.MS_IMAGE ");
                    sbQuery.Append("        , TMM.MS_HIS_ID ");
                    sbQuery.Append("        , TMM.MS_REP_ID ");
                    sbQuery.Append("        , TMM.REG_DATE ");
                    sbQuery.Append("        , TMM.REG_EMP ");
                    sbQuery.Append("        , TMM.MDFY_DATE ");
                    sbQuery.Append("        , TMM.MDFY_EMP ");
                    sbQuery.Append("        , TMM.DEL_DATE ");
                    sbQuery.Append("        , TMM.DEL_EMP ");
                    sbQuery.Append("        , TMM.DATA_FLAG ");
                    sbQuery.Append("        , CASE HIS.HIS_TYPE WHEN 'GIVE' THEN HIS.HIS_DATE END GIVE_DATE ");
                    sbQuery.Append("        , CASE HIS.HIS_TYPE WHEN 'GIVE' THEN HIS.HIS_EMP END GIVE_EMP_CODE ");
                    sbQuery.Append("        , CASE HIS.HIS_TYPE WHEN 'GIVE' THEN EMP.ORG_CODE END GIVE_ORG_CODE ");
                    sbQuery.Append("        , HIS_DIS.HIS_DATE AS DISUSE_DATE");
                    sbQuery.Append("        , HIS_DIS.HIS_EMP AS DISUSE_EMP_CODE ");
                    sbQuery.Append("        , REP.REP_DATE ");
                    sbQuery.Append("        , REP.REP_VEN ");
                    sbQuery.Append("  FROM THIS_MEASURE_MASTER TMM      ");
                    sbQuery.Append("    LEFT JOIN (SELECT TMH.PLT_CODE     ");
                    sbQuery.Append("               	 , TMH.MS_HIS_ID            ");
                    sbQuery.Append("               	 , TMH.MS_NO            ");
                    sbQuery.Append("               	 , TMH.HIS_DATE            ");
                    sbQuery.Append("               	 , TMH.HIS_TYPE            ");
                    sbQuery.Append("               	 , TMH.HIS_EMP            ");
                    sbQuery.Append("               	 , TMH.SCOMMENT            ");
                    sbQuery.Append("               	 , TMH.REG_EMP            ");
                    sbQuery.Append("               	 , TMH.REG_DATE            ");
                    sbQuery.Append("                 FROM THIS_MEASURE_HISTORY TMH            ");
                    sbQuery.Append("               	INNER JOIN (SELECT PLT_CODE, MS_NO, MAX(MS_HIS_ID) AS MS_HIS_ID        ");
                    sbQuery.Append("               				  FROM THIS_MEASURE_HISTORY            ");
                    sbQuery.Append("               				 WHERE HIS_TYPE IN ('GIVE','RETURN')            ");
                    sbQuery.Append("               				GROUP BY PLT_CODE, MS_NO) GTMH            ");
                    sbQuery.Append("               		ON TMH.PLT_CODE = GTMH.PLT_CODE            ");
                    sbQuery.Append("               		AND TMH.MS_HIS_ID = GTMH.MS_HIS_ID) HIS          ");
                    sbQuery.Append("       ON TMM.PLT_CODE = HIS.PLT_CODE                 ");
                    sbQuery.Append("       AND TMM.MS_NO = HIS.MS_NO ");
                    sbQuery.Append("    LEFT JOIN TSTD_EMPLOYEE EMP     ");
                    sbQuery.Append("        ON HIS.PLT_CODE = EMP.PLT_CODE");
                    sbQuery.Append("        AND HIS.HIS_EMP = EMP.EMP_CODE");
                    sbQuery.Append("    LEFT JOIN (SELECT TMH.PLT_CODE     ");
                    sbQuery.Append("               	 , TMH.MS_HIS_ID            ");
                    sbQuery.Append("               	 , TMH.MS_NO            ");
                    sbQuery.Append("               	 , TMH.HIS_DATE            ");
                    sbQuery.Append("               	 , TMH.HIS_TYPE            ");
                    sbQuery.Append("               	 , TMH.HIS_EMP            ");
                    sbQuery.Append("               	 , TMH.SCOMMENT            ");
                    sbQuery.Append("               	 , TMH.REG_EMP            ");
                    sbQuery.Append("               	 , TMH.REG_DATE            ");
                    sbQuery.Append("                 FROM THIS_MEASURE_HISTORY TMH            ");
                    sbQuery.Append("               	INNER JOIN (SELECT PLT_CODE, MS_NO, MAX(MS_HIS_ID) AS MS_HIS_ID        ");
                    sbQuery.Append("               				  FROM THIS_MEASURE_HISTORY            ");
                    sbQuery.Append("               				 WHERE HIS_TYPE IN ('DISUSE')            ");
                    sbQuery.Append("               				GROUP BY PLT_CODE, MS_NO) GTMH            ");
                    sbQuery.Append("               		ON TMH.PLT_CODE = GTMH.PLT_CODE            ");
                    sbQuery.Append("               		AND TMH.MS_HIS_ID = GTMH.MS_HIS_ID) HIS_DIS          ");
                    sbQuery.Append("       ON TMM.PLT_CODE = HIS_DIS.PLT_CODE                 ");
                    sbQuery.Append("       AND TMM.MS_NO = HIS_DIS.MS_NO ");

                    sbQuery.Append("    LEFT JOIN (SELECT TMR.PLT_CODE     ");
                    sbQuery.Append("               	 , TMR.MS_REP_ID            ");
                    sbQuery.Append("               	 , TMR.MS_NO            ");
                    sbQuery.Append("               	 , TMR.REP_DATE            ");
                    sbQuery.Append("               	 , TMR.REP_TYPE            ");
                    sbQuery.Append("               	 , TMR.REP_EMP            ");
                    sbQuery.Append("               	 , TMR.REP_VEN            ");
                    sbQuery.Append("               	 , TMR.SCOMMENT            ");
                    sbQuery.Append("               	 , TMR.REG_EMP            ");
                    sbQuery.Append("               	 , TMR.REG_DATE            ");
                    sbQuery.Append("                 FROM THIS_MEASURE_REPAIR TMR            ");
                    sbQuery.Append("               	INNER JOIN (SELECT PLT_CODE, MS_NO, MAX(MS_REP_ID) AS MS_REP_ID        ");
                    sbQuery.Append("               				  FROM THIS_MEASURE_REPAIR            ");
                    sbQuery.Append("               				 WHERE REP_TYPE IN ('GYOJEONG')            ");
                    sbQuery.Append("               				GROUP BY PLT_CODE, MS_NO) GTMR            ");
                    sbQuery.Append("               		ON TMR.PLT_CODE = GTMR.PLT_CODE            ");
                    sbQuery.Append("               		AND TMR.MS_REP_ID = GTMR.MS_REP_ID) REP          ");
                    sbQuery.Append("       ON TMM.PLT_CODE = REP.PLT_CODE                 ");
                    sbQuery.Append("       AND TMM.MS_NO = REP.MS_NO ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE TMM.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@MS_NO_LIKE", "TMM.MS_NO LIKE '%' + @MS_NO_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MS_NO", " TMM.MS_NO = @MS_NO "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MS_CAT", " TMM.MS_CAT = @MS_CAT "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MS_NAME_LIKE", "TMM.MS_NAME LIKE '%' + @MS_NAME_LIKE + '%'"));

                        sbWhere.Append(UTIL.GetWhere(row, "@MCN_EMP", " EMP.EMP_CODE = @MCN_EMP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MCN_GRP", " EMP.ORG_CODE = @MCN_GRP"));

                        sbWhere.Append(UTIL.GetWhere(row, "@MS_TYPE", " TMM.MS_TYPE = @MS_TYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "TMM.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DAY_ARRANGE", "CONVERT(DATE,MS_NEXT_DATE) BETWEEN CONVERT(DATE,GETDATE()-@DAY_ARRANGE) AND CONVERT(DATE,GETDATE())"));
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
