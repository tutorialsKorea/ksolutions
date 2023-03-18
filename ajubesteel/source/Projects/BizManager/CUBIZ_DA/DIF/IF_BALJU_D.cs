using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DIF
{
    public class IF_BALJU_D
    {
        
    }

    public class IF_BALJU_D_QUERY
    {
        //자재발주현황
        public static DataTable IF_BALJU_D_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT M.발주일자,");
                    sbQuery.Append(" M.발주번호,");
                    sbQuery.Append(" D.순번,");
                    sbQuery.Append(" D.품목코드,");
                    sbQuery.Append(" D.수량,");
                    sbQuery.Append(" M.거래처코드,");
                    sbQuery.Append(" M.거래처명,");
                    sbQuery.Append(" D.납기일,");
                    sbQuery.Append(" D.비고,");
                    sbQuery.Append(" I.작업구분,");
                    sbQuery.Append(" I.작업자 ,");
                    sbQuery.Append(" 통합구분");
                    sbQuery.Append(" FROM IF_BALJU_D D JOIN IF_BALJU_M M");
                    sbQuery.Append(" ON D.발주번호 = M.발주번호");
                    sbQuery.Append(" LEFT JOIN IF_INOUT I");
                    sbQuery.Append(" ON D.발주번호 = I.통합번호");
                    sbQuery.Append(" AND D.순번 = I.발주서순번");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE  1=1");
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", " D.품목코드 = @PART_CODE"));
                        sbWhere.Append(" AND I.통합구분 IN ('자재발주서')");
                        sbWhere.Append(" ORDER BY M.발주번호 DESC, D.순번 ");



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

        //가공발주현황
        public static DataTable IF_BALJU_D_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT M.발주일자,");
                    sbQuery.Append(" M.발주번호,");
                    sbQuery.Append(" D.순번,");
                    sbQuery.Append(" D.품목코드,");
                    sbQuery.Append(" D.수량,");
                    sbQuery.Append(" M.거래처코드,");
                    sbQuery.Append(" M.거래처명,");
                    sbQuery.Append(" D.납기일,");
                    sbQuery.Append(" D.비고,");
                    sbQuery.Append(" I.작업구분,");
                    sbQuery.Append(" I.작업자 ,");
                    sbQuery.Append(" 통합구분");
                    sbQuery.Append(" FROM IF_BALJU_D D JOIN IF_BALJU_M M");
                    sbQuery.Append(" ON D.발주번호 = M.발주번호");
                    sbQuery.Append(" LEFT JOIN IF_INOUT I");
                    sbQuery.Append(" ON D.발주번호 = I.통합번호");
                    sbQuery.Append(" AND D.순번 = I.발주서순번");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE  1=1");
                        sbWhere.Append(UTIL.GetWhere(row, "@PART_CODE", " D.품목코드 = @PART_CODE"));
                        sbWhere.Append(" AND I.통합구분 IN ('가공발주서')");
                        sbWhere.Append(" ORDER BY M.발주번호 DESC, D.순번 ");



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
