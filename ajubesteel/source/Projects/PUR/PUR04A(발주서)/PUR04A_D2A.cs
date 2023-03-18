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
    public sealed partial class PUR04A_D2A : BaseMenuDialog
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

        public PUR04A_D2A(DataRow focusRow)
        {
            InitializeComponent();

            acLayoutControl1.DataBind(focusRow, false);
            acLayoutControl1.SetAllReadOnly(true);

            acAttachFileControl1.AttachLinkPermission = AttachFileManager.acAttachFileControl.emAttachLinkPermission.D;

            acAttachFileControl1.LinkKey = focusRow["LINK_NO"];
            acAttachFileControl1.ShowKey = new object[] { focusRow["LINK_NO"] };
        }



        public override void DialogInit()
        {
            base.DialogInit();
        }



        private void acBarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }


        }
    }
}

