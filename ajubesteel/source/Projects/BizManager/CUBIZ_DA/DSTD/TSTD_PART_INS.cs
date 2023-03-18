using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DSTD
{
    public class TSTD_PART_INS
    {

        public static DataTable TSTD_PART_INS_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();
                DataTable dtResult = new DataTable();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE");
                    sbQuery.Append(" ,PART_CODE		");
                    sbQuery.Append(" ,INS_CODE	");
                    sbQuery.Append(" ,MEAS_CODE	");
                    sbQuery.Append(" ,AVG_VAL	");
                    sbQuery.Append(" ,MIN_VAL	");
                    sbQuery.Append(" ,MAX_VAL	");
                    sbQuery.Append(" ,SCOMMENT		");
                    sbQuery.Append(" ,INS_SEQ		 ");
                    sbQuery.Append(" ,DATA_FLAG		");
                    sbQuery.Append(" ,REG_DATE		");
                    sbQuery.Append(" ,REG_EMP		");
                    sbQuery.Append(" ,MDFY_DATE		");
                    sbQuery.Append(" ,MDFY_EMP		");
                    sbQuery.Append(" FROM TSTD_PART_INS	");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE	   ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {

                            StringBuilder sbWhere = new StringBuilder();

                            sbWhere.Append(UTIL.GetWhere(row, "@INS_CODE", "INS_CODE = @INS_CODE"));
                            sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "DATA_FLAG = @DATA_FLAG"));

                            sbWhere.Append(" ORDER BY INS_SEQ ");


                            dtResult = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(), row).Copy();
                            dtResult.TableName = "RSLTDT";

                            //DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString() + sbWhere.ToString(), row).Copy();

                            //sourceTable.TableName = "RSLTDT";
                            //dsResult.Merge(sourceTable);
                        }
                    }
                }

                return dtResult;
                //return UTIL.GetDsToDt(dsResult);

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataTable TSTD_PART_INS_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" SELECT PLT_CODE");
                    sbQuery.Append(" ,PART_CODE		");
                    sbQuery.Append(" ,INS_CODE	");
                    sbQuery.Append(" ,MEAS_CODE	");
                    sbQuery.Append(" ,AVG_VAL	");
                    sbQuery.Append(" ,MIN_VAL	");
                    sbQuery.Append(" ,MAX_VAL	");
                    sbQuery.Append(" ,SCOMMENT		");
                    sbQuery.Append(" ,REG_DATE		");
                    sbQuery.Append(" ,REG_EMP		");
                    sbQuery.Append(" ,MDFY_DATE		");
                    sbQuery.Append(" ,MDFY_EMP		");
                    sbQuery.Append(" FROM TSTD_PART_INS	");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE");
                    sbQuery.Append(" AND INS_CODE = @INS_CODE");
                    sbQuery.Append(" ORDER BY INS_SEQ ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "INS_CODE")) isHasColumn = false;

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

        public static void TSTD_PART_INS_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO TSTD_PART_INS");
                    sbQuery.Append(" (PLT_CODE			 ");
                    sbQuery.Append(" ,PART_CODE			 ");
                    sbQuery.Append(" ,INS_CODE		 ");
                    sbQuery.Append(" ,MEAS_CODE		 ");
                    sbQuery.Append(" ,AVG_VAL		 ");
                    sbQuery.Append(" ,MIN_VAL		 ");
                    sbQuery.Append(" ,MAX_VAL		 ");
                    sbQuery.Append(" ,SCOMMENT			 ");
                    sbQuery.Append(" ,INS_SEQ		 ");
                    sbQuery.Append(" ,DATA_FLAG		 ");
                    sbQuery.Append(" ,REG_DATE			 ");
                    sbQuery.Append(" ,REG_EMP)			 ");
                    sbQuery.Append(" VALUES				 ");
                    sbQuery.Append(" (@PLT_CODE			 ");
                    sbQuery.Append(" ,@PART_CODE     	 ");
                    sbQuery.Append(" ,@INS_CODE	        ");
                    sbQuery.Append(" ,@MEAS_CODE		");
                    sbQuery.Append(" ,@AVG_VAL		 ");
                    sbQuery.Append(" ,@MIN_VAL		 ");
                    sbQuery.Append(" ,@MAX_VAL		 ");
                    sbQuery.Append(" ,@SCOMMENT		    ");
                    sbQuery.Append(" ,(SELECT COUNT(*)+1 FROM TSTD_PART_INS WHERE PLT_CODE = @PLT_CODE AND PART_CODE = @PART_CODE)		 ");
                    sbQuery.Append(" ,0		    ");
                    sbQuery.Append(" ,GETDATE()			");
                    sbQuery.Append(" ," + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(") ");

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
        
        public static void TSTD_PART_INS_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSTD_PART_INS		   ");
                    sbQuery.Append(" SET MEAS_CODE = @MEAS_CODE	   ");
                    sbQuery.Append(" ,AVG_VAL = @AVG_VAL ");
                    sbQuery.Append(" ,MIN_VAL = @MIN_VAL ");
                    sbQuery.Append(" ,MAX_VAL = @MAX_VAL ");
                    sbQuery.Append(" ,SCOMMENT = @SCOMMENT ");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , DATA_FLAG = 0 ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE	   ");
                    sbQuery.Append(" AND INS_CODE = @INS_CODE	   ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "INS_CODE")) isHasColumn = false;

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

        public static void TSTD_PART_INS_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSTD_PART_INS		   ");
                    sbQuery.Append(" SET MEAS_CODE = @MEAS_CODE	   ");
                    sbQuery.Append(" ,AVG_VAL = @AVG_VAL ");
                    sbQuery.Append(" ,MIN_VAL = @MIN_VAL ");
                    sbQuery.Append(" ,MAX_VAL = @MAX_VAL ");
                    sbQuery.Append(" ,SCOMMENT = @SCOMMENT ");
                    sbQuery.Append(" ,DATA_FLAG = @DATA_FLAG ");
                    sbQuery.Append(" , MDFY_DATE = GETDATE()");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE	   ");
                    sbQuery.Append(" AND INS_CODE = @INS_CODE	   ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "INS_CODE")) isHasColumn = false;

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
        public static void TSTD_PART_INS_UPD3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSTD_PART_INS		   ");
                    sbQuery.Append(" SET INS_SEQ = @INS_SEQ	   ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE	   ");
                    sbQuery.Append(" AND INS_CODE = @INS_CODE	   ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "INS_CODE")) isHasColumn = false;

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

        public static void TSTD_PART_INS_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSTD_PART_INS	   ");
                    sbQuery.Append(" SET DATA_FLAG = 2, ");
                    sbQuery.Append("  DEL_EMP = @DEL_EMP, ");
                    sbQuery.Append("  DEL_DATE = GETDATE(), ");
                    sbQuery.Append("  DEL_REASON = @DEL_REASON ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE	   ");
                    sbQuery.Append(" AND INS_CODE = @INS_CODE	   ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
                        if (!UTIL.ValidColumn(row, "PART_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "INS_CODE")) isHasColumn = false;

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

        public static void TSTD_PART_INS_DEL2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE TSTD_PART_INS	   ");
                    sbQuery.Append(" SET DATA_FLAG = 2, ");
                    sbQuery.Append("  DEL_EMP = @DEL_EMP, ");
                    sbQuery.Append("  DEL_DATE = GETDATE(), ");
                    sbQuery.Append("  DEL_REASON = @DEL_REASON ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND PART_CODE = @PART_CODE	   ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;
                        //검색 조건 유무 체크
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

}
