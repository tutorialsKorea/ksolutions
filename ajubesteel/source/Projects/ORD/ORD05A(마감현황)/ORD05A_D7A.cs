using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;
using DevExpress.XtraEditors.Controls;
using BizManager;
using DevExpress.XtraEditors.Repository;

namespace ORD
{
    public sealed partial class ORD05A_D7A : BaseMenuDialog
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


        private string _type = "TAX";

        private string _prod_code = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type">수금일 등록</param>
        public ORD05A_D7A(string type, string prod_code)
        {
            InitializeComponent();

            this._type = type;

            this._prod_code = prod_code;

            this.Text = "수금일 등록 및 수정";


            acGridView1.GridType = acGridView.emGridType.LIST;
            acGridView1.AddTextEdit("PROD_CODE", "수주번호", "40239", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddDateEdit("BILL_DATE", "발행일자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false, acGridView.emDateMask.SHORT_DATE);
            acGridView1.AddLookUpEmp("BILL_EMP", "발행자", "", false, DevExpress.Utils.HorzAlignment.Center, false, true, false);
            acGridView1.AddTextEdit("BILL_QTY", "수량", "40239", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.NONE);
            acGridView1.AddTextEdit("BILL_AMT", "금액", "", false, DevExpress.Utils.HorzAlignment.Far, false, true, false, acGridView.emTextEditMask.MONEY);
            acGridView1.AddMemoEdit("SCOMMENT", "비고", "", false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, false, false, true, false);
            acGridView1.AddDateEdit("COLLECT_DATE", "수금일", "", false, DevExpress.Utils.HorzAlignment.Center, true, true, false, acGridView.emDateMask.SHORT_DATE);

            acGridView1.AddHidden("BILL_NO", typeof(string));

            acGridView1.KeyColumn = new string[] { "BILL_NO" };


        }

        DataTable dtBillUpdate = null;

        public override void DialogInit()
        {

            DataTable paramTable = new DataTable("RQSTDT");
            paramTable.Columns.Add("PLT_CODE", typeof(String)); //
            paramTable.Columns.Add("BILL_TYPE", typeof(String)); //
            paramTable.Columns.Add("PROD_CODE", typeof(String)); //

            DataRow paramRow = paramTable.NewRow();
            paramRow["PLT_CODE"] = acInfo.PLT_CODE;
            paramRow["BILL_TYPE"] = this._type;
            paramRow["PROD_CODE"] = this._prod_code;

            paramTable.Rows.Add(paramRow);
            DataSet paramSet = new DataSet();
            paramSet.Tables.Add(paramTable);


            DataTable dtBill = BizRun.QBizRun.ExecuteService(this, "ORD05A_SER2", paramSet, "RQSTDT", "RSLTDT").Tables["RSLTDT"];

            dtBillUpdate = dtBill.Clone();

            acGridView1.GridControl.DataSource = dtBill;


            base.DialogInit();

        }



        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장
            try
            {
                acGridView1.EndEditor();

                DataSet dataSet = new DataSet();

                DataTable dtMdfy = acGridView1.GetAddModifyRows();

                foreach(DataRow row in dtMdfy.Rows)
                {
                    DataRow newRow = dtBillUpdate.NewRow();
                    newRow["PLT_CODE"] = acInfo.PLT_CODE;
                    newRow["BILL_NO"] = row["BILL_NO"];
                    newRow["BILL_TYPE"] = row["BILL_TYPE"];
                    newRow["PROD_CODE"] = row["PROD_CODE"];
                    newRow["COLLECT_DATE"] = row["COLLECT_DATE"].toDateString("yyyyMMdd");

                    dtBillUpdate.Rows.Add(newRow);
                }


                if (dtMdfy.Rows.Count == 0)
                {
                    DataRow newRow = dtBillUpdate.NewRow();
                    newRow["PLT_CODE"] = acInfo.PLT_CODE;
                    newRow["PROD_CODE"] = this._prod_code;

                    dtBillUpdate.Rows.Add(newRow);
                }


                dtBillUpdate.TableName = "RQSTDT";
               

                dataSet.Tables.Add(dtBillUpdate);

                this.OutputData = dataSet;

                this.DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


    }
}