using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizExecute;
using System.Data;
using System.Data.SqlClient;

namespace DSTD
{
    public class TSTD_VENDOR_GRP_DETAIL
    { 
        /// <summary>
        /// 특정 그룹에 해당하는 품목 정보 표시
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TSTD_VENDOR_GRP_DETAIL_SER1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" , GRP_ID ");
                    sbQuery.Append(" , PART_CODE ");
                    sbQuery.Append(" , VIEW_FLAG ");
                    sbQuery.Append(" , SCOMMENT ");
                    sbQuery.Append(" FROM TSTD_VENDOR_GRP_DETAIL  ");
                    sbQuery.Append(" WHERE GRP_ID = @GRP_ID  ");
                    sbQuery.Append("    AND PART_CODE = @PART_CODE  ");

                    foreach (DataRow row in dtParam.Rows)
                    {                                                                   
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "GRP_ID")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {
                            DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString(),row).Copy();

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


        /// <summary>
        /// 선택한 그룹의 품목 삭제 _ PUR55B_D0A 재고 그룹 리스트에서 삭제
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        public static void TSTD_VENDOR_GRP_DETAIL_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" DELETE FROM  TSTD_VENDOR_GRP_DETAIL  ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append("  AND GRP_ID = @GRP_ID");
                    sbQuery.Append("  AND PART_CODE = @PART_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "GRP_ID")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {                            
                            bizExecute.executeUpdateQuery(sbQuery.ToString(),row);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static void TSTD_VENDOR_GRP_DETAIL_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO TSTD_VENDOR_GRP_DETAIL");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" , GRP_ID");
                    sbQuery.Append(" , PART_CODE");
                    sbQuery.Append(" , VIEW_FLAG");
                    sbQuery.Append(" , SCOMMENT");
                    sbQuery.Append(" ) ");
                    sbQuery.Append(" VALUES");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" @PLT_CODE ");
                    sbQuery.Append(" , @GRP_ID");
                    sbQuery.Append(" , @PART_CODE ");
                    sbQuery.Append(" , @VIEW_FLAG ");
                    sbQuery.Append(" , @SCOMMENT ");
                    sbQuery.Append(" ) ");

                    foreach (DataRow row in dtParam.Rows)
                    {                        
                        bizExecute.executeInsertQuery(sbQuery.ToString(),row);
                    }
                }

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static void TSTD_VENDOR_GRP_DETAIL_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSTD_VENDOR_GRP_DETAIL ");
                    sbQuery.Append(" SET VIEW_FLAG = @VIEW_FLAG");
                    sbQuery.Append(" , SCOMMENT = @SCOMMENT");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND GRP_ID = @GRP_ID");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "GRP_ID")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;

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

    public class TSTD_VENDOR_GRP_DETAIL_QUERY
    {
        

    }
}

