using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BizExecute;


namespace BSTD
{
    public class STD20A
    {
        /// <summary>
        /// 사용자 그룹 조회
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet STD20A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte)); // VAR에 DATA_FLAG값 0 설정

                DataTable dtRslt = DSYS.TSYS_USERGRP_QUERY.TSYS_USERGRP_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.Columns.Add("SEL");
                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch(Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        /// <summary>
        /// 사용자 그룹별 메뉴리스트를 알아온다.
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet STD20A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                ////존재여부 검사후 진행
                ////ControlManager.acInfo.PackageType
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_ID", "Active#", typeof(String)); //
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "STD_MENU", null, typeof(Byte));
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PRO_MENU", null, typeof(Byte));
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                ////DataTable dtRslt = DSYS.TSYS_VERSION.TSYS_VERSION_SER(paramDS.Tables["RQSTDT"], bizExecute);

                //DataTable dtRsltMenu = null;

                //DataTable dtRsltMenu2 = null;

                ////if (dtRslt.Rows.Count != 0)
                ////{
                //    foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                //    {
                //        //if (ControlManager.acInfo.PackageType == ControlManager.acInfo.emPackageEditionType.Standard)
                //        ////if (object.Equals(dtRslt.Rows[0]["TYPE"], "Standard"))
                //        //{
                //        //    row["STD_MENU"] = "1";
                //        //}
                //        //else if ((ControlManager.acInfo.PackageType == ControlManager.acInfo.emPackageEditionType.Professional))
                //        {
                //            row["PRO_MENU"] = "1";
                //        }
                //    }

                //    //그룹별 가능 메뉴를 알아온다.
                //    dtRsltMenu = DSYS.TSYS_MENULIST_QUERY.TSYS_MENULIST_QUERY5(paramDS.Tables["RQSTDT"], bizExecute);

                //    //그룹별 권한정보가 없는 메뉴를 알아온다.
                //    dtRsltMenu2 = DSYS.TSYS_MENULIST_QUERY.TSYS_MENULIST_QUERY6(paramDS.Tables["RQSTDT"], bizExecute);
                ////}
                ////else
                ////{
                ////    throw new Exception("시스템 버전정보가 존재하지 않습니다.");
                ////}



                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "APP_ID", "Active#", typeof(String)); //
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "STD_MENU", null, typeof(Byte));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PRO_MENU", null, typeof(Byte));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRsltMenu = null;

                DataTable dtRsltMenu2 = null;

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    {
                        row["PRO_MENU"] = "1";
                    }
                }

                //그룹별 가능 메뉴를 알아온다.
                dtRsltMenu = DSYS.TSYS_MENULIST_QUERY.TSYS_MENULIST_QUERY5(paramDS.Tables["RQSTDT"], bizExecute);

                //그룹별 권한정보가 없는 메뉴를 알아온다.
                dtRsltMenu2 = DSYS.TSYS_MENULIST_QUERY.TSYS_MENULIST_QUERY6(paramDS.Tables["RQSTDT"], bizExecute);

                DataSet dsRslt = new DataSet();

                dsRslt.Merge(dtRsltMenu);
                dsRslt.Merge(dtRsltMenu2);

                return dsRslt;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 사용자 그룹 추가
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet STD20A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //컬럼 유요성검사
                if (!paramDS.Tables["RQSTDT"].Columns.Contains("REG_DATE")) paramDS.Tables["RQSTDT"].Columns.Add("REG_DATE", typeof(String));
                if (!paramDS.Tables["RQSTDT"].Columns.Contains("MDFY_DATE")) paramDS.Tables["RQSTDT"].Columns.Add("MDFY_DATE", typeof(String));
                if (!paramDS.Tables["RQSTDT"].Columns.Contains("MDFY_EMP")) paramDS.Tables["RQSTDT"].Columns.Add("MDFY_EMP", typeof(String));
                if (!paramDS.Tables["RQSTDT"].Columns.Contains("DATA_FLAG")) paramDS.Tables["RQSTDT"].Columns.Add("DATA_FLAG", typeof(Int32));

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));


                //현재시간
                DataTable dtNow = UTIL.UTILITY_GET_DTNOW(bizExecute);
                string dt = ((DateTime)dtNow.Rows[0]["NOW_DT"]).ToString("yyyy-MM-dd HH:mm:ss");

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    //DataTable dtRsltMenu = SQL.SQL_GETDATA("TSYS_USERGRP_SER", paramDS.Tables["RQSTDT"],  bizExecute);
                    DataTable dtRsltMenu = DSYS.TSYS_USERGRP.TSYS_USERGRP_SER(paramDS.Tables["RQSTDT"], bizExecute);

                    if (dtRsltMenu.Rows.Count != 0)
                    {
                        if (dtRsltMenu.Rows[0]["DATA_FLAG"].ToString() == "2")
                        {
                            if (paramDS.Tables["RQSTDT"].Rows[0]["OVERWRITE"].Equals("1"))
                            {
                                row["MDFY_DATE"] = dt;
                                row["MDFY_EMP"] = row["REG_EMP"];
                                row["DATA_FLAG"] = 0;
                                //SQL.SQL_SETDATA("TSYS_USERGRP_UPD", paramDS.Tables["RQSTDT"],  bizExecute);
                                //DSTD.TSTD_PROCGRP.TSTD_PROCGRP_UPD(UTIL.GetRowToDt(row), bizExecute);
                                DSYS.TSYS_USERGRP.TSYS_USERGRP_UPD(UTIL.GetRowToDt(row), bizExecute);
                            }
                            else
                            {
                                throw new Exception("동일 이력 데이터가 존재합니다.");
                            }
                        }
                        else
                        {
                            if (paramDS.Tables["RQSTDT"].Rows[0]["OVERWRITE"].Equals("1"))
                            {
                                row["MDFY_DATE"] = dt;
                                row["MDFY_EMP"] = row["REG_EMP"];
                                row["DATA_FLAG"] = 0;
                                DSYS.TSYS_USERGRP.TSYS_USERGRP_UPD(UTIL.GetRowToDt(row), bizExecute);
                            }
                            else
                            {
                                throw new Exception("동일 데이터가 존재합니다.");
                            }
                        }
                    }
                    else
                    {
                        row["REG_DATE"] = dt;
                        row["DATA_FLAG"] = 0;

                        //SQL.SQL_SETDATA("TSYS_USERGRP_INS", paramDS.Tables["RQSTDT"],  bizExecute);
                        DSYS.TSYS_USERGRP.TSYS_USERGRP_INS(UTIL.GetRowToDt(row), bizExecute);

                    }

                    dtRsltMenu.Clear();
                }


                return STD20A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet STD20A_INS2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                if (paramDS.Tables["RQSTDT"].Rows.Count != 0)
                {

                    DataTable paramDT = new DataTable("RQSTDT");
                    paramDT.Columns.Add("PLT_CODE", typeof(String)); //
                    paramDT.Columns.Add("USRGRP_CODE", typeof(String)); //

                    DataRow paramRow = paramDT.NewRow();
                    paramRow["PLT_CODE"] = paramDS.Tables["RQSTDT"].Rows[0]["PLT_CODE"];
                    paramRow["USRGRP_CODE"] = paramDS.Tables["RQSTDT"].Rows[0]["USRGRP_CODE"];
                    paramDT.Rows.Add(paramRow);

                    //SQL.SQL_SETDATA("TSYS_ACCESS_DEL2", paramDT, bizExecute);
                    DSYS.TSYS_ACCESS.TSYS_ACCESS_DEL2(paramDS.Tables["RQSTDT"], bizExecute);

                }

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    //SQL.SQL_SETDATA("TSYS_ACCESS_INS", paramDS.Tables["RQSTDT"],  bizExecute);
                    DSYS.TSYS_ACCESS.TSYS_ACCESS_INS(UTIL.GetRowToDt(row), bizExecute);
                }



                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static DataSet STD20A_INS3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                //컬럼 유요성검사
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", "0", typeof(Byte)); //
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "MENU_CODE", null, typeof(String)); //
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "ACC_LEVEL", null, typeof(String)); //
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "IS_DEFAULT_MENU", null, typeof(Byte)); //
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "MDFY_DATE", null, typeof(String)); //
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "MDFY_EMP", null, typeof(String)); //

                //현재시간
                DataTable dtNow = UTIL.UTILITY_GET_DTNOW(bizExecute);
                string dt = ((DateTime)dtNow.Rows[0]["NOW_DT"]).ToString("yyyy-MM-dd HH:mm:ss");

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {

                    DataTable dtRslt = DSYS.TSYS_USERGRP.TSYS_USERGRP_SER(paramDS.Tables["RQSTDT"], bizExecute);

                    if (dtRslt.Rows.Count != 0)
                    {
                        if (dtRslt.Rows[0]["DATA_FLAG"].ToString() == "2")
                        {
                            if (paramDS.Tables["RQSTDT"].Rows[0]["OVERWRITE"].Equals("1"))
                            {
                                row["MDFY_DATE"] = dt;
                                row["MDFY_EMP"] = dtRslt.Rows[0]["REG_EMP"];
                                //row["DATA_FLAG"] = 0;
                                DSYS.TSYS_USERGRP.TSYS_USERGRP_UPD(UTIL.GetRowToDt(row), bizExecute);

                                DSYS.TSYS_ACCESS.TSYS_ACCESS_DEL2(UTIL.GetRowToDt(row), bizExecute);

                                //DSYS.TSYS_ACCESS_QUERY.TSYS_ACCESS_QUERY1(UTIL.GetRowToDt(row), bizExecute);

                                //DataTable dtRsltAccess = DSYS.TSYS_ACCESS_QUERY.TSYS_ACCESS_QUERY1(UTIL.GetRowToDt(row), bizExecute);
                                DataTable dtRsltAccess = DSYS.TSYS_ACCESS_QUERY.TSYS_ACCESS_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                                row["MENU_CODE"] = dtRsltAccess.Rows[0]["MENU_CODE"];
                                row["ACC_LEVEL"] = dtRsltAccess.Rows[0]["ACC_LEVEL"];
                                row["IS_DEFAULT_MENU"] = dtRsltAccess.Rows[0]["IS_DEFAULT_MENU"];

                                DSYS.TSYS_ACCESS.TSYS_ACCESS_INS(UTIL.GetRowToDt(row), bizExecute);
                            }
                            else
                            {
                                throw new Exception("동일 이력 데이터가 존재합니다.");
                            }
                          

                        }
                        else
                        {
                            if (paramDS.Tables["RQSTDT"].Rows[0]["OVERWRITE"].Equals("1"))
                            {
                                row["MDFY_DATE"] = dt;
                                row["MDFY_EMP"] = dtRslt.Rows[0]["REG_EMP"];
                                //row["DATA_FLAG"] = 0;
                                DSYS.TSYS_USERGRP.TSYS_USERGRP_INS(UTIL.GetRowToDt(row), bizExecute);

                                //DSYS.TSYS_ACCESS.TSYS_ACCESS_DEL2(UTIL.GetRowToDt(row), bizExecute);

                                //DSYS.TSYS_ACCESS_QUERY.TSYS_ACCESS_QUERY1(UTIL.GetRowToDt(row), bizExecute);

                                //DataTable dtRsltAccess = DSYS.TSYS_ACCESS_QUERY.TSYS_ACCESS_QUERY1(UTIL.GetRowToDt(row), bizExecute);

                                row["USRGRP_CODE"] = paramDS.Tables["RQSTDT"].Rows[0]["COPY_USRGRP_CODE"];
                                DataTable dtRsltAccess = DSYS.TSYS_ACCESS_QUERY.TSYS_ACCESS_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                                row["MENU_CODE"] = dtRsltAccess.Rows[0]["MENU_CODE"];
                                row["ACC_LEVEL"] = dtRsltAccess.Rows[0]["ACC_LEVEL"];
                                row["IS_DEFAULT_MENU"] = dtRsltAccess.Rows[0]["IS_DEFAULT_MENU"];
                                row["USRGRP_CODE"] = dtRslt.Rows[0]["USRGRP_CODE"];

                                DSYS.TSYS_ACCESS.TSYS_ACCESS_INS(UTIL.GetRowToDt(row), bizExecute);
                            }
                            else
                            {
                                throw new Exception("동일 데이터가 존재합니다.");
                            }
                         

                        }
                    }
                    else
                    {

                        row["MDFY_DATE"] = dt;
                        //row["MDFY_EMP"] = dtRslt.Rows[0]["REG_EMP"];

                        DSYS.TSYS_USERGRP.TSYS_USERGRP_INS(UTIL.GetRowToDt(row), bizExecute);

                        DataTable dtRsltAccess = DSYS.TSYS_ACCESS_QUERY.TSYS_ACCESS_QUERY1(UTIL.GetRowToDt(row), bizExecute);

                        row["MENU_CODE"] = dtRsltAccess.Rows[0]["MENU_CODE"];
                        row["ACC_LEVEL"] = dtRsltAccess.Rows[0]["ACC_LEVEL"];
                        row["IS_DEFAULT_MENU"] = dtRsltAccess.Rows[0]["IS_DEFAULT_MENU"];

                        DSYS.TSYS_ACCESS.TSYS_ACCESS_INS(UTIL.GetRowToDt(row), bizExecute);
                    }

                    dtRslt.Clear();
                }


                return STD20A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet STD20A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //컬럼 유요성검사
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", "2", typeof(Byte)); //
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "USRGRP_CODE", DBNull.Value, typeof(String));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "SEARCH_DATA_FLAG", 0, typeof(Byte));

                //현재시간
                DataTable dtNow = UTIL.UTILITY_GET_DTNOW(bizExecute);
                string dt = ((DateTime)dtNow.Rows[0]["NOW_DT"]).ToString("yyyy-MM-dd HH:mm:ss");

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
 
                    DataTable dtRslt = DSTD.TSTD_EMPLOYEE_QUERY.TSTD_EMPLOYEE_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                    if (dtRslt.Rows.Count != 0)
                    {
                        if (dtRslt.Rows[0]["OVERDEL"].ToString() == "1")
                        {

                                row["MDFY_DATE"] = dt;
                                row["EMP_CODE"] = dtRslt.Rows[0]["EMP_CODE"];
                                //row["DATA_FLAG"] = 0;
                                DSTD.TSTD_EMPLOYEE.TSTD_EMPLOYEE_UPD2(UTIL.GetRowToDt(row), bizExecute);
                       
                        }
                        else
                        {
                             throw new Exception("삭제하고자 하는 사용자 그룹으로 설정된 사용자가 존재합니다.");
                        }
                    }
                    else
                    {

                        row["DEL_DATE"] = dt;
                        //row["DATA_FLAG"] = 0;
                        DSYS.TSYS_USERGRP.TSYS_USERGRP_UDE(UTIL.GetRowToDt(row), bizExecute);

                    }

                    dtRslt.Clear();
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
