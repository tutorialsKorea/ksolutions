using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using ControlManager;
using System.Data;

namespace REPORT
{
    public sealed partial class FRM_A0009 : acReport
    {
        public FRM_A0009()
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

            FRM_A0002_DS newDatasource = new FRM_A0002_DS();

            FRM_A0002_DS.MRow mRow = newDatasource.M.NewMRow();

            mRow.VEN_NAME = originalMasterRow["VEN_NAME"].toStringEmpty();

            mRow.BALJU_NUM = originalMasterRow["BALJU_NUM"].toStringEmpty();

            mRow.BALJU_DATE = originalMasterRow["BALJU_DATE"].toDateString("yyyy-MM-dd");

            decimal totalAmt = 0;

            int cnt = 1;

            foreach (DataRow row in original.Tables["D"].Rows)
            {
                FRM_A0002_DS.DRow newRow = newDatasource.D.NewDRow();

                newRow.SEQ = cnt;

                string cvnd_name = string.Empty;

                if (row["CVND_NAME"].toStringEmpty() != "")
                {
                    cvnd_name = row["CVND_NAME"].ToString();

                    if (cvnd_name.StartsWith("("))
                        cvnd_name = cvnd_name.Length > 5 ? cvnd_name.Substring(0, 5) : cvnd_name;
                    else
                        cvnd_name = cvnd_name.Length > 3 ? cvnd_name.Substring(0, 3) : cvnd_name;

                    //newRow.ITEM_CODE = row["ITEM_CODE"].toStringEmpty() + "\r\n" + (row["CVND_NAME"].ToString().Length >= 3 ? row["CVND_NAME"].ToString().Substring(0, 3) : row["CVND_NAME"].ToString());
                    newRow.ITEM_CODE = row["ITEM_CODE"].toStringEmpty() + "\r\n" + cvnd_name;

                }
                else
                {
                    newRow.ITEM_CODE = row["ITEM_CODE"].toStringEmpty() + "\r\n ";
                }

                if (row["DRAW_NO"].toStringEmpty() != "")
                {
                    newRow.PART_NAME = row["PART_NAME"].toStringEmpty() + "\r\n" + row["DRAW_NO"].toStringEmpty();
                }
                else
                {
                    newRow.PART_NAME = row["PART_NAME"].toStringEmpty() + "\r\n ";
                }
                
                //newRow.DRAW_NO = row["DRAW_NO"].toStringEmpty();
                
                newRow.B_MAT_SPEC = row["B_MAT_SPEC"].toStringEmpty();
                
                newRow.PART_QLTY_NAME = row["PART_QLTY_NAME"].toStringEmpty();

                newRow.QTY = row["QTY"].toInt();

                newRow.B_WEIGHT = row["B_WEIGHT"].toDecimal();

                newRow.Calc_WEIGHT = row["QTY"].toInt() * row["B_WEIGHT"].toDecimal();

                newRow.UNIT_COST = row["UNIT_COST"].toDecimal();

                newRow.AMT = row["AMT"].toDecimal();

                newRow.DUE_DATE = acDateEdit.GetFomattedDateTime(row["DUE_DATE"].toDateTime(), "MM/dd");

                //newRow.DUE_DATE = row["DUE_DATE"].toDateString("MM/dd");

                newRow.SCOMMENT = row["BAL_SCOMMENT"].toStringEmpty();

                totalAmt = totalAmt + row["AMT"].toDecimal();

                cnt = cnt + 1;

                newDatasource.D.AddDRow(newRow);
            }

            int blankRows = 0;
            cnt = cnt - 1;
            int firstRowCnt = 6;
            int nextRowCnt = 9;

            if (cnt >= firstRowCnt)
            {
                blankRows = nextRowCnt - ((cnt - firstRowCnt) % nextRowCnt);
            }
            else
            {
                blankRows = firstRowCnt - cnt;

                xrTable6.SizeF = new SizeF(xrTable6.SizeF.Width, xrTable6.SizeF.Height + 30);

            }

            for (int i = 0; i < (blankRows -1); i++)
            {
                FRM_A0002_DS.DRow newRow = newDatasource.D.NewDRow();

                newRow.ITEM_CODE = " ";

                newDatasource.D.AddDRow(newRow);
            }

            mRow.TOTAL_AMT = totalAmt;

            mRow.DELIVERY_LOCATION = "\r\n ※ 주의사항 ※ \r\n 1. " + originalMasterRow["DELIVERY_LOCATION"].toStringEmpty() + " 납품.(거래명세서에 발주번호 반드시 표기 요망!)"
                                       + "\r\n 2. 제품 물류운반시 찍힘발생 등 주의 요망! \r\n 3. 납기 늦어지는 품목에 대해 사전 통보 요망!";

            newDatasource.M.AddMRow(mRow);
            

            return newDatasource;


        }
    }
}
