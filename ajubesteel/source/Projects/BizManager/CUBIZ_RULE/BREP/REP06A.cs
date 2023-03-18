using BizExecute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BREP
{
    public class REP06A
    {
        public static DataSet REP06A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable cloneTable = new DataTable();
                cloneTable.Columns.Add("PLT_CODE", typeof(String));
                cloneTable.Columns.Add("FLAG", typeof(String));
                cloneTable.Columns.Add("TYPE", typeof(String));
                cloneTable.Columns.Add("WORK_1", typeof(string));
                cloneTable.Columns.Add("WORK_2", typeof(string));
                cloneTable.Columns.Add("WORK_3", typeof(string));
                cloneTable.Columns.Add("WORK_4", typeof(string));
                cloneTable.Columns.Add("WORK_5", typeof(string));
                cloneTable.Columns.Add("WORK_6", typeof(string));
                cloneTable.Columns.Add("WORK_7", typeof(string));
                cloneTable.Columns.Add("WORK_8", typeof(string));
                cloneTable.Columns.Add("WORK_9", typeof(string));
                cloneTable.Columns.Add("WORK_10", typeof(string));
                cloneTable.Columns.Add("WORK_11", typeof(string));
                cloneTable.Columns.Add("WORK_12", typeof(string));
                cloneTable.Columns.Add("WORK_SUM", typeof(string));

                cloneTable.Columns.Add("WORK_1_D", typeof(decimal));
                cloneTable.Columns.Add("WORK_2_D", typeof(decimal));
                cloneTable.Columns.Add("WORK_3_D", typeof(decimal));
                cloneTable.Columns.Add("WORK_4_D", typeof(decimal));
                cloneTable.Columns.Add("WORK_5_D", typeof(decimal));
                cloneTable.Columns.Add("WORK_6_D", typeof(decimal));
                cloneTable.Columns.Add("WORK_7_D", typeof(decimal));
                cloneTable.Columns.Add("WORK_8_D", typeof(decimal));
                cloneTable.Columns.Add("WORK_9_D", typeof(decimal));
                cloneTable.Columns.Add("WORK_10_D", typeof(decimal));
                cloneTable.Columns.Add("WORK_11_D", typeof(decimal));
                cloneTable.Columns.Add("WORK_12_D", typeof(decimal));
                cloneTable.Columns.Add("WORK_SUM_D", typeof(decimal));

                DataTable dtRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY41(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable dtworDay = DSTD.TSTD_WORKDAY.TSTD_WORKDAY_SER2(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable gridTable = cloneTable.Clone();

                DataRow newRow = gridTable.NewRow();
                newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                newRow["FLAG"] = "RATE";
                newRow["TYPE"] = "조립효율";
                for (int i = 1; i < 13; i++)
                {
                    newRow["WORK_" + i.ToString()] = string.Format("{0:N1}", 0.0);
                }

                for (int i = 1; i < 13; i++)
                {
                    newRow["WORK_" + i.ToString() + "_D"] = 0.0;
                }

                gridTable.Rows.Add(newRow);


                newRow = gridTable.NewRow();
                newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                newRow["FLAG"] = "WORK_TIME";
                newRow["TYPE"] = "근무시간";
                for (int i = 1; i < 13; i++)
                {
                    newRow["WORK_" + i.ToString()] = string.Format("{0:N0}", 0);
                }

                for (int i = 1; i < 13; i++)
                {
                    newRow["WORK_" + i.ToString() + "_D"] = 0.0;
                }

                gridTable.Rows.Add(newRow);


                newRow = gridTable.NewRow();
                newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                newRow["FLAG"] = "ACT";
                newRow["TYPE"] = "조립실적";
                for (int i = 1; i < 13; i++)
                {
                    newRow["WORK_" + i.ToString()] = string.Format("{0:N0}", 0);
                }

                for (int i = 1; i < 13; i++)
                {
                    newRow["WORK_" + i.ToString() + "_D"] = 0.0;
                }

                gridTable.Rows.Add(newRow);


                newRow = gridTable.NewRow();
                newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                newRow["FLAG"] = "DAY";
                newRow["TYPE"] = "근무일수";
                for (int i = 1; i < 13; i++)
                {
                    newRow["WORK_" + i.ToString()] = string.Format("{0:N0}", 0);
                }

                for (int i = 1; i < 13; i++)
                {
                    newRow["WORK_" + i.ToString() + "_D"] = 0.0;
                }

                gridTable.Rows.Add(newRow);


                int empCnt = 0;

                foreach (DataRow row in dtRslt.Rows)
                {
                    empCnt = row["EMP_COUNT"].toInt();

                    DataRow[] wRows = gridTable.Select("FLAG = 'ACT'");

                    if (wRows.Length > 0)
                    {
                        if (row["END_TIME"].ToString().Substring(4, 2) == "01")
                        {
                            wRows[0]["WORK_1_D"] = wRows[0]["WORK_1_D"].toInt() + row["LT"].toInt();
                            wRows[0]["WORK_1"] = string.Format("{0:n0}", wRows[0]["WORK_1_D"]);
                        }

                        if (row["END_TIME"].ToString().Substring(4, 2) == "02")
                        {
                            wRows[0]["WORK_2_D"] = wRows[0]["WORK_2_D"].toInt() + row["LT"].toInt();
                            wRows[0]["WORK_2"] = string.Format("{0:n0}", wRows[0]["WORK_2_D"]);
                        }

                        if (row["END_TIME"].ToString().Substring(4, 2) == "03")
                        {
                            wRows[0]["WORK_3_D"] = wRows[0]["WORK_3_D"].toInt() + row["LT"].toInt();
                            wRows[0]["WORK_3"] = string.Format("{0:n0}", wRows[0]["WORK_3_D"]);
                        }

                        if (row["END_TIME"].ToString().Substring(4, 2) == "04")
                        {
                            wRows[0]["WORK_4_D"] = wRows[0]["WORK_4_D"].toInt() + row["LT"].toInt();
                            wRows[0]["WORK_4"] = string.Format("{0:n0}", wRows[0]["WORK_4_D"]);
                        }

                        if (row["END_TIME"].ToString().Substring(4, 2) == "05")
                        {
                            wRows[0]["WORK_5_D"] = wRows[0]["WORK_5_D"].toInt() + row["LT"].toInt();
                            wRows[0]["WORK_5"] = string.Format("{0:n0}", wRows[0]["WORK_5_D"]);
                        }

                        if (row["END_TIME"].ToString().Substring(4, 2) == "06")
                        {
                            wRows[0]["WORK_6_D"] = wRows[0]["WORK_6_D"].toInt() + row["LT"].toInt();
                            wRows[0]["WORK_6"] = string.Format("{0:n0}", wRows[0]["WORK_6_D"]);
                        }

                        if (row["END_TIME"].ToString().Substring(4, 2) == "07")
                        {
                            wRows[0]["WORK_7_D"] = wRows[0]["WORK_7_D"].toInt() + row["LT"].toInt();
                            wRows[0]["WORK_7"] = string.Format("{0:n0}", wRows[0]["WORK_7_D"]);
                        }

                        if (row["END_TIME"].ToString().Substring(4, 2) == "08")
                        {
                            wRows[0]["WORK_8_D"] = wRows[0]["WORK_8_D"].toInt() + row["LT"].toInt();
                            wRows[0]["WORK_8"] = string.Format("{0:n0}", wRows[0]["WORK_8_D"]);
                        }

                        if (row["END_TIME"].ToString().Substring(4, 2) == "09")
                        {
                            wRows[0]["WORK_9_D"] = wRows[0]["WORK_9_D"].toInt() + row["LT"].toInt();
                            wRows[0]["WORK_9"] = string.Format("{0:n0}", wRows[0]["WORK_9_D"]);
                        }

                        if (row["END_TIME"].ToString().Substring(4, 2) == "10")
                        {
                            wRows[0]["WORK_10_D"] = wRows[0]["WORK_10_D"].toInt() + row["LT"].toInt();
                            wRows[0]["WORK_10"] = string.Format("{0:n0}", wRows[0]["WORK_10_D"]);
                        }

                        if (row["END_TIME"].ToString().Substring(4, 2) == "11")
                        {
                            wRows[0]["WORK_11_D"] = wRows[0]["WORK_11_D"].toInt() + row["LT"].toInt();
                            wRows[0]["WORK_11"] = string.Format("{0:n0}", wRows[0]["WORK_11_D"]);
                        }

                        if (row["END_TIME"].ToString().Substring(4, 2) == "12")
                        {
                            wRows[0]["WORK_12_D"] = wRows[0]["WORK_12_D"].toInt() + row["LT"].toInt();
                            wRows[0]["WORK_12"] = string.Format("{0:n0}", wRows[0]["WORK_12_D"]);
                        }

                        double sum = wRows[0]["WORK_1_D"].toInt() + wRows[0]["WORK_2_D"].toInt() + wRows[0]["WORK_3_D"].toInt() + wRows[0]["WORK_4_D"].toInt()
                                     + wRows[0]["WORK_5_D"].toInt() + wRows[0]["WORK_6_D"].toInt() + wRows[0]["WORK_7_D"].toInt() + wRows[0]["WORK_8_D"].toInt()
                                     + wRows[0]["WORK_9_D"].toInt() + wRows[0]["WORK_10_D"].toInt() + wRows[0]["WORK_11_D"].toInt() + wRows[0]["WORK_12_D"].toInt();

                        wRows[0]["WORK_SUM"] = string.Format("{0:n0}", sum);
                        wRows[0]["WORK_SUM_D"] = sum;
                    }
                }

                foreach (DataRow row in dtworDay.Rows)
                {
                    DataRow[] wRows = gridTable.Select("FLAG = 'DAY'");

                    DataRow[] aRows = gridTable.Select("FLAG = 'WORK_TIME'");

                    if (wRows.Length > 0)
                    {
                        if (row["WORK_MONTH"].ToString().Substring(4, 2) == "01")
                        {
                            wRows[0]["WORK_1_D"] = wRows[0]["WORK_1_D"].toInt() + row["WORK_DAY"].toInt();
                            wRows[0]["WORK_1"] = string.Format("{0:n0}", wRows[0]["WORK_1_D"]);

                            aRows[0]["WORK_1_D"] = aRows[0]["WORK_1_D"].toInt() + (row["WORK_DAY"].toInt() * 10 * 60);
                            aRows[0]["WORK_1"] = string.Format("{0:n0}", aRows[0]["WORK_1_D"]);
                        }

                        if (row["WORK_MONTH"].ToString().Substring(4, 2) == "02")
                        {
                            wRows[0]["WORK_2_D"] = wRows[0]["WORK_2_D"].toInt() + row["WORK_DAY"].toInt();
                            wRows[0]["WORK_2"] = string.Format("{0:n0}", wRows[0]["WORK_2_D"]);

                            aRows[0]["WORK_2_D"] = aRows[0]["WORK_2_D"].toInt() + (row["WORK_DAY"].toInt() * 10 * 60);
                            aRows[0]["WORK_2"] = string.Format("{0:n0}", aRows[0]["WORK_2_D"]);
                        }

                        if (row["WORK_MONTH"].ToString().Substring(4, 2) == "03")
                        {
                            wRows[0]["WORK_3_D"] = wRows[0]["WORK_3_D"].toInt() + row["WORK_DAY"].toInt();
                            wRows[0]["WORK_3"] = string.Format("{0:n0}", wRows[0]["WORK_3_D"]);

                            aRows[0]["WORK_3_D"] = aRows[0]["WORK_3_D"].toInt() + (row["WORK_DAY"].toInt() * 10 * 60);
                            aRows[0]["WORK_3"] = string.Format("{0:n0}", aRows[0]["WORK_3_D"]);
                        }

                        if (row["WORK_MONTH"].ToString().Substring(4, 2) == "04")
                        {
                            wRows[0]["WORK_4_D"] = wRows[0]["WORK_4_D"].toInt() + row["WORK_DAY"].toInt();
                            wRows[0]["WORK_4"] = string.Format("{0:n0}", wRows[0]["WORK_4_D"]);

                            aRows[0]["WORK_4_D"] = aRows[0]["WORK_4_D"].toInt() + (row["WORK_DAY"].toInt() * 10 * 60);
                            aRows[0]["WORK_4"] = string.Format("{0:n0}", aRows[0]["WORK_4_D"]);
                        }

                        if (row["WORK_MONTH"].ToString().Substring(4, 2) == "05")
                        {
                            wRows[0]["WORK_5_D"] = wRows[0]["WORK_5_D"].toInt() + row["WORK_DAY"].toInt();
                            wRows[0]["WORK_5"] = string.Format("{0:n0}", wRows[0]["WORK_5_D"]);

                            aRows[0]["WORK_5_D"] = aRows[0]["WORK_5_D"].toInt() + (row["WORK_DAY"].toInt() * 10 * 60);
                            aRows[0]["WORK_5"] = string.Format("{0:n0}", aRows[0]["WORK_5_D"]);
                        }

                        if (row["WORK_MONTH"].ToString().Substring(4, 2) == "06")
                        {
                            wRows[0]["WORK_6_D"] = wRows[0]["WORK_6_D"].toInt() + row["WORK_DAY"].toInt();
                            wRows[0]["WORK_6"] = string.Format("{0:n0}", wRows[0]["WORK_6_D"]);

                            aRows[0]["WORK_6_D"] = aRows[0]["WORK_6_D"].toInt() + (row["WORK_DAY"].toInt() * 10 * 60);
                            aRows[0]["WORK_6"] = string.Format("{0:n0}", aRows[0]["WORK_6_D"]);
                        }

                        if (row["WORK_MONTH"].ToString().Substring(4, 2) == "07")
                        {
                            wRows[0]["WORK_7_D"] = wRows[0]["WORK_7_D"].toInt() + row["WORK_DAY"].toInt();
                            wRows[0]["WORK_7"] = string.Format("{0:n0}", wRows[0]["WORK_7_D"]);

                            aRows[0]["WORK_7_D"] = aRows[0]["WORK_7_D"].toInt() + (row["WORK_DAY"].toInt() * 10 * 60);
                            aRows[0]["WORK_7"] = string.Format("{0:n0}", aRows[0]["WORK_7_D"]);
                        }

                        if (row["WORK_MONTH"].ToString().Substring(4, 2) == "08")
                        {
                            wRows[0]["WORK_8_D"] = wRows[0]["WORK_8_D"].toInt() + row["WORK_DAY"].toInt();
                            wRows[0]["WORK_8"] = string.Format("{0:n0}", wRows[0]["WORK_8_D"]);

                            aRows[0]["WORK_8_D"] = aRows[0]["WORK_8_D"].toInt() + (row["WORK_DAY"].toInt() * 10 * 60);
                            aRows[0]["WORK_8"] = string.Format("{0:n0}", aRows[0]["WORK_8_D"]);
                        }

                        if (row["WORK_MONTH"].ToString().Substring(4, 2) == "09")
                        {
                            wRows[0]["WORK_9_D"] = wRows[0]["WORK_9_D"].toInt() + row["WORK_DAY"].toInt();
                            wRows[0]["WORK_9"] = string.Format("{0:n0}", wRows[0]["WORK_9_D"]);

                            aRows[0]["WORK_9_D"] = aRows[0]["WORK_9_D"].toInt() + (row["WORK_DAY"].toInt() * 10 * 60);
                            aRows[0]["WORK_9"] = string.Format("{0:n0}", aRows[0]["WORK_9_D"]);
                        }

                        if (row["WORK_MONTH"].ToString().Substring(4, 2) == "10")
                        {
                            wRows[0]["WORK_10_D"] = wRows[0]["WORK_10_D"].toInt() + row["WORK_DAY"].toInt();
                            wRows[0]["WORK_10"] = string.Format("{0:n0}", wRows[0]["WORK_10_D"]);

                            aRows[0]["WORK_10_D"] = aRows[0]["WORK_10_D"].toInt() + (row["WORK_DAY"].toInt() * 10 * 60);
                            aRows[0]["WORK_10"] = string.Format("{0:n0}", aRows[0]["WORK_10_D"]);
                        }

                        if (row["WORK_MONTH"].ToString().Substring(4, 2) == "11")
                        {
                            wRows[0]["WORK_11_D"] = wRows[0]["WORK_11_D"].toInt() + row["WORK_DAY"].toInt();
                            wRows[0]["WORK_11"] = string.Format("{0:n0}", wRows[0]["WORK_11_D"]);

                            aRows[0]["WORK_11_D"] = aRows[0]["WORK_11_D"].toInt() + (row["WORK_DAY"].toInt() * 10 * 60);
                            aRows[0]["WORK_11"] = string.Format("{0:n0}", aRows[0]["WORK_11_D"]);
                        }

                        if (row["WORK_MONTH"].ToString().Substring(4, 2) == "12")
                        {
                            wRows[0]["WORK_12_D"] = wRows[0]["WORK_12_D"].toInt() + row["WORK_DAY"].toInt();
                            wRows[0]["WORK_12"] = string.Format("{0:n0}", wRows[0]["WORK_12_D"]);

                            aRows[0]["WORK_12_D"] = aRows[0]["WORK_12_D"].toInt() + (row["WORK_DAY"].toInt() * 10 * 60);
                            aRows[0]["WORK_12"] = string.Format("{0:n0}", aRows[0]["WORK_12_D"]);
                        }

                        double sum = wRows[0]["WORK_1_D"].toInt() + wRows[0]["WORK_2_D"].toInt() + wRows[0]["WORK_3_D"].toInt() + wRows[0]["WORK_4_D"].toInt()
                                     + wRows[0]["WORK_5_D"].toInt() + wRows[0]["WORK_6_D"].toInt() + wRows[0]["WORK_7_D"].toInt() + wRows[0]["WORK_8_D"].toInt()
                                     + wRows[0]["WORK_9_D"].toInt() + wRows[0]["WORK_10_D"].toInt() + wRows[0]["WORK_11_D"].toInt() + wRows[0]["WORK_12_D"].toInt();

                        wRows[0]["WORK_SUM"] = string.Format("{0:n0}", sum);
                        wRows[0]["WORK_SUM_D"] = sum;


                        double sum2 = aRows[0]["WORK_1_D"].toInt() + aRows[0]["WORK_2_D"].toInt() + aRows[0]["WORK_3_D"].toInt() + aRows[0]["WORK_4_D"].toInt()
                                     + aRows[0]["WORK_5_D"].toInt() + aRows[0]["WORK_6_D"].toInt() + aRows[0]["WORK_7_D"].toInt() + aRows[0]["WORK_8_D"].toInt()
                                     + aRows[0]["WORK_9_D"].toInt() + aRows[0]["WORK_10_D"].toInt() + aRows[0]["WORK_11_D"].toInt() + aRows[0]["WORK_12_D"].toInt();

                        aRows[0]["WORK_SUM"] = string.Format("{0:n0}", sum2);
                        aRows[0]["WORK_SUM_D"] = sum2;
                    }
                }

                DataRow[] RaterRows = gridTable.Select("FLAG = 'RATE'");

                DataRow[] RatewRows = gridTable.Select("FLAG = 'WORK_TIME'");

                DataRow[] RateaRows = gridTable.Select("FLAG = 'ACT'");


                for (int i = 1; i < 13; i++)
                {
                    RaterRows[0]["WORK_" + i.ToString()] = string.Format("{0:N1}%", 0.0);
                    RaterRows[0]["WORK_" + i.ToString() + "_D"] = 0;

                    if (RatewRows[0]["WORK_" + i.ToString() + "_D"].toInt() > 0)
                    {
                        decimal rate = RateaRows[0]["WORK_" + i.ToString() + "_D"].toDecimal() / RatewRows[0]["WORK_" + i.ToString() + "_D"].toDecimal();

                        rate = rate * 100;

                        RaterRows[0]["WORK_" + i.ToString()] = string.Format("{0:N1}%", rate);
                        RaterRows[0]["WORK_" + i.ToString() + "_D"] = rate;
                    }
                }

                decimal rate2 = 0;

                if (RatewRows[0]["WORK_SUM_D"].toDecimal() > 0)
                {
                    rate2 = RateaRows[0]["WORK_SUM_D"].toDecimal() / RatewRows[0]["WORK_SUM_D"].toDecimal() * 100;
                }

                

                RaterRows[0]["WORK_SUM"] = string.Format("{0:N1}%", rate2);
                RaterRows[0]["WORK_SUM_D"] = rate2;

                gridTable.TableName = "RSLTDT";

                paramDS.Tables.Add(gridTable);




                DataTable dtRslt2 = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY42(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable gridTable2 = cloneTable.Clone();

                DataRow newRow2 = gridTable2.NewRow();
                newRow2["PLT_CODE"] = ConnInfo.PLT_CODE;
                newRow2["FLAG"] = "LT";
                newRow2["TYPE"] = "조립 L/T";
                for (int i = 1; i < 13; i++)
                {
                    newRow2["WORK_" + i.ToString()] = string.Format("{0:N1}", 0);
                    newRow2["WORK_" + i.ToString() + "_D"] = 0.0;
                }

                gridTable2.Rows.Add(newRow2);

                foreach (DataRow row in dtRslt2.Rows)
                {
                    DataRow[] wRows = gridTable2.Select("FLAG = 'LT'");

                    if (wRows.Length > 0)
                    {
                        if (row["ACT_MONTH"].ToString().Substring(4, 2) == "01")
                        {
                            wRows[0]["WORK_1_D"] = Convert.ToDecimal(wRows[0]["WORK_1_D"]) + Convert.ToDecimal(row["LT"]);
                            wRows[0]["WORK_1"] = string.Format("{0:n1}", wRows[0]["WORK_1_D"]);
                        }

                        if (row["ACT_MONTH"].ToString().Substring(4, 2) == "02")
                        {
                            wRows[0]["WORK_2_D"] = Convert.ToDecimal(wRows[0]["WORK_2_D"]) + Convert.ToDecimal(row["LT"]);
                            wRows[0]["WORK_2"] = string.Format("{0:n1}", wRows[0]["WORK_2_D"]);
                        }

                        if (row["ACT_MONTH"].ToString().Substring(4, 2) == "03")
                        {
                            wRows[0]["WORK_3_D"] = Convert.ToDecimal(wRows[0]["WORK_3_D"]) + Convert.ToDecimal(row["LT"]);
                            wRows[0]["WORK_3"] = string.Format("{0:n1}", wRows[0]["WORK_3_D"]);
                        }

                        if (row["ACT_MONTH"].ToString().Substring(4, 2) == "04")
                        {
                            wRows[0]["WORK_4_D"] = Convert.ToDecimal(wRows[0]["WORK_4_D"]) + Convert.ToDecimal(row["LT"]);
                            wRows[0]["WORK_4"] = string.Format("{0:n1}", wRows[0]["WORK_4_D"]);
                        }

                        if (row["ACT_MONTH"].ToString().Substring(4, 2) == "05")
                        {
                            wRows[0]["WORK_5_D"] = Convert.ToDecimal(wRows[0]["WORK_5_D"]) + Convert.ToDecimal(row["LT"]);
                            wRows[0]["WORK_5"] = string.Format("{0:n1}", wRows[0]["WORK_5_D"]);
                        }

                        if (row["ACT_MONTH"].ToString().Substring(4, 2) == "06")
                        {
                            wRows[0]["WORK_6_D"] = Convert.ToDecimal(wRows[0]["WORK_6_D"]) + Convert.ToDecimal(row["LT"]);
                            wRows[0]["WORK_6"] = string.Format("{0:n1}", wRows[0]["WORK_6_D"]);
                        }

                        if (row["ACT_MONTH"].ToString().Substring(4, 2) == "07")
                        {
                            wRows[0]["WORK_7_D"] = Convert.ToDecimal(wRows[0]["WORK_7_D"]) + Convert.ToDecimal(row["LT"]);
                            wRows[0]["WORK_7"] = string.Format("{0:n1}", wRows[0]["WORK_7_D"]);
                        }

                        if (row["ACT_MONTH"].ToString().Substring(4, 2) == "08")
                        {
                            wRows[0]["WORK_8_D"] = Convert.ToDecimal(wRows[0]["WORK_8_D"]) + Convert.ToDecimal(row["LT"]);
                            wRows[0]["WORK_8"] = string.Format("{0:n1}", wRows[0]["WORK_8_D"]);
                        }

                        if (row["ACT_MONTH"].ToString().Substring(4, 2) == "09")
                        {
                            wRows[0]["WORK_9_D"] = Convert.ToDecimal(wRows[0]["WORK_9_D"]) + Convert.ToDecimal(row["LT"]);
                            wRows[0]["WORK_9"] = string.Format("{0:n1}", wRows[0]["WORK_9_D"]);
                        }

                        if (row["ACT_MONTH"].ToString().Substring(4, 2) == "10")
                        {
                            wRows[0]["WORK_10_D"] = Convert.ToDecimal(wRows[0]["WORK_10_D"]) + Convert.ToDecimal(row["LT"]);
                            wRows[0]["WORK_10"] = string.Format("{0:n1}", wRows[0]["WORK_10_D"]);
                        }

                        if (row["ACT_MONTH"].ToString().Substring(4, 2) == "11")
                        {
                            wRows[0]["WORK_11_D"] = Convert.ToDecimal(wRows[0]["WORK_11_D"]) + Convert.ToDecimal(row["LT"]);
                            wRows[0]["WORK_11"] = string.Format("{0:n1}", wRows[0]["WORK_11_D"]);
                        }

                        if (row["ACT_MONTH"].ToString().Substring(4, 2) == "12")
                        {
                            wRows[0]["WORK_12_D"] = Convert.ToDecimal(wRows[0]["WORK_12_D"]) + Convert.ToDecimal(row["LT"]);
                            wRows[0]["WORK_12"] = string.Format("{0:n1}", wRows[0]["WORK_12_D"]);
                        }

                        decimal sum = Convert.ToDecimal(wRows[0]["WORK_1_D"]) + Convert.ToDecimal(wRows[0]["WORK_2_D"]) + Convert.ToDecimal(wRows[0]["WORK_3_D"]) + Convert.ToDecimal(wRows[0]["WORK_4_D"])
                                     + Convert.ToDecimal(wRows[0]["WORK_5_D"]) + Convert.ToDecimal(wRows[0]["WORK_6_D"]) + Convert.ToDecimal(wRows[0]["WORK_7_D"]) + Convert.ToDecimal(wRows[0]["WORK_8_D"])
                                     + Convert.ToDecimal(wRows[0]["WORK_9_D"]) + Convert.ToDecimal(wRows[0]["WORK_10_D"]) + Convert.ToDecimal(wRows[0]["WORK_11_D"]) + Convert.ToDecimal(wRows[0]["WORK_12_D"]);

                        wRows[0]["WORK_SUM"] = string.Format("{0:n1}", sum);
                        wRows[0]["WORK_SUM_D"] = sum;
                    }
                }

                gridTable2.TableName = "RSLTDT2";

                paramDS.Tables.Add(gridTable2);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet REP06A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                DataTable dtRslt = DREP.TREP_ASSY_AT_QUERY.TREP_ASSY_AT_QUERY1(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";

                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet REP06A_INS(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {

                    DataTable dtRslt = DREP.TREP_ASSY_AT.TREP_ASSY_AT_SER(UTIL.GetRowToDt(row), bizExecute);

                    if (dtRslt.Rows.Count > 0)
                    {
                        DREP.TREP_ASSY_AT.TREP_ASSY_AT_UPD(UTIL.GetRowToDt(row), bizExecute);
                    }
                    else
                    {

                        DREP.TREP_ASSY_AT.TREP_ASSY_AT_INS(UTIL.GetRowToDt(row), bizExecute);

                    }

                }

                return REP06A_SER2(paramDS, bizExecute);
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet REP06A_DEL(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {

                foreach (DataRow row in paramDS.Tables["RQSTDT"].Rows)
                {

                    DREP.TREP_ASSY_AT.TREP_ASSY_AT_DEL(UTIL.GetRowToDt(row), bizExecute);
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
