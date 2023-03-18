using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DORD
{
    public class TORD_PRODUCT_SPEC
    {
        public static DataTable TORD_PRODUCT_SPEC_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT				   ");
                    sbQuery.Append(" PLT_CODE			   ");
                    sbQuery.Append(" ,PROD_CODE			   ");
                    sbQuery.Append(" ,TG_NAME			   ");
                    sbQuery.Append(" ,MODEL				   ");
                    sbQuery.Append(" ,MOTOR				   ");
                    sbQuery.Append(" ,RPM				   ");
                    sbQuery.Append(" ,POLE				   ");
                    sbQuery.Append(" ,M_POWER			   ");
                    sbQuery.Append(" ,C_POWER			   ");
                    sbQuery.Append(" ,REV_CNT			   ");
                    sbQuery.Append(" ,MOV_TIME			   ");
                    sbQuery.Append(" ,TORQUE			   ");
                    sbQuery.Append(" ,T_TYPE			   ");
                    sbQuery.Append(" ,SERIES_TYPE		   ");
                    sbQuery.Append(" ,STEMBUSH_A		   ");
                    sbQuery.Append(" ,STEMBUSH_B		   ");
                    sbQuery.Append(" ,STEMCOVER			   ");
                    sbQuery.Append(" ,ETC_OPTION		   ");
                    sbQuery.Append(" ,RED_DETAIL		   ");
                    sbQuery.Append(" ,RED_AUTO			   ");
                    sbQuery.Append(" ,RED_QTY			   ");
                    sbQuery.Append(" ,RED_KEY			   ");
                    sbQuery.Append(" ,RED_OPTION		   ");
                    sbQuery.Append(" ,ENC_CASE_A		   ");
                    sbQuery.Append(" ,ENC_CASE_B		   ");
                    sbQuery.Append(" ,PAINTING			   ");
                    sbQuery.Append(" ,DIRECTION			   ");
                    sbQuery.Append(" ,DELIVERY_LOC		   ");
                    sbQuery.Append(" ,SCOMMENT			   ");
                    sbQuery.Append(" ,REDUCER			   ");
                    sbQuery.Append(" ,DUEDATE			   ");
                    sbQuery.Append(" FROM TORD_PRODUCT_SPEC");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND PROD_CODE = @PROD_CODE ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
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
    }
}
