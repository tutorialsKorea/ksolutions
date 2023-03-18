using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BizExecute;

namespace BSTD
{
    public class STD50A
    {
        public static DataSet STD50A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSTD.TSTD_BOM_MASTER_QUERY.TSTD_BOM_MASTER_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet STD50A_SER1(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DLSE.LSE_STD_PART_QUERY.LSE_STD_PART_QUERY4(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet STD50A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                DataTable dtResult = DSTD.TSTD_BOM_QUERY.TSTD_BOM_QUERY4(paramDS.Tables["RQSTDT"], bizExecute);
                dtResult.Columns.Add("STATE", typeof(String));
                dtResult.TableName = "RSLTDT";

                dsResult.Tables.Add(dtResult);

                return dsResult;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet STD50A_SER4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataSet dsResult = new DataSet();

                DataTable dtResult = DSTD.TSTD_BOM_QUERY.TSTD_BOM_QUERY4(paramDS.Tables["RQSTDT"], bizExecute);
                dtResult.Columns.Add("STATE", typeof(String));
                dtResult.TableName = "RSLTDT";

                dsResult.Merge(dtResult);


                if (paramDS.Tables["RQSTDT"].Rows[0]["PARENT_ID"].ToString() != "")
                {
                    DataTable dtParent = new DataTable("RQSTDT");
                    dtParent.Columns.Add("PLT_CODE", typeof(String));
                    dtParent.Columns.Add("BM_CODE", typeof(String));
                    dtParent.Columns.Add("BOM_ID", typeof(String));

                    DataRow drParent = dtParent.NewRow();
                    drParent["PLT_CODE"] = paramDS.Tables["RQSTDT"].Rows[0]["PLT_CODE"];
                    //drParent["BM_CODE"] = paramDS.Tables["RQSTDT"].Rows[0]["BM_CODE"];
                    //drParent["BOM_ID"] = dtResult.Rows[0]["PARENT_ID"];
                    drParent["BOM_ID"] = paramDS.Tables["RQSTDT"].Rows[0]["PARENT_ID"];
                    dtParent.Rows.Add(drParent);

                    DataTable dtBan = DSTD.TSTD_BOM_QUERY.TSTD_BOM_QUERY4(dtParent, bizExecute);
                    dsResult.Merge(dtBan);

                }

                return dsResult;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet STD50A_SER6(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSTD.TSTD_BOM_MASTER.TSTD_BOM_MASTER_SER4(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet STD50A_SER7(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSTD.TSTD_BOM.TSTD_BOM_SER(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet STD50A_SER9(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataTable dtRslt = DSTD.TSTD_BOM.TSTD_BOM_SER_1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet STD50A_SER11(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataTable dtRslt = DSTD.TSTD_BOM_QUERY.TSTD_BOM_QUERY7(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet STD50A_SER12(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataTable dtRslt = DSTD.TSTD_BOM_QUERY.TSTD_BOM_QUERY8(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT2";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet STD50A_SER14(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DLSE.LSE_STD_PART_QUERY.LSE_STD_PART_QUERY6_1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.Columns.Add("SEL", typeof(string));
                dtRslt.Columns.Add("REV_NO", typeof(string));
                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet STD50A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                //BOM 상태체크
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "CAT_CODE", "0A04", typeof(String));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "VALUE", "NOT DELETE", typeof(String));

                //DataTable dtSer = DSTD.TSTD_BOM_MASTER.TSTD_BOM_MASTER_SER6(paramDS.Tables["RQSTDT"], bizExecute);

                //foreach (DataRow dr in dtSer.Rows)
                //{
                //    if (dr["CAT_VALUE"].ToString() == "HALF")
                //        break;
                //    if (dr["BOM_STATE"].ToString() == dr["NOT_DEL_BOM_STATE"].ToString())
                //    {
                //        throw UTIL.SetException("BOM 상태가 [양산] 일 경우 삭제가 불가합니다."
                //      , "Error"
                //      , new System.Diagnostics.StackFrame().GetMethod().Name
                //      , BizException.ABORT);

                //    }
                //}

                //리비전 체크
                DataTable dtRev = DSTD.TSTD_BOM_MASTER.TSTD_BOM_MASTER_SER3(paramDS.Tables["RQSTDT"], bizExecute);
                if (dtRev.Rows[0]["REV_NO"].toInt() > paramDS.Tables["RQSTDT"].Rows[0]["REV_NO"].toInt())
                {
                    //리비전이 다르면 오류
                    throw UTIL.SetException("최상위 리비전만 삭제가 가능합니다."
                  , "Error"
                  , new System.Diagnostics.StackFrame().GetMethod().Name
                  , BizException.ABORT);
                }

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 2, typeof(Byte));

                DSTD.TSTD_BOM_MASTER.TSTD_BOM_MASTER_DEL(paramDS.Tables["RQSTDT"], bizExecute);
                DSTD.TSTD_BOM.TSTD_BOM_DEL2(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable searchT = new DataTable("RQSTDT");
                searchT.Columns.Add("PLT_CODE", typeof(string));
                searchT.Columns.Add("PART_CODE", typeof(string));
                searchT.Columns.Add("BM_KEY", typeof(string));
                searchT.Columns.Add("DATA_FLAG", typeof(int));

                DataRow searchr = searchT.NewRow();
                searchr["PLT_CODE"] = paramDS.Tables["RQSTDT"].Rows[0]["PLT_CODE"];
                searchr["PART_CODE"] = paramDS.Tables["RQSTDT"].Rows[0]["PART_CODE"];
                searchr["BM_KEY"] = paramDS.Tables["RQSTDT"].Rows[0]["BM_KEY"];
                searchr["DATA_FLAG"] = 0;

                searchT.Rows.Add(searchr);


                DataTable dtRslt = DLSE.LSE_STD_PART_QUERY.LSE_STD_PART_QUERY4(searchT, bizExecute);

                dtRslt.TableName = "RSLTDT";

                DataTable dtRslt2 = DSTD.TSTD_BOM_MASTER_QUERY.TSTD_BOM_MASTER_QUERY1(searchT, bizExecute);

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

        public static DataSet STD50A_INS2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_M"], "DATA_FLAG", 0, typeof(Byte));

                //BOM 상태체크
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_M"], "CAT_CODE", "0A04", typeof(String));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_M"], "VALUE", "NOT DELETE", typeof(String));

                //개정 정보가 존재하면 개정
                if (paramDS.Tables.Contains("RQSTDT_REV"))
                {
                    //개정
                    foreach (DataRow row in paramDS.Tables["RQSTDT_REV"].Rows)
                    {
                        //리비전 체크
                        DataTable dtRev = DSTD.TSTD_BOM_MASTER.TSTD_BOM_MASTER_SER3(paramDS.Tables["RQSTDT_REV"], bizExecute);
                        if (dtRev.Rows[0]["NEXT_REV_NO"].toInt() != row["REV_NO"].toInt())
                        {
                            //리비전이 다르면 오류
                            throw UTIL.SetException("BOM 리비전 정보가 옳바르지 않습니다."
                          , "Error"
                          , new System.Diagnostics.StackFrame().GetMethod().Name
                          , BizException.ABORT);
                        }

                        //리비전 저장
                        UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_M"], "REV_NO", row["REV_NO"].toInt(), typeof(Int32));

                        //BM KEY 생성
                        string sBM_KEY = UTIL.UTILITY_GET_SERIALNO(paramDS.Tables["RQSTDT_M"].Rows[0]["PLT_CODE"].ToString(), "BK", UTIL.emSerialFormat.YYMMDD, "", bizExecute);
                        UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_M"], "BM_KEY", sBM_KEY, typeof(String));

                        UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_M"], "REV_COMMENT", row["REV_COMMENT"], typeof(String));
                        UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_M"], "REV_DATE", row["REV_DATE"], typeof(String));

                        //BOM 마스터 저장
                        DSTD.TSTD_BOM_MASTER.TSTD_BOM_MASTER_INS(paramDS.Tables["RQSTDT_M"], bizExecute);
                    }

                    //개정 발생 + 알림 수신자 지정한 경우 알림 게시판 등록
                    if (paramDS.Tables.Contains("RQSTDT_BOARD"))
                    {
                        DataTable dtBoardIns = paramDS.Tables["RQSTDT_BOARD"];

                        DataRow drBoard = dtBoardIns.Rows[0];

                        string serial = UTIL.UTILITY_GET_SERIALNO(drBoard["PLT_CODE"].ToString(), "BRD", bizExecute);

                        drBoard["BOARD_ID"] = serial;

                        DSYS.TSYS_BOARD.TSYS_BOARD_INS(dtBoardIns, bizExecute);

                        if (paramDS.Tables["RQSTDT_BOARD_LIST"].Rows.Count != 0)
                        {
                            paramDS.Tables["RQSTDT_BOARD_LIST"].Columns.Add("BOARD_EMP_ID", typeof(String));
                            paramDS.Tables["RQSTDT_BOARD_LIST"].Columns.Add("BOARD_ID", typeof(String));

                            foreach (DataRow drList in paramDS.Tables["RQSTDT_BOARD_LIST"].Rows)
                            {
                                string empID = UTIL.UTILITY_GET_SERIALNO(drList["PLT_CODE"].ToString(), "BRDE", bizExecute);

                                drList["BOARD_EMP_ID"] = empID;
                                drList["BOARD_ID"] = serial;

                                DSYS.TSYS_BOARD_EMP.TSYS_BOARD_EMP_INS(UTIL.GetRowToDt(drList), bizExecute);
                            }
                        }
                    }
                }
                else
                {
                    DataTable dtSerM = DSTD.TSTD_BOM_MASTER.TSTD_BOM_MASTER_SER4(paramDS.Tables["RQSTDT_M"], bizExecute);

                    if (dtSerM.Rows.Count > 0)
                    {   //기존 정보 수정
                        UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_M"], "DATA_FLAG", 0, typeof(Byte));
                        DSTD.TSTD_BOM_MASTER.TSTD_BOM_MASTER_UPD(paramDS.Tables["RQSTDT_M"], bizExecute);

                    }
                    else
                    {
                        //신규 등록
                        //BOM 마스터 임시 키 생성
                        string sBM_KEY = UTIL.UTILITY_GET_SERIALNO(paramDS.Tables["RQSTDT_M"].Rows[0]["PLT_CODE"].ToString(), "BK", UTIL.emSerialFormat.YYMMDD, "", bizExecute);
                        UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_M"], "BM_KEY", sBM_KEY, typeof(String));

                        //리비전
                        DataTable dtRev = DSTD.TSTD_BOM_MASTER.TSTD_BOM_MASTER_SER3(paramDS.Tables["RQSTDT_M"], bizExecute);
                        UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT_M"], "REV_NO", dtRev.Rows[0]["NEXT_REV_NO"].toInt(), typeof(Int32));

                        //BOM 마스터 저장
                        DSTD.TSTD_BOM_MASTER.TSTD_BOM_MASTER_INS(paramDS.Tables["RQSTDT_M"], bizExecute);
                    }
                }

                //등록
                DataTable dtParam = paramDS.Tables["RQSTDT"];
                string bom_id = string.Empty;
                string parent_id;

                foreach (DataRow dr in dtParam.Rows)
                {
                    //리비전일 경우 새로저장
                    if (paramDS.Tables.Contains("RQSTDT_REV"))
                    {
                        dr["BOM_ID"] = "";
                    }

                    dr["BM_KEY"] = paramDS.Tables["RQSTDT_M"].Rows[0]["BM_KEY"];

                    DataTable dtSer = DSTD.TSTD_BOM.TSTD_BOM_SER(UTIL.GetRowToDt(dr), bizExecute);

                    if (dtSer.Rows.Count > 0)
                    {
                        DSTD.TSTD_BOM.TSTD_BOM_UPD(UTIL.GetRowToDt(dr), bizExecute);
                    }
                    else
                    {
                        if (!dr["BOM_ID"].ToString().StartsWith("BM"))
                            dr["BOM_ID"] = UTIL.UTILITY_GET_SERIALNO(dr["PLT_CODE"].ToString(), "BM", UTIL.emSerialFormat.YYMMDD, "", bizExecute);


                        if (!dr["PARENT_ID"].ToString().StartsWith("BM")
                        || paramDS.Tables.Contains("RQSTDT_REV"))
                        {
                            //부모 ID 찾기
                            DataRow[] pRows = dtParam.Select("ID = '" + dr["P_ID"].ToString() + "'");
                            if (pRows.Length > 0)
                            {
                                parent_id = pRows[0]["BOM_ID"].ToString();
                                dr["PARENT_ID"] = parent_id;
                            }

                        }

                        DSTD.TSTD_BOM.TSTD_BOM_INS(UTIL.GetRowToDt(dr), bizExecute);
                    }
                }

                foreach (DataRow dr in dtParam.Rows)
                {
                    if (!dr["PARENT_ID"].ToString().StartsWith("BM")
                        || paramDS.Tables.Contains("RQSTDT_REV"))
                    {
                        //부모 ID 찾기
                        DataRow[] pRows = dtParam.Select("ID = '" + dr["P_ID"].ToString() + "'");
                        if (pRows.Length > 0)
                        {
                            parent_id = pRows[0]["BOM_ID"].ToString();
                            dr["PARENT_ID"] = parent_id;

                            DSTD.TSTD_BOM.TSTD_BOM_UPD(UTIL.GetRowToDt(dr), bizExecute);
                        }

                    }
                }

                //자품목 삭제 필요
                if (paramDS.Tables.Contains("DEL_RQSTDT"))
                {
                    foreach (DataRow drDel in paramDS.Tables["DEL_RQSTDT"].Rows)
                    {
                        //DeleteChildren(UTIL.GetRowToDt(drDel), bizExecute);
                        //DeleteChildren2(UTIL.GetRowToDt(drDel), bizExecute);
                        DSTD.TSTD_BOM.TSTD_BOM_DEL(UTIL.GetRowToDt(drDel), bizExecute);
                    }


                }

                DataTable rsltdt = new DataTable("RSLTDT_M");
                rsltdt.Columns.Add("PLT_CODE", typeof(String));
                rsltdt.Columns.Add("BM_KEY", typeof(String));
                rsltdt.Columns.Add("BM_CODE", typeof(String));

                DataRow rsltrow = rsltdt.NewRow();
                rsltrow["PLT_CODE"] = paramDS.Tables["RQSTDT_M"].Rows[0]["PLT_CODE"];
                rsltrow["BM_KEY"] = paramDS.Tables["RQSTDT_M"].Rows[0]["BM_KEY"];
                rsltrow["BM_CODE"] = paramDS.Tables["RQSTDT_M"].Rows[0]["BM_CODE"];
                rsltdt.Rows.Add(rsltrow);

                DataTable rsltM = DSTD.TSTD_BOM_MASTER_QUERY.TSTD_BOM_MASTER_QUERY1(rsltdt, bizExecute);

                DataTable dtResult = DSTD.TSTD_BOM_QUERY.TSTD_BOM_QUERY4(rsltdt, bizExecute);
                dtResult.Columns.Add("STATE", typeof(String));
                dtResult.TableName = "RSLTDT_BOM";

                paramDS.Tables.Add(rsltM);
                paramDS.Tables.Add(dtResult);

                return paramDS;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet STD50A_INS3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                int rows = DSTD.TSTD_BOM.TSTD_BOM_UPD2(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable dtResult = new DataTable("RSLTDT");
                dtResult.Columns.Add("RESULT_ROWS", typeof(Int32));

                DataRow drResult = dtResult.NewRow();
                dtResult.Rows.Add(drResult);
                drResult["RESULT_ROWS"] = rows;

                paramDS.Tables.Add(dtResult);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet STD50A_INS4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (paramDS.Tables["RQSTDT"].Rows.Count > 0)
                {
                    DataRow row = paramDS.Tables["RQSTDT"].Rows[0];
                    DataTable dt = DSTD.TSTD_BOM_MASTER.TSTD_BOM_MASTER_SER8(UTIL.GetRowToDt(row), bizExecute);
                    row["REV_NO"] = dt.Rows[0]["REV_NO"];

                    string sBM_KEY = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "BK", UTIL.emSerialFormat.YYMMDD, "", bizExecute);
                    row["BM_KEY"] = sBM_KEY;

                    DSTD.TSTD_BOM_MASTER.TSTD_BOM_MASTER_INS(UTIL.GetRowToDt(row), bizExecute);

                    Dictionary<string, string> BM_DIC = new Dictionary<string, string>();

                    if (paramDS.Tables["RQSTDT_BOM"].Rows.Count > 0)
                    {
                        foreach (DataRow dr in paramDS.Tables["RQSTDT_BOM"].Rows)
                        {
                            dr["BM_CODE"] = row["BM_CODE"];
                            dr["BM_KEY"] = sBM_KEY;
                            if (BM_DIC.ContainsKey(dr["BOM_ID"].ToString()))
                            {
                                dr["BOM_ID"] = BM_DIC[dr["BOM_ID"].ToString()];
                            }
                            else
                            {
                                string bm_code = UTIL.UTILITY_GET_SERIALNO(dr["PLT_CODE"].ToString(), "BM", UTIL.emSerialFormat.YYMMDD, "", bizExecute);
                                BM_DIC.Add(dr["BOM_ID"].ToString(), bm_code);

                                dr["BOM_ID"] = bm_code;

                            }

                            if (BM_DIC.ContainsKey(dr["PARENT_ID"].ToString()))
                            {
                                dr["PARENT_ID"] = BM_DIC[dr["PARENT_ID"].ToString()];
                            }
                            else
                            {
                                string bm_code = UTIL.UTILITY_GET_SERIALNO(dr["PLT_CODE"].ToString(), "BM", UTIL.emSerialFormat.YYMMDD, "", bizExecute);
                                BM_DIC.Add(dr["PARENT_ID"].ToString(), bm_code);

                                dr["PARENT_ID"] = bm_code;

                            }

                            if (dr["BOM_ID"].ToString() == dr["PARENT_ID"].ToString())
                                dr["PART_CODE"] = dr["BM_CODE"];

                        }
                    }

                    DSTD.TSTD_BOM.TSTD_BOM_INS(paramDS.Tables["RQSTDT_BOM"], bizExecute);



                }

                DataTable dtRslt = DLSE.LSE_STD_PART_QUERY.LSE_STD_PART_QUERY4(paramDS.Tables["RQSTDT"], bizExecute);

                //DataTable dtRslt = DLSE.LSE_STD_PART_QUERY.LSE_STD_PART_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                DataTable dtRslt2 = DSTD.TSTD_BOM_MASTER_QUERY.TSTD_BOM_MASTER_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

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

        public static DataSet STD50A_INS5(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (paramDS.Tables["RQSTDT"].Rows.Count > 0)
                {
                    DataRow row = paramDS.Tables["RQSTDT"].Rows[0];

                    Dictionary<string, string> BM_DIC = new Dictionary<string, string>();

                    //BM_DIC.Add("temp", "temp");

                    if (paramDS.Tables["RQSTDT_BOM"].Rows.Count > 0)
                    {
                        foreach (DataRow dr in paramDS.Tables["RQSTDT_BOM"].Rows)
                        {
                            dr["BM_CODE"] = row["BM_CODE"];
                            dr["BM_KEY"] = row["BM_KEY"];

                            if (BM_DIC.ContainsKey(dr["BOM_ID"].ToString()))
                            {
                                dr["BOM_ID"] = BM_DIC[dr["BOM_ID"].ToString()];
                            }
                            else
                            {
                                string bm_code = UTIL.UTILITY_GET_SERIALNO(dr["PLT_CODE"].ToString(), "BM", UTIL.emSerialFormat.YYMMDD, "", bizExecute);
                                BM_DIC.Add(dr["BOM_ID"].ToString(), bm_code);

                                dr["BOM_ID"] = bm_code;

                            }

                            if (BM_DIC.ContainsKey(dr["PARENT_ID"].ToString()))
                            {
                                dr["PARENT_ID"] = BM_DIC[dr["PARENT_ID"].ToString()];
                            }
                            else
                            {
                                if (dr["PARENT_ID"].ToString() == "0")
                                {
                                    dr["PARENT_ID"] = row["PARENT_ID"];
                                }
                                else
                                {
                                    string bm_code = UTIL.UTILITY_GET_SERIALNO(dr["PLT_CODE"].ToString(), "BM", UTIL.emSerialFormat.YYMMDD, "", bizExecute);
                                    BM_DIC.Add(dr["PARENT_ID"].ToString(), bm_code);

                                    dr["PARENT_ID"] = bm_code;
                                }

                            }

                            if (dr["BOM_ID"].ToString() == dr["PARENT_ID"].ToString())
                                dr["PART_CODE"] = dr["BM_CODE"];

                        }
                    }

                    DSTD.TSTD_BOM.TSTD_BOM_INS(paramDS.Tables["RQSTDT_BOM"], bizExecute);



                }

                //DataTable dtRslt = DLSE.LSE_STD_PART_QUERY.LSE_STD_PART_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

                //dtRslt.TableName = "RSLTDT";

                //DataTable dtRslt2 = DSTD.TSTD_BOM_MASTER_QUERY.TSTD_BOM_MASTER_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                //dtRslt2.TableName = "RSLTDT2";

                //paramDS.Tables.Add(dtRslt);

                //paramDS.Tables.Add(dtRslt2);




                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet STD50A_UPD(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DSTD.TSTD_BOM_MASTER.TSTD_BOM_MASTER_UPD2(paramDS.Tables["RQSTDT"], bizExecute);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

    }
}
