using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSTD
{
    public class TSTD_MC_DAILYCAPA
    {

        public static DataTable TSTD_MC_DAILYCAPA_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    
                    sbQuery.Append(" SELECT   PLT_CODE ");
                    sbQuery.Append(" , MC_CODE ");
                    sbQuery.Append(" , WORK_DATE ");
                    sbQuery.Append(" , CAPA ");
                    sbQuery.Append("  FROM TSTD_MC_DAILYCAPA ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND MC_CODE = @MC_CODE  ");
                    sbQuery.Append("   AND WORK_DATE = @WORK_DATE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "MC_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "WORK_DATE")) isHasColumn = false;

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

        public static void TSTD_MC_DAILYCAPA_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    
                    sbQuery.Append(" INSERT INTO TSTD_MC_DAILYCAPA ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append("        PLT_CODE ");
                    sbQuery.Append("      , MC_CODE ");
                    sbQuery.Append("      , WORK_DATE ");
                    sbQuery.Append("      , CAPA ");
                    sbQuery.Append(" ) ");
                    sbQuery.Append(" VALUES ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append("        @PLT_CODE ");
                    sbQuery.Append("      , @MC_CODE ");
                    sbQuery.Append("      , @WORK_DATE ");
                    sbQuery.Append("      , @CAPA ");
                    sbQuery.Append(" ) ");


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

        public static void TSTD_MC_DAILYCAPA_INS2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            //해당 날짜 CAPA 0으로 Insert
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" INSERT INTO TSTD_MC_DAILYCAPA ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append("        PLT_CODE ");
                    sbQuery.Append("      , MC_CODE ");
                    sbQuery.Append("      , WORK_DATE ");
                    sbQuery.Append("      , CAPA ");
                    sbQuery.Append(" ) ");
                    sbQuery.Append(" VALUES ");
                    sbQuery.Append(" ( ");
                    sbQuery.Append("        @PLT_CODE ");
                    sbQuery.Append("      , @MC_CODE ");
                    sbQuery.Append("      , @WORK_DATE ");
                    sbQuery.Append("      , 0 ");
                    sbQuery.Append(" ) ");


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

        public static void TSTD_MC_DAILYCAPA_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSTD_MC_DAILYCAPA");
                    sbQuery.Append("  SET   CAPA = @CAPA ");
                    sbQuery.Append("     , SCOMMENT = @SCOMMENT ");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("  AND MC_CODE = @MC_CODE  ");
                    sbQuery.Append("  AND WORK_DATE = @WORK_DATE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "MC_CODE")) isHasColumn = false;
                        if (isHasColumn == true)
                        {

                            bizExecute.executeInsertQuery(sbQuery.ToString(), row);
                        }
                    }
                }
                
  
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static void TSTD_MC_DAILYCAPA_DEL2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    
                    sbQuery.Append(" DELETE FROM TSTD_MC_DAILYCAPA");
                    sbQuery.Append("  WHERE PLT_CODE = @PLT_CODE ");
                    sbQuery.Append("    AND MC_CODE = @MC_CODE ");
                    sbQuery.Append("   AND WORK_DATE = @WORK_DATE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "MC_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "WORK_DATE")) isHasColumn = false;
                        if (isHasColumn == true)
                        {

                            bizExecute.executeInsertQuery(sbQuery.ToString(), row);
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

    public class TSTD_MC_DAILYCAPA_QUERY
    {
        //가용설비 조회
        public static DataTable TSTD_MC_DAILYCAPA_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE");
                    sbQuery.Append(" ,MC_CODE");
                    sbQuery.Append(" ,WORK_DATE");
                    sbQuery.Append(" ,CAPA");
                    sbQuery.Append(" FROM TSTD_MC_DAILYCAPA");  
  
                    foreach (DataRow row in dtParam.Rows)
                    {

                        StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@MC_CODE", "MC_CODE = @MC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WORK_DATE", "WORK_DATE = @WORK_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@AFTER_WORK_DATE", "WORK_DATE BETWEEN @AFTER_WORK_DATE AND '99999999'"));


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

        //일별 CAPA , 공수  조회
        public static DataTable TSTD_MC_DAILYCAPA_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT																										");
                    sbQuery.Append(" CAPA.PLT_CODE,																								");
                    sbQuery.Append(" CAPA.MC_CODE,																								");
                    sbQuery.Append(" M.MC_NAME ,																								");
                    sbQuery.Append(" CAPA.WORK_DATE,																							");
                    sbQuery.Append(" ISNULL(CAPA.TOT_CAPA,0) AS TOT_CAPA,																		");
                    sbQuery.Append(" ISNULL(ACT.MAN_TIME,0)  AS MAN_TIME,																		");
                    sbQuery.Append(" ISNULL(ACT.SELF_TIME,0) AS SELF_TIME,																		");
                    sbQuery.Append(" ISNULL(ACT.OT_TIME,0)  AS OT_TIME,																			");
                    sbQuery.Append(" ISNULL(ACT.TOT_TIME,0) AS TOT_TIME,																		");
                    sbQuery.Append(" ISNULL(NG_ACT.NG_TIME,0) AS NG_TIME,																		");
                    sbQuery.Append(" ISNULL(IDLE.IDLE_TIME,0) AS IDLE_TIME ,																	");
                    sbQuery.Append(" 																											");
                    //가동율
                    sbQuery.Append(" CASE WHEN ISNULL(CAPA.TOT_CAPA,0) <> 0  THEN																");
                    sbQuery.Append(" ISNULL(ACT.TOT_TIME,0) / ISNULL(CAPA.TOT_CAPA,0)															");
                    sbQuery.Append(" ELSE 0 END AS WORK_RATE ,																					");
                    sbQuery.Append(" 																											");
                    //유실율
                    sbQuery.Append(" CASE WHEN ISNULL(CAPA.TOT_CAPA,0) <> 0  THEN																");
                    sbQuery.Append(" ISNULL(IDLE.IDLE_TIME,0) / ISNULL(CAPA.TOT_CAPA,0)															");
                    sbQuery.Append(" ELSE 0 END AS LOST_RATE ,																					");
                    sbQuery.Append(" 																											");
                    //불량율
                    sbQuery.Append(" CASE WHEN ISNULL(ACT.TOT_TIME,0) <> 0  THEN																");
                    sbQuery.Append(" ISNULL(NG_ACT.NG_TIME,0) / ISNULL(ACT.TOT_TIME,0)															");
                    sbQuery.Append(" ELSE 0 END AS NG_RATE 																						");
                    sbQuery.Append(" 																											");
                    sbQuery.Append(" FROM																										");
                    sbQuery.Append(" (																											");
                    sbQuery.Append(" SELECT 																									");
                    sbQuery.Append(" PLT_CODE ,																									");
                    sbQuery.Append(" MC_CODE ,																									");
                    sbQuery.Append(" WORK_DATE ,																								");
                    sbQuery.Append(" SUM(CAPA) AS TOT_CAPA 																						");
                    sbQuery.Append(" FROM dbo.TSTD_MC_DAILYCAPA CAPA																			");
                    sbQuery.Append(" GROUP BY PLT_CODE , MC_CODE , WORK_DATE																	");
                    sbQuery.Append(" ) CAPA																										");
                    sbQuery.Append(" LEFT JOIN 																									");
                    sbQuery.Append(" (																											");
                    sbQuery.Append(" SELECT																										");
                    sbQuery.Append(" A.PLT_CODE ,																								");
                    sbQuery.Append(" A.MC_CODE ,																								");
                    sbQuery.Append(" A.WORK_DATE ,																								");
                    sbQuery.Append(" SUM(A.MAN_TIME) AS MAN_TIME ,																				");
                    sbQuery.Append(" SUM(A.SELF_TIME)AS SELF_TIME,																				");
                    sbQuery.Append(" SUM(A.OT_TIME)AS OT_TIME ,																					");
                    sbQuery.Append(" SUM(A.MAN_TIME) + SUM(A.SELF_TIME) + SUM(A.OT_TIME) AS TOT_TIME											");
                    sbQuery.Append(" FROM																										");
                    sbQuery.Append(" (																											");
                    sbQuery.Append(" SELECT 																									");
                    sbQuery.Append(" PLT_CODE ,																									");
                    sbQuery.Append(" MC_CODE ,																									");
                    sbQuery.Append(" WORK_DATE ,																								");
                    sbQuery.Append(" SUM(MAN_TIME) AS MAN_TIME ,																				");
                    sbQuery.Append(" SUM(SELF_TIME)AS SELF_TIME,																				");
                    sbQuery.Append(" SUM(OT_TIME)AS OT_TIME ,																					");
                    sbQuery.Append(" SUM(MAN_TIME) + SUM(SELF_TIME) + SUM(OT_TIME) AS TOT_TIME													");
                    sbQuery.Append(" FROM TSHP_ACTUAL																							");
                    sbQuery.Append(" GROUP BY PLT_CODE , MC_CODE , WORK_DATE																	");
                    sbQuery.Append(" UNION																										");
                    sbQuery.Append(" SELECT 																									");
                    sbQuery.Append(" PLT_CODE ,																									");
                    sbQuery.Append(" MC_CODE ,																									");
                    sbQuery.Append(" WORK_DATE ,																								");
                    sbQuery.Append(" SUM(MAN_TIME) AS MAN_TIME ,																				");
                    sbQuery.Append(" SUM(SELF_TIME)AS SELF_TIME,																				");
                    sbQuery.Append(" SUM(OT_TIME)AS OT_TIME ,																					");
                    sbQuery.Append(" SUM(MAN_TIME) + SUM(SELF_TIME) + SUM(OT_TIME) AS TOT_TIME													");
                    sbQuery.Append(" FROM TSHP_MANACTUAL																						");
                    sbQuery.Append(" WHERE DATA_FLAG = 0																						");
                    sbQuery.Append(" GROUP BY PLT_CODE , MC_CODE , WORK_DATE																	");
                    sbQuery.Append(" ) A																										");
                    sbQuery.Append(" GROUP BY A.PLT_CODE , A.MC_CODE , A.WORK_DATE																");
                    sbQuery.Append(" ) ACT																										");
                    sbQuery.Append(" ON CAPA.PLT_CODE = ACT.PLT_CODE																			");
                    sbQuery.Append(" AND CAPA.MC_CODE = ACT.MC_CODE																				");
                    sbQuery.Append(" AND CAPA.WORK_DATE = ACT.WORK_DATE																			");
                    sbQuery.Append(" LEFT JOIN																									");
                    sbQuery.Append(" (																											");
                    sbQuery.Append(" SELECT																										");
                    sbQuery.Append(" B.PLT_CODE ,																								");
                    sbQuery.Append(" B.MC_CODE ,																								");
                    sbQuery.Append(" B.WORK_DATE ,																								");
                    sbQuery.Append(" B.NG_TIME 																									");
                    sbQuery.Append(" FROM																										");
                    sbQuery.Append(" (																											");
                    sbQuery.Append(" 	SELECT 																									");
                    sbQuery.Append(" 	PLT_CODE ,																								");
                    sbQuery.Append(" 	MC_CODE ,																								");
                    sbQuery.Append(" 	WORK_DATE ,																								");
                    sbQuery.Append(" 	NG_TIME =  CASE WHEN (SUM(NG_QTY) + SUM(OK_QTY)) < 1 THEN 0 ELSE ((SUM(MAN_TIME) + SUM(SELF_TIME) + SUM(OT_TIME)) / (SUM(NG_QTY) + SUM(OK_QTY))) * SUM(NG_QTY) END ");
                    sbQuery.Append(" 	FROM TSHP_ACTUAL 																						");
                    sbQuery.Append(" 	WHERE NG_QTY > 0																						");
                    sbQuery.Append(" 	GROUP BY PLT_CODE , MC_CODE , WORK_DATE																	");
                    sbQuery.Append(" 	UNION 																									");
                    sbQuery.Append(" 	SELECT 																									");
                    sbQuery.Append(" 	PLT_CODE ,																								");
                    sbQuery.Append(" 	MC_CODE ,																								");
                    sbQuery.Append(" 	WORK_DATE ,																								");
                    sbQuery.Append(" 	NG_TIME =  CASE WHEN (SUM(NG_QTY) + SUM(OK_QTY)) < 1 THEN 0 ELSE ((SUM(MAN_TIME) + SUM(SELF_TIME) + SUM(OT_TIME)) / (SUM(NG_QTY) + SUM(OK_QTY))) * SUM(NG_QTY) END");
                    sbQuery.Append(" 	FROM TSHP_MANACTUAL 																					");
                    sbQuery.Append(" 	WHERE DATA_FLAG = 0 AND NG_QTY > 0																		");
                    sbQuery.Append(" 	GROUP BY PLT_CODE , MC_CODE , WORK_DATE																	");
                    sbQuery.Append(" ) B 																										");
                    sbQuery.Append(" GROUP BY B.PLT_CODE , B.MC_CODE , B.WORK_DATE , B.NG_TIME													");
                    sbQuery.Append(" ) NG_ACT																									");
                    sbQuery.Append(" ON CAPA.PLT_CODE = NG_ACT.PLT_CODE																			");
                    sbQuery.Append(" AND CAPA.MC_CODE = NG_ACT.MC_CODE																			");
                    sbQuery.Append(" AND CAPA.WORK_DATE = NG_ACT.WORK_DATE																		");
                    sbQuery.Append(" LEFT JOIN 																									");
                    sbQuery.Append(" (																											");
                    sbQuery.Append(" SELECT 																									");
                    sbQuery.Append(" PLT_CODE ,																									");
                    sbQuery.Append(" WORK_DATE ,																								");
                    sbQuery.Append(" MC_CODE ,																									");
                    sbQuery.Append(" SUM(IDLE_TIME) AS IDLE_TIME																				");
                    sbQuery.Append(" FROM TSHP_IDLETIME																							");
                    sbQuery.Append(" WHERE DATA_FLAG = 0 																						");
                    sbQuery.Append(" GROUP BY PLT_CODE , WORK_DATE , MC_CODE																	");
                    sbQuery.Append(" ) IDLE																										");
                    sbQuery.Append(" ON CAPA.PLT_CODE = IDLE.PLT_CODE																			");
                    sbQuery.Append(" AND CAPA.MC_CODE = IDLE.MC_CODE																			");
                    sbQuery.Append(" AND CAPA.WORK_DATE = IDLE.WORK_DATE																		");
                    sbQuery.Append(" LEFT JOIN LSE_MACHINE M																					");
                    sbQuery.Append(" ON M.PLT_CODE = CAPA.PLT_CODE																				");
                    sbQuery.Append(" AND M.MC_CODE = CAPA.MC_CODE																				");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        StringBuilder sbWhere = new StringBuilder(" WHERE CAPA.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@MC_CODE", "CAPA.MC_CODE = @MC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WORK_DATE", "WORK_DATE = @WORK_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_WORK_DATE,@E_WORK_DATE", "CAPA.WORK_DATE BETWEEN @S_WORK_DATE AND @E_WORK_DATE"));
                        sbWhere.Append(" AND M.DATA_FLAG = '0'");


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

        //기간별(설비별) CAPA , 공수  조회
        public static DataTable TSTD_MC_DAILYCAPA_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT																										");
                    sbQuery.Append(" CAPA.PLT_CODE,																								");
                    sbQuery.Append(" M.MC_GROUP ,																								");
                    sbQuery.Append(" CAPA.MC_CODE,																								");
                    sbQuery.Append(" M.MC_NAME ,																								");
                    sbQuery.Append(" ISNULL(SUM(CAPA.TOT_CAPA),0) AS TOT_CAPA,																	");
                    sbQuery.Append(" ISNULL(SUM(ACT.MAN_TIME),0) AS MAN_TIME,																	");
                    sbQuery.Append(" ISNULL(SUM(ACT.SELF_TIME),0) AS SELF_TIME,																	");
                    sbQuery.Append(" ISNULL(SUM(ACT.OT_TIME),0)  AS OT_TIME,																	");
                    sbQuery.Append(" ISNULL(SUM(ACT.TOT_TIME),0) AS TOT_TIME,																	");
                    sbQuery.Append(" ISNULL(SUM(NG_ACT.NG_TIME),0) AS NG_TIME,																	");
                    sbQuery.Append(" ISNULL(SUM(IDLE.IDLE_TIME),0) AS IDLE_TIME ,																");
                    sbQuery.Append(" 																											");
                    //가동율
                    sbQuery.Append(" CASE WHEN ISNULL(SUM(CAPA.TOT_CAPA),0) <> 0  THEN															");
                    sbQuery.Append(" ISNULL(SUM(ACT.TOT_TIME),0) / ISNULL(SUM(CAPA.TOT_CAPA),0)													");
                    sbQuery.Append(" ELSE 0 END AS WORK_RATE ,																					");
                    sbQuery.Append(" 																											");
                    //유실율
                    sbQuery.Append(" CASE WHEN ISNULL(SUM(CAPA.TOT_CAPA),0) <> 0  THEN															");
                    sbQuery.Append(" ISNULL(SUM(IDLE.IDLE_TIME),0) / ISNULL(SUM(CAPA.TOT_CAPA),0)												");
                    sbQuery.Append(" ELSE 0 END AS LOST_RATE ,																					");
                    sbQuery.Append(" 																											");
                    //불량율
                    sbQuery.Append(" CASE WHEN ISNULL(SUM(ACT.TOT_TIME),0) <> 0  THEN															");
                    sbQuery.Append(" ISNULL(SUM(NG_ACT.NG_TIME),0) / ISNULL(SUM(ACT.TOT_TIME),0)												");
                    sbQuery.Append(" ELSE 0 END AS NG_RATE 																						");
                    sbQuery.Append(" 																											");
                    sbQuery.Append(" FROM																										");
                    sbQuery.Append(" (																											");
                    sbQuery.Append(" SELECT 																									");
                    sbQuery.Append(" PLT_CODE ,																									");
                    sbQuery.Append(" MC_CODE ,																									");
                    sbQuery.Append(" WORK_DATE ,																								");
                    sbQuery.Append(" SUM(CAPA) AS TOT_CAPA 																						");
                    sbQuery.Append(" FROM dbo.TSTD_MC_DAILYCAPA CAPA																			");
                    sbQuery.Append(" GROUP BY PLT_CODE , MC_CODE , WORK_DATE																	");
                    sbQuery.Append(" ) CAPA																										");
                    sbQuery.Append(" LEFT JOIN 																									");
                    sbQuery.Append(" (																											");
                    sbQuery.Append(" SELECT																										");
                    sbQuery.Append(" A.PLT_CODE ,																								");
                    sbQuery.Append(" A.MC_CODE ,																								");
                    sbQuery.Append(" A.WORK_DATE ,																								");
                    sbQuery.Append(" SUM(A.MAN_TIME) AS MAN_TIME ,																				");
                    sbQuery.Append(" SUM(A.SELF_TIME)AS SELF_TIME,																				");
                    sbQuery.Append(" SUM(A.OT_TIME)AS OT_TIME ,																					");
                    sbQuery.Append(" SUM(A.MAN_TIME) + SUM(A.SELF_TIME) + SUM(A.OT_TIME) AS TOT_TIME											");
                    sbQuery.Append(" FROM																										");
                    sbQuery.Append(" (																											");
                    sbQuery.Append(" SELECT 																									");
                    sbQuery.Append(" PLT_CODE ,																									");
                    sbQuery.Append(" MC_CODE ,																									");
                    sbQuery.Append(" WORK_DATE ,																								");
                    sbQuery.Append(" SUM(MAN_TIME) AS MAN_TIME ,																				");
                    sbQuery.Append(" SUM(SELF_TIME)AS SELF_TIME,																				");
                    sbQuery.Append(" SUM(OT_TIME)AS OT_TIME ,																					");
                    sbQuery.Append(" SUM(MAN_TIME) + SUM(SELF_TIME) + SUM(OT_TIME) AS TOT_TIME													");
                    sbQuery.Append(" FROM TSHP_ACTUAL																							");
                    sbQuery.Append(" GROUP BY PLT_CODE , MC_CODE , WORK_DATE																	");
                    sbQuery.Append(" UNION																										");
                    sbQuery.Append(" SELECT 																									");
                    sbQuery.Append(" PLT_CODE ,																									");
                    sbQuery.Append(" MC_CODE ,																									");
                    sbQuery.Append(" WORK_DATE ,																								");
                    sbQuery.Append(" SUM(MAN_TIME) AS MAN_TIME ,																				");
                    sbQuery.Append(" SUM(SELF_TIME)AS SELF_TIME,																				");
                    sbQuery.Append(" SUM(OT_TIME)AS OT_TIME ,																					");
                    sbQuery.Append(" SUM(MAN_TIME) + SUM(SELF_TIME) + SUM(OT_TIME) AS TOT_TIME													");
                    sbQuery.Append(" FROM TSHP_MANACTUAL																						");
                    sbQuery.Append(" WHERE DATA_FLAG = 0																						");
                    sbQuery.Append(" GROUP BY PLT_CODE , MC_CODE , WORK_DATE																	");
                    sbQuery.Append(" ) A																										");
                    sbQuery.Append(" GROUP BY A.PLT_CODE , A.MC_CODE , A.WORK_DATE																");
                    sbQuery.Append(" ) ACT																										");
                    sbQuery.Append(" ON CAPA.PLT_CODE = ACT.PLT_CODE																			");
                    sbQuery.Append(" AND CAPA.MC_CODE = ACT.MC_CODE																				");
                    sbQuery.Append(" AND CAPA.WORK_DATE = ACT.WORK_DATE																			");
                    sbQuery.Append(" LEFT JOIN																									");
                    sbQuery.Append(" (																											");
                    sbQuery.Append(" SELECT																										");
                    sbQuery.Append(" B.PLT_CODE ,																								");
                    sbQuery.Append(" B.MC_CODE ,																								");
                    sbQuery.Append(" B.WORK_DATE ,																								");
                    sbQuery.Append(" B.NG_TIME 																									");
                    sbQuery.Append(" FROM																										");
                    sbQuery.Append(" (																											");
                    sbQuery.Append(" 	SELECT 																									");
                    sbQuery.Append(" 	PLT_CODE ,																								");
                    sbQuery.Append(" 	MC_CODE ,																								");
                    sbQuery.Append(" 	WORK_DATE ,																								");
                    sbQuery.Append(" 	NG_TIME =  CASE WHEN (SUM(NG_QTY) + SUM(OK_QTY)) < 1 THEN 0 ELSE ((SUM(MAN_TIME) + SUM(SELF_TIME) + SUM(OT_TIME)) / (SUM(NG_QTY) + SUM(OK_QTY))) * SUM(NG_QTY) END");
                    sbQuery.Append(" 	FROM TSHP_ACTUAL 																						");
                    sbQuery.Append(" 	WHERE NG_QTY > 0																						");
                    sbQuery.Append(" 	GROUP BY PLT_CODE , MC_CODE , WORK_DATE																	");
                    sbQuery.Append(" 	UNION 																									");
                    sbQuery.Append(" 	SELECT 																									");
                    sbQuery.Append(" 	PLT_CODE ,																								");
                    sbQuery.Append(" 	MC_CODE ,																								");
                    sbQuery.Append(" 	WORK_DATE ,																								");
                    sbQuery.Append(" 	NG_TIME =  CASE WHEN (SUM(NG_QTY) + SUM(OK_QTY)) < 1 THEN 0 ELSE ((SUM(MAN_TIME) + SUM(SELF_TIME) + SUM(OT_TIME)) / (SUM(NG_QTY) + SUM(OK_QTY))) * SUM(NG_QTY) END");
                    sbQuery.Append(" 	FROM TSHP_MANACTUAL 																					");
                    sbQuery.Append(" 	WHERE DATA_FLAG = 0 AND NG_QTY > 0																		");
                    sbQuery.Append(" 	GROUP BY PLT_CODE , MC_CODE , WORK_DATE																	");
                    sbQuery.Append(" ) B 																										");
                    sbQuery.Append(" GROUP BY B.PLT_CODE , B.MC_CODE , B.WORK_DATE , B.NG_TIME													");
                    sbQuery.Append(" ) NG_ACT																									");
                    sbQuery.Append(" ON CAPA.PLT_CODE = NG_ACT.PLT_CODE																			");
                    sbQuery.Append(" AND CAPA.MC_CODE = NG_ACT.MC_CODE																			");
                    sbQuery.Append(" AND CAPA.WORK_DATE = NG_ACT.WORK_DATE																		");
                    sbQuery.Append(" LEFT JOIN 																									");
                    sbQuery.Append(" (																											");
                    sbQuery.Append(" SELECT 																									");
                    sbQuery.Append(" PLT_CODE ,																									");
                    sbQuery.Append(" WORK_DATE ,																								");
                    sbQuery.Append(" MC_CODE ,																									");
                    sbQuery.Append(" SUM(IDLE_TIME) AS IDLE_TIME																				");
                    sbQuery.Append(" FROM TSHP_IDLETIME 																						");
                    sbQuery.Append(" WHERE DATA_FLAG = 0																						");
                    sbQuery.Append(" GROUP BY PLT_CODE , WORK_DATE , MC_CODE																	");
                    sbQuery.Append(" ) IDLE																										");
                    sbQuery.Append(" ON CAPA.PLT_CODE = IDLE.PLT_CODE																			");
                    sbQuery.Append(" AND CAPA.MC_CODE = IDLE.MC_CODE																			");
                    sbQuery.Append(" AND CAPA.WORK_DATE = IDLE.WORK_DATE																		");
                    sbQuery.Append(" LEFT JOIN LSE_MACHINE M																					");
                    sbQuery.Append(" ON M.PLT_CODE = CAPA.PLT_CODE																				");
                    sbQuery.Append(" AND M.MC_CODE = CAPA.MC_CODE																				");


                    foreach (DataRow row in dtParam.Rows)
                    {

                        StringBuilder sbWhere = new StringBuilder(" WHERE CAPA.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@MC_CODE", "CAPA.MC_CODE = @MC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WORK_DATE", "WORK_DATE = @WORK_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_WORK_DATE,@E_WORK_DATE", "CAPA.WORK_DATE BETWEEN @S_WORK_DATE AND @E_WORK_DATE"));
                        sbWhere.Append(" AND M.DATA_FLAG = '0'");

                        sbWhere.Append(" GROUP BY CAPA.PLT_CODE , CAPA.MC_CODE , M.MC_NAME , M.MC_GROUP");

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

        //기간별(설비그룹) CAPA , 공수  조회
        public static DataTable TSTD_MC_DAILYCAPA_QUERY4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT																										");
                    sbQuery.Append(" CAPA.PLT_CODE,																								");
                    sbQuery.Append(" M.MC_GROUP ,																								");
                    sbQuery.Append(" ISNULL(SUM(CAPA.TOT_CAPA),0) AS TOT_CAPA,																	");
                    sbQuery.Append(" ISNULL(SUM(ACT.MAN_TIME),0) AS MAN_TIME,																	");
                    sbQuery.Append(" ISNULL(SUM(ACT.SELF_TIME),0) AS SELF_TIME,																	");
                    sbQuery.Append(" ISNULL(SUM(ACT.OT_TIME),0)  AS OT_TIME,																	");
                    sbQuery.Append(" ISNULL(SUM(ACT.TOT_TIME),0) AS TOT_TIME,																	");
                    sbQuery.Append(" ISNULL(SUM(NG_ACT.NG_TIME),0) AS NG_TIME,																	");
                    sbQuery.Append(" ISNULL(SUM(IDLE.IDLE_TIME),0) AS IDLE_TIME ,																");
                    sbQuery.Append(" 																											");
                    //가동율
                    sbQuery.Append(" CASE WHEN ISNULL(SUM(CAPA.TOT_CAPA),0) <> 0  THEN															");
                    sbQuery.Append(" ISNULL(SUM(ACT.TOT_TIME),0) / ISNULL(SUM(CAPA.TOT_CAPA),0)													");
                    sbQuery.Append(" ELSE 0 END AS WORK_RATE ,																					");
                    sbQuery.Append(" 																											");
                    //유실율
                    sbQuery.Append(" CASE WHEN ISNULL(SUM(CAPA.TOT_CAPA),0) <> 0  THEN															");
                    sbQuery.Append(" ISNULL(SUM(IDLE.IDLE_TIME),0) / ISNULL(SUM(CAPA.TOT_CAPA),0)												");
                    sbQuery.Append(" ELSE 0 END AS LOST_RATE ,																					");
                    sbQuery.Append(" 																											");
                    //불량율
                    sbQuery.Append(" CASE WHEN ISNULL(SUM(ACT.TOT_TIME),0) <> 0  THEN															");
                    sbQuery.Append(" ISNULL(SUM(NG_ACT.NG_TIME),0) / ISNULL(SUM(ACT.TOT_TIME),0)												");
                    sbQuery.Append(" ELSE 0 END AS NG_RATE 																						");
                    sbQuery.Append(" 																											");
                    sbQuery.Append(" FROM																										");
                    sbQuery.Append(" (																											");
                    sbQuery.Append(" SELECT 																									");
                    sbQuery.Append(" PLT_CODE ,																									");
                    sbQuery.Append(" MC_CODE ,																									");
                    sbQuery.Append(" WORK_DATE ,																								");
                    sbQuery.Append(" SUM(CAPA) AS TOT_CAPA 																						");
                    sbQuery.Append(" FROM dbo.TSTD_MC_DAILYCAPA CAPA																			");
                    sbQuery.Append(" GROUP BY PLT_CODE , MC_CODE , WORK_DATE																	");
                    sbQuery.Append(" ) CAPA																										");
                    sbQuery.Append(" LEFT JOIN 																									");
                    sbQuery.Append(" (																											");
                    sbQuery.Append(" SELECT																										");
                    sbQuery.Append(" A.PLT_CODE ,																								");
                    sbQuery.Append(" A.MC_CODE ,																								");
                    sbQuery.Append(" A.WORK_DATE ,																								");
                    sbQuery.Append(" SUM(A.MAN_TIME) AS MAN_TIME ,																				");
                    sbQuery.Append(" SUM(A.SELF_TIME)AS SELF_TIME,																				");
                    sbQuery.Append(" SUM(A.OT_TIME)AS OT_TIME ,																					");
                    sbQuery.Append(" SUM(A.MAN_TIME) + SUM(A.SELF_TIME) + SUM(A.OT_TIME) AS TOT_TIME											");
                    sbQuery.Append(" FROM																										");
                    sbQuery.Append(" (																											");
                    sbQuery.Append(" SELECT 																									");
                    sbQuery.Append(" PLT_CODE ,																									");
                    sbQuery.Append(" MC_CODE ,																									");
                    sbQuery.Append(" WORK_DATE ,																								");
                    sbQuery.Append(" SUM(MAN_TIME) AS MAN_TIME ,																				");
                    sbQuery.Append(" SUM(SELF_TIME)AS SELF_TIME,																				");
                    sbQuery.Append(" SUM(OT_TIME)AS OT_TIME ,																					");
                    sbQuery.Append(" SUM(MAN_TIME) + SUM(SELF_TIME) + SUM(OT_TIME) AS TOT_TIME													");
                    sbQuery.Append(" FROM TSHP_ACTUAL																							");
                    sbQuery.Append(" GROUP BY PLT_CODE , MC_CODE , WORK_DATE																	");
                    sbQuery.Append(" UNION																										");
                    sbQuery.Append(" SELECT 																									");
                    sbQuery.Append(" PLT_CODE ,																									");
                    sbQuery.Append(" MC_CODE ,																									");
                    sbQuery.Append(" WORK_DATE ,																								");
                    sbQuery.Append(" SUM(MAN_TIME) AS MAN_TIME ,																				");
                    sbQuery.Append(" SUM(SELF_TIME)AS SELF_TIME,																				");
                    sbQuery.Append(" SUM(OT_TIME)AS OT_TIME ,																					");
                    sbQuery.Append(" SUM(MAN_TIME) + SUM(SELF_TIME) + SUM(OT_TIME) AS TOT_TIME													");
                    sbQuery.Append(" FROM TSHP_MANACTUAL																						");
                    sbQuery.Append(" WHERE DATA_FLAG = 0																						");
                    sbQuery.Append(" GROUP BY PLT_CODE , MC_CODE , WORK_DATE																	");
                    sbQuery.Append(" ) A																										");
                    sbQuery.Append(" GROUP BY A.PLT_CODE , A.MC_CODE , A.WORK_DATE																");
                    sbQuery.Append(" ) ACT																										");
                    sbQuery.Append(" ON CAPA.PLT_CODE = ACT.PLT_CODE																			");
                    sbQuery.Append(" AND CAPA.MC_CODE = ACT.MC_CODE																				");
                    sbQuery.Append(" AND CAPA.WORK_DATE = ACT.WORK_DATE																			");
                    sbQuery.Append(" LEFT JOIN																									");
                    sbQuery.Append(" (																											");
                    sbQuery.Append(" SELECT																										");
                    sbQuery.Append(" B.PLT_CODE ,																								");
                    sbQuery.Append(" B.MC_CODE ,																								");
                    sbQuery.Append(" B.WORK_DATE ,																								");
                    sbQuery.Append(" B.NG_TIME 																									");
                    sbQuery.Append(" FROM																										");
                    sbQuery.Append(" (																											");
                    sbQuery.Append(" 	SELECT 																									");
                    sbQuery.Append(" 	PLT_CODE ,																								");
                    sbQuery.Append(" 	MC_CODE ,																								");
                    sbQuery.Append(" 	WORK_DATE ,																								");
                    sbQuery.Append(" 	NG_TIME =  ((SUM(MAN_TIME) + SUM(SELF_TIME) + SUM(OT_TIME)) / (SUM(NG_QTY) + SUM(OK_QTY))) * SUM(NG_QTY)");
                    sbQuery.Append(" 	FROM TSHP_ACTUAL 																						");
                    sbQuery.Append(" 	WHERE NG_QTY > 0																						");
                    sbQuery.Append(" 	GROUP BY PLT_CODE , MC_CODE , WORK_DATE																	");
                    sbQuery.Append(" 	UNION 																									");
                    sbQuery.Append(" 	SELECT 																									");
                    sbQuery.Append(" 	PLT_CODE ,																								");
                    sbQuery.Append(" 	MC_CODE ,																								");
                    sbQuery.Append(" 	WORK_DATE ,																								");
                    sbQuery.Append(" 	NG_TIME =  ((SUM(MAN_TIME) + SUM(SELF_TIME) + SUM(OT_TIME)) / (SUM(NG_QTY) + SUM(OK_QTY))) * SUM(NG_QTY)");
                    sbQuery.Append(" 	FROM TSHP_MANACTUAL 																					");
                    sbQuery.Append(" 	WHERE DATA_FLAG = 0 AND NG_QTY > 0																		");
                    sbQuery.Append(" 	GROUP BY PLT_CODE , MC_CODE , WORK_DATE																	");
                    sbQuery.Append(" ) B 																										");
                    sbQuery.Append(" GROUP BY B.PLT_CODE , B.MC_CODE , B.WORK_DATE , B.NG_TIME													");
                    sbQuery.Append(" ) NG_ACT																									");
                    sbQuery.Append(" ON CAPA.PLT_CODE = NG_ACT.PLT_CODE																			");
                    sbQuery.Append(" AND CAPA.MC_CODE = NG_ACT.MC_CODE																			");
                    sbQuery.Append(" AND CAPA.WORK_DATE = NG_ACT.WORK_DATE																		");
                    sbQuery.Append(" LEFT JOIN 																									");
                    sbQuery.Append(" (																											");
                    sbQuery.Append(" SELECT 																									");
                    sbQuery.Append(" PLT_CODE ,																									");
                    sbQuery.Append(" WORK_DATE ,																								");
                    sbQuery.Append(" MC_CODE ,																									");
                    sbQuery.Append(" SUM(IDLE_TIME) AS IDLE_TIME																				");
                    sbQuery.Append(" FROM TSHP_IDLETIME 																						");
                    sbQuery.Append(" WHERE DATA_FLAG = 0																						");
                    sbQuery.Append(" GROUP BY PLT_CODE , WORK_DATE , MC_CODE																	");
                    sbQuery.Append(" ) IDLE																										");
                    sbQuery.Append(" ON CAPA.PLT_CODE = IDLE.PLT_CODE																			");
                    sbQuery.Append(" AND CAPA.MC_CODE = IDLE.MC_CODE																			");
                    sbQuery.Append(" AND CAPA.WORK_DATE = IDLE.WORK_DATE																		");
                    sbQuery.Append(" LEFT JOIN LSE_MACHINE M																					");
                    sbQuery.Append(" ON M.PLT_CODE = CAPA.PLT_CODE																				");
                    sbQuery.Append(" AND M.MC_CODE = CAPA.MC_CODE																				");


                    foreach (DataRow row in dtParam.Rows)
                    {

                        StringBuilder sbWhere = new StringBuilder(" WHERE CAPA.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@MC_GROUP", "M.MC_GROUP = @MC_GROUP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@WORK_DATE", "WORK_DATE = @WORK_DATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_WORK_DATE,@E_WORK_DATE", "CAPA.WORK_DATE BETWEEN @S_WORK_DATE AND @E_WORK_DATE"));
                        sbWhere.Append(" AND M.DATA_FLAG = '0'");

                        sbWhere.Append(" GROUP BY CAPA.PLT_CODE , M.MC_GROUP");

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

        public static DataTable TSTD_MC_DAILYCAPA_QUERY5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    
                    sbQuery.Append(" SELECT ");
                    sbQuery.Append(" 	A.PLT_CODE, ");
                    sbQuery.Append(" 	A.WORK_DATE, ");
                    sbQuery.Append("     A.MC_CODE, ");
                    sbQuery.Append("     B.MC_NAME, ");
                    sbQuery.Append("     A.CAPA, ");
                    sbQuery.Append("     C.HOLI_NAME, ");
                    sbQuery.Append("     B.MC_GROUP, ");
                    sbQuery.Append("     A.SCOMMENT ");
                    sbQuery.Append(" FROM TSTD_MC_DAILYCAPA A  ");
                    sbQuery.Append("   LEFT JOIN LSE_MACHINE B  ");
                    sbQuery.Append("      ON A.MC_CODE = B.MC_CODE ");
                    sbQuery.Append("     AND A.PLT_CODE = B.PLT_CODE ");
                    sbQuery.Append("   LEFT JOIN LSE_HOLIDAY C ");
                    sbQuery.Append("      ON A.WORK_DATE = C.HOLI_DATE ");
                    sbQuery.Append("     AND A.PLT_CODE = C.PLT_CODE ");
                    

                    foreach (DataRow row in dtParam.Rows)
                    {

                        StringBuilder sbWhere = new StringBuilder(" WHERE A.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@DATE1,@DATE2", "A.WORK_DATE BETWEEN @DATE1 AND @DATE2"));
                        sbWhere.Append(" AND B.MC_MGT_FLAG = 1 AND B.DATA_FLAG = 0 ");
                        sbWhere.Append("ORDER BY A.PLT_CODE, A.WORK_DATE, B.MC_SEQ, A.MC_CODE");

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


        public static DataTable TSTD_MC_DAILYCAPA_QUERY6(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT ");
                    sbQuery.Append(" 	A.PLT_CODE ");
                    sbQuery.Append(" 	,A.WORK_DATE ");
                    sbQuery.Append(" FROM DBO.FN_MC_CAPA(@PLT_CODE,@S_DATE,@E_DATE) A  ");


                    foreach (DataRow row in dtParam.Rows)
                    {

                        StringBuilder sbWhere = new StringBuilder(" WHERE A.PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        //sbWhere.Append(UTIL.GetWhere(row, "@YEAR_MONTH", "SUBSTRING(A.WORK_DATE,1,6) = @YEAR_MONTH"));
                        sbWhere.Append(UTIL.GetWhere(row, "@S_DATE,@E_DATE", " A.WORK_DATE BETWEEN @S_DATE AND @E_DATE "));

                        sbWhere.Append(UTIL.GetWhere(row, "@MC_GROUP", "A.MC_CODE IN (SELECT MC_CODE FROM LSE_MACHINE WHERE PLT_CODE = A.PLT_CODE AND MC_GROUP IN @MC_GROUP) ", UTIL.SqlCondType.IN));

                        sbWhere.Append(" AND A.CAPA > 0 ");

                        sbWhere.Append("GROUP BY A.PLT_CODE,A.WORK_DATE");

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(),row).Copy();

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
