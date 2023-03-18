using BizExecute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BREP
{
    public class REP05A
    {
        public static DataSet REP05A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable cloneTable = new DataTable();
                cloneTable.Columns.Add("PLT_CODE", typeof(String));
                cloneTable.Columns.Add("WORK_LOC", typeof(String));
                cloneTable.Columns.Add("WORK_LOC_NAME", typeof(String));
                cloneTable.Columns.Add("EMP_CODE", typeof(String));
                cloneTable.Columns.Add("EMP_NAME", typeof(String));
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

                DataTable dtRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY39(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable dtNgRslt = DSHP.TSHP_NG_QUERY.TSHP_NG_QUERY8(paramDS.Tables["RQSTDT"], bizExecute);

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "CD_PARENT_IN", "A,B,I", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "CAT_CODE", "C401", typeof(string));
                DataTable dtNgCodeRslt = DSTD.TSTD_CODES_QUERY.TSTD_CODES_QUERY8(paramDS.Tables["RQSTDT"], bizExecute);

                var innerJoin = from tb1 in dtNgRslt.AsEnumerable()
                                    group tb1 by new { PLT_CODE = tb1.Field<string>("PLT_CODE"), DETAIL_CAUSE = tb1.Field<string>("DETAIL_CAUSE")} into gtb1
                                join tb2 in dtNgCodeRslt.AsEnumerable()
                                on gtb1.FirstOrDefault().Field<string>("DETAIL_CAUSE") equals tb2.Field<string>("CD_CODE") into dataKey
                                from tb2 in dataKey
                                select new
                                {
                                    PLT_CODE = tb2.Field<string>("PLT_CODE"),
                                    CD_CODE = tb2.Field<string>("CD_CODE"),
                                    CD_NAME = tb2.Field<string>("CD_NAME"),
                                };

                DataTable codeTable = innerJoin.LINQToDataTable();

                DataTable gridTable = cloneTable.Clone();

                foreach (DataRow row in dtRslt.Rows)
                {
                    DataRow[] rows = gridTable.Select("FLAG = '" + row["PROD_FLAG"].ToString() + "'");

                    if (rows.Length == 0)
                    {
                        DataRow newRow = gridTable.NewRow();
                        newRow["PLT_CODE"] = row["PLT_CODE"];
                        newRow["FLAG"] = "NE";
                        newRow["TYPE"] = "New";
                        for (int i = 1; i < 13; i++)
                        {
                            newRow["WORK_" + i.ToString()] = string.Format("{0:N0}", 0);
                        }
                        newRow["WORK_SUM"] = 0;
                        gridTable.Rows.Add(newRow);

                        newRow = gridTable.NewRow();
                        newRow["PLT_CODE"] = row["PLT_CODE"];
                        newRow["FLAG"] = "RE";
                        newRow["TYPE"] = "Repeat";
                        for (int i = 1; i < 13; i++)
                        {
                            newRow["WORK_" + i.ToString()] = string.Format("{0:N0}", 0);
                        }
                        newRow["WORK_SUM"] = 0;
                        gridTable.Rows.Add(newRow);

                        newRow = gridTable.NewRow();
                        newRow["PLT_CODE"] = row["PLT_CODE"];
                        newRow["FLAG"] = "CAM_SUM";
                        newRow["TYPE"] = "총 건수";
                        for (int i = 1; i < 13; i++)
                        {
                            newRow["WORK_" + i.ToString()] = string.Format("{0:N0}", 0);
                        }
                        newRow["WORK_SUM"] = 0;
                        gridTable.Rows.Add(newRow);

                        newRow = gridTable.NewRow();
                        newRow["PLT_CODE"] = row["PLT_CODE"];
                        newRow["FLAG"] = "NG_SUM";
                        newRow["TYPE"] = "불량건수";
                        for (int i = 1; i < 13; i++)
                        {
                            newRow["WORK_" + i.ToString()] = string.Format("{0:N0}", 0);
                        }
                        newRow["WORK_SUM"] = 0;
                        gridTable.Rows.Add(newRow);

                        foreach (DataRow stdRow in codeTable.Rows)
                        {
                            newRow = gridTable.NewRow();
                            newRow["PLT_CODE"] = row["PLT_CODE"];
                            newRow["FLAG"] = stdRow["CD_CODE"];
                            newRow["TYPE"] = "   " + stdRow["CD_NAME"];
                            for (int i = 1; i < 13; i++)
                            {
                                newRow["WORK_" + i.ToString()] = string.Format("{0:N0}", 0);
                            }
                            newRow["WORK_SUM"] = 0;
                            gridTable.Rows.Add(newRow);
                        }

                        newRow = gridTable.NewRow();
                        newRow["PLT_CODE"] = row["PLT_CODE"];
                        newRow["FLAG"] = "RATE";
                        newRow["TYPE"] = "비율";
                        for (int i = 1; i < 13; i++)
                        {
                            newRow["WORK_" + i.ToString()] = "0.00%";
                        }
                        newRow["WORK_SUM"] = "0.00%";
                        gridTable.Rows.Add(newRow);
                    }

                    DataRow[] wRows = gridTable.Select("FLAG = '" + row["PROD_FLAG"].ToString() + "'");

                    DataRow[] tRows = gridTable.Select("FLAG = 'CAM_SUM'");

                    if (wRows.Length > 0)
                    {
                        if (row["ACT_END_MONTH"].ToString().Substring(4, 2) == "01")
                        {
                            wRows[0]["WORK_1_D"] = wRows[0]["WORK_1_D"].toInt() + row["PART_CNT"].toInt();
                            wRows[0]["WORK_1"] = string.Format("{0:n0}", wRows[0]["WORK_1_D"]);
                        }

                        if (row["ACT_END_MONTH"].ToString().Substring(4, 2) == "02")
                        {
                            //wRows[0]["WORK_2"] = string.Format("{0:n0}", wRows[0]["WORK_2"].toInt() + row["PART_CNT"].toInt());
                            wRows[0]["WORK_2_D"] = wRows[0]["WORK_2_D"].toInt() + row["PART_CNT"].toInt();
                            wRows[0]["WORK_2"] = string.Format("{0:n0}", wRows[0]["WORK_2_D"]);
                        }

                        if (row["ACT_END_MONTH"].ToString().Substring(4, 2) == "03")
                        {
                            //wRows[0]["WORK_3"] = string.Format("{0:n0}", wRows[0]["WORK_3"].toInt() + row["PART_CNT"].toInt());
                            wRows[0]["WORK_3_D"] = wRows[0]["WORK_3_D"].toInt() + row["PART_CNT"].toInt();
                            wRows[0]["WORK_3"] = string.Format("{0:n0}", wRows[0]["WORK_3_D"]);
                        }

                        if (row["ACT_END_MONTH"].ToString().Substring(4, 2) == "04")
                        {
                            //wRows[0]["WORK_4"] = string.Format("{0:n0}", wRows[0]["WORK_4"].toInt() + row["PART_CNT"].toInt());
                            wRows[0]["WORK_4_D"] = wRows[0]["WORK_4_D"].toInt() + row["PART_CNT"].toInt();
                            wRows[0]["WORK_4"] = string.Format("{0:n0}", wRows[0]["WORK_4_D"]);
                        }

                        if (row["ACT_END_MONTH"].ToString().Substring(4, 2) == "05") 
                        {
                            //wRows[0]["WORK_5"] = string.Format("{0:n0}", wRows[0]["WORK_5"].toInt() + row["PART_CNT"].toInt());
                            wRows[0]["WORK_5_D"] = wRows[0]["WORK_5_D"].toInt() + row["PART_CNT"].toInt();
                            wRows[0]["WORK_5"] = string.Format("{0:n0}", wRows[0]["WORK_5_D"]);
                        }

                        if (row["ACT_END_MONTH"].ToString().Substring(4, 2) == "06")
                        {
                            //wRows[0]["WORK_6"] = string.Format("{0:n0}", wRows[0]["WORK_6"].toInt() + row["PART_CNT"].toInt());
                            wRows[0]["WORK_6_D"] = wRows[0]["WORK_6_D"].toInt() + row["PART_CNT"].toInt();
                            wRows[0]["WORK_6"] = string.Format("{0:n0}", wRows[0]["WORK_6_D"]);
                        }

                        if (row["ACT_END_MONTH"].ToString().Substring(4, 2) == "07")
                        {
                            //wRows[0]["WORK_7"] = string.Format("{0:n0}", wRows[0]["WORK_7"].toInt() + row["PART_CNT"].toInt());
                            wRows[0]["WORK_7_D"] = wRows[0]["WORK_7_D"].toInt() + row["PART_CNT"].toInt();
                            wRows[0]["WORK_7"] = string.Format("{0:n0}", wRows[0]["WORK_7_D"]);
                        }

                        if (row["ACT_END_MONTH"].ToString().Substring(4, 2) == "08")
                        {
                            //wRows[0]["WORK_8"] = string.Format("{0:n0}", wRows[0]["WORK_8"].toInt() + row["PART_CNT"].toInt());
                            wRows[0]["WORK_8_D"] = wRows[0]["WORK_8_D"].toInt() + row["PART_CNT"].toInt();
                            wRows[0]["WORK_8"] = string.Format("{0:n0}", wRows[0]["WORK_8_D"]);
                        }

                        if (row["ACT_END_MONTH"].ToString().Substring(4, 2) == "09")
                        {
                            //wRows[0]["WORK_9"] = string.Format("{0:n0}", wRows[0]["WORK_9"].toInt() + row["PART_CNT"].toInt());
                            wRows[0]["WORK_9_D"] = wRows[0]["WORK_9_D"].toInt() + row["PART_CNT"].toInt();
                            wRows[0]["WORK_9"] = string.Format("{0:n0}", wRows[0]["WORK_9_D"]);
                        }

                        if (row["ACT_END_MONTH"].ToString().Substring(4, 2) == "10")
                        {
                            //wRows[0]["WORK_10"] = string.Format("{0:n0}", wRows[0]["WORK_10"].toInt() + row["PART_CNT"].toInt());
                            wRows[0]["WORK_10_D"] = wRows[0]["WORK_10_D"].toInt() + row["PART_CNT"].toInt();
                            wRows[0]["WORK_10"] = string.Format("{0:n0}", wRows[0]["WORK_10_D"]);
                        }

                        if (row["ACT_END_MONTH"].ToString().Substring(4, 2) == "11")
                        {
                            //wRows[0]["WORK_11"] = string.Format("{0:n0}", wRows[0]["WORK_11"].toInt() + row["PART_CNT"].toInt());
                            wRows[0]["WORK_11_D"] = wRows[0]["WORK_11_D"].toInt() + row["PART_CNT"].toInt();
                            wRows[0]["WORK_11"] = string.Format("{0:n0}", wRows[0]["WORK_11_D"]);
                        }

                        if (row["ACT_END_MONTH"].ToString().Substring(4, 2) == "12")
                        {
                            //wRows[0]["WORK_12"] = string.Format("{0:n0}", wRows[0]["WORK_12"].toInt() + row["PART_CNT"].toInt());
                            wRows[0]["WORK_12_D"] = wRows[0]["WORK_12_D"].toInt() + row["PART_CNT"].toInt();
                            wRows[0]["WORK_12"] = string.Format("{0:n0}", wRows[0]["WORK_12_D"]);
                        }

                        double sum = wRows[0]["WORK_1_D"].toInt() + wRows[0]["WORK_2_D"].toInt() + wRows[0]["WORK_3_D"].toInt() + wRows[0]["WORK_4_D"].toInt()
                                     + wRows[0]["WORK_5_D"].toInt() + wRows[0]["WORK_6_D"].toInt() + wRows[0]["WORK_7_D"].toInt() + wRows[0]["WORK_8_D"].toInt()
                                     + wRows[0]["WORK_9_D"].toInt() + wRows[0]["WORK_10_D"].toInt() + wRows[0]["WORK_11_D"].toInt() + wRows[0]["WORK_12_D"].toInt();

                        wRows[0]["WORK_SUM"] = string.Format("{0:n0}", sum);
                        wRows[0]["WORK_SUM_D"] = sum;

                        if (tRows.Length == 1)
                        {
                            if (row["ACT_END_MONTH"].ToString().Substring(4, 2) == "01")
                            {
                                //tRows[0]["WORK_1"] = string.Format("{0:n0}", tRows[0]["WORK_1"].toInt() + wRows[0]["WORK_1"].toInt());
                                tRows[0]["WORK_1_D"] = tRows[0]["WORK_1_D"].toInt() + row["PART_CNT"].toInt();
                                tRows[0]["WORK_1"] = string.Format("{0:n0}", tRows[0]["WORK_1_D"]);
                            }

                            if (row["ACT_END_MONTH"].ToString().Substring(4, 2) == "02")
                            {
                                //tRows[0]["WORK_2"] = string.Format("{0:n0}", tRows[0]["WORK_2"].toInt() + wRows[0]["WORK_2"].toInt());
                                tRows[0]["WORK_2_D"] = tRows[0]["WORK_2_D"].toInt() + row["PART_CNT"].toInt();
                                tRows[0]["WORK_2"] = string.Format("{0:n0}", tRows[0]["WORK_2_D"]);
                            }

                            if (row["ACT_END_MONTH"].ToString().Substring(4, 2) == "03")
                            {
                                //tRows[0]["WORK_3"] = string.Format("{0:n0}", tRows[0]["WORK_3"].toInt() + wRows[0]["WORK_3"].toInt());
                                tRows[0]["WORK_3_D"] = tRows[0]["WORK_3_D"].toInt() + row["PART_CNT"].toInt();
                                tRows[0]["WORK_3"] = string.Format("{0:n0}", tRows[0]["WORK_3_D"]);
                            }

                            if (row["ACT_END_MONTH"].ToString().Substring(4, 2) == "04")
                            {
                                //tRows[0]["WORK_4"] = string.Format("{0:n0}", tRows[0]["WORK_4"].toInt() + wRows[0]["WORK_4"].toInt());
                                tRows[0]["WORK_4_D"] = tRows[0]["WORK_4_D"].toInt() + row["PART_CNT"].toInt();
                                tRows[0]["WORK_4"] = string.Format("{0:n0}", tRows[0]["WORK_4_D"]);
                            }

                            if (row["ACT_END_MONTH"].ToString().Substring(4, 2) == "05")
                            {
                                //tRows[0]["WORK_5"] = string.Format("{0:n0}", tRows[0]["WORK_5"].toInt() + wRows[0]["WORK_5"].toInt());
                                tRows[0]["WORK_5_D"] = tRows[0]["WORK_5_D"].toInt() + row["PART_CNT"].toInt();
                                tRows[0]["WORK_5"] = string.Format("{0:n0}", tRows[0]["WORK_5_D"]);
                            }

                            if (row["ACT_END_MONTH"].ToString().Substring(4, 2) == "06")
                            {
                                //tRows[0]["WORK_6"] = string.Format("{0:n0}", tRows[0]["WORK_6"].toInt() + wRows[0]["WORK_6"].toInt());
                                tRows[0]["WORK_6_D"] = tRows[0]["WORK_6_D"].toInt() + row["PART_CNT"].toInt();
                                tRows[0]["WORK_6"] = string.Format("{0:n0}", tRows[0]["WORK_6_D"]);
                            }

                            if (row["ACT_END_MONTH"].ToString().Substring(4, 2) == "07")
                            {
                                //tRows[0]["WORK_7"] = string.Format("{0:n0}", tRows[0]["WORK_7"].toInt() + wRows[0]["WORK_7"].toInt());
                                tRows[0]["WORK_7_D"] = tRows[0]["WORK_7_D"].toInt() + row["PART_CNT"].toInt();
                                tRows[0]["WORK_7"] = string.Format("{0:n0}", tRows[0]["WORK_7_D"]);
                            }

                            if (row["ACT_END_MONTH"].ToString().Substring(4, 2) == "08")
                            {
                                //tRows[0]["WORK_8"] = string.Format("{0:n0}", tRows[0]["WORK_8"].toInt() + wRows[0]["WORK_8"].toInt());
                                tRows[0]["WORK_8_D"] = tRows[0]["WORK_8_D"].toInt() + row["PART_CNT"].toInt();
                                tRows[0]["WORK_8"] = string.Format("{0:n0}", tRows[0]["WORK_8_D"]);
                            }

                            if (row["ACT_END_MONTH"].ToString().Substring(4, 2) == "09")
                            {
                                //tRows[0]["WORK_9"] = string.Format("{0:n0}", tRows[0]["WORK_9"].toInt() + wRows[0]["WORK_9"].toInt());
                                tRows[0]["WORK_9_D"] = tRows[0]["WORK_9_D"].toInt() + row["PART_CNT"].toInt();
                                tRows[0]["WORK_9"] = string.Format("{0:n0}", tRows[0]["WORK_9_D"]);
                            }

                            if (row["ACT_END_MONTH"].ToString().Substring(4, 2) == "10")
                            {
                                //tRows[0]["WORK_10"] = string.Format("{0:n0}", tRows[0]["WORK_10"].toInt() + wRows[0]["WORK_10"].toInt());
                                tRows[0]["WORK_10_D"] = tRows[0]["WORK_10_D"].toInt() + row["PART_CNT"].toInt();
                                tRows[0]["WORK_10"] = string.Format("{0:n0}", tRows[0]["WORK_10_D"]);
                            }

                            if (row["ACT_END_MONTH"].ToString().Substring(4, 2) == "11")
                            {
                                //tRows[0]["WORK_11"] = string.Format("{0:n0}", tRows[0]["WORK_11"].toInt() + wRows[0]["WORK_11"].toInt());
                                tRows[0]["WORK_11_D"] = tRows[0]["WORK_11_D"].toInt() + row["PART_CNT"].toInt();
                                tRows[0]["WORK_11"] = string.Format("{0:n0}", tRows[0]["WORK_11_D"]);
                            }

                            if (row["ACT_END_MONTH"].ToString().Substring(4, 2) == "12")
                            {
                                //tRows[0]["WORK_12"] = string.Format("{0:n0}", tRows[0]["WORK_12"].toInt() + wRows[0]["WORK_12"].toInt());
                                tRows[0]["WORK_12_D"] = tRows[0]["WORK_12_D"].toInt() + row["PART_CNT"].toInt();
                                tRows[0]["WORK_12"] = string.Format("{0:n0}", tRows[0]["WORK_12_D"]);
                            }


                            double tSum = tRows[0]["WORK_1_D"].toInt() + tRows[0]["WORK_2_D"].toInt() + tRows[0]["WORK_3_D"].toInt() + tRows[0]["WORK_4_D"].toInt()
                                         + tRows[0]["WORK_5_D"].toInt() + tRows[0]["WORK_6_D"].toInt() + tRows[0]["WORK_7_D"].toInt() + tRows[0]["WORK_8_D"].toInt()
                                         + tRows[0]["WORK_9_D"].toInt() + tRows[0]["WORK_10_D"].toInt() + tRows[0]["WORK_11_D"].toInt() + tRows[0]["WORK_12_D"].toInt();

                            tRows[0]["WORK_SUM"] = string.Format("{0:n0}", tSum);
                            tRows[0]["WORK_SUM_D"] = tSum;
                        }
                    }
                }

                foreach (DataRow nRow in dtNgRslt.Rows)
                {
                    DataRow[] nRows = gridTable.Select("FLAG = '" + nRow["DETAIL_CAUSE"].ToString() + "'");

                    DataRow[] tnRows = gridTable.Select("FLAG = 'NG_SUM'");

                    if (nRows.Length > 0)
                    {
                        if (nRow["NG_MONTH"].ToString().Substring(4, 2) == "01")
                        {
                            //nRows[0]["WORK_1"] = string.Format("{0:n0}", nRows[0]["WORK_1"].toInt() + nRow["NG_CNT"].toInt());
                            nRows[0]["WORK_1_D"] = nRows[0]["WORK_1_D"].toInt() + nRow["NG_CNT"].toInt();
                            nRows[0]["WORK_1"] = string.Format("{0:n0}", nRows[0]["WORK_1_D"]);
                        }

                        if (nRow["NG_MONTH"].ToString().Substring(4, 2) == "02")
                        {
                            //nRows[0]["WORK_2"] = string.Format("{0:n0}", nRows[0]["WORK_2"].toInt() + nRow["NG_CNT"].toInt());
                            nRows[0]["WORK_2_D"] = nRows[0]["WORK_2_D"].toInt() + nRow["NG_CNT"].toInt();
                            nRows[0]["WORK_2"] = string.Format("{0:n0}", nRows[0]["WORK_2_D"]);
                        }

                        if (nRow["NG_MONTH"].ToString().Substring(4, 2) == "03")
                        {
                            //nRows[0]["WORK_3"] = string.Format("{0:n0}", nRows[0]["WORK_3"].toInt() + nRow["NG_CNT"].toInt());
                            nRows[0]["WORK_3_D"] = nRows[0]["WORK_3_D"].toInt() + nRow["NG_CNT"].toInt();
                            nRows[0]["WORK_3"] = string.Format("{0:n0}", nRows[0]["WORK_3_D"]);
                        }

                        if (nRow["NG_MONTH"].ToString().Substring(4, 2) == "04")
                        {
                            //nRows[0]["WORK_4"] = string.Format("{0:n0}", nRows[0]["WORK_4"].toInt() + nRow["NG_CNT"].toInt());
                            nRows[0]["WORK_4_D"] = nRows[0]["WORK_4_D"].toInt() + nRow["NG_CNT"].toInt();
                            nRows[0]["WORK_4"] = string.Format("{0:n0}", nRows[0]["WORK_4_D"]);
                        }

                        if (nRow["NG_MONTH"].ToString().Substring(4, 2) == "05")
                        {
                            //nRows[0]["WORK_5"] = string.Format("{0:n0}", nRows[0]["WORK_5"].toInt() + nRow["NG_CNT"].toInt());
                            nRows[0]["WORK_5_D"] = nRows[0]["WORK_5_D"].toInt() + nRow["NG_CNT"].toInt();
                            nRows[0]["WORK_5"] = string.Format("{0:n0}", nRows[0]["WORK_5_D"]);
                        }

                        if (nRow["NG_MONTH"].ToString().Substring(4, 2) == "06")
                        {
                            //nRows[0]["WORK_6"] = string.Format("{0:n0}", nRows[0]["WORK_6"].toInt() + nRow["NG_CNT"].toInt());
                            nRows[0]["WORK_6_D"] = nRows[0]["WORK_6_D"].toInt() + nRow["NG_CNT"].toInt();
                            nRows[0]["WORK_6"] = string.Format("{0:n0}", nRows[0]["WORK_6_D"]);
                        }

                        if (nRow["NG_MONTH"].ToString().Substring(4, 2) == "07")
                        {
                            //nRows[0]["WORK_7"] = string.Format("{0:n0}", nRows[0]["WORK_7"].toInt() + nRow["NG_CNT"].toInt());
                            nRows[0]["WORK_7_D"] = nRows[0]["WORK_7_D"].toInt() + nRow["NG_CNT"].toInt();
                            nRows[0]["WORK_7"] = string.Format("{0:n0}", nRows[0]["WORK_7_D"]);
                        }

                        if (nRow["NG_MONTH"].ToString().Substring(4, 2) == "08")
                        {
                            //nRows[0]["WORK_8"] = string.Format("{0:n0}", nRows[0]["WORK_8"].toInt() + nRow["NG_CNT"].toInt());
                            nRows[0]["WORK_8_D"] = nRows[0]["WORK_8_D"].toInt() + nRow["NG_CNT"].toInt();
                            nRows[0]["WORK_8"] = string.Format("{0:n0}", nRows[0]["WORK_8_D"]);
                        }

                        if (nRow["NG_MONTH"].ToString().Substring(4, 2) == "09")
                        {
                            //nRows[0]["WORK_9"] = string.Format("{0:n0}", nRows[0]["WORK_9"].toInt() + nRow["NG_CNT"].toInt());
                            nRows[0]["WORK_9_D"] = nRows[0]["WORK_9_D"].toInt() + nRow["NG_CNT"].toInt();
                            nRows[0]["WORK_9"] = string.Format("{0:n0}", nRows[0]["WORK_9_D"]);
                        }
                        
                        if (nRow["NG_MONTH"].ToString().Substring(4, 2) == "10") 
                        {
                            //nRows[0]["WORK_10"] = string.Format("{0:n0}", nRows[0]["WORK_10"].toInt() + nRow["NG_CNT"].toInt());
                            nRows[0]["WORK_10_D"] = nRows[0]["WORK_10_D"].toInt() + nRow["NG_CNT"].toInt();
                            nRows[0]["WORK_10"] = string.Format("{0:n0}", nRows[0]["WORK_10_D"]);
                        }

                        if (nRow["NG_MONTH"].ToString().Substring(4, 2) == "11")
                        {
                            //nRows[0]["WORK_11"] = string.Format("{0:n0}", nRows[0]["WORK_11"].toInt() + nRow["NG_CNT"].toInt());
                            nRows[0]["WORK_11_D"] = nRows[0]["WORK_11_D"].toInt() + nRow["NG_CNT"].toInt();
                            nRows[0]["WORK_11"] = string.Format("{0:n0}", nRows[0]["WORK_11_D"]);
                        }

                        if (nRow["NG_MONTH"].ToString().Substring(4, 2) == "12")
                        {
                            //nRows[0]["WORK_12"] = string.Format("{0:n0}", nRows[0]["WORK_12"].toInt() + nRow["NG_CNT"].toInt());
                            nRows[0]["WORK_12_D"] = nRows[0]["WORK_12_D"].toInt() + nRow["NG_CNT"].toInt();
                            nRows[0]["WORK_12"] = string.Format("{0:n0}", nRows[0]["WORK_12_D"]);
                        }

                        double sum = nRows[0]["WORK_1_D"].toInt() + nRows[0]["WORK_2_D"].toInt() + nRows[0]["WORK_3_D"].toInt() + nRows[0]["WORK_4_D"].toInt()
                                     + nRows[0]["WORK_5_D"].toInt() + nRows[0]["WORK_6_D"].toInt() + nRows[0]["WORK_7_D"].toInt() + nRows[0]["WORK_8_D"].toInt()
                                     + nRows[0]["WORK_9_D"].toInt() + nRows[0]["WORK_10_D"].toInt() + nRows[0]["WORK_11_D"].toInt() + nRows[0]["WORK_12_D"].toInt();

                        nRows[0]["WORK_SUM"] = string.Format("{0:n0}", sum);
                        nRows[0]["WORK_SUM_D"] = sum;

                        if (tnRows.Length == 1)
                        {
                            if (nRow["NG_MONTH"].ToString().Substring(4, 2) == "01")
                            {
                                //tnRows[0]["WORK_1"] = string.Format("{0:n0}", tnRows[0]["WORK_1"].toInt() + nRows[0]["WORK_1"].toInt());
                                tnRows[0]["WORK_1_D"] = tnRows[0]["WORK_1_D"].toInt() + nRow["NG_CNT"].toInt();
                                tnRows[0]["WORK_1"] = string.Format("{0:n0}", tnRows[0]["WORK_1_D"]);
                            }

                            if (nRow["NG_MONTH"].ToString().Substring(4, 2) == "02")
                            {
                                //tnRows[0]["WORK_2"] = string.Format("{0:n0}", tnRows[0]["WORK_2"].toInt() + nRows[0]["WORK_2"].toInt());
                                tnRows[0]["WORK_2_D"] = tnRows[0]["WORK_2_D"].toInt() + nRow["NG_CNT"].toInt();
                                tnRows[0]["WORK_2"] = string.Format("{0:n0}", tnRows[0]["WORK_2_D"]);
                            }

                            if (nRow["NG_MONTH"].ToString().Substring(4, 2) == "03")
                            {
                                //tnRows[0]["WORK_3"] = string.Format("{0:n0}", tnRows[0]["WORK_3"].toInt() + nRows[0]["WORK_3"].toInt());
                                tnRows[0]["WORK_3_D"] = tnRows[0]["WORK_3_D"].toInt() + nRow["NG_CNT"].toInt();
                                tnRows[0]["WORK_3"] = string.Format("{0:n0}", tnRows[0]["WORK_3_D"]);
                            }

                            if (nRow["NG_MONTH"].ToString().Substring(4, 2) == "04")
                            {
                                //tnRows[0]["WORK_4"] = string.Format("{0:n0}", tnRows[0]["WORK_4"].toInt() + nRows[0]["WORK_4"].toInt());
                                tnRows[0]["WORK_4_D"] = tnRows[0]["WORK_4_D"].toInt() + nRow["NG_CNT"].toInt();
                                tnRows[0]["WORK_4"] = string.Format("{0:n0}", tnRows[0]["WORK_4_D"]);
                            }

                            if (nRow["NG_MONTH"].ToString().Substring(4, 2) == "05")
                            {
                                //tnRows[0]["WORK_5"] = string.Format("{0:n0}", tnRows[0]["WORK_5"].toInt() + nRows[0]["WORK_5"].toInt());
                                tnRows[0]["WORK_5_D"] = tnRows[0]["WORK_5_D"].toInt() + nRow["NG_CNT"].toInt();
                                tnRows[0]["WORK_5"] = string.Format("{0:n0}", tnRows[0]["WORK_5_D"]);
                            }

                            if (nRow["NG_MONTH"].ToString().Substring(4, 2) == "06")
                            {
                                //tnRows[0]["WORK_6"] = string.Format("{0:n0}", tnRows[0]["WORK_6"].toInt() + nRows[0]["WORK_6"].toInt());
                                tnRows[0]["WORK_6_D"] = tnRows[0]["WORK_6_D"].toInt() + nRow["NG_CNT"].toInt();
                                tnRows[0]["WORK_6"] = string.Format("{0:n0}", tnRows[0]["WORK_6_D"]);
                            }

                            if (nRow["NG_MONTH"].ToString().Substring(4, 2) == "07")
                            {
                                //tnRows[0]["WORK_7"] = string.Format("{0:n0}", tnRows[0]["WORK_7"].toInt() + nRows[0]["WORK_7"].toInt());
                                tnRows[0]["WORK_7_D"] = tnRows[0]["WORK_7_D"].toInt() + nRow["NG_CNT"].toInt();
                                tnRows[0]["WORK_7"] = string.Format("{0:n0}", tnRows[0]["WORK_7_D"]);
                            }

                            if (nRow["NG_MONTH"].ToString().Substring(4, 2) == "08")
                            {
                                //tnRows[0]["WORK_8"] = string.Format("{0:n0}", tnRows[0]["WORK_8"].toInt() + nRows[0]["WORK_8"].toInt());
                                tnRows[0]["WORK_8_D"] = tnRows[0]["WORK_8_D"].toInt() + nRow["NG_CNT"].toInt();
                                tnRows[0]["WORK_8"] = string.Format("{0:n0}", tnRows[0]["WORK_8_D"]);
                            }

                            if (nRow["NG_MONTH"].ToString().Substring(4, 2) == "09")
                            {
                                //tnRows[0]["WORK_9"] = string.Format("{0:n0}", tnRows[0]["WORK_9"].toInt() + nRows[0]["WORK_9"].toInt());
                                tnRows[0]["WORK_9_D"] = tnRows[0]["WORK_9_D"].toInt() + nRow["NG_CNT"].toInt();
                                tnRows[0]["WORK_9"] = string.Format("{0:n0}", tnRows[0]["WORK_9_D"]);
                            }

                            if (nRow["NG_MONTH"].ToString().Substring(4, 2) == "10")
                            {
                                //tnRows[0]["WORK_10"] = string.Format("{0:n0}", tnRows[0]["WORK_10"].toInt() + nRows[0]["WORK_10"].toInt());
                                tnRows[0]["WORK_10_D"] = tnRows[0]["WORK_10_D"].toInt() + nRow["NG_CNT"].toInt();
                                tnRows[0]["WORK_10"] = string.Format("{0:n0}", tnRows[0]["WORK_10_D"]);
                            }

                            if (nRow["NG_MONTH"].ToString().Substring(4, 2) == "11")
                            {
                                //tnRows[0]["WORK_11"] = string.Format("{0:n0}", tnRows[0]["WORK_11"].toInt() + nRows[0]["WORK_11"].toInt());
                                tnRows[0]["WORK_11_D"] = tnRows[0]["WORK_11_D"].toInt() + nRow["NG_CNT"].toInt();
                                tnRows[0]["WORK_11"] = string.Format("{0:n0}", tnRows[0]["WORK_11_D"]);
                            }

                            if (nRow["NG_MONTH"].ToString().Substring(4, 2) == "12")
                            {
                                //tnRows[0]["WORK_12"] = string.Format("{0:n0}", tnRows[0]["WORK_12"].toInt() + nRows[0]["WORK_12"].toInt());
                                tnRows[0]["WORK_12_D"] = tnRows[0]["WORK_12_D"].toInt() + nRow["NG_CNT"].toInt();
                                tnRows[0]["WORK_12"] = string.Format("{0:n0}", tnRows[0]["WORK_12_D"]);
                            }

                            double tSum2 = tnRows[0]["WORK_1_D"].toInt() + tnRows[0]["WORK_2_D"].toInt() + tnRows[0]["WORK_3_D"].toInt() + tnRows[0]["WORK_4_D"].toInt()
                                         + tnRows[0]["WORK_5_D"].toInt() + tnRows[0]["WORK_6_D"].toInt() + tnRows[0]["WORK_7_D"].toInt() + tnRows[0]["WORK_8_D"].toInt()
                                         + tnRows[0]["WORK_9_D"].toInt() + tnRows[0]["WORK_10_D"].toInt() + tnRows[0]["WORK_11_D"].toInt() + tnRows[0]["WORK_12_D"].toInt();

                            tnRows[0]["WORK_SUM"] = string.Format("{0:n0}", tSum2);
                            tnRows[0]["WORK_SUM_D"] = tSum2;
                        }
                    }
                }

                DataRow[] rateRows = gridTable.Select("FLAG = 'RATE'");

                foreach (DataRow row in rateRows)
                {
                    DataRow[] totalCamRows = gridTable.Select("FLAG = 'CAM_SUM'");
                    DataRow[] totalNgRows = gridTable.Select("FLAG = 'NG_SUM'");

                    if (totalCamRows.Length == 1 && totalNgRows.Length == 1)
                    {
                        if (totalNgRows[0]["WORK_1_D"].toInt() > 0 && totalCamRows[0]["WORK_1_D"].toInt() > 0) row["WORK_1"] = string.Format("{0:n2}%", totalNgRows[0]["WORK_1_D"].toDouble() / totalCamRows[0]["WORK_1_D"].toDouble() * 100);
                        if (totalNgRows[0]["WORK_2_D"].toInt() > 0 && totalCamRows[0]["WORK_2_D"].toInt() > 0) row["WORK_2"] = string.Format("{0:n2}%", totalNgRows[0]["WORK_2_D"].toDouble() / totalCamRows[0]["WORK_2_D"].toDouble() * 100);
                        if (totalNgRows[0]["WORK_3_D"].toInt() > 0 && totalCamRows[0]["WORK_3_D"].toInt() > 0) row["WORK_3"] = string.Format("{0:n2}%", totalNgRows[0]["WORK_3_D"].toDouble() / totalCamRows[0]["WORK_3_D"].toDouble() * 100);
                        if (totalNgRows[0]["WORK_4_D"].toInt() > 0 && totalCamRows[0]["WORK_4_D"].toInt() > 0) row["WORK_4"] = string.Format("{0:n2}%", totalNgRows[0]["WORK_4_D"].toDouble() / totalCamRows[0]["WORK_4_D"].toDouble() * 100);
                        if (totalNgRows[0]["WORK_5_D"].toInt() > 0 && totalCamRows[0]["WORK_5_D"].toInt() > 0) row["WORK_5"] = string.Format("{0:n2}%", totalNgRows[0]["WORK_5_D"].toDouble() / totalCamRows[0]["WORK_5_D"].toDouble() * 100);
                        if (totalNgRows[0]["WORK_6_D"].toInt() > 0 && totalCamRows[0]["WORK_6_D"].toInt() > 0) row["WORK_6"] = string.Format("{0:n2}%", totalNgRows[0]["WORK_6_D"].toDouble() / totalCamRows[0]["WORK_6_D"].toDouble() * 100);
                        if (totalNgRows[0]["WORK_7_D"].toInt() > 0 && totalCamRows[0]["WORK_7_D"].toInt() > 0) row["WORK_7"] = string.Format("{0:n2}%", totalNgRows[0]["WORK_7_D"].toDouble() / totalCamRows[0]["WORK_7_D"].toDouble() * 100);
                        if (totalNgRows[0]["WORK_8_D"].toInt() > 0 && totalCamRows[0]["WORK_8_D"].toInt() > 0) row["WORK_8"] = string.Format("{0:n2}%", totalNgRows[0]["WORK_8_D"].toDouble() / totalCamRows[0]["WORK_8_D"].toDouble() * 100);
                        if (totalNgRows[0]["WORK_9_D"].toInt() > 0 && totalCamRows[0]["WORK_9_D"].toInt() > 0) row["WORK_9"] = string.Format("{0:n2}%", totalNgRows[0]["WORK_9_D"].toDouble() / totalCamRows[0]["WORK_9_D"].toDouble() * 100);
                        if (totalNgRows[0]["WORK_10_D"].toInt() > 0 && totalCamRows[0]["WORK_10_D"].toInt() > 0) row["WORK_10"] = string.Format("{0:n2}%", totalNgRows[0]["WORK_10_D"].toDouble() / totalCamRows[0]["WORK_10_D"].toDouble() * 100);
                        if (totalNgRows[0]["WORK_11_D"].toInt() > 0 && totalCamRows[0]["WORK_11_D"].toInt() > 0) row["WORK_11"] = string.Format("{0:n2}%", totalNgRows[0]["WORK_11_D"].toDouble() / totalCamRows[0]["WORK_11_D"].toDouble() * 100);
                        if (totalNgRows[0]["WORK_12_D"].toInt() > 0 && totalCamRows[0]["WORK_12_D"].toInt() > 0) row["WORK_12"] = string.Format("{0:n2}%", totalNgRows[0]["WORK_12_D"].toDouble() / totalCamRows[0]["WORK_12_D"].toDouble() * 100);
                        if (totalNgRows[0]["WORK_SUM_D"].toInt() > 0 && totalCamRows[0]["WORK_SUM_D"].toInt() > 0) row["WORK_SUM"] = string.Format("{0:n2}%", totalNgRows[0]["WORK_SUM_D"].toDouble() / totalCamRows[0]["WORK_SUM_D"].toDouble() * 100);
                    }
                }


                gridTable.TableName = "RSLTDT";
                paramDS.Tables.Add(gridTable);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet REP05A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable cloneTable = new DataTable();
                cloneTable.Columns.Add("PLT_CODE", typeof(String));
                cloneTable.Columns.Add("WORK_LOC", typeof(String));
                cloneTable.Columns.Add("WORK_LOC_NAME", typeof(String));
                cloneTable.Columns.Add("EMP_CODE", typeof(String));
                cloneTable.Columns.Add("EMP_NAME", typeof(String));
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

                DataTable dtRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY39(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable dtNgRslt = DSHP.TSHP_NG_QUERY.TSHP_NG_QUERY8(paramDS.Tables["RQSTDT"], bizExecute);

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "CD_PARENT_IN", "A,B,I", typeof(string));
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "CAT_CODE", "C401", typeof(string));
                DataTable dtNgCodeRslt = DSTD.TSTD_CODES_QUERY.TSTD_CODES_QUERY8(paramDS.Tables["RQSTDT"], bizExecute);

                var innerJoin = from tb1 in dtNgRslt.AsEnumerable()
                                group tb1 by new { PLT_CODE = tb1.Field<string>("PLT_CODE"), DETAIL_CAUSE = tb1.Field<string>("DETAIL_CAUSE") } into gtb1
                                join tb2 in dtNgCodeRslt.AsEnumerable()
                                on gtb1.FirstOrDefault().Field<string>("DETAIL_CAUSE") equals tb2.Field<string>("CD_CODE") into dataKey
                                from tb2 in dataKey
                                select new
                                {
                                    PLT_CODE = tb2.Field<string>("PLT_CODE"),
                                    CD_CODE = tb2.Field<string>("CD_CODE"),
                                    CD_NAME = tb2.Field<string>("CD_NAME"),
                                };

                DataTable codeTable = innerJoin.LINQToDataTable();

                DataTable gridTable = cloneTable.Clone();

                foreach (DataRow row in dtRslt.Rows)
                {
                    DataRow[] rows = gridTable.Select("FLAG = '" + row["PROD_FLAG"].ToString() + "' AND EMP_CODE = '" + row["CAM_EMP"].ToString() + "'");

                    if (rows.Length == 0)
                    {
                        DataRow newRow = gridTable.NewRow();
                        newRow["PLT_CODE"] = row["PLT_CODE"];
                        newRow["WORK_LOC"] = row["WORK_LOC"];
                        newRow["WORK_LOC_NAME"] = row["WORK_LOC_NAME"];
                        newRow["EMP_CODE"] = row["CAM_EMP"];
                        newRow["EMP_NAME"] = row["CAM_EMP_NAME"];
                        newRow["FLAG"] = "NE";
                        newRow["TYPE"] = "New";

                        for (int i = 1; i < 13; i++)
                        {
                            newRow["WORK_" + i.ToString()] = string.Format("{0:N0}", 0);
                        }
                        newRow["WORK_SUM"] = 0;
                        gridTable.Rows.Add(newRow);

                        newRow = gridTable.NewRow();
                        newRow["PLT_CODE"] = row["PLT_CODE"];
                        newRow["WORK_LOC"] = row["WORK_LOC"];
                        newRow["WORK_LOC_NAME"] = row["WORK_LOC_NAME"];
                        newRow["EMP_CODE"] = row["CAM_EMP"];
                        newRow["EMP_NAME"] = row["CAM_EMP_NAME"];
                        newRow["FLAG"] = "RE";
                        newRow["TYPE"] = "Repeat";
                        for (int i = 1; i < 13; i++)
                        {
                            newRow["WORK_" + i.ToString()] = string.Format("{0:N0}", 0);
                        }
                        newRow["WORK_SUM"] = 0;
                        gridTable.Rows.Add(newRow);

                        newRow = gridTable.NewRow();
                        newRow["PLT_CODE"] = row["PLT_CODE"];
                        newRow["WORK_LOC"] = row["WORK_LOC"];
                        newRow["WORK_LOC_NAME"] = row["WORK_LOC_NAME"];
                        newRow["EMP_CODE"] = row["CAM_EMP"];
                        newRow["EMP_NAME"] = row["CAM_EMP_NAME"];
                        newRow["FLAG"] = "CAM_SUM";
                        newRow["TYPE"] = "총 건수";
                        for (int i = 1; i < 13; i++)
                        {
                            newRow["WORK_" + i.ToString()] = string.Format("{0:N0}", 0);
                        }
                        newRow["WORK_SUM"] = 0;
                        gridTable.Rows.Add(newRow);

                        newRow = gridTable.NewRow();
                        newRow["PLT_CODE"] = row["PLT_CODE"];
                        newRow["WORK_LOC"] = row["WORK_LOC"];
                        newRow["WORK_LOC_NAME"] = row["WORK_LOC_NAME"];
                        newRow["EMP_CODE"] = row["CAM_EMP"];
                        newRow["EMP_NAME"] = row["CAM_EMP_NAME"];
                        newRow["FLAG"] = "NG_SUM";
                        newRow["TYPE"] = "불량건수";
                        for (int i = 1; i < 13; i++)
                        {
                            newRow["WORK_" + i.ToString()] = string.Format("{0:N0}", 0);
                        }
                        newRow["WORK_SUM"] = 0;
                        gridTable.Rows.Add(newRow);

                        foreach (DataRow stdRow in codeTable.Rows)
                        {
                            newRow = gridTable.NewRow();
                            newRow["PLT_CODE"] = row["PLT_CODE"];
                            newRow["WORK_LOC"] = row["WORK_LOC"];
                            newRow["WORK_LOC_NAME"] = row["WORK_LOC_NAME"];
                            newRow["EMP_CODE"] = row["CAM_EMP"];
                            newRow["EMP_NAME"] = row["CAM_EMP_NAME"];
                            newRow["FLAG"] = stdRow["CD_CODE"];
                            newRow["TYPE"] = "   " + stdRow["CD_NAME"];
                            for (int i = 1; i < 13; i++)
                            {
                                newRow["WORK_" + i.ToString()] = string.Format("{0:N0}", 0);
                            }
                            newRow["WORK_SUM"] = 0;
                            gridTable.Rows.Add(newRow);
                        }

                        newRow = gridTable.NewRow();
                        newRow["PLT_CODE"] = row["PLT_CODE"];
                        newRow["WORK_LOC"] = row["WORK_LOC"];
                        newRow["WORK_LOC_NAME"] = row["WORK_LOC_NAME"];
                        newRow["EMP_CODE"] = row["CAM_EMP"];
                        newRow["EMP_NAME"] = row["CAM_EMP_NAME"];
                        newRow["FLAG"] = "RATE";
                        newRow["TYPE"] = "비율";
                        for (int i = 1; i < 13; i++)
                        {
                            newRow["WORK_" + i.ToString()] = "0.00%";
                        }
                        newRow["WORK_SUM"] = "0.00%";
                        gridTable.Rows.Add(newRow);
                    }

                    DataRow[] wRows = gridTable.Select("FLAG = '" + row["PROD_FLAG"].ToString() + "' AND EMP_CODE = '" + row["CAM_EMP"].ToString() + "'");

                    DataRow[] tRows = gridTable.Select("FLAG = 'CAM_SUM' AND EMP_CODE = '" + row["CAM_EMP"].ToString() + "'");

                    if (wRows.Length > 0)
                    {
                        if (row["ACT_END_MONTH"].ToString().Substring(4, 2) == "01")
                        {
                            //wRows[0]["WORK_1"] = string.Format("{0:n0}", wRows[0]["WORK_1"].toInt() + row["PART_CNT"].toInt());
                            wRows[0]["WORK_1_D"] = wRows[0]["WORK_1_D"].toInt() + row["PART_CNT"].toInt();
                            wRows[0]["WORK_1"] = string.Format("{0:n0}", wRows[0]["WORK_1_D"]);
                        }

                        if (row["ACT_END_MONTH"].ToString().Substring(4, 2) == "02")
                        {
                            //wRows[0]["WORK_2"] = string.Format("{0:n0}", wRows[0]["WORK_2"].toInt() + row["PART_CNT"].toInt());
                            wRows[0]["WORK_2_D"] = wRows[0]["WORK_2_D"].toInt() + row["PART_CNT"].toInt();
                            wRows[0]["WORK_2"] = string.Format("{0:n0}", wRows[0]["WORK_2_D"]);
                        }

                        if (row["ACT_END_MONTH"].ToString().Substring(4, 2) == "03")
                        {
                            //wRows[0]["WORK_3"] = string.Format("{0:n0}", wRows[0]["WORK_3"].toInt() + row["PART_CNT"].toInt());
                            wRows[0]["WORK_3_D"] = wRows[0]["WORK_3_D"].toInt() + row["PART_CNT"].toInt();
                            wRows[0]["WORK_3"] = string.Format("{0:n0}", wRows[0]["WORK_3_D"]);
                        }

                        if (row["ACT_END_MONTH"].ToString().Substring(4, 2) == "04")
                        {
                            //wRows[0]["WORK_4"] = string.Format("{0:n0}", wRows[0]["WORK_4"].toInt() + row["PART_CNT"].toInt());
                            wRows[0]["WORK_4_D"] = wRows[0]["WORK_4_D"].toInt() + row["PART_CNT"].toInt();
                            wRows[0]["WORK_4"] = string.Format("{0:n0}", wRows[0]["WORK_4_D"]);
                        }

                        if (row["ACT_END_MONTH"].ToString().Substring(4, 2) == "05")
                        {
                            //wRows[0]["WORK_5"] = string.Format("{0:n0}", wRows[0]["WORK_5"].toInt() + row["PART_CNT"].toInt());
                            wRows[0]["WORK_5_D"] = wRows[0]["WORK_5_D"].toInt() + row["PART_CNT"].toInt();
                            wRows[0]["WORK_5"] = string.Format("{0:n0}", wRows[0]["WORK_5_D"]);
                        }

                        if (row["ACT_END_MONTH"].ToString().Substring(4, 2) == "06")
                        {
                            //wRows[0]["WORK_6"] = string.Format("{0:n0}", wRows[0]["WORK_6"].toInt() + row["PART_CNT"].toInt());
                            wRows[0]["WORK_6_D"] = wRows[0]["WORK_6_D"].toInt() + row["PART_CNT"].toInt();
                            wRows[0]["WORK_6"] = string.Format("{0:n0}", wRows[0]["WORK_6_D"]);
                        }

                        if (row["ACT_END_MONTH"].ToString().Substring(4, 2) == "07")
                        {
                            //wRows[0]["WORK_7"] = string.Format("{0:n0}", wRows[0]["WORK_7"].toInt() + row["PART_CNT"].toInt());
                            wRows[0]["WORK_7_D"] = wRows[0]["WORK_7_D"].toInt() + row["PART_CNT"].toInt();
                            wRows[0]["WORK_7"] = string.Format("{0:n0}", wRows[0]["WORK_7_D"]);
                        }

                        if (row["ACT_END_MONTH"].ToString().Substring(4, 2) == "08")
                        {
                            //wRows[0]["WORK_8"] = string.Format("{0:n0}", wRows[0]["WORK_8"].toInt() + row["PART_CNT"].toInt());
                            wRows[0]["WORK_8_D"] = wRows[0]["WORK_8_D"].toInt() + row["PART_CNT"].toInt();
                            wRows[0]["WORK_8"] = string.Format("{0:n0}", wRows[0]["WORK_8_D"]);
                        }

                        if (row["ACT_END_MONTH"].ToString().Substring(4, 2) == "09")
                        {
                            //wRows[0]["WORK_9"] = string.Format("{0:n0}", wRows[0]["WORK_9"].toInt() + row["PART_CNT"].toInt());
                            wRows[0]["WORK_9_D"] = wRows[0]["WORK_9_D"].toInt() + row["PART_CNT"].toInt();
                            wRows[0]["WORK_9"] = string.Format("{0:n0}", wRows[0]["WORK_9_D"]);
                        }

                        if (row["ACT_END_MONTH"].ToString().Substring(4, 2) == "10")
                        {
                            //wRows[0]["WORK_10"] = string.Format("{0:n0}", wRows[0]["WORK_10"].toInt() + row["PART_CNT"].toInt());
                            wRows[0]["WORK_10_D"] = wRows[0]["WORK_10_D"].toInt() + row["PART_CNT"].toInt();
                            wRows[0]["WORK_10"] = string.Format("{0:n0}", wRows[0]["WORK_10_D"]);
                        }

                        if (row["ACT_END_MONTH"].ToString().Substring(4, 2) == "11")
                        {
                            //wRows[0]["WORK_11"] = string.Format("{0:n0}", wRows[0]["WORK_11"].toInt() + row["PART_CNT"].toInt());
                            wRows[0]["WORK_11_D"] = wRows[0]["WORK_11_D"].toInt() + row["PART_CNT"].toInt();
                            wRows[0]["WORK_11"] = string.Format("{0:n0}", wRows[0]["WORK_11_D"]);
                        }

                        if (row["ACT_END_MONTH"].ToString().Substring(4, 2) == "12")
                        {
                            //wRows[0]["WORK_12"] = string.Format("{0:n0}", wRows[0]["WORK_12"].toInt() + row["PART_CNT"].toInt());
                            wRows[0]["WORK_12_D"] = wRows[0]["WORK_12_D"].toInt() + row["PART_CNT"].toInt();
                            wRows[0]["WORK_12"] = string.Format("{0:n0}", wRows[0]["WORK_12_D"]);
                        }

                        double sum = wRows[0]["WORK_1_D"].toInt() + wRows[0]["WORK_2_D"].toInt() + wRows[0]["WORK_3_D"].toInt() + wRows[0]["WORK_4_D"].toInt()
                                     + wRows[0]["WORK_5_D"].toInt() + wRows[0]["WORK_6_D"].toInt() + wRows[0]["WORK_7_D"].toInt() + wRows[0]["WORK_8_D"].toInt()
                                     + wRows[0]["WORK_9_D"].toInt() + wRows[0]["WORK_10_D"].toInt() + wRows[0]["WORK_11_D"].toInt() + wRows[0]["WORK_12_D"].toInt();

                        wRows[0]["WORK_SUM"] = string.Format("{0:n0}", sum);
                        wRows[0]["WORK_SUM_D"] = sum;

                        if (tRows.Length == 1)
                        {
                            if (row["ACT_END_MONTH"].ToString().Substring(4, 2) == "01")
                            {
                                //tRows[0]["WORK_1"] = string.Format("{0:n0}", tRows[0]["WORK_1"].toInt() + wRows[0]["WORK_1"].toInt());
                                tRows[0]["WORK_1_D"] = tRows[0]["WORK_1_D"].toInt() + row["PART_CNT"].toInt();
                                tRows[0]["WORK_1"] = string.Format("{0:n0}", tRows[0]["WORK_1_D"]);
                            }

                            if (row["ACT_END_MONTH"].ToString().Substring(4, 2) == "02")
                            {
                                //tRows[0]["WORK_2"] = string.Format("{0:n0}", tRows[0]["WORK_2"].toInt() + wRows[0]["WORK_2"].toInt());
                                tRows[0]["WORK_2_D"] = tRows[0]["WORK_2_D"].toInt() + row["PART_CNT"].toInt();
                                tRows[0]["WORK_2"] = string.Format("{0:n0}", tRows[0]["WORK_2_D"]);
                            }

                            if (row["ACT_END_MONTH"].ToString().Substring(4, 2) == "03")
                            {
                                //tRows[0]["WORK_3"] = string.Format("{0:n0}", tRows[0]["WORK_3"].toInt() + wRows[0]["WORK_3"].toInt());
                                tRows[0]["WORK_3_D"] = tRows[0]["WORK_3_D"].toInt() + row["PART_CNT"].toInt();
                                tRows[0]["WORK_3"] = string.Format("{0:n0}", tRows[0]["WORK_3_D"]);
                            }

                            if (row["ACT_END_MONTH"].ToString().Substring(4, 2) == "04")
                            {
                                //tRows[0]["WORK_4"] = string.Format("{0:n0}", tRows[0]["WORK_4"].toInt() + wRows[0]["WORK_4"].toInt());
                                tRows[0]["WORK_4_D"] = tRows[0]["WORK_4_D"].toInt() + row["PART_CNT"].toInt();
                                tRows[0]["WORK_4"] = string.Format("{0:n0}", tRows[0]["WORK_4_D"]);
                            }

                            if (row["ACT_END_MONTH"].ToString().Substring(4, 2) == "05")
                            {
                                //tRows[0]["WORK_5"] = string.Format("{0:n0}", tRows[0]["WORK_5"].toInt() + wRows[0]["WORK_5"].toInt());
                                tRows[0]["WORK_5_D"] = tRows[0]["WORK_5_D"].toInt() + row["PART_CNT"].toInt();
                                tRows[0]["WORK_5"] = string.Format("{0:n0}", tRows[0]["WORK_5_D"]);
                            }

                            if (row["ACT_END_MONTH"].ToString().Substring(4, 2) == "06")
                            {
                                //tRows[0]["WORK_6"] = string.Format("{0:n0}", tRows[0]["WORK_6"].toInt() + wRows[0]["WORK_6"].toInt());
                                tRows[0]["WORK_6_D"] = tRows[0]["WORK_6_D"].toInt() + row["PART_CNT"].toInt();
                                tRows[0]["WORK_6"] = string.Format("{0:n0}", tRows[0]["WORK_6_D"]);
                            }

                            if (row["ACT_END_MONTH"].ToString().Substring(4, 2) == "07")
                            {
                                //tRows[0]["WORK_7"] = string.Format("{0:n0}", tRows[0]["WORK_7"].toInt() + wRows[0]["WORK_7"].toInt());
                                tRows[0]["WORK_7_D"] = tRows[0]["WORK_7_D"].toInt() + row["PART_CNT"].toInt();
                                tRows[0]["WORK_7"] = string.Format("{0:n0}", tRows[0]["WORK_7_D"]);
                            }

                            if (row["ACT_END_MONTH"].ToString().Substring(4, 2) == "08")
                            {
                                //tRows[0]["WORK_8"] = string.Format("{0:n0}", tRows[0]["WORK_8"].toInt() + wRows[0]["WORK_8"].toInt());
                                tRows[0]["WORK_8_D"] = tRows[0]["WORK_8_D"].toInt() + row["PART_CNT"].toInt();
                                tRows[0]["WORK_8"] = string.Format("{0:n0}", tRows[0]["WORK_8_D"]);
                            }

                            if (row["ACT_END_MONTH"].ToString().Substring(4, 2) == "09")
                            {
                                //tRows[0]["WORK_9"] = string.Format("{0:n0}", tRows[0]["WORK_9"].toInt() + wRows[0]["WORK_9"].toInt());
                                tRows[0]["WORK_9_D"] = tRows[0]["WORK_9_D"].toInt() + row["PART_CNT"].toInt();
                                tRows[0]["WORK_9"] = string.Format("{0:n0}", tRows[0]["WORK_9_D"]);
                            }

                            if (row["ACT_END_MONTH"].ToString().Substring(4, 2) == "10")
                            {
                                //tRows[0]["WORK_10"] = string.Format("{0:n0}", tRows[0]["WORK_10"].toInt() + wRows[0]["WORK_10"].toInt());
                                tRows[0]["WORK_10_D"] = tRows[0]["WORK_10_D"].toInt() + row["PART_CNT"].toInt();
                                tRows[0]["WORK_10"] = string.Format("{0:n0}", tRows[0]["WORK_10_D"]);
                            }

                            if (row["ACT_END_MONTH"].ToString().Substring(4, 2) == "11")
                            {
                                //tRows[0]["WORK_11"] = string.Format("{0:n0}", tRows[0]["WORK_11"].toInt() + wRows[0]["WORK_11"].toInt());
                                tRows[0]["WORK_11_D"] = tRows[0]["WORK_11_D"].toInt() + row["PART_CNT"].toInt();
                                tRows[0]["WORK_11"] = string.Format("{0:n0}", tRows[0]["WORK_11_D"]);
                            }

                            if (row["ACT_END_MONTH"].ToString().Substring(4, 2) == "12")
                            {
                                //tRows[0]["WORK_12"] = string.Format("{0:n0}", tRows[0]["WORK_12"].toInt() + wRows[0]["WORK_12"].toInt());
                                tRows[0]["WORK_12_D"] = tRows[0]["WORK_12_D"].toInt() + row["PART_CNT"].toInt();
                                tRows[0]["WORK_12"] = string.Format("{0:n0}", tRows[0]["WORK_12_D"]);
                            }


                            double tSum = tRows[0]["WORK_1_D"].toInt() + tRows[0]["WORK_2_D"].toInt() + tRows[0]["WORK_3_D"].toInt() + tRows[0]["WORK_4_D"].toInt()
                                         + tRows[0]["WORK_5_D"].toInt() + tRows[0]["WORK_6_D"].toInt() + tRows[0]["WORK_7_D"].toInt() + tRows[0]["WORK_8_D"].toInt()
                                         + tRows[0]["WORK_9_D"].toInt() + tRows[0]["WORK_10_D"].toInt() + tRows[0]["WORK_11_D"].toInt() + tRows[0]["WORK_12_D"].toInt();

                            tRows[0]["WORK_SUM"] = string.Format("{0:n0}", tSum);
                            tRows[0]["WORK_SUM_D"] = tSum;
                        }
                    }
                }

                foreach (DataRow nRow in dtNgRslt.Rows)
                {
                    DataRow[] nRows = gridTable.Select("FLAG = '" + nRow["DETAIL_CAUSE"].ToString() + "' AND EMP_CODE = '" + nRow["CAM_EMP"].ToString() + "'");

                    DataRow[] tnRows = gridTable.Select("FLAG = 'NG_SUM' AND EMP_CODE = '" + nRow["CAM_EMP"].ToString() + "'");

                    if (nRows.Length > 0)
                    {
                        if (nRow["NG_MONTH"].ToString().Substring(4, 2) == "01")
                        {
                            //nRows[0]["WORK_1"] = string.Format("{0:n0}", nRows[0]["WORK_1"].toInt() + nRow["NG_CNT"].toInt());
                            nRows[0]["WORK_1_D"] = nRows[0]["WORK_1_D"].toInt() + nRow["NG_CNT"].toInt();
                            nRows[0]["WORK_1"] = string.Format("{0:n0}", nRows[0]["WORK_1_D"]);
                        }

                        if (nRow["NG_MONTH"].ToString().Substring(4, 2) == "02")
                        {
                            //nRows[0]["WORK_2"] = string.Format("{0:n0}", nRows[0]["WORK_2"].toInt() + nRow["NG_CNT"].toInt());
                            nRows[0]["WORK_2_D"] = nRows[0]["WORK_2_D"].toInt() + nRow["NG_CNT"].toInt();
                            nRows[0]["WORK_2"] = string.Format("{0:n0}", nRows[0]["WORK_2_D"]);
                        }

                        if (nRow["NG_MONTH"].ToString().Substring(4, 2) == "03")
                        {
                            //nRows[0]["WORK_3"] = string.Format("{0:n0}", nRows[0]["WORK_3"].toInt() + nRow["NG_CNT"].toInt());
                            nRows[0]["WORK_3_D"] = nRows[0]["WORK_3_D"].toInt() + nRow["NG_CNT"].toInt();
                            nRows[0]["WORK_3"] = string.Format("{0:n0}", nRows[0]["WORK_3_D"]);
                        }

                        if (nRow["NG_MONTH"].ToString().Substring(4, 2) == "04")
                        {
                            //nRows[0]["WORK_4"] = string.Format("{0:n0}", nRows[0]["WORK_4"].toInt() + nRow["NG_CNT"].toInt());
                            nRows[0]["WORK_4_D"] = nRows[0]["WORK_4_D"].toInt() + nRow["NG_CNT"].toInt();
                            nRows[0]["WORK_4"] = string.Format("{0:n0}", nRows[0]["WORK_4_D"]);
                        }

                        if (nRow["NG_MONTH"].ToString().Substring(4, 2) == "05")
                        {
                            //nRows[0]["WORK_5"] = string.Format("{0:n0}", nRows[0]["WORK_5"].toInt() + nRow["NG_CNT"].toInt());
                            nRows[0]["WORK_5_D"] = nRows[0]["WORK_5_D"].toInt() + nRow["NG_CNT"].toInt();
                            nRows[0]["WORK_5"] = string.Format("{0:n0}", nRows[0]["WORK_5_D"]);
                        }

                        if (nRow["NG_MONTH"].ToString().Substring(4, 2) == "06")
                        {
                            //nRows[0]["WORK_6"] = string.Format("{0:n0}", nRows[0]["WORK_6"].toInt() + nRow["NG_CNT"].toInt());
                            nRows[0]["WORK_6_D"] = nRows[0]["WORK_6_D"].toInt() + nRow["NG_CNT"].toInt();
                            nRows[0]["WORK_6"] = string.Format("{0:n0}", nRows[0]["WORK_6_D"]);
                        }

                        if (nRow["NG_MONTH"].ToString().Substring(4, 2) == "07")
                        {
                            //nRows[0]["WORK_7"] = string.Format("{0:n0}", nRows[0]["WORK_7"].toInt() + nRow["NG_CNT"].toInt());
                            nRows[0]["WORK_7_D"] = nRows[0]["WORK_7_D"].toInt() + nRow["NG_CNT"].toInt();
                            nRows[0]["WORK_7"] = string.Format("{0:n0}", nRows[0]["WORK_7_D"]);
                        }

                        if (nRow["NG_MONTH"].ToString().Substring(4, 2) == "08")
                        {
                            //nRows[0]["WORK_8"] = string.Format("{0:n0}", nRows[0]["WORK_8"].toInt() + nRow["NG_CNT"].toInt());
                            nRows[0]["WORK_8_D"] = nRows[0]["WORK_8_D"].toInt() + nRow["NG_CNT"].toInt();
                            nRows[0]["WORK_8"] = string.Format("{0:n0}", nRows[0]["WORK_8_D"]);
                        }

                        if (nRow["NG_MONTH"].ToString().Substring(4, 2) == "09")
                        {
                            //nRows[0]["WORK_9"] = string.Format("{0:n0}", nRows[0]["WORK_9"].toInt() + nRow["NG_CNT"].toInt());
                            nRows[0]["WORK_9_D"] = nRows[0]["WORK_9_D"].toInt() + nRow["NG_CNT"].toInt();
                            nRows[0]["WORK_9"] = string.Format("{0:n0}", nRows[0]["WORK_9_D"]);
                        }

                        if (nRow["NG_MONTH"].ToString().Substring(4, 2) == "10")
                        {
                            //nRows[0]["WORK_10"] = string.Format("{0:n0}", nRows[0]["WORK_10"].toInt() + nRow["NG_CNT"].toInt());
                            nRows[0]["WORK_10_D"] = nRows[0]["WORK_10_D"].toInt() + nRow["NG_CNT"].toInt();
                            nRows[0]["WORK_10"] = string.Format("{0:n0}", nRows[0]["WORK_10_D"]);
                        }

                        if (nRow["NG_MONTH"].ToString().Substring(4, 2) == "11")
                        {
                            //nRows[0]["WORK_11"] = string.Format("{0:n0}", nRows[0]["WORK_11"].toInt() + nRow["NG_CNT"].toInt());
                            nRows[0]["WORK_11_D"] = nRows[0]["WORK_11_D"].toInt() + nRow["NG_CNT"].toInt();
                            nRows[0]["WORK_11"] = string.Format("{0:n0}", nRows[0]["WORK_11_D"]);
                        }

                        if (nRow["NG_MONTH"].ToString().Substring(4, 2) == "12")
                        {
                            //nRows[0]["WORK_12"] = string.Format("{0:n0}", nRows[0]["WORK_12"].toInt() + nRow["NG_CNT"].toInt());
                            nRows[0]["WORK_12_D"] = nRows[0]["WORK_12_D"].toInt() + nRow["NG_CNT"].toInt();
                            nRows[0]["WORK_12"] = string.Format("{0:n0}", nRows[0]["WORK_12_D"]);
                        }

                        double sum = nRows[0]["WORK_1_D"].toInt() + nRows[0]["WORK_2_D"].toInt() + nRows[0]["WORK_3_D"].toInt() + nRows[0]["WORK_4_D"].toInt()
                                     + nRows[0]["WORK_5_D"].toInt() + nRows[0]["WORK_6_D"].toInt() + nRows[0]["WORK_7_D"].toInt() + nRows[0]["WORK_8_D"].toInt()
                                     + nRows[0]["WORK_9_D"].toInt() + nRows[0]["WORK_10_D"].toInt() + nRows[0]["WORK_11_D"].toInt() + nRows[0]["WORK_12_D"].toInt();

                        nRows[0]["WORK_SUM"] = string.Format("{0:n0}", sum);
                        nRows[0]["WORK_SUM_D"] = sum;

                        if (tnRows.Length == 1)
                        {
                            if (nRow["NG_MONTH"].ToString().Substring(4, 2) == "01")
                            {
                                //tnRows[0]["WORK_1"] = string.Format("{0:n0}", tnRows[0]["WORK_1"].toInt() + nRows[0]["WORK_1"].toInt());
                                tnRows[0]["WORK_1_D"] = tnRows[0]["WORK_1_D"].toInt() + nRow["NG_CNT"].toInt();
                                tnRows[0]["WORK_1"] = string.Format("{0:n0}", tnRows[0]["WORK_1_D"]);
                            }

                            if (nRow["NG_MONTH"].ToString().Substring(4, 2) == "02")
                            {
                                //tnRows[0]["WORK_2"] = string.Format("{0:n0}", tnRows[0]["WORK_2"].toInt() + nRows[0]["WORK_2"].toInt());
                                tnRows[0]["WORK_2_D"] = tnRows[0]["WORK_2_D"].toInt() + nRow["NG_CNT"].toInt();
                                tnRows[0]["WORK_2"] = string.Format("{0:n0}", tnRows[0]["WORK_2_D"]);
                            }

                            if (nRow["NG_MONTH"].ToString().Substring(4, 2) == "03")
                            {
                                //tnRows[0]["WORK_3"] = string.Format("{0:n0}", tnRows[0]["WORK_3"].toInt() + nRows[0]["WORK_3"].toInt());
                                tnRows[0]["WORK_3_D"] = tnRows[0]["WORK_3_D"].toInt() + nRow["NG_CNT"].toInt();
                                tnRows[0]["WORK_3"] = string.Format("{0:n0}", tnRows[0]["WORK_3_D"]);
                            }

                            if (nRow["NG_MONTH"].ToString().Substring(4, 2) == "04")
                            {
                                //tnRows[0]["WORK_4"] = string.Format("{0:n0}", tnRows[0]["WORK_4"].toInt() + nRows[0]["WORK_4"].toInt());
                                tnRows[0]["WORK_4_D"] = tnRows[0]["WORK_4_D"].toInt() + nRow["NG_CNT"].toInt();
                                tnRows[0]["WORK_4"] = string.Format("{0:n0}", tnRows[0]["WORK_4_D"]);
                            }

                            if (nRow["NG_MONTH"].ToString().Substring(4, 2) == "05")
                            {
                                //tnRows[0]["WORK_5"] = string.Format("{0:n0}", tnRows[0]["WORK_5"].toInt() + nRows[0]["WORK_5"].toInt());
                                tnRows[0]["WORK_5_D"] = tnRows[0]["WORK_5_D"].toInt() + nRow["NG_CNT"].toInt();
                                tnRows[0]["WORK_5"] = string.Format("{0:n0}", tnRows[0]["WORK_5_D"]);
                            }

                            if (nRow["NG_MONTH"].ToString().Substring(4, 2) == "06")
                            {
                                //tnRows[0]["WORK_6"] = string.Format("{0:n0}", tnRows[0]["WORK_6"].toInt() + nRows[0]["WORK_6"].toInt());
                                tnRows[0]["WORK_6_D"] = tnRows[0]["WORK_6_D"].toInt() + nRow["NG_CNT"].toInt();
                                tnRows[0]["WORK_6"] = string.Format("{0:n0}", tnRows[0]["WORK_6_D"]);
                            }

                            if (nRow["NG_MONTH"].ToString().Substring(4, 2) == "07")
                            {
                                //tnRows[0]["WORK_7"] = string.Format("{0:n0}", tnRows[0]["WORK_7"].toInt() + nRows[0]["WORK_7"].toInt());
                                tnRows[0]["WORK_7_D"] = tnRows[0]["WORK_7_D"].toInt() + nRow["NG_CNT"].toInt();
                                tnRows[0]["WORK_7"] = string.Format("{0:n0}", tnRows[0]["WORK_7_D"]);
                            }

                            if (nRow["NG_MONTH"].ToString().Substring(4, 2) == "08")
                            {
                                //tnRows[0]["WORK_8"] = string.Format("{0:n0}", tnRows[0]["WORK_8"].toInt() + nRows[0]["WORK_8"].toInt());
                                tnRows[0]["WORK_8_D"] = tnRows[0]["WORK_8_D"].toInt() + nRow["NG_CNT"].toInt();
                                tnRows[0]["WORK_8"] = string.Format("{0:n0}", tnRows[0]["WORK_8_D"]);
                            }

                            if (nRow["NG_MONTH"].ToString().Substring(4, 2) == "09")
                            {
                                //tnRows[0]["WORK_9"] = string.Format("{0:n0}", tnRows[0]["WORK_9"].toInt() + nRows[0]["WORK_9"].toInt());
                                tnRows[0]["WORK_9_D"] = tnRows[0]["WORK_9_D"].toInt() + nRow["NG_CNT"].toInt();
                                tnRows[0]["WORK_9"] = string.Format("{0:n0}", tnRows[0]["WORK_9_D"]);
                            }

                            if (nRow["NG_MONTH"].ToString().Substring(4, 2) == "10")
                            {
                                //tnRows[0]["WORK_10"] = string.Format("{0:n0}", tnRows[0]["WORK_10"].toInt() + nRows[0]["WORK_10"].toInt());
                                tnRows[0]["WORK_10_D"] = tnRows[0]["WORK_10_D"].toInt() + nRow["NG_CNT"].toInt();
                                tnRows[0]["WORK_10"] = string.Format("{0:n0}", tnRows[0]["WORK_10_D"]);
                            }

                            if (nRow["NG_MONTH"].ToString().Substring(4, 2) == "11")
                            {
                                //tnRows[0]["WORK_11"] = string.Format("{0:n0}", tnRows[0]["WORK_11"].toInt() + nRows[0]["WORK_11"].toInt());
                                tnRows[0]["WORK_11_D"] = tnRows[0]["WORK_11_D"].toInt() + nRow["NG_CNT"].toInt();
                                tnRows[0]["WORK_11"] = string.Format("{0:n0}", tnRows[0]["WORK_11_D"]);
                            }

                            if (nRow["NG_MONTH"].ToString().Substring(4, 2) == "12")
                            {
                                //tnRows[0]["WORK_12"] = string.Format("{0:n0}", tnRows[0]["WORK_12"].toInt() + nRows[0]["WORK_12"].toInt());
                                tnRows[0]["WORK_12_D"] = tnRows[0]["WORK_12_D"].toInt() + nRow["NG_CNT"].toInt();
                                tnRows[0]["WORK_12"] = string.Format("{0:n0}", tnRows[0]["WORK_12_D"]);
                            }

                            double tSum2 = tnRows[0]["WORK_1_D"].toInt() + tnRows[0]["WORK_2_D"].toInt() + tnRows[0]["WORK_3_D"].toInt() + tnRows[0]["WORK_4_D"].toInt()
                                         + tnRows[0]["WORK_5_D"].toInt() + tnRows[0]["WORK_6_D"].toInt() + tnRows[0]["WORK_7_D"].toInt() + tnRows[0]["WORK_8_D"].toInt()
                                         + tnRows[0]["WORK_9_D"].toInt() + tnRows[0]["WORK_10_D"].toInt() + tnRows[0]["WORK_11_D"].toInt() + tnRows[0]["WORK_12_D"].toInt();

                            tnRows[0]["WORK_SUM"] = string.Format("{0:n0}", tSum2);
                            tnRows[0]["WORK_SUM_D"] = tSum2;
                        }
                    }
                }

                DataRow[] rateRows = gridTable.Select("FLAG = 'RATE'");

                foreach (DataRow row in rateRows)
                {
                    DataRow[] totalCamRows = gridTable.Select("FLAG = 'CAM_SUM' AND EMP_CODE = '" + row["EMP_CODE"].ToString() + "'");
                    DataRow[] totalNgRows = gridTable.Select("FLAG = 'NG_SUM' AND EMP_CODE = '" + row["EMP_CODE"].ToString() + "'");

                    if (totalCamRows.Length == 1 && totalNgRows.Length == 1)
                    {
                        if (totalNgRows[0]["WORK_1_D"].toInt() > 0 && totalCamRows[0]["WORK_1_D"].toInt() > 0) row["WORK_1"] = string.Format("{0:n2}%", totalNgRows[0]["WORK_1_D"].toDouble() / totalCamRows[0]["WORK_1_D"].toDouble() * 100);
                        if (totalNgRows[0]["WORK_2_D"].toInt() > 0 && totalCamRows[0]["WORK_2_D"].toInt() > 0) row["WORK_2"] = string.Format("{0:n2}%", totalNgRows[0]["WORK_2_D"].toDouble() / totalCamRows[0]["WORK_2_D"].toDouble() * 100);
                        if (totalNgRows[0]["WORK_3_D"].toInt() > 0 && totalCamRows[0]["WORK_3_D"].toInt() > 0) row["WORK_3"] = string.Format("{0:n2}%", totalNgRows[0]["WORK_3_D"].toDouble() / totalCamRows[0]["WORK_3_D"].toDouble() * 100);
                        if (totalNgRows[0]["WORK_4_D"].toInt() > 0 && totalCamRows[0]["WORK_4_D"].toInt() > 0) row["WORK_4"] = string.Format("{0:n2}%", totalNgRows[0]["WORK_4_D"].toDouble() / totalCamRows[0]["WORK_4_D"].toDouble() * 100);
                        if (totalNgRows[0]["WORK_5_D"].toInt() > 0 && totalCamRows[0]["WORK_5_D"].toInt() > 0) row["WORK_5"] = string.Format("{0:n2}%", totalNgRows[0]["WORK_5_D"].toDouble() / totalCamRows[0]["WORK_5_D"].toDouble() * 100);
                        if (totalNgRows[0]["WORK_6_D"].toInt() > 0 && totalCamRows[0]["WORK_6_D"].toInt() > 0) row["WORK_6"] = string.Format("{0:n2}%", totalNgRows[0]["WORK_6_D"].toDouble() / totalCamRows[0]["WORK_6_D"].toDouble() * 100);
                        if (totalNgRows[0]["WORK_7_D"].toInt() > 0 && totalCamRows[0]["WORK_7_D"].toInt() > 0) row["WORK_7"] = string.Format("{0:n2}%", totalNgRows[0]["WORK_7_D"].toDouble() / totalCamRows[0]["WORK_7_D"].toDouble() * 100);
                        if (totalNgRows[0]["WORK_8_D"].toInt() > 0 && totalCamRows[0]["WORK_8_D"].toInt() > 0) row["WORK_8"] = string.Format("{0:n2}%", totalNgRows[0]["WORK_8_D"].toDouble() / totalCamRows[0]["WORK_8_D"].toDouble() * 100);
                        if (totalNgRows[0]["WORK_9_D"].toInt() > 0 && totalCamRows[0]["WORK_9_D"].toInt() > 0) row["WORK_9"] = string.Format("{0:n2}%", totalNgRows[0]["WORK_9_D"].toDouble() / totalCamRows[0]["WORK_9_D"].toDouble() * 100);
                        if (totalNgRows[0]["WORK_10_D"].toInt() > 0 && totalCamRows[0]["WORK_10_D"].toInt() > 0) row["WORK_10"] = string.Format("{0:n2}%", totalNgRows[0]["WORK_10_D"].toDouble() / totalCamRows[0]["WORK_10_D"].toDouble() * 100);
                        if (totalNgRows[0]["WORK_11_D"].toInt() > 0 && totalCamRows[0]["WORK_11_D"].toInt() > 0) row["WORK_11"] = string.Format("{0:n2}%", totalNgRows[0]["WORK_11_D"].toDouble() / totalCamRows[0]["WORK_11_D"].toDouble() * 100);
                        if (totalNgRows[0]["WORK_12_D"].toInt() > 0 && totalCamRows[0]["WORK_12_D"].toInt() > 0) row["WORK_12"] = string.Format("{0:n2}%", totalNgRows[0]["WORK_12_D"].toDouble() / totalCamRows[0]["WORK_12_D"].toDouble() * 100);
                        if (totalNgRows[0]["WORK_SUM_D"].toInt() > 0 && totalCamRows[0]["WORK_SUM_D"].toInt() > 0) row["WORK_SUM"] = string.Format("{0:n2}%", totalNgRows[0]["WORK_SUM_D"].toDouble() / totalCamRows[0]["WORK_SUM_D"].toDouble() * 100);
                    }
                }


                gridTable.TableName = "RSLTDT";
                paramDS.Tables.Add(gridTable);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet REP05A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable cloneTable = new DataTable();
                cloneTable.Columns.Add("PLT_CODE", typeof(String));
                cloneTable.Columns.Add("MC_CODE", typeof(String));
                cloneTable.Columns.Add("MC_NAME", typeof(String));


                DateTime sDateTime = paramDS.Tables["RQSTDT"].Rows[0]["S_WORK_DATE"].toDateTime();
                DateTime eDateTime = paramDS.Tables["RQSTDT"].Rows[0]["E_WORK_DATE"].toDateTime();

                TimeSpan ts = eDateTime.Subtract(sDateTime);

                int days = ts.TotalDays.toInt() + 1;

                for (int i = 0; i < days; i++)
                {
                    cloneTable.Columns.Add(sDateTime.AddDays(i).toDateString("yyyyMMdd"), typeof(decimal));
                }


                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DPOP.TPOP_MC_ACTUAL_QUERY.TPOP_MC_ACTUAL_QUERY3(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable gridTable = cloneTable.Clone();

                foreach (DataRow row in dtRslt.Rows)
                {
                    DataRow[] mcRws = gridTable.Select("MC_CODE = '" + row["MC_CODE"].ToString() + "'");

                    if (mcRws.Length == 0)
                    {
                        DataRow newMcRow = gridTable.NewRow();
                        newMcRow["PLT_CODE"] = row["PLT_CODE"];
                        newMcRow["MC_CODE"] = row["MC_CODE"];
                        newMcRow["MC_NAME"] = row["MC_NAME"];
                        gridTable.Rows.Add(newMcRow);
                    }

                    if (!gridTable.Columns.Contains(row["WORK_DATE"].ToString()))
                    {
                        gridTable.Columns.Add(row["WORK_DATE"].ToString(), typeof(decimal));
                    }

                    DataRow[] mcRows = gridTable.Select("MC_CODE = '" + row["MC_CODE"].ToString() + "'");

                    if (mcRows.Length == 1)
                    {
                        mcRows[0][row["WORK_DATE"].ToString()] = row["ACT_RATE"];
                    }
                }

                int cnt = gridTable.Rows.Count;

                DataRow newRateRow = gridTable.NewRow();
                newRateRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                newRateRow["MC_CODE"] = "AVG";
                newRateRow["MC_NAME"] = "평균";


                Dictionary<string, int> sumDic = new Dictionary<string, int>();

                foreach (DataRow row in gridTable.Rows)
                {
                    foreach (DataColumn col in gridTable.Columns)
                    {
                        if (col.ColumnName.isNumeric())
                        {
                            if (row[col.ColumnName].ToString() == "")
                            {
                                row[col.ColumnName] = 0;
                            }

                            if (!sumDic.ContainsKey(col.ColumnName))
                            {
                                sumDic.Add(col.ColumnName, 0);
                            }

                            sumDic[col.ColumnName] = sumDic[col.ColumnName] + row[col.ColumnName].toInt();

                            newRateRow[col.ColumnName] = cnt > 0 ? sumDic[col.ColumnName] / cnt : 0;
                        }
                    }
                }


                gridTable.Rows.Add(newRateRow);

                gridTable.TableName = "RSLTDT";
                                                
                paramDS.Tables.Add(gridTable);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet REP05A_SER3_2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable cloneTable = new DataTable();
                cloneTable.Columns.Add("PLT_CODE", typeof(String));
                cloneTable.Columns.Add("MC_GROUP", typeof(String));
                cloneTable.Columns.Add("MC_GROUP_NAME", typeof(String));


                DateTime sDateTime = paramDS.Tables["RQSTDT"].Rows[0]["S_WORK_DATE"].toDateTime();
                DateTime eDateTime = paramDS.Tables["RQSTDT"].Rows[0]["E_WORK_DATE"].toDateTime();

                TimeSpan ts = eDateTime.Subtract(sDateTime);

                int days = ts.TotalDays.toInt() + 1;

                for (int i = 0; i < days; i++)
                {
                    cloneTable.Columns.Add(sDateTime.AddDays(i).toDateString("yyyyMMdd"), typeof(decimal));
                }


                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "DATA_FLAG", 0, typeof(Byte));

                DataTable dtRslt = DPOP.TPOP_MC_ACTUAL_QUERY.TPOP_MC_ACTUAL_QUERY3_2(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable gridTable = cloneTable.Clone();

                foreach (DataRow row in dtRslt.Rows)
                {
                    DataRow[] mcRws = gridTable.Select("MC_GROUP = '" + row["MC_GROUP"].ToString() + "'");

                    if (mcRws.Length == 0)
                    {
                        DataRow newMcRow = gridTable.NewRow();
                        newMcRow["PLT_CODE"] = row["PLT_CODE"];
                        newMcRow["MC_GROUP"] = row["MC_GROUP"];
                        newMcRow["MC_GROUP_NAME"] = row["MC_GROUP_NAME"];
                        gridTable.Rows.Add(newMcRow);
                    }

                    if (!gridTable.Columns.Contains(row["WORK_DATE"].ToString()))
                    {
                        gridTable.Columns.Add(row["WORK_DATE"].ToString(), typeof(decimal));
                    }

                    DataRow[] mcRows = gridTable.Select("MC_GROUP = '" + row["MC_GROUP"].ToString() + "'");

                    if (mcRows.Length == 1)
                    {
                        mcRows[0][row["WORK_DATE"].ToString()] = row["ACT_RATE"];
                    }
                }



                int cnt = gridTable.Rows.Count;

                DataRow newRateRow = gridTable.NewRow();
                newRateRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                newRateRow["MC_GROUP"] = "AVG";
                newRateRow["MC_GROUP_NAME"] = "평균";

                Dictionary<string, int> sumDic = new Dictionary<string, int>();

                foreach (DataRow row in gridTable.Rows)
                {
                    foreach (DataColumn col in gridTable.Columns)
                    {
                        if (col.ColumnName.isNumeric())
                        {
                            if (row[col.ColumnName].ToString() == "")
                            {
                                row[col.ColumnName] = 0;
                            }

                            if (!sumDic.ContainsKey(col.ColumnName))
                            {
                                sumDic.Add(col.ColumnName, 0);
                            }

                            sumDic[col.ColumnName] = sumDic[col.ColumnName] + row[col.ColumnName].toInt();

                            newRateRow[col.ColumnName] = cnt > 0 ? sumDic[col.ColumnName] / cnt : 0;
                        }
                    }
                }

                gridTable.Rows.Add(newRateRow);

                gridTable.TableName = "RSLTDT";

                paramDS.Tables.Add(gridTable);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet REP05A_SER4(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable cloneTable = new DataTable();
                cloneTable.Columns.Add("PLT_CODE", typeof(String));
                cloneTable.Columns.Add("CVND_CODE", typeof(String));
                cloneTable.Columns.Add("CVND_NAME", typeof(String));
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
                cloneTable.Columns.Add("WORK_AVG", typeof(string));

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
                cloneTable.Columns.Add("WORK_AVG_D", typeof(decimal));

                cloneTable.Columns.Add("INDEX", typeof(int));
                cloneTable.Columns.Add("INDEX2", typeof(int));

                DataTable dtRslt = DSHP.TSHP_WORKORDER_QUERY.TSHP_WORKORDER_QUERY40(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable gridTable = cloneTable.Clone();

                DataRow newRow = gridTable.NewRow();
                newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                newRow["CVND_CODE"] = "AVG";
                newRow["CVND_NAME"] = "평균";
                newRow["INDEX"] = 0;
                newRow["INDEX2"] = 0;
                gridTable.Rows.Add(newRow);

                int cnt = 0;
                Dictionary<string, decimal> avgDic = new Dictionary<string, decimal>();
                avgDic.Add("WORK_1", 0);
                avgDic.Add("WORK_2", 0);
                avgDic.Add("WORK_3", 0);
                avgDic.Add("WORK_4", 0);
                avgDic.Add("WORK_5", 0);
                avgDic.Add("WORK_6", 0);
                avgDic.Add("WORK_7", 0);
                avgDic.Add("WORK_8", 0);
                avgDic.Add("WORK_9", 0);
                avgDic.Add("WORK_10", 0);
                avgDic.Add("WORK_11", 0);
                avgDic.Add("WORK_12", 0);
                avgDic.Add("WORK_AVG", 0);

                Dictionary<string, decimal> avgCntDic = new Dictionary<string, decimal>();
                avgCntDic.Add("WORK_1", 0);
                avgCntDic.Add("WORK_2", 0);
                avgCntDic.Add("WORK_3", 0);
                avgCntDic.Add("WORK_4", 0);
                avgCntDic.Add("WORK_5", 0);
                avgCntDic.Add("WORK_6", 0);
                avgCntDic.Add("WORK_7", 0);
                avgCntDic.Add("WORK_8", 0);
                avgCntDic.Add("WORK_9", 0);
                avgCntDic.Add("WORK_10", 0);
                avgCntDic.Add("WORK_11", 0);
                avgCntDic.Add("WORK_12", 0);
                avgCntDic.Add("WORK_AVG", 0);

                int idx = 1;

                foreach (DataRow row in dtRslt.Rows)
                {
                    DataRow[] cvndRow = gridTable.Select("CVND_CODE = '" + row["CVND_CODE"].ToString() + "'");

                    if (cvndRow.Length == 0)
                    {
                        DataRow cvndNewRow = gridTable.NewRow();
                        cvndNewRow["PLT_CODE"] = row["PLT_CODE"];
                        cvndNewRow["CVND_CODE"] = row["CVND_CODE"];
                        cvndNewRow["CVND_NAME"] = row["CVND_NAME"];
                        cvndNewRow["WORK_1"] = "0.0일";
                        cvndNewRow["WORK_2"] = "0.0일";
                        cvndNewRow["WORK_3"] = "0.0일";
                        cvndNewRow["WORK_4"] = "0.0일";
                        cvndNewRow["WORK_5"] = "0.0일";
                        cvndNewRow["WORK_6"] = "0.0일";
                        cvndNewRow["WORK_7"] = "0.0일";
                        cvndNewRow["WORK_8"] = "0.0일";
                        cvndNewRow["WORK_9"] = "0.0일";
                        cvndNewRow["WORK_10"] = "0.0일";
                        cvndNewRow["WORK_11"] = "0.0일";
                        cvndNewRow["WORK_12"] = "0.0일";
                        cvndNewRow["WORK_AVG"] = "0.0일";
                                                 
                        cvndNewRow["WORK_1_D"] = 0.0;
                        cvndNewRow["WORK_2_D"] = 0.0;
                        cvndNewRow["WORK_3_D"] = 0.0;
                        cvndNewRow["WORK_4_D"] = 0.0;
                        cvndNewRow["WORK_5_D"] = 0.0;
                        cvndNewRow["WORK_6_D"] = 0.0;
                        cvndNewRow["WORK_7_D"] = 0.0;
                        cvndNewRow["WORK_8_D"] = 0.0;
                        cvndNewRow["WORK_9_D"] = 0.0;
                        cvndNewRow["WORK_10_D"] = 0.0;
                        cvndNewRow["WORK_11_D"] = 0.0;
                        cvndNewRow["WORK_12_D"] = 0.0;
                        cvndNewRow["WORK_AVG_D"] = 0.0;

                        cvndNewRow["INDEX"] = 1;
                        cvndNewRow["INDEX2"] = idx;
                        idx++;

                        gridTable.Rows.Add(cvndNewRow);

                        cnt++;
                    }

                    DataRow[] cRow = gridTable.Select("CVND_CODE = '" + row["CVND_CODE"].ToString() + "'");

                    if (cRow.Length > 0)
                    {
                        if (row["ORD_MONTH"].ToString().Substring(4, 2) == "01")
                        {
                            cRow[0]["WORK_1_D"] = cRow[0]["WORK_1_D"].toDecimal() + row["LT_AVG"].toDecimal();
                            cRow[0]["WORK_1"] = string.Format("{0:n1}일", cRow[0]["WORK_1_D"]);

                            if (row["LT_AVG"].toDecimal() > 0)
                            {
                                avgDic["WORK_1"] = avgDic["WORK_1"] + row["LT_AVG"].toDecimal();
                                avgCntDic["WORK_1"] = avgCntDic["WORK_1"] + 1;
                            }
                        }
                        if (row["ORD_MONTH"].ToString().Substring(4, 2) == "02")
                        {
                            //cRow[0]["WORK_2"] = string.Format("{0:n1}일", cRow[0]["WORK_2"].toDecimal() + row["LT_AVG"].toDecimal());
                            cRow[0]["WORK_2_D"] = cRow[0]["WORK_2_D"].toDecimal() + row["LT_AVG"].toDecimal();
                            cRow[0]["WORK_2"] = string.Format("{0:n1}일", cRow[0]["WORK_2_D"]);
                            

                            if (row["LT_AVG"].toDecimal() > 0)
                            {
                                avgDic["WORK_2"] = avgDic["WORK_2"] + row["LT_AVG"].toDecimal();
                                avgCntDic["WORK_2"] = avgCntDic["WORK_2"] + 1;
                            }

                        }
                        if (row["ORD_MONTH"].ToString().Substring(4, 2) == "03")
                        {
                            //cRow[0]["WORK_3"] = string.Format("{0:n1}일", cRow[0]["WORK_3"].toDecimal() + row["LT_AVG"].toDecimal());
                            cRow[0]["WORK_3_D"] = cRow[0]["WORK_3_D"].toDecimal() + row["LT_AVG"].toDecimal();
                            cRow[0]["WORK_3"] = string.Format("{0:n1}일", cRow[0]["WORK_3_D"]);

                            if (row["LT_AVG"].toDecimal() > 0)
                            {
                                avgDic["WORK_3"] = avgDic["WORK_3"] + row["LT_AVG"].toDecimal();
                                avgCntDic["WORK_3"] = avgCntDic["WORK_3"] + 1;
                            }
                        }
                        if (row["ORD_MONTH"].ToString().Substring(4, 2) == "04")
                        {
                            //cRow[0]["WORK_4"] = string.Format("{0:n1}일", cRow[0]["WORK_4"].toDecimal() + row["LT_AVG"].toDecimal());
                            cRow[0]["WORK_4_D"] = cRow[0]["WORK_4_D"].toDecimal() + row["LT_AVG"].toDecimal();
                            cRow[0]["WORK_4"] = string.Format("{0:n1}일", cRow[0]["WORK_4_D"]);

                            if (row["LT_AVG"].toDecimal() > 0)
                            {
                                avgDic["WORK_4"] = avgDic["WORK_4"] + row["LT_AVG"].toDecimal();
                                avgCntDic["WORK_4"] = avgCntDic["WORK_4"] + 1;
                            }
                        }
                        if (row["ORD_MONTH"].ToString().Substring(4, 2) == "05")
                        {
                            //cRow[0]["WORK_5"] = string.Format("{0:n1}일", cRow[0]["WORK_5"].toDecimal() + row["LT_AVG"].toDecimal());
                            cRow[0]["WORK_5_D"] = cRow[0]["WORK_5_D"].toDecimal() + row["LT_AVG"].toDecimal();
                            cRow[0]["WORK_5"] = string.Format("{0:n1}일", cRow[0]["WORK_5_D"]);

                            if (row["LT_AVG"].toDecimal() > 0)
                            {
                                avgDic["WORK_5"] = avgDic["WORK_5"] + row["LT_AVG"].toDecimal();
                                avgCntDic["WORK_5"] = avgCntDic["WORK_5"] + 1;
                            }
                        }
                        if (row["ORD_MONTH"].ToString().Substring(4, 2) == "06")
                        {
                            //cRow[0]["WORK_6"] = string.Format("{0:n1}일", cRow[0]["WORK_6"].toDecimal() + row["LT_AVG"].toDecimal());
                            cRow[0]["WORK_6_D"] = cRow[0]["WORK_6_D"].toDecimal() + row["LT_AVG"].toDecimal();
                            cRow[0]["WORK_6"] = string.Format("{0:n1}일", cRow[0]["WORK_6_D"]);

                            if (row["LT_AVG"].toDecimal() > 0)
                            {
                                avgDic["WORK_6"] = avgDic["WORK_6"] + row["LT_AVG"].toDecimal();
                                avgCntDic["WORK_6"] = avgCntDic["WORK_6"] + 1;
                            }
                        }

                        if (row["ORD_MONTH"].ToString().Substring(4, 2) == "07")
                        {
                            //cRow[0]["WORK_7"] = string.Format("{0:n1}일", cRow[0]["WORK_7"].toDecimal() + row["LT_AVG"].toDecimal());
                            cRow[0]["WORK_7_D"] = cRow[0]["WORK_7_D"].toDecimal() + row["LT_AVG"].toDecimal();
                            cRow[0]["WORK_7"] = string.Format("{0:n1}일", cRow[0]["WORK_7_D"]);

                            if (row["LT_AVG"].toDecimal() > 0)
                            {
                                avgDic["WORK_7"] = avgDic["WORK_7"] + row["LT_AVG"].toDecimal();
                                avgCntDic["WORK_7"] = avgCntDic["WORK_7"] + 1;
                            }
                        }
                        if (row["ORD_MONTH"].ToString().Substring(4, 2) == "08")
                        {
                            //cRow[0]["WORK_8"] = string.Format("{0:n1}일", cRow[0]["WORK_8"].toDecimal() + row["LT_AVG"].toDecimal());
                            cRow[0]["WORK_8_D"] = cRow[0]["WORK_8_D"].toDecimal() + row["LT_AVG"].toDecimal();
                            cRow[0]["WORK_8"] = string.Format("{0:n1}일", cRow[0]["WORK_8_D"]);

                            if (row["LT_AVG"].toDecimal() > 0)
                            {
                                avgDic["WORK_8"] = avgDic["WORK_8"] + row["LT_AVG"].toDecimal();
                                avgCntDic["WORK_8"] = avgCntDic["WORK_8"] + 1;
                            }
                        }
                        if (row["ORD_MONTH"].ToString().Substring(4, 2) == "09")
                        {
                            //cRow[0]["WORK_9"] = string.Format("{0:n1}일", cRow[0]["WORK_9"].toDecimal() + row["LT_AVG"].toDecimal());
                            cRow[0]["WORK_9_D"] = cRow[0]["WORK_9_D"].toDecimal() + row["LT_AVG"].toDecimal();
                            cRow[0]["WORK_9"] = string.Format("{0:n1}일", cRow[0]["WORK_9_D"]);

                            if (row["LT_AVG"].toDecimal() > 0)
                            {
                                avgDic["WORK_9"] = avgDic["WORK_9"] + row["LT_AVG"].toDecimal();
                                avgCntDic["WORK_9"] = avgCntDic["WORK_9"] + 1;
                            }
                        }
                        if (row["ORD_MONTH"].ToString().Substring(4, 2) == "10")
                        {
                            //cRow[0]["WORK_10"] = string.Format("{0:n1}일", cRow[0]["WORK_10"].toDecimal() + row["LT_AVG"].toDecimal());
                            cRow[0]["WORK_10_D"] = cRow[0]["WORK_10_D"].toDecimal() + row["LT_AVG"].toDecimal();
                            cRow[0]["WORK_10"] = string.Format("{0:n1}일", cRow[0]["WORK_10_D"]);

                            if (row["LT_AVG"].toDecimal() > 0)
                            {
                                avgDic["WORK_10"] = avgDic["WORK_10"] + row["LT_AVG"].toDecimal();
                                avgCntDic["WORK_10"] = avgCntDic["WORK_10"] + 1;
                            }
                        }
                        if (row["ORD_MONTH"].ToString().Substring(4, 2) == "11")
                        {
                            //cRow[0]["WORK_11"] = string.Format("{0:n1}일", cRow[0]["WORK_11"].toDecimal() + row["LT_AVG"].toDecimal());
                            cRow[0]["WORK_11_D"] = cRow[0]["WORK_11_D"].toDecimal() + row["LT_AVG"].toDecimal();
                            cRow[0]["WORK_11"] = string.Format("{0:n1}일", cRow[0]["WORK_11_D"]);

                            if (row["LT_AVG"].toDecimal() > 0)
                            {
                                avgDic["WORK_11"] = avgDic["WORK_11"] + row["LT_AVG"].toDecimal();
                                avgCntDic["WORK_11"] = avgCntDic["WORK_11"] + 1;
                            }
                        }
                        if (row["ORD_MONTH"].ToString().Substring(4, 2) == "12")
                        {
                            //cRow[0]["WORK_12"] = string.Format("{0:n1}일", cRow[0]["WORK_12"].toDecimal() + row["LT_AVG"].toDecimal());
                            cRow[0]["WORK_12_D"] = cRow[0]["WORK_12_D"].toDecimal() + row["LT_AVG"].toDecimal();
                            cRow[0]["WORK_12"] = string.Format("{0:n1}일", cRow[0]["WORK_12_D"]);

                            if (row["LT_AVG"].toDecimal() > 0)
                            {
                                avgDic["WORK_12"] = avgDic["WORK_12"] + row["LT_AVG"].toDecimal();
                                avgCntDic["WORK_12"] = avgCntDic["WORK_12"] + 1;
                            }
                        }
                    

                        double tSum = cRow[0]["WORK_1_D"].toDouble() + cRow[0]["WORK_2_D"].toDouble() + cRow[0]["WORK_3_D"].toDouble() + cRow[0]["WORK_4_D"].toDouble()
                                    + cRow[0]["WORK_5_D"].toDouble() + cRow[0]["WORK_6_D"].toDouble() + cRow[0]["WORK_7_D"].toDouble() + cRow[0]["WORK_8_D"].toDouble()
                                    + cRow[0]["WORK_9_D"].toDouble() + cRow[0]["WORK_10_D"].toDouble() + cRow[0]["WORK_11_D"].toDouble() + cRow[0]["WORK_12_D"].toDouble();

                        cRow[0]["WORK_AVG"] = string.Format("{0:n1}일", tSum / 12.0);
                    }
                }

                DataRow[] avgRow = gridTable.Select("CVND_CODE = 'AVG'");

                decimal dWork1 = 0, dWork2 = 0, dWork3 = 0, dWork4 = 0, dWork5 = 0, dWork6 = 0
                        ,dWork7 = 0, dWork8 = 0, dWork9 = 0,  dWork10 = 0, dWork11 = 0, dWork12 = 0;

                if (avgCntDic["WORK_1"] > 0) { dWork1 = avgDic["WORK_1"] / avgCntDic["WORK_1"]; }
                if (avgCntDic["WORK_2"] > 0) { dWork2 = avgDic["WORK_2"] / avgCntDic["WORK_2"]; }
                if (avgCntDic["WORK_3"] > 0) { dWork3 = avgDic["WORK_3"] / avgCntDic["WORK_3"]; }
                if (avgCntDic["WORK_4"] > 0) { dWork4 = avgDic["WORK_4"] / avgCntDic["WORK_4"]; }
                if (avgCntDic["WORK_5"] > 0) { dWork5 = avgDic["WORK_5"] / avgCntDic["WORK_5"]; }
                if (avgCntDic["WORK_6"] > 0) { dWork6 = avgDic["WORK_6"] / avgCntDic["WORK_6"]; }
                if (avgCntDic["WORK_7"] > 0) { dWork7 = avgDic["WORK_7"] / avgCntDic["WORK_7"]; }
                if (avgCntDic["WORK_8"] > 0) { dWork8 = avgDic["WORK_8"] / avgCntDic["WORK_8"]; }
                if (avgCntDic["WORK_9"] > 0) { dWork9 = avgDic["WORK_9"] / avgCntDic["WORK_9"]; }
                if (avgCntDic["WORK_10"] > 0) { dWork10 = avgDic["WORK_10"] / avgCntDic["WORK_10"]; }
                if (avgCntDic["WORK_11"] > 0) { dWork11 = avgDic["WORK_11"] / avgCntDic["WORK_11"]; }
                if (avgCntDic["WORK_12"] > 0) { dWork12 = avgDic["WORK_12"] / avgCntDic["WORK_12"]; }


                avgRow[0]["WORK_1"] = string.Format("{0:n1}일", dWork1);
                avgRow[0]["WORK_2"] = string.Format("{0:n1}일", dWork2);
                avgRow[0]["WORK_3"] = string.Format("{0:n1}일", dWork3);
                avgRow[0]["WORK_4"] = string.Format("{0:n1}일", dWork4);
                avgRow[0]["WORK_5"] = string.Format("{0:n1}일", dWork5);
                avgRow[0]["WORK_6"] = string.Format("{0:n1}일", dWork6);
                avgRow[0]["WORK_7"] = string.Format("{0:n1}일", dWork7);
                avgRow[0]["WORK_8"] = string.Format("{0:n1}일", dWork8);
                avgRow[0]["WORK_9"] = string.Format("{0:n1}일", dWork9);
                avgRow[0]["WORK_10"] = string.Format("{0:n1}일", dWork10);
                avgRow[0]["WORK_11"] = string.Format("{0:n1}일", dWork11);
                avgRow[0]["WORK_12"] = string.Format("{0:n1}일", dWork12);

                avgRow[0]["WORK_1_D"] = dWork1;
                avgRow[0]["WORK_2_D"] = dWork2;
                avgRow[0]["WORK_3_D"] = dWork3;
                avgRow[0]["WORK_4_D"] = dWork4;
                avgRow[0]["WORK_5_D"] = dWork5;
                avgRow[0]["WORK_6_D"] = dWork6;
                avgRow[0]["WORK_7_D"] = dWork7;
                avgRow[0]["WORK_8_D"] = dWork8;
                avgRow[0]["WORK_9_D"] = dWork9;
                avgRow[0]["WORK_10_D"] = dWork10;
                avgRow[0]["WORK_11_D"] = dWork11;
                avgRow[0]["WORK_12_D"] = dWork12;

                double aSum = avgRow[0]["WORK_1_D"].toDouble() + avgRow[0]["WORK_2_D"].toDouble() + avgRow[0]["WORK_3_D"].toDouble() + avgRow[0]["WORK_4_D"].toDouble()
                            + avgRow[0]["WORK_5_D"].toDouble() + avgRow[0]["WORK_6_D"].toDouble() + avgRow[0]["WORK_7_D"].toDouble() + avgRow[0]["WORK_8_D"].toDouble()
                            + avgRow[0]["WORK_9_D"].toDouble() + avgRow[0]["WORK_10_D"].toDouble() + avgRow[0]["WORK_11_D"].toDouble() + avgRow[0]["WORK_12_D"].toDouble();

                avgRow[0]["WORK_AVG"] = string.Format("{0:n1}일", aSum / 12.0);
                avgRow[0]["WORK_AVG_D"] = aSum / 12.0;

                gridTable.TableName = "RSLTDT";
                paramDS.Tables.Add(gridTable);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet REP05A_SER5(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable cloneTable = new DataTable();
                cloneTable.Columns.Add("PLT_CODE", typeof(String));
                cloneTable.Columns.Add("MC_CODE", typeof(String));
                cloneTable.Columns.Add("MC_NAME", typeof(String));
                cloneTable.Columns.Add("FLAG", typeof(String));
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

                DataTable dtRslt = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY5(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable dtRslt2 = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY5_2(paramDS.Tables["RQSTDT"], bizExecute); 

                DataTable gridTable = cloneTable.Clone();

                DataRow newRow = gridTable.NewRow();
                newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                newRow["MC_CODE"] = "MC";
                newRow["MC_NAME"] = "MCT 실적";
                newRow["FLAG"] = "MC";

                newRow["WORK_1"] = 0;
                newRow["WORK_2"] = 0;
                newRow["WORK_3"] = 0;
                newRow["WORK_4"] = 0;
                newRow["WORK_5"] = 0;
                newRow["WORK_6"] = 0;
                newRow["WORK_7"] = 0;
                newRow["WORK_8"] = 0;
                newRow["WORK_9"] = 00;
                newRow["WORK_10"] = 0;
                newRow["WORK_11"] = 0;
                newRow["WORK_12"] = 0;
                newRow["WORK_SUM"] = 0;

                gridTable.Rows.Add(newRow);

                DataRow[] rows = gridTable.Select("FLAG = 'MC'");

                foreach (DataRow row in dtRslt.Rows)
                {
                    if (row["ACT_END_TIME"].ToString().Substring(4, 2) == "01") { rows[0]["WORK_1"] = rows[0]["WORK_1"].toDecimal() + row["OK_QTY"].toDecimal(); }
                    if (row["ACT_END_TIME"].ToString().Substring(4, 2) == "02") { rows[0]["WORK_2"] = rows[0]["WORK_2"].toDecimal() + row["OK_QTY"].toDecimal(); }
                    if (row["ACT_END_TIME"].ToString().Substring(4, 2) == "03") { rows[0]["WORK_3"] = rows[0]["WORK_3"].toDecimal() + row["OK_QTY"].toDecimal(); }
                    if (row["ACT_END_TIME"].ToString().Substring(4, 2) == "04") { rows[0]["WORK_4"] = rows[0]["WORK_4"].toDecimal() + row["OK_QTY"].toDecimal(); }
                    if (row["ACT_END_TIME"].ToString().Substring(4, 2) == "05") { rows[0]["WORK_5"] = rows[0]["WORK_5"].toDecimal() + row["OK_QTY"].toDecimal(); }
                    if (row["ACT_END_TIME"].ToString().Substring(4, 2) == "06") { rows[0]["WORK_6"] = rows[0]["WORK_6"].toDecimal() + row["OK_QTY"].toDecimal(); }
                    if (row["ACT_END_TIME"].ToString().Substring(4, 2) == "07") { rows[0]["WORK_7"] = rows[0]["WORK_7"].toDecimal() + row["OK_QTY"].toDecimal(); }
                    if (row["ACT_END_TIME"].ToString().Substring(4, 2) == "08") { rows[0]["WORK_8"] = rows[0]["WORK_8"].toDecimal() + row["OK_QTY"].toDecimal(); }
                    if (row["ACT_END_TIME"].ToString().Substring(4, 2) == "09") { rows[0]["WORK_9"] = rows[0]["WORK_9"].toDecimal() + row["OK_QTY"].toDecimal(); }
                    if (row["ACT_END_TIME"].ToString().Substring(4, 2) == "10") { rows[0]["WORK_10"] = rows[0]["WORK_10"].toDecimal() + row["OK_QTY"].toDecimal(); }
                    if (row["ACT_END_TIME"].ToString().Substring(4, 2) == "11") { rows[0]["WORK_11"] = rows[0]["WORK_11"].toDecimal() + row["OK_QTY"].toDecimal(); }
                    if (row["ACT_END_TIME"].ToString().Substring(4, 2) == "12") { rows[0]["WORK_12"] = rows[0]["WORK_12"].toDecimal() + row["OK_QTY"].toDecimal(); }

                    double aSum = rows[0]["WORK_1"].toDouble() + rows[0]["WORK_2"].toDouble() + rows[0]["WORK_3"].toDouble() + rows[0]["WORK_4"].toDouble()
                                + rows[0]["WORK_5"].toDouble() + rows[0]["WORK_6"].toDouble() + rows[0]["WORK_7"].toDouble() + rows[0]["WORK_8"].toDouble()
                                + rows[0]["WORK_9"].toDouble() + rows[0]["WORK_10"].toDouble() + rows[0]["WORK_11"].toDouble() + rows[0]["WORK_12"].toDouble();

                    rows[0]["WORK_SUM"] = aSum;

                }


                gridTable.TableName = "RSLTDT";
                paramDS.Tables.Add(gridTable);

                dtRslt2.TableName = "RSLTDT2";
                paramDS.Tables.Add(dtRslt2);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }


        public static DataSet REP05A_SER6(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable cloneTable = new DataTable();
                cloneTable.Columns.Add("PLT_CODE", typeof(String));
                cloneTable.Columns.Add("INS_CODE", typeof(String));
                cloneTable.Columns.Add("INS_NAME", typeof(String));
                cloneTable.Columns.Add("FLAG", typeof(String));
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

                DataTable dtRslt = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY6(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable dtRslt2 = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY6_2(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable gridTable = cloneTable.Clone();

                DataRow newRow = gridTable.NewRow();
                newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                newRow["INS_CODE"] = "INS";
                newRow["INS_NAME"] = "중간검사 실적";
                newRow["FLAG"] = "INS";

                newRow["WORK_1"] = 0;
                newRow["WORK_2"] = 0;
                newRow["WORK_3"] = 0;
                newRow["WORK_4"] = 0;
                newRow["WORK_5"] = 0;
                newRow["WORK_6"] = 0;
                newRow["WORK_7"] = 0;
                newRow["WORK_8"] = 0;
                newRow["WORK_9"] = 00;
                newRow["WORK_10"] = 0;
                newRow["WORK_11"] = 0;
                newRow["WORK_12"] = 0;
                newRow["WORK_SUM"] = 0;

                gridTable.Rows.Add(newRow);

                DataRow[] rows = gridTable.Select("FLAG = 'INS'");

                foreach (DataRow row in dtRslt.Rows)
                {
                    if (row["ACT_END_TIME"].ToString().Substring(4, 2) == "01") { rows[0]["WORK_1"] = rows[0]["WORK_1"].toDecimal() + row["ACT_QTY"].toDecimal(); }
                    if (row["ACT_END_TIME"].ToString().Substring(4, 2) == "02") { rows[0]["WORK_2"] = rows[0]["WORK_2"].toDecimal() + row["ACT_QTY"].toDecimal(); }
                    if (row["ACT_END_TIME"].ToString().Substring(4, 2) == "03") { rows[0]["WORK_3"] = rows[0]["WORK_3"].toDecimal() + row["ACT_QTY"].toDecimal(); }
                    if (row["ACT_END_TIME"].ToString().Substring(4, 2) == "04") { rows[0]["WORK_4"] = rows[0]["WORK_4"].toDecimal() + row["ACT_QTY"].toDecimal(); }
                    if (row["ACT_END_TIME"].ToString().Substring(4, 2) == "05") { rows[0]["WORK_5"] = rows[0]["WORK_5"].toDecimal() + row["ACT_QTY"].toDecimal(); }
                    if (row["ACT_END_TIME"].ToString().Substring(4, 2) == "06") { rows[0]["WORK_6"] = rows[0]["WORK_6"].toDecimal() + row["ACT_QTY"].toDecimal(); }
                    if (row["ACT_END_TIME"].ToString().Substring(4, 2) == "07") { rows[0]["WORK_7"] = rows[0]["WORK_7"].toDecimal() + row["ACT_QTY"].toDecimal(); }
                    if (row["ACT_END_TIME"].ToString().Substring(4, 2) == "08") { rows[0]["WORK_8"] = rows[0]["WORK_8"].toDecimal() + row["ACT_QTY"].toDecimal(); }
                    if (row["ACT_END_TIME"].ToString().Substring(4, 2) == "09") { rows[0]["WORK_9"] = rows[0]["WORK_9"].toDecimal() + row["ACT_QTY"].toDecimal(); }
                    if (row["ACT_END_TIME"].ToString().Substring(4, 2) == "10") { rows[0]["WORK_10"] = rows[0]["WORK_10"].toDecimal() + row["ACT_QTY"].toDecimal(); }
                    if (row["ACT_END_TIME"].ToString().Substring(4, 2) == "11") { rows[0]["WORK_11"] = rows[0]["WORK_11"].toDecimal() + row["ACT_QTY"].toDecimal(); }
                    if (row["ACT_END_TIME"].ToString().Substring(4, 2) == "12") { rows[0]["WORK_12"] = rows[0]["WORK_12"].toDecimal() + row["ACT_QTY"].toDecimal(); }

                    double aSum = rows[0]["WORK_1"].toDouble() + rows[0]["WORK_2"].toDouble() + rows[0]["WORK_3"].toDouble() + rows[0]["WORK_4"].toDouble()
                                + rows[0]["WORK_5"].toDouble() + rows[0]["WORK_6"].toDouble() + rows[0]["WORK_7"].toDouble() + rows[0]["WORK_8"].toDouble()
                                + rows[0]["WORK_9"].toDouble() + rows[0]["WORK_10"].toDouble() + rows[0]["WORK_11"].toDouble() + rows[0]["WORK_12"].toDouble();

                    rows[0]["WORK_SUM"] = aSum;

                }


                gridTable.TableName = "RSLTDT";
                paramDS.Tables.Add(gridTable);

                dtRslt2.TableName = "RSLTDT2";
                paramDS.Tables.Add(dtRslt2);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet REP05A_SER7(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable cloneTable = new DataTable();
                cloneTable.Columns.Add("PLT_CODE", typeof(String));
                cloneTable.Columns.Add("TYPE_CODE", typeof(String));
                cloneTable.Columns.Add("TYPE_NAME", typeof(String));
                cloneTable.Columns.Add("FLAG", typeof(String));
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

                DataTable dtRslt = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY7(paramDS.Tables["RQSTDT"], bizExecute);

                DataRow[] mctRows = dtRslt.Select("MCT_ACT_QTY IS NOT NULL");

                DataTable gridTable = cloneTable.Clone();
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
                    newRow["WORK_1"] = mctRows.CopyToDataTable().Compute("SUM(MCT_ACT_QTY)", "MCT_ACT_END_MONTH = '" + paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + "01' AND PROC_CODE = 'P-04'").toInt();
                    newRow["WORK_2"] = mctRows.CopyToDataTable().Compute("SUM(MCT_ACT_QTY)", "MCT_ACT_END_MONTH = '" + paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + "02' AND PROC_CODE = 'P-04'").toInt();
                    newRow["WORK_3"] = mctRows.CopyToDataTable().Compute("SUM(MCT_ACT_QTY)", "MCT_ACT_END_MONTH = '" + paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + "03' AND PROC_CODE = 'P-04'").toInt();
                    newRow["WORK_4"] = mctRows.CopyToDataTable().Compute("SUM(MCT_ACT_QTY)", "MCT_ACT_END_MONTH = '" + paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + "04' AND PROC_CODE = 'P-04'").toInt();
                    newRow["WORK_5"] = mctRows.CopyToDataTable().Compute("SUM(MCT_ACT_QTY)", "MCT_ACT_END_MONTH = '" + paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + "05' AND PROC_CODE = 'P-04'").toInt();
                    newRow["WORK_6"] = mctRows.CopyToDataTable().Compute("SUM(MCT_ACT_QTY)", "MCT_ACT_END_MONTH = '" + paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + "06' AND PROC_CODE = 'P-04'").toInt();
                    newRow["WORK_7"] = mctRows.CopyToDataTable().Compute("SUM(MCT_ACT_QTY)", "MCT_ACT_END_MONTH = '" + paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + "07' AND PROC_CODE = 'P-04'").toInt();
                    newRow["WORK_8"] = mctRows.CopyToDataTable().Compute("SUM(MCT_ACT_QTY)", "MCT_ACT_END_MONTH = '" + paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + "08' AND PROC_CODE = 'P-04'").toInt();
                    newRow["WORK_9"] = mctRows.CopyToDataTable().Compute("SUM(MCT_ACT_QTY)", "MCT_ACT_END_MONTH = '" + paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + "09' AND PROC_CODE = 'P-04'").toInt();
                    newRow["WORK_10"] = mctRows.CopyToDataTable().Compute("SUM(MCT_ACT_QTY)", "MCT_ACT_END_MONTH = '" + paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + "10' AND PROC_CODE = 'P-04'").toInt();
                    newRow["WORK_11"] = mctRows.CopyToDataTable().Compute("SUM(MCT_ACT_QTY)", "MCT_ACT_END_MONTH = '" + paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + "11' AND PROC_CODE = 'P-04'").toInt();
                    newRow["WORK_12"] = mctRows.CopyToDataTable().Compute("SUM(MCT_ACT_QTY)", "MCT_ACT_END_MONTH = '" + paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + "12' AND PROC_CODE = 'P-04'").toInt();

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
                    newRow["WORK_1"] = mctRows.CopyToDataTable().Compute("SUM(OUT_ACT_QTY)", "MCT_ACT_END_MONTH = '" + paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + "01' AND PROC_CODE = 'P14'").toInt();
                    newRow["WORK_2"] = mctRows.CopyToDataTable().Compute("SUM(OUT_ACT_QTY)", "MCT_ACT_END_MONTH = '" + paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + "02' AND PROC_CODE = 'P14'").toInt();
                    newRow["WORK_3"] = mctRows.CopyToDataTable().Compute("SUM(OUT_ACT_QTY)", "MCT_ACT_END_MONTH = '" + paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + "03' AND PROC_CODE = 'P14'").toInt();
                    newRow["WORK_4"] = mctRows.CopyToDataTable().Compute("SUM(OUT_ACT_QTY)", "MCT_ACT_END_MONTH = '" + paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + "04' AND PROC_CODE = 'P14'").toInt();
                    newRow["WORK_5"] = mctRows.CopyToDataTable().Compute("SUM(OUT_ACT_QTY)", "MCT_ACT_END_MONTH = '" + paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + "05' AND PROC_CODE = 'P14'").toInt();
                    newRow["WORK_6"] = mctRows.CopyToDataTable().Compute("SUM(OUT_ACT_QTY)", "MCT_ACT_END_MONTH = '" + paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + "06' AND PROC_CODE = 'P14'").toInt();
                    newRow["WORK_7"] = mctRows.CopyToDataTable().Compute("SUM(OUT_ACT_QTY)", "MCT_ACT_END_MONTH = '" + paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + "07' AND PROC_CODE = 'P14'").toInt();
                    newRow["WORK_8"] = mctRows.CopyToDataTable().Compute("SUM(OUT_ACT_QTY)", "MCT_ACT_END_MONTH = '" + paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + "08' AND PROC_CODE = 'P14'").toInt();
                    newRow["WORK_9"] = mctRows.CopyToDataTable().Compute("SUM(OUT_ACT_QTY)", "MCT_ACT_END_MONTH = '" + paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + "09' AND PROC_CODE = 'P14'").toInt();
                    newRow["WORK_10"] = mctRows.CopyToDataTable().Compute("SUM(OUT_ACT_QTY)", "MCT_ACT_END_MONTH = '" + paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + "10' AND PROC_CODE = 'P14'").toInt();
                    newRow["WORK_11"] = mctRows.CopyToDataTable().Compute("SUM(OUT_ACT_QTY)", "MCT_ACT_END_MONTH = '" + paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + "11' AND PROC_CODE = 'P14'").toInt();
                    newRow["WORK_12"] = mctRows.CopyToDataTable().Compute("SUM(OUT_ACT_QTY)", "MCT_ACT_END_MONTH = '" + paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + "12' AND PROC_CODE = 'P14'").toInt();

                    double aSum = newRow["WORK_1"].toDouble() + newRow["WORK_2"].toDouble() + newRow["WORK_3"].toDouble() + newRow["WORK_4"].toDouble()
                                + newRow["WORK_5"].toDouble() + newRow["WORK_6"].toDouble() + newRow["WORK_7"].toDouble() + newRow["WORK_8"].toDouble()
                                + newRow["WORK_9"].toDouble() + newRow["WORK_10"].toDouble() + newRow["WORK_11"].toDouble() + newRow["WORK_12"].toDouble();

                    newRow["WORK_SUM"] = aSum;
                }


                gridTable.Rows.Add(newRow);



                DataRow[] insRows = dtRslt.Select("INS_ACT_QTY IS NOT NULL");

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
                    newRow2["WORK_1"] = insRows.CopyToDataTable().Compute("SUM(INS_ACT_QTY)", "INS_ACT_END_MONTH = '" + paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + "01'").toInt();
                    newRow2["WORK_2"] = insRows.CopyToDataTable().Compute("SUM(INS_ACT_QTY)", "INS_ACT_END_MONTH = '" + paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + "02'").toInt();
                    newRow2["WORK_3"] = insRows.CopyToDataTable().Compute("SUM(INS_ACT_QTY)", "INS_ACT_END_MONTH = '" + paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + "03'").toInt();
                    newRow2["WORK_4"] = insRows.CopyToDataTable().Compute("SUM(INS_ACT_QTY)", "INS_ACT_END_MONTH = '" + paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + "04'").toInt();
                    newRow2["WORK_5"] = insRows.CopyToDataTable().Compute("SUM(INS_ACT_QTY)", "INS_ACT_END_MONTH = '" + paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + "05'").toInt();
                    newRow2["WORK_6"] = insRows.CopyToDataTable().Compute("SUM(INS_ACT_QTY)", "INS_ACT_END_MONTH = '" + paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + "06'").toInt();
                    newRow2["WORK_7"] = insRows.CopyToDataTable().Compute("SUM(INS_ACT_QTY)", "INS_ACT_END_MONTH = '" + paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + "07'").toInt();
                    newRow2["WORK_8"] = insRows.CopyToDataTable().Compute("SUM(INS_ACT_QTY)", "INS_ACT_END_MONTH = '" + paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + "08'").toInt();
                    newRow2["WORK_9"] = insRows.CopyToDataTable().Compute("SUM(INS_ACT_QTY)", "INS_ACT_END_MONTH = '" + paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + "09'").toInt();
                    newRow2["WORK_10"] = insRows.CopyToDataTable().Compute("SUM(INS_ACT_QTY)", "INS_ACT_END_MONTH = '" + paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + "10'").toInt();
                    newRow2["WORK_11"] = insRows.CopyToDataTable().Compute("SUM(INS_ACT_QTY)", "INS_ACT_END_MONTH = '" + paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + "11'").toInt();
                    newRow2["WORK_12"] = insRows.CopyToDataTable().Compute("SUM(INS_ACT_QTY)", "INS_ACT_END_MONTH = '" + paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].ToString() + "12'").toInt();

                    double aSum = newRow2["WORK_1"].toDouble() + newRow2["WORK_2"].toDouble() + newRow2["WORK_3"].toDouble() + newRow2["WORK_4"].toDouble()
                                + newRow2["WORK_5"].toDouble() + newRow2["WORK_6"].toDouble() + newRow2["WORK_7"].toDouble() + newRow2["WORK_8"].toDouble()
                                + newRow2["WORK_9"].toDouble() + newRow2["WORK_10"].toDouble() + newRow2["WORK_11"].toDouble() + newRow2["WORK_12"].toDouble();

                    newRow2["WORK_SUM"] = aSum;
                }


                gridTable.Rows.Add(newRow2);



                //DataRow newRow3 = gridTable.NewRow();
                //newRow3["PLT_CODE"] = ConnInfo.PLT_CODE;
                //newRow3["TYPE_CODE"] = "COMPARE";
                //newRow3["TYPE_NAME"] = "차이";
                //newRow3["FLAG"] = "COMPARE";

                //newRow3["WORK_1"] = 0;
                //newRow3["WORK_2"] = 0;
                //newRow3["WORK_3"] = 0;
                //newRow3["WORK_4"] = 0;
                //newRow3["WORK_5"] = 0;
                //newRow3["WORK_6"] = 0;
                //newRow3["WORK_7"] = 0;
                //newRow3["WORK_8"] = 0;
                //newRow3["WORK_9"] = 0;
                //newRow3["WORK_10"] = 0;
                //newRow3["WORK_11"] = 0;
                //newRow3["WORK_12"] = 0;
                //newRow3["WORK_SUM"] = 0;

                //DataRow[] rsltInsRows = gridTable.Select("FLAG = 'INS'");
                //DataRow[] rsltMctRows = gridTable.Select("FLAG = 'MCT'");

                //newRow3["WORK_1"] = rsltInsRows[0]["WORK_1"].toInt() - rsltMctRows[0]["WORK_1"].toInt();
                //newRow3["WORK_2"] = rsltInsRows[0]["WORK_2"].toInt() - rsltMctRows[0]["WORK_2"].toInt();
                //newRow3["WORK_3"] = rsltInsRows[0]["WORK_3"].toInt() - rsltMctRows[0]["WORK_3"].toInt();
                //newRow3["WORK_4"] = rsltInsRows[0]["WORK_4"].toInt() - rsltMctRows[0]["WORK_4"].toInt();
                //newRow3["WORK_5"] = rsltInsRows[0]["WORK_5"].toInt() - rsltMctRows[0]["WORK_5"].toInt();
                //newRow3["WORK_6"] = rsltInsRows[0]["WORK_6"].toInt() - rsltMctRows[0]["WORK_6"].toInt();
                //newRow3["WORK_7"] = rsltInsRows[0]["WORK_7"].toInt() - rsltMctRows[0]["WORK_7"].toInt();
                //newRow3["WORK_8"] = rsltInsRows[0]["WORK_8"].toInt() - rsltMctRows[0]["WORK_8"].toInt();
                //newRow3["WORK_9"] = rsltInsRows[0]["WORK_9"].toInt() - rsltMctRows[0]["WORK_9"].toInt();
                //newRow3["WORK_10"] = rsltInsRows[0]["WORK_10"].toInt() - rsltMctRows[0]["WORK_10"].toInt();
                //newRow3["WORK_11"] = rsltInsRows[0]["WORK_11"].toInt() - rsltMctRows[0]["WORK_11"].toInt();
                //newRow3["WORK_12"] = rsltInsRows[0]["WORK_12"].toInt() - rsltMctRows[0]["WORK_12"].toInt();
                //newRow3["WORK_SUM"] = rsltInsRows[0]["WORK_SUM"].toInt() - rsltMctRows[0]["WORK_SUM"].toInt();

                //gridTable.Rows.Add(newRow3);


                gridTable.TableName = "RSLTDT";
                paramDS.Tables.Add(gridTable);

                dtRslt.TableName = "RSLTDT2";
                paramDS.Tables.Add(dtRslt);

                ////DataRow newRow = gridTable.NewRow();
                ////newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                ////newRow["INS_CODE"] = "INS";
                ////newRow["INS_NAME"] = "중간검사 실적";
                ////newRow["FLAG"] = "INS";

                ////newRow["WORK_1"] = 0;
                ////newRow["WORK_2"] = 0;
                ////newRow["WORK_3"] = 0;
                ////newRow["WORK_4"] = 0;
                ////newRow["WORK_5"] = 0;
                ////newRow["WORK_6"] = 0;
                ////newRow["WORK_7"] = 0;
                ////newRow["WORK_8"] = 0;
                ////newRow["WORK_9"] = 00;
                ////newRow["WORK_10"] = 0;
                ////newRow["WORK_11"] = 0;
                ////newRow["WORK_12"] = 0;
                ////newRow["WORK_SUM"] = 0;

                ////gridTable.Rows.Add(newRow);

                ////DataRow[] rows = gridTable.Select("FLAG = 'INS'");

                ////foreach (DataRow row in dtRslt.Rows)
                ////{
                ////    if (row["ACT_END_TIME"].ToString().Substring(4, 2) == "01") { rows[0]["WORK_1"] = rows[0]["WORK_1"].toDecimal() + row["ACT_QTY"].toDecimal(); }
                ////    if (row["ACT_END_TIME"].ToString().Substring(4, 2) == "02") { rows[0]["WORK_2"] = rows[0]["WORK_2"].toDecimal() + row["ACT_QTY"].toDecimal(); }
                ////    if (row["ACT_END_TIME"].ToString().Substring(4, 2) == "03") { rows[0]["WORK_3"] = rows[0]["WORK_3"].toDecimal() + row["ACT_QTY"].toDecimal(); }
                ////    if (row["ACT_END_TIME"].ToString().Substring(4, 2) == "04") { rows[0]["WORK_4"] = rows[0]["WORK_4"].toDecimal() + row["ACT_QTY"].toDecimal(); }
                ////    if (row["ACT_END_TIME"].ToString().Substring(4, 2) == "05") { rows[0]["WORK_5"] = rows[0]["WORK_5"].toDecimal() + row["ACT_QTY"].toDecimal(); }
                ////    if (row["ACT_END_TIME"].ToString().Substring(4, 2) == "06") { rows[0]["WORK_6"] = rows[0]["WORK_6"].toDecimal() + row["ACT_QTY"].toDecimal(); }
                ////    if (row["ACT_END_TIME"].ToString().Substring(4, 2) == "07") { rows[0]["WORK_7"] = rows[0]["WORK_7"].toDecimal() + row["ACT_QTY"].toDecimal(); }
                ////    if (row["ACT_END_TIME"].ToString().Substring(4, 2) == "08") { rows[0]["WORK_8"] = rows[0]["WORK_8"].toDecimal() + row["ACT_QTY"].toDecimal(); }
                ////    if (row["ACT_END_TIME"].ToString().Substring(4, 2) == "09") { rows[0]["WORK_9"] = rows[0]["WORK_9"].toDecimal() + row["ACT_QTY"].toDecimal(); }
                ////    if (row["ACT_END_TIME"].ToString().Substring(4, 2) == "10") { rows[0]["WORK_10"] = rows[0]["WORK_10"].toDecimal() + row["ACT_QTY"].toDecimal(); }
                ////    if (row["ACT_END_TIME"].ToString().Substring(4, 2) == "11") { rows[0]["WORK_11"] = rows[0]["WORK_11"].toDecimal() + row["ACT_QTY"].toDecimal(); }
                ////    if (row["ACT_END_TIME"].ToString().Substring(4, 2) == "12") { rows[0]["WORK_12"] = rows[0]["WORK_12"].toDecimal() + row["ACT_QTY"].toDecimal(); }

                ////    double aSum = rows[0]["WORK_1"].toDouble() + rows[0]["WORK_2"].toDouble() + rows[0]["WORK_3"].toDouble() + rows[0]["WORK_4"].toDouble()
                ////                + rows[0]["WORK_5"].toDouble() + rows[0]["WORK_6"].toDouble() + rows[0]["WORK_7"].toDouble() + rows[0]["WORK_8"].toDouble()
                ////                + rows[0]["WORK_9"].toDouble() + rows[0]["WORK_10"].toDouble() + rows[0]["WORK_11"].toDouble() + rows[0]["WORK_12"].toDouble();

                ////    rows[0]["WORK_SUM"] = aSum;

                ////}


                ////gridTable.TableName = "RSLTDT";
                ////paramDS.Tables.Add(gridTable);

                ////dtRslt2.TableName = "RSLTDT2";
                ////paramDS.Tables.Add(dtRslt2);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet REP05A_SER8(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PROC_CODE", "P-02", typeof(string));

                DataTable camALAct = DORD.TORD_PRODUCT_QUERY.TORD_PRODUCT_QUERY23(paramDS.Tables["RQSTDT"], bizExecute);
                DataTable camSujiAct = DORD.TORD_PRODUCT_QUERY.TORD_PRODUCT_QUERY24(paramDS.Tables["RQSTDT"], bizExecute);

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PROC_CODE", "P-04", typeof(string));

                DataTable mctALAct = DORD.TORD_PRODUCT_QUERY.TORD_PRODUCT_QUERY23(paramDS.Tables["RQSTDT"], bizExecute);
                DataTable mctSujiAct = DORD.TORD_PRODUCT_QUERY.TORD_PRODUCT_QUERY24(paramDS.Tables["RQSTDT"], bizExecute);

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "PROC_CODE", "P-06", typeof(string));

                DataTable insALAct = DORD.TORD_PRODUCT_QUERY.TORD_PRODUCT_QUERY23(paramDS.Tables["RQSTDT"], bizExecute);
                DataTable insSujiAct = DORD.TORD_PRODUCT_QUERY.TORD_PRODUCT_QUERY24(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable gridTable = new DataTable();
                gridTable.Columns.Add("PLT_CODE", typeof(String));
                gridTable.Columns.Add("FLAG", typeof(String));
                gridTable.Columns.Add("TYPE1", typeof(String));
                gridTable.Columns.Add("TYPE2", typeof(String));
                gridTable.Columns.Add("TYPE3", typeof(String));

                DateTime sDate = paramDS.Tables["RQSTDT"].Rows[0]["S_DATE"].toDateTime();
                DateTime eDate = paramDS.Tables["RQSTDT"].Rows[0]["E_DATE"].toDateTime();

                for (DateTime date = sDate; date <= eDate; date = date.AddDays(1))
                {
                    gridTable.Columns.Add(date.ToString("yyyyMMdd"), typeof(string));
                }

                SetRow(gridTable, "CAM", "캠");
                SetRow(gridTable, "MCT", "가공");
                SetRow(gridTable, "INS", "중간검사");



                //CAM
                //AL류
                Dictionary<string, int> prodDIc = new Dictionary<string, int>();

                DataRow[] sumCntRows = gridTable.Select("FLAG = 'CAM_COUNT_SUM'");
                DataRow[] sumQtyRows = gridTable.Select("FLAG = 'CAM_QTY_SUM'");
                DataRow[] cntRows = gridTable.Select("FLAG = 'CAM_AL_COUNT'");
                DataRow[] qtyRows = gridTable.Select("FLAG = 'CAM_AL_QTY'");

                foreach (DataRow row in camALAct.Rows)
                {
                    //if (row["CD_PARENT"].ToString() == "1"
                    //    || row["CD_PARENT"].ToString() == "2")
                    //{
                    //    if (!prodDIc.ContainsKey(row["PROD_CODE"].ToString()))
                    //    {
                    //        prodDIc.Add(row["PROD_CODE"].ToString(), 1);

                    //        string col = row["ACT_END_DATE"].ToString();

                    //        if (gridTable.Columns.Contains(col))
                    //        {
                    //            sumCntRows[0][col] = sumCntRows[0][col].toInt() + 1;
                    //            sumQtyRows[0][col] = sumQtyRows[0][col].toInt() + row["PROD_QTY"].toInt();
                    //            cntRows[0][col] = cntRows[0][col].toInt() + 1;
                    //            qtyRows[0][col] = qtyRows[0][col].toInt() + row["PROD_QTY"].toInt();
                    //        }
                    //    }
                    //}
                    //else if (row["CD_PARENT"].ToString() == "3")
                    //{
                    //    string col = row["ACT_END_DATE"].ToString();

                    //    if (gridTable.Columns.Contains(col))
                    //    {
                    //        sumCntRows[0][col] = sumCntRows[0][col].toInt() + 1;
                    //        sumQtyRows[0][col] = sumQtyRows[0][col].toInt() + row["PART_QTY"].toInt();
                    //        cntRows[0][col] = cntRows[0][col].toInt() + 1;
                    //        qtyRows[0][col] = qtyRows[0][col].toInt() + row["PART_QTY"].toInt();
                    //    }
                    //}

                    string col = row["ACT_END_DATE"].ToString();

                    if (gridTable.Columns.Contains(col))
                    {
                        sumCntRows[0][col] = sumCntRows[0][col].toInt() + 1;
                        sumQtyRows[0][col] = sumQtyRows[0][col].toInt() + row["PART_QTY"].toInt();
                        cntRows[0][col] = cntRows[0][col].toInt() + 1;
                        qtyRows[0][col] = qtyRows[0][col].toInt() + row["PART_QTY"].toInt();
                    }
                }

                //CAM
                //수지류

                prodDIc.Clear();

                //sumCntRows = gridTable.Select("FLAG = 'CAM_COUNT_SUM'");
                //sumQtyRows = gridTable.Select("FLAG = 'CAM_QTY_SUM'");
                cntRows = gridTable.Select("FLAG = 'CAM_SUJI_COUNT'");
                qtyRows = gridTable.Select("FLAG = 'CAM_SUJI_QTY'");

                foreach (DataRow row in camSujiAct.Rows)
                {
                    //if (row["CD_PARENT"].ToString() == "1"
                    //    || row["CD_PARENT"].ToString() == "2")
                    //{
                    //    if (!prodDIc.ContainsKey(row["PROD_CODE"].ToString()))
                    //    {
                    //        prodDIc.Add(row["PROD_CODE"].ToString(), 1);

                    //        string col = row["ACT_END_DATE"].ToString();

                    //        if (gridTable.Columns.Contains(col))
                    //        {
                    //            sumCntRows[0][col] = sumCntRows[0][col].toInt() + 1;
                    //            sumQtyRows[0][col] = sumQtyRows[0][col].toInt() + row["PROD_QTY"].toInt();
                    //            cntRows[0][col] = cntRows[0][col].toInt() + 1;
                    //            qtyRows[0][col] = qtyRows[0][col].toInt() + row["PROD_QTY"].toInt();
                    //        }
                    //    }
                    //}
                    //else if (row["CD_PARENT"].ToString() == "3")
                    //{
                    //    string col = row["ACT_END_DATE"].ToString();

                    //    if (gridTable.Columns.Contains(col))
                    //    {
                    //        sumCntRows[0][col] = sumCntRows[0][col].toInt() + 1;
                    //        sumQtyRows[0][col] = sumQtyRows[0][col].toInt() + row["PART_QTY"].toInt();
                    //        cntRows[0][col] = cntRows[0][col].toInt() + 1;
                    //        qtyRows[0][col] = qtyRows[0][col].toInt() + row["PART_QTY"].toInt();
                    //    }
                    //}

                    string col = row["ACT_END_DATE"].ToString();

                    if (gridTable.Columns.Contains(col))
                    {
                        sumCntRows[0][col] = sumCntRows[0][col].toInt() + 1;
                        sumQtyRows[0][col] = sumQtyRows[0][col].toInt() + row["PART_QTY"].toInt();
                        cntRows[0][col] = cntRows[0][col].toInt() + 1;
                        qtyRows[0][col] = qtyRows[0][col].toInt() + row["PART_QTY"].toInt();
                    }
                }



                //가공
                //AL류
                prodDIc.Clear();

                sumCntRows = gridTable.Select("FLAG = 'MCT_COUNT_SUM'");
                sumQtyRows = gridTable.Select("FLAG = 'MCT_QTY_SUM'");
                cntRows = gridTable.Select("FLAG = 'MCT_AL_COUNT'");
                qtyRows = gridTable.Select("FLAG = 'MCT_AL_QTY'");

                foreach (DataRow row in mctALAct.Rows)
                {
                    //if (row["CD_PARENT"].ToString() == "1"
                    //    || row["CD_PARENT"].ToString() == "2")
                    //{
                    //    if (!prodDIc.ContainsKey(row["PROD_CODE"].ToString()))
                    //    {
                    //        prodDIc.Add(row["PROD_CODE"].ToString(), 1);

                    //        string col = row["ACT_END_DATE"].ToString();

                    //        if (gridTable.Columns.Contains(col))
                    //        {
                    //            sumCntRows[0][col] = sumCntRows[0][col].toInt() + 1;
                    //            sumQtyRows[0][col] = sumQtyRows[0][col].toInt() + row["PROD_QTY"].toInt();
                    //            cntRows[0][col] = cntRows[0][col].toInt() + 1;
                    //            qtyRows[0][col] = qtyRows[0][col].toInt() + row["PROD_QTY"].toInt();
                    //        }
                    //    }
                    //}
                    //else if (row["CD_PARENT"].ToString() == "3")
                    //{
                    //    string col = row["ACT_END_DATE"].ToString();

                    //    if (gridTable.Columns.Contains(col))
                    //    {
                    //        sumCntRows[0][col] = sumCntRows[0][col].toInt() + 1;
                    //        sumQtyRows[0][col] = sumQtyRows[0][col].toInt() + row["PART_QTY"].toInt();
                    //        cntRows[0][col] = cntRows[0][col].toInt() + 1;
                    //        qtyRows[0][col] = qtyRows[0][col].toInt() + row["PART_QTY"].toInt();
                    //    }
                    //}

                    string col = row["ACT_END_DATE"].ToString();

                    if (gridTable.Columns.Contains(col))
                    {
                        sumCntRows[0][col] = sumCntRows[0][col].toInt() + 1;
                        sumQtyRows[0][col] = sumQtyRows[0][col].toInt() + row["PART_QTY"].toInt();
                        cntRows[0][col] = cntRows[0][col].toInt() + 1;
                        qtyRows[0][col] = qtyRows[0][col].toInt() + row["PART_QTY"].toInt();
                    }
                }

                //가공
                //수지류

                prodDIc.Clear();

                //sumCntRows = gridTable.Select("FLAG = 'CAM_COUNT_SUM'");
                //sumQtyRows = gridTable.Select("FLAG = 'CAM_QTY_SUM'");
                cntRows = gridTable.Select("FLAG = 'MCT_SUJI_COUNT'");
                qtyRows = gridTable.Select("FLAG = 'MCT_SUJI_QTY'");

                foreach (DataRow row in mctSujiAct.Rows)
                {
                    //if (row["CD_PARENT"].ToString() == "1"
                    //    || row["CD_PARENT"].ToString() == "2")
                    //{
                    //    if (!prodDIc.ContainsKey(row["PROD_CODE"].ToString()))
                    //    {
                    //        prodDIc.Add(row["PROD_CODE"].ToString(), 1);

                    //        string col = row["ACT_END_DATE"].ToString();

                    //        if (gridTable.Columns.Contains(col))
                    //        {
                    //            sumCntRows[0][col] = sumCntRows[0][col].toInt() + 1;
                    //            sumQtyRows[0][col] = sumQtyRows[0][col].toInt() + row["PROD_QTY"].toInt();
                    //            cntRows[0][col] = cntRows[0][col].toInt() + 1;
                    //            qtyRows[0][col] = qtyRows[0][col].toInt() + row["PROD_QTY"].toInt();
                    //        }
                    //    }
                    //}
                    //else if (row["CD_PARENT"].ToString() == "3")
                    //{
                    //    string col = row["ACT_END_DATE"].ToString();

                    //    if (gridTable.Columns.Contains(col))
                    //    {
                    //        sumCntRows[0][col] = sumCntRows[0][col].toInt() + 1;
                    //        sumQtyRows[0][col] = sumQtyRows[0][col].toInt() + row["PART_QTY"].toInt();
                    //        cntRows[0][col] = cntRows[0][col].toInt() + 1;
                    //        qtyRows[0][col] = qtyRows[0][col].toInt() + row["PART_QTY"].toInt();
                    //    }
                    //}

                    string col = row["ACT_END_DATE"].ToString();

                    if (gridTable.Columns.Contains(col))
                    {
                        sumCntRows[0][col] = sumCntRows[0][col].toInt() + 1;
                        sumQtyRows[0][col] = sumQtyRows[0][col].toInt() + row["PART_QTY"].toInt();
                        cntRows[0][col] = cntRows[0][col].toInt() + 1;
                        qtyRows[0][col] = qtyRows[0][col].toInt() + row["PART_QTY"].toInt();
                    }
                }

                //중간검사
                //AL류
                prodDIc.Clear();

                sumCntRows = gridTable.Select("FLAG = 'INS_COUNT_SUM'");
                sumQtyRows = gridTable.Select("FLAG = 'INS_QTY_SUM'");
                cntRows = gridTable.Select("FLAG = 'INS_AL_COUNT'");
                qtyRows = gridTable.Select("FLAG = 'INS_AL_QTY'");

                foreach (DataRow row in insALAct.Rows)
                {
                    //if (row["CD_PARENT"].ToString() == "1"
                    //    || row["CD_PARENT"].ToString() == "2")
                    //{
                    //    if (!prodDIc.ContainsKey(row["PROD_CODE"].ToString()))
                    //    {
                    //        prodDIc.Add(row["PROD_CODE"].ToString(), 1);

                    //        string col = row["ACT_END_DATE"].ToString();

                    //        if (gridTable.Columns.Contains(col))
                    //        {
                    //            sumCntRows[0][col] = sumCntRows[0][col].toInt() + 1;
                    //            sumQtyRows[0][col] = sumQtyRows[0][col].toInt() + row["PROD_QTY"].toInt();
                    //            cntRows[0][col] = cntRows[0][col].toInt() + 1;
                    //            qtyRows[0][col] = qtyRows[0][col].toInt() + row["PROD_QTY"].toInt();
                    //        }
                    //    }
                    //}
                    //else if (row["CD_PARENT"].ToString() == "3")
                    //{
                    //    string col = row["ACT_END_DATE"].ToString();

                    //    if (gridTable.Columns.Contains(col))
                    //    {
                    //        sumCntRows[0][col] = sumCntRows[0][col].toInt() + 1;
                    //        sumQtyRows[0][col] = sumQtyRows[0][col].toInt() + row["PART_QTY"].toInt();
                    //        cntRows[0][col] = cntRows[0][col].toInt() + 1;
                    //        qtyRows[0][col] = qtyRows[0][col].toInt() + row["PART_QTY"].toInt();
                    //    }
                    //}

                    string col = row["ACT_END_DATE"].ToString();

                    if (gridTable.Columns.Contains(col))
                    {
                        sumCntRows[0][col] = sumCntRows[0][col].toInt() + 1;
                        sumQtyRows[0][col] = sumQtyRows[0][col].toInt() + row["PART_QTY"].toInt();
                        cntRows[0][col] = cntRows[0][col].toInt() + 1;
                        qtyRows[0][col] = qtyRows[0][col].toInt() + row["PART_QTY"].toInt();
                    }
                }

                //중간검사
                //수지류

                prodDIc.Clear();

                //sumCntRows = gridTable.Select("FLAG = 'CAM_COUNT_SUM'");
                //sumQtyRows = gridTable.Select("FLAG = 'CAM_QTY_SUM'");
                cntRows = gridTable.Select("FLAG = 'INS_SUJI_COUNT'");
                qtyRows = gridTable.Select("FLAG = 'INS_SUJI_QTY'");

                foreach (DataRow row in insSujiAct.Rows)
                {
                    //if (row["CD_PARENT"].ToString() == "1"
                    //    || row["CD_PARENT"].ToString() == "2")
                    //{
                    //    if (!prodDIc.ContainsKey(row["PROD_CODE"].ToString()))
                    //    {
                    //        prodDIc.Add(row["PROD_CODE"].ToString(), 1);

                    //        string col = row["ACT_END_DATE"].ToString();

                    //        if (gridTable.Columns.Contains(col))
                    //        {
                    //            sumCntRows[0][col] = sumCntRows[0][col].toInt() + 1;
                    //            sumQtyRows[0][col] = sumQtyRows[0][col].toInt() + row["PROD_QTY"].toInt();
                    //            cntRows[0][col] = cntRows[0][col].toInt() + 1;
                    //            qtyRows[0][col] = qtyRows[0][col].toInt() + row["PROD_QTY"].toInt();
                    //        }
                    //    }
                    //}
                    //else if (row["CD_PARENT"].ToString() == "3")
                    //{
                    //    string col = row["ACT_END_DATE"].ToString();

                    //    if (gridTable.Columns.Contains(col))
                    //    {
                    //        sumCntRows[0][col] = sumCntRows[0][col].toInt() + 1;
                    //        sumQtyRows[0][col] = sumQtyRows[0][col].toInt() + row["PART_QTY"].toInt();
                    //        cntRows[0][col] = cntRows[0][col].toInt() + 1;
                    //        qtyRows[0][col] = qtyRows[0][col].toInt() + row["PART_QTY"].toInt();
                    //    }
                    //}

                    string col = row["ACT_END_DATE"].ToString();

                    if (gridTable.Columns.Contains(col))
                    {
                        sumCntRows[0][col] = sumCntRows[0][col].toInt() + 1;
                        sumQtyRows[0][col] = sumQtyRows[0][col].toInt() + row["PART_QTY"].toInt();
                        cntRows[0][col] = cntRows[0][col].toInt() + 1;
                        qtyRows[0][col] = qtyRows[0][col].toInt() + row["PART_QTY"].toInt();
                    }
                }

                gridTable.TableName = "RSLTDT";
                paramDS.Tables.Add(gridTable);


                //미완료 현황
                DataTable gridTable2 = gridTable.Clone();

                DataTable nonMctALAct = DORD.TORD_PRODUCT_QUERY.TORD_PRODUCT_QUERY25(paramDS.Tables["RQSTDT"], bizExecute);
                DataTable nonMctSujiAct = DORD.TORD_PRODUCT_QUERY.TORD_PRODUCT_QUERY26(paramDS.Tables["RQSTDT"], bizExecute);

                SetRow(gridTable2, "MCT", "가공", "기준");

                //가공
                //AL류
                prodDIc.Clear();

                sumCntRows = gridTable2.Select("FLAG = 'MCT_COUNT_SUM'");
                sumQtyRows = gridTable2.Select("FLAG = 'MCT_QTY_SUM'");
                cntRows = gridTable2.Select("FLAG = 'MCT_AL_COUNT'");
                qtyRows = gridTable2.Select("FLAG = 'MCT_AL_QTY'");

                foreach (DataRow row in nonMctALAct.Rows)
                {
                    //if (row["CD_PARENT"].ToString() == "1"
                    //    || row["CD_PARENT"].ToString() == "2")
                    //{
                    //    if (!prodDIc.ContainsKey(row["PROD_CODE"].ToString()))
                    //    {
                    //        prodDIc.Add(row["PROD_CODE"].ToString(), 1);

                    //        string col = row["DUE_DATE"].ToString();

                    //        if (gridTable2.Columns.Contains(col))
                    //        {
                    //            sumCntRows[0][col] = sumCntRows[0][col].toInt() + 1;
                    //            sumQtyRows[0][col] = sumQtyRows[0][col].toInt() + row["PROD_QTY"].toInt();
                    //            cntRows[0][col] = cntRows[0][col].toInt() + 1;
                    //            qtyRows[0][col] = qtyRows[0][col].toInt() + row["PROD_QTY"].toInt();
                    //        }
                    //    }
                    //}
                    //else if (row["CD_PARENT"].ToString() == "3")
                    //{
                    //    string col = row["DUE_DATE"].ToString();

                    //    if (gridTable2.Columns.Contains(col))
                    //    {
                    //        sumCntRows[0][col] = sumCntRows[0][col].toInt() + 1;
                    //        sumQtyRows[0][col] = sumQtyRows[0][col].toInt() + row["PART_QTY"].toInt();
                    //        cntRows[0][col] = cntRows[0][col].toInt() + 1;
                    //        qtyRows[0][col] = qtyRows[0][col].toInt() + row["PART_QTY"].toInt();
                    //    }
                    //}

                    string col = row["DUE_DATE"].ToString();

                    if (gridTable2.Columns.Contains(col))
                    {
                        sumCntRows[0][col] = sumCntRows[0][col].toInt() + 1;
                        sumQtyRows[0][col] = sumQtyRows[0][col].toInt() + row["PART_QTY"].toInt();
                        cntRows[0][col] = cntRows[0][col].toInt() + 1;
                        qtyRows[0][col] = qtyRows[0][col].toInt() + row["PART_QTY"].toInt();
                    }
                }

                //가공
                //수지류

                prodDIc.Clear();

                //sumCntRows = gridTable2.Select("FLAG = 'CAM_COUNT_SUM'");
                //sumQtyRows = gridTable2.Select("FLAG = 'CAM_QTY_SUM'");
                cntRows = gridTable2.Select("FLAG = 'MCT_SUJI_COUNT'");
                qtyRows = gridTable2.Select("FLAG = 'MCT_SUJI_QTY'");

                foreach (DataRow row in nonMctSujiAct.Rows)
                {
                    //if (row["CD_PARENT"].ToString() == "1"
                    //    || row["CD_PARENT"].ToString() == "2")
                    //{
                    //    if (!prodDIc.ContainsKey(row["PROD_CODE"].ToString()))
                    //    {
                    //        prodDIc.Add(row["PROD_CODE"].ToString(), 1);

                    //        string col = row["DUE_DATE"].ToString();

                    //        if (gridTable2.Columns.Contains(col))
                    //        {
                    //            sumCntRows[0][col] = sumCntRows[0][col].toInt() + 1;
                    //            sumQtyRows[0][col] = sumQtyRows[0][col].toInt() + row["PROD_QTY"].toInt();
                    //            cntRows[0][col] = cntRows[0][col].toInt() + 1;
                    //            qtyRows[0][col] = qtyRows[0][col].toInt() + row["PROD_QTY"].toInt();
                    //        }
                    //    }
                    //}
                    //else if (row["CD_PARENT"].ToString() == "3")
                    //{
                    //    string col = row["DUE_DATE"].ToString();

                    //    if (gridTable2.Columns.Contains(col))
                    //    {
                    //        sumCntRows[0][col] = sumCntRows[0][col].toInt() + 1;
                    //        sumQtyRows[0][col] = sumQtyRows[0][col].toInt() + row["PART_QTY"].toInt();
                    //        cntRows[0][col] = cntRows[0][col].toInt() + 1;
                    //        qtyRows[0][col] = qtyRows[0][col].toInt() + row["PART_QTY"].toInt();
                    //    }
                    //}

                    string col = row["DUE_DATE"].ToString();

                    if (gridTable2.Columns.Contains(col))
                    {
                        sumCntRows[0][col] = sumCntRows[0][col].toInt() + 1;
                        sumQtyRows[0][col] = sumQtyRows[0][col].toInt() + row["PART_QTY"].toInt();
                        cntRows[0][col] = cntRows[0][col].toInt() + 1;
                        qtyRows[0][col] = qtyRows[0][col].toInt() + row["PART_QTY"].toInt();
                    }
                }


                //조립 수량
                DataTable nonAssyAct = DORD.TORD_PRODUCT_QUERY.TORD_PRODUCT_QUERY27(paramDS.Tables["RQSTDT"], bizExecute);

                foreach (DataRow row in nonAssyAct.Rows)
                {
                    if (row["PROD_TYPE"].ToString() == "") continue;

                    DataRow[] rows = gridTable2.Select("FLAG = '" + row["PROD_TYPE"].ToString() + "'");

                    if (rows.Length == 0)
                    {
                        DataRow newRow = gridTable2.NewRow();
                        newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                        newRow["FLAG"] = row["PROD_TYPE"];
                        newRow["TYPE1"] = "조립 기준";
                        newRow["TYPE2"] = row["CD_NAME"];
                        newRow["TYPE3"] = "수량";

                        gridTable2.Rows.Add(newRow);
                    }

                    rows = gridTable2.Select("FLAG = '" + row["PROD_TYPE"].ToString() + "'");

                    string col = row["DUE_DATE"].ToString();

                    if (gridTable2.Columns.Contains(col))
                    {
                        rows[0][col] = rows[0][col].toInt() + row["PROD_QTY"].toInt();
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

        public static DataSet REP05A_SER9(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtRslt = DSHP.TSHP_ACTUAL_QUERY.TSHP_ACTUAL_QUERY34(paramDS.Tables["RQSTDT"], bizExecute);

                dtRslt.TableName = "RSLTDT";
                paramDS.Tables.Add(dtRslt);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        static void SetRow(DataTable gridTable, string flag, string type1, string type3 = "실적")
        {
            DataRow newRow = gridTable.NewRow();
            newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
            newRow["FLAG"] = flag + "_COUNT_SUM";
            newRow["TYPE1"] = type1 + " " + type3;
            newRow["TYPE2"] = "합계";
            newRow["TYPE3"] = "건수";
            gridTable.Rows.Add(newRow);

            newRow = gridTable.NewRow();
            newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
            newRow["FLAG"] = flag + "_QTY_SUM";
            newRow["TYPE1"] = type1 + " " + type3;
            newRow["TYPE2"] = "합계";
            newRow["TYPE3"] = "수량";
            gridTable.Rows.Add(newRow);

            newRow = gridTable.NewRow();
            newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
            newRow["FLAG"] = flag + "_AL_COUNT";
            newRow["TYPE1"] = type1 + " " + type3;
            newRow["TYPE2"] = "AL류";
            newRow["TYPE3"] = "건수";
            gridTable.Rows.Add(newRow);

            newRow = gridTable.NewRow();
            newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
            newRow["FLAG"] = flag + "_AL_QTY";
            newRow["TYPE1"] = type1 + " " + type3;
            newRow["TYPE2"] = "AL류";
            newRow["TYPE3"] = "수량";
            gridTable.Rows.Add(newRow);

            newRow = gridTable.NewRow();
            newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
            newRow["FLAG"] = flag + "_SUJI_COUNT";
            newRow["TYPE1"] = type1 + " " + type3;
            newRow["TYPE2"] = "수지류";
            newRow["TYPE3"] = "건수";
            gridTable.Rows.Add(newRow);

            newRow = gridTable.NewRow();
            newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
            newRow["FLAG"] = flag + "_SUJI_QTY";
            newRow["TYPE1"] = type1 + " " + type3;
            newRow["TYPE2"] = "수지류";
            newRow["TYPE3"] = "수량";
            gridTable.Rows.Add(newRow);
        }
    }
}

