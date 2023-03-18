using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DOUT
{
    public class TOUT_REQUEST
    {

        public static DataTable TOUT_REQUEST_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();


                    sbQuery.Append(" SELECT   PLT_CODE             ");
                    sbQuery.Append(" , REQUEST_NO                  ");
                    sbQuery.Append(" , REQUEST_SEQ                 ");
                    sbQuery.Append(" , WO_NO                       ");
                    sbQuery.Append(" , PROC_CODE                   ");
                    sbQuery.Append(" , QTY                         ");
                    sbQuery.Append(" , REQ_STAT                    ");
                    sbQuery.Append(" , C_REASON                    ");
                    sbQuery.Append(" , REG_DATE                    ");
                    sbQuery.Append(" , REG_EMP                     ");
                    sbQuery.Append(" , MDFY_DATE                   ");
                    sbQuery.Append(" , MDFY_EMP                    ");
                    sbQuery.Append(" FROM TOUT_REQUEST             ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE    ");
                    sbQuery.Append(" AND REQUEST_NO = @REQUEST_NO  ");
                    sbQuery.Append(" AND REQUEST_SEQ = @REQUEST_SEQ");


                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "REQUEST_NO")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "REQUEST_SEQ")) isHasColumn = false;

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

        public static void TOUT_REQUEST_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();


                    sbQuery.Append(" INSERT INTO TOUT_REQUEST");
                    sbQuery.Append(" (						 ");
                    sbQuery.Append(" PLT_CODE				 ");
                    sbQuery.Append(" , REQUEST_NO			 ");
                    sbQuery.Append(" , REQUEST_SEQ			 ");
                    sbQuery.Append(" , WO_NO				 ");
                    sbQuery.Append(" , PROC_CODE			 ");
                    sbQuery.Append(" , PART_CODE			 ");
                    sbQuery.Append(" , QTY					 ");
                    sbQuery.Append(" , REQ_STAT				 ");
                    sbQuery.Append(" , REG_DATE				 ");
                    sbQuery.Append(" , REG_EMP				 ");
                    sbQuery.Append(" )						 ");
                    sbQuery.Append(" VALUES					 ");
                    sbQuery.Append(" (						 ");
                    sbQuery.Append(" @PLT_CODE				 ");
                    sbQuery.Append(" , @REQUEST_NO			 ");
                    sbQuery.Append(" , @REQUEST_SEQ			 ");
                    sbQuery.Append(" , @WO_NO				 ");
                    sbQuery.Append(" , @PROC_CODE			 ");
                    sbQuery.Append(" , @PART_CODE			 ");
                    sbQuery.Append(" , @QTY					 ");
                    sbQuery.Append(" , @REQ_STAT			 ");
                    sbQuery.Append(" , GETDATE()            ");
                    sbQuery.Append(" ," + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" )                       ");

                    

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


        public static void TOUT_REQUEST_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TOUT_REQUEST		   ");
                    sbQuery.Append(" SET   QTY = @QTY			   ");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()       ");
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



        public static void TOUT_REQUEST_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TOUT_REQUEST		   ");
                    sbQuery.Append(" SET   REQ_STAT = @REQ_STAT	   ");
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

        public static void TOUT_REQUEST_UPD3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TOUT_REQUEST		   ");
                    sbQuery.Append(" SET   REQ_STAT = @REQ_STAT	   ");
                    sbQuery.Append(" , C_REASON = @C_REASON		   ");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()	   ");
                    sbQuery.Append(" , MDFY_EMP = @MDFY_EMP		   ");
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

    }

    public class TOUT_REQUEST_QUERY
    {

        public static DataTable TOUT_REQUEST_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT R.PLT_CODE				   ");
                    sbQuery.Append(" ,RM.REQ_DATE					   ");
                    sbQuery.Append(" ,RM.DUE_DATE					   ");
                    sbQuery.Append(" ,R.REQUEST_NO					   ");
                    sbQuery.Append(" ,R.REQUEST_SEQ					   ");
                    sbQuery.Append(" ,PT.PROD_CODE					   ");
                    sbQuery.Append(" ,P.PROD_NAME					   ");
                    //sbQuery.Append(" --,PT.PART_CODE				   ");
                    sbQuery.Append(" ,PT.PART_NUM					   ");
                    //sbQuery.Append(" --,PT.PT_NAME AS PART_NAME		   ");
                    sbQuery.Append(" ,LPT.PART_CODE					   ");
                    sbQuery.Append(" ,LPT.PART_NAME					   ");
                    sbQuery.Append(" ,LPT.MAT_LTYPE					   ");
                    sbQuery.Append(" ,LPT.MAT_MTYPE					   ");
                    sbQuery.Append(" ,LPT.MAT_STYPE					   ");
                    sbQuery.Append(" ,LPT.DRAW_NO					   ");
                    sbQuery.Append(" ,LPT.MAT_SPEC					   ");
                    sbQuery.Append(" ,LPT.MAT_UNIT					   ");
                    sbQuery.Append(" ,PPT.PART_CODE AS P_PART_CODE	   ");
                    sbQuery.Append(" ,PPT.PT_NAME AS P_PART_NAME	   ");
                    sbQuery.Append(" ,PPT.PART_NUM AS P_PART_NUM	   ");
                    sbQuery.Append(" ,R.PROC_CODE					   ");
                    sbQuery.Append(" ,PRC.PROC_NAME					   ");
                    sbQuery.Append(" ,R.QTY							   ");
                    sbQuery.Append(" ,R.REQ_STAT					   ");
                    sbQuery.Append(" ,R.REG_DATE					   ");
                    sbQuery.Append(" ,R.REG_EMP						   ");
                    sbQuery.Append(" ,E.EMP_NAME AS REG_EMP_NAME	   ");
                    sbQuery.Append(" ,P.PROD_TYPE					   ");
                    sbQuery.Append(" ,PT.PART_SPEC					   ");
                    sbQuery.Append(" ,PT.PART_SPEC1					   ");
                    sbQuery.Append(" ,PT.WEIGHT_VOLUME				   ");
                    sbQuery.Append(" ,PT.WEIGHT_VOLUME1				   ");
                    sbQuery.Append(" ,SP.MAT_UNIT					   ");
                    sbQuery.Append(" ,O.ORG_NAME					   ");
                    sbQuery.Append(" ,PT.PART_QLTY					   ");
                    sbQuery.Append(" ,Q.MQLTY_NAME AS PART_QLTY_NAME   ");
                    sbQuery.Append(" ,R.WO_NO						   ");
                    sbQuery.Append(" ,RM.SCOMMENT					   ");
                    sbQuery.Append(" FROM TOUT_REQUEST R			   ");
                    sbQuery.Append(" LEFT JOIN TOUT_REQUEST_MASTER RM  ");
                    sbQuery.Append(" ON R.PLT_CODE = RM.PLT_CODE	   ");
                    sbQuery.Append(" AND R.REQUEST_NO = RM.REQUEST_NO  ");
                    sbQuery.Append(" 								   ");
                    sbQuery.Append(" LEFT JOIN TMAT_PUR_PARTLIST PT	   ");
                    sbQuery.Append(" ON R.PLT_CODE = PT.PLT_CODE	   ");
                    sbQuery.Append(" AND R.REQUEST_NO = PT.REQUEST_NO  ");
                    sbQuery.Append(" AND R.REQUEST_SEQ = PT.REQUEST_SEQ");
                    sbQuery.Append(" 								   ");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P		   ");
                    sbQuery.Append(" ON PT.PLT_CODE = P.PLT_CODE	   ");
                    sbQuery.Append(" AND PT.PROD_CODE = P.PROD_CODE	   ");
                    sbQuery.Append(" 								   ");
                    sbQuery.Append(" LEFT JOIN TORD_ITEM I			   ");
                    sbQuery.Append(" ON P.PLT_CODE = I.PLT_CODE		   ");
                    sbQuery.Append(" AND P.ITEM_CODE = I.ITEM_CODE	   ");
                    sbQuery.Append(" 								   ");
                    sbQuery.Append(" LEFT JOIN TMAT_PARTLIST PPT	   ");
                    sbQuery.Append(" ON PT.PLT_CODE = PPT.PLT_CODE	   ");
                    sbQuery.Append(" AND PT.O_PT_ID = PPT.PT_ID		   ");
                    sbQuery.Append(" 								   ");
                    sbQuery.Append(" LEFT JOIN TMAT_QUC_MASTER Q	   ");
                    sbQuery.Append(" ON PT.PLT_CODE = Q.PLT_CODE 	   ");
                    sbQuery.Append(" AND PT.PART_QLTY = Q.MQLTY_CODE   ");
                    sbQuery.Append(" 								   ");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC PRC		   ");
                    sbQuery.Append(" ON R.PLT_CODE = PRC.PLT_CODE	   ");
                    sbQuery.Append(" AND R.PROC_CODE = PRC.PROC_CODE   ");
                    sbQuery.Append(" 								   ");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP		   ");
                    sbQuery.Append(" ON PT.PLT_CODE = SP.PLT_CODE	   ");
                    sbQuery.Append(" AND PT.PART_CODE = SP.PART_CODE   ");
                    sbQuery.Append(" 								   ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E		   ");
                    sbQuery.Append(" ON R.PLT_CODE = E.PLT_CODE		   ");
                    sbQuery.Append(" AND R.REG_EMP = E.EMP_CODE		   ");
                    sbQuery.Append(" 								   ");
                    sbQuery.Append(" LEFT JOIN TSTD_ORG O			   ");
                    sbQuery.Append(" ON E.PLT_CODE = O.PLT_CODE		   ");
                    sbQuery.Append(" AND E.ORG_CODE = O.ORG_CODE	   ");
                    sbQuery.Append(" 								   ");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART LPT		   ");
                    sbQuery.Append(" ON R.PLT_CODE = LPT.PLT_CODE	   ");
                    sbQuery.Append(" AND R.PART_CODE = LPT.PART_CODE   ");



                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE R.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@REG_EMP", " R.REG_EMP = @REG_EMP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_REQ_DATE,@E_REQ_DATE", " (RM.REQ_DATE BETWEEN @S_REQ_DATE AND @E_REQ_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE,E_DUE_DATE", " (RM.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", " PT.PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@REQ_STAT", " R.REQ_STAT = @REQ_STAT"));
                        sbWhere.Append(UTIL.GetWhere(row, "@REQUEST_NO", " R.REQUEST_NO = @REQUEST_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@REQUEST_SEQ", " R.REQUEST_SEQ = @REQUEST_SEQ"));

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


        public static DataTable TOUT_REQUEST_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT R.PLT_CODE				   ");
                    sbQuery.Append(" ,RM.REQ_DATE					   ");
                    sbQuery.Append(" ,RM.DUE_DATE					   ");
                    sbQuery.Append(" ,R.REQUEST_NO					   ");
                    sbQuery.Append(" ,R.REQUEST_SEQ					   ");
                    sbQuery.Append(" ,PT.PROD_CODE					   ");
                    sbQuery.Append(" ,P.PROD_NAME					   ");
                    //sbQuery.Append(" --,PT.PART_CODE				   ");
                    //sbQuery.Append(" --,PT.PART_NUM					   ");
                    //sbQuery.Append(" --,PT.PT_ID					   ");
                    //sbQuery.Append(" --,PT.PT_NAME AS PART_NAME		   ");
                    sbQuery.Append(" ,R.PART_CODE					   ");
                    sbQuery.Append(" ,LPT.PART_NAME					   ");
                    sbQuery.Append(" ,LPT.MAT_LTYPE					   ");
                    sbQuery.Append(" ,LPT.MAT_MTYPE					   ");
                    sbQuery.Append(" ,LPT.MAT_STYPE					   ");
                    sbQuery.Append(" ,LPT.DRAW_NO					   ");
                    sbQuery.Append(" ,LPT.MAT_SPEC					   ");
                    sbQuery.Append(" ,LPT.MAT_UNIT					   ");
                    sbQuery.Append(" ,PPT.PART_CODE AS P_PART_CODE	   ");
                    sbQuery.Append(" ,PPT.PT_NAME AS P_PART_NAME	   ");
                    sbQuery.Append(" ,PPT.PART_NUM AS P_PART_NUM	   ");
                    sbQuery.Append(" ,R.PROC_CODE					   ");
                    sbQuery.Append(" ,PRC.PROC_NAME					   ");
                    sbQuery.Append(" ,R.QTY							   ");
                    sbQuery.Append(" ,R.REQ_STAT					   ");
                    sbQuery.Append(" ,R.C_REASON					   ");
                    sbQuery.Append(" ,R.REG_DATE					   ");
                    sbQuery.Append(" ,R.REG_EMP						   ");
                    sbQuery.Append(" ,REG.EMP_NAME AS REG_EMP_NAME	   ");
                    sbQuery.Append(" ,R.MDFY_DATE					   ");
                    sbQuery.Append(" ,R.MDFY_EMP					   ");
                    sbQuery.Append(" ,MDFY.EMP_NAME AS MDFY_EMP_NAME   ");
                    sbQuery.Append(" ,P.PROD_TYPE					   ");
                    sbQuery.Append(" ,R.WO_NO						   ");
                    sbQuery.Append(" FROM TOUT_REQUEST R			   ");
                    sbQuery.Append(" LEFT JOIN TOUT_REQUEST_MASTER RM  ");
                    sbQuery.Append(" ON R.PLT_CODE = RM.PLT_CODE	   ");
                    sbQuery.Append(" AND R.REQUEST_NO = RM.REQUEST_NO  ");
                    sbQuery.Append(" 								   ");
                    sbQuery.Append(" LEFT JOIN TMAT_PUR_PARTLIST PT	   ");
                    sbQuery.Append(" ON R.PLT_CODE = PT.PLT_CODE	   ");
                    sbQuery.Append(" AND R.REQUEST_NO = PT.REQUEST_NO  ");
                    sbQuery.Append(" AND R.REQUEST_SEQ = PT.REQUEST_SEQ");
                    sbQuery.Append(" 								   ");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P		   ");
                    sbQuery.Append(" ON PT.PLT_CODE = P.PLT_CODE	   ");
                    sbQuery.Append(" AND PT.PROD_CODE = P.PROD_CODE	   ");
                    sbQuery.Append(" 								   ");
                    sbQuery.Append(" LEFT JOIN TMAT_PARTLIST PPT	   ");
                    sbQuery.Append(" ON PT.PLT_CODE = PPT.PLT_CODE	   ");
                    sbQuery.Append(" AND PT.O_PT_ID = PPT.PT_ID		   ");
                    sbQuery.Append(" 								   ");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC PRC		   ");
                    sbQuery.Append(" ON R.PLT_CODE = PRC.PLT_CODE	   ");
                    sbQuery.Append(" AND R.PROC_CODE = PRC.PROC_CODE   ");
                    sbQuery.Append(" 								   ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG	   ");
                    sbQuery.Append(" ON R.PLT_CODE = REG.PLT_CODE	   ");
                    sbQuery.Append(" AND R.REG_EMP = REG.EMP_CODE	   ");
                    sbQuery.Append(" 								   ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY	   ");
                    sbQuery.Append(" ON R.PLT_CODE = MDFY.PLT_CODE	   ");
                    sbQuery.Append(" AND R.MDFY_EMP = MDFY.EMP_CODE	   ");
                    sbQuery.Append(" 								   ");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART LPT		   ");
                    sbQuery.Append(" ON R.PLT_CODE = LPT.PLT_CODE	   ");
                    sbQuery.Append(" AND R.PART_CODE = LPT.PART_CODE   ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE R.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@REG_EMP", " R.REG_EMP = @REG_EMP                             "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_REQ_DATE,@E_REQ_DATE", " (RM.REQ_DATE BETWEEN @S_REQ_DATE AND @E_REQ_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE,@E_DUE_DATE", " (RM.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", " PT.PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@REQUEST_NO", " R.REQUEST_NO = @REQUEST_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@REQUEST_SEQ", " R.REQUEST_SEQ = @REQUEST_SEQ"));
                        sbWhere.Append(" AND R.REQ_STAT IN ('02', '04' , '05')");



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

        //공정외주 발주에서 신청승인된 건 조회
        public static DataTable TOUT_REQUEST_QUERY4(DataTable dtParam, BizExecute.BizExecute bizExecute)
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
                    sbQuery.Append(" ,RM.REQ_DATE ");
                    sbQuery.Append(" ,RM.CONFIRM_DATE ");
                    sbQuery.Append(" ,RM.DUE_DATE ");
                    sbQuery.Append(" ,R.REG_EMP ");
                    sbQuery.Append(" ,REG_EMP.EMP_NAME AS REG_EMP_NAME ");
                    sbQuery.Append(" ,I.ITEM_CODE ");
                    sbQuery.Append(" ,I.ITEM_NAME ");
                    sbQuery.Append(" ,P.PROD_CODE ");
                    sbQuery.Append(" ,P.PROD_NAME ");
                    sbQuery.Append(" ,PT.PART_CODE ");
                    sbQuery.Append(" ,PT.PT_NAME AS PART_NAME ");
                    sbQuery.Append(" ,PT.PART_NUM ");
                    sbQuery.Append(" ,PPT.PART_CODE AS P_PART_CODE ");
                    sbQuery.Append(" ,PPT.PT_NAME AS P_PART_NAME ");
                    sbQuery.Append(" ,PPT.PART_NUM AS P_PART_NUM ");
                    sbQuery.Append(" ,SP.MAT_TYPE ");
                    sbQuery.Append(" ,SP.MAT_LTYPE ");
                    sbQuery.Append(" ,SP.MAT_MTYPE ");
                    sbQuery.Append(" ,SP.MAT_STYPE ");
                    sbQuery.Append(" ,PT.PART_PRODTYPE ");
                    sbQuery.Append(" ,PT.PART_QLTY ");
                    sbQuery.Append(" ,Q.MQLTY_NAME AS PART_QLTY_NAME ");
                    sbQuery.Append(" ,PT.PART_SPEC ");
                    sbQuery.Append(" ,PT.PART_SPEC1 ");
                    sbQuery.Append(" ,PT.WEIGHT_VOLUME ");
                    sbQuery.Append(" ,PT.WEIGHT_VOLUME1 ");
                    sbQuery.Append(" ,R.QTY ");
                    sbQuery.Append(" ,REG_ORG.ORG_CODE AS REQ_ORG_CODE ");
                    sbQuery.Append(" ,REG_ORG.ORG_NAME AS REQ_ORG_NAME ");
                    sbQuery.Append(" ,RM.CONFIRM_EMP ");
                    sbQuery.Append(" ,CONFIRM_EMP.EMP_NAME AS CONFIRM_EMP_NAME ");
                    sbQuery.Append(" ,R.PROC_CODE ");
                    sbQuery.Append(" ,PRC.PROC_NAME ");
                    sbQuery.Append(" ,R.WO_NO ");
                    sbQuery.Append(" ,PRC.MAIN_VND ");
                    sbQuery.Append(" ,V.VEN_NAME AS MAIN_VND_NAME ");
                    sbQuery.Append(" FROM TOUT_REQUEST R ");
                    sbQuery.Append(" JOIN TOUT_REQUEST_MASTER RM ");
                    sbQuery.Append(" ON R.PLT_CODE = RM.PLT_CODE ");
                    sbQuery.Append(" AND R.REQUEST_NO = RM.REQUEST_NO ");
                    sbQuery.Append(" LEFT JOIN TMAT_PUR_PARTLIST PT ");
                    sbQuery.Append(" ON R.PLT_CODE = PT.PLT_CODE ");
                    sbQuery.Append(" AND R.REQUEST_NO = PT.REQUEST_NO ");
                    sbQuery.Append(" AND R.REQUEST_SEQ = PT.REQUEST_SEQ ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG_EMP ");
                    sbQuery.Append(" ON R.PLT_CODE = REG_EMP.PLT_CODE ");
                    sbQuery.Append(" AND R.REG_EMP = REG_EMP.EMP_CODE ");
                    sbQuery.Append(" LEFT JOIN TSTD_ORG REG_ORG ");
                    sbQuery.Append(" ON REG_EMP.PLT_CODE = REG_ORG.PLT_CODE ");
                    sbQuery.Append(" AND REG_EMP.ORG_CODE = REG_ORG.ORG_CODE ");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P ");
                    sbQuery.Append(" ON PT.PLT_CODE = P.PLT_CODE ");
                    sbQuery.Append(" AND PT.PROD_CODE = P.PROD_CODE ");
                    sbQuery.Append(" LEFT JOIN TORD_ITEM I ");
                    sbQuery.Append(" ON P.PLT_CODE = I.PLT_CODE ");
                    sbQuery.Append(" AND P.ITEM_CODE = I.ITEM_CODE ");
                    sbQuery.Append(" LEFT JOIN TMAT_PARTLIST PPT ");
                    sbQuery.Append(" ON PT.PLT_CODE = PPT.PLT_CODE ");
                    sbQuery.Append(" AND PT.O_PT_ID = PPT.PT_ID ");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP ");
                    sbQuery.Append(" ON PT.PLT_CODE = SP.PLT_CODE ");
                    sbQuery.Append(" AND PT.PART_CODE = SP.PART_CODE ");
                    sbQuery.Append(" LEFT JOIN TMAT_QUC_MASTER Q ");
                    sbQuery.Append(" ON PT.PLT_CODE = Q.PLT_CODE  ");
                    sbQuery.Append(" AND PT.PART_QLTY = Q.MQLTY_CODE ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE CONFIRM_EMP ");
                    sbQuery.Append(" ON RM.PLT_CODE = CONFIRM_EMP.PLT_CODE ");
                    sbQuery.Append(" AND RM.CONFIRM_EMP = CONFIRM_EMP.EMP_CODE ");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC PRC ");
                    sbQuery.Append(" ON R.PLT_CODE = PRC.PLT_CODE  ");
                    sbQuery.Append(" AND R.PROC_CODE = PRC.PROC_CODE ");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V ");
                    sbQuery.Append(" ON PRC.PLT_CODE = V.PLT_CODE  ");
                    sbQuery.Append(" AND PRC.MAIN_VND = V.VEN_CODE ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE R.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", " PT.PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@REQ_ORG_CODE", " REG_ORG.ORG_CODE = @REQ_ORG_CODE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_REQ_DATE,@E_REQ_DATE", " (RM.REQ_DATE BETWEEN @S_REQ_DATE AND @E_REQ_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE,@E_DUE_DATE", " (RM.DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_CONFIRM_DATE,@E_CONFIRM_DATE", " ((RM.CONFIRM_DATE BETWEEN @S_CONFIRM_DATE AND @E_CONFIRM_DATE))"));
                        sbWhere.Append(UTIL.GetWhere(row, "@REQUEST_NO", " R.REQUEST_NO = @REQUEST_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@REQUEST_SEQ", " R.REQUEST_SEQ = @REQUEST_SEQ"));
                        sbWhere.Append(UTIL.GetWhere(row, "@REQ_STAT", " R.REQ_STAT = @REQ_STAT"));



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

        //외주 공정인 작업지시 조회
        public static DataTable TOUT_REQUEST_QUERY5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT  ");
                    sbQuery.Append(" TW.PLT_CODE  ");
                    sbQuery.Append(" ,TW.WO_NO ");

                    sbQuery.Append(" ,I.CVND_CODE  ");
                    sbQuery.Append(" ,CV.VEN_NAME AS CVND_NAME  ");

                    sbQuery.Append(" ,I.ITEM_CODE  ");
                    sbQuery.Append(" ,I.ITEM_NAME  ");
                    sbQuery.Append(" ,P.PROD_CODE  ");
                    sbQuery.Append(" ,P.PROD_NAME  ");
                    sbQuery.Append(" ,P.PART_CODE  ");
                    sbQuery.Append(" ,SP.DRAW_NO ");
                    sbQuery.Append(" ,SP.PART_NAME ");
                    sbQuery.Append(" ,SP.MAT_TYPE  ");
                    sbQuery.Append(" ,SP.MAT_LTYPE  ");
                    sbQuery.Append(" ,SP.MAT_MTYPE  ");
                    sbQuery.Append(" ,SP.MAT_STYPE  ");
                    sbQuery.Append(" ,SP.PART_PRODTYPE ");
                    sbQuery.Append(" ,SP.MAT_QLTY AS PART_QLTY");
                    sbQuery.Append(" ,Q.MQLTY_NAME AS PART_QLTY_NAME  ");

                    sbQuery.Append(" ,SP.MAT_SPEC1 ");
                    sbQuery.Append(" ,SP.MAT_SPEC ");
                    sbQuery.Append(" ,SP.BAL_SPEC ");
                    sbQuery.Append(" ,SP.MAT_WEIGHT1 ");
                    sbQuery.Append(" ,SP.MAT_WEIGHT ");
                    sbQuery.Append(" ,SP.BAL_WEIGHT ");

                    sbQuery.Append(" ,SP.MAT_SPEC AS PART_SPEC");
                    sbQuery.Append(" ,SP.MAT_SPEC1 AS PART_SPEC1 ");
                    sbQuery.Append(" ,TW.PART_QTY ");
                    sbQuery.Append(" ,TW.PART_QTY AS QTY ");
                    sbQuery.Append(" ,TW.PROC_CODE  ");
                    //sbQuery.Append(" ,SPR.PROC_UC AS UNIT_COST");
                    sbQuery.Append(" ,SPR.PROC_COST AS UNIT_COST");
                    //sbQuery.Append(" ,(ISNULL(TW.PART_QTY, 1) * ISNULL( SPR.PROC_UC, 1)) AS AMT ");
                    //sbQuery.Append(" ,(ISNULL(TW.PART_QTY, 1) * ISNULL( ROUND(SPR.PROC_UC, 0) , 1)) AS AMT ");
                    //PROC_COST
                    sbQuery.Append(" ,(ISNULL(TW.PART_QTY, 1) * ISNULL( ROUND(SPR.PROC_COST, 0) , 1)) AS AMT ");
                    sbQuery.Append(" ,PRC.PROC_NAME  ");
                    sbQuery.Append(" ,PRC.MAIN_VND  ");
                    sbQuery.Append(" ,M.VEN_CODE    ");
                    sbQuery.Append(" ,PRC.BAL_DISP ");
                    sbQuery.Append(" ,SPR.SCOMMENT ");
                    sbQuery.Append(" ,SPR.PUR_SCOMMENT ");
                    sbQuery.Append(" FROM  ");

                    sbQuery.Append(" TSHP_WORKORDER TW ");
                    sbQuery.Append(" JOIN TORD_PRODUCT P  ");
                    sbQuery.Append(" ON TW.PLT_CODE = P.PLT_CODE  ");
                    sbQuery.Append(" AND TW.PROD_CODE = P.PROD_CODE  ");
                    sbQuery.Append(" AND TW.PART_CODE = P.PART_CODE ");

                    sbQuery.Append(" JOIN TORD_ITEM I  ");
                    sbQuery.Append(" ON P.PLT_CODE = I.PLT_CODE  ");
                    sbQuery.Append(" AND P.ITEM_CODE = I.ITEM_CODE  ");

                    sbQuery.Append(" JOIN LSE_STD_PART SP  ");
                    sbQuery.Append(" ON P.PLT_CODE = SP.PLT_CODE  ");
                    sbQuery.Append(" AND P.PART_CODE = SP.PART_CODE  ");

                    sbQuery.Append(" JOIN LSE_STD_PROC PRC  ");
                    sbQuery.Append(" ON TW.PLT_CODE = PRC.PLT_CODE   ");
                    sbQuery.Append(" AND TW.PROC_CODE = PRC.PROC_CODE  ");

                    sbQuery.Append(" LEFT JOIN TMAT_QUC_MASTER Q  ");
                    sbQuery.Append(" ON SP.PLT_CODE = Q.PLT_CODE   ");
                    sbQuery.Append(" AND SP.MAT_QLTY = Q.MQLTY_CODE  ");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PARTPROC SPR ");
                    sbQuery.Append("   ON TW.PLT_CODE = SPR.PLT_CODE ");
                    sbQuery.Append("  AND TW.PART_CODE = SPR.PART_CODE ");
                    sbQuery.Append("  AND TW.PROC_CODE = SPR.PROC_CODE ");

                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR CV  ");
                    sbQuery.Append(" ON I.PLT_CODE = CV.PLT_CODE   ");
                    sbQuery.Append(" AND I.CVND_CODE = CV.VEN_CODE ");

                    sbQuery.Append(" LEFT JOIN LSE_MACHINE M  ");
                    sbQuery.Append(" ON TW.PLT_CODE = M.PLT_CODE   ");
                    sbQuery.Append(" AND TW.MC_CODE = M.MC_CODE  ");

                    

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE TW.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", " TW.PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@ITEM_CODE", " I.ITEM_CODE = @ITEM_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PLN_START_TIME,@PLN_END_TIME", "TW.PLN_START_TIME BETWEEN @PLN_START_TIME + '0000' AND @PLN_END_TIME + '9999'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PLN_START_TIME,@PLN_END_TIME", "TW.PLN_END_TIME BETWEEN @PLN_START_TIME + '0000' AND @PLN_END_TIME + '9999'"));
                        
                        sbWhere.Append(" AND TW.DATA_FLAG = 0 AND TW.WO_FLAG = '1' AND PRC.IS_OS = 1");
                        //sbWhere.Append(" AND TW.DATA_FLAG = 0 AND TW.WO_FLAG IN ('0','1','2','3') AND PRC.IS_OS = 1");

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

        public static DataTable TOUT_REQUEST_QUERY5_1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT  ");
                    sbQuery.Append(" TW.PLT_CODE  ");
                    sbQuery.Append(" ,TW.WO_NO ");

                    sbQuery.Append(" ,I.CVND_CODE  ");
                    sbQuery.Append(" ,CV.VEN_NAME AS CVND_NAME  ");

                    sbQuery.Append(" ,I.ITEM_CODE  ");
                    sbQuery.Append(" ,I.ITEM_NAME  ");
                    sbQuery.Append(" ,P.PROD_CODE  ");
                    sbQuery.Append(" ,P.PROD_NAME  ");
                    sbQuery.Append(" ,P.PART_CODE  ");
                    sbQuery.Append(" ,SP.DRAW_NO ");
                    sbQuery.Append(" ,SP.PART_NAME ");
                    sbQuery.Append(" ,SP.MAT_TYPE  ");
                    sbQuery.Append(" ,SP.MAT_LTYPE  ");
                    sbQuery.Append(" ,SP.MAT_MTYPE  ");
                    sbQuery.Append(" ,SP.MAT_STYPE  ");
                    sbQuery.Append(" ,SP.PART_PRODTYPE ");
                    sbQuery.Append(" ,SP.MAT_QLTY AS PART_QLTY");
                    sbQuery.Append(" ,Q.MQLTY_NAME AS PART_QLTY_NAME  ");

                    sbQuery.Append(" ,SP.MAT_SPEC1 ");
                    sbQuery.Append(" ,SP.MAT_SPEC ");
                    sbQuery.Append(" ,SP.BAL_SPEC ");
                    sbQuery.Append(" ,SP.MAT_WEIGHT1 ");
                    sbQuery.Append(" ,SP.MAT_WEIGHT ");
                    sbQuery.Append(" ,SP.BAL_WEIGHT ");

                    sbQuery.Append(" ,SP.MAT_SPEC AS PART_SPEC");
                    sbQuery.Append(" ,SP.MAT_SPEC1 AS PART_SPEC1 ");
                    sbQuery.Append(" ,TW.PART_QTY AS ALL_QTY");
                    sbQuery.Append(" ,TW.PART_QTY - ISNULL(WO.SUM_QTY,0) AS QTY");
                    sbQuery.Append(" ,TW.PART_QTY - ISNULL(WO.SUM_QTY,0) AS REMAIN_QTY");
                    sbQuery.Append(" ,WO.SUM_QTY");
                    sbQuery.Append(" ,TW.PROC_CODE  ");
                    //sbQuery.Append(" ,SPR.PROC_UC AS UNIT_COST");
                    sbQuery.Append(" ,SPR.PROC_COST AS UNIT_COST");
                    //sbQuery.Append(" ,(ISNULL(TW.PART_QTY, 1) * ISNULL( SPR.PROC_UC, 1)) AS AMT ");
                    //sbQuery.Append(" ,(ISNULL(TW.PART_QTY, 1) * ISNULL( ROUND(SPR.PROC_UC, 0) , 1)) AS AMT ");
                    //PROC_COST
                    sbQuery.Append(" ,((ISNULL(TW.PART_QTY, 1) - ISNULL(WO.SUM_QTY,0)) * ISNULL( ROUND(SPR.PROC_COST, 0) , 1)) AS AMT ");
                    sbQuery.Append(" ,PRC.PROC_NAME  ");
                    sbQuery.Append(" ,PRC.MAIN_VND  ");
                    sbQuery.Append(" ,M.VEN_CODE    ");
                    sbQuery.Append(" ,PRC.BAL_DISP ");
                    sbQuery.Append(" ,SPR.SCOMMENT ");
                    sbQuery.Append(" ,SPR.PUR_SCOMMENT ");
                    sbQuery.Append(" FROM  ");

                    sbQuery.Append(" TSHP_WORKORDER TW ");
                    sbQuery.Append(" JOIN TORD_PRODUCT P  ");
                    sbQuery.Append(" ON TW.PLT_CODE = P.PLT_CODE  ");
                    sbQuery.Append(" AND TW.PROD_CODE = P.PROD_CODE  ");
                    sbQuery.Append(" AND TW.PART_CODE = P.PART_CODE ");

                    sbQuery.Append(" JOIN TORD_ITEM I  ");
                    sbQuery.Append(" ON P.PLT_CODE = I.PLT_CODE  ");
                    sbQuery.Append(" AND P.ITEM_CODE = I.ITEM_CODE  ");

                    sbQuery.Append(" JOIN LSE_STD_PART SP  ");
                    sbQuery.Append(" ON P.PLT_CODE = SP.PLT_CODE  ");
                    sbQuery.Append(" AND P.PART_CODE = SP.PART_CODE  ");

                    sbQuery.Append(" JOIN LSE_STD_PROC PRC  ");
                    sbQuery.Append(" ON TW.PLT_CODE = PRC.PLT_CODE   ");
                    sbQuery.Append(" AND TW.PROC_CODE = PRC.PROC_CODE  ");

                    sbQuery.Append(" LEFT JOIN TMAT_QUC_MASTER Q  ");
                    sbQuery.Append(" ON SP.PLT_CODE = Q.PLT_CODE   ");
                    sbQuery.Append(" AND SP.MAT_QLTY = Q.MQLTY_CODE  ");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PARTPROC SPR ");
                    sbQuery.Append("   ON TW.PLT_CODE = SPR.PLT_CODE ");
                    sbQuery.Append("  AND TW.PART_CODE = SPR.PART_CODE ");
                    sbQuery.Append("  AND TW.PROC_CODE = SPR.PROC_CODE ");

                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR CV  ");
                    sbQuery.Append(" ON I.PLT_CODE = CV.PLT_CODE   ");
                    sbQuery.Append(" AND I.CVND_CODE = CV.VEN_CODE ");

                    sbQuery.Append(" LEFT JOIN LSE_MACHINE M  ");
                    sbQuery.Append(" ON TW.PLT_CODE = M.PLT_CODE   ");
                    sbQuery.Append(" AND TW.MC_CODE = M.MC_CODE  ");

                    sbQuery.Append(" LEFT JOIN (SELECT B.PLT_CODE	");
                    sbQuery.Append("                 , R.WO_NO   ");
                    sbQuery.Append("                 , SUM(ISNULL(B.QTY,0)) AS SUM_QTY   ");
                    sbQuery.Append("              FROM TOUT_PROCBALJU B 		 ");
                    sbQuery.Append("                JOIN TOUT_PROCBALJU_MASTER BM 	 ");
                    sbQuery.Append("                    ON B.PLT_CODE = BM.PLT_CODE   ");
                    sbQuery.Append("                    AND B.BALJU_NUM = BM.BALJU_NUM   ");
                    sbQuery.Append("                JOIN TOUT_REQUEST R      ");
                    sbQuery.Append("                    ON B.PLT_CODE = R.PLT_CODE 	");
                    sbQuery.Append("                    AND B.REQUEST_NO = R.REQUEST_NO   ");
                    sbQuery.Append("                    AND B.REQUEST_SEQ = R.REQUEST_SEQ   ");
                    sbQuery.Append("               WHERE B.BAL_STAT <> '14'	");
                    sbQuery.Append("              GROUP BY B.PLT_CODE, R.WO_NO)	AS WO ");
                    sbQuery.Append(" ON TW.PLT_CODE = WO.PLT_CODE   ");
                    sbQuery.Append(" AND TW.WO_NO = WO.WO_NO  ");





                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE TW.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", " TW.PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@ITEM_CODE", " I.ITEM_CODE = @ITEM_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PLN_START_TIME,@PLN_END_TIME", "TW.PLN_START_TIME BETWEEN @PLN_START_TIME + '0000' AND @PLN_END_TIME + '9999'"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PLN_START_TIME,@PLN_END_TIME", "TW.PLN_END_TIME BETWEEN @PLN_START_TIME + '0000' AND @PLN_END_TIME + '9999'"));

                        //sbWhere.Append(" AND TW.DATA_FLAG = 0 AND TW.WO_FLAG = '1' AND PRC.IS_OS = 1");
                        sbWhere.Append(" AND TW.DATA_FLAG = 0 AND TW.WO_FLAG IN ('0','1','2','3') AND PRC.IS_OS = 1");
                        sbWhere.Append(" AND TW.PART_QTY > ISNULL(WO.SUM_QTY,0)");
                        sbWhere.Append(" AND P.PROD_STATE <> 'SH'");

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

        public static DataTable TOUT_REQUEST_QUERY8(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT R.PLT_CODE                    ");
                    sbQuery.Append(" ,R.REQUEST_NO	                      ");
                    sbQuery.Append(" ,R.REQUEST_SEQ	                      ");
                    sbQuery.Append(" ,R.PROC_CODE	                      ");
                    sbQuery.Append(" ,R.WO_NO		                      ");
                    sbQuery.Append(" ,W.PROD_CODE						  ");
                    sbQuery.Append(" ,W.PART_ID							  ");
                    sbQuery.Append(" ,W.PROC_ID							  ");
                    sbQuery.Append(" ,R.QTY								  ");
                    sbQuery.Append(" ,R.REQ_STAT						  ");
                    sbQuery.Append(" ,R.C_REASON						  ");
                    sbQuery.Append(" ,R.REG_DATE						  ");
                    sbQuery.Append(" ,R.REG_EMP							  ");
                    sbQuery.Append(" ,R.MDFY_DATE						  ");
                    sbQuery.Append(" ,R.MDFY_EMP						  ");
                    sbQuery.Append(" ,PR.WO_DEFAULT_OSMC				  ");
                    sbQuery.Append(" ,OSMC.MAIN_EMP AS WO_DEFAULT_OSMC_EMP");
                    sbQuery.Append(" FROM TOUT_REQUEST R				  ");
                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER W			  ");
                    sbQuery.Append(" ON R.PLT_CODE = W.PLT_CODE			  ");
                    sbQuery.Append(" AND R.WO_NO = W.WO_NO				  ");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC PR			  ");
                    sbQuery.Append(" ON R.PLT_CODE = PR.PLT_CODE		  ");
                    sbQuery.Append(" AND R.PROC_CODE = PR.PROC_CODE		  ");
                    sbQuery.Append(" LEFT JOIN LSE_MACHINE OSMC			  ");
                    sbQuery.Append(" ON PR.PLT_CODE = OSMC.PLT_CODE		  ");
                    sbQuery.Append(" AND PR.WO_DEFAULT_OSMC = OSMC.MC_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE R.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());
                        sbWhere.Append(UTIL.GetWhere(row, "@REQUEST_NO", " R.REQUEST_NO = @REQUEST_NO"));
                        sbWhere.Append(UTIL.GetWhere(row, "@REQUEST_SEQ", " R.REQUEST_SEQ = @REQUEST_SEQ"));
                        sbWhere.Append(UTIL.GetWhere(row, "@REQ_STAT", " R.REQ_STAT = @REQ_STAT                             "));


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

        //공정외주신청현황
        public static DataTable TOUT_REQUEST_QUERY11(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT							 ");
                    sbQuery.Append(" R.REQUEST_NO					 ");
                    sbQuery.Append(" ,REQ_DATE 						 ");
                    sbQuery.Append(" ,DUE_DATE 						 ");
                    sbQuery.Append(" ,R.PART_CODE					 ");
                    sbQuery.Append(" ,SP.PART_NAME					 ");
                    sbQuery.Append(" ,SP.DRAW_NO					 ");
                    sbQuery.Append(" ,SP.MAT_SPEC					 ");
                    sbQuery.Append(" ,SP.MAT_UNIT					 ");
                    sbQuery.Append(" ,R.QTY							 ");
                    sbQuery.Append(" FROM TOUT_REQUEST R			 ");
                    sbQuery.Append(" LEFT JOIN TOUT_REQUEST_MASTER RM");
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

        
    }
}
