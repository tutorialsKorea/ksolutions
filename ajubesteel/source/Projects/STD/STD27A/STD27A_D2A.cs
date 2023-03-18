using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using ControlManager;
using BizManager;

namespace STD
{
    public sealed partial class STD27A_D2A : BaseMenuDialog
    {
        public override acBarManager BarManager
        {

            get
            {
                return acBarManager1;
            }

        }


        public override void BarCodeScanInput(string barcode)
        {


        }

        private acGridView _LinkView = null;


        public STD27A_D2A(acGridView linkView)
        {


            InitializeComponent();


            _LinkView = linkView;

            acGridView1.GridType = acGridView.emGridType.FIXED;

            acGridView1.AddCheckEdit("SEL", "선택", "40290", true, true, true, acGridView.emCheckEditDataType._STRING);
            acGridView1.AddTextEdit("UTC_CODE", "임률코드", "0BXLGNK0", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("UTC_NAME", "임률명", "PQB42PSL", true , DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("SCOMMENT", "비고", "ARYZ726K", true , DevExpress.Utils.HorzAlignment.Near, false, true, false, acGridView.emTextEditMask.NONE);


            acGridView2.GridType = acGridView.emGridType.FIXED;

            acGridView2.AddTextEdit("MAN", "유인임률", "N7SYDPE0", true , DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.MONEY);
            acGridView2.AddTextEdit("SELF", "무인임률", "OWFU4DVX", true , DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.MONEY);
            acGridView2.AddTextEdit("OT", "잔업임률", "IGHDSHAT", true , DevExpress.Utils.HorzAlignment.Far, true, true, false, acGridView.emTextEditMask.MONEY);


        }


        public override void DialogInit()
        {


            //acRadioComboBoxEdit1.RadioGroup.AddRadioItem("가산임률", true, "9FGA2LO5", false, string.Empty, "0");
            //acRadioComboBoxEdit1.RadioGroup.AddRadioItem("수동임률", true, "4Y8NXQM5", false, string.Empty, "1");


            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);

            DataSet resultSet = BizRun.QBizRun.ExecuteService(this, "STD27A_SER4", paramSet, "RQSTDT", "RSLTDT");


            acGridView1.GridControl.DataSource = resultSet.Tables["RSLTDT"];

            DataRow newRow = acGridView2.NewRow();

            newRow["MAN"] = 0;
            newRow["SELF"] = 0;
            newRow["OT"] = 0;


            acGridView2.AddRow(newRow);

            acLayoutControl1.GetEditor("UTC_DATE").Value = DateTime.Now;


        }


        private void barItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //특정일 임률 생성

            try
            {
                acGridView1.EndEditor();
                acGridView2.EndEditor();

                if (acLayoutControl1.ValidCheck() == false)
                {
                    return;
                }



                DataRow layoutRow1 = acLayoutControl1.CreateParameterRow();

                DataRow layoutRow2 = acLayoutControl2.CreateParameterRow();

                DataRow layoutRow3 = acLayoutControl3.CreateParameterRow();

                DataRow focusRow = acGridView2.GetFocusedDataRow();

                DataTable paramTable1 = new DataTable("RQSTDT");
                paramTable1.Columns.Add("PLT_CODE", typeof(String)); //
                paramTable1.Columns.Add("UTC_CODE", typeof(String)); //
                paramTable1.Columns.Add("UTC_DATE", typeof(String)); //
                paramTable1.Columns.Add("MAN", typeof(Decimal)); //
                paramTable1.Columns.Add("SELF", typeof(Decimal)); //
                paramTable1.Columns.Add("OT", typeof(Decimal)); //
                paramTable1.Columns.Add("SCOMMENT", typeof(String)); //
                paramTable1.Columns.Add("REG_EMP", typeof(String)); //
                paramTable1.Columns.Add("OVERWRITE", typeof(String)); //


                DataTable paramTable2 = new DataTable("OPT");
                paramTable2.Columns.Add("CREATE_TYPE", typeof(String)); //임률생성형태
                paramTable2.Columns.Add("ADD_COST_PERCENT", typeof(Decimal)); //가산율





                DataView selectedView = acGridView1.GetDataSourceView("SEL = '1'");

                for (int i = 0; selectedView.Count > i; i++)
                {

                    DataRow paramRow1 = paramTable1.NewRow();
                    paramRow1["PLT_CODE"] = acInfo.PLT_CODE;
                    paramRow1["UTC_CODE"] = selectedView[i]["UTC_CODE"];
                    paramRow1["UTC_DATE"] = layoutRow1["UTC_DATE"];
                    paramRow1["MAN"] = focusRow["MAN"];
                    paramRow1["SELF"] = focusRow["SELF"];
                    paramRow1["OT"] = focusRow["OT"];
                    paramRow1["SCOMMENT"] = layoutRow1["SCOMMENT"];
                    paramRow1["REG_EMP"] = acInfo.UserID;
                    paramRow1["OVERWRITE"] = "0";
                    paramTable1.Rows.Add(paramRow1);
                }

                DataRow paramRow2 = paramTable2.NewRow();


                //생성 임률형태
                paramRow2["CREATE_TYPE"] = acTabControl1.GetSelectedContainerName();

                paramRow2["ADD_COST_PERCENT"] = layoutRow2["PERCENT"];


                paramTable2.Rows.Add(paramRow2);


                DataSet paramSet = new DataSet();
                paramSet.Tables.Add(paramTable1);
                paramSet.Tables.Add(paramTable2);
                
                BizRun.QBizRun.ExecuteService(
                this, QBiz.emExecuteType.NEW,
                "STD27A_INS3", paramSet, "RQSTDT,OPT", "RSLTDT",
                QuickSave,
                QuickException);

            }

            catch (Exception ex)
            {

                acMessageBox.Show(this, ex);
            }

        }



        void QuickSave(object sender, QBiz qBiz, QBiz.ExcuteCompleteArgs e)
        {
            try
            {
                foreach (DataRow row in e.result.Tables["RSLTDT"].Rows)
                {
                    this._LinkView.UpdateMapingRow(row, true);
                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }


        void QuickException(object sender, QBiz qBiz, BizManager.BizException ex)
        {
            if (ex.ErrNumber == BizManager.BizException.OVERWRITE || ex.ErrNumber == BizManager.BizException.OVERWRITE_HISTORY)
            {

                if (acMessageBox.Show(acInfo.BizError.GetDesc(ex.ErrNumber), this.Caption, acMessageBox.emMessageBoxType.YESNO) == DialogResult.No)
                {
                    return;
                }


                foreach (DataRow row in qBiz.RefData.Tables["RQSTDT"].Rows)
                {
                    row["OVERWRITE"] = "1";
                }

                qBiz.Start();

            }
            else
            {
                acMessageBox.Show(this, ex);
            }

        }



    }
}