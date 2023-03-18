using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSTD
{
    public class TSTD_TOOL
    {
        public static DataTable TSTD_TOOL_SER1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT   PLT_CODE            ");
                    sbQuery.Append("       , TL_CODE             ");
                    sbQuery.Append("       , TL_NAME             ");
                    sbQuery.Append("       , TL_TYPE             ");
                    sbQuery.Append("       , TL_LTYPE            ");
                    sbQuery.Append("       , TL_MTYPE            ");
                    sbQuery.Append("       , TL_STYPE            ");
                    sbQuery.Append("       , TL_SIZE             ");
                    sbQuery.Append("       , SHANK               ");
                    sbQuery.Append("       , CUT_LENGTH          ");
                    sbQuery.Append("       , OVR_LENGTH          ");
                    sbQuery.Append("       , TL_SPEC             ");
                    sbQuery.Append("       , TL_MIN              ");
                    sbQuery.Append("       , TL_MAX              ");
                    sbQuery.Append("       , TL_DANGER_QTY       ");
                    sbQuery.Append("       , TL_MAKER            ");
                    sbQuery.Append("       , TL_UNITCOST         ");
                    sbQuery.Append("       , TL_UNIT             ");
                    sbQuery.Append("       , HOLDER              ");
                    sbQuery.Append("       , TL_LENGTH           ");
                    sbQuery.Append("       , MAIN_VND            ");
                    sbQuery.Append("       , TL_QTY              ");
                    sbQuery.Append("       , TL_D_QTY            ");
                    sbQuery.Append("       , TL_IMAGE            ");
                    sbQuery.Append("       , SCOMMENT            ");
                    sbQuery.Append("       , STD_LIFE            ");
                    sbQuery.Append("       , REG_DATE            ");
                    sbQuery.Append("       , REG_EMP             ");
                    sbQuery.Append("       , MDFY_DATE           ");
                    sbQuery.Append("       , MDFY_EMP            ");
                    sbQuery.Append("       , DEL_DATE            ");
                    sbQuery.Append("       , DEL_EMP             ");
                    sbQuery.Append("       , DEL_REASON	         ");
                    sbQuery.Append("       , DATA_FLAG           ");
                    sbQuery.Append("  FROM TSTD_TOOL              ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE   ");
                    sbQuery.Append("   AND TL_CODE = @TL_CODE     ");
                    sbQuery.Append("   AND DATA_FLAG = 0          ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "TL_CODE")) isHasColumn = false;

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

        public static void TSTD_TOOL_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSTD_TOOL");
                    sbQuery.Append(" SET TL_NAME = @TL_NAME");
                    sbQuery.Append(" , TL_TYPE = @TL_TYPE");
                    sbQuery.Append(" , TL_LTYPE = @TL_LTYPE");
                    sbQuery.Append(" , TL_MTYPE = @TL_MTYPE");
                    sbQuery.Append(" , TL_STYPE = @TL_STYPE");
                    sbQuery.Append(" , TL_SIZE = @TL_SIZE  ");
                    sbQuery.Append(" , SHANK = @SHANK      ");
                    sbQuery.Append(" , CUT_LENGTH = @CUT_LENGTH ");
                    sbQuery.Append(" , OVR_LENGTH = @OVR_LENGTH ");
                    sbQuery.Append(" , TL_SPEC = @TL_SPEC");
                    sbQuery.Append(" , TL_MIN = @TL_MIN");
                    sbQuery.Append(" , TL_MAX = @TL_MAX");
                    sbQuery.Append(" , TL_DANGER_QTY = @TL_DANGER_QTY");
                    sbQuery.Append(" , TL_MAKER = @TL_MAKER");
                    sbQuery.Append(" , TL_UNITCOST = @TL_UNITCOST");
                    sbQuery.Append(" , TL_UNIT = @TL_UNIT");
                    sbQuery.Append(" , HOLDER = @HOLDER");
                    sbQuery.Append(" , TL_LENGTH = @TL_LENGTH");
                    sbQuery.Append(" , MAIN_VND = @MAIN_VND");
                    sbQuery.Append(" , TL_QTY = @TL_QTY");
                    sbQuery.Append(" , TL_D_QTY = @TL_D_QTY");
                    sbQuery.Append(" , TL_IMAGE = @TL_IMAGE");
                    sbQuery.Append(" , SCOMMENT = @SCOMMENT");
                    sbQuery.Append(" , TOOL_LOCATION = @TOOL_LOCATION");
                    sbQuery.Append(" , TOOL_LOCATION_DETAIL = @TOOL_LOCATION_DETAIL");
                    sbQuery.Append(" , STD_LIFE = @STD_LIFE");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND TL_CODE = @TL_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "TL_CODE")) isHasColumn = false;

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

        /// <summary>
        /// 재고 증가
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TSTD_TOOL_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSTD_TOOL");
                    sbQuery.Append(" SET TL_QTY = TL_QTY + @ADD_QTY");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND TL_CODE = @TL_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "TL_CODE")) isHasColumn = false;

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

        /// <summary>
        /// 재고 감소
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TSTD_TOOL_UPD3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSTD_TOOL");
                    sbQuery.Append(" SET TL_QTY = TL_QTY - @GIVE_QTY");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND TL_CODE = @TL_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "TL_CODE")) isHasColumn = false;

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

        /// <summary>
        /// 재고 수량 감소 및 폐기 수량 증가
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TSTD_TOOL_UPD4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSTD_TOOL");
                    sbQuery.Append(" SET TL_QTY = TL_QTY - @GIVE_QTY");
                    sbQuery.Append(" , TL_D_QTY = TL_D_QTY + @GIVE_QTY");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND TL_CODE = @TL_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "TL_CODE")) isHasColumn = false;

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

        /// <summary>
        /// 재고 증가
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TSTD_TOOL_UPD5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSTD_TOOL");
                    sbQuery.Append(" SET TL_QTY = TL_QTY + @ADD_QTY");
                    sbQuery.Append(" , TL_D_QTY = TL_D_QTY - @ADD_QTY");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND TL_CODE = @TL_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "TL_CODE")) isHasColumn = false;

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

        public static void TSTD_TOOL_UPD6(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSTD_TOOL");
                    sbQuery.Append(" SET TL_NAME = @TL_NAME");
                    sbQuery.Append(" , TL_UNITCOST = @TL_UNITCOST");
                    sbQuery.Append(" , MAIN_VND = @MAIN_VND");
                    sbQuery.Append(" , TL_DANGER_QTY = @TL_DANGER_QTY");
                    sbQuery.Append(" , TOOL_LOCATION = @TOOL_LOCATION");
                    sbQuery.Append(" , TOOL_LOCATION_DETAIL = @TOOL_LOCATION_DETAIL");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND TL_CODE = @TL_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "TL_CODE")) isHasColumn = false;

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

        public static void TSTD_TOOL_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append("UPDATE TSTD_TOOL SET");
                    sbQuery.Append("  DEL_REASON = @DEL_REASON");
                    sbQuery.Append(" , DEL_DATE = GETDATE()");
                    sbQuery.Append(" , DEL_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , DATA_FLAG = 2");

                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND TL_CODE = @TL_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "TL_CODE")) isHasColumn = false;

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

        public static void TSTD_TOOL_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO TSTD_TOOL");
                    sbQuery.Append(" (");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" , TL_CODE");
                    sbQuery.Append(" , TL_NAME");
                    sbQuery.Append(" , TL_TYPE");
                    sbQuery.Append(" , TL_LTYPE");
                    sbQuery.Append(" , TL_MTYPE");
                    sbQuery.Append(" , TL_STYPE");
                    sbQuery.Append(" , TL_SIZE");
                    sbQuery.Append(" , SHANK ");
                    sbQuery.Append(" , CUT_LENGTH ");
                    sbQuery.Append(" , OVR_LENGTH ");
                    sbQuery.Append(" , TL_SPEC");
                    sbQuery.Append(" , TL_MIN");
                    sbQuery.Append(" , TL_MAX");
                    sbQuery.Append(" , TL_DANGER_QTY");
                    sbQuery.Append(" , TL_MAKER");
                    sbQuery.Append(" , TL_UNITCOST");
                    sbQuery.Append(" , TL_UNIT");
                    sbQuery.Append(" , HOLDER");
                    sbQuery.Append(" , TL_LENGTH");
                    sbQuery.Append(" , MAIN_VND");
                    sbQuery.Append(" , TOOL_LOCATION");
                    sbQuery.Append(" , TOOL_LOCATION_DETAIL");
                    sbQuery.Append(" , TL_QTY");
                    sbQuery.Append(" , TL_D_QTY");
                    sbQuery.Append(" , TL_IMAGE");
                    sbQuery.Append(" , SCOMMENT");
                    sbQuery.Append(" , STD_LIFE");
                    sbQuery.Append(" , REG_DATE");
                    sbQuery.Append(" , REG_EMP");
                    sbQuery.Append(" , DATA_FLAG");
                    sbQuery.Append(" )");
                    sbQuery.Append(" VALUES ");
                    sbQuery.Append(" (");
                    sbQuery.Append(" @PLT_CODE");
                    sbQuery.Append(" , @TL_CODE");
                    sbQuery.Append(" , @TL_NAME");
                    sbQuery.Append(" , @TL_TYPE");
                    sbQuery.Append(" , @TL_LTYPE");
                    sbQuery.Append(" , @TL_MTYPE");
                    sbQuery.Append(" , @TL_STYPE");
                    sbQuery.Append(" , @TL_SIZE");
                    sbQuery.Append(" , @SHANK ");
                    sbQuery.Append(" , @CUT_LENGTH ");
                    sbQuery.Append(" , @OVR_LENGTH ");
                    sbQuery.Append(" , @TL_SPEC");
                    sbQuery.Append(" , @TL_MIN");
                    sbQuery.Append(" , @TL_MAX");
                    sbQuery.Append(" , @TL_DANGER_QTY");
                    sbQuery.Append(" , @TL_MAKER");
                    sbQuery.Append(" , @TL_UNITCOST");
                    sbQuery.Append(" , @TL_UNIT");
                    sbQuery.Append(" , @HOLDER");
                    sbQuery.Append(" , @TL_LENGTH");
                    sbQuery.Append(" , @MAIN_VND");
                    sbQuery.Append(" , @TOOL_LOCATION");
                    sbQuery.Append(" , @TOOL_LOCATION_DETAIL");
                    sbQuery.Append(" , @TL_QTY");
                    sbQuery.Append(" , @TL_D_QTY");
                    sbQuery.Append(" , @TL_IMAGE");
                    sbQuery.Append(" , @SCOMMENT");
                    sbQuery.Append(" , @STD_LIFE");
                    sbQuery.Append(" , GETDATE() ");
                    sbQuery.Append(" ," + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , 0 ");

                    sbQuery.Append(" )");

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

    public class TSTD_TOOL_QUERY
    {
        public static DataTable TSTD_TOOL_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT   TT.PLT_CODE            ");
                    sbQuery.Append("       , TT.TL_CODE             ");
                    sbQuery.Append("       , TT.TL_NAME             ");
                    sbQuery.Append("       , TT.TL_TYPE             ");
                    sbQuery.Append("       , TT.TL_LTYPE            ");
                    sbQuery.Append("       , TT.TL_MTYPE            ");
                    sbQuery.Append("       , TT.TL_STYPE            ");
                    sbQuery.Append("       , TT.TL_SPEC             ");
                    sbQuery.Append("       , TT.TL_SIZE             ");
                    sbQuery.Append("       , TT.SHANK               ");
                    sbQuery.Append("       , TT.CUT_LENGTH          ");
                    sbQuery.Append("       , TT.OVR_LENGTH          ");
                    sbQuery.Append("       , TT.TL_MIN              ");
                    sbQuery.Append("       , TT.TL_MAX              ");
                    sbQuery.Append("       , TT.TL_DANGER_QTY       ");
                    sbQuery.Append("       , TT.TL_MAKER            ");
                    sbQuery.Append("       , TT.TL_UNITCOST         ");
                    sbQuery.Append("       , TT.TL_UNIT             ");
                    sbQuery.Append("       , TT.HOLDER              ");
                    sbQuery.Append("       , TT.TL_LENGTH           ");
                    sbQuery.Append("       , TT.MAIN_VND            ");
                    sbQuery.Append("       , TT.TL_QTY              ");
                    sbQuery.Append("       , TT.TL_QTY - ISNULL(GAVE_CNT,0) AS GIVE_POSSIBLE_QTY       ");
                    sbQuery.Append("       , ISNULL(GAVE_CNT,0) AS GIVE_QTY       ");
                    sbQuery.Append("       , TT.TL_D_QTY            ");
                    sbQuery.Append("       , TT.TL_IMAGE            ");
                    sbQuery.Append("       , TT.SCOMMENT            ");
                    sbQuery.Append("       , TT.STD_LIFE            ");
                    sbQuery.Append("       , TT.REG_DATE            ");
                    sbQuery.Append("       , TT.REG_EMP             ");
                    sbQuery.Append("       , TT.MDFY_DATE           ");
                    sbQuery.Append("       , TT.MDFY_EMP            ");
                    sbQuery.Append("       , TT.DEL_DATE            ");
                    sbQuery.Append("       , TT.DEL_EMP             ");
                    sbQuery.Append("       , TT.DEL_REASON	         ");
                    sbQuery.Append("       , TT.DATA_FLAG           ");
                    sbQuery.Append("  FROM TSTD_TOOL  TT            ");
                    sbQuery.Append("    LEFT JOIN (SELECT G.PLT_CODE           ");
                    sbQuery.Append("                     , T.TL_CODE       ");
                    sbQuery.Append("                     , COUNT(*) AS GAVE_CNT       ");
                    sbQuery.Append("                 FROM TTOL_GIVE  G         ");
                    sbQuery.Append("                    INNER JOIN TTOL_TOOLLIST T        ");
                    sbQuery.Append("                       ON G.PLT_CODE = T.PLT_CODE     ");
                    sbQuery.Append("                       AND G.TL_LOT = T.TL_LOT     ");
                    sbQuery.Append("                WHERE G.GIVE_STATE = 'GU'             ");
                    sbQuery.Append("               GROUP BY G.PLT_CODE, T.TL_CODE) TG       ");
                    sbQuery.Append("        ON TT.PLT_CODE = TG.PLT_CODE         ");
                    sbQuery.Append("        AND TT.TL_CODE = TG.TL_CODE        ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE TT.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@TL_CODE", "TT.TL_CODE = @TL_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@TL_LTYPE", "TT.TL_LTYPE = @TL_LTYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@TL_MTYPE", "TT.TL_MTYPE = @TL_MTYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@TL_STYPE", "TT.TL_STYPE = @TL_STYPE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@TL_LIKE", "(TT.TL_CODE LIKE '%' + @TL_LIKE + '%' OR TT.TL_NAME LIKE '%' + @TL_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@TL_SPEC_LIKE", "(TT.TL_SPEC LIKE '%' + @TL_SPEC_LIKE + '%')"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@TL_LOT_LIKE", "(TL.TL_LOT LIKE '%' + @TL_LOT_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "TT.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE,@E_REG_DATE", "CONVERT(CHAR(10), TT.REG_DATE, 23) BETWEEN @S_REG_DATE AND @E_REG_DATE"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@S_RTN_DATE,@E_RTN_DATE", "TR.RTN_DATE BETWEEN @S_RTN_DATE AND @E_RTN_DATE"));


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

        /// <summary>
        /// 지급이 존재하는 공구 목록
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TSTD_TOOL_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT   T.PLT_CODE         ");
                    sbQuery.Append("       , T.TL_CODE             ");
                    sbQuery.Append("       , T.TL_NAME             ");
                    sbQuery.Append("       , T.TL_TYPE             ");
                    sbQuery.Append("       , T.TL_LTYPE            ");
                    sbQuery.Append("       , T.TL_MTYPE            ");
                    sbQuery.Append("       , T.TL_STYPE            ");
                    sbQuery.Append("       , T.TL_SPEC             ");
                    sbQuery.Append("       , T.TL_MIN              ");
                    sbQuery.Append("       , T.TL_MAX              ");
                    sbQuery.Append("       , T.TL_DANGER_QTY       ");
                    sbQuery.Append("       , T.TL_MAKER            ");
                    sbQuery.Append("       , T.TL_UNITCOST         ");
                    sbQuery.Append("       , T.TL_UNIT             ");
                    sbQuery.Append("       , T.HOLDER              ");
                    sbQuery.Append("       , T.TL_LENGTH           ");
                    sbQuery.Append("       , T.MAIN_VND            ");
                    sbQuery.Append("       , T.TL_QTY              ");
                    sbQuery.Append("       , T.TL_D_QTY            ");
                    //sbQuery.Append("       , T.TL_IMAGE            ");
                    sbQuery.Append("       , T.REG_DATE          ");
                    sbQuery.Append("       , T.REG_EMP           ");
                    sbQuery.Append("       , T.MDFY_DATE         ");
                    sbQuery.Append("       , T.MDFY_EMP          ");
                    sbQuery.Append("       , T.SCOMMENT            ");
                    sbQuery.Append("       , T.STD_LIFE            ");
                    sbQuery.Append("       , TLG.GIVE_QTY            ");
                    sbQuery.Append("       , TLG.PLT_CODE            ");
                    sbQuery.Append("       , TLG.TL_CODE            ");
                    sbQuery.Append("       , 0 AS RTN_QTY            ");
                    sbQuery.Append("  FROM TSTD_TOOL T      ");
                    sbQuery.Append("    INNER JOIN ( SELECT                 ");
                    sbQuery.Append("                    COUNT(TL.TL_LOT) AS GIVE_QTY         ");
                    sbQuery.Append("                    , TL.PLT_CODE        ");
                    sbQuery.Append("                    , TL.TL_CODE        ");
                    sbQuery.Append("                 FROM TTOL_TOOLLIST AS TL     ");
                    sbQuery.Append("                    INNER JOIN TTOL_GIVE AS TG  ");
                    sbQuery.Append("                        ON TL.PLT_CODE = TG.PLT_CODE    ");
                    sbQuery.Append("                        AND TL.TL_LOT = TG.TL_LOT   ");
                    sbQuery.Append("                        AND TL.TL_STAT = TG.GIVE_STATE   ");
                    sbQuery.Append("                 WHERE TL_STAT = 'GU'   ");
                    sbQuery.Append("                 GROUP BY TL.PLT_CODE, TL.TL_CODE) AS TLG    ");
                    sbQuery.Append("        ON T.PLT_CODE = TLG.PLT_CODE      ");
                    sbQuery.Append("        AND T.TL_CODE = TLG.TL_CODE      ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE T.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@TL_CODE", " T.TL_CODE = @TL_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@GIVE_MC", " TG.GIVE_MC = @GIVE_MC"));
                        sbWhere.Append(UTIL.GetWhere(row, "@GIVE_EMP", " TG.GIVE_EMP = @GIVE_EMP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "T.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE,@E_REG_DATE", "CONVERT(CHAR(10), T.REG_DATE, 23) BETWEEN @S_REG_DATE AND @E_REG_DATE"));

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

        public static DataTable TSTD_TOOL_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT   TT.PLT_CODE            ");
                    sbQuery.Append("       , TT.TL_CODE             ");
                    sbQuery.Append("       , TL.TL_LOT             ");
                    sbQuery.Append("       , TL.WO_NO             ");
                    sbQuery.Append("       , TT.TL_NAME             ");
                    sbQuery.Append("       , TT.TL_TYPE             ");
                    sbQuery.Append("       , TL.TL_LIFE           ");
                    sbQuery.Append("       , TL.YPGO_DATE             ");
                    sbQuery.Append("       , TT.TL_LTYPE            ");
                    sbQuery.Append("       , TT.TL_MTYPE            ");
                    sbQuery.Append("       , TT.TL_STYPE            ");
                    sbQuery.Append("       , TT.TL_SPEC             ");
                    sbQuery.Append("       , TT.TL_MIN              ");
                    sbQuery.Append("       , TT.TL_MAX              ");
                    sbQuery.Append("       , TT.TL_DANGER_QTY       ");
                    sbQuery.Append("       , TT.TL_MAKER            ");
                    sbQuery.Append("       , TT.TL_UNITCOST         ");
                    sbQuery.Append("       , TT.TL_UNIT             ");
                    sbQuery.Append("       , TT.HOLDER              ");
                    sbQuery.Append("       , TT.TL_LENGTH           ");
                    sbQuery.Append("       , TT.MAIN_VND            ");
                    sbQuery.Append("       , TT.TL_QTY              ");
                    sbQuery.Append("       , TT.TL_D_QTY            ");
                    sbQuery.Append("       , TT.TL_IMAGE            ");
                    sbQuery.Append("       , TT.SCOMMENT            ");
                    sbQuery.Append("       , TT.STD_LIFE            ");
                    sbQuery.Append("       , TT.REG_DATE            ");
                    sbQuery.Append("       , TT.REG_EMP             ");
                    sbQuery.Append("       , TT.MDFY_DATE           ");
                    sbQuery.Append("       , TT.MDFY_EMP            ");
                    sbQuery.Append("       , TT.DEL_DATE            ");
                    sbQuery.Append("       , TT.DEL_EMP             ");
                    sbQuery.Append("       , TT.DEL_REASON	         ");
                    sbQuery.Append("       , TT.DATA_FLAG           ");
                    sbQuery.Append("  FROM TSTD_TOOL  TT            ");
                    sbQuery.Append("    INNER JOIN TTOL_TOOLLIST TL        ");
                    sbQuery.Append("           ON TT.PLT_CODE = TL.PLT_CODE     ");
                    sbQuery.Append("           AND TT.TL_CODE = TL.TL_CODE    ");
                    sbQuery.Append("    LEFT JOIN (SELECT G.PLT_CODE												  ");
                    sbQuery.Append("                	  , G.GIVE_NO												  ");
                    sbQuery.Append("                	  , G.GIVE_SEQ												  ");
                    sbQuery.Append("                	  , G.GIVE_DATE											  ");
                    sbQuery.Append("                	  , G.GIVE_STATE											  ");
                    sbQuery.Append("                	  , G.TL_LOT												  ");
                    sbQuery.Append("                	  , G.GIVE_MC												  ");
                    sbQuery.Append("                	  , G.GIVE_EMP												  ");
                    sbQuery.Append("                	  , G.SCOMMENT												  ");
                    sbQuery.Append("                	  , G.REG_DATE												  ");
                    sbQuery.Append("                	  , G.REG_EMP												  ");
                    sbQuery.Append("                	  , G.MDFY_DATE											  ");
                    sbQuery.Append("                	  , G.MDFY_EMP												  ");
                    sbQuery.Append("                  FROM TTOL_GIVE AS G												  ");
                    sbQuery.Append("                	INNER JOIN (SELECT PLT_CODE,MAX(REG_DATE) AS REG_DATE, TL_LOT ");
                    sbQuery.Append("                				FROM TTOL_GIVE									  ");
                    sbQuery.Append("                				WHERE GIVE_STATE = 'GU'							  ");//상태값 GU는 지급
                    sbQuery.Append("                				GROUP BY PLT_CODE, TL_LOT) AS SUB_G			        ");
                    sbQuery.Append("                		ON G.PLT_CODE = SUB_G.PLT_CODE						        ");
                    sbQuery.Append("                		AND G.TL_LOT = SUB_G.TL_LOT							        ");
                    sbQuery.Append("                		AND G.REG_DATE = SUB_G.REG_DATE) AS TG						  ");
                    sbQuery.Append("        ON TL.PLT_CODE = TG.PLT_CODE      ");
                    sbQuery.Append("        AND TL.TL_LOT = TG.TL_LOT      ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE TT.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@TL_CODE", "TT.TL_CODE = @TL_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@TL_LTYPE", "TT.TL_LTYPE = @TL_LTYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@TL_MTYPE", "TT.TL_MTYPE = @TL_MTYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@TL_STYPE", "TT.TL_STYPE = @TL_STYPE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@TL_LIKE", "(TT.TL_CODE LIKE '%' + @TL_LIKE + '%' OR TT.TL_NAME LIKE '%' + @TL_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@TL_SPEC_LIKE", "(TT.TL_SPEC LIKE '%' + @TL_SPEC_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WO_NO_LIKE", "(TL.WO_NO LIKE '%' + @WO_NO_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@TL_STAT", "TL.TL_STAT IN @TL_STAT ", UTIL.SqlCondType.IN));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_CODE", "TG.GIVE_MC = @MC_CODE"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@TL_LOT_LIKE", "(TL.TL_LOT LIKE '%' + @TL_LOT_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "TT.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE,@E_REG_DATE", "CONVERT(CHAR(10), TT.REG_DATE, 23) BETWEEN @S_REG_DATE AND @E_REG_DATE"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@S_RTN_DATE,@E_RTN_DATE", "TR.RTN_DATE BETWEEN @S_RTN_DATE AND @E_RTN_DATE"));


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


        public static DataTable TSTD_TOOL_QUERY4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT   TT.PLT_CODE            ");
                    sbQuery.Append("       , TT.TL_CODE             ");
                    sbQuery.Append("       , TT.TL_NAME             ");
                    sbQuery.Append("       , TT.TL_TYPE             ");
                    sbQuery.Append("       , TT.TL_LTYPE            ");
                    sbQuery.Append("       , TT.TL_MTYPE            ");
                    sbQuery.Append("       , TT.TL_STYPE            ");
                    sbQuery.Append("       , TT.TL_SPEC             ");
                    sbQuery.Append("       , TT.TL_SIZE             ");
                    sbQuery.Append("       , TT.SHANK               ");
                    sbQuery.Append("       , TT.CUT_LENGTH          ");
                    sbQuery.Append("       , TT.OVR_LENGTH          ");
                    sbQuery.Append("       , TT.TL_MIN              ");
                    sbQuery.Append("       , TT.TL_MAX              ");
                    sbQuery.Append("       , TT.TL_DANGER_QTY       ");
                    sbQuery.Append("       , TT.TL_MAKER            ");
                    sbQuery.Append("       , TT.TL_UNITCOST         ");
                    sbQuery.Append("       , TT.TL_UNIT             ");
                    sbQuery.Append("       , TT.HOLDER              ");
                    sbQuery.Append("       , TT.TL_LENGTH           ");
                    sbQuery.Append("       , TT.MAIN_VND            ");
                    sbQuery.Append("       , TT.TL_QTY              ");
                    sbQuery.Append("       , TT.TL_QTY - ISNULL(GAVE_CNT,0) AS GIVE_POSSIBLE_QTY       ");
                    sbQuery.Append("       , ISNULL(GAVE_CNT,0) AS GIVE_QTY       ");
                    //sbQuery.Append("       , ISNULL(BAL.BAL_QTY,0) AS BAL_QTY       ");
                    sbQuery.Append("       , TT.TL_D_QTY            ");
                    sbQuery.Append("       , TT.TL_IMAGE            ");
                    sbQuery.Append("       , TT.SCOMMENT            ");
                    sbQuery.Append("       , TT.TOOL_LOCATION            ");
                    sbQuery.Append("       , TT.TOOL_LOCATION_DETAIL            ");
                    sbQuery.Append("       , TT.STD_LIFE            ");
                    sbQuery.Append("       , TT.REG_DATE            ");
                    sbQuery.Append("       , TT.REG_EMP             ");
                    sbQuery.Append("       , TT.MDFY_DATE           ");
                    sbQuery.Append("       , TT.MDFY_EMP            ");
                    sbQuery.Append("       , TT.DEL_DATE            ");
                    sbQuery.Append("       , TT.DEL_EMP             ");
                    sbQuery.Append("       , TT.DEL_REASON	         ");
                    sbQuery.Append("       , TT.DATA_FLAG           ");
                    sbQuery.Append("  FROM TSTD_TOOL  TT            ");
                    sbQuery.Append("    LEFT JOIN (SELECT G.PLT_CODE           ");
                    sbQuery.Append("                     , T.TL_CODE       ");
                    sbQuery.Append("                     , COUNT(*) AS GAVE_CNT       ");
                    sbQuery.Append("                 FROM TTOL_GIVE  G         ");
                    sbQuery.Append("                    INNER JOIN TTOL_TOOLLIST T        ");
                    sbQuery.Append("                       ON G.PLT_CODE = T.PLT_CODE     ");
                    sbQuery.Append("                       AND G.TL_LOT = T.TL_LOT     ");
                    sbQuery.Append("                WHERE G.GIVE_STATE = 'GU'             ");
                    sbQuery.Append("               GROUP BY G.PLT_CODE, T.TL_CODE) TG       ");
                    sbQuery.Append("        ON TT.PLT_CODE = TG.PLT_CODE         ");
                    sbQuery.Append("        AND TT.TL_CODE = TG.TL_CODE        ");

                    //sbQuery.Append("    LEFT JOIN (SELECT  B.PLT_CODE           ");
                    //sbQuery.Append("                     , R.PART_CODE       ");
                    //sbQuery.Append("                     , B.QTY AS BAL_QTY ");
                    //sbQuery.Append("                 FROM TMAT_BALJU B         ");
                    //sbQuery.Append("                    INNER JOIN TMAT_REQUEST R        ");
                    //sbQuery.Append("                       ON B.PLT_CODE = R.PLT_CODE     ");
                    //sbQuery.Append("                       AND B.REQUEST_NO = R.REQUEST_NO AND B.REQUEST_SEQ = R.REQUEST_SEQ ");
                    //sbQuery.Append("                WHERE B.BAL_STAT IN ('11', '13') ) BAL    ");
                    //sbQuery.Append("        ON TT.PLT_CODE = BAL.PLT_CODE         ");
                    //sbQuery.Append("        AND TT.TL_CODE = BAL.PART_CODE        ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder();

                        sbWhere.Append(" WHERE TT.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@TL_CODE", "TT.TL_CODE = @TL_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@TL_LTYPE", "TT.TL_LTYPE = @TL_LTYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@TL_MTYPE", "TT.TL_MTYPE = @TL_MTYPE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@TL_STYPE", "TT.TL_STYPE = @TL_STYPE"));

                        sbWhere.Append(UTIL.GetWhere(row, "@TL_LIKE", "(TT.TL_CODE LIKE '%' + @TL_LIKE + '%' OR TT.TL_NAME LIKE '%' + @TL_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@TL_SPEC_LIKE", "(TT.TL_SPEC LIKE '%' + @TL_SPEC_LIKE + '%')"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@TL_LOT_LIKE", "(TL.TL_LOT LIKE '%' + @TL_LOT_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "TT.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE,@E_REG_DATE", "CONVERT(CHAR(10), TT.REG_DATE, 23) BETWEEN @S_REG_DATE AND @E_REG_DATE"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@S_RTN_DATE,@E_RTN_DATE", "TR.RTN_DATE BETWEEN @S_RTN_DATE AND @E_RTN_DATE"));


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

        public static DataTable TSTD_TOOL_QUERY5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT TT.PLT_CODE									  ");
                    sbQuery.Append(" 	 , TT.TL_CODE									  ");
                    sbQuery.Append(" 	 , TT.TL_NAME									  ");
                    sbQuery.Append(" 	 , LOT.EVENT_DATE								  ");
                    sbQuery.Append("   FROM TSTD_TOOL TT								  ");
                    sbQuery.Append(" 	INNER JOIN TTOL_TOOLLIST TL						  ");
                    sbQuery.Append(" 		ON TT.PLT_CODE = TL.PLT_CODE				  ");
                    sbQuery.Append(" 		AND TT.TL_CODE = TL.TL_CODE					  ");
                    sbQuery.Append(" 	INNER JOIN (SELECT PLT_CODE						  ");
                    sbQuery.Append(" 					, TL_LOT						  ");
                    sbQuery.Append(" 					, GIVE_DATE AS EVENT_DATE		  ");
                    sbQuery.Append(" 				 FROM TTOL_GIVE						  ");
                    sbQuery.Append(" 			   GROUP BY PLT_CODE					  ");
                    sbQuery.Append(" 					  , TL_LOT						  ");
                    sbQuery.Append(" 					  , GIVE_DATE					  ");
                    sbQuery.Append(" 													  ");
                    sbQuery.Append(" 				UNION								  ");
                    sbQuery.Append(" 													  ");
                    sbQuery.Append(" 			   SELECT R.PLT_CODE					  ");
                    sbQuery.Append(" 					, G.TL_LOT						  ");
                    sbQuery.Append(" 					, R.RTN_DATE AS EVENT_DATE		  ");
                    sbQuery.Append(" 				 FROM TTOL_RETURN R					  ");
                    sbQuery.Append(" 					INNER JOIN TTOL_GIVE G			  ");
                    sbQuery.Append(" 						ON R.PLT_CODE = G.PLT_CODE	  ");
                    sbQuery.Append(" 						AND R.GIVE_NO = G.GIVE_NO	  ");
                    sbQuery.Append(" 						AND R.GIVE_SEQ = G.GIVE_SEQ	  ");
                    sbQuery.Append(" 			   GROUP BY R.PLT_CODE					  ");
                    sbQuery.Append(" 					  , G.TL_LOT					  ");
                    sbQuery.Append(" 					  , R.RTN_DATE					  ");
                    sbQuery.Append(" 													  ");
                    sbQuery.Append(" 				UNION								  ");
                    sbQuery.Append(" 													  ");
                    sbQuery.Append(" 			   SELECT PLT_CODE						  ");
                    sbQuery.Append(" 					, TL_LOT						  ");
                    sbQuery.Append(" 					, TDU_DATE AS EVENT_DATE		  ");
                    sbQuery.Append(" 				 FROM TTOL_DISUSE					  ");
                    sbQuery.Append(" 			   GROUP BY PLT_CODE					  ");
                    sbQuery.Append(" 					  , TL_LOT						  ");
                    sbQuery.Append(" 					  , TDU_DATE) LOT				  ");
                    sbQuery.Append(" 		ON TL.PLT_CODE = LOT.PLT_CODE				  ");
                    sbQuery.Append(" 		AND TL.TL_LOT = LOT.TL_LOT					  ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE TT.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "TT.DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@YEAR", "LEFT(EVENT_DATE,4) = @YEAR"));

                        sbWhere.Append(" GROUP BY TT.PLT_CODE								  ");
                        sbWhere.Append(" 	 , TT.TL_CODE									  ");
                        sbWhere.Append(" 	 , TT.TL_NAME									  ");
                        sbWhere.Append(" 	 , LOT.EVENT_DATE								  ");

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
