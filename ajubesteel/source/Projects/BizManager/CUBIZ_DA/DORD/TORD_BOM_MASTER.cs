using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DORD
{
    public class TORD_BOM_MASTER
    {
        public static DataTable TORD_BOM_MASTER_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,BM_CODE ");
                    sbQuery.Append(" ,PROD_CODE ");
                    sbQuery.Append(" ,PART_CODE ");
                    sbQuery.Append(" ,REV_NO ");
                    sbQuery.Append(" ,BM_STATE ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,REV_DATE ");
                    sbQuery.Append(" ,LOCK_EMP ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,MDFY_DATE ");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append(" ,DEL_DATE ");
                    sbQuery.Append(" ,DEL_EMP ");
                    sbQuery.Append("  FROM TORD_BOM_MASTER  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND BM_CODE = @BM_CODE  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "BM_CODE")) isHasColumn = false;

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


        public static void TORD_BOM_MASTER_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TORD_BOM_MASTER SET  ");
                    //sbQuery.Append("  PROD_CODE = @PROD_CODE ");
                    //sbQuery.Append(" ,PART_CODE = @PART_CODE ");
                    //sbQuery.Append(" ,REV_NO = @REV_NO ");
                    sbQuery.Append(" BM_STATE = @BM_STATE ");
                    //sbQuery.Append(" ,SCOMMENT = @SCOMMENT ");
                    //sbQuery.Append(" ,REV_DATE = @REV_DATE ");
                    //sbQuery.Append(" ,LOCK_EMP = @LOCK_EMP ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = '" + ConnInfo.UserID + "' ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND BM_CODE = @BM_CODE ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "BM_CODE")) isHasColumn = false;

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



        public static void TORD_BOM_MASTER_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TORD_BOM_MASTER (  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,BM_CODE ");
                    sbQuery.Append(" ,PROD_CODE ");
                    sbQuery.Append(" ,PART_CODE ");
                    sbQuery.Append(" ,REV_NO ");
                    sbQuery.Append(" ,BM_STATE ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,REV_DATE ");
                    sbQuery.Append(" ,LOCK_EMP ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append("  ) VALUES (  ");
                    sbQuery.Append("  @PLT_CODE ");
                    sbQuery.Append(" ,@BM_CODE ");
                    sbQuery.Append(" ,@PROD_CODE ");
                    sbQuery.Append(" ,@PART_CODE ");
                    sbQuery.Append(" ,@REV_NO ");
                    sbQuery.Append(" ,@BM_STATE ");
                    sbQuery.Append(" ,@SCOMMENT ");
                    sbQuery.Append(" ,@REV_DATE ");
                    sbQuery.Append(" ,@LOCK_EMP ");
                    sbQuery.Append(" ,GETDATE() ");
                    sbQuery.Append(" ,'" + ConnInfo.UserID + "' ");
                    sbQuery.Append(" ,@DATA_FLAG ");
                    sbQuery.Append("  ) ");

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

    public class TORD_BOM_MASTER_QUERY
    {
        /// <summary>
        /// bom rev 조회 
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TORD_BOM_MASTER_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  BM.PLT_CODE ");
                    sbQuery.Append(" ,BM.BM_CODE ");
                    sbQuery.Append(" ,BM.PROD_CODE ");
                    sbQuery.Append(" ,BM.PART_CODE ");
                    sbQuery.Append(" ,PT.PART_NAME ");
                    sbQuery.Append(" ,PT.MAT_TYPE ");
                    sbQuery.Append(" ,PT.MAT_TYPE1 ");
                    sbQuery.Append(" ,PT.MAT_TYPE2 ");
                    sbQuery.Append(" ,PT.MAT_LTYPE ");
                    sbQuery.Append(" ,PT.PART_PRODTYPE ");
                    sbQuery.Append(" ,PT.MAT_UNIT ");
                    sbQuery.Append(" ,PT.MAT_SPEC ");
                    sbQuery.Append(" ,BM.REV_NO ");
                    sbQuery.Append(" ,BM.BM_STATE ");
                    sbQuery.Append(" ,BM.SCOMMENT ");
                    sbQuery.Append(" ,BM.REV_DATE ");
                    sbQuery.Append(" ,BM.LOCK_EMP ");
                    sbQuery.Append(" ,BM.REG_DATE ");
                    sbQuery.Append(" ,BM.REG_EMP ");
                    sbQuery.Append(" ,BM.MDFY_DATE ");
                    sbQuery.Append(" ,BM.MDFY_EMP ");
                    sbQuery.Append(" ,BM.DATA_FLAG ");
                    sbQuery.Append(" ,BM.DEL_DATE ");
                    sbQuery.Append(" ,BM.DEL_EMP ");
                    sbQuery.Append("  FROM TORD_BOM_MASTER BM ");
                    sbQuery.Append("  LEFT JOIN LSE_STD_PART PT ");
                    sbQuery.Append("  ON BM.PLT_CODE = PT.PLT_CODE ");
                    sbQuery.Append("  AND BM.PART_CODE = PT.PART_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
  
                        StringBuilder sbWhere = new StringBuilder(" WHERE BM.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", " BM.PART_CODE = @PART_CODE "));   //특허상태

                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", " BM.DATA_FLAG = @DATA_FLAG "));

                        sbWhere.Append(" ORDER BY REV_NO DESC ");

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
