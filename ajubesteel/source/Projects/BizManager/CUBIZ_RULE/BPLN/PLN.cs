using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;
//using ControlManager;

namespace BPLN
{
    public class PLN
    {
        //표준 공정 정보 가져오기(컬럼 생성용)
        public static DataSet PLN_PROC(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {

            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DLSE.LSE_STD_PROC_QUERY.LSE_STD_PROC_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);

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

        public static DataTable Get_ChildProcWoFlag(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count <= 0) return null;

                //가공 공정 리스트 가져오기
                DataTable dtparamProc = new DataTable();
                UTIL.SetBizAddColumnToValue(dtparamProc, "PLT_CODE", ConnInfo.PLT_CODE, typeof(String));
                UTIL.SetBizAddColumnToValue(dtparamProc, "DATA_FLAG", 0, typeof(Byte));
                UTIL.SetBizAddColumnToValue(dtparamProc, "IS_BOP_PROC", 1, typeof(Byte));

                DataTable dtProc = DLSE.LSE_STD_PROC_QUERY.LSE_STD_PROC_QUERY1(dtparamProc, bizExecute);

                //resultSet
                DataTable dtResult = new DataTable();
                dtResult.Columns.Add("PLT_CODE", typeof(String));
                dtResult.Columns.Add("WP_NO", typeof(String));
                dtResult.Columns.Add("WO_NO", typeof(String));
                dtResult.Columns.Add("PROD_CODE", typeof(String));
                dtResult.Columns.Add("PART_CODE", typeof(String));
                dtResult.Columns.Add("PROC_CODE", typeof(String));
                dtResult.Columns.Add("WO_FLAG", typeof(String));
                dtResult.Columns.Add("WO_FLAG_NAME", typeof(String));
                dtResult.Columns.Add("PLN_START", typeof(String));
                dtResult.Columns.Add("PLN_END", typeof(String));
                dtResult.Columns.Add("ACT_END", typeof(String));
                dtResult.Columns.Add("IS_YPGO", typeof(Decimal));

                foreach (DataRow dr in dtParam.Rows)
                {

                    string prod_code = dr["PROD_CODE"].ToString();  // dtParam.Rows[0]["PROD_CODE"].ToString();
                    string part_code = dr["PART_CODE"].ToString();  // dtParam.Rows[0]["PART_CODE"].ToString();
                    
                    //단품정보 가져오기
                    DataTable dtparamChild = new DataTable();
                    UTIL.SetBizAddColumnToValue(dtparamChild, "PLT_CODE", ConnInfo.PLT_CODE, typeof(String));
                    UTIL.SetBizAddColumnToValue(dtparamChild, "DATA_FLAG", 0, typeof(Byte));
                    UTIL.SetBizAddColumnToValue(dtparamChild, "PROD_CODE", prod_code, typeof(String));
                    UTIL.SetBizAddColumnToValue(dtparamChild, "PARENT_PART", part_code, typeof(String));

                    //작업정보 가져오기

                    DataTable dtparamWo = new DataTable();
                    UTIL.SetBizAddColumnToValue(dtparamWo, "PLT_CODE", ConnInfo.PLT_CODE, typeof(String));
                    UTIL.SetBizAddColumnToValue(dtparamWo, "PROD_CODE", prod_code, typeof(String));
                    UTIL.SetBizAddColumnToValue(dtparamWo, "DATA_FLAG", 0, typeof(Byte));

                    DataTable dtWO = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY10(dtparamWo, bizExecute);

                    foreach (DataRow drproc in dtProc.Rows)
                    {

                        DataRow[] rowsWo = dtWO.Select(string.Format("PROC_CODE = '{0}'", drproc["PROC_CODE"]), "WO_FLAG");

                        if (rowsWo.Length == 0) continue;

                        DataTable dtcopy = rowsWo.CopyToDataTable();

                        DataRow drWo = rowsWo[0];

                        DataRow drResult = dtResult.NewRow();
                        drResult["PLT_CODE"] = drWo["PLT_CODE"];
                        drResult["PROD_CODE"] = drWo["PROD_CODE"];
                        drResult["PART_CODE"] = part_code; // drWo["PARENT_PART"];
                        drResult["PROC_CODE"] = drWo["PROC_CODE"];
                        drResult["WO_FLAG"] = drWo["WO_FLAG"];
                        drResult["WO_FLAG_NAME"] = drWo["WO_FLAG_NAME"];
                        //drResult["ACT_END"] = drWo["ACT_END"];
                        //drResult["PLN_END"] = drWo["PLN_END_TIME"];
                        //PLN_END_TIME
                        
                        drResult["WP_NO"] = drWo["WP_NO"];
                        drResult["WO_NO"] = drWo["WO_NO"];

                        drResult["IS_YPGO"] = drWo["IS_YPGO"];

                        dtResult.Rows.Add(drResult);

                    }
                }
                dtResult.TableName = "RSLTDT";
                
                return dtResult;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static DataTable Get_ChildProcWoFlag2(DataTable dtProc, DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                if (dtParam.Rows.Count <= 0) return null;
                
                //resultSet
                DataTable dtResult = new DataTable();
                dtResult.Columns.Add("PLT_CODE", typeof(String));
                dtResult.Columns.Add("WP_NO", typeof(String));
                dtResult.Columns.Add("WO_NO", typeof(String));
                dtResult.Columns.Add("PROD_CODE", typeof(String));
                dtResult.Columns.Add("PART_CODE", typeof(String));
                dtResult.Columns.Add("PROC_CODE", typeof(String));
                dtResult.Columns.Add("WO_FLAG", typeof(String));
                dtResult.Columns.Add("WO_FLAG_NAME", typeof(String));
                dtResult.Columns.Add("PLN_START", typeof(DateTime));
                dtResult.Columns.Add("PLN_END", typeof(DateTime));
                dtResult.Columns.Add("ACT_END", typeof(DateTime));
                dtResult.Columns.Add("ACT_QTY", typeof(Int32));
                dtResult.Columns.Add("PART_QTY", typeof(Int32));
                dtResult.Columns.Add("IS_ASSY", typeof(Int32));

                foreach (DataRow dr in dtParam.Rows)
                {

                    string prod_code = dr["PROD_CODE"].ToString();  // dtParam.Rows[0]["PROD_CODE"].ToString();
                    string part_code = dr["PART_CODE"].ToString();  // dtParam.Rows[0]["PART_CODE"].ToString();

                    //단품정보 가져오기
                    DataTable dtparamChild = new DataTable();
                    UTIL.SetBizAddColumnToValue(dtparamChild, "PLT_CODE", ConnInfo.PLT_CODE, typeof(String));
                    UTIL.SetBizAddColumnToValue(dtparamChild, "DATA_FLAG", 0, typeof(Byte));
                    UTIL.SetBizAddColumnToValue(dtparamChild, "PROD_CODE", prod_code, typeof(String));
                    UTIL.SetBizAddColumnToValue(dtparamChild, "PARENT_PART", part_code, typeof(String));

                    //작업정보 가져오기

                    DataTable dtparamWo = new DataTable();
                    UTIL.SetBizAddColumnToValue(dtparamWo, "PLT_CODE", ConnInfo.PLT_CODE, typeof(String));
                    UTIL.SetBizAddColumnToValue(dtparamWo, "PROD_CODE", prod_code, typeof(String));
                    UTIL.SetBizAddColumnToValue(dtparamWo, "DATA_FLAG", 0, typeof(Byte));

                    DataTable dtWO = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY10(dtparamWo, bizExecute);

                    foreach (DataRow drproc in dtProc.Rows)
                    {

                        DataRow[] rowsWo = null;
                        if (drproc["IS_ASSY"].ToString().Equals("1"))
                        {
                            rowsWo = dtWO.Select(string.Format("PROC_CODE = '{0}' AND PARENT_PART IS NULL", drproc["PROC_CODE"]), "WO_FLAG");
                        }
                        else
                        {
                            rowsWo = dtWO.Select(string.Format("PROC_CODE = '{0}'", drproc["PROC_CODE"]), "WO_FLAG");
                        }

                        if (rowsWo.Length == 0) continue;

                        DataTable dtcopy = rowsWo.CopyToDataTable();

                        DataRow drWo = rowsWo[0];

                        DataRow drResult = dtResult.NewRow();
                        drResult["PLT_CODE"] = drWo["PLT_CODE"];
                        drResult["PROD_CODE"] = drWo["PROD_CODE"];
                        drResult["PART_CODE"] = part_code; // drWo["PARENT_PART"];
                        drResult["PROC_CODE"] = drWo["PROC_CODE"];
                        drResult["WO_FLAG"] = drWo["WO_FLAG"];
                        drResult["WO_FLAG_NAME"] = drWo["WO_FLAG_NAME"];
                       
                        drResult["WP_NO"] = drWo["WP_NO"];
                        drResult["WO_NO"] = drWo["WO_NO"];

                        drResult["ACT_END"] = drWo["ACT_END_TIME"];
                        drResult["PLN_END"] = drWo["PLN_END"];
                        drResult["PLN_START"] = drWo["PLN_START"];

                        drResult["ACT_QTY"] = drWo["ACT_QTY"];
                        drResult["PART_QTY"] = drWo["PART_QTY"];
                        drResult["IS_ASSY"] = drWo["IS_ASSY"];

                        dtResult.Rows.Add(drResult);

                    }
                }
                dtResult.TableName = "RSLTDT";

                return dtResult;

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 표준 BOM 자식 부품 중 선삭 부품만 저장
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TurnningChildBomSave(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in dtParam.Rows)
                {
                    DataTable dtBomSer = new DataTable("RQSTDT");
                    dtBomSer.Columns.Add("PLT_CODE", typeof(String));
                    dtBomSer.Columns.Add("BOM_PART_CODE", typeof(String));
                    dtBomSer.Columns.Add("IS_TURNING", typeof(Byte));

                    DataRow paramRow = dtBomSer.NewRow();
                    paramRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                    paramRow["BOM_PART_CODE"] = row["PART_CODE"];
                    paramRow["IS_TURNING"] = 1;

                    dtBomSer.Rows.Add(paramRow);

                    DataTable dtBomSerRslt = DSTD.TSTD_BOM_QUERY.TSTD_BOM_QUERY1(dtBomSer, bizExecute);

                    foreach (DataRow bomRow in dtBomSerRslt.Rows)
                    {
                        DataRow inputRow = bomRow.NewCopy();
                        inputRow["PLT_CODE"] = row["PLT_CODE"];
                        inputRow["BOM_ID"] = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "BM", bizExecute);
                        inputRow["BOM_PART_CODE"] = row["BOM_PART_CODE"];
                        inputRow["PARENT_ID"] = row["BOM_ID"];
                        //PART_CODE 그대로 사용
                        //inputRow["PART_CODE"] = row["PART_CODE"];
                        //inputRow["BOM_QTY"] = ;
                        inputRow["BOM_SEQ"] = 0;
                        DSTD.TSTD_BOM.TSTD_BOM_INS(UTIL.GetRowToDt(inputRow), bizExecute);
                    }
                }
                return dtParam;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// Product에 선삭 추가
        /// </summary>
        /// <param name="dtParam"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataTable TurnningChildBomSave2(DataTable dtParam, BizExecute.BizExecute bizExecute)
        {
            try
            {
                foreach (DataRow row in dtParam.Rows)
                {
                    DataTable dtBomSer = new DataTable("RQSTDT");
                    dtBomSer.Columns.Add("PLT_CODE", typeof(String));
                    dtBomSer.Columns.Add("BOM_PART_CODE", typeof(String));
                    dtBomSer.Columns.Add("IS_TURNING", typeof(Byte));

                    DataRow paramRow = dtBomSer.NewRow();
                    paramRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                    paramRow["BOM_PART_CODE"] = row["PART_CODE"];
                    paramRow["IS_TURNING"] = 1;

                    dtBomSer.Rows.Add(paramRow);

                    DataTable dtBomSerRslt = DSTD.TSTD_BOM_QUERY.TSTD_BOM_QUERY1(dtBomSer, bizExecute);

                    foreach (DataRow bomRow in dtBomSerRslt.Rows)
                    {
                        DataTable dtBomIns = new DataTable("RQSTDT");
                        dtBomIns.Columns.Add("PLT_CODE", typeof(String));
                        dtBomIns.Columns.Add("PART_CODE", typeof(String));
                        dtBomIns.Columns.Add("PROD_NAME", typeof(String));
                        dtBomIns.Columns.Add("PROD_CODE", typeof(String));
                        dtBomIns.Columns.Add("PARENT_PART", typeof(String));

                        DataRow paramRow2 = dtBomIns.NewRow();
                        paramRow2["PLT_CODE"] = ConnInfo.PLT_CODE;
                        paramRow2["PART_CODE"] = bomRow["PART_CODE"];
                        paramRow2["PROD_NAME"] = bomRow["PART_NAME"];
                        paramRow2["PROD_CODE"] = row["PROD_CODE"];
                        paramRow2["PARENT_PART"] = row["PART_CODE"];

                        dtBomIns.Rows.Add(paramRow2);

                        DataTable rslt = DORD.TORD_PRODUCT.TORD_PRODUCT_SER(dtBomIns, bizExecute);

                        if (rslt.Rows.Count == 0)
                        {
                            //DORD.TORD_PRODUCT.TORD_PRODUCT_INS2(dtBomIns, bizExecute);
                        }
                    }
                }
                return dtParam;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }
    }
}
