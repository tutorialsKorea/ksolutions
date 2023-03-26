using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BizExecute;

namespace BSTD
{
    public class STD60A
    {
        /// <summary>
        /// 분류코드 추가
        /// 0. DATA_FLAG 추가
        /// 1. 분류 코드 테이블 조회하여 SYS_CODECAT_SER
        /// 2. 데이터 없으면 INSERT,
        /// 3. 데이터 있으면, 삭제 여부 판단하여 삭제된 데이터는 UPD,
        ///    삭제되지 않은 데이터이면 동일 데이터 존재한다는 오류 메시지 발행한다.
        /// </summary>
        /// <param name="paramDS"></param>
        public static DataSet STD60A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {

                    DataTable dtSer = DSYS.TSYS_CODECAT.TSYS_CODECAT_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (dtSer.Rows.Count > 0)
                    {
                        if (row["OVERWRITE"].Equals("1"))
                        {
                            DSYS.TSYS_CODECAT.TSYS_CODECAT_UPD(UTIL.GetRowToDt(row), bizExecute);
                        }
                        else
                        {
                            if (dtSer.Rows[0]["DATA_FLAG"].Equals((byte)2))
                            {
                                throw UTIL.SetException("동일 데이터가 이력이 존재할때 발생"
                                    , row["CAT_CODE"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.OVERWRITE_HISTORY, dtSer.Rows[0]);

                            }
                            else
                            {
                                throw UTIL.SetException("동일 데이터가 존재할때 발생"
                                    , row["CAT_CODE"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.OVERWRITE);
                            }
                        }
                    }
                    else
                    {
                        DSYS.TSYS_CODECAT.TSYS_CODECAT_INS(UTIL.GetRowToDt(row), bizExecute);
                    }

                }

                return STD60A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 표준코드 추가
        /// 1. 해당 코드분류 조회
        /// 2. 코드분류가 고정코드일 경우 시스템 계정이면 변경 가능, 그 외 계정은 변경 불가.
        /// 3. 고정코드 아닐 경우 표준코드 조회
        /// 4. 데이터가 있을 경우, 변경 혹은 삭제된 데이터인 경우, 덮어쓰기 할거면 tstd_codes_upd
        /// 5. 데이터가 없을 경우, tstd_codes_ins
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet STD60A_INS2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtSer = DSTD.TSTD_CODES.TSTD_CODES_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (dtSer.Rows.Count > 0)
                    {
                        if (row["OVERWRITE"].Equals("1"))
                        {
                            DSTD.TSTD_CODES.TSTD_CODES_UPD(UTIL.GetRowToDt(row), bizExecute);
                        }
                        else
                        {
                            if (dtSer.Rows[0]["DATA_FLAG"].Equals((byte)2))
                            {
                                throw UTIL.SetException("동일 데이터가 이력이 존재할때 발생"
                                    , row["CD_CODE"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.OVERWRITE_HISTORY, dtSer.Rows[0]);

                            }
                            else
                            {
                                throw UTIL.SetException("동일 데이터가 존재할때 발생"
                                    , row["CD_CODE"].ToString()
                                    , new System.Diagnostics.StackFrame().GetMethod().Name
                                    , BizException.OVERWRITE);
                            }
                        }
                    }
                    else
                    {
                        DSTD.TSTD_CODES.TSTD_CODES_INS(UTIL.GetRowToDt(row), bizExecute);
                    }

                }

                return STD60A_SER2(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 분류코드 조회
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet STD60A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(byte));

                //DataTable dtRslt = DSTD.TSTD_PANEL_MASTER_QUERY.TSTD_PANEL_MASTER_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                DataTable dtRslt = DSTD.TSTD_CODES_QUERY.TSTD_CODES_QUERY7(paramDS.Tables["RQSTDT"], bizExecute);

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

        public static DataSet STD60A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSTD.TSTD_CODES_QUERY.TSTD_CODES_QUERY7(paramDS.Tables["RQSTDT"], bizExecute);

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
        /// 분류코드 삭제
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet STD60A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DSYS.TSYS_CODECAT.TSYS_CODECAT_UDE(paramDS.Tables["RQSTDT"], bizExecute);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        /// <summary>
        /// 표준코드 삭제
        /// 1.tsys_codecat 조회
        /// 2. 분류코드가 고정 코드이면 (is_fixed_cd==1)
        /// 3. 접속자가 시스템 계정(tstd_employee.is_system=1)일 경우 삭제
        /// 4. 그렇지 않은 경우 삭제 불가.
        /// </summary>
        /// <param name="paramDS"></param>
        public static DataSet STD60A_DEL2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                bool bUpdatable = false;

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {


                    //1. tsys_codecat 조회
                    //DataTable dtRsltCat = SQL.SQL_GETDATA("TSYS_CODECAT_SER2", dtSysCat);
                    DataTable dtRsltCat = DSYS.TSYS_CODECAT.TSYS_CODECAT_SER2(UTIL.GetRowToDt(row), bizExecute);

                    if (dtRsltCat.Rows.Count > 0)
                    {
                        if (object.Equals(dtRsltCat.Rows[0]["IS_FIXED_CD"], (byte)1))
                        {
                            //2.tstd_employee 조회
                            DataTable paramEmp = new DataTable("RQSTDT");
                            paramEmp.Columns.Add("PLT_CODE", typeof(String));
                            paramEmp.Columns.Add("EMP_CODE", typeof(String));

                            DataRow paramDr = paramEmp.NewRow();
                            paramDr["PLT_CODE"] = row["PLT_CODE"];
                            paramDr["EMP_CODE"] = row["DEL_EMP"];
                            paramEmp.Rows.Add(paramDr);


                            //DataTable dtEmp = SQL.SQL_GETDATA("TSTD_EMPLOYEE_SER", paramEmp);
                            DataTable dtEmp = DSTD.TSTD_EMPLOYEE.TSTD_EMPLOYEE_SER(paramEmp, bizExecute);

                            if (dtEmp.Rows.Count > 0)
                            {
                                if (object.Equals(dtEmp.Rows[0]["IS_SYSTEM"], (byte)1))
                                    bUpdatable = true;
                                else
                                    throw UTIL.SetException("고정 분류코드는 항목을 변경할 수 없습니다."
                                        , new System.Diagnostics.StackFrame().GetMethod().Name);
                            }

                        }
                        else
                        {
                            bUpdatable = true;
                        }
                    }

                    if (bUpdatable)
                    {
                        //SQL.SQL_SETDATA("TSTD_CODES_UDE", UTIL.GetRowToDt(row), bizExecute);
                        DSTD.TSTD_CODES.TSTD_CODES_UDE(UTIL.GetRowToDt(row), bizExecute);
                    }
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
