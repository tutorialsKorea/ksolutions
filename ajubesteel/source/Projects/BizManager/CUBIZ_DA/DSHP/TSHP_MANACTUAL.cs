using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSHP
{
    public class TSHP_MANACTUAL
    {
        public static DataTable TSHP_MANACTUAL_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT   PLT_CODE");
                    sbQuery.Append(" , ACTUAL_ID");
                    sbQuery.Append(" , EMP_CODE");
                    sbQuery.Append(" , WORK_DATE");
                    sbQuery.Append(" , PROD_CODE");
                    sbQuery.Append(" , PT_ID");
                    sbQuery.Append(" , PROC_CODE");
                    sbQuery.Append(" , MC_CODE");
                    sbQuery.Append(" , PROC_STAT");
                    sbQuery.Append(" , ACT_START_TIME");
                    sbQuery.Append(" , ACT_END_TIME");
                    sbQuery.Append(" , SELF_TIME");
                    sbQuery.Append(" , MAN_TIME");
                    sbQuery.Append(" , OT_TIME");
                    sbQuery.Append(" , OK_QTY");
                    sbQuery.Append(" , NG_QTY");
                    sbQuery.Append(" , IS_MPROC_ACT");
                    sbQuery.Append(" , SCOMMENT");
                    sbQuery.Append(" , STK_ID");
                    sbQuery.Append(" , REG_DATE");
                    sbQuery.Append(" , REG_EMP");
                    sbQuery.Append(" , MDFY_DATE");
                    sbQuery.Append(" , MDFY_EMP");
                    sbQuery.Append(" , DEL_DATE");
                    sbQuery.Append(" , DEL_EMP");
                    sbQuery.Append(" , DATA_FLAG");
                    sbQuery.Append(" FROM TSHP_MANACTUAL");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND ACTUAL_ID = @ACTUAL_ID");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "ACTUAL_ID")) isHasColumn = false;

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
            catch(Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static void TSHP_MANACTUAL_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO TSHP_MANACTUAL");
                    sbQuery.Append(" (PLT_CODE");
                    sbQuery.Append(" ,ACTUAL_ID");
                    sbQuery.Append(" ,EMP_CODE");
                    sbQuery.Append(" ,WORK_DATE");
                    sbQuery.Append(" ,PROD_CODE");
                    sbQuery.Append(" ,PART_CODE");
                    sbQuery.Append(" ,PROC_CODE");
                    sbQuery.Append(" ,MC_CODE");
                    sbQuery.Append(" ,IS_LAST");
                    sbQuery.Append(" ,PROC_STAT");
                    sbQuery.Append(" ,ACT_START_TIME");
                    sbQuery.Append(" ,ACT_END_TIME");
                    sbQuery.Append(" ,SELF_TIME");
                    sbQuery.Append(" ,MAN_TIME");
                    sbQuery.Append(" ,OT_TIME");
                    sbQuery.Append(" ,OK_QTY");
                    sbQuery.Append(" ,NG_QTY");
                    sbQuery.Append(" ,IS_MPROC_ACT");
                    sbQuery.Append(" ,SCOMMENT");
                    sbQuery.Append(" ,REG_DATE");
                    sbQuery.Append(" ,REG_EMP");
                    sbQuery.Append(" ,DATA_FLAG)");
                    sbQuery.Append(" VALUES");
                    sbQuery.Append(" (@PLT_CODE");
                    sbQuery.Append(" ,@ACTUAL_ID");
                    sbQuery.Append(" ,@EMP_CODE");
                    sbQuery.Append(" ,@WORK_DATE");
                    sbQuery.Append(" ,@PROD_CODE");
                    sbQuery.Append(" ,@PART_CODE");
                    sbQuery.Append(" ,@PROC_CODE");
                    sbQuery.Append(" ,@MC_CODE");
                    sbQuery.Append(" ,@IS_LAST");
                    sbQuery.Append(" ,@PROC_STAT");
                    sbQuery.Append(" ,@ACT_START_TIME");
                    sbQuery.Append(" ,@ACT_END_TIME");
                    sbQuery.Append(" ,@SELF_TIME");
                    sbQuery.Append(" ,@MAN_TIME");
                    sbQuery.Append(" ,@OT_TIME");
                    sbQuery.Append(" ,@OK_QTY");
                    sbQuery.Append(" ,@NG_QTY");
                    sbQuery.Append(" ,@IS_MPROC_ACT");
                    sbQuery.Append(" ,NULL");
                    sbQuery.Append(" ,GETDATE()");
                    sbQuery.Append(" ,@REG_EMP");
                    sbQuery.Append(" ,0)");

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

        public static void TSHP_MANACTUAL_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_MANACTUAL");
                    sbQuery.Append(" SET   EMP_CODE = @EMP_CODE");
                    sbQuery.Append(" , WORK_DATE = @WORK_DATE");
                    sbQuery.Append(" , PROD_CODE = @PROD_CODE");
                    //sbQuery.Append(" , PT_ID = @PT_ID");
                    sbQuery.Append(" , PROC_CODE = @PROC_CODE");
                    sbQuery.Append(" , MC_CODE = @MC_CODE");
                    sbQuery.Append(" , PROC_STAT = @PROC_STAT");
                    sbQuery.Append(" , ACT_START_TIME = @ACT_START_TIME");
                    sbQuery.Append(" , ACT_END_TIME = @ACT_END_TIME");
                    sbQuery.Append(" , SELF_TIME = @SELF_TIME");
                    sbQuery.Append(" , MAN_TIME = @MAN_TIME");
                    sbQuery.Append(" , OT_TIME = @OT_TIME");
                    sbQuery.Append(" , OK_QTY = @OK_QTY");
                    sbQuery.Append(" , NG_QTY = @NG_QTY");
                    sbQuery.Append(" , SCOMMENT = @SCOMMENT");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()");
                    sbQuery.Append(" , MDFY_EMP =" + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , DATA_FLAG = @DATA_FLAG");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND ACTUAL_ID = @ACTUAL_ID");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "ACTUAL_ID")) isHasColumn = false;

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

        public static void TSHP_MANACTUAL_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_MANACTUAL ");
                    sbQuery.Append(" SET  NG_QTY = @NG_QTY ");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append("   AND ACTUAL_ID = @ACTUAL_ID");

                    foreach (DataRow dr in dtParam.Rows)
                    {
                        bizExecute.executeUpdateQuery(sbQuery.ToString(), dr);
                    }
                }

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static void TSHP_MANACTUAL_UPD6(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_MANACTUAL");
                    sbQuery.Append(" SET  STK_ID = @STK_ID");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append("   AND ACTUAL_ID = @ACTUAL_ID");

                    foreach (DataRow dr in dtParam.Rows)
                    {
                        bizExecute.executeUpdateQuery(sbQuery.ToString(), dr);
                    }
                }

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static void TSHP_MANACTUAL_UPD7(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_MANACTUAL");
                    sbQuery.Append(" SET  STK_ID = NULL");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append("   AND ACTUAL_ID = @ACTUAL_ID");

                    foreach (DataRow dr in dtParam.Rows)
                    {
                        bizExecute.executeUpdateQuery(sbQuery.ToString(), dr);
                    }
                }

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static void TSHP_MANACTUAL_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSHP_MANACTUAL");
                    sbQuery.Append(" SET   DEL_DATE = GETDATE()");
                    sbQuery.Append(" , DEL_EMP =" + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , DATA_FLAG = @DATA_FLAG");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND ACTUAL_ID = @ACTUAL_ID");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "ACTUAL_ID")) isHasColumn = false;

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

    public class TSHP_MANACTUAL_QUERY
    {

        public static DataTable TSHP_MANACTUAL_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT");
                    sbQuery.Append(" M.PLT_CODE");
                    sbQuery.Append(" ,M.EMP_CODE");
                    sbQuery.Append(" ,E.EMP_NAME");
                    sbQuery.Append(" ,WORK_DATE");
                    sbQuery.Append(" ,M.PART_CODE");
                    sbQuery.Append(" ,PT.PART_NAME");
                    sbQuery.Append(" ,PT.MAT_SPEC");
                    sbQuery.Append(" ,PT.STD_PT_NUM");
                    sbQuery.Append(" ,M.PROC_CODE");
                    sbQuery.Append(" ,RR.PROC_NAME");
                    sbQuery.Append(" ,M.MC_CODE");
                    sbQuery.Append(" ,MC.MC_NAME");
                    sbQuery.Append(" ,ACT_START_TIME");
                    sbQuery.Append(" ,ACT_END_TIME");
                    sbQuery.Append(" ,OK_QTY");
                    sbQuery.Append(" ,NG_QTY");
                    sbQuery.Append(" FROM TSHP_MANACTUAL M");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC RR");
                    sbQuery.Append(" ON M.PLT_CODE = RR.PLT_CODE");
                    sbQuery.Append(" AND M.PROC_CODE = RR.PROC_CODE");
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART PT");
                    sbQuery.Append(" ON M.PLT_CODE = PT.PLT_CODE");
                    sbQuery.Append(" AND M.PART_CODE = PT.PART_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE E");
                    sbQuery.Append(" ON M.PLT_CODE = E.PLT_CODE");
                    sbQuery.Append(" AND M.EMP_CODE = E.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN LSE_MACHINE MC");
                    sbQuery.Append(" ON M.PLT_CODE = MC.PLT_CODE");
                    sbQuery.Append(" AND M.MC_CODE = MC.MC_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE M.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@MC_CODE", "M.MC_CODE = @MC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "M.PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@W_DATE", "DATEPART(WK,WORK_DATE) = @W_DATE "));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "M.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(" ORDER BY M.WORK_DATE DESC");

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(), row).Copy();

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


        public static DataTable TSHP_MANACTUAL_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT M.PLT_CODE");
                    sbQuery.Append(" ,M.ACTUAL_ID");
                    sbQuery.Append(" ,M.EMP_CODE");
                    sbQuery.Append(" ,EMP.EMP_NAME");
                    sbQuery.Append(" ,M.WORK_DATE");
                    sbQuery.Append(" ,M.PROD_CODE");
                    sbQuery.Append(" ,P.PROD_NAME");
                    sbQuery.Append(" ,M.PT_ID");
                    sbQuery.Append(" ,SPT.PART_CODE");
                    sbQuery.Append(" ,SPT.PART_NAME");
                    sbQuery.Append(" ,SPT.MAT_SPEC");
                    sbQuery.Append(" ,SPT.STD_PT_NUM");
                    sbQuery.Append(" ,PT.PT_NAME");
                    sbQuery.Append(" ,PT.PART_NUM");
                    sbQuery.Append(" ,M.PROC_CODE");
                    sbQuery.Append(" ,PC.PROC_NAME");
                    sbQuery.Append(" ,M.MC_CODE");
                    sbQuery.Append(" ,MC.MC_NAME");
                    sbQuery.Append(" ,M.ACT_START_TIME");
                    sbQuery.Append(" ,M.ACT_END_TIME");
                    sbQuery.Append(" ,M.PROC_STAT");
                    sbQuery.Append(" ,M.SELF_TIME");
                    sbQuery.Append(" ,M.MAN_TIME");
                    sbQuery.Append(" ,M.OT_TIME");
                    sbQuery.Append(" ,(M.SELF_TIME + M.MAN_TIME + M.OT_TIME) AS WORK_TIME");
                    sbQuery.Append(" ,M.SCOMMENT");
                    sbQuery.Append(" ,M.OK_QTY");
                    sbQuery.Append(" ,M.NG_QTY");
                    sbQuery.Append(" ,(M.OK_QTY + M.NG_QTY) AS WORK_QTY");
                    sbQuery.Append(" ,M.REG_DATE");
                    sbQuery.Append(" ,M.REG_EMP");
                    sbQuery.Append(" ,REG.EMP_NAME AS REG_EMP_NAME");
                    sbQuery.Append(" ,M.MDFY_DATE");
                    sbQuery.Append(" ,M.MDFY_EMP");
                    sbQuery.Append(" ,MDFY.EMP_NAME AS MDFY_EMP_NAME");
                    sbQuery.Append(" FROM TSHP_MANACTUAL M");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P ");
                    sbQuery.Append(" ON M.PLT_CODE = P.PLT_CODE");
                    sbQuery.Append(" AND M.PROD_CODE = P.PROD_CODE");
                    
                    sbQuery.Append(" LEFT JOIN TMAT_PARTLIST PT");
                    sbQuery.Append(" ON M.PLT_CODE = PT.PLT_CODE");
                    sbQuery.Append(" AND M.PT_ID = PT.PT_ID");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SPT");
                    sbQuery.Append(" ON M.PLT_CODE = SPT.PLT_CODE");
                    sbQuery.Append(" AND M.PART_CODE = SPT.PART_CODE");
                    
                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC PC");
                    sbQuery.Append(" ON M.PLT_CODE = PC.PLT_CODE");
                    sbQuery.Append(" AND M.PROC_CODE = PC.PROC_CODE");
                    
                    sbQuery.Append(" LEFT JOIN LSE_MACHINE MC");
                    sbQuery.Append(" ON M.PLT_CODE = MC.PLT_CODE");
                    sbQuery.Append(" AND M.MC_CODE = MC.MC_CODE");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE EMP");
                    sbQuery.Append(" ON M.PLT_CODE = EMP.PLT_CODE");
                    sbQuery.Append(" AND M.EMP_CODE = EMP.EMP_CODE");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG");
                    sbQuery.Append(" ON M.PLT_CODE = REG.PLT_CODE");
                    sbQuery.Append(" AND M.REG_EMP = REG.EMP_CODE");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY");
                    sbQuery.Append(" ON M.PLT_CODE = MDFY.PLT_CODE");
                    sbQuery.Append(" AND M.MDFY_EMP = MDFY.EMP_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE M.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@ACTUAL_ID", "M.ACTUAL_ID = @ACTUAL_ID"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "M.PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROC_CODE", "M.PROC_CODE = @PROC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_WORK_DATE,@E_WORK_DATE", "(M.WORK_DATE BETWEEN @S_WORK_DATE AND @E_WORK_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@ORG_CODE", "EMP.ORG_CODE = @ORG_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@EMP_CODE", "M.EMP_CODE = @EMP_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", "SPT.PART_CODE = @PART_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_MPROC_ACT", "M.IS_MPROC_ACT = @IS_MPROC_ACT"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "M.DATA_FLAG = @DATA_FLAG"));

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(), row).Copy();

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
