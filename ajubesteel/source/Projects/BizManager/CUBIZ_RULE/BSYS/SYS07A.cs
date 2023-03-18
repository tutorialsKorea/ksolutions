using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BizExecute;

namespace BSYS
{
    public class SYS07A
    {

        public static DataSet SYS07A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DSTD.TSTD_EMPLOYEE_QUERY.TSTD_EMPLOYEE_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt.Columns.Add("SEL");
                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        
        /// <summary>
        /// 사용자 환경 복사.
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet SYS07A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (paramDS.Tables["RQSTDT"].Rows.Count != 0)
                {
                    //원본 사용자 환경 알아옴.
                    DataTable dtCopy = paramDS.Tables["RQSTDT"].Copy();
                    dtCopy.Columns.Add("EMP_CODE");

                    foreach (DataRow dr in dtCopy.Rows)
                    {
                        dr["EMP_CODE"] = dr["SOURCE_EMP"];

                        DataTable dtSource = DSYS.TSYS_USERCONFIG_USE_QUERY.TSYS_USERCONFIG_USE_QUERY1(UTIL.GetRowToDt(dr), bizExecute);

                        //대상 사용자 환경 삭제.
                        dr["EMP_CODE"] = dr["TARGET_EMP"];
                        DSYS.TSYS_USERCONFIG_USE.TSYS_USERCONFIG_USE_DEL3(dtCopy, bizExecute);

                        //대상 사용자 환경 복사.
                        foreach (DataRow row in dtSource.Rows)
                        {
                            row["EMP_CODE"] = dtCopy.Rows[0]["TARGET_EMP"];
                        }

                        DSYS.TSYS_USERCONFIG_USE.TSYS_USERCONFIG_USE_INS(dtSource, bizExecute);
                    }

                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 사용자 환경 초기화

        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        public static DataSet SYS07A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (paramDS.Tables["RQSTDT"].Rows.Count != 0)
                {
                    DSYS.TSYS_USERCONFIG_USE.TSYS_USERCONFIG_USE_DEL3(paramDS.Tables["RQSTDT"], bizExecute);
                }

                DataSet dsResult = new DataSet();

                dsResult.Tables.Add(paramDS.Tables["RQSTDT"].Copy());
                dsResult.Tables[0].TableName = "RQSTDT";

                return paramDS;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 사용자 환경 초기화(자동 UI 변경)
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        public static DataSet SYS07A_DEL2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtParam = paramDS.Tables["RQSTDT"];
                UTIL.SetBizAddColumnToValue(dtParam, "CONFIG_NAME", dtParam.Rows[0]["USE_CONFIG_NAME"].ToString(), typeof(String));
                DSYS.TSYS_USERCONFIG_LIST.TSYS_USERCONFIG_LIST_DEL4(dtParam, bizExecute);

                DSYS.TSYS_USERCONFIG_USE.TSYS_USERCONFIG_USE_DEL4(dtParam, bizExecute);

                DataSet dsResult = new DataSet();

                dsResult.Tables.Add(dtParam.Copy());
                dsResult.Tables[0].TableName = "RQSTDT";

                return paramDS;

                
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 특정클래스 사용자 환경 초기화 (자동UI 환경)
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        public static DataSet SYS07A_DEL3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtParam = paramDS.Tables["RQSTDT"];
                DSYS.TSYS_USERCONFIG_LIST.TSYS_USERCONFIG_LIST_DEL6(dtParam, bizExecute);

                DSYS.TSYS_USERCONFIG_USE.TSYS_USERCONFIG_USE_DEL6(dtParam, bizExecute);

                DataSet dsResult = new DataSet();

                dsResult.Tables.Add(dtParam.Copy());
                dsResult.Tables[0].TableName = "RQSTDT";

                return paramDS;


            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
    }
}
