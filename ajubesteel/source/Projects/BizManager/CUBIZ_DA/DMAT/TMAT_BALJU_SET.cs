using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DMAT
{
    public class TMAT_BALJU_SET
    {

        public static DataTable TMAT_BALJU_SET_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,SET_EMP ");
                    sbQuery.Append(" ,INCL_VAT ");
                    sbQuery.Append(" ,SPLIT ");
                    sbQuery.Append(" ,DELIVERY_LOCATION ");
                    sbQuery.Append(" ,PAY_CONDITION ");
                    sbQuery.Append(" ,YPGO_CHARGE ");
                    sbQuery.Append(" ,CHK_MEASURE ");
                    sbQuery.Append(" ,CHK_PERFORM ");
                    sbQuery.Append(" ,CHK_ATTEND ");
                    sbQuery.Append(" ,CHK_TEST ");
                    sbQuery.Append(" ,CHK_MEEL ");
                    sbQuery.Append(" ,CHK_ADD1 ");
                    sbQuery.Append(" ,CHK_ADD2 ");
                    sbQuery.Append(" ,CHK_ADD3 ");
                    sbQuery.Append(" ,CHARGE_EMP ");
                    sbQuery.Append(" ,CHARGE_PHONE ");
                    sbQuery.Append(" ,CHARGE_EMAIL ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,MDFY_DATE ");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append("  FROM TMAT_BALJU_SET  ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND SET_ID = @SET_ID  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "SET_ID")) isHasColumn = false;

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

        public static void TMAT_BALJU_SET_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TMAT_BALJU_SET (  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,SET_ID ");
                    sbQuery.Append(" ,SET_EMP ");
                    sbQuery.Append(" ,INCL_VAT ");
                    sbQuery.Append(" ,SPLIT ");
                    sbQuery.Append(" ,DELIVERY_LOCATION ");
                    sbQuery.Append(" ,PAY_CONDITION ");
                    sbQuery.Append(" ,YPGO_CHARGE ");
                    sbQuery.Append(" ,CHK_MEASURE ");
                    sbQuery.Append(" ,CHK_PERFORM ");
                    sbQuery.Append(" ,CHK_ATTEND ");
                    sbQuery.Append(" ,CHK_TEST ");
                    sbQuery.Append(" ,CHK_MEEL ");
                    sbQuery.Append(" ,CHK_ADD1 ");
                    sbQuery.Append(" ,CHK_ADD2 ");
                    sbQuery.Append(" ,CHK_ADD3 ");
                    sbQuery.Append(" ,CHARGE_EMP ");
                    sbQuery.Append(" ,CHARGE_PHONE ");
                    sbQuery.Append(" ,CHARGE_EMAIL ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,APP_ORG ");
                    sbQuery.Append(" ,CHK_RD ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,DATA_FLAG ");
                    sbQuery.Append("  ) VALUES (  ");
                    sbQuery.Append("  @PLT_CODE ");
                    sbQuery.Append(" ,@SET_ID ");
                    sbQuery.Append(" ,@SET_EMP ");
                    sbQuery.Append(" ,@INCL_VAT ");
                    sbQuery.Append(" ,@SPLIT ");
                    sbQuery.Append(" ,@DELIVERY_LOCATION ");
                    sbQuery.Append(" ,@PAY_CONDITION ");
                    sbQuery.Append(" ,@YPGO_CHARGE ");
                    sbQuery.Append(" ,@CHK_MEASURE ");
                    sbQuery.Append(" ,@CHK_PERFORM ");
                    sbQuery.Append(" ,@CHK_ATTEND ");
                    sbQuery.Append(" ,@CHK_TEST ");
                    sbQuery.Append(" ,@CHK_MEEL ");
                    sbQuery.Append(" ,@CHK_ADD1 ");
                    sbQuery.Append(" ,@CHK_ADD2 ");
                    sbQuery.Append(" ,@CHK_ADD3 ");
                    sbQuery.Append(" ,@CHARGE_EMP ");
                    sbQuery.Append(" ,@CHARGE_PHONE ");
                    sbQuery.Append(" ,@CHARGE_EMAIL ");
                    sbQuery.Append(" ,@SCOMMENT ");
                    sbQuery.Append(" ,@APP_ORG ");
                    sbQuery.Append(" ,@CHK_RD ");
                    sbQuery.Append(" , GETDATE() ");
                    sbQuery.Append(" ," + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" ,0 ");
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

        public static void TMAT_BALJU_SET_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_BALJU_SET SET  ");
                    sbQuery.Append("  SET_EMP = @SET_EMP ");
                    sbQuery.Append(" ,INCL_VAT = @INCL_VAT ");
                    sbQuery.Append(" ,SPLIT = @SPLIT ");
                    sbQuery.Append(" ,DELIVERY_LOCATION = @DELIVERY_LOCATION ");
                    sbQuery.Append(" ,PAY_CONDITION = @PAY_CONDITION ");
                    sbQuery.Append(" ,YPGO_CHARGE = @YPGO_CHARGE ");
                    sbQuery.Append(" ,CHK_MEASURE = @CHK_MEASURE ");
                    sbQuery.Append(" ,CHK_PERFORM = @CHK_PERFORM ");
                    sbQuery.Append(" ,CHK_ATTEND = @CHK_ATTEND ");
                    sbQuery.Append(" ,CHK_TEST = @CHK_TEST ");
                    sbQuery.Append(" ,CHK_MEEL = @CHK_MEEL ");
                    sbQuery.Append(" ,CHK_ADD1 = @CHK_ADD1 ");
                    sbQuery.Append(" ,CHK_ADD2 = @CHK_ADD2 ");
                    sbQuery.Append(" ,CHK_ADD3 = @CHK_ADD3 ");
                    sbQuery.Append(" ,CHARGE_EMP = @CHARGE_EMP ");
                    sbQuery.Append(" ,CHARGE_PHONE = @CHARGE_PHONE ");
                    sbQuery.Append(" ,CHARGE_EMAIL = @CHARGE_EMAIL ");
                    sbQuery.Append(" ,SCOMMENT = @SCOMMENT ");
                    sbQuery.Append(" ,APP_ORG = @APP_ORG ");
                    sbQuery.Append(" ,CHK_RD = @CHK_RD ");
                    sbQuery.Append(" ,MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" ,MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND SET_ID = @SET_ID ");
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "SET_EMP")) isHasColumn = false;

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


        public static void TMAT_BALJU_SET_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" UPDATE TMAT_BALJU_SET ");
                    sbQuery.Append(" SET DATA_FLAG = 2 ");
                    sbQuery.Append(" , DEL_DATE = GETDATE() ");
                    sbQuery.Append(" , DEL_EMP = @SET_EMP ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND SET_ID = @SET_ID ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "SET_ID")) isHasColumn = false;

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


    public class TMAT_BALJU_SET_QUERY
    {
        
        public static DataTable TMAT_BALJU_SET_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT  ");
                    sbQuery.Append("  PLT_CODE ");
                    sbQuery.Append(" ,SET_ID ");
                    sbQuery.Append(" ,SET_EMP ");
                    sbQuery.Append(" ,INCL_VAT ");
                    sbQuery.Append(" ,SPLIT ");
                    sbQuery.Append(" ,DELIVERY_LOCATION ");
                    sbQuery.Append(" ,PAY_CONDITION ");
                    sbQuery.Append(" ,YPGO_CHARGE ");
                    sbQuery.Append(" ,CHK_MEASURE ");
                    sbQuery.Append(" ,CHK_PERFORM ");
                    sbQuery.Append(" ,CHK_ATTEND ");
                    sbQuery.Append(" ,CHK_TEST ");
                    sbQuery.Append(" ,CHK_MEEL ");
                    sbQuery.Append(" ,CHK_ADD1 ");
                    sbQuery.Append(" ,CHK_ADD2 ");
                    sbQuery.Append(" ,CHK_ADD3 ");
                    sbQuery.Append(" ,CHARGE_EMP ");
                    sbQuery.Append(" ,CHARGE_PHONE ");
                    sbQuery.Append(" ,CHARGE_EMAIL ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,APP_ORG ");
                    sbQuery.Append(" ,CHK_RD ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP ");
                    sbQuery.Append(" ,MDFY_DATE ");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append("  FROM TMAT_BALJU_SET  ");
                    
                    foreach (DataRow row in dtParam.Rows)
                    {
                        
                        StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", " DATA_FLAG = @DATA_FLAG "));
                        sbWhere.Append(UTIL.GetWhere(row, "@SET_EMP", " SET_EMP = @SET_EMP "));

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
