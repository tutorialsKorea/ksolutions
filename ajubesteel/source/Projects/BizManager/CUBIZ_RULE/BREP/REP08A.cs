using BizExecute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BREP
{
    public class REP08A
    {
        public static DataSet REP08A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtypgoRslt = DMAT.TMAT_YPGO_QUERY.TMAT_YPGO_QUERY7(paramDS.Tables["RQSTDT"], bizExecute);

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

                cloneTable.Columns.Add("WORK_1_R", typeof(decimal));
                cloneTable.Columns.Add("WORK_2_R", typeof(decimal));
                cloneTable.Columns.Add("WORK_3_R", typeof(decimal));
                cloneTable.Columns.Add("WORK_4_R", typeof(decimal));
                cloneTable.Columns.Add("WORK_5_R", typeof(decimal));
                cloneTable.Columns.Add("WORK_6_R", typeof(decimal));
                cloneTable.Columns.Add("WORK_7_R", typeof(decimal));
                cloneTable.Columns.Add("WORK_8_R", typeof(decimal));
                cloneTable.Columns.Add("WORK_9_R", typeof(decimal));
                cloneTable.Columns.Add("WORK_10_R", typeof(decimal));
                cloneTable.Columns.Add("WORK_11_R", typeof(decimal));
                cloneTable.Columns.Add("WORK_12_R", typeof(decimal));

                DataTable ypgoTable1 = ypgoType1(cloneTable, dtypgoRslt);
                ypgoTable1.TableName = "RSLTDT";

                DataTable ypgoTable2 = ypgoType2(cloneTable, dtypgoRslt);
                ypgoTable2.TableName = "RSLTDT2";

                paramDS.Tables.Add(ypgoTable1);
                paramDS.Tables.Add(ypgoTable2);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
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

        static DataTable ypgoType2(DataTable cloneTable, DataTable oriTable)
        {
            DataTable gridTable = cloneTable.Clone();

            foreach (DataRow row in oriTable.Rows)
            {

                if (row["MVND_CODE"].ToString() == "") continue;

                DataRow[] rows = gridTable.Select("FLAG = '" + row["MVND_CODE"].ToString() + "'");

                if (rows.Length == 0)
                {
                    DataRow newRow = gridTable.NewRow();
                    newRow["PLT_CODE"] = ConnInfo.PLT_CODE;
                    newRow["FLAG"] = row["MVND_CODE"];
                    newRow["TYPE"] = row["MVND_NAME"];

                    gridTable.Rows.Add(newRow);
                }

                rows = gridTable.Select("FLAG = '" + row["MVND_CODE"].ToString() + "'");

                if (rows.Length > 0)
                {
                    for (int i = 0; i < 12; i++)
                    {
                        if (!row["AMT"].isNumeric()) row["AMT"] = 0;
                        if (!rows[0]["WORK_" + (i + 1).ToString()].isNumeric()) rows[0]["WORK_" + (i + 1).ToString()] = 0;
                        //if (row["WORK_" + (i + 1).ToString()]) == 0) row["WORK_" + (i + 1).ToString()] = 0;
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
                    //if (row["AMT"].toInt() == 0) row["AMT"] = 0;
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
            }

            return gridTable;
        }

        static DataTable ypgoType3(DataTable cloneTable, DataTable oriTable)
        {
            DataTable gridTable = cloneTable.Clone();

            foreach (DataRow row in oriTable.Rows)
            {

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
                    for (int i = 0; i < 12; i++)
                    {
                        if (!row["AMT"].isNumeric()) row["AMT"] = 0;
                        if (!rows[0]["WORK_" + (i + 1).ToString()].isNumeric()) rows[0]["WORK_" + (i + 1).ToString()] = 0;
                        //if (row["WORK_" + (i + 1).ToString()]) == 0) row["WORK_" + (i + 1).ToString()] = 0;
                    }

                    if (row["YPGO_MONTH"].ToString().Substring(4, 2) == "01") rows[0]["WORK_1"] = rows[0]["WORK_1"].toDecimal() + row["AMT"].toDecimal();
                    if (row["YPGO_MONTH"].ToString().Substring(4, 2) == "02") rows[0]["WORK_2"] = rows[0]["WORK_2"].toDecimal() + row["AMT"].toDecimal();
                    if (row["YPGO_MONTH"].ToString().Substring(4, 2) == "03") rows[0]["WORK_3"] = rows[0]["WORK_3"].toDecimal() + row["AMT"].toDecimal();
                    if (row["YPGO_MONTH"].ToString().Substring(4, 2) == "04") rows[0]["WORK_4"] = rows[0]["WORK_4"].toDecimal() + row["AMT"].toDecimal();
                    if (row["YPGO_MONTH"].ToString().Substring(4, 2) == "05") rows[0]["WORK_5"] = rows[0]["WORK_5"].toDecimal() + row["AMT"].toDecimal();
                    if (row["YPGO_MONTH"].ToString().Substring(4, 2) == "06") rows[0]["WORK_6"] = rows[0]["WORK_6"].toDecimal() + row["AMT"].toDecimal();
                    if (row["YPGO_MONTH"].ToString().Substring(4, 2) == "07") rows[0]["WORK_7"] = rows[0]["WORK_7"].toDecimal() + row["AMT"].toDecimal();
                    if (row["YPGO_MONTH"].ToString().Substring(4, 2) == "08") rows[0]["WORK_8"] = rows[0]["WORK_8"].toDecimal() + row["AMT"].toDecimal();
                    if (row["YPGO_MONTH"].ToString().Substring(4, 2) == "09") rows[0]["WORK_9"] = rows[0]["WORK_9"].toDecimal() + row["AMT"].toDecimal();
                    if (row["YPGO_MONTH"].ToString().Substring(4, 2) == "10") rows[0]["WORK_10"] = rows[0]["WORK_10"].toDecimal() + row["AMT"].toDecimal();
                    if (row["YPGO_MONTH"].ToString().Substring(4, 2) == "11") rows[0]["WORK_11"] = rows[0]["WORK_11"].toDecimal() + row["AMT"].toDecimal();
                    if (row["YPGO_MONTH"].ToString().Substring(4, 2) == "12") rows[0]["WORK_12"] = rows[0]["WORK_12"].toDecimal() + row["AMT"].toDecimal();

                    decimal sum = rows[0]["WORK_1"].toDecimal() + rows[0]["WORK_2"].toDecimal() + rows[0]["WORK_3"].toDecimal() + rows[0]["WORK_4"].toDecimal()
                                 + rows[0]["WORK_5"].toDecimal() + rows[0]["WORK_6"].toDecimal() + rows[0]["WORK_7"].toDecimal() + rows[0]["WORK_8"].toDecimal()
                                 + rows[0]["WORK_9"].toDecimal() + rows[0]["WORK_10"].toDecimal() + rows[0]["WORK_11"].toDecimal() + rows[0]["WORK_12"].toDecimal();

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
                    //if (row["AMT"].toInt() == 0) row["AMT"] = 0;
                    if (!newRow2["WORK_" + (i + 1).ToString()].isNumeric()) newRow2["WORK_" + (i + 1).ToString()] = 0;
                    if (!row["WORK_" + (i + 1).ToString()].isNumeric()) row["WORK_" + (i + 1).ToString()] = 0;
                }

                newRow2["WORK_1"] = newRow2["WORK_1"].toDecimal() + row["WORK_1"].toDecimal();
                newRow2["WORK_2"] = newRow2["WORK_2"].toDecimal() + row["WORK_2"].toDecimal();
                newRow2["WORK_3"] = newRow2["WORK_3"].toDecimal() + row["WORK_3"].toDecimal();
                newRow2["WORK_4"] = newRow2["WORK_4"].toDecimal() + row["WORK_4"].toDecimal();
                newRow2["WORK_5"] = newRow2["WORK_5"].toDecimal() + row["WORK_5"].toDecimal();
                newRow2["WORK_6"] = newRow2["WORK_6"].toDecimal() + row["WORK_6"].toDecimal();
                newRow2["WORK_7"] = newRow2["WORK_7"].toDecimal() + row["WORK_7"].toDecimal();
                newRow2["WORK_8"] = newRow2["WORK_8"].toDecimal() + row["WORK_8"].toDecimal();
                newRow2["WORK_9"] = newRow2["WORK_9"].toDecimal() + row["WORK_9"].toDecimal();
                newRow2["WORK_10"] = newRow2["WORK_10"].toDecimal() + row["WORK_10"].toDecimal();
                newRow2["WORK_11"] = newRow2["WORK_11"].toDecimal() + row["WORK_11"].toDecimal();
                newRow2["WORK_12"] = newRow2["WORK_12"].toDecimal() + row["WORK_12"].toDecimal();

                decimal sum = newRow2["WORK_1"].toDecimal() + newRow2["WORK_2"].toDecimal() + newRow2["WORK_3"].toDecimal() + newRow2["WORK_4"].toDecimal()
                         + newRow2["WORK_5"].toDecimal() + newRow2["WORK_6"].toDecimal() + newRow2["WORK_7"].toDecimal() + newRow2["WORK_8"].toDecimal()
                         + newRow2["WORK_9"].toDecimal() + newRow2["WORK_10"].toDecimal() + newRow2["WORK_11"].toDecimal() + newRow2["WORK_12"].toDecimal();

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

        public static DataSet REP08A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtypgoRslt = DMAT.TMAT_YPGO_QUERY.TMAT_YPGO_QUERY7(paramDS.Tables["RQSTDT"], bizExecute);

                UTIL.SetBizAddColumnToValue(paramDS.Tables["RQSTDT"], "WORK_YEAR", "YEAR");

                paramDS.Tables["RQSTDT"].Rows[0]["YEAR"] = paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].toInt() - 1;
                paramDS.Tables["RQSTDT"].Rows[0]["WORK_YEAR"] = paramDS.Tables["RQSTDT"].Rows[0]["YEAR"];
                string prev = paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].ToString();

                DataTable dtprevYpgoRslt = DMAT.TMAT_YPGO_QUERY.TMAT_YPGO_QUERY7(paramDS.Tables["RQSTDT"], bizExecute);

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


                paramDS.Tables["RQSTDT"].Rows[0]["YEAR"] = paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].toInt() - 1;
                paramDS.Tables["RQSTDT"].Rows[0]["WORK_YEAR"] = paramDS.Tables["RQSTDT"].Rows[0]["YEAR"];
                string prev2 = paramDS.Tables["RQSTDT"].Rows[0]["YEAR"].ToString();

                DataTable dtprevYpgoRslt2 = DMAT.TMAT_YPGO_QUERY.TMAT_YPGO_QUERY7(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable dtProdRslt2 = DORD.TORD_PRODUCT_QUERY.TORD_PRODUCT_QUERY16(paramDS.Tables["RQSTDT"], bizExecute);

                DataTable groupDt2 = dtProdRslt2
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

                DataTable ypgoTable1 = ypgoType3(cloneTable, dtypgoRslt, dtprevYpgoRslt, prev, dtprevYpgoRslt2, prev2);
                ypgoTable1.TableName = "RSLTDT";

                DataTable ypgoTable2 = ypgoType4(cloneTable, dtypgoRslt, groupDt, prev, groupDt2, prev2);
                ypgoTable2.TableName = "RSLTDT2";

                paramDS.Tables.Add(ypgoTable1);
                paramDS.Tables.Add(ypgoTable2);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet REP08A_SER3(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable dtypgoRslt = DOUT.TOUT_PROCYPGO_QUERY.TOUT_PROCYPGO_QUERY6(paramDS.Tables["RQSTDT"], bizExecute);

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

                DataTable ypgoTable1 = ypgoType3(cloneTable, dtypgoRslt);
                ypgoTable1.TableName = "RSLTDT";

                paramDS.Tables.Add(ypgoTable1);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        static DataTable ypgoType3(DataTable cloneTable, DataTable oriTable, DataTable prevTable, string prev, DataTable prevTable2, string prev2)
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
                        //if (newRow2["WORK_" + (i + 1).ToString()].toInt() == 0) newRow2["WORK_" + (i + 1).ToString()] = 0;
                        //if (row["WORK_" + (i + 1).ToString()].toInt() == 0) row["WORK_" + (i + 1).ToString()] = 0;
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
                    if (!row["WORK_" + (i + 1).ToString()].isNumeric()) row["WORK_" + (i + 1).ToString()] = 0;
                    if (!newRow2["WORK_" + (i + 1).ToString()].isNumeric()) newRow2["WORK_" + (i + 1).ToString()] = 0;
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
                         +System.Convert.ToInt64(newRow2["WORK_9"]) + System.Convert.ToInt64(newRow2["WORK_10"]) + System.Convert.ToInt64(newRow2["WORK_11"]) + System.Convert.ToInt64(newRow2["WORK_12"]);

                newRow2["WORK_SUM"] = sum;
            }

            gridTable.Rows.Add(newRow2);
            //gridTable.Rows.InsertAt(newRow2, 0);

            DataRow[] sumRows = gridTable.Select("FLAG = 'SUM'");

            foreach (DataRow row in gridTable.Rows)
            {
                if (sumRows[0]["WORK_SUM"].toDecimal() > 0) { row["WORK_RATE"] = row["WORK_SUM"].toDecimal() / sumRows[0]["WORK_SUM"].toDecimal(); } else { row["WORK_RATE"] = 0; };
            }



            DataRow sumRow = gridTable.NewRow();
            sumRow["FLAG"] = "PREV_SUM";
            sumRow["TYPE"] = prev + "년도 매입액";

            foreach (DataRow row in prevTable.Rows)
            {

                //DataRow[] rows = gridTable.Select("FLAG = 'PREV_SUM'");

                //if (rows.Length > 0)
                //{
                    for (int i = 0; i < 12; i++)
                    {
                        if (!row["AMT"].isNumeric()) row["AMT"] = 0;
                        if (!sumRow["WORK_" + (i + 1).ToString()].isNumeric()) sumRow["WORK_" + (i + 1).ToString()] = 0;
                        //if (newRow2["WORK_" + (i + 1).ToString()].toInt() == 0) newRow2["WORK_" + (i + 1).ToString()] = 0;
                        //if (row["WORK_" + (i + 1).ToString()].toInt() == 0) row["WORK_" + (i + 1).ToString()] = 0;
                    }

                    if (row["CLOSE_MONTH"].ToString().Substring(4, 2) == "01") sumRow["WORK_1"] = System.Convert.ToInt64(sumRow["WORK_1"]) + System.Convert.ToInt64(row["AMT"]);
                    if (row["CLOSE_MONTH"].ToString().Substring(4, 2) == "02") sumRow["WORK_2"] = System.Convert.ToInt64(sumRow["WORK_2"]) + System.Convert.ToInt64(row["AMT"]);
                    if (row["CLOSE_MONTH"].ToString().Substring(4, 2) == "03") sumRow["WORK_3"] = System.Convert.ToInt64(sumRow["WORK_3"]) + System.Convert.ToInt64(row["AMT"]);
                    if (row["CLOSE_MONTH"].ToString().Substring(4, 2) == "04") sumRow["WORK_4"] = System.Convert.ToInt64(sumRow["WORK_4"]) + System.Convert.ToInt64(row["AMT"]);
                    if (row["CLOSE_MONTH"].ToString().Substring(4, 2) == "05") sumRow["WORK_5"] = System.Convert.ToInt64(sumRow["WORK_5"]) + System.Convert.ToInt64(row["AMT"]);
                    if (row["CLOSE_MONTH"].ToString().Substring(4, 2) == "06") sumRow["WORK_6"] = System.Convert.ToInt64(sumRow["WORK_6"]) + System.Convert.ToInt64(row["AMT"]);
                    if (row["CLOSE_MONTH"].ToString().Substring(4, 2) == "07") sumRow["WORK_7"] = System.Convert.ToInt64(sumRow["WORK_7"]) + System.Convert.ToInt64(row["AMT"]);
                    if (row["CLOSE_MONTH"].ToString().Substring(4, 2) == "08") sumRow["WORK_8"] = System.Convert.ToInt64(sumRow["WORK_8"]) + System.Convert.ToInt64(row["AMT"]);
                    if (row["CLOSE_MONTH"].ToString().Substring(4, 2) == "09") sumRow["WORK_9"] = System.Convert.ToInt64(sumRow["WORK_9"]) + System.Convert.ToInt64(row["AMT"]);
                    if (row["CLOSE_MONTH"].ToString().Substring(4, 2) == "10") sumRow["WORK_10"] = System.Convert.ToInt64(sumRow["WORK_10"]) + System.Convert.ToInt64(row["AMT"]);
                    if (row["CLOSE_MONTH"].ToString().Substring(4, 2) == "11") sumRow["WORK_11"] = System.Convert.ToInt64(sumRow["WORK_11"]) + System.Convert.ToInt64(row["AMT"]);
                    if (row["CLOSE_MONTH"].ToString().Substring(4, 2) == "12") sumRow["WORK_12"] = System.Convert.ToInt64(sumRow["WORK_12"]) + System.Convert.ToInt64(row["AMT"]);

                    double sum = System.Convert.ToInt64(sumRow["WORK_1"]) + System.Convert.ToInt64(sumRow["WORK_2"]) + System.Convert.ToInt64(sumRow["WORK_3"]) + System.Convert.ToInt64(sumRow["WORK_4"])
                                 + System.Convert.ToInt64(sumRow["WORK_5"]) + System.Convert.ToInt64(sumRow["WORK_6"]) + System.Convert.ToInt64(sumRow["WORK_7"]) + System.Convert.ToInt64(sumRow["WORK_8"])
                                 +System.Convert.ToInt64(sumRow["WORK_9"]) + System.Convert.ToInt64(sumRow["WORK_10"]) + System.Convert.ToInt64(sumRow["WORK_11"]) + System.Convert.ToInt64(sumRow["WORK_12"]);

                sumRow["WORK_SUM"] = sum;
                //}
            }

            gridTable.Rows.Add(sumRow);


            sumRow = gridTable.NewRow();
            sumRow["FLAG"] = "PREV_SUM2";
            sumRow["TYPE"] = prev2 + "년도 매입액";

            foreach (DataRow row in prevTable2.Rows)
            {

                //DataRow[] rows = gridTable.Select("FLAG = 'PREV_SUM2'");

                //if (rows.Length > 0)
                //{
                    for (int i = 0; i < 12; i++)
                    {
                        if (!row["AMT"].isNumeric()) row["AMT"] = 0;
                        if (!sumRow["WORK_" + (i + 1).ToString()].isNumeric()) sumRow["WORK_" + (i + 1).ToString()] = 0;
                        //if (newRow2["WORK_" + (i + 1).ToString()].toInt() == 0) newRow2["WORK_" + (i + 1).ToString()] = 0;
                        //if (row["WORK_" + (i + 1).ToString()].toInt() == 0) row["WORK_" + (i + 1).ToString()] = 0;
                    }

                    if (row["CLOSE_MONTH"].ToString().Substring(4, 2) == "01") sumRow["WORK_1"] = System.Convert.ToInt64(sumRow["WORK_1"]) + System.Convert.ToInt64(row["AMT"]);
                    if (row["CLOSE_MONTH"].ToString().Substring(4, 2) == "02") sumRow["WORK_2"] = System.Convert.ToInt64(sumRow["WORK_2"]) + System.Convert.ToInt64(row["AMT"]);
                    if (row["CLOSE_MONTH"].ToString().Substring(4, 2) == "03") sumRow["WORK_3"] = System.Convert.ToInt64(sumRow["WORK_3"]) + System.Convert.ToInt64(row["AMT"]);
                    if (row["CLOSE_MONTH"].ToString().Substring(4, 2) == "04") sumRow["WORK_4"] = System.Convert.ToInt64(sumRow["WORK_4"]) + System.Convert.ToInt64(row["AMT"]);
                    if (row["CLOSE_MONTH"].ToString().Substring(4, 2) == "05") sumRow["WORK_5"] = System.Convert.ToInt64(sumRow["WORK_5"]) + System.Convert.ToInt64(row["AMT"]);
                    if (row["CLOSE_MONTH"].ToString().Substring(4, 2) == "06") sumRow["WORK_6"] = System.Convert.ToInt64(sumRow["WORK_6"]) + System.Convert.ToInt64(row["AMT"]);
                    if (row["CLOSE_MONTH"].ToString().Substring(4, 2) == "07") sumRow["WORK_7"] = System.Convert.ToInt64(sumRow["WORK_7"]) + System.Convert.ToInt64(row["AMT"]);
                    if (row["CLOSE_MONTH"].ToString().Substring(4, 2) == "08") sumRow["WORK_8"] = System.Convert.ToInt64(sumRow["WORK_8"]) + System.Convert.ToInt64(row["AMT"]);
                    if (row["CLOSE_MONTH"].ToString().Substring(4, 2) == "09") sumRow["WORK_9"] = System.Convert.ToInt64(sumRow["WORK_9"]) + System.Convert.ToInt64(row["AMT"]);
                    if (row["CLOSE_MONTH"].ToString().Substring(4, 2) == "10") sumRow["WORK_10"] = System.Convert.ToInt64(sumRow["WORK_10"]) + System.Convert.ToInt64(row["AMT"]);
                    if (row["CLOSE_MONTH"].ToString().Substring(4, 2) == "11") sumRow["WORK_11"] = System.Convert.ToInt64(sumRow["WORK_11"]) + System.Convert.ToInt64(row["AMT"]);
                    if (row["CLOSE_MONTH"].ToString().Substring(4, 2) == "12") sumRow["WORK_12"] = System.Convert.ToInt64(sumRow["WORK_12"]) + System.Convert.ToInt64(row["AMT"]);

                    double sum = System.Convert.ToInt64(sumRow["WORK_1"]) + System.Convert.ToInt64(sumRow["WORK_2"]) + System.Convert.ToInt64(sumRow["WORK_3"]) + System.Convert.ToInt64(sumRow["WORK_4"])
                                 + System.Convert.ToInt64(sumRow["WORK_5"]) + System.Convert.ToInt64(sumRow["WORK_6"]) + System.Convert.ToInt64(sumRow["WORK_7"]) + System.Convert.ToInt64(sumRow["WORK_8"])
                                 + System.Convert.ToInt64(sumRow["WORK_9"]) + System.Convert.ToInt64(sumRow["WORK_10"]) + System.Convert.ToInt64(sumRow["WORK_11"]) + System.Convert.ToInt64(sumRow["WORK_12"]);

                sumRow["WORK_SUM"] = sum;
                //}
            }

            gridTable.Rows.Add(sumRow);

            return gridTable;
        }

        static DataTable ypgoType4(DataTable cloneTable, DataTable oriTable, DataTable prevTable, string prev, DataTable prevTable2, string prev2)
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
                    for (int j = 0; j < 12; j++)
                    {
                        if (!row["AMT"].isNumeric()) row["AMT"] = 0;
                        if (!rows[0]["WORK_" + (j + 1).ToString()].isNumeric()) rows[0]["WORK_" + (j + 1).ToString()] = 0;
                        //if (newRow2["WORK_" + (i + 1).ToString()].toInt() == 0) newRow2["WORK_" + (i + 1).ToString()] = 0;
                        //if (row["WORK_" + (i + 1).ToString()].toInt() == 0) row["WORK_" + (i + 1).ToString()] = 0;
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
                for (int idx = 0; idx < 12; idx++)
                {
                    if (!row["WORK_" + (idx + 1).ToString()].isNumeric()) row["WORK_" + (idx + 1).ToString()] = 0;
                    if (!newRow2["WORK_" + (idx + 1).ToString()].isNumeric()) newRow2["WORK_" + (idx + 1).ToString()] = 0;
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

            gridTable.Rows.Add(newRow2);
            //gridTable.Rows.InsertAt(newRow2, 0);

            DataRow[] sumRows = gridTable.Select("FLAG = 'SUM'");

            foreach (DataRow row in gridTable.Rows)
            {
                if (sumRows[0]["WORK_SUM"].toDecimal() > 0) { row["WORK_RATE"] = row["WORK_SUM"].toDecimal() / sumRows[0]["WORK_SUM"].toDecimal(); } else { row["WORK_RATE"] = 0; };
            }

            DataRow sumRow = gridTable.NewRow();
            sumRow["FLAG"] = "PREV_SUM";
            sumRow["TYPE"] = prev + "년도 매출액";

            int i = 0;
            foreach (DataRow row in prevTable.Rows)
            {
                if (i > 0) break;
                i++;
                //DataRow[] rows = gridTable.Select("FLAG = 'PREV_SUM'");

                //if (rows.Length > 0)
                //{
                //sumRow["WORK_1"] = System.Convert.ToInt64(sumRow["WORK_1"]) + System.Convert.ToInt64(row["JAN"]);
                //sumRow["WORK_2"] = System.Convert.ToInt64(sumRow["WORK_2"]) + System.Convert.ToInt64(row["FEB"]);
                //sumRow["WORK_3"] = System.Convert.ToInt64(sumRow["WORK_3"]) + System.Convert.ToInt64(row["MAR"]);
                //sumRow["WORK_4"] = System.Convert.ToInt64(sumRow["WORK_4"]) + System.Convert.ToInt64(row["APR"]);
                //sumRow["WORK_5"] = System.Convert.ToInt64(sumRow["WORK_5"]) + System.Convert.ToInt64(row["MAY"]);
                //sumRow["WORK_6"] = System.Convert.ToInt64(sumRow["WORK_6"]) + System.Convert.ToInt64(row["JUN"]);
                //sumRow["WORK_7"] = System.Convert.ToInt64(sumRow["WORK_7"]) + System.Convert.ToInt64(row["JUL"]);
                //sumRow["WORK_8"] = System.Convert.ToInt64(sumRow["WORK_8"]) + System.Convert.ToInt64(row["AUG"]);
                //sumRow["WORK_9"] = System.Convert.ToInt64(sumRow["WORK_9"]) + System.Convert.ToInt64(row["SEP"]);
                //sumRow["WORK_10"] = System.Convert.ToInt64(sumRow["WORK_10"]) + System.Convert.ToInt64(row["OCT"]);
                //sumRow["WORK_11"] = System.Convert.ToInt64(sumRow["WORK_11"]) + System.Convert.ToInt64(row["NOV"]);
                //sumRow["WORK_12"] = System.Convert.ToInt64(sumRow["WORK_12"]) + System.Convert.ToInt64(row["DEC"]);

                if (row["JAN"].ToString() == "") row["JAN"] = 0;
                if (row["FEB"].ToString() == "") row["FEB"] = 0;
                if (row["MAR"].ToString() == "") row["MAR"] = 0;
                if (row["APR"].ToString() == "") row["APR"] = 0;
                if (row["MAY"].ToString() == "") row["MAY"] = 0;
                if (row["JUN"].ToString() == "") row["JUN"] = 0;
                if (row["JUL"].ToString() == "") row["JUL"] = 0;
                if (row["AUG"].ToString() == "") row["AUG"] = 0;
                if (row["SEP"].ToString() == "") row["SEP"] = 0;
                if (row["OCT"].ToString() == "") row["OCT"] = 0;
                if (row["NOV"].ToString() == "") row["NOV"] = 0;
                if (row["DEC"].ToString() == "") row["DEC"] = 0;

                sumRow["WORK_1"] = System.Convert.ToInt64(row["JAN"]);
                sumRow["WORK_2"] = System.Convert.ToInt64(row["FEB"]);
                sumRow["WORK_3"] = System.Convert.ToInt64(row["MAR"]);
                sumRow["WORK_4"] = System.Convert.ToInt64(row["APR"]);
                sumRow["WORK_5"] = System.Convert.ToInt64(row["MAY"]);
                sumRow["WORK_6"] = System.Convert.ToInt64(row["JUN"]);
                sumRow["WORK_7"] = System.Convert.ToInt64(row["JUL"]);
                sumRow["WORK_8"] = System.Convert.ToInt64(row["AUG"]);
                sumRow["WORK_9"] = System.Convert.ToInt64(row["SEP"]);
                sumRow["WORK_10"] = System.Convert.ToInt64(row["OCT"]);
                sumRow["WORK_11"] = System.Convert.ToInt64(row["NOV"]);
                sumRow["WORK_12"] = System.Convert.ToInt64(row["DEC"]);

                double sum = System.Convert.ToInt64(sumRow["WORK_1"]) + System.Convert.ToInt64(sumRow["WORK_2"]) + System.Convert.ToInt64(sumRow["WORK_3"]) + System.Convert.ToInt64(sumRow["WORK_4"])
                                 + System.Convert.ToInt64(sumRow["WORK_5"]) + System.Convert.ToInt64(sumRow["WORK_6"]) + System.Convert.ToInt64(sumRow["WORK_7"]) + System.Convert.ToInt64(sumRow["WORK_8"])
                                 + System.Convert.ToInt64(sumRow["WORK_9"]) + System.Convert.ToInt64(sumRow["WORK_10"]) + System.Convert.ToInt64(sumRow["WORK_11"]) + System.Convert.ToInt64(sumRow["WORK_12"]);

                sumRow["WORK_SUM"] = sum;

                //}
            }

            gridTable.Rows.Add(sumRow);


            sumRow = gridTable.NewRow();
            sumRow["FLAG"] = "PREV_SUM2";
            sumRow["TYPE"] = prev2 + "년도 매출액";

            i = 0;
            foreach (DataRow row in prevTable2.Rows)
            {
                if (i > 0) break;
                i++;

                //DataRow[] rows = gridTable.Select("FLAG = 'PREV_SUM2'");

                //if (rows.Length > 0)
                //{
                //sumRow["WORK_1"] = System.Convert.ToInt64(sumRow["WORK_1"]) + System.Convert.ToInt64(row["JAN"]);
                //sumRow["WORK_2"] = System.Convert.ToInt64(sumRow["WORK_2"]) + System.Convert.ToInt64(row["FEB"]);
                //sumRow["WORK_3"] = System.Convert.ToInt64(sumRow["WORK_3"]) + System.Convert.ToInt64(row["MAR"]);
                //sumRow["WORK_4"] = System.Convert.ToInt64(sumRow["WORK_4"]) + System.Convert.ToInt64(row["APR"]);
                //sumRow["WORK_5"] = System.Convert.ToInt64(sumRow["WORK_5"]) + System.Convert.ToInt64(row["MAY"]);
                //sumRow["WORK_6"] = System.Convert.ToInt64(sumRow["WORK_6"]) + System.Convert.ToInt64(row["JUN"]);
                //sumRow["WORK_7"] = System.Convert.ToInt64(sumRow["WORK_7"]) + System.Convert.ToInt64(row["JUL"]);
                //sumRow["WORK_8"] = System.Convert.ToInt64(sumRow["WORK_8"]) + System.Convert.ToInt64(row["AUG"]);
                //sumRow["WORK_9"] = System.Convert.ToInt64(sumRow["WORK_9"]) + System.Convert.ToInt64(row["SEP"]);
                //sumRow["WORK_10"] = System.Convert.ToInt64(sumRow["WORK_10"]) + System.Convert.ToInt64(row["OCT"]);
                //sumRow["WORK_11"] = System.Convert.ToInt64(sumRow["WORK_11"]) + System.Convert.ToInt64(row["NOV"]);
                //sumRow["WORK_12"] = System.Convert.ToInt64(sumRow["WORK_12"]) + System.Convert.ToInt64(row["DEC"]);

                if (row["JAN"].ToString() == "") row["JAN"] = 0;
                if (row["FEB"].ToString() == "") row["FEB"] = 0;
                if (row["MAR"].ToString() == "") row["MAR"] = 0;
                if (row["APR"].ToString() == "") row["APR"] = 0;
                if (row["MAY"].ToString() == "") row["MAY"] = 0;
                if (row["JUN"].ToString() == "") row["JUN"] = 0;
                if (row["JUL"].ToString() == "") row["JUL"] = 0;
                if (row["AUG"].ToString() == "") row["AUG"] = 0;
                if (row["SEP"].ToString() == "") row["SEP"] = 0;
                if (row["OCT"].ToString() == "") row["OCT"] = 0;
                if (row["NOV"].ToString() == "") row["NOV"] = 0;
                if (row["DEC"].ToString() == "") row["DEC"] = 0;

                sumRow["WORK_1"] = System.Convert.ToInt64(row["JAN"]);
                sumRow["WORK_2"] = System.Convert.ToInt64(row["FEB"]);
                sumRow["WORK_3"] = System.Convert.ToInt64(row["MAR"]);
                sumRow["WORK_4"] = System.Convert.ToInt64(row["APR"]);
                sumRow["WORK_5"] = System.Convert.ToInt64(row["MAY"]);
                sumRow["WORK_6"] = System.Convert.ToInt64(row["JUN"]);
                sumRow["WORK_7"] = System.Convert.ToInt64(row["JUL"]);
                sumRow["WORK_8"] = System.Convert.ToInt64(row["AUG"]);
                sumRow["WORK_9"] = System.Convert.ToInt64(row["SEP"]);
                sumRow["WORK_10"] = System.Convert.ToInt64(row["OCT"]);
                sumRow["WORK_11"] = System.Convert.ToInt64(row["NOV"]);
                sumRow["WORK_12"] = System.Convert.ToInt64(row["DEC"]);

                double sum = System.Convert.ToInt64(sumRow["WORK_1"]) + System.Convert.ToInt64(sumRow["WORK_2"]) + System.Convert.ToInt64(sumRow["WORK_3"]) + System.Convert.ToInt64(sumRow["WORK_4"])
                             + System.Convert.ToInt64(sumRow["WORK_5"]) + System.Convert.ToInt64(sumRow["WORK_6"]) + System.Convert.ToInt64(sumRow["WORK_7"]) + System.Convert.ToInt64(sumRow["WORK_8"])
                             + System.Convert.ToInt64(sumRow["WORK_9"]) + System.Convert.ToInt64(sumRow["WORK_10"]) + System.Convert.ToInt64(sumRow["WORK_11"]) + System.Convert.ToInt64(sumRow["WORK_12"]);

                sumRow["WORK_SUM"] = sum;
                //}
            }

            gridTable.Rows.Add(sumRow);

            return gridTable;
        }
    }
}
