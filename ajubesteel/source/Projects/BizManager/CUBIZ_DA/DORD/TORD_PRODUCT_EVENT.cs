using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizExecute;
using System.Data;

namespace DORD
{
    public class TORD_PRODUCT_EVENT
    {
        public static DataTable TORD_PRODUCT_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("         SELECT   PLT_CODE ");
                    sbQuery.Append("       , PROD_CODE ");
                    sbQuery.Append("       , CREATE_TYPE ");
                    sbQuery.Append("       , ITEM_CODE ");
                    sbQuery.Append("       , PRJ_CODE ");
                    sbQuery.Append("       , PROD_NAME ");
                    sbQuery.Append("       , PROD_TYPE ");
                    sbQuery.Append("       , ORD_DATE ");
                    sbQuery.Append("       , INDUE_DATE ");
                    sbQuery.Append("       , DUE_DATE ");
                    sbQuery.Append("       , END_DATE ");
                    sbQuery.Append("       , PROD_PRIORITY ");
                    sbQuery.Append("       , PROD_INSCHED ");
                    sbQuery.Append("       , PROD_QTY ");
                    sbQuery.Append("       , PROD_MANAGER ");
                    sbQuery.Append("       , ROOT_PART_ID ");
                    sbQuery.Append("       , LOCK_ID ");
                    sbQuery.Append("       , LOCK_FLAG ");
                    sbQuery.Append("       , LOAD_FLAG ");
                    sbQuery.Append("       , PROD_STATE ");
                    sbQuery.Append("       , INOUT_FLAG ");
                    sbQuery.Append("       , PROD_VND ");
                    sbQuery.Append("       , MASS_PROD_VND ");
                    sbQuery.Append("       , DRAW_EMP ");
                    sbQuery.Append("       , ASSY_EMP ");
                    sbQuery.Append("       , PROD_EST_NO ");
                    sbQuery.Append("       , SCOMMENT ");
                    sbQuery.Append("       , DIFFICULTY ");
                    sbQuery.Append("       , O_PROD_CODE ");
                    sbQuery.Append("       , PROD_UC ");
                    sbQuery.Append("       , PROD_COST ");
                    sbQuery.Append("       , TARGET_PRIMECOST ");
                    sbQuery.Append("       , TARGET_PRIMECOST_TYPE ");
                    sbQuery.Append("       , CONT_OP_NO ");
                    sbQuery.Append("       , STD_BOP ");
                    sbQuery.Append("       , SCH_LIMIT ");
                    sbQuery.Append("       , PROD_CATEGORY ");
                    sbQuery.Append("       , PROD_KIND ");
                    sbQuery.Append("       , PROD_TYPE1 ");
                    sbQuery.Append("       , PROD_TYPE2 ");
                    sbQuery.Append("       , INHERIT_PROD ");
                    sbQuery.Append("       , STD_SMLT_ID ");
                    sbQuery.Append("       , SHIP_ID ");
                    sbQuery.Append("       , CUST_PROD_NAME ");
                    sbQuery.Append("       , INS_FLAG ");
                    sbQuery.Append("       , REG_DATE ");
                    sbQuery.Append("       , REG_EMP ");
                    sbQuery.Append("       , MDFY_DATE ");
                    sbQuery.Append("       , MDFY_EMP ");
                    sbQuery.Append("       , DEL_DATE ");
                    sbQuery.Append("       , DEL_EMP ");
                    sbQuery.Append("       , DATA_FLAG ");
                    sbQuery.Append("  FROM TORD_PRODUCT ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append(" AND PROD_CODE = @PROD_CODE ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
                        //if (!UTIL.ValidColumn(row, "CD_CODE")) isHasColumn = false;

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

        public static void TSTD_CODES_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSTD_CODES ");
                    sbQuery.Append(" SET CAT_CODE = @CAT_CODE");
                    sbQuery.Append(" , CD_CODE = @CD_CODE");
                    sbQuery.Append(" , CD_NAME = @CD_NAME");
                    sbQuery.Append(" , VALUE = @VALUE");
                    sbQuery.Append(" , CD_PARENT = @CD_PARENT");
                    sbQuery.Append(" , CD_SEQ = @CD_SEQ");
                    sbQuery.Append(" , IS_DEFAULT = @IS_DEFAULT");
                    sbQuery.Append(" , SCOMMENT = @SCOMMENT");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , DATA_FLAG = 0");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND CAT_CODE = @CAT_CODE");
                    sbQuery.Append(" AND CD_CODE = @CD_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "CAT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "CD_CODE")) isHasColumn = false;

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

        public static void TORD_PRODUCT_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  UPDATE TORD_PRODUCT");
                    sbQuery.Append("  SET   LOAD_FLAG = @LOAD_FLAG");
                    sbQuery.Append(" , DEL_DATE = @DEL_DATE");
                    sbQuery.Append(" , DEL_EMP = @DEL_EMP");
                    sbQuery.Append(" , DATA_FLAG = @DATA_FLAG");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("   AND PROD_CODE = @PROD_CODE");
                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PROD_CODE")) isHasColumn = false;
                        //if (!UTIL.ValidColumn(row, "CD_CODE")) isHasColumn = false;

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

        public static void TORD_PRODUCT_EVENT_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("INSERT INTO TORD_PRODUCT_EVENT");
                    sbQuery.Append("(");
                    sbQuery.Append("       PLT_CODE");
                    sbQuery.Append("     , PROD_CODE");
                    //sbQuery.Append("     , OLD_PROD_STATE");
                    sbQuery.Append("     , PROD_STATE");
                    //sbQuery.Append("     , STATE_KEY");
                    sbQuery.Append("     , EVENT_DATE");
                    sbQuery.Append("     , REG_EMP");
                    sbQuery.Append(")");
                    sbQuery.Append("VALUES");
                    sbQuery.Append("(");
                    sbQuery.Append("       @PLT_CODE");
                    sbQuery.Append("     , @PROD_CODE");
                    //sbQuery.Append("     , @OLD_PROD_STATE");
                    sbQuery.Append("     , @PROD_STATE");
                    //sbQuery.Append("     , @STATE_KEY");
                    sbQuery.Append(" ,GETDATE()");
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
    }

    public class TORD_PRODUCT_EVENT_QUERY
    {
        public static DataTable TORD_PRODUCT_QUERY19(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();


                    sbQuery.Append(" SELECT A.PLT_CODE,");
                    sbQuery.Append(" A.ITEM_CODE,");
                    sbQuery.Append(" A.PROD_CODE,");
                    sbQuery.Append(" A.PROD_NAME,");
                    sbQuery.Append(" A.PROD_TYPE,");
                    sbQuery.Append(" A.PRJ_CODE,");
                    sbQuery.Append(" PJ.PRJ_NAME AS PRJ_NAME,");
                    sbQuery.Append(" A.PROD_TYPE,");
                    sbQuery.Append(" A.PROD_STATE,");
                    sbQuery.Append(" A.PROD_PRIORITY,");
                    sbQuery.Append(" A.DRAW_EMP,");
                    sbQuery.Append(" C.EMP_NAME AS DRAW_EMP_NAME,");
                    sbQuery.Append(" A.ASSY_EMP,");
                    sbQuery.Append(" D.EMP_NAME AS ASSY_EMP_NAME,");
                    sbQuery.Append(" A.ORD_DATE,");
                    sbQuery.Append(" A.INDUE_DATE,");
                    sbQuery.Append(" ,A.DUE_DATE");
                    sbQuery.Append(" A.LOAD_FLAG,");
                    sbQuery.Append(" A.INOUT_FLAG,");
                    sbQuery.Append(" A.PROD_VND ");
                    sbQuery.Append(" ,E.VEN_NAME AS PROD_VND_NAME,");
                    sbQuery.Append(" A.MASS_PROD_VND ");
                    sbQuery.Append(" ,MS.VEN_NAME AS MASS_PROD_VND_NAME,");
                    sbQuery.Append(" A.DIFFICULTY,");
                    sbQuery.Append(" A.PROD_QTY,");
                    sbQuery.Append(" A.PROD_UC,");
                    sbQuery.Append(" A.PROD_COST,");
                    sbQuery.Append(" A.SCOMMENT,");
                    sbQuery.Append(" A.CONT_OP_NO,");
                    sbQuery.Append(" A.STD_BOP,");
                    sbQuery.Append(" A.SCH_LIMIT,");
                    sbQuery.Append(" A.PROD_CATEGORY,");
                    sbQuery.Append(" A.PROD_KIND,");
                    sbQuery.Append(" A.PROD_TYPE1,");
                    sbQuery.Append(" A.PROD_TYPE2 ,");
                    sbQuery.Append(" A.REG_DATE ,");
                    sbQuery.Append(" A.REG_EMP ,");
                    sbQuery.Append(" ,REG.EMP_NAME AS REG_EMP_NAME ");
                    sbQuery.Append(" A.MDFY_DATE ,");
                    sbQuery.Append(" A.MDFY_EMP ");
                    sbQuery.Append(" ,MDFY.EMP_NAME AS MDFY_EMP_NAME ");
                    sbQuery.Append(" ,A.INHERIT_PROD");
                    sbQuery.Append(" ,A.TARGET_PRIMECOST");
                    sbQuery.Append(" ,A.TARGET_PRIMECOST_TYPE");
                    sbQuery.Append(" ,A.CUST_PROD_NAME");
                    sbQuery.Append(" ,A.SHIP_ID");
                    sbQuery.Append(" ,SH.SHIP_DATE");
                    sbQuery.Append(" ,SH.SHIP_EMP");
                    sbQuery.Append(" ,SHE.EMP_NAME AS SHIP_EMP_NAME");
                    sbQuery.Append(" ,A.INS_FLAG");
                    sbQuery.Append(" ,A.O_PROD_CODE");
                    sbQuery.Append(" ,A.IS_LMPLAN");
                    sbQuery.Append("FROM TORD_PRODUCT A");
                    sbQuery.Append("LEFT JOIN TORD_PROJECT PJ");
                    sbQuery.Append("ON A.PLT_CODE = PJ.PLT_CODE");
                    sbQuery.Append("AND A.PRJ_CODE = PJ.PRJ_CODE");
                    sbQuery.Append("LEFT JOIN TSTD_EMPLOYEE C");
                    sbQuery.Append("ON A.PLT_CODE = C.PLT_CODE ");
                    sbQuery.Append("AND A.DRAW_EMP = C.EMP_CODE");
                    sbQuery.Append("LEFT JOIN TSTD_EMPLOYEE D");
                    sbQuery.Append("ON A.PLT_CODE = D.PLT_CODE ");
                    sbQuery.Append("AND A.ASSY_EMP = D.EMP_CODE");
                    sbQuery.Append("LEFT JOIN TSTD_VENDOR E");
                    sbQuery.Append("ON A.PLT_CODE = E.PLT_CODE");
                    sbQuery.Append("AND A.PROD_VND = E.VEN_CODE");
                    sbQuery.Append("LEFT JOIN TSTD_VENDOR MS");
                    sbQuery.Append("ON A.PLT_CODE = MS.PLT_CODE");
                    sbQuery.Append("AND A.MASS_PROD_VND = MS.VEN_CODE");
                    sbQuery.Append("LEFT JOIN TORD_SHIP SH");
                    sbQuery.Append("ON A.PLT_CODE = SH.PLT_CODE");
                    sbQuery.Append("AND A.SHIP_ID = SH.SHIP_ID");
                    sbQuery.Append("LEFT JOIN TSTD_EMPLOYEE SHE");
                    sbQuery.Append("ON SH.PLT_CODE = SHE.PLT_CODE");
                    sbQuery.Append("AND SH.SHIP_EMP = SHE.EMP_CODE");
                    sbQuery.Append("LEFT JOIN TSTD_EMPLOYEE REG");
                    sbQuery.Append("ON A.PLT_CODE = REG.PLT_CODE ");
                    sbQuery.Append("AND A.REG_EMP = REG.EMP_CODE");
                    sbQuery.Append("LEFT JOIN TSTD_EMPLOYEE MDFY");
                    sbQuery.Append("ON A.PLT_CODE = MDFY.PLT_CODE ");
                    sbQuery.Append("AND A.MDFY_EMP = MDFY.EMP_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE A.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@ITEM_CODE", "A.ITEM_CODE = @ITEM_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "A.PROD_CODE = @PROD_CODE"));
                        //sbWhere.Append(UTIL.GetWhere(row, "", "A.DATA_FLAG = 0"));
                        sbQuery.Append(" AND A.DATA_FLAG = 0");

                        //sbWhere.Append(" ORDER BY CD.CD_SEQ");

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


        public static DataTable TORD_PRODUCT_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {


                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("  SELECT PLT_CODE");
                    sbQuery.Append(" ,PROD_CODE");
                    sbQuery.Append(" ,ITEM_CODE");
                    sbQuery.Append(" ,PRJ_CODE");
                    sbQuery.Append(" ,PROD_NAME");
                    sbQuery.Append(" ,PROD_TYPE");
                    sbQuery.Append(" ,ORD_DATE");
                    sbQuery.Append(" ,INDUE_DATE");
                    sbQuery.Append(" ,DUE_DATE");
                    sbQuery.Append(" ,PROD_PRIORITY");
                    sbQuery.Append(" ,PROD_INSCHED");
                    sbQuery.Append(" ,PROD_QTY");
                    sbQuery.Append(" ,ROOT_PART_ID");
                    sbQuery.Append(" ,LOCK_ID");
                    sbQuery.Append(" ,LOCK_FLAG");
                    sbQuery.Append(" ,LOAD_FLAG");
                    sbQuery.Append(" ,DAILY_MH");
                    sbQuery.Append(" ,PROD_STATE");
                    sbQuery.Append(" ,INOUT_FLAG");
                    sbQuery.Append(" ,PROD_VND");
                    sbQuery.Append(" ,DRAW_EMP");
                    sbQuery.Append(" ,ASSY_EMP");
                    sbQuery.Append(" ,PROD_EST_NO");
                    sbQuery.Append(" ,SCOMMENT");
                    sbQuery.Append(" ,DIFFICULTY");
                    sbQuery.Append(" ,O_PROD_CODE");
                    sbQuery.Append(" ,REG_DATE");
                    sbQuery.Append(" ,REG_EMP");
                    sbQuery.Append(" ,MDFY_DATE");
                    sbQuery.Append(" ,MDFY_EMP");
                    sbQuery.Append(" ,DATA_FLAG");
                    sbQuery.Append(" ,DEL_DATE");
                    sbQuery.Append(" ,DEL_EMP");
                    sbQuery.Append(" ,PROD_UC");
                    sbQuery.Append(" ,PROD_COST");
                    sbQuery.Append(" ,CONT_OP_NO");
                    sbQuery.Append(" ,STD_BOP");
                    sbQuery.Append(" ,SCH_LIMIT");
                    sbQuery.Append(" ,INHERIT_PROD");
                    sbQuery.Append(" FROM TORD_PRODUCT");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@PROD_CODE", "PROD_CODE = @PROD_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@ITEM_CODE", "ITEM_CODE = @ITEM_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@LOAD_FLAG", "LOAD_FLAG = @LOAD_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@INHERIT_PROD", "INHERIT_PROD = @INHERIT_PROD"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_ORD_DATE, @E_ORD_DATE", "(ORD_DATE BETWEEN @S_ORD_DATE AND @E_ORD_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DUE_DATE, @E_DUE_DATE", "(DUE_DATE BETWEEN @S_DUE_DATE AND @E_DUE_DATE)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "DATA_FLAG = @DATA_FLAG"));

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
