using BizExecute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPLN
{
    public class PLN21A
    {
        public static DataSet PLN21A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DMAT.TMAT_PARTLIST_QUERY.TMAT_PARTLIST_QUERY7(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PLN21A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DMAT.TMAT_PARTLIST_QUERY.TMAT_PARTLIST_QUERY8(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PLN21A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DMAT.TMAT_PARTLIST_QUERY.TMAT_PARTLIST_QUERY9(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PLN21A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable partRslt = DMAT.TMAT_PARTLIST.TMAT_PARTLIST_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (partRslt.Rows.Count > 0)
                    {
                        DMAT.TMAT_PARTLIST.TMAT_PARTLIST_UPD9(UTIL.GetRowToDt(row), bizExecute);

                        //중단을할경우 미진행 작지 제거
                        if (row["IS_REVISION"].ToString() == "1")
                        {
                            DataTable woRslt = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER19(UTIL.GetRowToDt(row), bizExecute);

                            foreach (DataRow rw in woRslt.Rows)
                            {
                                DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UDE4(UTIL.GetRowToDt(rw), bizExecute);
                            }
                        }
                        else
                        {
                            //중단체크 해제시 기존 작지 다시생성
                            DataTable woRslt = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER20(UTIL.GetRowToDt(row), bizExecute);

                            DataTable lwoRslt = null;

                            if (woRslt.Rows.Count > 0)
                            {
                                DataTable paramTable = new DataTable("RQSTDT");
                                paramTable.Columns.Add("PLT_CODE", typeof(string));
                                paramTable.Columns.Add("PROD_CODE", typeof(string));
                                paramTable.Columns.Add("PT_ID", typeof(string));
                                paramTable.Columns.Add("RE_WO_NO", typeof(string));

                                DataRow newRow = paramTable.NewRow();
                                newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                                newRow["PROD_CODE"] = woRslt.Rows[0]["PROD_CODE"];
                                newRow["PT_ID"] = woRslt.Rows[0]["PT_ID"];
                                newRow["RE_WO_NO"] = woRslt.Rows[0]["RE_WO_NO"];

                                paramTable.Rows.Add(newRow);

                                lwoRslt = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER21(paramTable, bizExecute);

                                int camTime = 0;
                                int milTime = 0;
                                int mcTime = 0;
                                int slitTime = 0;
                                int midInsTime = 0;
                                int sideTime = 0;
                                int asseyTime = 0;
                                int msopTime = 0;
                                int actAsseyTime = 0;
                                int shipInsTime = 0;

                                if (lwoRslt.Rows.Count > 0)
                                {
                                    DataTable dtPart = DLSE.LSE_STD_PART.LSE_STD_PART_SER(UTIL.GetRowToDt(lwoRslt.Rows[0]), bizExecute);

                                    if (dtPart.Rows.Count > 0)
                                    {
                                        camTime = dtPart.Rows[0]["CAM_TIME"].toInt();
                                        milTime = dtPart.Rows[0]["MIL_TIME"].toInt();
                                        mcTime = dtPart.Rows[0]["MC_TIME"].toInt();
                                        slitTime = dtPart.Rows[0]["SLIT_TIME"].toInt();
                                        midInsTime = dtPart.Rows[0]["MID_INS_TIME"].toInt();
                                        sideTime = dtPart.Rows[0]["SIDE_TIME"].toInt();
                                        asseyTime = dtPart.Rows[0]["ASSEY_TIME"].toInt();
                                        msopTime = dtPart.Rows[0]["MSOP_TIME"].toInt();
                                        actAsseyTime = dtPart.Rows[0]["ACT_ASSEY_TIME"].toInt();
                                        shipInsTime = dtPart.Rows[0]["SHIP_INS_TIME"].toInt();
                                    }
                                }

                                DateTime startTime = DateTime.Now;

                                double proc_time = 0;

                                int procid = 0;
                                foreach (DataRow rw in lwoRslt.Rows)
                                {

                                    if (rw["PROC_CODE"].ToString() == "P-02")
                                    {
                                        if (camTime > 0)
                                        {
                                            proc_time = camTime;
                                        }
                                    }
                                    else if (rw["PROC_CODE"].ToString() == "P-03")
                                    {
                                        if (milTime > 0)
                                        {
                                            proc_time = milTime;
                                        }
                                    }
                                    else if (rw["PROC_CODE"].ToString() == "P-04")
                                    {
                                        if (mcTime > 0)
                                        {
                                            proc_time = mcTime * rw["PART_QTY"].toInt();
                                        }

                                        //갯수에따라 시간 비율 계산
                                        if (rw["PART_QTY"].toInt() < 4)
                                        {
                                            proc_time = proc_time * 1;
                                        }
                                        else if (rw["PART_QTY"].toInt() < 10)
                                        {
                                            proc_time = proc_time * 0.85;
                                        }
                                        else if (rw["PART_QTY"].toInt() >= 10)
                                        {
                                            proc_time = proc_time * 0.5;
                                        }
                                    }
                                    else if (rw["PROC_CODE"].ToString() == "P-05")
                                    {
                                        if (slitTime > 0)
                                        {
                                            proc_time = slitTime;
                                        }
                                    }
                                    else if (rw["PROC_CODE"].ToString() == "P-06")
                                    {
                                        if (midInsTime > 0)
                                        {
                                            proc_time = midInsTime;
                                        }
                                    }
                                    else if (rw["PROC_CODE"].ToString() == "P-07")
                                    {
                                        if (sideTime > 0)
                                        {
                                            proc_time = sideTime;
                                        }
                                    }
                                    else if (rw["PROC_CODE"].ToString() == "P-09")
                                    {
                                        if (asseyTime > 0)
                                        {
                                            proc_time = asseyTime;
                                        }
                                    }
                                    else if (rw["PROC_CODE"].ToString() == "P-10")
                                    {
                                        if (msopTime > 0)
                                        {
                                            proc_time = msopTime;
                                        }
                                    }
                                    else if (rw["PROC_CODE"].ToString() == "P-11")
                                    {
                                        if (actAsseyTime > 0)
                                        {
                                            proc_time = actAsseyTime;
                                        }
                                    }
                                    else if (rw["PROC_CODE"].ToString() == "P-12")
                                    {
                                        if (shipInsTime > 0)
                                        {
                                            proc_time = shipInsTime;
                                        }
                                    }

                                    if (rw["DATA_FLAG"].ToString() == "2" && rw["DES_STOP"].ToString() == "1")
                                    {
                                        DataTable liveWoTable = new DataTable("RQSTDT");
                                        liveWoTable.Columns.Add("PLT_CODE", typeof(string));
                                        liveWoTable.Columns.Add("WO_NO", typeof(string));
                                        liveWoTable.Columns.Add("WO_FLAG", typeof(string));
                                        liveWoTable.Columns.Add("PROC_ID", typeof(int));
                                        liveWoTable.Columns.Add("DATA_FLAG", typeof(Byte));


                                        liveWoTable.Columns.Add("PLN_START_TIME", typeof(string));
                                        liveWoTable.Columns.Add("PLN_END_TIME", typeof(string));

                                        liveWoTable.Columns.Add("PLN_PROC_TIME", typeof(double));
                                        liveWoTable.Columns.Add("PLN_PROC_MAN_TIME", typeof(double));

                                        DataRow liveWoRow = liveWoTable.NewRow();
                                        liveWoRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                                        liveWoRow["WO_NO"] = rw["WO_NO"];
                                        liveWoRow["WO_FLAG"] = "1";
                                        liveWoRow["PROC_ID"] = procid;
                                        liveWoRow["DATA_FLAG"] = 0;

                                        liveWoRow["PLN_START_TIME"] = startTime.toDateString("yyyyMMddHHmm");
                                        liveWoRow["PLN_END_TIME"] = startTime.AddMinutes(proc_time).toDateString("yyyyMMddHHmm");
                                        liveWoRow["PLN_PROC_TIME"] = proc_time;
                                        liveWoRow["PLN_PROC_MAN_TIME"] = proc_time;

                                        liveWoTable.Rows.Add(liveWoRow);

                                        DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD46(UTIL.GetRowToDt(liveWoRow), bizExecute);

                                        startTime = startTime.AddMinutes(proc_time);

                                        procid++;
                                    }
                                    else if (rw["DATA_FLAG"].ToString() == "0")
                                    {
                                        DataTable liveWoTable = new DataTable("RQSTDT");
                                        liveWoTable.Columns.Add("PLT_CODE", typeof(string));
                                        liveWoTable.Columns.Add("WO_NO", typeof(string));
                                        liveWoTable.Columns.Add("PROC_ID", typeof(int));
                                        liveWoTable.Columns.Add("DATA_FLAG", typeof(Byte));

                                        DataRow liveWoRow = liveWoTable.NewRow();
                                        liveWoRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                                        liveWoRow["WO_NO"] = rw["WO_NO"];
                                        liveWoRow["PROC_ID"] = procid;
                                        liveWoTable.Rows.Add(liveWoRow);

                                        DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD47(UTIL.GetRowToDt(liveWoRow), bizExecute);

                                        procid++;
                                    }
                                }
                            }

                            //foreach (DataRow rw in woRslt.Rows)
                            //{
                            //    DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD45(UTIL.GetRowToDt(rw), bizExecute);
                            //}

                        }

                    }
                }

                return PLN21A_SER2(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static DataSet PLN21A_INS2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable partRslt = DMAT.TMAT_PARTLIST.TMAT_PARTLIST_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (partRslt.Rows.Count > 0)
                    {
                        DMAT.TMAT_PARTLIST.TMAT_PARTLIST_UPD9(UTIL.GetRowToDt(row), bizExecute);

                        //중단을할경우 미진행 작지 제거
                        if (row["IS_REVISION"].ToString() == "1")
                        {
                            
                            DataTable woRslt = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER19(UTIL.GetRowToDt(row), bizExecute);

                            foreach (DataRow rw in woRslt.Rows)
                            {
                                DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UDE4(UTIL.GetRowToDt(rw), bizExecute);
                            }
                        }
                        else
                        {
                            //중단체크 해제시 기존 작지 다시생성
                            DataTable woRslt = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER20(UTIL.GetRowToDt(row), bizExecute);

                            DataTable lwoRslt = null;

                            if (woRslt.Rows.Count > 0)
                            {
                                DataTable paramTable = new DataTable("RQSTDT");
                                paramTable.Columns.Add("PLT_CODE", typeof(string));
                                paramTable.Columns.Add("PROD_CODE", typeof(string));
                                paramTable.Columns.Add("PT_ID", typeof(string));
                                paramTable.Columns.Add("RE_WO_NO", typeof(string));

                                DataRow newRow = paramTable.NewRow();
                                newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                                newRow["PROD_CODE"] = woRslt.Rows[0]["PROD_CODE"];
                                newRow["PT_ID"] = woRslt.Rows[0]["PT_ID"];
                                newRow["RE_WO_NO"] = woRslt.Rows[0]["RE_WO_NO"];

                                paramTable.Rows.Add(newRow);

                                lwoRslt = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER21(paramTable, bizExecute);

                                int camTime = 0;
                                int milTime = 0;
                                int mcTime = 0;
                                int slitTime = 0;
                                int midInsTime = 0;
                                int sideTime = 0;
                                int asseyTime = 0;
                                int msopTime = 0;
                                int actAsseyTime = 0;
                                int shipInsTime = 0;

                                if (lwoRslt.Rows.Count > 0)
                                {
                                    DataTable dtPart = DLSE.LSE_STD_PART.LSE_STD_PART_SER(UTIL.GetRowToDt(lwoRslt.Rows[0]), bizExecute);

                                    if (dtPart.Rows.Count > 0)
                                    {
                                        camTime = dtPart.Rows[0]["CAM_TIME"].toInt();
                                        milTime = dtPart.Rows[0]["MIL_TIME"].toInt();
                                        mcTime = dtPart.Rows[0]["MC_TIME"].toInt();
                                        slitTime = dtPart.Rows[0]["SLIT_TIME"].toInt();
                                        midInsTime = dtPart.Rows[0]["MID_INS_TIME"].toInt();
                                        sideTime = dtPart.Rows[0]["SIDE_TIME"].toInt();
                                        asseyTime = dtPart.Rows[0]["ASSEY_TIME"].toInt();
                                        msopTime = dtPart.Rows[0]["MSOP_TIME"].toInt();
                                        actAsseyTime = dtPart.Rows[0]["ACT_ASSEY_TIME"].toInt();
                                        shipInsTime = dtPart.Rows[0]["SHIP_INS_TIME"].toInt();
                                    }
                                }

                                DateTime startTime = DateTime.Now;

                                double proc_time = 0;

                                int procid = 0;
                                foreach (DataRow rw in lwoRslt.Rows)
                                {

                                    if (rw["PROC_CODE"].ToString() == "P-02")
                                    {
                                        if (camTime > 0)
                                        {
                                            proc_time = camTime;
                                        }
                                    }
                                    else if (rw["PROC_CODE"].ToString() == "P-03")
                                    {
                                        if (milTime > 0)
                                        {
                                            proc_time = milTime;
                                        }
                                    }
                                    else if (rw["PROC_CODE"].ToString() == "P-04")
                                    {
                                        if (mcTime > 0)
                                        {
                                            proc_time = mcTime * rw["PART_QTY"].toInt();
                                        }

                                        //갯수에따라 시간 비율 계산
                                        if (rw["PART_QTY"].toInt() < 4)
                                        {
                                            proc_time = proc_time * 1;
                                        }
                                        else if (rw["PART_QTY"].toInt() < 10)
                                        {
                                            proc_time = proc_time * 0.85;
                                        }
                                        else if (rw["PART_QTY"].toInt() >= 10)
                                        {
                                            proc_time = proc_time * 0.5;
                                        }
                                    }
                                    else if (rw["PROC_CODE"].ToString() == "P-05")
                                    {
                                        if (slitTime > 0)
                                        {
                                            proc_time = slitTime;
                                        }
                                    }
                                    else if (rw["PROC_CODE"].ToString() == "P-06")
                                    {
                                        if (midInsTime > 0)
                                        {
                                            proc_time = midInsTime;
                                        }
                                    }
                                    else if (rw["PROC_CODE"].ToString() == "P-07")
                                    {
                                        if (sideTime > 0)
                                        {
                                            proc_time = sideTime;
                                        }
                                    }
                                    else if (rw["PROC_CODE"].ToString() == "P-09")
                                    {
                                        if (asseyTime > 0)
                                        {
                                            proc_time = asseyTime;
                                        }
                                    }
                                    else if (rw["PROC_CODE"].ToString() == "P-10")
                                    {
                                        if (msopTime > 0)
                                        {
                                            proc_time = msopTime;
                                        }
                                    }
                                    else if (rw["PROC_CODE"].ToString() == "P-11")
                                    {
                                        if (actAsseyTime > 0)
                                        {
                                            proc_time = actAsseyTime;
                                        }
                                    }
                                    else if (rw["PROC_CODE"].ToString() == "P-12")
                                    {
                                        if (shipInsTime > 0)
                                        {
                                            proc_time = shipInsTime;
                                        }
                                    }

                                    if (rw["DATA_FLAG"].ToString() == "2" && rw["DES_STOP"].ToString() == "1")
                                    {
                                        DataTable liveWoTable = new DataTable("RQSTDT");
                                        liveWoTable.Columns.Add("PLT_CODE", typeof(string));
                                        liveWoTable.Columns.Add("WO_NO", typeof(string));
                                        liveWoTable.Columns.Add("WO_FLAG", typeof(string));
                                        liveWoTable.Columns.Add("PROC_ID", typeof(int));
                                        liveWoTable.Columns.Add("DATA_FLAG", typeof(Byte));


                                        liveWoTable.Columns.Add("PLN_START_TIME", typeof(string));
                                        liveWoTable.Columns.Add("PLN_END_TIME", typeof(string));

                                        liveWoTable.Columns.Add("PLN_PROC_TIME", typeof(double));
                                        liveWoTable.Columns.Add("PLN_PROC_MAN_TIME", typeof(double));

                                        DataRow liveWoRow = liveWoTable.NewRow();
                                        liveWoRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                                        liveWoRow["WO_NO"] = rw["WO_NO"];
                                        liveWoRow["WO_FLAG"] = "1";
                                        liveWoRow["PROC_ID"] = procid;
                                        liveWoRow["DATA_FLAG"] = 0;

                                        liveWoRow["PLN_START_TIME"] = startTime.toDateString("yyyyMMddHHmm");
                                        liveWoRow["PLN_END_TIME"] = startTime.AddMinutes(proc_time).toDateString("yyyyMMddHHmm");
                                        liveWoRow["PLN_PROC_TIME"] = proc_time;
                                        liveWoRow["PLN_PROC_MAN_TIME"] = proc_time;

                                        liveWoTable.Rows.Add(liveWoRow);

                                        DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD46(UTIL.GetRowToDt(liveWoRow), bizExecute);

                                        startTime = startTime.AddMinutes(proc_time);

                                        procid++;
                                    }
                                    else if (rw["DATA_FLAG"].ToString() == "0")
                                    {
                                        DataTable liveWoTable = new DataTable("RQSTDT");
                                        liveWoTable.Columns.Add("PLT_CODE", typeof(string));
                                        liveWoTable.Columns.Add("WO_NO", typeof(string));
                                        liveWoTable.Columns.Add("PROC_ID", typeof(int));
                                        liveWoTable.Columns.Add("DATA_FLAG", typeof(Byte));

                                        DataRow liveWoRow = liveWoTable.NewRow();
                                        liveWoRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                                        liveWoRow["WO_NO"] = rw["WO_NO"];
                                        liveWoRow["PROC_ID"] = procid;
                                        liveWoTable.Rows.Add(liveWoRow);

                                        DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD47(UTIL.GetRowToDt(liveWoRow), bizExecute);

                                        procid++;
                                    }
                                }
                            }

                            //foreach (DataRow rw in woRslt.Rows)
                            //{
                            //    DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD45(UTIL.GetRowToDt(rw), bizExecute);
                            //}

                        }

                    }
                }

                return PLN21A_SER3(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static DataSet PLN21A_INS3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable prodTable = new DataTable("RQSTDT");
                    prodTable.Columns.Add("PLT_CODE", typeof(String));
                    prodTable.Columns.Add("PROD_CODE", typeof(String));

                    DataRow prodRow = prodTable.NewRow();
                    prodRow["PLT_CODE"] = row["PLT_CODE"];
                    prodRow["PROD_CODE"] = row["PROD_CODE"];
                    prodTable.Rows.Add(prodRow);

                    DataTable dtExistBom = DORD.TORD_PRODUCT_QUERY.TORD_PRODUCT_QUERY1(prodTable, bizExecute);

                    DataTable dtCopyBom = new DataTable();

                    DataTable dttmpCopyBom = new DataTable();

                    if (paramDS.Tables.Contains("RQSTDT_BOM"))
                    {
                        dtCopyBom = paramDS.Tables["RQSTDT_BOM"]; // 편집된 BOM

                        dttmpCopyBom = paramDS.Tables["RQSTDT_BOM"].Copy(); // 편집된 BOM
                    }

                    DataTable dtDelBom = new DataTable();

                    if (paramDS.Tables.Contains("RQSTDT_DEL_BOM"))
                    {
                        dtDelBom = paramDS.Tables["RQSTDT_DEL_BOM"];
                    }

                    if (dtExistBom.Rows.Count > 0 && dtCopyBom.Rows.Count > 0)
                    {
                        //Repeat인데 편집된 bom이 있으면 수정
                        SetBom(row, dtCopyBom, dtDelBom, bizExecute);

                        SetWorkOrder(row, "RE", dttmpCopyBom, bizExecute);
                    }
                }

                

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        static void SetBom(DataRow row, DataTable dtBomCopy, DataTable dtDelBom, BizExecute.BizExecute bizExecute)
        {
            DataTable dtBomList = null;

            if (dtBomCopy.Rows.Count > 0) // 편집된 BOM 목록이 있는 경우 
            {
                dtBomList = dtBomCopy;
            }

            DataTable dtSer = new DataTable("RQSTDT");
            UTIL.SetBizAddColumnToValue(dtSer, "PLT_CODE", ConnInfo.PLT_CODE, typeof(string));
            UTIL.SetBizAddColumnToValue(dtSer, "CD_CODE", row["PROD_TYPE"], typeof(string));
            UTIL.SetBizAddColumnToValue(dtSer, "CAT_CODE", "P010", typeof(string));

            DataTable prodType = DSTD.TSTD_CODES.TSTD_CODES_SER(dtSer, bizExecute);

            string sProdType = "1";

            if (prodType.Rows.Count > 0)
            {
                sProdType = prodType.Rows[0]["CD_PARENT"].ToString();
            }

            foreach (DataRow dataRow in dtBomList.Rows)
            {
                //string old_pord_code = dataRow["PROD_CODE"].ToString();


                double o_qty = 1;
                double sum_o_qty = 1;

                double ordQty = 1;
                double sum_ordQty = 1;

                string find_o_ptid = "";
                string find_ptid = "";

                find_o_ptid = dataRow["O_PT_ID"].ToString();
                find_ptid = dataRow["PT_ID"].ToString();

                int idx = 0;

                while (true)
                {
                    if (find_o_ptid == "")
                    {
                        break;
                    }

                    DataRow[] rows = dtBomList.Select("PT_ID = '" + find_o_ptid + "'");

                    if (rows.Length > 0)
                    {
                        o_qty = rows[0]["PART_QTY"].toDouble();

                        ordQty = rows[0]["ORD_QTY"].toDouble();

                        if (ordQty > 0)
                        {
                            o_qty = o_qty * ordQty;
                        }

                        sum_o_qty = sum_o_qty * o_qty;

                        sum_ordQty = sum_ordQty * ordQty;

                        find_o_ptid = rows[0]["O_PT_ID"].ToString();

                    }

                    if (idx > 10)
                    {
                        break;
                    }

                    idx++;
                }


                if (sProdType == "2")
                {
                    sum_o_qty = 1;
                }
                else if (sProdType == "3")
                {
                    sum_o_qty = 1;
                    dataRow["PART_QTY"] = 1;
                }

                dataRow["O_PART_QTY"] = sum_o_qty;

                int child_mat_cnt = 0;


                foreach (DataRow p_dataRow in dtBomList.Select(string.Format("O_PT_ID = '{0}'", dataRow["PT_ID"])))
                {
                    child_mat_cnt++;
                }

                if (dataRow["PART_CODE"].ToString().Substring(0, 1) == "M" && dataRow["MAT_LTYPE"].ToString() == "33" && child_mat_cnt == 0)
                {
                    dataRow["WO_PART"] = "1";
                }
                else if (dataRow["PART_CODE"].ToString().Substring(0, 1) == "A" && dataRow["P_PART_CODE"].ToString() == "")
                {
                    dataRow["WO_PART"] = "1";
                }

                DataTable dtPart = DLSE.LSE_STD_PART.LSE_STD_PART_SER(UTIL.GetRowToDt(dataRow), bizExecute);

                if (dtPart.Rows.Count > 0)
                {
                    if (dtPart.Rows[0]["MAT_MTYPE"].ToString() == "21")
                    {
                        child_mat_cnt = 0;
                    }

                    if ((dtPart.Rows[0]["MAT_MTYPE"].ToString() == "21"
                        || dtPart.Rows[0]["MAT_MTYPE"].ToString() == "23")
                        && child_mat_cnt == 0)
                    {
                        DataTable reqTable = new DataTable("RQSTDT");
                        reqTable.Columns.Add("PLT_CODE", typeof(string));
                        reqTable.Columns.Add("PT_ID", typeof(string));
                        reqTable.Columns.Add("OUT_REQ_STAT", typeof(string));

                        DataRow reqRow = reqTable.NewRow();
                        reqRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                        reqRow["PT_ID"] = dataRow["PT_ID"];
                        reqRow["OUT_REQ_STAT"] = "50";
                        reqTable.Rows.Add(reqRow);

                        DataTable oldReqTable = DMAT.TMAT_OUT_REQ.TMAT_OUT_REQ_SER2(reqTable, bizExecute);

                        if (oldReqTable.Rows.Count > 0)
                        {
                            int oldReqQty = oldReqTable.Rows[0]["OUT_REQ_QTY"].toInt();

                            double partQty = dataRow["PART_QTY"].toDouble();
                            double prodQty = row["PROD_QTY"].toDouble();

                            int reqQty = (partQty * dataRow["O_PART_QTY"].toDouble() * prodQty).toInt();

                            if (dataRow["ORD_QTY"].toInt() > 0)
                            {
                                reqQty = (partQty * dataRow["O_PART_QTY"].toDouble() * dataRow["ORD_QTY"].toDouble()).toInt();
                            }

                            if (oldReqQty != reqQty)
                            {
                                oldReqTable.Rows[0]["OUT_REQ_QTY"] = reqQty;
                                DMAT.TMAT_OUT_REQ.TMAT_OUT_REQ_UPD3(UTIL.GetRowToDt(oldReqTable.Rows[0]), bizExecute);
                            }
                        }
                        else
                        {
                            reqTable = new DataTable("RQSTDT");
                            reqTable.Columns.Add("PLT_CODE", typeof(string));
                            reqTable.Columns.Add("PT_ID", typeof(string));

                            reqRow = reqTable.NewRow();
                            reqRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                            reqRow["PT_ID"] = dataRow["PT_ID"];
                            reqTable.Rows.Add(reqRow);

                            oldReqTable = DMAT.TMAT_OUT_REQ.TMAT_OUT_REQ_SER3(reqTable, bizExecute);

                            int reqTotalQty = 0;
                            foreach (DataRow rRow in oldReqTable.Rows)
                            {
                                reqTotalQty = reqTotalQty + rRow["OUT_REQ_QTY"].toInt();
                            }

                            double partQty = dataRow["PART_QTY"].toDouble();
                            double prodQty = row["PROD_QTY"].toDouble();

                            int reqQty = (partQty * dataRow["O_PART_QTY"].toDouble() * prodQty).toInt();

                            if (dataRow["ORD_QTY"].toInt() > 0)
                            {
                                reqQty = (partQty * dataRow["O_PART_QTY"].toDouble() * dataRow["ORD_QTY"].toDouble()).toInt();
                            }

                            if (reqQty > reqTotalQty)
                            {
                                reqQty = reqQty - reqTotalQty;
                            } 
                            else if (reqQty <= reqTotalQty)
                            {
                                reqQty = 0;
                            }

                            if (reqQty > 0)
                            {
                                string OUT_REQ_ID = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "QREQ", bizExecute);

                                DataTable outReqTable = new DataTable("RQSTDT");
                                outReqTable.Columns.Add("PLT_CODE", typeof(String));
                                outReqTable.Columns.Add("OUT_REQ_ID", typeof(String));
                                outReqTable.Columns.Add("PT_ID", typeof(String));
                                outReqTable.Columns.Add("PART_CODE", typeof(String));
                                outReqTable.Columns.Add("OUT_REQ_DATE", typeof(String));
                                outReqTable.Columns.Add("OUT_REQ_EMP", typeof(String));
                                outReqTable.Columns.Add("OUT_REQ_QTY", typeof(int));
                                outReqTable.Columns.Add("OUT_REQ_STAT", typeof(String));
                                outReqTable.Columns.Add("OUT_REQ_LOC", typeof(String));
                                outReqTable.Columns.Add("SCOMMENT", typeof(String));
                                outReqTable.Columns.Add("DATA_FLAG", typeof(byte));

                                DataRow outReqRow = outReqTable.NewRow();
                                outReqRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                                outReqRow["OUT_REQ_ID"] = OUT_REQ_ID;
                                outReqRow["PT_ID"] = dataRow["PT_ID"];
                                outReqRow["PART_CODE"] = dataRow["PART_CODE"];
                                outReqRow["OUT_REQ_DATE"] = DateTime.Now.toDateString("yyyyMMdd");
                                outReqRow["OUT_REQ_EMP"] = "system";

                                outReqRow["OUT_REQ_QTY"] = reqQty;
                                outReqRow["OUT_REQ_STAT"] = "50";
                                outReqRow["OUT_REQ_LOC"] = "ASY";
                                outReqRow["SCOMMENT"] = "수량 변경으로 추가 불출";
                                outReqRow["DATA_FLAG"] = 0;
                                outReqTable.Rows.Add(outReqRow);

                                DMAT.TMAT_OUT_REQ.TMAT_OUT_REQ_INS(outReqTable, bizExecute);
                            }
                        }
                    }
                }
            }


            UTIL.SetBizAddColumnToValue(dtBomList, "DATA_FLAG", "0", typeof(Byte), true);

            foreach (DataRow pRow in dtBomList.Rows)
            {
                DataTable oldPartTable = DMAT.TMAT_PARTLIST.TMAT_PARTLIST_SER(UTIL.GetRowToDt(pRow), bizExecute);

                if (oldPartTable.Rows.Count > 0)
                {
                    DMAT.TMAT_PARTLIST.TMAT_PARTLIST_UPD8(UTIL.GetRowToDt(pRow), bizExecute);
                }
                else
                {
                    DMAT.TMAT_PARTLIST.TMAT_PARTLIST_INS(UTIL.GetRowToDt(pRow), bizExecute);
                }
            }


            DataTable dtBomDelList = new DataTable();

            if (dtDelBom.Rows.Count > 0) // 삭제된 BOM 목록이 있는 경우 
            {
                dtBomDelList = dtDelBom;
            }

            foreach (DataRow dRow in dtBomDelList.Rows)
            {
                ////1.설계를 제외한 작업이 진행중인 공정이 있으면 삭제 안함 -> 확인 필요
                //2.파트리스트삭제
                //3.작지삭제
                //4.불출이 안됬다면(불출요청 : 50, 불출취소 : 53) 삭제

                ////1.
                //DataTable workDT = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER23(UTIL.GetRowToDt(dRow), bizExecute);
                //if (workDT.Rows.Count > 0)
                //{
                //    continue;
                //}

                //2.
                DMAT.TMAT_PARTLIST.TMAT_PARTLIST_UDE(UTIL.GetRowToDt(dRow), bizExecute);

                //3.
                DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UDE3(UTIL.GetRowToDt(dRow), bizExecute);


                //4.
                DMAT.TMAT_OUT_REQ.TMAT_OUT_REQ_UDE2(UTIL.GetRowToDt(dRow), bizExecute);

            }
        }

        private static void SetWorkOrder(DataRow row, string type, DataTable editBomDT, BizExecute.BizExecute bizExecute)
        {
            DataTable dtSerProd = DORD.TORD_PRODUCT.TORD_PRODUCT_SER(UTIL.GetRowToDt(row), bizExecute);

            if (dtSerProd.Rows.Count == 0)
                throw UTIL.SetException("수주 정보가 없습니다."
                          , new System.Diagnostics.StackFrame().GetMethod().Name
                          , BizException.ABORT);

            string day_close = UTIL.GetConfValue("DAY_CLOSE_TIME", bizExecute);

            DataTable dtParam = new DataTable("RQSTDT");

            UTIL.SetBizAddColumnToValue(dtParam, "PLT_CODE", ConnInfo.PLT_CODE, typeof(string));

            UTIL.SetBizAddColumnToValue(dtParam, "PROD_CODE", row["PROD_CODE"], typeof(string));

            UTIL.SetBizAddColumnToValue(dtParam, "IS_WO_PART", "1", typeof(string));

            UTIL.SetBizAddColumnToValue(dtParam, "DATA_FLAG", 0, typeof(byte));

            UTIL.SetBizAddColumnToValue(dtParam, "ROUT_CODE", null, typeof(string));

            DataTable dtPartList = DMAT.TMAT_PARTLIST_QUERY.TMAT_PARTLIST_QUERY2(dtParam, bizExecute);

            //휴일조회
            DataTable dtHoliDay = DLSE.LSE_HOLIDAY_QUERY.LSE_HOLIDAY_QUERY1(dtParam, bizExecute);

            DataTable dtNow = UTIL.UTILITY_GET_DTNOW(bizExecute);
            int part_id = 0;
            foreach (DataRow part_row in dtPartList.Rows)
            {

                //DataTable dtSer = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER3(UTIL.GetRowToDt(part_row), bizExecute);

                //if (dtSer.Rows.Count > 0)
                //    continue;

                //부품별 공정시간 가져온다
                DataTable dtPart = DLSE.LSE_STD_PART.LSE_STD_PART_SER(UTIL.GetRowToDt(part_row), bizExecute);

                int camTime = 0;
                int milTime = 0;
                int mcTime = 0;
                int slitTime = 0;
                int midInsTime = 0;
                int sideTime = 0;
                int asseyTime = 0;
                int msopTime = 0;
                int actAsseyTime = 0;
                int shipInsTime = 0;

                if (dtPart.Rows.Count > 0)
                {
                    camTime = dtPart.Rows[0]["CAM_TIME"].toInt();
                    milTime = dtPart.Rows[0]["MIL_TIME"].toInt();
                    mcTime = dtPart.Rows[0]["MC_TIME"].toInt();
                    slitTime = dtPart.Rows[0]["SLIT_TIME"].toInt();
                    midInsTime = dtPart.Rows[0]["MID_INS_TIME"].toInt();
                    sideTime = dtPart.Rows[0]["SIDE_TIME"].toInt();
                    asseyTime = dtPart.Rows[0]["ASSEY_TIME"].toInt();
                    msopTime = dtPart.Rows[0]["MSOP_TIME"].toInt();
                    actAsseyTime = dtPart.Rows[0]["ACT_ASSEY_TIME"].toInt();
                    shipInsTime = dtPart.Rows[0]["SHIP_INS_TIME"].toInt();
                }


                string mc_group = CTRL.CTRL.GetPartToMcGroup(part_row["PART_CODE"].ToString(), "", part_row["PT_ID"].ToString(), bizExecute);

                string rout_group = CTRL.CTRL.GetPartToRoutGroup(part_row["PROD_CODE"].ToString(), part_row["PART_CODE"].ToString(), part_row["PT_ID"].ToString(), bizExecute);

                part_row["ROUT_CODE"] = rout_group;

                part_row["MC_GROUP"] = mc_group;
                //라우트 그룹, 설비 그룹 파트 리스트에 저장
                DMAT.TMAT_PARTLIST.TMAT_PARTLIST_UPD2(UTIL.GetRowToDt(part_row), bizExecute);

                dtParam.Rows[0]["ROUT_CODE"] = rout_group;

                //DataTable dtProc = DLSE.LSE_STD_PROC_QUERY.LSE_STD_PROC_QUERY1(dtParam, bizExecute);

                DataTable dtProc = DSTD.TSTD_ROUTING.TSTD_ROUTING_SER2(dtParam, bizExecute);

                int proc_id = 0;

                if (part_row["ORD_QTY"].toDouble() > 0)
                {
                    part_row["PART_QTY"] = (part_row["PART_QTY"].toDouble() * part_row["O_PART_QTY"].toDouble() * part_row["ORD_QTY"].toDouble()).toInt();
                }
                else
                {
                    part_row["PART_QTY"] = (part_row["PART_QTY"].toDouble() * part_row["O_PART_QTY"].toDouble() * part_row["PROD_QTY"].toDouble()).toInt();
                }

                foreach (DataRow proc_row in dtProc.Rows)
                {
                    DataTable woTable = new DataTable("RQSTDT");
                    woTable.Columns.Add("PLT_CODE", typeof(String));
                    woTable.Columns.Add("PT_ID", typeof(String));
                    woTable.Columns.Add("PROC_CODE", typeof(String));
                    woTable.Columns.Add("RE_WO_NO", typeof(String));

                    DataRow oldWoRow = woTable.NewRow();
                    oldWoRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                    oldWoRow["PT_ID"] = part_row["PT_ID"];
                    oldWoRow["PROC_CODE"] = proc_row["PROC_CODE"];
                    woTable.Rows.Add(oldWoRow);

                    DataTable oldWoRslt = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER2(woTable, bizExecute);

                    if (oldWoRslt.Rows.Count > 0)
                    {
                        DataRow[] delRows = editBomDT.Select("PT_ID = '" + part_row["PT_ID"].ToString() + "' AND DATA_FLAG = '2'");

                        if (delRows.Length > 0)
                        {
                            oldWoRslt.Rows[0]["DATA_FLAG"] = 0;

                            string wo_flag = oldWoRslt.Rows[0]["OLD_WO_FLAG"].ToString();

                            if (wo_flag == "")
                            {
                                wo_flag = "0";
                            }

                            DataTable liveTable = new DataTable("RQSTDT");
                            liveTable.Columns.Add("PLT_CODE", typeof(string));
                            liveTable.Columns.Add("WO_NO", typeof(string));
                            liveTable.Columns.Add("WO_FLAG", typeof(string));
                            liveTable.Columns.Add("PART_ID", typeof(int));
                            liveTable.Columns.Add("PROC_ID", typeof(int));
                            liveTable.Columns.Add("DATA_FLAG", typeof(Byte));

                            DataRow liveRow = liveTable.NewRow();
                            liveRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                            liveRow["WO_NO"] = oldWoRslt.Rows[0]["WO_NO"];
                            liveRow["WO_FLAG"] = wo_flag;
                            liveRow["PART_ID"] = part_id;
                            liveRow["PROC_ID"] = proc_id;
                            liveRow["DATA_FLAG"] = oldWoRslt.Rows[0]["DATA_FLAG"];
                            liveTable.Rows.Add(liveRow);

                            DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD44_1(liveTable, bizExecute);
                            proc_id++;
                        }

                        if (oldWoRslt.Rows[0]["PART_QTY"] != part_row["PART_QTY"])
                        {
                            oldWoRslt.Rows[0]["PART_QTY"] = part_row["PART_QTY"];

                            if (proc_row["WO_TYPE"].ToString() == "DES")
                            {
                                oldWoRslt.Rows[0]["ACT_QTY"] = part_row["PART_QTY"];
                            }

                            DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD44(UTIL.GetRowToDt(oldWoRslt.Rows[0]), bizExecute);
                        }
                    }
                    else
                    {
                        DataTable dtRow = new DataTable("RQSTDT");
                        UTIL.SetBizAddColumnToValue(dtRow, "PLT_CODE", ConnInfo.PLT_CODE, typeof(string));
                        //작지 번호
                        string strSerialWO = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "W", bizExecute);
                        UTIL.SetBizAddColumnToValue(dtRow, "WO_NO", strSerialWO, typeof(string));

                        UTIL.SetBizAddColumnToValue(dtRow, "PROD_CODE", part_row["PROD_CODE"], typeof(string));

                        UTIL.SetBizAddColumnToValue(dtRow, "PT_ID", part_row["PT_ID"], typeof(string));

                        UTIL.SetBizAddColumnToValue(dtRow, "PART_CODE", part_row["PART_CODE"], typeof(string));

                        UTIL.SetBizAddColumnToValue(dtRow, "PT_NAME", part_row["PART_NAME"], typeof(string));

                        //if (dtProcMc.Rows.Count > 0) strMcCode = dtProcMc.Rows[0]["MC_CODE"].ToString();
                        mc_group = CTRL.CTRL.GetPartToMcGroup(part_row["PART_CODE"].ToString(), proc_row["PROC_CODE"].ToString(), part_row["PT_ID"].ToString(), bizExecute);

                        //if (proc_row["PROC_CODE"].ToString() == "P-07")
                        //{
                        //    mc_group = "F";
                        //}

                        UTIL.SetBizAddColumnToValue(dtRow, "MC_GROUP", mc_group, typeof(string));

                        UTIL.SetBizAddColumnToValue(dtRow, "PART_ID", part_id, typeof(int));

                        UTIL.SetBizAddColumnToValue(dtRow, "PROC_ID", proc_id, typeof(int));

                        UTIL.SetBizAddColumnToValue(dtRow, "PROC_CODE", proc_row["PROC_CODE"], typeof(string));

                        UTIL.SetBizAddColumnToValue(dtRow, "PART_QTY", part_row["PART_QTY"], typeof(int));


                        //작업자 정보는 사용하지 않는다.
                        //DataTable dtMcEmp = DLSE.LSE_MACHINE.LSE_MACHINE_SER(dtRow, bizExecute);
                        //string strEmpCode = "";
                        //if (dtMcEmp.Rows.Count > 0) strEmpCode = dtMcEmp.Rows[0]["MAIN_EMP"].ToString();

                        string wo_flag = "0";
                        string wo_type = string.Empty;
                        //DataTable dtProc = DLSE.LSE_STD_PROC.LSE_STD_PROC_SER(dtRow, bizExecute);
                        string is_os = "0"; string os_vnd = string.Empty; double proc_time = 0;

                        //if (dtProc.Rows.Count > 0)
                        {
                            //공정외주 인지 판단
                            is_os = proc_row["IS_OS"].ToString();
                            os_vnd = proc_row["MAIN_VND"].ToString();
                            //가공시간
                            proc_time = proc_row["PROC_MAN_TIME"].toDouble();

                            wo_type = proc_row["WO_TYPE"].ToString();

                            //설계일경우
                            if (wo_type == "DES")
                            {
                                wo_flag = "4";
                                //BOM등록일 가져오기
                                //DataTable dtSerPt = DMAT.TMAT_PARTLIST.TMAT_PARTLIST_SER(UTIL.GetRowToDt(row), bizExecute);
                                //if (dtSerPt.Rows.Count > 0)
                                {
                                    if (type == "RE")
                                    {
                                        //설계계획 시작시간을 BOM등록 시간에서 표준공수를 뺀시간
                                        //UTIL.SetBizAddColumnToValue(dtRow, "PLN_START_TIME", part_row["REG_DATE"].toDateTime().AddMinutes(-proc_time).toDateString("yyyyMMddHHmm"), typeof(string));
                                        //설계계획 시작 시간을 BOM등록시간으로
                                        UTIL.SetBizAddColumnToValue(dtRow, "PLN_START_TIME", part_row["REG_DATE"].toDateTime().toDateString("yyyyMMddHHmm"), typeof(string));
                                        //설계계획 완료 시간을 BOM등록시간으로
                                        UTIL.SetBizAddColumnToValue(dtRow, "PLN_END_TIME", part_row["REG_DATE"].toDateTime().toDateString("yyyyMMddHHmm"), typeof(string));

                                        //설계실적 시작시간을 BOM등록 시간에서 표준공수를 뺀시간
                                        //UTIL.SetBizAddColumnToValue(dtRow, "ACT_START_TIME", part_row["REG_DATE"].toDateTime().AddMinutes(-proc_time), typeof(DateTime));

                                        //설계실적 시작 시간을 BOM등록시간으로
                                        UTIL.SetBizAddColumnToValue(dtRow, "ACT_START_TIME", part_row["REG_DATE"].toDateTime(), typeof(DateTime));
                                        //설계실적 완료 시간을 BOM등록시간으로
                                        UTIL.SetBizAddColumnToValue(dtRow, "ACT_END_TIME", part_row["REG_DATE"].toDateTime(), typeof(DateTime));
                                    }
                                    else
                                    {
                                        //설계계획 시작시간을 BOM등록 시간에서 표준공수를 뺀시간
                                        UTIL.SetBizAddColumnToValue(dtRow, "PLN_START_TIME", part_row["REG_DATE"].toDateTime().AddMinutes(-proc_time).toDateString("yyyyMMddHHmm"), typeof(string));
                                        //설계계획 완료 시간을 BOM등록시간으로
                                        UTIL.SetBizAddColumnToValue(dtRow, "PLN_END_TIME", part_row["REG_DATE"].toDateTime().toDateString("yyyyMMddHHmm"), typeof(string));

                                        //설계실적 시작시간을 BOM등록 시간에서 표준공수를 뺀시간
                                        UTIL.SetBizAddColumnToValue(dtRow, "ACT_START_TIME", part_row["REG_DATE"].toDateTime().AddMinutes(-proc_time), typeof(DateTime));

                                        //설계실적 완료 시간을 BOM등록시간으로
                                        UTIL.SetBizAddColumnToValue(dtRow, "ACT_END_TIME", part_row["REG_DATE"].toDateTime(), typeof(DateTime));
                                    }
                                }
                            }
                        }

                        UTIL.SetBizAddColumnToValue(dtRow, "IS_OS", is_os, typeof(string));
                        UTIL.SetBizAddColumnToValue(dtRow, "OS_VND", os_vnd, typeof(string));

                        //UTIL.SetBizAddColumnToValue(dtRow, "EMP_CODE", strEmpCode, typeof(string));
                        //작업지시 상태
                        UTIL.SetBizAddColumnToValue(dtRow, "WO_FLAG", wo_flag, typeof(string));
                        //작업지시 타입(용도 모름, 사용 안함)
                        UTIL.SetBizAddColumnToValue(dtRow, "WO_TYPE", "0", typeof(string));
                        //우선순위(보통)
                        UTIL.SetBizAddColumnToValue(dtRow, "JOB_PRIORITY", "1", typeof(string));
                        //사용 X
                        UTIL.SetBizAddColumnToValue(dtRow, "ACT_INPUT_TYPE", "IN", typeof(string));
                        //가공 예상 시간(분)
                        UTIL.SetBizAddColumnToValue(dtRow, "PLN_PROC_TIME", proc_time, typeof(double));
                        UTIL.SetBizAddColumnToValue(dtRow, "PLN_PROC_MAN_TIME", proc_time, typeof(double));
                        //설계가 아닐경우
                        if (wo_type != "DES")
                        {
                            //이전 작업의 계획 완료 시간 가져오기
                            DataTable dtBeforeProc = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER7(dtRow, bizExecute);

                            DateTime lastTime = part_row["REG_DATE"].toDateTime();

                            if (dtBeforeProc.Rows.Count > 0)
                            {
                                lastTime = dtBeforeProc.Rows[0]["PLN_END_TIME"].toDateTime();
                                //이전 공정이 설계이면 12시간 이후 시작
                                if (dtBeforeProc.Rows[0]["WO_TYPE"].Equals("DES"))
                                    lastTime = lastTime.AddHours(12);
                            }

                            //
                            if (proc_row["WORK_START_TIME"].toStringEmpty() != "")
                            {
                                int startTime = lastTime.toDateString("HHmm").toInt();
                                int procStartTime = proc_row["WORK_START_TIME"].toInt();
                                int procEndTime = proc_row["WORK_END_TIME"].toInt();

                                if (procEndTime < startTime)
                                {
                                    //종료시간이 공정 가용시간 @WORK_END_TIME 보다 크거나
                                    //@WORK_END_TIME 부터 종료시간까지차이를 다음날 @WORK_START_TIME 이후로 붙여준다

                                    DateTime tempTime = (lastTime.toDateString("yyyyMMdd") + proc_row["WORK_END_TIME"].ToString()).toDateTime();
                                    //TimeSpan ts = lastTime.Subtract(tempTime);
                                    lastTime = (lastTime.AddDays(1).toDateString("yyyyMMdd") + proc_row["WORK_START_TIME"].ToString()).toDateTime();
                                    //lastTime = lastTime.AddMinutes(ts.TotalMinutes);

                                }
                                else if (procStartTime > startTime)
                                {
                                    //종료시간이 공정 가용시간 @WORK_START_TIME 보다 작으면
                                    //@WORK_END_TIME 부터 종료시간까지차이를 다음날 @WORK_START_TIME 이후로 붙여준다
                                    DateTime tempTime = (lastTime.AddDays(-1).toDateString("yyyyMMdd") + proc_row["WORK_END_TIME"].ToString()).toDateTime();
                                    //TimeSpan ts = lastTime.Subtract(tempTime);
                                    lastTime = (lastTime.toDateString("yyyyMMdd") + proc_row["WORK_START_TIME"].ToString()).toDateTime();
                                    //lastTime = lastTime.AddMinutes(ts.TotalMinutes);
                                }
                            }

                            bool isprevEnd = true;
                            while (isprevEnd)
                            {
                                if (lastTime.DayOfWeek == DayOfWeek.Saturday
                                    || lastTime.DayOfWeek == DayOfWeek.Sunday)
                                {
                                    lastTime = lastTime.AddDays(1);
                                }
                                else if (dtHoliDay.Select("HOLI_DATE = '" + lastTime.toDateString("yyyyMMdd") + "'").Length > 0)
                                {
                                    lastTime = lastTime.AddDays(1);
                                }
                                else
                                {
                                    isprevEnd = false;
                                }
                            }


                            if (proc_row["PROC_CODE"].ToString() == "P-02")
                            {
                                if (type == "RE")
                                {
                                    proc_time = 5;
                                }
                                else
                                {
                                    if (camTime > 0)
                                    {
                                        proc_time = camTime;
                                    }
                                }
                            }
                            else if (proc_row["PROC_CODE"].ToString() == "P-03")
                            {
                                if (milTime > 0)
                                {
                                    proc_time = milTime;
                                }
                            }
                            else if (proc_row["PROC_CODE"].ToString() == "P-04")
                            {
                                if (mcTime > 0)
                                {
                                    proc_time = mcTime * part_row["PART_QTY"].toInt();
                                }

                                //갯수에따라 시간 비율 계산
                                if (part_row["PART_QTY"].toInt() < 4)
                                {
                                    proc_time = proc_time * 1;
                                }
                                else if (part_row["PART_QTY"].toInt() < 10)
                                {
                                    proc_time = proc_time * 0.85;
                                }
                                else if (part_row["PART_QTY"].toInt() >= 10)
                                {
                                    proc_time = proc_time * 0.5;
                                }
                            }
                            else if (proc_row["PROC_CODE"].ToString() == "P-05")
                            {
                                if (slitTime > 0)
                                {
                                    proc_time = slitTime;
                                }
                            }
                            else if (proc_row["PROC_CODE"].ToString() == "P-06")
                            {
                                if (midInsTime > 0)
                                {
                                    proc_time = midInsTime;
                                }
                            }
                            else if (proc_row["PROC_CODE"].ToString() == "P-07")
                            {
                                if (sideTime > 0)
                                {
                                    proc_time = sideTime;
                                }
                            }
                            else if (proc_row["PROC_CODE"].ToString() == "P-09")
                            {
                                if (asseyTime > 0)
                                {
                                    proc_time = asseyTime;
                                }
                            }
                            else if (proc_row["PROC_CODE"].ToString() == "P-10")
                            {
                                if (msopTime > 0)
                                {
                                    proc_time = msopTime;
                                }
                            }
                            else if (proc_row["PROC_CODE"].ToString() == "P-11")
                            {
                                if (actAsseyTime > 0)
                                {
                                    proc_time = actAsseyTime;
                                }
                            }
                            else if (proc_row["PROC_CODE"].ToString() == "P-12")
                            {
                                if (shipInsTime > 0)
                                {
                                    proc_time = shipInsTime;
                                }
                            }

                            ////일요일 체크 - 일요일이면 다음날로
                            //if (lastTime.DayOfWeek == DayOfWeek.Sunday)
                            //{
                            //    lastTime = lastTime.AddDays(1);
                            //    lastTime = (lastTime.Year.ToString() + lastTime.Month.ToString() + lastTime.Day.ToString() + day_close).toDateTime();
                            //}

                            //작업일 작업시간으로 변경
                            UTIL.SetBizAddColumnToValue(dtRow, "PLN_START_TIME", lastTime.toDateString("yyyyMMddHHmm"), typeof(string));
                            //작업일 작업시간으로 변경
                            UTIL.SetBizAddColumnToValue(dtRow, "PLN_END_TIME", lastTime.AddMinutes(proc_time).toDateString("yyyyMMddHHmm"), typeof(string));


                            if (proc_row["WORK_START_TIME"].toStringEmpty() != "")
                            {
                                int startTime = dtRow.Rows[0]["PLN_END_TIME"].toDateString("HHmm").toInt();
                                int procStartTime = proc_row["WORK_START_TIME"].toInt();
                                int procEndTime = proc_row["WORK_END_TIME"].toInt();

                                if (procEndTime < startTime)
                                {
                                    //종료시간이 공정 가용시간 @WORK_END_TIME 보다 크거나
                                    //@WORK_END_TIME 부터 종료시간까지차이를 다음날 @WORK_START_TIME 이후로 붙여준다

                                    DateTime tempTime = (dtRow.Rows[0]["PLN_END_TIME"].toDateString("yyyyMMdd") + proc_row["WORK_END_TIME"].ToString()).toDateTime();
                                    TimeSpan ts = dtRow.Rows[0]["PLN_END_TIME"].toDateTime().Subtract(tempTime);
                                    dtRow.Rows[0]["PLN_END_TIME"] = (dtRow.Rows[0]["PLN_END_TIME"].toDateTime().AddDays(1).toDateString("yyyyMMdd") + proc_row["WORK_START_TIME"].ToString()).toDateTime().toDateString("yyyyMMddHHmm");
                                    dtRow.Rows[0]["PLN_END_TIME"] = dtRow.Rows[0]["PLN_END_TIME"].toDateTime().AddMinutes(ts.TotalMinutes).toDateString("yyyyMMddHHmm");

                                }
                                else if (procStartTime > startTime)
                                {
                                    //종료시간이 공정 가용시간 @WORK_START_TIME 보다 작으면
                                    //@WORK_END_TIME 부터 종료시간까지차이를 다음날 @WORK_START_TIME 이후로 붙여준다
                                    DateTime tempTime = (dtRow.Rows[0]["PLN_END_TIME"].toDateTime().AddDays(-1).toDateString("yyyyMMdd") + proc_row["WORK_END_TIME"].ToString()).toDateTime();
                                    TimeSpan ts = dtRow.Rows[0]["PLN_END_TIME"].toDateTime().Subtract(tempTime);
                                    dtRow.Rows[0]["PLN_END_TIME"] = (dtRow.Rows[0]["PLN_END_TIME"].toDateTime().toDateString("yyyyMMdd") + proc_row["WORK_START_TIME"].ToString()).toDateTime().toDateString("yyyyMMddHHmm");
                                    dtRow.Rows[0]["PLN_END_TIME"] = dtRow.Rows[0]["PLN_END_TIME"].toDateTime().AddMinutes(ts.TotalMinutes).toDateString("yyyyMMddHHmm");
                                }
                            }


                            bool isEnd = true;
                            while (isEnd)
                            {
                                if (dtRow.Rows[0]["PLN_END_TIME"].toDateTime().DayOfWeek == DayOfWeek.Saturday
                                    || dtRow.Rows[0]["PLN_END_TIME"].toDateTime().DayOfWeek == DayOfWeek.Sunday)
                                {
                                    dtRow.Rows[0]["PLN_END_TIME"] = dtRow.Rows[0]["PLN_END_TIME"].toDateTime().AddDays(1).toDateString("yyyyMMddHHmm");
                                }
                                else if (dtHoliDay.Select("HOLI_DATE = '" + dtRow.Rows[0]["PLN_END_TIME"].toDateString("yyyyMMdd") + "'").Length > 0)
                                {
                                    dtRow.Rows[0]["PLN_END_TIME"] = dtRow.Rows[0]["PLN_END_TIME"].toDateTime().AddDays(1).toDateString("yyyyMMddHHmm");
                                }
                                else
                                {
                                    isEnd = false;
                                }
                            }


                            //가공 예상 시간(분)
                            UTIL.SetBizAddColumnToValue(dtRow, "PLN_PROC_TIME", proc_time, typeof(double));
                            UTIL.SetBizAddColumnToValue(dtRow, "PLN_PROC_MAN_TIME", proc_time, typeof(double));

                            UTIL.SetBizAddColumnToValue(dtRow, "DATA_FLAG", 0, typeof(Byte));
                            //조립품(어쎄이) 공정중 PROC_ID가 '0'인 공정 가져온다.
                            //조립품 라우팅을 가져온다.
                            //계획 시작시간이 dtRow["PLN_END_TIME"]보다 작을경우 해당시간으로 시간 계산해서 업데이트
                            DataTable dtAsseyPart = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY34(dtRow, bizExecute);

                            if (dtAsseyPart.Rows.Count > 0)
                            {
                                if (dtAsseyPart.Rows[0]["PLN_START_TIME"].toDateTime() < dtRow.Rows[0]["PLN_END_TIME"].toDateTime())
                                {
                                    DataTable dtAsseyRout = DMAT.TMAT_PARTLIST.TMAT_PARTLIST_SER(dtAsseyPart, bizExecute);

                                    if (dtAsseyRout.Rows.Count > 0)
                                    {
                                        DataTable dtRout = new DataTable("RQSTDT");
                                        dtRout.Columns.Add("PLT_CODE", typeof(string));
                                        dtRout.Columns.Add("ROUT_CODE", typeof(string));

                                        DataRow routRow = dtRout.NewRow();
                                        routRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                                        routRow["ROUT_CODE"] = dtAsseyRout.Rows[0]["ROUT_CODE"];
                                        dtRout.Rows.Add(routRow);

                                        DataTable dtAsseyProc = DSTD.TSTD_ROUTING.TSTD_ROUTING_SER2(dtRout, bizExecute);

                                        lastTime = dtRow.Rows[0]["PLN_END_TIME"].toDateTime();

                                        foreach (DataRow asseyRow in dtAsseyProc.Rows)
                                        {
                                            DataTable dtWo = new DataTable("RQSTDT");
                                            dtWo.Columns.Add("PLT_CODE", typeof(string));
                                            dtWo.Columns.Add("PROD_CODE", typeof(string));
                                            dtWo.Columns.Add("PART_CODE", typeof(string));
                                            dtWo.Columns.Add("PROC_CODE", typeof(string));

                                            DataRow woRow = dtWo.NewRow();
                                            woRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                                            woRow["PROD_CODE"] = dtRow.Rows[0]["PROD_CODE"];
                                            woRow["PART_CODE"] = dtAsseyPart.Rows[0]["PART_CODE"];
                                            woRow["PROC_CODE"] = asseyRow["PROC_CODE"];
                                            dtWo.Rows.Add(woRow);

                                            DataTable dtAsseyWo = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER10(dtWo, bizExecute);

                                            if (dtAsseyWo.Rows.Count > 0)
                                            {
                                                proc_time = dtAsseyWo.Rows[0]["PLN_PROC_TIME"].toDouble();

                                                dtAsseyWo.Rows[0]["PLN_START_TIME"] = lastTime.toDateString("yyyyMMddHHmm");
                                                dtAsseyWo.Rows[0]["PLN_END_TIME"] = lastTime.AddMinutes(proc_time).toDateString("yyyyMMddHHmm");

                                                if (proc_row["WORK_START_TIME"].toStringEmpty() != "")
                                                {
                                                    int startTime = dtAsseyWo.Rows[0]["PLN_END_TIME"].toDateString("HHmm").toInt();
                                                    int procStartTime = proc_row["WORK_START_TIME"].toInt();
                                                    int procEndTime = proc_row["WORK_END_TIME"].toInt();

                                                    if (procEndTime < startTime)
                                                    {
                                                        //종료시간이 공정 가용시간 @WORK_END_TIME 보다 크거나
                                                        //@WORK_END_TIME 부터 종료시간까지차이를 다음날 @WORK_START_TIME 이후로 붙여준다

                                                        DateTime tempTime = (dtAsseyWo.Rows[0]["PLN_END_TIME"].toDateString("yyyyMMdd") + proc_row["WORK_END_TIME"].ToString()).toDateTime();
                                                        TimeSpan ts = dtAsseyWo.Rows[0]["PLN_END_TIME"].toDateTime().Subtract(tempTime);
                                                        dtAsseyWo.Rows[0]["PLN_END_TIME"] = (dtAsseyWo.Rows[0]["PLN_END_TIME"].toDateTime().AddDays(1).toDateString("yyyyMMdd") + proc_row["WORK_START_TIME"].ToString()).toDateTime().toDateString("yyyyMMddHHmm");
                                                        dtAsseyWo.Rows[0]["PLN_END_TIME"] = dtAsseyWo.Rows[0]["PLN_END_TIME"].toDateTime().AddMinutes(ts.TotalMinutes).toDateString("yyyyMMddHHmm");

                                                    }
                                                    else if (procStartTime > startTime)
                                                    {
                                                        //종료시간이 공정 가용시간 @WORK_START_TIME 보다 작으면
                                                        //@WORK_END_TIME 부터 종료시간까지차이를 다음날 @WORK_START_TIME 이후로 붙여준다
                                                        DateTime tempTime = (dtAsseyWo.Rows[0]["PLN_END_TIME"].toDateTime().AddDays(-1).toDateString("yyyyMMdd") + proc_row["WORK_END_TIME"].ToString()).toDateTime();
                                                        TimeSpan ts = dtAsseyWo.Rows[0]["PLN_END_TIME"].toDateTime().Subtract(tempTime);
                                                        dtAsseyWo.Rows[0]["PLN_END_TIME"] = (dtAsseyWo.Rows[0]["PLN_END_TIME"].toDateTime().toDateString("yyyyMMdd") + proc_row["WORK_START_TIME"].ToString()).toDateTime().toDateString("yyyyMMddHHmm");
                                                        dtAsseyWo.Rows[0]["PLN_END_TIME"] = dtAsseyWo.Rows[0]["PLN_END_TIME"].toDateTime().AddMinutes(ts.TotalMinutes).toDateString("yyyyMMddHHmm");
                                                    }
                                                }


                                                bool isAseeyEnd = true;
                                                while (isAseeyEnd)
                                                {
                                                    if (dtAsseyWo.Rows[0]["PLN_END_TIME"].toDateTime().DayOfWeek == DayOfWeek.Saturday
                                                        || dtAsseyWo.Rows[0]["PLN_END_TIME"].toDateTime().DayOfWeek == DayOfWeek.Sunday)
                                                    {
                                                        dtAsseyWo.Rows[0]["PLN_END_TIME"] = dtAsseyWo.Rows[0]["PLN_END_TIME"].toDateTime().AddDays(1).toDateString("yyyyMMddHHmm");
                                                    }
                                                    else if (dtHoliDay.Select("HOLI_DATE = '" + dtAsseyWo.Rows[0]["PLN_END_TIME"].toDateString("yyyyMMdd") + "'").Length > 0)
                                                    {
                                                        dtAsseyWo.Rows[0]["PLN_END_TIME"] = dtAsseyWo.Rows[0]["PLN_END_TIME"].toDateTime().AddDays(1).toDateString("yyyyMMddHHmm");
                                                    }
                                                    else
                                                    {
                                                        isAseeyEnd = false;
                                                    }
                                                }

                                                lastTime = dtAsseyWo.Rows[0]["PLN_END_TIME"].toDateTime();

                                                DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD17(UTIL.GetRowToDt(dtAsseyWo.Rows[0]), bizExecute);
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        foreach (DataRow sideRow in dtRow.Rows)
                        {
                            if (sideRow["PROC_CODE"].ToString() == "P-07")
                            {
                                sideRow["MC_GROUP"] = "F";
                            }
                        }

                        //작지가 있으면 UPDATE, 있으면 INSERT로 바꿀것
                        //DataTable woRslt = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER(dtRow, bizExecute);

                        if (wo_type == "DES")
                        {
                            UTIL.SetBizAddColumnToValue(dtRow, "ACT_QTY", "PART_QTY");
                        }

                        DSHP.TSHP_WORKORDER.TSHP_WORKORDER_INS(dtRow, bizExecute);

                        proc_id++;
                    }
                }

                part_id++;
            }

        }
    }
}
