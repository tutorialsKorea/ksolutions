using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BPLN
{
    public class PLN08A
    {

        //품목 정보 가져오기(트리)
        public static DataSet PLN08A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DLSE.LSE_STD_PART_QUERY.LSE_STD_PART_QUERY10(paramDS.Tables["RQSTDT"], bizExecute);

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

        //해당 자품목조회
        public static DataSet PLN08A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataTable dtRslt = DSTD.TSTD_BOM_QUERY.TSTD_BOM_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.Columns.Add("SEL", typeof(string));
                dtRslt.TableName = "RSLTDT";

                if (dtRslt.Rows.Count > 0)
                {
                    DataTable dtSorted = dtRslt.Select("", "BOM_SEQ").CopyToDataTable();
                    dtSorted.TableName = "RSLTDT";
                    paramDS.Tables.Add(dtSorted);
                }
                else
                {
                   
                    paramDS.Tables.Add(dtRslt);
                }
                

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        //BOM리스트 조회
        public static DataSet PLN08A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataTable dtRslt = DSTD.TSTD_BOM_QUERY.TSTD_BOM_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

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

        public static DataSet PLN08A_SER4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                DataTable dtRslt = DSTD.TSTD_BOM_QUERY.TSTD_BOM_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);

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
        /// BOM 저장
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet PLN08A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                string _strBomPartCode = "";


                if (paramDS.Tables["RQSTDT_DEL"].Rows.Count > 0)
                {
                    if (_strBomPartCode == "")
                    {
                        _strBomPartCode = paramDS.Tables["RQSTDT_DEL"].Rows[0]["BOM_PART_CODE"].ToString();
                    }


                    DataTable dtDel = paramDS.Tables["RQSTDT_DEL"].Copy();
                    dtDel.TableName = "RQSTDT";
                    DataSet dsDel = new DataSet();
                    dsDel.Tables.Add(dtDel);

                    PLN08A_DEL(dsDel, bizExecute);

                }

                if (paramDS.Tables["RQSTDT"].Rows.Count > 0)
                {
                    if (_strBomPartCode == "")
                    {
                        _strBomPartCode = paramDS.Tables["RQSTDT"].Rows[0]["BOM_PART_CODE"].ToString();
                    }

                    //BOM등록여부 조회
                    DataTable dtBomSer = new DataTable("RQSTDT");
                    dtBomSer.Columns.Add("PLT_CODE", typeof(String));
                    dtBomSer.Columns.Add("BOM_PART_CODE", typeof(String));

                    DataRow paramRow = dtBomSer.NewRow();
                    paramRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                    paramRow["BOM_PART_CODE"] = _strBomPartCode;

                    dtBomSer.Rows.Add(paramRow);

                    DataTable dtBomSerRslt = DSTD.TSTD_BOM_QUERY.TSTD_BOM_QUERY1(dtBomSer, bizExecute);

                    if (dtBomSerRslt.Rows.Count == 0)
                    {
                        //등록된 BOM이 없으면 최상위 부품 INSERT
                        DataTable dtBomIns = new DataTable("RQSTDT");
                        dtBomIns.Columns.Add("PLT_CODE", typeof(String));
                        dtBomIns.Columns.Add("BOM_ID", typeof(String));
                        dtBomIns.Columns.Add("BOM_PART_CODE", typeof(String));
                        dtBomIns.Columns.Add("PARENT_ID", typeof(String));
                        dtBomIns.Columns.Add("PART_CODE", typeof(String));

                        DataRow paramRow2 = dtBomIns.NewRow();
                        paramRow2["PLT_CODE"] = ConnInfo.PLT_CODE;
                        paramRow2["BOM_ID"] = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "BM", bizExecute);
                        paramRow2["BOM_PART_CODE"] = _strBomPartCode;
                        paramRow2["PARENT_ID"] = null;
                        paramRow2["PART_CODE"] = _strBomPartCode;

                        dtBomIns.Rows.Add(paramRow2);

                        DSTD.TSTD_BOM.TSTD_BOM_INS(dtBomIns, bizExecute);

                        //모품목 설정
                        UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PARENT_ID", dtBomIns.Rows[0]["BOM_ID"].ToString(), typeof(String));
                    }


                    foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                    {
                        if (row["BOM_ID"].ToString() != "")
                        {
                            //BOM_ID가 있을 경우 UPDATE
                            DSTD.TSTD_BOM.TSTD_BOM_UPD(UTIL.GetRowToDt(row), bizExecute);

                        }
                        else
                        {
                            //BOM_ID가 없을경우 INSERT
                            row["BOM_ID"] = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "BM", bizExecute);

                            DSTD.TSTD_BOM.TSTD_BOM_INS(UTIL.GetRowToDt(row), bizExecute);

                            PLN.TurnningChildBomSave(UTIL.GetRowToDt(row), bizExecute);
                        }
                    }
                }
                
                DataTable dtRslt = new DataTable("RQSTDT");
                dtRslt.Columns.Add("PLT_CODE", typeof(String));
                dtRslt.Columns.Add("BOM_PART_CODE", typeof(String));

                DataRow paramRow3 = dtRslt.NewRow();
                paramRow3["PLT_CODE"] = ConnInfo.PLT_CODE;
                paramRow3["BOM_PART_CODE"] = _strBomPartCode;
                dtRslt.Rows.Add(paramRow3);

                DataSet dsRslt = new DataSet();

                dsRslt.Tables.Add(dtRslt);

                return PLN08A_SER3(dsRslt, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        //BOM붙여넣기
        public static DataSet PLN08A_INS2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                paramDS.Tables["RQSTDT"].Columns.Add("NEW_BOM_ID", typeof(String));

                //BOM등록여부 조회
                DataTable dtBomSer = new DataTable("RQSTDT");
                dtBomSer.Columns.Add("PLT_CODE", typeof(String));
                dtBomSer.Columns.Add("BOM_PART_CODE", typeof(String));

                DataRow paramRow = dtBomSer.NewRow();
                paramRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                paramRow["BOM_PART_CODE"] = paramDS.Tables["RQSTDT"].Rows[0]["NEW_BOM_PART_CODE"];

                dtBomSer.Rows.Add(paramRow);

                DataTable dtBomSerRslt = DSTD.TSTD_BOM_QUERY.TSTD_BOM_QUERY1(dtBomSer, bizExecute);

                string _strTopBomID = "";
                if (dtBomSerRslt.Rows.Count == 0)
                {
                        DataTable dtBomIns = new DataTable("RQSTDT");
                        dtBomIns.Columns.Add("PLT_CODE", typeof(String));
                        dtBomIns.Columns.Add("BOM_ID", typeof(String));
                        dtBomIns.Columns.Add("BOM_PART_CODE", typeof(String));
                        dtBomIns.Columns.Add("PARENT_ID", typeof(String));
                        dtBomIns.Columns.Add("PART_CODE", typeof(String));

                        DataRow paramRow2 = dtBomIns.NewRow();
                        paramRow2["PLT_CODE"] = ConnInfo.PLT_CODE;
                        _strTopBomID = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "BM", bizExecute);
                        paramRow2["BOM_ID"] = _strTopBomID;
                        paramRow2["BOM_PART_CODE"] = paramDS.Tables["RQSTDT"].Rows[0]["NEW_BOM_PART_CODE"];
                        paramRow2["PARENT_ID"] = null;
                        paramRow2["PART_CODE"] = paramDS.Tables["RQSTDT"].Rows[0]["NEW_BOM_PART_CODE"];

                        dtBomIns.Rows.Add(paramRow2);

                        DSTD.TSTD_BOM.TSTD_BOM_INS(dtBomIns, bizExecute);


                        foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                        {
                            if (row["PARENT_ID"].ToString() != "")
                            {
                                DataTable dtBomIns2 = DSTD.TSTD_BOM.TSTD_BOM_SER(UTIL.GetRowToDt(row), bizExecute);

                                dtBomIns2.Rows[0]["BOM_PART_CODE"] = row["NEW_BOM_PART_CODE"];

                                dtBomIns2.Rows[0]["BOM_ID"] = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "BM", bizExecute);

                                dtBomIns2.Rows[0]["PARENT_ID"] = _strTopBomID;

                                DSTD.TSTD_BOM.TSTD_BOM_INS(dtBomIns2, bizExecute);

                                row["NEW_BOM_ID"] = dtBomIns2.Rows[0]["BOM_ID"];

                                childIns(UTIL.GetRowToDt(row), bizExecute);
                            }
                            else
                            {
                                row["NEW_BOM_ID"] = _strTopBomID;

                                childIns(UTIL.GetRowToDt(row), bizExecute);
                            }
                            
                            
                        }
                }
                else
                {
                    foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                    {
                        DataTable dtBomIns = DSTD.TSTD_BOM.TSTD_BOM_SER(UTIL.GetRowToDt(row), bizExecute);

                        dtBomIns.Rows[0]["BOM_PART_CODE"] = row["NEW_BOM_PART_CODE"];

                        dtBomIns.Rows[0]["BOM_ID"] = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "BM", bizExecute);

                        dtBomIns.Rows[0]["PARENT_ID"] = row["NEW_PARENT_ID"];

                        DSTD.TSTD_BOM.TSTD_BOM_INS(dtBomIns, bizExecute);

                        row["NEW_BOM_ID"] = dtBomIns.Rows[0]["BOM_ID"];
                        childIns(UTIL.GetRowToDt(row), bizExecute);
                    }
                }

                DataTable dtRslt = new DataTable("RQSTDT");
                dtRslt.Columns.Add("PLT_CODE", typeof(String));
                dtRslt.Columns.Add("BOM_PART_CODE", typeof(String));

                DataRow paramRow3 = dtRslt.NewRow();
                paramRow3["PLT_CODE"] = ConnInfo.PLT_CODE;
                paramRow3["BOM_PART_CODE"] = paramDS.Tables["RQSTDT"].Rows[0]["NEW_BOM_PART_CODE"];
                dtRslt.Rows.Add(paramRow3);

                DataSet dsRslt = new DataSet();

                dsRslt.Tables.Add(dtRslt);

                return PLN08A_SER3(dsRslt, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet PLN08A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                string _strBomPartCode = "";
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    if (_strBomPartCode == "")
                    {
                        _strBomPartCode = row["BOM_PART_CODE"].ToString();
                    }

                    DSTD.TSTD_BOM.TSTD_BOM_DEL(UTIL.GetRowToDt(row), bizExecute);

                    childDel(UTIL.GetRowToDt(row), bizExecute);
                }

                DataTable dtRslt = new DataTable("RQSTDT");
                dtRslt.Columns.Add("PLT_CODE", typeof(String));
                dtRslt.Columns.Add("BOM_PART_CODE", typeof(String));

                DataRow paramRow = dtRslt.NewRow();
                paramRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                paramRow["BOM_PART_CODE"] = _strBomPartCode;
                dtRslt.Rows.Add(paramRow);

                DataSet dsRslt = new DataSet();

                dsRslt.Tables.Add(dtRslt);

                return PLN08A_SER3(dsRslt, bizExecute);

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        //자품목 DELETE
        public static void childDel(DataTable paramDT, BizExecute.BizExecute bizExecute)
        {
            DataTable dtChild = DSTD.TSTD_BOM.TSTD_BOM_SER3(paramDT, bizExecute);

            if (dtChild.Rows.Count != 0)
            {
                DSTD.TSTD_BOM.TSTD_BOM_DEL(dtChild, bizExecute);

                for (int i = 0; i < dtChild.Rows.Count; i++)
                {
                    dtChild.Rows[i]["PARENT_ID"] = dtChild.Rows[i]["BOM_ID"];
                }

                childDel(dtChild, bizExecute);
            }

        }

        //자품목 INSERT
        public static void childIns(DataTable paramDT, BizExecute.BizExecute bizExecute)
        {
  
            foreach (DataRow paramRow in paramDT.Rows)
            {

                DataTable dtChild = DSTD.TSTD_BOM.TSTD_BOM_SER3(UTIL.GetRowToDt(paramRow), bizExecute);

                DataTable dtChildCopy = dtChild.Copy();

                dtChildCopy.Columns.Add("NEW_BOM_ID", typeof(string));
                dtChildCopy.Columns.Add("NEW_BOM_PART_CODE", typeof(string));

                if (dtChildCopy.Rows.Count != 0)
                {

                    foreach (DataRow row in dtChildCopy.Rows)
                    {
                        if (paramRow["NEW_BOM_ID"].ToString() != row["BOM_ID"].ToString())
                        {
                            DataTable dtTemp = UTIL.GetRowToDt(row).Copy();
                            DataTable dtBomIns = dtTemp.Copy();

                            dtBomIns.Rows[0]["BOM_ID"] = UTIL.UTILITY_GET_SERIALNO(dtBomIns.Rows[0]["PLT_CODE"].ToString(), "BM", bizExecute);
                            dtBomIns.Rows[0]["PARENT_ID"] = paramDT.Rows[0]["NEW_BOM_ID"];
                            dtBomIns.Rows[0]["BOM_PART_CODE"] = paramDT.Rows[0]["NEW_BOM_PART_CODE"].ToString();


                            DSTD.TSTD_BOM.TSTD_BOM_INS(UTIL.GetRowToDt(dtBomIns.Rows[0]), bizExecute);


                            row["NEW_BOM_ID"] = dtBomIns.Rows[0]["BOM_ID"];
                            row["NEW_BOM_PART_CODE"] = dtBomIns.Rows[0]["BOM_PART_CODE"];

                            childIns(UTIL.GetRowToDt(row), bizExecute);
                        }
                    }


                    
                }

            }
        }

    }
}
