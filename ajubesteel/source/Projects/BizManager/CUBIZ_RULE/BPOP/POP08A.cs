using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BPOP
{
    public class POP08A
    {
        public static DataSet POP08A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WO_TYPE", "CAM", typeof(string));

                DataTable dtRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY9(paramDS.Tables["RQSTDT"], bizExecute);

                UTIL.SetBizAddColumnToValue(dtRslt, "DATA_FLAG", 0, typeof(Byte), true);

                UTIL.SetBizAddColumnToValue(dtRslt, "WO_TYPE", "CAM", typeof(string), true);
                UTIL.SetBizAddColumnToValue(dtRslt, "NOT_WO_NO", "WO_NO");

                DataTable dtWoRslt = dtRslt.Clone();

                Dictionary<string, bool> chainDic = new Dictionary<string, bool>();

                string pt_id_not_in = "";

                foreach (DataRow row in dtRslt.Rows)
                {
                    pt_id_not_in = pt_id_not_in + "," + row["PT_ID"].ToString();

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

                        DataTable dtChainWoRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY9(paramTable, bizExecute);

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

                if (pt_id_not_in.Length > 1)
                {
                    pt_id_not_in = pt_id_not_in.Substring(1, pt_id_not_in.Length - 1);
                }


                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WO_TYPE", null, typeof(string));

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PROC_CODE", "P14", typeof(string));

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PT_ID_NOT_IN", pt_id_not_in, typeof(string));

                DataTable dtPoRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY9_1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.Merge(dtPoRslt);

                DataView dv = dtRslt.DefaultView;
                dv.Sort = "DUE_DATE ASC, PROD_PRIORITY ASC, PROD_CODE";

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

                dtRsltWo.TableName = "RSLTDT";

                dtRsltWo.Columns.Add("SEL");

                paramDS.Tables.Add(dtRsltWo);


                //DataView dv = dtRslt.DefaultView;
                //dv.Sort = "CHAIN_WO_NO";

                //dtRslt = dv.ToTable();

                //dtRslt.Columns.Add("SEL");
                //dtRslt.TableName = "RSLTDT";

                //paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        //public static DataSet POP08A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        //{
        //    try
        //    {
        //        UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

        //        UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WO_TYPE", "CAM", typeof(string));

        //        DataTable dtRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY9(paramDS.Tables["RQSTDT"], bizExecute);

        //        dtRslt.Columns.Add("SEL", typeof(string));
        //        dtRslt.TableName = "RSLTDT";

        //        paramDS.Tables.Add(dtRslt);

        //        return paramDS;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
        //    }
        //}


        /// <summary>
        ///   CAM담당자 지정
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet POP08A_SAVE(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte), true);


                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD29(UTIL.GetRowToDt(row), bizExecute);
                }


                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet POP08A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                string chainWoNo = "";
                string mcGroup = "";
                if (paramDS.Tables["RQSTDT"].Rows.Count > 0)
                {
                    chainWoNo = UTIL.UTILITY_GET_SERIALNO("100", "CW", UTIL.emSerialFormat.YYMMDDHH, "", bizExecute);
                    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "CHAIN_WO_NO", chainWoNo, typeof(string));
                    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "CHAIN_EMP", ConnInfo.UserID, typeof(string));
                    mcGroup = paramDS.Tables["RQSTDT"].Rows[0]["MC_GROUP"].ToString();
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

                        row["MC_GROUP"] = mcGroup;
                        if (row["RE_WO_NO"].ToString() == "")
                        {
                            DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD35(UTIL.GetRowToDt(row), bizExecute);
                        }
                        else
                        {
                            DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD35_1(UTIL.GetRowToDt(row), bizExecute);
                        }
                        
                    }
                }

                return POP08A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet POP08A_INS2(DataSet paramDS, BizExecute.BizExecute bizExecute)
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

                return POP08A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        /// <summary>
        /// 검사결과 삭제
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet POP08A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 2, typeof(Byte));


                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {

                    DSHP.TSHP_INSPECTION_RESULT.TSHP_INSPECTION_RESULT_UDE(UTIL.GetRowToDt(row), bizExecute);

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
