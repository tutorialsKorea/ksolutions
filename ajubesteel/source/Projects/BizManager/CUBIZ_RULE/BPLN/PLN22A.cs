using BizExecute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPLN
{
    public class PLN22A
    {
        public static DataSet PLN22A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY31(paramDS.Tables["RQSTDT"], bizExecute);

                UTIL.SetBizAddColumnToValue(dtRslt, "DATA_FLAG", 0, typeof(Byte), true);

                //UTIL.SetBizAddColumnToValue(dtRslt, "NOT_WO_NO", "WO_NO");
                UTIL.SetBizAddColumnToValue(dtRslt, "NOT_PT_ID", "PT_ID");


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
                            DataRow[] rows = dtWoRslt.Select("PT_ID = '" + row["PT_ID"].ToString() + "'");
                            if (rows.Length > 0)
                            {
                                dtWoRslt.Rows.Remove(rows[0]);
                            }
                            continue;
                        }

                        DataTable paramTable = new DataTable("RQSTDT");
                        paramTable.Columns.Add("PLT_CODE", typeof(string));
                        //paramTable.Columns.Add("NOT_WO_NO", typeof(string));
                        paramTable.Columns.Add("NOT_PT_ID", typeof(string));
                        paramTable.Columns.Add("CHAIN_WO_NO", typeof(string));
                        paramTable.Columns.Add("DATA_FLAG", typeof(Byte));

                        DataRow paramRow = paramTable.NewRow();
                        paramRow["PLT_CODE"] = row["PLT_CODE"];
                        //paramRow["NOT_WO_NO"] = row["NOT_WO_NO"];
                        paramRow["NOT_PT_ID"] = row["NOT_PT_ID"];
                        paramRow["CHAIN_WO_NO"] = row["CHAIN_WO_NO"];
                        paramRow["DATA_FLAG"] = 0;

                        paramTable.Rows.Add(paramRow);

                        DataTable dtChainWoRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY31(paramTable, bizExecute);

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

                dtRsltWo.Columns.Add("SEL", typeof(string));

                dtRsltWo.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRsltWo);



                string ptIDs = "";
                foreach (DataRow row in dtRsltWo.Rows)
                {
                    ptIDs += "," + row["PT_ID"].ToString();
                }

                if (ptIDs.Length > 0)
                {
                    ptIDs = ptIDs.Substring(1, ptIDs.Length - 1);
                }

                DataTable woTable = new DataTable("RQSTDT");
                woTable.Columns.Add("PLT_CODE", typeof(string));
                woTable.Columns.Add("PT_ID_IN", typeof(string));
                woTable.Columns.Add("DATA_FLAG", typeof(byte));

                UTIL.SetBizAddColumnToValue(woTable, "PLT_CODE", ConnInfo.PLT_CODE, typeof(string));
                UTIL.SetBizAddColumnToValue(woTable, "PT_ID_IN", ptIDs, typeof(string));
                UTIL.SetBizAddColumnToValue(woTable, "DATA_FLAG", 0, typeof(Byte));

                DataTable dtDetailWoRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY32(woTable, bizExecute);

                dtDetailWoRslt.TableName = "RSLTDT_WO";

                paramDS.Tables.Add(dtDetailWoRslt);


                foreach (DataRow row in dtRsltWo.Rows)
                {
                    string where = string.Format("PT_ID = '{0}' AND RE_WO_NO IS NULL", row["PT_ID"]);

                    if (row["RE_WO_NO"].toStringEmpty() != "")
                    {
                        where = string.Format("PT_ID = '{0}' AND RE_WO_NO = '{1}'", row["PT_ID"], row["RE_WO_NO"]);
                    }

                    DataRow[] rows = dtDetailWoRslt.Select(where);

                    if (rows.Length > 0)
                    {
                        foreach (DataRow rw in rows)
                        {
                            if (!dtRsltWo.Columns.Contains(rw["PROC_CODE"].ToString()))
                            {
                                dtRsltWo.Columns.Add(rw["PROC_CODE"].ToString(), typeof(String));
                            }

                            row[rw["PROC_CODE"].ToString()] = rw["WO_FLAG"];
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

        public static DataSet PLN22A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
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

                return PLN22A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PLN22A_INS2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PREV_CHAIN_WO_NO", DBNull.Value, typeof(string), true);
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "CHAIN_EMP", DBNull.Value, typeof(string), true);

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

                return PLN22A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PLN22A_INS3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable woRslt = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER3(UTIL.GetRowToDt(row), bizExecute);

                    foreach (DataRow rw in woRslt.Rows)
                    {
                        if (rw["WO_FLAG"].ToString() == "0")
                        {
                            DataTable woTable = new DataTable("RQSTDT");
                            woTable.Columns.Add("PLT_CODE", typeof(string));
                            woTable.Columns.Add("WO_NO", typeof(string));
                            woTable.Columns.Add("WO_FLAG", typeof(byte));

                            UTIL.SetBizAddColumnToValue(woTable, "PLT_CODE", ConnInfo.PLT_CODE, typeof(string));
                            UTIL.SetBizAddColumnToValue(woTable, "WO_NO", rw["WO_NO"].ToString(), typeof(string));
                            UTIL.SetBizAddColumnToValue(woTable, "WO_FLAG", "1", typeof(string));

                            DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD5_5(woTable, bizExecute);
                        }
                    }
                }

                return PLN22A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PLN22A_INS4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable woRslt = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER3(UTIL.GetRowToDt(row), bizExecute);

                    foreach (DataRow rw in woRslt.Rows)
                    {
                        if (rw["WO_FLAG"].ToString() == "1")
                        {
                            DataTable woTable = new DataTable("RQSTDT");
                            woTable.Columns.Add("PLT_CODE", typeof(string));
                            woTable.Columns.Add("WO_NO", typeof(string));
                            woTable.Columns.Add("WO_FLAG", typeof(byte));

                            UTIL.SetBizAddColumnToValue(woTable, "PLT_CODE", ConnInfo.PLT_CODE, typeof(string));
                            UTIL.SetBizAddColumnToValue(woTable, "WO_NO", rw["WO_NO"].ToString(), typeof(string));
                            UTIL.SetBizAddColumnToValue(woTable, "WO_FLAG", "0", typeof(string));

                            DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD5_5(woTable, bizExecute);
                        }
                    }
                }

                return PLN22A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
    }
}
