using BizExecute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMNT
{
    public class MNT06A
    {
        public static DataSet MNT06A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(byte));

                DataTable dt = new DataTable("RSLTDT");
                dt.Columns.Add("PLT_CODE", typeof(string));
                dt.Columns.Add("DATA1", typeof(string));
                dt.Columns.Add("DATA2", typeof(decimal));
                dt.Columns.Add("DATA3", typeof(decimal));
                dt.Columns.Add("DATA4", typeof(decimal));
                dt.Columns.Add("DATA5", typeof(decimal));
                dt.Columns.Add("DATA6", typeof(decimal));
                dt.Columns.Add("DATA7", typeof(decimal));

                dt.Columns.Add("DATA8", typeof(decimal));
                dt.Columns.Add("DATA9", typeof(decimal));
                dt.Columns.Add("DATA10", typeof(decimal));
                dt.Columns.Add("DATA11", typeof(decimal));
                dt.Columns.Add("DATA12", typeof(decimal));
                dt.Columns.Add("DATA13", typeof(decimal));
                dt.Columns.Add("DATA14", typeof(decimal));

                DataRow row = dt.NewRow();
                row["PLT_CODE"] = ConnInfo.PLT_CODE;
                row["DATA1"] = 0;
                row["DATA2"] = 0;
                row["DATA3"] = 0;
                row["DATA4"] = 0;
                row["DATA5"] = 0;
                row["DATA6"] = 0;
                row["DATA7"] = 0;
                row["DATA8"] = 0;
                row["DATA9"] = 0;
                row["DATA10"] = 0;
                row["DATA11"] = 0;
                row["DATA12"] = 0;
                row["DATA13"] = 0;
                row["DATA14"] = 0;

                //매입현황
                DataTable dtypgoRslt = DMAT.TMAT_YPGO_QUERY.TMAT_YPGO_QUERY8(paramDS.Tables["RQSTDT"], bizExecute);

                if (dtypgoRslt.Rows.Count > 0)
                {
                    row["DATA1"] = dtypgoRslt.Compute("SUM(AMT)", "");
                }

                //매출현황
                DataTable dtRslt2 = DORD.TORD_PRODUCT_QUERY.TORD_PRODUCT_QUERY16(paramDS.Tables["RQSTDT"], bizExecute);
                if (dtRslt2.Rows.Count > 0)
                {
                    row["DATA2"] = dtRslt2.Compute("SUM(PROD_AMT)", "");
                }

                //수주현황
                DataTable dtRslt3 = DORD.TORD_PRODUCT_QUERY.TORD_PRODUCT_QUERY28(paramDS.Tables["RQSTDT"], bizExecute);
                if (dtRslt3.Rows.Count > 0)
                {
                    row["DATA3"] = dtRslt3.Compute("SUM(PROD_CNT)", "");
                }

                //출하실적
                DataTable dtRslt4 = DORD.TORD_SHIP_QUERY.TORD_SHIP_QUERY14(paramDS.Tables["RQSTDT"], bizExecute);
                if (dtRslt4.Rows.Count > 0)
                {
                    row["DATA4"] = dtRslt4.Compute("SUM(PROD_CNT)", "");
                }

                DataTable dtRslt5 = DORD.TORD_PRODUCT_QUERY.TORD_PRODUCT_QUERY22_2(paramDS.Tables["RQSTDT"], bizExecute);
                
                if (dtRslt5.Rows.Count > 0)
                {
                    //재고금액
                    row["DATA5"] = dtRslt5.Compute("SUM(PROD_AMT)", "STK > 0").toDecimal();

                    //재공금액
                    row["DATA6"] = dtRslt5.Compute("SUM(PROD_AMT)", "WIP > 0").toDecimal();
                }

                //클레임율
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "YEAR", paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(0,4), typeof(string));
                DataTable dtShipRslt = DORD.TORD_PRODUCT_QUERY.TORD_PRODUCT_QUERY20(paramDS.Tables["RQSTDT"], bizExecute);
                DataTable dtAsRslt = DORD.TORD_PRODUCT_QUERY.TORD_PRODUCT_QUERY21(paramDS.Tables["RQSTDT"], bizExecute);
                DataTable dtGoal = DSTD.TSTD_AS_GOAL.TSTD_AS_GOAL_SER2(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable cloneTable = new DataTable();
                cloneTable.Columns.Add("PLT_CODE", typeof(String));
                cloneTable.Columns.Add("FLAG", typeof(String));
                cloneTable.Columns.Add("TYPE", typeof(String));
                cloneTable.Columns.Add("WORK_1", typeof(decimal));
                cloneTable.Columns.Add("WORK_2", typeof(decimal));
                cloneTable.Columns.Add("WORK_3", typeof(decimal));
                cloneTable.Columns.Add("WORK_4", typeof(decimal));
                cloneTable.Columns.Add("WORK_5", typeof(decimal));
                cloneTable.Columns.Add("WORK_6", typeof(decimal));
                cloneTable.Columns.Add("WORK_7", typeof(decimal));
                cloneTable.Columns.Add("WORK_8", typeof(decimal));
                cloneTable.Columns.Add("WORK_9", typeof(decimal));
                cloneTable.Columns.Add("WORK_10", typeof(decimal));
                cloneTable.Columns.Add("WORK_11", typeof(decimal));
                cloneTable.Columns.Add("WORK_12", typeof(decimal));
                cloneTable.Columns.Add("WORK_SUM", typeof(decimal));
                cloneTable.Columns.Add("WORK_RATE", typeof(decimal));

                DataTable ngTable1 = claimType1(cloneTable, dtShipRslt, dtAsRslt, dtGoal);
                ngTable1.TableName = "RSLTDT";

                DataRow[] rows = ngTable1.Select("FLAG = 'RATE'");
                if (rows.Length > 0)
                {
                    if (paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(4, 2) == "01") row["DATA7"] = rows[0]["WORK_1"].ToString().Replace("%", "");
                    if (paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(4, 2) == "02") row["DATA7"] = rows[0]["WORK_2"].ToString().Replace("%", "");
                    if (paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(4, 2) == "03") row["DATA7"] = rows[0]["WORK_3"].ToString().Replace("%", "");
                    if (paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(4, 2) == "04") row["DATA7"] = rows[0]["WORK_4"].ToString().Replace("%", "");
                    if (paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(4, 2) == "05") row["DATA7"] = rows[0]["WORK_5"].ToString().Replace("%", "");
                    if (paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(4, 2) == "06") row["DATA7"] = rows[0]["WORK_6"].ToString().Replace("%", "");
                    if (paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(4, 2) == "07") row["DATA7"] = rows[0]["WORK_7"].ToString().Replace("%", "");
                    if (paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(4, 2) == "08") row["DATA7"] = rows[0]["WORK_8"].ToString().Replace("%", "");
                    if (paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(4, 2) == "09") row["DATA7"] = rows[0]["WORK_9"].ToString().Replace("%", "");
                    if (paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(4, 2) == "10") row["DATA7"] = rows[0]["WORK_10"].ToString().Replace("%", "");
                    if (paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(4, 2) == "11") row["DATA7"] = rows[0]["WORK_11"].ToString().Replace("%", "");
                    if (paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(4, 2) == "12") row["DATA7"] = rows[0]["WORK_12"].ToString().Replace("%", "");
                }


                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                DataTable dt3 = new DataTable();

                dev(out dt1, out dt2, out dt3, paramDS, bizExecute);
                //개발현황(소켓기준)
                DataRow[] rows2 = dt1.Select("FLAG = 'TOTAL'");
                if (rows2.Length > 0)
                {
                    if (paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(4, 2) == "01") row["DATA8"] = rows2[0]["WORK_1"];
                    if (paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(4, 2) == "02") row["DATA8"] = rows2[0]["WORK_2"];
                    if (paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(4, 2) == "03") row["DATA8"] = rows2[0]["WORK_3"];
                    if (paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(4, 2) == "04") row["DATA8"] = rows2[0]["WORK_4"];
                    if (paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(4, 2) == "05") row["DATA8"] = rows2[0]["WORK_5"];
                    if (paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(4, 2) == "06") row["DATA8"] = rows2[0]["WORK_6"];
                    if (paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(4, 2) == "07") row["DATA8"] = rows2[0]["WORK_7"];
                    if (paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(4, 2) == "08") row["DATA8"] = rows2[0]["WORK_8"];
                    if (paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(4, 2) == "09") row["DATA8"] = rows2[0]["WORK_9"];
                    if (paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(4, 2) == "10") row["DATA8"] = rows2[0]["WORK_10"];
                    if (paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(4, 2) == "11") row["DATA8"] = rows2[0]["WORK_11"];
                    if (paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(4, 2) == "12") row["DATA8"] = rows2[0]["WORK_12"];
                }

                //출도현황(부품기준)
                DataRow[] rows3 = dt3.Select("FLAG = 'TOTAL'");
                if (rows3.Length > 0)
                {
                    if (paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(4, 2) == "01") row["DATA9"] = rows3[0]["WORK_1"];
                    if (paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(4, 2) == "02") row["DATA9"] = rows3[0]["WORK_2"];
                    if (paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(4, 2) == "03") row["DATA9"] = rows3[0]["WORK_3"];
                    if (paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(4, 2) == "04") row["DATA9"] = rows3[0]["WORK_4"];
                    if (paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(4, 2) == "05") row["DATA9"] = rows3[0]["WORK_5"];
                    if (paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(4, 2) == "06") row["DATA9"] = rows3[0]["WORK_6"];
                    if (paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(4, 2) == "07") row["DATA9"] = rows3[0]["WORK_7"];
                    if (paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(4, 2) == "08") row["DATA9"] = rows3[0]["WORK_8"];
                    if (paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(4, 2) == "09") row["DATA9"] = rows3[0]["WORK_9"];
                    if (paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(4, 2) == "10") row["DATA9"] = rows3[0]["WORK_10"];
                    if (paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(4, 2) == "11") row["DATA9"] = rows3[0]["WORK_11"];
                    if (paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(4, 2) == "12") row["DATA9"] = rows3[0]["WORK_12"];

                    //작업지시현황(부품기준)
                    if (paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(4, 2) == "01") row["DATA10"] = rows3[0]["WORK_1"];
                    if (paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(4, 2) == "02") row["DATA10"] = rows3[0]["WORK_2"];
                    if (paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(4, 2) == "03") row["DATA10"] = rows3[0]["WORK_3"];
                    if (paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(4, 2) == "04") row["DATA10"] = rows3[0]["WORK_4"];
                    if (paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(4, 2) == "05") row["DATA10"] = rows3[0]["WORK_5"];
                    if (paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(4, 2) == "06") row["DATA10"] = rows3[0]["WORK_6"];
                    if (paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(4, 2) == "07") row["DATA10"] = rows3[0]["WORK_7"];
                    if (paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(4, 2) == "08") row["DATA10"] = rows3[0]["WORK_8"];
                    if (paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(4, 2) == "09") row["DATA10"] = rows3[0]["WORK_9"];
                    if (paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(4, 2) == "10") row["DATA10"] = rows3[0]["WORK_10"];
                    if (paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(4, 2) == "11") row["DATA10"] = rows3[0]["WORK_11"];
                    if (paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(4, 2) == "12") row["DATA10"] = rows3[0]["WORK_12"];
                }

                //가공실적(부품기준)
                DataTable dtRslt11 = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY35(paramDS.Tables["RQSTDT"], bizExecute);
                if (dtRslt11.Rows.Count > 0)
                {
                    row["DATA11"] = dtRslt11.Compute("SUM(OK_QTY)", "");
                }

                //조립실적(소켓기준)
                DataTable dtRslt12 = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY45(paramDS.Tables["RQSTDT"], bizExecute);
                if (dtRslt12.Rows.Count > 0)
                {
                    row["DATA12"] = dtRslt12.Compute("SUM(PROD_CNT)", "");
                }

                //불량현황
                DataTable ngTable = ngRate(paramDS, bizExecute);

                foreach (DataRow ngRow in ngTable.Rows)
                {
                    if (ngRow["MONTH_FLAG"].ToString() == paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(4, 2))
                    {
                        row["DATA13"] = ngRow["N_RATE"].toDecimal() * 100;
                    }
                }

                //인원현황
                DataTable dtRslt14 = DSTD.TSTD_EMPLOYEE_QUERY.TSTD_EMPLOYEE_QUERY10(paramDS.Tables["RQSTDT"], bizExecute);
                if (dtRslt14.Rows.Count > 0)
                {
                    row["DATA14"] = dtRslt14.Compute("SUM(EMP_CNT)", "");
                }


                dt.Rows.Add(row);

                paramDS.Tables.Add(dt);


                //매입현황(차트)
                DataTable conTable = new DataTable();
                UTIL.SetBizAddColumnToValue(conTable, "PLT_CODE", ConnInfo.PLT_CODE, typeof(byte));
                UTIL.SetBizAddColumnToValue(conTable, "WORK_YEAR", paramDS.Tables["RQSTDT"].Rows[0]["S_MONTH"].ToString().Substring(0, 4), typeof(string));
                UTIL.SetBizAddColumnToValue(conTable, "DATA_FLAG", 0, typeof(byte));

                DataTable dtRslt = DORD.TORD_PRODUCT_QUERY.TORD_PRODUCT_QUERY16(conTable, bizExecute);

                DataTable groupDt = dtRslt.AsEnumerable()
                                        .GroupBy(g => new
                                        {
                                            PLT_CODE = g["PLT_CODE"],
                                            WORK_MONTH = g["BILL_DATE"].toDateString("MM"),
                                            GUBUN = g["BVEN_TYPE"],
                                            CURR_UNIT = g["CURR_UNIT"]
                                        })
                                        .Select(r => new
                                        {
                                            PLT_CODE = r.Key.PLT_CODE,
                                            WORK_MONTH = r.Key.WORK_MONTH,
                                            GUBUN = r.Key.GUBUN,
                                            CURR_UNIT = r.Key.CURR_UNIT,
                                            PROD_AMT = r.Sum(s => s["PROD_AMT"].toDecimal()),
                                        })
                                        .GroupBy(g => new
                                        {
                                            PLT_CODE = g.PLT_CODE,
                                            GUBUN = g.GUBUN,
                                            CURR_UNIT = g.CURR_UNIT

                                        })
                                        .Select(r => new
                                        {
                                            PLT_CODE = r.Key.PLT_CODE,
                                            //GUBUN = "국내",
                                            GUBUN = r.Key.GUBUN,
                                            CURR_UNIT = r.Key.CURR_UNIT,

                                            JAN = (r.Where(w => w.WORK_MONTH == "01").Sum(s => s.PROD_AMT)),
                                            FEB = (r.Where(w => w.WORK_MONTH == "02").Sum(s => s.PROD_AMT)),
                                            MAR = (r.Where(w => w.WORK_MONTH == "03").Sum(s => s.PROD_AMT)),
                                            APR = (r.Where(w => w.WORK_MONTH == "04").Sum(s => s.PROD_AMT)),
                                            MAY = (r.Where(w => w.WORK_MONTH == "05").Sum(s => s.PROD_AMT)),
                                            JUN = (r.Where(w => w.WORK_MONTH == "06").Sum(s => s.PROD_AMT)),
                                            JUL = (r.Where(w => w.WORK_MONTH == "07").Sum(s => s.PROD_AMT)),
                                            AUG = (r.Where(w => w.WORK_MONTH == "08").Sum(s => s.PROD_AMT)),
                                            SEP = (r.Where(w => w.WORK_MONTH == "09").Sum(s => s.PROD_AMT)),
                                            OCT = (r.Where(w => w.WORK_MONTH == "10").Sum(s => s.PROD_AMT)),
                                            NOV = (r.Where(w => w.WORK_MONTH == "11").Sum(s => s.PROD_AMT)),
                                            DEC = (r.Where(w => w.WORK_MONTH == "12").Sum(s => s.PROD_AMT)),
                                            TOTAL = r.Sum(s => s.PROD_AMT)


                                        })
                                        .LINQToDataTable();

                groupDt.TableName = "RSLTDT_CHART1";
                paramDS.Tables.Add(groupDt);

                //매출현황 차트
                DataTable dtypgoRslt2 = DMAT.TMAT_YPGO_QUERY.TMAT_YPGO_QUERY7(paramDS.Tables["RQSTDT"], bizExecute);
                DataTable cloneTable2 = new DataTable();
                cloneTable2.Columns.Add("PLT_CODE", typeof(String));
                cloneTable2.Columns.Add("FLAG", typeof(String));
                cloneTable2.Columns.Add("TYPE", typeof(String));
                cloneTable2.Columns.Add("WORK_1", typeof(decimal));
                cloneTable2.Columns.Add("WORK_2", typeof(decimal));
                cloneTable2.Columns.Add("WORK_3", typeof(decimal));
                cloneTable2.Columns.Add("WORK_4", typeof(decimal));
                cloneTable2.Columns.Add("WORK_5", typeof(decimal));
                cloneTable2.Columns.Add("WORK_6", typeof(decimal));
                cloneTable2.Columns.Add("WORK_7", typeof(decimal));
                cloneTable2.Columns.Add("WORK_8", typeof(decimal));
                cloneTable2.Columns.Add("WORK_9", typeof(decimal));
                cloneTable2.Columns.Add("WORK_10", typeof(decimal));
                cloneTable2.Columns.Add("WORK_11", typeof(decimal));
                cloneTable2.Columns.Add("WORK_12", typeof(decimal));
                cloneTable2.Columns.Add("WORK_SUM", typeof(decimal));
                cloneTable2.Columns.Add("WORK_RATE", typeof(decimal));

                cloneTable2.Columns.Add("WORK_1_R", typeof(decimal));
                cloneTable2.Columns.Add("WORK_2_R", typeof(decimal));
                cloneTable2.Columns.Add("WORK_3_R", typeof(decimal));
                cloneTable2.Columns.Add("WORK_4_R", typeof(decimal));
                cloneTable2.Columns.Add("WORK_5_R", typeof(decimal));
                cloneTable2.Columns.Add("WORK_6_R", typeof(decimal));
                cloneTable2.Columns.Add("WORK_7_R", typeof(decimal));
                cloneTable2.Columns.Add("WORK_8_R", typeof(decimal));
                cloneTable2.Columns.Add("WORK_9_R", typeof(decimal));
                cloneTable2.Columns.Add("WORK_10_R", typeof(decimal));
                cloneTable2.Columns.Add("WORK_11_R", typeof(decimal));
                cloneTable2.Columns.Add("WORK_12_R", typeof(decimal));

                DataTable ypgoTable1 = ypgoType1(cloneTable2, dtypgoRslt2);
                ypgoTable1.TableName = "RSLTDT_CHART2";
                paramDS.Tables.Add(ypgoTable1);


                //가공및 검사실적(차트)
                DataTable cloneTable3 = new DataTable();
                cloneTable3.Columns.Add("PLT_CODE", typeof(String));
                cloneTable3.Columns.Add("TYPE_CODE", typeof(String));
                cloneTable3.Columns.Add("TYPE_NAME", typeof(String));
                cloneTable3.Columns.Add("FLAG", typeof(String));
                cloneTable3.Columns.Add("WORK_1", typeof(decimal));
                cloneTable3.Columns.Add("WORK_2", typeof(decimal));
                cloneTable3.Columns.Add("WORK_3", typeof(decimal));
                cloneTable3.Columns.Add("WORK_4", typeof(decimal));
                cloneTable3.Columns.Add("WORK_5", typeof(decimal));
                cloneTable3.Columns.Add("WORK_6", typeof(decimal));
                cloneTable3.Columns.Add("WORK_7", typeof(decimal));
                cloneTable3.Columns.Add("WORK_8", typeof(decimal));
                cloneTable3.Columns.Add("WORK_9", typeof(decimal));
                cloneTable3.Columns.Add("WORK_10", typeof(decimal));
                cloneTable3.Columns.Add("WORK_11", typeof(decimal));
                cloneTable3.Columns.Add("WORK_12", typeof(decimal));
                cloneTable3.Columns.Add("WORK_SUM", typeof(decimal));

                DataTable dtRsltchart3 = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY7(paramDS.Tables["RQSTDT"], bizExecute);

                DataRow[] mctRows = dtRsltchart3.Select("MCT_ACT_QTY IS NOT NULL");

                DataTable gridTable = cloneTable3.Clone();
                DataRow newRow = gridTable.NewRow();
                newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                newRow["TYPE_CODE"] = "MCT";
                newRow["TYPE_NAME"] = "MCT 실적";
                newRow["FLAG"] = "MCT";

                newRow["WORK_1"] = 0;
                newRow["WORK_2"] = 0;
                newRow["WORK_3"] = 0;
                newRow["WORK_4"] = 0;
                newRow["WORK_5"] = 0;
                newRow["WORK_6"] = 0;
                newRow["WORK_7"] = 0;
                newRow["WORK_8"] = 0;
                newRow["WORK_9"] = 0;
                newRow["WORK_10"] = 0;
                newRow["WORK_11"] = 0;
                newRow["WORK_12"] = 0;
                newRow["WORK_SUM"] = 0;



                if (mctRows.Length > 0)
                {
                    newRow["WORK_1"] = mctRows.CopyToDataTable().Compute("SUM(MCT_ACT_QTY)", "MCT_ACT_END_MONTH = 202201 AND PROC_CODE = 'P-04'").toInt();
                    newRow["WORK_2"] = mctRows.CopyToDataTable().Compute("SUM(MCT_ACT_QTY)", "MCT_ACT_END_MONTH = 202202 AND PROC_CODE = 'P-04'").toInt();
                    newRow["WORK_3"] = mctRows.CopyToDataTable().Compute("SUM(MCT_ACT_QTY)", "MCT_ACT_END_MONTH = 202203 AND PROC_CODE = 'P-04'").toInt();
                    newRow["WORK_4"] = mctRows.CopyToDataTable().Compute("SUM(MCT_ACT_QTY)", "MCT_ACT_END_MONTH = 202204 AND PROC_CODE = 'P-04'").toInt();
                    newRow["WORK_5"] = mctRows.CopyToDataTable().Compute("SUM(MCT_ACT_QTY)", "MCT_ACT_END_MONTH = 202205 AND PROC_CODE = 'P-04'").toInt();
                    newRow["WORK_6"] = mctRows.CopyToDataTable().Compute("SUM(MCT_ACT_QTY)", "MCT_ACT_END_MONTH = 202206 AND PROC_CODE = 'P-04'").toInt();
                    newRow["WORK_7"] = mctRows.CopyToDataTable().Compute("SUM(MCT_ACT_QTY)", "MCT_ACT_END_MONTH = 202207 AND PROC_CODE = 'P-04'").toInt();
                    newRow["WORK_8"] = mctRows.CopyToDataTable().Compute("SUM(MCT_ACT_QTY)", "MCT_ACT_END_MONTH = 202208 AND PROC_CODE = 'P-04'").toInt();
                    newRow["WORK_9"] = mctRows.CopyToDataTable().Compute("SUM(MCT_ACT_QTY)", "MCT_ACT_END_MONTH = 202209 AND PROC_CODE = 'P-04'").toInt();
                    newRow["WORK_10"] = mctRows.CopyToDataTable().Compute("SUM(MCT_ACT_QTY)", "MCT_ACT_END_MONTH = 202210 AND PROC_CODE = 'P-04'").toInt();
                    newRow["WORK_11"] = mctRows.CopyToDataTable().Compute("SUM(MCT_ACT_QTY)", "MCT_ACT_END_MONTH = 202211 AND PROC_CODE = 'P-04'").toInt();
                    newRow["WORK_12"] = mctRows.CopyToDataTable().Compute("SUM(MCT_ACT_QTY)", "MCT_ACT_END_MONTH = 202212 AND PROC_CODE = 'P-04'").toInt();

                    double aSum = newRow["WORK_1"].toDouble() + newRow["WORK_2"].toDouble() + newRow["WORK_3"].toDouble() + newRow["WORK_4"].toDouble()
                                + newRow["WORK_5"].toDouble() + newRow["WORK_6"].toDouble() + newRow["WORK_7"].toDouble() + newRow["WORK_8"].toDouble()
                                + newRow["WORK_9"].toDouble() + newRow["WORK_10"].toDouble() + newRow["WORK_11"].toDouble() + newRow["WORK_12"].toDouble();

                    newRow["WORK_SUM"] = aSum;
                }


                gridTable.Rows.Add(newRow);


                newRow = gridTable.NewRow();
                newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                newRow["TYPE_CODE"] = "OUT";
                newRow["TYPE_NAME"] = "외주가공 실적";
                newRow["FLAG"] = "OUT";

                newRow["WORK_1"] = 0;
                newRow["WORK_2"] = 0;
                newRow["WORK_3"] = 0;
                newRow["WORK_4"] = 0;
                newRow["WORK_5"] = 0;
                newRow["WORK_6"] = 0;
                newRow["WORK_7"] = 0;
                newRow["WORK_8"] = 0;
                newRow["WORK_9"] = 0;
                newRow["WORK_10"] = 0;
                newRow["WORK_11"] = 0;
                newRow["WORK_12"] = 0;
                newRow["WORK_SUM"] = 0;



                if (mctRows.Length > 0)
                {
                    newRow["WORK_1"] = mctRows.CopyToDataTable().Compute("SUM(OUT_ACT_QTY)", "MCT_ACT_END_MONTH = 202201 AND PROC_CODE = 'P14'").toInt();
                    newRow["WORK_2"] = mctRows.CopyToDataTable().Compute("SUM(OUT_ACT_QTY)", "MCT_ACT_END_MONTH = 202202 AND PROC_CODE = 'P14'").toInt();
                    newRow["WORK_3"] = mctRows.CopyToDataTable().Compute("SUM(OUT_ACT_QTY)", "MCT_ACT_END_MONTH = 202203 AND PROC_CODE = 'P14'").toInt();
                    newRow["WORK_4"] = mctRows.CopyToDataTable().Compute("SUM(OUT_ACT_QTY)", "MCT_ACT_END_MONTH = 202204 AND PROC_CODE = 'P14'").toInt();
                    newRow["WORK_5"] = mctRows.CopyToDataTable().Compute("SUM(OUT_ACT_QTY)", "MCT_ACT_END_MONTH = 202205 AND PROC_CODE = 'P14'").toInt();
                    newRow["WORK_6"] = mctRows.CopyToDataTable().Compute("SUM(OUT_ACT_QTY)", "MCT_ACT_END_MONTH = 202206 AND PROC_CODE = 'P14'").toInt();
                    newRow["WORK_7"] = mctRows.CopyToDataTable().Compute("SUM(OUT_ACT_QTY)", "MCT_ACT_END_MONTH = 202207 AND PROC_CODE = 'P14'").toInt();
                    newRow["WORK_8"] = mctRows.CopyToDataTable().Compute("SUM(OUT_ACT_QTY)", "MCT_ACT_END_MONTH = 202208 AND PROC_CODE = 'P14'").toInt();
                    newRow["WORK_9"] = mctRows.CopyToDataTable().Compute("SUM(OUT_ACT_QTY)", "MCT_ACT_END_MONTH = 202209 AND PROC_CODE = 'P14'").toInt();
                    newRow["WORK_10"] = mctRows.CopyToDataTable().Compute("SUM(OUT_ACT_QTY)", "MCT_ACT_END_MONTH = 202210 AND PROC_CODE = 'P14'").toInt();
                    newRow["WORK_11"] = mctRows.CopyToDataTable().Compute("SUM(OUT_ACT_QTY)", "MCT_ACT_END_MONTH = 202211 AND PROC_CODE = 'P14'").toInt();
                    newRow["WORK_12"] = mctRows.CopyToDataTable().Compute("SUM(OUT_ACT_QTY)", "MCT_ACT_END_MONTH = 202212 AND PROC_CODE = 'P14'").toInt();

                    double aSum = newRow["WORK_1"].toDouble() + newRow["WORK_2"].toDouble() + newRow["WORK_3"].toDouble() + newRow["WORK_4"].toDouble()
                                + newRow["WORK_5"].toDouble() + newRow["WORK_6"].toDouble() + newRow["WORK_7"].toDouble() + newRow["WORK_8"].toDouble()
                                + newRow["WORK_9"].toDouble() + newRow["WORK_10"].toDouble() + newRow["WORK_11"].toDouble() + newRow["WORK_12"].toDouble();

                    newRow["WORK_SUM"] = aSum;
                }


                gridTable.Rows.Add(newRow);



                DataRow[] insRows = dtRsltchart3.Select("INS_ACT_QTY IS NOT NULL");

                DataRow newRow2 = gridTable.NewRow();
                newRow2["PLT_CODE"] = ConnInfo.PLT_CODE;
                newRow2["TYPE_CODE"] = "INS";
                newRow2["TYPE_NAME"] = "중간검사 실적";
                newRow2["FLAG"] = "INS";

                newRow2["WORK_1"] = 0;
                newRow2["WORK_2"] = 0;
                newRow2["WORK_3"] = 0;
                newRow2["WORK_4"] = 0;
                newRow2["WORK_5"] = 0;
                newRow2["WORK_6"] = 0;
                newRow2["WORK_7"] = 0;
                newRow2["WORK_8"] = 0;
                newRow2["WORK_9"] = 0;
                newRow2["WORK_10"] = 0;
                newRow2["WORK_11"] = 0;
                newRow2["WORK_12"] = 0;
                newRow2["WORK_SUM"] = 0;



                if (mctRows.Length > 0)
                {
                    newRow2["WORK_1"] = insRows.CopyToDataTable().Compute("SUM(INS_ACT_QTY)", "INS_ACT_END_MONTH = 202201").toInt();
                    newRow2["WORK_2"] = insRows.CopyToDataTable().Compute("SUM(INS_ACT_QTY)", "INS_ACT_END_MONTH = 202202").toInt();
                    newRow2["WORK_3"] = insRows.CopyToDataTable().Compute("SUM(INS_ACT_QTY)", "INS_ACT_END_MONTH = 202203").toInt();
                    newRow2["WORK_4"] = insRows.CopyToDataTable().Compute("SUM(INS_ACT_QTY)", "INS_ACT_END_MONTH = 202204").toInt();
                    newRow2["WORK_5"] = insRows.CopyToDataTable().Compute("SUM(INS_ACT_QTY)", "INS_ACT_END_MONTH = 202205").toInt();
                    newRow2["WORK_6"] = insRows.CopyToDataTable().Compute("SUM(INS_ACT_QTY)", "INS_ACT_END_MONTH = 202206").toInt();
                    newRow2["WORK_7"] = insRows.CopyToDataTable().Compute("SUM(INS_ACT_QTY)", "INS_ACT_END_MONTH = 202207").toInt();
                    newRow2["WORK_8"] = insRows.CopyToDataTable().Compute("SUM(INS_ACT_QTY)", "INS_ACT_END_MONTH = 202208").toInt();
                    newRow2["WORK_9"] = insRows.CopyToDataTable().Compute("SUM(INS_ACT_QTY)", "INS_ACT_END_MONTH = 202209").toInt();
                    newRow2["WORK_10"] = insRows.CopyToDataTable().Compute("SUM(INS_ACT_QTY)", "INS_ACT_END_MONTH = 202210").toInt();
                    newRow2["WORK_11"] = insRows.CopyToDataTable().Compute("SUM(INS_ACT_QTY)", "INS_ACT_END_MONTH = 202211").toInt();
                    newRow2["WORK_12"] = insRows.CopyToDataTable().Compute("SUM(INS_ACT_QTY)", "INS_ACT_END_MONTH = 202212").toInt();

                    double aSum = newRow2["WORK_1"].toDouble() + newRow2["WORK_2"].toDouble() + newRow2["WORK_3"].toDouble() + newRow2["WORK_4"].toDouble()
                                + newRow2["WORK_5"].toDouble() + newRow2["WORK_6"].toDouble() + newRow2["WORK_7"].toDouble() + newRow2["WORK_8"].toDouble()
                                + newRow2["WORK_9"].toDouble() + newRow2["WORK_10"].toDouble() + newRow2["WORK_11"].toDouble() + newRow2["WORK_12"].toDouble();

                    newRow2["WORK_SUM"] = aSum;
                }


                gridTable.Rows.Add(newRow2);

                gridTable.TableName = "RSLTDT_CHART3";
                paramDS.Tables.Add(gridTable);


                ngTable.TableName = "RSLTDT_CHART4";
                paramDS.Tables.Add(ngTable);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        static DataTable claimType1(DataTable cloneTable, DataTable dtShipRslt, DataTable dtAsRslt, DataTable dtGoal)
        {

            DataTable gridTable = cloneTable.Clone();

            DataRow newRow = gridTable.NewRow();
            newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
            newRow["FLAG"] = "SHIP";
            newRow["TYPE"] = "납품건수";
            gridTable.Rows.Add(newRow);

            newRow = gridTable.NewRow();
            newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
            newRow["FLAG"] = "NG";
            newRow["TYPE"] = "발생건수";
            gridTable.Rows.Add(newRow);

            newRow = gridTable.NewRow();
            newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
            newRow["FLAG"] = "RATE";
            newRow["TYPE"] = "Claim율";
            gridTable.Rows.Add(newRow);

            newRow = gridTable.NewRow();
            newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
            newRow["FLAG"] = "GOAL";
            newRow["TYPE"] = "A/S목표";
            gridTable.Rows.Add(newRow);

            newRow = gridTable.NewRow();
            newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
            newRow["FLAG"] = "RESULT";
            newRow["TYPE"] = "결과";
            gridTable.Rows.Add(newRow);

            foreach (DataRow row in dtShipRslt.Rows)
            {
                DataRow[] rows = gridTable.Select("FLAG = 'SHIP'");


                if (rows.Length > 0)
                {
                    if (row["SHIP_MONTH"].ToString().Substring(4, 2) == "01") rows[0]["WORK_1"] = rows[0]["WORK_1"].toInt() + row["SHIP_CNT"].toInt();
                    if (row["SHIP_MONTH"].ToString().Substring(4, 2) == "02") rows[0]["WORK_2"] = rows[0]["WORK_2"].toInt() + row["SHIP_CNT"].toInt();
                    if (row["SHIP_MONTH"].ToString().Substring(4, 2) == "03") rows[0]["WORK_3"] = rows[0]["WORK_3"].toInt() + row["SHIP_CNT"].toInt();
                    if (row["SHIP_MONTH"].ToString().Substring(4, 2) == "04") rows[0]["WORK_4"] = rows[0]["WORK_4"].toInt() + row["SHIP_CNT"].toInt();
                    if (row["SHIP_MONTH"].ToString().Substring(4, 2) == "05") rows[0]["WORK_5"] = rows[0]["WORK_5"].toInt() + row["SHIP_CNT"].toInt();
                    if (row["SHIP_MONTH"].ToString().Substring(4, 2) == "06") rows[0]["WORK_6"] = rows[0]["WORK_6"].toInt() + row["SHIP_CNT"].toInt();
                    if (row["SHIP_MONTH"].ToString().Substring(4, 2) == "07") rows[0]["WORK_7"] = rows[0]["WORK_7"].toInt() + row["SHIP_CNT"].toInt();
                    if (row["SHIP_MONTH"].ToString().Substring(4, 2) == "08") rows[0]["WORK_8"] = rows[0]["WORK_8"].toInt() + row["SHIP_CNT"].toInt();
                    if (row["SHIP_MONTH"].ToString().Substring(4, 2) == "09") rows[0]["WORK_9"] = rows[0]["WORK_9"].toInt() + row["SHIP_CNT"].toInt();
                    if (row["SHIP_MONTH"].ToString().Substring(4, 2) == "10") rows[0]["WORK_10"] = rows[0]["WORK_10"].toInt() + row["SHIP_CNT"].toInt();
                    if (row["SHIP_MONTH"].ToString().Substring(4, 2) == "11") rows[0]["WORK_11"] = rows[0]["WORK_11"].toInt() + row["SHIP_CNT"].toInt();
                    if (row["SHIP_MONTH"].ToString().Substring(4, 2) == "12") rows[0]["WORK_12"] = rows[0]["WORK_12"].toInt() + row["SHIP_CNT"].toInt();

                    double sum = rows[0]["WORK_1"].toInt() + rows[0]["WORK_2"].toInt() + rows[0]["WORK_3"].toInt() + rows[0]["WORK_4"].toInt()
                                 + rows[0]["WORK_5"].toInt() + rows[0]["WORK_6"].toInt() + rows[0]["WORK_7"].toInt() + rows[0]["WORK_8"].toInt()
                                 + rows[0]["WORK_9"].toInt() + rows[0]["WORK_10"].toInt() + rows[0]["WORK_11"].toInt() + rows[0]["WORK_12"].toInt();

                    rows[0]["WORK_SUM"] = sum;
                }
            }

            foreach (DataRow row in dtAsRslt.Rows)
            {
                DataRow[] rows = gridTable.Select("FLAG = 'NG'");

                if (rows.Length > 0)
                {
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "01") rows[0]["WORK_1"] = rows[0]["WORK_1"].toInt() + row["PROD_CNT"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "02") rows[0]["WORK_2"] = rows[0]["WORK_2"].toInt() + row["PROD_CNT"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "03") rows[0]["WORK_3"] = rows[0]["WORK_3"].toInt() + row["PROD_CNT"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "04") rows[0]["WORK_4"] = rows[0]["WORK_4"].toInt() + row["PROD_CNT"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "05") rows[0]["WORK_5"] = rows[0]["WORK_5"].toInt() + row["PROD_CNT"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "06") rows[0]["WORK_6"] = rows[0]["WORK_6"].toInt() + row["PROD_CNT"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "07") rows[0]["WORK_7"] = rows[0]["WORK_7"].toInt() + row["PROD_CNT"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "08") rows[0]["WORK_8"] = rows[0]["WORK_8"].toInt() + row["PROD_CNT"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "09") rows[0]["WORK_9"] = rows[0]["WORK_9"].toInt() + row["PROD_CNT"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "10") rows[0]["WORK_10"] = rows[0]["WORK_10"].toInt() + row["PROD_CNT"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "11") rows[0]["WORK_11"] = rows[0]["WORK_11"].toInt() + row["PROD_CNT"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "12") rows[0]["WORK_12"] = rows[0]["WORK_12"].toInt() + row["PROD_CNT"].toInt();

                    double sum = rows[0]["WORK_1"].toInt() + rows[0]["WORK_2"].toInt() + rows[0]["WORK_3"].toInt() + rows[0]["WORK_4"].toInt()
                                 + rows[0]["WORK_5"].toInt() + rows[0]["WORK_6"].toInt() + rows[0]["WORK_7"].toInt() + rows[0]["WORK_8"].toInt()
                                 + rows[0]["WORK_9"].toInt() + rows[0]["WORK_10"].toInt() + rows[0]["WORK_11"].toInt() + rows[0]["WORK_12"].toInt();

                    rows[0]["WORK_SUM"] = sum;
                }
            }

            foreach (DataRow row in dtGoal.Rows)
            {
                DataRow[] rows = gridTable.Select("FLAG = 'GOAL'");

                if (rows.Length > 0)
                {
                    if (row["GOAL_MONTH"].ToString().Substring(4, 2) == "01") rows[0]["WORK_1"] = rows[0]["WORK_1"].toDecimal() + row["GOAL_RATE"].toDecimal();
                    if (row["GOAL_MONTH"].ToString().Substring(4, 2) == "02") rows[0]["WORK_2"] = rows[0]["WORK_2"].toDecimal() + row["GOAL_RATE"].toDecimal();
                    if (row["GOAL_MONTH"].ToString().Substring(4, 2) == "03") rows[0]["WORK_3"] = rows[0]["WORK_3"].toDecimal() + row["GOAL_RATE"].toDecimal();
                    if (row["GOAL_MONTH"].ToString().Substring(4, 2) == "04") rows[0]["WORK_4"] = rows[0]["WORK_4"].toDecimal() + row["GOAL_RATE"].toDecimal();
                    if (row["GOAL_MONTH"].ToString().Substring(4, 2) == "05") rows[0]["WORK_5"] = rows[0]["WORK_5"].toDecimal() + row["GOAL_RATE"].toDecimal();
                    if (row["GOAL_MONTH"].ToString().Substring(4, 2) == "06") rows[0]["WORK_6"] = rows[0]["WORK_6"].toDecimal() + row["GOAL_RATE"].toDecimal();
                    if (row["GOAL_MONTH"].ToString().Substring(4, 2) == "07") rows[0]["WORK_7"] = rows[0]["WORK_7"].toDecimal() + row["GOAL_RATE"].toDecimal();
                    if (row["GOAL_MONTH"].ToString().Substring(4, 2) == "08") rows[0]["WORK_8"] = rows[0]["WORK_8"].toDecimal() + row["GOAL_RATE"].toDecimal();
                    if (row["GOAL_MONTH"].ToString().Substring(4, 2) == "09") rows[0]["WORK_9"] = rows[0]["WORK_9"].toDecimal() + row["GOAL_RATE"].toDecimal();
                    if (row["GOAL_MONTH"].ToString().Substring(4, 2) == "10") rows[0]["WORK_10"] = rows[0]["WORK_10"].toDecimal() + row["GOAL_RATE"].toDecimal();
                    if (row["GOAL_MONTH"].ToString().Substring(4, 2) == "11") rows[0]["WORK_11"] = rows[0]["WORK_11"].toDecimal() + row["GOAL_RATE"].toDecimal();
                    if (row["GOAL_MONTH"].ToString().Substring(4, 2) == "12") rows[0]["WORK_12"] = rows[0]["WORK_12"].toDecimal() + row["GOAL_RATE"].toDecimal();

                    double sum = rows[0]["WORK_1"].toInt() + rows[0]["WORK_2"].toInt() + rows[0]["WORK_3"].toInt() + rows[0]["WORK_4"].toInt()
                                 + rows[0]["WORK_5"].toInt() + rows[0]["WORK_6"].toInt() + rows[0]["WORK_7"].toInt() + rows[0]["WORK_8"].toInt()
                                 + rows[0]["WORK_9"].toInt() + rows[0]["WORK_10"].toInt() + rows[0]["WORK_11"].toInt() + rows[0]["WORK_12"].toInt();

                    rows[0]["WORK_SUM"] = sum;
                }
            }

            DataRow[] shipRow = gridTable.Select("FLAG = 'SHIP'");
            DataRow[] asRow = gridTable.Select("FLAG = 'NG'");
            DataRow[] rateRow = gridTable.Select("FLAG = 'RATE'");

            foreach (DataRow row in gridTable.Rows)
            {
                if (row["FLAG"].ToString() == "RATE")
                {
                    if (shipRow[0]["WORK_1"].toDecimal() > 0) { row["WORK_1"] = asRow[0]["WORK_1"].toDecimal() / shipRow[0]["WORK_1"].toDecimal(); } else { row["WORK_1"] = 0; }
                    if (shipRow[0]["WORK_2"].toDecimal() > 0) { row["WORK_2"] = asRow[0]["WORK_2"].toDecimal() / shipRow[0]["WORK_2"].toDecimal(); } else { row["WORK_2"] = 0; }
                    if (shipRow[0]["WORK_3"].toDecimal() > 0) { row["WORK_3"] = asRow[0]["WORK_3"].toDecimal() / shipRow[0]["WORK_3"].toDecimal(); } else { row["WORK_3"] = 0; }
                    if (shipRow[0]["WORK_4"].toDecimal() > 0) { row["WORK_4"] = asRow[0]["WORK_4"].toDecimal() / shipRow[0]["WORK_4"].toDecimal(); } else { row["WORK_4"] = 0; }
                    if (shipRow[0]["WORK_5"].toDecimal() > 0) { row["WORK_5"] = asRow[0]["WORK_5"].toDecimal() / shipRow[0]["WORK_5"].toDecimal(); } else { row["WORK_5"] = 0; }
                    if (shipRow[0]["WORK_6"].toDecimal() > 0) { row["WORK_6"] = asRow[0]["WORK_6"].toDecimal() / shipRow[0]["WORK_6"].toDecimal(); } else { row["WORK_6"] = 0; }
                    if (shipRow[0]["WORK_7"].toDecimal() > 0) { row["WORK_7"] = asRow[0]["WORK_7"].toDecimal() / shipRow[0]["WORK_7"].toDecimal(); } else { row["WORK_7"] = 0; }
                    if (shipRow[0]["WORK_8"].toDecimal() > 0) { row["WORK_8"] = asRow[0]["WORK_8"].toDecimal() / shipRow[0]["WORK_8"].toDecimal(); } else { row["WORK_8"] = 0; }
                    if (shipRow[0]["WORK_9"].toDecimal() > 0) { row["WORK_9"] = asRow[0]["WORK_9"].toDecimal() / shipRow[0]["WORK_9"].toDecimal(); } else { row["WORK_9"] = 0; }
                    if (shipRow[0]["WORK_10"].toDecimal() > 0) { row["WORK_10"] = asRow[0]["WORK_10"].toDecimal() / shipRow[0]["WORK_10"].toDecimal(); } else { row["WORK_10"] = 0; }
                    if (shipRow[0]["WORK_11"].toDecimal() > 0) { row["WORK_11"] = asRow[0]["WORK_11"].toDecimal() / shipRow[0]["WORK_11"].toDecimal(); } else { row["WORK_11"] = 0; }
                    if (shipRow[0]["WORK_12"].toDecimal() > 0) { row["WORK_12"] = asRow[0]["WORK_12"].toDecimal() / shipRow[0]["WORK_12"].toDecimal(); } else { row["WORK_12"] = 0; }
                }
            }

            DataTable newTable = new DataTable();
            newTable.Columns.Add("PLT_CODE", typeof(String));
            newTable.Columns.Add("FLAG", typeof(String));
            newTable.Columns.Add("TYPE", typeof(String));
            newTable.Columns.Add("WORK_1", typeof(string));
            newTable.Columns.Add("WORK_2", typeof(string));
            newTable.Columns.Add("WORK_3", typeof(string));
            newTable.Columns.Add("WORK_4", typeof(string));
            newTable.Columns.Add("WORK_5", typeof(string));
            newTable.Columns.Add("WORK_6", typeof(string));
            newTable.Columns.Add("WORK_7", typeof(string));
            newTable.Columns.Add("WORK_8", typeof(string));
            newTable.Columns.Add("WORK_9", typeof(string));
            newTable.Columns.Add("WORK_10", typeof(string));
            newTable.Columns.Add("WORK_11", typeof(string));
            newTable.Columns.Add("WORK_12", typeof(string));
            newTable.Columns.Add("WORK_SUM", typeof(string));


            foreach (DataRow row in gridTable.Rows)
            {

                switch (row["FLAG"].ToString())
                {
                    case "RATE":
                    case "GOAL":
                    case "RESULT":
                        DataRow newGridRow = newTable.NewRow();
                        newGridRow["PLT_CODE"] = row["PLT_CODE"];
                        newGridRow["FLAG"] = row["FLAG"];
                        newGridRow["TYPE"] = row["TYPE"];
                        newGridRow["WORK_1"] = string.Format("{0:N2}%", row["WORK_1"].toDecimal() * 100);
                        newGridRow["WORK_2"] = string.Format("{0:N2}%", row["WORK_2"].toDecimal() * 100);
                        newGridRow["WORK_3"] = string.Format("{0:N2}%", row["WORK_3"].toDecimal() * 100);
                        newGridRow["WORK_4"] = string.Format("{0:N2}%", row["WORK_4"].toDecimal() * 100);
                        newGridRow["WORK_5"] = string.Format("{0:N2}%", row["WORK_5"].toDecimal() * 100);
                        newGridRow["WORK_6"] = string.Format("{0:N2}%", row["WORK_6"].toDecimal() * 100);
                        newGridRow["WORK_7"] = string.Format("{0:N2}%", row["WORK_7"].toDecimal() * 100);
                        newGridRow["WORK_8"] = string.Format("{0:N2}%", row["WORK_8"].toDecimal() * 100);
                        newGridRow["WORK_9"] = string.Format("{0:N2}%", row["WORK_9"].toDecimal() * 100);
                        newGridRow["WORK_10"] = string.Format("{0:N2}%", row["WORK_10"].toDecimal() * 100);
                        newGridRow["WORK_11"] = string.Format("{0:N2}%", row["WORK_11"].toDecimal() * 100);
                        newGridRow["WORK_12"] = string.Format("{0:N2}%", row["WORK_12"].toDecimal() * 100);
                        newGridRow["WORK_SUM"] = string.Format("{0:N2}%", row["WORK_SUM"].toDecimal() * 100);

                        newTable.Rows.Add(newGridRow);

                        break;

                    default:
                        DataRow newGridRow2 = newTable.NewRow();
                        newGridRow2["PLT_CODE"] = row["PLT_CODE"];
                        newGridRow2["FLAG"] = row["FLAG"];
                        newGridRow2["TYPE"] = row["TYPE"];
                        newGridRow2["WORK_1"] = string.Format("{0:N0}", row["WORK_1"]);
                        newGridRow2["WORK_2"] = string.Format("{0:N0}", row["WORK_2"]);
                        newGridRow2["WORK_3"] = string.Format("{0:N0}", row["WORK_3"]);
                        newGridRow2["WORK_4"] = string.Format("{0:N0}", row["WORK_4"]);
                        newGridRow2["WORK_5"] = string.Format("{0:N0}", row["WORK_5"]);
                        newGridRow2["WORK_6"] = string.Format("{0:N0}", row["WORK_6"]);
                        newGridRow2["WORK_7"] = string.Format("{0:N0}", row["WORK_7"]);
                        newGridRow2["WORK_8"] = string.Format("{0:N0}", row["WORK_8"]);
                        newGridRow2["WORK_9"] = string.Format("{0:N0}", row["WORK_9"]);
                        newGridRow2["WORK_10"] = string.Format("{0:N0}", row["WORK_10"]);
                        newGridRow2["WORK_11"] = string.Format("{0:N0}", row["WORK_11"]);
                        newGridRow2["WORK_12"] = string.Format("{0:N0}", row["WORK_12"]);
                        newGridRow2["WORK_SUM"] = string.Format("{0:N0}", row["WORK_SUM"]);

                        newTable.Rows.Add(newGridRow2);
                        break;
                }
            }


            return newTable;

        }


        static void dev(out DataTable dt, out DataTable dt2, out DataTable dt3, DataSet paramSet,  BizExecute.BizExecute biz)
        {
            DataTable cloneTable = new DataTable();
            cloneTable.Columns.Add("PLT_CODE", typeof(String));
            cloneTable.Columns.Add("FLAG", typeof(String));
            cloneTable.Columns.Add("TYPE", typeof(String));
            cloneTable.Columns.Add("WORK_1", typeof(int));
            cloneTable.Columns.Add("WORK_2", typeof(int));
            cloneTable.Columns.Add("WORK_3", typeof(int));
            cloneTable.Columns.Add("WORK_4", typeof(int));
            cloneTable.Columns.Add("WORK_5", typeof(int));
            cloneTable.Columns.Add("WORK_6", typeof(int));
            cloneTable.Columns.Add("WORK_7", typeof(int));
            cloneTable.Columns.Add("WORK_8", typeof(int));
            cloneTable.Columns.Add("WORK_9", typeof(int));
            cloneTable.Columns.Add("WORK_10", typeof(int));
            cloneTable.Columns.Add("WORK_11", typeof(int));
            cloneTable.Columns.Add("WORK_12", typeof(int));
            cloneTable.Columns.Add("WORK_SUM", typeof(int));

            DataTable dtRslt = DORD.TORD_PRODUCT_QUERY.TORD_PRODUCT_QUERY18(paramSet.Tables["RQSTDT"], biz);

            /*
             0 : Socket
             1 : Pin Block
             2 : Jig
             3 : Part Assy
             4 : Parts
             5 : Sales Pin
             6 : Actuator
            */

            DataTable SocketTable = cloneTable.Clone();

            DataRow newRow = SocketTable.NewRow();
            newRow["FLAG"] = "TOTAL";
            newRow["TYPE"] = "Socket 전체 건수";
            SocketTable.Rows.Add(newRow);

            DataRow[] socketRows = dtRslt.Select("PROD_TYPE = '0'");

            foreach (DataRow row in socketRows)
            {
                DataRow[] rows = SocketTable.Select("TYPE = 'Socket " + row["WORK_LOC_NAME"].ToString() + " 건수'");

                if (rows.Length == 0)
                {
                    DataRow newSocketRow = SocketTable.NewRow();
                    newSocketRow["PLT_CODE"] = row["PLT_CODE"];
                    newSocketRow["TYPE"] = "Socket " + row["WORK_LOC_NAME"] + " 건수";

                    newSocketRow["WORK_1"] = 0;
                    newSocketRow["WORK_2"] = 0;
                    newSocketRow["WORK_3"] = 0;
                    newSocketRow["WORK_4"] = 0;
                    newSocketRow["WORK_5"] = 0;
                    newSocketRow["WORK_6"] = 0;
                    newSocketRow["WORK_7"] = 0;
                    newSocketRow["WORK_8"] = 0;
                    newSocketRow["WORK_9"] = 0;
                    newSocketRow["WORK_10"] = 0;
                    newSocketRow["WORK_11"] = 0;
                    newSocketRow["WORK_12"] = 0;

                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "01") newSocketRow["WORK_1"] = row["ORD_QTY"];
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "02") newSocketRow["WORK_2"] = row["ORD_QTY"];
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "03") newSocketRow["WORK_3"] = row["ORD_QTY"];
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "04") newSocketRow["WORK_4"] = row["ORD_QTY"];
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "05") newSocketRow["WORK_5"] = row["ORD_QTY"];
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "06") newSocketRow["WORK_6"] = row["ORD_QTY"];
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "07") newSocketRow["WORK_7"] = row["ORD_QTY"];
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "08") newSocketRow["WORK_8"] = row["ORD_QTY"];
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "09") newSocketRow["WORK_9"] = row["ORD_QTY"];
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "10") newSocketRow["WORK_10"] = row["ORD_QTY"];
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "11") newSocketRow["WORK_11"] = row["ORD_QTY"];
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "12") newSocketRow["WORK_12"] = row["ORD_QTY"];

                    double sum = newSocketRow["WORK_1"].toInt() + newSocketRow["WORK_2"].toInt() + newSocketRow["WORK_3"].toInt() + newSocketRow["WORK_4"].toInt()
                                 + newSocketRow["WORK_5"].toInt() + newSocketRow["WORK_6"].toInt() + newSocketRow["WORK_7"].toInt() + newSocketRow["WORK_8"].toInt()
                                 + newSocketRow["WORK_9"].toInt() + newSocketRow["WORK_10"].toInt() + newSocketRow["WORK_11"].toInt() + newSocketRow["WORK_12"].toInt();

                    newSocketRow["WORK_SUM"] = sum;

                    SocketTable.Rows.Add(newSocketRow);
                }
                else
                {
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "01") rows[0]["WORK_1"] = rows[0]["WORK_1"].toInt() + row["ORD_QTY"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "02") rows[0]["WORK_2"] = rows[0]["WORK_2"].toInt() + row["ORD_QTY"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "03") rows[0]["WORK_3"] = rows[0]["WORK_3"].toInt() + row["ORD_QTY"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "04") rows[0]["WORK_4"] = rows[0]["WORK_4"].toInt() + row["ORD_QTY"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "05") rows[0]["WORK_5"] = rows[0]["WORK_5"].toInt() + row["ORD_QTY"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "06") rows[0]["WORK_6"] = rows[0]["WORK_6"].toInt() + row["ORD_QTY"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "07") rows[0]["WORK_7"] = rows[0]["WORK_7"].toInt() + row["ORD_QTY"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "08") rows[0]["WORK_8"] = rows[0]["WORK_8"].toInt() + row["ORD_QTY"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "09") rows[0]["WORK_9"] = rows[0]["WORK_9"].toInt() + row["ORD_QTY"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "10") rows[0]["WORK_10"] = rows[0]["WORK_10"].toInt() + row["ORD_QTY"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "11") rows[0]["WORK_11"] = rows[0]["WORK_11"].toInt() + row["ORD_QTY"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "12") rows[0]["WORK_12"] = rows[0]["WORK_12"].toInt() + row["ORD_QTY"].toInt();

                    double sum = rows[0]["WORK_1"].toInt() + rows[0]["WORK_2"].toInt() + rows[0]["WORK_3"].toInt() + rows[0]["WORK_4"].toInt()
                                 + rows[0]["WORK_5"].toInt() + rows[0]["WORK_6"].toInt() + rows[0]["WORK_7"].toInt() + rows[0]["WORK_8"].toInt()
                                 + rows[0]["WORK_9"].toInt() + rows[0]["WORK_10"].toInt() + rows[0]["WORK_11"].toInt() + rows[0]["WORK_12"].toInt();

                    rows[0]["WORK_SUM"] = sum;
                }
            }

            DataRow[] totalRows = SocketTable.Select("FLAG = 'TOTAL'");

            foreach (DataRow row in SocketTable.Rows)
            {
                if (row["FLAG"].ToString() == "TOTAL") continue;

                totalRows[0]["WORK_1"] = totalRows[0]["WORK_1"].toInt() + row["WORK_1"].toInt();
                totalRows[0]["WORK_2"] = totalRows[0]["WORK_2"].toInt() + row["WORK_2"].toInt();
                totalRows[0]["WORK_3"] = totalRows[0]["WORK_3"].toInt() + row["WORK_3"].toInt();
                totalRows[0]["WORK_4"] = totalRows[0]["WORK_4"].toInt() + row["WORK_4"].toInt();
                totalRows[0]["WORK_5"] = totalRows[0]["WORK_5"].toInt() + row["WORK_5"].toInt();
                totalRows[0]["WORK_6"] = totalRows[0]["WORK_6"].toInt() + row["WORK_6"].toInt();
                totalRows[0]["WORK_7"] = totalRows[0]["WORK_7"].toInt() + row["WORK_7"].toInt();
                totalRows[0]["WORK_8"] = totalRows[0]["WORK_8"].toInt() + row["WORK_8"].toInt();
                totalRows[0]["WORK_9"] = totalRows[0]["WORK_9"].toInt() + row["WORK_9"].toInt();
                totalRows[0]["WORK_10"] = totalRows[0]["WORK_10"].toInt() + row["WORK_10"].toInt();
                totalRows[0]["WORK_11"] = totalRows[0]["WORK_11"].toInt() + row["WORK_11"].toInt();
                totalRows[0]["WORK_12"] = totalRows[0]["WORK_12"].toInt() + row["WORK_12"].toInt();
                totalRows[0]["WORK_SUM"] = totalRows[0]["WORK_SUM"].toInt() + row["WORK_SUM"].toInt();
            }


            DataTable pinBlockTable = cloneTable.Clone();

            DataRow newRow2 = pinBlockTable.NewRow();
            newRow2["FLAG"] = "TOTAL";
            newRow2["TYPE"] = "PinBlock 전체 건수";
            pinBlockTable.Rows.Add(newRow2);

            DataRow[] pinBolckRows = dtRslt.Select("PROD_TYPE = '1'");

            foreach (DataRow row in pinBolckRows)
            {
                DataRow[] rows = pinBlockTable.Select("TYPE = 'PinBlock " + row["WORK_LOC_NAME"].ToString() + " 건수'");

                if (rows.Length == 0)
                {
                    DataRow newPinBlockRow = pinBlockTable.NewRow();
                    newPinBlockRow["PLT_CODE"] = row["PLT_CODE"];
                    newPinBlockRow["TYPE"] = "PinBlock " + row["WORK_LOC_NAME"] + " 건수";

                    newPinBlockRow["WORK_1"] = 0;
                    newPinBlockRow["WORK_2"] = 0;
                    newPinBlockRow["WORK_3"] = 0;
                    newPinBlockRow["WORK_4"] = 0;
                    newPinBlockRow["WORK_5"] = 0;
                    newPinBlockRow["WORK_6"] = 0;
                    newPinBlockRow["WORK_7"] = 0;
                    newPinBlockRow["WORK_8"] = 0;
                    newPinBlockRow["WORK_9"] = 0;
                    newPinBlockRow["WORK_10"] = 0;
                    newPinBlockRow["WORK_11"] = 0;
                    newPinBlockRow["WORK_12"] = 0;

                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "01") newPinBlockRow["WORK_1"] = row["ORD_QTY"];
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "02") newPinBlockRow["WORK_2"] = row["ORD_QTY"];
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "03") newPinBlockRow["WORK_3"] = row["ORD_QTY"];
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "04") newPinBlockRow["WORK_4"] = row["ORD_QTY"];
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "05") newPinBlockRow["WORK_5"] = row["ORD_QTY"];
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "06") newPinBlockRow["WORK_6"] = row["ORD_QTY"];
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "07") newPinBlockRow["WORK_7"] = row["ORD_QTY"];
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "08") newPinBlockRow["WORK_8"] = row["ORD_QTY"];
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "09") newPinBlockRow["WORK_9"] = row["ORD_QTY"];
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "10") newPinBlockRow["WORK_10"] = row["ORD_QTY"];
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "11") newPinBlockRow["WORK_11"] = row["ORD_QTY"];
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "12") newPinBlockRow["WORK_12"] = row["ORD_QTY"];

                    double sum = newPinBlockRow["WORK_1"].toInt() + newPinBlockRow["WORK_2"].toInt() + newPinBlockRow["WORK_3"].toInt() + newPinBlockRow["WORK_4"].toInt()
                                 + newPinBlockRow["WORK_5"].toInt() + newPinBlockRow["WORK_6"].toInt() + newPinBlockRow["WORK_7"].toInt() + newPinBlockRow["WORK_8"].toInt()
                                 + newPinBlockRow["WORK_9"].toInt() + newPinBlockRow["WORK_10"].toInt() + newPinBlockRow["WORK_11"].toInt() + newPinBlockRow["WORK_12"].toInt();

                    newPinBlockRow["WORK_SUM"] = sum;

                    pinBlockTable.Rows.Add(newPinBlockRow);
                }
                else
                {
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "01") rows[0]["WORK_1"] = rows[0]["WORK_1"].toInt() + row["ORD_QTY"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "02") rows[0]["WORK_2"] = rows[0]["WORK_2"].toInt() + row["ORD_QTY"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "03") rows[0]["WORK_3"] = rows[0]["WORK_3"].toInt() + row["ORD_QTY"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "04") rows[0]["WORK_4"] = rows[0]["WORK_4"].toInt() + row["ORD_QTY"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "05") rows[0]["WORK_5"] = rows[0]["WORK_5"].toInt() + row["ORD_QTY"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "06") rows[0]["WORK_6"] = rows[0]["WORK_6"].toInt() + row["ORD_QTY"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "07") rows[0]["WORK_7"] = rows[0]["WORK_7"].toInt() + row["ORD_QTY"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "08") rows[0]["WORK_8"] = rows[0]["WORK_8"].toInt() + row["ORD_QTY"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "09") rows[0]["WORK_9"] = rows[0]["WORK_9"].toInt() + row["ORD_QTY"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "10") rows[0]["WORK_10"] = rows[0]["WORK_10"].toInt() + row["ORD_QTY"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "11") rows[0]["WORK_11"] = rows[0]["WORK_11"].toInt() + row["ORD_QTY"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "12") rows[0]["WORK_12"] = rows[0]["WORK_12"].toInt() + row["ORD_QTY"].toInt();

                    double sum = rows[0]["WORK_1"].toInt() + rows[0]["WORK_2"].toInt() + rows[0]["WORK_3"].toInt() + rows[0]["WORK_4"].toInt()
                                 + rows[0]["WORK_5"].toInt() + rows[0]["WORK_6"].toInt() + rows[0]["WORK_7"].toInt() + rows[0]["WORK_8"].toInt()
                                 + rows[0]["WORK_9"].toInt() + rows[0]["WORK_10"].toInt() + rows[0]["WORK_11"].toInt() + rows[0]["WORK_12"].toInt();

                    rows[0]["WORK_SUM"] = sum;
                }
            }

            DataRow[] totalPinBlockRows = pinBlockTable.Select("FLAG = 'TOTAL'");

            foreach (DataRow row in pinBlockTable.Rows)
            {
                if (row["FLAG"].ToString() == "TOTAL") continue;

                totalPinBlockRows[0]["WORK_1"] = totalPinBlockRows[0]["WORK_1"].toInt() + row["WORK_1"].toInt();
                totalPinBlockRows[0]["WORK_2"] = totalPinBlockRows[0]["WORK_2"].toInt() + row["WORK_2"].toInt();
                totalPinBlockRows[0]["WORK_3"] = totalPinBlockRows[0]["WORK_3"].toInt() + row["WORK_3"].toInt();
                totalPinBlockRows[0]["WORK_4"] = totalPinBlockRows[0]["WORK_4"].toInt() + row["WORK_4"].toInt();
                totalPinBlockRows[0]["WORK_5"] = totalPinBlockRows[0]["WORK_5"].toInt() + row["WORK_5"].toInt();
                totalPinBlockRows[0]["WORK_6"] = totalPinBlockRows[0]["WORK_6"].toInt() + row["WORK_6"].toInt();
                totalPinBlockRows[0]["WORK_7"] = totalPinBlockRows[0]["WORK_7"].toInt() + row["WORK_7"].toInt();
                totalPinBlockRows[0]["WORK_8"] = totalPinBlockRows[0]["WORK_8"].toInt() + row["WORK_8"].toInt();
                totalPinBlockRows[0]["WORK_9"] = totalPinBlockRows[0]["WORK_9"].toInt() + row["WORK_9"].toInt();
                totalPinBlockRows[0]["WORK_10"] = totalPinBlockRows[0]["WORK_10"].toInt() + row["WORK_10"].toInt();
                totalPinBlockRows[0]["WORK_11"] = totalPinBlockRows[0]["WORK_11"].toInt() + row["WORK_11"].toInt();
                totalPinBlockRows[0]["WORK_12"] = totalPinBlockRows[0]["WORK_12"].toInt() + row["WORK_12"].toInt();
                totalPinBlockRows[0]["WORK_SUM"] = totalPinBlockRows[0]["WORK_SUM"].toInt() + row["WORK_SUM"].toInt();
            }


            DataTable partTable = cloneTable.Clone();

            DataRow newRow3 = partTable.NewRow();
            newRow3["FLAG"] = "TOTAL";
            newRow3["TYPE"] = "Parts 전체 건수";
            partTable.Rows.Add(newRow3);

            DataRow[] partRows = dtRslt.Select("PROD_TYPE = '4'");

            foreach (DataRow row in partRows)
            {
                DataRow[] rows = partTable.Select("TYPE = 'Parts " + row["WORK_LOC_NAME"].ToString() + " 건수'");

                if (rows.Length == 0)
                {
                    DataRow newPartRow = partTable.NewRow();
                    newPartRow["PLT_CODE"] = row["PLT_CODE"];
                    newPartRow["TYPE"] = "Parts " + row["WORK_LOC_NAME"] + " 건수";

                    newPartRow["WORK_1"] = 0;
                    newPartRow["WORK_2"] = 0;
                    newPartRow["WORK_3"] = 0;
                    newPartRow["WORK_4"] = 0;
                    newPartRow["WORK_5"] = 0;
                    newPartRow["WORK_6"] = 0;
                    newPartRow["WORK_7"] = 0;
                    newPartRow["WORK_8"] = 0;
                    newPartRow["WORK_9"] = 0;
                    newPartRow["WORK_10"] = 0;
                    newPartRow["WORK_11"] = 0;
                    newPartRow["WORK_12"] = 0;

                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "01") newPartRow["WORK_1"] = row["ORD_QTY"];
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "02") newPartRow["WORK_2"] = row["ORD_QTY"];
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "03") newPartRow["WORK_3"] = row["ORD_QTY"];
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "04") newPartRow["WORK_4"] = row["ORD_QTY"];
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "05") newPartRow["WORK_5"] = row["ORD_QTY"];
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "06") newPartRow["WORK_6"] = row["ORD_QTY"];
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "07") newPartRow["WORK_7"] = row["ORD_QTY"];
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "08") newPartRow["WORK_8"] = row["ORD_QTY"];
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "09") newPartRow["WORK_9"] = row["ORD_QTY"];
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "10") newPartRow["WORK_10"] = row["ORD_QTY"];
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "11") newPartRow["WORK_11"] = row["ORD_QTY"];
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "12") newPartRow["WORK_12"] = row["ORD_QTY"];

                    double sum = newPartRow["WORK_1"].toInt() + newPartRow["WORK_2"].toInt() + newPartRow["WORK_3"].toInt() + newPartRow["WORK_4"].toInt()
                                 + newPartRow["WORK_5"].toInt() + newPartRow["WORK_6"].toInt() + newPartRow["WORK_7"].toInt() + newPartRow["WORK_8"].toInt()
                                 + newPartRow["WORK_9"].toInt() + newPartRow["WORK_10"].toInt() + newPartRow["WORK_11"].toInt() + newPartRow["WORK_12"].toInt();

                    newPartRow["WORK_SUM"] = sum;

                    partTable.Rows.Add(newPartRow);
                }
                else
                {
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "01") rows[0]["WORK_1"] = rows[0]["WORK_1"].toInt() + row["ORD_QTY"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "02") rows[0]["WORK_2"] = rows[0]["WORK_2"].toInt() + row["ORD_QTY"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "03") rows[0]["WORK_3"] = rows[0]["WORK_3"].toInt() + row["ORD_QTY"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "04") rows[0]["WORK_4"] = rows[0]["WORK_4"].toInt() + row["ORD_QTY"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "05") rows[0]["WORK_5"] = rows[0]["WORK_5"].toInt() + row["ORD_QTY"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "06") rows[0]["WORK_6"] = rows[0]["WORK_6"].toInt() + row["ORD_QTY"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "07") rows[0]["WORK_7"] = rows[0]["WORK_7"].toInt() + row["ORD_QTY"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "08") rows[0]["WORK_8"] = rows[0]["WORK_8"].toInt() + row["ORD_QTY"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "09") rows[0]["WORK_9"] = rows[0]["WORK_9"].toInt() + row["ORD_QTY"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "10") rows[0]["WORK_10"] = rows[0]["WORK_10"].toInt() + row["ORD_QTY"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "11") rows[0]["WORK_11"] = rows[0]["WORK_11"].toInt() + row["ORD_QTY"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "12") rows[0]["WORK_12"] = rows[0]["WORK_12"].toInt() + row["ORD_QTY"].toInt();

                    double sum = rows[0]["WORK_1"].toInt() + rows[0]["WORK_2"].toInt() + rows[0]["WORK_3"].toInt() + rows[0]["WORK_4"].toInt()
                                 + rows[0]["WORK_5"].toInt() + rows[0]["WORK_6"].toInt() + rows[0]["WORK_7"].toInt() + rows[0]["WORK_8"].toInt()
                                 + rows[0]["WORK_9"].toInt() + rows[0]["WORK_10"].toInt() + rows[0]["WORK_11"].toInt() + rows[0]["WORK_12"].toInt();

                    rows[0]["WORK_SUM"] = sum;
                }
            }

            DataRow[] totalPartRows = partTable.Select("FLAG = 'TOTAL'");

            foreach (DataRow row in partTable.Rows)
            {
                if (row["FLAG"].ToString() == "TOTAL") continue;

                totalPartRows[0]["WORK_1"] = totalPartRows[0]["WORK_1"].toInt() + row["WORK_1"].toInt();
                totalPartRows[0]["WORK_2"] = totalPartRows[0]["WORK_2"].toInt() + row["WORK_2"].toInt();
                totalPartRows[0]["WORK_3"] = totalPartRows[0]["WORK_3"].toInt() + row["WORK_3"].toInt();
                totalPartRows[0]["WORK_4"] = totalPartRows[0]["WORK_4"].toInt() + row["WORK_4"].toInt();
                totalPartRows[0]["WORK_5"] = totalPartRows[0]["WORK_5"].toInt() + row["WORK_5"].toInt();
                totalPartRows[0]["WORK_6"] = totalPartRows[0]["WORK_6"].toInt() + row["WORK_6"].toInt();
                totalPartRows[0]["WORK_7"] = totalPartRows[0]["WORK_7"].toInt() + row["WORK_7"].toInt();
                totalPartRows[0]["WORK_8"] = totalPartRows[0]["WORK_8"].toInt() + row["WORK_8"].toInt();
                totalPartRows[0]["WORK_9"] = totalPartRows[0]["WORK_9"].toInt() + row["WORK_9"].toInt();
                totalPartRows[0]["WORK_10"] = totalPartRows[0]["WORK_10"].toInt() + row["WORK_10"].toInt();
                totalPartRows[0]["WORK_11"] = totalPartRows[0]["WORK_11"].toInt() + row["WORK_11"].toInt();
                totalPartRows[0]["WORK_12"] = totalPartRows[0]["WORK_12"].toInt() + row["WORK_12"].toInt();
                totalPartRows[0]["WORK_SUM"] = totalPartRows[0]["WORK_SUM"].toInt() + row["WORK_SUM"].toInt();
            }



            SocketTable.TableName = "RSLTDT";
            pinBlockTable.TableName = "RSLTDT2";
            partTable.TableName = "RSLTDT3";

            dt = SocketTable;
            dt2 = pinBlockTable;
            dt3 = partTable;
        }


        static DataTable ngRate(DataSet paramSet, BizExecute.BizExecute biz)
        {
            DataTable dtRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY43(paramSet.Tables["RQSTDT"], biz);
            DataTable dtRslt2 = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY44(paramSet.Tables["RQSTDT"], biz);

            DataTable dtNgRslt = DSHP.TSHP_NG_QUERY.TSHP_NG_QUERY9(paramSet.Tables["RQSTDT"], biz);

            DataTable gridTable = new DataTable();
            gridTable.Columns.Add("END_MONTH", typeof(String));
            gridTable.Columns.Add("MONTH_FLAG", typeof(String));
            gridTable.Columns.Add("PART_QTY", typeof(Decimal));
            gridTable.Columns.Add("ACT_QTY", typeof(Decimal));

            gridTable.Columns.Add("R_PART_QTY", typeof(Decimal));
            gridTable.Columns.Add("R_RATE", typeof(Decimal));

            gridTable.Columns.Add("M_PART_QTY", typeof(Decimal));
            gridTable.Columns.Add("M_RATE", typeof(Decimal));

            gridTable.Columns.Add("S_PART_QTY", typeof(Decimal));
            gridTable.Columns.Add("S_RATE", typeof(Decimal));

            gridTable.Columns.Add("N_PART_QTY", typeof(Decimal));
            gridTable.Columns.Add("N_RATE", typeof(Decimal));

            for (int i = 0; i < 12; i++)
            {
                DataRow newRow = gridTable.NewRow();
                newRow["END_MONTH"] = (i + 1).ToString() + " 월";
                newRow["MONTH_FLAG"] = (i + 1).ToString().PadLeft(2, '0');

                gridTable.Rows.Add(newRow);
            }

            foreach (DataRow row in dtRslt.Rows)
            {
                DataRow[] rows = gridTable.Select("MONTH_FLAG = '" + row["END_MONTH"].ToString().Substring(4, 2) + "'");

                if (rows.Length > 0)
                {
                    rows[0]["PART_QTY"] = row["PART_QTY"];
                    rows[0]["ACT_QTY"] = row["ACT_QTY"];
                }
            }

            foreach (DataRow row in dtRslt2.Rows)
            {
                switch (row["IS_REWORK"].ToString())
                {
                    case "3":
                    case "5":

                        DataRow[] rows = gridTable.Select("MONTH_FLAG = '" + row["END_MONTH"].ToString().Substring(4, 2) + "'");

                        if (rows.Length > 0)
                        {
                            rows[0]["R_PART_QTY"] = row["PART_QTY"];
                        }

                        break;

                    case "4":
                    case "6":

                        DataRow[] rows2 = gridTable.Select("MONTH_FLAG = '" + row["END_MONTH"].ToString().Substring(4, 2) + "'");

                        if (rows2.Length > 0)
                        {
                            rows2[0]["M_PART_QTY"] = row["PART_QTY"];
                        }

                        break;
                }

            }

            foreach (DataRow row in dtNgRslt.Rows)
            {
                DataRow[] rows = gridTable.Select("MONTH_FLAG = '" + row["NG_MONTH"].ToString().Substring(4, 2) + "'");

                if (rows.Length > 0)
                {
                    rows[0]["S_PART_QTY"] = row["QUANTITY"];
                }
            }

            foreach (DataRow row in gridTable.Rows)
            {
                if (row["PART_QTY"].toDecimal() > 0) { row["R_RATE"] = row["R_PART_QTY"].toDecimal() / row["PART_QTY"].toDecimal(); } else { row["R_RATE"] = 0; };
                if (row["PART_QTY"].toDecimal() > 0) { row["M_RATE"] = row["M_PART_QTY"].toDecimal() / row["PART_QTY"].toDecimal(); } else { row["M_RATE"] = 0; };
                if (row["PART_QTY"].toDecimal() > 0) { row["S_RATE"] = row["S_PART_QTY"].toDecimal() / row["PART_QTY"].toDecimal(); } else { row["S_RATE"] = 0; };

                row["N_PART_QTY"] = row["R_PART_QTY"].toInt() + row["M_PART_QTY"].toInt();
                row["N_RATE"] = row["R_RATE"].toDecimal() + row["M_RATE"].toDecimal();
            }

            gridTable.TableName = "RSLTDT";

            return gridTable;
        }

        static DataTable ypgoType1(DataTable cloneTable, DataTable oriTable)
        {
            DataTable gridTable = cloneTable.Clone();

            SetTable(gridTable);

            foreach (DataRow row in oriTable.Rows)
            {
                string flag = "";

                if (row["MAT_LTYPE"].toStringEmpty() == "22" && row["MAT_MTYPE"].toStringEmpty() == "23")
                {
                    flag = "1";
                }
                else if (row["MAT_LTYPE"].toStringEmpty() == "22" && row["MAT_MTYPE"].toStringEmpty() == "21")
                {
                    flag = "2";
                }
                else if (row["MAT_LTYPE"].toStringEmpty() == "22" && row["MAT_MTYPE"].toStringEmpty() == "20")
                {
                    flag = "3";
                }
                else if (row["MAT_LTYPE"].toStringEmpty() == "5" && row["MAT_MTYPE"].toStringEmpty() == "80")
                {
                    flag = "4";
                }
                else if (row["MAT_LTYPE"].toStringEmpty() == "7" && row["MAT_MTYPE"].toStringEmpty() == "32")
                {
                    flag = "5";
                }
                else if (row["MAT_LTYPE"].toStringEmpty() == "8")
                {
                    flag = "6";
                }
                else if (row["MAT_LTYPE"].toStringEmpty() == "6")
                {
                    flag = "7";
                }
                else if (row["MAT_LTYPE"].toStringEmpty() == "5")
                {
                    if (row["MAT_LTYPE"].toStringEmpty() != "42"
                        && row["MAT_LTYPE"].toStringEmpty() != "80")
                    {
                        flag = "8";
                    }
                }
                else if (row["MAT_LTYPE"].toStringEmpty() == "4")
                {
                    flag = "9";
                }

                if (flag == "") continue;


                DataRow[] rows = gridTable.Select("FLAG = '" + flag + "'");

                rows = gridTable.Select("FLAG = '" + flag + "'");

                if (rows.Length > 0)
                {
                    for (int i = 0; i < 12; i++)
                    {
                        if (!row["AMT"].isNumeric()) row["AMT"] = 0;
                        if (!rows[0]["WORK_" + (i + 1).ToString()].isNumeric()) rows[0]["WORK_" + (i + 1).ToString()] = 0;
                    }

                    if (row["CLOSE_MONTH"].ToString().Substring(4, 2) == "01") rows[0]["WORK_1"] = System.Convert.ToInt64(rows[0]["WORK_1"]) + System.Convert.ToInt64(row["AMT"]);
                    if (row["CLOSE_MONTH"].ToString().Substring(4, 2) == "02") rows[0]["WORK_2"] = System.Convert.ToInt64(rows[0]["WORK_2"]) + System.Convert.ToInt64(row["AMT"]);
                    if (row["CLOSE_MONTH"].ToString().Substring(4, 2) == "03") rows[0]["WORK_3"] = System.Convert.ToInt64(rows[0]["WORK_3"]) + System.Convert.ToInt64(row["AMT"]);
                    if (row["CLOSE_MONTH"].ToString().Substring(4, 2) == "04") rows[0]["WORK_4"] = System.Convert.ToInt64(rows[0]["WORK_4"]) + System.Convert.ToInt64(row["AMT"]);
                    if (row["CLOSE_MONTH"].ToString().Substring(4, 2) == "05") rows[0]["WORK_5"] = System.Convert.ToInt64(rows[0]["WORK_5"]) + System.Convert.ToInt64(row["AMT"]);
                    if (row["CLOSE_MONTH"].ToString().Substring(4, 2) == "06") rows[0]["WORK_6"] = System.Convert.ToInt64(rows[0]["WORK_6"]) + System.Convert.ToInt64(row["AMT"]);
                    if (row["CLOSE_MONTH"].ToString().Substring(4, 2) == "07") rows[0]["WORK_7"] = System.Convert.ToInt64(rows[0]["WORK_7"]) + System.Convert.ToInt64(row["AMT"]);
                    if (row["CLOSE_MONTH"].ToString().Substring(4, 2) == "08") rows[0]["WORK_8"] = System.Convert.ToInt64(rows[0]["WORK_8"]) + System.Convert.ToInt64(row["AMT"]);
                    if (row["CLOSE_MONTH"].ToString().Substring(4, 2) == "09") rows[0]["WORK_9"] = System.Convert.ToInt64(rows[0]["WORK_9"]) + System.Convert.ToInt64(row["AMT"]);
                    if (row["CLOSE_MONTH"].ToString().Substring(4, 2) == "10") rows[0]["WORK_10"] = System.Convert.ToInt64(rows[0]["WORK_10"]) + System.Convert.ToInt64(row["AMT"]);
                    if (row["CLOSE_MONTH"].ToString().Substring(4, 2) == "11") rows[0]["WORK_11"] = System.Convert.ToInt64(rows[0]["WORK_11"]) + System.Convert.ToInt64(row["AMT"]);
                    if (row["CLOSE_MONTH"].ToString().Substring(4, 2) == "12") rows[0]["WORK_12"] = System.Convert.ToInt64(rows[0]["WORK_12"]) + System.Convert.ToInt64(row["AMT"]);

                    double sum = System.Convert.ToInt64(rows[0]["WORK_1"]) + System.Convert.ToInt64(rows[0]["WORK_2"]) + System.Convert.ToInt64(rows[0]["WORK_3"]) + System.Convert.ToInt64(rows[0]["WORK_4"])
                                 + System.Convert.ToInt64(rows[0]["WORK_5"]) + System.Convert.ToInt64(rows[0]["WORK_6"]) + System.Convert.ToInt64(rows[0]["WORK_7"]) + System.Convert.ToInt64(rows[0]["WORK_8"])
                                 + System.Convert.ToInt64(rows[0]["WORK_9"]) + System.Convert.ToInt64(rows[0]["WORK_10"]) + System.Convert.ToInt64(rows[0]["WORK_11"]) + System.Convert.ToInt64(rows[0]["WORK_12"]);

                    rows[0]["WORK_SUM"] = sum;
                }
            }

            DataRow newRow2 = gridTable.NewRow();
            newRow2["PLT_CODE"] = ConnInfo.PLT_CODE;
            newRow2["FLAG"] = "SUM";
            newRow2["TYPE"] = "합계";

            foreach (DataRow row in gridTable.Rows)
            {
                for (int i = 0; i < 12; i++)
                {
                    //if (row["AMT"].toInt() == 0) row["WORK_" + (i + 1).ToString()] = 0;
                    if (!newRow2["WORK_" + (i + 1).ToString()].isNumeric()) newRow2["WORK_" + (i + 1).ToString()] = 0;
                    if (!row["WORK_" + (i + 1).ToString()].isNumeric()) row["WORK_" + (i + 1).ToString()] = 0;
                }

                newRow2["WORK_1"] = System.Convert.ToInt64(newRow2["WORK_1"]) + System.Convert.ToInt64(row["WORK_1"]);
                newRow2["WORK_2"] = System.Convert.ToInt64(newRow2["WORK_2"]) + System.Convert.ToInt64(row["WORK_2"]);
                newRow2["WORK_3"] = System.Convert.ToInt64(newRow2["WORK_3"]) + System.Convert.ToInt64(row["WORK_3"]);
                newRow2["WORK_4"] = System.Convert.ToInt64(newRow2["WORK_4"]) + System.Convert.ToInt64(row["WORK_4"]);
                newRow2["WORK_5"] = System.Convert.ToInt64(newRow2["WORK_5"]) + System.Convert.ToInt64(row["WORK_5"]);
                newRow2["WORK_6"] = System.Convert.ToInt64(newRow2["WORK_6"]) + System.Convert.ToInt64(row["WORK_6"]);
                newRow2["WORK_7"] = System.Convert.ToInt64(newRow2["WORK_7"]) + System.Convert.ToInt64(row["WORK_7"]);
                newRow2["WORK_8"] = System.Convert.ToInt64(newRow2["WORK_8"]) + System.Convert.ToInt64(row["WORK_8"]);
                newRow2["WORK_9"] = System.Convert.ToInt64(newRow2["WORK_9"]) + System.Convert.ToInt64(row["WORK_9"]);
                newRow2["WORK_10"] = System.Convert.ToInt64(newRow2["WORK_10"]) + System.Convert.ToInt64(row["WORK_10"]);
                newRow2["WORK_11"] = System.Convert.ToInt64(newRow2["WORK_11"]) + System.Convert.ToInt64(row["WORK_11"]);
                newRow2["WORK_12"] = System.Convert.ToInt64(newRow2["WORK_12"]) + System.Convert.ToInt64(row["WORK_12"]);

                double sum = System.Convert.ToInt64(newRow2["WORK_1"]) + System.Convert.ToInt64(newRow2["WORK_2"]) + System.Convert.ToInt64(newRow2["WORK_3"]) + System.Convert.ToInt64(newRow2["WORK_4"])
                         + System.Convert.ToInt64(newRow2["WORK_5"]) + System.Convert.ToInt64(newRow2["WORK_6"]) + System.Convert.ToInt64(newRow2["WORK_7"]) + System.Convert.ToInt64(newRow2["WORK_8"])
                         + System.Convert.ToInt64(newRow2["WORK_9"]) + System.Convert.ToInt64(newRow2["WORK_10"]) + System.Convert.ToInt64(newRow2["WORK_11"]) + System.Convert.ToInt64(newRow2["WORK_12"]);

                newRow2["WORK_SUM"] = sum;
            }

            //gridTable.Rows.Add(newRow2);

            gridTable.Rows.InsertAt(newRow2, 0);

            DataRow[] sumRows = gridTable.Select("FLAG = 'SUM'");

            foreach (DataRow row in gridTable.Rows)
            {
                if (sumRows[0]["WORK_SUM"].toDecimal() > 0) { row["WORK_RATE"] = row["WORK_SUM"].toDecimal() / sumRows[0]["WORK_SUM"].toDecimal(); } else { row["WORK_RATE"] = 0; };

                if (row["WORK_1"].toDecimal() > 0) { row["WORK_1_R"] = row["WORK_1"].toDecimal() / sumRows[0]["WORK_1"].toDecimal(); } else { row["WORK_1_R"] = 0; };
                if (row["WORK_2"].toDecimal() > 0) { row["WORK_2_R"] = row["WORK_2"].toDecimal() / sumRows[0]["WORK_2"].toDecimal(); } else { row["WORK_2_R"] = 0; };
                if (row["WORK_3"].toDecimal() > 0) { row["WORK_3_R"] = row["WORK_3"].toDecimal() / sumRows[0]["WORK_3"].toDecimal(); } else { row["WORK_3_R"] = 0; };
                if (row["WORK_4"].toDecimal() > 0) { row["WORK_4_R"] = row["WORK_4"].toDecimal() / sumRows[0]["WORK_4"].toDecimal(); } else { row["WORK_4_R"] = 0; };
                if (row["WORK_5"].toDecimal() > 0) { row["WORK_5_R"] = row["WORK_5"].toDecimal() / sumRows[0]["WORK_5"].toDecimal(); } else { row["WORK_5_R"] = 0; };
                if (row["WORK_6"].toDecimal() > 0) { row["WORK_6_R"] = row["WORK_6"].toDecimal() / sumRows[0]["WORK_6"].toDecimal(); } else { row["WORK_6_R"] = 0; };
                if (row["WORK_7"].toDecimal() > 0) { row["WORK_7_R"] = row["WORK_7"].toDecimal() / sumRows[0]["WORK_7"].toDecimal(); } else { row["WORK_7_R"] = 0; };
                if (row["WORK_8"].toDecimal() > 0) { row["WORK_8_R"] = row["WORK_8"].toDecimal() / sumRows[0]["WORK_8"].toDecimal(); } else { row["WORK_8_R"] = 0; };
                if (row["WORK_9"].toDecimal() > 0) { row["WORK_9_R"] = row["WORK_9"].toDecimal() / sumRows[0]["WORK_9"].toDecimal(); } else { row["WORK_9_R"] = 0; };
                if (row["WORK_10"].toDecimal() > 0) { row["WORK_10_R"] = row["WORK_10"].toDecimal() / sumRows[0]["WORK_10"].toDecimal(); } else { row["WORK_10_R"] = 0; };
                if (row["WORK_11"].toDecimal() > 0) { row["WORK_11_R"] = row["WORK_11"].toDecimal() / sumRows[0]["WORK_11"].toDecimal(); } else { row["WORK_11_R"] = 0; };
                if (row["WORK_12"].toDecimal() > 0) { row["WORK_12_R"] = row["WORK_12"].toDecimal() / sumRows[0]["WORK_12"].toDecimal(); } else { row["WORK_12_R"] = 0; };

            }

            return gridTable;
        }

        static void SetTable(DataTable gridTable)
        {
            DataRow newRow = gridTable.NewRow();
            newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
            newRow["FLAG"] = "1";
            newRow["TYPE"] = "Contact";
            gridTable.Rows.Add(newRow);

            newRow = gridTable.NewRow();
            newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
            newRow["FLAG"] = "2";
            newRow["TYPE"] = "Actuator";
            gridTable.Rows.Add(newRow);

            newRow = gridTable.NewRow();
            newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
            newRow["FLAG"] = "3";
            newRow["TYPE"] = "원판";
            gridTable.Rows.Add(newRow);

            newRow = gridTable.NewRow();
            newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
            newRow["FLAG"] = "4";
            newRow["TYPE"] = "공구";
            gridTable.Rows.Add(newRow);

            newRow = gridTable.NewRow();
            newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
            newRow["FLAG"] = "5";
            newRow["TYPE"] = "외주가공비";
            gridTable.Rows.Add(newRow);

            newRow = gridTable.NewRow();
            newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
            newRow["FLAG"] = "6";
            newRow["TYPE"] = "기계장치";
            gridTable.Rows.Add(newRow);

            newRow = gridTable.NewRow();
            newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
            newRow["FLAG"] = "7";
            newRow["TYPE"] = "비품";
            gridTable.Rows.Add(newRow);

            newRow = gridTable.NewRow();
            newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
            newRow["FLAG"] = "8";
            newRow["TYPE"] = "소모품";
            gridTable.Rows.Add(newRow);

            newRow = gridTable.NewRow();
            newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
            newRow["FLAG"] = "9";
            newRow["TYPE"] = "조립자재(소모품)";
            gridTable.Rows.Add(newRow);
        }
    }
}
