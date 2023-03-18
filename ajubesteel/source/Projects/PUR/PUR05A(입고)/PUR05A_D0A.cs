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
    public sealed partial class PUR05A_D0A : BaseMenuDialog
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

        public PUR05A_D0A()
        {
            InitializeComponent();


        }



        public override void DialogInit()
        {
            //¿‘∞Ì¿œ

            acLayoutControl1.GetEditor("YPGO_DATE").Value = acDateEdit.GetNowDateFromServer();

            acLayoutControl1.GetEditor("YPGO_DATE").isReadyOnly = !this.GetMenuConfig("IS_CHANGE_YPGO_DATE").toBoolean();

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
                int datediff = DateTime.Compare(DateTime.Today, datarow["YPGO_DATE"].toDateTime());

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

