using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using ControlManager;
using System.Data;

namespace REPORT
{
    public sealed partial class FRM_A0007 : acReport
    {
        public FRM_A0007()
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

            FRM_A0007_DS newDatasource = new FRM_A0007_DS();

            FRM_A0007_DS.MRow mRow = newDatasource.M.NewMRow();

            DateTime dt = originalMasterRow["SHIP_DATE"].toDateTime();

            mRow.DAY = dt.toDateString("yyyy-MM-dd") + "(" + WeekDay(dt) + ")";

            newDatasource.M.AddMRow(mRow);

            int cnt = 1;
            foreach (DataRow row in original.Tables["D"].Rows)
            {
                FRM_A0007_DS.DRow newRow = newDatasource.D.NewDRow();

                //newRow.CVND_NAME = "��ü�� : " + row["CVND_NAME"].toStringEmpty() + "     �ù� �߼� �ּ� : " + row["VEN_ADDRESS3"].toStringEmpty();
                newRow.CVND_NAME = " " + row["CVND_NAME"].toStringEmpty();

                newRow.DELIVERY_ADDR = "��ǰ�ּ� : " + row["VEN_ADDRESS3"].toStringEmpty();

                newRow.ITEM_CODE = row["ITEM_CODE"].toStringEmpty();

                newRow.PART_CODE = row["DRAW_NO"].toStringEmpty();

                newRow.PART_NAME = row["PART_NAME"].toStringEmpty();

                newRow.SHIP_QTY = row["SHIP_QTY"].toInt();

                newRow.SHIP_COST = row["SHIP_COST2"].toDecimal();

                newRow.VEN_TEL = row["VEN_TEL"].toStringEmpty();

                newRow.VEN_CHARGE_EMP = row["VEN_CHARGE_EMP"].toStringEmpty();

                newRow.VEN_CHARGE_HP = row["VEN_CHARGE_HP"].toStringEmpty();

                newRow.DELIVERY = acInfo.StdCodes.GetNameByCode("D002", row["DELIVERY"].toStringEmpty());

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
                case DayOfWeek.Monday: //��
                    tempWeekDay = "��";
                    break;

                case DayOfWeek.Tuesday: //ȭ
                    tempWeekDay = "ȭ";
                    break;

                case DayOfWeek.Wednesday: //��
                    tempWeekDay = "��";
                    break;

                case DayOfWeek.Thursday: //��
                    tempWeekDay = "��";
                    break;

                case DayOfWeek.Friday: //��
                    tempWeekDay = "��";
                    break;

                case DayOfWeek.Saturday: //��
                    tempWeekDay = "��";
                    break;

                case DayOfWeek.Sunday: //��
                    tempWeekDay = "��";
                    break;

            }

            return tempWeekDay;
        }

    }
}
