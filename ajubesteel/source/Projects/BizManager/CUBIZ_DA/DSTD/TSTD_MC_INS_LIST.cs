using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSTD
{
    public class TSTD_MC_INS_LIST
    {


        public static DataTable TSTD_MC_INS_LIST_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("SELECT   PLT_CODE ");
                    sbQuery.Append("       , MC_INS_CODE ");
                    sbQuery.Append("       , INS_INTERVAL ");
                    sbQuery.Append("       , INS_ITEM ");
                    sbQuery.Append("       , INS_METHOD ");
                    sbQuery.Append("       , LIMIT_LOW ");
                    sbQuery.Append("       , LIMIT_HIGH ");
                    sbQuery.Append("       , INS_UNIT ");
                    sbQuery.Append("       , INS_ACTION ");
                    sbQuery.Append("       , INS_SEQ ");
                    sbQuery.Append("       , REG_DATE ");
                    sbQuery.Append("       , REG_EMP ");
                    sbQuery.Append("       , MDFY_DATE ");
                    sbQuery.Append("       , MDFY_EMP ");
                    sbQuery.Append("       , DEL_DATE ");
                    sbQuery.Append("       , DEL_EMP ");
                    sbQuery.Append("       , DATA_FLAG ");
                    sbQuery.Append("  FROM TSTD_MC_INS_LIST ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND MC_INS_CODE = @MC_INS_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "MC_INS_CODE")) isHasColumn = false;

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

        public static void TSTD_MC_INS_LIST_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("UPDATE TSTD_MC_INS_LIST ");
                    sbQuery.Append("   SET   INS_SEQ = @INS_SEQ ");
                    sbQuery.Append("       , INS_INTERVAL = @INS_INTERVAL ");
                    sbQuery.Append("       , INS_METHOD = @INS_METHOD");
                    sbQuery.Append("       , INS_ITEM = @INS_ITEM");
                    sbQuery.Append("       , LIMIT_LOW = @LIMIT_LOW ");
                    sbQuery.Append("       , LIMIT_HIGH = @LIMIT_HIGH ");
                    sbQuery.Append("       , INS_UNIT = @INS_UNIT ");
                    sbQuery.Append("       , INS_ACTION = @INS_ACTION");
                    sbQuery.Append("       , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("       , MDFY_EMP = @MDFY_EMP ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND MC_INS_CODE = @MC_INS_CODE ");


                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크                        
                        if (!UTIL.ValidColumn(row, "MC_INS_CODE")) isHasColumn = false;

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

        public static void TSTD_MC_INS_LIST_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();


                    sbQuery.Append("INSERT INTO TSTD_MC_INS_LIST ");
                    sbQuery.Append("( ");
                    sbQuery.Append("         PLT_CODE ");
                    sbQuery.Append("       , MC_CODE ");
                    sbQuery.Append("       , MC_INS_CODE ");
                    sbQuery.Append("       , INS_INTERVAL ");
                    sbQuery.Append("       , INS_ITEM ");
                    sbQuery.Append("       , INS_METHOD ");
                    sbQuery.Append("       , LIMIT_LOW ");
                    sbQuery.Append("       , LIMIT_HIGH ");
                    sbQuery.Append("       , INS_UNIT ");
                    sbQuery.Append("       , INS_ACTION ");
                    sbQuery.Append("       , INS_SEQ ");
                    sbQuery.Append("       , REG_DATE ");
                    sbQuery.Append("       , REG_EMP ");
                    sbQuery.Append("       , DATA_FLAG ");
                    sbQuery.Append(") ");
                    sbQuery.Append("VALUES ");
                    sbQuery.Append("( ");
                    sbQuery.Append("         @PLT_CODE ");
                    sbQuery.Append("       , @MC_CODE ");
                    sbQuery.Append("       , @MC_INS_CODE ");
                    sbQuery.Append("       , @INS_INTERVAL ");
                    sbQuery.Append("       , @INS_ITEM ");
                    sbQuery.Append("       , @INS_METHOD ");
                    sbQuery.Append("       , @LIMIT_LOW ");
                    sbQuery.Append("       , @LIMIT_HIGH ");
                    sbQuery.Append("       , @INS_UNIT ");
                    sbQuery.Append("       , @INS_ACTION ");
                    sbQuery.Append("       , @INS_SEQ ");
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

        public static void TSTD_MC_INS_LIST_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("UPDATE TSTD_MC_INS_LIST ");
                    sbQuery.Append("  SET   DEL_DATE = GETDATE() ");
                    sbQuery.Append("      , DEL_EMP = @DEL_EMP ");
                    sbQuery.Append("      , DATA_FLAG = 2 ");
                    sbQuery.Append("WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND MC_INS_CODE = @MC_INS_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크                        
                        if (!UTIL.ValidColumn(row, "MC_INS_CODE")) isHasColumn = false;

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

    public class TSTD_MC_INS_LIST_QUERY
    {
     
        public static DataTable TSTD_MC_INS_LIST_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
              
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("SELECT   MIL.PLT_CODE ");
                    sbQuery.Append("       , MIL.MC_CODE ");
                    sbQuery.Append("       , MIL.MC_INS_CODE ");
                    sbQuery.Append("       , MIL.INS_INTERVAL ");
                    sbQuery.Append("       , MIL.INS_ITEM ");
                    sbQuery.Append("       , MIL.INS_METHOD ");
                    sbQuery.Append("       , CAST(CAST(LIMIT_LOW AS INT) AS varchar) + ' ~ ' + CAST(CAST(LIMIT_HIGH AS INT) AS varchar) + TC.CD_NAME AS INS_SPEC ");
                    sbQuery.Append("       , MIL.LIMIT_LOW ");
                    sbQuery.Append("       , MIL.LIMIT_HIGH ");
                    sbQuery.Append("       , MIL.INS_UNIT ");
                    sbQuery.Append("       , MIL.INS_ACTION ");
                    sbQuery.Append("       , MIL.INS_SEQ ");
                    sbQuery.Append("       , MIL.REG_DATE ");
                    sbQuery.Append("       , MIL.REG_EMP ");
                    sbQuery.Append("       , MIL.MDFY_DATE ");
                    sbQuery.Append("       , MIL.MDFY_EMP ");
                    sbQuery.Append("       , MIL.DEL_DATE ");
                    sbQuery.Append("       , MIL.DEL_EMP ");
                    sbQuery.Append("       , MIL.DATA_FLAG ");
                    sbQuery.Append("  FROM TSTD_MC_INS_LIST MIL       ");
                    sbQuery.Append("  LEFT JOIN TSTD_CODES TC         ");
                    sbQuery.Append("  ON MIL.PLT_CODE = TC.PLT_CODE   ");
                    sbQuery.Append("  AND MIL.INS_UNIT = TC.CD_CODE   ");
                    sbQuery.Append("  AND TC.CAT_CODE = 'S050'        ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            StringBuilder sbWhere = new StringBuilder();

                            sbWhere.Append(" WHERE MIL.DATA_FLAG = 0 ");

                            sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", " MIL.PLT_CODE = @PLT_CODE "));
                            sbWhere.Append(UTIL.GetWhere(row, "@MC_CODE", "MIL.MC_CODE = @MC_CODE ")); 
                            //sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE, @E_REG_DATE", " REG_DATE BETWEEN @S_REG_DATE AND @E_REG_DATE ")); // 등록일
                         
                         
                            sbWhere.Append(" ORDER BY MIL.INS_SEQ ");

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


        public static DataTable TSTD_MC_INS_LIST_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("SELECT   MIL.PLT_CODE ");
                    sbQuery.Append("       , MIL.MC_CODE ");
                    sbQuery.Append("       , MIL.MC_INS_CODE ");
                    sbQuery.Append("       , MIL.INS_INTERVAL ");
                    sbQuery.Append("       , MIL.INS_ITEM ");
                    sbQuery.Append("       , MIL.INS_METHOD ");
                    sbQuery.Append("       , MIL.INS_SPEC ");
                    sbQuery.Append("       , MIL.INS_ACTION ");
                    sbQuery.Append("       , MIL.INS_SEQ ");
                    sbQuery.Append("       , TIM.MRI_CODE ");
                    sbQuery.Append("       , TIM.INS_DATE ");
                    sbQuery.Append("       , TIM.OK_QTY ");
                    sbQuery.Append("       , TIM.NG_QTY ");
                    sbQuery.Append("       , TIM.INS_CHARGE ");
                    sbQuery.Append("       , TIM.MEASURE ");
                    sbQuery.Append("       , MIL.REG_DATE ");
                    sbQuery.Append("       , MIL.REG_EMP ");
                    sbQuery.Append("       , MIL.MDFY_DATE ");
                    sbQuery.Append("       , MIL.MDFY_EMP ");
                    sbQuery.Append("       , MIL.DEL_DATE ");
                    sbQuery.Append("       , MIL.DEL_EMP ");
                    sbQuery.Append("       , MIL.DATA_FLAG ");
                    sbQuery.Append("  FROM TSTD_MC_INS_LIST MIL ");
                    sbQuery.Append("  JOIN THIS_INS_MC TIM ");
                    sbQuery.Append("  ON MIL.PLT_CODE = TIM.PLT_CODE ");
                    sbQuery.Append("  AND MIL.MC_CODE = TIM.MC_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            StringBuilder sbWhere = new StringBuilder();

                            sbWhere.Append(" WHERE MIL.DATA_FLAG = 0 ");

                            sbWhere.Append(UTIL.GetWhere(row, "@PLT_CODE", " MIL.PLT_CODE = @PLT_CODE "));
                            sbWhere.Append(UTIL.GetWhere(row, "@INS_ITEM", "MIL.INS_ITEM = @INS_ITEM "));
                            sbWhere.Append(UTIL.GetWhere(row, "@MRI_CODE", "TIM.MRI_CODE = @MRI_CODE "));
                            //sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE, @E_REG_DATE", " REG_DATE BETWEEN @S_REG_DATE AND @E_REG_DATE ")); // 등록일


                            sbWhere.Append(" ORDER BY INS_SEQ ");

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



        public static DataTable TSTD_MC_INS_LIST_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();


                    sbQuery.Append("SELECT   MIL.PLT_CODE ");
                    sbQuery.Append("       , MIL.MC_CODE ");
                    sbQuery.Append("       , MIL.MC_INS_CODE ");
                    sbQuery.Append("       , MIL.INS_INTERVAL ");
                    sbQuery.Append("       , MIL.INS_ITEM ");
                    sbQuery.Append("       , MIL.INS_METHOD ");
                    sbQuery.Append("       , CAST(CAST(MIL.LIMIT_LOW AS INT) AS varchar) + ' ~ ' + CAST(CAST(MIL.LIMIT_HIGH AS INT) AS varchar) + MIL.INS_UNIT AS INS_SPEC ");
                    sbQuery.Append("       , MIL.LIMIT_LOW ");
                    sbQuery.Append("       , MIL.LIMIT_HIGH ");
                    sbQuery.Append("       , MIL.INS_UNIT ");
                    sbQuery.Append("       , MIL.INS_ACTION ");
                    sbQuery.Append("       , MIL.INS_SEQ ");
                    sbQuery.Append("       , TIM.MRI_CODE ");
                    sbQuery.Append("       , TIM.INS_DATE ");
                    sbQuery.Append("       , TIM.INS_OK ");
                    sbQuery.Append("       , TIM.INS_NG ");
                    sbQuery.Append("       , TIM.INS_CHARGE ");
                    sbQuery.Append("       , TIM.MEASURE ");
                    sbQuery.Append("       , MIL.REG_DATE ");
                    sbQuery.Append("       , MIL.REG_EMP ");
                    sbQuery.Append("       , MIL.MDFY_DATE ");
                    sbQuery.Append("       , MIL.MDFY_EMP ");
                    sbQuery.Append("       , MIL.DEL_DATE ");
                    sbQuery.Append("       , MIL.DEL_EMP ");
                    sbQuery.Append("       , MIL.DATA_FLAG ");
                    sbQuery.Append("  FROM TSTD_MC_INS_LIST MIL ");
                    sbQuery.Append("  JOIN (SELECT * FROM THIS_INS_MC WHERE MC_CODE = @MC_CODE AND INS_DATE = @INS_DATE AND INS_CHARGE = @INS_CHARGE) TIM ");
                    sbQuery.Append("  ON MIL.PLT_CODE = TIM.PLT_CODE ");
                    sbQuery.Append("  AND MIL.MC_CODE = TIM.MC_CODE ");
                    sbQuery.Append("  AND MIL.INS_ITEM = TIM.INS_ITEM ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "MC_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "INS_DATE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "INS_CHARGE")) isHasColumn = false;


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

    }
}
