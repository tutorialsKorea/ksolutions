using BizExecute;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BREP
{
    public class REP04A
    {
        public static DataSet REP04A_SER(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
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

                DataTable dtRslt = DORD.TORD_PRODUCT_QUERY.TORD_PRODUCT_QUERY18(paramDS.Tables["RQSTDT"], bizExecute);

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

                paramDS.Tables.Add(SocketTable);
                paramDS.Tables.Add(pinBlockTable);
                paramDS.Tables.Add(partTable);

                return paramDS;
            }
            catch (Exception ex)
            {
                throw UTIL.SetException(ex, new System.Diagnostics.StackFrame().GetMethod().Name);
            }
        }

        public static DataSet REP04A_SER2(DataSet paramDS, BizExecute.BizExecute bizExecute)
        {
            try
            {
                DataTable cloneTable = new DataTable();
                cloneTable.Columns.Add("PLT_CODE", typeof(String));
                cloneTable.Columns.Add("FLAG", typeof(String));
                cloneTable.Columns.Add("WORK_LOC_NAME", typeof(String));
                cloneTable.Columns.Add("EMP_CODE", typeof(String));
                cloneTable.Columns.Add("EMP_NAME", typeof(String));
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

                DataTable dtRslt = DORD.TORD_PRODUCT_QUERY.TORD_PRODUCT_QUERY18(paramDS.Tables["RQSTDT"], bizExecute);

                /*
                 0 : Socket
                 1 : Pin Block
                 2 : Jig
                 3 : Part Assy
                 4 : Parts
                 5 : Sales Pin
                 6 : Actuator
                */

                DataTable gridTable = cloneTable.Clone();

                foreach (DataRow row in dtRslt.Rows)
                {
                    DataRow[] rows = gridTable.Select("EMP_CODE = '" + row["EMP_CODE"].ToString() + "'");

                    if (rows.Length == 0)
                    {
                        DataRow newRow = gridTable.NewRow();
                        newRow["FLAG"] = "0";
                        newRow["TYPE"] = "Socket 모델수";
                        newRow["WORK_LOC_NAME"] = row["WORK_LOC_NAME"];
                        newRow["EMP_CODE"] = row["EMP_CODE"];
                        newRow["EMP_NAME"] = row["EMP_NAME"];
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
                        gridTable.Rows.Add(newRow);

                        newRow = gridTable.NewRow();
                        newRow["FLAG"] = "0";
                        newRow["TYPE"] = "Socket 부품수";
                        newRow["WORK_LOC_NAME"] = row["WORK_LOC_NAME"];
                        newRow["EMP_CODE"] = row["EMP_CODE"];
                        newRow["EMP_NAME"] = row["EMP_NAME"];
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
                        gridTable.Rows.Add(newRow);

                        newRow = gridTable.NewRow();
                        newRow["FLAG"] = "1";
                        newRow["TYPE"] = "Pin Block 모델수";
                        newRow["WORK_LOC_NAME"] = row["WORK_LOC_NAME"];
                        newRow["EMP_CODE"] = row["EMP_CODE"];
                        newRow["EMP_NAME"] = row["EMP_NAME"];
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
                        gridTable.Rows.Add(newRow);

                        newRow = gridTable.NewRow();
                        newRow["FLAG"] = "1";
                        newRow["TYPE"] = "Pin Block 부품수";
                        newRow["WORK_LOC_NAME"] = row["WORK_LOC_NAME"];
                        newRow["EMP_CODE"] = row["EMP_CODE"];
                        newRow["EMP_NAME"] = row["EMP_NAME"];
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
                        gridTable.Rows.Add(newRow);

                        newRow = gridTable.NewRow();
                        newRow["FLAG"] = "2";
                        newRow["TYPE"] = "Jig 모델수";
                        newRow["WORK_LOC_NAME"] = row["WORK_LOC_NAME"];
                        newRow["EMP_CODE"] = row["EMP_CODE"];
                        newRow["EMP_NAME"] = row["EMP_NAME"];
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
                        gridTable.Rows.Add(newRow);

                        newRow = gridTable.NewRow();
                        newRow["FLAG"] = "2";
                        newRow["TYPE"] = "Jig 부품수";
                        newRow["WORK_LOC_NAME"] = row["WORK_LOC_NAME"];
                        newRow["EMP_CODE"] = row["EMP_CODE"];
                        newRow["EMP_NAME"] = row["EMP_NAME"];
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
                        gridTable.Rows.Add(newRow);

                        newRow = gridTable.NewRow();
                        newRow["FLAG"] = "4";
                        newRow["TYPE"] = "Part 모델수";
                        newRow["WORK_LOC_NAME"] = row["WORK_LOC_NAME"];
                        newRow["EMP_CODE"] = row["EMP_CODE"];
                        newRow["EMP_NAME"] = row["EMP_NAME"];
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
                        gridTable.Rows.Add(newRow);

                        newRow = gridTable.NewRow();
                        newRow["FLAG"] = "4";
                        newRow["TYPE"] = "Part 부품수";
                        newRow["WORK_LOC_NAME"] = row["WORK_LOC_NAME"];
                        newRow["EMP_CODE"] = row["EMP_CODE"];
                        newRow["EMP_NAME"] = row["EMP_NAME"];
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
                        gridTable.Rows.Add(newRow);
                    }

                    DataRow[] rows2 = gridTable.Select("FLAG = '" + row["PROD_TYPE"].ToString() + "' AND EMP_CODE = '" + row["EMP_CODE"].ToString() + "'");

                    if (rows2.Length == 2)
                    {
                        if (row["ORD_MONTH"].ToString().Substring(4, 2) == "01") rows2[0]["WORK_1"] = rows2[0]["WORK_1"].toInt() + row["ORD_QTY"].toInt();
                        if (row["ORD_MONTH"].ToString().Substring(4, 2) == "02") rows2[0]["WORK_2"] = rows2[0]["WORK_2"].toInt() + row["ORD_QTY"].toInt();
                        if (row["ORD_MONTH"].ToString().Substring(4, 2) == "03") rows2[0]["WORK_3"] = rows2[0]["WORK_3"].toInt() + row["ORD_QTY"].toInt();
                        if (row["ORD_MONTH"].ToString().Substring(4, 2) == "04") rows2[0]["WORK_4"] = rows2[0]["WORK_4"].toInt() + row["ORD_QTY"].toInt();
                        if (row["ORD_MONTH"].ToString().Substring(4, 2) == "05") rows2[0]["WORK_5"] = rows2[0]["WORK_5"].toInt() + row["ORD_QTY"].toInt();
                        if (row["ORD_MONTH"].ToString().Substring(4, 2) == "06") rows2[0]["WORK_6"] = rows2[0]["WORK_6"].toInt() + row["ORD_QTY"].toInt();
                        if (row["ORD_MONTH"].ToString().Substring(4, 2) == "07") rows2[0]["WORK_7"] = rows2[0]["WORK_7"].toInt() + row["ORD_QTY"].toInt();
                        if (row["ORD_MONTH"].ToString().Substring(4, 2) == "08") rows2[0]["WORK_8"] = rows2[0]["WORK_8"].toInt() + row["ORD_QTY"].toInt();
                        if (row["ORD_MONTH"].ToString().Substring(4, 2) == "09") rows2[0]["WORK_9"] = rows2[0]["WORK_9"].toInt() + row["ORD_QTY"].toInt();
                        if (row["ORD_MONTH"].ToString().Substring(4, 2) == "10") rows2[0]["WORK_10"] = rows2[0]["WORK_10"].toInt() + row["ORD_QTY"].toInt();
                        if (row["ORD_MONTH"].ToString().Substring(4, 2) == "11") rows2[0]["WORK_11"] = rows2[0]["WORK_11"].toInt() + row["ORD_QTY"].toInt();
                        if (row["ORD_MONTH"].ToString().Substring(4, 2) == "12") rows2[0]["WORK_12"] = rows2[0]["WORK_12"].toInt() + row["ORD_QTY"].toInt();

                        double sum = rows2[0]["WORK_1"].toInt() + rows2[0]["WORK_2"].toInt() + rows2[0]["WORK_3"].toInt() + rows2[0]["WORK_4"].toInt()
                                    + rows2[0]["WORK_5"].toInt() + rows2[0]["WORK_6"].toInt() + rows2[0]["WORK_7"].toInt() + rows2[0]["WORK_8"].toInt()
                                    + rows2[0]["WORK_9"].toInt() + rows2[0]["WORK_10"].toInt() + rows2[0]["WORK_11"].toInt() + rows2[0]["WORK_12"].toInt();

                        rows2[0]["WORK_SUM"] = sum;

                        if (row["ORD_MONTH"].ToString().Substring(4, 2) == "01") rows2[1]["WORK_1"] = rows2[1]["WORK_1"].toInt() + row["PART_QTY"].toInt();
                        if (row["ORD_MONTH"].ToString().Substring(4, 2) == "02") rows2[1]["WORK_2"] = rows2[1]["WORK_2"].toInt() + row["PART_QTY"].toInt();
                        if (row["ORD_MONTH"].ToString().Substring(4, 2) == "03") rows2[1]["WORK_3"] = rows2[1]["WORK_3"].toInt() + row["PART_QTY"].toInt();
                        if (row["ORD_MONTH"].ToString().Substring(4, 2) == "04") rows2[1]["WORK_4"] = rows2[1]["WORK_4"].toInt() + row["PART_QTY"].toInt();
                        if (row["ORD_MONTH"].ToString().Substring(4, 2) == "05") rows2[1]["WORK_5"] = rows2[1]["WORK_5"].toInt() + row["PART_QTY"].toInt();
                        if (row["ORD_MONTH"].ToString().Substring(4, 2) == "06") rows2[1]["WORK_6"] = rows2[1]["WORK_6"].toInt() + row["PART_QTY"].toInt();
                        if (row["ORD_MONTH"].ToString().Substring(4, 2) == "07") rows2[1]["WORK_7"] = rows2[1]["WORK_7"].toInt() + row["PART_QTY"].toInt();
                        if (row["ORD_MONTH"].ToString().Substring(4, 2) == "08") rows2[1]["WORK_8"] = rows2[1]["WORK_8"].toInt() + row["PART_QTY"].toInt();
                        if (row["ORD_MONTH"].ToString().Substring(4, 2) == "09") rows2[1]["WORK_9"] = rows2[1]["WORK_9"].toInt() + row["PART_QTY"].toInt();
                        if (row["ORD_MONTH"].ToString().Substring(4, 2) == "10") rows2[1]["WORK_10"] = rows2[1]["WORK_10"].toInt() + row["PART_QTY"].toInt();
                        if (row["ORD_MONTH"].ToString().Substring(4, 2) == "11") rows2[1]["WORK_11"] = rows2[1]["WORK_11"].toInt() + row["PART_QTY"].toInt();
                        if (row["ORD_MONTH"].ToString().Substring(4, 2) == "12") rows2[1]["WORK_12"] = rows2[1]["WORK_12"].toInt() + row["PART_QTY"].toInt();

                        double sum2 = rows2[1]["WORK_1"].toInt() + rows2[1]["WORK_2"].toInt() + rows2[1]["WORK_3"].toInt() + rows2[1]["WORK_4"].toInt()
                                    + rows2[1]["WORK_5"].toInt() + rows2[1]["WORK_6"].toInt() + rows2[1]["WORK_7"].toInt() + rows2[1]["WORK_8"].toInt()
                                    + rows2[1]["WORK_9"].toInt() + rows2[1]["WORK_10"].toInt() + rows2[1]["WORK_11"].toInt() + rows2[1]["WORK_12"].toInt();

                        rows2[1]["WORK_SUM"] = sum2;

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
    }
}
