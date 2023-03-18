using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BPOP
{
    public class POP06A
    {


        public static DataSet POP06A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte),true);

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WO_TYPE", "ASY", typeof(string), true);

                //DataTable dtRslt = DORD.TORD_PRODUCT_QUERY.TORD_PRODUCT_QUERY14(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable dtRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY22(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.Columns.Add("SEL");
                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);


                if (paramDS.Tables.Contains("RQSTDT_CON"))
                {
                    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_CON"], "REG_EMP", ConnInfo.UserID, typeof(string));

                    foreach (DataRow row in paramDS.Tables["RQSTDT_CON"].Rows)
                    {
                        DataTable ConRslt = DSYS.TSYS_CONTROL_CONDITION.TSYS_CONTROL_CONDITION_SER(UTIL.GetRowToDt(row), bizExecute);

                        if (ConRslt.Rows.Count > 0)
                        {
                            DSYS.TSYS_CONTROL_CONDITION.TSYS_CONTROL_CONDITION_UPD(UTIL.GetRowToDt(row), bizExecute);
                        }
                        else
                        {
                            DSYS.TSYS_CONTROL_CONDITION.TSYS_CONTROL_CONDITION_INS(UTIL.GetRowToDt(row), bizExecute);
                        }
                    }
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet POP06A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WO_TYPE", "ASY", typeof(string), true);
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(byte), true);

                DataTable dtRslt = DLSE.LSE_STD_PROC.LSE_STD_PROC_SER2(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet POP06A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "REG_EMP", ConnInfo.UserID, typeof(string), true);

                DataTable dtRslt = DSYS.TSYS_CONTROL_CONDITION.TSYS_CONTROL_CONDITION_SER2(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet POP06A_SER4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DPOP.TPOP_ASSY_EMPS_QUERY.TPOP_ASSY_EMPS_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet POP06A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "ASSY_EMPS", "", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PIN_EMPS", "", typeof(string));

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT2"], "ASSY_EMPS", "", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT2"], "PIN_EMPS", "", typeof(string));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DPOP.TPOP_ASSY_EMPS.TPOP_ASSY_EMPS_DEL(UTIL.GetRowToDt(row), bizExecute);

                    if (row["FLAG"].ToString() == "A")
                    {
                        DMAT.TMAT_PARTLIST.TMAT_PARTLIST_UPD10(UTIL.GetRowToDt(row), bizExecute);
                    }
                    else if (row["FLAG"].ToString() == "P")
                    {
                        DMAT.TMAT_PARTLIST.TMAT_PARTLIST_UPD11(UTIL.GetRowToDt(row), bizExecute);
                    }
                }

                foreach(DataRow row in paramDS.Tables["RQSTDT_EMP"].Rows)
                {
                    DPOP.TPOP_ASSY_EMPS.TPOP_ASSY_EMPS_INS(UTIL.GetRowToDt(row), bizExecute);
                }

                foreach (DataRow row in paramDS.Tables["RQSTDT2"].Rows)
                {
                    if (row["FLAG"].ToString() == "A")
                    {
                        row["ASSY_EMPS"] = row["EMPS"];
                        DMAT.TMAT_PARTLIST.TMAT_PARTLIST_UPD10(UTIL.GetRowToDt(row), bizExecute);
                    }
                    else if (row["FLAG"].ToString() == "P")
                    {
                        row["PIN_EMPS"] = row["EMPS"];
                        DMAT.TMAT_PARTLIST.TMAT_PARTLIST_UPD11(UTIL.GetRowToDt(row), bizExecute);
                    }
                }

                return POP06A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        /// <summary>
        ///   INS 실적입력
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet POP06A_SAVE(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte), true);
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "ACTUAL_ID", string.Empty, typeof(string), true);
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "EMP_CODE", ConnInfo.UserID, typeof(string), true);
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PROC_STAT", 2, typeof(Byte), true);
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WO_FLAG", "2", typeof(string), true);
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WORK_DATE", DateTime.Now.ToString("yyyyMMdd"), typeof(string), true);

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "ACT_QTY", 0, typeof(int), true);

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtSer = DSHP.TSHP_ACTUAL_ASSY.TSHP_ACTUAL_ASSY_SER(UTIL.GetRowToDt(row), bizExecute);


                    row["ACT_QTY"] = row["ASSY_RATE"].toDecimal() * row["PART_QTY"].toDecimal();

                    if(row["ASSY_RATE"].toDecimal() >= 1)
                    {
                        row["WO_FLAG"] = 4;
                        //row["PROC_STAT"] = 4;
                    }

                    if (dtSer.Rows.Count > 0)
                    {
                        row["ACTUAL_ID"] = dtSer.Rows[0]["ACTUAL_ID"];

                        DSHP.TSHP_ACTUAL_ASSY.TSHP_ACTUAL_ASSY_UPD(UTIL.GetRowToDt(row), bizExecute);

                        DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD33(UTIL.GetRowToDt(row), bizExecute);
                    }
                    else
                    {
                        row["ACTUAL_ID"] = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "YACT", bizExecute);

                        DSHP.TSHP_ACTUAL_ASSY.TSHP_ACTUAL_ASSY_INS(UTIL.GetRowToDt(row), bizExecute);

                        DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD32(UTIL.GetRowToDt(row), bizExecute);
                    }
                    
                }


                return POP06A_SER(paramDS,bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        /// <summary>
        ///   조립 완료
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet POP06A_UPD(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte), true);
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "INS_DATE", DateTime.Now.ToString("yyyyMMdd"), typeof(string), true);
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WO_FLAG", "4", typeof(string), true);

                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PROD_STATE", "10", typeof(string));
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "SHIP_FLAG", "1", typeof(string));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD31_1(UTIL.GetRowToDt(row), bizExecute);

                    ////출하검사 - 기준정보 공정에 IS_SHIP이 '1'이고 완료시 출하지시여부 체크한경우 출하지시 진행
                    //if (row["IS_SHIP"].ToString() == "1")
                    //{
                    //    DORD.TORD_PRODUCT.TORD_PRODUCT_UPD3(UTIL.GetRowToDt(row), bizExecute);
                    //}
                }


                return POP06A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet POP06A_UPD2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtRslt = DPOP.TPOP_ASSY_SCOMMENT.TPOP_ASSY_SCOMMENT_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (dtRslt.Rows.Count > 0)
                    {
                        DPOP.TPOP_ASSY_SCOMMENT.TPOP_ASSY_SCOMMENT_UPD(UTIL.GetRowToDt(row), bizExecute);
                    }
                    else
                    {
                        DPOP.TPOP_ASSY_SCOMMENT.TPOP_ASSY_SCOMMENT_INS(UTIL.GetRowToDt(row), bizExecute);
                    }
                }

                return POP06A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        //public static DataSet POP06A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        //{
        //    try
        //    {
        //        UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

        //        ///part list
        //        DataTable dtRslt = DMAT.TMAT_PARTLIST_QUERY.TMAT_PARTLIST_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
        //        dtRslt.Columns.Add("SEL");
        //        dtRslt.TableName = "RSLTDT";

        //        DataTable dtRslt_wo = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
        //        dtRslt_wo.Columns.Add("SEL");
        //        dtRslt_wo.TableName = "RSLTDT_WO";


        //        DataTable dtRslt_bom = DMAT.TMAT_PARTLIST_QUERY.TMAT_PARTLIST_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
        //        dtRslt_bom.Columns.Add("SEL");
        //        dtRslt_bom.TableName = "RSLTDT_BOM";

        //        paramDS.Tables.Add(dtRslt);
        //        paramDS.Tables.Add(dtRslt_wo);
        //        paramDS.Tables.Add(dtRslt_bom);

        //        return paramDS;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
        //    }
        //}
    }
}
