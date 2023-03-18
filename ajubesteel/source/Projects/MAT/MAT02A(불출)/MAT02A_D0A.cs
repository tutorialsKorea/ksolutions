using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using ControlManager;

namespace MAT
{
    public sealed partial class MAT02A_D0A : BaseMenuDialog
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

        private DataRow _linkRow = null;

        public MAT02A_D0A(DataRow linkRow)
        {
            InitializeComponent();

            _linkRow = linkRow;

            acLayoutControl1.OnValueChanged += acLayoutControl1_OnValueChanged;

            acLayoutControl1.DataBind(linkRow, false);

            acLayoutControl1.GetEditor("OUT_REQ_DATE").Value = acDateEdit.GetNowDateFromServer();

            acLayoutControl1.GetEditor("OUT_REQ_EMP").Value = acInfo.UserID;

            DataRow row = acEmp1.SelectedRow;

            acLayoutControl1.GetEditor("ORG_NAME").Value = row["ORG_NAME"];

            //(acLayoutControl1.GetEditor("STOCK_CODE") as acLookupEdit).SetCode("M005");
        }

        void acLayoutControl1_OnValueChanged(object sender, IBaseEditControl info, object newValue)
        {

            try
            {
                acLayoutControl layout = sender as acLayoutControl;


                switch (info.ColumnName)
                {
                    case "OUT_REQ_EMP":

                        DataRow row = acEmp1.SelectedRow;

                        layout.GetEditor("ORG_NAME").Value = row["ORG_NAME"];

                        break;

                }
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }


        public override void DialogInit()
        {


            base.DialogInit();
        }



        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (acLayoutControl1.ValidCheck() == false)
                {
                    return;
                }

                base.OutputData = acLayoutControl1.CreateParameterRow();

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }
    }
}

