using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BMAT
{
    public class MAT05A
    {
        /// <summary>
        ///  조회(재고 내역)
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExe"></param>
        /// <returns></returns>
        public static DataSet MAT05A_SER(DataSet paramDS, BizExecute.BizExecute bizExe)
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


        public static DataSet MAT05A_SER2(DataSet paramDS, BizExecute.BizExecute bizExe)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DMAT.TMAT_RET_REQ_QUERY.TMAT_RET_REQ_QUERY2(paramDS.Tables["RQSTDT"], bizExe);

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

        public static DataSet MAT05A_INS(DataSet paramDS, BizExecute.BizExecute bizExe)
        {
            try
            {
                string out_id;

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "RET_REQ_STAT", "22", typeof(String));

                string YPGO_STAT = "22";
                string SR_CODE = "MY";
                //완료;

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
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
                    paramRowYPGO["YPGO_STAT"] = YPGO_STAT;
                    paramRowYPGO["SCOMMENT"] = SCOMMENT;
                    paramRowYPGO["YPGO_LOC"] = YPGO_LOC;
                    paramRowYPGO["TYPE"] = "IN";
                    paramRowYPGO["PART_CODE"] = row["PART_CODE"];
                    paramTableYPGO.Rows.Add(paramRowYPGO);

                    //입고 정보
                    DMAT.TMAT_YPGO.TMAT_YPGO_INS(paramTableYPGO, bizExe);

                    //재고 입고 처리
                    CTRL.CTRL.SET_STOCK_PROCESS(paramRowYPGO, bizExe, "PART_CODE", "YPGO_LOC", "QTY", "AMT", "YPGO_ID", null);

                    row["YPGO_ID"] = SR_NO;

                    DMAT.TMAT_RET_REQ.TMAT_RET_REQ_UPD(UTIL.GetRowToDt(row), bizExe);
                }


                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet MAT05A_DEL(DataSet paramDS, BizExecute.BizExecute bizExe)
        {
            try
            {
                //반납요청 상태
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "RET_REQ_STAT", "49", typeof(String));

                DataTable paramTableYPGO = new DataTable("BALJU");
                paramTableYPGO.Columns.Add("BAL_STAT", typeof(String)); //
                paramTableYPGO.Columns.Add("YPGO_STAT", typeof(String)); //
                paramTableYPGO.Columns.Add("PLT_CODE", typeof(String)); //
                paramTableYPGO.Columns.Add("YPGO_ID", typeof(string)); //
                paramTableYPGO.Columns.Add("PART_CODE", typeof(string)); //
                paramTableYPGO.Columns.Add("DETAIL_PART_NAME", typeof(string)); //
                paramTableYPGO.Columns.Add("TYPE", typeof(string)); //

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {
                    DMAT.TMAT_RET_REQ.TMAT_RET_REQ_UPD(UTIL.GetRowToDt(row), bizExe);

                    paramTableYPGO.Clear();
                    DataRow paramRowYPGO = paramTableYPGO.NewRow();
                    paramRowYPGO["PLT_CODE"] = row["PLT_CODE"];
                    paramRowYPGO["YPGO_ID"] = row["YPGO_ID"];
                    paramRowYPGO["YPGO_STAT"] = "23";    //입고 취소
                    paramRowYPGO["TYPE"] = "IN_CANCEL";
                    paramTableYPGO.Rows.Add(paramRowYPGO);

                    DMAT.TMAT_YPGO.TMAT_YPGO_UPD2(paramTableYPGO, bizExe);

                    //재고 입고 취소 처리
                    CTRL.CTRL.SET_STOCK_PROCESS(paramRowYPGO, bizExe, "PART_CODE", "YPGO_LOC", "QTY", "AMT", "YPGO_ID", null);
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
