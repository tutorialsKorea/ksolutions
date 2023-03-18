using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using ControlManager;
using System.Data;

namespace REPORT
{
    public sealed partial class FRM_A0003 : acReport
    {
        public FRM_A0003()
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

            FRM_A0003_DS newDatasource = new FRM_A0003_DS();

            FRM_A0003_DS.MRow mRow = newDatasource.M.NewMRow();

            mRow.VEN_NAME = originalMasterRow["VEN_NAME"].toStringEmpty() + " 거래처 원장";

            mRow.VEN_BIZ_NO = originalMasterRow["VEN_BIZ_NO"].toStringEmpty();

            mRow.VEN_ADDRESS = originalMasterRow["VEN_ADDRESS"].toStringEmpty();

            mRow.VEN_TEL_FAX = "TEL : " + originalMasterRow["VEN_TEL"].toStringEmpty() + " , FAX : " + originalMasterRow["VEN_FAX"].toStringEmpty();

            mRow.VEN_CEO = originalMasterRow["VEN_CEO"].toStringEmpty();

            //mRow.VEN_CONDITIONS = originalMasterRow["VEN_CONDITIONS"].toStringEmpty();
            mRow.VEN_CONDITIONS = acInfo.StdCodes.GetNameByCode("C017", originalMasterRow["VEN_CONDITIONS"]);

            mRow.VEN_PRODUCTS = originalMasterRow["VEN_PRODUCTS"].toStringEmpty();

            mRow.VEN_EMAIL = originalMasterRow["VEN_EMAIL"].toStringEmpty();

            mRow.VEN_CHARGE_EMP = originalMasterRow["VEN_CHARGE_EMP"].toStringEmpty();

            mRow.VEN_CHARGE_HP = originalMasterRow["VEN_CHARGE_HP"].toStringEmpty();

            mRow.VEN_CHARGE_TEL = originalMasterRow["VEN_CHARGE_TEL"].toStringEmpty();

            newDatasource.M.AddMRow(mRow);

            foreach (DataRow row in original.Tables["D"].Rows)
            {
                FRM_A0003_DS.DRow newRow = newDatasource.D.NewDRow();


                newRow.DATE = row["DATE"].toDateString("yy/MM/dd");

                newRow.PART_NAME = row["PART_NAME"].toStringEmpty();

                newRow.PART_CODE = row["PART_CODE"].toStringEmpty();

                newRow.B_MAT_SPEC = row["B_MAT_SPEC"].toStringEmpty();

                newRow.QTY = row["QTY"].toInt();

                newRow.UNIT_COST = row["UNIT_COST"].toInt();

                newRow.AMT = row["AMT"].toInt();

                newRow.SCOMMENT = row["SCOMMENT"].toStringEmpty();


                newDatasource.D.AddDRow(newRow);
            }
            

            return newDatasource;


        }
    }
}
