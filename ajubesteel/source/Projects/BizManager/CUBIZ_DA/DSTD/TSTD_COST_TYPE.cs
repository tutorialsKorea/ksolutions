using BizExecute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSTD
{
    public class TSTD_COST_TYPE
    {
        public static DataTable TSTD_COST_TYPE_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,COST_TYPE ");
                    sbQuery.Append(" ,COST_FLAG ");
                    sbQuery.Append(" ,DES_COST ");
                    sbQuery.Append(" ,MILL_COST ");
                    sbQuery.Append(" ,CAM_COST ");
                    sbQuery.Append(" ,MCT_COST ");
                    sbQuery.Append(" ,SIDE_COST ");
                    sbQuery.Append(" ,ASSY_COST ");
                    sbQuery.Append(" ,SHIP_COST ");
                    sbQuery.Append(" ,INS_COST ");
                    sbQuery.Append("  FROM TSTD_COST_TYPE  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND COST_TYPE = @COST_TYPE  ");
                    sbQuery.Append("  AND COST_FLAG = @COST_FLAG  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "COST_TYPE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "COST_FLAG")) isHasColumn = false;

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

        public static DataTable TSTD_COST_TYPE_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,COST_TYPE ");
                    sbQuery.Append(" ,COST_FLAG ");
                    sbQuery.Append(" ,DES_COST ");
                    sbQuery.Append(" ,MILL_COST ");
                    sbQuery.Append(" ,CAM_COST ");
                    sbQuery.Append(" ,MCT_COST ");
                    sbQuery.Append(" ,SIDE_COST ");
                    sbQuery.Append(" ,ASSY_COST ");
                    sbQuery.Append(" ,SHIP_COST ");
                    sbQuery.Append(" ,INS_COST ");
                    sbQuery.Append("  FROM TSTD_COST_TYPE  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  ORDER BY COST_FLAG  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;

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

        public static void TSTD_COST_TYPE_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TSTD_COST_TYPE (  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,COST_TYPE ");
                    sbQuery.Append(" ,COST_FLAG ");
                    sbQuery.Append(" ,DES_COST ");
                    sbQuery.Append(" ,MILL_COST ");
                    sbQuery.Append(" ,CAM_COST ");
                    sbQuery.Append(" ,MCT_COST ");
                    sbQuery.Append(" ,SIDE_COST ");
                    sbQuery.Append(" ,ASSY_COST ");
                    sbQuery.Append(" ,SHIP_COST ");
                    sbQuery.Append(" ,INS_COST ");
                    sbQuery.Append("  ) VALUES (  ");
                    sbQuery.Append("  @PLT_CODE ");
                    sbQuery.Append(" ,@COST_TYPE ");
                    sbQuery.Append(" ,@COST_FLAG ");
                    sbQuery.Append(" ,@DES_COST ");
                    sbQuery.Append(" ,@MILL_COST ");
                    sbQuery.Append(" ,@CAM_COST ");
                    sbQuery.Append(" ,@MCT_COST ");
                    sbQuery.Append(" ,@SIDE_COST ");
                    sbQuery.Append(" ,@ASSY_COST ");
                    sbQuery.Append(" ,@SHIP_COST ");
                    sbQuery.Append(" ,@INS_COST ");
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


        public static void TSTD_COST_TYPE_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSTD_COST_TYPE SET  ");
                    sbQuery.Append("  DES_COST = @DES_COST ");
                    sbQuery.Append(" ,MILL_COST = @MILL_COST ");
                    sbQuery.Append(" ,CAM_COST = @CAM_COST ");
                    sbQuery.Append(" ,MCT_COST = @MCT_COST ");
                    sbQuery.Append(" ,SIDE_COST = @SIDE_COST ");
                    sbQuery.Append(" ,ASSY_COST = @ASSY_COST ");
                    sbQuery.Append(" ,SHIP_COST = @SHIP_COST ");
                    sbQuery.Append(" ,INS_COST = @INS_COST ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND COST_TYPE = @COST_TYPE ");
                    sbQuery.Append("  AND COST_FLAG = @COST_FLAG ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "COST_TYPE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "COST_FLAG")) isHasColumn = false;

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
}
