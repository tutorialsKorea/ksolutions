using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BSTD
{
    public class STD13A
    {
        public static DataSet STD13A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSTD.TSTD_ORG_QUERY.TSTD_ORG_QUERY2(paramDS.Tables["RQSTDT"],  bizExecute);

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

        public static  DataSet STD13A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //if (!paramDS.Tables["RQSTDT"].Columns.Contains("DATA_FLAG"))
                //    paramDS.Tables["RQSTDT"].Columns.Add("DATA_FLAG");

                //foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                //{
                //    row["DATA_FLAG"] = 0;
                //}

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSTD.TSTD_EMPLOYEE_QUERY.TSTD_EMPLOYEE_QUERY1(paramDS.Tables["RQSTDT"],  bizExecute);

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

        public static DataSet STD13A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSTD.TSTD_EMPLOYEE.TSTD_EMPLOYEE_SER4(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }


        // 부서 조회
        public static DataSet STD13A_SER4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                // DataTable dtRslt = DSTD.TSTD_ORG.TSTD_ORG_SER(paramDS.Tables["RQSTDT"], bizExecute);
                
                DataTable dtRslt = DSTD.TSTD_ORG_QUERY.TSTD_ORG_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }





        public static DataSet STD13A_SER5(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSTD.TSTD_ORG_REF_EMP_QUERY.TSTD_ORG_REF_EMP_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

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




        public static void STD13A_UPD(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "NEW_PASSWORD", ConnInfo.INIT_PWD, typeof(String));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DSTD.TSTD_EMPLOYEE.TSTD_EMPLOYEE_UPD3(UTIL.GetRowToDt(row), bizExecute);
                }

                return;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        //조직 그룹 추가
        public static DataSet STD13A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {

                    DataTable dtSer = DSTD.TSTD_ORG.TSTD_ORG_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (dtSer.Rows.Count > 0)
                    {
                        if (row["OVERWRITE"].Equals("1"))
                        {
                            DSTD.TSTD_ORG.TSTD_ORG_UPD(UTIL.GetRowToDt(row), bizExecute);
                        }
                        else
                        {
                            if (dtSer.Rows[0]["DATA_FLAG"].Equals((byte)2))
                            {
                                throw UTIL.SetException("동일 데이터가 이력이 존재할때 발생"
                                    , row["ORG_CODE"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.OVERWRITE_HISTORY, dtSer.Rows[0]);

                            }
                            else
                            {
                                throw UTIL.SetException("동일 데이터가 존재할때 발생"
                                    , row["ORG_CODE"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.OVERWRITE);
                            }
                        }
                    }
                    else
                    {
                        DSTD.TSTD_ORG.TSTD_ORG_INS(UTIL.GetRowToDt(row), bizExecute);
                    }


                    DSTD.TSTD_ORG_REF_EMP.TSTD_ORG_REF_EMP_DEL(UTIL.GetRowToDt(row), bizExecute);

                    if (paramDS.Tables.Contains("RQSTDT2"))
                    {
                        if (paramDS.Tables["RQSTDT2"].Rows.Count != 0)
                        {
                            UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT2"], "ORG_CODE", row["ORG_CODE"].ToString(), typeof(string));
                            UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT2"], "DATA_FLAG", 0, typeof(byte));

                            foreach (DataRow row2 in paramDS.Tables["RQSTDT2"].Rows)
                            {
                                DSTD.TSTD_ORG_REF_EMP.TSTD_ORG_REF_EMP_INS(UTIL.GetRowToDt(row2), bizExecute);
                            }
                        }
                    }

                }

                return STD13A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        //사원 추가
        public static DataSet STD13A_INS2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                if (!paramDS.Tables["RQSTDT"].Columns.Contains("IS_SYSTEM"))
                    paramDS.Tables["RQSTDT"].Columns.Add("IS_SYSTEM",typeof(byte));

                DataTable dtEmpConf = DSYS.TSYS_EMP_CONF_LIST_QUERY.TSYS_EMP_CONF_LIST_QUERY2(bizExecute);

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"],"IS_SYSTEM",0, typeof(byte));
                

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    
                    if(row["EMP_CODE"].ToString().ToUpper().Equals("@ACTIVE") || row["EMP_CODE"].ToString().ToUpper().Equals("@SYSTEM"))
                    {
                        throw UTIL.SetException("사원코드가 시스템 예약어로 등록되어있습니다."
                                    , row["EMP_CODE"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.SYSTEM_REG);
                    }

                    DataTable dtSer = DSTD.TSTD_EMPLOYEE.TSTD_EMPLOYEE_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (dtSer.Rows.Count > 0)
                    {
                        if (dtSer.Rows[0]["IS_SYSTEM"].Equals((byte)1))
                        {
                            throw UTIL.SetException("사원코드가 시스템 예약어로 등록되어있습니다."
                                    , row["EMP_CODE"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.SYSTEM_REG);
                        }

                        if (row["OVERWRITE"].Equals("1"))
                        {
                            DSTD.TSTD_EMPLOYEE.TSTD_EMPLOYEE_UPD(UTIL.GetRowToDt(row), bizExecute);
                        }
                        else
                        {
                            if (dtSer.Rows[0]["DATA_FLAG"].Equals((byte)2))
                            {
                                throw UTIL.SetException("동일 데이터가 이력이 존재할때 발생"
                                    , row["EMP_CODE"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.OVERWRITE_HISTORY, dtSer.Rows[0]);

                            }
                            else
                            {
                                throw UTIL.SetException("동일 데이터가 존재할때 발생"
                                    , row["EMP_CODE"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.OVERWRITE);
                            }
                        }
                    }
                    else
                    {
                        UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"],"ACC_PWD","EMP_CODE");

                        DSTD.TSTD_EMPLOYEE.TSTD_EMPLOYEE_INS(UTIL.GetRowToDt(row), bizExecute);

                        row["ACC_PWD"] = "";

                        if (dtEmpConf.Rows.Count > 0)
                        {
                            //if (!dtEmpConf.Columns.Contains("PLT_CODE")) dtEmpConf.Columns.Add("PLT_CODE");
                            //if (!dtEmpConf.Columns.Contains("EMP_CODE")) dtEmpConf.Columns.Add("EMP_CODE");

                            //foreach(DataRow confRow in dtEmpConf.Rows)
                            //{
                            //    confRow["PLT_CODE"] = row["PLT_CODE"];
                            //    confRow["EMP_CODE"] = row["EMP_CODE"];
                            //}

                            UTIL.SetBizAddColumnToValue(dtEmpConf, "PLT_CODE", row["PLT_CODE"], typeof(String));
                            UTIL.SetBizAddColumnToValue(dtEmpConf, "EMP_CODE", row["EMP_CODE"], typeof(String));
                            UTIL.SetBizAddColumnToValue(dtEmpConf, "CONF_VALUE", "DEF_VALUE");

                            DSYS.TSYS_EMP_CONF.TSYS_EMP_CONF_INS(dtEmpConf, bizExecute);
                        }
                    }

                  

                }

                return STD13A_SER2(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 부서 삭제
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet STD13A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtSer = DSTD.TSTD_EMPLOYEE_QUERY.TSTD_EMPLOYEE_QUERY1(UTIL.GetRowToDt(row), bizExecute);

                    if(dtSer.Rows.Count > 0)
                    {
                        //삭제 물은 여부
                        if (!row["OVERDEL"].Equals("1"))
                        {
                            throw UTIL.SetException("삭제하고자 하는 부서에 속해있는 사원이 존재합니다."
                                    , row["ORG_CODE"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , 200012);
                        }

                        //UTIL.SetBizAddColumnToValue(dtSer, "DEL_EMP", row["DEL_EMP"],typeof(String));
                        UTIL.SetBizAddColumnToValue(dtSer, "DEL_REASON", row["DEL_REASON"], typeof(String));                        
                        dtSer.TableName = "RQSTDT";

                        STD13A_DEL2(UTIL.GetDtToDs(dtSer), bizExecute);
                    }

                    DSTD.TSTD_ORG.TSTD_ORG_UDE(UTIL.GetRowToDt(row), bizExecute);
                }

                
                return paramDS;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        /// <summary>
        /// 사원 삭제
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet STD13A_DEL2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "MAIN_EMP", "EMP_CODE");

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    //기준정보 삭제
                    DSTD.TSTD_EMPLOYEE.TSTD_EMPLOYEE_UDE(UTIL.GetRowToDt(row), bizExecute);
                    //설비 가용 인원 삭제
                    DSTD.TSTD_MC_AVAILEMP.TSTD_MC_AVAILEMP_DEL2(UTIL.GetRowToDt(row), bizExecute);                    
                    //담당자별 설비 담당자 확인
                    DataTable dtSerMc = DLSE.LSE_MACHINE_QUERY.LSE_MACHINE_QUERY1(UTIL.GetRowToDt(row), bizExecute);                    
                    //설비담당자 변경 null로
                    UTIL.SetBizAddColumnToValue(dtSerMc, "MAIN_EMP", null, typeof(String));
                    DLSE.LSE_MACHINE.LSE_MACHINE_UPD2(dtSerMc,bizExecute);
                    //사용자 환경 삭제
                    UTIL.GetRowToDt(row).TableName = "RQSTDT";
                    CTRL.CTRL.SET_USERCONFIG_DEL2(UTIL.GetDtToDs(UTIL.GetRowToDt(row)),bizExecute);
                    //사용자 환경 변수 삭제
                    DSYS.TSYS_EMP_CONF.TSYS_EMP_CONF_DEL2(UTIL.GetRowToDt(row), bizExecute);
                }


                return paramDS;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }
    }
}
