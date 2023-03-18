using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DORD
{
    public class TORD_PROJECT_HISTORY
    {

        public static DataTable TORD_PROJECT_HISTORY_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("SELECT   PLT_CODE ");
                    sbQuery.Append("       , PRJ_CODE ");
                    sbQuery.Append("       , PRJ_HIS_CODE ");
                    sbQuery.Append("       , CONTENTS ");
                    sbQuery.Append("       , EMP_CODE ");
                    sbQuery.Append("       , HIS_DATE ");
                    sbQuery.Append("       , REG_DATE ");
                    sbQuery.Append("       , REG_EMP ");
                    sbQuery.Append("       , MDFY_DATE ");
                    sbQuery.Append("       , MDFY_EMP ");
                    sbQuery.Append("       , DEL_DATE ");
                    sbQuery.Append("       , DEL_EMP ");
                    sbQuery.Append("       , DATA_FLAG ");
                    sbQuery.Append("  FROM TORD_PROJECT_HISTORY ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND PRJ_HIS_CODE = @PRJ_HIS_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PRJ_HIS_CODE")) isHasColumn = false;

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

        public static void TORD_PROJECT_HISTORY_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("UPDATE TORD_PROJECT_HISTORY ");
                    sbQuery.Append("   SET   EMP_CODE = @EMP_CODE ");
                    sbQuery.Append("       , HIS_DATE = @HIS_DATE ");
                    sbQuery.Append("       , CONTENTS = @CONTENTS ");
                    sbQuery.Append("       , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("       , MDFY_EMP = @MDFY_EMP ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND PRJ_HIS_CODE = @PRJ_HIS_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크                        
                        if (!UTIL.ValidColumn(row, "PRJ_HIS_CODE")) isHasColumn = false;

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

        public static void TORD_PROJECT_HISTORY_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();


                    sbQuery.Append("INSERT INTO TORD_PROJECT_HISTORY ");
                    sbQuery.Append("( ");
                    sbQuery.Append("         PLT_CODE ");
                    sbQuery.Append("       , PRJ_CODE ");
                    sbQuery.Append("       , PRJ_HIS_CODE ");
                    sbQuery.Append("       , EMP_CODE ");
                    sbQuery.Append("       , HIS_DATE ");
                    sbQuery.Append("       , CONTENTS ");
                    sbQuery.Append("       , REG_DATE ");
                    sbQuery.Append("       , REG_EMP ");
                    sbQuery.Append("       , DATA_FLAG ");
                    sbQuery.Append(") ");
                    sbQuery.Append("VALUES ");
                    sbQuery.Append("( ");
                    sbQuery.Append("         @PLT_CODE ");
                    sbQuery.Append("       , @PRJ_CODE ");
                    sbQuery.Append("       , @PRJ_HIS_CODE ");
                    sbQuery.Append("       , @EMP_CODE ");
                    sbQuery.Append("       , @HIS_DATE ");
                    sbQuery.Append("       , @CONTENTS ");
                    sbQuery.Append("       , GETDATE() ");
                    sbQuery.Append("       , @REG_EMP ");
                    sbQuery.Append("       , 0 ");
                    sbQuery.Append(") ");

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

        public static void TORD_PROJECT_HISTORY_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("UPDATE TORD_PROJECT_HISTORY ");
                    sbQuery.Append("  SET   DEL_DATE = GETDATE() ");
                    sbQuery.Append("      , DEL_EMP = @DEL_EMP ");
                    sbQuery.Append("      , DATA_FLAG = 2 ");
                    sbQuery.Append("WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND PRJ_HIS_CODE = @PRJ_HIS_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크                        
                        if (!UTIL.ValidColumn(row, "PRJ_HIS_CODE")) isHasColumn = false;

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

    public class TORD_PROJECT_HISTORY_QUERY
    {
        public static DataTable TORD_PROJECT_HISTORY_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("SELECT   H.PLT_CODE ");
                    sbQuery.Append("       , H.PRJ_CODE ");
                    sbQuery.Append("       , H.PRJ_HIS_CODE ");
                    sbQuery.Append("       , H.CONTENTS ");
                    sbQuery.Append("       , H.EMP_CODE ");
                    sbQuery.Append("       , H.HIS_DATE ");
                    sbQuery.Append("       , H.REG_DATE ");
                    sbQuery.Append("       , H.REG_EMP ");
                    sbQuery.Append("       , H.MDFY_DATE ");
                    sbQuery.Append("       , H.MDFY_EMP ");
                    sbQuery.Append("       , H.DEL_DATE ");
                    sbQuery.Append("       , H.DEL_EMP ");
                    sbQuery.Append("       , H.DATA_FLAG ");
                    sbQuery.Append("  FROM TORD_PROJECT P ");
                    sbQuery.Append("  JOIN TORD_PROJECT_HISTORY H ");
                    sbQuery.Append("  ON P.PLT_CODE = H.PLT_CODE ");
                    sbQuery.Append("  AND P.PRJ_CODE = H.PRJ_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            StringBuilder sbWhere = new StringBuilder();

                            sbWhere.Append(" WHERE H.DATA_FLAG = 0 ");
                            sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", " H.PLT_CODE = @PLT_CODE"));
                            sbWhere.Append(UTIL.GetWhere(row, "@PRJ_CODE", " H.PRJ_CODE = @PRJ_CODE"));

                            sbWhere.Append(" ORDER BY H.HIS_DATE DESC ");

                            DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

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
    }
}
