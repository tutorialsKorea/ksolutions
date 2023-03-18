using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BPOP
{
    public class POP02A
    {


        public static DataSet POP02A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte),true);

                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WO_TYPE", "CAM", typeof(string));

                //DataTable dtRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY13(paramDS.Tables["RQSTDT"], bizExecute);

                //DataView dv = dtRslt.DefaultView;
                //dv.Sort = "CHAIN_WO_NO DESC";

                //dtRslt = dv.ToTable();

                //dtRslt.Columns.Add("SEL");
                //dtRslt.TableName = "RSLTDT";

                //paramDS.Tables.Add(dtRslt);

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte), true);

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WO_TYPE", "CAM", typeof(string));

                DataTable dtRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY13(paramDS.Tables["RQSTDT"], bizExecute);

                //결과에대해 묶음 작지 찾기
                UTIL.SetBizAddColumnToValue(dtRslt, "DATA_FLAG", 0, typeof(Byte), true);

                UTIL.SetBizAddColumnToValue(dtRslt, "WO_TYPE", "CAM", typeof(string), true);
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

                        DataTable dtChainWoRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY13(paramTable, bizExecute);

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


                paramDS.Tables.Add(dtRsltWo);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet POP02A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte), true);
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PART_NO", "PART_CODE");
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "LINK_KEY", "PART_CODE");
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "UPLOAD_MENU", "PLN13A", typeof(string), true);

                DataTable dtRslt = DIF.IF_MES_DWG.IF_MES_DWG_FILE_SER(paramDS.Tables["RQSTDT"], bizExecute);

                if (dtRslt.Rows.Count == 0)
                {
                    dtRslt = DSYS.TSYS_FILELIST_MASTER.TSYS_FILELIST_MASTER_SER2(paramDS.Tables["RQSTDT"], bizExecute);
                }

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

        public static DataSet POP02A_SER2_2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte), true);
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PART_NO", "PART_CODE");
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "LINK_KEY", "PART_CODE");
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "UPLOAD_MENU", "PLN13A", typeof(string), true);

                DataTable dtTempRslt = new DataTable("RSLTDT");
                DataTable dtTempRslt2 = new DataTable("RSLTDT2");

                DataTable dtRslt = null;
                DataTable dtRslt2 = null;

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    dtTempRslt = DIF.IF_MES_DWG.IF_MES_DWG_FILE_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (dtTempRslt.Rows.Count > 0)
                    {
                        if (dtRslt == null)
                        {
                            dtRslt = dtTempRslt.Clone();
                        }

                        DataRow newRow = dtRslt.NewRow();
                        newRow.ItemArray = dtTempRslt.Rows[0].ItemArray;
                        dtRslt.Rows.Add(newRow);
                    }

                    if (dtTempRslt.Rows.Count == 0)
                    {
                        dtTempRslt2 = DSYS.TSYS_FILELIST_MASTER.TSYS_FILELIST_MASTER_SER2(UTIL.GetRowToDt(row), bizExecute);

                        if (dtTempRslt2.Rows.Count > 0)
                        {
                            if (dtRslt2 == null)
                            {
                                dtRslt2 = dtTempRslt2.Clone();
                            }

                            DataRow newRow = dtRslt2.NewRow();
                            newRow.ItemArray = dtTempRslt2.Rows[0].ItemArray;
                            dtRslt2.Rows.Add(newRow);
                        }
                    }
                }

                if (dtRslt == null) dtRslt = new DataTable("RSLTDT");
                if (dtRslt2 == null) dtRslt2 = new DataTable("RSLTDT2");

                dtRslt.TableName = "RSLTDT";
                dtRslt2.TableName = "RSLTDT2";

                paramDS.Tables.Add(dtRslt);
                paramDS.Tables.Add(dtRslt2);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet POP02A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PART_PATH_LIKE", "PART_CODE");

                DataTable dtRslt = DIF.IF_MES_DWG.IF_MES_DWG_FILE_SER3(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet POP02A_SER4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte), true);
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PART_NO", "PART_CODE");
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "LINK_KEY", "PART_CODE");
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "UPLOAD_MENU", "PLN13A", typeof(string), true);

                DataTable dtRslt = DIF.IF_MES_DWG.IF_MES_DWG_FILE_SER(paramDS.Tables["RQSTDT"], bizExecute);

                if (dtRslt.Rows.Count == 0)
                {
                    dtRslt = DSYS.TSYS_FILELIST_MASTER.TSYS_FILELIST_MASTER_SER2(paramDS.Tables["RQSTDT"], bizExecute);
                }

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

        public static DataSet POP02A_SER5(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte), true);


                DataTable dtRslt = DIF.IF_MES_DWG.IF_MES_DWG_FILE_SER5(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet POP02A_SER6(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte), true);


                DataTable dtRslt = DIF.IF_MES_DWG.IF_MES_DWG_FILE_SER6(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet POP02A_SER7(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DSHP.TSHP_NG_QUERY.TSHP_NG_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.Columns.Add("SEL", typeof(string));
                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        /// <summary>
        ///   CAM 실적입력
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet POP02A_SAVE(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte), true);
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PROC_STAT", 2, typeof(Byte), true);
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WO_FLAG", "2", typeof(string), true);
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WORK_DATE", DateTime.Now.ToString("yyyyMMdd"), typeof(string), true);

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtSer = DSHP.TSHP_ACTUAL_CAM.TSHP_ACTUAL_CAM_SER2(UTIL.GetRowToDt(row), bizExecute);

                    DataTable dtWo = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (dtWo.Rows.Count > 0)
                    {
                        if (dtWo.Rows[0]["DATA_FLAG"].ToString() == "2")
                        {
                            throw UTIL.SetException("중단된 작업이 존재합니다."
                            , new System.Diagnostics.StackFrame().GetMethod().Name
                            , BizException.ABORT);
                        }
                    }

                    if(dtSer.Rows.Count > 0)
                    {
                        row["PROC_STAT"] = dtSer.Rows[0]["PROC_STAT"];
                        row["WO_FLAG"] = dtSer.Rows[0]["PROC_STAT"];
                        row["ACTUAL_ID"] = dtSer.Rows[0]["ACTUAL_ID"];
                        DSHP.TSHP_ACTUAL_CAM.TSHP_ACTUAL_CAM_UPD(UTIL.GetRowToDt(row), bizExecute);

                        //DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD33(UTIL.GetRowToDt(row), bizExecute);
                    }
                    else
                    {
                        row["ACTUAL_ID"] = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "CACT", bizExecute);

                        DSHP.TSHP_ACTUAL_CAM.TSHP_ACTUAL_CAM_INS(UTIL.GetRowToDt(row), bizExecute);

                        DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD32(UTIL.GetRowToDt(row), bizExecute);
                    }

                    DLSE.LSE_STD_PART.LSE_STD_PART_UPD17(UTIL.GetRowToDt(row), bizExecute);

                    //재작업인경우 BOM설비그룹은 안바꾸고 재작업에 묶여있는 작업지시만 설비그룹 변경
                    if (row["RE_WO_NO"].isNullOrEmpty())
                    {
                        //설비 그룹 변경 일괄, 디플러스 특성으로 가공품 기준 설비 그룹이 정해짐
                        DMAT.TMAT_PARTLIST.TMAT_PARTLIST_UPD3(UTIL.GetRowToDt(row), bizExecute);

                        DataTable WoRslt = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER(UTIL.GetRowToDt(row), bizExecute);

                        if (WoRslt.Rows.Count > 0)
                        {
                            if (WoRslt.Rows[0]["MC_GROUP"].ToString() != row["MC_GROUP"].ToString())
                            {
                                DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD35(UTIL.GetRowToDt(row), bizExecute);
                            }
                        }
                    }
                    else
                    {
                        DataTable WoRslt = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER(UTIL.GetRowToDt(row), bizExecute);

                        if (WoRslt.Rows.Count > 0)
                        {
                            if (WoRslt.Rows[0]["MC_GROUP"].ToString() != row["MC_GROUP"].ToString())
                            {
                                DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD35_1(UTIL.GetRowToDt(row), bizExecute);
                            }
                        }
                    }
                }


                return POP02A_SER(paramDS,bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet POP02A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                string chainWoNo = "";
                if (paramDS.Tables["RQSTDT"].Rows.Count > 0)
                {
                    chainWoNo = UTIL.UTILITY_GET_SERIALNO("100", "CW", UTIL.emSerialFormat.YYMMDDHH, "", bizExecute);
                    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "CHAIN_WO_NO", chainWoNo, typeof(string));
                    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "CHAIN_EMP", ConnInfo.UserID, typeof(string));
                }

                string material = "";
                int i = 0;

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable woRslt = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER3(UTIL.GetRowToDt(row), bizExecute);

                    DataTable dtMat = DMAT.TMAT_PARTLIST.TMAT_PARTLIST_SER(UTIL.GetRowToDt(row), bizExecute);
                    if (dtMat.Rows.Count > 0)
                    {
                        if (i == 0)
                        {
                            material = dtMat.Rows[0]["Material"].ToString();
                        }
                        else
                        {
                            if (material != dtMat.Rows[0]["Material"].ToString())
                            {
                                throw UTIL.SetException("같은 재질만 처리가능합니다."
                                , new System.Diagnostics.StackFrame().GetMethod().Name
                                , BizException.ABORT);
                            }
                        }

                        i++;
                    }


                    if (woRslt.Rows.Count > 0)
                    {
                        //묶음시 파일 LINK_KEY를 PT_ID에서 CHAIN_WO_NO로 변경
                        //->파일존재시 묶음 불가
                        DataTable dtFile = new DataTable("RQSTDT");
                        dtFile.Columns.Add("PLT_CODE", typeof(string));
                        dtFile.Columns.Add("PT_ID", typeof(string));

                        DataRow fileRow = dtFile.NewRow();
                        fileRow["PLT_CODE"] = row["PLT_CODE"];
                        fileRow["PT_ID"] = row["PT_ID"];

                        dtFile.Rows.Add(fileRow);

                        UTIL.SetBizAddColumnToValue(dtFile, "IS_UPLOAD", "1", typeof(string));
                        UTIL.SetBizAddColumnToValue(dtFile, "UPLOAD_MENU", "POP02A", typeof(string));
                        UTIL.SetBizAddColumnToValue(dtFile, "LINK_KEY", "PT_ID");

                        DataTable dtFileRslt = DSYS.TSYS_FILELIST_MASTER.TSYS_FILELIST_MASTER_SER3(dtFile, bizExecute);

                        foreach (DataRow fRow in dtFileRslt.Rows)
                        {
                            //fRow["LINK_KEY"] = chainWoNo;
                            //DSYS.TSYS_FILELIST_MASTER.TSYS_FILELIST_MASTER_UPD6(UTIL.GetRowToDt(fRow), bizExecute);
                            throw UTIL.SetException("CAM 파일이 존재합니다. 삭제 후 묶음이 가능합니다."
                            , new System.Diagnostics.StackFrame().GetMethod().Name
                            , BizException.ABORT);
                        }

                        DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD37(UTIL.GetRowToDt(row), bizExecute);
                    }
                }

                return POP02A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet POP02A_INS2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PREV_CHAIN_WO_NO", DBNull.Value, typeof(string), true);
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "CHAIN_EMP", DBNull.Value, typeof(string), true);

                //int i = 0;
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    string chainWoNo = "";

                    DataTable woRslt = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER3(UTIL.GetRowToDt(row), bizExecute);

                    if (woRslt.Rows.Count > 0)
                    {
                        chainWoNo = woRslt.Rows[0]["CHAIN_WO_NO"].ToString();

                        if (chainWoNo != "")
                        {
                            DataTable dtFile = new DataTable("RQSTDT");
                            dtFile.Columns.Add("PLT_CODE", typeof(string));
                            dtFile.Columns.Add("CHAIN_WO_NO", typeof(string));

                            DataRow fileRow = dtFile.NewRow();
                            fileRow["PLT_CODE"] = row["PLT_CODE"];
                            fileRow["CHAIN_WO_NO"] = chainWoNo;

                            dtFile.Rows.Add(fileRow);

                            UTIL.SetBizAddColumnToValue(dtFile, "IS_UPLOAD", "1", typeof(string));
                            UTIL.SetBizAddColumnToValue(dtFile, "UPLOAD_MENU", "POP02A", typeof(string));
                            UTIL.SetBizAddColumnToValue(dtFile, "LINK_KEY", "CHAIN_WO_NO");

                            DataTable dtFileRslt = DSYS.TSYS_FILELIST_MASTER.TSYS_FILELIST_MASTER_SER3(dtFile, bizExecute);

                            //첨부파일이 없는경우에만 묶음 취소가능
                            if (dtFileRslt.Rows.Count == 0)
                            {
                                DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD37(UTIL.GetRowToDt(row), bizExecute);

                                row["PREV_CHAIN_WO_NO"] = chainWoNo;
                                DataTable revChainWono = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER18(UTIL.GetRowToDt(row), bizExecute);

                                foreach (DataRow rw in revChainWono.Rows)
                                {
                                    DataTable prevTable = new DataTable("RQSTDT");
                                    prevTable.Columns.Add("PLT_CODE", typeof(string));
                                    prevTable.Columns.Add("PROD_CODE", typeof(string));
                                    prevTable.Columns.Add("PT_ID", typeof(string));
                                    prevTable.Columns.Add("RE_WO_NO", typeof(string));
                                    prevTable.Columns.Add("IS_PREV_CHAIN", typeof(Byte));

                                    DataRow prevRow = prevTable.NewRow();
                                    prevRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                                    prevRow["PROD_CODE"] = rw["PROD_CODE"];
                                    prevRow["PT_ID"] = rw["PT_ID"];
                                    prevRow["RE_WO_NO"] = rw["RE_WO_NO"];
                                    prevRow["IS_PREV_CHAIN"] = "2";
                                    prevTable.Rows.Add(prevRow);

                                    DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD45(prevTable, bizExecute);
                                }

                            }
                            else
                            {
                                throw UTIL.SetException("CAM 파일이 존재합니다. 삭제 후 묶음취소가 가능합니다."
                                , new System.Diagnostics.StackFrame().GetMethod().Name
                                , BizException.ABORT);
                            }
                        }

                        //DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD37(UTIL.GetRowToDt(row), bizExecute);
                    }

                    ////묶음취소시 파일 LINK_KEY를 CHAIN_WO_NO에서 PT_ID로 변경
                    ////첫 작업지시에 다 넣는다
                    //if (i == 0)
                    //{
                    //    if (chainWoNo != "")
                    //    {
                    //        DataTable dtFile = new DataTable("RQSTDT");
                    //        dtFile.Columns.Add("PLT_CODE", typeof(string));
                    //        dtFile.Columns.Add("CHAIN_WO_NO", typeof(string));

                    //        DataRow fileRow = dtFile.NewRow();
                    //        fileRow["PLT_CODE"] = row["PLT_CODE"];
                    //        fileRow["CHAIN_WO_NO"] = chainWoNo;

                    //        dtFile.Rows.Add(fileRow);

                    //        UTIL.SetBizAddColumnToValue(dtFile, "IS_UPLOAD", "1", typeof(string));
                    //        UTIL.SetBizAddColumnToValue(dtFile, "UPLOAD_MENU", "POP02A", typeof(string));
                    //        UTIL.SetBizAddColumnToValue(dtFile, "LINK_KEY", "CHAIN_WO_NO");

                    //        DataTable dtFileRslt = DSYS.TSYS_FILELIST_MASTER.TSYS_FILELIST_MASTER_SER3(dtFile, bizExecute);

                    //        foreach (DataRow fRow in dtFileRslt.Rows)
                    //        {
                    //            fRow["LINK_KEY"] = row["PT_ID"];
                    //            DSYS.TSYS_FILELIST_MASTER.TSYS_FILELIST_MASTER_UPD6(UTIL.GetRowToDt(fRow), bizExecute);
                    //        }
                    //    }
                    //}

                    //i++;

                }

                return POP02A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        /// <summary>
        ///   CAM 작업완료
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet POP02A_UPD(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte), true);
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PROC_STAT", 4, typeof(Byte), true);
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WO_FLAG", "4", typeof(string), true);
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "ACT_QTY", 0, typeof(int), true);
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WORK_DATE", DateTime.Now.ToString("yyyyMMdd"), typeof(string), true);

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtWo = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (dtWo.Rows.Count > 0)
                    {
                        if (dtWo.Rows[0]["DATA_FLAG"].ToString() == "2")
                        {
                            throw UTIL.SetException("중단된 작업이 존재합니다."
                            , new System.Diagnostics.StackFrame().GetMethod().Name
                            , BizException.ABORT);
                        }
                    }

                    DataTable dtFile = new DataTable("RQSTDT");
                    dtFile.Columns.Add("PLT_CODE", typeof(string));
                    dtFile.Columns.Add("LINK_KEY", typeof(string));

                    DataRow fileRow = dtFile.NewRow();
                    fileRow["PLT_CODE"] = row["PLT_CODE"];

                    string link_key = row["PT_ID"].ToString();
                    if (row["CHAIN_WO_NO"].ToString() != "")
                    {
                        link_key = row["CHAIN_WO_NO"].ToString();
                    }

                    fileRow["LINK_KEY"] = link_key;

                    dtFile.Rows.Add(fileRow);

                    UTIL.SetBizAddColumnToValue(dtFile, "IS_UPLOAD", "1", typeof(string));
                    UTIL.SetBizAddColumnToValue(dtFile, "UPLOAD_MENU", "POP02A", typeof(string));
                    //UTIL.SetBizAddColumnToValue(dtFile, "LINK_KEY", "CHAIN_WO_NO");

                    DataTable dtFileRslt = DSYS.TSYS_FILELIST_MASTER.TSYS_FILELIST_MASTER_SER3(dtFile, bizExecute);


                    if (dtFileRslt.Rows.Count == 0)
                    {
                        throw UTIL.SetException("파일이 없습니다."
                        , new System.Diagnostics.StackFrame().GetMethod().Name
                        , BizException.ABORT);
                    }


                    DataTable dtSer = DSHP.TSHP_ACTUAL_CAM.TSHP_ACTUAL_CAM_SER2(UTIL.GetRowToDt(row), bizExecute);

                    if (dtSer.Rows.Count > 0)
                    {
                        row["ACTUAL_ID"] = dtSer.Rows[0]["ACTUAL_ID"];
                        DSHP.TSHP_ACTUAL_CAM.TSHP_ACTUAL_CAM_UPD2(UTIL.GetRowToDt(row), bizExecute);
                    }
                    else
                    {
                        row["ACTUAL_ID"] = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "CACT", bizExecute);

                        //DSHP.TSHP_ACTUAL_CAM.TSHP_ACTUAL_CAM_INS(UTIL.GetRowToDt(row), bizExecute);
                        DSHP.TSHP_ACTUAL_CAM.TSHP_ACTUAL_CAM_INS2(UTIL.GetRowToDt(row), bizExecute);
                    }

                    DLSE.LSE_STD_PART.LSE_STD_PART_UPD17(UTIL.GetRowToDt(row), bizExecute);

                    DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD34(UTIL.GetRowToDt(row), bizExecute);


                    //재작업인경우 BOM설비그룹은 안바꾸고 재작업에 묶여있는 작업지시만 설비그룹 변경
                    if (row["RE_WO_NO"].isNullOrEmpty())
                    {
                        //설비 그룹 변경 일괄, 디플러스 특성으로 가공품 기준 설비 그룹이 정해짐
                        DMAT.TMAT_PARTLIST.TMAT_PARTLIST_UPD3(UTIL.GetRowToDt(row), bizExecute);

                        DataTable WoRslt = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER(UTIL.GetRowToDt(row), bizExecute);

                        if (WoRslt.Rows.Count > 0)
                        {
                            if (WoRslt.Rows[0]["MC_GROUP"].ToString() != row["MC_GROUP"].ToString())
                            {
                                DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD35(UTIL.GetRowToDt(row), bizExecute);
                            }
                        }
                    }
                    else
                    {
                        DataTable WoRslt = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER(UTIL.GetRowToDt(row), bizExecute);

                        if (WoRslt.Rows.Count > 0)
                        {
                            if (WoRslt.Rows[0]["MC_GROUP"].ToString() != row["MC_GROUP"].ToString())
                            {
                                DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD35_1(UTIL.GetRowToDt(row), bizExecute);
                            }
                        }
                    }
                }


                return POP02A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static DataSet POP02A_UPD2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte), true);
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PROC_STAT", 2, typeof(Byte), true);
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WO_FLAG", "2", typeof(string), true);

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable milTable = DSHP.TSHP_ACTUAL_MILL.TSHP_ACTUAL_MILL_SER3(UTIL.GetRowToDt(row), bizExecute);

                    if (milTable.Rows.Count > 0)
                    {
                        throw UTIL.SetException("밀링이 시작된 품목이 존재합니다."
                        , new System.Diagnostics.StackFrame().GetMethod().Name
                        , BizException.ABORT);
                    }

                    DataTable dtSer = DSHP.TSHP_ACTUAL_CAM.TSHP_ACTUAL_CAM_SER2(UTIL.GetRowToDt(row), bizExecute);

                    if (dtSer.Rows.Count > 0)
                    {
                        row["ACTUAL_ID"] = dtSer.Rows[0]["ACTUAL_ID"];
                        DSHP.TSHP_ACTUAL_CAM.TSHP_ACTUAL_CAM_UPD3(UTIL.GetRowToDt(row), bizExecute);
                    }

                    DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD34_1(UTIL.GetRowToDt(row), bizExecute);
                }


                return POP02A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

    }
}
