using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ControlManager;

namespace ORD
{
    public sealed partial class ORD03A_D0A : BaseMenuDialog
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

        public ORD03A_D0A(DataRow linkRow)
        {
            InitializeComponent();

            _linkRow = linkRow;
        }



        public override void DialogInit()
        {

            acDateEdit1.EditValue = acDateEdit.GetNowDateFromServer();

            acEmp1.Value = acInfo.UserID;

            acLayoutControl1.GetEditor("PO_NO").Value = _linkRow["PO_NO"];

            base.DialogInit();


        }




        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //저장
            try
            {                

                this.OutputData = acLayoutControl1.CreateParameterRow();


                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }

        }


    }
}