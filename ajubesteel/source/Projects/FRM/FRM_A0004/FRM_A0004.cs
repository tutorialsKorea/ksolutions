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

            mRow.DAY = dt.toDateString("yyyy") + " ��   " + dt.toDateString("MM") + " ��   " + dt.toDateString("dd") + " ��   " + WeekDay(dt);

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
                    newRow.PART_NAME = "��������";
                }

                newRow.MC_NAME = " ���� : " + row["MC_NAME"].toStringEmpty();

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
                case DayOfWeek.Monday: //��
                    tempWeekDay = "������";
                    break;

                case DayOfWeek.Tuesday: //ȭ
                    tempWeekDay = "ȭ����";
                    break;

                case DayOfWeek.Wednesday: //��
                    tempWeekDay = "������";
                    break;

                case DayOfWeek.Thursday: //��
                    tempWeekDay = "�����";
                    break;

                case DayOfWeek.Friday: //��
                    tempWeekDay = "�ݿ���";
                    break;

                case DayOfWeek.Saturday: //��
                    tempWeekDay = "�����";
                    break;

                case DayOfWeek.Sunday: //��
                    tempWeekDay = "�Ͽ���";
                    break;

            }

            return tempWeekDay;
        }

    }
}
