using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DHIS
{
    public class THIS_INS_MC
    {
        public static DataTable THIS_INS_MC_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT  PLT_CODE      ");
                    sbQuery.Append("        , MRI_CODE ");
                    sbQuery.Append("        , MC_CODE ");
                    sbQuery.Append("        , INS_ITEM ");
                    sbQuery.Append("        , MEASURE ");
                    sbQuery.Append("        , INS_OK ");
                    sbQuery.Append("        , INS_NG ");
                    sbQuery.Append("        , INS_CHARGE ");
                    sbQuery.Append("        , INS_DATE ");
                    sbQuery.Append("        , REG_DATE ");
                    sbQuery.Append("        , REG_EMP ");
                    sbQuery.Append("        , MDFY_DATE ");
                    sbQuery.Append("        , MDFY_EMP ");
                    sbQuery.Append("  FROM THIS_INS_MC       ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append("   AND MRI_CODE = @MRI_CODE      ");
                    sbQuery.Append("   AND MC_CODE = @MC_CODE      ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MRI_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MC_CODE")) isHasColumn = false;

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
        /// 설비점검기록 _적합,부적합건 조회 
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable THIS_INS_MC_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT   INS_DATE      ");
                    sbQuery.Append("        , SUM(INS_OK) AS OK_QTY ");
                    sbQuery.Append("        , SUM(INS_NG) AS NG_QTY ");
                    sbQuery.Append("        , INS_CHARGE ");
                    sbQuery.Append("        , MC_CODE ");
                 
                    sbQuery.Append("  FROM THIS_INS_MC       ");
                    sbQuery.Append(" WHERE MC_CODE = @MC_CODE");
                    sbQuery.Append(" GROUP BY MC_CODE, INS_DATE, INS_CHARGE ");
                    sbQuery.Append(" ORDER BY INS_DATE ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MC_CODE")) isHasColumn = false;

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



        public static void THIS_INS_MC_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE THIS_INS_MC                      ");
                    sbQuery.Append("    SET  INS_ITEM   = @INS_ITEM      ");
                    sbQuery.Append("        , INS_DATE   = @INS_DATE     ");
                    sbQuery.Append("        , MEASURE   = @MEASURE     ");
                    sbQuery.Append("        , INS_OK   = @INS_OK     ");
                    sbQuery.Append("        , INS_NG   = @INS_NG     ");
                    sbQuery.Append("        , INS_CHARGE   = @INS_CHARGE     ");
                    sbQuery.Append("        , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("        , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE           ");
                    sbQuery.Append("    AND MRI_CODE = @MRI_CODE             ");
                    sbQuery.Append("    AND MC_CODE = @MC_CODE             ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MRI_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MC_CODE")) isHasColumn = false;

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
        public static void THIS_INS_MC_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" DELETE FROM  THIS_INS_MC                  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE           ");
                    sbQuery.Append("    AND MRI_CODE = @MRI_CODE             ");
                   // sbQuery.Append("    AND MC_CODE = @MC_CODE             ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MRI_CODE")) isHasColumn = false;
                     // if (!UTIL.ValidColumn(row, "MC_CODE")) isHasColumn = false;

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





        public static void THIS_INS_MC_DEL2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" DELETE FROM  THIS_INS_MC             ");
                    sbQuery.Append("  WHERE MC_CODE = @MC_CODE            ");
                    sbQuery.Append("    AND INS_DATE = @INS_DATE          ");
                    sbQuery.Append("    AND INS_CHARGE = @INS_CHARGE      ");
                    // sbQuery.Append("    AND MC_CODE = @MC_CODE             ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "MC_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "INS_DATE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "INS_CHARGE")) isHasColumn = false;
                        // if (!UTIL.ValidColumn(row, "MC_CODE")) isHasColumn = false;

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




        public static void THIS_INS_MC_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO THIS_INS_MC ");
                    sbQuery.Append(" (                         ");
                    sbQuery.Append("        PLT_CODE      ");
                    sbQuery.Append("        , MRI_CODE ");
                    sbQuery.Append("        , MC_CODE ");
                    sbQuery.Append("        , INS_ITEM ");
                    sbQuery.Append("        , MEASURE ");
                    sbQuery.Append("        , INS_OK ");
                    sbQuery.Append("        , INS_NG ");
                    sbQuery.Append("        , INS_CHARGE ");
                    sbQuery.Append("        , INS_DATE ");
                    sbQuery.Append("        , REG_DATE ");
                    sbQuery.Append("        , REG_EMP ");
                    sbQuery.Append(" )                         ");
                    sbQuery.Append(" VALUES                    ");
                    sbQuery.Append(" (                         ");
                    sbQuery.Append("        @PLT_CODE      ");
                    sbQuery.Append("        , @MRI_CODE ");
                    sbQuery.Append("        , @MC_CODE ");
                    sbQuery.Append("        , @INS_ITEM ");
                    sbQuery.Append("        , @MEASURE");
                    sbQuery.Append("        , @INS_OK ");
                    sbQuery.Append("        , @INS_NG ");
                    sbQuery.Append("        , @INS_CHARGE ");
                    sbQuery.Append("        , @INS_DATE ");
                    sbQuery.Append("        , GETDATE()");
                    sbQuery.Append("        , " + UTIL.GetValidValue(ConnInfo.UserID));
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

    public class THIS_INS_MC_QUERY
    {
      
        public static DataTable THIS_INS_MC_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT   TIM.PLT_CODE ");
                    sbQuery.Append("        , TIM.MC_CODE ");
                    sbQuery.Append("        , TIM.MRI_CODE ");
                    sbQuery.Append("        , TIM.INS_ITEM ");
                    sbQuery.Append("        , TIM.MEASURE ");
                    sbQuery.Append("        , TIM.INS_OK ");
                    sbQuery.Append("        , TIM.INS_NG ");
                    sbQuery.Append("        , TIM.INS_CHARGE ");
                    sbQuery.Append("        , TIM.INS_DATE "); 
                    sbQuery.Append("        , TIM.REG_DATE ");
                    sbQuery.Append("        , TIM.REG_EMP ");
                    sbQuery.Append("        , TIM.MDFY_DATE ");
                    sbQuery.Append("        , TIM.MDFY_EMP ");
                    sbQuery.Append("  FROM THIS_INS_MC TIM      ");
                    //sbQuery.Append("    INNER JOIN THIS_STD_PM SP     ");
                    //sbQuery.Append("        ON PM.PLT_CODE = SP.PLT_CODE     ");
                    //sbQuery.Append("        AND PM.MTN_CODE = SP.MTN_CODE     ");
                    //sbQuery.Append("    LEFT JOIN LSE_MACHINE MC     ");
                    //sbQuery.Append("        ON PM.PLT_CODE = MC.PLT_CODE     ");
                    //sbQuery.Append("        AND PM.MC_CODE = MC.MC_CODE     ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE TIM.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@MRI_CODE", "TIM.MRI_CODE = @MRI_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_CODE", "TIM.MC_CODE = @MC_CODE "));

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
