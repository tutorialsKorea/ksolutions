using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ControlManager;
using DevExpress.XtraEditors;
using BizManager;
using System.Linq;

namespace POP
{
    public partial class POP05B_D2A : BaseMenuDialog
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

        public POP05B_D2A()
        {
            InitializeComponent();
        }


        private bool _isEnd = false;
        public override void DialogInit()
        {
            base.DialogInit();
        }
        public override void DialogNew()
        {
            acLayoutControl1.GetEditor("IS_SHIP").Value = "1";
            base.DialogNew();

        }

        public override void DialogOpen()
        {
            base.DialogOpen();
        }

        private void barItemYes_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DataRow layoutRow = acLayoutControl1.CreateParameterRow();

                OutputData = layoutRow;

                DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }

        private void barItemNo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DialogResult = DialogResult.No;

            }
            catch (Exception ex)
            {
                acMessageBox.Show(this, ex);
            }
        }
    }
}