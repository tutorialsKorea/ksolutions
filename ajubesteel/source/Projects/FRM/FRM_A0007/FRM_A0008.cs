using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using ControlManager;
using System.Data;



namespace REPORT
{
    public sealed partial class FRM_A0008 : acReport
    {
        public FRM_A0008()
        {
            InitializeComponent();
        }

        public override object DataSourceProcess(object datasource)
        {

            if (datasource == null)
            {
                return datasource;
            }

            DataRow myVendor = acReportHelper.acVendor.GetMyVendor();
                
            DataSet original = datasource as DataSet;

            FRM_A0008_DS newDatasource = new FRM_A0008_DS();

            foreach (DataRow row in original.Tables["M"].Rows)
            {
                FRM_A0008_DS.MRow mRow = newDatasource.M.NewMRow();

                mRow.PAGE_INFO = row["PAGE_INFO"].toStringEmpty();

                DateTime dt = original.Tables["M"].Rows[0]["SHIP_DATE"].toDateTime();

                mRow.ITEM_CODE = "No. " + original.Tables["M"].Rows[0]["ITEM_CODE"].toStringEmpty();

                mRow.DAY = dt.toDateString("yyyy-MM-dd") + "(" + WeekDay(dt) + ")";

                mRow.CVND_NAME = original.Tables["M"].Rows[0]["CVND_NAME"].toStringEmpty();

                mRow.VEN_ADDRESS = original.Tables["M"].Rows[0]["VEN_ADDRESS"].toStringEmpty();

                mRow.VEN_TEL = original.Tables["M"].Rows[0]["VEN_TEL"].toStringEmpty();

                mRow.VEN_FAX = original.Tables["M"].Rows[0]["VEN_FAX"].toStringEmpty();

                mRow.SELF_BIZ_NO = myVendor["VEN_BIZ_NO"].toStringEmpty();

                mRow.SELF_VEN_NAME = myVendor["VEN_NAME"].toStringEmpty();

                mRow.SELF_VEN_CEO = myVendor["VEN_CEO"].toStringEmpty();

                mRow.SELF_VEN_ADDRESS = myVendor["VEN_ADDRESS"].toStringEmpty();

                mRow.SELF_VEN_CONDITIONS = acInfo.StdCodes.GetNameByCode("C017", myVendor["VEN_CONDITIONS"]); 

                mRow.SELF_VEN_PRODUCTS = myVendor["VEN_PRODUCTS"].toStringEmpty();

                mRow.SELF_VEN_TEL = myVendor["VEN_TEL"].toStringEmpty();

                mRow.SELF_VEN_FAX = myVendor["VEN_FAX"].toStringEmpty();

                mRow.PROJECT = original.Tables["M"].Rows[0]["ITEM_NAME"].toStringEmpty();

                mRow.BALJU_NUM = original.Tables["M"].Rows[0]["BALJU_NUM"].toStringEmpty();

                mRow.SCOMMENT = original.Tables["M"].Rows[0]["ITEM_SCOMMENT"].toStringEmpty();

                newDatasource.M.AddMRow(mRow);
            }


            int cnt = 1;
            int pageInfo = 0;
            decimal totalAmt = 0;
            foreach (DataRow row in original.Tables["D"].Rows)
            {
                FRM_A0008_DS.DRow newRow = newDatasource.D.NewDRow();

                newRow.PAGE_INFO = row["PAGE_INFO"].toStringEmpty();

                newRow.SHIP_DATE = row["SHIP_DATE"].toDateString("MM-dd");

                newRow.PART_NAME = row["PART_NAME"].toStringEmpty();

                newRow.PART_CODE = row["DRAW_NO"].toStringEmpty();

                newRow.SHIP_QTY = row["SHIP_QTY"].toInt();

                newRow.PROD_UC = row["UNIT_COST"].toDecimal();

                newRow.SHIP_COST = row["AMT"].toDecimal();

                newRow.PROD_VAT = row["PROD_VAT"].toDecimal();

                totalAmt = totalAmt + row["AMT"].toDecimal() + row["PROD_VAT"].toDecimal();

                pageInfo = row["PAGE_INFO"].toInt();

                newDatasource.D.AddDRow(newRow);

                cnt++;
            }

            FRM_A0008_DS.TRow tRow = newDatasource.T.NewTRow();

            tRow["TOTAL_AMT"] = totalAmt;

            newDatasource.T.AddTRow(tRow);

            

            int blankRows = 0;
            cnt = cnt - 1;
            if (cnt > 9)
            {
                if ((cnt % 9) != 0)
                {
                    blankRows = 9 - (cnt % 9);
                }
                else
                {
                    blankRows = 0;
                }

            }
            else
            {
                blankRows = 9 - cnt;
            }

            for (int i = 0; i < blankRows; i++)
            {
                FRM_A0008_DS.DRow newRow = newDatasource.D.NewDRow();

                newRow.PART_NAME = " ";
                newRow.PAGE_INFO = pageInfo.toStringEmpty();

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
                    tempWeekDay = "월";
                    break;

                case DayOfWeek.Tuesday: //화
                    tempWeekDay = "화";
                    break;

                case DayOfWeek.Wednesday: //수
                    tempWeekDay = "수";
                    break;

                case DayOfWeek.Thursday: //목
                    tempWeekDay = "목";
                    break;

                case DayOfWeek.Friday: //금
                    tempWeekDay = "금";
                    break;

                case DayOfWeek.Saturday: //토
                    tempWeekDay = "토";
                    break;

                case DayOfWeek.Sunday: //일
                    tempWeekDay = "일";
                    break;

            }

            return tempWeekDay;
        }

    }
}
