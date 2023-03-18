using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using ControlManager;

namespace PUR
{
    public sealed partial class PUR04A_D1A : BaseMenuDialog
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

        public PUR04A_D1A(DataRow focusRow)
        {
            InitializeComponent();

            acLayoutControl1.DataBind(focusRow, false);
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

                DataRow datarow = acLayoutControl1.CreateParameterRow();

                base.OutputData = datarow;

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }
    }
}

