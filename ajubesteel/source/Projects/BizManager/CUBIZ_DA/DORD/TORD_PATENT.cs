using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DORD
{
    public class TORD_PATENT
    {


        public static DataTable TORD_PATENT_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("SELECT   PLT_CODE ");
                    sbQuery.Append("       , PATENT_CODE ");
                    sbQuery.Append("       , TITLE ");
                    sbQuery.Append("       , PATENT_NO ");
                    sbQuery.Append("       , PATENT_DATE ");
                    sbQuery.Append("       , PATENT_REG_NO ");
                    sbQuery.Append("       , PATENT_REG_DATE ");
                    sbQuery.Append("       , PATENTEE ");
                    sbQuery.Append("       , INVENTOR ");
                    sbQuery.Append("       , PATENT_FIELD ");
                    sbQuery.Append("       , PATENT_IMG ");
                    sbQuery.Append("       , NATION ");
                    sbQuery.Append("       , KOR_TITLE ");
                    sbQuery.Append("       , ENG_TITLE ");
                    sbQuery.Append("       , PATENT_STATE ");
                    sbQuery.Append("       , SCOMMENT");
                    sbQuery.Append("       , REG_DATE ");
                    sbQuery.Append("       , REG_EMP ");
                    sbQuery.Append("       , MDFY_DATE ");
                    sbQuery.Append("       , MDFY_EMP ");
                    sbQuery.Append("       , DEL_DATE ");
                    sbQuery.Append("       , DEL_EMP ");
                    sbQuery.Append("       , DATA_FLAG ");
                    sbQuery.Append("  FROM TORD_PATENT ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND PATENT_CODE = @PATENT_CODE");
                    sbQuery.Append("   AND DATA_FLAG = @DATA_FLAG");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PATENT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "DATA_FLAG")) isHasColumn = false;

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

        public static void TORD_PATENT_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("UPDATE TORD_PATENT ");
                    sbQuery.Append("   SET   TITLE = @TITLE ");
                    sbQuery.Append("       , PATENT_NO = @PATENT_NO ");
                    sbQuery.Append("       , PATENT_DATE = @PATENT_DATE");
                    sbQuery.Append("       , PATENT_REG_NO = @PATENT_REG_NO");
                    sbQuery.Append("       , PATENT_REG_DATE = @PATENT_REG_DATE");
                    sbQuery.Append("       , PATENTEE = @PATENTEE");
                    sbQuery.Append("       , INVENTOR = @INVENTOR");
                    sbQuery.Append("       , PATENT_FIELD = @PATENT_FIELD ");
                    sbQuery.Append("       , PATENT_IMG = @PATENT_IMG ");
                    sbQuery.Append("       , NATION = @NATION ");
                    sbQuery.Append("       , KOR_TITLE = @KOR_TITLE ");
                    sbQuery.Append("       , ENG_TITLE = @ENG_TITLE ");
                    sbQuery.Append("       , PATENT_STATE = @PATENT_STATE ");
                    sbQuery.Append("       , SCOMMENT = @SCOMMENT");
                    sbQuery.Append("       , MDFY_DATE = GETDATE() ");
                    sbQuery.Append("       , MDFY_EMP = @MDFY_EMP ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("   AND PATENT_CODE = @PATENT_CODE ");


                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크                        
                        if (!UTIL.ValidColumn(row, "PATENT_CODE")) isHasColumn = false;

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

        public static void TORD_PATENT_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();


                    sbQuery.Append("INSERT INTO TORD_PATENT ");
                    sbQuery.Append("( ");
                    sbQuery.Append("         PLT_CODE ");
                    sbQuery.Append("       , PATENT_CODE ");
                    sbQuery.Append("       , TITLE ");
                    sbQuery.Append("       , PATENT_NO ");
                    sbQuery.Append("       , PATENT_DATE ");
                    sbQuery.Append("       , PATENT_REG_NO ");
                    sbQuery.Append("       , PATENT_REG_DATE ");
                    sbQuery.Append("       , PATENTEE ");
                    sbQuery.Append("       , INVENTOR ");
                    sbQuery.Append("       , PATENT_FIELD ");
                    sbQuery.Append("       , PATENT_IMG ");
                    sbQuery.Append("       , NATION ");
                    sbQuery.Append("       , KOR_TITLE ");
                    sbQuery.Append("       , ENG_TITLE ");
                    sbQuery.Append("       , PATENT_STATE ");
                    sbQuery.Append("       , SCOMMENT");
                    sbQuery.Append("       , REG_DATE ");
                    sbQuery.Append("       , REG_EMP ");
                    sbQuery.Append("       , DATA_FLAG ");
                    sbQuery.Append(") ");
                    sbQuery.Append("VALUES ");
                    sbQuery.Append("( ");
                    sbQuery.Append("         @PLT_CODE ");
                    sbQuery.Append("       , @PATENT_CODE ");
                    sbQuery.Append("       , @TITLE ");
                    sbQuery.Append("       , @PATENT_NO ");
                    sbQuery.Append("       , @PATENT_DATE ");
                    sbQuery.Append("       , @PATENT_REG_NO ");
                    sbQuery.Append("       , @PATENT_REG_DATE ");
                    sbQuery.Append("       , @PATENTEE ");
                    sbQuery.Append("       , @INVENTOR ");
                    sbQuery.Append("       , @PATENT_FIELD ");
                    sbQuery.Append("       , @PATENT_IMG ");
                    sbQuery.Append("       , @NATION ");
                    sbQuery.Append("       , @KOR_TITLE ");
                    sbQuery.Append("       , @ENG_TITLE ");
                    sbQuery.Append("       , @PATENT_STATE ");
                    sbQuery.Append("       , @SCOMMENT");
                    sbQuery.Append("       , GETDATE() ");
                    sbQuery.Append("       , @REG_EMP ");
                    sbQuery.Append("       , 0 ");
                    sbQuery.Append(") ");

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

        public static void TORD_PATENT_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("UPDATE TORD_PATENT ");
                    sbQuery.Append("  SET   DEL_DATE = GETDATE() ");
                    sbQuery.Append("      , DEL_EMP = @DEL_EMP ");
                    sbQuery.Append("      , DATA_FLAG = 2 ");
                    sbQuery.Append("WHERE PLT_CODE = @PLT_CODE  ");
                    sbQuery.Append("  AND PATENT_CODE = @PATENT_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크                        
                        if (!UTIL.ValidColumn(row, "PATENT_CODE")) isHasColumn = false;

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

    public class TORD_PATENT_QUERY
    {
        /// <summary>
        /// 특허 진행사항 조회 
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TORD_PATENT_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("SELECT   PLT_CODE ");
                    sbQuery.Append("       , PATENT_CODE ");
                    sbQuery.Append("       , TITLE ");
                    sbQuery.Append("       , PATENT_NO ");
                    sbQuery.Append("       , PATENT_DATE ");
                    sbQuery.Append("       , PATENT_REG_NO ");
                    sbQuery.Append("       , PATENT_REG_DATE ");
                    sbQuery.Append("       , PATENTEE ");
                    sbQuery.Append("       , INVENTOR ");
                    sbQuery.Append("       , PATENT_FIELD ");
                    sbQuery.Append("       , PATENT_IMG ");
                    sbQuery.Append("       , CASE WHEN PATENT_IMG IS NOT NULL THEN 1 ELSE 0 END AS IMG_CNT ");
                    sbQuery.Append("       , NATION ");
                    sbQuery.Append("       , KOR_TITLE ");
                    sbQuery.Append("       , ENG_TITLE ");
                    sbQuery.Append("       , PATENT_STATE ");
                    sbQuery.Append("       , SCOMMENT");
                    sbQuery.Append("       , REG_DATE ");
                    sbQuery.Append("       , REG_EMP ");
                    sbQuery.Append("       , MDFY_DATE ");
                    sbQuery.Append("       , MDFY_EMP ");
                    sbQuery.Append("       , DEL_DATE ");
                    sbQuery.Append("       , DEL_EMP ");
                    sbQuery.Append("       , DATA_FLAG ");
                    sbQuery.Append("  FROM TORD_PATENT ");
                   
                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                           
                            StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE = " + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                            sbWhere.Append(UTIL.GetWhere(row, "@PATENT_CODE", " PATENT_CODE = @PATENT_CODE "));

                            sbWhere.Append(UTIL.GetWhere(row, "@TITLE_LIKE", "TITLE LIKE '%' + @TITLE_LIKE + '%' "));  // 특허명
                            
                            sbWhere.Append(UTIL.GetWhere(row, "@S_REG_DATE, @E_REG_DATE", "(CONVERT(nvarchar(8),REG_DATE,112) BETWEEN @S_REG_DATE AND @E_REG_DATE)")); //등록일

                            sbWhere.Append(UTIL.GetWhere(row, "@PATENT_STATE", " PATENT_STATE = @PATENT_STATE "));   //특허상태

                            sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", " DATA_FLAG = @DATA_FLAG "));

                            sbWhere.Append(" ORDER BY PATENT_DATE DESC ");

                            DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString()).Copy();

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
