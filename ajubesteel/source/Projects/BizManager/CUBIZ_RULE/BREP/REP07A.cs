using BizExecute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BREP
{
    public class REP07A
    {
        public static DataSet REP07A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY43(paramDS.Tables["RQSTDT"], bizExecute);
                DataTable dtRslt2 = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY44(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable dtNgRslt = DSHP.TSHP_NG_QUERY.TSHP_NG_QUERY9(paramDS.Tables["RQSTDT"], bizExecute);

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
                    DataRow[] rows = gridTable.Select("MONTH_FLAG = '" + row["END_MONTH"].ToString().Substring(4,2) +"'");

                    if (rows.Length > 0)
                    {
                        rows[0]["PART_QTY"] = row["PART_QTY"];
                        rows[0]["ACT_QTY"] = row["ACT_QTY"];
                    }
                }

                foreach (DataRow row in dtRslt2.Rows)
                {
                    switch(row["IS_REWORK"].ToString())
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
                    if (row["PART_QTY"].toDecimal() > 0) { row["M_RATE"] = row["M_PART_QTY"].toDecimal() / row["PART_QTY"].toDecimal();} else { row["M_RATE"] = 0; };
                    if (row["PART_QTY"].toDecimal() > 0) { row["S_RATE"] = row["S_PART_QTY"].toDecimal() / row["PART_QTY"].toDecimal();} else { row["S_RATE"] = 0; };

                    row["N_PART_QTY"] = row["R_PART_QTY"].toInt() + row["M_PART_QTY"].toInt();
                    row["N_RATE"] = row["R_RATE"].toDecimal() + row["M_RATE"].toDecimal();
                }

                gridTable.TableName = "RSLTDT";


                ////////////////////////////////////////////////////////////////////////////

                DataTable dtAmtRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY43(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable dtAmtNgRslt = DSHP.TSHP_NG_QUERY.TSHP_NG_QUERY10(paramDS.Tables["RQSTDT"], bizExecute);


                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WORK_YEAR", "YEAR");

                DataTable dtProdRslt = DORD.TORD_PRODUCT_QUERY.TORD_PRODUCT_QUERY16(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable groupDt = dtProdRslt
                                            .AsEnumerable()
                                            .GroupBy(g => new
                                            {
                                                PLT_CODE = g["PLT_CODE"],
                                                WORK_MONTH = g["BILL_DATE"].toDateString("MM"),
                                                CURR_UNIT = g["CURR_UNIT"]
                                            })
                                            .Select(r => new
                                            {
                                                PLT_CODE = r.Key.PLT_CODE,
                                                WORK_MONTH = r.Key.WORK_MONTH,
                                                CURR_UNIT = r.Key.CURR_UNIT,
                                                PROD_AMT = r.Sum(s => s["PROD_AMT"].toDecimal()),
                                            })
                                            .GroupBy(g => new
                                            {
                                                PLT_CODE = g.PLT_CODE,
                                                CURR_UNIT = g.CURR_UNIT

                                            })
                                            .Select(r => new
                                            {
                                                PLT_CODE = r.Key.PLT_CODE,
                                                //GUBUN = "국내",
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


                DataTable gridAmtTable = new DataTable();
                gridAmtTable.Columns.Add("NG_MONTH", typeof(String));
                gridAmtTable.Columns.Add("MONTH_FLAG", typeof(String));
                gridAmtTable.Columns.Add("PART_QTY", typeof(Decimal));
                gridAmtTable.Columns.Add("ACT_QTY", typeof(Decimal));

                gridAmtTable.Columns.Add("IN_NG_AMT", typeof(Decimal));
                gridAmtTable.Columns.Add("IN_NG_RATE", typeof(Decimal));

                gridAmtTable.Columns.Add("OUT_NG_AMT", typeof(Decimal));
                gridAmtTable.Columns.Add("OUT_NG_RATE", typeof(Decimal));

                gridAmtTable.Columns.Add("SUM_NG_AMT", typeof(Decimal));
                gridAmtTable.Columns.Add("SUM_NG_RATE", typeof(Decimal));

                for (int i = 0; i < 12; i++)
                {
                    DataRow newRow = gridAmtTable.NewRow();
                    newRow["NG_MONTH"] = (i + 1).ToString() + " 월";
                    newRow["MONTH_FLAG"] = (i + 1).ToString().PadLeft(2, '0');

                    gridAmtTable.Rows.Add(newRow);
                }

                foreach (DataRow row in dtAmtRslt.Rows)
                {
                    DataRow[] rows = gridAmtTable.Select("MONTH_FLAG = '" + row["END_MONTH"].ToString().Substring(4, 2) + "'");

                    if (rows.Length > 0)
                    {
                        rows[0]["PART_QTY"] = row["PART_QTY"];
                        rows[0]["ACT_QTY"] = row["ACT_QTY"];
                    }
                }


                foreach (DataRow row in dtAmtNgRslt.Rows)
                {
                    DataRow[] rows = gridAmtTable.Select("MONTH_FLAG = '" + row["NG_MONTH"].ToString().Substring(4, 2) + "'");

                    if (rows.Length > 0)
                    {
                        switch (row["NG_CAT"].ToString())
                        {
                            case "IN":
                                rows[0]["IN_NG_AMT"] = row["NG_COST"];
                                break;

                            case "FC":
                            case "OT":
                                rows[0]["OUT_NG_AMT"] = +rows[0]["OUT_NG_AMT"].toDecimal() + row["NG_COST"].toDecimal();
                                break;
                        }
                    }
                }

                string[] month = new string[] { "JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC" };

                if (groupDt.Rows.Count > 0)
                {
                    int i = 0;
                    foreach (DataRow row in gridAmtTable.Rows)
                    {
                        if (groupDt.Rows[0][month[i]].toDecimal() > 0) { row["IN_NG_RATE"] = row["IN_NG_AMT"].toDecimal() / groupDt.Rows[0][month[i]].toDecimal(); } else { row["IN_NG_RATE"] = 0; };
                        if (groupDt.Rows[0][month[i]].toDecimal() > 0) { row["OUT_NG_RATE"] = row["OUT_NG_AMT"].toDecimal() / groupDt.Rows[0][month[i]].toDecimal(); } else { row["OUT_NG_RATE"] = 0; };


                        row["SUM_NG_AMT"] = row["IN_NG_AMT"].toInt() + row["OUT_NG_AMT"].toInt();
                        if (groupDt.Rows[0][month[i]].toDecimal() > 0) { row["SUM_NG_RATE"] = row["SUM_NG_AMT"].toDecimal() / groupDt.Rows[0][month[i]].toDecimal(); } else { row["SUM_NG_RATE"] = 0; };

                        i++;
                    }
                }

                


                gridAmtTable.TableName = "RSLTDT2";




                paramDS.Tables.Add(gridTable);
                paramDS.Tables.Add(gridAmtTable);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet REP07A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DSHP.TSHP_NG_QUERY.TSHP_NG_QUERY11(paramDS.Tables["RQSTDT"], bizExecute);
                DataTable dtDesRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY46(paramDS.Tables["RQSTDT"], bizExecute);

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

                DataTable ngTable1 = ngType1(cloneTable, dtRslt, dtDesRslt);
                ngTable1.TableName = "RSLTDT";

                DataTable ngTable2 = ngType2(cloneTable, dtRslt);
                ngTable2.TableName = "RSLTDT2";

                DataTable ngTable3 = ngType3(cloneTable, dtRslt);
                ngTable3.TableName = "RSLTDT3";

                DataTable dtProdTable = DORD.TORD_PRODUCT_QUERY.TORD_PRODUCT_QUERY19(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable ngTable4 = ngType4(cloneTable, dtProdTable);
                ngTable4.TableName = "RSLTDT4";

                paramDS.Tables.Add(ngTable1);
                paramDS.Tables.Add(ngTable2);
                paramDS.Tables.Add(ngTable3);
                paramDS.Tables.Add(ngTable4);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet REP07A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
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

                DataTable ngTable2 = claimType2(cloneTable, dtAsRslt);
                ngTable2.TableName = "RSLTDT2";

                paramDS.Tables.Add(ngTable1);
                paramDS.Tables.Add(ngTable2);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        static DataTable ngType1(DataTable cloneTable, DataTable oriTable, DataTable oriDesTable)
        {
            DataTable gridTable = cloneTable.Clone();

            foreach (DataRow row in oriTable.Rows)
            {
                DataRow[] rows = gridTable.Select("FLAG = '" + row["DETAIL_CAUSE"].ToString() + "'");

                if (rows.Length == 0)
                {
                    DataRow newRow = gridTable.NewRow();
                    newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                    newRow["FLAG"] = row["DETAIL_CAUSE"];
                    newRow["TYPE"] = row["NG_NAME"];

                    gridTable.Rows.Add(newRow);
                }

                rows = gridTable.Select("FLAG = '" + row["DETAIL_CAUSE"].ToString() + "'");

                if (rows.Length > 0)
                {
                    if (row["NG_MONTH"].ToString().Substring(4, 2) == "01") rows[0]["WORK_1"] = rows[0]["WORK_1"].toInt() + row["QUANTITY"].toInt();
                    if (row["NG_MONTH"].ToString().Substring(4, 2) == "02") rows[0]["WORK_2"] = rows[0]["WORK_2"].toInt() + row["QUANTITY"].toInt();
                    if (row["NG_MONTH"].ToString().Substring(4, 2) == "03") rows[0]["WORK_3"] = rows[0]["WORK_3"].toInt() + row["QUANTITY"].toInt();
                    if (row["NG_MONTH"].ToString().Substring(4, 2) == "04") rows[0]["WORK_4"] = rows[0]["WORK_4"].toInt() + row["QUANTITY"].toInt();
                    if (row["NG_MONTH"].ToString().Substring(4, 2) == "05") rows[0]["WORK_5"] = rows[0]["WORK_5"].toInt() + row["QUANTITY"].toInt();
                    if (row["NG_MONTH"].ToString().Substring(4, 2) == "06") rows[0]["WORK_6"] = rows[0]["WORK_6"].toInt() + row["QUANTITY"].toInt();
                    if (row["NG_MONTH"].ToString().Substring(4, 2) == "07") rows[0]["WORK_7"] = rows[0]["WORK_7"].toInt() + row["QUANTITY"].toInt();
                    if (row["NG_MONTH"].ToString().Substring(4, 2) == "08") rows[0]["WORK_8"] = rows[0]["WORK_8"].toInt() + row["QUANTITY"].toInt();
                    if (row["NG_MONTH"].ToString().Substring(4, 2) == "09") rows[0]["WORK_9"] = rows[0]["WORK_9"].toInt() + row["QUANTITY"].toInt();
                    if (row["NG_MONTH"].ToString().Substring(4, 2) == "10") rows[0]["WORK_10"] = rows[0]["WORK_10"].toInt() + row["QUANTITY"].toInt();
                    if (row["NG_MONTH"].ToString().Substring(4, 2) == "11") rows[0]["WORK_11"] = rows[0]["WORK_11"].toInt() + row["QUANTITY"].toInt();
                    if (row["NG_MONTH"].ToString().Substring(4, 2) == "12") rows[0]["WORK_12"] = rows[0]["WORK_12"].toInt() + row["QUANTITY"].toInt();

                    double sum = rows[0]["WORK_1"].toInt() + rows[0]["WORK_2"].toInt() + rows[0]["WORK_3"].toInt() + rows[0]["WORK_4"].toInt()
                                 + rows[0]["WORK_5"].toInt() + rows[0]["WORK_6"].toInt() + rows[0]["WORK_7"].toInt() + rows[0]["WORK_8"].toInt()
                                 + rows[0]["WORK_9"].toInt() + rows[0]["WORK_10"].toInt() + rows[0]["WORK_11"].toInt() + rows[0]["WORK_12"].toInt();

                    rows[0]["WORK_SUM"] = sum;
                }
            }


            //설계변경(재가공)
            DataRow[] reMct = oriDesTable.Select("IS_REMCT = '1'");
            foreach (DataRow row in reMct)
            {
                DataRow[] rows = gridTable.Select("FLAG = 'DES_REMCT'");

                if (rows.Length == 0)
                {
                    DataRow newRow = gridTable.NewRow();
                    newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                    newRow["FLAG"] = "DES_REMCT";
                    newRow["TYPE"] = "설계변경(재가공)";

                    gridTable.Rows.Add(newRow);
                }

                rows = gridTable.Select("FLAG = 'DES_REMCT'");

                if (rows.Length > 0)
                {
                    if (row["REG_DATE"].ToString().Substring(4, 2) == "01") rows[0]["WORK_1"] = rows[0]["WORK_1"].toInt() + row["PART_QTY"].toInt();
                    if (row["REG_DATE"].ToString().Substring(4, 2) == "02") rows[0]["WORK_2"] = rows[0]["WORK_2"].toInt() + row["PART_QTY"].toInt();
                    if (row["REG_DATE"].ToString().Substring(4, 2) == "03") rows[0]["WORK_3"] = rows[0]["WORK_3"].toInt() + row["PART_QTY"].toInt();
                    if (row["REG_DATE"].ToString().Substring(4, 2) == "04") rows[0]["WORK_4"] = rows[0]["WORK_4"].toInt() + row["PART_QTY"].toInt();
                    if (row["REG_DATE"].ToString().Substring(4, 2) == "05") rows[0]["WORK_5"] = rows[0]["WORK_5"].toInt() + row["PART_QTY"].toInt();
                    if (row["REG_DATE"].ToString().Substring(4, 2) == "06") rows[0]["WORK_6"] = rows[0]["WORK_6"].toInt() + row["PART_QTY"].toInt();
                    if (row["REG_DATE"].ToString().Substring(4, 2) == "07") rows[0]["WORK_7"] = rows[0]["WORK_7"].toInt() + row["PART_QTY"].toInt();
                    if (row["REG_DATE"].ToString().Substring(4, 2) == "08") rows[0]["WORK_8"] = rows[0]["WORK_8"].toInt() + row["PART_QTY"].toInt();
                    if (row["REG_DATE"].ToString().Substring(4, 2) == "09") rows[0]["WORK_9"] = rows[0]["WORK_9"].toInt() + row["PART_QTY"].toInt();
                    if (row["REG_DATE"].ToString().Substring(4, 2) == "10") rows[0]["WORK_10"] = rows[0]["WORK_10"].toInt() + row["PART_QTY"].toInt();
                    if (row["REG_DATE"].ToString().Substring(4, 2) == "11") rows[0]["WORK_11"] = rows[0]["WORK_11"].toInt() + row["PART_QTY"].toInt();
                    if (row["REG_DATE"].ToString().Substring(4, 2) == "12") rows[0]["WORK_12"] = rows[0]["WORK_12"].toInt() + row["PART_QTY"].toInt();

                    double sum = rows[0]["WORK_1"].toInt() + rows[0]["WORK_2"].toInt() + rows[0]["WORK_3"].toInt() + rows[0]["WORK_4"].toInt()
                                 + rows[0]["WORK_5"].toInt() + rows[0]["WORK_6"].toInt() + rows[0]["WORK_7"].toInt() + rows[0]["WORK_8"].toInt()
                                 + rows[0]["WORK_9"].toInt() + rows[0]["WORK_10"].toInt() + rows[0]["WORK_11"].toInt() + rows[0]["WORK_12"].toInt();

                    rows[0]["WORK_SUM"] = sum;
                }
            }

            //설계변경(수정)

            DataRow[] reModify = oriDesTable.Select("IS_MODIFY = '1'");

            foreach (DataRow row in reModify)
            {
                DataRow[] rows = gridTable.Select("FLAG = 'DES_MODIFY'");

                if (rows.Length == 0)
                {
                    DataRow newRow = gridTable.NewRow();
                    newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                    newRow["FLAG"] = "DES_MODIFY";
                    newRow["TYPE"] = "설계변경(수정)";

                    gridTable.Rows.Add(newRow);
                }

                rows = gridTable.Select("FLAG = 'DES_MODIFY'");

                if (rows.Length > 0)
                {
                    if (row["REG_DATE"].ToString().Substring(4, 2) == "01") rows[0]["WORK_1"] = rows[0]["WORK_1"].toInt() + row["PART_QTY"].toInt();
                    if (row["REG_DATE"].ToString().Substring(4, 2) == "02") rows[0]["WORK_2"] = rows[0]["WORK_2"].toInt() + row["PART_QTY"].toInt();
                    if (row["REG_DATE"].ToString().Substring(4, 2) == "03") rows[0]["WORK_3"] = rows[0]["WORK_3"].toInt() + row["PART_QTY"].toInt();
                    if (row["REG_DATE"].ToString().Substring(4, 2) == "04") rows[0]["WORK_4"] = rows[0]["WORK_4"].toInt() + row["PART_QTY"].toInt();
                    if (row["REG_DATE"].ToString().Substring(4, 2) == "05") rows[0]["WORK_5"] = rows[0]["WORK_5"].toInt() + row["PART_QTY"].toInt();
                    if (row["REG_DATE"].ToString().Substring(4, 2) == "06") rows[0]["WORK_6"] = rows[0]["WORK_6"].toInt() + row["PART_QTY"].toInt();
                    if (row["REG_DATE"].ToString().Substring(4, 2) == "07") rows[0]["WORK_7"] = rows[0]["WORK_7"].toInt() + row["PART_QTY"].toInt();
                    if (row["REG_DATE"].ToString().Substring(4, 2) == "08") rows[0]["WORK_8"] = rows[0]["WORK_8"].toInt() + row["PART_QTY"].toInt();
                    if (row["REG_DATE"].ToString().Substring(4, 2) == "09") rows[0]["WORK_9"] = rows[0]["WORK_9"].toInt() + row["PART_QTY"].toInt();
                    if (row["REG_DATE"].ToString().Substring(4, 2) == "10") rows[0]["WORK_10"] = rows[0]["WORK_10"].toInt() + row["PART_QTY"].toInt();
                    if (row["REG_DATE"].ToString().Substring(4, 2) == "11") rows[0]["WORK_11"] = rows[0]["WORK_11"].toInt() + row["PART_QTY"].toInt();
                    if (row["REG_DATE"].ToString().Substring(4, 2) == "12") rows[0]["WORK_12"] = rows[0]["WORK_12"].toInt() + row["PART_QTY"].toInt();

                    double sum = rows[0]["WORK_1"].toInt() + rows[0]["WORK_2"].toInt() + rows[0]["WORK_3"].toInt() + rows[0]["WORK_4"].toInt()
                                 + rows[0]["WORK_5"].toInt() + rows[0]["WORK_6"].toInt() + rows[0]["WORK_7"].toInt() + rows[0]["WORK_8"].toInt()
                                 + rows[0]["WORK_9"].toInt() + rows[0]["WORK_10"].toInt() + rows[0]["WORK_11"].toInt() + rows[0]["WORK_12"].toInt();

                    rows[0]["WORK_SUM"] = sum;
                }
            }

            DataRow newRow2 = gridTable.NewRow();
            newRow2["PLT_CODE"] = ConnInfo.PLT_CODE;
            newRow2["FLAG"] = "SUM";
            newRow2["TYPE"] = "사내 유형별 합계";

            foreach (DataRow row in gridTable.Rows)
            {
                newRow2["WORK_1"] = newRow2["WORK_1"].toInt() + row["WORK_1"].toInt();
                newRow2["WORK_2"] = newRow2["WORK_2"].toInt() + row["WORK_2"].toInt();
                newRow2["WORK_3"] = newRow2["WORK_3"].toInt() + row["WORK_3"].toInt();
                newRow2["WORK_4"] = newRow2["WORK_4"].toInt() + row["WORK_4"].toInt();
                newRow2["WORK_5"] = newRow2["WORK_5"].toInt() + row["WORK_5"].toInt();
                newRow2["WORK_6"] = newRow2["WORK_6"].toInt() + row["WORK_6"].toInt();
                newRow2["WORK_7"] = newRow2["WORK_7"].toInt() + row["WORK_7"].toInt();
                newRow2["WORK_8"] = newRow2["WORK_8"].toInt() + row["WORK_8"].toInt();
                newRow2["WORK_9"] = newRow2["WORK_9"].toInt() + row["WORK_9"].toInt();
                newRow2["WORK_10"] = newRow2["WORK_10"].toInt() + row["WORK_10"].toInt();
                newRow2["WORK_11"] = newRow2["WORK_11"].toInt() + row["WORK_11"].toInt();
                newRow2["WORK_12"] = newRow2["WORK_12"].toInt() + row["WORK_12"].toInt();

                double sum = newRow2["WORK_1"].toInt() + newRow2["WORK_2"].toInt() + newRow2["WORK_3"].toInt() + newRow2["WORK_4"].toInt()
                         + newRow2["WORK_5"].toInt() + newRow2["WORK_6"].toInt() + newRow2["WORK_7"].toInt() + newRow2["WORK_8"].toInt()
                         + newRow2["WORK_9"].toInt() + newRow2["WORK_10"].toInt() + newRow2["WORK_11"].toInt() + newRow2["WORK_12"].toInt();

                newRow2["WORK_SUM"] = sum;
            }

            //gridTable.Rows.Add(newRow2);
            gridTable.Rows.InsertAt(newRow2, 0);

            DataRow[] sumRows = gridTable.Select("FLAG = 'SUM'");

            foreach (DataRow row in gridTable.Rows)
            {
                if (sumRows[0]["WORK_SUM"].toDecimal() > 0) { row["WORK_RATE"] = row["WORK_SUM"].toDecimal() / sumRows[0]["WORK_SUM"].toDecimal(); } else { row["WORK_RATE"] = 0; };
            }

            return gridTable;
        }

        static DataTable ngType2(DataTable cloneTable, DataTable oriTable)
        {
            DataTable gridTable = cloneTable.Clone();

            foreach (DataRow row in oriTable.Rows)
            {
                if (row["NG_CAT"].ToString() != "OT") continue;
                if (row["OVND_CODE"].ToString() == "") continue;

                DataRow[] rows = gridTable.Select("FLAG = '" + row["OVND_CODE"].ToString() + "'");

                if (rows.Length == 0)
                {
                    DataRow newRow = gridTable.NewRow();
                    newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                    newRow["FLAG"] = row["OVND_CODE"];
                    newRow["TYPE"] = row["OVND_NAME"];

                    gridTable.Rows.Add(newRow);
                }

                rows = gridTable.Select("FLAG = '" + row["OVND_CODE"].ToString() + "'");

                if (rows.Length > 0)
                {
                    if (row["NG_MONTH"].ToString().Substring(4, 2) == "01") rows[0]["WORK_1"] = rows[0]["WORK_1"].toInt() + row["QUANTITY"].toInt();
                    if (row["NG_MONTH"].ToString().Substring(4, 2) == "02") rows[0]["WORK_2"] = rows[0]["WORK_2"].toInt() + row["QUANTITY"].toInt();
                    if (row["NG_MONTH"].ToString().Substring(4, 2) == "03") rows[0]["WORK_3"] = rows[0]["WORK_3"].toInt() + row["QUANTITY"].toInt();
                    if (row["NG_MONTH"].ToString().Substring(4, 2) == "04") rows[0]["WORK_4"] = rows[0]["WORK_4"].toInt() + row["QUANTITY"].toInt();
                    if (row["NG_MONTH"].ToString().Substring(4, 2) == "05") rows[0]["WORK_5"] = rows[0]["WORK_5"].toInt() + row["QUANTITY"].toInt();
                    if (row["NG_MONTH"].ToString().Substring(4, 2) == "06") rows[0]["WORK_6"] = rows[0]["WORK_6"].toInt() + row["QUANTITY"].toInt();
                    if (row["NG_MONTH"].ToString().Substring(4, 2) == "07") rows[0]["WORK_7"] = rows[0]["WORK_7"].toInt() + row["QUANTITY"].toInt();
                    if (row["NG_MONTH"].ToString().Substring(4, 2) == "08") rows[0]["WORK_8"] = rows[0]["WORK_8"].toInt() + row["QUANTITY"].toInt();
                    if (row["NG_MONTH"].ToString().Substring(4, 2) == "09") rows[0]["WORK_9"] = rows[0]["WORK_9"].toInt() + row["QUANTITY"].toInt();
                    if (row["NG_MONTH"].ToString().Substring(4, 2) == "10") rows[0]["WORK_10"] = rows[0]["WORK_10"].toInt() + row["QUANTITY"].toInt();
                    if (row["NG_MONTH"].ToString().Substring(4, 2) == "11") rows[0]["WORK_11"] = rows[0]["WORK_11"].toInt() + row["QUANTITY"].toInt();
                    if (row["NG_MONTH"].ToString().Substring(4, 2) == "12") rows[0]["WORK_12"] = rows[0]["WORK_12"].toInt() + row["QUANTITY"].toInt();

                    double sum = rows[0]["WORK_1"].toInt() + rows[0]["WORK_2"].toInt() + rows[0]["WORK_3"].toInt() + rows[0]["WORK_4"].toInt()
                                 + rows[0]["WORK_5"].toInt() + rows[0]["WORK_6"].toInt() + rows[0]["WORK_7"].toInt() + rows[0]["WORK_8"].toInt()
                                 + rows[0]["WORK_9"].toInt() + rows[0]["WORK_10"].toInt() + rows[0]["WORK_11"].toInt() + rows[0]["WORK_12"].toInt();

                    rows[0]["WORK_SUM"] = sum;
                }
            }

            DataRow newRow2 = gridTable.NewRow();
            newRow2["PLT_CODE"] = ConnInfo.PLT_CODE;
            newRow2["FLAG"] = "SUM";
            newRow2["TYPE"] = "외주 업체별 합계";

            foreach (DataRow row in gridTable.Rows)
            {
                newRow2["WORK_1"] = newRow2["WORK_1"].toInt() + row["WORK_1"].toInt();
                newRow2["WORK_2"] = newRow2["WORK_2"].toInt() + row["WORK_2"].toInt();
                newRow2["WORK_3"] = newRow2["WORK_3"].toInt() + row["WORK_3"].toInt();
                newRow2["WORK_4"] = newRow2["WORK_4"].toInt() + row["WORK_4"].toInt();
                newRow2["WORK_5"] = newRow2["WORK_5"].toInt() + row["WORK_5"].toInt();
                newRow2["WORK_6"] = newRow2["WORK_6"].toInt() + row["WORK_6"].toInt();
                newRow2["WORK_7"] = newRow2["WORK_7"].toInt() + row["WORK_7"].toInt();
                newRow2["WORK_8"] = newRow2["WORK_8"].toInt() + row["WORK_8"].toInt();
                newRow2["WORK_9"] = newRow2["WORK_9"].toInt() + row["WORK_9"].toInt();
                newRow2["WORK_10"] = newRow2["WORK_10"].toInt() + row["WORK_10"].toInt();
                newRow2["WORK_11"] = newRow2["WORK_11"].toInt() + row["WORK_11"].toInt();
                newRow2["WORK_12"] = newRow2["WORK_12"].toInt() + row["WORK_12"].toInt();

                double sum = newRow2["WORK_1"].toInt() + newRow2["WORK_2"].toInt() + newRow2["WORK_3"].toInt() + newRow2["WORK_4"].toInt()
                         + newRow2["WORK_5"].toInt() + newRow2["WORK_6"].toInt() + newRow2["WORK_7"].toInt() + newRow2["WORK_8"].toInt()
                         + newRow2["WORK_9"].toInt() + newRow2["WORK_10"].toInt() + newRow2["WORK_11"].toInt() + newRow2["WORK_12"].toInt();

                newRow2["WORK_SUM"] = sum;
            }

            //gridTable.Rows.Add(newRow2);
            gridTable.Rows.InsertAt(newRow2, 0);

            DataRow[] sumRows = gridTable.Select("FLAG = 'SUM'");

            foreach (DataRow row in gridTable.Rows)
            {
                if (sumRows[0]["WORK_SUM"].toDecimal() > 0) { row["WORK_RATE"] = row["WORK_SUM"].toDecimal() / sumRows[0]["WORK_SUM"].toDecimal(); } else { row["WORK_RATE"] = 0; };
            }



            return gridTable;
        }

        static DataTable ngType3(DataTable cloneTable, DataTable oriTable)
        {
            DataTable gridTable = cloneTable.Clone();

            DataRow newRow = gridTable.NewRow();
            newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
            newRow["FLAG"] = "IN";
            newRow["TYPE"] = "사내품질비용";
            gridTable.Rows.Add(newRow);

            newRow = gridTable.NewRow();
            newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
            newRow["FLAG"] = "OUT";
            newRow["TYPE"] = "외부품질비용";
            gridTable.Rows.Add(newRow);

            foreach (DataRow row in oriTable.Rows)
            {
                switch(row["NG_CAT"].ToString())
                {
                    case "IN":
                        DataRow[] INrows = gridTable.Select("FLAG = 'IN'");

                        if (INrows.Length > 0)
                        {
                            if (row["NG_MONTH"].ToString().Substring(4, 2) == "01") INrows[0]["WORK_1"] = INrows[0]["WORK_1"].toInt() + row["NG_COST"].toInt();
                            if (row["NG_MONTH"].ToString().Substring(4, 2) == "02") INrows[0]["WORK_2"] = INrows[0]["WORK_2"].toInt() + row["NG_COST"].toInt();
                            if (row["NG_MONTH"].ToString().Substring(4, 2) == "03") INrows[0]["WORK_3"] = INrows[0]["WORK_3"].toInt() + row["NG_COST"].toInt();
                            if (row["NG_MONTH"].ToString().Substring(4, 2) == "04") INrows[0]["WORK_4"] = INrows[0]["WORK_4"].toInt() + row["NG_COST"].toInt();
                            if (row["NG_MONTH"].ToString().Substring(4, 2) == "05") INrows[0]["WORK_5"] = INrows[0]["WORK_5"].toInt() + row["NG_COST"].toInt();
                            if (row["NG_MONTH"].ToString().Substring(4, 2) == "06") INrows[0]["WORK_6"] = INrows[0]["WORK_6"].toInt() + row["NG_COST"].toInt();
                            if (row["NG_MONTH"].ToString().Substring(4, 2) == "07") INrows[0]["WORK_7"] = INrows[0]["WORK_7"].toInt() + row["NG_COST"].toInt();
                            if (row["NG_MONTH"].ToString().Substring(4, 2) == "08") INrows[0]["WORK_8"] = INrows[0]["WORK_8"].toInt() + row["NG_COST"].toInt();
                            if (row["NG_MONTH"].ToString().Substring(4, 2) == "09") INrows[0]["WORK_9"] = INrows[0]["WORK_9"].toInt() + row["NG_COST"].toInt();
                            if (row["NG_MONTH"].ToString().Substring(4, 2) == "10") INrows[0]["WORK_10"] = INrows[0]["WORK_10"].toInt() + row["NG_COST"].toInt();
                            if (row["NG_MONTH"].ToString().Substring(4, 2) == "11") INrows[0]["WORK_11"] = INrows[0]["WORK_11"].toInt() + row["NG_COST"].toInt();
                            if (row["NG_MONTH"].ToString().Substring(4, 2) == "12") INrows[0]["WORK_12"] = INrows[0]["WORK_12"].toInt() + row["NG_COST"].toInt();

                            double sum = INrows[0]["WORK_1"].toInt() + INrows[0]["WORK_2"].toInt() + INrows[0]["WORK_3"].toInt() + INrows[0]["WORK_4"].toInt()
                                         + INrows[0]["WORK_5"].toInt() + INrows[0]["WORK_6"].toInt() + INrows[0]["WORK_7"].toInt() + INrows[0]["WORK_8"].toInt()
                                         + INrows[0]["WORK_9"].toInt() + INrows[0]["WORK_10"].toInt() + INrows[0]["WORK_11"].toInt() + INrows[0]["WORK_12"].toInt();

                            INrows[0]["WORK_SUM"] = sum;
                        }
                        break;

                    case "FC":
                    case "OT":
                        DataRow[] rows = gridTable.Select("FLAG = 'OUT'");

                        if (rows.Length > 0)
                        {
                            if (row["NG_MONTH"].ToString().Substring(4, 2) == "01") rows[0]["WORK_1"] = rows[0]["WORK_1"].toInt() + row["NG_COST"].toInt();
                            if (row["NG_MONTH"].ToString().Substring(4, 2) == "02") rows[0]["WORK_2"] = rows[0]["WORK_2"].toInt() + row["NG_COST"].toInt();
                            if (row["NG_MONTH"].ToString().Substring(4, 2) == "03") rows[0]["WORK_3"] = rows[0]["WORK_3"].toInt() + row["NG_COST"].toInt();
                            if (row["NG_MONTH"].ToString().Substring(4, 2) == "04") rows[0]["WORK_4"] = rows[0]["WORK_4"].toInt() + row["NG_COST"].toInt();
                            if (row["NG_MONTH"].ToString().Substring(4, 2) == "05") rows[0]["WORK_5"] = rows[0]["WORK_5"].toInt() + row["NG_COST"].toInt();
                            if (row["NG_MONTH"].ToString().Substring(4, 2) == "06") rows[0]["WORK_6"] = rows[0]["WORK_6"].toInt() + row["NG_COST"].toInt();
                            if (row["NG_MONTH"].ToString().Substring(4, 2) == "07") rows[0]["WORK_7"] = rows[0]["WORK_7"].toInt() + row["NG_COST"].toInt();
                            if (row["NG_MONTH"].ToString().Substring(4, 2) == "08") rows[0]["WORK_8"] = rows[0]["WORK_8"].toInt() + row["NG_COST"].toInt();
                            if (row["NG_MONTH"].ToString().Substring(4, 2) == "09") rows[0]["WORK_9"] = rows[0]["WORK_9"].toInt() + row["NG_COST"].toInt();
                            if (row["NG_MONTH"].ToString().Substring(4, 2) == "10") rows[0]["WORK_10"] = rows[0]["WORK_10"].toInt() + row["NG_COST"].toInt();
                            if (row["NG_MONTH"].ToString().Substring(4, 2) == "11") rows[0]["WORK_11"] = rows[0]["WORK_11"].toInt() + row["NG_COST"].toInt();
                            if (row["NG_MONTH"].ToString().Substring(4, 2) == "12") rows[0]["WORK_12"] = rows[0]["WORK_12"].toInt() + row["NG_COST"].toInt();

                            double sum = rows[0]["WORK_1"].toInt() + rows[0]["WORK_2"].toInt() + rows[0]["WORK_3"].toInt() + rows[0]["WORK_4"].toInt()
                                         + rows[0]["WORK_5"].toInt() + rows[0]["WORK_6"].toInt() + rows[0]["WORK_7"].toInt() + rows[0]["WORK_8"].toInt()
                                         + rows[0]["WORK_9"].toInt() + rows[0]["WORK_10"].toInt() + rows[0]["WORK_11"].toInt() + rows[0]["WORK_12"].toInt();

                            rows[0]["WORK_SUM"] = sum;
                        }
                        break;
                }
            }

            DataRow newRow2 = gridTable.NewRow();
            newRow2["PLT_CODE"] = ConnInfo.PLT_CODE;
            newRow2["FLAG"] = "SUM";
            newRow2["TYPE"] = "합  계(원)";

            foreach (DataRow row in gridTable.Rows)
            {
                newRow2["WORK_1"] = newRow2["WORK_1"].toInt() + row["WORK_1"].toInt();
                newRow2["WORK_2"] = newRow2["WORK_2"].toInt() + row["WORK_2"].toInt();
                newRow2["WORK_3"] = newRow2["WORK_3"].toInt() + row["WORK_3"].toInt();
                newRow2["WORK_4"] = newRow2["WORK_4"].toInt() + row["WORK_4"].toInt();
                newRow2["WORK_5"] = newRow2["WORK_5"].toInt() + row["WORK_5"].toInt();
                newRow2["WORK_6"] = newRow2["WORK_6"].toInt() + row["WORK_6"].toInt();
                newRow2["WORK_7"] = newRow2["WORK_7"].toInt() + row["WORK_7"].toInt();
                newRow2["WORK_8"] = newRow2["WORK_8"].toInt() + row["WORK_8"].toInt();
                newRow2["WORK_9"] = newRow2["WORK_9"].toInt() + row["WORK_9"].toInt();
                newRow2["WORK_10"] = newRow2["WORK_10"].toInt() + row["WORK_10"].toInt();
                newRow2["WORK_11"] = newRow2["WORK_11"].toInt() + row["WORK_11"].toInt();
                newRow2["WORK_12"] = newRow2["WORK_12"].toInt() + row["WORK_12"].toInt();

                double sum = newRow2["WORK_1"].toInt() + newRow2["WORK_2"].toInt() + newRow2["WORK_3"].toInt() + newRow2["WORK_4"].toInt()
                         + newRow2["WORK_5"].toInt() + newRow2["WORK_6"].toInt() + newRow2["WORK_7"].toInt() + newRow2["WORK_8"].toInt()
                         + newRow2["WORK_9"].toInt() + newRow2["WORK_10"].toInt() + newRow2["WORK_11"].toInt() + newRow2["WORK_12"].toInt();

                newRow2["WORK_SUM"] = sum;
            }

            //gridTable.Rows.Add(newRow2);
            gridTable.Rows.InsertAt(newRow2, 0);

            DataRow[] sumRows = gridTable.Select("FLAG = 'SUM'");

            foreach (DataRow row in gridTable.Rows)
            {
                if (sumRows[0]["WORK_SUM"].toDecimal() > 0) { row["WORK_RATE"] = row["WORK_SUM"].toDecimal() / sumRows[0]["WORK_SUM"].toDecimal(); } else { row["WORK_RATE"] = 0; };
            }

            return gridTable;
        }

        static DataTable ngType4(DataTable cloneTable, DataTable oriTable)
        {
            DataTable gridTable = cloneTable.Clone();

            foreach (DataRow row in oriTable.Rows)
            {
                DataRow[] rows = gridTable.Select("FLAG = '" + row["ITEM_FLAG"].ToString() + "'");

                if (rows.Length == 0)
                {
                    DataRow newRow = gridTable.NewRow();
                    newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                    newRow["FLAG"] = row["ITEM_FLAG"];
                    newRow["TYPE"] = row["ITEM_FLAG_NAME"];

                    gridTable.Rows.Add(newRow);
                }

                rows = gridTable.Select("FLAG = '" + row["ITEM_FLAG"].ToString() + "'");

                if (rows.Length > 0)
                {
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "01") rows[0]["WORK_1"] = rows[0]["WORK_1"].toInt() + row["PROD_QTY"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "02") rows[0]["WORK_2"] = rows[0]["WORK_2"].toInt() + row["PROD_QTY"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "03") rows[0]["WORK_3"] = rows[0]["WORK_3"].toInt() + row["PROD_QTY"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "04") rows[0]["WORK_4"] = rows[0]["WORK_4"].toInt() + row["PROD_QTY"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "05") rows[0]["WORK_5"] = rows[0]["WORK_5"].toInt() + row["PROD_QTY"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "06") rows[0]["WORK_6"] = rows[0]["WORK_6"].toInt() + row["PROD_QTY"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "07") rows[0]["WORK_7"] = rows[0]["WORK_7"].toInt() + row["PROD_QTY"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "08") rows[0]["WORK_8"] = rows[0]["WORK_8"].toInt() + row["PROD_QTY"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "09") rows[0]["WORK_9"] = rows[0]["WORK_9"].toInt() + row["PROD_QTY"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "10") rows[0]["WORK_10"] = rows[0]["WORK_10"].toInt() + row["PROD_QTY"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "11") rows[0]["WORK_11"] = rows[0]["WORK_11"].toInt() + row["PROD_QTY"].toInt();
                    if (row["ORD_MONTH"].ToString().Substring(4, 2) == "12") rows[0]["WORK_12"] = rows[0]["WORK_12"].toInt() + row["PROD_QTY"].toInt();

                    double sum = rows[0]["WORK_1"].toInt() + rows[0]["WORK_2"].toInt() + rows[0]["WORK_3"].toInt() + rows[0]["WORK_4"].toInt()
                                 + rows[0]["WORK_5"].toInt() + rows[0]["WORK_6"].toInt() + rows[0]["WORK_7"].toInt() + rows[0]["WORK_8"].toInt()
                                 + rows[0]["WORK_9"].toInt() + rows[0]["WORK_10"].toInt() + rows[0]["WORK_11"].toInt() + rows[0]["WORK_12"].toInt();

                    rows[0]["WORK_SUM"] = sum;
                }
            }

            DataRow newRow2 = gridTable.NewRow();
            newRow2["PLT_CODE"] = ConnInfo.PLT_CODE;
            newRow2["FLAG"] = "SUM";
            newRow2["TYPE"] = "납품 현황 합계";

            foreach (DataRow row in gridTable.Rows)
            {
                newRow2["WORK_1"] = newRow2["WORK_1"].toInt() + row["WORK_1"].toInt();
                newRow2["WORK_2"] = newRow2["WORK_2"].toInt() + row["WORK_2"].toInt();
                newRow2["WORK_3"] = newRow2["WORK_3"].toInt() + row["WORK_3"].toInt();
                newRow2["WORK_4"] = newRow2["WORK_4"].toInt() + row["WORK_4"].toInt();
                newRow2["WORK_5"] = newRow2["WORK_5"].toInt() + row["WORK_5"].toInt();
                newRow2["WORK_6"] = newRow2["WORK_6"].toInt() + row["WORK_6"].toInt();
                newRow2["WORK_7"] = newRow2["WORK_7"].toInt() + row["WORK_7"].toInt();
                newRow2["WORK_8"] = newRow2["WORK_8"].toInt() + row["WORK_8"].toInt();
                newRow2["WORK_9"] = newRow2["WORK_9"].toInt() + row["WORK_9"].toInt();
                newRow2["WORK_10"] = newRow2["WORK_10"].toInt() + row["WORK_10"].toInt();
                newRow2["WORK_11"] = newRow2["WORK_11"].toInt() + row["WORK_11"].toInt();
                newRow2["WORK_12"] = newRow2["WORK_12"].toInt() + row["WORK_12"].toInt();

                double sum = newRow2["WORK_1"].toInt() + newRow2["WORK_2"].toInt() + newRow2["WORK_3"].toInt() + newRow2["WORK_4"].toInt()
                         + newRow2["WORK_5"].toInt() + newRow2["WORK_6"].toInt() + newRow2["WORK_7"].toInt() + newRow2["WORK_8"].toInt()
                         + newRow2["WORK_9"].toInt() + newRow2["WORK_10"].toInt() + newRow2["WORK_11"].toInt() + newRow2["WORK_12"].toInt();

                newRow2["WORK_SUM"] = sum;
            }

            //gridTable.Rows.Add(newRow2);
            gridTable.Rows.InsertAt(newRow2, 0);

            DataRow[] sumRows = gridTable.Select("FLAG = 'SUM'");

            foreach (DataRow row in gridTable.Rows)
            {
                if (sumRows[0]["WORK_SUM"].toDecimal() > 0) { row["WORK_RATE"] = row["WORK_SUM"].toDecimal() / sumRows[0]["WORK_SUM"].toDecimal(); } else { row["WORK_RATE"] = 0; };
            }



            return gridTable;
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

                if (row["FLAG"].ToString() == "RESULT")
                {

                    DataRow[] rateRow = gridTable.Select("FLAG = 'RATE'");
                    DataRow[] goalRow = gridTable.Select("FLAG = 'GOAL'");

                    if (goalRow[0]["WORK_1"].toDecimal() > 0) { row["WORK_1"] = rateRow[0]["WORK_1"].toDecimal() / goalRow[0]["WORK_1"].toDecimal(); } else { row["WORK_1"] = 0; }
                    if (goalRow[0]["WORK_2"].toDecimal() > 0) { row["WORK_2"] = rateRow[0]["WORK_2"].toDecimal() / goalRow[0]["WORK_2"].toDecimal(); } else { row["WORK_2"] = 0; }
                    if (goalRow[0]["WORK_3"].toDecimal() > 0) { row["WORK_3"] = rateRow[0]["WORK_3"].toDecimal() / goalRow[0]["WORK_3"].toDecimal(); } else { row["WORK_3"] = 0; }
                    if (goalRow[0]["WORK_4"].toDecimal() > 0) { row["WORK_4"] = rateRow[0]["WORK_4"].toDecimal() / goalRow[0]["WORK_4"].toDecimal(); } else { row["WORK_4"] = 0; }
                    if (goalRow[0]["WORK_5"].toDecimal() > 0) { row["WORK_5"] = rateRow[0]["WORK_5"].toDecimal() / goalRow[0]["WORK_5"].toDecimal(); } else { row["WORK_5"] = 0; }
                    if (goalRow[0]["WORK_6"].toDecimal() > 0) { row["WORK_6"] = rateRow[0]["WORK_6"].toDecimal() / goalRow[0]["WORK_6"].toDecimal(); } else { row["WORK_6"] = 0; }
                    if (goalRow[0]["WORK_7"].toDecimal() > 0) { row["WORK_7"] = rateRow[0]["WORK_7"].toDecimal() / goalRow[0]["WORK_7"].toDecimal(); } else { row["WORK_7"] = 0; }
                    if (goalRow[0]["WORK_8"].toDecimal() > 0) { row["WORK_8"] = rateRow[0]["WORK_8"].toDecimal() / goalRow[0]["WORK_8"].toDecimal(); } else { row["WORK_8"] = 0; }
                    if (goalRow[0]["WORK_9"].toDecimal() > 0) { row["WORK_9"] = rateRow[0]["WORK_9"].toDecimal() / goalRow[0]["WORK_9"].toDecimal(); } else { row["WORK_9"] = 0; }
                    if (goalRow[0]["WORK_10"].toDecimal() > 0) { row["WORK_10"] = rateRow[0]["WORK_10"].toDecimal() / goalRow[0]["WORK_10"].toDecimal(); } else { row["WORK_10"] = 0; }
                    if (goalRow[0]["WORK_11"].toDecimal() > 0) { row["WORK_11"] = rateRow[0]["WORK_11"].toDecimal() / goalRow[0]["WORK_11"].toDecimal(); } else { row["WORK_11"] = 0; }
                    if (goalRow[0]["WORK_12"].toDecimal() > 0) { row["WORK_12"] = rateRow[0]["WORK_12"].toDecimal() / goalRow[0]["WORK_12"].toDecimal(); } else { row["WORK_12"] = 0; }
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

        static DataTable claimType2(DataTable cloneTable, DataTable oriTable)
        {
            DataTable gridTable = cloneTable.Clone();

            foreach (DataRow row in oriTable.Rows)
            {
                DataRow[] rows = gridTable.Select("FLAG = '" + row["CVND_CODE"].ToString() + "'");

                if (rows.Length == 0)
                {
                    DataRow newRow = gridTable.NewRow();
                    newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                    newRow["FLAG"] = row["CVND_CODE"];
                    newRow["TYPE"] = row["CVND_NAME"];

                    gridTable.Rows.Add(newRow);
                }

                rows = gridTable.Select("FLAG = '" + row["CVND_CODE"].ToString() + "'");

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

            DataRow newRow2 = gridTable.NewRow();
            newRow2["PLT_CODE"] = ConnInfo.PLT_CODE;
            newRow2["FLAG"] = "SUM";
            newRow2["TYPE"] = "사내 유형별 합계";

            foreach (DataRow row in gridTable.Rows)
            {
                newRow2["WORK_1"] = newRow2["WORK_1"].toInt() + row["WORK_1"].toInt();
                newRow2["WORK_2"] = newRow2["WORK_2"].toInt() + row["WORK_2"].toInt();
                newRow2["WORK_3"] = newRow2["WORK_3"].toInt() + row["WORK_3"].toInt();
                newRow2["WORK_4"] = newRow2["WORK_4"].toInt() + row["WORK_4"].toInt();
                newRow2["WORK_5"] = newRow2["WORK_5"].toInt() + row["WORK_5"].toInt();
                newRow2["WORK_6"] = newRow2["WORK_6"].toInt() + row["WORK_6"].toInt();
                newRow2["WORK_7"] = newRow2["WORK_7"].toInt() + row["WORK_7"].toInt();
                newRow2["WORK_8"] = newRow2["WORK_8"].toInt() + row["WORK_8"].toInt();
                newRow2["WORK_9"] = newRow2["WORK_9"].toInt() + row["WORK_9"].toInt();
                newRow2["WORK_10"] = newRow2["WORK_10"].toInt() + row["WORK_10"].toInt();
                newRow2["WORK_11"] = newRow2["WORK_11"].toInt() + row["WORK_11"].toInt();
                newRow2["WORK_12"] = newRow2["WORK_12"].toInt() + row["WORK_12"].toInt();

                double sum = newRow2["WORK_1"].toInt() + newRow2["WORK_2"].toInt() + newRow2["WORK_3"].toInt() + newRow2["WORK_4"].toInt()
                         + newRow2["WORK_5"].toInt() + newRow2["WORK_6"].toInt() + newRow2["WORK_7"].toInt() + newRow2["WORK_8"].toInt()
                         + newRow2["WORK_9"].toInt() + newRow2["WORK_10"].toInt() + newRow2["WORK_11"].toInt() + newRow2["WORK_12"].toInt();

                newRow2["WORK_SUM"] = sum;
            }

            //gridTable.Rows.Add(newRow2);
            gridTable.Rows.InsertAt(newRow2, 0);

            DataRow[] sumRows = gridTable.Select("FLAG = 'SUM'");

            foreach (DataRow row in gridTable.Rows)
            {
                if (sumRows[0]["WORK_SUM"].toDecimal() > 0) { row["WORK_RATE"] = row["WORK_SUM"].toDecimal() / sumRows[0]["WORK_SUM"].toDecimal(); } else { row["WORK_RATE"] = 0; };
            }

            return gridTable;
        }


    }
}
