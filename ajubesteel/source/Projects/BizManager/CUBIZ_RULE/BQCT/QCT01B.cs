using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using BizExecute;

namespace BQCT
{
    public class QCT01B
    {
        public static DataSet QCT01B_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DSHP.TSHP_NG_QUERY.TSHP_NG_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

                UTIL.SetBizAddColumnToValue(dtRslt, "DATA_FLAG", 0, typeof(Byte),true);
                if (dtRslt.Rows.Count> 0)
                {
                    DataTable dtWo = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY20(dtRslt, bizExecute);

                    DataTable dt = dtRslt.AsEnumerable()
                            .Join(dtWo.AsEnumerable()
                                , wo => wo["ACTUAL_ID"]
                                , rslt => rslt["ACTUAL_ID"]
                                , (rslt, wo) => new
                                {
                                    PLT_CODE = rslt.Field<String>("PLT_CODE"),
                                    ITEM_CODE = rslt.Field<String>("ITEM_CODE"),
                                    CVND_CODE = rslt.Field<String>("CVND_CODE"),
                                    CVND_NAME = rslt.Field<String>("CVND_NAME"),
                                    PROD_CODE = rslt.Field<String>("PROD_CODE"),
                                    PART_CODE = rslt.Field<String>("PART_CODE"),
                                    PROC_SEQ = rslt["PROC_SEQ"],
                                    PART_NAME = rslt.Field<String>("PART_NAME"),
                                    DRAW_NO = rslt.Field<String>("DRAW_NO"),
                                    PROC_CODE = rslt.Field<String>("PROC_CODE"),
                                    NG_QTY = rslt["NG_QTY"],
                                    ACT_QTY = rslt["ACT_QTY"],
                                    PART_QTY = rslt["PART_QTY"],
                                    PROC_NAME = rslt.Field<String>("PROC_NAME"),
                                    NG_ID = rslt.Field<String>("NG_ID"),
                                    WO_NO = rslt.Field<String>("WO_NO"),
                                    WORK_DATE = rslt["WORK_DATE"],
                                    ACT_START_TIME = rslt["ACT_START_TIME"],
                                    ACT_END_TIME = rslt["ACT_END_TIME"],
                                    ACTUAL_ID = rslt.Field<String>("ACTUAL_ID"),
                                    LINK_KEY = rslt.Field<String>("LINK_KEY"),
                                    MC_CODE = rslt.Field<String>("MC_CODE"),
                                    MC_NAME = rslt.Field<String>("MC_NAME"),
                                    EMP_CODE = rslt.Field<String>("EMP_CODE"),
                                    EMP_NAME = rslt.Field<String>("EMP_NAME"),
                                    ACT_TYPE = rslt.Field<String>("ACT_TYPE"),
                                    MASTER_CAUSE = rslt.Field<String>("MASTER_CAUSE"),
                                    DETAIL_CAUSE = rslt.Field<String>("DETAIL_CAUSE"),
                                    QUANTITY = rslt["QUANTITY"].toDecimal(),
                                    NG_TYPE = rslt.Field<String>("NG_TYPE"),
                                    NG_CONTENTS = rslt.Field<String>("NG_CONTENTS"),
                                    NG_CAUSE = rslt.Field<String>("NG_CAUSE"),
                                    NG_MEASURE = rslt.Field<String>("NG_MEASURE"),
                                    NG_STATE = rslt.Field<String>("NG_STATE"),
                                    NG_MAT_COST = rslt["NG_MAT_COST"].toDecimal(),
                                    NG_LAB_COST = rslt["NG_LAB_COST"].toDecimal(),
                                    NG_DIST_COST = rslt["NG_DIST_COST"].toDecimal(),
                                    NG_MEASURE_EMP = rslt.Field<String>("NG_MEASURE_EMP"),
                                    NG_MEASURE_EMP_NAME = rslt.Field<String>("NG_MEASURE_EMP_NAME"),
                                    NG_CAT = rslt.Field<String>("NG_CAT"),
                                    NG_OCCUR = rslt.Field<String>("NG_OCCUR"),
                                    NG_OUT_COST = rslt.Field<Decimal?>("NG_OUT_COST"),
                                    NG_PROC_COST = rslt.Field<Decimal?>("NG_PROC_COST"),
                                    NG_COST = rslt.Field<Decimal?>("NG_COST"),
                                    NG_COST_CODE = rslt.Field<String>("NG_COST_CODE"),
                                    MDFY_DATE = rslt.Field<DateTime?>("MDFY_DATE"),
                                    MDFY_EMP = rslt.Field<String>("MDFY_EMP"),
                                    WK_NG_QTY = rslt["WK_NG_QTY"],
                                    WO_PROC_SEQ = wo["PROC_SEQ"],
                                    WO_IS_OS = wo.Field<byte?>("IS_OS"),
                                    WO_PROC_COST = wo["PROC_COST"].toDecimal(),
                                    CALC_COST = rslt["QUANTITY"].toDecimal() * wo["PROC_COST"].toDecimal(),
                                    IN_COST = wo.Field<byte?>("IS_OS") == 0 ? rslt["QUANTITY"].toDecimal() * wo["PROC_COST"].toDecimal() : 0,
                                    OUT_COST = wo.Field<byte?>("IS_OS") == 1 ? rslt["QUANTITY"].toDecimal() * wo["PROC_COST"].toDecimal() : 0
                                })
                    .GroupBy(g => new { ACTUAL_ID = g.ACTUAL_ID })
                    .Select(r => new
                    {
                        PLT_CODE = r.Max(m => m.PLT_CODE),
                        ITEM_CODE = r.Max(m => m.ITEM_CODE),
                        CVND_CODE = r.Max(m => m.CVND_CODE),
                        CVND_NAME = r.Max(m => m.CVND_NAME),
                        PROD_CODE = r.Max(m => m.PROD_CODE),
                        PART_CODE = r.Max(m => m.PART_CODE),
                        PROC_SEQ = r.Max(m => m.PROC_SEQ),
                        PART_NAME = r.Max(m => m.PART_NAME),
                        DRAW_NO = r.Max(m => m.DRAW_NO),
                        PROC_CODE = r.Max(m => m.PROC_CODE),
                        NG_QTY = r.Max(m => m.NG_QTY),
                        ACT_QTY = r.Max(m => m.ACT_QTY),
                        PART_QTY = r.Max(m => m.PART_QTY),
                        PROC_NAME = r.Max(m => m.PROC_NAME),
                        NG_ID = r.Max(m => m.NG_ID),
                        WO_NO = r.Max(m => m.WO_NO),
                        WORK_DATE = r.Max(m => m.WORK_DATE),
                        ACT_START_TIME = r.Max(m => m.ACT_START_TIME),
                        ACT_END_TIME = r.Max(m => m.ACT_END_TIME),
                        ACTUAL_ID = r.Key.ACTUAL_ID,
                        LINK_KEY = r.Max(m => m.LINK_KEY),
                        MC_CODE = r.Max(m => m.MC_CODE),
                        MC_NAME = r.Max(m => m.MC_NAME),
                        EMP_CODE = r.Max(m => m.EMP_CODE),
                        EMP_NAME = r.Max(m => m.EMP_NAME),
                        ACT_TYPE = r.Max(m => m.ACT_TYPE),
                        MASTER_CAUSE = r.Max(m => m.MASTER_CAUSE),
                        DETAIL_CAUSE = r.Max(m => m.DETAIL_CAUSE),
                        QUANTITY = r.Max(m => m.QUANTITY),
                        NG_TYPE = r.Max(m => m.NG_TYPE),
                        NG_CONTENTS = r.Max(m => m.NG_CONTENTS),
                        NG_CAUSE = r.Max(m => m.NG_CAUSE),
                        NG_MEASURE = r.Max(m => m.NG_MEASURE),
                        NG_STATE = r.Max(m => m.NG_STATE),
                        NG_MAT_COST = r.Max(m => m.NG_MAT_COST),
                        NG_LAB_COST = r.Max(m => m.NG_LAB_COST),
                        NG_DIST_COST = r.Max(m => m.NG_DIST_COST),
                        NG_MEASURE_EMP = r.Max(m => m.NG_MEASURE_EMP),
                        NG_MEASURE_EMP_NAME = r.Max(m => m.NG_MEASURE_EMP_NAME),
                        NG_CAT = r.Max(m => m.NG_CAT),
                        NG_OCCUR = r.Max(m => m.NG_OCCUR),
                        //2020-05-08 외주비용 소재비 제외
                        NG_OUT_COST = r.Max(m => m.NG_OUT_COST).isNullOrEmpty() ? (r.Sum(s => s.OUT_COST.toDecimal()) - r.Max(m => m.NG_MAT_COST)) : r.Max(m => m.NG_OUT_COST.toDecimal()),
                        NG_PROC_COST = r.Max(m => m.NG_PROC_COST).isNullOrEmpty() ? r.Sum(s => s.IN_COST.toDecimal()) : r.Max(m => m.NG_PROC_COST.toDecimal()),
                        NG_COST = r.Max(m => m.NG_COST).isNullOrEmpty() ? r.Sum(s => s.CALC_COST.toDecimal()) : r.Max(m => m.NG_COST.toDecimal()),
                        NG_COST_CODE = r.Max(m => m.NG_COST_CODE),
                        MDFY_DATE = r.Max(m => m.MDFY_DATE),
                        MDFY_EMP = r.Max(m => m.MDFY_EMP),
                        WK_NG_QTY = r.Max(m => m.WK_NG_QTY)
                    }).LINQToDataTable();

                    //외주비용이 소재비를 뺏을 경우 음수이면 0으로 치환
                    foreach(DataRow linqRow in dt.Rows)
                    {
                        if(linqRow["NG_OUT_COST"].toDecimal() < 0)
                        {
                            linqRow["NG_OUT_COST"] = 0;
                        }
                    }

                    dt.Columns.Add("SEL", typeof(string));
                    dt.TableName = "RSLTDT";
                    paramDS.Tables.Add(dt);
                }
                else
                {
                    dtRslt.Columns.Add("SEL", typeof(string));
                    dtRslt.TableName = "RSLTDT";
                    paramDS.Tables.Add(dtRslt);
                }

                //foreach(DataRow row in dtRslt.Rows)
                //{
                //    if (row["NG_PROC_COST"].isNullOrEmpty() && row["NG_OUT_COST"].isNullOrEmpty())
                //    {
                //        DataTable dtNgCost = DSHP.TSHP_NG_QUERY.TSHP_NG_QUERY4(UTIL.GetRowToDt(row), bizExecute);
                //        //foreach (DataRow rowNgCost in dtNgCost.Rows)
                //        //{
                //        //    row["NG_PROC_COST"] = rowNgCost["IN_COST"].toDBDecimal();
                //        //    row["NG_OUT_COST"] = rowNgCost["OUT_COST"].toDBDecimal();
                //        //    row["NG_COST"] = rowNgCost["NG_COST"];
                //        //}
                //    }
                //}

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet QCT01B_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DQCT.TQCT_PURCHASE_NG_QUERY.TQCT_PURCHASE_NG_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                UTIL.SetBizAddColumnToValue(dtRslt, "DATA_FLAG", 0, typeof(Byte), true);
                if (dtRslt.Rows.Count > 0)
                {
                    DataTable dtWo = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY21(dtRslt, bizExecute);

                    DataTable dt = dtRslt.AsEnumerable()
                            .Join(dtWo.AsEnumerable()
                                , wo => wo["NG_ID"]
                                , rslt => rslt["NG_ID"]
                                , (rslt, wo) => new
                                {
                                    NG_ID = rslt.Field<String>("NG_ID"),
                                    TYP_ID = rslt.Field<String>("TYP_ID"),
                                    PLT_CODE = rslt.Field<String>("PLT_CODE"),
                                    BALJU_NUM = rslt.Field<String>("BALJU_NUM"),
                                    BALJU_SEQ = rslt.Field<String>("BALJU_SEQ"),
                                    BALJU_DATE = rslt.Field<String>("BALJU_DATE"),
                                    ITEM_CODE = rslt.Field<String>("ITEM_CODE"),
                                    CVND_CODE = rslt.Field<String>("CVND_CODE"),
                                    CVND_NAME = rslt.Field<String>("CVND_NAME"),
                                    VEN_CODE = rslt.Field<String>("VEN_CODE"),
                                    VEN_NAME = rslt.Field<String>("VEN_NAME"),
                                    PROD_CODE = rslt.Field<String>("PROD_CODE"),
                                    NG_PROD_CODE = rslt.Field<String>("NG_PROD_CODE"),
                                    PART_CODE = rslt.Field<String>("PART_CODE"),
                                    PART_NAME = rslt.Field<String>("PART_NAME"),
                                    PROC_SEQ = rslt["PROC_SEQ"].toDecimal(),
                                    DRAW_NO = rslt.Field<String>("DRAW_NO"),
                                    PROC_CODE = rslt.Field<String>("PROC_CODE"),
                                    PROC_NAME = rslt.Field<String>("PROC_NAME"),
                                    NG_QTY = rslt["NG_QTY"],
                                    BAL_QTY = rslt["BAL_QTY"],
                                    PART_QTY = rslt["PART_QTY"],
                                    WO_NO = rslt.Field<String>("WO_NO"),
                                    EMP_CODE = rslt.Field<String>("EMP_CODE"),
                                    EMP_NAME = rslt.Field<String>("EMP_NAME"),
                                    MASTER_CAUSE = rslt.Field<String>("MASTER_CAUSE"),
                                    DETAIL_CAUSE = rslt.Field<String>("DETAIL_CAUSE"),
                                    NG_TYPE = rslt.Field<String>("NG_TYPE"),
                                    NG_CONTENTS = rslt.Field<String>("NG_CONTENTS"),
                                    NG_CAUSE = rslt.Field<String>("NG_CAUSE"),
                                    NG_MEASURE = rslt.Field<String>("NG_MEASURE"),
                                    NG_COST_CODE = rslt.Field<String>("NG_COST_CODE"),
                                    NG_STATE = rslt.Field<String>("NG_STATE"),
                                    NG_MAT_COST = rslt["NG_MAT_COST"].toDecimal(),
                                    NG_OTHER_OUT_COST = rslt.Field<Decimal>("NG_OTHER_OUT_COST"),
                                    NG_PROC_COST = rslt.Field<Decimal>("NG_PROC_COST"),
                                    NG_THIS_OUT_COST = rslt.Field<Decimal>("NG_THIS_OUT_COST"),
                                    NG_PRE_COST = rslt["NG_PRE_COST"].toDecimal(),
                                    NG_COST = rslt["NG_COST"].toDecimal(),
                                    MAT_WEIGHT = rslt["MAT_WEIGHT"].toDecimal(),
                                    MAT_UNIT = rslt.Field<String>("MAT_UNIT"),
                                    MAT_LTYPE = rslt.Field<String>("MAT_LTYPE"),
                                    PART_PRODTYPE = rslt.Field<String>("PART_PRODTYPE"),
                                    PART_QLTY_NAME = rslt.Field<String>("PART_QLTY_NAME"),
                                    MAT_SPEC = rslt.Field<String>("MAT_SPEC"),
                                    SCOMMENT = rslt.Field<String>("SCOMMENT"),
                                    INS_DATE = rslt.Field<String>("INS_DATE"),
                                    //MDFY_DATE = rslt.Field<DateTime?>("MDFY_DATE"),
                                    //MDFY_EMP = rslt.Field<String>("MDFY_EMP"),
                                    WO_PROC_SEQ = wo["PROC_SEQ"].toDecimal(),
                                    WO_IS_OS = wo.Field<byte>("IS_OS"),
                                    WO_PROC_COST = wo["PROC_COST"].toDecimal(),
                                    CALC_COST = rslt["NG_QTY"].toDecimal() * wo["PROC_COST"].toDecimal(),
                                    IN_COST = wo.Field<byte>("IS_OS") == 0 ? rslt["NG_QTY"].toDecimal() * wo["PROC_COST"].toDecimal() : 0,
                                    OUT_COST = wo.Field<byte>("IS_OS") == 1 ? rslt["NG_QTY"].toDecimal() * wo["PROC_COST"].toDecimal() : 0
                                })
                    .GroupBy(g => new { NG_ID = g.NG_ID })
                    .Select(r => new
                    {
                        PLT_CODE = r.Max(m => m.PLT_CODE),
                        NG_ID = r.Key.NG_ID,
                        TYP_ID = r.Max(m => m.TYP_ID),
                        BALJU_NUM = r.Max(m => m.BALJU_NUM),
                        BALJU_SEQ = r.Max(m => m.BALJU_SEQ),
                        BALJU_DATE = r.Max(m => m.BALJU_DATE),
                        ITEM_CODE = r.Max(m => m.ITEM_CODE),
                        CVND_CODE = r.Max(m => m.CVND_CODE),
                        CVND_NAME = r.Max(m => m.CVND_NAME),
                        VEN_CODE = r.Max(m => m.VEN_CODE),
                        VEN_NAME = r.Max(m => m.VEN_NAME),
                        PROD_CODE = r.Max(m => m.PROD_CODE),
                        NG_PROD_CODE = r.Max(m => m.NG_PROD_CODE),
                        PART_CODE = r.Max(m => m.PART_CODE),
                        PART_NAME = r.Max(m => m.PART_NAME),
                        PROC_SEQ = r.Max(m => m.PROC_SEQ),
                        DRAW_NO = r.Max(m => m.DRAW_NO),
                        PROC_CODE = r.Max(m => m.PROC_CODE),
                        PROC_NAME = r.Max(m => m.PROC_NAME),
                        NG_QTY = r.Max(m => m.NG_QTY),
                        BAL_QTY = r.Max(m => m.BAL_QTY),
                        PART_QTY = r.Max(m => m.PART_QTY),
                        WO_NO = r.Max(m => m.WO_NO),
                        EMP_CODE = r.Max(m => m.EMP_CODE),
                        EMP_NAME = r.Max(m => m.EMP_NAME),
                        MASTER_CAUSE = r.Max(m => m.MASTER_CAUSE),
                        DETAIL_CAUSE = r.Max(m => m.DETAIL_CAUSE),
                        NG_TYPE = r.Max(m => m.NG_TYPE),
                        NG_CONTENTS = r.Max(m => m.NG_CONTENTS),
                        NG_CAUSE = r.Max(m => m.NG_CAUSE),
                        NG_MEASURE = r.Max(m => m.NG_MEASURE),
                        NG_STATE = r.Max(m => m.NG_STATE),
                        MAT_WEIGHT = r.Max(m => m.MAT_WEIGHT),
                        MAT_UNIT = r.Max(m => m.MAT_UNIT),
                        MAT_LTYPE = r.Max(m => m.MAT_LTYPE),
                        PART_PRODTYPE = r.Max(m => m.PART_PRODTYPE),
                        PART_QLTY_NAME = r.Max(m => m.PART_QLTY_NAME),
                        MAT_SPEC = r.Max(m => m.MAT_SPEC),
                        SCOMMENT = r.Max(m => m.SCOMMENT),
                        INS_DATE = r.Max(m => m.INS_DATE),
                        NG_COST_CODE = r.Max(m => m.NG_COST_CODE),
                        WO_PROC_SEQ = r.Max(m => m.WO_PROC_SEQ),
                        WO_IS_OS = r.Max(m => m.WO_IS_OS),
                        WO_PROC_COST = r.Max(m => m.WO_PROC_COST),
                        NG_MAT_COST = r.Max(m => m.NG_MAT_COST),
                        NG_PRE_COST = r.Max(m => m.NG_PRE_COST),
                        //2020-05-08 외주비용 소재비 제외
                        NG_OTHER_OUT_COST = r.Max(m => m.NG_OTHER_OUT_COST).isNullOrEmpty() ? (r.Sum(s => s.PROC_SEQ != s.WO_PROC_SEQ ? s.OUT_COST.toDecimal() : 0) - r.Max(m => m.NG_MAT_COST)) : r.Max(m => m.NG_OTHER_OUT_COST.toDecimal()),
                        NG_THIS_OUT_COST = r.Max(m => m.NG_THIS_OUT_COST).isNullOrEmpty() ? r.Sum(s => s.PROC_SEQ == s.WO_PROC_SEQ ? s.OUT_COST.toDecimal() : 0) : r.Max(m => m.NG_THIS_OUT_COST.toDecimal()),
                        NG_PROC_COST = r.Max(m => m.NG_PROC_COST).isNullOrEmpty() ? r.Sum(s => s.IN_COST.toDecimal()) : r.Max(m => m.NG_PROC_COST.toDecimal()),
                        //NG_COST = r.Max(m => m.NG_COST).isNullOrEmpty() ? r.Sum(s => s.CALC_COST.toDecimal()) : r.Max(m => m.NG_COST.toDecimal()),
                        NG_COST = 0
                        //MDFY_DATE = r.Max(m => m.MDFY_DATE),
                        //MDFY_EMP = r.Max(m => m.MDFY_EMP)
                    }).LINQToDataTable();

                    //외주비용이 소재비를 뺏을 경우 음수이면 0으로 치환
                    foreach (DataRow linqRow in dt.Rows)
                    {
                        if (linqRow["NG_OTHER_OUT_COST"].toDecimal() < 0)
                        {
                            linqRow["NG_OTHER_OUT_COST"] = 0;
                        }

                        linqRow["NG_COST"] = linqRow["NG_MAT_COST"].toDecimal()
                                            + linqRow["NG_PRE_COST"].toDecimal()
                                            + linqRow["NG_OTHER_OUT_COST"].toDecimal()
                                            + linqRow["NG_THIS_OUT_COST"].toDecimal()
                                            + linqRow["NG_PROC_COST"].toDecimal();
                    }
                    
                    dt.Columns.Add("SEL", typeof(string));
                    dt.TableName = "RSLTDT";
                    paramDS.Tables.Add(dt);
                }
                else
                {
                    dtRslt.Columns.Add("SEL", typeof(string));
                    dtRslt.TableName = "RSLTDT";
                    paramDS.Tables.Add(dtRslt);
                }

                //dtRslt.Columns.Add("SEL", typeof(string));
                //dtRslt.TableName = "RSLTDT";

                //paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static DataSet QCT01B_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSHP.TSHP_NG_QUERY.TSHP_NG_QUERY2(paramDS.Tables["RQSTDT"], bizExecute);

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
        /// 사내, 외주 => 공정단가, 실적공수
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet QCT01B_SER4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DLSE.LSE_STD_PARTPROC_QUERY.LSE_STD_PARTPROC_QUERY5(paramDS.Tables["RQSTDT"], bizExecute);

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

        public static DataSet QCT01B_SER5(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                //UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DSTD.TSTD_EMPLOYEE.TSTD_EMPLOYEE_SER6(paramDS.Tables["RQSTDT"], bizExecute);

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
        /// 사내 불량 대책 처리
        /// </summary>
        /// <param name="paramDS"></param>
        /// <param name="bizExecute"></param>
        public static DataSet QCT01B_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtParam = paramDS.Tables["RQSTDT"];

                foreach (DataRow dr in dtParam.Rows)
                {
                    DataTable dtSer = DQCT.TQCT_PURCHASE_NG.TQCT_PURCHASE_NG_SER(UTIL.GetRowToDt(dr), bizExecute);

                    if (dtSer.Rows.Count > 0)
                    {
                        //불량 내용 수정
                        DQCT.TQCT_PURCHASE_NG.TQCT_PURCHASE_NG_UPD(UTIL.GetRowToDt(dr), bizExecute);
                    }
                    else
                    {
                        dr["NG_ID"] = UTIL.UTILITY_GET_SERIALNO(ConnInfo.PLT_CODE, "PNG", UTIL.emSerialFormat.YYMM, "", bizExecute);
                        DataTable dtNG = UTIL.GetRowToDt(dr);
                        DQCT.TQCT_PURCHASE_NG.TQCT_PURCHASE_NG_INS(dtNG, bizExecute);
                    }
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet QCT01B_INS2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtParam = paramDS.Tables["RQSTDT"];
                dtParam.Columns.Add("IS_POP", typeof(Byte));
                //dtParam.Columns.Add("NG_QTY", typeof(Int32));

                foreach (DataRow dr in dtParam.Rows)
                {
                    DataTable dtSer = DSHP.TSHP_NG.TSHP_NG_SER(UTIL.GetRowToDt(dr), bizExecute);

                    if (dtSer.Rows.Count > 0)
                    {
                        //불량 내용 수정
                        DSHP.TSHP_NG.TSHP_NG_UPD(UTIL.GetRowToDt(dr), bizExecute);
                    }
                    else
                    {
                        //사내 불량 추가
                        dr["NG_ID"] = UTIL.UTILITY_GET_SERIALNO(dr["PLT_CODE"].ToString(), "NG", UTIL.emSerialFormat.YYYYMMDD, "", bizExecute);

                        DataTable dtNG = UTIL.GetRowToDt(dr);

                        UTIL.SetBizAddColumnToValue(dtNG, "DATA_FLAG", 0, typeof(Byte));
                        UTIL.SetBizAddColumnToValue(dtNG, "NG_STATE", "W", typeof(String));

                        DSHP.TSHP_NG.TSHP_NG_INS2(dtNG, bizExecute);

                        //해당 작업지시에 불량수량을 더한다.
                        DataTable dtWoRslt = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER(UTIL.GetRowToDt(dr), bizExecute);

                        if (dtWoRslt.Rows.Count > 0)
                        {
                            DataTable woTable = new DataTable("RQSTDT");
                            woTable.Columns.Add("PLT_CODE", typeof(string));
                            woTable.Columns.Add("WO_NO", typeof(string));
                            woTable.Columns.Add("NG_QTY", typeof(int));

                            DataRow woRow = woTable.NewRow();
                            woRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                            woRow["WO_NO"] = dr["WO_NO"];
                            woRow["NG_QTY"] = dtWoRslt.Rows[0]["NG_QTY"].toInt() + dr["QUANTITY"].toInt();
                            woTable.Rows.Add(woRow);

                            DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD39(woTable, bizExecute);
                        }

                        //가공실적에 대해서만 가져온다?
                        //해당 작업지시 마지막 실적에 불량수량 더한다.
                        DataTable dtActRslt = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY33(UTIL.GetRowToDt(dr), bizExecute);

                        if (dtActRslt.Rows.Count > 0)
                        {
                            DataTable actTable = new DataTable("RQSTDT");
                            actTable.Columns.Add("PLT_CODE", typeof(string));
                            actTable.Columns.Add("ACTUAL_ID", typeof(string));
                            actTable.Columns.Add("NG_QTY", typeof(int));

                            DataRow actRow = actTable.NewRow();
                            actRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                            actRow["ACTUAL_ID"] = dtActRslt.Rows[0]["ACTUAL_ID"];
                            actRow["NG_QTY"] = dtActRslt.Rows[0]["NG_QTY"].toInt() + dr["QUANTITY"].toInt();
                            actTable.Rows.Add(actRow);

                            DSHP.TSHP_ACTUAL.TSHP_ACTUAL_UPD9(actTable, bizExecute);
                        }
                        else
                        {
                            ////해당 작업지시에 실적이 없으면 입력 못하게?
                            //throw UTIL.SetException("해당 공정에 실적이 없습니다."
                            //              , new System.Diagnostics.StackFrame().GetMethod().Name
                            //              , BizException.ABORT);
                        }
                    }

                    //if ((dr["NG_TYPE"].ToString() == "P"
                    //    || dr["NG_TYPE"].ToString() == "R"
                    //    || dr["NG_TYPE"].ToString() == "S")
                    //    && 
                    if(dr["EMP_CODE"].ToString() != ""
                    || dr["BUSINESS_EMP"].ToString() != ""
                    || dr["DEV_EMP"].ToString() != "")
                    {
                        DataTable ngNotiTable = new DataTable();
                        ngNotiTable.Columns.Add("PLT_CODE", typeof(string));
                        ngNotiTable.Columns.Add("NG_ID", typeof(string));
                        ngNotiTable.Columns.Add("EMP_CODE", typeof(string));
                        ngNotiTable.Columns.Add("IS_POPUP", typeof(byte));

                        if (dr["EMP_CODE"].ToString() != "")
                        {
                            if (dr["EMP_CODE"].ToString() != ConnInfo.UserID)
                            {
                                DataRow newRow = ngNotiTable.NewRow();
                                newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                                newRow["NG_ID"] = dr["NG_ID"];
                                newRow["EMP_CODE"] = dr["EMP_CODE"];
                                ngNotiTable.Rows.Add(newRow);
                            }
                        }

                        if (dr["BUSINESS_EMP"].ToString() != "")
                        {
                            if (dr["BUSINESS_EMP"].ToString() != ConnInfo.UserID)
                            {
                                DataRow newRow = ngNotiTable.NewRow();
                                newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                                newRow["NG_ID"] = dr["NG_ID"];
                                newRow["EMP_CODE"] = dr["BUSINESS_EMP"];
                                ngNotiTable.Rows.Add(newRow);
                            } 
                        }

                        if (dr["DEV_EMP"].ToString() != "")
                        {
                            if (dr["DEV_EMP"].ToString() != ConnInfo.UserID)
                            {
                                DataRow newRow = ngNotiTable.NewRow();
                                newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                                newRow["NG_ID"] = dr["NG_ID"];
                                newRow["EMP_CODE"] = dr["DEV_EMP"];
                                ngNotiTable.Rows.Add(newRow);
                            }

                            DataTable dtLeader = new DataTable("RQSTDT");
                            dtLeader.Columns.Add("PLT_CODE", typeof(string));
                            dtLeader.Columns.Add("EMP_CODE", typeof(string));

                            DataRow newRow2 = dtLeader.NewRow();
                            newRow2["PLT_CODE"] = ConnInfo.PLT_CODE;
                            newRow2["EMP_CODE"] = dr["DEV_EMP"];
                            dtLeader.Rows.Add(newRow2);

                            DataTable leaderDT = DSTD.TSTD_EMPLOYEE.TSTD_EMPLOYEE_SER(dtLeader, bizExecute);

                            if (leaderDT.Rows.Count > 0)
                            {
                                if (leaderDT.Rows[0]["LEADER_EMP_CODE"].toStringEmpty() != "")
                                {
                                    if (leaderDT.Rows[0]["LEADER_EMP_CODE"].toStringEmpty() != ConnInfo.UserID)
                                    {
                                        DataRow newRow = ngNotiTable.NewRow();
                                        newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                                        newRow["NG_ID"] = dr["NG_ID"];
                                        newRow["EMP_CODE"] = leaderDT.Rows[0]["LEADER_EMP_CODE"];
                                        ngNotiTable.Rows.Add(newRow);
                                    }
                                }
                            }
                        }

                        foreach (DataRow row in ngNotiTable.Rows)
                        {
                            DataTable notiTable = DSHP.TSHP_NG_EMP.TSHP_NG_EMP_SER2(UTIL.GetRowToDt(row), bizExecute);

                            row["IS_POPUP"] = 0;

                            if (notiTable.Rows.Count == 0)
                            {
                                DSHP.TSHP_NG_EMP.TSHP_NG_EMP_INS(UTIL.GetRowToDt(row), bizExecute);
                            }
                            else
                            {
                                DSHP.TSHP_NG_EMP.TSHP_NG_EMP_UPD(UTIL.GetRowToDt(row), bizExecute);
                            }
                        }
                    }


                    ////DataTable dtSum = DSHP.TSHP_NG.TSHP_NG_SER4(dtParam, bizExecute);

                    ////if (dtSum.Rows.Count > 0)
                    ////    dr["NG_QTY"] = dtSum.Rows[0]["TOT_QTY"];
                    ////else
                    ////    dr["NG_QTY"] = 0;

                    ////dr["ACTUAL_ID"] = dr["LINK_KEY"];
                    ////if (dr["ACT_TYPE"].ToString() == "W")
                    ////    DSHP.TSHP_ACTUAL.TSHP_ACTUAL_UPD4(UTIL.GetRowToDt(dr), bizExecute);
                    ////else
                    ////    DSHP.TSHP_MANACTUAL.TSHP_MANACTUAL_UPD2(UTIL.GetRowToDt(dr), bizExecute);

                }

                return QCT01A.QCT01A_SER(paramDS, bizExecute);

            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// 불량 삭제
        /// </summary>
        /// <param name="paramDS">NG_ID</param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet QCT01B_INS3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtParam = paramDS.Tables["RQSTDT"];

                foreach (DataRow row in dtParam.Rows)
                {
                    DataTable dtSer = DSHP.TSHP_NG_QUERY.TSHP_NG_QUERY2(UTIL.GetRowToDt(row), bizExecute);

                    if (dtSer.Rows.Count <= 0)
                    {
                        throw UTIL.SetException("유효하지 않은 데이터"
                                      , row["NG_ID"].ToString()
                                      , new System.Diagnostics.StackFrame().GetMethod().Name
                                      , BizException.UNVALID_DATA);
                    }
                    else
                    {

                        string ngState = dtSer.Rows[0]["NG_STATE"].ToString();

                        if (ngState == "C")     //대책 완료
                        {
                            throw UTIL.SetException("대책 완료 상태는 삭제 불가합니다."
                                      , row["NG_ID"].ToString()
                                      , new System.Diagnostics.StackFrame().GetMethod().Name
                                      , BizException.CANNOT_DELETE);
                        }


                        //불량 내역 삭제
                        DSHP.TSHP_NG.TSHP_NG_DEL(UTIL.GetRowToDt(row), bizExecute);


                        //해당 작업지시에 불량수량을 뺀다.
                        DataTable dtWoRslt = DSHP.TSHP_WORKORDER.TSHP_WORKORDER_SER(UTIL.GetRowToDt(row), bizExecute);

                        if (dtWoRslt.Rows.Count > 0)
                        {
                            DataTable woTable = new DataTable("RQSTDT");
                            woTable.Columns.Add("PLT_CODE", typeof(string));
                            woTable.Columns.Add("WO_NO", typeof(string));
                            woTable.Columns.Add("NG_QTY", typeof(int));

                            DataRow woRow = woTable.NewRow();
                            woRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                            woRow["WO_NO"] = row["WO_NO"];
                            woRow["NG_QTY"] = dtWoRslt.Rows[0]["NG_QTY"].toInt() - row["QUANTITY"].toInt();
                            woTable.Rows.Add(woRow);

                            DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD39(woTable, bizExecute);
                        }

                        //가공실적에 대해서만 가져온다?
                        //해당 작업지시 마지막 실적에 불량수량 뺀다.
                        DataTable dtActRslt = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY33(UTIL.GetRowToDt(row), bizExecute);

                        if (dtActRslt.Rows.Count > 0)
                        {
                            DataTable actTable = new DataTable("RQSTDT");
                            actTable.Columns.Add("PLT_CODE", typeof(string));
                            actTable.Columns.Add("ACTUAL_ID", typeof(string));
                            actTable.Columns.Add("NG_QTY", typeof(int));

                            DataRow actRow = actTable.NewRow();
                            actRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                            actRow["ACTUAL_ID"] = dtActRslt.Rows[0]["ACTUAL_ID"];
                            actRow["NG_QTY"] = dtActRslt.Rows[0]["NG_QTY"].toInt() - row["QUANTITY"].toInt();
                            actTable.Rows.Add(actRow);

                            DSHP.TSHP_ACTUAL.TSHP_ACTUAL_UPD9(actTable, bizExecute);
                        }
                        else
                        {
                            ////해당 작업지시에 실적이 없으면 입력 못하게?
                            //throw UTIL.SetException("해당 공정에 실적이 없습니다."
                            //              , new System.Diagnostics.StackFrame().GetMethod().Name
                            //              , BizException.ABORT);
                        }


                        ////불량 수량 0으로 수정.
                        //if (dtSer.Rows[0]["ACT_TYPE"].ToString() == "W")
                        //    DSHP.TSHP_ACTUAL.TSHP_ACTUAL_UPD4(UTIL.GetRowToDt(row), bizExecute);
                        //else
                        //    DSHP.TSHP_MANACTUAL.TSHP_MANACTUAL_UPD2(UTIL.GetRowToDt(row), bizExecute);

                    }
                }

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        //확정 불량 수량 변경
        public static DataSet QCT01B_INS4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtParam = paramDS.Tables["RQSTDT"];

                foreach (DataRow row in dtParam.Rows)
                {
                    DataTable dtSer = DSHP.TSHP_NG_QUERY.TSHP_NG_QUERY2(UTIL.GetRowToDt(row), bizExecute);

                    if (dtSer.Rows.Count <= 0)
                    {
                        throw UTIL.SetException("유효하지 않은 데이터"
                                      , row["NG_ID"].ToString()
                                      , new System.Diagnostics.StackFrame().GetMethod().Name
                                      , BizException.UNVALID_DATA);
                    }
                    else
                    {
                        //PROD, PART로 마지막 공정 지시 찾기.  TSHP_WORKORDER_QUERY12
                        DataTable dtWoSer = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY12(UTIL.GetRowToDt(row), bizExecute);

                        if (dtWoSer.Rows.Count > 0)
                        {
                            row["WO_NO"] = dtWoSer.Rows[0]["WO_NO"];

                            //작업지시에 불량 수량 증가
                            DSHP.TSHP_WORKORDER.TSHP_WORKORDER_UPD11(UTIL.GetRowToDt(row), bizExecute);
                        }

                        //불량 확정 시 해당 실적 찾아서 양품 수량에서 차감 처리
                        DataTable dtActual = DSHP.TSHP_ACTUAL.TSHP_ACTUAL_SER2(dtSer, bizExecute);

                        if (dtActual.Rows.Count > 0)
                        {
                            dtActual.Rows[0]["OK_QTY"] = dtActual.Rows[0]["OK_QTY"].toInt32() + row["OLD_WK_NG_QTY"].toInt32()
                                    - row["WK_NG_QTY"].toInt32();

                            DSHP.TSHP_ACTUAL.TSHP_ACTUAL_UPD5(dtActual, bizExecute);

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

        /// <summary>
        /// 외주 불량 삭제
        /// </summary>
        /// <param name="paramDS">NG_ID</param>
        /// <param name="bizExecute"></param>
        /// <returns></returns>
        public static DataSet QCT01B_INS5(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtParam = paramDS.Tables["RQSTDT"];

                foreach (DataRow row in dtParam.Rows)
                {
                    DataTable dtSer = DQCT.TQCT_PURCHASE_NG.TQCT_PURCHASE_NG_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (dtSer.Rows.Count <= 0)
                    {
                        throw UTIL.SetException("유효하지 않은 데이터"
                                      , row["NG_ID"].ToString()
                                      , new System.Diagnostics.StackFrame().GetMethod().Name
                                      , BizException.UNVALID_DATA);
                    }
                    else
                    {
                        //불량 내역 삭제
                        DQCT.TQCT_PURCHASE_NG.TQCT_PURCHASE_NG_UDE(UTIL.GetRowToDt(row), bizExecute);

                        //불량 수량 0으로 수정.
                        //if (dtSer.Rows[0]["ACT_TYPE"].ToString() == "W")
                        //    DSHP.TSHP_ACTUAL.TSHP_ACTUAL_UPD4(UTIL.GetRowToDt(row), bizExecute);
                        //else
                        //    DSHP.TSHP_MANACTUAL.TSHP_MANACTUAL_UPD2(UTIL.GetRowToDt(row), bizExecute);

                    }
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
