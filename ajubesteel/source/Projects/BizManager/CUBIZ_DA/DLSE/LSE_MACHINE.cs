using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace DLSE
{
    public class LSE_MACHINE
    {
        public static DataTable LSE_MACHINE_SER(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" , MC_CODE ");
                    sbQuery.Append(" , MC_NAME ");
                    sbQuery.Append(" , MC_GROUP");
                    sbQuery.Append(" , MC_AUTOMATED");
                    sbQuery.Append(" , MC_OS ");
                    sbQuery.Append(" , MC_SHIFT");
                    sbQuery.Append(" , MC_MGT_FLAG ");
                    sbQuery.Append(" , MC_OPEN_DATE");
                    sbQuery.Append(" , MC_CLOSE_DATE ");
                    sbQuery.Append(" , MC_MODEL");
                    //sbQuery.Append(" , MC_EFFICIENCY ");
                    sbQuery.Append(" , CPROC_CODE");
                    sbQuery.Append(" , CPROC_CODE2");
                    sbQuery.Append(" , MC_TYPE ");
                    sbQuery.Append(" , MC_SEQ");
                    sbQuery.Append(" , MAIN_EMP");
                    sbQuery.Append(" , VEN_CODE");
                    //sbQuery.Append(" , SCOMMENT");
                    //sbQuery.Append(" , MC_IP ");
                    sbQuery.Append(" , PLC_IP  ");
                    sbQuery.Append(" , MC_MAKER  ");
                    sbQuery.Append(" , ASSET_NO  ");
                    sbQuery.Append(" , AS_TEL  ");
                    //sbQuery.Append(" , PLC_PORT");
                    sbQuery.Append(" , IS_SIGNAL ");
                    //sbQuery.Append(" , SIGNAL_TYPE ");
                    sbQuery.Append(" , IS_OPERATE_STATE");
                    sbQuery.Append(" , IS_MULTI_START");
                    sbQuery.Append(" , MULTI_START_DIV ");
                    //sbQuery.Append(" , FTP_PORT");
                    //sbQuery.Append(" , FTP_USER");
                    //sbQuery.Append(" , FTP_USER_PW ");
                    //sbQuery.Append(" , FTP_DIR ");
                    sbQuery.Append(" , MC_IMAGE");
                    sbQuery.Append(" , REG_DATE");
                    sbQuery.Append(" , REG_EMP ");
                    sbQuery.Append(" , MDFY_DATE ");
                    sbQuery.Append(" , MDFY_EMP");
                    sbQuery.Append(" , DATA_FLAG ");
                    sbQuery.Append(" , DEL_DATE");
                    sbQuery.Append(" , DEL_EMP ");
                    sbQuery.Append(" , DEL_REASON");
                    sbQuery.Append(" FROM LSE_MACHINE");
                    sbQuery.Append(" WHERE MC_CODE = @MC_CODE");
                    sbQuery.Append(" AND PLT_CODE = @PLT_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {                        
                        bool isHasColumn = true;
                     
                        if (!UTIL.ValidColumn(row, "MC_CODE")) isHasColumn = false;

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

        public static DataTable LSE_MACHINE_SER2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT					");
                    sbQuery.Append(" PLT_CODE				");
                    sbQuery.Append(" ,MC_CODE				");
                    sbQuery.Append(" ,MC_NAME				");
                    sbQuery.Append(" FROM LSE_MACHINE		");
                    sbQuery.Append(" WHERE MC_MGT_FLAG = @MC_MGT_FLAG");
                    sbQuery.Append(" AND DATA_FLAG = @DATA_FLAG	");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "MC_MGT_FLAG")) isHasColumn = false;
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

        public static DataTable LSE_MACHINE_GETIMG(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbQuery = new StringBuilder();
                        sbQuery.Append(" SELECT PLT_CODE");
                        sbQuery.Append(" MC_IMAGE ");
                        sbQuery.Append(" FROM LSE_MACHINE");
                        sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE ");
                        sbQuery.Append(" AND MC_CODE = @MC_CODE ");                        
                    
                        bool isHasColumn = true;
                        
                        if (!UTIL.ValidColumn(row, "MC_CODE")) isHasColumn = false;

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

        public static void LSE_MACHINE_SETIMG(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE LSE_MACHINE ");
                    sbQuery.Append(" SET MC_IMAGE = @MC_IMAGE ");
                    sbQuery.Append(" WHERE MC_CODE = @MC_CODE ");
                    sbQuery.Append(" AND PLT_CODE = @PLT_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "MC_CODE")) isHasColumn = false;

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

        public static void LSE_MACHINE_UPD(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE LSE_MACHINE ");
                    sbQuery.Append(" SET MC_CODE = @MC_CODE ");
                    sbQuery.Append(" , MC_NAME = @MC_NAME ");
                    sbQuery.Append(" , MC_GROUP = @MC_GROUP ");
                    sbQuery.Append(" , MC_AUTOMATED = @MC_AUTOMATED ");
                    sbQuery.Append(" , MC_OS = @MC_OS ");
                    sbQuery.Append(" , MC_SHIFT = @MC_SHIFT ");
                    sbQuery.Append(" , MC_MGT_FLAG = @MC_MGT_FLAG ");
                    sbQuery.Append(" , MC_OPEN_DATE = @MC_OPEN_DATE ");
                    sbQuery.Append(" , MC_CLOSE_DATE = @MC_CLOSE_DATE ");
                    sbQuery.Append(" , MC_MODEL = @MC_MODEL ");
                    //sbQuery.Append(" , MC_EFFICIENCY = @MC_EFFICIENCY ");
                    sbQuery.Append(" , CPROC_CODE = @CPROC_CODE ");
                    sbQuery.Append(" , CPROC_CODE2 = @CPROC_CODE2 ");
                    sbQuery.Append(" , MC_SEQ = @MC_SEQ ");
                    sbQuery.Append(" , MAIN_EMP = @MAIN_EMP ");
                    sbQuery.Append(" , SCOMMENT = @SCOMMENT ");
                    sbQuery.Append(" , VEN_CODE = @VEN_CODE ");
                    //sbQuery.Append(" , MC_IP = @MC_IP ");
                    sbQuery.Append(" , PLC_IP = @PLC_IP ");
                    sbQuery.Append(" , MC_MAKER = @MC_MAKER ");
                    sbQuery.Append(" , ASSET_NO = @ASSET_NO ");
                    sbQuery.Append(" , AS_TEL = @AS_TEL ");
                    //sbQuery.Append(" , PLC_PORT = @PLC_PORT ");
                    sbQuery.Append(" , IS_SIGNAL = @IS_SIGNAL ");
                    //sbQuery.Append(" , SIGNAL_TYPE = @SIGNAL_TYPE ");
                    sbQuery.Append(" , IS_OPERATE_STATE = @IS_OPERATE_STATE ");
                    sbQuery.Append(" , IS_MULTI_START = @IS_MULTI_START ");
                    sbQuery.Append(" , MULTI_START_DIV = @MULTI_START_DIV ");
                    //sbQuery.Append(" , FTP_PORT = @FTP_PORT ");
                    //sbQuery.Append(" , FTP_USER = @FTP_USER ");
                    //sbQuery.Append(" , FTP_USER_PW = @FTP_USER_PW ");
                    //sbQuery.Append(" , FTP_DIR = @FTP_DIR ");
                    //sbQuery.Append(" , IF_MC_CODE = @IF_MC_CODE ");
                    sbQuery.Append(" , MC_IMAGE = @MC_IMAGE ");
                    sbQuery.Append(" , MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" , MDFY_EMP = "+ UTIL.GetValidValue(ConnInfo.UserID) );
                    sbQuery.Append(" , DATA_FLAG = 0 ");
                    sbQuery.Append(" WHERE MC_CODE = @MC_CODE ");
                    sbQuery.Append(" AND PLT_CODE = @PLT_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "MC_CODE")) isHasColumn = false;

                        if (isHasColumn == true)
                        {                            
                            bizExecute.executeUpdateQuery(sbQuery.ToString() , row);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }


        //담당자 정보 변경
        public static void LSE_MACHINE_UPD2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" UPDATE LSE_MACHINE");
                    sbQuery.Append(" SET MAIN_EMP = @MAIN_EMP");
                    sbQuery.Append(" , MDFY_DATE = GETDATE() ");
                    sbQuery.Append(" , MDFY_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND MC_CODE = @MC_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "MC_CODE")) isHasColumn = false;

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

        public static void LSE_MACHINE_UDE(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    
                    sbQuery.Append("   UPDATE LSE_MACHINE");
                    sbQuery.Append("   SET   DATA_FLAG = 2");
                    sbQuery.Append("   , DEL_DATE = GETDATE()");
                    sbQuery.Append(" , DEL_EMP = " + UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append("   , DEL_REASON = @DEL_REASON");
                    sbQuery.Append("   WHERE MC_CODE = @MC_CODE ");
                    sbQuery.Append("   AND PLT_CODE = @PLT_CODE");


                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "PLT_CODE")) isHasColumn = false;
                        if (!UTIL.ValidColumn(row, "MC_CODE")) isHasColumn = false;

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



        public static void LSE_MACHINE_DEL(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {

                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" DELETE FROM LSE_MACHINE ");
                    sbQuery.Append(" WHERE PLT_CODE = @PLT_CODE");
                    sbQuery.Append(" AND MC_CODE = @MC_CODE");

                    foreach (DataRow row in dtParam.Rows)
                    {

                        bool isHasColumn = true;

                        if (!UTIL.ValidColumn(row, "MC_CODE")) isHasColumn = false;

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


        public static void LSE_MACHINE_INS(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();
                    sbQuery.Append(" INSERT INTO LSE_MACHINE");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" PLT_CODE");
                    sbQuery.Append(" , MC_CODE ");
                    sbQuery.Append(" , MC_NAME ");
                    sbQuery.Append(" , MC_GROUP");
                    sbQuery.Append(" , MC_AUTOMATED");
                    sbQuery.Append(" , MC_OS ");
                    sbQuery.Append(" , MC_SHIFT");
                    sbQuery.Append(" , MC_MGT_FLAG ");
                    sbQuery.Append(" , MC_OPEN_DATE");
                    sbQuery.Append(" , MC_CLOSE_DATE ");
                    sbQuery.Append(" , MC_MODEL");
                    //sbQuery.Append(" , MC_EFFICIENCY ");
                    sbQuery.Append(" , CPROC_CODE");
                    sbQuery.Append(" , CPROC_CODE2");
                    sbQuery.Append(" , MC_TYPE ");
                    sbQuery.Append(" , MC_SEQ");
                    sbQuery.Append(" , MAIN_EMP");
                    sbQuery.Append(" , SCOMMENT");
                    sbQuery.Append(" , VEN_CODE");
                    sbQuery.Append(" , IS_OPERATE_STATE");
                    sbQuery.Append(" , IS_MULTI_START");
                    sbQuery.Append(" , MULTI_START_DIV ");
                    sbQuery.Append(" , PLC_IP  ");
                    sbQuery.Append(" , MC_MAKER  ");
                    sbQuery.Append(" , ASSET_NO  ");
                    sbQuery.Append(" , AS_TEL  ");
                    //sbQuery.Append(" , FTP_PORT");
                    //sbQuery.Append(" , FTP_USER");
                    //sbQuery.Append(" , FTP_USER_PW ");
                    //sbQuery.Append(" , FTP_DIR ");
                    //sbQuery.Append(" , IF_MC_CODE");
                    //sbQuery.Append(" , MC_IMAGE");
                    sbQuery.Append(" , REG_DATE");
                    sbQuery.Append(" , REG_EMP ");
                    sbQuery.Append(" , DATA_FLAG ");
                    sbQuery.Append(" ) ");
                    sbQuery.Append(" VALUES");
                    sbQuery.Append(" ( ");
                    sbQuery.Append(" @PLT_CODE ");
                    sbQuery.Append(" , @MC_CODE");
                    sbQuery.Append(" , @MC_NAME");
                    sbQuery.Append(" , @MC_GROUP ");
                    sbQuery.Append(" , @MC_AUTOMATED ");
                    sbQuery.Append(" , @MC_OS");
                    sbQuery.Append(" , @MC_SHIFT ");
                    sbQuery.Append(" , @MC_MGT_FLAG");
                    sbQuery.Append(" , @MC_OPEN_DATE ");
                    sbQuery.Append(" , @MC_CLOSE_DATE");
                    sbQuery.Append(" , @MC_MODEL ");
                    //sbQuery.Append(" , @MC_EFFICIENCY");
                    sbQuery.Append(" , @CPROC_CODE ");
                    sbQuery.Append(" , @CPROC_CODE2 ");
                    sbQuery.Append(" , 0");
                    sbQuery.Append(" , @MC_SEQ ");
                    sbQuery.Append(" , @MAIN_EMP ");
                    sbQuery.Append(" , @SCOMMENT ");
                    sbQuery.Append(" , @VEN_CODE");
                    sbQuery.Append(" , @IS_OPERATE_STATE ");
                    sbQuery.Append(" , @IS_MULTI_START ");
                    sbQuery.Append(" , @MULTI_START_DIV");
                    sbQuery.Append(" , @PLC_IP  ");
                    sbQuery.Append(" , @MC_MAKER  ");
                    sbQuery.Append(" , @ASSET_NO  ");
                    sbQuery.Append(" , @AS_TEL  ");
                    //sbQuery.Append(" , @FTP_PORT ");
                    //sbQuery.Append(" , @FTP_USER ");
                    //sbQuery.Append(" , @FTP_USER_PW");
                    //sbQuery.Append(" , @FTP_DIR");
                    //sbQuery.Append(" , @IF_MC_CODE ");
                    sbQuery.Append(" , GETDATE() ");
                    sbQuery.Append(" , "+ UTIL.GetValidValue(ConnInfo.UserID));
                    sbQuery.Append(" , 0");
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

    }

    public class LSE_MACHINE_QUERY
    {


        //설비 기준정보 불러오기
        public static DataTable LSE_MACHINE_QUERY1(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT PLT_CODE ");
                    sbQuery.Append(" ,MC_CODE");
                    sbQuery.Append(" ,MC_NAME");
                    sbQuery.Append(" ,MC_GROUP ");
                    sbQuery.Append(" ,MC_AUTOMATED ");
                    sbQuery.Append(" ,MC_OS");
                    sbQuery.Append(" ,MC_SHIFT ");
                    sbQuery.Append(" ,MC_MGT_FLAG");
                    sbQuery.Append(" ,MC_OPEN_DATE ");
                    sbQuery.Append(" ,MC_CLOSE_DATE");
                    sbQuery.Append(" ,MC_MODEL ");
                    sbQuery.Append(" ,MC_EFFICIENCY");
                    sbQuery.Append(" ,CPROC_CODE ");
                    sbQuery.Append(" ,CPROC_CODE2 ");
                    sbQuery.Append(" ,MC_TYPE");
                    sbQuery.Append(" ,MC_SEQ ");
                    sbQuery.Append(" ,MAIN_EMP ");
                    sbQuery.Append(" ,SCOMMENT ");
                    sbQuery.Append(" ,REG_DATE ");
                    sbQuery.Append(" ,REG_EMP");
                    sbQuery.Append(" ,MDFY_DATE");
                    sbQuery.Append(" ,MDFY_EMP ");
                    sbQuery.Append(" ,DATA_FLAG");
                    sbQuery.Append(" ,DEL_DATE ");
                    sbQuery.Append(" ,DEL_EMP");
                    sbQuery.Append(" ,MC_IP");
                    sbQuery.Append(" , PLC_IP  ");
                    sbQuery.Append(" , MC_MAKER  ");
                    sbQuery.Append(" , ASSET_NO  ");
                    sbQuery.Append(" , AS_TEL  ");
                    sbQuery.Append(" ,IS_SIGNAL");
                    sbQuery.Append(" ,IS_OPERATE_STATE ");
                    sbQuery.Append(" ,FTP_PORT ");
                    sbQuery.Append(" ,FTP_USER ");
                    sbQuery.Append(" ,FTP_USER_PW");
                    sbQuery.Append(" ,FTP_DIR");
                    sbQuery.Append(" ,MC_IMAGE");
                    sbQuery.Append(" FROM LSE_MACHINE");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE PLT_CODE =" + UTIL.GetValidValue(row, "PLT_CODE").ToString().ToString());                        

                        sbWhere.Append(UTIL.GetWhere(row, "@MC_CODE", "MC_CODE = @MC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_GROUP","MC_GROUP = @MC_GROUP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_OS", "MC_OS = @MC_OS"));
                        sbWhere.Append(UTIL.GetWhere(row, "@IS_OPERATE_STATE", "IS_OPERATE_STATE = @IS_OPERATE_STATE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MAIN_EMP", "MAIN_EMP = @MAIN_EMP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_MGT_FLAG", "MC_MGT_FLAG = @MC_MGT_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_LIKE", "(MC_CODE LIKE '%' + @MC_LIKE + '%' OR MC_NAME LIKE '%' + @MC_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@DATA_FLAG", "DATA_FLAG = @DATA_FLAG"));
                        sbWhere.Append(UTIL.GetWhere(row, "@VEN_CODE", "VEN_CODE = @VEN_CODE "));

                        sbWhere.Append(" ORDER BY MC_SEQ ASC");

                        DataTable sourceTable = bizExecute.executeSelectQuery(sbQuery.ToString()+sbWhere.ToString()).Copy();

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

        public static DataTable LSE_MACHINE_QUERY2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("SELECT ");
                    sbQuery.Append(" A.PLT_CODE ");
                    sbQuery.Append(" ,A.MC_CODE ");
                    sbQuery.Append(" ,A.MC_NAME ");
                    sbQuery.Append(" ,A.MC_MODEL");
                    sbQuery.Append(" ,A.MC_GROUP");
                    sbQuery.Append(" ,A.MC_AUTOMATED");
                    sbQuery.Append(" ,A.MC_OS ");
                    sbQuery.Append(" ,A.MC_MGT_FLAG ");
                    sbQuery.Append(" ,A.MC_OPEN_DATE");
                    sbQuery.Append(" ,A.MC_CLOSE_DATE ");
                    sbQuery.Append(" ,A.MC_SEQ");
                    sbQuery.Append(" ,A.MAIN_EMP");
                    sbQuery.Append(" ,B.EMP_NAME AS MAIN_EMP_NAME ");
                    sbQuery.Append(" ,A.CPROC_CODE");
                    sbQuery.Append(" ,UM.UTC_NAME AS CPROC_NAME ");
                    sbQuery.Append(" ,A.CPROC_CODE2");
                    sbQuery.Append(" ,UM2.UTC_NAME AS CPROC_NAME2 ");
                    sbQuery.Append(" ,A.SCOMMENT");
                    sbQuery.Append(" ,A.REG_DATE");
                    sbQuery.Append(" ,A.REG_EMP ");
                    sbQuery.Append(" ,REG.EMP_NAME AS REG_EMP_NAME");
                    sbQuery.Append(" ,A.MDFY_DATE ");
                    sbQuery.Append(" ,A.MDFY_EMP");
                    sbQuery.Append(" ,MDFY.EMP_NAME AS MDFY_EMP_NAME");
                    sbQuery.Append(" ,A.MC_SHIFT");
                    sbQuery.Append(" ,A.IS_SIGNAL ");
                    sbQuery.Append(" ,A.MC_IP ");
                    sbQuery.Append(" ,A.PLC_IP  ");
                    sbQuery.Append(" ,A.MC_MAKER  ");
                    sbQuery.Append(" ,A.ASSET_NO  ");
                    sbQuery.Append(" ,A.AS_TEL  ");
                    sbQuery.Append(" ,A.PLC_PORT");
                    sbQuery.Append(" ,A.IS_OPERATE_STATE");
                    sbQuery.Append(" ,A.FTP_PORT");
                    sbQuery.Append(" ,A.FTP_USER");
                    sbQuery.Append(" ,A.FTP_USER_PW ");
                    sbQuery.Append(" ,A.FTP_DIR ");
                    sbQuery.Append(" ,A.IS_MULTI_START");
                    sbQuery.Append(" ,A.MULTI_START_DIV ");
                    sbQuery.Append(" ,A.SIGNAL_TYPE ");
                    sbQuery.Append(" ,A.IF_MC_CODE");
                    //sbQuery.Append(" ,A.MC_IMAGE");
                    sbQuery.Append(" FROM LSE_MACHINE A");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE B");
                    sbQuery.Append(" ON A.PLT_CODE = B.PLT_CODE AND A.MAIN_EMP = B.EMP_CODE ");
                    sbQuery.Append(" LEFT JOIN TCST_UNIT_COST_MASTER UM ");
                    sbQuery.Append(" ON A.PLT_CODE = UM.PLT_CODE AND A.CPROC_CODE = UM.UTC_CODE ");
                    sbQuery.Append(" LEFT JOIN TCST_UNIT_COST_MASTER UM2 ");
                    sbQuery.Append(" ON A.PLT_CODE = UM2.PLT_CODE AND A.CPROC_CODE2 = UM2.UTC_CODE ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG");
                    sbQuery.Append(" ON A.PLT_CODE = REG.PLT_CODE AND A.REG_EMP = REG.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY ");
                    sbQuery.Append(" ON A.PLT_CODE = MDFY.PLT_CODE AND A.MDFY_EMP = MDFY.EMP_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE A.PLT_CODE =" + UTIL.GetValidValue(row, "PLT_CODE").ToString() + " AND A.DATA_FLAG = 0");

                        sbWhere.Append(UTIL.GetWhere(row, "@AVAILEMP", "A.MC_CODE IN (SELECT MC_CODE  FROM TSTD_MC_AVAILEMP WHERE  PLT_CODE = A.PLT_CODE AND EMP_CODE = @AVAILEMP)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_CODE", "A.MC_CODE = @MC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_NAME", "A.MC_NAME = @MC_NAME"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_GROUP", "A.MC_GROUP = @MC_GROUP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_LIKE", "(A.MC_CODE LIKE '%' + @MC_LIKE + '%' OR A.MC_NAME LIKE '%' + @MC_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_MODEL_LIKE", "(A.MC_MODEL LIKE '%' + @MC_MODEL_LIKE + '%')"));

                        sbWhere.Append(" ORDER BY A.MC_SEQ");

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

        //20160407 김준구 - 설비 기준정보 불러오기(이미지 필드 포함)
        public static DataTable LSE_MACHINE_QUERY3(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append("SELECT ");
                    sbQuery.Append(" A.PLT_CODE ");
                    sbQuery.Append(" ,A.MC_CODE ");
                    sbQuery.Append(" ,A.MC_NAME ");
                    sbQuery.Append(" ,A.MC_MODEL");
                    sbQuery.Append(" ,A.MC_GROUP");
                    sbQuery.Append(" ,A.MC_AUTOMATED");
                    sbQuery.Append(" ,A.MC_OS ");
                    sbQuery.Append(" ,A.MC_MGT_FLAG ");
                    sbQuery.Append(" ,A.MC_OPEN_DATE");
                    sbQuery.Append(" ,A.MC_CLOSE_DATE ");
                    sbQuery.Append(" ,A.MC_SEQ");
                    sbQuery.Append(" ,A.MAIN_EMP");
                    sbQuery.Append(" ,B.EMP_NAME AS MAIN_EMP_NAME ");
                    sbQuery.Append(" ,A.VEN_CODE ");
                    sbQuery.Append(" ,V.VEN_NAME  ");
                    sbQuery.Append(" ,A.CPROC_CODE");
                    sbQuery.Append(" ,UM.UTC_NAME AS CPROC_NAME ");
                    sbQuery.Append(" ,A.CPROC_CODE2");
                    sbQuery.Append(" ,UM2.UTC_NAME AS CPROC_NAME2 ");
                    sbQuery.Append(" ,A.SCOMMENT");
                    sbQuery.Append(" ,A.REG_DATE");
                    sbQuery.Append(" ,A.REG_EMP ");
                    sbQuery.Append(" ,REG.EMP_NAME AS REG_EMP_NAME");
                    sbQuery.Append(" ,A.MDFY_DATE ");
                    sbQuery.Append(" ,A.MDFY_EMP");
                    sbQuery.Append(" ,MDFY.EMP_NAME AS MDFY_EMP_NAME");
                    sbQuery.Append(" ,A.MC_SHIFT");
                    sbQuery.Append(" ,A.IS_SIGNAL ");
                    sbQuery.Append(" ,A.MC_IP ");
                    sbQuery.Append(" ,A.PLC_IP  ");
                    sbQuery.Append(" ,A.MC_MAKER  ");
                    sbQuery.Append(" ,A.ASSET_NO  ");
                    sbQuery.Append(" ,A.AS_TEL  ");
                    sbQuery.Append(" ,A.PLC_PORT");
                    sbQuery.Append(" ,A.IS_OPERATE_STATE");
                    sbQuery.Append(" ,A.FTP_PORT");
                    sbQuery.Append(" ,A.FTP_USER");
                    sbQuery.Append(" ,A.FTP_USER_PW ");
                    sbQuery.Append(" ,A.FTP_DIR ");
                    sbQuery.Append(" ,A.IS_MULTI_START");
                    sbQuery.Append(" ,A.MULTI_START_DIV ");
                    sbQuery.Append(" ,A.SIGNAL_TYPE ");
                    sbQuery.Append(" ,A.IF_MC_CODE");
                    sbQuery.Append(" ,A.MC_IMAGE");

  

                    sbQuery.Append(" FROM LSE_MACHINE A");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE B");
                    sbQuery.Append(" ON A.PLT_CODE = B.PLT_CODE AND A.MAIN_EMP = B.EMP_CODE ");
                    sbQuery.Append(" LEFT JOIN TCST_UNIT_COST_MASTER UM ");
                    sbQuery.Append(" ON A.PLT_CODE = UM.PLT_CODE AND A.CPROC_CODE = UM.UTC_CODE ");
                    sbQuery.Append(" LEFT JOIN TCST_UNIT_COST_MASTER UM2 ");
                    sbQuery.Append(" ON A.PLT_CODE = UM2.PLT_CODE AND A.CPROC_CODE2 = UM2.UTC_CODE ");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE REG");
                    sbQuery.Append(" ON A.PLT_CODE = REG.PLT_CODE AND A.REG_EMP = REG.EMP_CODE");
                    sbQuery.Append(" LEFT JOIN TSTD_EMPLOYEE MDFY ");
                    sbQuery.Append(" ON A.PLT_CODE = MDFY.PLT_CODE AND A.MDFY_EMP = MDFY.EMP_CODE ");
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V ");
                    sbQuery.Append(" ON A.PLT_CODE = V.PLT_CODE AND A.VEN_CODE = V.VEN_CODE ");

                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE A.PLT_CODE =" + UTIL.GetValidValue(row, "PLT_CODE").ToString() + " AND A.DATA_FLAG = 0");

                        sbWhere.Append(UTIL.GetWhere(row, "@AVAILEMP", "A.MC_CODE IN (SELECT MC_CODE  FROM TSTD_MC_AVAILEMP WHERE  PLT_CODE = A.PLT_CODE AND EMP_CODE = @AVAILEMP)"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_CODE", "A.MC_CODE = @MC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_NAME", "A.MC_NAME = @MC_NAME"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_LIKE", "(A.MC_CODE LIKE '%' + @MC_LIKE + '%' OR A.MC_NAME LIKE '%' + @MC_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_MODEL_LIKE", "(A.MC_MODEL LIKE '%' + @MC_MODEL_LIKE + '%')"));

                        sbWhere.Append(" ORDER BY A.MC_SEQ");

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

        public static DataTable LSE_MACHINE_QUERY4(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT  ");
                    sbQuery.Append(" M.PLT_CODE  ");
                    sbQuery.Append(" ,M.MC_GROUP  ");
                    sbQuery.Append(" ,M.MC_CODE  ");
                    sbQuery.Append(" ,M.MC_NAME ");
                    sbQuery.Append(" ,CASE WHEN A.MC_CODE IS NOT NULL THEN 1 ");
                    sbQuery.Append(" WHEN IDLE.MC_CODE IS NOT NULL THEN 2 ");
                    sbQuery.Append(" ELSE 0 END AS MC_STAT ");
                    sbQuery.Append(" FROM LSE_MACHINE M ");
                    sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE, MC_CODE FROM TSHP_ACTUAL ACT WHERE PROC_STAT = 2 ");
                    sbQuery.Append(" AND WO_NO IN (SELECT WO_NO FROM TSHP_WORKORDER WHERE PLT_CODE = ACT.PLT_CODE AND DATA_FLAG = 0) GROUP BY PLT_CODE, MC_CODE) A  ");
                    sbQuery.Append(" ON M.PLT_CODE = A.PLT_CODE ");
                    sbQuery.Append(" AND M.MC_CODE = A.MC_CODE ");

                    sbQuery.Append(" LEFT JOIN (SELECT PLT_CODE,MC_CODE FROM TSHP_IDLETIME WHERE IDLE_STATE = 1 GROUP BY PLT_CODE, MC_CODE) IDLE ");
                    sbQuery.Append(" ON M.PLT_CODE = IDLE.PLT_CODE ");
                    sbQuery.Append(" AND M.MC_CODE = IDLE.MC_CODE ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE M.PLT_CODE =" + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@MC_CODE", "M.MC_CODE = @MC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_GROUP", "M.MC_GROUP = @MC_GROUP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_LIKE", "(A.MC_CODE LIKE '%' + @MC_LIKE + '%' OR A.MC_NAME LIKE '%' + @MC_LIKE + '%')"));
                        sbWhere.Append(" AND M.DATA_FLAG = 0");

                        sbWhere.Append(" ORDER BY M.MC_GROUP, M.MC_NAME");

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
        /// 설비별 가동시간 현황 설비 리스트 가져오기
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable LSE_MACHINE_QUERY5(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT   ");
                    sbQuery.Append(" M.PLT_CODE   ");
                    sbQuery.Append(" ,M.MC_CODE   ");
                    sbQuery.Append(" ,M.MC_NAME  ");
                    sbQuery.Append(" ,M.MC_MAKER  ");
                    sbQuery.Append(" ,M.VEN_CODE  ");
                    sbQuery.Append(" FROM LSE_MACHINE M ");



                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE M.PLT_CODE =" + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(UTIL.GetWhere(row, "@MC_CODE", "M.MC_CODE = @MC_CODE"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_GROUP", "M.MC_GROUP = @MC_GROUP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_GRP", "M.MC_GROUP = @MC_GRP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_GROUP", "M.MC_GROUP = @MC_GROUP"));
                        sbWhere.Append(UTIL.GetWhere(row, "@MC_LIKE", "(M.MC_CODE LIKE '%' + @MC_LIKE + '%' OR MC_NAME LIKE '%' + @MC_LIKE + '%')"));
                        //sbWhere.Append(UTIL.GetWhere(row, "@SERIAL_NO_LIKE", "(M.MC_CODE LIKE '%' + @SERIAL_NO_LIKE + '%' OR MC_NAME LIKE '%' + @SERIAL_NO_LIKE + '%')"));
                        sbWhere.Append(UTIL.GetWhere(row, "@VEN_CODE", "M.VEN_CODE = @VEN_CODE"));
                        sbWhere.Append(" AND M.DATA_FLAG = 0");

                        sbWhere.Append(" ORDER BY ISNULL(M.MC_SEQ, 0)");

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

        //일일업무계획 조회
        public static DataTable LSE_MACHINE_QUERY6(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                if (dtParam.Rows.Count > 0)
                {
                    StringBuilder sbQuery = new StringBuilder();

                    sbQuery.Append(" SELECT																												   ");
                    sbQuery.Append(" M.PLT_CODE																											   ");
                    sbQuery.Append(" ,M.MC_CODE																											   ");
                    sbQuery.Append(" ,M.MC_NAME																											   ");
                    sbQuery.Append(" ,W.PROD_CODE																										   ");
                    sbQuery.Append(" ,I.ITEM_CODE																										   ");
                    sbQuery.Append(" ,I.ITEM_NAME																										   ");
                    sbQuery.Append(" ,I.CVND_CODE																										   ");
                    sbQuery.Append(" ,V.VEN_NAME AS CVND_NAME																							   ");
                    sbQuery.Append(" ,SP.PART_NAME																										   ");
                    sbQuery.Append(" ,W.PROC_CODE																										   ");
                    sbQuery.Append(" ,PR.PROC_NAME																										   ");
                    sbQuery.Append(" ,W.EMP_CODE																										   ");
                    sbQuery.Append(" ,W.PART_CODE																										   ");
                    sbQuery.Append(" ,W.PART_QTY																										   ");
                    sbQuery.Append(" ,(SELECT ISNULL(SUM(OK_QTY),0) FROM TSHP_ACTUAL A WHERE A.WO_NO = W.WO_NO) AS TOTAL_ACT_QTY						   ");
                    sbQuery.Append(" ,(SELECT ISNULL(SUM(OK_QTY),0) FROM TSHP_ACTUAL A WHERE A.WO_NO = W.WO_NO AND A.WORK_DATE = @PLN_DATE) AS DAY_ACT_QTY");
                    sbQuery.Append(" ,SP.DRAW_NO																										   ");
                    sbQuery.Append(" ,W.PLN_START_TIME		");
                    sbQuery.Append(" ,W.PLN_END_TIME    ");
                    sbQuery.Append(" ,M.MC_SEQ      																									   ");
                    sbQuery.Append(" FROM LSE_MACHINE M																									   ");
                    sbQuery.Append(" LEFT JOIN TSHP_WORKORDER W																							   ");
                    sbQuery.Append(" ON W.PLT_CODE = M.PLT_CODE																							   ");
                    sbQuery.Append(" AND W.MC_CODE = M.MC_CODE																							   ");
                    //sbQuery.Append(" AND LEFT(W.PLN_END_TIME,8) = @PLN_DATE 																			   ");
                    //sbQuery.Append(" AND ( LEFT(W.PLN_START_TIME,8) >= @PLN_DATE OR LEFT(	W.PLN_END_TIME, 8) <= @PLN_DATE )    ");
                    sbQuery.Append(" AND @PLN_DATE BETWEEN LEFT(PLN_START_TIME, 8) AND LEFT(PLN_END_TIME, 8) ");
                    sbQuery.Append(" AND W.DATA_FLAG = '0'  																							   ");
                    sbQuery.Append(" 																													   ");
                    sbQuery.Append(" LEFT JOIN TORD_PRODUCT P																							   ");
                    sbQuery.Append(" ON W.PLT_CODE = P.PLT_CODE																							   ");
                    sbQuery.Append(" AND W.PROD_CODE = P.PROD_CODE																						   ");
                    sbQuery.Append(" AND P.PARENT_PART IS NULL																							   ");
                    
                    sbQuery.Append(" LEFT JOIN TORD_ITEM I																								   ");
                    sbQuery.Append(" ON P.PLT_CODE = I.PLT_CODE																							   ");
                    sbQuery.Append(" AND P.ITEM_CODE = I.ITEM_CODE																						   ");
                    
                    sbQuery.Append(" LEFT JOIN TSTD_VENDOR V																							   ");
                    sbQuery.Append(" ON I.PLT_CODE = V.PLT_CODE																							   ");
                    sbQuery.Append(" AND I.CVND_CODE = V.VEN_CODE																						   ");
                    
                    sbQuery.Append(" LEFT JOIN LSE_STD_PART SP																							   ");
                    sbQuery.Append(" ON W.PLT_CODE = SP.PLT_CODE																						   ");
                    sbQuery.Append(" AND W.PART_CODE = SP.PART_CODE																						   ");

                    sbQuery.Append(" LEFT JOIN LSE_STD_PROC PR																							   ");
                    sbQuery.Append(" ON W.PLT_CODE = PR.PLT_CODE																						   ");
                    sbQuery.Append(" AND W.PROC_CODE = PR.PROC_CODE																						   ");


                    foreach (DataRow row in dtParam.Rows)
                    {
                        StringBuilder sbWhere = new StringBuilder(" WHERE M.PLT_CODE =" + UTIL.GetValidValue(row, "PLT_CODE").ToString());

                        sbWhere.Append(" AND M.DATA_FLAG = '0' AND M.MC_MGT_FLAG = '1'");

                        sbWhere.Append(" ORDER BY ISNULL(M.MC_SEQ, 0)");

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
