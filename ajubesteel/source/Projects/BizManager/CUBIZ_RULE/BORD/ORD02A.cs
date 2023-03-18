using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BizExecute;

namespace BORD
{
    public class ORD02A
    {
        /// <summary>
        /// 수주 등록
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet ORD02A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
  

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {

                    DataTable dtRslt = DORD.TORD_PRODUCT.TORD_PRODUCT_SER(UTIL.GetRowToDt(row), bizExecute);

                    //데이터가 있을경우
                    if (dtRslt.Rows.Count > 0)
                    {
                        //데이터 삭제여부
                        if (row["OVERWRITE"].Equals("1"))
                        {
                            //덮어쓰기 여부
                            if (row["DATA_FLAG"].Equals("2"))
                            {
                                throw UTIL.SetException("동일 이력 데이터가 존재합니다."
                                   , new System.Diagnostics.StackFrame().GetMethod().Name);                                
                            }
                            else
                            {
                                IsLock(row, bizExecute);

                                //DORD.TORD_ITEM.TORD_ITEM_UPD(UTIL.GetRowToDt(row), bizExecute);
                                DORD.TORD_PRODUCT.TORD_PRODUCT_UPD(UTIL.GetRowToDt(row), bizExecute);


                                //DataTable dtNewPart = new DataTable("RQSTDT");
                                //UTIL.SetBizAddColumnToValue(dtNewPart, "PLT_CODE", ConnInfo.PLT_CODE, typeof(string));
                                //UTIL.SetBizAddColumnToValue(dtNewPart, "PART_CODE", "P-" + row["PROD_CODE"].ToString(), typeof(string));
                                //UTIL.SetBizAddColumnToValue(dtNewPart, "PART_NAME", row["PROD_NAME"], typeof(string));
                                //UTIL.SetBizAddColumnToValue(dtNewPart, "INS_FLAG", "0", typeof(string));
                                //UTIL.SetBizAddColumnToValue(dtNewPart, "MAT_LTYPE", "0", typeof(string));
                                //UTIL.SetBizAddColumnToValue(dtNewPart, "SAFE_STK_QTY", 0, typeof(int));


                                //DataTable dtExistPart = DLSE.LSE_STD_PART.LSE_STD_PART_SER5(dtNewPart, bizExecute);

                                //if (dtExistPart.Rows.Count == 0)
                                //    DLSE.LSE_STD_PART.LSE_STD_PART_INS(dtNewPart, bizExecute);

                            }
                        }
                        //덮어쓰기 여부
                        else
                        {                            
                            throw UTIL.SetException("동일 데이터가 존재합니다."
                                , new System.Diagnostics.StackFrame().GetMethod().Name);                            
                        }
                    }
                    else
                    {
                        //string item_code = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "ITEM", UTIL.emSerialFormat.YYYYMMDD, "-", bizExecute);

                        //row["ITEM_CODE"] = item_code;

                        //DORD.TORD_ITEM.TORD_ITEM_INS(UTIL.GetRowToDt(row), bizExecute);

                        string prod_code = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "PROD", UTIL.emSerialFormat.YYYYMMDD, "-", bizExecute);

                        row["PROD_CODE"] = prod_code;

                        row["DEV_EMP"] = row["SEND_DEV_EMP1"];

                        DORD.TORD_PRODUCT.TORD_PRODUCT_INS(UTIL.GetRowToDt(row), bizExecute);

                        if (row["ITEM_FLAG"].ToString() == "3")
                        {
                            DataTable asTable = new DataTable("RQSTDT");
                            asTable.Columns.Add("PLT_CODE", typeof(String));
                            asTable.Columns.Add("PROD_CODE", typeof(String));
                            asTable.Columns.Add("AS_NO", typeof(String));
                            asTable.Columns.Add("AS_EMP", typeof(String));
                            asTable.Columns.Add("ACCEPT_DATE", typeof(String));
                            asTable.Columns.Add("PROD_NAME", typeof(String));
                            asTable.Columns.Add("CUSTOMER_EMP", typeof(String));
                            asTable.Columns.Add("CVND_CODE", typeof(String));

                            DataRow newRow = asTable.NewRow();
                            newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                            string serial_code = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "AS", UTIL.emSerialFormat.YYYYMMDD, "-", bizExecute);
                            newRow["AS_NO"] = serial_code;
                            newRow["PROD_CODE"] = row["PROD_CODE"];
                            newRow["AS_EMP"] = row["BUSINESS_EMP"];
                            newRow["ACCEPT_DATE"] = DateTime.Now.toDateString("yyyyMMdd");
                            newRow["PROD_NAME"] = row["PROD_NAME"];
                            newRow["CUSTOMER_EMP"] = row["CUSTOMER_EMP"];
                            newRow["CVND_CODE"] = row["CVND_CODE"];
                            asTable.Rows.Add(newRow);

                            DORD.TORD_PRODUCT_AS.TORD_PRODUCT_AS_INS2(asTable, bizExecute);
                        }
                        
                        //DataTable dtNewPart = new DataTable("RQSTDT");
                        
                        //UTIL.SetBizAddColumnToValue(dtNewPart, "PLT_CODE", ConnInfo.PLT_CODE, typeof(string));
                        //UTIL.SetBizAddColumnToValue(dtNewPart, "PART_CODE", "P-" + prod_code, typeof(string));
                        //UTIL.SetBizAddColumnToValue(dtNewPart, "PART_NAME", row["PROD_NAME"], typeof(string));
                        //UTIL.SetBizAddColumnToValue(dtNewPart, "MAT_LTYPE", "0", typeof(string));
                        //UTIL.SetBizAddColumnToValue(dtNewPart, "INS_FLAG", "0", typeof(string));
                        //UTIL.SetBizAddColumnToValue(dtNewPart, "SAFE_STK_QTY", 0, typeof(int));


                        //DataTable dtExistPart = DLSE.LSE_STD_PART.LSE_STD_PART_SER5(dtNewPart, bizExecute);

                        //if(dtExistPart.Rows.Count == 0)
                        //    DLSE.LSE_STD_PART.LSE_STD_PART_INS(dtNewPart, bizExecute);

                    }


                    //repeat 수주 bom 복사
                    if (row["PROD_FLAG"].Equals("RE"))
                    {

                        //구분이 제품인건만 BOM등록
                        //상품도 필요하다고 하면 자동 불출요청 로직 필요(확인필요)
                        if (row["PROD_KIND"].Equals("PD")
                            || row["PROD_KIND"].Equals("PE"))
                        {
                            DataTable dtExistBom = DORD.TORD_PRODUCT_QUERY.TORD_PRODUCT_QUERY1(UTIL.GetRowToDt(row), bizExecute);

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

                            
                            if (dtExistBom.Rows.Count > 0 && !dtExistBom.Rows[0]["BOM_FLAG"].Equals(1))
                            {
                                //Repeat인데 등록된 bom이 없으면 복사등록
                                SetCopyBom(row, dtCopyBom, bizExecute);

                                SetWorkOrderCreate(row, "RE", bizExecute);
                            }
                            else if (dtExistBom.Rows.Count > 0 && dtCopyBom.Rows.Count > 0)
                            {
                                //Repeat인데 편집된 bom이 있으면 수정
                                SetBom(row, dtCopyBom, dtDelBom, bizExecute);

                                SetWorkOrder(row, "RE", dttmpCopyBom, bizExecute);
                            }
                        }
                    }
                    else if (row["PROD_FLAG"].Equals("NE"))
                    {

                        if (row["PROD_KIND"].Equals("PD")
                            || row["PROD_KIND"].Equals("PE"))
                        {
                            DataTable dtExistBom = DORD.TORD_PRODUCT_QUERY.TORD_PRODUCT_QUERY1(UTIL.GetRowToDt(row), bizExecute);

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
                                SetBom(row, dtCopyBom, dtDelBom, bizExecute);

                                SetWorkOrder(row, "RE", dttmpCopyBom, bizExecute);
                            }
                        }
                    }


                }

                return ORD02A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        

        public static DataSet ORD02A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                
                DataTable dtRslt = DORD.TORD_PRODUCT_QUERY.TORD_PRODUCT_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.Columns.Add("SEL");
                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet ORD02A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));


                DataTable dtRslt_bom = DMAT.TMAT_PARTLIST_QUERY.TMAT_PARTLIST_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt_bom.Columns.Add("SEL");
                dtRslt_bom.TableName = "RSLTDT_BOM";

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "IS_WO_PART", "1", typeof(string));

                ///part list
                DataTable dtRslt = DMAT.TMAT_PARTLIST_QUERY.TMAT_PARTLIST_QUERY2_1(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt.Columns.Add("SEL");
                dtRslt.TableName = "RSLTDT";

                DataTable dtRslt_wo = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt_wo.Columns.Add("SEL");
                dtRslt_wo.TableName = "RSLTDT_WO";

                DataTable dtRslt_part = DMAT.TMAT_PARTLIST_QUERY.TMAT_PARTLIST_QUERY2_2(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt_part.Columns.Add("SEL");
                dtRslt_part.TableName = "RSLTDT_PART";

                paramDS.Tables.Add(dtRslt);
                paramDS.Tables.Add(dtRslt_wo);
                paramDS.Tables.Add(dtRslt_bom);
                paramDS.Tables.Add(dtRslt_part);

                return paramDS;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet ORD02A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_TYPE", "V", typeof(String));

                DataTable VenRslt = DORD.TORD_MODEL_QUERY.TORD_MODEL_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable dtRslt = new DataTable();

                if (VenRslt.Rows.Count == 1)
                {
                    UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "P_SCODE", VenRslt.Rows[0]["SCODE"].ToString(), typeof(String));

                    dtRslt = DORD.TORD_MODEL_QUERY.TORD_MODEL_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);
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

        public static DataSet ORD02A_SER4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DORD.TORD_MODEL_QUERY.TORD_MODEL_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet ORD02A_SER5(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSTD.TSTD_VENDOR_QUERY.TSTD_VENDOR_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet ORD02A_SER6(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "ORD02A", 1, typeof(Byte)); // 거래처 타입이 공통 or 매출인 것만 조회.

                DataTable dtRslt = DSTD.TSTD_VENDOR_QUERY.TSTD_VENDOR_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

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
        /// 복사할 BOM 조회
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet ORD02A_SER7(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt_bom = new DataTable();

                if (paramDS.Tables["RQSTDT"].Rows[0]["TYPE"].ToString() == "1")
                {
                    dtRslt_bom = DMAT.TMAT_PARTLIST_QUERY.TMAT_PARTLIST_QUERY5_2(paramDS.Tables["RQSTDT"], bizExecute); 
                }
                else
                {
                    dtRslt_bom = DMAT.TMAT_PARTLIST_QUERY.TMAT_PARTLIST_QUERY5(paramDS.Tables["RQSTDT"], bizExecute);
                }

                dtRslt_bom.Columns.Add("SEL");
                dtRslt_bom.Columns.Add("CHK_FLAG");
                dtRslt_bom.Columns.Add("SUM_QTY", typeof(int));
                UTIL.SetBizAddColumnToValue(dtRslt_bom, "CHK_FLAG", "0", typeof(string), true);

                //dtRslt_bom.Columns["ORD_QTY"].DataType = typeof(Double);

                if (dtRslt_bom.Columns["ORD_QTY"].DataType.Name != "double")
                {
                    DataTable dtClone = dtRslt_bom.Clone();
                    dtClone.Columns["ORD_QTY"].DataType = typeof(double);

                    foreach (DataRow row in dtRslt_bom.Rows)
                    {
                        dtClone.ImportRow(row);
                    }

                    if (dtClone.Rows.Count > 0)
                    {
                        dtRslt_bom = dtClone;
                    }
                }


                //dtRslt_bom.Columns.Add("ORD_QTY", typeof(int));
                dtRslt_bom.TableName = "RSLTDT_BOM";

                //DataTable dtRslt_AllBom = DMAT.TMAT_PARTLIST_QUERY.TMAT_PARTLIST_QUERY5(paramDS.Tables["RQSTDT"], bizExecute);
                //dtRslt_AllBom.Columns.Add("SEL");
                //dtRslt_AllBom.Columns.Add("CHK_FLAG");
                //UTIL.SetBizAddColumnToValue(dtRslt_AllBom, "CHK_FLAG", "0", typeof(string), true);
                ////dtRslt_AllBom.Columns.Add("ORD_QTY", typeof(int));
                //dtRslt_AllBom.TableName = "RSLTDT_ALL_BOM";

                paramDS.Tables.Add(dtRslt_bom);
                //paramDS.Tables.Add(dtRslt_AllBom);

                return paramDS;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet ORD02A_SER8(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt_bom = DMAT.TMAT_PARTLIST_QUERY.TMAT_PARTLIST_QUERY5_1(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt_bom.Columns.Add("SEL");
                dtRslt_bom.Columns.Add("CHK_FLAG");
                dtRslt_bom.Columns.Add("SUM_QTY", typeof(int));
                UTIL.SetBizAddColumnToValue(dtRslt_bom, "CHK_FLAG", "0", typeof(string), true);
                dtRslt_bom.TableName = "RSLTDT_BOM";

                paramDS.Tables.Add(dtRslt_bom);

                return paramDS;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        /// <summary>
        /// 수주상태 변경
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet ORD02A_UPD(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    IsLock(row, bizExecute);

                    DORD.TORD_PRODUCT.TORD_PRODUCT_UPD2(UTIL.GetRowToDt(row), bizExecute);
                }
                return ORD02A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 출하지시
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet ORD02A_UPD2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PROD_STATE", "10", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "SHIP_FLAG", "1", typeof(string));
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    IsLock(row, bizExecute);

                    DataTable dtProd = DORD.TORD_PRODUCT.TORD_PRODUCT_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (dtProd.Rows.Count > 0)
                    {
                        if (dtProd.Rows[0]["SHIP_FLAG"].ToString() != "1")
                        {
                            DORD.TORD_PRODUCT.TORD_PRODUCT_UPD3(UTIL.GetRowToDt(row), bizExecute);
                        }
                    }

                }
                return ORD02A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        /// <summary>
        /// 잠금
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet ORD02A_UPD3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtSer = DORD.TORD_PRODUCT.TORD_PRODUCT_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (dtSer.Rows[0]["LOCK_FLAG"].ToString() == "1")
                        throw UTIL.SetException("이미 잠금 처리 되었습니다."
                                  , new System.Diagnostics.StackFrame().GetMethod().Name
                                  , BizException.ABORT);

                    DORD.TORD_PRODUCT.TORD_PRODUCT_UPD4(UTIL.GetRowToDt(row), bizExecute);
                }

                return ORD02A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        /// <summary>
        /// 잠금해제
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet ORD02A_UPD4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtSer = DORD.TORD_PRODUCT.TORD_PRODUCT_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (dtSer.Rows.Count > 0 && dtSer.Rows[0]["LOCK_FLAG"].ToString() != "1")
                        throw UTIL.SetException("잠금 설정이 안된 데이터입니다."
                                  , new System.Diagnostics.StackFrame().GetMethod().Name
                                  , BizException.ABORT);

                    if (!row["LOCK_EMP"].Equals(dtSer.Rows[0]["LOCK_EMP"]))
                        throw UTIL.SetException("잠금자와 잠금해제자와 일치 하지 않습니다."
                                  , new System.Diagnostics.StackFrame().GetMethod().Name
                                  , BizException.ABORT);

                    DORD.TORD_PRODUCT.TORD_PRODUCT_UPD5(UTIL.GetRowToDt(row), bizExecute);
                }

                return ORD02A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 수주상태 변경(확정전용)
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet ORD02A_UPD7(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    IsLock(row, bizExecute);

                    DORD.TORD_PRODUCT.TORD_PRODUCT_UPD2_2(UTIL.GetRowToDt(row), bizExecute);

                    DORD.TORD_PRODUCT_CONFIRM_LOG.TORD_PRODUCT_CONFIRM_LOG_INS(UTIL.GetRowToDt(row), bizExecute);

                    DataTable prod = DORD.TORD_PRODUCT_QUERY.TORD_PRODUCT_QUERY30(UTIL.GetRowToDt(row), bizExecute);

                    if (prod.Rows.Count > 0)
                    {
                        if (row["SEND_DEV_EMP1"].ToString() != "")
                        {
                            sendDev(prod.Rows[0], row["SEND_DEV_EMP1"].ToString(), bizExecute);
                        }

                        if (row["SEND_DEV_EMP2"].ToString() != "")
                        {
                            sendDev(prod.Rows[0], row["SEND_DEV_EMP2"].ToString(), bizExecute);
                        }
                    }
                }
                return ORD02A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        static void sendDev(DataRow row , string empCode, BizExecute.BizExecute bizExecute)
        {
            DataTable dt = new DataTable("RQSTDT");
            dt.Columns.Add("PLT_CODE", typeof(string));
            dt.Columns.Add("SEND_NO", typeof(string));
            dt.Columns.Add("EMP_CODE", typeof(string));
            dt.Columns.Add("PROD_CODE", typeof(string));
            dt.Columns.Add("PROD_NAME", typeof(string));
            dt.Columns.Add("PROD_FLAG", typeof(string));
            dt.Columns.Add("PROD_TYPE", typeof(string));
            dt.Columns.Add("CUSTDESIGN_EMP", typeof(string));
            dt.Columns.Add("BUSINESS_EMP", typeof(string));
            dt.Columns.Add("CVND_NAME", typeof(string));
            dt.Columns.Add("PROD_QTY", typeof(int));

            DataRow newRow = dt.NewRow();
            newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
            newRow["SEND_NO"] = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "PSD", UTIL.emSerialFormat.YYYYMMDD, "", bizExecute);
            newRow["EMP_CODE"] = empCode;
            newRow["PROD_CODE"] = row["PROD_CODE"];
            newRow["PROD_NAME"] = row["PROD_NAME"];
            newRow["PROD_FLAG"] = row["PROD_FLAG"];
            newRow["PROD_TYPE"] = row["PROD_TYPE"];
            newRow["CUSTDESIGN_EMP"] = row["CUSTDESIGN_EMP"];
            newRow["BUSINESS_EMP"] = row["BUSINESS_EMP"];
            newRow["CVND_NAME"] = row["CVND_NAME"];
            newRow["PROD_QTY"] = row["PROD_QTY"];
            dt.Rows.Add(newRow);

            DORD.TORD_PRODUCT_SEND_DEV.TORD_PRODUCT_SEND_DEV_INS(dt, bizExecute);
        }


        /// <summary>
        /// 영업기밀사항 업데이트
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet ORD02A_UPD6(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DORD.TORD_PRODUCT.TORD_PRODUCT_UPD15(UTIL.GetRowToDt(row), bizExecute);
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }



        public static DataSet ORD02A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 2, typeof(Byte));
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "SEARCH_DATA_FLAG", 0, typeof(Byte));

                //DataTable dtNow = UTIL.UTILITY_GET_DTNOW(bizExecute);
                //string dt = ((DateTime)dtNow.Rows[0]["NOW_DT"]).ToString("yyyy-MM-dd HH:mm:ss");


                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    IsLock(row,bizExecute);
                    
                    DataTable dtRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY37(UTIL.GetRowToDt(row), bizExecute);

                    if (dtRslt.Rows.Count > 0)
                    {
                        throw UTIL.SetException("실적내역이 존재하는 수주는 삭제할 수 없습니다."
                              , new System.Diagnostics.StackFrame().GetMethod().Name
                              , 200203);
                    }

                    else
                    {
                        row["DATA_FLAG"] = "2";
                        DORD.TORD_PRODUCT.TORD_PRODUCT_UDE(UTIL.GetRowToDt(row), bizExecute);
                    }

                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }

        }

        public static DataSet ORD02A_VEN_CHARGE(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));


                DataTable dtRslt = DSTD.TSTD_VENDOR_CHARGE_QUERY.TSTD_VENDOR_CHARGE_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);
                dtRslt.Columns.Add("SEL");
                dtRslt.TableName = "RSLTDT";


                paramDS.Tables.Add(dtRslt);


                return paramDS;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }



        public static DataSet ORD02A_MODEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(byte));

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_TYPE", "T", typeof(string));

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "USE_FLAG", "1", typeof(string));

                DataTable dtRslt = DORD.TORD_MODEL_QUERY.TORD_MODEL_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.Columns.Add("SEL");

                dtRslt.TableName = "RSLTDT_T";


                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_TYPE", "M", typeof(string));

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "USE_FLAG", "1", typeof(string));

                DataTable dtRslt2 = DORD.TORD_MODEL_QUERY.TORD_MODEL_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt2.Columns.Add("SEL");

                dtRslt2.TableName = "RSLTDT_M";


                paramDS.Tables.Add(dtRslt);
                paramDS.Tables.Add(dtRslt2);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 부품리스트 등록(BOM등록 - Excel)
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet ORD02A_INS2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if(paramDS.Tables["RQSTDT"].Rows.Count == 0)
                    throw UTIL.SetException("BOM데이터가 없습니다."
                              , new System.Diagnostics.StackFrame().GetMethod().Name
                              , BizException.ABORT);

                DataTable prodDT = DORD.TORD_PRODUCT.TORD_PRODUCT_SER(UTIL.GetRowToDt(paramDS.Tables["RQSTDT"].Rows[0]), bizExecute);

                DataTable partlistDT = DMAT.TMAT_PARTLIST.TMAT_PARTLIST_SER5(UTIL.GetRowToDt(paramDS.Tables["RQSTDT"].Rows[0]), bizExecute);

                if (prodDT.Rows.Count > 0 && partlistDT.Rows.Count > 0)
                {
                    DataRow[] rows = paramDS.Tables["RQSTDT"].Select("PART_CODE = '" + partlistDT.Rows[0]["PART_CODE"].ToString() + "'");

                    if (rows.Length == 0)
                    {
                        if (prodDT.Rows[0]["ASSY_CHG_FLAG"].ToString() == "1")
                        {
                            DMAT.TMAT_PARTLIST.TMAT_PARTLIST_UDE2(UTIL.GetRowToDt(paramDS.Tables["RQSTDT"].Rows[0]), bizExecute);
                            DSHP.TSHP_WORKORDER.TSHP_WORKORDER_DEL2(UTIL.GetRowToDt(paramDS.Tables["RQSTDT"].Rows[0]), bizExecute);
                            DMAT.TMAT_OUT_REQ.TMAT_OUT_REQ_DEL(UTIL.GetRowToDt(paramDS.Tables["RQSTDT"].Rows[0]), bizExecute);
                        }
                        else
                        {
                            throw UTIL.SetException(string.Format("기존 조립품과 다른 조립품입니다.")
                                        , new System.Diagnostics.StackFrame().GetMethod().Name
                                        , BizException.ABORT);
                        }
                    }
                }


                

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PREV_PART_CODE", "", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PART_CODE_SUBSTRING", "", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "O_PART_QTY", 1, typeof(int));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "IS_ORD", 0, typeof(byte));

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "O_PART_CODE_SUBSTRING", "", typeof(string));

                

                string sProdType = "1";
                DataTable prodType = null;
                if (prodDT.Rows.Count > 0)
                {
                    DataTable dtSer = new DataTable("RQSTDT");
                    UTIL.SetBizAddColumnToValue(dtSer, "PLT_CODE", ConnInfo.PLT_CODE, typeof(string));
                    UTIL.SetBizAddColumnToValue(dtSer, "CD_CODE", prodDT.Rows[0]["PROD_TYPE"], typeof(string));
                    UTIL.SetBizAddColumnToValue(dtSer, "CAT_CODE", "P010", typeof(string));

                    prodType = DSTD.TSTD_CODES.TSTD_CODES_SER(dtSer, bizExecute);
                }

                if (prodType != null)
                {
                    if (prodType.Rows.Count > 0)
                    {
                        sProdType = prodType.Rows[0]["CD_PARENT"].ToString();
                    }
                }

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "O_PART_ID", "1", typeof(string));

                DataRow[] assyRows = paramDS.Tables["RQSTDT"].Select("SUBSTRING(PART_CODE, 1, 1) = 'A' AND ISNULL(P_PART_CODE,'') = ''");


                //Dictionary<string, int> partDic = new Dictionary<string, int>();
                //foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                //{
                //    if (!partDic.ContainsKey(row["PART_CODE"].ToString()))
                //    {
                //        partDic.Add(row["PART_CODE"].ToString(), 0);
                //    }
                //    else
                //    {
                //        if (partDic[row["PART_CODE"].ToString()] == 0)
                //        {
                //            partDic[row["PART_CODE"].ToString()] = 1;

                //            DataRow[] rows = paramDS.Tables["RQSTDT"].Select("P_PART_CODE = '" + row["PART_CODE"].ToString() + "'");

                //            if (rows.Length > 1)
                //            {
                //                DataRow[] pRows = paramDS.Tables["RQSTDT"].Select("PART_CODE = '" + row["PART_CODE"].ToString() + "'");

                //                int idx = 1;
                //                foreach (DataRow rw in pRows)
                //                {
                //                    rw["O_PART_ID"] = idx.ToString();
                //                    idx++;
                //                }

                //                setOpartID(paramDS, row["PART_CODE"].ToString());

                //            }
                //        }
                //    }
                //}

                
                if (assyRows.Length > 0)
                {
                    //setOpartID(paramDS, assyRows[0]["PART_CODE"].ToString());
                }

                Dictionary<string, int> partDic = new Dictionary<string, int>();
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    if (!partDic.ContainsKey(row["P_PART_CODE"].ToString() + "_" + row["PART_CODE"].ToString()))
                    {
                        partDic.Add(row["P_PART_CODE"].ToString() + "_" + row["PART_CODE"].ToString(), 1);
                    }
                    else
                    {
                        DataRow[] rows = paramDS.Tables["RQSTDT"].Select("P_PART_CODE = '" + row["P_PART_CODE"].ToString() + "' AND PART_CODE = '" + row["PART_CODE"].ToString() + "'");

                        int idx = 1;
                        foreach (DataRow rw in rows)
                        {
                            rw["O_PART_ID"] = idx.ToString();
                            idx++;
                        }
                    }
                }


                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    double o_qty = 1;
                    double sum_o_qty = 1;

                    double ordQty = 1;
                    double sum_ordQty = 1;

                    string find_o_ptid = "";
                    string find_ptid = "";

                    find_o_ptid = row["P_PART_CODE"].ToString();
                    find_ptid = row["PART_CODE"].ToString();

                    bool isOrd = false;

                    int idx = 0;

                    while (true)
                    {
                        if (find_o_ptid == "")
                        {
                            break;
                        }

                        DataRow[] rows = paramDS.Tables["RQSTDT"].Select("PART_CODE = '" + find_o_ptid + "'");

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

                            find_o_ptid = rows[0]["P_PART_CODE"].ToString();

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
                        row["PART_QTY"] = 1;
                    }

                    row["O_PART_QTY"] = sum_o_qty;

                    row["PART_CODE_SUBSTRING"] = row["PART_CODE"].ToString().Substring(0, 1);
                    //대표자재 품목명으로 찾아서 변경
                    //없으면 해당 품목이 메인품목이됨
                    if (row["PART_CODE_SUBSTRING"].ToString() != "M")
                    {
                        if (row["PART_CODE_SUBSTRING"].ToString() != "A")
                        {
                            DataTable dtExistStdPart = DLSE.LSE_STD_PART.LSE_STD_PART_SER5(UTIL.GetRowToDt(row), bizExecute);

                            if (dtExistStdPart.Rows.Count > 0)
                            {
                                if (dtExistStdPart.Rows[0]["MAT_LTYPE"].ToString() == "22"
                                    || dtExistStdPart.Rows[0]["MAT_LTYPE"].ToString() == "4")
                                {
                                    DataRow[] rows = paramDS.Tables["RQSTDT"].Select("P_PART_CODE = '" + row["PART_CODE"].ToString() + "'");

                                    row["PREV_PART_CODE"] = row["PART_CODE"];
                                    row["PART_CODE"] = dtExistStdPart.Rows[0]["PART_CODE"];

                                    row["MAT_LTYPE"] = dtExistStdPart.Rows[0]["MAT_LTYPE"];
                                    row["MAT_MTYPE"] = dtExistStdPart.Rows[0]["MAT_MTYPE"];
                                    row["MAT_STYPE"] = dtExistStdPart.Rows[0]["MAT_STYPE"];

                                    foreach (DataRow rw in rows)
                                    {
                                        rw["P_PART_CODE"] = row["PART_CODE"];
                                    }
                                }
                            }
                            else
                            {
                                if (row["MAT_LTYPE"].ToString() == "22"
                                    || row["MAT_LTYPE"].ToString() == "4")
                                {
                                    DataTable partTable = new DataTable("RQSTDT");
                                    partTable.Columns.Add("PLT_CODE", typeof(String));
                                    partTable.Columns.Add("PART_CODE", typeof(String));
                                    partTable.Columns.Add("IS_MAIN_PART", typeof(Byte));

                                    DataRow partRow = partTable.NewRow();
                                    partRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                                    partRow["PART_CODE"] = row["PART_CODE"];
                                    partRow["IS_MAIN_PART"] = 1;
                                    partTable.Rows.Add(partRow);

                                    DLSE.LSE_STD_PART.LSE_STD_PART_UPD19(partTable, bizExecute);
                                }
                            }
                        }
                    }
                }

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PT_ID", "", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PT_NO", "", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "O_PT_ID", "", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "INS_FLAG", "0", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "SAFE_STK_QTY", 0, typeof(int));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PT_NAME","PART_NAME");
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WO_PART", "0", typeof(string));
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "MAT_LTYPE", null, typeof(string));

                //foreach (DataRow row in paramDS.Tables["RQSTDT"].Select("ISNULL(P_PART_CODE,'') = ''"))
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DataTable dtExistStdPart = DLSE.LSE_STD_PART.LSE_STD_PART_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (dtExistStdPart.Rows.Count == 0)
                    {
                        if (row["MAT_LTYPE"].isNullOrEmpty())
                        {
                            switch (row["PART_CODE"].ToString().Substring(0, 1))
                            {
                                case "M":
                                    row["MAT_LTYPE"] = "33";
                                    break;
                                case "E"://사출품
                                    row["MAT_LTYPE"] = "1";
                                    break;
                                case "O"://구매품 -- 원재료
                                    row["MAT_LTYPE"] = "22";
                                    break;
                                case "A"://완제품
                                    row["MAT_LTYPE"] = "11";
                                    break;
                            }
                        }
                        //DLSE.LSE_STD_PART.LSE_STD_PART_INS(UTIL.GetRowToDt(row), bizExecute);
                    }
                    else
                    {
                        if (row["MAT_LTYPE"].isNullOrEmpty()) row["MAT_LTYPE"] = dtExistStdPart.Rows[0]["MAT_LTYPE"];
                        if (row["MAT_MTYPE"].isNullOrEmpty()) row["MAT_MTYPE"] = dtExistStdPart.Rows[0]["MAT_MTYPE"];
                        if (row["MAT_STYPE"].isNullOrEmpty()) row["MAT_STYPE"] = dtExistStdPart.Rows[0]["MAT_STYPE"];
                    }

                    string pt_id = row["PROD_CODE"].ToString() + (row["P_PART_CODE"].isNullOrEmpty() ? "" : "_" + row["P_PART_CODE"].ToString()) + "_" + row["PART_CODE"].ToString() + "_" + row["O_PART_ID"].ToString();

                    string pt_no = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "PT", UTIL.emSerialFormat.YYYYMMDD,"", bizExecute);


                    DataRow[] exsitPartRows = paramDS.Tables["RQSTDT"].Select(string.Format("PT_ID = '{0}' ", pt_id));
                    if(exsitPartRows.Length > 0)
                    {
                        throw UTIL.SetException(string.Format("동일한 BOM품목이 존재 합니다.다시 확인하여 주십시오." +
                                                                "\r\n<모품목:{0},자품목:{1}>", row["P_PART_CODE"], row["PART_CODE"])
                                                                , row["PT_ID"].toStringEmpty()
                                                                , new System.Diagnostics.StackFrame().GetMethod().Name
                                                                , BizException.ABORT, row);
                    }

                    row["PT_ID"] = pt_id;

                    row["PT_NO"] = pt_no;


                    DataRow[] c_rows = paramDS.Tables["RQSTDT"].Select(string.Format("P_PART_CODE = '{0}' ", row["PART_CODE"]));

                    int child_wo_part_cnt = 0;

                    foreach (DataRow c_row in c_rows)
                    {
                        //p_row["O_PT_ID"] = pt_id;
                        //if (p_row["PART_CODE"].ToString().Substring(0, 1) == "M")
                        //    child_wo_part_cnt++;
                        child_wo_part_cnt++;
                    }

                    DataRow[] p_rows = paramDS.Tables["RQSTDT"].Select(string.Format("PART_CODE = '{0}' ", row["P_PART_CODE"]));

                    int pidx = 1;
                    foreach (DataRow p_row in p_rows)
                    {
                        if (pidx == row["O_PART_iD"].toInt())
                        {
                            row["O_PT_ID"] = p_row["PROD_CODE"].ToString() + (p_row["P_PART_CODE"].isNullOrEmpty() ? "" : "_" + p_row["P_PART_CODE"].ToString()) + "_" + p_row["PART_CODE"].ToString() + "_" + p_row["O_PART_ID"].ToString();
                        }

                        pidx++;
                    }

                    if (p_rows.Length > 0)
                    {
                        if (row["O_PT_ID"].ToString() == "")
                        {
                            row["O_PT_ID"] = p_rows[0]["PROD_CODE"].ToString() + (p_rows[0]["P_PART_CODE"].isNullOrEmpty() ? "" : "_" + p_rows[0]["P_PART_CODE"].ToString()) + "_" + p_rows[0]["PART_CODE"].ToString() + "_" + p_rows[0]["O_PART_ID"].ToString();
                        }
                    }


                    if (row["PART_CODE"].ToString().Substring(0, 1) == "M" && row["MAT_LTYPE"].ToString() == "33" && child_wo_part_cnt == 0)
                    {
                        row["WO_PART"] = "1";
                    }
                    else if (row["PART_CODE"].ToString().Substring(0, 1) == "A" && row["P_PART_CODE"].ToString() == "")
                    {
                        row["WO_PART"] = "1";
                    }

                    if (row["PART_CODE"].ToString().Substring(0, 1) == "M" && row["MAT_LTYPE"].ToString() == "33" && child_wo_part_cnt > 0)
                    {
                        row["MAT_LTYPE"] = "44";
                    }


                    if (dtExistStdPart.Rows.Count == 0)
                    {
                        DLSE.LSE_STD_PART.LSE_STD_PART_INS(UTIL.GetRowToDt(row), bizExecute);
                    }
                    else
                    {
                        if (row["TAB_MACHINE"].ToString() == "")
                        {
                            row["TAB_MACHINE"] = dtExistStdPart.Rows[0]["TAB_MACHINE"];
                        }

                        if (row["MakeSideHole"].ToString() == "")
                        {
                            row["MakeSideHole"] = dtExistStdPart.Rows[0]["MakeSideHole"];
                        }

                        //if (row["도금"].ToString() == "")
                        //{
                        //    row["도금"] = dtExistStdPart.Rows[0]["도금"];
                        //}

                        if (row["Slit_Division"].ToString() == "")
                        {
                            row["Slit_Division"] = dtExistStdPart.Rows[0]["Slit_Division"];
                        }

                        if (row["SAFE_STK_QTY"].ToString() == "")
                        {
                            row["SAFE_STK_QTY"] = dtExistStdPart.Rows[0]["SAFE_STK_QTY"];
                        }

                        if (row["MAT_QLTY"].ToString() == "")
                        {
                            row["MAT_QLTY"] = dtExistStdPart.Rows[0]["MAT_QLTY"];
                        }

                        if (row["AFTER_TREAT"].ToString() == "")
                        {
                            row["AFTER_TREAT"] = dtExistStdPart.Rows[0]["AFTER_TREAT"];
                        }

                        DLSE.LSE_STD_PART.LSE_STD_PART_UPD18(UTIL.GetRowToDt(row), bizExecute);
                    }
                }

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "Material", "MAT_QLTY");

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    if (row["MAT_MTYPE"].ToString() == "21"
                        || row["MAT_MTYPE"].ToString() == "23")
                    {
                        DataRow[] p_rows = paramDS.Tables["RQSTDT"].Select(string.Format("P_PART_CODE = '{0}' ", row["PART_CODE"]));

                        int child_mat_cnt = 0;

                        if (row["MAT_MTYPE"].ToString() == "23")
                        {
                            foreach (DataRow p_row in p_rows)
                            {
                                child_mat_cnt++;
                            }
                        }

                        if (child_mat_cnt == 0)
                        {
                            DataTable dtOutReq = DMAT.TMAT_OUT_REQ.TMAT_OUT_REQ_SER(UTIL.GetRowToDt(row), bizExecute);

                            if (dtOutReq.Rows.Count == 0)
                            {
                                DataTable dtProd = DORD.TORD_PRODUCT.TORD_PRODUCT_SER(UTIL.GetRowToDt(row), bizExecute);

                                if (dtProd.Rows.Count != 0)
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
                                    outReqTable.Columns.Add("DATA_FLAG", typeof(byte));

                                    double prodQty = dtProd.Rows[0]["PROD_QTY"].toDouble();
                                    double ordQty = row["ORD_QTY"].toDouble();

                                    int reqQty = (prodQty * row["PART_QTY"].toDouble() * row["O_PART_QTY"].toDouble()).toInt();

                                    if (ordQty > 0)
                                    {
                                        reqQty = (row["PART_QTY"].toDouble() * ordQty * row["O_PART_QTY"].toDouble()).toInt();
                                    }

                                    DataRow outReqRow = outReqTable.NewRow();
                                    outReqRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                                    outReqRow["OUT_REQ_ID"] = OUT_REQ_ID;
                                    outReqRow["PT_ID"] = row["PT_ID"];
                                    outReqRow["PART_CODE"] = row["PART_CODE"];
                                    outReqRow["OUT_REQ_DATE"] = DateTime.Now.toDateString("yyyyMMdd");
                                    outReqRow["OUT_REQ_EMP"] = "system";
                                    outReqRow["OUT_REQ_QTY"] = reqQty;
                                    outReqRow["OUT_REQ_STAT"] = "50";
                                    outReqRow["OUT_REQ_LOC"] = "ASY";
                                    outReqRow["DATA_FLAG"] = 0;
                                    outReqTable.Rows.Add(outReqRow);

                                    DMAT.TMAT_OUT_REQ.TMAT_OUT_REQ_INS(outReqTable, bizExecute);
                                }


                            }
                        }
                    }

                    DataTable dtExistPartList = DMAT.TMAT_PARTLIST.TMAT_PARTLIST_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (dtExistPartList.Rows.Count > 0)
                    {
                        DMAT.TMAT_PARTLIST.TMAT_PARTLIST_UPD(UTIL.GetRowToDt(row), bizExecute);
                    }
                    else
                    {
                        DMAT.TMAT_PARTLIST.TMAT_PARTLIST_INS(UTIL.GetRowToDt(row), bizExecute);
                    }
                }

                SetWorkOrderCreate(paramDS.Tables["RQSTDT"].Rows[0], "NE", bizExecute);

                DataTable prodTable = new DataTable("RQSTDT");
                prodTable.Columns.Add("PLT_CODE", typeof(String));
                prodTable.Columns.Add("PROD_CODE", typeof(String));
                prodTable.Columns.Add("DES_DATE", typeof(String));

                DataRow prodRow = prodTable.NewRow();
                prodRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                prodRow["PROD_CODE"] = paramDS.Tables["RQSTDT"].Rows[0]["PROD_CODE"];
                prodRow["DES_DATE"] = DateTime.Now.toDateString("yyyyMMdd");
                prodTable.Rows.Add(prodRow);

                DORD.TORD_PRODUCT.TORD_PRODUCT_UPD10(prodTable, bizExecute);

                #region 주석
                //foreach (DataRow row in paramDS.Tables["RQSTDT"].Select("ISNULL(P_PART_CODE,'') <> ''"))
                //{

                //    DataTable dtExistStdPart = DLSE.LSE_STD_PART.LSE_STD_PART_SER(UTIL.GetRowToDt(row), bizExecute);

                //    if (dtExistStdPart.Rows.Count == 0)
                //        DLSE.LSE_STD_PART.LSE_STD_PART_INS(UTIL.GetRowToDt(row), bizExecute);

                //    string pt_id = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "PT", UTIL.emSerialFormat.YYYYMMDD, "", bizExecute);

                //    row["PT_ID"] = pt_id;

                //    DataRow[] p_rows = paramDS.Tables["RQSTDT"].Select(string.Format("PART_CODE = '{0}'",row["P_PART_CODE"]));
                //    if(p_rows.Length > 0)
                //        row["O_PT_ID"] = p_rows[0]["PT_ID"];

                //    DMAT.TMAT_PARTLIST.TMAT_PARTLIST_INS(UTIL.GetRowToDt(row), bizExecute);

                //}
                #endregion

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        private static void setOpartID(DataSet paramSet, string part_code)
        {

            DataRow[] rows = paramSet.Tables["RQSTDT"].Select("P_PART_CODE = '" + part_code + "'");

            if (rows.Length > 1)
            {
                //int idx = 0;
                Dictionary<string, int> partDic = new Dictionary<string, int>();
                foreach (DataRow rw in rows)
                {
                    if (rw["O_PART_ID"].ToString() != "0") continue;

                    if (!partDic.ContainsKey(rw["PART_CODE"].ToString()))
                    {
                        partDic.Add(rw["PART_CODE"].ToString(), 1);
                    }
                    else
                    {
                        partDic[rw["PART_CODE"].ToString()] = partDic[rw["PART_CODE"].ToString()] + 1;
                    }

                    rw["O_PART_ID"] = partDic[rw["PART_CODE"].ToString()].ToString();

                    if (partDic[rw["PART_CODE"].ToString()] == 1)
                    {
                        setOpartID(paramSet, rw["PART_CODE"].ToString());
                    }
                }
            }
            else if (rows.Length == 1)
            {
                rows[0]["O_PART_ID"] = "1";
            }

            //foreach (DataRow row in paramSet.Tables["RQSTDT"].Rows)
            //{
            //    DataRow[] rows = paramSet.Tables["RQSTDT"].Select("PART_CODE = '" + row["PART_CODE"].ToString() + "'");

            //    if (rows.Length > 1)
            //    {
            //        int idx = 1;
            //        foreach (DataRow rw in rows)
            //        {
            //            if (rw["O_PART_ID"].ToString() != "")
            //            {
            //                rw["O_PART_ID"] = idx.ToString();
            //                idx++;
            //            }
            //        }

            //        setOpartID(paramSet)
            //    }
            //    else if (rows.Length == 1)
            //    {
            //        row["O_PART_ID"] = "0";
            //    }
            //}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row">수주정보</param>
        /// <param name="bizExecute"></param>
        private static void SetWorkOrderCreate(DataRow row, string type, BizExecute.BizExecute bizExecute)
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
            UTIL.SetBizAddColumnToValue(dtParam, "IS_COPY_SIDE", 0, typeof(byte));
            UTIL.SetBizAddColumnToValue(dtParam, "IS_SIDE", 0, typeof(byte));
            

            DataTable dtPartList = DMAT.TMAT_PARTLIST_QUERY.TMAT_PARTLIST_QUERY2(dtParam, bizExecute);

            //휴일조회
            DataTable dtHoliDay = DLSE.LSE_HOLIDAY_QUERY.LSE_HOLIDAY_QUERY1(dtParam, bizExecute);

            DataTable dtNow = UTIL.UTILITY_GET_DTNOW(bizExecute);
            int part_id = 0;
            foreach(DataRow part_row in dtPartList.Rows)
            {
                DataTable dtSer = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER3(UTIL.GetRowToDt(part_row), bizExecute);
                
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

                dtParam.Rows[0]["IS_COPY_SIDE"] = part_row["IS_COPY_SIDE"];
                dtParam.Rows[0]["IS_SIDE"] = part_row["IS_SIDE"];
                DataTable dtProc = DSTD.TSTD_ROUTING.TSTD_ROUTING_SER2(dtParam, bizExecute);

                if (part_row["IS_COPY_SIDE"].ToString() == "1")
                {
                    if (part_row["IS_SIDE"].ToString() == "0")
                    {
                        DataRow[] rows = dtProc.Select("PROC_CODE = 'P-07'");

                        if (rows.Length > 0)
                        {
                            dtProc.Rows.Remove(rows[0]);
                        }
                    }
                }


                int proc_id = 0;

                if (part_row["ORD_QTY"].toDouble() > 0)
                {
                    part_row["PART_QTY"] = (part_row["PART_QTY"].toDouble() * part_row["O_PART_QTY"].toDouble() * part_row["ORD_QTY"].toDouble()).toInt();
                }
                else
                {
                    part_row["PART_QTY"] = (part_row["PART_QTY"].toDouble() * part_row["O_PART_QTY"].toDouble() * part_row["PROD_QTY"].toDouble()).toInt();
                }

                string RE_WO_NO = "";
                string RE_WO_FLAG = "4";
                string PREV_CHAIN_WO_NO = "";
                string OLD_RE_WO = "";
                string IS_PREV_CHAIN = "";

                foreach (DataRow proc_row in dtProc.Rows)
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


                    if (row.Table.Columns.Contains("OLD_PROD_CODE"))
                    {
                        DataTable paramCamTable = new DataTable("RQSTDT");
                        paramCamTable.Columns.Add("PLT_CODE", typeof(string));
                        paramCamTable.Columns.Add("PROD_CODE", typeof(string));
                        paramCamTable.Columns.Add("PART_CODE", typeof(string));
                        paramCamTable.Columns.Add("PROC_CODE", typeof(string));

                        DataRow paramCamRow = paramCamTable.NewRow();
                        paramCamRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                        paramCamRow["PROD_CODE"] = row["OLD_PROD_CODE"];
                        paramCamRow["PART_CODE"] = part_row["PART_CODE"];
                        paramCamRow["PROC_CODE"] = proc_row["PROC_CODE"];

                        paramCamTable.Rows.Add(paramCamRow);

                        DataTable dtCAMSer = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER11(paramCamTable, bizExecute);

                        if (dtCAMSer.Rows.Count > 0)
                        {
                            UTIL.SetBizAddColumnToValue(dtRow, "CAM_EMP", dtCAMSer.Rows[0]["CAM_EMP"].ToString(), typeof(string));
                        }
                    }

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

                    if (wo_type == "DES")
                    {
                        UTIL.SetBizAddColumnToValue(dtRow, "ACT_QTY", "PART_QTY");
                    }

                    //작지가 있으면 UPDATE, 있으면 INSERT
                    DataTable woRslt = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER24(dtRow, bizExecute);

                    DataTable revisionDT = DMAT.TMAT_PARTLIST.TMAT_PARTLIST_SER_(dtRow, bizExecute);

                    int isRev = 0;
                    int isMct = 0;
                    int isMdf = 0;

                    if (revisionDT.Rows.Count > 0)
                    {
                        isRev = revisionDT.Rows[0]["IS_REVISION"].toInt();
                        isMct = revisionDT.Rows[0]["IS_REMCT"].toInt();
                        isMdf = revisionDT.Rows[0]["IS_MODIFY"].toInt();
                    }


                    if (isRev == 1)
                    {
                        if (RE_WO_NO == "")
                        {
                            DataTable woDt = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER25(dtRow, bizExecute);

                            if (woDt.Rows.Count == 0)
                            {
                                woDt = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER25_2(dtRow, bizExecute);
                            }
                            else
                            {
                                RE_WO_FLAG = woDt.Rows[0]["WO_FLAG"].ToString();
                            }

                            if (woDt.Rows.Count > 0)
                            {
                                PREV_CHAIN_WO_NO = woDt.Rows[0]["CHAIN_WO_NO"].ToString();
                                OLD_RE_WO = woDt.Rows[0]["RE_WO_NO"].ToString();
                            }
                        }


                        if (RE_WO_FLAG == "4" && isRev == 1)
                        {
                            if (dtRow.Rows[0]["PROC_CODE"].ToString() == "P-02")
                            {
                                DataTable prevCamEmp = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER11_2(dtRow, bizExecute);

                                if (prevCamEmp.Rows.Count > 0)
                                {
                                    UTIL.SetBizAddColumnToValue(dtRow, "CAM_EMP", prevCamEmp.Rows[0]["CAM_EMP"].ToString(), typeof(string));
                                    UTIL.SetBizAddColumnToValue(dtRow, "CAM_EMP_DATE", DateTime.Now.ToString("yyyyMMdd"), typeof(string));
                                }
                            }

                            if (RE_WO_NO == "")
                            {
                                RE_WO_NO = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "RW", bizExecute);
                            }

                            UTIL.SetBizAddColumnToValue(dtRow, "RE_WO_NO", RE_WO_NO, typeof(string));


                            if (PREV_CHAIN_WO_NO != "")
                            {
                                UTIL.SetBizAddColumnToValue(dtRow, "IS_PREV_CHAIN", 1, typeof(byte));

                                UTIL.SetBizAddColumnToValue(dtRow, "PREV_CHAIN_WO_NO", PREV_CHAIN_WO_NO, typeof(byte));
                            }
                            else
                            {
                                UTIL.SetBizAddColumnToValue(dtRow, "IS_PREV_CHAIN", DBNull.Value, typeof(byte));
                            }


                            UTIL.SetBizAddColumnToValue(dtRow, "IS_DES_CHANGE", 1, typeof(byte));
                            UTIL.SetBizAddColumnToValue(dtRow, "IS_REMCT", isMct, typeof(byte));

                            UTIL.SetBizAddColumnToValue(dtRow, "IS_MODIFY", isMdf, typeof(byte));

                            DSHP.TSHP_WORKORDER.TSHP_WORKORDER_INS(dtRow, bizExecute);

                        }
                        else if (RE_WO_FLAG == "2" && isRev == 1)
                        {
                            DataTable woDT = new DataTable();

                            if (OLD_RE_WO != "")
                            {
                                woDT = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER27(dtRow, bizExecute);
                            }
                            else
                            {

                                UTIL.SetBizAddColumnToValue(dtRow, "OLD_RE_WO", OLD_RE_WO, typeof(byte));
                                woDT = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER27_2(dtRow, bizExecute);
                            }

                            if (woDT.Rows.Count > 0)
                            {
                                if (woDT.Rows[0]["WO_NO"].ToString() != "" && woDT.Rows[0]["DES_STOP"].ToString() == "1")
                                {
                                    UTIL.SetBizAddColumnToValue(dtRow, "WO_NO", woDT.Rows[0]["WO_NO"].ToString(), typeof(String));

                                    DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD49(dtRow, bizExecute);
                                }
                            }

                        }


                    }
                    else
                    {
                        if (woRslt.Rows.Count == 0)
                        {
                            DSHP.TSHP_WORKORDER.TSHP_WORKORDER_INS(dtRow, bizExecute);
                        }
                        else
                        {
                            dtRow.Rows[0]["WO_NO"] = woRslt.Rows[0]["WO_NO"];

                            DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD48(dtRow, bizExecute);

                            if (wo_type == "DES")
                            {
                                DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD48_2(dtRow, bizExecute);
                            }
                        }
                    }

                    


                    proc_id++;
                }

                DMAT.TMAT_PARTLIST.TMAT_PARTLIST_UPD12(UTIL.GetRowToDt(part_row), bizExecute);

                part_id++;
            }

        }

        /// <summary>
        /// BOM복사
        /// </summary>
        /// <param name="row"></param>
        /// <param name="bizExecute"></param>
        static void SetCopyBom(DataRow row, DataTable dtBomCopy, BizExecute.BizExecute bizExecute)
        {
         
            #region 21-11-13 변경 전 코드
            //동일 모델명의 가장 최근 BOM PROD_CODE가져오기

            //DataTable dtOldProd = DORD.TORD_PRODUCT.TORD_PRODUCT_SER2(UTIL.GetRowToDt(row), bizExecute);

            //if (dtOldProd.Rows.Count == 0)
            //    return;

            //string old_prod_code = dtOldProd.Rows[0]["PROD_CODE"].ToString();
            #endregion

            if (row["OLD_PROD_CODE"].isNullOrEmpty())
                return;

            string old_prod_code = row["OLD_PROD_CODE"].ToString();

            DataTable dtParam = new DataTable("RQSTDT");
            UTIL.SetBizAddColumnToValue(dtParam, "PLT_CODE", ConnInfo.PLT_CODE, typeof(string));
            UTIL.SetBizAddColumnToValue(dtParam, "PROD_CODE", old_prod_code, typeof(string));

            DataTable dtBomList = null;

            bool isStay = true;
            if (dtBomCopy.Rows.Count > 0) // 편집된 BOM 목록이 있는 경우 
            {
                dtBomList = dtBomCopy;
                isStay = false;
            }
            else
            {
                // 편집된 BOM 목록이 없는 경우 기존 수주의 BOM을 그대로 적용 
                // dtBomList = DMAT.TMAT_PARTLIST.TMAT_PARTLIST_SER2(dtParam, bizExecute);
                dtBomList = DMAT.TMAT_PARTLIST_QUERY.TMAT_PARTLIST_QUERY5(dtParam, bizExecute);
            }

            dtBomList.Columns.Add("PREV_PT_ID", typeof(string));
            dtBomList.Columns.Add("PREV_PART_CODE", typeof(string));
            dtBomList.Columns.Add("PREV_O_PT_ID", typeof(string));

            dtBomList.Columns.Add("IS_SIDE", typeof(byte));

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

            //리핏시 품목ID(PT_ID), 모품목ID(O_PT_ID) 신규 수주번호로 변경
            foreach (DataRow rpRow in dtBomList.Rows)
            {
                if (rpRow["IS_COPY_SIDE"].ToString() == "1")
                {
                    DataTable sideTable = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY47(UTIL.GetRowToDt(rpRow), bizExecute);

                    rpRow["IS_SIDE"] = 0;

                    if (sideTable.Rows.Count > 0)
                    {
                        if (sideTable.Rows[0]["SIDE_CNT"].toInt() > 0)
                        {
                            rpRow["IS_SIDE"] = 1;
                        }
                    }
                }


                //신규 데이터 변경
                rpRow["PT_ID"] = rpRow["PT_ID"].ToString().Replace(old_prod_code, row["PROD_CODE"].ToString());
                rpRow["O_PT_ID"] = rpRow["O_PT_ID"].ToString().Replace(old_prod_code, row["PROD_CODE"].ToString());
                rpRow["PROD_CODE"] = row["PROD_CODE"];
            }

            UTIL.SetBizAddColumnToValue(dtBomList, "PART_CODE_SUBSTRING", "", typeof(string));


            //대표자재 품목명으로 찾아서 변경
            //없으면 해당 품목이 메인품목이됨
            foreach (DataRow pRow in dtBomList.Rows)
            {
                pRow["PART_CODE_SUBSTRING"] = pRow["PART_CODE"].ToString().Substring(0, 1);
                
                if (pRow["PART_CODE_SUBSTRING"].ToString() != "M")
                {
                    if (pRow["PART_CODE_SUBSTRING"].ToString() != "A")
                    {
                        DataTable stdPart = DLSE.LSE_STD_PART.LSE_STD_PART_SER(UTIL.GetRowToDt(pRow), bizExecute);

                        stdPart.Columns.Add("PART_CODE_SUBSTRING", typeof(string));

                        DataTable dtExistStdPart = new DataTable();
                        if (stdPart.Rows.Count == 1)
                        {
                            stdPart.Rows[0]["PART_CODE_SUBSTRING"] = pRow["PART_CODE_SUBSTRING"];
                            dtExistStdPart = DLSE.LSE_STD_PART.LSE_STD_PART_SER5(stdPart, bizExecute);
                        }

                        if (dtExistStdPart.Rows.Count > 0)
                        {
                            if (pRow["PART_CODE"].ToString() != dtExistStdPart.Rows[0]["PART_CODE"].ToString())
                            {
                                if (dtExistStdPart.Rows[0]["MAT_LTYPE"].ToString() == "22"
                                || dtExistStdPart.Rows[0]["MAT_LTYPE"].ToString() == "4")
                                {
                                    DataRow[] rows = dtBomList.Select("O_PT_ID = '" + pRow["PT_ID"].ToString() + "'");

                                    pRow["PREV_PART_CODE"] = pRow["PART_CODE"];
                                    pRow["PREV_PT_ID"] = pRow["PT_ID"];
                                    pRow["PT_ID"] = pRow["PT_ID"].ToString().Replace(pRow["PART_CODE"].ToString(), dtExistStdPart.Rows[0]["PART_CODE"].ToString());
                                    pRow["PART_CODE"] = dtExistStdPart.Rows[0]["PART_CODE"];

                                    foreach (DataRow rw in rows)
                                    {
                                        rw["PREV_O_PT_ID"] = rw["PT_ID"];
                                        rw["O_PT_ID"] = pRow["PT_ID"];
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (pRow["MAT_LTYPE"].ToString() == "22"
                                || pRow["MAT_LTYPE"].ToString() == "4")
                            {
                                DataTable partTable = new DataTable("RQSTDT");
                                partTable.Columns.Add("PLT_CODE", typeof(String));
                                partTable.Columns.Add("PART_CODE", typeof(String));
                                partTable.Columns.Add("IS_MAIN_PART", typeof(Byte));

                                DataRow partRow = partTable.NewRow();
                                partRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                                partRow["PART_CODE"] = pRow["PART_CODE"];
                                partRow["IS_MAIN_PART"] = 1;
                                partTable.Rows.Add(partRow);

                                DLSE.LSE_STD_PART.LSE_STD_PART_UPD19(partTable, bizExecute);
                            }
                        }
                    }
                }
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
                //dataRow["PROD_CODE"] = row["PROD_CODE"];

                int child_mat_cnt = 0;

                foreach (DataRow p_dataRow in dtBomList.Select(string.Format("O_PT_ID = '{0}'", dataRow["PT_ID"])))
                {
                    //p_dataRow["O_PT_ID"] = p_dataRow["O_PT_ID"].ToString().Replace(old_prod_code, row["PROD_CODE"].ToString());
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

                string pt_no = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "PT", bizExecute);

                //신규 데이터 변경
                //dataRow["PT_ID"] = dataRow["PT_ID"].ToString().Replace(old_prod_code, row["PROD_CODE"].ToString());
                dataRow["PT_NO"] = pt_no;
                //dataRow["PROD_CODE"] = row["PROD_CODE"];

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
                        outReqTable.Columns.Add("DATA_FLAG", typeof(byte));

                        DataRow outReqRow = outReqTable.NewRow();
                        outReqRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                        outReqRow["OUT_REQ_ID"] = OUT_REQ_ID;
                        outReqRow["PT_ID"] = dataRow["PT_ID"];
                        outReqRow["PART_CODE"] = dataRow["PART_CODE"];
                        outReqRow["OUT_REQ_DATE"] = DateTime.Now.toDateString("yyyyMMdd");
                        outReqRow["OUT_REQ_EMP"] = "system";

                        
                        double partQty = dataRow["PART_QTY"].toInt();
                        double prodQty = row["PROD_QTY"].toInt();

                        int reqQty = (partQty * dataRow["O_PART_QTY"].toDouble() * prodQty).toInt();

                        if (dataRow["ORD_QTY"].toDouble() > 0)
                        {
                            reqQty = (partQty * dataRow["O_PART_QTY"].toDouble() * dataRow["ORD_QTY"].toDouble()).toInt();
                        }

                        outReqRow["OUT_REQ_QTY"] = reqQty;
                        outReqRow["OUT_REQ_STAT"] = "50";
                        outReqRow["OUT_REQ_LOC"] = "ASY";
                        outReqRow["DATA_FLAG"] = 0;
                        outReqTable.Rows.Add(outReqRow);

                        DMAT.TMAT_OUT_REQ.TMAT_OUT_REQ_INS(outReqTable, bizExecute);
                    }
                }

            }

            DMAT.TMAT_PARTLIST.TMAT_PARTLIST_INS(dtBomList, bizExecute);


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

                            if (reqQty == reqTotalQty)
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



        /// <summary>
        /// 수주 복구
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet ORD02A_UPD5(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    IsLock(row, bizExecute);

                    DORD.TORD_PRODUCT.TORD_PRODUCT_UPD7(UTIL.GetRowToDt(row), bizExecute);
                }
                return ORD02A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static void IsLock(DataRow row, BizExecute.BizExecute bizExecute)
        {
            DataTable dt = DORD.TORD_PRODUCT.TORD_PRODUCT_SER(UTIL.GetRowToDt(row), bizExecute);

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["LOCK_FLAG"].Equals("1") && dt.Rows[0]["LOCK_EMP"].ToString() != ConnInfo.UserID)
                {
                    throw UTIL.SetException("잠금 설정되어 처리할 수 없습니다."
                              , new System.Diagnostics.StackFrame().GetMethod().Name
                              , BizException.PROD_LOCK);
                }
            }
        }

        public static DataSet ORD02A_UPD8(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DORD.TORD_PRODUCT.TORD_PRODUCT_UPD17(UTIL.GetRowToDt(row), bizExecute);
                }
                return ORD02A_SER(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
    }
}
