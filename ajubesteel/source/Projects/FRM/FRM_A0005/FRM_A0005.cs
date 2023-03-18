using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using ControlManager;
using System.Data;

namespace REPORT
{
    public sealed partial class FRM_A0005 : acReport
    {
        public FRM_A0005()
        {
            InitializeComponent();
        }

        public override object DataSourceProcess(object datasource)
        {

            if (datasource == null)
            {
                return datasource;
            }

            DataSet original = datasource as DataSet;

            DataRow originalMasterRow = original.Tables["M"].Rows[0];

            FRM_A0005_DS newDatasource = new FRM_A0005_DS();

            FRM_A0005_DS.MRow mRow = newDatasource.M.NewMRow();

            DateTime dt = originalMasterRow["DAY"].toDateTime();

            mRow.DAY = dt.toDateString("yyyy") + " 년   " + dt.toDateString("MM") + " 월   " + dt.toDateString("dd") + " 일   ";

            newDatasource.M.AddMRow(mRow);

            int cnt = 1;

            string old_org = "";

            string old_group = "";
            int group_cnt = 1;

            foreach (DataRow row in original.Tables["D"].Rows)
            {
                FRM_A0005_DS.DRow newRow = newDatasource.D.NewDRow();

                newRow.SEQ = cnt;

                if (old_org != row["ORG_CODE"].toStringEmpty())
                {
                    old_org = row["ORG_CODE"].toStringEmpty();
                    group_cnt = 0;
                }

                if (row["ORG_CODE"].toStringEmpty() == "생산부3")
                {
                    if (old_group != row["EMP_NAME"].toStringEmpty())
                    {
                        old_group = row["EMP_NAME"].toStringEmpty();
                        group_cnt++;
                    }
                }
                else
                {
                    if (old_group != row["MC_NAME"].toStringEmpty())
                    {
                        old_group = row["MC_NAME"].toStringEmpty();
                        group_cnt++;
                    }
                }

                

                if (row["ORG_CODE"].toStringEmpty() == "생산부3")
                    newRow.GROUP_NAME = group_cnt.ToString() +". " + row["EMP_NAME"].toStringEmpty();
                else
                    newRow.GROUP_NAME = group_cnt.ToString() +". " + row["MC_NAME"].toStringEmpty();

                newRow.ORG_NAME = row["ORG_NAME"].toStringEmpty();

                newRow.CVND_NAME = row["CVND_NAME"].toStringEmpty();

                newRow.ITEM_CODE = row["ITEM_CODE"].toStringEmpty();

                newRow.PART_PRODTYPE = acInfo.StdCodes.GetNameByCode("M007", row["PART_PRODTYPE"]);

                newRow.MAT_TYPE = acInfo.StdCodes.GetNameByCode("S016", row["MAT_TYPE"]);

                newRow.PART_CODE = row["PART_CODE"].toStringEmpty();

                newRow.PART_NAME = row["PART_NAME"].toStringEmpty();

                newRow.PLN_QTY = row["PLN_QTY"].toInt();

                newRow.DUMMY_PLN_QTY = row["DUMMY_PLN_QTY"].toInt();
                
                newRow.OK_QTY = row["OK_QTY"].toInt();
                
                newRow.TOTAL_OK_QTY = row["TOTAL_OK_QTY"].toInt();

                newRow.MAT_WEIGHT1 = row["MAT_WEIGHT1"].toDecimal();

                newRow.PROC_NAME = row["PROC_NAME"].toStringEmpty();

                newRow.MC_NAME = row["MC_NAME"].toStringEmpty();

                newRow.EMP_NAME = row["EMP_NAME"].toStringEmpty();

                newRow.ACT_START_TIME = row["ACT_START_TIME"].toDateString("yy/MM HH:mm");

                newRow.ACT_END_TIME = row["ACT_END_TIME"].toDateString("HH:mm");

                newRow.PRE_START_TIME = row["PRE_START_TIME"].toDateString("HH:mm");

                newRow.PRE_END_TIME = row["PRE_END_TIME"].toDateString("HH:mm");

                newRow.PROC_TIME = row["PROC_TIME"].toInt();

                newRow.ACT_TIME = row["ACT_TIME"].toInt();

                newRow.MAN_TIME = row["MAN_TIME"].toInt();

                newRow.PRE_TIME = row["PRE_TIME"].toInt();

                newRow.IDLE_TIME = row["IDLE_TIME"].toInt();

                newRow.TOTAL_TIME = row["TOTAL_TIME"].toInt();

                newRow.IDLE_CAUSE = row["IDLE_CAUSE"].toStringEmpty();

                newRow.DRAW_NO = row["DRAW_NO"].toStringEmpty();

                newRow.MC_SEQ = row["MC_SEQ"].ToString();

                newDatasource.D.AddDRow(newRow);

                cnt++;
            }
            

            return newDatasource;


        }
        public static string WeekDay(DateTime dateTime)
        {
            string tempWeekDay = "";

            var dt = dateTime.DayOfWeek;

            switch (dt)
            {
                case DayOfWeek.Monday: //월
                    tempWeekDay = "월요일";
                    break;

                case DayOfWeek.Tuesday: //화
                    tempWeekDay = "화요일";
                    break;

                case DayOfWeek.Wednesday: //수
                    tempWeekDay = "수요일";
                    break;

                case DayOfWeek.Thursday: //목
                    tempWeekDay = "목요일";
                    break;

                case DayOfWeek.Friday: //금
                    tempWeekDay = "금요일";
                    break;

                case DayOfWeek.Saturday: //토
                    tempWeekDay = "토요일";
                    break;

                case DayOfWeek.Sunday: //일
                    tempWeekDay = "일요일";
                    break;

            }

            return tempWeekDay;
        }

    }
}
