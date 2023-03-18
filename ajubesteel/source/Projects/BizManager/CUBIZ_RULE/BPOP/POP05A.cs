using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;
using System.Drawing;

namespace BPOP
{
    public class POP05A
    {


        public static DataSet POP05A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte),true);

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WO_TYPE", "INS", typeof(string), true);

                DataTable dtRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY18(paramDS.Tables["RQSTDT"], bizExecute);


                UTIL.SetBizAddColumnToValue(dtRslt, "DATA_FLAG", 0, typeof(Byte), true);

                UTIL.SetBizAddColumnToValue(dtRslt, "WO_TYPE", "INS", typeof(string), true);
                UTIL.SetBizAddColumnToValue(dtRslt, "NOT_WO_NO", "WO_NO");

                DataTable dtWoRslt = dtRslt.Clone();

                Dictionary<string, bool> chainDic = new Dictionary<string, bool>();

                foreach (DataRow row in dtRslt.Rows)
                {
                    if (row["CHAIN_WO_NO"].ToString() != "")
                    {
                        if (!chainDic.ContainsKey(row["CHAIN_WO_NO"].ToString()))
                        {
                            chainDic.Add(row["CHAIN_WO_NO"].ToString(), true);
                        }
                        else
                        {
                            DataRow[] rows = dtWoRslt.Select("WO_NO = '" + row["WO_NO"].ToString() + "'");
                            if (rows.Length > 0)
                            {
                                dtWoRslt.Rows.Remove(rows[0]);
                            }
                            continue;
                        }

                        DataTable paramTable = new DataTable("RQSTDT");
                        paramTable.Columns.Add("PLT_CODE", typeof(string));
                        paramTable.Columns.Add("NOT_WO_NO", typeof(string));
                        paramTable.Columns.Add("WO_TYPE", typeof(string));
                        paramTable.Columns.Add("CHAIN_WO_NO", typeof(string));
                        paramTable.Columns.Add("DATA_FLAG", typeof(Byte));

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = row["PLT_CODE"];
                        paramRow["NOT_WO_NO"] = row["NOT_WO_NO"];
                        paramRow["WO_TYPE"] = row["WO_TYPE"];
                        paramRow["CHAIN_WO_NO"] = row["CHAIN_WO_NO"];
                        paramRow["DATA_FLAG"] = 0;

                        paramTable.Rows.Add(paramRow);

                        DataTable dtChainWoRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY18(paramTable, bizExecute);

                        foreach (DataRow cRow in dtChainWoRslt.Rows)
                        {
                            DataRow newRow = dtWoRslt.NewRow();
                            newRow.ItemArray = cRow.ItemArray;
                            dtWoRslt.Rows.Add(newRow);
                        }
                    }
                }

                if (dtWoRslt.Rows.Count > 0)
                {
                    dtRslt.Merge(dtWoRslt);
                }

                DataView dv = dtRslt.DefaultView;
                dv.Sort = "DUE_DATE ASC, PROD_PRIORITY ASC";

                dtRslt = dv.ToTable();


                chainDic.Clear();

                DataTable dtRsltWo = dtRslt.Clone();

                foreach (DataRow row in dtRslt.Rows)
                {
                    if (row["CHAIN_WO_NO"].ToString() != "")
                    {
                        if (!chainDic.ContainsKey(row["CHAIN_WO_NO"].ToString()))
                        {
                            chainDic.Add(row["CHAIN_WO_NO"].ToString(), true);
                        }
                        else
                        {
                            continue;
                        }

                        DataRow[] rows = dtRslt.Select("CHAIN_WO_NO = '" + row["CHAIN_WO_NO"].ToString() + "'");

                        foreach (DataRow rw in rows)
                        {
                            DataRow newRow = dtRsltWo.NewRow();
                            newRow.ItemArray = rw.ItemArray;
                            dtRsltWo.Rows.Add(newRow);
                        }

                    }
                    else
                    {
                        DataRow newRow = dtRsltWo.NewRow();
                        newRow.ItemArray = row.ItemArray;
                        dtRsltWo.Rows.Add(newRow);
                    }
                }

                dtRsltWo.Columns.Add("SEL");
                dtRsltWo.TableName = "RSLTDT";
                dtRsltWo.Columns.Add("INS_WORK_STATE", typeof(Bitmap));

                paramDS.Tables.Add(dtRsltWo);

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

        public static DataSet POP05A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WO_TYPE", "INS", typeof(string), true);
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

        public static DataSet POP05A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
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

        public static DataSet POP05A_SER4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte), true);

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WO_TYPE", "INS", typeof(string), true);

                DataTable dtRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY18(paramDS.Tables["RQSTDT"], bizExecute);

                UTIL.SetBizAddColumnToValue(dtRslt, "DATA_FLAG", 0, typeof(Byte), true);

                UTIL.SetBizAddColumnToValue(dtRslt, "WO_TYPE", "INS", typeof(string), true);
                UTIL.SetBizAddColumnToValue(dtRslt, "NOT_WO_NO", "WO_NO");

                DataTable dtWoRslt = dtRslt.Clone();

                foreach (DataRow row in dtRslt.Rows)
                {
                    if (row["CHAIN_WO_NO"].ToString() != "")
                    {
                        DataTable dtChainWoRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY36(UTIL.GetRowToDt(row), bizExecute);

                        foreach (DataRow cRow in dtChainWoRslt.Rows)
                        {
                            DataRow newRow = dtWoRslt.NewRow();
                            newRow.ItemArray = cRow.ItemArray;
                            dtWoRslt.Rows.Add(newRow);
                        }
                    }
                }
                if (dtWoRslt.Rows.Count > 0)
                {
                    dtRslt.Merge(dtWoRslt);
                }

                DataView dv = dtRslt.DefaultView;
                dv.Sort = "CHAIN_WO_NO DESC";

                dtRslt = dv.ToTable();

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


        /// <summary>
        ///   INS 실적입력
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet POP05A_SAVE(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte), true);
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WO_FLAG", "2", typeof(string), true);
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "ACTUAL_ID", string.Empty, typeof(string), true);
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "EMP_CODE", ConnInfo.UserID, typeof(string), true);
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PROC_STAT", 4, typeof(Byte), true);
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WORK_DATE", DateTime.Now.ToString("yyyyMMdd"), typeof(string), true);

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {

                    DataTable dtSer = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY18(UTIL.GetRowToDt(row), bizExecute);

                    if (dtSer.Rows.Count > 0)
                    {
                        int proc_qty = dtSer.Rows[0]["ACT_QTY"].toInt();

                        int old_ins_qty = dtSer.Rows[0]["OLD_INS_QTY"].toInt();

                        int new_ins_qty = row["INS_QTY"].toInt();

                        if (proc_qty < old_ins_qty + new_ins_qty)
                        {
                            throw UTIL.SetException("검사완료 수량이 가공완료 수량보다 클수 없습니다."
                              , new System.Diagnostics.StackFrame().GetMethod().Name
                              , BizException.ABORT);
                        }

                        if (0 > old_ins_qty + new_ins_qty)
                        {
                            throw UTIL.SetException("검사완료 수량이 0보다 작을수 없습니다."
                              , new System.Diagnostics.StackFrame().GetMethod().Name
                              , BizException.ABORT);
                        }

                        row["ACTUAL_ID"] = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "IACT", bizExecute);

                        DSHP.TSHP_ACTUAL_INS.TSHP_ACTUAL_INS_INS(UTIL.GetRowToDt(row), bizExecute);

                        if (old_ins_qty + new_ins_qty == 0)
                        {
                            row["WO_FLAG"] = "1";
                        }

                        if (row["WO_FLAG"].ToString() == "1")
                        {
                            DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD30_2(UTIL.GetRowToDt(row), bizExecute);
                        }
                        else if (dtSer.Rows[0]["INS_ACT_START_TIME"].ToString() == "")
                        {
                            DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD30(UTIL.GetRowToDt(row), bizExecute);
                        }
                        else
                        {
                            DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD30_1(UTIL.GetRowToDt(row), bizExecute);
                        }

                        DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD40(UTIL.GetRowToDt(row), bizExecute);
                    }
                    //else
                    //{
                    //    row["ACTUAL_ID"] = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "IACT", bizExecute);

                    //    DSHP.TSHP_ACTUAL_INS.TSHP_ACTUAL_INS_INS(UTIL.GetRowToDt(row), bizExecute);

                    //    DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD30(UTIL.GetRowToDt(row), bizExecute);
                    //}

                }


                return POP05A_SER(paramDS,bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        /// <summary>
        ///   검사 완료
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet POP05A_UPD(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte), true);
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PROC_STAT", 4, typeof(Byte), true);
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WORK_DATE", DateTime.Now.ToString("yyyyMMdd"), typeof(string), true);
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "INS_DATE", DateTime.Now.ToString("yyyyMMdd"), typeof(string), true);
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WO_FLAG", "4", typeof(string), true);

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PROD_STATE", "10", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "SHIP_FLAG", "1", typeof(string));

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD31(UTIL.GetRowToDt(row), bizExecute);

                    //출하검사 - 기준정보 공정에 IS_SHIP이 '1'이고 완료시 출하지시여부 체크한경우 출하지시 진행
                    if (row["IS_SHIP"].ToString() == "1")
                    {
                        DORD.TORD_PRODUCT.TORD_PRODUCT_UPD3(UTIL.GetRowToDt(row), bizExecute);
                    }
                }


                return POP05A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet POP05A_UPD2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PROD_STATE", "10", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "SHIP_FLAG", "1", typeof(string));
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DORD.TORD_PRODUCT.TORD_PRODUCT_UPD3(UTIL.GetRowToDt(row), bizExecute);
                }
                return POP05A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet POP05A_UPD3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD40(UTIL.GetRowToDt(row), bizExecute);
                }

                return POP05A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet POP05A_UPD4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtRslt = DPOP.TPOP_INS_SCOMMENT.TPOP_INS_SCOMMENT_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (dtRslt.Rows.Count > 0)
                    {
                        DPOP.TPOP_INS_SCOMMENT.TPOP_INS_SCOMMENT_UPD(UTIL.GetRowToDt(row), bizExecute);
                    }
                    else
                    {
                        DPOP.TPOP_INS_SCOMMENT.TPOP_INS_SCOMMENT_INS(UTIL.GetRowToDt(row), bizExecute);
                    }
                }

                return POP05A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
    }
}
