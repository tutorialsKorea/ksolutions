using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using ControlManager;
using System.Data;

namespace REPORT
{
    public sealed partial class FRM_A0004 : acReport
    {
        public FRM_A0004()
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

            FRM_A0004_DS newDatasource = new FRM_A0004_DS();

            FRM_A0004_DS.MRow mRow = newDatasource.M.NewMRow();

            DateTime dt = originalMasterRow["DAY"].toDateTime();

            mRow.DAY = dt.toDateString("yyyy") + " 년   " + dt.toDateString("MM") + " 월   " + dt.toDateString("dd") + " 일   " + WeekDay(dt);

            mRow.TOTAL_PERSONS = originalMasterRow["TOTAL_PERSONS"].toStringEmpty();
            
            mRow.ACCIDENT = originalMasterRow["ACCIDENT"].toStringEmpty();
            
            mRow.PERSONS = originalMasterRow["PERSONS"].toStringEmpty();
            
            mRow.ACCIDENT_CONTENTS = originalMasterRow["ACCIDENT_CONTENTS"].toStringEmpty();
            
            mRow.MORNING = originalMasterRow["MORNING"].toStringEmpty();
            
            mRow.AFTERNOON = originalMasterRow["AFTERNOON"].toStringEmpty();
            
            mRow.OVERTIME = originalMasterRow["OVERTIME"].toStringEmpty();
            
            mRow.TOTAL_TIME = (mRow.MORNING.toInt() + mRow.AFTERNOON.toInt() + mRow.OVERTIME.toInt()).toStringEmpty();
            
            mRow.SCOMMENT = originalMasterRow["SCOMMENT"].toStringEmpty();

            newDatasource.M.AddMRow(mRow);

            foreach (DataRow row in original.Tables["D"].Rows)
            {
                FRM_A0004_DS.DRow newRow = newDatasource.D.NewDRow();

                newRow.MC_SEQ = row["MC_SEQ"].toInt();

                if (row["PART_NAME"].toStringEmpty() != "")
                {
                    newRow.PART_NAME = row["PART_NAME"].toStringEmpty();
                }
                else
                {
                    newRow.PART_NAME = "공정없음";
                }

                newRow.MC_NAME = " 기종 : " + row["MC_NAME"].toStringEmpty();

                newRow.ITEM_CODE = row["ITEM_CODE"].toStringEmpty();

                newRow.CVND_NAME = row["CVND_NAME"].toStringEmpty();

                newRow.PART_CODE = row["PART_CODE"].toStringEmpty();

                newRow.DRAW_NO = row["DRAW_NO"].toStringEmpty();

                //newRow.PART_QTY = row["PART_QTY"].toInt();

                newRow.PART_QTY = row["PLAN_QTY"].toInt();

                newRow.ACT_QTY = row["TOTAL_ACT_QTY"].toInt();

                newDatasource.D.AddDRow(newRow);
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
