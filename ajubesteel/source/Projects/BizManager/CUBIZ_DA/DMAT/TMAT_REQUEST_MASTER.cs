using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DMAT
{
    public class TMAT_REQUEST_MASTER
    {
        public static void TMAT_REQUEST_MASTER_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TMAT_REQUEST_MASTER");
                    sbQuery.Append(" (PLT_CODE						");
                    sbQuery.Append(" ,REQUEST_NO					");
                    sbQuery.Append(" ,REQ_DATE						");
                    sbQuery.Append(" ,DUE_DATE						");
                    sbQuery.Append(" ,REQ_STAT						");
                    sbQuery.Append(" ,SCOMMENT						");
                    sbQuery.Append(" ,CONFIRM_DATE					");
                    sbQuery.Append(" ,CONFIRM_EMP					");
                    sbQuery.Append(" ,REG_DATE						");
                    sbQuery.Append(" ,REG_EMP)						");
                    sbQuery.Append(" VALUES							");
                    sbQuery.Append(" ( @PLT_CODE					");
                    sbQuery.Append(" ,@REQUEST_NO					");
                    sbQuery.Append(" ,@REQ_DATE						");
                    sbQuery.Append(" ,@DUE_DATE						");
                    sbQuery.Append(" ,@REQ_STAT						");
                    sbQuery.Append(" ,@SCOMMENT						");
                    sbQuery.Append(" ,@CONFIRM_DATE					");
                    sbQuery.Append(" ,@CONFIRM_EMP					");
                    sbQuery.Append(" ,GETDATE()						");
                    sbQuery.Append(" ," + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(")");
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


        public static void TMAT_REQUEST_MASTER_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_REQUEST_MASTER");
                    sbQuery.Append(" SET REQ_STAT = @REQ_STAT");
                    sbQuery.Append(" ,CONFIRM_DATE = @CONFIRM_DATE");
                    sbQuery.Append(" ,CONFIRM_EMP = @CONFIRM_EMP");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND REQUEST_NO = @REQUEST_NO");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "REQUEST_NO")) isHasColumn = false;

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


        public static void TMAT_REQUEST_MASTER_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_REQUEST_MASTER");
                    sbQuery.Append(" SET REQ_STAT = @REQ_STAT");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND REQUEST_NO = @REQUEST_NO");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "REQUEST_NO")) isHasColumn = false;

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

        public static void TMAT_REQUEST_MASTER_UPD3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_REQUEST_MASTER");
                    sbQuery.Append(" SET REQ_STAT = @REQ_STAT");
                    sbQuery.Append(" ,CONFIRM_DATE = @CONFIRM_DATE");
                    sbQuery.Append(" ,CONFIRM_EMP = @CONFIRM_EMP");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND REQUEST_NO = @REQUEST_NO");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "REQUEST_NO")) isHasColumn = false;

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

    public class TMAT_REQUEST_MASTER_QUERY
    {
        public static DataTable TMAT_REQUEST_MASTER_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT RM.PLT_CODE				 ");
                    sbQuery.Append(" ,'M' AS REQ_TYPE				 ");
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
                    sbQuery.Append(" FROM TMAT_REQUEST_MASTER RM	 ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E		 ");
                    sbQuery.Append(" ON RM.PLT_CODE = E.PLT_CODE 	 ");
                    sbQuery.Append(" AND RM.REG_EMP = E.EMP_CODE	 ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE CE		 ");
                    sbQuery.Append(" ON RM.PLT_CODE = CE.PLT_CODE 	 ");
                    sbQuery.Append(" AND RM.CONFIRM_EMP = CE.EMP_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE RM.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@S_REQ_DATE,@E_REQ_DATE", " (RM.REQ_DATE BETWEEN @S_REQ_DATE AND @E_REQ_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE,@E_DUE_DATE", " (RM.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_CONFIRM_DATE,@E_CONFIRM_DATE", " (RM.CONFIRM_DATE BETWEEN @S_CONFIRM_DATE AND @E_CONFIRM_DATE)	"));
                        sbWhere.Append(UTIL.GetWhere(row, "@REQUEST_NO", " RM.REQUEST_NO = @REQUEST_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@CONFIRM_EMP", " RM.CONFIRM_EMP = @CONFIRM_EMP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@REQ_STAT", " RM.REQ_STAT = @REQ_STAT AND (SELECT COUNT(*) FROM TMAT_REQUEST WHERE PLT_CODE = RM.PLT_CODE AND REQUEST_NO = RM.REQUEST_NO AND REQ_STAT = @REQ_STAT) > 0 "));

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
