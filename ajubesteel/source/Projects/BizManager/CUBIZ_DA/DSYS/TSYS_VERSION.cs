using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSYS
{
    public class TSYS_VERSION
    {
        public static DataTable TSYS_VERSION_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT APP_ID ");
                    sbQuery.Append(" , VERSION ");
                    sbQuery.Append(" , TYPE ");
                    sbQuery.Append(" FROM TSYS_VERSION ");
                    sbQuery.Append(" WHERE APP_ID  = @APP_ID");                    

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "APP_ID")) isHasColumn = false;

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

        public static DataTable TSYS_VERSION_SER2(BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();


                StringBuilder sbQuery = new StringBuilder();
                sbQuery.Append(" SELECT APP_ID ");
                sbQuery.Append(" , VERSION ");
                sbQuery.Append(" , TYPE ");
                sbQuery.Append(" FROM TSYS_VERSION ");
                sbQuery.Append(" WHERE APP_ID  = 'Active#'");

                DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString()).Copy();

                sourceTable.TableName = "RSLTDT";
                dsResult.Merge(sourceTable);


                return UTIL.GetDsToDt(dsResult);

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
    }


    public class TSYS_VERSION_QUERY
    {
        

    }
}
