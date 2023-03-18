using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BMAT
{
    public class MAT04A
    {
        /// <summary>
        ///  조회(반납 요청할 내역)
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExe"></param>
        /// <returns></returns>
        public static DataSet MAT04A_SER(DataSet paramDS, BizExecute.BizExecute bizExe)
        {
            try
            {
                DataTable dtRslt = DORD.TORD_PRODUCT_QUERY.TORD_PRODUCT_QUERY15(paramDS.Tables["RQSTDT"], bizExe);

                dtRslt.Columns.Add("SEL", typeof(String));
                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static DataSet MAT04A_SER2(DataSet paramDS, BizExecute.BizExecute bizExe)
        {
            try
            {

                DataTable dtRslt = DMAT.TMAT_PARTLIST_QUERY.TMAT_PARTLIST_QUERY4(paramDS.Tables["RQSTDT"], bizExe);

                dtRslt.Columns.Add("SEL", typeof(String));
                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet MAT04A_SER3(DataSet paramDS, BizExecute.BizExecute bizExe)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DMAT.TMAT_RET_REQ_QUERY.TMAT_RET_REQ_QUERY1(paramDS.Tables["RQSTDT"], bizExe);
                dtRslt.Columns.Add("SEL", typeof(String));
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
       /// 반납 요청
       /// </summary>
       /// <param name="paramDS"></param>
       /// <param name="bizExe"></param>
       /// <returns></returns>
        public static DataSet MAT04A_INS(DataSet paramDS, BizExecute.BizExecute bizExe)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                int cnt = 0;

                string SR_CODE = "MY";

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    string RetReqID = UTIL.UTILITY_GET_SERIALNO(row["PLT_CODE"].ToString(), "RREQ", bizExe);
                    row["RET_REQ_ID"] = RetReqID;

                    DMAT.TMAT_RET_REQ.TMAT_RET_REQ_INS(UTIL.GetRowToDt(row), bizExe);

                    string PLT_CODE = row["PLT_CODE"].ToString();
                    string YPGO_DATE = row["YPGO_DATE"].ToString();
                    int QTY = row["QTY"].toInt32();
                    decimal UNIT_COST = row["YPGO_COST"].toDecimal();
                    decimal AMT = row["YPGO_AMT"].toDecimal();
                    string SCOMMENT = row["SCOMMENT"].ToString();
                    string REG_EMP = ConnInfo.UserID;
                    string YPGO_LOC = row["STK_LOCATION"].ToString();

                    string SR_NO = UTIL.UTILITY_GET_SERIALNO(PLT_CODE, SR_CODE, UTIL.emSerialFormat.YYYYMMDD, "", bizExe);

                    DataTable paramTableYPGO = new DataTable("YPGO");
                    paramTableYPGO.Columns.Add("PLT_CODE", typeof(String)); //
                    paramTableYPGO.Columns.Add("YPGO_ID", typeof(String)); //
                    paramTableYPGO.Columns.Add("BALJU_NUM", typeof(String)); //
                    paramTableYPGO.Columns.Add("BALJU_SEQ", typeof(Int32)); //
                    paramTableYPGO.Columns.Add("YPGO_DATE", typeof(String)); //
                    paramTableYPGO.Columns.Add("QTY", typeof(Int32)); //
                    paramTableYPGO.Columns.Add("UNIT_COST", typeof(Decimal)); //
                    paramTableYPGO.Columns.Add("AMT", typeof(Decimal)); //
                    paramTableYPGO.Columns.Add("YPGO_STAT", typeof(String)); //
                    paramTableYPGO.Columns.Add("INS_FLAG", typeof(String)); //
                    paramTableYPGO.Columns.Add("SCOMMENT", typeof(String)); //
                    paramTableYPGO.Columns.Add("YPGO_LOC", typeof(String)); //
                    paramTableYPGO.Columns.Add("TYPE", typeof(String)); //
                    paramTableYPGO.Columns.Add("PART_CODE", typeof(String)); //
                    paramTableYPGO.Columns.Add("DETAIL_PART_NAME", typeof(String)); //
                    paramTableYPGO.Columns.Add("STK_ID", typeof(String)); //

                    DataRow paramRowYPGO = paramTableYPGO.NewRow();
                    paramRowYPGO["PLT_CODE"] = PLT_CODE;
                    paramRowYPGO["YPGO_ID"] = SR_NO;
                    paramRowYPGO["YPGO_DATE"] = YPGO_DATE;
                    paramRowYPGO["BALJU_NUM"] = row["RET_REQ_ID"];
                    paramRowYPGO["BALJU_SEQ"] = 0;
                    paramRowYPGO["QTY"] = QTY;
                    paramRowYPGO["UNIT_COST"] = UNIT_COST;
                    paramRowYPGO["AMT"] = AMT;
                    paramRowYPGO["YPGO_STAT"] = "22";
                    paramRowYPGO["SCOMMENT"] = SCOMMENT;
                    paramRowYPGO["YPGO_LOC"] = YPGO_LOC;
                    paramRowYPGO["TYPE"] = "IN";
                    paramRowYPGO["PART_CODE"] = row["PART_CODE"];
                    paramTableYPGO.Rows.Add(paramRowYPGO);

                    //입고 정보
                    DMAT.TMAT_YPGO.TMAT_YPGO_INS(paramTableYPGO, bizExe);

                    //재고 입고 처리
                    CTRL.CTRL.SET_STOCK_PROCESS(paramRowYPGO, bizExe, "PART_CODE", "YPGO_LOC", "QTY", "AMT", "YPGO_ID", null, SCOMMENT, "RE");

                    row["YPGO_ID"] = SR_NO;

                    DMAT.TMAT_RET_REQ.TMAT_RET_REQ_UPD(UTIL.GetRowToDt(row), bizExe);

                    cnt++;
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
        public static DataSet MAT04A_DEL(DataSet paramDS, BizExecute.BizExecute bizExe)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 2, typeof(Byte));

                DMAT.TMAT_RET_REQ.TMAT_RET_REQ_UDE(paramDS.Tables["RQSTDT"], bizExe);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
    }
}
