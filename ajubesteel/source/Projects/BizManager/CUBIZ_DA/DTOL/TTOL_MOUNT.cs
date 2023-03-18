using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DTOL
{
    public class TTOL_MOUNT
    {

        public static DataTable TTOL_MOUNT_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("SELECT   PLT_CODE ");
                    sbQuery.Append("       , MOUNT_ID ");
                    sbQuery.Append("       , MC_CODE ");
                    sbQuery.Append("       , TL_CODE ");
                    sbQuery.Append("       , MNT_POS ");
                    sbQuery.Append("       , USED_LIFE ");
                    sbQuery.Append("       , REG_DATE ");
                    sbQuery.Append("       , REG_EMP ");
                    sbQuery.Append("       , MDFY_DATE ");
                    sbQuery.Append("       , MDFY_EMP ");
                    sbQuery.Append("       , DEL_DATE ");
                    sbQuery.Append("       , DEL_EMP ");
                    sbQuery.Append("       , DATA_FLAG ");
                    sbQuery.Append("  FROM TTOL_MOUNT ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND MOUNT_ID = @MOUNT_ID");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PROPS_ID")) isHasColumn = false;

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



        public static void TTOL_MOUNT_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();


                    sbQuery.Append("INSERT INTO TTOL_MOUNT ");
                    sbQuery.Append("( ");
                    sbQuery.Append("         PLT_CODE ");
                    sbQuery.Append("       , MOUNT_ID ");
                    sbQuery.Append("       , MC_CODE ");
                    sbQuery.Append("       , TL_CODE ");
                    sbQuery.Append("       , MNT_POS ");
                    sbQuery.Append("       , USED_LIFE ");
                    sbQuery.Append("       , REG_DATE ");
                    sbQuery.Append("       , REG_EMP ");
                    sbQuery.Append("       , DATA_FLAG ");
                    sbQuery.Append(") ");
                    sbQuery.Append("VALUES ");
                    sbQuery.Append("( ");
                    sbQuery.Append("         @PLT_CODE ");
                    sbQuery.Append("       , @MOUNT_ID ");
                    sbQuery.Append("       , @MC_CODE ");
                    sbQuery.Append("       , @TL_CODE ");
                    sbQuery.Append("       , @MNT_POS ");
                    sbQuery.Append("       , @USED_LIFE ");
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



        public static void TTOL_MOUNT_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("UPDATE TTOL_MOUNT         ");
                    sbQuery.Append("   SET   MNT_POS = @MNT_POS ");
                    sbQuery.Append("       , USED_LIFE = @USED_LIFE ");
                    sbQuery.Append("       , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("       , MDFY_EMP = @MDFY_EMP ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND MOUNT_ID = @MOUNT_ID ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크                        
                        if (!UTIL.ValidColumn(row, "MOUNT_ID")) isHasColumn = false;

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


        public static void TTOL_MOUNT_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("UPDATE TTOL_MOUNT    ");
                    sbQuery.Append("  SET   DEL_DATE = GETDATE() ");
                    sbQuery.Append("      , DEL_EMP = @DEL_EMP ");
                    sbQuery.Append("      , DATA_FLAG = 2 ");
                    sbQuery.Append("WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND MOUNT_ID = @MOUNT_ID ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크                        
                        if (!UTIL.ValidColumn(row, "MOUNT_ID")) isHasColumn = false;

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

    public class TTOL_MOUNT_QUERY
    {
        public static DataTable TTOL_MOUNT_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT TM.PLT_CODE");
                    sbQuery.Append(" ,TM.MOUNT_ID");
                    sbQuery.Append(" ,TM.MC_CODE");
                    sbQuery.Append(" ,TM.TL_CODE");
                    sbQuery.Append(" ,TL.TL_NAME");
                    sbQuery.Append(" ,TL.STD_LIFE");
                    sbQuery.Append(" ,TM.MNT_POS");
                    sbQuery.Append(" ,TM.REG_DATE");
                    sbQuery.Append(" ,TM.REG_EMP");
                    sbQuery.Append(" ,TM.MDFY_DATE");
                    sbQuery.Append(" ,TM.MDFY_EMP");
                    sbQuery.Append(" ,ISNULL(ACT.ACT_TOOL_TIME,0) AS ACT_TOOL_TIME");
                    sbQuery.Append(" FROM TTOL_MOUNT TM");
                    sbQuery.Append(" LEFT JOIN TSTD_TOOL TL");
                    sbQuery.Append(" ON TM.PLT_CODE = TL.PLT_CODE");
                    sbQuery.Append(" AND TM.TL_CODE = TL.TL_CODE");
                    sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE,MC_CODE,TOOL_NO,SUM(DATEDIFF(MI,MC_START_TIME,MC_END_TIME)) AS ACT_TOOL_TIME");
                    sbQuery.Append(" FROM TPOP_MC_ACTUAL WHERE TOOL_DEL_DATE IS NULL GROUP BY PLT_CODE,MC_CODE,TOOL_NO) ACT");
                    sbQuery.Append(" ON TM.PLT_CODE = ACT.PLT_CODE");
                    sbQuery.Append(" AND TM.MC_CODE = ACT.MC_CODE");
                    sbQuery.Append(" AND TM.MNT_POS = ACT.TOOL_NO ");



                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE TM.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@MOUNT_ID", " TM.MOUNT_ID = @MOUNT_ID"));

                        sbWhere.Append(UTIL.GetWhere(row, "@MC_CODE", " TM.MC_CODE = @MC_CODE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", " TM.DATA_FLAG = @DATA_FLAG"));

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
