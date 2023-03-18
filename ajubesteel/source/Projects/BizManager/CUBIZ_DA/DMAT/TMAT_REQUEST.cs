using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DMAT
{
    public class TMAT_REQUEST
    {
        public static DataTable TMAT_REQUEST_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE			 ");
                    sbQuery.Append(" ,REQUEST_NO				 ");
                    sbQuery.Append(" ,REQUEST_SEQ				 ");
                    sbQuery.Append(" ,PROD_CODE					 ");
                    sbQuery.Append(" ,PART_CODE					 ");
                    sbQuery.Append(" ,QTY						 ");
                    sbQuery.Append(" ,REQ_STAT					 ");
                    sbQuery.Append(" ,C_REASON					 ");
                    sbQuery.Append(" ,REG_DATE					 ");
                    sbQuery.Append(" ,REG_EMP					 ");
                    sbQuery.Append(" ,MDFY_DATE					 ");
                    sbQuery.Append(" ,MDFY_EMP					 ");
                    sbQuery.Append(" FROM TMAT_REQUEST			 ");
                    sbQuery.Append(" WHERE PROD_CODE = @PROD_CODE");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE	 ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;

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

        public static void TMAT_REQUEST_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TMAT_REQUEST");
                    sbQuery.Append(" (						 ");
                    sbQuery.Append(" PLT_CODE				 ");
                    sbQuery.Append(" ,REQUEST_NO			 ");
                    sbQuery.Append(" ,REQUEST_SEQ			 ");
                    sbQuery.Append(" ,PROD_CODE				 ");
                    sbQuery.Append(" ,PART_CODE				 ");
                    sbQuery.Append(" ,WO_NO				 ");
                    sbQuery.Append(" ,QTY					 ");
                    sbQuery.Append(" ,REQ_STAT				 ");
                    sbQuery.Append(" ,REG_DATE				 ");
                    sbQuery.Append(" ,REG_EMP				 ");
                    sbQuery.Append(" )      				 ");
                    sbQuery.Append(" VALUES					 ");
                    sbQuery.Append(" (@PLT_CODE				 ");
                    sbQuery.Append(" ,@REQUEST_NO			 ");
                    sbQuery.Append(" ,@REQUEST_SEQ			 ");
                    sbQuery.Append(" ,@PROD_CODE			 ");
                    sbQuery.Append(" ,@PART_CODE			 ");
                    sbQuery.Append(" ,@WO_NO			 ");
                    sbQuery.Append(" ,@QTY					 ");
                    sbQuery.Append(" ,@REQ_STAT				 ");
                    sbQuery.Append(" ,GETDATE()			     ");
                    sbQuery.Append(" ," + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" )						 ");

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

        public static void TMAT_REQUEST_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_REQUEST            ");
                    sbQuery.Append(" SET   QTY = @QTY               ");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()       ");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE     ");
                    sbQuery.Append(" AND REQUEST_NO = @REQUEST_NO   ");
                    sbQuery.Append(" AND REQUEST_SEQ = @REQUEST_SEQ ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "REQUEST_NO")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "REQUEST_SEQ")) isHasColumn = false;

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


        public static void TMAT_REQUEST_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_REQUEST		   ");
                    sbQuery.Append(" SET REQ_STAT = @REQ_STAT	   ");
                    sbQuery.Append("   , PUR_SCOMMENT = @PUR_SCOMMENT	   ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE	   ");
                    sbQuery.Append(" AND REQUEST_NO = @REQUEST_NO  ");
                    sbQuery.Append(" AND REQUEST_SEQ = @REQUEST_SEQ");


                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "REQUEST_NO")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "REQUEST_SEQ")) isHasColumn = false;

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

        public static void TMAT_REQUEST_UPD3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_REQUEST           ");
                    sbQuery.Append(" SET   REQ_STAT = @REQ_STAT    ");
                    sbQuery.Append(" , C_REASON = @C_REASON        ");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()      ");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE    ");
                    sbQuery.Append(" AND REQUEST_NO = @REQUEST_NO  ");
                    sbQuery.Append(" AND REQUEST_SEQ = @REQUEST_SEQ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "REQUEST_NO")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "REQUEST_SEQ")) isHasColumn = false;

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


        public static void TMAT_REQUEST_UPD4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_REQUEST		   ");
                    sbQuery.Append(" SET REQ_STAT = @REQ_STAT	   ");
                    sbQuery.Append(" , QTY = @QTY	   ");
                    sbQuery.Append(" , PUR_SCOMMENT = @PUR_SCOMMENT	   ");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()	   ");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE	   ");
                    sbQuery.Append(" AND REQUEST_NO = @REQUEST_NO  ");
                    sbQuery.Append(" AND REQUEST_SEQ = @REQUEST_SEQ");


                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "REQUEST_NO")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "REQUEST_SEQ")) isHasColumn = false;

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

        public static void TMAT_REQUEST_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" DELETE FROM TMAT_REQUEST           ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE    ");
                    sbQuery.Append(" AND WO_NO = @WO_NO  ");
                   

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "WO_NO")) isHasColumn = false;

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


    public class TMAT_REQUEST_QUERY
    {
        public static DataTable TMAT_REQUEST_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE  ");
                    sbQuery.Append(" ,REQUEST_NO	  ");
                    sbQuery.Append(" ,REQUEST_SEQ	  ");
                    sbQuery.Append(" ,PROD_CODE		  ");
                    sbQuery.Append(" ,PART_CODE		  ");
                    sbQuery.Append(" ,QTY			  ");
                    sbQuery.Append(" ,REQ_STAT		  ");
                    sbQuery.Append(" ,C_REASON		  ");
                    sbQuery.Append(" ,REG_DATE		  ");
                    sbQuery.Append(" ,REG_EMP		  ");
                    sbQuery.Append(" ,MDFY_DATE		  ");
                    sbQuery.Append(" ,MDFY_EMP		  ");
                    sbQuery.Append(" FROM TMAT_REQUEST");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@REQUEST_NO", " REQUEST_NO = @REQUEST_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@REQUEST_SEQ", " REQUEST_SEQ = @REQUEST_SEQ"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", " PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", " PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@REQ_STAT", " REQ_STAT = @REQ_STAT"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WO_NO", " WO_NO = @WO_NO"));

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

        public static DataTable TMAT_REQUEST_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT R.PLT_CODE					");
                    sbQuery.Append(" ,RM.REQ_DATE 						");
                    sbQuery.Append(" ,RM.DUE_DATE						");
                    sbQuery.Append(" ,R.REQUEST_NO						");
                    sbQuery.Append(" ,R.REQUEST_SEQ						");
                    sbQuery.Append(" ,I.ITEM_CODE						");
                    sbQuery.Append(" ,I.ITEM_NAME						");
                    sbQuery.Append(" ,PL.PROD_CODE						");
                    sbQuery.Append(" ,P.PROD_NAME						");
                    sbQuery.Append(" ,P.PRJ_CODE						");
                    sbQuery.Append(" ,PJ.PRJ_NAME						");
                    sbQuery.Append(" ,PPT.PART_CODE AS P_PART_CODE		");
                    sbQuery.Append(" ,PPT.PT_NAME AS P_PART_NAME		");
                    sbQuery.Append(" ,PPT.PART_NUM AS P_PART_NUM		");
                    sbQuery.Append(" ,PL.PART_CODE						");
                    sbQuery.Append(" ,PL.PT_NAME AS PART_NAME			");
                    sbQuery.Append(" ,PL.PART_NUM						");
                    sbQuery.Append(" ,PL.PART_PRODTYPE					");
                    sbQuery.Append(" ,PL.PART_QLTY 						");
                    sbQuery.Append(" ,Q.MQLTY_NAME AS PART_QLTY_NAME	");
                    sbQuery.Append(" ,PL.PART_SPEC						");
                    sbQuery.Append(" ,PL.PART_SPEC1						");
                    sbQuery.Append(" ,R.QTY								");
                    sbQuery.Append(" ,PL.WEIGHT_VOLUME					");
                    sbQuery.Append(" ,PL.WEIGHT_VOLUME1					");
                    sbQuery.Append(" ,SP.MAT_UNIT						");
                    sbQuery.Append(" ,RM.REG_EMP						");
                    sbQuery.Append(" ,E.EMP_NAME AS REG_EMP_NAME		");
                    sbQuery.Append(" ,O.ORG_NAME						");
                    sbQuery.Append(" ,RM.SCOMMENT						");
                    sbQuery.Append(" ,PL.UNIT_COST						");
                    sbQuery.Append(" FROM TMAT_REQUEST R				");
                    sbQuery.Append(" JOIN TMAT_REQUEST_MASTER RM 		");
                    sbQuery.Append(" ON R.PLT_CODE = RM.PLT_CODE		");
                    sbQuery.Append(" AND R.REQUEST_NO = RM.REQUEST_NO	");
                    sbQuery.Append(" LEFT JOIN TMAT_PUR_PARTLIST PL		");
                    sbQuery.Append(" ON R.PLT_CODE = PL.PLT_CODE		");
                    sbQuery.Append(" AND R.REQUEST_NO = PL.REQUEST_NO	");
                    sbQuery.Append(" AND R.REQUEST_SEQ = PL.REQUEST_SEQ	");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P			");
                    sbQuery.Append(" ON PL.PLT_CODE = P.PLT_CODE		");
                    sbQuery.Append(" AND PL.PROD_CODE = P.PROD_CODE		");
                    sbQuery.Append(" LEFT JOIN TORD_ITEM I				");
                    sbQuery.Append(" ON P.PLT_CODE = I.PLT_CODE			");
                    sbQuery.Append(" AND P.ITEM_CODE = I.ITEM_CODE		");
                    sbQuery.Append(" LEFT JOIN TORD_PROJECT PJ			");
                    sbQuery.Append(" ON P.PLT_CODE = PJ.PLT_CODE		");
                    sbQuery.Append(" AND P.PRJ_CODE = PJ.PRJ_CODE 		");
                    sbQuery.Append(" LEFT JOIN TMAT_PARTLIST PPT		");
                    sbQuery.Append(" ON PL.PLT_CODE = PPT.PLT_CODE		");
                    sbQuery.Append(" AND PL.O_PT_ID = PPT.PT_ID			");
                    sbQuery.Append(" LEFT JOIN TMAT_QUC_MASTER Q		");
                    sbQuery.Append(" ON PL.PLT_CODE = Q.PLT_CODE 		");
                    sbQuery.Append(" AND PL.PART_QLTY = Q.MQLTY_CODE	");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP			");
                    sbQuery.Append(" ON PL.PLT_CODE = SP.PLT_CODE		");
                    sbQuery.Append(" AND PL.PART_CODE = SP.PART_CODE	");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E			");
                    sbQuery.Append(" ON R.PLT_CODE = E.PLT_CODE			");
                    sbQuery.Append(" AND RM.REG_EMP = E.EMP_CODE		");
                    sbQuery.Append(" LEFT JOIN TSTD_ORG O				");
                    sbQuery.Append(" ON E.PLT_CODE = O.PLT_CODE			");
                    sbQuery.Append(" AND E.ORG_CODE = O.ORG_CODE		");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE R.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", " PL.PROD_CODE = @PROD_CODE                        "));
                        sbWhere.Append(UTIL.GetWhere(row, "@REG_EMP", " R.REG_EMP = @REG_EMP                             "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_REQ_DATE,@E_REQ_DATE", " (RM.REQ_DATE BETWEEN @S_REQ_DATE AND @E_REQ_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE,@E_DUE_DATE", " (RM.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@REQ_STAT", " R.REQ_STAT = @REQ_STAT                           "));
                        sbWhere.Append(UTIL.GetWhere(row, "@REQUEST_NO", " R.REQUEST_NO = @REQUEST_NO                       "));
                        sbWhere.Append(UTIL.GetWhere(row, "@REQUEST_SEQ", " R.REQUEST_SEQ = @REQUEST_SEQ                     "));
                        sbWhere.Append(" AND R.PART_CODE IS NULL                              ");

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

        public static DataTable TMAT_REQUEST_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT R.PLT_CODE				 ");
                    sbQuery.Append(" ,RM.REQ_DATE 					 ");
                    sbQuery.Append(" ,RM.DUE_DATE					 ");
                    sbQuery.Append(" ,R.REQUEST_NO					 ");
                    sbQuery.Append(" ,R.REQUEST_SEQ					 ");
                    sbQuery.Append(" ,R.PART_CODE					 ");
                    sbQuery.Append(" ,PT.PART_NAME					 ");
                    sbQuery.Append(" ,PT.MAT_UNIT					 ");
                    sbQuery.Append(" ,PT.MAT_SPEC           		 ");
                    sbQuery.Append(" ,PT.MAT_SPEC1 AS PART_SPEC1	 ");
                    sbQuery.Append(" ,PT.MAT_QLTY AS PART_QLTY		 ");
                    sbQuery.Append(" ,Q.MQLTY_NAME AS PART_QLTY_NAME ");
                    sbQuery.Append(" ,R.QTY							 ");
                    sbQuery.Append(" ,RM.REG_EMP					 ");
                    sbQuery.Append(" ,E.EMP_NAME AS REG_EMP_NAME	 ");
                    sbQuery.Append(" ,O.ORG_NAME					 ");
                    sbQuery.Append(" ,RM.SCOMMENT					 ");
                    sbQuery.Append(" ,PT.MAT_COST AS UNIT_COST		 ");
                    sbQuery.Append(" ,PT.MAT_LTYPE           		 ");
                    sbQuery.Append(" ,PT.MAT_MTYPE           		 ");
                    sbQuery.Append(" ,PT.MAT_STYPE           		 ");
                    sbQuery.Append(" ,PT.DRAW_NO           		     ");
                    sbQuery.Append(" FROM TMAT_REQUEST R			 ");
                    sbQuery.Append(" JOIN TMAT_REQUEST_MASTER RM 	 ");
                    sbQuery.Append(" ON R.PLT_CODE = RM.PLT_CODE	 ");
                    sbQuery.Append(" AND R.REQUEST_NO = RM.REQUEST_NO");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART PT		 ");
                    sbQuery.Append(" ON R.PLT_CODE = PT.PLT_CODE	 ");
                    sbQuery.Append(" AND R.PART_CODE = PT.PART_CODE	 ");
                    sbQuery.Append(" LEFT JOIN TMAT_QUC_MASTER Q	 ");
                    sbQuery.Append(" ON PT.PLT_CODE = Q.PLT_CODE 	 ");
                    sbQuery.Append(" AND PT.MAT_QLTY = Q.MQLTY_CODE	 ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E		 ");
                    sbQuery.Append(" ON R.PLT_CODE = E.PLT_CODE		 ");
                    sbQuery.Append(" AND RM.REG_EMP = E.EMP_CODE	 ");
                    sbQuery.Append(" LEFT JOIN TSTD_ORG O			 ");
                    sbQuery.Append(" ON E.PLT_CODE = O.PLT_CODE		 ");
                    sbQuery.Append(" AND E.ORG_CODE = O.ORG_CODE	 ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE R.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@REG_EMP", " R.REG_EMP = @REG_EMP                             "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_REQ_DATE,@E_REQ_DATE", " (RM.REQ_DATE BETWEEN @S_REQ_DATE AND @E_REQ_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE,@E_DUE_DATE", " (RM.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@REQ_STAT", " R.REQ_STAT = @REQ_STAT                           "));
                        sbWhere.Append(UTIL.GetWhere(row, "@REQUEST_NO", " R.REQUEST_NO = @REQUEST_NO                       "));
                        sbWhere.Append(UTIL.GetWhere(row, "@REQUEST_SEQ", " R.REQUEST_SEQ = @REQUEST_SEQ                     "));
                        sbWhere.Append(" AND R.PART_CODE IS NOT NULL                              ");

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

        public static DataTable TMAT_REQUEST_QUERY4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT R.PLT_CODE				   ");
                    sbQuery.Append(" ,R.REQ_STAT					   ");
                    sbQuery.Append(" ,RM.REQ_DATE 					   ");
                    sbQuery.Append(" ,RM.DUE_DATE					   ");
                    sbQuery.Append(" ,R.REQUEST_NO					   ");
                    sbQuery.Append(" ,R.REQUEST_SEQ					   ");
                    sbQuery.Append(" ,I.ITEM_CODE					   ");
                    sbQuery.Append(" ,I.ITEM_NAME					   ");
                    sbQuery.Append(" ,PL.PROD_CODE					   ");
                    sbQuery.Append(" ,P.PROD_NAME					   ");
                    sbQuery.Append(" ,P.PRJ_CODE					   ");
                    sbQuery.Append(" ,PJ.PRJ_NAME					   ");
                    sbQuery.Append(" ,PPL.PART_CODE AS P_PART_CODE	   ");
                    sbQuery.Append(" ,PPL.PT_NAME AS P_PART_NAME	   ");
                    sbQuery.Append(" ,PPL.PART_NUM AS P_PART_NUM	   ");
                    sbQuery.Append(" ,R.PART_CODE					   ");
                    sbQuery.Append(" ,PL.PT_NAME AS PART_NAME		   ");
                    sbQuery.Append(" ,PL.PART_NUM					   ");
                    sbQuery.Append(" ,PL.PART_PRODTYPE				   ");
                    sbQuery.Append(" ,PL.PART_QLTY 					   ");
                    sbQuery.Append(" ,Q.MQLTY_NAME AS PART_QLTY_NAME   ");
                    sbQuery.Append(" ,PL.PART_SPEC AS MAT_SPEC		   ");
                    sbQuery.Append(" ,PL.PART_SPEC1 AS MAT_SPEC1	   ");
                    sbQuery.Append(" ,R.QTY							   ");
                    sbQuery.Append(" ,PL.PT_ID						   ");
                    sbQuery.Append(" ,R.C_REASON					   ");
                    sbQuery.Append(" ,R.REG_EMP						   ");
                    sbQuery.Append(" ,REG.EMP_NAME AS REG_EMP_NAME	   ");
                    sbQuery.Append(" ,R.MDFY_EMP					   ");
                    sbQuery.Append(" ,MDFY.EMP_NAME AS MDFY_EMP_NAME   ");
                    sbQuery.Append(" FROM TMAT_REQUEST R			   ");
                    sbQuery.Append(" JOIN TMAT_REQUEST_MASTER RM 	   ");
                    sbQuery.Append(" ON R.PLT_CODE = RM.PLT_CODE	   ");
                    sbQuery.Append(" AND R.REQUEST_NO = RM.REQUEST_NO  ");
                    sbQuery.Append(" LEFT JOIN TMAT_PUR_PARTLIST PL	   ");
                    sbQuery.Append(" ON R.PLT_CODE = PL.PLT_CODE	   ");
                    sbQuery.Append(" AND R.REQUEST_NO = PL.REQUEST_NO  ");
                    sbQuery.Append(" AND R.REQUEST_SEQ = PL.REQUEST_SEQ");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P		   ");
                    sbQuery.Append(" ON PL.PLT_CODE = P.PLT_CODE	   ");
                    sbQuery.Append(" AND PL.PROD_CODE = P.PROD_CODE	   ");
                    sbQuery.Append(" LEFT JOIN TORD_ITEM I			   ");
                    sbQuery.Append(" ON P.PLT_CODE = I.PLT_CODE		   ");
                    sbQuery.Append(" AND P.ITEM_CODE = I.ITEM_CODE	   ");
                    sbQuery.Append(" LEFT JOIN TORD_PROJECT PJ		   ");
                    sbQuery.Append(" ON P.PLT_CODE = PJ.PLT_CODE	   ");
                    sbQuery.Append(" AND P.PRJ_CODE = PJ.PRJ_CODE 	   ");
                    sbQuery.Append(" LEFT JOIN TMAT_PARTLIST PPL	   ");
                    sbQuery.Append(" ON PL.PLT_CODE = PPL.PLT_CODE	   ");
                    sbQuery.Append(" AND PL.O_PT_ID = PPL.PT_ID		   ");
                    sbQuery.Append(" LEFT JOIN TMAT_QUC_MASTER Q	   ");
                    sbQuery.Append(" ON PL.PLT_CODE = Q.PLT_CODE 	   ");
                    sbQuery.Append(" AND PL.PART_QLTY = Q.MQLTY_CODE   ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG	   ");
                    sbQuery.Append(" ON R.PLT_CODE = REG.PLT_CODE	   ");
                    sbQuery.Append(" AND R.REG_EMP = REG.EMP_CODE	   ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY	   ");
                    sbQuery.Append(" ON R.PLT_CODE = MDFY.PLT_CODE	   ");
                    sbQuery.Append(" AND R.MDFY_EMP = MDFY.EMP_CODE	   ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE R.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@REG_EMP", " R.REG_EMP = @REG_EMP                             "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_REQ_DATE,@E_REQ_DATE", " (RM.REQ_DATE BETWEEN @S_REQ_DATE AND @E_REQ_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE,@E_DUE_DATE", " (RM.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE)"));
                        sbWhere.Append(" AND R.PART_CODE IS NULL AND R.REQ_STAT IN ('02', '04' , '05')");



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

        public static DataTable TMAT_REQUEST_QUERY5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT R.PLT_CODE				 ");
                    sbQuery.Append(" ,R.REQ_STAT					 ");
                    sbQuery.Append(" ,RM.REQ_DATE 					 ");
                    sbQuery.Append(" ,RM.DUE_DATE					 ");
                    sbQuery.Append(" ,R.REQUEST_NO					 ");
                    sbQuery.Append(" ,R.REQUEST_SEQ					 ");
                    sbQuery.Append(" ,R.PART_CODE					 ");
                    sbQuery.Append(" ,PT.PART_NAME					 ");
                    sbQuery.Append(" ,PT.DRAW_NO					 ");
                    sbQuery.Append(" ,PT.MAT_SPEC					 ");
                    sbQuery.Append(" ,PT.MAT_UNIT					 ");
                    sbQuery.Append(" ,R.QTY							 ");
                    sbQuery.Append(" ,R.C_REASON					 ");
                    sbQuery.Append(" ,R.REG_EMP						 ");
                    sbQuery.Append(" ,REG.EMP_NAME AS REG_EMP_NAME	 ");
                    sbQuery.Append(" ,R.MDFY_EMP					 ");
                    sbQuery.Append(" ,MDFY.EMP_NAME AS MDFY_EMP_NAME ");
                    sbQuery.Append(" FROM TMAT_REQUEST R			 ");
                    sbQuery.Append(" JOIN TMAT_REQUEST_MASTER RM 	 ");
                    sbQuery.Append(" ON R.PLT_CODE = RM.PLT_CODE	 ");
                    sbQuery.Append(" AND R.REQUEST_NO = RM.REQUEST_NO");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART PT		 ");
                    sbQuery.Append(" ON R.PLT_CODE = PT.PLT_CODE	 ");
                    sbQuery.Append(" AND R.PART_CODE = PT.PART_CODE	 ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG	 ");
                    sbQuery.Append(" ON R.PLT_CODE = REG.PLT_CODE	 ");
                    sbQuery.Append(" AND R.REG_EMP = REG.EMP_CODE	 ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY	 ");
                    sbQuery.Append(" ON R.PLT_CODE = MDFY.PLT_CODE	 ");
                    sbQuery.Append(" AND R.MDFY_EMP = MDFY.EMP_CODE	 ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE R.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@REG_EMP", " R.REG_EMP = @REG_EMP                             "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_REQ_DATE,@E_REQ_DATE", " (RM.REQ_DATE BETWEEN @S_REQ_DATE AND @E_REQ_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE,@E_DUE_DATE", " (RM.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE)"));
                        sbWhere.Append(" AND R.PART_CODE IS NOT NULL AND R.REQ_STAT IN ('02', '04' , '05')");



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

   
        //자재발주에서 자재신청승인된 건 조회 (표준품)
        public static DataTable TMAT_REQUEST_QUERY10(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT  ");
                    sbQuery.Append(" R.PLT_CODE ");
                    sbQuery.Append(" ,R.REQUEST_NO ");
                    sbQuery.Append(" ,R.REQUEST_SEQ ");
                    sbQuery.Append(" ,R.WO_NO ");
                    sbQuery.Append(" ,RM.REQ_DATE ");
                    sbQuery.Append(" ,RM.CONFIRM_DATE ");
                    sbQuery.Append(" ,RM.DUE_DATE ");
                    sbQuery.Append(" ,R.REG_EMP ");
                    sbQuery.Append(" ,REG_EMP.EMP_NAME AS REG_EMP_NAME ");
                    sbQuery.Append(" ,SP.PART_CODE ");
                    sbQuery.Append(" ,SP.PART_NAME ");
                    sbQuery.Append(" ,SP.DRAW_NO ");
                    sbQuery.Append(" ,SP.MAT_LTYPE ");
                    sbQuery.Append(" ,SP.MAT_MTYPE ");
                    sbQuery.Append(" ,SP.MAT_STYPE ");
                    sbQuery.Append(" ,SP.MAT_TYPE ");
                    sbQuery.Append(" ,SP.SPEC_TYPE ");
                    sbQuery.Append(" ,SP.MAT_QLTY AS PART_QLTY ");
                    sbQuery.Append(" ,Q.MQLTY_NAME AS PART_QLTY_NAME ");
                    sbQuery.Append(" ,SP.MAT_SPEC AS PART_SPEC ");
                    sbQuery.Append(" ,SP.MAT_SPEC1 AS PART_SPEC1 ");
                    sbQuery.Append(" ,SP.BAL_SPEC AS BALJU_SPEC");
                    sbQuery.Append(" ,SP.MAT_WEIGHT1 ");
                    sbQuery.Append(" ,SP.MAT_WEIGHT ");
                    sbQuery.Append(" ,SP.BAL_WEIGHT ");
                    sbQuery.Append(" ,SP.SCOMMENT AS PT_SCOMMENT ");
                    sbQuery.Append(" ,ISNULL(SP.MAT_COST,0) AS UNIT_COST ");
                    sbQuery.Append(" ,ISNULL(SP.MAT_UC,0) AS MAT_UC ");
                    sbQuery.Append(" ,ISNULL(R.QTY,0) AS QTY");

                    sbQuery.Append(" ,ISNULL(( ROUND(SP.MAT_COST, 0) * R.QTY),0) AS AMT ");
                    sbQuery.Append(" ,RM.SCOMMENT AS RM_SCOMMENT ");
                    sbQuery.Append(" ,NULL AS SCOMMENT ");
                   
                    sbQuery.Append(" ,SP.MAIN_VND ");
                    sbQuery.Append(" ,W.MC_CODE");
                    sbQuery.Append(" ,W.WO_NO ");
                    sbQuery.Append(" ,M.VEN_CODE ");
                    sbQuery.Append(" ,TI.CVND_CODE ");
                    sbQuery.Append(" ,CV.VEN_NAME AS CVND_NAME ");
                    sbQuery.Append(" ,TI.ITEM_CODE ");
                    sbQuery.Append(" ,TI.ITEM_NAME ");
                    sbQuery.Append(" ,R.PROD_CODE ");
                    sbQuery.Append(" ,SP.DRAW_NO ");
                    sbQuery.Append(" ,SP.PART_PRODTYPE ");
                    //sbQuery.Append(" ,R.PUR_SCOMMENT ");

                    sbQuery.Append(" , (SELECT PUR_SCOMMENT FROM LSE_STD_PARTPROC WHERE PLT_CODE = R.PLT_CODE AND PART_CODE = R.PART_CODE AND PROC_CODE = 'P-02') AS PUR_SCOMMENT");
                    sbQuery.Append(" FROM TMAT_REQUEST R ");
                    sbQuery.Append(" JOIN TMAT_REQUEST_MASTER RM ");
                    sbQuery.Append(" ON R.PLT_CODE = RM.PLT_CODE ");
                    sbQuery.Append(" AND R.REQUEST_NO = RM.REQUEST_NO ");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG_EMP ");
                    sbQuery.Append(" ON R.PLT_CODE = REG_EMP.PLT_CODE ");
                    sbQuery.Append(" AND R.REG_EMP = REG_EMP.EMP_CODE ");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP ");
                    sbQuery.Append(" ON R.PLT_CODE = SP.PLT_CODE ");
                    sbQuery.Append(" AND R.PART_CODE = SP.PART_CODE ");

                    sbQuery.Append(" LEFT JOIN TMAT_QUC_MASTER Q ");
                    sbQuery.Append(" ON SP.PLT_CODE = Q.PLT_CODE  ");
                    sbQuery.Append(" AND SP.MAT_QLTY = Q.MQLTY_CODE ");

                    sbQuery.Append(" JOIN TORD_PRODUCT TP ");
                    sbQuery.Append(" ON R.PLT_CODE = TP.PLT_CODE ");
                    sbQuery.Append(" AND R.PROD_CODE = TP.PROD_CODE ");
                    sbQuery.Append(" AND R.PART_CODE = TP.PART_CODE ");

                    sbQuery.Append(" JOIN TORD_ITEM TI ");
                    sbQuery.Append(" ON TP.PLT_CODE = TI.PLT_CODE ");
                    sbQuery.Append(" AND TP.ITEM_CODE = TI.ITEM_CODE ");

                    sbQuery.Append(" JOIN TSTD_VENDOR CV ");
                    sbQuery.Append(" ON TI.PLT_CODE = CV.PLT_CODE ");
                    sbQuery.Append(" AND TI.CVND_CODE = CV.VEN_CODE ");

                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER W ");
                    sbQuery.Append(" ON R.PLT_CODE = W.PLT_CODE ");
                    sbQuery.Append(" AND R.WO_NO = W.WO_NO");

                    sbQuery.Append(" LEFT JOIN LSE_MACHINE M ");
                    sbQuery.Append(" ON W.PLT_CODE = M.PLT_CODE ");
                    sbQuery.Append(" AND W.MC_CODE = M.MC_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE R.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        //sbWhere.Append(UTIL.GetWhere(row, "@REQ_ORG_CODE", " REG_ORG.ORG_CODE = @REQ_ORG_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_LTYPE", " SP.MAT_LTYPE = @MAT_LTYPE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_MTYPE", " SP.MAT_MTYPE = @MAT_MTYPE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_STYPE", " SP.MAT_STYPE = @MAT_STYPE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_REQ_DATE,@E_REQ_DATE", " (RM.REQ_DATE BETWEEN @S_REQ_DATE AND @E_REQ_DATE) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE,@E_DUE_DATE", " (RM.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_CONFIRM_DATE,@E_CONFIRM_DATE", " (RM.CONFIRM_DATE BETWEEN @S_CONFIRM_DATE AND @E_CONFIRM_DATE) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@REQUEST_NO", " R.REQUEST_NO = @REQUEST_NO "));
                        sbWhere.Append(UTIL.GetWhere(row, "@REQUEST_SEQ", " R.REQUEST_SEQ = @REQUEST_SEQ "));
                        sbWhere.Append(UTIL.GetWhere(row, "@REQ_STAT", " R.REQ_STAT = @REQ_STAT "));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", " R.PROD_CODE = @PROD_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@ITEM_CODE", " TI.ITEM_CODE = @ITEM_CODE "));
                        sbWhere.Append(" AND R.PART_CODE IS NOT NULL ");


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

        public static DataTable TMAT_REQUEST_QUERY10_1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT  ");
                    sbQuery.Append(" R.PLT_CODE ");
                    sbQuery.Append(" ,R.REQUEST_NO ");
                    sbQuery.Append(" ,R.REQUEST_SEQ ");
                    sbQuery.Append(" ,R.WO_NO ");
                    sbQuery.Append(" ,RM.REQ_DATE ");
                    sbQuery.Append(" ,RM.CONFIRM_DATE ");
                    sbQuery.Append(" ,RM.DUE_DATE ");
                    sbQuery.Append(" ,R.REG_EMP ");
                    sbQuery.Append(" ,REG_EMP.EMP_NAME AS REG_EMP_NAME ");
                    sbQuery.Append(" ,SP.PART_CODE ");
                    sbQuery.Append(" ,SP.PART_NAME ");
                    sbQuery.Append(" ,SP.DRAW_NO ");
                    sbQuery.Append(" ,SP.MAT_LTYPE ");
                    sbQuery.Append(" ,SP.MAT_MTYPE ");
                    sbQuery.Append(" ,SP.MAT_STYPE ");
                    sbQuery.Append(" ,SP.MAT_TYPE ");
                    sbQuery.Append(" ,SP.SPEC_TYPE ");
                    sbQuery.Append(" ,SP.MAT_QLTY AS PART_QLTY ");
                    sbQuery.Append(" ,Q.MQLTY_NAME AS PART_QLTY_NAME ");
                    sbQuery.Append(" ,SP.MAT_SPEC AS PART_SPEC ");
                    sbQuery.Append(" ,SP.MAT_SPEC1 AS PART_SPEC1 ");
                    sbQuery.Append(" ,SP.BAL_SPEC AS BALJU_SPEC");
                    sbQuery.Append(" ,SP.MAT_WEIGHT1 ");
                    sbQuery.Append(" ,SP.MAT_WEIGHT ");
                    sbQuery.Append(" ,SP.BAL_WEIGHT ");
                    sbQuery.Append(" ,SP.SCOMMENT AS PT_SCOMMENT ");
                    sbQuery.Append(" ,ISNULL(SP.MAT_COST,0) AS UNIT_COST ");
                    sbQuery.Append(" ,ISNULL(SP.MAT_UC,0) AS MAT_UC ");
                    //sbQuery.Append(" ,ISNULL(R.QTY,0) AS QTY");
                    sbQuery.Append(" ,ISNULL(R.QTY,0) AS ALL_QTY");
                    sbQuery.Append(" ,ISNULL(R.QTY,0) - ISNULL(RE_QTY,0) AS REMAIN_QTY");
                    sbQuery.Append(" ,ISNULL(R.QTY,0) - ISNULL(RE_QTY,0) AS QTY");

                    sbQuery.Append(" ,ISNULL(( ROUND(SP.MAT_COST, 0) * R.QTY),0) AS AMT ");
                    sbQuery.Append(" ,RM.SCOMMENT AS RM_SCOMMENT ");
                    sbQuery.Append(" ,NULL AS SCOMMENT ");

                    sbQuery.Append(" ,SP.MAIN_VND ");
                    sbQuery.Append(" ,W.MC_CODE");
                    sbQuery.Append(" ,W.WO_NO ");
                    sbQuery.Append(" ,M.VEN_CODE ");
                    sbQuery.Append(" ,TI.CVND_CODE ");
                    sbQuery.Append(" ,CV.VEN_NAME AS CVND_NAME ");
                    sbQuery.Append(" ,TI.ITEM_CODE ");
                    sbQuery.Append(" ,TI.ITEM_NAME ");
                    sbQuery.Append(" ,R.PROD_CODE ");
                    sbQuery.Append(" ,SP.DRAW_NO ");
                    sbQuery.Append(" ,SP.PART_PRODTYPE ");
                    //sbQuery.Append(" ,R.PUR_SCOMMENT ");

                    sbQuery.Append(" , (SELECT PUR_SCOMMENT FROM LSE_STD_PARTPROC WHERE PLT_CODE = R.PLT_CODE AND PART_CODE = R.PART_CODE AND PROC_CODE = 'P-02') AS PUR_SCOMMENT");
                    sbQuery.Append(" FROM TMAT_REQUEST R ");
                    sbQuery.Append(" JOIN TMAT_REQUEST_MASTER RM ");
                    sbQuery.Append(" ON R.PLT_CODE = RM.PLT_CODE ");
                    sbQuery.Append(" AND R.REQUEST_NO = RM.REQUEST_NO ");

                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG_EMP ");
                    sbQuery.Append(" ON R.PLT_CODE = REG_EMP.PLT_CODE ");
                    sbQuery.Append(" AND R.REG_EMP = REG_EMP.EMP_CODE ");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP ");
                    sbQuery.Append(" ON R.PLT_CODE = SP.PLT_CODE ");
                    sbQuery.Append(" AND R.PART_CODE = SP.PART_CODE ");

                    sbQuery.Append(" LEFT JOIN TMAT_QUC_MASTER Q ");
                    sbQuery.Append(" ON SP.PLT_CODE = Q.PLT_CODE  ");
                    sbQuery.Append(" AND SP.MAT_QLTY = Q.MQLTY_CODE ");

                    sbQuery.Append(" JOIN TORD_PRODUCT TP ");
                    sbQuery.Append(" ON R.PLT_CODE = TP.PLT_CODE ");
                    sbQuery.Append(" AND R.PROD_CODE = TP.PROD_CODE ");
                    sbQuery.Append(" AND R.PART_CODE = TP.PART_CODE ");

                    sbQuery.Append(" JOIN TORD_ITEM TI ");
                    sbQuery.Append(" ON TP.PLT_CODE = TI.PLT_CODE ");
                    sbQuery.Append(" AND TP.ITEM_CODE = TI.ITEM_CODE ");

                    sbQuery.Append(" JOIN TSTD_VENDOR CV ");
                    sbQuery.Append(" ON TI.PLT_CODE = CV.PLT_CODE ");
                    sbQuery.Append(" AND TI.CVND_CODE = CV.VEN_CODE ");

                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER W ");
                    sbQuery.Append(" ON R.PLT_CODE = W.PLT_CODE ");
                    sbQuery.Append(" AND R.WO_NO = W.WO_NO");

                    sbQuery.Append(" LEFT JOIN LSE_MACHINE M ");
                    sbQuery.Append(" ON W.PLT_CODE = M.PLT_CODE ");
                    sbQuery.Append(" AND W.MC_CODE = M.MC_CODE ");

                    //발주취소 제외
                    sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE, REQUEST_NO, SUM(QTY) AS RE_QTY FROM TMAT_BALJU WHERE BAL_STAT <> '14' GROUP BY PLT_CODE, REQUEST_NO) TB");
                    sbQuery.Append(" ON R.PLT_CODE = TB.PLT_CODE ");
                    sbQuery.Append(" AND R.REQUEST_NO = TB.REQUEST_NO ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE R.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        //sbWhere.Append(UTIL.GetWhere(row, "@REQ_ORG_CODE", " REG_ORG.ORG_CODE = @REQ_ORG_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_LTYPE", " SP.MAT_LTYPE = @MAT_LTYPE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_MTYPE", " SP.MAT_MTYPE = @MAT_MTYPE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAT_STYPE", " SP.MAT_STYPE = @MAT_STYPE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_REQ_DATE,@E_REQ_DATE", " (RM.REQ_DATE BETWEEN @S_REQ_DATE AND @E_REQ_DATE) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE,@E_DUE_DATE", " (RM.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_CONFIRM_DATE,@E_CONFIRM_DATE", " (RM.CONFIRM_DATE BETWEEN @S_CONFIRM_DATE AND @E_CONFIRM_DATE) "));
                        sbWhere.Append(UTIL.GetWhere(row, "@REQUEST_NO", " R.REQUEST_NO = @REQUEST_NO "));
                        sbWhere.Append(UTIL.GetWhere(row, "@REQUEST_SEQ", " R.REQUEST_SEQ = @REQUEST_SEQ "));
                        sbWhere.Append(UTIL.GetWhere(row, "@REQ_STAT", "R.REQ_STAT = @REQ_STAT OR (R.REQ_STAT='11' AND ISNULL(R.QTY,0) >ISNULL(RE_QTY,0))"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", " R.PROD_CODE = @PROD_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@ITEM_CODE", " TI.ITEM_CODE = @ITEM_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", " W.DATA_FLAG = @DATA_FLAG "));
                        sbWhere.Append(" AND R.PART_CODE IS NOT NULL ");
                        sbWhere.Append(" AND TP.PROD_STATE <> 'SH' ");


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

        //자재신청현황
        public static DataTable TMAT_REQUEST_QUERY11(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT							 ");
                    sbQuery.Append(" R.REQUEST_NO					 ");
                    sbQuery.Append(" ,REQ_DATE						 ");
                    sbQuery.Append(" ,DUE_DATE						 ");
                    sbQuery.Append(" ,R.PART_CODE					 ");
                    sbQuery.Append(" ,SP.PART_NAME					 ");
                    sbQuery.Append(" ,SP.DRAW_NO					 ");
                    sbQuery.Append(" ,SP.MAT_SPEC					 ");
                    sbQuery.Append(" ,SP.MAT_UNIT					 ");
                    sbQuery.Append(" ,R.QTY							 ");
                    sbQuery.Append(" FROM TMAT_REQUEST R			 ");
                    sbQuery.Append(" LEFT JOIN TMAT_REQUEST_MASTER RM");
                    sbQuery.Append(" ON R.PLT_CODE = RM.PLT_CODE	 ");
                    sbQuery.Append(" AND R.REQUEST_NO = RM.REQUEST_NO");
                    sbQuery.Append(" 								 ");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP		 ");
                    sbQuery.Append(" ON R.PLT_CODE = SP.PLT_CODE	 ");
                    sbQuery.Append(" AND R.PART_CODE = SP.PART_CODE	 ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE R.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_LIKE", "(R.PART_CODE LIKE '%' + @PART_LIKE + '%' OR SP.PART_NAME LIKE '%' + @PART_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DRAW_LIKE", " SP.DRAW_NO LIKE '%' + @DRAW_LIKE + '%'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_REQ_DATE,@E_REQ_DATE", " (RM.REQ_DATE BETWEEN @S_REQ_DATE AND @E_REQ_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE,@E_DUE_DATE", " (RM.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE)"));
                        sbWhere.Append(" AND R.REQ_STAT IN ('01','03')");
                        sbWhere.Append(" ORDER BY REQ_DATE");



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


        public static DataTable TMAT_REQUEST_QUERY12(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT 																			  ");
                    sbQuery.Append(" PROD_CODE 																			  ");
                    sbQuery.Append(" ,PART_CODE 																			  ");
                    sbQuery.Append(" ,(SELECT PROC_CODE FROM LSE_STD_PROC WHERE IS_MAT = '1' AND DATA_FLAG = 0) AS MAT_PROC");
                    sbQuery.Append(" ,REQ_STAT																			  ");
                    sbQuery.Append(" FROM TMAT_REQUEST																	  ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "PART_CODE = @PART_CODE"));



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
