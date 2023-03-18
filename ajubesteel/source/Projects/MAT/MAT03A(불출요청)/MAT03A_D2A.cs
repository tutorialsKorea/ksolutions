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
    public sealed partial class MAT03A_D2A : BaseMenuDialog
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

        public MAT03A_D2A()
        {
            InitializeComponent();

        }

        public override void DialogInit()
        {

            (acLayoutControl1.GetEditor("STK_LOCATION") as acLookupEdit).SetCode("M005");
            
            base.DialogInit();
        }



        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
               
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

