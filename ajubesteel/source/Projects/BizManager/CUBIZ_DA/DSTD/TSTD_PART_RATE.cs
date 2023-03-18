using BizExecute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSTD
{
    public class TSTD_PART_RATE
    {
        public static DataTable TSTD_PART_RATE_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,DES_RATE ");
                    sbQuery.Append(" ,MILL_RATE ");
                    sbQuery.Append(" ,CAM_RATE ");
                    sbQuery.Append(" ,MCT_RATE ");
                    sbQuery.Append(" ,SIDE_RATE ");
                    sbQuery.Append(" ,INS_RATE ");
                    sbQuery.Append(" ,ASSY_RATE ");
                    sbQuery.Append(" ,SHIP_RATE ");
                    sbQuery.Append("  FROM TSTD_PART_RATE  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");

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


        public static void TSTD_PART_RATE_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TSTD_PART_RATE (  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,DES_RATE ");
                    sbQuery.Append(" ,MILL_RATE ");
                    sbQuery.Append(" ,CAM_RATE ");
                    sbQuery.Append(" ,MCT_RATE ");
                    sbQuery.Append(" ,SIDE_RATE ");
                    sbQuery.Append(" ,INS_RATE ");
                    sbQuery.Append(" ,ASSY_RATE ");
                    sbQuery.Append(" ,SHIP_RATE ");
                    sbQuery.Append("  ) VALUES (  ");
                    sbQuery.Append("  @PLT_CODE ");
                    sbQuery.Append(" ,@DES_RATE ");
                    sbQuery.Append(" ,@MILL_RATE ");
                    sbQuery.Append(" ,@CAM_RATE ");
                    sbQuery.Append(" ,@MCT_RATE ");
                    sbQuery.Append(" ,@SIDE_RATE ");
                    sbQuery.Append(" ,@INS_RATE ");
                    sbQuery.Append(" ,@ASSY_RATE ");
                    sbQuery.Append(" ,@SHIP_RATE ");
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

        public static void TSTD_PART_RATE_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TSTD_PART_RATE SET  ");
                    sbQuery.Append("  DES_RATE = @DES_RATE ");
                    sbQuery.Append(" ,MILL_RATE = @MILL_RATE ");
                    sbQuery.Append(" ,CAM_RATE = @CAM_RATE ");
                    sbQuery.Append(" ,MCT_RATE = @MCT_RATE ");
                    sbQuery.Append(" ,SIDE_RATE = @SIDE_RATE ");
                    sbQuery.Append(" ,INS_RATE = @INS_RATE ");
                    sbQuery.Append(" ,ASSY_RATE = @ASSY_RATE ");
                    sbQuery.Append(" ,SHIP_RATE = @SHIP_RATE ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;

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
