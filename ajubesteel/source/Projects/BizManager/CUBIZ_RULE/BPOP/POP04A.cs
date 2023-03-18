using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BPOP
{
    public class POP04A
    {

        // 패널 설비조회
        public static DataSet POP04A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSTD.TSTD_PANEL_MASTER_QUERY.TSTD_PANEL_MASTER_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

                DataSet dsRslt = new DataSet();

                dtRslt.TableName = "RSLTDT";

                dsRslt.Tables.Add(dtRslt);

                return dsRslt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        // 작업실적 조회
        public static DataSet POP04A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY12(paramDS.Tables["RQSTDT"], bizExecute);

                DataSet dsRslt = new DataSet();

                dtRslt.TableName = "RSLTDT";

                dsRslt.Tables.Add(dtRslt);

                return dsRslt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// 단말기 작업지시 조회 [가공]
        public static DataSet POP04A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WO_TYPE", "PRC", typeof(String));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WO_FLAG", 4, typeof(String));

                // 비가동 조회
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "IDLE_STATE", "1", typeof(string));

                //단말기 조회는 Row수가 하나이다
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY4_1(UTIL.GetRowToDt(row), bizExecute);

                    DataTable paramTable = new DataTable("RQSTDT");
                    paramTable.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTable.Columns.Add("WO_NO", typeof(String)); //
                    paramTable.Columns.Add("MC_CODE", typeof(String)); //
                    paramTable.Columns.Add("PROC_STAT", typeof(int)); //

                    dtRslt.Columns.Add("WO_IDX", typeof(int));

                    foreach (DataRow drRslt in dtRslt.Rows)
                    {
                        if (drRslt["WO_FLAG"].toStringEmpty() == "2")
                        {
                            DataRow paramRow = paramTable.NewRow();
                            paramRow["PLT_CODE"] = drRslt["PLT_CODE"];
                            paramRow["WO_NO"] = drRslt["WO_NO"];
                            paramRow["MC_CODE"] = row["MC_CODE"];
                            paramRow["PROC_STAT"] = 2;
                            paramTable.Rows.Add(paramRow);
                        }

                        if (drRslt["WO_FLAG"].toStringEmpty() == "1")
                        {
                            drRslt["WO_IDX"] = 2;
                        }
                        else if (drRslt["WO_FLAG"].toStringEmpty() == "2")
                        {
                            drRslt["WO_IDX"] = 0;
                        }
                        else if (drRslt["WO_FLAG"].toStringEmpty() == "3")
                        {
                            drRslt["WO_IDX"] = 1;
                        }
                        else if (drRslt["WO_FLAG"].toStringEmpty() == "4")
                        {
                            drRslt["WO_IDX"] = 3;
                        }
                    }

                    DataTable dtProgress = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY15(paramTable, bizExecute);

                    DataTable dtIdle = DSHP.TSHP_IDLETIME_QUERY.TSHP_IDLETIME_QUERY2(UTIL.GetRowToDt(row), bizExecute);

                    //DataView dv = dtRslt.DefaultView;
                    //dv.Sort = "WO_IDX ASC, CHAIN_WO_NO DESC, PROD_PRIORITY";

                    //dtRslt = dv.ToTable();

                    DataView dv = dtRslt.DefaultView;
                    dv.Sort = "WO_IDX ASC, DUE_DATE, PROD_PRIORITY";

                    dtRslt = dv.ToTable();

                    DataTable rsltdt = dtRslt.Clone();

                    Dictionary<string, string> wdic = new Dictionary<string, string>();

                    foreach (DataRow wRow in dtRslt.Rows)
                    {
                        if (wRow["CHAIN_WO_NO"].ToString() == "")
                        {
                            DataRow newRow = rsltdt.NewRow();

                            newRow.ItemArray = wRow.ItemArray;

                            rsltdt.Rows.Add(newRow);
                        }
                        else
                        {
                            if (wdic.ContainsKey(wRow["CHAIN_WO_NO"].ToString()))
                            {
                                continue;
                            }
                            else
                            {
                                wdic.Add(wRow["CHAIN_WO_NO"].ToString(), "1");

                                DataRow[] rows = dtRslt.Select("CHAIN_WO_NO = '" + wRow["CHAIN_WO_NO"].ToString() + "'");

                                foreach (DataRow addRow in rows)
                                {
                                    DataRow newRow = rsltdt.NewRow();

                                    newRow.ItemArray = addRow.ItemArray;

                                    rsltdt.Rows.Add(newRow);
                                }
                            }
                        }
                    }

                    //dtRslt.TableName = "RSLTDT";
                    rsltdt.TableName = "RSLTDT";
                    dtIdle.TableName = "RSLTDT_IDLE";
                    dtProgress.TableName = "RSLTDT_PROG";

                    //paramDS.Tables.Add(dtRslt);
                    paramDS.Tables.Add(rsltdt);
                    paramDS.Tables.Add(dtIdle);
                    paramDS.Tables.Add(dtProgress);
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


       //단말기 실적정보
        public static DataSet POP04A_SER4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY23(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static DataSet POP04A_SER5(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(byte));

            DataTable dtRslt = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY14(paramDS.Tables["RQSTDT"], bizExecute);

            DataSet dsRslt = new DataSet();

            dtRslt.TableName = "RSLTDT";

            dsRslt.Tables.Add(dtRslt);


            DataTable dtWo = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER(paramDS.Tables["RQSTDT"], bizExecute);

            dtWo.TableName = "RSLTDT_WO";

            dsRslt.Tables.Add(dtWo);

            return dsRslt;

        }


        // 공구현황 조회 
        public static DataSet POP04A_SER6(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY12(paramDS.Tables["RQSTDT"], bizExecute);

                DataSet dsRslt = new DataSet();

                dtRslt.TableName = "RSLTDT";

                dsRslt.Tables.Add(dtRslt);

                return dsRslt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        // 공구현황 조회
        public static DataSet POP04A_SER7(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DTOL.TTOL_MOUNT_QUERY.TTOL_MOUNT_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.Columns.Add("SEL", typeof(string));

                DataSet dsRslt = new DataSet();

                dtRslt.TableName = "RSLTDT";

                dsRslt.Tables.Add(dtRslt);

                return dsRslt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }




        /// <summary>
        /// 공구 목록 조회
        /// </summary>
        /// <param name="paramDS"></param>
        /// <returns></returns>
        public static DataSet POP04A_SER8(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSTD.TSTD_TOOL_QUERY.TSTD_TOOL_QUERY4(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.Columns.Add("SEL", typeof(string));
                dtRslt.Columns.Add("MNT_POS", typeof(int));

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }




        public static DataSet POP04A_SER9(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(byte));
            //저장된 설비 조회
            DataTable dtRslt = DSTD.TSTD_MC_AVAILEMP_QUERY.TSTD_MC_AVAILEMP_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

            DataSet dsRslt = new DataSet();

            dtRslt.TableName = "RSLTDT";

            dsRslt.Tables.Add(dtRslt);

            return dsRslt;

        }


        //설비조회
        public static DataSet POP04A_SER10(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(byte));

                DataTable dtRslt = DLSE.LSE_MACHINE.LSE_MACHINE_SER(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        // 가공 완료/진행/잔량 수량조회
        public static DataSet POP04A_SER11(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY13(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet POP04A_SER11_2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY13_2(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                DataTable dtRsltTemp = dtRslt.Clone();

                DataRow newRow = dtRsltTemp.NewRow();

                foreach (DataRow row in dtRslt.Rows)
                {
                    newRow["ACT_QTY"] = newRow["ACT_QTY"].toInt() + row["ACT_QTY"].toInt();
                    newRow["ING_QTY"] = newRow["ING_QTY"].toInt() + row["ING_QTY"].toInt();
                    newRow["LEFT_QTY"] = newRow["LEFT_QTY"].toInt() + row["LEFT_QTY"].toInt();
                }

                dtRsltTemp.Rows.Add(newRow);


                paramDS.Tables.Add(dtRsltTemp);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        // 특정 작업지시가 특정 설비에서 가동중인지 조회
        public static DataSet POP04A_SER12(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(byte));

                DataTable dtRslt = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY15(paramDS.Tables["RQSTDT"], bizExecute);

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
        /// BOM 조회
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet POP04A_SER13(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG",0, typeof(byte));

                DataTable dtRslt = DMAT.TMAT_PARTLIST_QUERY.TMAT_PARTLIST_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
        public static DataSet POP04A_SER14(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DLSE.LSE_MACHINE_QUERY.LSE_MACHINE_QUERY4(paramDS.Tables["RQSTDT"], bizExecute);

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
        /// RegAct2
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet POP04A_SER15(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            DataTable dtRslt = DSHP.TSHP_ACTUAL.TSHP_ACTUAL_SER(paramDS.Tables["RQSTDT"], bizExecute);

            DataSet dsRslt = new DataSet();

            dtRslt.TableName = "RSLTDT";

            dsRslt.Tables.Add(dtRslt);

            return dsRslt;

        }


        /// <summary>
        /// 단말기 검색
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet POP04A_SER16(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DSTD.TSTD_PANEL_MASTER_QUERY.TSTD_PANEL_MASTER_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

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

        public static DataSet POP04A_SER17(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DLSE.LSE_MACHINE.LSE_MACHINE_SER(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet POP04A_SER18(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PROC_CODE", "P-02", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "UPLOAD_MENU", "POP02A", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "LINK_KEY", "PT_ID");

                DataTable dtRslt = DSYS.TSYS_FILELIST_MASTER.TSYS_FILELIST_MASTER_SER3(paramDS.Tables["RQSTDT"], bizExecute);

                if (dtRslt.Rows.Count == 0)
                {
                    if (paramDS.Tables["RQSTDT"].Rows[0]["CHAIN_WO_NO"].ToString() != "")
                    {
                        //DataTable dtWoRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY38(paramDS.Tables["RQSTDT"], bizExecute);

                        //UTIL.SetBizAddColumnToValue(dtWoRslt, "UPLOAD_MENU", "POP02A", typeof(string));
                        //UTIL.SetBizAddColumnToValue(dtWoRslt, "LINK_KEY", "PT_ID");

                        //foreach (DataRow row in dtWoRslt.Rows)
                        //{
                        //    dtRslt = DSYS.TSYS_FILELIST_MASTER.TSYS_FILELIST_MASTER_SER3(UTIL.GetRowToDt(row), bizExecute);
                            
                        //    if (dtRslt.Rows.Count > 0)
                        //    {
                        //        break;
                        //    }
                        //}

                        UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "LINK_KEY", "CHAIN_WO_NO");

                        dtRslt = DSYS.TSYS_FILELIST_MASTER.TSYS_FILELIST_MASTER_SER3(paramDS.Tables["RQSTDT"], bizExecute);
                    }                    
                }

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static DataSet POP04A_POP_INFO(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(byte));

                DataTable dtRslt = DSTD.TSTD_PANEL_MASTER_QUERY.TSTD_PANEL_MASTER_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        // 실적완료
        public static DataSet POP04A_INS3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {                


                // 실적갱신
                DataTable actRslt = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY11(paramDS.Tables["RQSTDT"], bizExecute);

                foreach (DataRow row in actRslt.Rows)
                {
                    DateTime nowDT = paramDS.Tables["RQSTDT"].Rows[0]["ACT_END_TIME"].toDateTime();
                    row["PROC_STAT"] = paramDS.Tables["RQSTDT"].Rows[0]["PROC_STAT"];
                    row["PANEL_STAT"] = paramDS.Tables["RQSTDT"].Rows[0]["PANEL_STAT"];
                    row["OK_QTY"] = paramDS.Tables["RQSTDT"].Rows[0]["OK_QTY"];
                    row["NG_QTY"] = paramDS.Tables["RQSTDT"].Rows[0]["NG_QTY"];
                    row["ACT_END_TIME"] = nowDT;
                    row["ACT_TIME"] = nowDT.Subtract(row["ACT_START_TIME"].toDateTime()).TotalMinutes.toDecimal();
                    DSHP.TSHP_ACTUAL.TSHP_ACTUAL_UPD8(UTIL.GetRowToDt(row), bizExecute);  // 실적입력


                }

                // 작지상태 변경
                DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD5_1(paramDS.Tables["RQSTDT"], bizExecute);

                //21.11.01 실적에 대한 불량에서 작업지시에 대한 불량으로 변경 
                // DataTable dtActRslt = DSHP.TSHP_ACTUAL.TSHP_ACTUAL_SER5(paramDS.Tables["RQSTDT"], bizExecute);


                // 부적합등록 
                if (paramDS.Tables["RQSTDT_NG"].Rows.Count != 0)
                {
                    paramDS.Tables["RQSTDT_NG"].Columns.Add("NG_ID", typeof(String));
                    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_NG"], "PLT_CODE", "100", typeof(String));
                    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_NG"], "NG_STATE", "W", typeof(String));
                    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_NG"], "ACT_TYPE", "W", typeof(String));
                    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_NG"], "LINK_KEY", paramDS.Tables["RQSTDT"].Rows[0]["WO_NO"], typeof(String));

                    for (int i = 0; i < paramDS.Tables["RQSTDT_NG"].Rows.Count; i++)
                    {
                        string ngID = UTIL.UTILITY_GET_SERIALNO(paramDS.Tables["RQSTDT"].Rows[0]["PLT_CODE"].ToString(), "NG", bizExecute);
                        paramDS.Tables["RQSTDT_NG"].Rows[i]["NG_ID"] = ngID;
                    }

                    DSHP.TSHP_NG.TSHP_NG_INS(paramDS.Tables["RQSTDT_NG"], bizExecute);
                }

                return paramDS;
            }
            catch(Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet POP04A_INS3_2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (paramDS.Tables["RQSTDT"].Rows.Count == 0) return paramDS;

                int okQty = paramDS.Tables["RQSTDT"].Rows[0]["OK_QTY"].toInt();
                int ngQty = paramDS.Tables["RQSTDT"].Rows[0]["NG_QTY"].toInt();

                DataTable dtActRslt = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY13_2(paramDS.Tables["RQSTDT"], bizExecute);

                bool isEnd = false;
                int totalLeftQty = 0;
                if (dtActRslt.Rows.Count > 0)
                {
                    totalLeftQty = dtActRslt.Compute("SUM(LEFT_QTY)", "").toInt();

                    if (okQty >= totalLeftQty)
                    {
                        isEnd = true;
                    }
                }

                int cnt = 1;
                string ngWoNo = "";
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    /*
                     * WO_FLAG / PANEL_STAT / PROC_STAT / OK_QTY / NG_QTY
                     */

                    if (isEnd)
                    {
                        if (row["WO_FLAG"].ToString() == "3")
                        {
                            row["WO_FLAG"] = "4";
                            row["PANEL_STAT"] = "4";
                            row["PROC_STAT"] = "4";
                        }
                    }

                    //OK_QTY / WO_FLAG
                    DataRow[] actRows = dtActRslt.Select("WO_NO = '" + row["WO_NO"].ToString() + "'");

                    if (actRows.Length > 0)
                    {
                        int leftQty = actRows[0]["LEFT_QTY"].toInt();
                        if (okQty > leftQty)
                        {
                            if (paramDS.Tables["RQSTDT"].Rows.Count == cnt)
                            {
                                row["OK_QTY"] = okQty;
                                okQty = okQty - leftQty;

                                row["NG_QTY"] = ngQty;

                                if (ngQty > 0) ngWoNo = row["WO_NO"].ToString();

                                ngQty = 0;
                            }
                            else
                            {
                                row["OK_QTY"] = leftQty;
                                row["NG_QTY"] = 0;
                                okQty = okQty - leftQty;
                            }
                        }
                        else if (okQty <= leftQty)
                        {
                            row["OK_QTY"] = okQty;
                            okQty = 0;

                            row["NG_QTY"] = ngQty;
                            if (ngQty > 0) ngWoNo = row["WO_NO"].ToString();
                            ngQty = 0;

                        }
                        else if (okQty == 0)
                        {
                            row["OK_QTY"] = okQty;

                            row["NG_QTY"] = ngQty;
                            if (ngQty > 0) ngWoNo = row["WO_NO"].ToString();
                            ngQty = 0;
                        }
                    }

                    cnt++;

                    // 실적갱신
                    DataTable actRslt = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY11(UTIL.GetRowToDt(row), bizExecute);

                    foreach (DataRow rw in actRslt.Rows)
                    {
                        DateTime nowDT = paramDS.Tables["RQSTDT"].Rows[0]["ACT_END_TIME"].toDateTime();
                        rw["PROC_STAT"] = row["PROC_STAT"];
                        rw["PANEL_STAT"] = row["PANEL_STAT"];
                        rw["OK_QTY"] = row["OK_QTY"];
                        rw["NG_QTY"] = row["NG_QTY"];
                        rw["ACT_END_TIME"] = nowDT;
                        rw["ACT_TIME"] = nowDT.Subtract(rw["ACT_START_TIME"].toDateTime()).TotalMinutes.toDecimal();
                        DSHP.TSHP_ACTUAL.TSHP_ACTUAL_UPD8(UTIL.GetRowToDt(rw), bizExecute);  // 실적입력
                    }

                    // 작지상태 변경
                    DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD5_1(UTIL.GetRowToDt(row), bizExecute);
                }

                // 부적합등록 
                if (paramDS.Tables["RQSTDT_NG"].Rows.Count != 0)
                {
                    paramDS.Tables["RQSTDT_NG"].Columns.Add("NG_ID", typeof(String));
                    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_NG"], "PLT_CODE", "100", typeof(String));
                    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_NG"], "NG_STATE", "W", typeof(String));
                    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_NG"], "ACT_TYPE", "W", typeof(String));
                    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_NG"], "LINK_KEY", ngWoNo, typeof(String));

                    for (int i = 0; i < paramDS.Tables["RQSTDT_NG"].Rows.Count; i++)
                    {
                        string ngID = UTIL.UTILITY_GET_SERIALNO(paramDS.Tables["RQSTDT"].Rows[0]["PLT_CODE"].ToString(), "NG", bizExecute);
                        paramDS.Tables["RQSTDT_NG"].Rows[i]["NG_ID"] = ngID;
                    }

                    DSHP.TSHP_NG.TSHP_NG_INS(paramDS.Tables["RQSTDT_NG"], bizExecute);
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }




        // 부적합 등록 (사용X)
        public static DataSet POP04A_INS4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtParam = paramDS.Tables["RQSTDT"];

                dtParam.Columns.Add("NG_QTY", typeof(Int32));
                dtParam.Columns.Add("ACTUAL_ID", typeof(String));

                foreach (DataRow dr in dtParam.Rows)
                {
                    DataTable dtSer = DSHP.TSHP_NG.TSHP_NG_SER(UTIL.GetRowToDt(dr), bizExecute);

                    if (dtSer.Rows.Count > 0)
                    {
                        //불량 내용 수정
                        DSHP.TSHP_NG.TSHP_NG_UPD(UTIL.GetRowToDt(dr), bizExecute);
                    }
                    else
                    {
                        //사내 불량 추가
                        dr["NG_ID"] = UTIL.UTILITY_GET_SERIALNO(dr["PLT_CODE"].ToString(), "NG", UTIL.emSerialFormat.YYYYMMDD, "", bizExecute);

                        DataTable dtNG = UTIL.GetRowToDt(dr);

                        UTIL.SetBizAddColumnToValue(dtNG, "DATA_FLAG", 0, typeof(Byte));
                        UTIL.SetBizAddColumnToValue(dtNG, "NG_STATE", "W", typeof(String));

                        DSHP.TSHP_NG.TSHP_NG_INS2(dtNG, bizExecute);
                    }

                    DataTable dtSum = DSHP.TSHP_NG.TSHP_NG_SER4(dtParam, bizExecute);

                    if (dtSum.Rows.Count > 0)
                        dr["NG_QTY"] = dtSum.Rows[0]["TOT_QTY"];
                    else
                        dr["NG_QTY"] = 0;

                    dr["ACTUAL_ID"] = dr["LINK_KEY"];
                    if (dr["ACT_TYPE"].ToString() == "W")
                        DSHP.TSHP_ACTUAL.TSHP_ACTUAL_UPD4(UTIL.GetRowToDt(dr), bizExecute);
                    else
                        DSHP.TSHP_MANACTUAL.TSHP_MANACTUAL_UPD2(UTIL.GetRowToDt(dr), bizExecute);

                }

                return paramDS;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }



        // 설비별 공구 장착 
        public static DataSet POP04A_INS5(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                if (paramDS.Tables["RQSTDT"].Rows.Count != 0)
                {

                   //  DataRow row = paramDS.Tables["RQSTDT"].Rows[0];

                    DataTable dtRst = DTOL.TTOL_MOUNT.TTOL_MOUNT_SER(paramDS.Tables["RQSTDT"], bizExecute);

                    if (dtRst.Rows.Count > 0)
                    {
                        DTOL.TTOL_MOUNT.TTOL_MOUNT_UPD(paramDS.Tables["RQSTDT"], bizExecute);
                    }
                    else
                    {
                        for (int i = 0; i < paramDS.Tables["RQSTDT"].Rows.Count; i++)
                        {
                            string mntId = UTIL.UTILITY_GET_SERIALNO(paramDS.Tables["RQSTDT"].Rows[0]["PLT_CODE"].ToString(), "MNT", bizExecute);
                            paramDS.Tables["RQSTDT"].Rows[i]["MOUNT_ID"] = mntId;
                        }

                        DTOL.TTOL_MOUNT.TTOL_MOUNT_INS(paramDS.Tables["RQSTDT"], bizExecute);
                    }
                }

                return POP04A_SER7(paramDS, bizExecute);

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        /// 단말기 실적 시작등록 _ 21.05.12

        public static DataSet POP04A_INS9(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            //실적이 존재하는지 판단하여 존재하지 않는다면 작업시간입력
            DataTable dtRst = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY20(paramDS.Tables["RQSTDT"], bizExecute);

            if(dtRst.Rows.Count == 0)
            {
                // 지시상태 변경 ( 1 -> 2) , 작지 ACT_START_TIME 추가
                DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD6_1(paramDS.Tables["RQSTDT"], bizExecute); // 기존: UPD4
            }
            else if(!dtRst.Select("ACT_END_TIME IS NULL").Any())
            {
                //존재하지만 종료된것만 있을때 상태변경
                DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD4(paramDS.Tables["RQSTDT"], bizExecute); 
            }

            // 신규생성
            string actualID = UTIL.UTILITY_GET_SERIALNO(paramDS.Tables["RQSTDT"].Rows[0]["PLT_CODE"].ToString(), "ACT", bizExecute);
            UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "ACTUAL_ID", actualID, typeof(String));

            DSHP.TSHP_ACTUAL.TSHP_ACTUAL_INS(paramDS.Tables["RQSTDT"], bizExecute);

            DataSet dsRslt = new DataSet();
            DataTable dtRslt = new DataTable();
        
            dtRslt.TableName = "RSLTDT";
            dsRslt.Tables.Add(dtRslt);

            return dsRslt;
        }

        /// <summary>
        /// 묶음실행
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet POP04A_INS9_2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            
            DataTable dtWoRslt = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER9(paramDS.Tables["RQSTDT"], bizExecute);

            DataTable dtActRslt = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY13_2(paramDS.Tables["RQSTDT"], bizExecute);

            int plnQty = paramDS.Tables["RQSTDT"].Rows[0]["PLN_QTY"].toInt();

            int i = 1;

            foreach (DataRow row in dtWoRslt.Rows)
            {
                DataRow[] actRows = dtActRslt.Select("WO_NO = '" + row["WO_NO"].ToString() + "'");
                int ingQty = 0;
                if (actRows.Length > 0)
                {
                    ingQty = actRows[0]["ING_QTY"].toInt();
                }

                DataTable paramTable = paramDS.Tables["RQSTDT"].Clone();

                DataRow newRow = paramTable.NewRow();
                newRow.ItemArray = paramDS.Tables["RQSTDT"].Rows[0].ItemArray;
                newRow["WO_NO"] = row["WO_NO"];

                //총예상수량이 계획수량 - 실적수량보다 크면
                //총예상수량 - (계획수량 - 실적수량) : 예상수량 차감
                //해당예상수량은 계획수량 - 실적수량
                int qty = row["PART_QTY"].toInt() - row["ACT_QTY"].toInt() - ingQty;

                if (plnQty > 0)
                {
                    if (plnQty > qty)
                    {
                        if (dtWoRslt.Rows.Count == i)
                        {
                            //마지막이면 예상수량 전부가 계획수량
                            newRow["PLN_QTY"] = plnQty;
                            plnQty = plnQty - qty;
                        }
                        else
                        {
                            plnQty = plnQty - qty;
                            newRow["PLN_QTY"] = qty;
                        }
                    }
                    else if (plnQty <= qty)
                    {
                        newRow["PLN_QTY"] = plnQty;

                        plnQty = 0;
                    }
                }
                else
                {
                    newRow["PLN_QTY"] = 0;
                }

                i++;

                paramTable.Rows.Add(newRow);


                //실적이 존재하는지 판단하여 존재하지 않는다면 작업시간입력
                DataTable dtRst = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY20(paramTable, bizExecute);

                if (dtRst.Rows.Count == 0)
                {
                    // 지시상태 변경 ( 1 -> 2) , 작지 ACT_START_TIME 추가
                    DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD6_1(paramTable, bizExecute); // 기존: UPD4
                }
                else if (!dtRst.Select("ACT_END_TIME IS NULL").Any())
                {
                    //존재하지만 종료된것만 있을때 상태변경
                    DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD4(paramTable, bizExecute);
                }

                // 신규생성
                string actualID = UTIL.UTILITY_GET_SERIALNO(paramTable.Rows[0]["PLT_CODE"].ToString(), "ACT", bizExecute);
                UTIL.SetBizAddColumnToValue(paramTable, "ACTUAL_ID", actualID, typeof(String));

                DSHP.TSHP_ACTUAL.TSHP_ACTUAL_INS(paramTable, bizExecute);

            }

            DataSet dsRslt = new DataSet();
            DataTable dtRslt = new DataTable();

            dtRslt.TableName = "RSLTDT";
            dsRslt.Tables.Add(dtRslt);

            return dsRslt;
        }



        // 단말기 MAC주소 저장
        public static DataSet POP04A_INS8(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
          
            DataTable dtRslt = DSTD.TSTD_PANEL_POP.TSTD_PANEL_POP_SER(paramDS.Tables["RQSTDT"], bizExecute);

            if(dtRslt.Rows.Count > 0 )
            {
                DSTD.TSTD_PANEL_POP.TSTD_PANEL_POP_UPD(paramDS.Tables["RQSTDT"], bizExecute);
            }
            else
            {
                DSTD.TSTD_PANEL_POP.TSTD_PANEL_POP_INS(paramDS.Tables["RQSTDT"], bizExecute);
            }

            return paramDS;   
        }


        public static DataSet POP04A_INS14(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            DataTable dtRslt = DSTD.TSTD_PANEL_POP.TSTD_PANEL_POP_SER(paramDS.Tables["RQSTDT"], bizExecute);

            if (dtRslt.Rows.Count > 0)
            {
                DSTD.TSTD_PANEL_POP.TSTD_PANEL_POP_UPD2(paramDS.Tables["RQSTDT"], bizExecute);
            }
            //else
            //{
            //    DSTD.TSTD_PANEL_POP.TSTD_PANEL_POP_INS(paramDS.Tables["RQSTDT"], bizExecute);
            //}

            return paramDS;
        }



        /// [가공단말기] 실적중지 _21.05.13

        public static DataSet POP04A_INS10(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            // ACTUAL_ID 가져오기
            DataTable actRslt = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY11(paramDS.Tables["RQSTDT"], bizExecute);

            foreach (DataRow row in actRslt.Rows)
            {
                row["PROC_STAT"] = 3;
                row["PANEL_STAT"] = 2;

                row["ACT_END_TIME"] = paramDS.Tables["RQSTDT"].Rows[0]["START_TIME"]; //실적종료시간 = 비가동시작시간
                row["ACT_TIME"] = row["ACT_END_TIME"].toDateTime().Subtract(row["ACT_START_TIME"].toDateTime()).TotalMinutes.toDecimal();
              
                row["MAN_END_TIME"] = paramDS.Tables["RQSTDT"].Rows[0]["START_TIME"];
                row["MAN_TIME"] = row["MAN_END_TIME"].toDateTime().Subtract(row["MAN_START_TIME"].toDateTime()).TotalMinutes.toDecimal();

                DSHP.TSHP_ACTUAL.TSHP_ACTUAL_UPD8(UTIL.GetRowToDt(row), bizExecute);  // ACT_END_TIME 추가
             
            }

            UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PROC_STAT", 0, typeof(Byte));
            // 진행중인 실적이 있는지 판단 
            DataTable dtRst = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

            if (dtRst.Rows.Count == 0)
            {
                // 지시상태 변경 (2 -> 3)
                DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD4(paramDS.Tables["RQSTDT"], bizExecute);
            }


            //비가동 시작
            DSHP.TSHP_IDLETIME.TSHP_IDLETIME_INS(paramDS.Tables["RQSTDT"], bizExecute);

            DataSet dsRslt = new DataSet();

            DataTable dtRslt = new DataTable();

            dtRslt.TableName = "RSLTDT";

            dsRslt.Tables.Add(dtRslt);
            return dsRslt;
        }


        //묶음중지
        public static DataSet POP04A_INS10_2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
            {
                // ACTUAL_ID 가져오기
                DataTable actRslt = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY11(UTIL.GetRowToDt(row), bizExecute);

                foreach (DataRow rw in actRslt.Rows)
                {
                    rw["PROC_STAT"] = 3;
                    rw["PANEL_STAT"] = 2;

                    rw["ACT_END_TIME"] = paramDS.Tables["RQSTDT"].Rows[0]["START_TIME"]; //실적종료시간 = 비가동시작시간
                    rw["ACT_TIME"] = rw["ACT_END_TIME"].toDateTime().Subtract(rw["ACT_START_TIME"].toDateTime()).TotalMinutes.toDecimal();

                    rw["MAN_END_TIME"] = paramDS.Tables["RQSTDT"].Rows[0]["START_TIME"];
                    rw["MAN_TIME"] = rw["MAN_END_TIME"].toDateTime().Subtract(rw["MAN_START_TIME"].toDateTime()).TotalMinutes.toDecimal();

                    DSHP.TSHP_ACTUAL.TSHP_ACTUAL_UPD8(UTIL.GetRowToDt(rw), bizExecute);  // ACT_END_TIME 추가

                }

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PROC_STAT", 0, typeof(Byte));
                // 진행중인 실적이 있는지 판단 
                DataTable dtRst = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY1(UTIL.GetRowToDt(row), bizExecute);

                if (dtRst.Rows.Count == 0)
                {
                    // 지시상태 변경 (2 -> 3)
                    DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD4(UTIL.GetRowToDt(row), bizExecute);
                }
            }            


            //비가동 시작
            DSHP.TSHP_IDLETIME.TSHP_IDLETIME_INS(UTIL.GetRowToDt(paramDS.Tables["RQSTDT"].Rows[0]), bizExecute);

            DataSet dsRslt = new DataSet();

            DataTable dtRslt = new DataTable();

            dtRslt.TableName = "RSLTDT";

            dsRslt.Tables.Add(dtRslt);
            return dsRslt;
        }



        /// [가공단말기] 실적완료 21.05.13

        public static DataSet POP04A_INS11(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            // 작지상태 변경
            DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD4(paramDS.Tables["RQSTDT"], bizExecute);

            // ACTUAL_ID 가져오기
            DataTable actRslt = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY11(paramDS.Tables["RQSTDT"], bizExecute);


            foreach (DataRow row in actRslt.Rows)
            {
                row["PROC_STAT"] = 4;
                row["PANEL_STAT"] = 4;
                row["ACT_END_TIME"] = paramDS.Tables["RQSTDT"].Rows[0]["ACT_END_TIME"];
                row["ACT_TIME"] = row["ACT_END_TIME"].toDateTime().Subtract(row["ACT_START_TIME"].toDateTime()).TotalMinutes.toDecimal();
                DSHP.TSHP_ACTUAL.TSHP_ACTUAL_UPD8(UTIL.GetRowToDt(row), bizExecute);  // ACT_END_TIME 추가
               // DSHP.TSHP_ACTUAL.TSHP_ACTUAL_UPD9(UTIL.GetRowToDt(row), bizExecute);  // ACT_TIME 산출

            }

            DataSet dsRslt = new DataSet();

            DataTable dtRslt = new DataTable();

            dtRslt.TableName = "RSLTDT";

            dsRslt.Tables.Add(dtRslt);
            return dsRslt;
        }




       
        ///  [가공단말기] 비가동 종료 후 - 재시작 _21.05.14
   
        public static DataSet POP04A_INS12(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            //2021-08-03 비가동 내역은 중지하지만 기존 작지는 진행하지 않게 변경함

            // IDLE_ID 가져오기
            DataTable idlRslt = DSHP.TSHP_IDLETIME_QUERY.TSHP_IDLETIME_QUERY6(paramDS.Tables["RQSTDT_IDL"], bizExecute);

            foreach (DataRow row in idlRslt.Rows)
            {
                row["IDLE_STATE"] = 0;
                row["END_TIME"] = paramDS.Tables["RQSTDT_IDL"].Rows[0]["END_TIME"];
                row["IDLE_TIME"] = row["END_TIME"].toDateTime().Subtract(row["START_TIME"].toDateTime()).TotalMinutes.toDecimal();

                DSHP.TSHP_IDLETIME.TSHP_IDLETIME_UPD3(UTIL.GetRowToDt(row), bizExecute); //END_TIME,IDLE_STATE 갱신

            }

         
            //// 신규 실적 생성 
            //DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD4(paramDS.Tables["RQSTDT_ACT"], bizExecute);

            //string actualID = UTIL.UTILITY_GET_SERIALNO(paramDS.Tables["RQSTDT_ACT"].Rows[0]["PLT_CODE"].ToString(), "ACT", bizExecute);
            //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_ACT"], "ACTUAL_ID", actualID, typeof(String));

            //DSHP.TSHP_ACTUAL.TSHP_ACTUAL_INS(paramDS.Tables["RQSTDT_ACT"], bizExecute);

            return paramDS;
        }


       
        /// 비가동 종료 (비가동 --> 완료처리)
  
        public static DataSet POP04A_INS13(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            // 작지상태 변경 3 -> 4
            DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD4(paramDS.Tables["RQSTDT_IDL"], bizExecute);

            // IDLE_ID 가져오기
            DataTable idlRslt = DSHP.TSHP_IDLETIME_QUERY.TSHP_IDLETIME_QUERY6(paramDS.Tables["RQSTDT_IDL"], bizExecute);

            foreach (DataRow row in idlRslt.Rows)
            {
                row["IDLE_STATE"] = 0;
                row["END_TIME"] = paramDS.Tables["RQSTDT_IDL"].Rows[0]["END_TIME"];
                row["IDLE_TIME"] = row["END_TIME"].toDateTime().Subtract(row["START_TIME"].toDateTime()).TotalMinutes.toDecimal();

                DSHP.TSHP_IDLETIME.TSHP_IDLETIME_UPD3(UTIL.GetRowToDt(row), bizExecute); //END_TIME,IDLE_STATE 갱신
                // DSHP.TSHP_IDLETIME.TSHP_IDLETIME_UPD4(UTIL.GetRowToDt(row), bizExecute); // IDLE_TIME 갱신
            }

            DataSet dsRslt = new DataSet();
            DataTable dtRslt = new DataTable();

            dtRslt.TableName = "RSLTDT";
            dsRslt.Tables.Add(dtRslt);

            return dsRslt;
        }



        public static void POP04A_UPD2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            //마지막설비 EMP_CONF에 저장

            UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "EMP_CODE", ConnInfo.UserID, typeof(String));

            DSYS.TSYS_EMP_CONF.TSYS_EMP_CONF_UPD(paramDS.Tables["RQSTDT"], bizExecute);

        }


        // 공구 사용시간 초기화
        public static DataSet POP04A_UPD3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "TOOL_NO", "MNT_POS");

                string tool_del_no = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "TD", bizExecute);

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "TOOL_DEL_NO", tool_del_no, typeof(string));


                DPOP.TPOP_MC_ACTUAL.TPOP_MC_ACTUAL_UPD2(paramDS.Tables["RQSTDT"], bizExecute);


                return POP04A_SER7(paramDS, bizExecute);

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        /// 비가동 완료 처리 
        /// 
        public static DataSet POP04A_UPD6(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            // 작지상태 변경
            DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD4(paramDS.Tables["RQSTDT"], bizExecute);


            // IDLE_ID 가져오기
            DataTable idlRslt = DSHP.TSHP_IDLETIME_QUERY.TSHP_IDLETIME_QUERY6(paramDS.Tables["RQSTDT"], bizExecute);


            foreach (DataRow row in idlRslt.Rows)
            {
                row["IDLE_STATE"] = 0;
                row["END_TIME"] = paramDS.Tables["RQSTDT"].Rows[0]["END_TIME"];
                row["IDLE_TIME"] = row["END_TIME"].toDateTime().Subtract(row["START_TIME"].toDateTime()).TotalMinutes.toDecimal();

                DSHP.TSHP_IDLETIME.TSHP_IDLETIME_UPD3(UTIL.GetRowToDt(row), bizExecute); //END_TIME,IDLE_STATE 갱신
               // DSHP.TSHP_IDLETIME.TSHP_IDLETIME_UPD4(UTIL.GetRowToDt(row), bizExecute); // IDLE_TIME 갱신
            }


            DataSet dsRslt = new DataSet();
            DataTable dtRslt = new DataTable();

            dtRslt.TableName = "RSLTDT";
            dsRslt.Tables.Add(dtRslt);

            return dsRslt;

        }

        public static DataSet POP04A_UPD7(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WO_FLAG", "1", typeof(string));

            DataTable serTable = new DataTable("RQSTDT");
            serTable.Columns.Add("PLT_CODE", typeof(string));
            serTable.Columns.Add("WO_NO", typeof(string));

            foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
            {
                DataTable actTable = DSHP.TSHP_ACTUAL.TSHP_ACTUAL_SER6(UTIL.GetRowToDt(row), bizExecute);

                if (actTable.Rows.Count == 0)
                {
                    if (row["CHAIN_WO_NO"].ToString() == "")
                    {
                        DSHP.TSHP_ACTUAL.TSHP_ACTUAL_DEL2(UTIL.GetRowToDt(row), bizExecute);

                        DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD41(UTIL.GetRowToDt(row), bizExecute);

                        DataRow serRow = serTable.NewRow();
                        serRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                        serRow["WO_NO"] = row["WO_NO"];
                        serTable.Rows.Add(serRow);
                    }
                    else
                    {
                        DataTable woTable = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER12(UTIL.GetRowToDt(row), bizExecute);

                        UTIL.SetBizAddColumnToValue(woTable, "WO_FLAG", "1", typeof(string));

                        foreach (DataRow rw in woTable.Rows)
                        {
                            DSHP.TSHP_ACTUAL.TSHP_ACTUAL_DEL2(UTIL.GetRowToDt(rw), bizExecute);

                            DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD41(UTIL.GetRowToDt(rw), bizExecute);

                            DataRow serRow = serTable.NewRow();
                            serRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                            serRow["WO_NO"] = rw["WO_NO"];
                            serTable.Rows.Add(serRow);
                        }
                    }
                }
                else
                {
                    throw UTIL.SetException("최초 진행건만 취소할 수 있습니다."
                    , row["WO_NO"].ToString()
                    , new System.Diagnostics.StackFrame().GetMethod().Name
                    , BizException.ABORT);
                }
            }

            UTIL.SetBizAddColumnToValue(serTable, "DATA_FLAG", 0, typeof(Byte));

            DataTable dtRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY4_2(serTable, bizExecute);
            dtRslt.TableName = "RSLTDT";
            paramDS.Tables.Add(dtRslt);

            return paramDS;
        }


        //공구삭제

        public static DataSet POP04A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DTOL.TTOL_MOUNT.TTOL_MOUNT_UDE(paramDS.Tables["RQSTDT"], bizExecute);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
    }

}
