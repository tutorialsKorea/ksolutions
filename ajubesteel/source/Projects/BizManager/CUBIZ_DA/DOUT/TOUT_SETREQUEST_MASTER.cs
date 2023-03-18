using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DOUT
{
    public class TOUT_SETREQUEST_MASTER
    {
    }

    public class TOUT_SETREQUEST_MASTER_QUERY
    {
        public static DataTable TOUT_SETREQUEST_MASTER_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT RM.PLT_CODE				 ");
                    sbQuery.Append(" ,'SO' AS REQ_TYPE 				 ");
                    sbQuery.Append(" ,RM.REQUEST_NO					 ");
                    sbQuery.Append(" ,RM.REQ_DATE					 ");
                    sbQuery.Append(" ,RM.DUE_DATE					 ");
                    sbQuery.Append(" ,RM.CONFIRM_DATE				 ");
                    sbQuery.Append(" ,RM.REQ_STAT					 ");
                    sbQuery.Append(" ,RM.REG_EMP					 ");
                    sbQuery.Append(" ,E.EMP_NAME AS REG_EMP_NAME	 ");
                    sbQuery.Append(" ,RM.CONFIRM_EMP				 ");
                    sbQuery.Append(" ,CE.EMP_NAME AS CONFIRM_EMP_NAME");
                    sbQuery.Append(" ,RM.SCOMMENT					 ");
                    sbQuery.Append(" FROM TOUT_SETREQUEST_MASTER RM	 ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E		 ");
                    sbQuery.Append(" ON RM.PLT_CODE = E.PLT_CODE 	 ");
                    sbQuery.Append(" AND RM.REG_EMP = E.EMP_CODE	 ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE CE		 ");
                    sbQuery.Append(" ON RM.PLT_CODE = CE.PLT_CODE 	 ");
                    sbQuery.Append(" AND RM.REG_EMP = CE.EMP_CODE	 ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE RM.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@S_REQ_DATE,@E_REQ_DATE", " (RM.REQ_DATE BETWEEN @S_REQ_DATE AND @E_REQ_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE,@E_DUE_DATE", " (RM.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_CONFIRM_DATE,@E_CONFIRM_DATE", " (RM.CONFIRM_DATE BETWEEN @S_CONFIRM_DATE AND @E_CONFIRM_DATE)	"));
                        sbWhere.Append(UTIL.GetWhere(row, "@REQUEST_NO", " RM.REQUEST_NO = @REQUEST_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CONFIRM_EMP", " RM.CONFIRM_EMP = @CONFIRM_EMP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@REQ_STAT", " RM.REQ_STAT = @REQ_STAT AND (SELECT COUNT(*) FROM TOUT_SETREQUEST WHERE PLT_CODE = RM.PLT_CODE AND REQUEST_NO = RM.REQUEST_NO AND REQ_STAT = @REQ_STAT) > 0 "));

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
