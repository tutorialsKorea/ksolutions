using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BizExecute;

namespace BSTD
{
    public class STD06A
    {
        //설비 가용 인원 설정
        public static DataSet STD06A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT3"].Rows)
                {
                    //가용 인원 삭제                    
                    DSTD.TSTD_MC_AVAILEMP.TSTD_MC_AVAILEMP_DEL(UTIL.GetRowToDt(row), bizExecute);

                    if (paramDS.Tables["RQSTDT4"].Rows.Count > 0)//데이터 여부
                    {
                        DataTable dtRqstdt2 = paramDS.Tables["RQSTDT4"].Copy();

                        UTIL.SetBizAddColumnToValue(dtRqstdt2, "PLT_CODE", row["PLT_CODE"], typeof(String));
                        UTIL.SetBizAddColumnToValue(dtRqstdt2, "MC_CODE", row["MC_CODE"], typeof(String));

                        DSTD.TSTD_MC_AVAILEMP.TSTD_MC_AVAILEMP_INS(dtRqstdt2, bizExecute);
                    }
                }

                return STD06A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
        
        /// <summary>
        /// 설비별 가용인원 설정 설비
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet STD06A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT3"], "DATA_FLAG", 0, typeof(Byte));
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "MC_OS", 0, typeof(Byte));

                DataTable dtRslt = DLSE.LSE_MACHINE_QUERY.LSE_MACHINE_QUERY1(paramDS.Tables["RQSTDT3"],  bizExecute);

                dtRslt.Columns.Add("SEL", typeof(string));
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
        /// 설비별 가용인원 조회
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet STD06A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt =  DSTD.TSTD_MC_AVAILEMP_QUERY.TSTD_MC_AVAILEMP_QUERY1(paramDS.Tables["RQSTDT"],  bizExecute);
                dtRslt.Columns.Add("SEL", typeof(string));
               
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
        /// 가능 작업자 조회
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet STD06A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "IS_SYSTEM", 0, typeof(Byte));
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "IS_ORG", "1", typeof(String));

                DataTable dtRslt = DSTD.TSTD_EMPLOYEE_QUERY.TSTD_EMPLOYEE_QUERY6(paramDS.Tables["RQSTDT"],  bizExecute);

                dtRslt.Columns.Add("SEL", typeof(string));

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
        
    }
}
